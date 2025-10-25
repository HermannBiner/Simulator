'This class contains the Iteration Controller for FrmSpringPendulum

'Status Checked

Imports System.Reflection

Public Class ClsNumericMethodController

    'Iteration parameters Pendulum A: The real spring pendulum
    Private DSA As INumericMethod

    'Iteration parameters Pendulum B: The approximated spring pendulum
    'the y-coordinate is a numeric approach depending on the chosen method
    Private DSB As INumericMethod

    Private ReadOnly MyForm As FrmNumericMethod

    Private ReadOnly LM As ClsLanguageManager

    'Mathematical Interval in y-direction
    Private ReadOnly MathInterval As ClsInterval

    'Draws into the picturebox
    'this is drawing the actual status of the pendulums
    Private PicGraphics As ClsGraphicTool

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
    Private BmpDiagram As Bitmap
    Private ShiftedBmpDiagram As Bitmap
    Private ReadOnly XShift As Integer = 1
    Private NumberOfStepsUntilShift As Integer = 1

    'Draws persistently into the bitmap
    'this is to draw the track of the pendulum-movement
    Private BmpGraphics As ClsGraphicTool

    'Iteration control
    Private IterationStatus As ClsDynamics.EnIterationStatus

    'Status Parameters
    Private n As Integer '#Steps

    'The X-Position of both Pendulums
    'this is a fixed value
    Const XPositionA As Decimal = CDec(-0.97)
    Const XPositionB As Decimal = CDec(-0.94)

    'to draw the trace we need:
    Private TraceA As ClsMathpoint
    Private NextTraceA As ClsMathpoint

    Private TraceB As ClsMathpoint
    Private NextTraceB As ClsMathpoint

    'and the step width of the iteration is 
    Private StepWidthA As Decimal = CDec(0.1)

    'CDec(0.1) is the Standard, but the StepWidthB is calculated
    'in SetStepWidthB based on TrbStepWidth.value
    Private StepWidthB As Decimal = CDec(0.1)

    'Setting UsereStartPosition
    Private IsMouseDown As Boolean = False

    'SECTOR INITIALIZATION

    Public Sub New(Form As FrmNumericMethod)
        MyForm = Form
        LM = ClsLanguageManager.LM
        MathInterval = New ClsInterval(-1, 1)
    End Sub

    Public Sub FillDynamicSystem()

        MyForm.CboPendulum.Items.Clear()

        'Add the classes implementing ISpringPendulum
        'to the Combobox CboPendulum by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(INumericMethod)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If types.Count > 0 Then
            Dim DSName As String
            For Each type In types

                'GetString is calle dwith the option IsClass = true
                'That effects that - if there is no Entry in the Resource files LabelsEN, LabelsDE -
                'the name of the Class implementing an Interface is used as default
                'suppressing the extension "Cls"
                DSName = LM.GetString(type.Name, True)
                MyForm.CboPendulum.Items.Add(DSName)
            Next
        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If
        MyForm.CboPendulum.SelectedIndex = 0

    End Sub

    Public Sub SetDS()

        'This sets the type of PendulumB by Reflection

        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(INumericMethod)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If MyForm.CboPendulum.SelectedIndex >= 0 Then

            Dim SelectedName As String = MyForm.CboPendulum.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If LM.GetString(type.Name, True) = SelectedName Then
                        DSB = CType(Activator.CreateInstance(type), INumericMethod)
                        Exit For
                    End If
                Next
            End If

        End If

        DSA = New ClsRealSpringPendulum

        InitializeMe()

        SetDefaultUserData()

        'If the type of iteration changes, everything has to be reset
        ResetIteration()

    End Sub

    'PendulumA is just a real Spring Pendulum
    Public Sub InitializeMe()

        PicGraphics = New ClsGraphicTool(MyForm.PicDiagram, MathInterval, MathInterval)
        BmpDiagram = New Bitmap(MyForm.PicDiagram.Width, MyForm.PicDiagram.Height)
        MyForm.PicDiagram.Image = BmpDiagram
        BmpGraphics = New ClsGraphicTool(BmpDiagram, MathInterval, MathInterval)

        MyForm.ChkStretched.Checked = False
        DrawPicPendulums()
    End Sub

    Public Sub SetDefaultUserData()

        'all default start parameters are zero
        With DSA
            .Amplitude = CDec(0.5) 'this sets .ActualParameter(1)
            .ActualParameter(0) = 0
            .ActualParameter(2) = 0
        End With

        With DSB
            .Amplitude = CDec(0.5) 'this sets .ActualParameter(1)
            .ActualParameter(0) = 0
            .ActualParameter(2) = 0
        End With

        PrepareDiagram()
        DrawPicPendulums()
    End Sub

    Public Sub SetStepWidthAB()

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
        Dim StretchFactor As Integer = MyForm.TrbStepWidth.Value

        If StretchFactor > 5 Then
            LocStepWidth = CDec(Math.Max(0.01 - 0.001 * (StretchFactor - 6), 0.001))
        Else
            LocStepWidth = CDec(0.1 - 0.02 * (StretchFactor - 1))
        End If

        If MyForm.ChkStretched.Checked Then

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

        DSA.h = StepWidthA
        DSA.NumberOfApproxSteps = 1

        DSB.h = StepWidthB
        DSB.NumberOfApproxSteps = NumberOfApproxStepsB

        MyForm.LblStepWidth.Text = LM.GetString("StepWidth") & ": " & LocStepWidth.ToString

    End Sub

    Public Sub ResetIteration()

        SetControlsEnabled(True)
        IterationStatus = ClsDynamics.EnIterationStatus.Stopped
        BmpGraphics.Clear(Color.White)
        MyForm.PicDiagram.Refresh()

        MyForm.LstValueList.Items.Clear()
        MyForm.BtnStart.Enabled = True
        MyForm.BtnStart.Text = LM.GetString("Start")

        n = 0
        MyForm.LblSteps.Text = "0"

        PrepareDiagram()
        DrawPicPendulums()
    End Sub

    Private Sub PrepareDiagram()

        'Draw the x-axis (time - axis) of the Coordinate System
        BmpGraphics.Clear(Color.White)
        BmpGraphics.DrawLine(New ClsMathpoint(-1, 0), New ClsMathpoint(1, 0), Color.Black, 1)
        MyForm.PicDiagram.Refresh()

    End Sub

    Private Sub SetControlsEnabled(IsEnabled As Boolean)
        With MyForm
            .BtnStart.Enabled = IsEnabled
            .BtnReset.Enabled = IsEnabled
            .BtnDefault.Enabled = IsEnabled
            .CboPendulum.Enabled = IsEnabled
            .ChkStretched.Enabled = IsEnabled
        End With
    End Sub


    'SECTOR ITERATION

    Public Async Sub StartIteration()

        'UserData are always OK
        With MyForm
            .BtnStart.Text = LM.GetString("Continue")
            .Cursor = Cursors.WaitCursor
        End With

        SetControlsEnabled(False)

        'MyStartposition is already set by the user

        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then

            'Initializing only in the beginning
            'that gives the possibility to continue after an interrupt
            n = 0

            TraceA = New ClsMathpoint(XPositionA, DSA.ActualParameter(1))
            TraceB = New ClsMathpoint(XPositionB, DSB.ActualParameter(1))
            NextTraceA = New ClsMathpoint(XPositionA, DSA.ActualParameter(1))
            NextTraceB = New ClsMathpoint(XPositionB, DSB.ActualParameter(1))

            'prepare stepwidth and NumberOfApproxSteps
            If MyForm.ChkStretched.Checked Then
                'both pendulums have the same stepwidth
                'and the same number of approx steps
                DSB.h = DSA.h
                DSB.NumberOfApproxSteps = 1
                'remark: PendulumA has already NumberOfApproxSteps = 1
            Else
                DSA.h = StepWidthA
                'remark: PendulumB is set in CalcStepWidth
                SetStepWidthAB()
            End If

            'the next number is needed because the XShift of 1 pixel
            'corresponds to 0.02
            'and this should be equal to "NumberOfStepsUntilShift x StepWidthA"
            'so that the Shift is done when the Width if 1 pixel is reached by "NumberOfStepsUntilShift x StepWidthA"
            'but the minimum is of course 1
            NumberOfStepsUntilShift = Math.Max(1, CInt(0.02 / StepWidthA))

            IterationStatus = ClsDynamics.EnIterationStatus.Ready

        End If

        If IterationStatus = ClsDynamics.EnIterationStatus.Ready Or IterationStatus = ClsDynamics.EnIterationStatus.Interrupted Then

            IterationStatus = ClsDynamics.EnIterationStatus.Running

            'The loop controls as well the Iterationstatus
            Await IterationLoop()
        End If
    End Sub

    Public Async Function IterationLoop() As Task

        Do
                n += 1

                TraceA.X = NextTraceA.X
                TraceA.Y = NextTraceA.Y

                TraceB.X = NextTraceB.X
                TraceB.Y = NextTraceB.Y

                DSA.Iteration()
                DSB.Iteration()

                NextTraceA = New ClsMathpoint(XPositionA, DSA.ActualParameter(1))
                NextTraceB = New ClsMathpoint(XPositionB, DSB.ActualParameter(1))

                'Draw the line of movement into the bitmap
                BmpGraphics.DrawLine(TraceA, NextTraceA, Color.Green, 1)
            BmpGraphics.DrawLine(TraceB, NextTraceB, Color.Red, 1)

            'copy the bitmap
            ShiftedBmpDiagram = New Bitmap(BmpDiagram)

            If n Mod NumberOfStepsUntilShift = 0 Then

                    'Draw this copy right-shifted into the bitmap
                    BmpGraphics.Clear(Color.White)
                BmpGraphics.DrawImage(ShiftedBmpDiagram, XShift, 0)
                ShiftedBmpDiagram.Dispose()

                'Coordinate system x-axis
                BmpGraphics.DrawLine(New ClsMathpoint(-1, 0), New ClsMathpoint(CDec(-0.9), 0), Color.Black, 1)
                    Try
                        'update Picdiagram
                        MyForm.PicDiagram.Refresh()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try

                End If

                DrawPicPendulums()

                MyForm.LstValueList.Items.Add(n.ToString("00000") & ": " & (TraceA.Y - TraceB.Y).ToString("0.##########"))

                If n Mod 50 = 0 Then
                    MyForm.LblSteps.Text = n.ToString
                    Await Task.Delay(1)

                End If

            Loop Until IterationStatus = ClsDynamics.EnIterationStatus.Interrupted Or
                IterationStatus = ClsDynamics.EnIterationStatus.Stopped

    End Function

    Public Sub StopIteration()

        MyForm.BtnStart.Enabled = True
        MyForm.BtnReset.Enabled = True
        MyForm.Cursor = Cursors.Arrow
        IterationStatus = ClsDynamics.EnIterationStatus.Interrupted
    End Sub

    Private Sub DrawPicPendulums()

        MyForm.PicDiagram.Refresh()

        Dim PositionA As New ClsMathpoint(XPositionA, DSA.ActualParameter(1))
        Dim SuspensionA As New ClsMathpoint(XPositionA, 1)
        Dim PositionB As New ClsMathpoint(XPositionB, DSB.ActualParameter(1))
        Dim SuspensionB As New ClsMathpoint(XPositionB, 1)

        PicGraphics.DrawPoint(PositionA, Brushes.Green, 5)
        PicGraphics.DrawLine(PositionA, SuspensionA, Color.Green, 2)

        PicGraphics.DrawPoint(PositionB, Brushes.Red, 5)
        PicGraphics.DrawLine(PositionB, SuspensionB, Color.Red, 2)

    End Sub

    'SECTOR SET STARTPARAMETER

    Public Sub MouseDown(e As MouseEventArgs)

        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            If e.X < 100 Then

                MyForm.Cursor = Cursors.Hand
                IsMouseDown = True

                'Now, Moving the Mouse moves the pendulum as well
                MouseMove(e)

            End If
        End If
    End Sub

    Public Sub MouseMove(e As MouseEventArgs)

        If IsMouseDown Then
            'Because the Cursor is "Hand", the Mouse Position is adjusted a bit
            Dim Mouseposition As New Point With {
            .X = e.X + 2,
            .Y = e.Y - 25
        }

            If Mouseposition.X >= 100 Then
                IsMouseDown = False
                MyForm.Cursor = Cursors.Arrow
            Else
                PrepareDiagram()
                'Setting the Amplitude sets also the ActualParameter(1)
                DSA.Amplitude = Math.Min(Math.Max(PixelqToMathy(Mouseposition.Y), CDec(-0.95)), CDec(0.95))
                DSB.Amplitude = Math.Min(Math.Max(PixelqToMathy(Mouseposition.Y), CDec(-0.95)), CDec(0.95))
                DrawPicPendulums()
            End If
        End If
    End Sub

    Public Sub MouseUp(e As MouseEventArgs)
        'Has only an effect, if the Mouse was down
        If IsMouseDown Then

            'The Position of the Mouse sets the Position of the pendulum
            'e: Mouseposition is relative to PicDiagram
            Dim Mouseposition As Point
            Mouseposition.X = e.X + 2
            Mouseposition.Y = e.Y - 25

            'The Mouse gets its normal behaviour again
            MyForm.Cursor = Cursors.Arrow
            IsMouseDown = False
        End If
    End Sub

    Private Function PixelqToMathy(q As Integer) As Decimal

        Dim y As Decimal = MathInterval.B - (q * MathInterval.IntervalWidth _
            / MyForm.PicDiagram.Height)

        Return y
    End Function

End Class
