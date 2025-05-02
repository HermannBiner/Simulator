'This form is the user interface to investigate the Hopf Bifurcation
'for the Lorenz-System and the Roessler-System
'It shows the dependence of the behaviour of the iteration
'from the parameter Rho and a

'Status Tested

Public Class FrmBifurcation


    Private IsFormLoaded As Boolean
    Private FC As ClsBifurcationController
    Private ReadOnly LM As ClsLanguageManager
    Private IsAdjusting As Boolean

    'SECTOR INITIALIZATION
    Public Sub New()
        'This is necessary for the designer
        InitializeComponent()
        LM = ClsLanguageManager.LM
    End Sub

    Private Sub FrmBifurcation_Load(sender As Object, e As EventArgs) Handles Me.Load
        IsFormLoaded = False
        FC = New ClsBifurcationController(Me)

        'Initialize Language
        InitializeLanguage()

        FC.FillDynamicSystem()
    End Sub

    Private Sub FrmBifurcation_Resize(sender As Object, e As EventArgs) Handles Me.Resize
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
                PicDiagram.Top = CboSystem.Top
                If IsFormLoaded Then
                    FC.InitializeMe()
                    FC.ResetIteration()
                End If
            End If
            IsAdjusting = False
        End If
    End Sub

    Private Sub FrmBifurcation_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FC.SetDS()
        IsFormLoaded = True
    End Sub

    Private Sub InitializeLanguage()

        Text = LM.GetString("Bifurcation")
        LblDeltaX.Text = LM.GetString("Delta") & " = "
        LblDeltaA.Text = LM.GetString("Delta") & " = "
        LblValueRange.Text = LM.GetString("ExaminatedValueRange")
        LblParameterRange.Text = LM.GetString("ExaminatedParameterRange")
        BtnReset.Text = LM.GetString("ResetIteration")
        BtnDefault.Text = LM.GetString("DefaultUserData")
        GrpCoordinates.Text = LM.GetString("Coordinate")

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

    Private Sub CboSystem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboSystem.SelectedIndexChanged
        If IsFormLoaded Then
            FC.SetDS()
        End If
    End Sub

    Private Sub TxtAMax_TextChanged(sender As Object, e As EventArgs) Handles TxtAMax.TextChanged
        If IsFormLoaded Then
            FC.SetDelta()
        End If
    End Sub

    Private Sub TxtAMin_TextChanged(sender As Object, e As EventArgs) Handles TxtAMin.TextChanged
        If IsFormLoaded Then
            FC.SetDelta()
        End If
    End Sub

    Private Sub TxtXMax_TextChanged(sender As Object, e As EventArgs) Handles TxtXMax.TextChanged
        If IsFormLoaded Then
            FC.SetDelta()
        End If
    End Sub

    Private Sub TxtXMin_TextChanged(sender As Object, e As EventArgs) Handles TxtXMin.TextChanged
        If IsFormLoaded Then
            FC.SetDelta()
        End If
    End Sub

    'SECTOR ITERATION
    Private Sub BtnStartIteration_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        If IsFormLoaded Then
            FC.StartIteration()
        End If
    End Sub

    Private Sub OptX_CheckedChanged(sender As Object, e As EventArgs) Handles OptX.CheckedChanged
        If IsFormLoaded Then
            FC.SetActualValueRange()
        End If
    End Sub

    Private Sub OptY_CheckedChanged(sender As Object, e As EventArgs) Handles OptY.CheckedChanged
        If IsFormLoaded Then
            FC.SetActualValueRange()
        End If
    End Sub

    Private Sub OptZ_CheckedChanged(sender As Object, e As EventArgs) Handles OptZ.CheckedChanged
        If IsFormLoaded Then
            FC.SetActualValueRange()
        End If
    End Sub

    Private Sub SplitContainer_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer.SplitterMoved
        If IsFormLoaded Then
            AdjustLayout()
        End If
    End Sub

    Private Sub FrmBifurcation_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If IsFormLoaded Then
            AdjustLayout()
        End If
    End Sub
End Class