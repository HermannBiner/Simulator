'This is the interface to implement th specific functions
'that are needed when calculating the Runge Kutta algorithm
'the interface is needed for ClsRungeKutta4General
'and must be implemented by classes, that are using 
'ClsRungeKutta4General - e.g. Universes

'Status in Construction

Public Interface IRungeKuttaFunctions

    Function F1(MyX As ClsNTupel) As Decimal
    Function F2(MyX As ClsNTupel) As Decimal
    Function G1(MyX As ClsNTupel) As Decimal
    Function G2(MyX As ClsNTupel) As Decimal

End Interface
