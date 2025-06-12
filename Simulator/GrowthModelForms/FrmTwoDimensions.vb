'Suppose an experimentator works in a two dimensional space and chooses a startpoint for his experiment
'and suppose, the exactness of his measure instruments is limited
'in that case, two startpoints that are a little bit different, are measured as identical startpoints
'but if the behaviour is chaotic, this little difference leads to completely different orbits
'for the experimentator, the experiment looks like random
'because in his view, he starts always at the same startpoint
'but the generated orbits are completely different
'Iterated are unimodal functions like Tentmap, Logistic Growth or Parabola
'see the mathematical documentation

'The form is based on an Interface IIteration 
'that is implemented by ClsTentmap, ClsLogisticGrowth, ClsParabola
'Therefore, more cases of unimodal functions could be easely programmed
'just by implementing hits interface

'Status Checked

Public Class FrmTwoDimensions

    Private IsFormLoaded As Boolean
    Private FC As ClsTwoDimensionsController

    Private ReadOnly LM As ClsLanguageManager
    Private IsAdjusting As Boolean

    'SECTOR INITIALIZATION

    Public Sub New()
        'This is necessary for the designer
        InitializeComponent()
        LM = ClsLanguageManager.LM
    End Sub

    Private Sub FrmTwoDimensions_Load(sender As Object, e As EventArgs) Handles Me.Load
        IsFormLoaded = False
        FC = New ClsTwoDimensionsController(Me)

        'Initialize Language
        InitializeLanguage()

        'Fill DS-List into CboFunction
        FC.FillDynamicSystem()
    End Sub
    Private Sub FrmTwoDimensions_Resize(sender As Object, e As EventArgs) Handles Me.Resize
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
                PicDiagram.Top = CboFunction.Top
                If IsFormLoaded Then
                    FC.InitializeMe()
                    FC.ResetIteration()
                End If
            End If
            IsAdjusting = False
        End If
    End Sub

    Private Sub FrmTwoDimensions_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FC.SetDS()
        IsFormLoaded = True
    End Sub

    Private Sub InitializeLanguage()

        Text = LM.GetString("TwoDimensions")
        GrpParameter.Text = LM.GetString("Parameter")
        GrpExperiment.Text = LM.GetString("ExperimentNo")
        BtnNextStep.Text = LM.GetString("NextStep")
        BtnReset.Text = LM.GetString("ResetIteration")
        BtnNext10.Text = LM.GetString("Next10Steps")
        GrpStartpoint.Text = LM.GetString("CoordinatesStartpoint")
        BtnDefault.Text = LM.GetString("DefaultUserData")
        GrpFunction.Text = LM.GetString("Function")
        OptSensitivity.Text = LM.GetString("Sensitivity")
        OptTransitivity.Text = LM.GetString("Transitivity")

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

    Private Sub CboFunction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboFunction.SelectedIndexChanged
        If IsFormLoaded Then
            FC.SetDS()
        End If
    End Sub

    Private Sub CboExperiment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboExperiment.SelectedIndexChanged
        If IsFormLoaded Then
            FC.SetBrush()
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

    Private Sub BtnNextStep_Click(sender As Object, e As EventArgs) Handles BtnNextStep.Click
        If IsFormLoaded Then
            'Perform one iteration step
            FC.StartIteration(1)
        End If
    End Sub

    Private Sub BtnNext10_Click(sender As Object, e As EventArgs) Handles BtnNext10.Click
        If IsFormLoaded Then
            'Perform 10 iteration steps
            FC.StartIteration(10)
        End If
    End Sub

    Private Sub OptSensitivity_CheckedChanged(sender As Object, e As EventArgs) Handles OptSensitivity.CheckedChanged
        If IsFormLoaded Then
            FC.SetFunction()
        End If
    End Sub

    Private Sub OptTransitivity_CheckedChanged(sender As Object, e As EventArgs) Handles OptTransitivity.CheckedChanged
        If IsFormLoaded Then
            FC.SetFunction()
        End If
    End Sub

    'LAYOUT

    Private Sub SplitContainer_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer.SplitterMoved
        If IsFormLoaded Then
            AdjustLayout()
        End If
    End Sub

    Private Sub FrmTwoDimensions_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If IsFormLoaded Then
            AdjustLayout()
        End If
    End Sub
End Class