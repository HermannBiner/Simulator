'Implements the Interface IPolynom
'and inherits ClsUnitRootAbstract
'for the invers unit-roots g(w)=nw/(n-1+w^n) - see math. doc.

'Status Checked

Public Class ClsInversUnitRoots
    Inherits ClsPolynomAbstract

    'SECTOR INITIALIZATION

    Public Sub New()

        MyAllowedXRange = New ClsInterval(CDec(-1.5), CDec(1.5))
        MyAllowedYRange = New ClsInterval(CDec(-1.5), CDec(1.5))

        MyActualXRange = MyAllowedXRange
        MyActualYRange = MyAllowedYRange

        MyUseN = True
        MyUseC = False

    End Sub

    Protected Overrides Sub PrepareIteration()

        Dim k As Integer

        'Generate Roots
        Roots.Clear()

        Dim W = New ClsComplexNumber(1, 0)
        Roots.Add(New ClsRoot(W, 1))

        For k = 2 To MyN
            Roots.Add(New ClsRoot(W.Rotate(CDec(2 * Math.PI * (k - 1) / MyN)), k))
        Next

        MyIterationDeepness = 60 * MyN

    End Sub


    Public Overrides Function StopCondition(Z As ClsComplexNumber) As Boolean

        'The stop condition is
        'Abs(1-z^n) small
        'if this condition is fullfilled then the startpoint converges to a root

        Dim Stopped As Boolean
        Dim W = Z.Power(MyN)

        'Is z near a unit root?
        Stopped = (W.Add(New ClsComplexNumber(-1, 0)).AbsoluteValue < MyRadius)
        Return Stopped

    End Function

    Public Overrides Function Newton(Z As ClsComplexNumber) As ClsComplexNumber

        Select Case MyMixing
            Case IPolynom.EnMixing.Conjugate
                Z = Z.Conjugate
            Case IPolynom.EnMixing.Rotate
                Dim Phi As Double = 2 * Math.PI / MyN
                Z = Z.Mult(New ClsComplexNumber(Math.Cos(Phi), Math.Sin(Phi)))
            Case Else
                'nothing
        End Select

        'This is the formula for the Newton Iteration
        'see math. doc.
        Dim W As ClsComplexNumber = Z.Stretch(MyN).Mult(Denominator(Z))

        Return W

    End Function

    Public Overrides Function Denominator(Z As ClsComplexNumber) As ClsComplexNumber

        Return Z.Power(MyN).Add(New ClsComplexNumber(MyN - 1, 0)).Invers

    End Function

End Class
