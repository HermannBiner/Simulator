'This class contains mathematical Methods 
'that are used by all Billiard Tables or Billiard Balls

'Status Checked

Public Class ClsMathhelperBilliard

    Public Function CalculateAngleOfDirection(DeltaX As Decimal, DeltaY As Decimal) As Decimal

        'receives a vector (deltaX, deltaY)
        'return the angle between this vector and the positive x-axis in [0, 2*pi[

        Dim Phi As Decimal

        If DeltaX > 0 Then
            If DeltaY >= 0 Then
                Phi = CDec(Math.Atan(DeltaY / DeltaX))
            Else
                Phi = CDec(2 * Math.PI + Math.Atan(DeltaY / DeltaX))
            End If
        ElseIf DeltaX < 0 Then
            Phi = CDec(Math.PI + Math.Atan(DeltaY / DeltaX))
        Else
            'here is DeltaX = 0
            If DeltaY > 0 Then
                Phi = CDec(Math.PI / 2)
            Else
                Phi = CDec(Math.PI * 3 / 2)
            End If
        End If

        Return Phi

    End Function

    Public Function AngleInNullTwoPi(Angle As Decimal) As Decimal

        'makes sure that an angle is in the interval [0, 2*pi[

        Dim Tempangle As Decimal = Angle

        Do Until Tempangle > 0
            Tempangle = CDec(Tempangle + Math.PI * 2)
        Loop

        Tempangle = CDec(Tempangle Mod (Math.PI * 2))

        Return Tempangle

    End Function

End Class
