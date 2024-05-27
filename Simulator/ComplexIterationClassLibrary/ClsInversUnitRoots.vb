'Implements the Interface IPolynom
'and inherits ClsUnitRootAbstract
'for the invers unit-roots g(w)=nw/(n-1+w^n) - see math. doc.

'Status Checked

Public Class ClsInversUnitRoots
    Inherits ClsPolynomAbstract

    Private MyRadius As Double

    'SECTOR INITIALIZATION

    Public Sub New()

        MyAllowedXRange = New ClsInterval(CDec(-1.5), CDec(1.5))
        MyAllowedYRange = New ClsInterval(CDec(-1.5), CDec(1.5))

        MyActualXRange = MyAllowedXRange
        MyActualYRange = MyAllowedYRange

        MyUseN = True
        MyUseC = False

    End Sub

    Overrides WriteOnly Property Deepness As Integer
        Set(value As Integer)
            MyDeepness = value * 30 * MyN
            MyRadius = 0.2 / value
        End Set
    End Property


    Protected Overrides Sub PrepareIteration()

        ReDim Root(MyN)

        Dim Colors As New ClsBasinColors

        Dim k As Integer

        'Generate Roots
        Dim W = New ClsComplexNumber(1, 0)
        Root(1) = New ClsRoot(W, Colors.GetColor(1))

        For k = 2 To MyN
            Root(k) = New ClsRoot(W.Rotate(CDec(2 * Math.PI * (k - 1) / MyN)), Colors.GetColor(k))
        Next

    End Sub

    'Draws roots of the polynom
    Protected Overrides Sub DrawRoots(Finished As Boolean)

        'Roots
        Dim i As Integer
        Dim Col As Brush

        For i = 1 To MyN
            If Finished Then
                Col = Brushes.Black
            Else
                Col = Root(i).Color
            End If
            MyMapCPlaneGraphics.DrawPoint(New ClsMathpoint(CDec(Root(i).X), CDec(Root(i).Y)), Col, 3)
        Next

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

    Protected Overrides Function GetBasin(Z As ClsComplexNumber) As Brush

        'If the stop condition is fullfilled, then the startpoint converges to a root
        'and we have to find out, which root that is

        Dim Difference As Double
        Dim Temp As Double = Z.Add(Root(1).Stretch(-1)).AbsoluteValue
        Dim Color As Brush = Root(1).Color
        Dim i As Integer

        For i = 2 To MyN
            Difference = Z.Add(Root(i).Stretch(-1)).AbsoluteValue
            If Difference < Temp Then
                Temp = Difference
                Color = Root(i).Color
            End If
        Next

        Return Color

    End Function

    Public Overrides Function Newton(Z As ClsComplexNumber) As ClsComplexNumber

        If MyConjugateZ Then
            Z = Z.Conjugate
        End If

        'This is the formula for the Newton Iteration
        'see math. doc.
        Dim W As ClsComplexNumber = Z.Stretch(MyN).Mult(Denominator(Z))

        Return W

    End Function

    Public Overrides Function Denominator(Z As ClsComplexNumber) As ClsComplexNumber

        Return Z.Power(MyN).Add(New ClsComplexNumber(MyN - 1, 0)).Invers

    End Function

End Class
