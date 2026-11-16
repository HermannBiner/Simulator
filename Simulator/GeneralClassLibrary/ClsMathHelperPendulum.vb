'This class contains some mathematical calculations that are used by different pendulums

'Status Checked

Public Class ClsMathHelperPendulum

    Public Shared Function GetAngle(X As Double, Y As Double) As Double

        'Calculation of the Angle between the negative Y-axis and the Pendulum-Axis
        Dim Phi As Double

        If Y = 0 Then
            If X > 0 Then
                Phi = CDbl(Math.PI / 2)
            Else
                Phi = -CDbl(Math.PI / 2)
            End If
        Else
            Dim alfa As Double = -CDbl(Math.Atan(X / Y))

            Select Case True
                Case Y < 0
                    Phi = alfa
                Case X < 0 And Y > 0
                    Phi = alfa - CDbl(Math.PI)
                Case Else 'x > 0, y > 0
                    Phi = alfa + CDbl(Math.PI)
            End Select

        End If

        Return Phi

    End Function


    Public Shared Function AngleInMinusPiAndPi(Angle As Double) As Double

        'makes sure that an angle is in the interval [-pi, pi[

        Dim Tempangle As Double = ClsNumericCheck.ReduceAngle(Angle)

        'Make sure that angle is > -Pi
        Do Until Tempangle > -CDbl(Math.PI)
            Tempangle = CDbl(Tempangle + Math.PI * 2)
        Loop

        'Make sure that angle is <= pi
        Do Until Tempangle <= CDbl(Math.PI)
            Tempangle = CDbl(Tempangle - Math.PI * 2)
        Loop

        Return Tempangle

    End Function

End Class
