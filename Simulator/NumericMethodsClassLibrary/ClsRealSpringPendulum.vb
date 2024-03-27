'This class is the "real" Spring Pendulum
'that oscillates like cos(t)

'Status Checked

Public Class ClsRealSpringPendulum
    Inherits ClsSpringPendulumAbstract

    Protected Overrides Sub Iteration()

        Dim i As Integer

        For i = 1 To MyNumberOfApproxSteps
            MyActualParameter.Component(0) += MyH
        Next

        'MyStartParameter.Component(1) is the y-Startparameter and also the amplitude
        MyActualParameter.Component(0) = MyActualParameter.Component(0) Mod CDec(2 * Math.PI)
        MyActualParameter.Component(1) = MyStartParameter.Component(1) * CDec(Math.Cos(MyActualParameter.Component(0)))

    End Sub

End Class
