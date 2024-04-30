'This form is the user interface for the so called Feigenbaum Diagram
'It shows the dependence of the behaviour of the iteration
'from the parameter a
'for certain parameter values, the behaviour is chaotic
'see as well the mathematical documentation

'The form is based on the Interface IIteration 
'that is implemented by ClsTentmap, ClsLogisticGrowth, ClsParabola
'Therefore, more cases of unimodal functions could be easely programmed
'by implementing this interface

'Status Checked

Imports System.Globalization
Imports System.Reflection

Public Class FrmFeigenbaum

    'Prepare basic objects

    'MyBitmapGraphics draws into the Feigenbaum Diagram
    Private FeigenbaumDiagram As Bitmap
    Private MyBitmapGraphics As ClsGraphicTool
    Private Iterator As IIteration

    'Private global variables

    'Parameter Range for the Parameter a
    Private Parameterrange As ClsInterval

    'Value Range for the Iteration Value x
    Private Valuerange As ClsInterval

    'For the Check if the Definitions of the Ranges by the User is OK
    Private IsUserSelectionValid As Boolean

    'Variables for the definition of the Ranges by a selection-rectangle
    Private IsMousedown As Boolean = False

    'Point where the left mouse button was pushed down
    Private UserSelectionStartpoint As Point

    'Point where the left mouse button was released
    Private UserSelectionEndpoint As Point

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub InitializeLanguage()

        Text = Main.LM.GetString("FeigenbaumDiagram")
        ChkColored.Text = Main.LM.GetString("ColoredDiagram")
        ChkSplitPoints.Text = Main.LM.GetString("ShowSplitPoints")
        LblDeltaX.Text = Main.LM.GetString("Delta") & " = "
        LblDeltaA.Text = Main.LM.GetString("Delta") & " = "
        LblValueRange.Text = Main.LM.GetString("ExaminatedValueRange")
        LblPrecision.Text = Main.LM.GetString("Precision") & "; " & (TrbPrecision.Value * 100).ToString(CultureInfo.CurrentCulture)
        LblParameterRange.Text = Main.LM.GetString("ExaminatedParameterRange")
        BtnStartIteration.Text = Main.LM.GetString("StartIteration")
        BtnReset.Text = Main.LM.GetString("ResetIteration")

        CboFunction.Items.Clear()

        'Add the classes implementing IIteration
        'to the Combobox CboPendulum by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IIteration)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If types.Count > 0 Then
            Dim IteratorName As String
            For Each type In types

                'GetString is calle dwith the option IsClass = true
                'That effects that - if there is no Entry in the Resource files LabelsEN, LabelsDE -
                'the name of the Class implementing an Interface is used as default
                'suppressing the extension "Cls"
                IteratorName = Main.LM.GetString(type.Name, True)
                CboFunction.Items.Add(IteratorName)
            Next

            CboFunction.SelectedIndex = CboFunction.Items.Count - 1
            CboFunction.Select()

        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If

    End Sub

    Private Sub FrmFeigenbaum_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Generate objects
        FeigenbaumDiagram = New Bitmap(PicDiagram.Width, PicDiagram.Height)
        PicDiagram.Image = FeigenbaumDiagram
        Iterator = New ClsLogisticGrowth With {
            .Power = 1
        }

        'Initialize Language
        InitializeLanguage()

        'additional default settings
        SetDefaultValues()


    End Sub

    Private Sub SetDefaultValues()

        'if there where User-defined ranges,
        'or the iterator has changed
        'the ranges are reset to the standard
        Parameterrange = Iterator.ParameterInterval
        Valuerange = Iterator.IterationInterval
        MyBitmapGraphics = New ClsGraphicTool(FeigenbaumDiagram, Parameterrange, Valuerange)

        TxtAMin.Text = Parameterrange.A.ToString(CultureInfo.CurrentCulture)
        TxtAMax.Text = Parameterrange.B.ToString(CultureInfo.CurrentCulture)
        LblDeltaA.Text = Main.LM.GetString("Delta") & " = " & Parameterrange.IntervalWidth.ToString(CultureInfo.CurrentCulture)

        TxtXMin.Text = Valuerange.A.ToString(CultureInfo.CurrentCulture)
        TxtXMax.Text = Valuerange.B.ToString(CultureInfo.CurrentCulture)
        LblDeltaX.Text = Main.LM.GetString("Delta") & " = " & Valuerange.IntervalWidth.ToString(CultureInfo.CurrentCulture)

        Resetiteration()

        IsUserSelectionValid = True

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click

        SetDefaultValues()

    End Sub

    Sub Resetiteration()

        'The display is cleared
        'When loading the form, MyBitmapGraphics is maybe not inizialized
        If Not IsNothing(MyBitmapGraphics) Then
            MyBitmapGraphics.Clear(Color.White)
        End If

        PicDiagram.Refresh()

    End Sub

    Private Sub CboFunction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboFunction.SelectedIndexChanged

        'This sets the type of Iterator by Reflection

        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IIteration)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If CboFunction.SelectedIndex >= 0 Then

            Dim SelectedName As String = CboFunction.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If Main.LM.GetString(type.Name, True) = SelectedName Then
                        Iterator = CType(Activator.CreateInstance(type), IIteration)
                    End If
                Next
            End If

        End If

        Iterator.Power = 1

        'Reset ranges and default Values
        SetDefaultValues()

    End Sub

    Private Sub TrbPrecision_ValueChanged(sender As Object, e As EventArgs) Handles TrbPrecision.ValueChanged

        'The precision defines how precise the diagram is generated
        LblPrecision.Text = Main.LM.GetString("Precision") & ": " & (1000 * TrbPrecision.Value).ToString(CultureInfo.CurrentCulture)

    End Sub

    'SECTOR ITERATION

    Private Sub BtnStartIteration_Click(sender As Object, e As EventArgs) Handles BtnStartIteration.Click

        BtnStartIteration.Enabled = False
        BtnReset.Enabled = False

        'Check and set the Ranges, defined by the user
        CheckUserRanges()

        If IsUserSelectionValid Then

            MyBitmapGraphics.Clear(Color.White)

            'In the direction of the x-axis, we work with pixel coordinates
            Dim p As Integer

            For p = 1 To PicDiagram.Width

                'for each p, the according parametervalue a is calculated
                'and then, the iteration runs until RuntimeUntilCycle
                'finally, the iteration cycle is drawn
                DrawIterationCycle(p)

            Next

            'Draw the Splitpoints
            If ChkSplitPoints.Checked Then
                DrawSplitPoints()
            End If

        Else
            'There is already a message generated
        End If

        BtnStartIteration.Enabled = True
        BtnReset.Enabled = True

    End Sub

    Private Sub DrawIterationCycle(p As Integer)

        'The startvalue x for the iteration should be the same for all values of a
        Dim x As Decimal = CDec(Iterator.IterationInterval.A + (Valuerange.IntervalWidth * 0.31415926535))

        'Calculate the parameter a for the iteration depending on p
        Dim a As Decimal = Parameterrange.A + (Parameterrange.IntervalWidth * p / PicDiagram.Width)
        Iterator.Parameter = a

        'First, the iteration runs a while until it gets periodic (if the behaviour is not chaotic)
        Dim RuntimeUntilCycle As Integer = 1000 * TrbPrecision.Value
        For n = 1 To RuntimeUntilCycle - 1
            x = Iterator.FN(x)
        Next

        'After that, the number of iterations must be big enough to draw the cycle
        Dim LengthOfCycle As Integer = CInt(PicDiagram.Height * Valuerange.IntervalWidth _
            * TrbPrecision.Value / 25 / Math.Max(Valuerange.IntervalWidth, 0.01))

        '..but not bigger than the y-axis allows
        LengthOfCycle = Math.Min(LengthOfCycle, 5 * PicDiagram.Height)

        'Finally , the cycle is drawn
        Dim Z As New ClsMathpoint(a, x)

        For n = RuntimeUntilCycle To RuntimeUntilCycle + LengthOfCycle
            MyBitmapGraphics.DrawPoint(Z, SetColor(n), 1)
            x = Iterator.FN(x)
            Z.Y = x
        Next
        PicDiagram.Refresh()

    End Sub

    Private Function SetColor(n As Integer) As Brush

        'It's possible to use two colors for the image
        'The reader can add more colors by programming

        Dim MyBrush As Brush

        If ChkColored.Checked Then
            Select Case n Mod 2
                Case 0
                    MyBrush = Brushes.Blue
                Case Else
                    MyBrush = Brushes.Green
            End Select
        Else
            MyBrush = Brushes.Blue
        End If

        Return MyBrush

    End Function


    'SECTOR MANAGE USER RANGES

    Private Sub PicDiagram_MouseDown(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseDown

        'The user can choose a range by a flexible rectangle
        IsMousedown = True

        'e guarantees, that the mouse position is relative to PicDiagram
        'and the Startpoint is the position, where the left mouse button was first pushed down
        UserSelectionStartpoint = e.Location

    End Sub

    Private Sub PicDiagram_MouseMove(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseMove

        If IsMousedown Then

            'the endpoint is on the actual mouse position
            UserSelectionEndpoint = e.Location

            'this refreshing launches the paint-event of e and the selection-rectangle is drawn
            'in the actual position
            PicDiagram.Refresh()

        End If

    End Sub

    Private Sub PicDiagram_Paint(sender As Object, e As PaintEventArgs) Handles PicDiagram.Paint

        If IsMousedown Then

            'the selection-rectangle is dranw in its actual position
            Dim rect As New Rectangle(Math.Min(UserSelectionStartpoint.X, UserSelectionEndpoint.X), Math.Min(UserSelectionStartpoint.Y, UserSelectionEndpoint.Y),
                                      Math.Abs(UserSelectionStartpoint.X - UserSelectionEndpoint.X), Math.Abs(UserSelectionStartpoint.Y - UserSelectionEndpoint.Y))
            Using MyPen As New Pen(Color.Red, 2)
                e.Graphics.DrawRectangle(MyPen, rect)
            End Using

        End If

    End Sub

    Private Sub PicDiagram_MouseUp(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseUp

        If IsMousedown Then
            IsMousedown = False

            'Now, the final EndPoint is set on the position, where the mouse button was released
            UserSelectionEndpoint = e.Location

            'We have to check, if the selection-rectangle shows a valid selection
            If UserSelectionStartpoint <> UserSelectionEndpoint Then

                'The selection is OK

                'Now, we adjust the interval of p. p moves between pMin and pMax
                Dim pMin As Integer = Math.Min(UserSelectionStartpoint.X, UserSelectionEndpoint.X)
                Dim pMax As Integer = Math.Max(UserSelectionStartpoint.X, UserSelectionEndpoint.X)

                'as well, in direction of the y-axis we have to adjust the relevant interval
                Dim qMin As Integer = Math.Min(PicDiagram.Height - UserSelectionStartpoint.Y, PicDiagram.Height - UserSelectionEndpoint.Y)
                Dim qMax As Integer = Math.Max(PicDiagram.Height - UserSelectionStartpoint.Y, PicDiagram.Height - UserSelectionEndpoint.Y)

                'This rectangle surrounds the selected range
                Dim rect As New Rectangle(pMin, qMin, pMax - pMin, qMax - qMin)

                'transmit the selection to the parameter range
                TxtAMin.Text = Math.Max(PixelToA(pMin), Parameterrange.A).ToString(CultureInfo.CurrentCulture)
                TxtAMax.Text = Math.Min(PixelToA(pMax), Parameterrange.B).ToString(CultureInfo.CurrentCulture)
                LblDeltaA.Text = "Delta = " & (PixelToA(pMax) - PixelToA(pMin)).ToString(CultureInfo.CurrentCulture)

                'transmit the selection to the value range of x
                TxtXMin.Text = Math.Max(PixelToX(qMin), Valuerange.A).ToString(CultureInfo.CurrentCulture)
                TxtXMax.Text = Math.Min(PixelToX(qMax), Valuerange.B).ToString(CultureInfo.CurrentCulture)
                LblDeltaX.Text = "Delta = " & (PixelToX(qMax) - PixelToX(qMin)).ToString(CultureInfo.CurrentCulture)

            End If
        End If

    End Sub

    'SECTOR TRANSFORMATION OF USER RANGES

    Private Function PixelToA(p As Integer) As Decimal

        'calculates the parametervalue a according to p
        Dim a As Decimal = Parameterrange.A + ((p - 1) * Parameterrange.IntervalWidth / PicDiagram.Width)
        Return a

    End Function

    Private Function PixelToX(q As Integer) As Decimal

        'calculates the x-value that belongs to a q-pixel coordinate in y-axis direction
        Dim x As Decimal = CDec(Valuerange.A + (q * Valuerange.IntervalWidth / (PicDiagram.Height * 0.99)))

        Return x

    End Function

    'CHECK USER RANGES AND SET PARAMETER AND VALUE INTERVAL

    Private Sub CheckUserRanges()

        'The parameter range has to be part of the allowed interval for the parameter a
        'depending of the type of iteration
        Dim CheckParameterrange As New ClsCheckIsInterval(TxtAMin, TxtAMax)
        Dim IsParameterrangeValid As Boolean

        'The interval borders have to be numeric and a < b
        If CheckParameterrange.IsIntervalValid Then

            'if [a,b] is an interval, then the parameter interval is constructed
            Dim TempParameterrange = New ClsInterval(CheckParameterrange.A, CheckParameterrange.B)

            'is the parameter range part of the allowed parameter interval?
            If Iterator.ParameterInterval.IsInterval2PartOfInterval(TempParameterrange) Then
                IsParameterrangeValid = True
                'take over
                Parameterrange = TempParameterrange
            Else
                MessageBox.Show(Main.LM.GetString("ParameterRangeNotAllowed") & " [" &
                   Iterator.ParameterInterval.A.ToString(CultureInfo.CurrentCulture) &
                   ", " & Iterator.ParameterInterval.B.ToString(CultureInfo.CurrentCulture) &
                   "] ")
                IsParameterrangeValid = False
            End If
        Else
            IsParameterrangeValid = False
        End If

        Dim IsValuerangeValid As Boolean = False

        If IsParameterrangeValid Then

            'Analogue, the range of the x-value is checked
            Dim CheckValuerange As New ClsCheckIsInterval(TxtXMin, TxtXMax)

            'are the interval borders numeric and is a < b
            If CheckValuerange.IsIntervalValid Then

                'in that case, the value range is constructed
                Dim TempValuerange = New ClsInterval(CheckValuerange.A, CheckValuerange.B)

                'Is the value range part of the allowed value interval?
                If Iterator.IterationInterval.IsInterval2PartOfInterval(TempValuerange) Then
                    IsValuerangeValid = True
                    'take over
                    Valuerange = TempValuerange
                Else
                    MessageBox.Show(Main.LM.GetString("ValueRangeNotAllowed") & " [" &
                       Iterator.IterationInterval.A.ToString(CultureInfo.CurrentCulture) &
                       ", " & Iterator.IterationInterval.B.ToString(CultureInfo.CurrentCulture) &
                       "] ")
                    IsValuerangeValid = False
                End If
            Else
                IsValuerangeValid = False
            End If
        End If

        IsUserSelectionValid = IsParameterrangeValid And IsValuerangeValid

        If IsUserSelectionValid Then
            LblDeltaA.Text = Main.LM.GetString("Delta") & " = " & Parameterrange.IntervalWidth.ToString(CultureInfo.CurrentCulture)
            LblDeltaX.Text = Main.LM.GetString("Delta") & " = " & Valuerange.IntervalWidth.ToString(CultureInfo.CurrentCulture)
            MyBitmapGraphics = New ClsGraphicTool(FeigenbaumDiagram, Parameterrange, Valuerange)
        Else
            'nothing
        End If

    End Sub

    'SECTOR SPLITPOINTS

    Private Sub DrawSplitPoints()

        If IsUserSelectionValid Then

            'the first split points are marked by vertical lines
            Dim Splitpoints As List(Of Decimal) = Iterator.Splitpoints
            Dim i As Integer

            Dim MyDiagramGraphics = New ClsGraphicTool(PicDiagram, Parameterrange, Valuerange)
            Dim A As New ClsMathpoint
            Dim B As New ClsMathpoint

            For i = 0 To Splitpoints.Count - 1
                If Parameterrange.IsNumberInInterval(Splitpoints(i)) Then
                    A.X = Splitpoints(i)
                    A.Y = Valuerange.A
                    B.X = Splitpoints(i)
                    B.Y = Valuerange.B
                    If i < Splitpoints.Count - 1 Then
                        MyDiagramGraphics.DrawLine(A, B, Color.Green, 1)
                    Else
                        MyDiagramGraphics.DrawLine(A, B, Color.Red, 1)
                    End If
                End If
            Next

        Else
            'there is already a message generated
        End If
    End Sub

    Private Sub ChkSplitPoints_Click(sender As Object, e As EventArgs) Handles ChkSplitPoints.Click

        If ChkSplitPoints.Checked Then
            DrawSplitPoints()
        Else
            PicDiagram.Refresh()
        End If

    End Sub

End Class