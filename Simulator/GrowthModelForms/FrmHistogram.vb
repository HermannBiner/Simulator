'This form is the user interface for investigations of a histogram
'counting, how many times a small part of the iteration interval
'is hit by an iteration value during the iteration
'Iterated are unimodal functions like Tentmap, Logistic Growth or Parabola.
'In case of chaotical behaviour, the histogram looks like random distributed
'see as well the mathematical documentation

'The form is based on an Interface IIteration 
'that is implemented by ClsTentmap, ClsLogisticGrowth, ClsParabola
'Therefore, more cases of unimodal functions could be easely programmed
'just by implementing this interface

'Status Checked

Public Class FrmHistogram

    'Loading Control
    Private IsFormLoaded As Boolean
    Private LM As ClsLanguageManager

    'Histogram Controller
    Private FC As ClsHistogramController

    'SECTOR INITIALIZATION
    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()
        LM = ClsLanguageManager.LM
    End Sub

    Private Sub FrmHistogramm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IsFormLoaded = False
        'Form Controller
        FC = New ClsHistogramController(Me)

        'Initialize Language
        InitializeLanguage()

        FC.FillDynamicSystem()
    End Sub

    Private Sub FrmHistogram_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FC.SetDS()
        IsFormLoaded = True
    End Sub

    Private Sub InitializeLanguage()

        Text = LM.GetString("Histogram")
        LblNumberOfSteps.Text = LM.GetString("NumberOfSteps")
        BtnReset.Text = LM.GetString("ResetIteration")
        LblStartValue.Text = LM.GetString("StartValue") & " ="
        LblParameter.Text = LM.GetString("Parameter") & " = "
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

    Private Sub TxtParameter_LostFocus(sender As Object, e As EventArgs) Handles TxtParameter.LostFocus
        If IsFormLoaded Then
            'If this value changes, the Iteration has to be reset
            FC.ResetIteration()
        End If
    End Sub

    Private Sub TxtStartWert_LostFocus(sender As Object, e As EventArgs) Handles TxtStartValue.LostFocus
        If IsFormLoaded Then
            'If this value changes, the Iteration has to be reset
            FC.ResetIteration()
        End If
    End Sub

    'SECTOR HISTOGRAM

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