'This Form supports the L-System fractal generation.

'Status Checked


Public Class FrmLSystems

    Private IsFormLoaded As Boolean
    Private FC As ClsLSystemsController

    Private ReadOnly LM As ClsLanguageManager
    Private IsAdjusting As Boolean

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()
        LM = ClsLanguageManager.LM
    End Sub

    Private Sub FrmLSystems_Load(sender As Object, e As EventArgs) Handles Me.Load

        IsFormLoaded = False
        FC = New ClsLSystemsController(Me)

        'Initialize Language
        InitializeLanguage()
        FC.LoadFileToLSystemCollection(0)

    End Sub

    Private Sub FrmLSystems_Resize(sender As Object, e As EventArgs) Handles Me.Resize
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
                    FC.ResetIteration()
                End If
            End If
            IsAdjusting = False
        End If
    End Sub

    Private Sub FrmLSystems_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FC.SetLSystem()
        IsFormLoaded = True
    End Sub

    Private Sub InitializeLanguage()

        Text = LM.GetString("LSystems")
        BtnReset.Text = LM.GetString("Reset")
        GrpIteration.Text = LM.GetString("Iteration")
        GrpRules.Text = LM.GetString("Rules")
        GrpSystemParameters.Text = LM.GetString("SystemParameters")
        BtnCancel.Text = LM.GetString("Cancel")
        BtnAddRule.Text = LM.GetString("AddRule")
        BtnAddSystem.Text = LM.GetString("AddSystem")
        BtnStart.Text = LM.GetString("Start")
        BtnStop.Text = LM.GetString("Stop")
        BtnGetDefaultSystems.Text = LM.GetString("GetDefaultSystems")
        BtnRestoreCopy.Text = LM.GetString("RestoreCopy")
        BtnDeleteRule.Text = LM.GetString("Delete")
        BtnDeleteSystem.Text = LM.GetString("Delete")
        BtnEditSystem.Text = LM.GetString("Edit")
        BtnSaveSystem.Text = LM.GetString("SaveSystem")
        'ChkExtended.Text is set in the controller
        LblAngleLeft.Text = LM.GetString("AngleLeft")
        LblAngleRight.Text = LM.GetString("AngleRight")
        LblAxiom.Text = LM.GetString("Axiom")
        LblColor.Text = LM.GetString("Color")
        LblScaleFactor.Text = LM.GetString("ScaleFactor")
        LblSource.Text = LM.GetString("Source")
        LblTarget.Text = LM.GetString("Target")
        LblName.Text = LM.GetString("Name")
        BtnSaveRule.Text = LM.GetString("SaveRule")
        LblScaling.Text = LM.GetString("Scaling")
        LblStartLength.Text = LM.GetString("StartLength")
        LblStartPosition.Text = LM.GetString("StartPosition") & " (X/Y) in [0,13] x [0,13]"
        LblType.Text = LM.GetString("Type")
        Dim TypeArray As Array = [Enum].GetValues(GetType(ClsLSystem.EnLSystemType))
        CboType.Items.Clear()
        For Each TypeValue As ClsLSystem.EnLSystemType In TypeArray
            CboType.Items.Add(LM.GetString(TypeValue.ToString))
        Next
        Dim ScalingArray As Array = [Enum].GetValues(GetType(ClsLSystemsController.EnScaling))
        CboScaling.Items.Clear()
        For Each ScalingValue As ClsLSystemsController.EnScaling In ScalingArray
            CboScaling.Items.Add(LM.GetString(ScalingValue.ToString))
        Next
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        If IsFormLoaded Then
            FC.ResetIteration()
        End If
    End Sub

    Private Sub CboSystem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboSystem.SelectedIndexChanged
        If IsFormLoaded Then
            FC.SetLSystem()
        End If
    End Sub

    Private Sub CboColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboColor.SelectedIndexChanged
        If IsFormLoaded Then
            FC.ShowColor(CInt(CboColor.SelectedItem.ToString.Split(" "c)(0)))
        End If
    End Sub

    Private Sub CboRules_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboRules.SelectedIndexChanged
        If IsFormLoaded Then
            FC.ShowRuleDetails()
        End If
    End Sub

    'SECTOR EDIT SYSTEMS

    Private Sub BtnAddSystem_Click(sender As Object, e As EventArgs) Handles BtnAddSystem.Click
        If IsFormLoaded Then
            FC.AddSystem()
        End If
    End Sub

    Private Sub BtnEditSystem_Click(sender As Object, e As EventArgs) Handles BtnEditSystem.Click
        If IsFormLoaded Then
            FC.EditSystem()
        End If
    End Sub

    Private Sub BtnDeleteSystem_Click(sender As Object, e As EventArgs) Handles BtnDeleteSystem.Click
        If IsFormLoaded Then
            FC.DeleteSystem()
        End If
    End Sub

    Private Sub BtnSaveSystem_Click(sender As Object, e As EventArgs) Handles BtnSaveSystem.Click
        If IsFormLoaded Then
            FC.SaveSystem()
        End If
    End Sub
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        If IsFormLoaded Then
            FC.Cancel()
        End If
    End Sub

    'SECTOR EDIT RULES
    Private Sub BtnAddRule_Click(sender As Object, e As EventArgs) Handles BtnAddRule.Click
        If IsFormLoaded Then
            FC.AddRule()
        End If
    End Sub

    Private Sub BtnSaveRule_Click(sender As Object, e As EventArgs) Handles BtnSaveRule.Click
        If IsFormLoaded Then
            FC.SaveRule()
        End If
    End Sub

    Private Sub BtnDeleteRule_Click(sender As Object, e As EventArgs) Handles BtnDeleteRule.Click
        If IsFormLoaded Then
            FC.DeleteRule()
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

    'LAYOUT

    Private Sub SplitContainer_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer.SplitterMoved
        If IsFormLoaded Then
            AdjustLayout()
        End If
    End Sub

    Private Sub FrmLSystems_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If IsFormLoaded Then
            AdjustLayout()
        End If
    End Sub

    Private Sub BtnGetDefaultSystems_Click(sender As Object, e As EventArgs) Handles BtnGetDefaultSystems.Click
        If IsFormLoaded Then
            FC.GetDefaultSystems(True)
        End If
    End Sub

    Private Sub BtnRestoreCopy_Click(sender As Object, e As EventArgs) Handles BtnRestoreCopy.Click
        If IsFormLoaded Then
            FC.RestoreCopy
        End If
    End Sub

    Private Sub CboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboType.SelectedIndexChanged
        If IsFormLoaded Then
            FC.ShowOptions
        End If
    End Sub
End Class