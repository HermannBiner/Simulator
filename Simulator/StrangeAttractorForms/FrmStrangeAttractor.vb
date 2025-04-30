'This form shows different strange attractors

'Status Tested

Public Class FrmStrangeAttractor
    Private IsFormLoaded As Boolean
    Private FC As ClsStrangeAttractorController

    Private ReadOnly LM As ClsLanguageManager
    Private IsAdjusting As Boolean

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()
        LM = ClsLanguageManager.LM

    End Sub

    Private Sub FrmStrangeAttractor_Load(sender As Object, e As EventArgs) Handles Me.Load

        IsFormLoaded = False
        FC = New ClsStrangeAttractorController(Me)

        'we have to make sure that the diagram is square
        Dim DiagramSize As Integer
        If PicDiagram.Width < PicDiagram.Height Then
            DiagramSize = PicDiagram.Width
            PicDiagram.Height = DiagramSize
        Else
            DiagramSize = PicDiagram.Height
            PicDiagram.Width = DiagramSize
        End If

        'Initialize Language
        InitializeLanguage()
        FC.FillDynamicSystem()
    End Sub

    Private Sub FrmStrangeAttractor_Resize(sender As Object, e As EventArgs) Handles Me.Resize
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
                Dim DiagramSize As Integer = Math.Max(Math.Min(SplitContainer.Panel1.Width, SplitContainer.Panel1.Height), 10)
                PicDiagram.Width = DiagramSize
                PicDiagram.Height = DiagramSize
                SplitContainer.SplitterDistance = DiagramSize
                PicDiagram.Left = SplitContainer.SplitterDistance - DiagramSize
                PicDiagram.Top = 5
                If IsFormLoaded Then
                    FC.InitializeMe()
                    FC.ResetIteration()
                End If
            End If
            IsAdjusting = False
        End If

    End Sub

    Private Sub FrmStrangeAttractor_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FC.SetDS()
        IsFormLoaded = True
    End Sub

    Private Sub InitializeLanguage()

        Text = LM.GetString("StrangeAttractor")
        BtnReset.Text = LM.GetString("ResetIteration")
        BtnDefault.Text = LM.GetString("DefaultUserData")
        LblStepWidth.Text = LM.GetString("StepWidth")
        LblStrangeAttractor.Text = LM.GetString("StrangeAttractor")
        LblStartpointSets.Text = LM.GetString("StartpointSets")
        LblNumberOfSteps.Text = LM.GetString("NumberOfSteps")
        GrpView.Text = LM.GetString("Projection")
        GrpStartPoint.Text = LM.GetString("StartPointCoordinates")
        BtnTakeOverPointSet.Text = LM.GetString("TakeOverPointSet")

    End Sub

    Private Sub BtnDefault_Click(sender As Object, e As EventArgs) Handles BtnDefault.Click
        If IsFormLoaded Then
            FC.SetDefaultUserData()
        End If
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        If IsFormLoaded Then
            FC.ResetIteration()
        End If
    End Sub

    Private Sub BtnTakeOverPointSet_Click(sender As Object, e As EventArgs) Handles BtnTakeOverPointSet.Click
        If IsFormLoaded Then
            FC.TakeOverPointSet()
        End If
    End Sub

    Private Sub CboStrangeAttractor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboStrangeAttractor.SelectedIndexChanged
        If IsFormLoaded Then
            FC.SetDS()
        End If
    End Sub

    Private Sub CboStartpointSets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboStartpointSets.SelectedIndexChanged
        If IsFormLoaded Then
            FC.SetStartPointSet()
        End If
    End Sub

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        If IsFormLoaded Then
            FC.StartIteration()
            'FC.DebugIteration()
        End If
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click
        If IsFormLoaded Then
            FC.StopIteration()
        End If
    End Sub

    Private Sub TrbStepWidth_Scroll(sender As Object, e As EventArgs) Handles TrbStepWidth.Scroll
        If IsFormLoaded Then
            FC.SetStepWidthFromTrb()
        End If
    End Sub

    Private Sub TrbDSParameter_Scroll(sender As Object, e As EventArgs) Handles TrbDSParameter.Scroll
        If IsFormLoaded Then
            FC.SetDSParameterFromTrb()
        End If
    End Sub

    'SECTOR SET VIEW

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
            FC.MouseUp(e)
        End If
    End Sub

    Private Sub Opt3D_CheckedChanged(sender As Object, e As EventArgs) Handles Opt3D.CheckedChanged
        If IsFormLoaded Then
            FC.ShowProjectionAngles()
        End If
    End Sub

    Private Sub OptXY_CheckedChanged(sender As Object, e As EventArgs) Handles OptXY.CheckedChanged
        If IsFormLoaded Then
            FC.ShowProjectionAngles()
        End If
    End Sub

    Private Sub OptXZ_CheckedChanged(sender As Object, e As EventArgs) Handles OptXZ.CheckedChanged
        If IsFormLoaded Then
            FC.ShowProjectionAngles()
        End If
    End Sub

    Private Sub SplitContainer_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer.SplitterMoved
        If IsFormLoaded Then
            AdjustLayout()
        End If
    End Sub

    Private Sub FrmStrangeAttractor_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If IsFormLoaded Then
            Me.Width = Math.Max(Me.Width, 600)
            Me.Height = Math.Max(Me.Height, 600)
            AdjustLayout()
        End If
    End Sub
End Class