'This form shows the simulation of n-Bodies in the universe
'or the simulation of sun - planet systems
'it is based on the interface IUniverse
'that is implemented by the class ClsUniverseAbstract
'and ClsUniverse that heritates from this class
'see mathematical and technical documentation

'Status in construction

Public Class FrmUniverse

    Private IsFormLoaded As Boolean
    Private FC As ClsUniverseController

    Private ReadOnly LM As ClsLanguageManager
    Private IsAdjusting As Boolean

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()
        LM = ClsLanguageManager.LM
    End Sub

    Private Sub FrmUniverse_Load(sender As Object, e As EventArgs) Handles Me.Load

        IsFormLoaded = False
        FC = New ClsUniverseController(Me)

        'Initialize Language
        InitializeLanguage()
        FC.FillDynamicSystem()
    End Sub
    Private Sub FrmUniverse_Resize(sender As Object, e As EventArgs) Handles Me.Resize
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
                SplitContainer2.SplitterDistance = Math.Max(SplitContainer2.Panel1.MinimumSize.Width, CboUniverse.Width + 20)

                If IsFormLoaded Then
                    FC.ClearUniverse()
                    FC.InitializeMe()
                End If
            End If
            IsAdjusting = False
        End If
    End Sub

    Private Sub FrmUniverse_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FC.SetDS()
        IsFormLoaded = True

        'Standards for Buttons
        BtnTakeOverConstellation.Enabled = True
        BtnNewStar.Enabled = True
        BtnSave.Enabled = False
        BtnStart.Enabled = False
        BtnStop.Enabled = False
        BtnDefault.Enabled = False
        BtnReset.Enabled = False
        BtnClearUniverse.Enabled = False

        'Adjust Stepwidth
        FC.SetStepWidthFromTrb()
    End Sub

    Private Sub InitializeLanguage()

        Text = LM.GetString("Universe")

        BtnNewStar.Text = LM.GetString("NewStar")
        GrpNewStar.Text = LM.GetString("NewStar")
        BtnSave.Text = LM.GetString("Save")
        BtnReset.Text = LM.GetString("ResetIteration")
        LblMass.Text = LM.GetString("Mass") & ": "
        BtnDefault.Text = LM.GetString("DefaultUserData")
        BtnClearUniverse.Text = LM.GetString("ClearUniverse")
        LblStarColor.Text = LM.GetString("StarColor")
        LblDefault.Text = LM.GetString("Default")
        LblUniverse.Text = LM.GetString("Universe")
        BtnTakeOverConstellation.Text = LM.GetString("TakeOverConstellation")
        LblConstellations.Text = LM.GetString("Constellation")
        LblNumberOfSteps.Text = LM.GetString("NumberOfSteps")
        LblPulse.Text = LM.GetString("Pulse")
        LblAngularMomentum.Text = LM.GetString("Angular Momentum")
        LblEnergy.Text = LM.GetString("Energy")
        LblStepWidth.Text = LM.GetString("StepWidth")
        ChkConservationLaws.Text = LM.GetString("ConservationLaws")
        LblVelocity.Text = LM.GetString("Velocity")
        LblPosition.Text = LM.GetString("Position")
        LblTime.Text = LM.GetString("Time")
        ChkZoom.Text = LM.GetString("Zoom")
        ChkPhasePortrait.Text = LM.GetString("PhasePortrait")
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        If IsFormLoaded Then
            FC.ResetIteration()
        End If
    End Sub

    Private Sub BtnDefault_Click(sender As Object, e As EventArgs) Handles BtnDefault.Click
        If IsFormLoaded Then
            'first, the parameters are reset
            FC.SetAllStarsDefaultUserData()
            'and then, the diagram is reset and the stars are shown again
            FC.ResetIteration()
        End If
    End Sub

    Private Sub BtnClearUniverse_Click(sender As Object, e As EventArgs) Handles BtnClearUniverse.Click
        If IsFormLoaded Then
            FC.ClearUniverse()
        End If
    End Sub

    Private Sub CboUniverse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboUniverse.SelectedIndexChanged
        If IsFormLoaded Then
            FC.SetDS()
        End If
    End Sub

    Private Sub CboStarColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboStarColor.SelectedIndexChanged
        If IsFormLoaded Then
            'ActiveStar
            FC.SetColor(FC.GetColor(CboStarColor.SelectedItem.ToString))
        End If
    End Sub

    Private Sub TrbMass_Scroll(sender As Object, e As EventArgs) Handles TrbMass.Scroll
        If IsFormLoaded Then
            'ActiveStar
            FC.SetMassFromTrb()
        End If
    End Sub

    Private Sub TrbVelocity_Scroll(sender As Object, e As EventArgs) Handles TrbVelocity.Scroll
        If IsFormLoaded Then
            FC.SetVelocityFromTrb()
        End If
    End Sub

    'SECTOR CREATE NEW OBJECT

    Private Sub BtnTakeOverConstellation_Click(sender As Object, e As EventArgs) Handles BtnTakeOverConstellation.Click
        If IsFormLoaded Then
            'All Stars of the constellation are set into the diagram
            FC.TakeOverConstellation()
        End If
    End Sub

    Private Sub BtnNewStar_Click(sender As Object, e As EventArgs) Handles BtnNewStar.Click
        If IsFormLoaded Then
            'The defaultstar of the CboDefaultStar.SelectedIndex
            FC.TakeOverNewStarOrCancel()
        End If
    End Sub

    Private Sub CboConstellation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboConstellations.SelectedIndexChanged
        If IsFormLoaded Then
            FC.FillDefaultStars()
        End If
    End Sub

    'SECTOR SET STARTPARAMETERS

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

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If IsFormLoaded Then
            FC.SaveStar()
        End If
    End Sub

    Private Sub ChkZoom_CheckedChanged(sender As Object, e As EventArgs) Handles ChkZoom.CheckedChanged
        If IsFormLoaded Then
            FC.RedrawUniverse()
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

    Private Sub TrbStepWidth_Scroll(sender As Object, e As EventArgs) Handles TrbStepWidth.Scroll
        If IsFormLoaded Then
            FC.SetStepWidthFromTrb()
        End If
    End Sub

    'LAYOUT

    Private Sub SplitContainer1_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer1.SplitterMoved
        If IsFormLoaded Then
            AdjustLayout()
        End If
    End Sub

    Private Sub FrmFrmUniverse_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If IsFormLoaded Then
            AdjustLayout()
        End If
    End Sub
End Class