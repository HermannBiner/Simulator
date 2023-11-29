'This windows compares the movement of a 'real' spring pendulum (green)
'oscillating like cos(t)
'and the movement of a (red) spring pendulum which movement is approximated
'by different numeric methods

'Status: Under Construction!!

Imports System.ComponentModel
Imports System.Globalization
Imports System.Net.Mail
Imports System.Threading

Public Class FrmSpringPendulum

    'Mathematicel Interval in y-direction
    Private MyMathRange As ClsInterval

    'Draws into the picturebox
    Private MyPictureBoxDrawer As ClsGraphicTool

    'Bitmap and shifted Bitmap to draw the traces
    Private MyBitmap As Bitmap
    Private MyShiftedBitmap As Bitmap
    Private XShift As Integer = 1

    'Draws persistently into the bitmap
    Private MyBitmapDrawer As ClsGraphicTool

    'Iteration control
    Private StopIteration As Boolean
    Private InitializeIteration As Boolean = True
    Private n As Integer '#Steps

    'Approximation of PendulumB
    'The stepwidth of the numerical method for the approximation
    Private StepWidth As Decimal

    'and the number of approximation steps for the next PendulumB.Y-value
    Private ApproxSteps As Integer

    'User Startposition
    Private IsMouseDown As Boolean = False

    'The Angle is the argument of the pendulum function
    'starting by 0 and then increasing by stepwidth
    Private Angle As Decimal
    Private DeltaAngle As Decimal = CDec(0.1)

    'A is the start amplitude of both pendulums
    Private A As Decimal

    'Iteration parameters Pendulum A: The real spring pendulum
    'the y-coordinate is just A*cos(angle)
    Private PendulumA As ClsMathpoint
    Private TraceA As ClsMathpoint
    Private NextTraceA As ClsMathpoint

    'Iteration parameters Pendulum B: The approximated spring penduum
    'the y-coordinate is a numeric approach depending on the chosen method
    Private PendulumB As ClsMathpoint
    Private TraceB As ClsMathpoint
    Private NextTraceB As ClsMathpoint

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

        'Initialize Language
        InitializeLanguage()

    End Sub

    Private Sub InitializeLanguage()

        Text = Main.LM.GetString("SpringPendulum")
        BtnReset.Text = Main.LM.GetString("Reset")
        BtnStart.Text = Main.LM.GetString("Start")
        BtnStop.Text = Main.LM.GetString("Stop")
        LblNumericMethod.Text = Main.LM.GetString("NumericMethod")
        LblStepWidth.Text = Main.LM.GetString("StepWidth") & " " & CalcStepWidth(TrbStepWidth.Value).ToString
        LblNumberOfSteps.Text = Main.LM.GetString("NumberOfSteps")
        ChkStretched.Text = Main.LM.GetString("StretchedMode")
        LblDifference.Text = Main.LM.GetString("Difference")
        CboNumericMethod.Items.Clear()

        'the following order of adding the type of the numeric method is relevant!
        'there is at the moment no better concept implemented to identify
        'the type of the numeric method
        CboNumericMethod.Items.Add(Main.LM.GetString("Euler"))
        CboNumericMethod.Items.Add(Main.LM.GetString("RungeKutta3"))
        CboNumericMethod.Items.Add(Main.LM.GetString("RungeKutta4"))

        CboNumericMethod.SelectedIndex = 2
        CboNumericMethod.Select()

    End Sub

    Private Sub FrmSpringPendulum_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Initialize Bitmap
        MyBitmap = New Bitmap(PicDiagram.Width, PicDiagram.Height)
        PicDiagram.Image = MyBitmap

        'Initialize GraphicTools
        MyMathRange = New ClsInterval(CDec(-1), CDec(1))
        MyPictureBoxDrawer = New ClsGraphicTool(PicDiagram, MyMathRange, MyMathRange)
        MyBitmapDrawer = New ClsGraphicTool(MyBitmap, MyMathRange, MyMathRange)
        MyBitmapDrawer.Clear(Color.White)

        'Initialize Pendulums
        PendulumA = New ClsMathpoint(CDec(-0.95), 0)
        PendulumB = New ClsMathpoint(CDec(-0.9), 0)

        'Draw Pendulums 
        MyBitmapDrawer.DrawPoint(PendulumA, Brushes.Green, 5)
        MyBitmapDrawer.DrawLine(New ClsMathpoint(PendulumA.X, 1), PendulumA, Color.Green, 2)

        MyBitmapDrawer.DrawPoint(PendulumB, Brushes.Red, 5)
        MyBitmapDrawer.DrawLine(New ClsMathpoint(PendulumB.X, 1), PendulumB, Color.Red, 2)

        'Coordinate System x-axis
        MyBitmapDrawer.DrawLine(New ClsMathpoint(-1, 0), New ClsMathpoint(1, 0), Color.Black, 1)

        PicDiagram.Invalidate()

    End Sub

    Private Function CalcStepWidth(TrackBarValue As Integer) As Decimal

        'In case of the non-stretched mode
        'the stepwidth for the approximation of PendulumB.Y
        'should be a whole-number divisor of DeltaAngle
        'see preliminarey note of the Sub IterationLoop

        Dim LocStepWidth As Decimal
        If TrackBarValue > 5 Then
            LocStepWidth = CDec(Math.Max(0.01 - 0.001 * (TrackBarValue - 6), 0.001))
        Else
            LocStepWidth = CDec(0.1 - 0.02 * (TrackBarValue - 1))
        End If

        If ChkStretched.Checked Then
            ApproxSteps = CInt(Math.Round(DeltaAngle / LocStepWidth))
            LocStepWidth = DeltaAngle / ApproxSteps
        Else
            ApproxSteps = 1
        End If

        Return LocStepWidth

    End Function


    Private Sub TrbStepWidth_ValueChanged(sender As Object, e As EventArgs) Handles TrbStepWidth.ValueChanged

        'Set Stepwidth
        StepWidth = CalcStepWidth(TrbStepWidth.Value)
        LblStepWidth.Text = Main.LM.GetString("StepWidth") & " " & StepWidth.ToString("0.0000")
        Reset()

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        Reset()
    End Sub

    Private Sub Reset()

        StopIteration = True
        InitializeIteration = True
        PicDiagram.Refresh()
        LstValueList.Items.Clear()
        InitializeIteration = True
        BtnStart.Enabled = True

        'when loading the form, click events are launched
        'before MyBitmapDrawer is initialized
        If MyBitmapDrawer IsNot Nothing Then
            MyBitmapDrawer.Clear(Color.White)
        End If

        Drawpendulums()

    End Sub

    Private Sub ChkStretched_CheckedChanged(sender As Object, e As EventArgs) Handles ChkStretched.CheckedChanged
        Reset()
    End Sub

    'SECTOR ITERATION

    Private Async Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click

        StopIteration = False
        BtnStart.Enabled = False
        BtnReset.Enabled = False

        Await IterationLoop()

    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click

        StopIteration = True
        BtnStart.Enabled = True
        BtnReset.Enabled = True

    End Sub

    Private Async Function IterationLoop() As Task

        'preliminary note:
        'PendulumB.Y is approached by a numeric method
        'the Stepwidth of the method is just given by the parameter Stepwidth
        'in stretched mode, each step is drawn into the bitmap
        'and simultaneously the "real" pendulum is increased by Stepwidth

        'in case of "non streteched", the "real" pendulum is increased by DeltaAngle
        'and for the approximation of PendulumB are so many steps performed
        'until the number of steps x the stepwidth is equal to DetlaAngle
        'because the number of steps is Integer, the stepwidth is maybe a little bit adjusted
        'this happens in the Function CalcStepWidth

        If InitializeIteration Then

            'Initializing only in the beginning
            'that gives the possibility to continue after an interrupt
            n = 0
            Angle = 0

            A = Math.Abs(PendulumA.Y)

            TraceA = New ClsMathpoint(PendulumA.X, 0)
            NextTraceA = New ClsMathpoint(PendulumA.X - CDec(XShift * MyMathRange.IntervalWidth / PicDiagram.Height), CDec(A * Math.Sin(StepWidth)))
            TraceB = New ClsMathpoint(PendulumB.X, 0)
            NextTraceB = New ClsMathpoint(PendulumB.X - CDec(XShift * MyMathRange.IntervalWidth / PicDiagram.Height), CDec(A * Math.Sin(StepWidth)))


            InitializeIteration = False

        End If


        Do
            n += 1

            'copy the bitmap
            MyShiftedBitmap = New Bitmap(MyBitmap)

            'Draw this copy right-shifted into the bitmap
            MyBitmapDrawer.Clear(Color.White)
            MyBitmapDrawer.DrawImage(MyShiftedBitmap, XShift, 0)

            'Coordinate system x-axis
            MyBitmapDrawer.DrawLine(New ClsMathpoint(-1, 0), New ClsMathpoint(CDec(-0.9), 0), Color.Black, 1)

            'Draw the line of movement into the bitmap
            MyBitmapDrawer.DrawLine(TraceA, NextTraceA, Color.Green, 1)
            MyBitmapDrawer.DrawLine(TraceB, NextTraceB, Color.Red, 1)

            'update the Picdiagram
            PicDiagram.Invalidate()
            Drawpendulums()

            'prepare the next point
            If ChkStretched.Checked Then
                Angle += StepWidth
            Else
                Angle += DeltaAngle
            End If

            Angle = Angle Mod CDec(Math.PI * 2)

            PendulumA.Y = CDec(A * Math.Sin(Angle))
            TraceA.Y = NextTraceA.Y
            NextTraceA.Y = PendulumA.Y




            PendulumB.Y = CDec(A * Math.Sin(Angle))
            TraceB.Y = NextTraceB.Y
            NextTraceB.Y = PendulumB.Y

            LstValueList.Items.Add(n.ToString("00000") & ": " & (PendulumA.Y - PendulumB.Y).ToString("0.##########"))

            If n Mod 5 = 0 Then
                LblSteps.Text = n.ToString
                Await Task.Delay(2)
            End If
        Loop Until StopIteration

    End Function

    'SECTOR DRAWINGS

    Private Sub Drawpendulums()

        PicDiagram.Refresh()

        If PendulumA IsNot Nothing And PendulumB IsNot Nothing Then
            MyPictureBoxDrawer.DrawPoint(PendulumA, Brushes.Green, 5)
            MyPictureBoxDrawer.DrawLine(New ClsMathpoint(PendulumA.X, 1), PendulumA, Color.Green, 2)

            MyPictureBoxDrawer.DrawPoint(PendulumB, Brushes.Red, 5)
            MyPictureBoxDrawer.DrawLine(New ClsMathpoint(PendulumB.X, 1), PendulumB, Color.Red, 2)
        End If

    End Sub

    'SECTOR USER START POSITION

    Private Sub PicDiagram_MouseDown(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseDown

        If StopIteration Then
            If e.X < 100 Then

                Cursor = Cursors.Hand
                IsMouseDown = True

                'Now, Moving the Mouse moves the pendulum as well
                MouseMoving(e)

            End If
        End If

    End Sub

    Private Sub PicDiagram_MouseUp(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseUp

        'Has only an effect, if the Mouse was down
        If IsMousedown Then

            'The Position of the Mouse sets the Position of the pendulum
            'e: Mouseposition is relative to PicBilliardTable
            Dim Mouseposition As Point
            Mouseposition.X = e.X + 2
            Mouseposition.Y = e.Y - 25

            'The Mouse gets its normal behaviour again
            Cursor = Cursors.Arrow
            IsMouseDown = False
        End If


    End Sub

    Private Sub PicDiagram_MouseMove(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseMove

        If IsMouseDown Then
            MouseMoving(e)
        End If

    End Sub

    Private Sub MouseMoving(e As MouseEventArgs)

        'Because the Cursor is "Hand", the Mouse Position is adjusted a bit
        Dim Mouseposition As New Point With {
            .X = e.X + 2,
            .Y = e.Y - 25
        }

        If Mouseposition.X >= 100 Then
            IsMouseDown = False
            Cursor = Cursors.Arrow
        Else
            MyBitmapDrawer.Clear(Color.White)
            MyBitmapDrawer.DrawLine(New ClsMathpoint(-1, 0), New ClsMathpoint(1, 0), Color.Black, 1)
            PendulumA.Y = Math.Min(Math.Max(PixelqToMathy(Mouseposition.Y), CDec(-0.95)), CDec(0.95))
            PendulumB.Y = PendulumA.Y
            Drawpendulums()
        End If


    End Sub

    Private Function PixelqToMathy(q As Integer) As Decimal

        Dim y As Decimal = MyMathRange.B - (q * MyMathRange.IntervalWidth _
            / PicDiagram.Height)

        Return y
    End Function

End Class