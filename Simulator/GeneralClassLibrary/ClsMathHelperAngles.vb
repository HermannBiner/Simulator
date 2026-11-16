'This class contains mathematical Methods 
'that are used by all Billiard Tables or Billiard Balls

'Status Checked

Public Class ClsMathHelperAngles

    Public Function CalculateAngleOfDirection(DeltaX As Double, DeltaY As Double) As Double

        'receives a vector (deltaX, deltaY)
        'return the angle between this vector and the positive x-axis in [0, 2*pi[

        Dim Phi As Double

        If DeltaX > 0 Then
            If DeltaY >= 0 Then
                Phi = CDbl(Math.Atan(DeltaY / DeltaX))
            Else
                Phi = CDbl(2 * Math.PI + Math.Atan(DeltaY / DeltaX))
            End If
        ElseIf DeltaX < 0 Then
            Phi = CDbl(Math.PI + Math.Atan(DeltaY / DeltaX))
        Else
            'here is DeltaX = 0
            If DeltaY > 0 Then
                Phi = CDbl(Math.PI / 2)
            Else
                Phi = CDbl(Math.PI * 3 / 2)
            End If
        End If

        Return Phi

    End Function

    Public Function AngleInNullTwoPi(Angle As Double) As Double

        'makes sure that an angle is in the interval [0, 2*pi[

        Dim Tempangle As Double = ClsNumericCheck.ReduceAngle(Angle)

        Do Until Tempangle > 0
            Tempangle = CDbl(Tempangle + Math.PI * 2)
        Loop

        Tempangle = CDbl(Tempangle Mod (Math.PI * 2))

        Return Tempangle

    End Function

End Class
