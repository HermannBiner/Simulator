'This form allows testing graphical or other methods
'normally, the menu to open this form in FrmMain is not visible

'Status checked

Public Class FrmTests

    Private Z As ClsComplexNumber

    Public Sub New()

        Z = New ClsComplexNumber(100, 100)

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub InitializeLanguage()

        BtnTest.Text = Main.LM.GetString("Test")
        Text = Main.LM.GetString("Test")

    End Sub

    Private Sub FrmTests_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Initialize Language
        InitializeLanguage()

    End Sub


    Private Sub BtnTest_Click(sender As Object, e As EventArgs) Handles BtnTest.Click

        If Z.X = 100 Then
            Z.X = CDec(InputBox("X="))
        End If
        If Z.Y = 100 Then
            Z.Y = CDec(InputBox("Y="))
        End If

        LstValues.Items.Add("Z = " & Z.X.ToString("N8") & "/" & Z.Y.ToString("N8"))

        Dim W As ClsComplexNumber
        Dim k As Integer

        For k = -2 To 5

            W = Z.Power(k)

            LstValues.Items.Add("k = " & k.ToString & ", " & W.X.ToString("N8") & "/" & W.Y.ToString("N8"))
        Next


    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click


    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click

        Z.X = 100
        Z.Y = 100
        LstValues.Items.Clear()

    End Sub
End Class
