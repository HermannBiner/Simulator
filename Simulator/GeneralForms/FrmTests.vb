'This form allows testing graphical or other methods
'normally, the menu to open this form in FrmMain is not visible
'Status checked

Public Class FrmTests

    Private MyMathXIntervall As ClsInterval
    Private MyMathYIntervall As ClsInterval
    Private g As ClsGraphicTool

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

        'Initialize Language
        InitializeLanguage()

        'This is a test
        MyMathXIntervall = New ClsInterval(CDec(-0.1), CDec(1.1))
        MyMathYIntervall = New ClsInterval(CDec(-0.1), CDec(1.1))
        g = New ClsGraphicTool(PicDiagram, MyMathXIntervall, MyMathYIntervall)

    End Sub

    Private Sub InitializeLanguage()

        BtnTest.Text = Main.LM.GetString("Test")
        Text = Main.LM.GetString("Test")

    End Sub

    Private Sub BtnTest_Click(sender As Object, e As EventArgs) Handles BtnTest.Click

        'Example: Show the graph of a curve
        g.Clear(Color.White)
        Dim MidPoint As New ClsMathpoint(0, 0)
        g.DrawCoordinateSystem(MidPoint, Color.Black, 1)

        Dim p As Integer
        For p = 1 To 1000
            Dim t As Decimal = CDec(Math.PI * p / 1000)
            Dim Gamma As New ClsMathpoint(CDec(Math.Cos(t) * Math.Cos(t)), CDec(Math.Sin(t)))
            g.DrawPoint(Gamma, Brushes.Blue, 1)
        Next

    End Sub
End Class
