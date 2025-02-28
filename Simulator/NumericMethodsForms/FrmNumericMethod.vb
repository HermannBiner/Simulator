'This windows compares the movement of a 'real' spring pendulum (green)
'oscillating like cos(t)
'and the movement of a (red) spring pendulum which movement is approximated
'by different numerical methods

'Status Redesign Checked

Public Class FrmNumericMethod

    Private IsFormLoaded As Boolean
    Private FC As ClsNumericMethodController

    Private ReadOnly LM As ClsLanguageManager

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()
        LM = ClsLanguageManager.LM
    End Sub

    Private Sub FrmSpringPendulum_Load(sender As Object, e As EventArgs) Handles Me.Load

        IsFormLoaded = False
        FC = New ClsNumericMethodController(Me)

        'Initialize Language
        InitializeLanguage()
        FC.FillDynamicSystem()
    End Sub

    Private Sub FrmSpringPendulum_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FC.SetDS()
        IsFormLoaded = True
    End Sub

    Private Sub InitializeLanguage()

        Text = LM.GetString("SpringPendulum")
        BtnReset.Text = LM.GetString("ResetIteration")
        LblNumMethod.Text = LM.GetString("NumericMethods")
        LblStepWidth.Text = LM.GetString("StepWidth") & " 0.02"
        LblNumberOfSteps.Text = LM.GetString("NumberOfSteps")
        ChkStretched.Text = LM.GetString("StretchedMode")
        LblDifference.Text = LM.GetString("Difference")
        BtnDefault.Text = LM.GetString("DefaultUserData")

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

    Private Sub ChkStretched_CheckedChanged(sender As Object, e As EventArgs) Handles ChkStretched.CheckedChanged
        If IsFormLoaded Then
            FC.ResetIteration()
            FC.SetStepWidthAB()
        End If
    End Sub

    Private Sub TrbStepWidth_Scroll(sender As Object, e As EventArgs) Handles TrbStepWidth.Scroll
        If IsFormLoaded Then
            FC.SetStepWidthAB()
        End If
    End Sub

    'SECTOR SET STARTPARAMETER

    Private Sub PicDiagram_MouseDown(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseDown
        If IsFormLoaded Then
            FC.MouseDown(e)
        End If

    End Sub

    Private Sub PicDiagram_MouseUp(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseUp

        If IsFormLoaded Then
            FC.MouseUp(e)
        End If

    End Sub

    Private Sub PicDiagram_MouseMove(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseMove

        If IsFormLoaded Then
            FC.MouseMove(e)
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

End Class