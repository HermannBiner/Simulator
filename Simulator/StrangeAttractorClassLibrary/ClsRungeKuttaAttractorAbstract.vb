'This class is the base class for all Strange Attractor classes
'that uses the Runge Kutta methods

'Status Tested

Public MustInherit Class ClsRungeKuttaAttractorAbstract
    Inherits ClsStrangeAttractorAbstract

    'Runge Kutta Parameter
    'Runge Kutta Parameters
    Protected u As Decimal
    Protected v As Decimal
    Protected w As Decimal

    'And additional Parameters for Runge Kutta
    Protected ReadOnly z As ClsNTupel
    Protected ReadOnly k As ClsNTupel
    Protected ReadOnly l As ClsNTupel
    Protected ReadOnly m As ClsNTupel

    Public Sub New()
        z = New ClsNTupel(2)
        k = New ClsNTupel(3)
        l = New ClsNTupel(3)
        m = New ClsNTupel(3)
    End Sub

    Public Overrides Sub IterationStep()

        'Startpoint
        With MyActualMathPoint
            u = .X
            v = .Y
            w = .Z
        End With

        With z
            .Component(0) = u
            .Component(1) = v
            .Component(2) = w
        End With

        'First RK Step
        k.Component(0) = F(z)
        l.Component(0) = G(z)
        m.Component(0) = H(z)

        With z
            .Component(0) = u + MyStepWidth * k.Component(0) / 2
            .Component(1) = v + MyStepWidth * l.Component(0) / 2
            .Component(2) = w + MyStepWidth * m.Component(0) / 2
        End With

        'Second RK Step
        k.Component(1) = F(z)
        l.Component(1) = G(z)
        m.Component(1) = H(z)

        With z
            .Component(0) = u + MyStepWidth * k.Component(1) / 2
            .Component(1) = v + MyStepWidth * l.Component(1) / 2
            .Component(2) = w + MyStepWidth * m.Component(1) / 2
        End With

        'Third RK Step
        k.Component(2) = F(z)
        l.Component(2) = G(z)
        m.Component(2) = H(z)

        With z
            .Component(0) = u + MyStepWidth * k.Component(2)
            .Component(1) = v + MyStepWidth * l.Component(2)
            .Component(2) = w + MyStepWidth * m.Component(2)
        End With

        'Fourth RK Step
        k.Component(3) = F(z)
        l.Component(3) = G(z)
        m.Component(3) = H(z)

        'Final Step
        u += MyStepWidth * (k.Component(0) + 2 * k.Component(1) + 2 * k.Component(2) + k.Component(3)) / 6
        v += MyStepWidth * (l.Component(0) + 2 * l.Component(1) + 2 * l.Component(2) + l.Component(3)) / 6
        w += MyStepWidth * (m.Component(0) + 2 * m.Component(1) + 2 * m.Component(2) + m.Component(3)) / 6

        With MyActualMathPoint
            .X = u
            .Y = v
            .Z = w
        End With

    End Sub

    Public Overrides Sub SetIterationParameters()
        'not used for Runge Kutta Attractors
    End Sub

    Public MustOverride Function F(z As ClsNTupel) As Decimal
    Public MustOverride Function G(z As ClsNTupel) As Decimal
    Public MustOverride Function H(z As ClsNTupel) As Decimal

End Class
