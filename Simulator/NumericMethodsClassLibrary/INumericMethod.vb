'This is the interface for different kind of pendulum
'together with its numeric method to calculate its position
'thereby e.g. a Spring Pendulum with the Euler Explicit approximation method
'is treated as a different pendulum than a Spring Pendulum with the Euler Implicit Method
'Terefore, the kind of Pendulum is implicitely defined by its numerical method

'Status Checked

Public Interface INumericMethod

    'step width for each approximation step
    'this is set before the approximation starts
    'by the User Interface
    Property h As Decimal

    'number of approximation steps before result is returned
    'This number is set by the User Interface
    WriteOnly Property NumberOfApproxSteps As Integer

    'The amplitude is constant and set at the startposition
    WriteOnly Property Amplitude As Decimal

    'The ActualParameter holds the information about the 
    'y-position of the Pendulum in its Component(1)
    'and the "time" t in its Component(0)
    'and additional values like the derivate y' in Component(2)
    Property ActualParameter(Index As Integer) As Decimal

    'The variable Parameters are changed during the iteration
    'Iteration performs one approximation step
    Sub Iteration()

End Interface
