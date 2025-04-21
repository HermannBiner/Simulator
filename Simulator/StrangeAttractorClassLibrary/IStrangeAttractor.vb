'This is the Interface for all types of strange attractors
'it contains all parameters and definitions
'and RK functions that are specific for strange attractors

'Status Tested

Public Interface IStrangeAttractor

    'Relevant Parameter for chaotic behaviour
    'Definition
    ReadOnly Property DSParameter As ClsGeneralParameter

    'Parameter itself
    Property DSParameterValue As Decimal

    ReadOnly Property XValueParameter As ClsGeneralParameter
    ReadOnly Property YValueParameter As ClsGeneralParameter
    ReadOnly Property ZValueParameter As ClsGeneralParameter

    Property StepWidth As Decimal

    ReadOnly Property StartPointSets As List(Of ClsPointSet)

    ReadOnly Property MathInterval As ClsInterval

    'Splitpoints of the Hopf-Bifurcation diagram
    ReadOnly Property Splitpoints As List(Of Decimal)

    Property ActualMathPoint As ClsMathpoint

    'for the better view in the diagram we adjust the position
    'depending on the attractor
    ReadOnly Property ViewCorrection As ClsNTupel

    Sub CreateStartPointSets()

    Sub SetIterationParameters()

    Sub IterationStep()

End Interface
