'Implements the Interface IPolynom
'and inherits ClsUnitRootAbstract
'for the unit-roots f(z)=z^n-1

'Status Checked

Public Class ClsUnitRoots
    Inherits ClsPolynomAbstract

    Overrides WriteOnly Property Deepness As Integer
        Set(value As Integer)
            MyDeepness = value * 30 * MyN
        End Set
    End Property

    'SECTOR INITIALIZATION

    Public Sub New()

        MyAllowedXRange = New ClsInterval(CDec(-1.5), CDec(1.5))
        MyAllowedYRange = New ClsInterval(CDec(-1.5), CDec(1.5))

        MyActualXRange = MyAllowedXRange
        MyActualYRange = MyAllowedYRange


    End Sub

    Protected Overrides Sub PrepareIteration()

        ReDim Root(MyN)

        Dim k As Integer

        'Prepare Brushlist
        Dim BrushList(12) As Brush
        BrushList(1) = Brushes.Red
        BrushList(2) = Brushes.Blue
        BrushList(3) = Brushes.Green
        BrushList(4) = Brushes.Yellow
        BrushList(5) = Brushes.Salmon
        BrushList(6) = Brushes.SkyBlue
        BrushList(7) = Brushes.Gold
        BrushList(8) = Brushes.Lime
        BrushList(9) = Brushes.DarkOrange
        BrushList(10) = Brushes.Aqua
        BrushList(11) = Brushes.Magenta
        BrushList(12) = Brushes.SpringGreen

        'Generate Roots
        Dim W = New ClsComplexNumber(1, 0)
        Root(1) = New ClsRoot(W, BrushList(1))

        For k = 2 To MyN
            Root(k) = New ClsRoot(W.Rotate(CDec(2 * Math.PI * (k - 1) / MyN)), BrushList(k))
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

    Protected Overrides Function StopCondition(Z As ClsComplexNumber) As Boolean

        'The stop condition is
        'Abs(1-z^n) < abs(z^n)  -- see math. doc.
        'if this condition is fullfilled then the startpoint converges to a root

        Dim W = Z.Power(MyN)

        Return (W.Add(New ClsComplexNumber(-1, 0)).AbsoluteValue < W.AbsoluteValue)

    End Function

    Protected Overrides Function GetBasin(Z As ClsComplexNumber) As Brush


        'If sht stop condition is fullfilled, then the startpoint onverges to a root
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

    Protected Overrides Function Newton(Z As ClsComplexNumber) As ClsComplexNumber

        'This is the formula for the Newton Iteration
        'see math. doc.
        Dim W As ClsComplexNumber = Z.Power(MyN - 1).Invers.Stretch(1 / MyN)
        W = Z.Stretch((MyN - 1) / MyN).Add(W)

        Return W

    End Function

End Class
