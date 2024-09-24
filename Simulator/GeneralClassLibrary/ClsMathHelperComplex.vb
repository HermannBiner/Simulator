'This Class contains mathematical calculations
'supporting complex numbers
'that allows easy implementations of complex number formulas

'Status Checked

Public Class ClsMathHelperComplex

    'Gets the Angle of a Point in R2 with the x-Axis
    'The result is in [0,2*pi[
    'It is used to get the Argument of a Complex Number
    'The Argument of (0/0) is 0
    Function GetArgument(X As Double, Y As Double) As Double

        Dim Arg As Double

        If X = 0 Then
            Select Case Y
                Case > 0
                    Arg = Math.PI / 2
                Case 0
                    Arg = 0
                Case Else
                    Arg = 3 * Math.PI / 2
            End Select
        Else
            Dim Phi As Double = Math.Atan(Y / X)
            'phi is in [-pi,pi]
            'arg should be in [0,2*pi[

            Select Case True
                Case X < 0
                    Arg = Phi + Math.PI
                Case Y < 0 And X > 0
                    Arg = Phi + 2 * Math.PI
                Case Else 'x > 0, y > 0
                    Arg = Phi
            End Select
        End If

        Return Arg

    End Function

End Class
