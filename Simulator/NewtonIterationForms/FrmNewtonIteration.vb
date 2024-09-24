'This form is the user interface for the complex Newton Iteration
'Different complex polynoms can be implemented
'the pixelpoints in the diagram CPlane are the startpoints of the iteration
'and they are colored depending to which root of the polynom they converge
'see as well the mathematical documentation

'The form is based on the Interface IPolynom 
'that is implemented by ClsUnitRoots3 and other
'Therefore, more cases of polynoms could be easely programmed
'by implementing this interface

'Status Checked

Imports System.Globalization
Imports System.Reflection

Public Class FrmNewtonIteration

    'Private global variables
    Private IsFormLoaded As Boolean
    Private FC As ClsNewtonIterationController

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub FrmNewtonIteration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IsFormLoaded = False
        FC = New ClsNewtonIterationController(Me)

        'Initialize Language
        InitializeLanguage()
        FC.FillDynamicSystem()
    End Sub

    Private Sub FrmNewtonIteration_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FC.SetDS()
        IsFormLoaded = True
    End Sub

    Private Sub InitializeLanguage()

        Text = FrmMain.LM.GetString("NewtonIteration")
        LblProtocol.Text = FrmMain.LM.GetString("ProtocolNewton")
        ChkProtocol.Text = FrmMain.LM.GetString("Protocol")
        BtnStart.Text = FrmMain.LM.GetString("Start")
        BtnStop.Text = FrmMain.LM.GetString("Stop")
        BtnShowBasin.Text = FrmMain.LM.GetString("ShowBasin")
        BtnReset.Text = FrmMain.LM.GetString("ResetIteration")
        LblTime.Text = FrmMain.LM.GetString("Time")
        LblSteps.Text = FrmMain.LM.GetString("Steps")
        GrpMixing.Text = FrmMain.LM.GetString("Mixing")
        OptNone.Text = FrmMain.LM.GetString("None")
        OptConjugate.Text = FrmMain.LM.GetString("Conjugate")
        OptRotate.Text = FrmMain.LM.GetString("Rotate")
        GrpColor.Text = FrmMain.LM.GetString("Color")
        OptBright.Text = FrmMain.LM.GetString("Bright")
        OptShadowed.Text = FrmMain.LM.GetString("Shadowed")
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

    Private Sub CboN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboN.SelectedIndexChanged
        If IsFormLoaded Then
            FC.SetExponent()
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

    Private Sub BtnShowBasin_Click(sender As Object, e As EventArgs) Handles BtnShowBasin.Click
        If IsFormLoaded Then
            FC.ShowBasin()
        End If
    End Sub

    Private Sub TxtA_LostFocus(sender As Object, e As EventArgs) Handles TxtA.LostFocus
        If IsFormLoaded Then
            FC.SetDefaultUserData()
            FC.ResetIteration()
        End If
    End Sub

    Private Sub TxtB_LostFocus(sender As Object, e As EventArgs) Handles TxtB.LostFocus
        If IsFormLoaded Then
            FC.SetDefaultUserData()
            FC.ResetIteration()
        End If
    End Sub

    Private Sub TxtXMax_LostFocus(sender As Object, e As EventArgs) Handles TxtXMax.LostFocus
        If IsFormLoaded Then
            FC.SetDelta()
        End If
    End Sub

    Private Sub TxtXMin_LostFocus(sender As Object, e As EventArgs) Handles TxtXMin.LostFocus
        If IsFormLoaded Then
            FC.SetDelta()
        End If
    End Sub

    Private Sub TxtYMax_LostFocus(sender As Object, e As EventArgs) Handles TxtXMax.LostFocus
        If IsFormLoaded Then
            FC.SetDelta()
        End If
    End Sub

    Private Sub TxtYMin_LostFocus(sender As Object, e As EventArgs) Handles TxtXMin.LostFocus
        If IsFormLoaded Then
            FC.SetDelta()
        End If
    End Sub

End Class