'This class is the abstract Spring Pendulum
'and contains parameters, that are needed for all kind of spring pendulums
'the iteration-Method is MustOverride
'The real pendulums differ only in this Iteration-Method
'with maybe some more local parameters
'to apply the numeric method for the iteration

'Status Redesign Checked

Public MustInherit Class ClsSpringPendulumAbstract
    Implements ISpringPendulum

    'Step Width for the approximation
    Protected MyH As Decimal

    'Number of approximation steps before result is returned
    Protected MyNumberOfApproxSteps As Integer

    'Amplitude is the Y-Position of the Pendulum
    'at the Start Position
    Protected MyAmplitude As Decimal

    'Data transfer is here based on a vector
    'ActualParameter(0) is the "time"-Parameter t
    'and ActualParameter(1) is the Y-Position of the Pendulum
    Protected MyActualParameter As New ClsVector(2)

    Property h As Decimal Implements ISpringPendulum.h
        Get
            h = MyH
        End Get
        Set(value As Decimal)
            MyH = value
        End Set
    End Property

    WriteOnly Property NumberOfApproxSteps As Integer Implements ISpringPendulum.NumberOfApproxSteps
        Set(value As Integer)
            MyNumberOfApproxSteps = value
        End Set
    End Property

    WriteOnly Property Amplitude As Decimal Implements ISpringPendulum.Amplitude
        Set(value As Decimal)
            MyAmplitude = value
            MyActualParameter.Component(1) = value
        End Set
    End Property

    Property ActualParameter(index As Integer) As Decimal Implements ISpringPendulum.ActualParameter
        Get
            ActualParameter = MyActualParameter.Component(index)
        End Get
        Set(value As Decimal)
            MyActualParameter.Component(index) = value
        End Set
    End Property

    Protected MustOverride Sub Iteration() Implements ISpringPendulum.Iteration

End Class
