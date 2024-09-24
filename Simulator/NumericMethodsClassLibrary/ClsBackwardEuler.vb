'This class is the Spring Pendulum
'together with the "Backward Euler" numerical Method 
'in German "Euler Implizit" method
'based on the differential equation of a real spring pendulum

'Status Checked

Public Class ClsBackwardEuler
    Inherits ClsNumericMethodAbstract

    'These are the parameters according to the mathematical documentation
    'first the y-substitution component(1)
    Private u As Decimal

    'and the derivated y' substitution component(2)
    Private v As Decimal

    Protected Overrides Sub Iteration()

        Dim i As Integer
        Dim locH As Decimal = 1 + MyH * MyH

        With MyActualParameter
            For i = 1 To MyNumberOfApproxSteps
                .Component(0) += MyH

                'the numerical equation is described in the mathematical documentation

                'Component(1) holds the y-value
                u = .Component(1)
                v = .Component(2)

                'this is the numerical approximation
                'for Euler Implicit
                .Component(1) = (u + v * MyH) / locH
                .Component(2) = (v - u * MyH) / locH
            Next

            'the Component(0) holds the "time" t with 2*pi period
            .Component(0) = .Component(0) Mod CDec(2 * Math.PI)

        End With

    End Sub


End Class
