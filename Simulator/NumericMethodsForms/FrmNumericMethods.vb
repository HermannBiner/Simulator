'This windows compares the movement of a 'real' spring pendulum (green)
'oscillating like cos(t)
'and the movement of a (red) spring pendulum which movement is approximated
'by different numerical methods

'Status Redesign Checked

Imports System.Reflection

Public Class FrmNumericMethods

    Private IsFormLoaded As Boolean
    Private SpringPendulumController As ClsNumericMethodsController

    'User Startposition is set by pushing the left mouse button down
    Private IsMouseDown As Boolean = False

    'Iteration parameters Pendulum A: The real spring pendulum
    Private DSA As ISpringPendulum

    'Iteration parameters Pendulum B: The approximated spring pendulum
    'the y-coordinate is a numeric approach depending on the numeric method
    Private DSB As ISpringPendulum


    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub FrmSpringPendulum_Load(sender As Object, e As EventArgs) Handles Me.Load

        IsFormLoaded = False
        SpringPendulumController = New ClsNumericMethodsController

        'Initialize Language
        InitializeLanguage()

        FillDynamicSystem()

    End Sub

    Private Sub FrmSpringPendulum_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        CboPendulum.SelectedIndex = 0
        ChkStretched.Checked = False

        SetDS()
        IsFormLoaded = True

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

    End Sub

    Private Sub FillDynamicSystem()
        CboPendulum.Items.Clear()

        'Add the classes implementing ISpringPendulum
        'to the Combobox CboPendulum by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(ISpringPendulum)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If types.Count > 0 Then
            Dim DSName As String
            For Each type In types

                'GetString is calle dwith the option IsClass = true
                'That effects that - if there is no Entry in the Resource files LabelsEN, LabelsDE -
                'the name of the Class implementing an Interface is used as default
                'suppressing the extension "Cls"
                DSName = FrmMain.LM.GetString(type.Name, True)
                CboPendulum.Items.Add(DSName)
            Next
        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If

    End Sub

    Private Sub SetDS()

        'This sets the type of PendulumB by Reflection

        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(ISpringPendulum)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If CboPendulum.SelectedIndex >= 0 Then

            Dim SelectedName As String = CboPendulum.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If FrmMain.LM.GetString(type.Name, True) = SelectedName Then
                        DSB = CType(Activator.CreateInstance(type), ISpringPendulum)
                    End If
                Next
            End If

        End If

        DSA = New ClsRealSpringPendulum

        InitializeDS()

        SetDefaultUserData()

        'If the type of iteration changes, everything has to be reset
        ResetIteration()

    End Sub

    'PendulumA is just a real Spring Pendulum
    Private Sub InitializeDS()

        With SpringPendulumController
            .DSA = DSA
            .DSB = DSB
            .PicDiagram = PicDiagram
            .LblSteps = LblSteps
            .ValueList = LstValueList
            .Stretched = ChkStretched.Checked
            .StretchFactor = TrbStepWidth.Value
            'This sets StepWidthAB automatically
        End With

        SpringPendulumController.DrawPicPendulums()

    End Sub
    Private Sub SetDefaultUserData()

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

    End Sub

    Private Sub ResetIteration()

        BtnStart.Enabled = True
        BtnStart.Text = FrmMain.LM.GetString("Start")
        SpringPendulumController.IterationStatus = ClsDynamics.EnIterationStatus.Stopped

        SetDefaultUserData()

        With SpringPendulumController
            .PrepareDiagram()
            .DrawPicPendulums()
        End With

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        If IsFormLoaded Then
            ResetIteration()
        End If
    End Sub

    Private Sub CboPendulum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboPendulum.SelectedIndexChanged
        If IsFormLoaded Then
            SetDS()
        End If
    End Sub

    Private Sub ChkStretched_CheckedChanged(sender As Object, e As EventArgs) Handles ChkStretched.CheckedChanged
        If IsFormLoaded Then
            SpringPendulumController.Stretched = ChkStretched.Checked
            ResetIteration()
        End If
    End Sub

    Private Sub TrbStepWidth_ValueChanged(sender As Object, e As EventArgs) Handles TrbStepWidth.ValueChanged
        If IsFormLoaded Then
            'Set Stepwidth
            SpringPendulumController.StretchFactor = TrbStepWidth.Value
            LblStepWidth.Text = FrmMain.LM.GetString("StepWidth") & " " & SpringPendulumController.StepWidthB.ToString("0.0000")
            ResetIteration()
        End If
    End Sub

    'SECTOR USER START POSITION

    Private Sub PicDiagram_MouseDown(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseDown

        If SpringPendulumController.IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
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
            SpringPendulumController.PrepareDiagram()
            'Setting the Amplitude sets also the ActualParameter(1)
            DSA.Amplitude = Math.Min(Math.Max(PixelqToMathy(Mouseposition.Y), CDec(-0.95)), CDec(0.95))
            DSB.Amplitude = Math.Min(Math.Max(PixelqToMathy(Mouseposition.Y), CDec(-0.95)), CDec(0.95))
            SpringPendulumController.DrawPicPendulums()
        End If

    End Sub

    Private Function PixelqToMathy(q As Integer) As Decimal

        Dim y As Decimal = SpringPendulumController.MathRange.B - (q * SpringPendulumController.MathRange.IntervalWidth _
            / PicDiagram.Height)

        Return y
    End Function

    'SECTOR ITERATION

    Private Async Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click

        If IsFormLoaded Then
            BtnStart.Enabled = False
            BtnStart.Text = FrmMain.LM.GetString("Continue")
            BtnReset.Enabled = False

            'The loop controls as well the Iterationstatus
            Await SpringPendulumController.IterationLoop()
        End If
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click

        If IsFormLoaded Then
            BtnStart.Enabled = True
            BtnReset.Enabled = True
            SpringPendulumController.IterationStatus = ClsDynamics.EnIterationStatus.Interrupted
        End If
    End Sub

End Class