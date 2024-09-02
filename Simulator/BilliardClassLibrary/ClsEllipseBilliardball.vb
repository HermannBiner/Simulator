'This class contains all properties of the Billiard Ball on an elliptic Billiard Table
'and all Methods, this Ball has to know
'including its movement on the table and setting its start position
'therefore, many Balls can be placed on the Table
'with different colors (to be distinguished)
'See mathematical documentation

'important: this class works with mathematical coordinates
'the Instance of the GraphicTool transforms them in Pixel-Coordinates

'Status Checked

Imports System.Globalization

Public Class ClsEllipseBilliardball
    Implements IBilliardball, ICDiagramBilliard

    'The actual position of the Ball is drawn into this PictureBox
    'and shown by the Refresh-Method
    Private MyBilliardtable As PictureBox
    Private MyBilliardtableGraphics As ClsGraphicTool

    'The permanent Orbit of the Ball is drawn into the BitMap
    Private MyMapBilliardtable As Bitmap
    Private MyMapBilliardtableGraphics As ClsGraphicTool

    'The ball draws as well into the Phase Portrait
    Private MyPhaseportrait As PictureBox
    Private MyPhaseportraitGraphics As ClsGraphicTool

    'and protocols its Position (Parameter t and reflexion-angle Alfa) into a ListBox
    Private MyParameterListbox As ListBox

    'The Value Ranges of the relevant Parameters
    'Reflexion Angle between the Ball-Movement-Vector and the Ellipse-Tangent in the Hit Point
    'the angle is in ]0, pi[
    Private ReadOnly MyAlfaValueRange As ClsInterval

    'Value Range of the Parameter t that defines the Hit Point, in [0, 2*pi[
    Private ReadOnly MyTValueRange As ClsInterval

    'Collection of the two ValueRanges for the C-Diagram
    Private ReadOnly MyValueParameters As List(Of ClsValueParameter)

    'The Value Range of the Mathematical Coordinates - Standard is the Interval [-1,1]
    'and the Coordinate System a Square [-1,1] x [-1,1]
    Private ReadOnly MyMathValueRange As ClsInterval

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

    'Profile of the Ellipse
    'Major axis
    Private a As Decimal
    'Minor axis
    Private b As Decimal
    'Relation c = b:a
    Private MyC As Decimal

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
        MyMathValueRange = New ClsInterval(-1, 1)
        MyAlfaValueRange = New ClsInterval(0, CDec(Math.PI))
        MyTValueRange = New ClsInterval(0, CDec(Math.PI * 2))

        MyValueParameters = New List(Of ClsValueParameter)

        Dim ValueRange As ClsValueParameter
        ValueRange = New ClsValueParameter(1, "t-Parameter", MyTValueRange)
        MyValueParameters.Add(ValueRange)

        ValueRange = New ClsValueParameter(2, "Angle Alfa", MyAlfaValueRange)
        MyValueParameters.Add(ValueRange)

        'Default
        MyC = CDec(0.8)

    End Sub

    WriteOnly Property Billiardtable As PictureBox Implements IBilliardball.Billiardtable
        Set(value As PictureBox)
            MyBilliardtable = value
            MyBilliardtableGraphics = New ClsGraphicTool(MyBilliardtable, MyMathValueRange, MyMathValueRange)
        End Set
    End Property

    WriteOnly Property MapBilliardtable As Bitmap Implements IBilliardball.MapBilliardtable
        Set(value As Bitmap)
            MyMapBilliardtable = value
            MyMapBilliardtableGraphics = New ClsGraphicTool(MyMapBilliardtable, MyMathValueRange, MyMathValueRange)
        End Set
    End Property

    Property C As Decimal Implements IBilliardball.C
        Get
            C = MyC
        End Get
        Set(value As Decimal)
            MyC = value

            If MyC <= 1 Then

                'a > b, , for better visibility a = 0.99 instead of 1
                a = CDec(0.99)
                b = MyC * a
            Else

                'b > a, for better visibility b = 0.99 instead of 1
                b = CDec(0.99)
                a = b / MyC
            End If

            'Default Startposition is (0/b)
            UserStartposition = New ClsMathpoint(0, b)
            DrawUserStartposition(False)

            'and Endposition (a,0)
            UserEndposition = New ClsMathpoint(a, 0)

            'these Parameters are set later by moving the Mouse

        End Set
    End Property

    Property CParameter As Decimal Implements ICDiagramBilliard.CParameter
        Get
            CParameter = MyC
        End Get
        Set(value As Decimal)
            MyC = value

            If MyC <= 1 Then

                'a > b, , for better visibility a = 0.99 instead of 1
                a = CDec(0.99)
                b = MyC * a
            Else

                'b > a, for better visibility b = 0.99 instead of 1
                b = CDec(0.99)
                a = b / MyC
            End If

        End Set
    End Property


    WriteOnly Property Phaseportrait As PictureBox Implements IBilliardball.Phaseportrait
        Set(value As PictureBox)
            MyPhaseportrait = value
            MyPhaseportraitGraphics = New ClsGraphicTool(MyPhaseportrait, MyTValueRange, MyAlfaValueRange)
        End Set
    End Property

    WriteOnly Property ParameterProtocol As ListBox Implements IBilliardball.ParameterProtocol
        Set(value As ListBox)
            MyParameterListbox = value
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
            UserStartposition.X = CDec(a * Math.Cos(MyT))
            UserStartposition.Y = CDec(b * Math.Sin(MyT))

            DrawUserStartposition(True)
            MyStartpositionSet = True
        End Set
    End Property

    WriteOnly Property Startangle As Decimal Implements IBilliardball.Startangle
        Set(value As Decimal)

            'In addition to the Startparameter t,
            'the angle of the first  reflection is necessary as well
            'to start the movement of the Ball
            Dim alfa As Decimal = value

            'first, we calculate the angle between the tangent in the hit point
            'and the positive xaxis
            Dim psi As Decimal = MyMathhelper.AngleInNullTwoPi(CalculatePsi(MyT))

            'Now the angle between the next moving-direction and the positive x-axis is:
            MyPhi = psi + alfa

            'With these parameters, we can calculate the next Hit Point
            'and its Parameter NextT
            Dim nextT As Decimal = ParameterOfNextHitPoint(MyT, MyPhi)

            'The Position von the next Hit Point is the Endposition
            'of this part of the Ball-Movement
            UserEndposition.X = CDec(a * Math.Cos(nextT))
            UserEndposition.Y = CDec(b * Math.Sin(nextT))
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

            'The MidPoint of the Ellipse is always (0/0)
            .DrawEllipse(New ClsMathpoint(0, 0), a, b, Color.Blue, 1)

            'Set Focal Points F1 and F2 of the Ellipse
            Dim F1 As New ClsMathpoint
            Dim F2 As New ClsMathpoint

            Dim f As Decimal
            If a > b Then
                f = CDec(Math.Sqrt(a * a - b * b))
                F1.X = f
                F1.Y = 0
                F2.X = -f
                F2.Y = 0
            Else
                f = CDec(Math.Sqrt(b * b - a * a))
                F1.X = 0
                F1.Y = f
                F2.X = 0
                F2.Y = -f
            End If

            'Draw Focal Points
            .DrawPoint(F1, Brushes.DarkBlue, 3)
            .DrawPoint(F2, Brushes.DarkBlue, 3)
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
        MyT = t

        'Now, the Startposition is set on the border of the Ellipse
        UserStartposition.X = CDec(a * Math.Cos(t))
        UserStartposition.Y = CDec(b * Math.Sin(t))

        Return t

    End Function

    Private Sub DrawUserStartposition(definitive As Boolean)

        If definitive Then

            'The Ball is drawn permanentely into the BitMap
            MyMapBilliardtableGraphics.DrawPoint(UserStartposition, MyColor, MySize)
            MyBilliardtable.Refresh()
        Else

            'The actual and still moving Ball is drawn into the PicDiagram
            MyBilliardtable.Refresh()
            MyBilliardtableGraphics.DrawPoint(UserStartposition, MyColor, MySize)
        End If
    End Sub

    Public Function SetAndDrawUserEndposition(Mouseposition As Point, definitive As Boolean) As Decimal _
        Implements IBilliardball.SetAndDrawUserEndposition

        'The Endposition is definied by the angle phi of the next moving direction
        Dim Phi As Decimal = SetUserEndposition(Mouseposition)

        DrawUserEndPosition(definitive)

        'We need Phi to calculate Alfa and for the Procotol in the Phase Portrait
        Return Phi

    End Function

    Private Function SetUserEndposition(Mouseposition As Point) As Decimal

        'The Endposition of the Ball in math. coordinates
        'is just equal to the Mouseposition in Pixels
        UserEndposition = MyMapBilliardtableGraphics.PixelToMathpoint(Mouseposition)

        'With this Endposition, we calculate the Angle phi
        'that is the Angle of the next moving-direction and the positive x-axis
        Dim deltaX As Decimal = UserEndposition.X - UserStartposition.X
        Dim deltaY As Decimal = UserEndposition.Y - UserStartposition.Y
        Dim phi = MyMathhelper.CalculateAngleOfDirection(deltaX, deltaY)

        'With this Angle, we can calculate the next Hit Point
        'and its Parameter NextT
        Dim nextT As Decimal = ParameterOfNextHitPoint(MyT, phi)

        'and then set the Endposition of the Ball definitively on the Border of the Ellipse
        UserEndposition.X = CDec(a * Math.Cos(nextT))
        UserEndposition.Y = CDec(b * Math.Sin(nextT))

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
            Startpoint.X = CDec(a * Math.Cos(MyT))
            Startpoint.Y = CDec(b * Math.Sin(MyT))

            'NextT is the Parameter of the EndPoint of the actual part of the Orbit
            nextT = ParameterOfNextHitPoint(MyT, MyPhi)
            Endpoint.X = CDec(a * Math.Cos(nextT))
            Endpoint.Y = CDec(b * Math.Sin(nextT))

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
        'and the positive xaxis
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
        Dim Stepwide As Decimal = MyMathValueRange.IntervalWidth * MySpeed / 1000

        Do
            i += 1
            Nextposition.X = Startposition.X + (Endposition.X - Startposition.X) * i * Stepwide
            Nextposition.Y = Startposition.Y + (Endposition.Y - Startposition.Y) * i * Stepwide

            'Small rounding effects are corrected
            If Not IsBallOnEllipse(Nextposition) Then
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

    Private Function IsBallOnEllipse(Ballposition As ClsMathpoint) As Boolean

        Return (Math.Pow(Ballposition.X / a, 2) + Math.Pow(Ballposition.Y / b, 2) <= 1)

    End Function

    Private Function ParameterOfNextHitPoint(t As Decimal, phi As Decimal) As Decimal

        't is the Parameter of the Startpoint of the actual part of the Orbit
        'and Phi the direction of the movement relative to the positive x-axis
        'this medhod calculates then the next Hit Point 
        'and returns its Parameter NextT
        'see mathematical documentation

        'Theta is the Parameter of a vector parallel to the direction-angle Phi
        Dim theta As Decimal = MyMathhelper.CalculateAngleOfDirection(CDec(b * Math.Cos(phi)), CDec(a * Math.Sin(phi)))

        'u is the Parameter where the straight line of the Orbit intersects the Ellipse
        'see math. doc.
        Dim u As Decimal = CDec(-2 * Math.Cos(t - theta))

        'NextT is calculated and small rounding effects are corrected
        Dim nextT As Decimal = CDec(Math.Min(1, Math.Cos(t) + u * Math.Cos(theta)))
        nextT = Math.Max(-1, nextT)
        nextT = CDec(Math.Acos(nextT))

        'The solution above is in [0,pi]
        'but there is also another solution in [pi, 2*pi]
        'and we have to control according to the math. doc.
        'which solution is the correct one
        If Math.Sin(t) + u * Math.Sin(theta) <= 0 Then
            nextT = CDec(2 * Math.PI - nextT)
        End If

        nextT = MyMathhelper.AngleInNullTwoPi(nextT)

        Return nextT

    End Function

    Private Function CalculateNextPhi(t As Decimal, phi As Decimal) As Decimal

        't is the Parameter of the Startpoint of the actual part of the Orbit
        'and Phi the direction of the movement relative to the positive x-axis
        'this medhod calculates then the next Direction-Angle NextPhi 
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
            MyPhaseportraitGraphics.DrawPoint(New ClsMathpoint(MyT, Alfa), MyColor, p)
            MyParameterListbox.Items.Add(FrmMain.LM.GetString(MyTrackcolor.Name) & " t/alfa = " &
                                         MyT.ToString(CultureInfo.CurrentCulture) & "/" & Alfa.ToString(CultureInfo.CurrentCulture))
            MyParameterListbox.Refresh()
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
        Dim psi As Decimal = MyMathhelper.CalculateAngleOfDirection(CDec(-a * Math.Sin(t)), CDec(b * Math.Cos(t)))
        Return psi

    End Function
End Class
