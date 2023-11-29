'This class contains mathematical Methods 
'that are used by all Billiard Tables or Billiard Balls

'Status Checked

Public Class ClsMathhelperBilliard

    Public Function CalculateAngleOfDirection(deltaX As Decimal, deltaY As Decimal) As Decimal

        'receives a vector (deltaX, deltaY)
        'return the angle between this vector and the positive x-axis in [0, 2*pi[

        Dim phi As Decimal

        If deltaX > 0 Then
            If deltaY >= 0 Then
                phi = CDec(Math.Atan(deltaY / deltaX))
            Else
                phi = CDec(2 * Math.PI + Math.Atan(deltaY / deltaX))
            End If
        ElseIf deltaX < 0 Then
            phi = CDec(Math.PI + Math.Atan(deltaY / deltaX))
        Else
            'here is DeltaX = 0
            If deltaY > 0 Then
                phi = CDec(Math.PI / 2)
            Else
                phi = CDec(Math.PI * 3 / 2)
            End If
        End If

        Return phi

    End Function

    Public Function AngleInNullTwoPi(angle As Decimal) As Decimal

        'makes sure that an angle is in the interval [0, 2*pi[

        Dim Tempangle As Decimal = angle

        Do Until Tempangle > 0
            Tempangle = CDec(Tempangle + Math.PI * 2)
        Loop

        Tempangle = CDec(Tempangle Mod (Math.PI * 2))

        Return Tempangle

    End Function

End Class
