'This form allows the study of bifurcation in case of the Mandelbrot Set
'for real values of z
'the parameter a varies then between aMin and aMax horizontally
'for each a, p(x)=x^2+a is iterated starting with z0 = a
'after a certain number of iteration steps
'the following values of x are plotted vertically

'Status Checked

Imports System.Globalization

Public Class FrmBifurcation

    'Prepare basic objects

    'MyBitmapGraphics draws into the Feigenbaum Diagram
    Private BifurcationDiagram As Bitmap
    Private MyBitmapGraphics As ClsGraphicTool

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

        Text = FrmMain.LM.GetString("BifurcationDiagram")
        LblDeltaX.Text = FrmMain.LM.GetString("Delta") & " = "
        LblDeltaA.Text = FrmMain.LM.GetString("Delta") & " = "
        LblValueRange.Text = FrmMain.LM.GetString("ExaminatedValueRange")
        LblParameterRange.Text = FrmMain.LM.GetString("ExaminatedParameterRange")
        BtnStartIteration.Text = FrmMain.LM.GetString("StartIteration")
        BtnReset.Text = FrmMain.LM.GetString("ResetIteration")

    End Sub

    Private Sub FrmBifurcation_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Generate objects
        BifurcationDiagram = New Bitmap(PicDiagram.Width, PicDiagram.Height)
        PicDiagram.Image = BifurcationDiagram

        'Initialize Language
        InitializeLanguage()

        'additional default settings
        SetDefaultValues()

    End Sub

    Private Sub SetDefaultValues()

        'if there where User-defined ranges,
        'or the iterator has changed
        'the ranges are reset to the standard
        Parameterrange = New ClsInterval(CDec(-2), CDec(0.25))
        Valuerange = New ClsInterval(CDec(-2), CDec(2))
        MyBitmapGraphics = New ClsGraphicTool(BifurcationDiagram, Parameterrange, Valuerange)

        TxtAMin.Text = Parameterrange.A.ToString(CultureInfo.CurrentCulture)
        TxtAMax.Text = Parameterrange.B.ToString(CultureInfo.CurrentCulture)
        LblDeltaA.Text = FrmMain.LM.GetString("Delta") & " = " & Parameterrange.IntervalWidth.ToString(CultureInfo.CurrentCulture)

        TxtXMin.Text = Valuerange.A.ToString(CultureInfo.CurrentCulture)
        TxtXMax.Text = Valuerange.B.ToString(CultureInfo.CurrentCulture)
        LblDeltaX.Text = FrmMain.LM.GetString("Delta") & " = " & Valuerange.IntervalWidth.ToString(CultureInfo.CurrentCulture)

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

        Else
            'There is already a message generated
        End If

        BtnStartIteration.Enabled = True
        BtnReset.Enabled = True

    End Sub

    Private Sub DrawIterationCycle(p As Integer)

        'Calculate the parameter a for the iteration depending on p
        Dim a As Decimal = Parameterrange.A + (Parameterrange.IntervalWidth * p / PicDiagram.Width)
        Dim x As Decimal = a
        Dim i As Integer = 1

        Dim CyclePoint As New ClsMathpoint(a, x)

        'First, the iteration runs a while until it gets periodic (if the behaviour is not chaotic)
        Dim RuntimeUntilCycle As Integer = 10000

        Do
            x = FN(x, a)
            i += 1
        Loop Until i > RuntimeUntilCycle Or (x * x > 4)

        'After that, the number of iterations must be big enough to draw the cycle
        Dim LengthOfCycle As Integer = PicDiagram.Height

        'Finally , the cycle is drawn

        Do
            CyclePoint.Y = CDec(Math.Max(Valuerange.A, Math.Min(x, Valuerange.B)))
            MyBitmapGraphics.DrawPoint(CyclePoint, Brushes.Blue, 1)
            x = FN(x, a)
            i += 1
        Loop Until (i > RuntimeUntilCycle + LengthOfCycle) Or (x * x > 4)

        PicDiagram.Refresh()

    End Sub

    Private Function FN(x As Decimal, a As Decimal) As Decimal

        Return x * x + a

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
            If Parameterrange.IsInterval2PartOfInterval(TempParameterrange) Then
                IsParameterrangeValid = True
                'take over
                Parameterrange = TempParameterrange
            Else
                MessageBox.Show(FrmMain.LM.GetString("ParameterRangeNotAllowed") & " [" &
                   Parameterrange.A.ToString(CultureInfo.CurrentCulture) &
                   ", " & Parameterrange.B.ToString(CultureInfo.CurrentCulture) &
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
                If Valuerange.IsInterval2PartOfInterval(TempValuerange) Then
                    IsValuerangeValid = True
                    'take over
                    Valuerange = TempValuerange
                Else
                    MessageBox.Show(FrmMain.LM.GetString("ValueRangeNotAllowed") & " [" &
                       Valuerange.A.ToString(CultureInfo.CurrentCulture) &
                       ", " & Valuerange.B.ToString(CultureInfo.CurrentCulture) &
                       "] ")
                    IsValuerangeValid = False
                End If
            Else
                IsValuerangeValid = False
            End If
        End If

        IsUserSelectionValid = IsParameterrangeValid And IsValuerangeValid

        If IsUserSelectionValid Then
            LblDeltaA.Text = FrmMain.LM.GetString("Delta") & " = " & Parameterrange.IntervalWidth.ToString(CultureInfo.CurrentCulture)
            LblDeltaX.Text = FrmMain.LM.GetString("Delta") & " = " & Valuerange.IntervalWidth.ToString(CultureInfo.CurrentCulture)
            MyBitmapGraphics = New ClsGraphicTool(BifurcationDiagram, Parameterrange, Valuerange)
        Else
            'nothing
        End If

    End Sub

End Class