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

        'Sin/Cos
        'XInterval = New ClsInterval(CDec(-2), CDec(2))
        'YInterval = New ClsInterval(CDec(-1), CDec(1))
        'Parabola
        XInterval = New ClsInterval(CDec(0), CDec(2))
        YInterval = New ClsInterval(CDec(0), CDec(6))
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

            DrawDirectionField()


        End If
    End Sub

    Private Sub DrawCurve()
        Dim u As Decimal = 0
        Dim Gamma As New ClsMathpoint
        Dim p As Integer = 5

        Do

            With Gamma
                .X = CDec((2 + Math.Sin(u)) * Math.Cos(p * u))
                .Y = CDec((2 + Math.Sin(u)) * Math.Sin(p * u))
            End With
            MyGraphics.DrawPoint(Gamma, Brushes.Blue, 1)

            u += CDec(0.001)


        Loop Until u > CDec(2 * Math.PI)
    End Sub

    Private Sub DrawDirectionField()
        Dim y As Decimal = YInterval.A
        Dim t As Decimal
        Dim Deltay As Decimal
        Dim Deltat As Decimal
        'sin cos
        'Dim h As Decimal = CDec(0.05)
        'Dim k As Decimal = CDec(0.02)
        'Parabola
        Dim h As Decimal = CDec(0.06)
        Dim k As Decimal = CDec(0.05)
        Dim DrawPoint1 As ClsMathpoint
        Dim DrawPoint2 As ClsMathpoint

        'Draw Direction Field
        Do
            t = XInterval.A
            Do
                MyGraphics.DrawPoint(New ClsMathpoint(t, y), Brushes.Black, 2)
                'Deltat = CosArctan(y')*k
                Deltat = CDec(k / Math.Sqrt(1 + Math.Pow(Derivate(t, y), 2)))
                'Deltay = SinArctan(y')*k
                Deltay = CDec(Derivate(t, y) * k / Math.Sqrt(1 + Math.Pow(Derivate(t, y), 2)))
                'Draw Direction at (t,y)
                DrawPoint1 = New ClsMathpoint(t - Deltat, y - Deltay)
                DrawPoint2 = New ClsMathpoint(t + Deltat, y + Deltay)
                MyGraphics.DrawLine(DrawPoint1, DrawPoint2, Color.Blue, 1)
                t += h
            Loop Until t > XInterval.B
            y += h * 2
        Loop Until y > YInterval.B

        'Draw Function Curve
        t = XInterval.A
        Do
            MyGraphics.DrawPoint(New ClsMathpoint(t, f(t)), Brushes.Green, 1)
            t += h * CDec(0.01)
        Loop Until t > XInterval.B

    End Sub

    Private Function Derivate(t As Decimal, y As Decimal) As Decimal
        'Return CDec(Math.Sin(t * 3))
        Return CDec(3 * t * t)
    End Function

    Private Function f(t As Decimal) As Decimal
        'Return CDec((1 - Math.Cos(t * 3)) / 3)
        Return CDec(t * t * t)
    End Function

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
