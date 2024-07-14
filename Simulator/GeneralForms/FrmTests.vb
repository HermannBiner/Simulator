'This form allows testing graphical or other methods
'normally, the menu to open this form in FrmMain is not visible

'Status checked

Public Class FrmTests

    Const N As Integer = 3
    Const StepWide As Double = 0.001

    Private MyGraphics As ClsGraphicTool
    Private XInterval As ClsInterval
    Private YInterval As ClsInterval

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

        SetDefaulValues()

    End Sub

    Private Sub SetDefaulValues()

        XInterval = New ClsInterval(CDec(-0.1), CDec(3))
        YInterval = New ClsInterval(CDec(-2), CDec(8))
        MyGraphics = New ClsGraphicTool(PicDiagram, XInterval, YInterval)

    End Sub

    Private Sub DrawDefault()
        MyGraphics.DrawLine(New ClsMathpoint(XInterval.A, 0), New ClsMathpoint(XInterval.B, 0),
                    Color.Black, 1)
        MyGraphics.DrawLine(New ClsMathpoint(0, YInterval.A), New ClsMathpoint(0, YInterval.B),
                    Color.Black, 1)

    End Sub

    Private Sub Clear()
        LstValues.Items.Clear()
        MyGraphics.Clear(Color.White)
    End Sub

    Private Sub BtnTest_Click(sender As Object, e As EventArgs) Handles BtnTest.Click

        Clear()
        DrawDefault()


        Dim x As Decimal = 0

        Do
            MyGraphics.DrawPoint(New ClsMathpoint(x, CDec(Math.Pow(x, 3)) - 1), Brushes.Blue, 1)
            x += CDec(0.001)


        Loop Until x > 2


    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click


    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click

        Clear()
        DrawDefault()

    End Sub
End Class
