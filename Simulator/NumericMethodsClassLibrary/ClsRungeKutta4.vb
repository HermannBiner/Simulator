'This class is the Spring Pendulum
'together with the "Runge Kutta 4" numerical Method 
'based on the differential equation of a real spring pendulum

'Status Checked

Public Class ClsRungeKutta4
    Inherits ClsNumericMethodAbstract

    'These are the parameters according to the mathematical documentation
    'first the y-substitution component(1)
    Private u As Decimal

    'and the derivated y' substitution component(2)
    Private v As Decimal

    'The Runge Kutta Parameters for u
    Private ReadOnly k As New ClsNTupel(3)

    'the Runge Kutta Parameters for v
    Private ReadOnly l As New ClsNTupel(3)

    Protected Overrides Sub Iteration()

        Dim i As Integer

        With MyActualParameter
            For i = 1 To MyNumberOfApproxSteps
                .Component(0) += MyH

                'Component(1) holds the y-value
                u = .Component(1)
                v = .Component(2)

                'the numerical equation is described in the mathematical documentation
                k.Component(0) = MyH * v
                l.Component(0) = -MyH * u

                k.Component(1) = MyH * (v + l.Component(0) / 2)
                l.Component(1) = MyH * (-u - k.Component(0) / 2)

                k.Component(2) = MyH * (v + l.Component(1) / 2)
                l.Component(2) = MyH * (-u - k.Component(1) / 2)

                k.Component(3) = MyH * (v + l.Component(2))
                l.Component(3) = MyH * (-u - k.Component(2))

                .Component(1) = u + (k.Component(0) + 2 * k.Component(1) + 2 * k.Component(2) + k.Component(3)) / 6
                .Component(2) = v + (l.Component(0) + 2 * l.Component(1) + 2 * l.Component(2) + l.Component(3)) / 6

            Next

            'the Component(0) holds the "time" t with 2*pi period
            .Component(0) = .Component(0) Mod CDec(2 * Math.PI)

        End With

    End Sub

End Class
