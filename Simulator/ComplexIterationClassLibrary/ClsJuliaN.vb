'This class implements the generation of the Julia set
'in case of the iterated function f(z)=z^N+c
'It implements Julia and heritates from ClsJuliaAbstract

'Status Checked


Public Class ClsJuliaN
    Inherits ClsJuliaAbstract

    'the precision of the border of the Julia set
    Const MaxSteps As Integer = 250

    Private MyN As Integer

    Private ReadOnly StandardColors As ClsSystemBrushes

    Private UpperBoundSteps As Integer = 0
    Private LowerBoundSteps As Integer = MaxSteps

    Public Sub New()

        'The Julia set is contained in a circle of radius 2
        MyAllowedXRange = New ClsInterval(CDec(-1.5), CDec(1.5))
        MyAllowedYRange = New ClsInterval(CDec(-1.5), CDec(1.5))

        MyActualXRange = MyAllowedXRange
        MyActualYRange = MyAllowedYRange

        StandardColors = New ClsSystemBrushes(MaxSteps)

    End Sub

    Protected Overrides WriteOnly Property N As Integer
        Set(value As Integer)
            MyN = value
        End Set
    End Property

    Public Overrides Function IterationFormula(Zi As ClsComplexNumber) As Brush

        Dim Steps As Integer = 0
        Dim R As Decimal = CDec(Math.Max(MyC.AbsoluteValue, Math.Pow(2, 1 / (MyN - 1))))

        Do Until (Zi.AbsoluteValue > R) Or (Steps > MaxSteps)

            Steps += 1

            'This is the formula for the classic Julia set
            Zi = Zi.Power(MyN).Add(MyC)

        Loop

        'depending on the #of steps, the color of the brush is choosen
        'there are 25 colors available and the steps are between 0 and MaxSteps
        'The lowest color-index is for the highest # steps, therefore:
        Dim MyBrush As Brush
        Dim ColorIndex As Double

        If Steps > MaxSteps Then
            MyBrush = New SolidBrush(Color.Black)
        Else
            'if steps = 0, the color would be black as well, therefore we set
            Steps = Math.Max(1, Steps)


            If MyUseSystemColors Then
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

            If MyIsProtocol Then
                If Steps > UpperBoundSteps Then
                    UpperBoundSteps = Steps
                    MyProtocolList.Items.Add(UpperBoundSteps.ToString)
                ElseIf Steps < LowerBoundSteps Then
                    LowerBoundSteps = Steps
                    MyProtocolList.Items.Add(LowerBoundSteps.ToString)
                End If
            End If
        End If

        'the lower the colorindex the brighter the color
        Return MyBrush

    End Function

    Public Overrides Sub ShowCTrack()
        'is not relevant for a Julia Set Generation
        Throw New NotImplementedException()
    End Sub

End Class
