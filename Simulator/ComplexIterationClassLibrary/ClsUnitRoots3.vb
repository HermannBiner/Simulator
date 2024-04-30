'Implements the Interface IPolynom
'and inherits ClsUnitRootAbstract
'for the unit-roots f(z)=z^3-1

'Status Checked

Public Class ClsUnitRoots3
    Inherits ClsUnitRootAbstract

    'Radius of the Basins that contains a root
    Const RootRadius As Double = 0.45

    Overrides WriteOnly Property Deepness As Integer
        Set(value As Integer)
            MyDeepness = value + 30
        End Set
    End Property

    'SECTOR INITIALIZATION

    Public Sub New()

        MyAllowedXRange = New ClsInterval(CDec(-1.5), CDec(1.5))
        MyAllowedYRange = New ClsInterval(CDec(-1.5), CDec(1.5))

        MyActualXRange = MyAllowedXRange
        MyActualYRange = MyAllowedYRange

        ReDim Root(3)

        Dim W = New ClsComplexNumber(1, 0)

        Root(1) = New ClsRoot(W, Brushes.Red)
        Root(2) = New ClsRoot(W.Rotate(CDec(2 * Math.PI / 3)), Brushes.Blue)
        Root(3) = New ClsRoot(W.Rotate(CDec(2 * 2 * Math.PI / 3)), Brushes.Green)

    End Sub

    'Draws roots of the polynom
    Protected Overrides Sub DrawRoots()

        'Roots
        Dim i As Integer
        For i = 1 To 3
            MyMapCPlaneGraphics.DrawPoint(New ClsMathpoint(CDec(Root(i).X), CDec(Root(i).Y)), Brushes.Black, 3)
        Next

    End Sub


    Protected Overrides Function GetBasin(Z As ClsComplexNumber) As Brush

        Dim Difference As Double
        Dim Temp As Double = 10
        Dim Color As Brush = Brushes.White
        Dim i As Integer

        For i = 1 To 3

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

        Dim W As ClsComplexNumber = Z.Power2.Invers.Stretch(1 / 3)
        W = Z.Stretch(2 / 3).Add(W)

        Return W

    End Function

End Class
