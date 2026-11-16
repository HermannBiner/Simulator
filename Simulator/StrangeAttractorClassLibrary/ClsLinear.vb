'This class shows the bevaviour of a linear map
'in the neighbourhood of the zero point

'Status Tested


Public Class ClsLinear
    Inherits ClsStrangeAttractorAbstract

    'Parameters - Standardform of the Matrix of the linear map
    'see math. doc.

    'the real Eigenvalue
    Private Lambda As Double
    'if Beta = 0, then the second real Eigenvalue
    'if Beta <> 0, then the real part of the complex Eigenvalue
    'and in that case must be Delta = Alfa
    Private Alfa As Double
    'if Beta <> 0, then the imaginary part of the complex Eigenvalue
    Private Beta As Double
    'if Beta <> 0, then Delta = Alfa
    'else: Delta the third real Eigenvalue
    Private Delta As Double
    'Phi is the angle of the rotation
    Private Phi As Double

    'PointConstellations
    Private Hexagon As ClsPointSet
    Private Triangle As ClsPointSet

    Public Sub New()
        'Definition of Parameters
        'Rho defines the type of the Zero Point as fixed point
        MyDSParameter = New ClsGeneralParameter(0, "Rho", New ClsInterval(0, 20), ClsGeneralParameter.TypeOfParameterEnum.DS, 4)
        MyDSParameterValue = MyDSParameter.DefaultValue

        'Coordinates 
        MyXValueParameter = New ClsGeneralParameter(1, "X", New ClsInterval(-10, 10), ClsGeneralParameter.TypeOfParameterEnum.Variable, 1)
        MyYValueParameter = New ClsGeneralParameter(2, "Y", New ClsInterval(-10, 10), ClsGeneralParameter.TypeOfParameterEnum.Variable, 1)
        MyZValueParameter = New ClsGeneralParameter(3, "Z", New ClsInterval(0, 10), ClsGeneralParameter.TypeOfParameterEnum.Variable, 1)


        'Default step width: the bifurcation diagram uses it
        '0.005 is the proposed step width of the start point sets
        MyStepWidth = CDbl(0.005)

        MyMathInterval = New ClsInterval(-10, 10)

        'PointSets
        Hexagon = New ClsPointSet(LM.GetString("Hexagon"))
        Triangle = New ClsPointSet(LM.GetString("Triangle"))


        'not used at the moment
        MySplitpoints = New List(Of Double)

        MyViewCorrection.Component(0) = CDbl(0)
        MyViewCorrection.Component(1) = CDbl(0)
        MyViewCorrection.Component(2) = CDbl(0)

    End Sub

    Public Overrides Sub CreateStartPointSets()

        'Hexagon
        Hexagon.AddPoint(New ClsIterationPoint(8, 8, 10, Brushes.Aqua))
        Hexagon.AddPoint(New ClsIterationPoint(2, 2, 10, Brushes.Blue))
        Hexagon.AddPoint(New ClsIterationPoint(1, 3, 10, Brushes.Green))
        Hexagon.AddPoint(New ClsIterationPoint(3, 1, 10, Brushes.LightGreen))
        Hexagon.AddPoint(New ClsIterationPoint(4, 4, 10, Brushes.Orange))
        Hexagon.AddPoint(New ClsIterationPoint(5, 5, 10, Brushes.Red))
        Hexagon.ProposedStepWidth = CDbl(0.005)
        MyStartPointSets.Add(Hexagon)

        'Triangle
        Triangle.AddPoint(New ClsIterationPoint(5, 5, 10, Brushes.Green))
        Triangle.AddPoint(New ClsIterationPoint(1, 3, 10, Brushes.Blue))
        Triangle.AddPoint(New ClsIterationPoint(3, 1, 10, Brushes.Red))
        Triangle.ProposedStepWidth = CDbl(0.005)
        MyStartPointSets.Add(Triangle)


    End Sub

    Public Overrides Sub SetIterationParameters()
        'a sector for the DSParameter
        Dim Sector As Double
        Sector = CDbl(MyDSParameter.Range.IntervalWidth / 2)
        Select Case True
            Case DSParameterValue <= Sector
                Lambda = CDbl(0.985 + 0.01 * DSParameterValue / Sector)
                Alfa = CDbl(0.985 + 0.02 * DSParameterValue / Sector)
                Delta = CDbl(0.985 + 0.03 * DSParameterValue / Sector)
                Beta = 0
            Case Else
                Lambda = CDbl(0.985 + 0.01 * (DSParameterValue - Sector) / Sector)
                Phi = CDbl(MyStepWidth * Math.PI)
                Dim a As Double = CDbl(0.985 + 0.02 * (DSParameterValue - Sector) / Sector)
                Alfa = CDbl(a * Math.Cos(Phi))
                Delta = Alfa
                Beta = CDbl(a * Math.Sin(Phi))
        End Select

    End Sub


    Public Overrides Sub IterationStep()

        With MyActualMathPoint
            'the repeated multiplication with a factor lamda
            'let grow .X, .Y nd .Z very fast
            'therefore, that is sopped if the values are out of the range

            'Y is calculated with the old X
            Dim OldX As Double = .X

            .X = Math.Max(-DSParameter.Range.IntervalWidth * 2,
                          Math.Min(DSParameter.Range.IntervalWidth * 2, Alfa * OldX - Beta * .Y))
            .Y = Math.Max(-DSParameter.Range.IntervalWidth * 2,
                          Math.Min(DSParameter.Range.IntervalWidth * 2, Beta * OldX + Delta * .Y))
            .Z = Math.Max(-DSParameter.Range.IntervalWidth * 2,
                          Math.Min(DSParameter.Range.IntervalWidth * 2, Lambda * .Z))
        End With

    End Sub

End Class
