'This class contains some mathematical calculations that are used by different pendulums
Public Class ClsMathHelperPendulum

    Public Function GetAngle(X As Decimal, Y As Decimal) As Decimal

        'Calculation of the Angle between the negative Y-axis and the Pendulum-Axis
        Dim Phi As Decimal

        Select Case True
            Case X >= 0 And Y < 0
                Phi = CDec(Math.Atan(Math.Abs(X / Y)))
            Case X <= 0 And Y > 0
                Phi = CDec(Math.Atan(Math.Abs(X / Y)) - Math.PI)
            Case X > 0 And Y >= 0
                Phi = CDec(Math.Atan(Math.Abs(Y / X)) + Math.PI / 2)
            Case Else
                Phi = CDec(Math.Atan(Math.Abs(Y / X)) - Math.PI / 2)
        End Select

        Return Phi

    End Function


    Public Function AngleInMinusPiAndPi(angle As Decimal) As Decimal

        'makes sure that an angle is in the interval [0, 2*pi[

        Dim Tempangle As Decimal = angle

        'Make sure that angle is >= -Pi
        Do Until Tempangle > -CDec(Math.PI)
            Tempangle = CDec(Tempangle + Math.PI * 2)
        Loop

        'If Angle was > pi from the beginning
        Tempangle = CDec(Tempangle Mod (Math.PI))

        Return Tempangle

    End Function

End Class
