'This class implements the generation of the Mandelbrot Set
'in case of the iterated function f(z)=z^N+c
'It implements Julia and heritates from ClsJuliaAbstract

'Status Checked

Public Class ClsMandelbrot
    Inherits ClsJuliaAbstract
    Const MaxSteps As Integer = 250

    Private UpperBoundSteps As Integer = 0
    Private LowerBoundSteps As Integer = MaxSteps


    Public Sub New()

        'The Julia set is contained in a circle of raduis 2
        MyAllowedXRange = New ClsInterval(CDec(-2), CDec(0.6))
        MyAllowedYRange = New ClsInterval(CDec(-1.3), CDec(1.3))

        MyActualXRange = MyAllowedXRange
        MyActualYRange = MyAllowedYRange

    End Sub

    Public Overrides Function IterationFormula(Zi As ClsComplexNumber) As Brush

        Dim Steps As Integer = 0

        'For the Mandelbrot-Set, the Parameter C is the Point Zi
        MyC.X = Zi.X
        MyC.Y = Zi.Y

        'For the Mandelbrot set, the Iteration starts always with Zi=0
        Zi = New ClsComplexNumber(0, 0)

        Do Until (Zi.AbsoluteValue > Math.Exp(Math.Log(2) / (MyN - 1))) Or (Steps > MaxSteps)

            Steps += 1

            'This is the formula for the classic Julia set
            Zi = Zi.Power(MyN).Add(MyC)

        Loop

        'depending on the #of steps, the color of the brush is choosen
        'there are 25 colors available and the steps are between 0 and MaxSteps
        'The lowest color-index is for the highest # steps, therefore:
        Dim MyBrush As Brush

        If Steps > MaxSteps Then
            MyBrush = New SolidBrush(Color.Black)
        Else
            Steps = Math.Max(1, Steps) 'if steps = 0, then the color is black as well otherwise
            'we increase the bright part of the Julia set
            'that means, we replace the linear increasing step-number
            'by a parabola going through the points (0,0), (MaxSteps, MaxSteps)
            Dim ColorIndex As Double = Steps / MaxSteps
            ColorIndex = Math.Exp(Math.Log(ColorIndex) / 5)

            MyBrush = New SolidBrush(Color.FromArgb(255, CInt(255 * ColorIndex * MyRedPercent),
                       CInt(255 * ColorIndex * MyGreenPercent), CInt(255 * ColorIndex * MyBluePercent)))
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

        'the lower the colorindex the brighter the color
        Return MyBrush

    End Function

End Class
