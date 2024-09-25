'This class implements the generation of the Mandelbrot Set
'in case of the iterated function f(z)=z^N+c
'It implements Julia and heritates from ClsJuliaAbstract

'Status Checked


Public Class ClsMandelbrot
    Inherits ClsJuliaAbstract

    'the precision of the boundary of the Mandelbrot set
    Const MaxSteps As Integer = 250

    Private MyN As Integer

    Private ReadOnly StandardColors As ClsSystemBrushes

    Private UpperBoundSteps As Integer = 0
    Private LowerBoundSteps As Integer = MaxSteps

    'Iteration Parameter
    Private Zi As ClsComplexNumber
    Private Shadows Steps As Integer
    Private Radius As Decimal
    Private ColorIndex As Double
    Private MyBrush As Brush

    Public Sub New()

        SetParameterRange()

        StandardColors = New ClsSystemBrushes(MaxSteps)

        'Iteration Parameter
        Zi = New ClsComplexNumber(0, 0)

        MyBrush = New SolidBrush(Color.Black)

    End Sub

    Protected Overrides WriteOnly Property N As Integer
        Set(value As Integer)
            If value <> MyN Then
                MyN = value
                SetParameterRange()
            End If
        End Set
    End Property

    Protected Overrides ReadOnly Property IsMandelbrot As Boolean
        Get
            IsMandelbrot = True
        End Get
    End Property

    Private Sub SetParameterRange()

        If MyN = 2 Then

            'Size of the Mandelbrot set in case MyN = 2
            MyXValueParameter = New ClsGeneralParameter(1, "x-Values", New ClsInterval(CDec(-2), CDec(0.6)), ClsGeneralParameter.TypeOfParameterEnum.Value)
            MyYValueParameter = New ClsGeneralParameter(1, "y-Values", New ClsInterval(CDec(-1.3), CDec(1.3)), ClsGeneralParameter.TypeOfParameterEnum.Value)

        Else

            'centered
            MyXValueParameter = New ClsGeneralParameter(1, "x-Values", New ClsInterval(CDec(-1.5), CDec(1.5)), ClsGeneralParameter.TypeOfParameterEnum.Value)
            MyYValueParameter = New ClsGeneralParameter(1, "y-Values", New ClsInterval(CDec(-1.5), CDec(1.5)), ClsGeneralParameter.TypeOfParameterEnum.Value)
        End If

        MyActualXRange = MyXValueParameter.Range
        MyActualYRange = MyYValueParameter.Range

    End Sub

    Public Overrides Sub IterationStep(Startpoint As Point)

        'Transform the PixelPoint to a Complex Number

        With BmpGraphics.PixelToMathpoint(Startpoint)
            'Saved for debugging
            Zi.X = .X
            Zi.Y = .Y
        End With

        Steps = 0

        'For the Mandelbrot-Set, the Point Zi is replaced by C
        MyC.X = Zi.X
        MyC.Y = Zi.Y

        'For the Mandelbrot set, the Iteration starts always with Zi = 0
        Zi.X = 0
        Zi.Y = 0

        Radius = CDec(Math.Pow(2, 1 / (MyN - 1)))

        Do Until (Zi.AbsoluteValue > Radius) Or (Steps > MaxSteps)

            Steps += 1

            'This is the formula for the classic Julia set
            Zi = Zi.Power(MyN).Add(MyC)

        Loop

        'depending on the #of steps, the color of the brush is choosen
        'there are 25 colors available and the steps are between 0 and MaxSteps
        'The lowest color-index is for the highest # steps, therefore:

        If Steps > MaxSteps Then
            MyBrush = New SolidBrush(Color.Black)
        Else
            'if steps = 0, the color would be black as well, therefore we set
            Steps = Math.Max(1, Steps)

            If MyIsUseSystemColors Then
                MyBrush = StandardColors.GetSystemBrush(Steps)
                ColorIndex = 1
            Else

                ColorIndex = Steps / MaxSteps

                'to keep the brightness higher
                ColorIndex = Math.Min(1, ColorIndex * 2)
                ColorIndex = Math.Pow(ColorIndex, 1 / 5)

                MyBrush = New SolidBrush(Color.FromArgb(255, CInt(255 * ColorIndex * MyRedPercent),
                CInt(255 * ColorIndex * MyGreenPercent), CInt(255 * ColorIndex * MyBluePercent)))
            End If
        End If

        If MyIsProtocol Then
            If Steps > UpperBoundSteps Then
                UpperBoundSteps = Steps
                MyProtocolList.Items.Add(UpperBoundSteps)
            ElseIf Steps < LowerBoundSteps Then
                LowerBoundSteps = Steps
                MyProtocolList.Items.Add(LowerBoundSteps)
            End If
        End If

        BmpGraphics.DrawPoint(Startpoint, MyBrush, 1)
        MyBrush.Dispose()

    End Sub

End Class
