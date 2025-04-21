'this is a concrete star moving in a Newton Universe

'Status Checked


Public Class ClsNewtonStar
    Inherits ClsStarAbstract

    'in our planet system, the given data about planets
    'is not the actual position, but the perihel and its argument
    Private MyPerihel As Decimal
    Private MyArgumentPerihel As Decimal

    'Velocity at the perihel
    Private MyPerihelVelocity As Decimal

    'To sum the Gravity of each other star
    'acting on the calculated star
    Private LocSum As Double

    Protected Overridable ReadOnly Property GravConst As Decimal
        'see the math. doc. for the gravity constant
        'depending on the chosen units:
        'astronomic unit instead of km
        'years instead of seconds
        'earth mass instead of kg
        Get
            Return CDec(0.00000000088874 * Tau * Tau)  'see math. doc.
        End Get
    End Property

    Public Overridable ReadOnly Property Tau As Decimal
        Get
            Return CDec(1)
        End Get
    End Property

    WriteOnly Property Perihel As Decimal
        Set(value As Decimal)
            MyPerihel = value
        End Set
    End Property

    WriteOnly Property ArgumentPerihel As Decimal
        Set(value As Decimal)
            MyArgumentPerihel = value
        End Set
    End Property

    WriteOnly Property PerihelVelocity As Decimal
        Set(value As Decimal)
            MyPerihelVelocity = value
        End Set
    End Property

    Public Sub SetDefaultParameterByPerihelData()
        With MyOriginalStartPosition
            .X = CDec(MyPerihel * Math.Cos(MyArgumentPerihel))
            .Y = CDec(MyPerihel * Math.Sin(MyArgumentPerihel))
            If .Abs > 0 Then
                v1 = -MyPerihelVelocity * .Y / .Abs
                v2 = MyPerihelVelocity * .X / .Abs
            Else
                v1 = MyPerihelVelocity * CDec(Math.Sqrt(2))
                v2 = v1
            End If
        End With
        MyUserStartPosition.Equal(MyOriginalStartPosition)
        MyActualPosition.Equal(MyOriginalStartPosition)
        MyOriginalStartVelocity.X = v1
        MyOriginalStartVelocity.Y = v2
        MyUserStartVelocity.Equal(MyOriginalStartVelocity)
        MyActualVelocity.Equal(MyUserStartVelocity)
    End Sub

    Public Overrides Sub DrawOrbit(IsDefinitive As Boolean)
        'We have to draw an ellipse
        'but the main axis is not parallel to the x-axis of the coordinate-system
        'we have first to calculate the Energy E
        'to get the parameters p and epsilon of the orbit formula
        'see math. doc.
        If MyTotalMassOfOtherStars > 0 And MyUserStartPosition.Abs > 0 Then

            Dim L As Double
            L = MyUserMass * MyUserStartPosition.Abs * MyUserStartVelocity.Abs

            Dim E As Double
            E = MyUserMass * Math.Pow(MyUserStartVelocity.Abs, 2) / 2 - GravConst * MyUserMass * Math.Pow(MyTotalMassOfOtherStars, 3) /
                    (Math.Pow(MyTotalMassOfOtherStars + MyUserMass, 2) * MyUserStartPosition.Abs)

            Dim p As Double
            p = Math.Pow((MyTotalMassOfOtherStars + MyUserMass) * L, 2) /
                    (GravConst * Math.Pow(MyTotalMassOfOtherStars, 3) * Math.Pow(MyUserMass, 2))

            Dim EpsSquare As Double
            EpsSquare = 1 + 2 * E * Math.Pow(L, 2) * Math.Pow(MyTotalMassOfOtherStars + MyUserMass, 4) /
                (Math.Pow(GravConst, 2) * Math.Pow(MyUserMass, 3) * Math.Pow(MyTotalMassOfOtherStars, 6))

            Dim Epsilon As Decimal
            If EpsSquare >= 0 Then
                Epsilon = CDec(Math.Sqrt(EpsSquare))
            Else
                Throw New Exception("NegativeSquareRoot")
            End If

            Dim ArgumentStartPosition As Decimal
            ArgumentStartPosition = MathHelper.AngleInNullTwoPi(MathHelper.CalculateAngleOfDirection(MyUserStartPosition.X, MyUserStartPosition.Y))

            Dim Rho As Decimal
            Rho = CDec(p / (1 + Epsilon))

            'if the velocity is < the balance between gravitation and 
            'the centrifugal force, the startpoint of the body is not anymore
            'the perihel, but the aphel
            'that means, the orbit is turned by pi
            Dim CorrectAlfa As Decimal

            If MyUserStartVelocity.Abs < CDec(Math.Sqrt(GravConst * MyTotalMassOfOtherStars / MyUserStartPosition.Abs)) Then
                CorrectAlfa = -1
            Else
                CorrectAlfa = 1
            End If

            Dim NumCorrFactor As Decimal
            If Rho <> 0 Then
                NumCorrFactor = MyUserStartPosition.Abs / Rho
            End If

            Dim Point = New ClsMathpoint(0, 0)
            Dim Theta As Decimal

            'Theta - MyUserArgumentPerihel should be in [-pi,pi]

            For Theta = ArgumentStartPosition - CDec(Math.PI + 0.01) To _
               ArgumentStartPosition + CDec(Math.PI - 0.01) Step CDec(0.02)
                Rho = CDec(p / (1 + CorrectAlfa * Epsilon * Math.Cos(Theta - ArgumentStartPosition)))
                Rho *= (1 + CorrectAlfa * Epsilon) / (1 + Epsilon)
                If Rho > 0 Then 'otherwise, we are out of the definition range of the e.g. hyperbola
                    Point.X = NumCorrFactor * MyUniverse.DiagramZoom * Rho * CDec(Math.Cos(Theta))
                    Point.Y = NumCorrFactor * MyUniverse.DiagramZoom * Rho * CDec(Math.Sin(Theta))

                    If IsDefinitive Then
                        MyBmpGraphics.DrawPoint(Point, MyStarColor, 1)
                    Else
                        MyPicGraphics.DrawPoint(Point, MyStarColor, 1)
                    End If
                End If
            Next

            If IsDefinitive Then
                MyPicDiagram.Refresh()
            End If

        End If

    End Sub

    Public Overrides Function GetEnergy() As Decimal
        'for debug
        Dim Debug As String
        Dim LocEKin As Decimal
        LocEKin = MyUserMass * (v1 * v1 + v2 * v2) / 2
        Debug = LocEKin.ToString
        Dim MassFactor As Decimal
        MassFactor = CDec(GravConst * MyUserMass * Math.Pow(MyTotalMassOfOtherStars, 3) /
                    Math.Pow(MyTotalMassOfOtherStars + MyUserMass, 2))
        Debug = MassFactor.ToString
        Dim LocEPot As Decimal
        LocEPot = -CDec(MassFactor / Math.Max(1, Math.Sqrt(u1 * u1 + u2 * u2)))
        Debug = LocEPot.ToString
        Return LocEKin + LocEPot
    End Function

    Protected Overrides Function F1(LocZ As ClsNTupel) As Decimal
        'u1' = v1
        Return LocZ.Component(1)
    End Function

    Protected Overrides Function G1(LocZ As ClsNTupel) As Decimal
        LocSum = 0
        'Go through all other stars
        For Each aStar As IStar In MyUniverse.ActiveStarCollection
            If aStar IsNot Me Then
                LocSum += aStar.UserMass * (aStar.ActualPosition.X - MyActualPosition.X) / (Math.Max(0.001, Math.Pow(Distance(aStar.ActualPosition, MyActualPosition), 3)))
            End If
        Next
        Return CDec(LocSum * GravConst)
    End Function

    Protected Overrides Function F2(LocZ As ClsNTupel) As Decimal
        'u2' = v2
        Return LocZ.Component(3)
    End Function

    Protected Overrides Function G2(LocZ As ClsNTupel) As Decimal
        LocSum = 0
        'Go through all other stars
        For Each aStar As IStar In MyUniverse.ActiveStarCollection
            If aStar IsNot Me Then
                LocSum += aStar.UserMass * (aStar.ActualPosition.Y - MyActualPosition.Y) / (Math.Max(0.001, Math.Pow(Distance(aStar.ActualPosition, MyActualPosition), 3)))
            End If
        Next
        Return CDec(LocSum * GravConst)
    End Function

    Private Function Distance(Position1 As ClsVector, Position2 As ClsVector) As Decimal
        'This is Rij in the math.doc.
        Return CDec(Math.Sqrt(Math.Pow(Position1.X - Position2.X, 2) + Math.Pow(Position1.Y - Position2.Y, 2)))
    End Function

End Class
