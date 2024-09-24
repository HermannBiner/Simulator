'This Form is the User Interface for all Investigations of different Pendulums
'like Double Pendulum, Combined Pendulum or Shake Pendulum
'it is based on the interfaces IPendulum
'that are implemented by the according classes ClsDoublePendulum, ClsCombinedPendulum etc.
'see mathematical documentation
'if other Pendulums are programmed, the according classes have just to implement this interfaces

'Status Checked

Imports System.Reflection

Public Class FrmPendulum

    Private IsFormLoaded As Boolean
    Private FC As ClsPendulumController

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()
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

        Text = FrmMain.LM.GetString("Pendulum")
        LblPendulum.Text = FrmMain.LM.GetString("Pendulum")

        'LblSteps contains the  #Steps
        LblNumberOfSteps.Text = FrmMain.LM.GetString("NumberOfSteps")

        'LblAdditionParameter, LblP1 ... LblP5 is set by the Active Pendulum
        BtnTakeOverStartParameter.Text = FrmMain.LM.GetString("TakeOver")
        GrpStartParameter.Text = FrmMain.LM.GetString("StartParameter")
        BtnReset.Text = FrmMain.LM.GetString("ResetIteration")
        BtnStart.Text = FrmMain.LM.GetString("Start")
        LblStepWidth.Text = FrmMain.LM.GetString("StepWidth") & ": "
        LblTypeofPhaseportrait.Text = FrmMain.LM.GetString("TypeofPhaseportrait")
        BtnDefault.Text = FrmMain.LM.GetString("DefaultUserData")

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

    Private Sub TrbStepWide_Scroll(sender As Object, e As EventArgs) Handles TrbStepWidth.Scroll
        If IsFormLoaded Then
            FC.SetStepWidth()
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


    'SECTOR SET STARTPOSITION

    Private Sub PicDiagram_MouseDown(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseDown
        If IsFormLoaded Then
            FC.MouseDown(e)
        End If
    End Sub

    Private Sub PicDiagram_MouseMove(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseMove
        If IsFormLoaded Then
            FC.MouseMoving(e)
        End If
    End Sub

    Private Sub PicDiagram_MouseUp(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseUp
        If IsFormLoaded Then
            FC.MouseUp()
        End If
    End Sub
End Class