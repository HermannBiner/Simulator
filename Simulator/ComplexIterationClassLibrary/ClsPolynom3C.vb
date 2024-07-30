'Implements the Interface IPolynom
'and inherits ClsPolynomAbstract
'for the roots of the Polynom
'p(z)=(z+1)(z-1)(z-c); c is a free parameter

'Status Checked

Public Class ClsPolynom3C
    Inherits ClsPolynomAbstract

    'SECTOR INITIALIZATION

    Public Sub New()

        MyAllowedXRange = New ClsInterval(CDec(-1.5), CDec(1.5))
        MyAllowedYRange = New ClsInterval(CDec(-1.5), CDec(1.5))

        MyActualXRange = MyAllowedXRange
        MyActualYRange = MyAllowedYRange

        MyUseN = False
        MyUseC = True

    End Sub

    Protected Overrides Sub PrepareIteration()

        'Generate Roots
        Roots.Clear()

        Roots.Add(New ClsRoot(New ClsComplexNumber(-1, 0), 1))
        Roots.Add(New ClsRoot(New ClsComplexNumber(1, 0), 2))
        Roots.Add(New ClsRoot(New ClsComplexNumber(MyC.X, MyC.Y), 3))


        MyN = 3
        MyIterationDeepness = 100

    End Sub

    Public Overrides Function StopCondition(Z As ClsComplexNumber) As Boolean

        'left side of the stop condition
        Dim Stopped As Boolean = False

        'in all cases, we need the denominator
        Dim V As Double = Denominator(Z).Power2.AbsoluteValue

        'is z near 1 or -1 or c?
        If Z.Add(New ClsComplexNumber(1, 0)).AbsoluteValue < MyRadius Then
            Stopped = True
        ElseIf Z.Add(New ClsComplexNumber(-1, 0)).AbsoluteValue < MyRadius Then
            Stopped = True
        ElseIf Z.Add(New ClsComplexNumber(-MyC.X, -MyC.Y)).AbsoluteValue < MyRadius Then
            Stopped = True
        End If

        Return Stopped Or (V = 0)

    End Function

    Public Overrides Function Denominator(Z As ClsComplexNumber) As ClsComplexNumber

        Dim V As ClsComplexNumber

        Select Case MyC.Y
            Case 0
                Select Case MyC.X
                    Case 1
                        V = Z.Stretch(3).Add(New ClsComplexNumber(1, 0))
                    Case -1
                        V = Z.Stretch(3).Add(New ClsComplexNumber(-1, 0))
                    Case Else
                        V = Nothing
                End Select
            Case Else
                V = Nothing
        End Select

        If V Is Nothing Then
            V = Z.Power2.Stretch(3)
            V = V.Add(Z.Mult(MyC.Stretch(-2)))
            V = V.Add(New ClsComplexNumber(-1, 0))
        End If

        Return V

    End Function

    Public Overrides Function Newton(Z As ClsComplexNumber) As ClsComplexNumber


        Select Case MyMixing
            Case IPolynom.EnMixing.Conjugate
                Z = Z.Conjugate
            Case IPolynom.EnMixing.Rotate
                Dim Phi As Double = 2 * Math.PI / 3
                Z = Z.Mult(New ClsComplexNumber(Math.Cos(Phi), Math.Sin(Phi)))
            Case Else
                'nothing
        End Select

        'Nominator of the iterated function g(z)
        Dim W As ClsComplexNumber

        Select Case MyC.Y
            Case 0
                Select Case MyC.X
                    Case 1
                        W = Z.Power2.Stretch(2).Add(Z).Add(New ClsComplexNumber(1, 0))
                    Case -1
                        W = Z.Power2.Stretch(2).Add(Z.Stretch(-1)).Add(New ClsComplexNumber(1, 0))
                    Case Else
                        W = Nothing
                End Select
            Case Else
                W = Nothing
        End Select

        If W Is Nothing Then
            W = Z.Power(3).Stretch(2)
            W = W.Add(Z.Power2.Mult(MyC.Stretch(-1)))
            W = W.Add(MyC.Stretch(-1))
        End If

        'It is already checked, that Denominator(Z).AbsoluteValue > 0

        Return W.Div(Denominator(Z))

    End Function
End Class
