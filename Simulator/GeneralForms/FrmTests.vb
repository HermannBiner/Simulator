'This form allows testing graphical or other methods
'normally, the menu to open this form in FrmMain is not visible

'Status checked

Public Class FrmTests

    Private Z As ClsComplexNumber

    Public Sub New()

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

        Dim Z = New ClsComplexNumber(-0.9, 0)
        Dim W = New ClsComplexNumber(0, 0)
        Dim i As Integer
        Dim k As Integer

        For k = 1 To 18

            LstValues.Items.Add(Z.X.ToString("N5") & ", " & Z.Y.ToString("N5"))
            W.X = Z.X
            W.Y = Z.Y

            If W.AbsoluteValue > 0 Then
                For i = 1 To 50

                    If W.AbsoluteValue > 0 Then
                        W = W.Power2.Add(New ClsComplexNumber(1, 0)).Div(W.Stretch(2))
                    Else
                        i = 51
                    End If

                Next i
            End If

            LstValues.Items.Add(W.X.ToString("N5") & ", " & W.Y.ToString("N5"))

            Z.X += 0.1 * k

        Next k
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click


    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click

        LstValues.Items.Clear()

    End Sub
End Class
