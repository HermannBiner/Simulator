'This class contains all Properties of the Billiard Ball on an Stadium Billiard Table
'and all Methods, this Ball has to know
'including its movement on the table and setting its start position
'therefore, many Balls can be placed on the Table
'with different colors (to be distinguished)
'See mathematical documentation

'important: this class works with mathematical coordinates
'the Instance of the GraphicTool transforms these in Pixel-Coordinates

'Status Checked

Imports System.Globalization

Public Class ClsStadiumBilliardball
    Inherits ClsBilliardBallAbstract


    'SECTOR INITIALIZATION

    Overrides Property Startparameter As Decimal
        Get
            Startparameter = T
        End Get
        'The user can set the Startparameter t also manually (when not setting it by the mouse)
        'and transmit this value to the Ball
        Set(value As Decimal)
            T = value

            If IsNothing(UserStartposition) Then
                UserStartposition = New ClsMathpoint(0, 0)
            End If

            'and then, the Startposition according to the mathematical documentation is
            Dim StartPointBall As ClsMathpoint = CalculateMathPointFromT(T)
            UserStartposition.X = StartPointBall.X
            UserStartposition.Y = StartPointBall.Y

            DrawUserStartposition(True)
            MyStartPositionSet = True
        End Set
    End Property

    Overrides WriteOnly Property Startangle As Decimal

        Set(value As Decimal)

            'In addition to the Startparameter t
            'the angle of the first reflection is necessary as well
            'to start the movement of the Ball
            Dim alfa As Decimal = value

            'first, we calculate the angle between tangent in the hit point
            'and the positive xaxis
            Dim psi As Decimal = CalculatePsi(T)
            psi = Mathhelper.AngleInNullTwoPi(psi)

            'Now the angle between the next moving-direction and the positive x-axis is:
            Phi = psi + alfa

            If IsNothing(UserEndposition) Then
                UserEndposition = New ClsMathpoint(0, 0)
            End If

            'With these parameters, we can calculate the next Hit Point
            'and its Parameter NextT
            Dim NextT As Decimal = ParameterOfNextHitpoint(T, Phi)

            Dim Userposition As ClsMathpoint = CalculateMathPointFromT(NextT)
            UserEndposition.X = Userposition.X
            UserEndposition.Y = Userposition.Y
            DrawUserEndposition(True)
            MyStartAngleSet = True

        End Set
    End Property

    'SECTOR SETTING STARTPOSITION AND STARTANGLE OF THE BALL

    Public Overrides Function SetAndDrawUserStartposition(Mouseposition As Point, IsDefinitive As Boolean) As Decimal

        Dim t As Decimal = SetUserStartposition(Mouseposition)
        DrawUserStartposition(IsDefinitive)

        'we need t for the Protocol
        Return t

    End Function

    Private Function SetUserStartposition(Mouseposition As Point) As Decimal

        'Position of the Ball in math. coordinates, set by the Mouseposition in Pixel Coordinates
        'this startposition is still at the mouseposition (and not on the border of the Stadium)
        UserStartposition = MyBmpGraphics.PixelToMathpoint(Mouseposition)

        'Parameter of this Startpoint
        T = CalculateTFromMathPoint(UserStartposition)

        'Now, the Startposition is set on the border of the Ellipse
        Dim StartpointBall As ClsMathpoint = CalculateMathPointFromT(T)
        UserStartposition.X = StartpointBall.X
        UserStartposition.Y = StartpointBall.Y

        Return T

    End Function

    Public Overrides Sub DrawFirstUserStartposition()

        'Standard Start Point is (0/b)
        UserStartposition = New ClsMathpoint(MyA, MyB)

        'the final EndPosition is set later
        UserEndposition = New ClsMathpoint(-MyA, -MyB)

        'these Parameters are set later by moving the Mouse
        DrawUserStartposition(False)

    End Sub

    Private Sub DrawUserStartposition(IsDefinitive As Boolean)
        If IsDefinitive Then

            'The Ball is drawn permanentely into the BitMap
            MyBmpGraphics.DrawPoint(UserStartposition, MyColor, Size)
            MyPicDiagram.Refresh()
        Else

            'The actual and still moving Ball is drawn into PicDiagram
            MyPicDiagram.Refresh()
            MyPicGraphics.DrawPoint(UserStartposition, MyColor, Size)
        End If
    End Sub

    Public Overrides Function SetAndDrawUserEndposition(Mouseposition As Point, IsDefinitive As Boolean) As Decimal _


        'The Endposition is definied by the angle phi of the next moving direction
        Dim phi As Decimal = SetUserEndposition(Mouseposition)

        DrawUserEndposition(IsDefinitive)

        'We need Phi to calculate Alfa and for the Procotol in the Phase Portrait
        Return phi

    End Function

    Private Function SetUserEndposition(Mouseposition As Point) As Decimal

        'The Endposition of the Ball in math. coordinates
        'is just equal to the Mouseposition in Pixels
        UserEndposition = MyBmpGraphics.PixelToMathpoint(Mouseposition)

        'Now, we need the Parameter t according to this Point
        Dim t As Decimal = CalculateTFromMathPoint(UserEndposition)

        'and the coordinates of the EndPoint of this part of the Orbit
        Dim EndpointBall As ClsMathpoint = CalculateMathPointFromT(t)
        UserEndposition.X = EndpointBall.X
        UserEndposition.Y = EndpointBall.Y

        'With this Endposition, we calculate the Angle phi
        'that is the Angle of the next moving-direction and the positive x-axis
        Dim DeltaX As Decimal = UserEndposition.X - UserStartposition.X
        Dim DeltaY As Decimal = UserEndposition.Y - UserStartposition.Y
        Dim phi = Mathhelper.CalculateAngleOfDirection(DeltaX, DeltaY)

        Return phi

    End Function

    Private Sub DrawUserEndposition(IsDefinitive As Boolean)

        If IsDefinitive Then

            'The Endposition of the Ball is drawn permanentely into the BitMap
            MyBmpGraphics.DrawPoint(UserEndposition, MyColor, Size)
            MyPicDiagram.Refresh()

            'The Track of the first Hit of the Ball is drawn only into the PicDiagram
            MyPicGraphics.DrawLine(UserStartposition, UserEndposition, MyColor, 1)
        Else
            MyPicDiagram.Refresh()

            'The actual Ballposition is drawn only into the PicDiagram
            MyPicGraphics.DrawPoint(UserEndposition, MyColor, Size)
            MyPicGraphics.DrawLine(UserStartposition, UserEndposition, MyColor, 1)
        End If

    End Sub

    'SECTOR ITERATION

    Public Overrides Sub IterationStep()

        'Startpoint of the actual part of the Orbit
        Dim Startpoint As New ClsMathpoint

        'Parameter of the next Endpoint of the actual part of the Orbit
        Dim NextT As Decimal

        'and the according EndPoint
        Dim Endpoint As New ClsMathpoint


        'MyT is the Parameter ot the StartPoint of the actual part of the Orbit
        Dim TempStartpoint As ClsMathpoint = CalculateMathPointFromT(T)

        Startpoint.X = TempStartpoint.X
        Startpoint.Y = TempStartpoint.Y

        'NextT is the Parameter of the EndPoint of the actual part of the Orbit
        NextT = ParameterOfNextHitpoint(T, Phi)
        Dim TempEndpoint As ClsMathpoint = CalculateMathPointFromT(NextT)
        Endpoint.X = TempEndpoint.X
        Endpoint.Y = TempEndpoint.Y

        'The Ball moves between these Points
        MoveOnOrbitPart(Startpoint, Endpoint)

        'The EndPoint is then the StartPoint of the following part of the Orbit
        T = NextT
        Startpoint.X = Endpoint.X
            Startpoint.Y = Endpoint.Y

            'in addition, we calculate the angle of the following movement
            Phi = CalculateNextPhi(T, Phi)


    End Sub

    Public Overrides Function GetNextValuePair(ActualPoint As ClsValuePair) As ClsValuePair

        T = ActualPoint.X
        Dim alfa As Decimal = ActualPoint.Y

        'first, we calculate the angle between tangent in the hit point
        'and the positive xaxis
        Dim psi As Decimal = Mathhelper.AngleInNullTwoPi(CalculatePsi(T))

        'Now the angle between the next moving-direction and the positive x-axis is:
        Phi = psi + alfa

        'Parameter of the next Enpoint of the actual part of the Orbit
        Dim NextT As Decimal = ParameterOfNextHitpoint(T, Phi)

        'in addition, we calculate the angle of the following movement
        Phi = CalculateNextPhi(NextT, Phi)

        alfa = CalculateAlfa(NextT, Phi)

        Dim NextPoint As New ClsValuePair(NextT, alfa)

        Return NextPoint

    End Function

    'SECTOR BALL MOVEMENT

    Private Sub MoveOnOrbitPart(Startposition As ClsMathpoint, Endposition As ClsMathpoint)

        Dim ActualPosition As New ClsMathpoint With {
            .X = Startposition.X,
            .Y = Startposition.Y
        }

        Dim Nextposition As New ClsMathpoint

        Dim i As Integer = 0

        'The following Stepwide was defined by an Experiment
        Dim Stepwide As Decimal = MyMathInterval.IntervalWidth * MySpeed / 1000

        Do
            i += 1
            Nextposition.X = Startposition.X + (Endposition.X - Startposition.X) * i * Stepwide
            Nextposition.Y = Startposition.Y + (Endposition.Y - Startposition.Y) * i * Stepwide

            If Not IsBallOnStadium(Nextposition) Then
                Nextposition.X = Endposition.X
                Nextposition.Y = Endposition.Y
            End If

            'Draw the trace of this part of the Orbit permanentely into the BitMap
            MyBmpGraphics.DrawLine(ActualPosition, Nextposition, MyColor, 1)

            'and show the trace by refreshing the Diagram
            MyPicDiagram.Refresh()

            'and draw the new Ball Position
            MyPicGraphics.DrawPoint(Nextposition, MyColor, Size)

            ActualPosition.X = Nextposition.X
            ActualPosition.Y = Nextposition.Y

        Loop Until i * Stepwide > 1

    End Sub

    'SECTOR CALCULATION

    Private Function IsBallOnStadium(Position As ClsMathpoint) As Boolean

        Dim OK As Boolean = False

        'Is the Ball in the Rectangle?
        If -MyA <= Position.X And Position.X <= MyA Then
            If -MyB <= Position.Y And Position.Y <= MyB Then
                OK = True
            End If
        End If

        'Is the Ball in the left half-Circle
        If Not OK Then
            If -MyA - MyB <= Position.Y And Position.X <= MyA Then
                If Position.X * Position.X + Position.Y * Position.Y <= MyB * MyB Then
                    OK = True
                End If
            End If
        End If

        'Is the Ball in the right half-Circle?
        If Not OK Then
            If MyA <= Position.X And Position.X <= MyA + MyB Then
                If Position.X * Position.X + Position.Y * Position.Y <= MyB * MyB Then
                    OK = True
                End If
            End If
        End If

        Return OK

    End Function

    Private Function ParameterOfNextHitpoint(s As Decimal, phi As Decimal) As Decimal

        't is the Parameter of the Startpoint of the actual part of the Orbit
        'and Phi the direction of the movement relative to the positive x-axis
        'this medhod calculates then the next Hit Point 
        'and returns its Parameter NextT
        'see mathematical documentation

        'Make sure that Phi is in [0, 2*pi]
        phi = Mathhelper.AngleInNullTwoPi(phi)

        'The Ball is moving on a straight line (its Orbit) through the startpoint
        'and in direction of the angle Phi between this line and the positive x-axis
        Dim Startpoint As ClsMathpoint = CalculateMathPointFromT(s)

        Dim Intersection As New ClsMathpoint
        Dim IsIntersectionFound As Boolean = False
        Dim NextT As Decimal

        'See the mathematical documentation for the following calculation
        't is the Parameter of the equation of the line
        Dim t As Decimal

        If phi <> 0 And Math.Abs(phi - Math.PI) > 0 Then

            'the Orbit intersects the line y = b
            t = CDec((MyB - Startpoint.Y) / Math.Sin(phi))

            'if the x-coordinate is in [-a,a], then the intersection is found
            'but we have to exclude t = 0 (the StartPoint)
            Intersection.X = Startpoint.X + t * CDec(Math.Cos(phi))
            If Math.Abs(Intersection.X) <= MyA And Math.Abs(t) > 0.0000001 Then
                Intersection.Y = MyB
                IsIntersectionFound = True
            Else

                'the Orbit intersects the line y = -b
                t = CDec((-MyB - Startpoint.Y) / Math.Sin(phi))

                'if the x-coordinate is in [-a,a], then the intersection is found
                'but we have to exclude t = 0 (the StartPoint)
                Intersection.X = Startpoint.X + t * CDec(Math.Cos(phi))
                If Math.Abs(Intersection.X) <= MyA And Math.Abs(t) > 0.0000001 Then
                    Intersection.Y = -MyB
                    IsIntersectionFound = True
                End If
            End If
        End If

        If Not IsIntersectionFound Then
            Dim TempB As Decimal
            Dim TempC As Decimal

            'The Orbit intersects the right half-Circle
            TempB = CDec((Startpoint.X - MyA) * Math.Cos(phi) + Startpoint.Y * Math.Sin(phi))
            TempC = (Startpoint.X - MyA) * (Startpoint.X - MyA) + Startpoint.Y * Startpoint.Y - MyB * MyB

            'The discriminant must be positive
            If TempB * TempB - TempC >= 0 Then

                'first try for a solution of the quadratic equation
                t = -TempB + CDec(Math.Sqrt(TempB * TempB - TempC))
                Intersection.X = Startpoint.X + t * CDec(Math.Cos(phi))
                If Intersection.X > MyA And Math.Abs(t) > 0.0000001 Then
                    Intersection.Y = Startpoint.Y + t * CDec(Math.Sin(phi))
                    IsIntersectionFound = True
                Else

                    'second try for a solution of the quadratic equation
                    t = -TempB - CDec(Math.Sqrt(TempB * TempB - TempC))
                    Intersection.X = Startpoint.X + t * CDec(Math.Cos(phi))
                    If Intersection.X > MyA And Math.Abs(t) > 0.0000001 Then
                        Intersection.Y = Startpoint.Y + t * CDec(Math.Sin(phi))
                        IsIntersectionFound = True
                    End If
                End If
            End If

            If Not IsIntersectionFound Then

                'The Orbit intersects the left half-Circle
                TempB = CDec((Startpoint.X + MyA) * Math.Cos(phi) + Startpoint.Y * Math.Sin(phi))
                TempC = (Startpoint.X + MyA) * (Startpoint.X + MyA) + Startpoint.Y * Startpoint.Y - MyB * MyB

                'The discriminant must be positive
                If TempB * TempB - TempC >= 0 Then

                    'first try for a solution of the quadratic equation
                    t = -TempB + CDec(Math.Sqrt(TempB * TempB - TempC))
                    Intersection.X = Startpoint.X + t * CDec(Math.Cos(phi))
                    If Intersection.X < -MyA And Math.Abs(t) > 0.0000001 Then
                        Intersection.Y = Startpoint.Y + t * CDec(Math.Sin(phi))
                        IsIntersectionFound = True
                    Else

                        'second try for a solution of the quadratic equation
                        t = -TempB - CDec(Math.Sqrt(TempB * TempB - TempC))
                        Intersection.X = Startpoint.X + t * CDec(Math.Cos(phi))
                        If Intersection.X < -MyA And Math.Abs(t) > 0.0000001 Then
                            Intersection.Y = Startpoint.Y + t * CDec(Math.Sin(phi))
                            IsIntersectionFound = True
                        End If
                    End If
                End If
            End If
        End If

        'Note to Math.Abs(t) > 0.0000001
        'if we would write Math.Abs(t) > 0
        'then, it could be possible that for very small t the last hit point is found
        'as solution of the intersect equation
        'the limit 0.0000001 is bigger than the rounding-effects
        'but smaller than the pixel-unit

        If Not IsIntersectionFound Then
            Throw New ArgumentException(FrmMain.LM.GetString("NoIntersectionPoint"))
        Else
            NextT = CalculateTFromMathPoint(Intersection)
        End If

        Return NextT

    End Function

    Private Function CalculateNextPhi(t As Decimal, phi As Decimal) As Decimal

        't is the Parameter of the Startpoint of the actual part of the Orbit
        'and Phi the direction of the movement relative to the positive x-axis
        'this medhod calculates then the next Direction-Angle NextPhi 
        'see mathematical documentation

        'First, we need the angle between tangent in the Hit Point and the positive x-axis
        Dim psi As Decimal = CalculatePsi(t)
        psi = Mathhelper.AngleInNullTwoPi(psi)

        'This gives the angle NextPhi - see math. doc.
        Dim NextPhi As Decimal = 2 * psi - phi
        NextPhi = Mathhelper.AngleInNullTwoPi(NextPhi)

        'This is the perfect moment to write the protocol
        'of the next part of the Orbit into the Phase Portrait
        If PhaseportraitGraphics IsNot Nothing Then
            Dim Alfa As Decimal = CalculateAlfa(t, NextPhi)
            PhaseportraitGraphics.DrawPoint(New ClsMathpoint(MyBase.T, Alfa), MyColor, p)
            If MyValueProtocol IsNot Nothing Then
                MyValueProtocol.Items.Add(FrmMain.LM.GetString(
                                     DirectCast(MyColor, SolidBrush).Color.Name) & " t/alfa = " &
                                     MyBase.T.ToString(CultureInfo.CurrentCulture) & "/" & Alfa.ToString(CultureInfo.CurrentCulture))
                MyValueProtocol.Refresh()
            End If
        End If

        Return NextPhi

    End Function

    Public Overrides Function CalculateAlfa(t As Decimal, phi As Decimal) As Decimal

        'This method calculates the next reflection angle Alfa

        'First, we need the angle between tangent in the Hit Point and the positive x-axis
        Dim psi As Decimal = CalculatePsi(t)
        psi = Mathhelper.AngleInNullTwoPi(psi)

        'and then - see math. doc.
        Dim alfa As Decimal = phi - psi
        alfa = Mathhelper.AngleInNullTwoPi(alfa)

        Return alfa

    End Function

    Private Function CalculatePsi(t As Decimal) As Decimal

        'This method calculates the angle between tangent in the Hit Point and the positive x-axis
        'and we have different cases
        Dim psi As Decimal

        Select Case True
            Case t <= 2 * MyA
                psi = CDec(Math.PI)
            Case t > 2 * MyA And t < 2 * MyA + MyB * CDec(Math.PI)
                Dim angle As Decimal = (t - 2 * MyA) / MyB
                psi = CDec(Math.PI) + angle
            Case t >= 2 * MyA + MyB * CDec(Math.PI) And t <= 4 * MyA + MyB * CDec(Math.PI)
                psi = 0
            Case Else
                Dim angle As Decimal = (t - 4 * MyA - MyB * CDec(Math.PI)) / MyB
                psi = angle
        End Select

        Return psi

    End Function

    Private Function CalculateMathPointFromT(t As Decimal) As ClsMathpoint

        'this method calculates the Ball position in math. coordinates
        'if the Parameter t is given

        Dim Ballpoint As New ClsMathpoint(0, 0)

        t = t Mod (4 * MyA + 2 * MyB * CDec(Math.PI))

        Select Case True
            Case t <= 2 * MyA
                Ballpoint.X = MyA - t
                Ballpoint.Y = MyB
            Case t > 2 * MyA And t < 2 * MyA + MyB * CDec(Math.PI)
                Dim Angle As Decimal = (t - 2 * MyA) / MyB
                Ballpoint.X = -MyA - MyB * CDec(Math.Sin(Angle))
                Ballpoint.Y = MyB * CDec(Math.Cos(Angle))
            Case t >= 2 * MyA + MyB * CDec(Math.PI) And t <= 4 * MyA + MyB * CDec(Math.PI)
                Ballpoint.X = t - 3 * MyA - MyB * CDec(Math.PI)
                Ballpoint.Y = -MyB
            Case Else
                Dim Angle As Decimal = (t - 4 * MyA - MyB * CDec(Math.PI)) / MyB
                Ballpoint.X = MyA + MyB * CDec(Math.Sin(Angle))
                Ballpoint.Y = -MyB * CDec(Math.Cos(Angle))
        End Select

        Return Ballpoint

    End Function

    Private Function CalculateTFromMathPoint(Mathpoint As ClsMathpoint) As Decimal

        'this method calculates the parameter t for a given position of the Ball
        'in math. coordinates

        Dim TempT As Decimal

        If -MyA <= Mathpoint.X And Mathpoint.X <= MyA Then

            'Set the Ball on the Border of the rectangle
            If Mathpoint.Y >= 0 Then

                'Is the position above the rectangle?
                TempT = MyA - Mathpoint.X
            Else

                'Is the position below the rectangle?
                TempT = 3 * MyA + MyB * CDec(Math.PI) + Mathpoint.X
            End If
        Else
            Dim SinValue As Decimal
            If Mathpoint.X < -MyA Then

                'Set the Ball on the Border of the left half-Circle
                SinValue = Math.Min(1, (-Mathpoint.X - MyA) / MyB)
                If Mathpoint.Y >= 0 Then

                    'Above x-axis
                    TempT = 2 * MyA + MyB * CDec(Math.Asin(SinValue))
                Else

                    'Below x-axis
                    TempT = 2 * MyA + MyB * (CDec(Math.PI) - CDec(Math.Asin(SinValue)))
                End If
            Else

                'Set the Ball on the Border of the right half-Circle
                SinValue = Math.Min(1, (Mathpoint.X - MyA) / MyB)
                If Mathpoint.Y <= 0 Then

                    'below x-axis
                    TempT = 4 * MyA + MyB * (CDec(Math.PI) + CDec(Math.Asin(SinValue)))
                Else

                    'above x-axis
                    TempT = 4 * MyA + MyB * (2 * CDec(Math.PI) - CDec(Math.Asin(SinValue)))
                End If
            End If
        End If

        Return TempT

    End Function
End Class
