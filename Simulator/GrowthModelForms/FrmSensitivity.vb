'This form is the user interface for the investigation of the sensitivity
'of unimodal functions like Tentmap, Logistic Growth or Parabola
'if the behaviour of the iteration is chaotic, then a little differenc between two startvalues
'leads to big differences of their orbits
'see the mathematical documentation

'The form is based on an Interface IIteration 
'that is implemented by ClsTentmap, ClsLogisticGrowth, ClsParabola
'Therefore, more cases of unimodal functions could be easely programmed
'just by implementing this interface

'Status Checked

Public Class FrmSensitivity

    Private IsFormLoaded As Boolean
    Private FC As ClsSensitivityController

    Private LM As ClsLanguageManager

    'SECTOR INITIALIZATION

    Public Sub New()
        'This is necessary for the designer
        InitializeComponent()
        LM = ClsLanguageManager.LM
    End Sub

    Private Sub FrmSensitivity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IsFormLoaded = False
        FC = New ClsSensitivityController(Me)
        'Initialize Language
        InitializeLanguage()
        FC.FillDynamicSystem()
    End Sub

    Private Sub FrmSensitivity_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FC.SetDS()
        IsFormLoaded = True
    End Sub

    Private Sub InitializeLanguage()

        Text = LM.GetString("Sensitivity")
        LblNumberOfSteps.Text = LM.GetString("NumberOfSteps")
        BtnReset.Text = LM.GetString("ResetIteration")
        BtnStartIteration.Text = LM.GetString("StartIteration")
        OptDifference.Text = LM.GetString("Difference12")
        OptSingleOrbit.Text = LM.GetString("SingleOrbits")
        LblxStretching.Text = LM.GetString("xStretching")
        LblStretching.Text = LM.GetString("DinStretching")
        GrpPresentation.Text = LM.GetString("Presentation")
        LblStartValue2.Text = LM.GetString("StartValue2")
        LblStartValue1.Text = LM.GetString("StartValue1")
        LblValueList2.Text = LM.GetString("ValueList2")
        LblValueList1.Text = LM.GetString("ValueList1")
        LblIterationDepth.Text = LM.GetString("IterationDepth")
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

    Private Sub CboFunction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboFunction.SelectedIndexChanged
        If IsFormLoaded Then
            FC.SetDS()
        End If
    End Sub

    Private Sub CboIterationDepth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboIterationDepth.SelectedIndexChanged
        If IsFormLoaded Then
            'If this value changes, the Iteration has to be reset
            FC.ResetIteration()
        End If
    End Sub

    Private Sub TxtParameter_LostFocus(sender As Object, e As EventArgs) Handles TxtParameter.LostFocus
        If IsFormLoaded Then
            'If this value changes, the Iteration has to be reset
            FC.ResetIteration()
        End If
    End Sub

    Private Sub TxtStartValue1_LostFocus(sender As Object, e As EventArgs) Handles TxtStartValue1.LostFocus
        If IsFormLoaded Then
            'If this value changes, the Iteration has to be reset
            FC.ResetIteration()
        End If
    End Sub

    Private Sub TxtStartValue2_LostFocus(sender As Object, e As EventArgs) Handles TxtStartValue2.LostFocus
        If IsFormLoaded Then
            'If this value changes, the Iteration has to be reset
            FC.ResetIteration()
        End If
    End Sub

    Private Sub TxtxStretching_LostFocus(sender As Object, e As EventArgs) Handles TxtxStretching.LostFocus
        If IsFormLoaded Then
            'If this value changes, the Iteration has to be reset
            FC.ResetIteration()
        End If
    End Sub

    Private Sub OptDifference_CheckedChanged(sender As Object, e As EventArgs) Handles OptDifference.CheckedChanged
        If IsFormLoaded Then
            If OptDifference.Checked Then
                FC.ResetIteration()
            End If
        End If
    End Sub

    Private Sub OptSingleOrbit_CheckedChanged(sender As Object, e As EventArgs) Handles OptSingleOrbit.CheckedChanged
        If IsFormLoaded Then
            If OptSingleOrbit.Checked Then
                FC.ResetIteration()
            End If
        End If
    End Sub


    'SECTOR ITERATION
    Private Sub BtnStartIteration_Click(sender As Object, e As EventArgs) Handles BtnStartIteration.Click
        If IsFormLoaded Then
            FC.StartIteration()
        End If
    End Sub
End Class