'Implements the Interface IPolynom
'and inherits ClsPolynomAbstract
'for the roots of the Polynom
'p(z)=(z+1)(z-1)(z-c); c is a free parameter

'Status Checked

Public Class ClsPolynom3C
    Inherits ClsPolynomAbstract

    Private MyRadius As Double

    'SECTOR INITIALIZATION

    Public Sub New()

        MyAllowedXRange = New ClsInterval(CDec(-1.5), CDec(1.5))
        MyAllowedYRange = New ClsInterval(CDec(-1.5), CDec(1.5))

        MyActualXRange = MyAllowedXRange
        MyActualYRange = MyAllowedYRange

        MyUseN = False
        MyUseC = True

        MyN = 3

    End Sub

    Public Overrides WriteOnly Property Deepness As Integer
        Set(value As Integer)
            MyDeepness = value * 20
            MyRadius = 0.2 / value
        End Set
    End Property

    Protected Overrides Sub PrepareIteration()

        ReDim Root(MyN)

        'Generate Roots
        Root(1) = New ClsRoot(New ClsComplexNumber(-1, 0), Brushes.Red)
        Root(2) = New ClsRoot(New ClsComplexNumber(1, 0), Brushes.Blue)
        Root(3) = New ClsRoot(New ClsComplexNumber(MyC.X, MyC.Y), Brushes.Green)

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

        'left side of the stop condition
        Dim W As ClsComplexNumber
        Dim Stopped As Boolean = False

        'in all cases, we need the denominator
        Dim V As Double = Denominator(Z).Power2.AbsoluteValue

        'is z near 1 or -1 or c?
        If Z.Add(New ClsComplexNumber(1, 0)).AbsoluteValue < MyRadius Then
            Stopped = True
        ElseIf Z.Add(New ClsComplexNumber(-1, 0)).AbsoluteValue < MyRadius Then
            Stopped = True
        ElseIf Z.Add(New ClsComplexNumber(-MyC.x, -MyC.y)).AbsoluteValue < MyRadius Then
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

    Protected Overrides Function GetBasin(Z As ClsComplexNumber) As Brush

        'If the stop condition is fullfilled, then the startpoint onverges to a root
        'and we have to find out, which root that is

        Dim Difference As Double
        Dim Temp As Double = Z.Add(Root(1).Stretch(-1)).AbsoluteValue
        Dim Color As Brush = Root(1).Color
        Dim i As Integer

        For i = 2 To 3
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
