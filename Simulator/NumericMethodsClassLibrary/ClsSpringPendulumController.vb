'This class contains the Iteration Controller for FrmSpringPendulum

'Status Redesign Checked

Public Class ClsSpringPendulumController

    'Iteration parameters Pendulum A: The real spring pendulum
    Private MyDSA As ISpringPendulum

    'Iteration parameters Pendulum B: The approximated spring pendulum
    'the y-coordinate is a numeric approach depending on the chosen method
    Private MyDSB As ISpringPendulum

    'Mathematicel Interval in y-direction
    Private MyMathRange As ClsInterval

    'Draws into the picturebox
    'this is drawing the actual status of the pendulums
    Private MyPicDiagram As PictureBox
    Private MyPicGraphics As ClsGraphicTool

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
    Private MyBmpDiagram As Bitmap
    Private MyShiftedBmpDiagram As Bitmap
    Private XShift As Integer = 1
    Private NumberOfStepsUntilShift As Integer = 1

    'Draws persistently into the bitmap
    'this is to draw the track of the pendulum-movement
    Private MyBmpGraphics As ClsGraphicTool

    'Iteration control
    Private MyIterationStatus As ClsGeneral.EnIterationStatus

    'Status Parameters
    Private n As Integer '#Steps
    Private MyLblN As Label
    Private MyValueList As ListBox

    'The X-Position of both Pendulums
    'this is a fixed value
    Const MyXPositionA As Decimal = CDec(-0.97)
    Const MyXPositionB As Decimal = CDec(-0.94)

    'to draw the trace we need:
    Private TraceA As ClsMathpoint
    Private NextTraceA As ClsMathpoint

    Private TraceB As ClsMathpoint
    Private NextTraceB As ClsMathpoint

    'and the step width of the iteration is 
    Private MyStepWidthA As Decimal = CDec(0.1)

    'CDec(0.1) is the Standard, but the StepWidthB is calculated
    'in SetStepWidthB based on TrbStepWidth.value
    Private MyStepWidthB As Decimal = CDec(0.1)

    'Is Diagram Stretched
    Private IsStretched As Boolean
    Private MyStretchFactor As Integer

    WriteOnly Property DSA As ISpringPendulum
        Set(value As ISpringPendulum)
            MyDSA = value
        End Set
    End Property

    WriteOnly Property DSB As ISpringPendulum
        Set(value As ISpringPendulum)
            MyDSB = value
        End Set
    End Property

    ReadOnly Property MathRange As ClsInterval
        Get
            MathRange = MyMathRange
        End Get
    End Property

    WriteOnly Property PicDiagram As PictureBox
        Set(value As PictureBox)
            MyPicDiagram = value
            MyPicGraphics = New ClsGraphicTool(MyPicDiagram, MyMathRange, MyMathRange)
            MyBmpDiagram = New Bitmap(MyPicDiagram.Width, MyPicDiagram.Height)
            MyPicDiagram.Image = MyBmpDiagram
            MyBmpGraphics = New ClsGraphicTool(MyBmpDiagram, MyMathRange, MyMathRange)
        End Set
    End Property

    Property IterationStatus As ClsGeneral.EnIterationStatus
        Get
            IterationStatus = MyIterationStatus
        End Get
        Set(value As ClsGeneral.EnIterationStatus)
            MyIterationStatus = value
        End Set
    End Property

    WriteOnly Property LblSteps As Label
        Set(value As Label)
            MyLblN = value
        End Set
    End Property

    WriteOnly Property ValueList As ListBox
        Set(value As ListBox)
            MyValueList = value
        End Set
    End Property

    ReadOnly Property StepWidthA As Decimal
        Get
            StepWidthA = MyStepWidthA
        End Get
    End Property

    ReadOnly Property StepWidthB As Decimal
        Get
            StepWidthB = MyStepWidthB
        End Get
    End Property

    WriteOnly Property Stretched As Boolean
        Set(value As Boolean)
            IsStretched = value
            SetStepWidthAB()
        End Set
    End Property

    WriteOnly Property StretchFactor As Integer
        Set(value As Integer)
            MyStretchFactor = value
            SetStepWidthAB()
        End Set
    End Property

    Public Sub New()
        MyMathRange = New ClsInterval(-1, 1)
    End Sub

    Private Sub SetStepWidthAB()

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

        If MyStretchFactor > 5 Then
            LocStepWidth = CDec(Math.Max(0.01 - 0.001 * (MyStretchFactor - 6), 0.001))
        Else
            LocStepWidth = CDec(0.1 - 0.02 * (MyStretchFactor - 1))
        End If

        If IsStretched Then

            'in that case, the stepwidth of both pendulums are the same
            'and therefore also the NumberOfApproxStepsB is = 1
            'like NumberOfApproxStepsA
            MyStepWidthA = LocStepWidth
            MyStepWidthB = StepWidthA
            NumberOfApproxStepsB = 1

        Else
            'StepWidthA is set as Standard = 0.1
            MyStepWidthA = CDec(0.1)

            'and StepWidthB is equal locStepWidth and adapted
            'so that StepWidthB x NumberOfApproxStepsB = StepWidthA
            NumberOfApproxStepsB = CInt(Math.Round(StepWidthA / LocStepWidth))
            MyStepWidthB = MyStepWidthA / NumberOfApproxStepsB
        End If

        MyDSA.h = StepWidthA
        MyDSA.NumberOfApproxSteps = 1

        MyDSB.h = StepWidthB
        MyDSB.NumberOfApproxSteps = NumberOfApproxStepsB

    End Sub

    Public Sub ResetIteration()

        MyIterationStatus = ClsGeneral.EnIterationStatus.Stopped
        MyBmpGraphics.Clear(Color.White)
        MyPicDiagram.Refresh()
        MyValueList.Items.Clear()

    End Sub

    Public Sub PrepareDiagram()

        'Draw the x-axis (time - axis) of the Coordinate System
        MyBmpGraphics.Clear(Color.White)
        MyBmpGraphics.DrawLine(New ClsMathpoint(-1, 0), New ClsMathpoint(1, 0), Color.Black, 1)
        MyPicDiagram.Refresh()

    End Sub

    Public Async Function IterationLoop() As Task

        'MyStartposition is already set by the user

        If MyIterationStatus = ClsGeneral.EnIterationStatus.Stopped Then

            'Initializing only in the beginning
            'that gives the possibility to continue after an interrupt
            n = 0

            TraceA = New ClsMathpoint(MyXPositionA, MyDSA.ActualParameter(1))
            TraceB = New ClsMathpoint(MyXPositionB, MyDSB.ActualParameter(1))
            NextTraceA = New ClsMathpoint(MyXPositionA, MyDSA.ActualParameter(1))
            NextTraceB = New ClsMathpoint(MyXPositionB, MyDSB.ActualParameter(1))

            'prepare stepwidth and NumberOfApproxSteps
            If IsStretched Then
                'both pendulums have the same stepwidth
                'and the same number of approx steps
                MyDSB.h = MyDSA.h
                MyDSB.NumberOfApproxSteps = 1
                'remark: PendulumA has already NumberOfApproxSteps = 1
            Else
                MyDSA.h = MyStepWidthA
                'remark: PendulumB is set in CalcStepWidth
                SetStepWidthAB()
            End If

            'the next number is needed because the XShift of 1 pixel
            'corresponds to 0.02
            'and this should be equal to "NumberOfStepsUntilShift x StepWidthA"
            'so that the Shift is done when the Width if 1 pixel is reached by "NumberOfStepsUntilShift x StepWidthA"
            'but the minimum is of course 1
            NumberOfStepsUntilShift = Math.Max(1, CInt(0.02 / MyStepWidthA))

            MyIterationStatus = ClsGeneral.EnIterationStatus.Ready

        End If

        If MyIterationStatus = ClsGeneral.EnIterationStatus.Ready Or MyIterationStatus = ClsGeneral.EnIterationStatus.Interrupted Then

            MyIterationStatus = ClsGeneral.EnIterationStatus.Running
            Do
                n += 1

                TraceA.X = NextTraceA.X
                TraceA.Y = NextTraceA.Y

                TraceB.X = NextTraceB.X
                TraceB.Y = NextTraceB.Y

                MyDSA.Iteration()
                MyDSB.Iteration()

                NextTraceA = New ClsMathpoint(MyXPositionA, MyDSA.ActualParameter(1))
                NextTraceB = New ClsMathpoint(MyXPositionB, MyDSB.ActualParameter(1))

                'Draw the line of movement into the bitmap
                MyBmpGraphics.DrawLine(TraceA, NextTraceA, Color.Green, 1)
                MyBmpGraphics.DrawLine(TraceB, NextTraceB, Color.Red, 1)

                'copy the bitmap
                MyShiftedBmpDiagram = New Bitmap(MyBmpDiagram)

                If n Mod NumberOfStepsUntilShift = 0 Then

                    'Draw this copy right-shifted into the bitmap
                    MyBmpGraphics.Clear(Color.White)
                    MyBmpGraphics.DrawImage(MyShiftedBmpDiagram, XShift, 0)

                    'Coordinate system x-axis
                    MyBmpGraphics.DrawLine(New ClsMathpoint(-1, 0), New ClsMathpoint(CDec(-0.9), 0), Color.Black, 1)

                    'update Picdiagram
                    MyPicDiagram.Refresh()
                End If


                DrawPicPendulums()

                MyValueList.Items.Add(n.ToString("00000") & ": " & (TraceA.Y - TraceB.Y).ToString("0.##########"))

                If n Mod 5 = 0 Then
                    MyLblN.Text = n.ToString

                    Application.DoEvents()
                    Await Task.Delay(2)

                End If

            Loop Until MyIterationStatus = ClsGeneral.EnIterationStatus.Interrupted Or
                MyIterationStatus = ClsGeneral.EnIterationStatus.Stopped


        End If

    End Function

    'SECTOR DRAWINGS

    Public Sub DrawPicPendulums()

        MyPicDiagram.Refresh()

        Dim PositionA As New ClsMathpoint(MyXPositionA, MyDSA.ActualParameter(1))
        Dim SuspensionA As New ClsMathpoint(MyXPositionA, 1)
        Dim PositionB As New ClsMathpoint(MyXPositionB, MyDSB.ActualParameter(1))
        Dim SuspensionB As New ClsMathpoint(MyXPositionB, 1)

        MyPicGraphics.DrawPoint(PositionA, Brushes.Green, 5)
        MyPicGraphics.DrawLine(PositionA, SuspensionA, Color.Green, 2)

        MyPicGraphics.DrawPoint(PositionB, Brushes.Red, 5)
        MyPicGraphics.DrawLine(PositionB, SuspensionB, Color.Red, 2)

    End Sub

End Class
