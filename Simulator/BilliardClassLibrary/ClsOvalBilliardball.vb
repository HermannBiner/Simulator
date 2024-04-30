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
    Implements IBilliardball, ICDiagramBilliard

    'The actual position of the Ball is drawn into this PictureBox
    'and shown by the Refresh-Method
    Private MyBilliardtable As PictureBox
    Private MyBilliardtableGraphics As ClsGraphicTool

    'The permanent Orbit of the Ball is drawn into the BitMap
    Private MyMapBilliardtable As Bitmap '
    Private MyMapBilliardtableGraphics As ClsGraphicTool

    'The ball draws as well into the Phase Portrait
    Private MyPhaseportrait As PictureBox
    Private MyPhaseportraitGraphics As ClsGraphicTool

    'and protocols its Position (Parameter t and reflexion-angle Alfa) into a ListBox
    Private MyParameterlistbox As ListBox

    'The Value Ranges of the relevant Parameters
    'Reflexion Angle between the Ball-Movement-Vector and the Ellipse-Tangent in the Hit Point
    'the angle is in ]0, pi[
    Private ReadOnly MyAlfaValuerange As ClsInterval

    'Value Range of the Parameter t that defines the Hit Point, in [0, 2*pi[
    Private ReadOnly MyTValuerange As ClsInterval

    'Collection of the two ValueRanges for the C-Diagram
    Private ReadOnly MyValueParameters As List(Of ClsValueParameter)

    'The Value Range of the Mathematical Coordinates - Standard is the Interval [-1,1]
    'and the Coordinate System as Square [-1,1] x [-1,1]
    Private ReadOnly MyMathValuerange As ClsInterval

    'The class for general mathematical Calculations
    Private ReadOnly MyMathhelper As ClsMathhelperBilliard

    'Properties of the Ball
    Private MyColor As Brush

    'Color of the Orbit
    Private MyTrackcolor As Color

    'Size in pixel units
    Private MySize As Integer
    Private MySpeed As Integer = 5

    'Parameter that defines the actual hit point
    'see mathematical documentation
    Private MyT As Decimal

    'This is the angle between the actual moving-direction and the positive x-axis
    Private MyPhi As Decimal

    'Profile of the Oval
    'Major axis of the elliptic part
    Private a As Decimal
    'Minor axis and radius of the circle
    Private b As Decimal
    'Relation c = b:a
    Private MyC As Decimal
    'x-coordinate of the MidPoint of the Circle and the Ellipse
    Private m As Decimal

    'Size of the point in the phase portrait
    Const p As Integer = 2

    'Start Position of the Ball, set by the User
    Private UserStartposition As ClsMathpoint
    Private UserEndposition As ClsMathpoint

    'Control ot Setting these Start Parameters
    Private MyStartpositionSet As Boolean
    Private MyStartangleSet As Boolean

    'SECTOR INITIALIZATION

    Public Sub New()

        MyMathhelper = New ClsMathhelperBilliard
        MyMathValuerange = New ClsInterval(-1, 1)
        MyAlfaValuerange = New ClsInterval(0, CDec(Math.PI))
        MyTValuerange = New ClsInterval(0, CDec(Math.PI * 2))

        MyValueParameters = New List(Of ClsValueParameter)

        Dim ValueRange As ClsValueParameter
        ValueRange = New ClsValueParameter(1, "t-Parameter", MyTValuerange)
        MyValueParameters.Add(ValueRange)

        ValueRange = New ClsValueParameter(2, "Angle Alfa", MyAlfaValuerange)
        MyValueParameters.Add(ValueRange)

        'Default
        MyC = CDec(0.5)

    End Sub

    WriteOnly Property Billiardtable As PictureBox Implements IBilliardball.Billiardtable
        Set(value As PictureBox)
            MyBilliardtable = value
            MyBilliardtableGraphics = New ClsGraphicTool(MyBilliardtable, MyMathValuerange, MyMathValuerange)
        End Set
    End Property

    WriteOnly Property MapBilliardtable As Bitmap Implements IBilliardball.MapBilliardtable
        Set(value As Bitmap)
            MyMapBilliardtable = value
            MyMapBilliardtableGraphics = New ClsGraphicTool(MyMapBilliardtable, MyMathValuerange, MyMathValuerange)
        End Set
    End Property

    Property C As Decimal Implements IBilliardball.C
        Get
            C = MyC
        End Get
        Set(value As Decimal)
            MyC = value

            'for better visibility, a + b is set = 1.9 (instead of 2)
            a = CDec(1.9 * Math.Min(1 / (1 + MyC), 1 / (2 * MyC)))
            b = MyC * a
            m = (a - b) / 2

            'Standard StartPoint is (m, b)
            UserStartposition = New ClsMathpoint((a - b) / 2, b)
            DrawUserStartposition(False)

            'and Endposition (a+b,0)
            UserEndposition = New ClsMathpoint(a + b, 0)

            'these Parameters are set later by moving the Mouse

        End Set
    End Property

    Property CParameter As Decimal Implements ICDiagramBilliard.CParameter
        Get
            CParameter = MyC
        End Get
        Set(value As Decimal)
            MyC = value

            'for better visibility, a + b is set = 1.9 (instead of 2)
            a = CDec(1.9 * Math.Min(1 / (1 + MyC), 1 / (2 * MyC)))
            b = MyC * a
            m = (a - b) / 2

        End Set
    End Property

    WriteOnly Property Phaseportrait As PictureBox Implements IBilliardball.Phaseportrait
        Set(value As PictureBox)
            MyPhaseportrait = value
            MyPhaseportraitGraphics = New ClsGraphicTool(MyPhaseportrait, MyTValuerange, MyAlfaValuerange)
        End Set
    End Property

    WriteOnly Property ParameterProtocol As ListBox Implements IBilliardball.ParameterProtocol
        Set(value As ListBox)
            MyParameterlistbox = value
        End Set
    End Property

    WriteOnly Property Ballcolor As Brush Implements IBilliardball.Ballcolor
        Set(value As Brush)
            MyColor = value
            MyTrackcolor = DirectCast(MyColor, SolidBrush).Color
        End Set
    End Property

    WriteOnly Property Ballsize As Integer Implements IBilliardball.Ballsize
        Set(value As Integer)
            MySize = value
        End Set
    End Property

    WriteOnly Property Ballspeed As Integer Implements IBilliardball.Ballspeed
        Set(value As Integer)
            MySpeed = value
        End Set
    End Property

    Property Startparameter As Decimal Implements IBilliardball.Startparameter
        Get
            Startparameter = MyT
        End Get

        'The user can set the Startparameter t also manually (when not setting it by the mouse)
        'and transmit this value to the Ball
        Set(value As Decimal)
            MyT = value

            'and then, the Startposition according to the mathematical documentation is:
            Dim TempMathpoint As ClsMathpoint = CalculateBallPositionFromT(MyT)

            UserStartposition.X = TempMathpoint.X
            UserStartposition.Y = TempMathpoint.Y
            DrawUserStartposition(True)
            MyStartpositionSet = True

        End Set
    End Property

    WriteOnly Property Startangle As Decimal Implements IBilliardball.Startangle

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

            'The Position von the next Hit Point is the Endposition
            'of this part of the Ball-Movement
            Dim Userposition As ClsMathpoint = CalculateBallPositionFromT(nextT)

            UserEndposition.X = Userposition.X
            UserEndposition.Y = Userposition.Y
            DrawUserEndPosition(True)

            MyStartangleSet = True

        End Set
    End Property

    Property IsStartpositionSet As Boolean Implements IBilliardball.IsStartpositionSet
        Get
            IsStartpositionSet = MyStartpositionSet
        End Get
        Set(value As Boolean)
            MyStartpositionSet = value
        End Set
    End Property

    Property IsStartangleSet As Boolean Implements IBilliardball.IsStartangleSet
        Get
            IsStartangleSet = MyStartangleSet
        End Get
        Set(value As Boolean)
            MyStartangleSet = value
        End Set
    End Property

    ReadOnly Property CParameterRange As ClsInterval Implements ICDiagramBilliard.CParameterRange
        Get
            CParameterRange = New ClsInterval(CDec(0.5), CDec(2))
        End Get
    End Property

    ReadOnly Property ValueParameters As List(Of ClsValueParameter) Implements ICDiagramBilliard.ValueParameters
        Get
            ValueParameters = MyValueParameters
        End Get
    End Property

    Public Sub DrawBilliardTable() Implements IBilliardball.DrawBilliardtable

        With MyMapBilliardtableGraphics
            'Coordinate System
            .DrawCoordinateSystem(New ClsMathpoint(0, 0), Color.Black, 1)

            'Special Points
            'MidPoint of the Circle and the Ellipse
            Dim Midpoint As New ClsMathpoint((a - b) / 2, 0)

            'Focal Point of the Ellipse
            Dim Focalpoint As ClsMathpoint
            If a >= b Then
                Focalpoint = New ClsMathpoint(Midpoint.X - CDec(Math.Sqrt(a * a - b * b)), 0) ''linker Brennpunkt
            Else
                Focalpoint = New ClsMathpoint(Midpoint.X, CDec(Math.Sqrt(b * b - a * a)))
            End If

            'Draw these points
            .DrawPoint(Midpoint, Brushes.Blue, 2)
            .DrawPoint(Focalpoint, Brushes.Blue, 2)

            'Draw half-Circle
            .DrawCircleArc(Midpoint, b, CDec(3 * Math.PI / 2), CDec(Math.PI), Color.Blue, 1)

            'Draw half-Ellipse
            'Rectangle for the Ellipse bottom-left
            Dim BottomLeft As New ClsMathpoint(Midpoint.X - a, -b)

            'Rectangle for the Ellipse top-right
            Dim TopRight As New ClsMathpoint(Midpoint.X + a, b)

            .DrawEllipticArc(BottomLeft, TopRight, CDec(Math.PI / 2), CDec(Math.PI), Color.Blue, 1)
        End With


    End Sub

    Public Sub ClearBilliardTable() Implements IBilliardball.ClearBilliardTable
        MyMapBilliardtableGraphics.Clear(Color.White)
    End Sub

    'SECTOR SETTING STARTPOSITION AND STARTANGLE OF THE BALL

    Public Function SetAndDrawUserStartposition(Mouseposition As Point, definitive As Boolean) As Decimal _
        Implements IBilliardball.SetAndDrawUserStartposition

        Dim t As Decimal = SetUserStartposition(Mouseposition)
        DrawUserStartposition(definitive)

        'we need t for the Protocol
        Return t

    End Function

    Private Function SetUserStartposition(Mouseposition As Point) As Decimal

        'Position of the Ball in math. coordinates, set by the Mouseposition in Pixel Coordinates
        'this startposition is still at the mouseposition (and not on the border of the Ellipse)
        UserStartposition = MyMapBilliardtableGraphics.PixelToMathpoint(Mouseposition)

        'Parameter of this Startpoint
        Dim t As Decimal = MyMathhelper.CalculateAngleOfDirection(UserStartposition.X, UserStartposition.Y)

        'Now, the Startposition is set on the border of the Oval
        Dim StartpointBall As ClsMathpoint = CalculateBallPositionFromT(t)
        UserStartposition.X = StartpointBall.X
        UserStartposition.Y = StartpointBall.Y
        MyT = t

        Return t

    End Function

    Private Sub DrawUserStartposition(definitive As Boolean)
        If definitive Then

            'The Ball is drawn permanentely into the BitMap
            MyMapBilliardtableGraphics.DrawPoint(UserStartposition, MyColor, MySize)
            MyBilliardtable.Refresh()
        Else

            'The actual and still moving Ball is drawn into PicDiagram
            MyBilliardtable.Refresh()
            MyBilliardtableGraphics.DrawPoint(UserStartposition, MyColor, MySize)
        End If
    End Sub

    Public Function SetAndDrawUserEndposition(Mouseposition As Point, definitive As Boolean) As Decimal _
        Implements IBilliardball.SetAndDrawUserEndposition

        'The Endposition is definied by the angle phi of the next moving direction
        Dim phi As Decimal = SetUserEndposition(Mouseposition)

        DrawUserEndPosition(definitive)

        'We need Phi to calculate Alfa and for the Procotol in the Phase Portrait
        Return phi

    End Function

    Private Function SetUserEndposition(Mouseposition As Point) As Decimal

        'The Endposition of the Ball in math. coordinates
        'is just equal to the Mouseposition in Pixels
        UserEndposition = MyMapBilliardtableGraphics.PixelToMathpoint(Mouseposition)

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
            MyMapBilliardtableGraphics.DrawPoint(UserEndposition, MyColor, MySize)
            MyBilliardtable.Refresh()

            'The Track of the first Hit of the Ball is drawn only into the PicDiagram
            MyBilliardtableGraphics.DrawLine(UserStartposition, UserEndposition, MyTrackcolor, 1)
        Else
            MyBilliardtable.Refresh()

            'The actual Ballposition is drawn only into the PicDiagram
            MyBilliardtableGraphics.DrawPoint(UserEndposition, MyColor, MySize)
            MyBilliardtableGraphics.DrawLine(UserStartposition, UserEndposition, MyTrackcolor, 1)
        End If

    End Sub

    'SECTOR ITERATION

    Public Sub Iteration(NumberOfSteps As Integer) Implements IBilliardball.Iteration

        'Startpoint of the actual part of the Orbit
        Dim Startpoint As New ClsMathpoint

        'Parameter of the next Endpoint of the actual part of the Orbit
        Dim nextT As Decimal

        'and the according EndPoint
        Dim Endpoint As New ClsMathpoint

        Dim i As Integer

        For i = 1 To NumberOfSteps

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
        Next i

    End Sub

    Public Function GetNextPoint(ActualPoint As ClsValuePair) As ClsValuePair Implements ICDiagramBilliard.GetNextPoint

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
            MyMapBilliardtableGraphics.DrawLine(Actualposition, Nextposition, MyTrackcolor, 1)

            'and show the trace by refreshing the Diagram
            MyBilliardtable.Refresh()

            'and draw the new Ball Position
            MyBilliardtableGraphics.DrawPoint(Nextposition, MyColor, MySize)

            Actualposition.X = Nextposition.X
            Actualposition.Y = Nextposition.Y

        Loop Until i * Stepwide > 1

    End Sub

    'SECTOR CALCULATION

    Private Function IsBallInOval(Ballposition As ClsMathpoint) As Boolean

        Dim OK As Boolean

        If Ballposition.X >= m Then

            'Check the Circle
            OK = Math.Pow(Ballposition.X - m, 2) + Math.Pow(Ballposition.Y, 2) <= b * b
        Else

            'Check the Ellipse
            OK = Math.Pow((Ballposition.X - m) / a, 2) + Math.Pow(Ballposition.Y / b, 2) <= 1
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
        Dim DA As Decimal = b * b
        Dim DB As Decimal = b * b * CDec(((p - m) * Math.Cos(Phi) + q * Math.Sin(Phi)))
        Dim DC As Decimal = b * b * (CDec(Math.Pow(p - m, 2)) + q * q - b * b)

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
            DA = CDec(Math.Pow(a * Math.Sin(Phi), 2) + Math.Pow(b * Math.Cos(Phi), 2))
            DB = CDec(a * a * q * Math.Sin(Phi) + b * b * (p - m) * Math.Cos(Phi))
            DC = CDec(Math.Pow(b * (p - m), 2) + a * a * (q * q - b * b))

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
            Throw New ArgumentException(Main.LM.GetString("NoIntersectionPoint"))

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
            MyParameterlistbox.Items.Add(Main.LM.GetString(MyTrackcolor.Name) & " t/alfa = " &
                                         MyT.ToString(CultureInfo.CurrentCulture) & "/" & Alfa.ToString(CultureInfo.CurrentCulture))
            MyParameterlistbox.Refresh()
        End If

        Return nextPhi

    End Function

    Public Function CalculateAlfa(t As Decimal, phi As Decimal) As Decimal Implements IBilliardball.CalculateAlfa

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
            TempHitpoint.X = -b * CDec(Math.Sin(t))
        Else

            'The TempHitPoint is on the Ellipse
            TempHitpoint.X = -a * CDec(Math.Sin(t))
        End If

        'in both cases
        TempHitpoint.Y = b * CDec(Math.Cos(t))

        Dim psi As Decimal = MyMathhelper.CalculateAngleOfDirection(TempHitpoint.X, TempHitpoint.Y)

        Return psi

    End Function

    Private Function CalculateBallPositionFromT(t As Decimal) As ClsMathpoint

        'this method calculates the Ball position in math. coordinates
        'if the Parameter t is given

        Dim TempMathpoint As New ClsMathpoint

        t = MyMathhelper.AngleInNullTwoPi(t)
        If (0 <= t And t <= Math.PI / 2) Or (3 * Math.PI / 2 <= t And t < 2 * Math.PI) Then

            'The Point is on the Circle
            TempMathpoint.X = m + b * CDec(Math.Cos(t))
        Else

            'The Point is on the Ellipse
            TempMathpoint.X = m + a * CDec(Math.Cos(t))
        End If

        'in both Cases
        TempMathpoint.Y = b * CDec(Math.Sin(t))

        Return TempMathpoint

    End Function

    Private Function CalculateTFromBallPosition(Mathpoint As ClsMathpoint) As Decimal


        'this method calculates the parameter t for a given position of the Ball
        'in math. coordinates

        Dim TempT As Decimal

        If Mathpoint.X >= m Then

            'The Point is on the Circle
            TempT = MyMathhelper.CalculateAngleOfDirection((Mathpoint.X - m), Mathpoint.Y)
        Else

            'The Point is on the Ellipse
            TempT = MyMathhelper.CalculateAngleOfDirection((Mathpoint.X - m) / a, Mathpoint.Y / b)
        End If

        Return TempT

    End Function

End Class
