﻿'This Form shows the size of a population as set of points in a circle
'it is adequate to show the population growth depending on the parameter a
'to people, that has less mathematical background

'Status checked

Public Class FrmPopulation

    Private IsFormLoaded As Boolean
    Private FC As ClsPopulationController

    Private LM As ClsLanguageManager

    'SECTOR INITIALIZATION

    Public Sub New()
        'This is necessary for the designer
        InitializeComponent()
        LM = ClsLanguageManager.LM
    End Sub

    Private Sub FrmPopulation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IsFormLoaded = False
        FC = New ClsPopulationController(Me)

        'Initialize Language
        InitializeLanguage()
        FC.FillDynamicSystem()
    End Sub

    Private Sub FrmPopulation_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FC.SetDS()
        IsFormLoaded = True
    End Sub


    Private Sub InitializeLanguage()

        Text = LM.GetString("PopulationDensity")
        LblPopulationDensity.Text = LM.GetString("PopulationDensity")
        LblNumberOfSteps.Text = LM.GetString("NumberOfSteps")
        LblStartValue.Text = LM.GetString("StartValue") & " = "
        BtnReset.Text = LM.GetString("ResetIteration")
        LblParameterA.Text = LM.GetString("Parameter") & " a"
        BtnDefault.Text = LM.GetString("DefaultUserData")
        BtnStart.Text = LM.GetString("Start")
        BtnStop.Text = LM.GetString("Stop")
        BtnNextStep.Text = LM.GetString("NextStep")

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


    'SECTOR ITERATION

    Private Sub BtnNextStep_Click(sender As Object, e As EventArgs) Handles BtnNextStep.Click
        If IsFormLoaded Then
            FC.NextStep
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

End Class