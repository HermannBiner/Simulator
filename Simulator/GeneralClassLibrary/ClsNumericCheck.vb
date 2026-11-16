'Checks of Double values
'In the Decimal version, an overflow threw an OverflowException
'Double goes on with infinity or NaN, so the models check their state
'and throw the same exception (the controllers stop and show a message)

'Status Checked

Public Class ClsNumericCheck

    Public Shared Sub EnsureFinite(ParamArray Values() As Double)

        'Throws an OverflowException if one of the values is infinite or NaN
        For Each Value As Double In Values
            If Not Double.IsFinite(Value) Then
                Throw New OverflowException(ClsLanguageManager.LM.GetString("NumericOverflow"))
            End If
        Next

    End Sub

    Public Shared Function IsFiniteNumber(Text As String) As Boolean

        'IsNumeric, but without "NaN" and "Infinity" (Decimal could not hold them, Double can)
        Return IsNumeric(Text) AndAlso Double.IsFinite(CDbl(Text))

    End Function

    Public Shared Function ReduceAngle(Angle As Double) As Double

        'For the angle normalisations (loops adding or subtracting 2*pi):
        'throws for infinity or NaN (the loops would never end)
        'and reduces large angles first, where adding 2*pi no longer changes the Double
        EnsureFinite(Angle)

        Return If(Math.Abs(Angle) > 1000000.0, Math.IEEERemainder(Angle, 2 * Math.PI), Angle)

    End Function

End Class
