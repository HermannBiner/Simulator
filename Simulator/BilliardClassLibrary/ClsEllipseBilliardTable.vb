'This class represents an elliptic BilliardTable
'and has a pointer on "its" BilliardBall

Public Class ClsEllipseBilliardTable
    Inherits ClsBilliardTableAbstract

    Public Sub New()

        'Default
        MyC = CDbl(0.8)
        MyA = CDbl(0.99)
        MyB = MyA * MyC

        'Set specific parameters and ranges
        MyTValueParameter = New ClsGeneralParameter(1, "Parameter t", New ClsInterval(0, CDbl(Math.PI * 2)),
                                                    ClsGeneralParameter.TypeOfParameterEnum.Variable, CDbl(Math.PI / 2))
        MyAlfaValueParameter = New ClsGeneralParameter(2, "Angle Alfa", New ClsInterval(CDbl(0.001), CDbl(3.13)),
                                                       ClsGeneralParameter.TypeOfParameterEnum.Variable, CDbl(0.001))

        MyValueParameterList.Add(MyTValueParameter)
        MyValueParameterList.Add(MyAlfaValueParameter)

    End Sub

    Public Overrides Function GetBilliardBall() As IBilliardball

        Dim BilliardBall As New ClsEllipseBilliardball

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
            .B = MyB
            .IsStartangleSet = False
            .IsStartParameterSet = False
        End With

        Return BilliardBall
    End Function

    Public Overrides Property C As Double
        Get
            C = MyC
        End Get
        Set(value As Double)
            MyC = value

            If MyC <= 1 Then

                'a > b, , for better visibility a = 0.99 instead of 1
                MyA = CDbl(0.99)
                MyB = MyC * MyA
            Else

                'b > a, for better visibility b = 0.99 instead of 1
                MyB = CDbl(0.99)
                MyA = MyB / MyC
            End If
        End Set
    End Property

    Public Overrides Sub DrawBilliardtable()
        With MyBmpGraphics
            'Coordinate System
            .DrawCoordinateSystem(New ClsMathpoint(0, 0), Color.Black, 1)

            'The MidPoint of the Ellipse is always (0/0)
            .DrawEllipse(New ClsMathpoint(0, 0), MyA, B, Color.Blue, 1)

            'Set Focal Points F1 and F2 of the Ellipse
            Dim F1 As New ClsMathpoint
            Dim F2 As New ClsMathpoint

            Dim f As Double
            If MyA > B Then
                f = CDbl(Math.Sqrt(MyA * MyA - B * B))
                F1.X = f
                F1.Y = 0
                F2.X = -f
                F2.Y = 0
            Else
                f = CDbl(Math.Sqrt(B * B - MyA * MyA))
                F1.X = 0
                F1.Y = f
                F2.X = 0
                F2.Y = -f
            End If

            'Draw Focal Points
            .DrawPoint(F1, Brushes.DarkBlue, 3)
            .DrawPoint(F2, Brushes.DarkBlue, 3)
        End With
        MyPicDiagram.Refresh()
    End Sub

End Class
