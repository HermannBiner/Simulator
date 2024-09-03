'This class is the abstract Spring Pendulum
'and contains parameters, that are needed for all kind of spring pendulums
'the iteration-Method is MustOverride
'The real pendulums differ only in this Iteration-Method
'with maybe some more local parameters
'to apply the numeric method for the iteration

'Status Checked

Public MustInherit Class ClsSpringPendulumAbstract
    Implements ISpringPendulum

    'Step Width for the approximation
    Protected MyH As Decimal

    'Number of approximation steps before result is returned
    Protected MyNumberOfApproxSteps As Integer

    'Data transfer is here based on a vector
    'StartParameter(0) is the "time"-Parameter t
    'and StartParameter(1) is the Y-Position of the Pendulum
    'at the Start Position
    Protected MyStartParameter As New ClsVector(2)

    'Data transfer is here based on a vector
    'ActualParameter(0) is the "time"-Parameter t
    'and ActualParameter(1) is the Y-Position of the Pendulum
    Protected MyActualParameter As New ClsVector(2)

    Protected Sub New()

        'Standard Values
        MyStartParameter.Component(0) = 0
        MyStartParameter.Component(1) = 0
        MyStartParameter.Component(2) = 0

        'Standard Values
        MyActualParameter.Component(0) = MyStartParameter.Component(0)
        MyActualParameter.Component(1) = MyStartParameter.Component(1)
        MyActualParameter.Component(2) = MyStartParameter.Component(2)

    End Sub

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

    WriteOnly Property StartParameter(index As Integer) As Decimal Implements ISpringPendulum.StartParameter
        Set(value As Decimal)
            MyStartParameter.Component(index) = value
            MyActualParameter.Component(index) = value
        End Set
    End Property

    ReadOnly Property ActualParameter(index As Integer) As Decimal Implements ISpringPendulum.ActualParameter
        Get
            ActualParameter = MyActualParameter.Component(index)
        End Get
    End Property

    Protected MustOverride Sub Iteration() Implements ISpringPendulum.Iteration

End Class
