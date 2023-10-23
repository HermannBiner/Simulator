'This class contains all Properties of the Billard Ball on an Stadium Billard Table
'and all Methods, this Ball has to know
'including its movement on the table and setting its start position
'therefore, many Balls can be intanced on the Table
'with different colors (to be distinguished)
'See mathematical documentation

'important: this class works with mathematical coordinates
'the Instance of the GraphicTool transforms these in Pixel-Coordinates

'Status Checke

Imports System.Globalization

Public Class ClsStadiumBillardball
    Implements IBillardball

    'The actual position of the Ball is drawned into this PictureBox
    'and shown by the Refresh-Method
    Private MyBillardtable As PictureBox
    Private MyBillardtableGraphics As ClsGraphicTool

    'The permanent Orbit of the Ball is drawned into the BitMap
    Private MyMapBillardtable As Bitmap
    Private MyMapBillardtableGraphics As ClsGraphicTool

    'The ball draws as well into the Phase Portrait
    Private MyPhaseportrait As PictureBox
    Private MyPhaseportraitGraphics As ClsGraphicTool

    'and protocols its Position (Parameter t and reflexion-angle Alfa) into a ListBox
    Private MyParameterListbox As ListBox

    'The class for general mathematical Calculations
    Private ReadOnly MyMathhelper As ClsMathhelperBillard

    'The Value Ranges of the relevant Parameters
    'Reflexion Angle between the Ball-Movement-Vector and the Tangent in the Hit Point
    'it is in ]0, pi[
    Private ReadOnly MyAlfaValuerange As ClsInterval

    'Value Range of the Parameter t that defines the Hit Point
    'here it is the distance between the Hit Point and a Zero Point on the Border of the Table
    Private MyTValuerange As ClsInterval

    'The Value Range of the Mathematical Coordinates - Standard is the Interval [-1,1]
    'and the Coordinate System as Square [-1,1] x [-1,1]
    Private ReadOnly MyStadiumValuerange As ClsInterval

    'Parameter that defines the actual hit point
    'see mathematical documentation
    Private MyT As Decimal

    'This is the angle between the actual moving-direction and the positive x-axis
    Private MyPhi As Decimal

    'Profile of the Stadium
    'a and b are the half sides of the rectangle in the middle of the stadium
    'the corner points of this rectangle have the coordinates (+-a, +-b)
    'and the half circles on the border of the stadium the radius b
    Private a As Decimal
    Private b As Decimal

    'The parameter C defines the profile of the stadium: b = C*a
    Private MyC As Decimal

    'Properties of the Ball
    Private MyColor As Brush

    'Color of the Orbit
    Private MyTrackcolor As Color

    'Size in about pixel units
    Private MySize As Integer
    Private MySpeed As Integer = 5

    'Start Position of the Ball, set by the User
    Private UserStartposition As ClsMathpoint
    Private UserEndposition As ClsMathpoint

    'Control ot Setting these Start Parameters
    Private MyStartpositionSet As Boolean
    Private MyStartangleSet As Boolean

    'SECTOR INITIALIZATION

    Public Sub New()

        MyMathhelper = New ClsMathhelperBillard
        MyStadiumValuerange = New ClsInterval(-1, 1)
        MyAlfaValuerange = New ClsInterval(0, CDec(Math.PI))

        'The ValueRange of MyT is only known, after a, b and C are set

        MyT = 0

    End Sub

    WriteOnly Property Billardtable As PictureBox Implements IBillardball.Billardtable
        Set(value As PictureBox)
            MyBillardtable = value
            MyBillardtableGraphics = New ClsGraphicTool(MyBillardtable, MyStadiumValuerange, MyStadiumValuerange)
        End Set
    End Property

    WriteOnly Property MapBillardtable As Bitmap Implements IBillardball.MapBillardtable
        Set(value As Bitmap)
            MyMapBillardtable = value
            MyMapBillardtableGraphics = New ClsGraphicTool(MyMapBillardtable, MyStadiumValuerange, MyStadiumValuerange)
        End Set
    End Property

    WriteOnly Property C As Decimal Implements IBillardball.C
        Set(value As Decimal)

            MyC = value

            'Because of better visibility we set a = 0.95 (instead of 1)
            a = CDec(0.95) / (1 + MyC)
            b = MyC * a

            'Now, the perimeter of the Billard Table is known and that is the Value Range of T
            MyTValuerange = New ClsInterval(0, 4 * a + 2 * b * CDec(Math.PI))

            'Standard Start Point is (0/b)
            UserStartposition = New ClsMathpoint(a, b)
            DrawUserStartposition(False)

            'the final EndPosition is set later
            UserEndposition = New ClsMathpoint(-a, -b)

        End Set
    End Property

    WriteOnly Property Phaseportrait As PictureBox Implements IBillardball.Phaseportrait
        Set(value As PictureBox)
            MyPhaseportrait = value
            MyPhaseportraitGraphics = New ClsGraphicTool(MyPhaseportrait, MyTValuerange, MyAlfaValuerange)
        End Set
    End Property

    WriteOnly Property ParameterProtocol As ListBox Implements IBillardball.ParameterProtocol
        Set(value As ListBox)
            MyParameterListbox = value
        End Set
    End Property

    WriteOnly Property Ballcolor As Brush Implements IBillardball.Ballcolor
        Set(value As Brush)
            MyColor = value
            MyTrackcolor = DirectCast(MyColor, SolidBrush).Color
        End Set
    End Property

    WriteOnly Property Ballsize As Integer Implements IBillardball.Ballsize
        Set(value As Integer)
            MySize = value
        End Set
    End Property

    WriteOnly Property Ballspeed As Integer Implements IBillardball.Ballspeed
        Set(value As Integer)
            MySpeed = value
        End Set
    End Property

    Property IsStartpositionSet As Boolean Implements IBillardball.IsStartpositionSet
        Get
            IsStartpositionSet = MyStartpositionSet
        End Get
        Set(value As Boolean)
            MyStartpositionSet = value
        End Set
    End Property

    Property IsStartangleSet As Boolean Implements IBillardball.IsStartangleSet
        Get
            IsStartangleSet = MyStartangleSet
        End Get
        Set(value As Boolean)
            MyStartangleSet = value
        End Set
    End Property

    Property Startparameter As Decimal Implements IBillardball.Startparameter
        Get
            Startparameter = MyT
        End Get

        'The user can set the Startparameter t also manually (when not setting it by the mouse)
        'and transmit this value to the Ball
        Set(value As Decimal)
            MyT = value

            'and then, the Startposition according to the mathematical documentation is
            Dim StartPointBall As ClsMathpoint = CalculateMathPointFromT(MyT)
            UserStartposition.X = StartPointBall.X
            UserStartposition.Y = StartPointBall.Y

            DrawUserStartposition(True)
            MyStartpositionSet = True
        End Set
    End Property

    WriteOnly Property Startangle As Decimal Implements IBillardball.Startangle

        Set(value As Decimal)

            'In addition to the Startparameter t,
            'the angle of the first  reflection is necessary as well
            'to start the movement of the Ball
            Dim alfa As Decimal = value

            'first, we calculate the angle between tangent in the hit point
            'and the positive xaxis
            Dim psi As Decimal = CalculatePsi(MyT)
            psi = MyMathhelper.AngleInNullTwoPi(psi)

            'Now the angle between the next moving-direction and the positive x-axis is:
            MyPhi = psi + alfa

            'With these parameters, we can calculate the next Hit Point
            'and its Parameter NextT
            Dim nextT As Decimal = ParameterOfNextHitpoint(MyT, MyPhi)

            Dim Userposition As ClsMathpoint = CalculateMathPointFromT(nextT)
            UserEndposition.X = Userposition.X
            UserEndposition.Y = Userposition.Y
            DrawUserEndposition(True)
            MyStartangleSet = True

        End Set
    End Property

    'SECTOR SETTING STARTPOSITION AND STARTANGLE OF THE BALL

    Public Function SetAndDrawUserStartposition(Mouseposition As Point, definitive As Boolean) As Decimal _
        Implements IBillardball.SetAndDrawUserStartposition

        Dim t As Decimal = SetUserStartposition(Mouseposition)
        DrawUserStartposition(definitive)

        'we need t for the Protocol
        Return t

    End Function

    Private Function SetUserStartposition(Mouseposition As Point) As Decimal

        'Position of the Ball in math. coordinates, set by the Mouseposition in Pixel Coordinates
        'this startposition is still on the mouseposition (and not on the border of the Stadium)
        UserStartposition = MyMapBillardtableGraphics.PixelToMathpoint(Mouseposition)

        'Parameter of this Startpoint
        Dim t As Decimal = CalculateTFromMathPoint(UserStartposition)
        MyT = t

        'Now, the Startposition is set on the border of the Ellipse
        Dim StartpointBall As ClsMathpoint = CalculateMathPointFromT(t)
        UserStartposition.X = StartpointBall.X
        UserStartposition.Y = StartpointBall.Y

        Return t

    End Function

    Private Sub DrawUserStartposition(definitive As Boolean)
        If definitive Then

            'The Ball is drawn permanentely into the BitMap
            MyMapBillardtableGraphics.DrawPoint(UserStartposition, MyColor, MySize)
            MyBillardtable.Refresh()
        Else

            'The actual Ball is drawn into PicDiagram
            MyBillardtable.Refresh()
            MyBillardtableGraphics.DrawPoint(UserStartposition, MyColor, MySize)
        End If
    End Sub

    Public Function SetAndDrawUserEndposition(Mouseposition As Point, definitive As Boolean) As Decimal _
        Implements IBillardball.SetAndDrawUserEndposition

        'The Endposition is definied by the angle phi of the next moving direction
        Dim phi As Decimal = SetUserEndposition(Mouseposition)

        DrawUserEndposition(definitive)

        'We need Phi to calculate Alfa and the Procotol in the Phase Portrait
        Return phi

    End Function

    Private Function SetUserEndposition(Mouseposition As Point) As Decimal

        'The Endposition of the Ball in math. coordinates
        'is just equal to the Mouseposition in Pixels
        UserEndposition = MyMapBillardtableGraphics.PixelToMathpoint(Mouseposition)

        'Now, we need the Parameter t according to this Point
        Dim t As Decimal = CalculateTFromMathPoint(UserEndposition)

        'and the coordinates of the EndPoint of this part of the Orbit
        Dim EndpointBall As ClsMathpoint = CalculateMathPointFromT(t)
        UserEndposition.X = EndpointBall.X
        UserEndposition.Y = EndpointBall.Y

        'With this Endposition, we calculate the Angle phi
        'that is the Angle of the next moving-direction and the positive x-axis
        Dim deltaX As Decimal = UserEndposition.X - UserStartposition.X
        Dim deltaY As Decimal = UserEndposition.Y - UserStartposition.Y
        Dim phi = MyMathhelper.CalculateAngleOfDirection(deltaX, deltaY)

        Return phi

    End Function

    Private Sub DrawUserEndposition(definitive As Boolean)

        If definitive Then

            'The Endposition of the Ball is drawn permanentely into the BitMap
            MyMapBillardtableGraphics.DrawPoint(UserEndposition, MyColor, MySize)
            MyBillardtable.Refresh()

            'The Track of the first Hit of the Ball is drawn only into the PicDiagram
            MyBillardtableGraphics.DrawLine(UserStartposition, UserEndposition, MyTrackcolor, 1)
        Else
            MyBillardtable.Refresh()

            'The actual Ballposition is dran only into the PicDiagram
            MyBillardtableGraphics.DrawPoint(UserEndposition, MyColor, MySize)
            MyBillardtableGraphics.DrawLine(UserStartposition, UserEndposition, MyTrackcolor, 1)
        End If

    End Sub

    'SECTOR ITERATION

    Public Sub Iteration(NumberOfSteps As Integer) Implements IBillardball.Iteration

        'Startpoint of the actual part of the Orbit
        Dim Startpoint As New ClsMathpoint

        'Parameter of the next Enpoint of the actual part of the Orbit
        Dim nextT As Decimal

        'and the according EndPoint
        Dim Endpoint As New ClsMathpoint

        Dim i As Integer

        For i = 1 To NumberOfSteps

            'MyT is the Parameter ot the StartPoint of the actual part of the Orbit
            Dim TempStartpoint As ClsMathpoint = CalculateMathPointFromT(MyT)

            Startpoint.X = TempStartpoint.X
            Startpoint.Y = TempStartpoint.Y

            'NextT is the Parameter of the EndPoint of the actual part of the Orbit
            nextT = ParameterOfNextHitpoint(MyT, MyPhi)
            Dim TempEndpoint As ClsMathpoint = CalculateMathPointFromT(nextT)
            Endpoint.X = TempEndpoint.X
            Endpoint.Y = TempEndpoint.Y

            'The Ball moves between these Points
            MoveOnOrbitPart(Startpoint, Endpoint)

            'The EndPoint is then the StartPoint of the following part of the Orbit
            MyT = nextT
            Startpoint.X = Endpoint.X
            Startpoint.Y = Endpoint.Y

            'in addition, we calculate the angle of the following movement
            MyPhi = CalculateNextPhi(MyT, MyPhi)

        Next i

    End Sub

    'SECTOR BALL MOVEMENT

    Private Sub MoveOnOrbitPart(Startposition As ClsMathpoint, Endposition As ClsMathpoint)

        Dim ActualPosition As New ClsMathpoint With {
            .X = Startposition.X,
            .Y = Startposition.Y
        }

        Dim Nextposition As New ClsMathpoint

        Dim i As Integer = 0

        'The following StepWide was defined by an Experiment
        Dim Stepwide As Decimal = MyStadiumValuerange.IntervalWidth * MySpeed / 1000

        Do
            i += 1
            Nextposition.X = Startposition.X + (Endposition.X - Startposition.X) * i * Stepwide
            Nextposition.Y = Startposition.Y + (Endposition.Y - Startposition.Y) * i * Stepwide

            If Not IsBallOnStadium(Nextposition) Then
                Nextposition.X = Endposition.X
                Nextposition.Y = Endposition.Y
            End If

            'Draw the trace of this part of the Orbit permanentely into the BitMap
            MyMapBillardtableGraphics.DrawLine(ActualPosition, Nextposition, MyTrackcolor, 1)

            'and show the trace by refreshing the Diagram
            MyBillardtable.Refresh()

            'and draw the new Ball Position
            MyBillardtableGraphics.DrawPoint(Nextposition, MyColor, MySize)

            ActualPosition.X = Nextposition.X
            ActualPosition.Y = Nextposition.Y

        Loop Until i * Stepwide > 1

    End Sub

    'SECTOR CALCULATION

    Private Function IsBallOnStadium(Position As ClsMathpoint) As Boolean

        Dim OK As Boolean = False

        'Is the Ball in the Rectangle?
        If -a <= Position.X And Position.X <= a Then
            If -b <= Position.Y And Position.Y <= b Then
                OK = True
            End If
        End If

        'Is the Ball in the left half-Circle
        If Not OK Then
            If -a - b <= Position.Y And Position.X <= a Then
                If Position.X * Position.X + Position.Y * Position.Y <= b * b Then
                    OK = True
                End If
            End If
        End If

        'Is the Ball in the right half-Circle?
        If Not OK Then
            If a <= Position.X And Position.X <= a + b Then
                If Position.X * Position.X + Position.Y * Position.Y <= b * b Then
                    OK = True
                End If
            End If
        End If

        Return OK

    End Function

    Private Function ParameterOfNextHitpoint(s As Decimal, phi As Decimal) As Decimal

        't is the Parameter of the Startpoint of the actual part of the Orbit
        'and Phi the direction of the movement
        'this medhod calculates then the next Hit Point 
        'and returns its Parameter NextT
        'see mathematical documentation

        'Make sure that Phi is in [0, 2*pi]
        phi = MyMathhelper.AngleInNullTwoPi(phi)

        'The Ball is moving on a straight line (its Orbit) through the startpoint
        'and the angle Phi between this line and the positive x-axis
        Dim Startpoint As ClsMathpoint = CalculateMathPointFromT(s)

        Dim Intersection As New ClsMathpoint
        Dim IsIntersectionFound As Boolean = False
        Dim nextT As Decimal

        'See the mathematical documentation for the following calculation
        't is the Parameter of the equation of the line
        Dim t As Decimal

        If phi <> 0 And Math.Abs(phi - Math.PI) > 0 Then

            'the Orbit intersects the line y = b
            t = CDec((b - Startpoint.Y) / Math.Sin(phi))

            'if the x-coordinate is in [-a,a], then the intersection is found
            'but we have to exclude t = 0 (the StartPoint)
            Intersection.X = Startpoint.X + t * CDec(Math.Cos(phi))
            If Math.Abs(Intersection.X) <= a And Math.Abs(t) > 0.0000001 Then
                Intersection.Y = b
                IsIntersectionFound = True
            Else

                'the Orbit intersects the line y = -b
                t = CDec((-b - Startpoint.Y) / Math.Sin(phi))

                'if the x-coordinate is in [-a,a], then the intersection is found
                'but we have to exclude t = 0 (the StartPoint)
                Intersection.X = Startpoint.X + t * CDec(Math.Cos(phi))
                If Math.Abs(Intersection.X) <= a And Math.Abs(t) > 0.0000001 Then
                    Intersection.Y = -b
                    IsIntersectionFound = True
                End If
            End If
        End If

        If Not IsIntersectionFound Then
            Dim TempB As Decimal
            Dim TempC As Decimal

            'The Orbit intersects the right half-Circle
            TempB = CDec((Startpoint.X - a) * Math.Cos(phi) + Startpoint.Y * Math.Sin(phi))
            TempC = (Startpoint.X - a) * (Startpoint.X - a) + Startpoint.Y * Startpoint.Y - b * b

            'The discriminant must be positive
            If TempB * TempB - TempC >= 0 Then

                'first try for a solution of the quadratic equation
                t = -TempB + CDec(Math.Sqrt(TempB * TempB - TempC))
                Intersection.X = Startpoint.X + t * CDec(Math.Cos(phi))
                If Intersection.X > a And Math.Abs(t) > 0.0000001 Then
                    Intersection.Y = Startpoint.Y + t * CDec(Math.Sin(phi))
                    IsIntersectionFound = True
                Else

                    'second try for a solution of the quadratic equation
                    t = -TempB - CDec(Math.Sqrt(TempB * TempB - TempC))
                    Intersection.X = Startpoint.X + t * CDec(Math.Cos(phi))
                    If Intersection.X > a And Math.Abs(t) > 0.0000001 Then
                        Intersection.Y = Startpoint.Y + t * CDec(Math.Sin(phi))
                        IsIntersectionFound = True
                    End If
                End If
            End If

            If Not IsIntersectionFound Then

                'The Orbit intersects the left half-Circle
                TempB = CDec((Startpoint.X + a) * Math.Cos(phi) + Startpoint.Y * Math.Sin(phi))
                TempC = (Startpoint.X + a) * (Startpoint.X + a) + Startpoint.Y * Startpoint.Y - b * b

                'The discriminant must be positive
                If TempB * TempB - TempC >= 0 Then

                    'first try for a solution of the quadratic equation
                    t = -TempB + CDec(Math.Sqrt(TempB * TempB - TempC))
                    Intersection.X = Startpoint.X + t * CDec(Math.Cos(phi))
                    If Intersection.X < -a And Math.Abs(t) > 0.0000001 Then
                        Intersection.Y = Startpoint.Y + t * CDec(Math.Sin(phi))
                        IsIntersectionFound = True
                    Else

                        'second try for a solution of the quadratic equation
                        t = -TempB - CDec(Math.Sqrt(TempB * TempB - TempC))
                        Intersection.X = Startpoint.X + t * CDec(Math.Cos(phi))
                        If Intersection.X < -a And Math.Abs(t) > 0.0000001 Then
                            Intersection.Y = Startpoint.Y + t * CDec(Math.Sin(phi))
                            IsIntersectionFound = True
                        End If
                    End If
                End If
            End If
        End If

        'Note to Math.Abs(t) > 0.0000001
        'if we would write Math.Abs(t) > 0
        'then, it could be possible tht for very small t the last hit point is found
        'as solution of the intersect equation
        'the limit 0.0000001 is bigger than the rounding-effects
        'but smaller than the pixel-unit

        If Not IsIntersectionFound Then
            Throw New ArgumentException(Main.LM.GetString("NoIntersectionPoint"))
        Else
            nextT = CalculateTFromMathPoint(Intersection)
        End If

        Return nextT

    End Function

    Private Function CalculateNextPhi(t As Decimal, phi As Decimal) As Decimal

        't is the Parameter of the Startpoint of the actual part of the Orbit
        'and Phi the direction of the movement
        'this medhod calculates then the next Direction-Angle NextPhi 
        'and returns its Parameter ts
        'see mathematical documentation

        'First, we need the angle between tangent in the Hit Point and the positive x-axis
        Dim psi As Decimal = CalculatePsi(t)
        psi = MyMathhelper.AngleInNullTwoPi(psi)

        'This gives the angle NextPhi - see math. doc.
        Dim nextPhi As Decimal = 2 * psi - phi
        nextPhi = MyMathhelper.AngleInNullTwoPi(nextPhi)

        'This is the perfect moment to write the protocol
        'of the next part of the Orbit into the Phase Portrait
        If MyPhaseportraitGraphics IsNot Nothing Then
            Dim Alfa As Decimal = CalculateAlfa(t, nextPhi)
            MyPhaseportraitGraphics.DrawPoint(New ClsMathpoint(MyT, Alfa), MyColor, 2)
            MyParameterListbox.Items.Add(MyTrackcolor.Name & " s/phi = " & MyT.ToString(CultureInfo.CurrentCulture) & "/" & Alfa.ToString(CultureInfo.CurrentCulture))
            MyParameterListbox.Refresh()
        End If

        Return nextPhi

    End Function

    Public Function CalculateAlfa(t As Decimal, phi As Decimal) As Decimal Implements IBillardball.CalculateAlfa

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
        Dim psi As Decimal

        Select Case True
            Case t <= 2 * a
                psi = CDec(Math.PI)
            Case t > 2 * a And t < 2 * a + b * CDec(Math.PI)
                Dim angle As Decimal = (t - 2 * a) / b
                psi = CDec(Math.PI) + angle
            Case t >= 2 * a + b * CDec(Math.PI) And t <= 4 * a + b * CDec(Math.PI)
                psi = 0
            Case Else
                Dim angle As Decimal = (t - 4 * a - b * CDec(Math.PI)) / b
                psi = angle
        End Select

        Return psi

    End Function

    Private Function CalculateMathPointFromT(t As Decimal) As ClsMathpoint

        'this method calculates the Ball position in math. coordinates
        'if the Parameter t is given

        Dim Ballpoint As New ClsMathpoint(0, 0)

        t = t Mod (4 * a + 2 * b * CDec(Math.PI))

        Select Case True
            Case t <= 2 * a
                Ballpoint.X = a - t
                Ballpoint.Y = b
            Case t > 2 * a And t < 2 * a + b * CDec(Math.PI)
                Dim Angle As Decimal = (t - 2 * a) / b
                Ballpoint.X = -a - b * CDec(Math.Sin(Angle))
                Ballpoint.Y = b * CDec(Math.Cos(Angle))
            Case t >= 2 * a + b * CDec(Math.PI) And t <= 4 * a + b * CDec(Math.PI)
                Ballpoint.X = t - 3 * a - b * CDec(Math.PI)
                Ballpoint.Y = -b
            Case Else
                Dim Angle As Decimal = (t - 4 * a - b * CDec(Math.PI)) / b
                Ballpoint.X = a + b * CDec(Math.Sin(Angle))
                Ballpoint.Y = -b * CDec(Math.Cos(Angle))
        End Select

        Return Ballpoint

    End Function

    Private Function CalculateTFromMathPoint(Mathpoint As ClsMathpoint) As Decimal

        'this method calculates the parameter t for a given position of the Ball
        'in math. coordinates

        Dim TempT As Decimal

        If -a <= Mathpoint.X And Mathpoint.X <= a Then

            'Set the Ball on the Border of the rectangle
            If Mathpoint.Y >= 0 Then

                'Is the position above the rectangle?
                TempT = a - Mathpoint.X
            Else

                'Is the position below the rectangle?
                TempT = 3 * a + b * CDec(Math.PI) + Mathpoint.X
            End If
        Else
            Dim Sinevalue As Decimal
            If Mathpoint.X < -a Then

                'Set the Ball on the Border of the left half-Circle
                Sinevalue = Math.Min(1, (-Mathpoint.X - a) / b)
                If Mathpoint.Y >= 0 Then

                    'Above x-axis
                    TempT = 2 * a + b * CDec(Math.Asin(Sinevalue))
                Else

                    'Below x-axis
                    TempT = 2 * a + b * (CDec(Math.PI) - CDec(Math.Asin(Sinevalue)))
                End If
            Else

                'Set the Ball on the Border of the right half-Circle
                Sinevalue = Math.Min(1, (Mathpoint.X - a) / b)
                If Mathpoint.Y <= 0 Then

                    'below x-axis
                    TempT = 4 * a + b * (CDec(Math.PI) + CDec(Math.Asin(Sinevalue)))
                Else

                    'above x-axis
                    TempT = 4 * a + b * (2 * CDec(Math.PI) - CDec(Math.Asin(Sinevalue)))
                End If
            End If
        End If

        Return TempT

    End Function
End Class
