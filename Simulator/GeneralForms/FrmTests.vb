'This form allows testing graphical or other methods
'normally, the menu to open this form in FrmMain is not visible

'Status checked

Public Class FrmTests

    Private ReadOnly LM As ClsLanguageManager

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

        XInterval = New ClsInterval(CDec(-0.2), CDec(1.2))
        YInterval = New ClsInterval(CDec(-0.2), CDec(1.2))
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


        Dim u As Decimal = 0
        Dim Sinus As New ClsMathpoint

        Do

            With Sinus
                .X = CDec(u)
                .Y = CDec(Math.Pow(Math.Sin(u * Math.PI / 2), 2))
            End With
            MyGraphics.DrawPoint(Sinus, Brushes.Blue, 1)

            u += CDec(0.001)


        Loop Until u > CDec(1)

        MyGraphics.DrawLine(New ClsMathpoint(0, 1), New ClsMathpoint(1, 1), Color.Black, 1)
        MyGraphics.DrawLine(New ClsMathpoint(1, 0), New ClsMathpoint(1, 1), Color.Black, 1)


    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click


    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click

        Clear()
        DrawCoordinateSystem()

    End Sub
End Class
