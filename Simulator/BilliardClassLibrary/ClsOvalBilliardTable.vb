'This class represents an elliptic BilliardTable
'and has a pointer on "its" BilliardBall

Public Class ClsOvalBilliardTable
    Inherits ClsBilliardTableAbstract

    Public Sub New()

        'Set specific parameters and ranges
        MyAlfaValueRange = New ClsInterval(0, CDec(Math.PI))
        MyTValueRange = New ClsInterval(0, CDec(Math.PI * 2))

        MyValueParameters = New List(Of ClsValueParameter)

        Dim ValueRange As ClsValueParameter

        ValueRange = New ClsValueParameter(1, "t-Parameter", MyTValueRange)
        MyValueParameters.Add(ValueRange)

        ValueRange = New ClsValueParameter(2, "Angle Alfa", MyAlfaValueRange)
        MyValueParameters.Add(ValueRange)

        'Default
        MyC = CDec(0.5)
        MyA = CDec(1.9 * Math.Min(1 / (1 + MyC), 1 / (2 * MyC)))
        MyB = MyC * MyA

    End Sub

    Public Overrides Property C As Decimal
        Get
            C = MyC
        End Get
        Set(value As Decimal)
            MyC = value

            'for better visibility, a + b is set = 1.9 (instead of 2)
            MyA = CDec(1.9 * Math.Min(1 / (1 + MyC), 1 / (2 * MyC)))
            MyB = MyC * MyA
        End Set
    End Property

    Public Overrides Sub DrawBilliardtable()
        With MyBmpGraphics
            'Coordinate System
            .DrawCoordinateSystem(New ClsMathpoint(0, 0), Color.Black, 1)

            'Special Points
            'MidPoint of the Circle and the Ellipse
            Dim Midpoint As New ClsMathpoint((MyA - b) / 2, 0)

            'Focal Point of the Ellipse
            Dim Focalpoint As ClsMathpoint
            If MyA >= b Then
                Focalpoint = New ClsMathpoint(Midpoint.X - CDec(Math.Sqrt(MyA * MyA - b * b)), 0) ''linker Brennpunkt
            Else
                Focalpoint = New ClsMathpoint(Midpoint.X, CDec(Math.Sqrt(b * b - MyA * MyA)))
            End If

            'Draw these points
            .DrawPoint(Midpoint, Brushes.Blue, 2)
            .DrawPoint(Focalpoint, Brushes.Blue, 2)

            'Draw half-Circle
            .DrawCircleArc(Midpoint, b, CDec(3 * Math.PI / 2), CDec(Math.PI), Color.Blue, 1)

            'Draw half-Ellipse
            'Rectangle for the Ellipse bottom-left
            Dim BottomLeft As New ClsMathpoint(Midpoint.X - MyA, -b)

            'Rectangle for the Ellipse top-right
            Dim TopRight As New ClsMathpoint(Midpoint.X + MyA, b)

            .DrawEllipticArc(BottomLeft, TopRight, CDec(Math.PI / 2), CDec(Math.PI), Color.Blue, 1)
        End With
        MyPicDiagram.Refresh()
    End Sub

    Public Overrides Function GetBilliardBall() As IBilliardball

        Dim BilliardBall As New ClsOvalBilliardball

        With BilliardBall
            .MathValueRange = MyMathValueRange
            .AlfaValueRange = MyAlfaValueRange
            .TValueRange = MyTValueRange
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            'PhasePortrait and ValueProtocol is not allways needed
            If MyPhasePortrait IsNot Nothing Then
                .PhasePortrait = MyPhasePortrait
            End If
            If MyValueProtocol IsNot Nothing Then
                .ValueProtocol = MyValueProtocol
            End If
            .A = MyA
            .B = b
            .IsStartangleSet = False
            .IsStartpositionSet = False
        End With

        Return BilliardBall
    End Function
End Class
