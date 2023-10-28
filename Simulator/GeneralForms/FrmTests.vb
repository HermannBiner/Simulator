'This form allows testing graphical methods

Public Class FrmTests

    Private MyMathXIntervall As ClsInterval
    Private MyMathYIntervall As ClsInterval
    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

        'Initialize Language
        InitializeLanguage()

    End Sub

    Private Sub InitializeLanguage()

        BtnTest.Text = Main.LM.GetString("Test")
        Text = Main.LM.GetString("Test")

    End Sub

    Private Sub BtnTest_Click(sender As Object, e As EventArgs) Handles BtnTest.Click

        'This is a test
        MyMathXIntervall = New ClsInterval(0, 1)
        MyMathYIntervall = New ClsInterval(0, 1)
        Dim g As New ClsGraphicTool(PicDiagram, MyMathXIntervall, MyMathYIntervall)
        Dim A As New ClsMathpoint(CDec(0.1), CDec(0.1))
        Dim C As New ClsMathpoint(CDec(0.9), CDec(0.9))
        g.DrawEllipticArc(A, C, 0, CDec(6 * Math.PI / 4), Color.Red, 2)

    End Sub
End Class
