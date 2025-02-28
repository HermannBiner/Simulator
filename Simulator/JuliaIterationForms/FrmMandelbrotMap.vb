'This class shows the Mandelbrot set
'The user can chose with the mouse a point on the Mandelbrot set
'That defines a complex number c = a + ib
'If one klicks the mouse button, then the Julia set is generated
'for this value of c

'Status

Public Class FrmMandelbrotMap

    'Private global variables
    Private IsFormLoaded As Boolean
    Private FC As ClsMandelbrotMapController

    Private ReadOnly LM As ClsLanguageManager

    'SECTOR INITIALIZATION
    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()
        LM = ClsLanguageManager.LM
    End Sub

    Private Sub FrmMandelbrotMap_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Generate objects
        IsFormLoaded = False
        FC = New ClsMandelbrotMapController(Me)

        'Initialize Language
        InitializeLanguage()
    End Sub

    Private Sub FrmMandelbrotMap_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FC.SetDS()
        IsFormLoaded = True
    End Sub

    Private Sub InitializeLanguage()

        Text = LM.GetString("MandelbrotMap")
        BtnDefault.Text = LM.GetString("DefaultUserData")

    End Sub

    Private Sub BtnDefault_Click(sender As Object, e As EventArgs) Handles BtnDefault.Click
        If IsFormLoaded Then
            FC.SetDefaultUserData()
        End If
    End Sub

    'SECTOR SET STARTPARAMETER

    Private Sub PicDiagram_MouseDown(sender As Object, e As MouseEventArgs) Handles PicMandelbrot.MouseDown
        If IsFormLoaded Then
            FC.MouseDown(e)
        End If
    End Sub

    Private Sub PicDiagram_MouseUp(sender As Object, e As MouseEventArgs) Handles PicMandelbrot.MouseUp
        If IsFormLoaded Then
            FC.MouseUp(e)
        End If
    End Sub

    Private Sub PicDiagram_MouseMove(sender As Object, e As MouseEventArgs) Handles PicMandelbrot.MouseMove
        If IsFormLoaded Then
            FC.MouseMove(e)
        End If
    End Sub

End Class