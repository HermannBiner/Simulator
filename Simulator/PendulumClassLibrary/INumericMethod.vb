'This is the interface for different numerical methods
'to solve ordinary differential equations
'that occur in the case of pendula

Public Interface INumericMethod

    'step width
    WriteOnly Property h As Decimal

    'The method to perform one approximation step
    Function NextApproxStep(Tupel As ClsVector) As ClsVector



End Interface
