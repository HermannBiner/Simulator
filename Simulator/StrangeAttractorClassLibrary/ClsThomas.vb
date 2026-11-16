'This defines the Thomas Attractor

'Status Tested

Public Class ClsThomas
    Inherits ClsRungeKuttaAttractorAbstract

    'PointConstellations
    Private Standard As ClsPointSet
    Private DoublePair As ClsPointSet
    Private Cloud As ClsPointSet

    Public Sub New()
        'Definition of Parameters
        'Rayleigh number: see math. doc.
        MyDSParameter = New ClsGeneralParameter(0, "b", New ClsInterval(0, CDbl(1)), ClsGeneralParameter.TypeOfParameterEnum.DS, CDbl(0.1998))
        MyDSParameterValue = MyDSParameter.DefaultValue

        'Coordinates 
        MyXValueParameter = New ClsGeneralParameter(1, "X", New ClsInterval(-4, 4), ClsGeneralParameter.TypeOfParameterEnum.Variable, 1)
        MyYValueParameter = New ClsGeneralParameter(2, "Y", New ClsInterval(-4, 4), ClsGeneralParameter.TypeOfParameterEnum.Variable, 1)
        MyZValueParameter = New ClsGeneralParameter(3, "Z", New ClsInterval(-4, 4), ClsGeneralParameter.TypeOfParameterEnum.Variable, 1)

        'Additional Parameters
        MyStepWidth = CDbl(0.05)
        MyMathInterval = New ClsInterval(-5, 5)

        'PointSets
        Standard = New ClsPointSet(LM.GetString("Standard"))
        DoublePair = New ClsPointSet(LM.GetString("DoublePair"))
        Cloud = New ClsPointSet(LM.GetString("Cloud"))

        'Setting split points to be drawn in the Hopf-Bifurcation Diagram
        MySplitpoints = New List(Of Double)
        'there are no split points, 
        'this set is empty

        MyViewCorrection.Component(0) = CDbl(1)
        MyViewCorrection.Component(1) = CDbl(1)
        MyViewCorrection.Component(2) = CDbl(1)

    End Sub

    Public Overrides Sub CreateStartPointSets()

        'Standard
        Standard.AddPoint(New ClsIterationPoint(0, CDbl(0.1), 0, Brushes.Blue))
        Standard.ProposedStepWidth = CDbl(0.05)
        MyStartPointSets.Add(Standard)

        'DoublePair
        DoublePair.AddPoint(New ClsIterationPoint(CDbl(0.1), 0, CDbl(0.1), Brushes.Blue))
        DoublePair.AddPoint(New ClsIterationPoint(CDbl(0.2), 0, CDbl(0.2), Brushes.Aqua))
        DoublePair.AddPoint(New ClsIterationPoint(CDbl(-0.2), 0, CDbl(-0.2), Brushes.Red))
        DoublePair.AddPoint(New ClsIterationPoint(CDbl(-0.1), 0, CDbl(-0.1), Brushes.Green))
        DoublePair.ProposedStepWidth = CDbl(0.05)
        MyStartPointSets.Add(DoublePair)

        'Cloud
        Cloud.AddPoint(New ClsIterationPoint(CDbl(0.1), CDbl(0.1), CDbl(0.1), Brushes.Blue))
        Cloud.AddPoint(New ClsIterationPoint(CDbl(-0.1), CDbl(0.1), CDbl(0.1), Brushes.Aqua))
        Cloud.AddPoint(New ClsIterationPoint(CDbl(0.1), CDbl(-0.1), CDbl(0.1), Brushes.LightBlue))
        Cloud.AddPoint(New ClsIterationPoint(CDbl(0.1), CDbl(0.1), CDbl(-0.1), Brushes.Magenta))
        Cloud.AddPoint(New ClsIterationPoint(CDbl(-0.1), CDbl(-0.1), CDbl(0.1), Brushes.Red))
        Cloud.AddPoint(New ClsIterationPoint(CDbl(-0.1), CDbl(0.1), CDbl(-0.1), Brushes.Green))
        Cloud.AddPoint(New ClsIterationPoint(CDbl(0.1), CDbl(-0.1), CDbl(-0.1), Brushes.Cyan))
        Cloud.ProposedStepWidth = CDbl(0.05)
        MyStartPointSets.Add(Cloud)

    End Sub

    Public Overrides Function F(LocZ As ClsNTupel) As Double
        Return CDbl(-MyDSParameterValue * LocZ.Component(0) + Math.Sin(LocZ.Component(1)))
    End Function

    Public Overrides Function G(LocZ As ClsNTupel) As Double
        Return CDbl(-MyDSParameterValue * LocZ.Component(1) + Math.Sin(LocZ.Component(2)))
    End Function

    Public Overrides Function H(LocZ As ClsNTupel) As Double
        Return CDbl(-MyDSParameterValue * LocZ.Component(2) + Math.Sin(LocZ.Component(0)))
    End Function


End Class
