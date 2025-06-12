'This Form is the User Interface for all Investigations of different Pendulums
'like Double Pendulum, Combined Pendulum or Shake Pendulum
'it is based on the interfaces IPendulum
'that are implemented by ClsPendulumAbstract
'the according classes ClsDoublePendulum, ClsCombinedPendulum etc. heritates from this class
'see mathematical documentation
'if other Pendulums are programmed, the according classes have just to implement this interfaces

'Status Checked

Public Class FrmPendulum

    Private IsFormLoaded As Boolean
    Private FC As ClsPendulumController

    Private ReadOnly LM As ClsLanguageManager
    Private IsAdjusting As Boolean

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()
        LM = ClsLanguageManager.LM
    End Sub

    Private Sub FrmPendulum_Load(sender As Object, e As EventArgs) Handles Me.Load

        IsFormLoaded = False
        FC = New ClsPendulumController(Me)

        'Initialize Language
        InitializeLanguage()
        FC.FillDynamicSystem()
    End Sub

    Private Sub FrmPendulum_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FC.SetDS()
        IsFormLoaded = True
    End Sub

    Private Sub InitializeLanguage()

        Text = LM.GetString("Pendulum")

        'LblSteps contains the  #Steps
        LblNumberOfSteps.Text = LM.GetString("NumberOfSteps")

        'LblAdditionParameter, LblP1 ... LblP5 is set by the Active Pendulum
        BtnTakeOverStartParameter.Text = LM.GetString("TakeOver")
        GrpStartParameter.Text = LM.GetString("StartParameter")
        BtnReset.Text = LM.GetString("ResetIteration")
        LblStepWidth.Text = LM.GetString("StepWidth") & ": "
        LblTypeofPhaseportrait.Text = LM.GetString("TypeofPhaseportrait")
        BtnDefault.Text = LM.GetString("DefaultUserData")
        BtnCreatePendulum.Text = LM.GetString("CreatePendulum")
    End Sub

    'LAYOUT

    Private Sub FrmPendulum_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        AdjustLayout()
    End Sub

    Private Sub SplitContainer1_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer1.SplitterMoved
        If IsFormLoaded Then
            AdjustLayout()
        End If
    End Sub

    Private Sub FrmPendulum_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If IsFormLoaded Then
            AdjustLayout()
        End If
    End Sub

    Private Sub AdjustLayout()
        'to avoid a loop
        If IsAdjusting Then
            Exit Sub
        Else
            IsAdjusting = True
            If WindowState <> FormWindowState.Minimized Then
                'we have to make sure that the diagram is square
                Dim DiagramSize As Integer = Math.Max(Math.Min(SplitContainer1.Panel1.Width, SplitContainer1.Panel1.Height), 10)
                PicDiagram.Width = DiagramSize
                PicDiagram.Height = DiagramSize
                SplitContainer1.SplitterDistance = DiagramSize
                PicDiagram.Left = SplitContainer1.SplitterDistance - DiagramSize
                PicDiagram.Top = 5
                SplitContainer2.SplitterDistance = Math.Max(SplitContainer2.Panel1.MinimumSize.Width, CboPendulum.Width + 20)

                If IsFormLoaded Then
                    FC.InitializeMe()
                    FC.ResetIteration()
                End If
            End If
            IsAdjusting = False
        End If
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        If IsFormLoaded Then
            FC.ResetIteration()
        End If
    End Sub

    Private Sub BtnDefault_Click(sender As Object, e As EventArgs) Handles BtnDefault.Click
        If IsFormLoaded Then
            FC.ResetIteration()
            FC.SetDefaultUserData()
        End If
    End Sub

    Private Sub CboPendulum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboPendulum.SelectedIndexChanged
        If IsFormLoaded Then
            FC.SetDS()
        End If
    End Sub

    Private Sub TrbAdditionalParameter_Scroll(sender As Object, e As EventArgs) Handles TrbAdditionalParameter.Scroll
        If IsFormLoaded Then
            FC.SetTrbAdditionalParameter()
        End If
    End Sub

    Private Sub CboTypeofPhaseportrait_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboTypeofPhaseportrait.SelectedIndexChanged
        If IsFormLoaded Then
            FC.SetTypeOfPhasePortrait()
        End If
    End Sub

    Private Sub TrbStepWidth_Scroll(sender As Object, e As EventArgs) Handles TrbStepWidth.Scroll
        If IsFormLoaded Then
            FC.SetStepWidth()
        End If
    End Sub

    Private Sub BtnCreatePendulum_Click(sender As Object, e As EventArgs) Handles BtnCreatePendulum.Click
        If IsFormLoaded Then
            FC.CreateOrRemovePendulum()
        End If
    End Sub

    Private Sub BtnTakeOverStartParameter_Click(sender As Object, e As EventArgs) Handles BtnTakeOverStartParameter.Click
        If IsFormLoaded Then
            FC.TakeOverStartParameter()
        End If
    End Sub

    'SECTOR ITERATION

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        If IsFormLoaded Then
            FC.StartIteration()
        End If
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click

        If IsFormLoaded Then
            FC.StopIteration()
        End If
    End Sub

    'SECTOR SET STARTPARAMETER

    Private Sub PicDiagram_MouseDown(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseDown
        If IsFormLoaded Then
            FC.MouseDown(e)
        End If
    End Sub

    Private Sub PicDiagram_MouseMove(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseMove
        If IsFormLoaded Then
            FC.MouseMove(e)
        End If
    End Sub

    Private Sub PicDiagram_MouseUp(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseUp
        If IsFormLoaded Then
            FC.MouseUp()
        End If
    End Sub

End Class