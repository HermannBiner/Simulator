'This defines the Roessler Attractor

'Status Tested

Public Class ClsRoessler
    Inherits ClsRungeKuttaAttractorAbstract

    'Parameters
    'we study the case where a and b are fixed (see math. doc.)
    'and c is the DSParameter
    Private Const a As Double = CDbl(0.2)
    Private Const b As Double = CDbl(0.2)

    'PointConstellations
    Private Standard As ClsPointSet
    Private DoublePair As ClsPointSet
    Private Cloud As ClsPointSet

    Public Sub New()
        'Definition of Parameters
        'Rayleigh number: see math. doc.
        MyDSParameter = New ClsGeneralParameter(0, "c", New ClsInterval(1, 10), ClsGeneralParameter.TypeOfParameterEnum.DS, 6)
        MyDSParameterValue = MyDSParameter.DefaultValue

        'Coordinates 
        MyXValueParameter = New ClsGeneralParameter(1, "X", New ClsInterval(-25, 25), ClsGeneralParameter.TypeOfParameterEnum.Variable, 1)
        MyYValueParameter = New ClsGeneralParameter(2, "Y", New ClsInterval(-25, 25), ClsGeneralParameter.TypeOfParameterEnum.Variable, 1)
        MyZValueParameter = New ClsGeneralParameter(3, "Z", New ClsInterval(0, 30), ClsGeneralParameter.TypeOfParameterEnum.Variable, 1)

        'Additional Parameters
        MyStepWidth = CDbl(0.01)
        MyMathInterval = New ClsInterval(0, 40)

        'PointSets
        Standard = New ClsPointSet(LM.GetString("Standard"))
        DoublePair = New ClsPointSet(LM.GetString("DoublePair"))
        Cloud = New ClsPointSet(LM.GetString("Cloud"))

        'Setting split points to be drawn in the Hopf-Bifurcation Diagram
        MySplitpoints = New List(Of Double)
        'Because in the Roessler Diagram, there arre no split points, 
        'this set is empty

        MyViewCorrection.Component(0) = CDbl(-5)
        MyViewCorrection.Component(1) = CDbl(-5)
        MyViewCorrection.Component(2) = CDbl(-5)

    End Sub

    Public Overrides Sub CreateStartPointSets()

        'Standard
        Standard.AddPoint(New ClsIterationPoint(0, 1, 0, Brushes.Blue))
        Standard.ProposedStepWidth = CDbl(0.01)
        MyStartPointSets.Add(Standard)

        'DoublePair
        DoublePair.AddPoint(New ClsIterationPoint(CDbl(0.1), CDbl(0.1), CDbl(0.1), Brushes.Blue))
        DoublePair.AddPoint(New ClsIterationPoint(CDbl(-0.1), CDbl(-0.1), CDbl(0.1), Brushes.Red))
        DoublePair.AddPoint(New ClsIterationPoint(CDbl(-0.1), CDbl(0.1), CDbl(0.1), Brushes.Green))
        DoublePair.AddPoint(New ClsIterationPoint(CDbl(0.1), CDbl(-0.1), CDbl(0.1), Brushes.OrangeRed))
        DoublePair.ProposedStepWidth = CDbl(0.01)
        MyStartPointSets.Add(DoublePair)


        'Cloud
        Cloud.AddPoint(New ClsIterationPoint(CDbl(0.1), CDbl(0.1), CDbl(0.1), Brushes.Blue))
        Cloud.AddPoint(New ClsIterationPoint(CDbl(-0.1), CDbl(0.1), CDbl(0.1), Brushes.Aqua))
        Cloud.AddPoint(New ClsIterationPoint(CDbl(0.1), CDbl(-0.1), CDbl(0.1), Brushes.LightBlue))
        Cloud.AddPoint(New ClsIterationPoint(CDbl(0.1), CDbl(0.1), CDbl(0.5), Brushes.Magenta))
        Cloud.AddPoint(New ClsIterationPoint(CDbl(-0.1), CDbl(-0.1), CDbl(0.1), Brushes.Red))
        Cloud.AddPoint(New ClsIterationPoint(CDbl(-0.1), CDbl(0.1), CDbl(0.5), Brushes.Green))
        Cloud.AddPoint(New ClsIterationPoint(CDbl(0.1), CDbl(-0.1), CDbl(0.5), Brushes.Cyan))
        Cloud.ProposedStepWidth = CDbl(0.05)
        MyStartPointSets.Add(Cloud)

    End Sub

    Public Overrides Function F(LocZ As ClsNTupel) As Double
        Return -(LocZ.Component(1) + LocZ.Component(2))
    End Function

    Public Overrides Function G(LocZ As ClsNTupel) As Double
        Return LocZ.Component(0) + a * LocZ.Component(1)
    End Function

    Public Overrides Function H(LocZ As ClsNTupel) As Double
        Return b + (LocZ.Component(0) - MyDSParameterValue) * LocZ.Component(2)
    End Function

End Class
