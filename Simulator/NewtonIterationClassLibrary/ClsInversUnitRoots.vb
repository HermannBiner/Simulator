'Implements the Interface IPolynom
'and inherits ClsUnitRootAbstract
'for the invers unit-roots g(w)=nw/(n-1+w^n) - see math. doc.

'Status Checked

Public Class ClsInversUnitRoots
    Inherits ClsNewtonAbstract

    'SECTOR INITIALIZATION

    Public Sub New()

        MyIsUseN = True
        MyIsUseC = False

    End Sub

    Public Overrides ReadOnly Property IsShowBasin As Boolean
        Get
            IsShowBasin = False
        End Get
    End Property

    Protected Overrides Sub PrepareUnitRoots()

        Dim k As Integer

        'Generate Roots
        UnitRootCollection.Clear()

        Dim W = New ClsComplexNumber(1, 0)
        UnitRootCollection.Add(New ClsUnitRoot(W, 1))

        For k = 2 To MyN
            UnitRootCollection.Add(New ClsUnitRoot(W.Rotate(CDec(2 * Math.PI * (k - 1) / MyN)), k))
        Next

        IterationDeepness = 60 * MyN

    End Sub


    Public Overrides Function StopCondition(Z As ClsComplexNumber) As Boolean

        'The stop condition is
        'Abs(1-z^n) small
        'if this condition is fullfilled then the startpoint converges to a root

        Dim IsConvergent As Boolean
        Dim W = Z.Power(MyN)

        'Is z near a unit root?
        IsConvergent = (W.Add(New ClsComplexNumber(-1, 0)).AbsoluteValue < MyRadius)
        Return IsConvergent

    End Function

    Public Overrides Function Newton(Z As ClsComplexNumber) As ClsComplexNumber

        Select Case MyMixing
            Case INewton.EnMixing.Conjugate
                Z = Z.Conjugate
            Case INewton.EnMixing.Rotate
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
