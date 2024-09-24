'This class contains some mathematical calculations that are used by different pendulums

'Status Checked

Public Class ClsMathHelperPendulum

    Public Function GetAngle(X As Decimal, Y As Decimal) As Decimal

        'Calculation of the Angle between the negative Y-axis and the Pendulum-Axis
        Dim Phi As Decimal

        If Y = 0 Then
            If X > 0 Then
                Phi = CDec(Math.PI / 2)
            Else
                Phi = -CDec(Math.PI / 2)
            End If
        Else
            Dim alfa As Decimal = -CDec(Math.Atan(X / Y))

            Select Case True
                Case Y < 0
                    Phi = alfa
                Case X < 0 And Y > 0
                    Phi = alfa - CDec(Math.PI)
                Case Else 'x > 0, y > 0
                    Phi = alfa + CDec(Math.PI)
            End Select

        End If

        Return Phi

    End Function


    Public Function AngleInMinusPiAndPi(Angle As Decimal) As Decimal

        'makes sure that an angle is in the interval [-pi, pi[

        Dim Tempangle As Decimal = Angle

        'Make sure that angle is > -Pi
        Do Until Tempangle > -CDec(Math.PI)
            Tempangle = CDec(Tempangle + Math.PI * 2)
        Loop

        'Make sure that angle is <= pi
        Do Until Tempangle <= CDec(Math.PI)
            Tempangle = CDec(Tempangle - Math.PI * 2)
        Loop

        Return Tempangle

    End Function

End Class
