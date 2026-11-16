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
    Private z As ClsComplexNumber
    Private z1 As ClsComplexNumber

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
        'XInterval = New ClsInterval(CDbl(-2), CDbl(2))
        'YInterval = New ClsInterval(CDbl(-1), CDbl(1))

        'Parabola
        'XInterval = New ClsInterval(CDbl(0), CDbl(2))
        'YInterval = New ClsInterval(CDbl(0), CDbl(6))

        'Epicycle
        XInterval = New ClsInterval(CDbl(-1.5), CDbl(1.5))
        YInterval = New ClsInterval(CDbl(-1.5), CDbl(1.5))

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
        'If IsFormLoaded Then
        '    Clear()
        '    DrawCoordinateSystem()

        '    ApproxEllipseByEpicycle()


        'End If

        z = New ClsComplexNumber(1, 1)

        z1 = z.Power(2)

    End Sub

    Private Sub DrawEpicycle()

        Dim rMain As Double = CDbl(0.8)
        Dim rEpi As Double = CDbl(0.2)
        Dim Omega As Double = CDbl(11)

        Dim t As Double = 0
        Const dt As Double = CDbl(0.001)

        Dim Orbit As New ClsMathpoint

        Do
            With Orbit
                .X = CDbl(rMain * Math.Cos(t) + rEpi * Math.Cos(Omega * t))
                .Y = CDbl(rMain * Math.Sin(t) + rEpi * Math.Sin(Omega * t))

                MyGraphics.DrawPoint(Orbit, Brushes.Blue, 1)

                t += dt
            End With

        Loop Until t >= CDbl(2 * Math.PI)


        MyGraphics.DrawCircle(New ClsMathpoint(0, 0), rMain, Brushes.Red, 1)
        MyGraphics.DrawCircle(New ClsMathpoint(rMain, 0), rEpi, Brushes.Blue, 1)

    End Sub

    Private Sub ApproxEllipseByEpicycle()

        Dim a As Double = CDbl(1)
        Dim b As Double = CDbl(0.8)

        Dim t As Double = 0
        Const dt As Double = CDbl(0.001)

        Dim Orbit As New ClsMathpoint

        'DrawEllipse
        Do
            With Orbit
                .X = CDbl(a * Math.Cos(t))
                .Y = CDbl(b * Math.Sin(t))
                MyGraphics.DrawPoint(Orbit, Brushes.Green, 1)
                t += dt
            End With
        Loop Until t >= CDbl(2 * Math.PI)

        t = 0

        'DrawEpicycle
        Do
            With Orbit
                .X = CDbl((a + b) * Math.Cos(t) / 2 + (a - b) * Math.Cos(3 * t) / 2)
                .Y = CDbl((a + b) * Math.Sin(t) / 2 + (a - b) * Math.Sin(3 * t) / 2)
                MyGraphics.DrawPoint(Orbit, Brushes.Red, 1)
                t += dt
            End With
        Loop Until t >= CDbl(2 * Math.PI)

    End Sub

    Private Sub DrawCurve()
        Dim u As Double = 0
        Dim Gamma As New ClsMathpoint
        Dim p As Integer = 5

        Do

            With Gamma
                .X = CDbl((2 + Math.Sin(u)) * Math.Cos(p * u))
                .Y = CDbl((2 + Math.Sin(u)) * Math.Sin(p * u))
            End With
            MyGraphics.DrawPoint(Gamma, Brushes.Blue, 1)

            u += CDbl(0.001)


        Loop Until u > CDbl(2 * Math.PI)
    End Sub

    Private Sub DrawDirectionField()
        Dim y As Double = YInterval.A
        Dim t As Double
        Dim Deltay As Double
        Dim Deltat As Double
        'sin cos
        'Dim h As Double = CDbl(0.05)
        'Dim k As Double = CDbl(0.02)
        'Parabola
        Dim h As Double = CDbl(0.06)
        Dim k As Double = CDbl(0.05)
        Dim DrawPoint1 As ClsMathpoint
        Dim DrawPoint2 As ClsMathpoint

        'Draw Direction Field
        Do
            t = XInterval.A
            Do
                MyGraphics.DrawPoint(New ClsMathpoint(t, y), Brushes.Black, 2)
                'Deltat = CosArctan(y')*k
                Deltat = CDbl(k / Math.Sqrt(1 + Math.Pow(Derivate(t, y), 2)))
                'Deltay = SinArctan(y')*k
                Deltay = CDbl(Derivate(t, y) * k / Math.Sqrt(1 + Math.Pow(Derivate(t, y), 2)))
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
            t += h * CDbl(0.01)
        Loop Until t > XInterval.B

    End Sub

    Private Function Derivate(t As Double, y As Double) As Double
        'Return CDbl(Math.Sin(t * 3))
        Return CDbl(3 * t * t)
    End Function

    Private Function f(t As Double) As Double
        'Return CDbl((1 - Math.Cos(t * 3)) / 3)
        Return CDbl(t * t * t)
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
