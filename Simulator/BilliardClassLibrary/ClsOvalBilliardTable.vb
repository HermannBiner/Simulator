'This class represents an elliptic BilliardTable
'and has a pointer on "its" BilliardBall

Public Class ClsOvalBilliardTable
    Inherits ClsBilliardTableAbstract

    Public Sub New()

        'Set specific parameters and ranges
        MyTValueParameter = New ClsGeneralParameter(1, "Parameter t", New ClsInterval(0, CDec(Math.PI * 2)),
                                                    ClsGeneralParameter.TypeOfParameterEnum.Variable, CDec(Math.PI / 2))
        MyAlfaValueParameter = New ClsGeneralParameter(2, "Angle Alfa", New ClsInterval(CDec(0.001), CDec(3.13)),
                                                       ClsGeneralParameter.TypeOfParameterEnum.Variable, CDec(Math.PI / 30))

        MyValueParameterList.Add(MyTValueParameter)
        MyValueParameterList.Add(MyAlfaValueParameter)

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
            Dim Midpoint As New ClsMathpoint((MyA - B) / 2, 0)

            'Focal Point of the Ellipse
            Dim Focalpoint As ClsMathpoint
            If MyA >= B Then
                Focalpoint = New ClsMathpoint(Midpoint.X - CDec(Math.Sqrt(MyA * MyA - B * B)), 0) ''linker Brennpunkt
            Else
                Focalpoint = New ClsMathpoint(Midpoint.X, CDec(Math.Sqrt(B * B - MyA * MyA)))
            End If

            'Draw these points
            .DrawPoint(Midpoint, Brushes.Blue, 2)
            .DrawPoint(Focalpoint, Brushes.Blue, 2)

            'Draw half-Circle
            .DrawCircleArc(Midpoint, B, CDec(3 * Math.PI / 2), CDec(Math.PI), Color.Blue, 1)

            'Draw half-Ellipse
            'Rectangle for the Ellipse bottom-left
            Dim BottomLeft As New ClsMathpoint(Midpoint.X - MyA, -B)

            'Rectangle for the Ellipse top-right
            Dim TopRight As New ClsMathpoint(Midpoint.X + MyA, B)

            .DrawEllipticArc(BottomLeft, TopRight, CDec(Math.PI / 2), CDec(Math.PI), Color.Blue, 1)
        End With
        MyPicDiagram.Refresh()
    End Sub

    Public Overrides Function GetBilliardBall() As IBilliardball

        Dim BilliardBall As New ClsOvalBilliardball

        With BilliardBall
            .MathInterval = MyMathInterval
            .AlfaValueRange = MyAlfaValueParameter.Range
            .TValueRange = MyTValueParameter.Range
            .ParameterRange = MyDSParameter.Range
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
            .B = B
            .IsStartangleSet = False
            .IsStartParameterSet = False
        End With

        Return BilliardBall
    End Function
End Class
