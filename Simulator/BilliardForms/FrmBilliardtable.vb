'This Form is the User Interface for all Investigations of different Billiards
'like elliptic, stadium or oval
'it is based on the interfaces IBilliardBall
'that are implemented by the according classes ClsEllipticBilliardTable, ClsEllipticBilliardBall, etc.
'see mathematical documentation
'if other Billiards are programmed, the according classes have just to implement this interface

'Status Checked

Public Class FrmBilliardtable

    'Controlling Form Load
    Private IsFormLoaded As Boolean
    Private FC As ClsBilliardTableController

    Private LM As ClsLanguageManager

    'SECTOR INITIALIZATION

    Public Sub New()
        LM = ClsLanguageManager.LM
        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub InitializeLanguage()

        Text = LM.GetString("Billiard")
        BtnPhasePortrait.Text = LM.GetString("FillPhasePortrait")
        LblNumberOfSteps.Text = LM.GetString("NumberOfSteps")
        LblBilliardTable.Text = LM.GetString("BilliardTable")
        LblAlfa.Text = LM.GetString("Alfa")
        BtnTakeOverStartParameter.Text = LM.GetString("TakeOver")
        GrpStartParameter.Text = LM.GetString("StartParameter")
        LblPhasePortrait.Text = LM.GetString("PhasePortrait") & ": t, alfa"
        LblSpeed.Text = LM.GetString("BallSpeed") & " " & TrbSpeed.Value.ToString
        LblBallColor.Text = LM.GetString("BallColor")
        BtnNewBall.Text = LM.GetString("NewBall")
        BtnReset.Text = LM.GetString("ResetIteration")
        BtnNextStep.Text = LM.GetString("NextStep")
        LblParameterc.Text = LM.GetString("ParameterC")
        BtnDefault.Text = LM.GetString("DefaultUserData")
        LblProtocol.Text = LM.GetString("Protocol")
        ChkProtocol.Text = LM.GetString("Protocol")

        CboBallColor.Items.Clear()

        'the following order of adding the iteration type is relevant!
        'there is at the moment no better concept implemented to identify the type of Billiard
        CboBallColor.Items.Add(LM.GetString("Red"))
        CboBallColor.Items.Add(LM.GetString("Green"))
        CboBallColor.Items.Add(LM.GetString("Blue"))
        CboBallColor.Items.Add(LM.GetString("Black"))
        CboBallColor.Items.Add(LM.GetString("Magenta"))

    End Sub

    Private Sub FrmBilliardTable_Load(sender As Object, e As EventArgs) Handles Me.Load

        IsFormLoaded = False
        FC = New ClsBilliardTableController(Me)

        'Initialize Language
        InitializeLanguage()
        FC.FillDynamicSystem()
    End Sub

    Private Sub FrmBilliardtable_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FC.SetDS()
        IsFormLoaded = True
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        If IsFormLoaded Then
            FC.ResetIteration()
        End If
    End Sub

    Private Sub CboBilliardTable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboBilliardTable.SelectedIndexChanged
        If IsFormLoaded Then
            FC.SetDS()
        End If
    End Sub

    Private Sub CboBallColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboBallColor.SelectedIndexChanged
        If IsFormLoaded Then
            FC.SetColor()
        End If
    End Sub

    Private Sub TrbSpeed_ValueChanged(sender As Object, e As EventArgs) Handles TrbSpeed.ValueChanged
        If IsFormLoaded Then
            LblSpeed.Text = LM.GetString("BallSpeed") & " " & TrbSpeed.Value.ToString
            FC.SetSpeed()
        End If
    End Sub

    Private Sub TrbParameterC_Scroll(sender As Object, e As EventArgs) Handles TrbParameterC.Scroll
        If IsFormLoaded Then
            TxtParameter.Text = CDec(TrbParameterC.Value * 0.01).ToString
            FC.SetParameterC()
        End If
    End Sub

    Private Sub TxtParameter_LostFocus(sender As Object, e As EventArgs) Handles TxtParameter.LostFocus
        If IsFormLoaded Then
            FC.SetTrbC()
        End If
    End Sub

    'SECTOR GENERATE A NEW BALL
    Private Sub BtnNewBall_Click(sender As Object, e As EventArgs) Handles BtnNewBall.Click
        If IsFormLoaded Then
            FC.CreateNewBall()
        End If
    End Sub

    'SECTOR SET STARTPOSITION AND POSITION OF THE FIRST HIT

    Private Sub PicBilliardTable_MouseDown(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseDown
        If IsFormLoaded Then
            FC.MouseDown(e)
        End If
    End Sub

    Private Sub PicBilliardTable_MouseUp(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseUp
        If IsFormLoaded Then
            FC.MouseUp(e)
        End If
    End Sub

    Private Sub PicBilliardTable_MouseMove(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseMove
        If IsFormLoaded Then
            FC.MouseMoving(e)
        End If
    End Sub

    Private Sub BtnTakeOverStartParameter_Click(sender As Object, e As EventArgs) Handles BtnTakeOverStartParameter.Click
        If IsFormLoaded Then
            FC.TakeOverStartParameter()
        End If
    End Sub

    'SECTOR ITERATION

    Private Sub BtnNextStep_Click(sender As Object, e As EventArgs) Handles BtnNextStep.Click

        If IsFormLoaded Then
            FC.NextStep()
        End If
    End Sub

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

    Private Sub BtnPhasePortrait_Click(sender As Object, e As EventArgs) Handles BtnPhasePortrait.Click

        If IsFormLoaded Then
            FC.PrepareBallsForPhasePortrait()
        End If
    End Sub

    Private Sub BtnDefault_Click(sender As Object, e As EventArgs) Handles BtnDefault.Click
        If IsFormLoaded Then
            FC.ResetIteration()
            FC.SetDefaultUserData()
        End If
    End Sub
End Class