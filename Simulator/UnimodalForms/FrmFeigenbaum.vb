'This form is the user interface for the so called Feigenbaum Diagram
'It shows the dependence of the behaviour of the iteration
'from the parameter a
'for certain parameter values, the behaviour is chaotic
'see as well the mathematical documentation

'The form is based on an Interface IIteration 
'that is implemented by ClsTentmap, ClsLogisticGrowth, ClsParabola
'Therefore, more cases of unimodal functions could be easely implemented

Imports System.Globalization

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
    Private IsUserinputValid As Boolean

    'Variables for the definition of the Ranges by a selection-rectangle
    Private IsMousedown As Boolean = False

    'Point where the left mouse button was pushed down
    Private Startpoint As Point

    'Point where the left mouse button was released
    Private Endpoint As Point

    'SECTOR INITIALIZATION
    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

        'Initialize Language
        InitializeLanguage()

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
        CboFunction.Items.Add(Main.LM.GetString("Tentmap"))
        CboFunction.Items.Add(Main.LM.GetString("LogisticGrowth"))
        CboFunction.Items.Add(Main.LM.GetString("Parabola"))



    End Sub

    Private Sub FrmFeigenbaum_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Generate objects
        FeigenbaumDiagram = New Bitmap(PicDiagram.Width, PicDiagram.Height)
        PicDiagram.Image = FeigenbaumDiagram
        Iterator = New ClsLogisticGrowth With {
            .Power = 1
        }

        'Default Settings
        Parameterrange = Iterator.ParameterInterval
        Valuerange = Iterator.IterationInterval
        MyBitmapGraphics = New ClsGraphicTool(FeigenbaumDiagram, Parameterrange, Valuerange)
        CboFunction.SelectedIndex = 1
        CboFunction.Select()

        'additional default settings
        SetDefaultValues()

    End Sub

    Private Sub SetDefaultValues()

        TxtAMin.Text = Iterator.ParameterInterval.A.ToString(CultureInfo.CurrentCulture)
        TxtAMax.Text = Iterator.ParameterInterval.B.ToString(CultureInfo.CurrentCulture)
        LblDeltaA.Text = Main.LM.GetString("Delta") & " = " & Iterator.ParameterInterval.IntervalWidth.ToString(CultureInfo.CurrentCulture)

        TxtXMin.Text = Iterator.IterationInterval.A.ToString(CultureInfo.CurrentCulture)
        TxtXMax.Text = Iterator.IterationInterval.B.ToString(CultureInfo.CurrentCulture)
        LblDeltaX.Text = Main.LM.GetString("Delta") & " = " & Iterator.IterationInterval.IntervalWidth.ToString(CultureInfo.CurrentCulture)

        IsUserinputValid = True

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click

        'The display is cleared
        MyBitmapGraphics.Clear(Color.White)
        PicDiagram.Refresh()

        'Reset the ranges
        Parameterrange = Iterator.ParameterInterval
        Valuerange = Iterator.IterationInterval
        MyBitmapGraphics = New ClsGraphicTool(FeigenbaumDiagram, Parameterrange, Valuerange)

    End Sub

    Private Sub CboFunktion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboFunction.SelectedIndexChanged

        Dim type As Integer

        'The user chooses the type of iteration
        type = CboFunction.SelectedIndex
        Select Case type
            Case 0  'Tentmap
                Iterator = New ClsTentmap
            Case 1 'Logistic Growth
                Iterator = New ClsLogisticGrowth
            Case Else  'Parabola
                Iterator = New ClsParabola
        End Select

        Iterator.Power = 1

        'Reset ranges
        Parameterrange = Iterator.ParameterInterval
        Valuerange = Iterator.IterationInterval
        MyBitmapGraphics = New ClsGraphicTool(FeigenbaumDiagram, Parameterrange, Valuerange)

        SetDefaultValues()

        MyBitmapGraphics.Clear(Color.White)

    End Sub

    Private Sub TrbPrecision_ValueChanged(sender As Object, e As EventArgs) Handles TrbPrecision.ValueChanged

        'The precision defines how precise the diagram is generated
        LblPrecision.Text = Main.LM.GetString("Precision") & ": " & (1000 * TrbPrecision.Value).ToString(CultureInfo.CurrentCulture)

    End Sub

    'SECTOR ITERATION

    Private Sub BtnStartIteration_Click(sender As Object, e As EventArgs) Handles BtnStartIteration.Click

        'Check and set the Ranges, defined by the user
        CheckUserRanges()

        If IsUserinputValid Then

            MyBitmapGraphics.Clear(Color.White)

            'In the direction of the x-axis, we work with pixel coordinates
            Dim p As Integer

            For p = 1 To PicDiagram.Width

                'for each p, the according paranmetervalue a is calculated
                'and then the iteration runs until RuntimeUntilCycle
                'finally, the cycle is drawn
                DrawCycle(p)

            Next

            'Draw the Splitpoints
            If ChkSplitPoints.Checked Then
                DrawSplitPoints()
            End If

        Else

            MessageBox.Show(Main.LM.GetString("ActionStopped"))
            SetDefaultValues()
        End If

    End Sub

    Private Sub DrawCycle(p As Integer)

        'The startvalue for the iteration is not important - we choose somtehing
        Dim x As Decimal = CDec(Valuerange.A + (Valuerange.IntervalWidth * 0.31415926535))

        'Calculate the parameter a for the iteration depending on p
        Dim a As Decimal = Parameterrange.A + (Parameterrange.IntervalWidth * p / PicDiagram.Width)
        Iterator.Parameter = a

        'First, the iteration runs a while until it gets periodic (if the behaviour is not chaotic)
        Dim RuntimeUntilCycle As Integer = 1000 * TrbPrecision.Value
        For n = 1 To RuntimeUntilCycle - 1
            x = Iterator.FN(x)
        Next

        'After that, the number of iterations must be big enough to draw the cycle
        Dim LengthOfCycle As Integer = CInt(PicDiagram.Height * Iterator.IterationInterval.IntervalWidth _
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

        'There is the possibility to use two colors
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

    Private Sub PicDiagram_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PicDiagram.MouseDown

        'The user can choose a range by a flexible rectangle
        IsMousedown = True

        'e guarantees, that the mouse position is relative to PicDiagram
        'and the Startpoint is the position, where the left mouse button was first pushed down
        Startpoint = e.Location

    End Sub

    Private Sub PicDiagram_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PicDiagram.MouseMove

        If IsMousedown Then

            'the endpoint is on the actual mouse position
            Endpoint = e.Location

            'this refreshing launches the paint-event of e and the selection-rectangle is drawn
            'in the actual position
            PicDiagram.Refresh()

        End If

    End Sub

    Private Sub PicDiagram_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles PicDiagram.Paint

        If IsMousedown Then

            'the selection-rectangle is dranw in its actual position
            Dim rect As New Rectangle(Math.Min(Startpoint.X, Endpoint.X), Math.Min(Startpoint.Y, Endpoint.Y),
                                      Math.Abs(Startpoint.X - Endpoint.X), Math.Abs(Startpoint.Y - Endpoint.Y))
            Using MyPen As New Pen(Color.Red)
                e.Graphics.DrawRectangle(MyPen, rect)
            End Using

        End If

    End Sub

    Private Sub PicDiagram_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PicDiagram.MouseUp

        IsMousedown = False

        'Now, the final EndPoint is set on the position, where the mouse button was released
        Endpoint = e.Location

        'We have to check, if the selection-rectangle shows a valid selection
        If Startpoint <> Endpoint Then

            'The selection is OK

            'Now, we adjust the interval of p. p moves between pMin and pMax
            Dim pMin As Integer = Math.Min(Startpoint.X, Endpoint.X)
            Dim pMax As Integer = Math.Max(Startpoint.X, Endpoint.X)

            'as well, in direction of the y-axis we have to adjust the relevant interval
            Dim qMin As Integer = Math.Min(PicDiagram.Height - Startpoint.Y, PicDiagram.Height - Endpoint.Y)
            Dim qMax As Integer = Math.Max(PicDiagram.Height - Startpoint.Y, PicDiagram.Height - Endpoint.Y)

            'This rectangle surrounds the selected range
            Dim rect As New Rectangle(pMin, qMin, pMax - pMin, qMax - qMin)

            'transmit the selection to the parameter range
            TxtAMin.Text = Math.Max(PixelToA(pMin), Iterator.ParameterInterval.A).ToString(CultureInfo.CurrentCulture)
            TxtAMax.Text = Math.Min(PixelToA(pMax), Iterator.ParameterInterval.B).ToString(CultureInfo.CurrentCulture)
            LblDeltaA.Text = "Delta = " & (PixelToA(pMax) - PixelToA(pMin)).ToString(CultureInfo.CurrentCulture)

            'transmit the selection to the value range of x
            TxtXMin.Text = Math.Max(PixelToX(qMin), Iterator.IterationInterval.A).ToString(CultureInfo.CurrentCulture)
            TxtXMax.Text = Math.Min(PixelToX(qMax), Iterator.IterationInterval.B).ToString(CultureInfo.CurrentCulture)
            LblDeltaX.Text = "Delta = " & (PixelToX(qMax) - PixelToX(qMin)).ToString(CultureInfo.CurrentCulture)

        End If
    End Sub

    'SECTOR TRANSFORMATION OF USER RANGES

    Private Function PixelToA(p As Integer) As Decimal

        'calculates the parametervalue a according to 
        Dim a As Decimal = Parameterrange.A + ((p - 1) * Parameterrange.IntervalWidth / PicDiagram.Width)
        Return a

    End Function

    Private Function PixelToX(q As Integer) As Decimal

        'calculates the x-value that belongs to a q-pixel coordinate in y-axis direction
        Dim x As Decimal = CDec(Valuerange.A + (q * Valuerange.IntervalWidth / (PicDiagram.Height * 0.99)))

        Return x

    End Function

    'MANUALLY SET USER RANGES

    Private Sub TxtAMax_LostFocus(sender As Object, e As EventArgs) Handles TxtAMax.LostFocus
        CheckUserRanges()
    End Sub

    Private Sub TxtAMin_LostFocus(sender As Object, e As EventArgs) Handles TxtAMin.LostFocus
        CheckUserRanges()
    End Sub

    Private Sub TxtXMax_LostFocus(sender As Object, e As EventArgs) Handles TxtXMax.LostFocus
        CheckUserRanges()
    End Sub

    Private Sub TxtXMin_LostFocus(sender As Object, e As EventArgs) Handles TxtXMin.LostFocus
        CheckUserRanges()
    End Sub

    'CHECK USER RANGES AND SET PARAMETER AND VALUE INTERVAL

    Private Sub CheckUserRanges()

        'The parameter range has to be part of the allowed interval for the parameter a
        'depending of the type of iteration
        Dim CheckParameterrange As New ClsCheckIsInterval(TxtAMin, TxtAMax)
        Dim IsParameterrangeValid As Boolean

        'The interval borders have to be numeric and a < b
        If CheckParameterrange.IsIntervalValid Then

            'if [a,b] is an interval, then the parameter interval is constructed
            Parameterrange = New ClsInterval(CheckParameterrange.A, CheckParameterrange.B)

            'is the parameter range part of the allowed parameter interval?
            If Iterator.ParameterInterval.IsInterval2PartOfInterval(Parameterrange) Then
                IsParameterrangeValid = True
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

        'Analogue, the range of the x-value is checked
        Dim CheckValuerange As New ClsCheckIsInterval(TxtXMin, TxtXMax)
        Dim IsValuerangeValid As Boolean

        'are the interval borders numeric and is a < b
        If CheckValuerange.IsIntervalValid Then

            'in that case, the value range is constructed
            Valuerange = New ClsInterval(CheckValuerange.A, CheckValuerange.B)

            'Is the value range part of the allowed value interval?
            If Iterator.IterationInterval.IsInterval2PartOfInterval(Valuerange) Then
                IsValuerangeValid = True
            Else
                MessageBox.Show(Main.LM.GetString("ParameterRangeNotAllowed") & " [" &
                   Iterator.IterationInterval.A.ToString(CultureInfo.CurrentCulture) &
                   ", " & Iterator.IterationInterval.B.ToString(CultureInfo.CurrentCulture) &
                   "] ")
                IsValuerangeValid = False
            End If
        Else
            IsValuerangeValid = False
        End If

        IsUserinputValid = IsParameterrangeValid And IsValuerangeValid

        If IsUserinputValid Then
            LblDeltaA.Text = Main.LM.GetString("Delta") & " = " & Parameterrange.IntervalWidth.ToString(CultureInfo.CurrentCulture)
            LblDeltaX.Text = Main.LM.GetString("Delta") & " = " & Valuerange.IntervalWidth.ToString(CultureInfo.CurrentCulture)
            MyBitmapGraphics = New ClsGraphicTool(FeigenbaumDiagram, Parameterrange, Valuerange)
        End If

    End Sub

    'SECTOR SPLITPOINTS

    Private Sub DrawSplitPoints()

        If IsUserinputValid Then

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
                    MyDiagramGraphics.DrawLine(A, B, Color.Red, 1)
                End If
            Next

        Else
            MessageBox.Show(Main.LM.GetString("InvalidUserRanges"))
            SetDefaultValues()
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