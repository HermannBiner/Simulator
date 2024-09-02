'This windows compares the movement of a 'real' spring pendulum (green)
'oscillating like cos(t)
'and the movement of a (red) spring pendulum which movement is approximated
'by different numerical methods

'Status Checked

Imports System.Reflection

Public Class FrmSpringPendulum

    'Mathematicel Interval in y-direction
    Private MyMathRange As ClsInterval

    'Draws into the picturebox
    'this is drawing the actual status of the pendulums
    Private MyPictureBoxDrawer As ClsGraphicTool

    'Bitmap and shifted Bitmap to draw the traces
    'the trick of the track moving to the right is
    'that the bitmap is copied into a ShiftedBitMap
    'after that, the original bitmap is cleared
    'and the shifted bitmap is copied into the
    'original one with a 1-pixel shift
    'to the right
    'if the stepwidth of the iteration is small
    'this shift happens only after a number 
    'of iteration steps - therefore
    'we need "NumberOfStepsUntilShift"
    Private MyBitmap As Bitmap
    Private MyShiftedBitmap As Bitmap
    Private XShift As Integer = 1
    Private NumberOfStepsUntilShift As Integer = 1

    'Draws persistently into the bitmap
    'this is to draw the track of the pendulum-movement
    Private MyBitmapDrawer As ClsGraphicTool

    'Iteration control
    Private StopIteration As Boolean
    Private InitializeIteration As Boolean = True
    Private n As Integer '#Steps

    'User Startposition is set by pushing the left mouse button down
    Private IsMouseDown As Boolean = False

    'The X-Position of both Pendulums
    'this is a fixed value
    Private MyXPositionA As Decimal = CDec(-0.97)
    Private MyXPositionB As Decimal = CDec(-0.94)

    'The Y-Startposition is for both pendulum the same
    'and is set by the user - default is 0.5
    Private MyYStartposition As Decimal = CDec(0.5)

    'Iteration parameters Pendulum A: The real spring pendulum
    Private PendulumA As ISpringPendulum

    'to draw the trace we need:
    Private TraceA As ClsMathpoint
    Private NextTraceA As ClsMathpoint

    'and the step width of the iteration is 
    Private StepWidthA As Decimal = CDec(0.1)

    'Iteration parameters Pendulum B: The approximated spring pendulum
    'the y-coordinate is a numeric approach depending on the chosen method
    Private PendulumB As ISpringPendulum
    Private TraceB As ClsMathpoint
    Private NextTraceB As ClsMathpoint

    'CDec(0.1) is the Standard, but the StepWidthB is calculated
    'in SetStepWidthB based on TrbStepWidth.value
    Private StepWidthB As Decimal = CDec(0.1)

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub InitializeLanguage()

        Text = FrmMain.LM.GetString("SpringPendulum")
        BtnReset.Text = FrmMain.LM.GetString("Reset")
        BtnStart.Text = FrmMain.LM.GetString("Start")
        BtnStop.Text = FrmMain.LM.GetString("Stop")
        LblPendulum.Text = FrmMain.LM.GetString("Pendulum")
        LblStepWidth.Text = FrmMain.LM.GetString("StepWidth") & " 0.02"
        LblNumberOfSteps.Text = FrmMain.LM.GetString("NumberOfSteps")
        ChkStretched.Text = FrmMain.LM.GetString("StretchedMode")
        LblDifference.Text = FrmMain.LM.GetString("Difference")
        CboPendulum.Items.Clear()

        'Add the classes implementing ISpringPendulum
        'to the Combobox CboPendulum by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(ISpringPendulum)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If types.Count > 0 Then
            Dim PendulumName As String
            For Each type In types

                'GetString is calle dwith the option IsClass = true
                'That effects that - if there is no Entry in the Resource files LabelsEN, LabelsDE -
                'the name of the Class implementing an Interface is used as default
                'suppressing the extension "Cls"
                PendulumName = FrmMain.LM.GetString(type.Name, True)
                CboPendulum.Items.Add(PendulumName)
            Next

            CboPendulum.SelectedIndex = CboPendulum.Items.Count - 1
            CboPendulum.Select()

        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If


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


        'Initialize Language
        InitializeLanguage()

        'Initialize Pendulums
        InitializePendulums()

        'Draw the x-axis (time - axis) of the Coordinate System
        MyBitmapDrawer.DrawLine(New ClsMathpoint(-1, 0), New ClsMathpoint(1, 0), Color.Black, 1)

        PicDiagram.Invalidate()


    End Sub

    'PendulumA is just a real Spring Pendulum
    Private Sub InitializePendulums()

        'PendulumA is always the real spring pendulum
        PendulumA = New ClsRealSpringPendulum With {
            .h = StepWidthA,
            .NumberOfApproxSteps = 1
        }

        'pendulumB can be the real spring pendulum
        'or any other pendulum definied by the numerical approximation method
        PendulumB = New ClsRealSpringPendulum With {
            .h = StepWidthB,
            .NumberOfApproxSteps = 1
        }

        'The default values for the Start- and Actualparameters
        'are set here:
        SetDefaultParameters()

        'and the pendulums are drawn in the default startposition
        Drawpendulums(MyPictureBoxDrawer)

    End Sub

    Sub SetDefaultParameters()

        'all default start parameters are zero
        If PendulumA IsNot Nothing Then
            With PendulumA
                .StartParameter(0) = 0
                .StartParameter(1) = MyYStartposition
            End With
        End If

        If PendulumB IsNot Nothing Then
            With PendulumB
                .StartParameter(0) = 0
                .StartParameter(1) = MyYStartposition
            End With
            If TypeOf PendulumB IsNot ClsRealSpringPendulum Then
                PendulumB.StartParameter(2) = 0
            End If
        End If

    End Sub

    Private Sub SetStepWidthAB(TrackBarValue As Integer)

        'concernes the number of approximation steps for the PendulumB.Y-value
        'the Default is 1, but the final value is calculated here 
        'and is depending of StepWidthB
        Dim NumberOfApproxStepsB As Integer

        'In case of the non-stretched mode
        'the stepwidth for the approximation of PendulumB.Y
        'should be a whole-number divisor of StepWidthA
        'see preliminarey note of the Sub IterationLoop

        'the effect is, that if PendulumA increases by StepWidthA
        'the iteration of PendulumB is repeated so many times
        'that NumberOfApproxStepsB x StepWidthB = StepWidthA
        'thereby both pendulums are synchronized

        Dim LocStepWidth As Decimal

        If TrackBarValue > 5 Then
            LocStepWidth = CDec(Math.Max(0.01 - 0.001 * (TrackBarValue - 6), 0.001))
        Else
            LocStepWidth = CDec(0.1 - 0.02 * (TrackBarValue - 1))
        End If

        If ChkStretched.Checked Then

            'in that case, the stepwidth of both pendulums are the same
            'and therefore also the NumberOfApproxStepsB is = 1
            'like NumberOfApproxStepsA
            StepWidthA = LocStepWidth
            StepWidthB = StepWidthA
            NumberOfApproxStepsB = 1

        Else
            'StepWidthA is set as Standard = 0.1
            StepWidthA = CDec(0.1)

            'and StepWidthB is equal locStepWidth and adapted
            'so that StepWidthB x NumberOfApproxStepsB = StepWidthA
            NumberOfApproxStepsB = CInt(Math.Round(StepWidthA / LocStepWidth))
            StepWidthB = StepWidthA / NumberOfApproxStepsB
        End If

        LblStepWidth.Text = FrmMain.LM.GetString("StepWidth") & " " & StepWidthB.ToString("0.0000")

        If PendulumA IsNot Nothing Then
            PendulumA.h = StepWidthA
            PendulumA.NumberOfApproxSteps = 1
        End If

        If PendulumB IsNot Nothing Then
            PendulumB.h = StepWidthB
            PendulumB.NumberOfApproxSteps = NumberOfApproxStepsB
        End If

    End Sub

    Private Sub TrbStepWidth_ValueChanged(sender As Object, e As EventArgs) Handles TrbStepWidth.ValueChanged

        'Set Stepwidth
        SetStepWidthAB(TrbStepWidth.Value)
        Reset()

    End Sub

    Private Sub CboPendulum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboPendulum.SelectedIndexChanged

        'This sets the type of PendulumB by Reflection

        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(ISpringPendulum)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If CboPendulum.SelectedIndex >= 0 Then

            Dim SelectedName As String = CboPendulum.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If FrmMain.LM.GetString(type.Name, True) = SelectedName Then
                        PendulumB = CType(Activator.CreateInstance(type), ISpringPendulum)
                    End If
                Next
            End If

        End If

        SetStepWidthAB(TrbStepWidth.Value)

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
        BtnStart.Text = FrmMain.LM.GetString("Start")

        'when loading the form, click events are launched
        'before MyBitmapDrawer is initialized
        MyBitmapDrawer?.Clear(Color.White)

        SetDefaultParameters()

        Drawpendulums(MyPictureBoxDrawer)

        'Coordinate System x-axis
        MyPictureBoxDrawer?.DrawLine(New ClsMathpoint(-1, 0), New ClsMathpoint(1, 0), Color.Black, 1)

    End Sub

    Private Sub ChkStretched_CheckedChanged(sender As Object, e As EventArgs) Handles ChkStretched.CheckedChanged
        SetStepWidthAB(TrbStepWidth.Value)
        Reset()
    End Sub

    'SECTOR ITERATION

    Private Async Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click

        StopIteration = False
        BtnStart.Enabled = False
        BtnStart.Text = FrmMain.LM.GetString("Continue")
        BtnReset.Enabled = False

        Await IterationLoop()

    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click

        StopIteration = True
        BtnStart.Enabled = True
        BtnReset.Enabled = True

    End Sub

    Private Async Function IterationLoop() As Task

        'MyStartposition is already set by the user

        If InitializeIteration Then

            'Initializing only in the beginning
            'that gives the possibility to continue after an interrupt
            n = 0


            TraceA = New ClsMathpoint(MyXPositionA, PendulumA.ActualParameter(1))
            TraceB = New ClsMathpoint(MyXPositionB, PendulumB.ActualParameter(1))
            NextTraceA = New ClsMathpoint(MyXPositionA, PendulumA.ActualParameter(1))
            NextTraceB = New ClsMathpoint(MyXPositionB, PendulumB.ActualParameter(1))

            'prepare stepwidth and NumberOfApproxSteps
            If ChkStretched.Checked Then
                'both pendulums have the same stepwidth
                'and the same number of approx steps
                PendulumB.h = PendulumA.h
                PendulumB.NumberOfApproxSteps = 1
                'remark: PendulumA has already NumberOfApproxSteps = 1
            Else
                PendulumA.h = StepWidthA
                'remark: PendulumB is set in CalcStepWidth
                SetStepWidthAB(TrbStepWidth.Value)
            End If

            InitializeIteration = False

            'the next number is needed because the XShift of 1 pixel
            'corresponds to 0.02
            'and this should be equal to "NumberOfStepsUntilShift x StepWidthA"
            'so that the Shift is done when the Width if 1 pixel is reached by "NumberOfStepsUntilShift x StepWidthA"
            'but the minimum is of course 1
            NumberOfStepsUntilShift = Math.Max(1, CInt(0.02 / StepWidthA))

        End If


        Do
            n += 1

            TraceA.X = NextTraceA.X
            TraceA.Y = NextTraceA.Y

            TraceB.X = NextTraceB.X
            TraceB.Y = NextTraceB.Y

            PendulumA.Iteration()
            PendulumB.Iteration()

            NextTraceA = New ClsMathpoint(MyXPositionA, PendulumA.ActualParameter(1))
            NextTraceB = New ClsMathpoint(MyXPositionB, PendulumB.ActualParameter(1))

            'Draw the line of movement into the bitmap
            MyBitmapDrawer.DrawLine(TraceA, NextTraceA, Color.Green, 1)
            MyBitmapDrawer.DrawLine(TraceB, NextTraceB, Color.Red, 1)

            'copy the bitmap
            MyShiftedBitmap = New Bitmap(MyBitmap)

            If n Mod NumberOfStepsUntilShift = 0 Then

                'Draw this copy right-shifted into the bitmap
                MyBitmapDrawer.Clear(Color.White)
                MyBitmapDrawer.DrawImage(MyShiftedBitmap, XShift, 0)

                'Coordinate system x-axis
                MyBitmapDrawer.DrawLine(New ClsMathpoint(-1, 0), New ClsMathpoint(CDec(-0.9), 0), Color.Black, 1)

                'update Picdiagram
                PicDiagram.Invalidate()
            End If


            Drawpendulums(MyPictureBoxDrawer)

            LstValueList.Items.Add(n.ToString("00000") & ": " & (TraceA.Y - TraceB.Y).ToString("0.##########"))

            If n Mod 5 = 0 Then
                LblSteps.Text = n.ToString
                Await Task.Delay(2)
            End If

        Loop Until StopIteration

    End Function

    'SECTOR DRAWINGS

    Private Sub Drawpendulums(Drawer As ClsGraphicTool)

        PicDiagram.Refresh()

        If PendulumA IsNot Nothing And PendulumB IsNot Nothing Then

            Dim PositionA As New ClsMathpoint(MyXPositionA, PendulumA.ActualParameter(1))
            Dim SuspensionA As New ClsMathpoint(MyXPositionA, 1)
            Dim PositionB As New ClsMathpoint(MyXPositionB, PendulumB.ActualParameter(1))
            Dim SuspensionB As New ClsMathpoint(MyXPositionB, 1)

            Drawer.DrawPoint(PositionA, Brushes.Green, 5)
            Drawer.DrawLine(PositionA, SuspensionA, Color.Green, 2)

            Drawer.DrawPoint(PositionB, Brushes.Red, 5)
            Drawer.DrawLine(PositionB, SuspensionB, Color.Red, 2)

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
        If IsMouseDown Then

            'The Position of the Mouse sets the Position of the pendulum
            'e: Mouseposition is relative to PicDiagram
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
            PendulumA.StartParameter(1) = Math.Min(Math.Max(PixelqToMathy(Mouseposition.Y), CDec(-0.95)), CDec(0.95))
            PendulumB.StartParameter(1) = Math.Min(Math.Max(PixelqToMathy(Mouseposition.Y), CDec(-0.95)), CDec(0.95))
            Drawpendulums(MyPictureBoxDrawer)
        End If


    End Sub

    Private Function PixelqToMathy(q As Integer) As Decimal

        Dim y As Decimal = MyMathRange.B - (q * MyMathRange.IntervalWidth _
            / PicDiagram.Height)

        Return y
    End Function

    Private Sub FrmSpringPendulum_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Reset()
    End Sub
End Class