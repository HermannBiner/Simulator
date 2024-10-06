'This form allows testing graphical or other methods
'normally, the menu to open this form in FrmMain is not visible

'Status checked

Public Class FrmTests

    Private LM As ClsLanguageManager

    Const StepWide As Double = 0.001

    Private MyGraphics As ClsGraphicTool
    Private XInterval As ClsInterval
    Private YInterval As ClsInterval

    Public Sub New()
        LM = ClsLanguageManager.LM

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub InitializeLanguage()

        BtnTest.Text = LM.GetString("Test")
        Text = LM.GetString("Test")

    End Sub

    Private Sub FrmTests_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Initialize Language
        InitializeLanguage()

        SetDefaulValues()

    End Sub

    Private Sub SetDefaulValues()

        XInterval = New ClsInterval(CDec(-1.3), CDec(0.7))
        YInterval = New ClsInterval(CDec(-1), CDec(1))
        MyGraphics = New ClsGraphicTool(PicDiagram, XInterval, YInterval)

    End Sub

    Private Sub DrawCoordinateSystem()
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
        DrawCoordinateSystem()


        Dim phi As Decimal = 0
        Dim Cardioide As New ClsMathpoint
        Dim Circle As New ClsMathpoint

        Do
            With Cardioide
                .X = CDec(Math.Cos(phi) / 2 - Math.Cos(2 * phi) / 4)
                .Y = CDec(Math.Sin(phi) / 2 - Math.Sin(2 * phi) / 4)
            End With
            MyGraphics.DrawPoint(Cardioide, Brushes.Blue, 1)

            With Circle
                .X = CDec(-1 + Math.Cos(phi) / 4)
                .Y = CDec(Math.Sin(phi) / 4)
            End With
            MyGraphics.DrawPoint(Circle, Brushes.Green, 1)

            phi += CDec(0.001)


        Loop Until phi > CDec(Math.pi * 2)


    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click


    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click

        Clear()
        DrawCoordinateSystem()

    End Sub
End Class
