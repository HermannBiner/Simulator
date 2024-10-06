'This form is the user interface for the so called Feigenbaum Diagram
'It shows the dependence of the behaviour of the iteration
'from the parameter a
'for certain parameter values, the behaviour is chaotic
'see as well the mathematical documentation

'The form is based on the Interface IIteration 
'that is implemented by ClsTentmap, ClsLogisticGrowth, ClsParabola
'Therefore, more cases of unimodal functions could be easely programmed
'by implementing this interface

'Status Checked

Public Class FrmFeigenbaum

    Private IsFormLoaded As Boolean
    Private FC As ClsFeigenbaumController
    Private LM As ClsLanguageManager

    'SECTOR INITIALIZATION
    Public Sub New()
        'This is necessary for the designer
        InitializeComponent()
        LM = ClsLanguageManager.LM
    End Sub

    Private Sub FrmFeigenbaum_Load(sender As Object, e As EventArgs) Handles Me.Load
        IsFormLoaded = False
        FC = New ClsFeigenbaumController(Me)

        'Initialize Language
        InitializeLanguage()

        FC.FillDynamicSystem()
    End Sub

    Private Sub FrmFeigenbaum_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FC.SetDS()
        IsFormLoaded = True
    End Sub

    Private Sub InitializeLanguage()

        Text = LM.GetString("FeigenbaumDiagram")
        ChkColored.Text = LM.GetString("ColoredDiagram")
        ChkSplitPoints.Text = LM.GetString("ShowSplitPoints")
        LblDeltaX.Text = LM.GetString("Delta") & " = "
        LblDeltaA.Text = LM.GetString("Delta") & " = "
        LblValueRange.Text = LM.GetString("ExaminatedValueRange")
        LblParameterRange.Text = LM.GetString("ExaminatedParameterRange")
        BtnStartIteration.Text = LM.GetString("StartIteration")
        BtnReset.Text = LM.GetString("ResetIteration")
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
    Private Sub BtnStartIteration_Click(sender As Object, e As EventArgs) Handles BtnStartIteration.Click
        If IsFormLoaded Then
            FC.StartIteration()
        End If
    End Sub

End Class