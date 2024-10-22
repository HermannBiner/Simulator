'This form is the user interface for investigations of the iteration
'of unimodal functions like Tentmap, Logistic Growth or Parabola
'a parameter a, that steeres the iteration function, can be defined
'the behaviour of the iteration depends on that parameter
'in certain cases, the behaviour is chaotic
'in that case, any protocol of the iteration is possible
'if an arbitrary protocol is given by the user
'the program calculates a startvalue for the iteration, that produces this protocol
'in addition, any target value can be defined by the user
'and the program adapts the startvalue a little bit different from the original one
'so that the iteration approaches the given target value during the iteration
'see the mathematical documentation

'The form is based on an Interface IIteration 
'that is implemented by ClsTentmap, ClsLogisticGrowth, ClsParabola
'Therefore, more cases of unimodal functions could be easely programmed
'just by implementing this interface

'Status Checked

Public Class FrmIteration

    Private IsFormLoaded As Boolean
    Private FC As ClsIterationController

    Private LM As ClsLanguageManager

    'SECTOR INITIALIZATION

    Public Sub New()
        'This is necessary for the designer
        InitializeComponent()
        LM = ClsLanguageManager.LM
    End Sub

    Private Sub FrmIteration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IsFormLoaded = False
        FC = New ClsIterationController(Me)

        'Initialize Language
        InitializeLanguage()
        FC.FillDynamicSystem()
    End Sub

    Private Sub FrmIteration_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FC.SetDS()
        IsFormLoaded = True
    End Sub

    Private Sub InitializeLanguage()

        Text = LM.GetString("GrowthModels")
        OptFunctionGraph.Text = LM.GetString("FunctionGraph")
        OptTimeAxis.Text = LM.GetString("TimeAxis")
        LblxStretching.Text = LM.GetString("xStretching")
        LblStretching.Text = LM.GetString("DinStretching")
        GrpPresentation.Text = LM.GetString("Presentation")
        LblLog.Text = LM.GetString("Log")
        LblXValues.Text = LM.GetString("XValues")
        LblIterationDepth.Text = LM.GetString("IterationDepth")
        BtnProtocolStartvalue.Text = LM.GetString("StartvalueForProtocol")
        GrpProtocol.Text = LM.GetString("TargetProtocol")
        LblTargetValue.Text = LM.GetString("TargetValue") & " = "
        BtnTransitiveStartValue.Text = LM.GetString("StartvalueForTargetvalue")
        GrpTargetValue.Text = LM.GetString("Transitivity")
        LblNumberOfSteps.Text = LM.GetString("NumberOfSteps")
        GrpStep.Text = LM.GetString("Iteration")
        BtnNext10Steps.Text = LM.GetString("Next10Steps")
        BtnNextStep.Text = LM.GetString("NextStep")
        LblStartValue.Text = LM.GetString("StartValue") & " = "
        BtnReset.Text = LM.GetString("ResetIteration")
        LblParameterA.Text = LM.GetString("Parameter") & " a"
        BtnDefault.Text = LM.GetString("DefaultUserData")

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        If IsFormLoaded Then
            FC.ResetIteration()
        End If
    End Sub

    Private Sub BtnDefault_Click(sender As Object, e As EventArgs) Handles BtnDefault.Click
        If IsFormLoaded Then
            FC.SetDefaultUserData()
            FC.ResetIteration()
        End If
    End Sub

    Private Sub CboFunction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboFunction.SelectedIndexChanged
        If IsFormLoaded Then
            FC.SetDS()
        End If
    End Sub

    Private Sub TxtStartValue_LostFocus(sender As Object, e As EventArgs) Handles TxtStartValue.LostFocus
        If IsFormLoaded Then
            'If this value changes, the Iteration has to be reset
            FC.ResetIteration()
        End If
    End Sub

    Private Sub TxtXStretching_LostFocus(sender As Object, e As EventArgs) Handles TxtXStretching.LostFocus
        If IsFormLoaded Then 'If this value changes, the Iteration has to be reset
            FC.ResetIteration()
        End If
    End Sub

    Private Sub OptFunctionGraph_CheckedChanged(sender As Object, e As EventArgs) Handles OptFunctionGraph.CheckedChanged
        If IsFormLoaded Then
            If OptFunctionGraph.Checked Then
                FC.SetPresentation()
                FC.ResetIteration()
            End If
        End If
    End Sub

    Private Sub OptTimeAxis_CheckedChanged(sender As Object, e As EventArgs) Handles OptTimeAxis.CheckedChanged
        If IsFormLoaded Then
            If OptTimeAxis.Checked Then
                FC.SetPresentation()
                FC.ResetIteration()
            End If
        End If
    End Sub

    Private Sub TrbParameterA_Scroll(sender As Object, e As EventArgs) Handles TrbParameterA.Scroll
        If IsFormLoaded Then
            FC.SetParameterA()
        End If
    End Sub

    Private Sub TxtParameterA_LostFocus(sender As Object, e As EventArgs) Handles TxtParameterA.LostFocus
        If IsFormLoaded Then
            FC.SetTrbA()
        End If
    End Sub

    Private Sub CboIterationDepth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboIterationDepth.SelectedIndexChanged
        If IsFormLoaded Then
            FC.SetExponent
        End If
    End Sub


    'SECTOR STARTVALUE FOR PROTOCOL

    Private Sub BtnProtocolStartvalue_Click(sender As Object, e As EventArgs) Handles BtnProtocolStartvalue.Click

        If IsFormLoaded Then
            FC.CalculateStartvalueForProtocol()
        End If

    End Sub

    'SECTOR ADAPTED STARTVALUE FOR THE TARGETVALUE

    Private Sub BtnTransitiveStartValue_Click(sender As Object, e As EventArgs) Handles BtnTransitiveStartValue.Click

        If IsFormLoaded Then
            FC.CalculateStartvalueForTargetValue()
        End If

    End Sub

    'SECTOR ITERATION

    Private Sub BtnNextStep_Click(sender As Object, e As EventArgs) Handles BtnNextStep.Click

        If IsFormLoaded Then
            'Perform one iteration step
            FC.StartIteration(1)
        End If

    End Sub

    Private Sub BtnNext10Steps_Click(sender As Object, e As EventArgs) Handles BtnNext10Steps.Click

        If IsFormLoaded Then
            'Perform one iteration step
            FC.StartIteration(10)
        End If
    End Sub

    Private Sub GrpProtocol_Enter(sender As Object, e As EventArgs) Handles GrpProtocol.Enter

    End Sub
End Class