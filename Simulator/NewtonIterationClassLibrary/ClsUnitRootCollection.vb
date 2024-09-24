'Implements the Interface IPolynom
'and inherits ClsUnitRootAbstract
'for the unit-roots f(z)=z^n-1

'Status Checked

Public Class ClsUnitRootCollection
    Inherits ClsNewtonAbstract

    'SECTOR INITIALIZATION

    Public Sub New()

        MyIsUseN = True
        MyIsUseC = False

    End Sub

    Public Overrides ReadOnly Property IsShowBasin As Boolean
        Get
            IsShowBasin = True
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

        'This is the formula for the Newton Iteration
        'see math. doc.

        Select Case MyMixing
            Case INewton.EnMixing.Conjugate
                Z = Z.Conjugate
            Case INewton.EnMixing.Rotate
                Dim Phi As Double = 2 * Math.PI / MyN
                Z = Z.Mult(New ClsComplexNumber(Math.Cos(Phi), Math.Sin(Phi)))
            Case Else
                'nothing
        End Select

        Dim W As ClsComplexNumber = Z.Stretch((MyN - 1) / MyN).Add(Denominator(Z))

        Return W

    End Function

    Public Overrides Function Denominator(Z As ClsComplexNumber) As ClsComplexNumber

        Return Z.Power(MyN - 1).Invers.Stretch(1 / MyN)

    End Function

End Class
