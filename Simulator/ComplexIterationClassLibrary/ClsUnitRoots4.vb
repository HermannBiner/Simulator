'Implements the Interface IPolynom
'and inherits ClsUnitRootAbstract
'for the unit-roots f(z)=z^4-1

'Status Checked

Public Class ClsUnitRoots4
    Inherits ClsUnitRootAbstract


    'Radius of the Basins that contains a root
    Const RootRadius As Decimal = CDec(0.4)

    Overrides WriteOnly Property Deepness As Integer
        Set(value As Integer)
            MyDeepness = value + 50
        End Set
    End Property

    'SECTOR INITIALIZATION

    Public Sub New()

        MyAllowedXRange = New ClsInterval(CDec(-1.5), CDec(1.5))
        MyAllowedYRange = New ClsInterval(CDec(-1.5), CDec(1.5))

        MyActualXRange = MyAllowedXRange
        MyActualYRange = MyAllowedYRange

        ReDim Root(4)

        Dim W = New ClsComplexNumber(1, 0)

        Root(1) = New ClsRoot(W, Brushes.Red)
        Root(2) = New ClsRoot(W.Rotate(CDec(2 * Math.PI / 4)), Brushes.Blue)
        Root(3) = New ClsRoot(W.Rotate(CDec(2 * 2 * Math.PI / 4)), Brushes.Green)
        Root(4) = New ClsRoot(W.Rotate(CDec(3 * 2 * Math.PI / 4)), Brushes.Yellow)


    End Sub

    'Draws Coordinatesystem and roots of the polynom
    Protected Overrides Sub Drawroots()

        'Roots
        Dim i As Integer
        For i = 1 To 4
            MyMapCPlaneGraphics.DrawPoint(New ClsMathpoint(CDec(Root(i).X), CDec(Root(i).Y)), Brushes.Black, 3)
        Next

    End Sub

    Protected Overrides Function GetBasin(Z As ClsComplexNumber) As Brush

        Dim Difference As Double
        Dim Temp As Double = 10
        Dim Color As Brush = Brushes.White
        Dim i As Integer

        For i = 1 To 4

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


        Dim W As ClsComplexNumber = Z.Power3.Invers.Stretch(1 / 4)
        W = Z.Stretch(3 / 4).Add(W)

        Return W

    End Function

End Class
