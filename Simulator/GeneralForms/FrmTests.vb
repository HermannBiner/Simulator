'This form allows testing graphical or other methods
'normally, the menu to open this form in FrmMain is not visible

'Status checked

Public Class FrmTests

    Private ReadOnly LM As ClsLanguageManager
    Private IsFormLoaded As Boolean
    Private IsAdjusting As Boolean

    Const StepWide As Double = 0.001

    Private MyGraphics As ClsGraphicTool
    Private XInterval As ClsInterval
    Private YInterval As ClsInterval

    Public Sub New()
        LM = ClsLanguageManager.LM

        'This is necessary for the designer
        InitializeComponent()

    End Sub


    Private Sub FrmTests_Load(sender As Object, e As EventArgs) Handles Me.Load

        IsFormLoaded = False

        'Initialize Language
        InitializeLanguage()
        SetDefaulValues()

    End Sub

    Private Sub FrmTests_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        AdjustLayout()
    End Sub

    Private Sub AdjustLayout()
        'to avoid a loop
        If IsAdjusting Then
            Exit Sub
        Else
            IsAdjusting = True
            'we have to make sure that the diagram is square
            Dim DiagramSize As Integer = Math.Max(Math.Min(SplitContainer.Panel1.Width, SplitContainer.Panel1.Height), 10)
            PicDiagram.Width = DiagramSize
            PicDiagram.Height = DiagramSize
            PicDiagram.Left = (SplitContainer.Panel1.Width - PicDiagram.Width) \ 2
            PicDiagram.Top = BtnTest.Top
            SplitContainer.SplitterDistance = DiagramSize
            IsAdjusting = False
        End If
    End Sub

    Private Sub FrmTests_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        IsFormLoaded = True
    End Sub

    Private Sub InitializeLanguage()

        BtnTest.Text = LM.GetString("Test")
        Text = LM.GetString("Test")

    End Sub

    Private Sub SetDefaulValues()

        XInterval = New ClsInterval(CDec(-4), CDec(4))
        YInterval = New ClsInterval(CDec(-4), CDec(4))
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
        If IsFormLoaded Then
            Clear()
            DrawCoordinateSystem()


            Dim u As Decimal = 0
            Dim Gamma As New ClsMathpoint

            Do

                With Gamma
                    .X = CDec(Math.Pow(Math.Cos(u), 3))
                    .Y = CDec(Math.Sin(u))
                End With
                MyGraphics.DrawPoint(Gamma, Brushes.Blue, 1)

                u += CDec(0.001)


            Loop Until u > CDec(2 * Math.pi)

        End If
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click
        If IsFormLoaded Then

        End If
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        If IsFormLoaded Then
            Clear()
            DrawCoordinateSystem()
        End If
    End Sub

    'LAYOUT

    Private Sub SplitContainer_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer.SplitterMoved
        If IsFormLoaded Then
            AdjustLayout()
        End If
    End Sub

    Private Sub FrmTests_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If IsFormLoaded Then
            AdjustLayout()
        End If
    End Sub
End Class
