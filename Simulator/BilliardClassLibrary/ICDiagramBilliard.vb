'Interface for the study of the influence of a parameter C
'defining the profile of Billiards
'to their parameters like Hitpoins or Angles
'describing their dynamic behaviour

'the C-Diagram corresponds to the Feigenbaum Diagramm for Unimodal Functions

'Status Checked


Public Interface ICDiagramBilliard

    'The Parameter C steers the profile of the investigated danymic system
    'and is set in the beginning of the iteration for this C
    WriteOnly Property CParameter As Decimal

    'depending on the type of iteration, 
    'the parameter C is in a certain interval
    ReadOnly Property CParameterRange As ClsInterval

    'ClsValueRange contains all necessary information of a valuerange
    'like the reflexion angle of a Billiard
    'and ValueRanges is the List of such Valueranges
    'of the dynamic system
    ReadOnly Property ValueParameters As List(Of ClsValueParameter)

    'This is the main Function to get the next Iteration Point
    Function GetNextPoint(ActualPoint As ClsValuePair) As ClsValuePair

End Interface
