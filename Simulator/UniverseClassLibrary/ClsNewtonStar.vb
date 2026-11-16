'this is a concrete star moving in a Newton Universe

'Status Checked


Public Class ClsNewtonStar
    Inherits ClsStarAbstract

    'in our planet system, the given data about planets
    'is not the actual position, but the perihel and its argument
    Private MyPerihel As Double
    Private MyArgumentPerihel As Double

    'Velocity at the perihel
    Private MyPerihelVelocity As Double

    'To sum the Gravity of each other star
    'acting on the calculated star
    Private LocSum As Double

    Protected Overridable ReadOnly Property GravConst As Double
        'see the math. doc. for the gravity constant
        'depending on the chosen units:
        'astronomic unit instead of km
        'years instead of seconds
        'earth mass instead of kg
        Get
            Return CDbl(0.00000000088874 * Tau * Tau)  'see math. doc.
        End Get
    End Property

    Public Overridable ReadOnly Property Tau As Double
        Get
            Return CDbl(1)
        End Get
    End Property

    WriteOnly Property Perihel As Double
        Set(value As Double)
            MyPerihel = value
        End Set
    End Property

    WriteOnly Property ArgumentPerihel As Double
        Set(value As Double)
            MyArgumentPerihel = value
        End Set
    End Property

    WriteOnly Property PerihelVelocity As Double
        Set(value As Double)
            MyPerihelVelocity = value
        End Set
    End Property

    Public Sub SetDefaultParameterByPerihelData()
        With MyOriginalStartPosition
            .X = CDbl(MyPerihel * Math.Cos(MyArgumentPerihel))
            .Y = CDbl(MyPerihel * Math.Sin(MyArgumentPerihel))
            If .Abs > 0 Then
                v1 = -MyPerihelVelocity * .Y / .Abs
                v2 = MyPerihelVelocity * .X / .Abs
            Else
                v1 = MyPerihelVelocity * CDbl(Math.Sqrt(2))
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

        Dim Debug As String = MyName

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

            Dim Epsilon As Double
            If EpsSquare >= 0 Then
                Epsilon = CDbl(Math.Sqrt(EpsSquare))
            Else
                Throw New Exception("NegativeSquareRoot")
            End If

            Dim ArgumentStartPosition As Double
            ArgumentStartPosition = MathHelper.AngleInNullTwoPi(MathHelper.CalculateAngleOfDirection(MyUserStartPosition.X, MyUserStartPosition.Y))

            Dim Rho As Double
            Rho = CDbl(p / (1 + Epsilon))

            'if the velocity is < the balance between gravitation and 
            'the centrifugal force, the startpoint of the body is not anymore
            'the perihel, but the aphel
            'that means, the orbit is turned by pi
            Dim CorrectAlfa As Double

            If MyUserStartVelocity.Abs < CDbl(Math.Sqrt(GravConst * MyTotalMassOfOtherStars / MyUserStartPosition.Abs)) Then
                CorrectAlfa = -1
            Else
                CorrectAlfa = 1
            End If

            Dim NumCorrFactor As Double
            If Rho <> 0 Then
                NumCorrFactor = MyUserStartPosition.Abs / Rho
            End If

            Dim Point = New ClsMathpoint(0, 0)
            Dim Theta As Double

            'Theta - MyUserArgumentPerihel should be in [-pi,pi]

            For Theta = ArgumentStartPosition - CDbl(Math.PI + 0.01) To _
               ArgumentStartPosition + CDbl(Math.PI - 0.01) Step CDbl(0.02)
                Rho = CDbl(p / (1 + CorrectAlfa * Epsilon * Math.Cos(Theta - ArgumentStartPosition)))
                Rho *= (1 + CorrectAlfa * Epsilon) / (1 + Epsilon)
                If Rho > 0 Then 'otherwise, we are out of the definition range of the e.g. hyperbola
                    Point.X = NumCorrFactor * MyUniverse.DiagramZoom * Rho * CDbl(Math.Cos(Theta))
                    Point.Y = NumCorrFactor * MyUniverse.DiagramZoom * Rho * CDbl(Math.Sin(Theta))

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

    Public Overrides Function GetEnergy() As Double
        'for debug
        Dim Debug As String
        Dim LocEKin As Double
        LocEKin = MyUserMass * (v1 * v1 + v2 * v2) / 2
        Debug = LocEKin.ToString
        Dim MassFactor As Double
        MassFactor = CDbl(GravConst * MyUserMass * Math.Pow(MyTotalMassOfOtherStars, 3) /
                    Math.Pow(MyTotalMassOfOtherStars + MyUserMass, 2))
        Debug = MassFactor.ToString
        Dim LocEPot As Double
        LocEPot = -CDbl(MassFactor / Math.Max(1, Math.Sqrt(u1 * u1 + u2 * u2)))
        Debug = LocEPot.ToString
        Return LocEKin + LocEPot
    End Function

    Protected Overrides Function F1(LocZ As ClsNTupel) As Double
        'u1' = v1
        Return LocZ.Component(1)
    End Function

    Protected Overrides Function G1(LocZ As ClsNTupel) As Double
        LocSum = 0
        'Go through all other stars
        'the own position is the stage position LocZ, the other stars are at their stage position as well
        For Each aStar As IStar In MyUniverse.ActiveStarCollection
            If aStar IsNot Me Then
                LocSum += aStar.UserMass * (aStar.StagePosition.X - LocZ.Component(0)) / (Math.Max(0.001, Math.Pow(Distance(aStar.StagePosition, LocZ), 3)))
            End If
        Next
        Return CDbl(LocSum * GravConst)
    End Function

    Protected Overrides Function F2(LocZ As ClsNTupel) As Double
        'u2' = v2
        Return LocZ.Component(3)
    End Function

    Protected Overrides Function G2(LocZ As ClsNTupel) As Double
        LocSum = 0
        'Go through all other stars
        'the own position is the stage position LocZ, the other stars are at their stage position as well
        For Each aStar As IStar In MyUniverse.ActiveStarCollection
            If aStar IsNot Me Then
                LocSum += aStar.UserMass * (aStar.StagePosition.Y - LocZ.Component(2)) / (Math.Max(0.001, Math.Pow(Distance(aStar.StagePosition, LocZ), 3)))
            End If
        Next
        Return CDbl(LocSum * GravConst)
    End Function

    Private Function Distance(Position1 As ClsVector, LocZ As ClsNTupel) As Double
        'This is Rij in the math.doc.
        'LocZ.Component(0) and LocZ.Component(2) are the coordinates of the own stage position
        Return CDbl(Math.Sqrt(Math.Pow(Position1.X - LocZ.Component(0), 2) + Math.Pow(Position1.Y - LocZ.Component(2), 2)))
    End Function

End Class
