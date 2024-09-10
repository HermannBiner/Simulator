'This class contains all Properties of the Billiard Ball on an Oval Billiard Table
'and all Methods, this Ball has to know
'including its movement on the table and setting its start position
'therefore, many Balls can be placed on the Table
'with different colors (to be distinguished)
'See mathematical documentation

'important: this class works with mathematical coordinates
'the Instance of the GraphicTool transforms these in Pixel-Coordinates

'Status Checked

Imports System.Globalization

Public Class ClsOvalBilliardball
    Inherits ClsBilliardBallAbstract

    'SECTOR INITIALIZATION

    Overrides Property Startparameter As Decimal
        Get
            Startparameter = MyT
        End Get
        'The user can set the Startparameter t also manually (when not setting it by the mouse)
        'and transmit this value to the Ball
        Set(value As Decimal)
            MyT = value

            If IsNothing(UserStartposition) Then
                UserStartposition = New ClsMathpoint(0, 0)
            End If

            'and then, the Startposition according to the mathematical documentation is:
            Dim TempMathpoint As ClsMathpoint = CalculateBallPositionFromT(MyT)

            UserStartposition.X = TempMathpoint.X
            UserStartposition.Y = TempMathpoint.Y
            DrawUserStartposition(True)
            MyStartPositionSet = True

        End Set
    End Property

    Overrides WriteOnly Property Startangle As Decimal

        'In addition to the Startparameter t,
        'the angle of the first  reflection is necessary as well
        'to start the movement of the Ball
        Set(value As Decimal)
            Dim alfa As Decimal = value

            'first, we calculate the angle between tangent in the hit point
            'and the positive xaxis
            Dim psi As Decimal = CalculatePsi(MyT)
            psi = MyMathhelper.AngleInNullTwoPi(psi)

            'Now the angle between the next moving-direction and the positive x-axis is:
            MyPhi = psi + alfa

            'With these parameters, we can calculate the next Hit Point
            'and its Parameter NextT
            Dim nextT As Decimal = ParameterOfNextHitPoint(MyT, MyPhi)

            If IsNothing(UserEndposition) Then
                UserEndposition = New ClsMathpoint(0, 0)
            End If

            'The Position von the next Hit Point is the Endposition
            'of this part of the Ball-Movement
            Dim Userposition As ClsMathpoint = CalculateBallPositionFromT(nextT)

            UserEndposition.X = Userposition.X
            UserEndposition.Y = Userposition.Y
            DrawUserEndPosition(True)

            MyStartAngleSet = True

        End Set
    End Property


    'SECTOR SETTING STARTPOSITION AND STARTANGLE OF THE BALL

    Public Overrides Function SetAndDrawUserStartposition(Mouseposition As Point, definitive As Boolean) As Decimal

        Dim t As Decimal = SetUserStartposition(Mouseposition)
        DrawUserStartposition(definitive)

        'we need t for the Protocol
        Return t

    End Function

    Private Function SetUserStartposition(Mouseposition As Point) As Decimal

        'Position of the Ball in math. coordinates, set by the Mouseposition in Pixel Coordinates
        'this startposition is still at the mouseposition (and not on the border of the Ellipse)
        UserStartposition = MyBmpGraphics.PixelToMathpoint(Mouseposition)

        'Parameter of this Startpoint
        MyT = MyMathhelper.CalculateAngleOfDirection(UserStartposition.X, UserStartposition.Y)

        'Now, the Startposition is set on the border of the Oval
        Dim StartpointBall As ClsMathpoint = CalculateBallPositionFromT(MyT)
        UserStartposition.X = StartpointBall.X
        UserStartposition.Y = StartpointBall.Y

        Return MyT

    End Function

    Public Overrides Sub DrawFirstUserStartposition()

        'Standard StartPoint is (m, b)
        UserStartposition = New ClsMathpoint((MyA - MyB) / 2, MyB)
        DrawUserStartposition(False)

        'and Endposition (a+b,0)
        UserEndposition = New ClsMathpoint(MyA + MyB, 0)

        'these Parameters are set later by moving the Mouse
        DrawUserStartposition(False)

    End Sub

    Private Sub DrawUserStartposition(definitive As Boolean)
        If definitive Then

            'The Ball is drawn permanentely into the BitMap
            MyBmpGraphics.DrawPoint(UserStartposition, MyColor, Size)
            MyPicDiagram.Refresh()
        Else

            'The actual and still moving Ball is drawn into PicDiagram
            MyPicDiagram.Refresh()
            MyPicGraphics.DrawPoint(UserStartposition, MyColor, Size)
        End If
    End Sub

    Public Overrides Function SetAndDrawUserEndposition(Mouseposition As Point, definitive As Boolean) As Decimal _


        'The Endposition is definied by the angle phi of the next moving direction
        Dim phi As Decimal = SetUserEndposition(Mouseposition)

        DrawUserEndPosition(definitive)

        'We need Phi to calculate Alfa and for the Procotol in the Phase Portrait
        Return phi

    End Function

    Private Function SetUserEndposition(Mouseposition As Point) As Decimal

        'The Endposition of the Ball in math. coordinates
        'is just equal to the Mouseposition in Pixels
        UserEndposition = MyBmpGraphics.PixelToMathpoint(Mouseposition)

        'TempPhi is a provisional angle between the UserEndPosition and the x-axis
        Dim TempPhi As Decimal = MyMathhelper.CalculateAngleOfDirection(UserEndposition.X, UserEndposition.Y)
        Dim Ballpoint As ClsMathpoint = CalculateBallPositionFromT(TempPhi)
        UserEndposition.X = Ballpoint.X
        UserEndposition.Y = Ballpoint.Y

        'With this Endposition, we calculate the definitive Angle phi
        'that is the Angle of the next moving-direction and the positive x-axis
        Dim deltaX As Decimal = UserEndposition.X - UserStartposition.X
        Dim deltaY As Decimal = UserEndposition.Y - UserStartposition.Y
        Dim phi = MyMathhelper.CalculateAngleOfDirection(deltaX, deltaY)

        Return phi

    End Function

    Private Sub DrawUserEndPosition(definitive As Boolean)

        If definitive Then

            'The Endposition of the Ball is drawn permanentely into the BitMap
            MyBmpGraphics.DrawPoint(UserEndposition, MyColor, Size)
            MyPicDiagram.Refresh()

            'The Track of the first Hit of the Ball is drawn only into the PicDiagram
            MyPicGraphics.DrawLine(UserStartposition, UserEndposition,
                                   DirectCast(MyColor, SolidBrush).Color, 1)
        Else
            MyPicDiagram.Refresh()

            'The actual Ballposition is drawn only into the PicDiagram
            MyPicGraphics.DrawPoint(UserEndposition, MyColor, Size)
            MyPicGraphics.DrawLine(UserStartposition, UserEndposition,
                                   DirectCast(MyColor, SolidBrush).Color, 1)
        End If

    End Sub

    'SECTOR ITERATION

    Public Overrides Sub IterationStep()

        'Startpoint of the actual part of the Orbit
        Dim Startpoint As New ClsMathpoint

        'Parameter of the next Endpoint of the actual part of the Orbit
        Dim nextT As Decimal

        'and the according EndPoint
        Dim Endpoint As New ClsMathpoint


        'MyT is the Parameter ot the StartPoint of the actual part of the Orbit
        Dim TempBallpoint As ClsMathpoint = CalculateBallPositionFromT(MyT)
            Startpoint.X = TempBallpoint.X
            Startpoint.Y = TempBallpoint.Y

            'NextT is the Parameter of the EndPoint of the actual part of the Orbit
            nextT = ParameterOfNextHitPoint(MyT, MyPhi)
            TempBallpoint = CalculateBallPositionFromT(nextT)
            Endpoint.X = TempBallpoint.X
            Endpoint.Y = TempBallpoint.Y

            'The Ball moves between these Points
            MoveOnOrbitPart(Startpoint, Endpoint)

            'The EndPoint is then the StartPoint of the following part of the Orbit
            MyT = nextT
            Startpoint.X = Endpoint.X
            Startpoint.Y = Endpoint.Y

            'in addition, we calculate the angle of the following movement
            MyPhi = CalculateNextPhi(MyT, MyPhi)


    End Sub

    Public Overrides Function GetNextValuePair(ActualPoint As ClsValuePair) As ClsValuePair

        MyT = ActualPoint.X
        Dim alfa As Decimal = ActualPoint.Y

        'first, we calculate the angle between tangent in the hit point
        'and the positive x-axis
        Dim psi As Decimal = MyMathhelper.AngleInNullTwoPi(CalculatePsi(MyT))

        'Now the angle between the next moving-direction and the positive x-axis is:
        MyPhi = psi + alfa

        'Parameter of the next Enpoint of the actual part of the Orbit
        Dim nextT As Decimal = ParameterOfNextHitPoint(MyT, MyPhi)

        'in addition, we calculate the angle of the following movement
        MyPhi = CalculateNextPhi(nextT, MyPhi)

        alfa = CalculateAlfa(nextT, MyPhi)

        Dim NextPoint As New ClsValuePair(nextT, alfa)

        Return NextPoint

    End Function

    'SECTOR BALL MOVEMENT

    Private Sub MoveOnOrbitPart(Startposition As ClsMathpoint, Endposition As ClsMathpoint)

        Dim Actualposition As New ClsMathpoint With {
            .X = Startposition.X,
            .Y = Startposition.Y
        }

        Dim Nextposition As New ClsMathpoint

        Dim i As Integer = 0

        'The following Stepwide was defined by an Experiment
        Dim Stepwide As Decimal = MyMathValuerange.IntervalWidth * MySpeed / 1000

        Do
            i += 1
            Nextposition.X = Startposition.X + (Endposition.X - Startposition.X) * i * Stepwide
            Nextposition.Y = Startposition.Y + (Endposition.Y - Startposition.Y) * i * Stepwide

            If Not IsBallInOval(Nextposition) Then
                Nextposition.X = Endposition.X
                Nextposition.Y = Endposition.Y
            End If

            'Draw the trace of this part of the Orbit permanentely into the BitMap
            MyBmpGraphics.DrawLine(Actualposition, Nextposition,
                                DirectCast(MyColor, SolidBrush).Color, 1)

            'and show the trace by refreshing the Diagram
            MyPicDiagram.Refresh()

            'and draw the new Ball Position
            MyPicGraphics.DrawPoint(Nextposition, MyColor, Size)

            Actualposition.X = Nextposition.X
            Actualposition.Y = Nextposition.Y

        Loop Until i * Stepwide > 1

    End Sub

    'SECTOR CALCULATION

    Private Function IsBallInOval(Ballposition As ClsMathpoint) As Boolean

        Dim OK As Boolean
        Dim m As Decimal = (MyA - MyB) / 2

        If Ballposition.X >= m Then

            'Check the Circle
            OK = Math.Pow(Ballposition.X - m, 2) + Math.Pow(Ballposition.Y, 2) <= MyB * MyB
        Else

            'Check the Ellipse
            OK = Math.Pow((Ballposition.X - m) / MyA, 2) + Math.Pow(Ballposition.Y / MyB, 2) <= 1
        End If

        Return OK

    End Function

    Private Function ParameterOfNextHitPoint(t As Decimal, Phi As Decimal) As Decimal

        't is the Parameter of the Startpoint of the actual part of the Orbit
        'and Phi the direction of the movement relative to the positive x-axis
        'this medhod calculates then the next Hit Point 
        'and returns its Parameter NextT
        'see mathematical documentation

        'u is the Parameter in the Line Equation
        'for the Intersection with the Oval
        Dim u As Decimal

        Dim m As Decimal = (MyA - MyB) / 2

        'The Solution of u gives the next Intersection Point
        Dim IntersectionPoint As New ClsMathpoint
        Dim IsIntersectionFound As Boolean = False

        'StartPoint of the Line
        Dim Startpoint As ClsMathpoint = CalculateBallPositionFromT(t)

        'Ad hoc to simplify the formulas
        Dim p As Decimal = Startpoint.X
        Dim q As Decimal = Startpoint.Y

        'And now according to the mathematical documentation
        'Discriminant
        Dim DA As Decimal = MyB * MyB
        Dim DB As Decimal = MyB * MyB * CDec(((p - m) * Math.Cos(Phi) + q * Math.Sin(Phi)))
        Dim DC As Decimal = MyB * MyB * (CDec(Math.Pow(p - m, 2)) + q * q - MyB * MyB)

        If DB * DB - DA * DC >= 0 Then

            'There is an intersection with the Circle
            'Try with the first solution of the quadratic equation
            u = (-DB + CDec(Math.Sqrt(DB * DB - DA * DC))) / DA

            'Check that u gives not the StartPoint
            If Math.Abs(u) > 0.000001 Then
                IntersectionPoint = CalculateCandidateForIntersection(Startpoint, Phi, u)

                'Is this IntersectionPoint really part of the right half-Circle 
                'and not of the left one
                If IntersectionPoint.X >= m Then
                    IsIntersectionFound = True
                End If
            End If

            If Not IsIntersectionFound Then

                'Try with the second solution of the quadratic equation
                u = (-DB - CDec(Math.Sqrt(DB * DB - DA * DC))) / DA

                'Check that u gives not the StartPoint
                If Math.Abs(u) > 0.000001 Then

                    IntersectionPoint = CalculateCandidateForIntersection(Startpoint, Phi, u)

                    'Is this IntersectionPoint really part of the right half-Circle 
                    'and not of the left one
                    If IntersectionPoint.X >= m Then
                        IsIntersectionFound = True
                    End If
                End If
            End If
        Else
            'There is no Intersection with the Circle
        End If

        If Not IsIntersectionFound Then

            'There must be an intersection with the Ellipse
            'Discriminant
            DA = CDec(Math.Pow(MyA * Math.Sin(Phi), 2) + Math.Pow(MyB * Math.Cos(Phi), 2))
            DB = CDec(MyA * MyA * q * Math.Sin(Phi) + MyB * MyB * (p - m) * Math.Cos(Phi))
            DC = CDec(Math.Pow(MyB * (p - m), 2) + MyA * MyA * (q * q - MyB * MyB))

            If DB * DB - DA * DC >= 0 Then

                'There is an intersection with the Ellipse
                'Try with the first solution of the quadratic equation
                u = (-DB + CDec(Math.Sqrt(DB * DB - DA * DC))) / DA

                'Check that u gives not the StartPoint
                If Math.Abs(u) > 0.000001 Then
                    IntersectionPoint = CalculateCandidateForIntersection(Startpoint, Phi, u)

                    'Is this IntersectionPoint part of the left half-Ellipse?
                    'and not of the right one
                    If IntersectionPoint.X < m Then
                        IsIntersectionFound = True
                    End If
                End If

                If Not IsIntersectionFound Then

                    'Try with the second solution of the quadratic equation
                    u = (-DB - CDec(Math.Sqrt(DB * DB - DA * DC))) / DA

                    'Check that u gives not the StartPoint
                    If Math.Abs(u) > 0.000001 Then
                        IntersectionPoint = CalculateCandidateForIntersection(Startpoint, Phi, u)

                        'Is this IntersectionPoint part of the left half-Ellipse?
                        'and not of the right one
                        If IntersectionPoint.X < m Then
                            IsIntersectionFound = True
                        End If
                    End If
                End If
            Else
                'There is no intersection with the Ellipse
            End If
        End If

        If Not IsIntersectionFound Then
            Throw New ArgumentException(FrmMain.LM.GetString("NoIntersectionPoint") & ", t: " & t.ToString & ", phi: " & Phi.ToString)

            Return 0

        Else

            'Calculate the Parameter T according to the Intersection Point
            Dim nextT = CalculateTFromBallPosition(IntersectionPoint)

            'and make sure that it is in the ParameterValueRange
            MyMathhelper.AngleInNullTwoPi(nextT)

            Return nextT

        End If

    End Function

    Private Function CalculateCandidateForIntersection(Startpoint As ClsMathpoint, phi As Decimal, u As Decimal) As ClsMathpoint

        'the solution of u is set into the line equation
        Dim CandidateForIntersection As New ClsMathpoint With {
            .X = Startpoint.X + u * CDec(Math.Cos(phi)),
            .Y = Startpoint.Y + u * CDec(Math.Sin(phi))
        }

        Return CandidateForIntersection

    End Function

    Private Function CalculateNextPhi(t As Decimal, phi As Decimal) As Decimal

        't is the Parameter of the Startpoint of the actual part of the Orbit
        'and Phi the direction of the movement relative to the positive x-axis
        'this medhod calculates then the next Direction-Angle NextPhi 
        'see mathematical documentation

        'First, we need the angle between tangent in the Hit Point and the positive x-axis
        Dim psi As Decimal = CalculatePsi(t)
        psi = MyMathhelper.AngleInNullTwoPi(psi)

        'This gives the angle NextPhi - see math. doc
        Dim nextPhi As Decimal = 2 * psi - phi
        nextPhi = MyMathhelper.AngleInNullTwoPi(nextPhi)

        'This is the perfect moment to write the protocol
        'of the next part of the Orbit into the Phase Portrait
        If MyPhaseportraitGraphics IsNot Nothing Then
            Dim Alfa As Decimal = CalculateAlfa(t, nextPhi)
            MyPhaseportraitGraphics.DrawPoint(New ClsMathpoint(MyT, Alfa), MyColor, p)
            If MyValueProtocol IsNot Nothing Then
                MyValueProtocol.Items.Add(FrmMain.LM.GetString(
                                          DirectCast(MyColor, SolidBrush).Color.Name) & " t/alfa = " &
                                             MyT.ToString(CultureInfo.CurrentCulture) & "/" & Alfa.ToString(CultureInfo.CurrentCulture))
                MyValueProtocol.Refresh()
            End If
        End If

        Return nextPhi

    End Function

    Public Overrides Function CalculateAlfa(t As Decimal, phi As Decimal) As Decimal

        'This method calculates the next reflection angle Alfa

        'First, we need the angle between tangent in the Hit Point and the positive x-axis
        Dim psi As Decimal = CalculatePsi(t)
        psi = MyMathhelper.AngleInNullTwoPi(psi)

        'and then - see math. doc.
        Dim alfa As Decimal = phi - psi
        alfa = MyMathhelper.AngleInNullTwoPi(alfa)

        Return alfa

    End Function

    Private Function CalculatePsi(t As Decimal) As Decimal

        'This method calculates the angle between tangent in the Hit Point and the positive x-axis
        'and we have different cases
        Dim TempHitpoint As New ClsMathpoint

        t = MyMathhelper.AngleInNullTwoPi(t)
        If (0 <= t And t <= Math.PI / 2) Or (3 * Math.PI / 2 <= t And t < 2 * Math.PI) Then

            'The TempHitPoint is on the Circle
            TempHitpoint.X = -MyB * CDec(Math.Sin(t))
        Else

            'The TempHitPoint is on the Ellipse
            TempHitpoint.X = -MyA * CDec(Math.Sin(t))
        End If

        'in both cases
        TempHitpoint.Y = MyB * CDec(Math.Cos(t))

        Dim psi As Decimal = MyMathhelper.CalculateAngleOfDirection(TempHitpoint.X, TempHitpoint.Y)

        Return psi

    End Function

    Private Function CalculateBallPositionFromT(t As Decimal) As ClsMathpoint

        'this method calculates the Ball position in math. coordinates
        'if the Parameter t is given

        Dim TempMathpoint As New ClsMathpoint
        Dim m As Decimal = (MyA - MyB) / 2

        t = MyMathhelper.AngleInNullTwoPi(t)
        If (0 <= t And t <= Math.PI / 2) Or (3 * Math.PI / 2 <= t And t < 2 * Math.PI) Then

            'The Point is on the Circle
            TempMathpoint.X = m + MyB * CDec(Math.Cos(t))
        Else

            'The Point is on the Ellipse
            TempMathpoint.X = m + MyA * CDec(Math.Cos(t))
        End If

        'in both Cases
        TempMathpoint.Y = MyB * CDec(Math.Sin(t))

        Return TempMathpoint

    End Function

    Private Function CalculateTFromBallPosition(Mathpoint As ClsMathpoint) As Decimal


        'this method calculates the parameter t for a given position of the Ball
        'in math. coordinates

        Dim TempT As Decimal
        Dim m As Decimal = (MyA - MyB) / 2

        If Mathpoint.X >= m Then

            'The Point is on the Circle
            TempT = MyMathhelper.CalculateAngleOfDirection((Mathpoint.X - m), Mathpoint.Y)
        Else

            'The Point is on the Ellipse
            TempT = MyMathhelper.CalculateAngleOfDirection((Mathpoint.X - m) / MyA, Mathpoint.Y / MyB)
        End If

        Return TempT

    End Function

End Class
