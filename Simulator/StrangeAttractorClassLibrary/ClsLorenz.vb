'This defines the Lorenz Attractor

'Status Tested

Public Class ClsLorenz
    Inherits ClsRungeKuttaAttractorAbstract

    'Parameters
    'Prandl number: Characteristic of the hydrodynamical system (see math. doc.)
    Private Const Sigma As Decimal = CDec(10)

    'Geometry: If a = CellHigh / Cell Width (see math. doc.)
    'then Beta = 4/(1+a*a)
    Private Const Beta As Decimal = CDec(8 / 3)

    'PointConstellations
    Private Classic As ClsPointSet
    Private Standard As ClsPointSet
    Private Chaotic As ClsPointSet
    Private Pair As ClsPointSet
    Private DoublePair As ClsPointSet
    Private UpperLeft As ClsPointSet
    Private UpperRight As ClsPointSet
    Private DownMiddle As ClsPointSet
    Private Cloud As ClsPointSet

    Public Sub New()
        'Definition of Parameters
        'Rayleigh number: see math. doc.
        MyDSParameter = New ClsGeneralParameter(0, "Rho", New ClsInterval(0, 30),
                                                ClsGeneralParameter.TypeOfParameterEnum.DS, 28)
        MyDSParameterValue = MyDSParameter.DefaultValue

        'Coordinates 
        'X ~ Intensity of the convection movement
        MyXValueParameter = New ClsGeneralParameter(1, "X", New ClsInterval(-20, 20),
                                                    ClsGeneralParameter.TypeOfParameterEnum.Variable, 1)

        'Y ~ temperature difference between ascending and descending stream
        MyYValueParameter = New ClsGeneralParameter(2, "Y", New ClsInterval(-20, 20),
                                                    ClsGeneralParameter.TypeOfParameterEnum.Variable, 1)

        'Z ~ deviation of the vertical temperature profile from a linear profile
        MyZValueParameter = New ClsGeneralParameter(3, "Z", New ClsInterval(0, 50),
                                                    ClsGeneralParameter.TypeOfParameterEnum.Variable, 1)

        'Additional Parameters
        MyStepWidth = CDec(0.001)
        MyMathInterval = New ClsInterval(0, 60)

        'PointSets
        Classic = New ClsPointSet(LM.GetString("Classic"))
        Standard = New ClsPointSet(LM.GetString("Standard"))
        Chaotic = New ClsPointSet(LM.GetString("Chaotic"))
        Pair = New ClsPointSet(LM.GetString("Pair"))
        DoublePair = New ClsPointSet(LM.GetString("DoublePair"))
        UpperLeft = New ClsPointSet(LM.GetString("UpperLeft"))
        UpperRight = New ClsPointSet(LM.GetString("UpperRight"))
        DownMiddle = New ClsPointSet(LM.GetString("DownMiddle"))
        Cloud = New ClsPointSet(LM.GetString("Cloud"))

        'Setting split points to be drawn in the Hopf-Bifurcation Diagram
        MySplitpoints = New List(Of Decimal) From {
            CDec(1), 'Pitchfork Bifurcation
            CDec(1.346), '3 real Eigenvalues
            CDec(13.926), 'C+ and C- exchange as target
            CDec(24.06), 'only some of the orbits are stable
            CDec(24.74) 'all orbits are unstable
           }

        MyViewCorrection.Component(0) = CDec(-10)
        MyViewCorrection.Component(1) = CDec(10)
        MyViewCorrection.Component(2) = CDec(-10)

    End Sub

    Public Overrides Sub CreateStartPointSets()

        'Classic
        Classic.AddPoint(New ClsIterationPoint(1, 1, 1, Brushes.Blue))
        Classic.ProposedStepWidth = CDec(0.001)
        MyStartPointSets.Add(Classic)

        'Standard
        Standard.AddPoint(New ClsIterationPoint(0, 1, 0, Brushes.Blue))
        Standard.ProposedStepWidth = CDec(0.001)
        MyStartPointSets.Add(Standard)

        'Chaotic
        Chaotic.AddPoint(New ClsIterationPoint(10, 10, 10, Brushes.Blue))
        Chaotic.ProposedStepWidth = CDec(0.001)
        MyStartPointSets.Add(Chaotic)

        'Pair   
        Pair.AddPoint(New ClsIterationPoint(CDec(0.01), CDec(0.01), CDec(0.1), Brushes.Blue))
        Pair.AddPoint(New ClsIterationPoint(CDec(-0.01), CDec(-0.01), CDec(0.1), Brushes.Red))

        Pair.ProposedStepWidth = CDec(0.001)
        MyStartPointSets.Add(Pair)

        'DoublePair
        DoublePair.AddPoint(New ClsIterationPoint(CDec(0.01), CDec(0.01), CDec(0.1), Brushes.Blue))
        DoublePair.AddPoint(New ClsIterationPoint(CDec(-0.01), CDec(-0.01), CDec(0.1), Brushes.Red))
        DoublePair.AddPoint(New ClsIterationPoint(CDec(-0.01), CDec(0.01), CDec(0.1), Brushes.Green))
        DoublePair.AddPoint(New ClsIterationPoint(CDec(0.01), CDec(-0.01), CDec(0.1), Brushes.OrangeRed))

        DoublePair.ProposedStepWidth = CDec(0.001)
        MyStartPointSets.Add(DoublePair)

        'UpperLeft
        UpperLeft.AddPoint(New ClsIterationPoint(CDec(-14), CDec(-14), CDec(39), Brushes.Red))
        UpperLeft.AddPoint(New ClsIterationPoint(CDec(-14.2), CDec(-14.2), CDec(39.2), Brushes.Red))
        UpperLeft.AddPoint(New ClsIterationPoint(CDec(-14.4), CDec(-14.4), CDec(39.4), Brushes.Yellow))
        UpperLeft.AddPoint(New ClsIterationPoint(CDec(-14.6), CDec(-14.6), CDec(39.6), Brushes.Magenta))
        UpperLeft.AddPoint(New ClsIterationPoint(CDec(-14.8), CDec(-14.8), CDec(39.8), Brushes.Pink))
        UpperLeft.AddPoint(New ClsIterationPoint(CDec(-15), CDec(-15), CDec(40), Brushes.Lime))
        UpperLeft.ProposedStepWidth = CDec(0.001)
        MyStartPointSets.Add(UpperLeft)

        'UpperRight
        UpperRight.AddPoint(New ClsIterationPoint(CDec(14), CDec(14), CDec(39), Brushes.Blue))
        UpperRight.AddPoint(New ClsIterationPoint(CDec(14.2), CDec(14.2), CDec(39.2), Brushes.Green))
        UpperRight.AddPoint(New ClsIterationPoint(CDec(14.4), CDec(14.4), CDec(39.4), Brushes.LightGreen))
        UpperRight.AddPoint(New ClsIterationPoint(CDec(14.6), CDec(14.6), CDec(39.6), Brushes.Cyan))
        UpperRight.AddPoint(New ClsIterationPoint(CDec(14.8), CDec(14.8), CDec(39.8), Brushes.LightBlue))
        UpperRight.AddPoint(New ClsIterationPoint(CDec(15), CDec(15), CDec(40), Brushes.LimeGreen))
        UpperRight.ProposedStepWidth = CDec(0.001)
        MyStartPointSets.Add(UpperRight)

        'DownMiddle
        DownMiddle.AddPoint(New ClsIterationPoint(CDec(-1), CDec(-1), CDec(0.5), Brushes.Red))
        DownMiddle.AddPoint(New ClsIterationPoint(CDec(-0.7), CDec(-0.7), CDec(1), Brushes.Yellow))
        DownMiddle.AddPoint(New ClsIterationPoint(CDec(-0.3), CDec(-0.3), CDec(0.8), Brushes.Pink))
        DownMiddle.AddPoint(New ClsIterationPoint(CDec(0.3), CDec(0.3), CDec(0.8), Brushes.Blue))
        DownMiddle.AddPoint(New ClsIterationPoint(CDec(0.7), CDec(0.7), CDec(1), Brushes.Green))
        DownMiddle.AddPoint(New ClsIterationPoint(CDec(1), CDec(1), CDec(0.5), Brushes.Cyan))
        DownMiddle.ProposedStepWidth = CDec(0.001)
        MyStartPointSets.Add(DownMiddle)

        'Cloud
        Cloud.AddPoint(New ClsIterationPoint(CDec(14), CDec(14), CDec(39), Brushes.Blue))
        Cloud.AddPoint(New ClsIterationPoint(CDec(-14), CDec(-14), CDec(39), Brushes.Red))
        Cloud.AddPoint(New ClsIterationPoint(CDec(10), CDec(10), CDec(10), Brushes.Green))
        Cloud.AddPoint(New ClsIterationPoint(CDec(-10), CDec(-10), CDec(10), Brushes.Magenta))
        Cloud.AddPoint(New ClsIterationPoint(CDec(1), CDec(1), CDec(5), Brushes.LightBlue))
        Cloud.AddPoint(New ClsIterationPoint(CDec(-1), CDec(-1), CDec(5), Brushes.Cyan))
        Cloud.AddPoint(New ClsIterationPoint(CDec(3), CDec(3), CDec(7), Brushes.Aqua))
        Cloud.AddPoint(New ClsIterationPoint(CDec(-3), CDec(-3), CDec(7), Brushes.Lime))
        Cloud.AddPoint(New ClsIterationPoint(CDec(5), CDec(5), CDec(9), Brushes.Yellow))
        Cloud.AddPoint(New ClsIterationPoint(CDec(-5), CDec(-5), CDec(9), Brushes.Pink))
        Cloud.ProposedStepWidth = CDec(0.005)
        MyStartPointSets.Add(Cloud)

    End Sub

    Public Overrides Function F(LocZ As ClsNTupel) As Decimal
        Return Sigma * (LocZ.Component(1) - LocZ.Component(0))
    End Function

    Public Overrides Function G(LocZ As ClsNTupel) As Decimal
        Return MyDSParameterValue * LocZ.Component(0) - LocZ.Component(1) - LocZ.Component(0) * LocZ.Component(2)
    End Function

    Public Overrides Function H(LocZ As ClsNTupel) As Decimal
        Return -Beta * LocZ.Component(2) + LocZ.Component(0) * LocZ.Component(1)
    End Function

End Class
