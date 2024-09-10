'This class represents an elliptic BilliardTable
'and has a pointer on "its" BilliardBall

Public Class ClsStadiumBilliardTable
    Inherits ClsBilliardTableAbstract


    Public Sub New()

        'Set specific parameters and ranges
        MyAlfaValueRange = New ClsInterval(0, CDec(Math.PI))

        'The ValueRange of MyT is only known, after a, b and C are set
        'here is set as default C = 1 (a = b)
        MyTValueRange = New ClsInterval(0, CDec(0.95 * (4 + 2 * Math.PI)))

        MyValueParameters = New List(Of ClsValueParameter)

        Dim ValueRange As ClsValueParameter

        ValueRange = New ClsValueParameter(1, "t-Parameter", MyTValueRange)
        MyValueParameters.Add(ValueRange)

        ValueRange = New ClsValueParameter(2, "Angle Alfa", MyAlfaValueRange)
        MyValueParameters.Add(ValueRange)

        'Default
        MyC = 2
        MyA = CDec(0.95) / (1 + MyC)
        MyB = MyC * MyA

    End Sub

    Public Overrides Property C As Decimal
        Get
            C = MyC
        End Get
        Set(value As Decimal)

            MyC = value

            'Because of better visibility we set a = 0.95 (instead of 1)
            MyA = CDec(0.95) / (1 + MyC)
            MyB = MyC * MyA

        End Set
    End Property

    Public Overrides Sub DrawBilliardtable()
        With MyBmpGraphics
            'Coordinate System
            .DrawCoordinateSystem(New ClsMathpoint(0, 0), Color.Black, 1)

            'Draw the rectangle in the middle of the stadium
            .DrawLine(New ClsMathpoint(-MyA, -b), New ClsMathpoint(MyA, -b), Color.Blue, 1)
            .DrawLine(New ClsMathpoint(-MyA, b), New ClsMathpoint(MyA, b), Color.Blue, 1)

            'Draw the half-circles including their midpoints
            .DrawCircleArc(New ClsMathpoint(-MyA, 0), b, CDec(Math.PI / 2), CDec(Math.PI), Color.Blue, 1)
            .DrawPoint(New ClsMathpoint(-MyA, 0), Brushes.Blue, 2)
            .DrawCircleArc(New ClsMathpoint(MyA, 0), b, CDec(3 * Math.PI / 2), CDec(Math.PI), Color.Blue, 1)
            .DrawPoint(New ClsMathpoint(MyA, 0), Brushes.Blue, 2)
        End With
        MyPicDiagram.Refresh()
    End Sub

    Public Overrides Function GetBilliardBall() As IBilliardball

        Dim BilliardBall As New ClsStadiumBilliardball

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
