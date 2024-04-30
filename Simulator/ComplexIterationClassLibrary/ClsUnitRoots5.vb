'Implements the Interface IPolynom
'and inherits ClsUnitRootAbstract
'for the unit-roots f(z)=z^5-1

'Status Checked

Public Class ClsUnitRoots5
    Inherits ClsUnitRootAbstract

    'Radius of the Basins that contains a root
    Const RootRadius As Decimal = CDec(0.3)

    Overrides WriteOnly Property Deepness As Integer
        Set(value As Integer)
            MyDeepness = value + 100
        End Set
    End Property

    'SECTOR INITIALIZATION

    Public Sub New()

        MyAllowedXRange = New ClsInterval(CDec(-1.5), CDec(1.5))
        MyAllowedYRange = New ClsInterval(CDec(-1.5), CDec(1.5))

        MyActualXRange = MyAllowedXRange
        MyActualYRange = MyAllowedYRange

        ReDim Root(5)

        Dim W = New ClsComplexNumber(1, 0)

        Root(1) = New ClsRoot(W, Brushes.Red)
        Root(2) = New ClsRoot(W.Rotate(CDec(2 * Math.PI / 5)), Brushes.Blue)
        Root(3) = New ClsRoot(W.Rotate(CDec(2 * 2 * Math.PI / 5)), Brushes.Green)
        Root(4) = New ClsRoot(W.Rotate(CDec(3 * 2 * Math.PI / 5)), Brushes.Yellow)
        Root(5) = New ClsRoot(W.Rotate(CDec(4 * 2 * Math.PI / 5)), Brushes.Aqua)

    End Sub

    'Draws Coordinatesystem and roots of the polynom
    Protected Overrides Sub Drawroots()

        'Roots
        Dim i As Integer
        For i = 1 To 5
            MyMapCPlaneGraphics.DrawPoint(New ClsMathpoint(CDec(Root(i).X), CDec(Root(i).Y)), Brushes.Black, 3)
        Next

    End Sub

    Protected Overrides Function GetBasin(Z As ClsComplexNumber) As Brush

        Dim Difference As Double
        Dim Temp As Double = 10
        Dim Color As Brush = Brushes.White
        Dim i As Integer

        For i = 1 To 5

            Difference = Z.Add(Root(i).Stretch(-1)).AbsoluteValue
            If Difference < Temp Then
                Temp = Difference
                Color = Root(i).Color
            End If
        Next

        If Temp < RootRadius Then
            Return Color
        Else
            Return Brushes.White
        End If

    End Function

    Protected Overrides Function Newton(Z As ClsComplexNumber) As ClsComplexNumber


        Dim W As ClsComplexNumber = Z.Power4.Invers.Stretch(1 / 5)
        W = Z.Stretch(4 / 5).Add(W)

        Return W

    End Function
End Class
