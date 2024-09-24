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

            'and then, the Startposition according to the mathematical documentation is:
            UserStartposition.X = CDec(MyA * Math.Cos(T))
            UserStartposition.Y = CDec(MyB * Math.Sin(T))

            DrawUserStartposition(True)
            MyStartPositionSet = True
        End Set
    End Property

    Overrides WriteOnly Property Startangle As Decimal
        Set(value As Decimal)

            'In addition to the Startparameter t,
            'the angle of the first  reflection is necessary as well
            'to start the movement of the Ball
            Dim alfa As Decimal = value

            'first, we calculate the angle between the tangent in the hit point
            'and the positive xaxis
            Dim psi As Decimal = Mathhelper.AngleInNullTwoPi(CalculatePsi(T))

            'Now the angle between the next moving-direction and the positive x-axis is:
            Phi = psi + alfa

            'With these parameters, we can calculate the next Hit Point
            'and its Parameter NextT
            Dim NextT As Decimal = ParameterOfNextHitPoint(T, Phi)

            If IsNothing(UserEndposition) Then
                UserEndposition = New ClsMathpoint(0, 0)
            End If

            'The Position von the next Hit Point is the Endposition
            'of this part of the Ball-Movement
            UserEndposition.X = CDec(MyA * Math.Cos(NextT))
            UserEndposition.Y = CDec(MyB * Math.Sin(NextT))
            DrawUserEndPosition(True)

            MyStartAngleSet = True

        End Set
    End Property


    'SECTOR SETTING STARTPOSITION AND STARTANGLE OF THE BALL

    Public Overrides Function SetAndDrawUserStartposition(Mouseposition As Point, IsDefinitive As Boolean) As Decimal

        Dim LocT As Decimal = SetUserStartposition(Mouseposition)
        DrawUserStartposition(IsDefinitive)

        'we need t for the Protocol
        Return LocT

    End Function

    Private Function SetUserStartposition(Mouseposition As Point) As Decimal

        'Position of the Ball in math. coordinates, set by the Mouseposition in Pixel Coordinates
        'this startposition is still at the mouseposition (and not on the border of the Ellipse)
        UserStartposition = MyBmpGraphics.PixelToMathpoint(Mouseposition)

        'Parameter of this Startpoint
        T = Mathhelper.CalculateAngleOfDirection(UserStartposition.X, UserStartposition.Y)

        'Now, the Startposition is set on the border of the Ellipse
        UserStartposition.X = CDec(MyA * Math.Cos(T))
        UserStartposition.Y = CDec(MyB * Math.Sin(T))

        Return T

    End Function

    Public Overrides Sub DrawFirstUserStartposition()

        'Default Startposition is (0/b)
        UserStartposition = New ClsMathpoint(0, MyB)
        DrawUserStartposition(False)

        'and Endposition (a,0)
        UserEndposition = New ClsMathpoint(MyA, 0)

        'these Parameters are set later by moving the Mouse
        DrawUserStartposition(False)

    End Sub

    Private Sub DrawUserStartposition(IsDefinitive As Boolean)

        If IsDefinitive Then

            'The Ball is drawn permanentely into the BitMap
            MyBmpGraphics.DrawPoint(UserStartposition, MyColor, Size)
            MyPicDiagram.Refresh()
        Else

            'The actual and still moving Ball is drawn into the PicDiagram
            MyPicDiagram.Refresh()
            MyPicGraphics.DrawPoint(UserStartposition, MyColor, Size)
        End If
    End Sub

    Public Overrides Function SetAndDrawUserEndposition(Mouseposition As Point, IsDefinitive As Boolean) As Decimal _

        'The Endposition is definied by the angle phi of the next moving direction
        Dim Phi As Decimal = SetUserEndposition(Mouseposition)

        DrawUserEndPosition(IsDefinitive)

        'We need Phi to calculate Alfa and for the Procotol in the Phase Portrait
        Return Phi

    End Function

    Private Function SetUserEndposition(Mouseposition As Point) As Decimal

        'The Endposition of the Ball in math. coordinates
        'is just equal to the Mouseposition in Pixels
        UserEndposition = MyBmpGraphics.PixelToMathpoint(Mouseposition)

        'With this Endposition, we calculate the Angle phi
        'that is the Angle of the next moving-direction and the positive x-axis
        Dim DeltaX As Decimal = UserEndposition.X - UserStartposition.X
        Dim DeltaY As Decimal = UserEndposition.Y - UserStartposition.Y
        Dim phi = Mathhelper.CalculateAngleOfDirection(DeltaX, DeltaY)

        'With this Angle, we can calculate the next Hit Point
        'and its Parameter NextT
        Dim NextT As Decimal = ParameterOfNextHitPoint(T, phi)

        'and then set the Endposition of the Ball definitively on the Border of the Ellipse
        UserEndposition.X = CDec(MyA * Math.Cos(NextT))
        UserEndposition.Y = CDec(MyB * Math.Sin(NextT))

        Return phi

    End Function

    Private Sub DrawUserEndPosition(IsDefinitive As Boolean)

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
        Startpoint.X = CDec(MyA * Math.Cos(T))
        Startpoint.Y = CDec(MyB * Math.Sin(T))

        'NextT is the Parameter of the EndPoint of the actual part of the Orbit
        NextT = ParameterOfNextHitPoint(T, Phi)
        Endpoint.X = CDec(MyA * Math.Cos(NextT))
        Endpoint.Y = CDec(MyB * Math.Sin(NextT))

        'The Ball moves between these Points
        MoveOnOrbitPart(Startpoint, Endpoint)

        'The EndPoint is then the StartPoint of the following part of the Orbit
        T = NextT
        Startpoint.X = Endpoint.X
        Startpoint.Y = Endpoint.Y

        'in addition, we calculate the angle of the following movement
        Phi = CalculateNextPhi(T, Phi)

    End Sub

    Public Overrides Function GetNextValuePair(ActualPair As ClsValuePair) As ClsValuePair

        T = ActualPair.X
        Dim alfa As Decimal = ActualPair.Y

        'first, we calculate the angle between tangent in the hit point
        'and the positive xaxis
        Dim psi As Decimal = Mathhelper.AngleInNullTwoPi(CalculatePsi(T))

        'Now the angle between the next moving-direction and the positive x-axis is:
        Phi = psi + alfa

        'Parameter of the next Enpoint of the actual part of the Orbit
        Dim NextT As Decimal = ParameterOfNextHitPoint(T, Phi)

        'in addition, we calculate the angle of the following movement
        Phi = CalculateNextPhi(NextT, Phi)

        alfa = CalculateAlfa(NextT, Phi)

        Dim NextPoint As New ClsValuePair(NextT, alfa)
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
        Dim Stepwide As Decimal = MyMathInterval.IntervalWidth * MySpeed / 1000

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
            MyBmpGraphics.DrawLine(Actualposition, Nextposition, MyColor, 1)

            'and show the trace by refreshing the Diagram
            MyPicDiagram.Refresh()

            'and draw the new Ball Position
            MyPicGraphics.DrawPoint(Nextposition, MyColor, Size)

            Actualposition.X = Nextposition.X
            Actualposition.Y = Nextposition.Y

        Loop Until i * Stepwide > 1

    End Sub

    'SECTOR CALCULATION

    Private Function IsBallOnEllipse(Ballposition As ClsMathpoint) As Boolean

        Return (Math.Pow(Ballposition.X / MyA, 2) + Math.Pow(Ballposition.Y / MyB, 2) <= 1)

    End Function

    Private Function ParameterOfNextHitPoint(t As Decimal, phi As Decimal) As Decimal

        't is the Parameter of the Startpoint of the actual part of the Orbit
        'and Phi the direction of the movement relative to the positive x-axis
        'this medhod calculates then the next Hit Point 
        'and returns its Parameter NextT
        'see mathematical documentation

        'Theta is the Parameter of a vector parallel to the direction-angle Phi
        Dim theta As Decimal = Mathhelper.CalculateAngleOfDirection(CDec(MyB * Math.Cos(phi)), CDec(MyA * Math.Sin(phi)))

        'u is the Parameter where the straight line of the Orbit intersects the Ellipse
        'see math. doc.
        Dim u As Decimal = CDec(-2 * Math.Cos(t - theta))

        'NextT is calculated and small rounding effects are corrected
        Dim NextT As Decimal = CDec(Math.Min(1, Math.Cos(t) + u * Math.Cos(theta)))
        NextT = Math.Max(-1, NextT)
        NextT = CDec(Math.Acos(NextT))

        'The solution above is in [0,pi]
        'but there is also another solution in [pi, 2*pi]
        'and we have to control according to the math. doc.
        'which solution is the correct one
        If Math.Sin(t) + u * Math.Sin(theta) <= 0 Then
            NextT = CDec(2 * Math.PI - NextT)
        End If

        NextT = Mathhelper.AngleInNullTwoPi(NextT)

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
        Dim psi As Decimal = Mathhelper.CalculateAngleOfDirection(CDec(-MyA * Math.Sin(t)), CDec(MyB * Math.Cos(t)))
        Return psi

    End Function
End Class
