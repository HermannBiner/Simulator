'Is the interface for any kind of iteration
'for unimodal functions
'To program a new unimodal function
'just this interface has to be implemented

'Status Checked

Public Interface IIteration

    'Steering parameter definition of the iteration 
    ReadOnly Property DSParameter As ClsGeneralParameter

    'Value of the steering Parameter
    Property ParameterA As Double

    'Definition of the x-Value for the Iteration
    ReadOnly Property ValueParameter As ClsGeneralParameter

    'How many times is the function F performed in one iteration step
    WriteOnly Property Power As Integer

    'Splitpoints of the Feigenbaum diagram
    ReadOnly Property Splitpoints As List(Of Double)

    'Critical Point for attractive basins
    ReadOnly Property CriticalPoint As Double

    'The Chaotic ParameterValue
    ReadOnly Property ChaoticParameterValue As Double


    'If there is a given protocol by the user
    'the program should calculate an appropriate start value (in case of chaos)
    'that delivers this protocol
    'see the mathematical documentation
    Function CalculateStartValueForProtocol(TargetProtocol As String) As Double

    'If there is a given target value for the iteration by the user
    'the program should calculate an appropriate start value (in case of chaos)
    'that approaches the target value
    'see the mathematical documentation
    Function CalculateStartValueForTargetValue(StartValue As Double, TargetValue As Double) As Double

    'F is the internal function, that contains the iteration rule
    'this function is repeated xPower in one iteration step
    'Therefore, the "outside" used function is Fn = F^Power
    'x is the argument of the function Fn
    Function FN(x As Double) As Double

    'Some of the experiments are only meaningfull in case of chaos
    'This function examines if the case is chaotic
    Function IsBehaviourChaotic() As Boolean

End Interface
