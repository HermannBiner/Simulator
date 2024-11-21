'This form is the user interface for the investigation
'of the relation of the parameters of Billiard, Pendulum or similar systems
'and the parmeter C (see math. doc.) that defines its profile
'the implementation follows the concept of the Feigenbaum Diagram

'The form is based on an Interface ICDiagram 
'that is implemented by the Billiard-Classes, Pendulum-Classes and other

Imports System.Globalization

Public Class FrmCDiagramBilliard

    Private IsFormLoaded As Boolean
    Private FC As ClsCDiagramController

    Private LM As ClsLanguageManager

    'SECTOR INITIALIZATION
    Public Sub New()
        LM = ClsLanguageManager.LM
        'This is necessary for the designer
        InitializeComponent()
    End Sub

    Private Sub FrmCDiagram_Load(sender As Object, e As EventArgs) Handles Me.Load

        IsFormLoaded = False
        FC = New ClsCDiagramController(Me)

        'Initialize Language
        InitializeLanguage()
        FC.FillDynamicSystem()
    End Sub

    Private Sub FrmCDiagram_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FC.SetDS()
        IsFormLoaded = True
    End Sub

    Private Sub InitializeLanguage()

        Text = LM.GetString("C-Diagram")
        LblDeltaV.Text = LM.GetString("Delta") & " = "
        LblDeltaC.Text = LM.GetString("Delta") & " = "
        LblValueParameter.Text = LM.GetString("ExaminatedValueParameter")
        LblStartValues.Text = LM.GetString("PositionStartValue2") &
            TrbPositionStartValues.Value.ToString(CultureInfo.CurrentCulture) & "/120"
        LblParameterRange.Text = LM.GetString("ExaminatedParameterRange")
        BtnReset.Text = LM.GetString("ResetIteration")
        BtnDefault.Text = LM.GetString("DefaultUserData")

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        If IsFormLoaded Then
            FC.ResetIteration()
        End If
    End Sub

    Private Sub CboFunktion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboFunction.SelectedIndexChanged
        If IsFormLoaded Then
            FC.SetDS()
        End If
    End Sub

    Private Sub CboValueParameter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboValueParameter.SelectedIndexChanged
        If IsFormLoaded Then
            FC.SetValueParameter()
        End If
    End Sub

    Private Sub TrbPositionStartValues_ValueChanged(sender As Object, e As EventArgs) Handles TrbPositionStartValues.ValueChanged
        If IsFormLoaded Then
            'The position of the start values is a number "pos" between 1 and 11
            'each startvalue is then set = ValueRange.A + pos * ValueRange.IntervalWidth / 120
            LblStartValues.Text = LM.GetString("PositionStartValue2") &
            TrbPositionStartValues.Value.ToString(CultureInfo.CurrentCulture) & "/120"
        End If
    End Sub

    Private Sub TxtCMin_TextChanged(sender As Object, e As EventArgs) Handles TxtCMin.TextChanged
        If IsFormLoaded Then
            FC.SetDelta()
        End If
    End Sub

    Private Sub TxtCMax_TextChanged(sender As Object, e As EventArgs) Handles TxtCMax.TextChanged
        If IsFormLoaded Then
            FC.SetDelta()
        End If
    End Sub

    Private Sub TxtVMin_TextChanged(sender As Object, e As EventArgs) Handles TxtVMin.TextChanged
        If IsFormLoaded Then
            FC.SetDelta()
        End If
    End Sub

    Private Sub TxtVMax_TextChanged(sender As Object, e As EventArgs) Handles TxtVMax.TextChanged
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

    Private Sub BtnDefault_Click(sender As Object, e As EventArgs) Handles BtnDefault.Click
        If IsFormLoaded Then
            FC.ResetIteration()
            FC.SetDefaultUserData()
        End If

    End Sub
End Class
