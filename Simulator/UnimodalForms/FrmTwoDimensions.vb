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

Imports System.Globalization
Imports System.Reflection

Public Class FrmTwoDimensions

    Private IsFormLoaded As Boolean
    Private FC As ClsTwoDimensionsController

    'SECTOR INITIALIZATION

    Public Sub New()
        'This is necessary for the designer
        InitializeComponent()
    End Sub

    Private Sub FrmTwoDimensions_Load(sender As Object, e As EventArgs) Handles Me.Load
        IsFormLoaded = False
        FC = New ClsTwoDimensionsController(Me)

        'Initialize Language
        InitializeLanguage()

        'Fill DS-List into CboFunction
        FC.FillDynamicSystem()
    End Sub

    Private Sub FrmTwoDimensions_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FC.SetDS()
        IsFormLoaded = True
    End Sub

    Private Sub InitializeLanguage()

        Text = FrmMain.LM.GetString("TwoDimensions")
        GrpParameter.Text = FrmMain.LM.GetString("Parameter")
        GrpExperiment.Text = FrmMain.LM.GetString("ExperimentNo")
        BtnNextStep.Text = FrmMain.LM.GetString("NextStep")
        BtnReset.Text = FrmMain.LM.GetString("ResetIteration")
        BtnNext10.Text = FrmMain.LM.GetString("Next10Steps")
        GrpStartpoint.Text = FrmMain.LM.GetString("CoordinatesStartpoint")
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

End Class