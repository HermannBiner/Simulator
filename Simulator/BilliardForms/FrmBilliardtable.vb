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

    Private ReadOnly LM As ClsLanguageManager
    Private IsAdjusting As Boolean

    'SECTOR INITIALIZATION

    Public Sub New()
        LM = ClsLanguageManager.LM
        'This is necessary for the designer
        InitializeComponent()
        AutoScaleMode = AutoScaleMode.Dpi

    End Sub


    Private Sub FrmBilliardTable_Load(sender As Object, e As EventArgs) Handles Me.Load

        IsFormLoaded = False
        FC = New ClsBilliardTableController(Me)

        'Initialize Language
        InitializeLanguage()
        FC.FillDynamicSystem()
    End Sub

    Private Sub FrmBilliardTable_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        AdjustLayout()
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
                SplitContainer2.SplitterDistance = Math.Max(SplitContainer2.Panel1.MinimumSize.Width, CboBilliardTable.Width + 15)

                If IsFormLoaded Then
                    FC.InitializeMe()
                    FC.ResetIteration()
                End If
            End If
            IsAdjusting = False
        End If
    End Sub

    Private Sub FrmBilliardtable_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FC.SetDS()
        IsFormLoaded = True
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

    'SECTOR CREATE NEW OBJECT

    Private Sub BtnNewBall_Click(sender As Object, e As EventArgs) Handles BtnNewBall.Click
        If IsFormLoaded Then
            FC.CreateNewBall()
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

    Private Sub BtnTakeOverStartParameter_Click(sender As Object, e As EventArgs) Handles BtnTakeOverStartParameter.Click
        If IsFormLoaded Then
            FC.TakeOverStartParameter()
        End If
    End Sub

    Private Sub BtnPhasePortrait_Click(sender As Object, e As EventArgs) Handles BtnPhasePortrait.Click

        If IsFormLoaded Then
            FC.PrepareBallsForPhaseportrait()
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

    Private Sub SplitContainer1_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer1.SplitterMoved
        If IsFormLoaded Then
            AdjustLayout()
        End If
    End Sub

    Private Sub FrmBilliardTable_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If IsFormLoaded Then
            Me.Width = Math.Max(Me.Width, 600)
            Me.Height = Math.Max(Me.Height, 600)
            AdjustLayout()
        End If
    End Sub

End Class