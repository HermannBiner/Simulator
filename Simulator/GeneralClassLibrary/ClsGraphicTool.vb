'This class supports all kind of drawings used by all classes on higher architecture level

'Status Checked

Public Class ClsGraphicTool

    'First option: this class can draw into a PictureBox
    'used when the drawings are not persistent and dynamic e.g. to show a moving ball
    'in this case, the reference of the drawing area is set to the PictureBox in the constructor
    'by PictureBox.refresh in the upper class, the image is updated

    'Second option: this class draws into a Bitmap
    'used when the drawing has to be persistent, e.g. to show the track of the ball
    'in this case, the reference of the drawing area is set to the Bitmap in the constructor

    'All classes using this ClsGraphicTool are working with mathematical coordinates
    'that means, the X-coordinate (horizontal axis) is in an interval [Xmin, Xmax] =: MyMathXInterval
    'and the Y-coordinate (vertical axis) is in an interval [Ymin, Ymax] =: MyMathYInterval
    'these intervals are set depensing of the dynamical system
    'and they are committed to the constructor as well

    'the ClsGraphictool "knows" the size of the PictureBox / Bitmap
    'and when knowing the X-range and Y-range of the matemathical coordinates, they are transformed
    'to the pixel-coordinates of the PictureBox / Bitmap by the ClsGraphicTool automatically
    'See SECTOR COORDINATE TRANSFORMATION

    'therefore, the programmer has not to take care of coordinate-transformation
    'on higher architecture level
    'he just works with his mathematical coordinate system
    'and objects of type ClsMathPoint
    'that are transmitted to ClsGraphicTool
    'ClsGraphicTool uses then internally objects of type Point in Pixel-coordinates
    'if (x,y) are the mathematical coordinates, the according pixel coordinates are (p,q)

    'although in the mathematical coordinate-system the Y-axis shows uppwards
    'and the X-axis to the right
    'in the pixel-coordinate-system, the p-axis shows to the right
    'and the q-axis shows downwards
    'but the programmer doesn't have to take care of that
    'because the ClsGrahicTool does

    'but of course, if there is a drawing in pixel coordinates needed
    'it is possible by overloading by objects of type Point instead of ClsMathPoint

    Private ReadOnly MyPicDiagram As PictureBox
    Private ReadOnly MyBitmap As Bitmap
    Private ReadOnly MyImage As Image

    'the Graphic object of the .NET library
    Private ReadOnly Graphs As Graphics

    Private MyMathXInterval As ClsInterval
    Private MyMathYInterval As ClsInterval
    Private ReadOnly MyPixelXInterval As ClsInterval
    Private ReadOnly MyPixelYInterval As ClsInterval

    'the upper right corner point of the PictureBox / Bitmap
    'it defines the size of the PictureBox / Bitmap
    Private DiagramCornerpoint As Point

    'SECTOR CONSTRUCTOR

    Public Sub New(PicDiagram As PictureBox, MathXInterval As ClsInterval, MathYInterval As ClsInterval)

        'In this case, ClsGraphics draws into a PictureBox
        MyPicDiagram = PicDiagram
        Graphs = MyPicDiagram.CreateGraphics

        'Because of better visibility in the User-Window,
        'the maximal ImageRange and DiagramSize are reduced by -1
        DiagramCornerpoint = New Point(Math.Max(1, MyPicDiagram.Width - 1), Math.Max(1, MyPicDiagram.Height - 1))

        MyMathXInterval = MathXInterval
        MyMathYInterval = MathYInterval
        MyPixelXInterval = New ClsInterval(0, Math.Max(1, MyPicDiagram.Width))
        MyPixelYInterval = New ClsInterval(0, Math.Max(1, MyPicDiagram.Height - 1))

    End Sub

    Public Sub New(Bitmap As Bitmap, MathXInterval As ClsInterval, MathYInterval As ClsInterval)

        'In this case, ClsGraphics draws into a Bitmap
        MyBitmap = Bitmap
        Graphs = Graphics.FromImage(MyBitmap)

        'Because of better visibility, the maximal ImageRange and DiagramSize are reduced by -1
        DiagramCornerpoint = New Point(MyBitmap.Width - 1, MyBitmap.Height - 1)

        MyMathXInterval = MathXInterval
        MyMathYInterval = MathYInterval
        MyPixelXInterval = New ClsInterval(0, MyBitmap.Width)
        MyPixelYInterval = New ClsInterval(0, Math.Max(1, MyBitmap.Height - 1))

    End Sub

    Public Sub New(Image As Image, MathXInterval As ClsInterval, MathYInterval As ClsInterval)

        'In this case, ClsGraphics draws into an image
        MyImage = Image
        Graphs = Graphics.FromImage(MyImage)

        'Because of better visibility, the maximal ImageRange and DiagramSize are reduced by -1
        DiagramCornerpoint = New Point(MyImage.Width - 1, MyImage.Height - 1)

        MyMathXInterval = MathXInterval
        MyMathYInterval = MathYInterval
        MyPixelXInterval = New ClsInterval(0, Image.Width)
        MyPixelYInterval = New ClsInterval(0, Image.Height - 1)

    End Sub

    Property MathXInterval As ClsInterval
        Get
            MathXInterval = MyMathXInterval
        End Get
        Set(value As ClsInterval)
            MyMathXInterval = value
        End Set
    End Property

    Property MathYInterval As ClsInterval
        Get
            MathYInterval = MyMathYInterval
        End Get
        Set(value As ClsInterval)
            MyMathYInterval = value
        End Set
    End Property

    'SECTOR GRAPHICS

    Public Sub Clear(color As Color)

        'Fills the drawing area with the color
        'and overdraws existing images
        Graphs.Clear(color)

    End Sub

    Public Sub DrawCoordinateSystem(Midpoint As ClsMathpoint, Color As Color, Wide As Integer)

        DrawHorizintalLine(Midpoint.Y, Color, Wide)
        DrawVerticalLine(Midpoint.X, Color, Wide)

    End Sub

    Public Sub DrawHorizintalLine(Y0 As Decimal, Color As Color, Wide As Integer)

        If MyMathYInterval.IsNumberInInterval(Y0) Then

            Dim LeftPoint As New ClsMathpoint(MyMathXInterval.A, Y0)
            Dim RightPoint As New ClsMathpoint(MyMathXInterval.B, Y0)

            Using Pen As New Pen(Color, Wide)
                Graphs.DrawLine(Pen, MathpointToPixel(LeftPoint), MathpointToPixel(RightPoint))
            End Using

        End If

    End Sub

    Public Sub DrawVerticalLine(X0 As Decimal, Color As Color, Wide As Integer)

        If MyMathXInterval.IsNumberInInterval(X0) Then

            Dim BottomPoint As New ClsMathpoint(X0, MyMathYInterval.A)
            Dim UpperPoint As New ClsMathpoint(X0, MyMathYInterval.B)

            Using Pen As New Pen(Color, Wide)
                Graphs.DrawLine(Pen, MathpointToPixel(BottomPoint), MathpointToPixel(UpperPoint))
            End Using

        End If

    End Sub

    Public Sub DrawLine(A As ClsMathpoint, B As ClsMathpoint, Color As Color, Wide As Integer)

        'Draws a line between the points A and B, given in mathematical coordinates

        Using Pen As New Pen(Color, Wide)
                Graphs.DrawLine(Pen, MathpointToPixel(A), MathpointToPixel(B))
            End Using

    End Sub

    Public Sub DrawLine(A As ClsMathpoint, B As ClsMathpoint, Brush As Brush, Wide As Integer)

        'Draws a line between the points A and B, given in mathematical coordinates

        Using Pen As New Pen(DirectCast(Brush, SolidBrush).Color, Wide)
                Graphs.DrawLine(Pen, MathpointToPixel(A), MathpointToPixel(B))
            End Using

    End Sub

    Public Sub DrawLine(A As ClsComplexNumber, B As ClsComplexNumber, Brush As Brush, Wide As Integer)

        'Draws a line between the points A and B, given in mathematical coordinates

        Using Pen As New Pen(DirectCast(Brush, SolidBrush).Color, Wide)
                Graphs.DrawLine(Pen, MathpointToPixel(New ClsMathpoint(CDec(A.X), CDec(A.Y))),
                                MathpointToPixel(New ClsMathpoint(CDec(B.X), CDec(B.Y))))
            End Using

    End Sub

    Public Sub DrawPoint(MathPoint As ClsMathpoint, Brush As SolidBrush, Wide As Integer)

        'Draws a point in mathematical coordinates filled with SolidBrush, Wide = 1 is about one pixel
        If MyMathXInterval.IsNumberInInterval(MathPoint.X) And
            MyMathYInterval.IsNumberInInterval(MathPoint.Y) Then

            Dim Size As Decimal = MyMathXInterval.IntervalWidth * Wide / DiagramCornerpoint.X
            FillCircle(MathPoint, Size, Brush)
        End If
    End Sub

    Public Sub DrawPoint(PixelPoint As Point, Brush As SolidBrush, Wide As Integer)

        If MyPixelXInterval.IsNumberInInterval(PixelPoint.X) And
                MyPixelYInterval.IsNumberInInterval(PixelPoint.Y) Then
            'Draws a point in pixel coordinates filled with SolidBrush, Wide = 1 is about one pixel
            FillCircle(PixelPoint, Wide, Brush)
        End If
    End Sub

    Public Sub DrawPoint(MathPoint As ClsMathpoint, Brush As Brush, Wide As Integer)

        If MyMathXInterval.IsNumberInInterval(MathPoint.X) And
            MyMathYInterval.IsNumberInInterval(MathPoint.Y) Then
            'Draws a point in mathematical coordinates filled with Brush, Wide = 1 is about one pixel

            Dim Size As Decimal = MyMathXInterval.IntervalWidth * Wide / DiagramCornerpoint.X
            FillCircle(MathPoint, Size, Brush)
        End If

    End Sub

    Public Sub DrawPoint(PixelPoint As Point, Brush As Brush, Wide As Integer)

        If MyPixelXInterval.IsNumberInInterval(PixelPoint.X) And
                MyPixelYInterval.IsNumberInInterval(PixelPoint.Y) Then
            'Draws a point in pixel coordinates filled with Brush, Wide = 1 is about one pixel

            FillCircle(PixelPoint, Wide, Brush)
        End If

    End Sub

    Public Sub DrawPoint(Z As ClsComplexNumber, Brush As Brush, Wide As Integer)

        If MyMathXInterval.IsNumberInInterval(Z.X) And
            MyMathYInterval.IsNumberInInterval(Z.Y) Then
            'Draws a point in mathematical coordinates filled with Brush, Wide = 1 is about one pixel

            Dim MathPoint As New ClsMathpoint(CDec(Z.X), CDec(Z.Y))
            Dim Size As Decimal = MyMathXInterval.IntervalWidth * Wide / DiagramCornerpoint.X
            FillCircle(MathPoint, Size, Brush)
        End If

    End Sub

    Public Sub DrawRectangle(A As ClsMathpoint, C As ClsMathpoint, Color As Color, Wide As Integer)

        If MyMathXInterval.IsNumberInInterval(A.X) And
         MyMathYInterval.IsNumberInInterval(A.Y) And
         MyMathXInterval.IsNumberInInterval(C.X) And
         MyMathYInterval.IsNumberInInterval(C.Y) Then

            'Draws a rectangle with left lower corner A, given as ClsMathpoint and right upper corner C

            Using Pen As New Pen(Color, Wide)
                Dim PixelA As Point = MathpointToPixel(A)
                Dim PixelC As Point = MathpointToPixel(C)

                'The object Graphs expects the upper left corner to be committed, therefore:
                Graphs.DrawRectangle(Pen, PixelA.X, PixelC.Y, PixelC.X - PixelA.X, PixelA.Y - PixelC.Y)
            End Using
        End If

    End Sub

    Public Sub DrawRectangle(A As ClsMathpoint, C As ClsMathpoint, Brush As Brush, Wide As Integer)

        If MyMathXInterval.IsNumberInInterval(A.X) And
         MyMathYInterval.IsNumberInInterval(A.Y) And
         MyMathXInterval.IsNumberInInterval(C.X) And
         MyMathYInterval.IsNumberInInterval(C.Y) Then

            'Draws a rectangle with left lower corner A and right upper corner C

            Using Pen As New Pen(DirectCast(Brush, SolidBrush).Color, Wide)
                Dim PixelA As Point = MathpointToPixel(A)
                Dim PixelC As Point = MathpointToPixel(C)

                'The object Graphs expects the upper left corner to be committed, therefore:
                Graphs.DrawRectangle(Pen, PixelA.X, PixelC.Y, PixelC.X - PixelA.X, PixelA.Y - PixelC.Y)
            End Using
        End If

    End Sub

    Public Sub FillRectangle(A As ClsMathpoint, C As ClsMathpoint, Brush As Brush)

        If MyMathXInterval.IsNumberInInterval(A.X) And
         MyMathYInterval.IsNumberInInterval(A.Y) And
         MyMathXInterval.IsNumberInInterval(C.X) And
         MyMathYInterval.IsNumberInInterval(C.Y) Then

            'Draws a rectangle with lower left corner A and upper right corner C
            'filled with Brush

            Dim PixelA As Point = MathpointToPixel(A)
            Dim PixelC As Point = MathpointToPixel(C)

            'The object Graphs expects the upper left corner to be committed, therefore:
            Graphs.FillRectangle(Brush, PixelA.X, PixelC.Y, PixelC.X - PixelA.X, PixelA.Y - PixelC.Y)
        End If

    End Sub

    Public Sub FillRectangle(A As ClsMathpoint, C As ClsMathpoint, Brush As SolidBrush)

        If MyMathXInterval.IsNumberInInterval(A.X) And
         MyMathYInterval.IsNumberInInterval(A.Y) And
         MyMathXInterval.IsNumberInInterval(C.X) And
         MyMathYInterval.IsNumberInInterval(C.Y) Then

            'Draws a rectangle with lower left corner A and upper right corner C
            'filled with SolidBrush

            Dim PixelA As Point = MathpointToPixel(A)
            Dim PixelC As Point = MathpointToPixel(C)

            'The object Graphs expects the upper left corner to be committed, therefore:
            Graphs.FillRectangle(Brush, PixelA.X, PixelC.Y, PixelC.X - PixelA.X, PixelA.Y - PixelC.Y)
        End If

    End Sub

    Public Sub DrawCircle(Midpoint As ClsMathpoint, Radius As Decimal, Color As Color, Wide As Integer)

        If MyMathXInterval.IsNumberInInterval(Midpoint.X) And
            MyMathYInterval.IsNumberInInterval(Midpoint.Y) Then
            'Draws a circle with MidPoint and Radius in mathematicel coordinates
            'Wide is the thickness of the line

            Using Pen As New Pen(Color, Wide)
                Dim PixelMidpoint As Point = MathpointToPixel(Midpoint)
                Dim PixelBorderpoint As Point = MathpointToPixel(New ClsMathpoint(Midpoint.X + Radius, Midpoint.Y))
                Dim PixelRadius As Integer = PixelBorderpoint.X - PixelMidpoint.X

                'The object Graphs expects a rectangle where the circle is drawed into
                Dim rect As New Rectangle(PixelMidpoint.X - PixelRadius, PixelMidpoint.Y - PixelRadius, 2 * PixelRadius, 2 * PixelRadius)
                Graphs.DrawEllipse(Pen, rect)
            End Using
        End If

    End Sub

    Public Sub DrawCircle(Midpoint As ClsMathpoint, Radius As Decimal, Brush As Brush, Wide As Integer)

        If MyMathXInterval.IsNumberInInterval(Midpoint.X) And
            MyMathYInterval.IsNumberInInterval(Midpoint.Y) Then
            'Draws a circle with MidPoint and Radius in mathematicel coordinates
            'Wide is the thickness of the line

            Using Pen As New Pen(DirectCast(Brush, SolidBrush).Color, Wide)
                Dim PixelMidpoint As Point = MathpointToPixel(Midpoint)
                Dim PixelBorderpoint As Point = MathpointToPixel(New ClsMathpoint(Midpoint.X + Radius, Midpoint.Y))
                Dim PixelRadius As Integer = PixelBorderpoint.X - PixelMidpoint.X

                'The object Graphs expects a rectangle where the circle is drawed into
                Dim rect As New Rectangle(PixelMidpoint.X - PixelRadius, PixelMidpoint.Y - PixelRadius, 2 * PixelRadius, 2 * PixelRadius)
                Graphs.DrawEllipse(Pen, rect)
            End Using
        End If

    End Sub

    Public Sub FillCircle(Midpoint As ClsMathpoint, Radius As Decimal, Brush As Brush)

        If MyMathXInterval.IsNumberInInterval(Midpoint.X) And
            MyMathYInterval.IsNumberInInterval(Midpoint.Y) Then
            'Draws a circle with MidPoint and Radius in mathematicel coordinates
            'and fills the circle with Brush

            Dim PixelMidpoint As Point = MathpointToPixel(Midpoint)
            Dim PixelBorderpoint As Point = MathpointToPixel(New ClsMathpoint(Midpoint.X + Radius, Midpoint.Y))
            Dim PixelRadius As Integer = PixelBorderpoint.X - PixelMidpoint.X

            'The object Graphs expects a rectangle where the circle is drawed into
            Dim Rect As New Rectangle(PixelMidpoint.X - PixelRadius, PixelMidpoint.Y - PixelRadius, 2 * PixelRadius, 2 * PixelRadius)
            Graphs.FillEllipse(Brush, Rect)
        End If

    End Sub

    Public Sub FillCircle(PixelMidPoint As Point, Radius As Integer, Brush As Brush)

        If MyPixelXInterval.IsNumberInInterval(PixelMidPoint.X) And
                MyPixelYInterval.IsNumberInInterval(PixelMidPoint.Y) Then
            'Draws a circle with MidPoint and Radius in pixel coordinates
            'and fills the circle with Brush

            'The object Graphs expects a rectangle where the circle is drawed into
            Dim Rect As New Rectangle(PixelMidPoint.X - Radius, PixelMidPoint.Y - Radius, 2 * Radius, 2 * Radius)
            Graphs.FillEllipse(Brush, Rect)
        End If

    End Sub

    Public Sub FillCircle(Midpoint As ClsMathpoint, Radius As Decimal, Brush As SolidBrush)

        If MyMathXInterval.IsNumberInInterval(Midpoint.X) And
            MyMathYInterval.IsNumberInInterval(Midpoint.Y) Then
            'Draws a circle with MidPoint and Radius in mathematicel coordinates
            'and fills the circle with SolidBrush

            Dim PixelMidpoint As Point = MathpointToPixel(Midpoint)
            Dim PixelBorderpoint As Point = MathpointToPixel(New ClsMathpoint(Midpoint.X + Radius, Midpoint.Y))
            Dim PixelRadius As Integer = PixelBorderpoint.X - PixelMidpoint.X

            'The object Graphs expects a rectangle where the circle is drawed into
            Dim Rect As New Rectangle(PixelMidpoint.X - PixelRadius, PixelMidpoint.Y - PixelRadius, 2 * PixelRadius, 2 * PixelRadius)
            Graphs.FillEllipse(Brush, Rect)
        End If

    End Sub

    Public Sub FillCircle(PixelMidPoint As Point, Radius As Integer, Brush As SolidBrush)

        If MyPixelXInterval.IsNumberInInterval(PixelMidPoint.X) And
                MyPixelYInterval.IsNumberInInterval(PixelMidPoint.Y) Then
            'Draws a circle with MidPoint and Radius in pixel coordinates
            'and fills the circle with SolidBrush

            'The object Graphs expects a rectangle where the circle is drawed into
            Dim Rect As New Rectangle(PixelMidPoint.X - Radius, PixelMidPoint.Y - Radius, 2 * Radius, 2 * Radius)
            Graphs.FillEllipse(Brush, Rect)
        End If

    End Sub

    Public Sub DrawEllipse(Midpoint As ClsMathpoint, a As Decimal, b As Decimal, Color As Color, Wide As Integer)

        If MyMathXInterval.IsNumberInInterval(Midpoint.X) And
            MyMathYInterval.IsNumberInInterval(Midpoint.Y) Then
            'Draws an ellipse with MidPoint, major axis a and minor axis b
            'given in mathematical coordinates

            Using Pen As New Pen(Color, Wide)
                Dim PixelMidpoint As Point = MathpointToPixel(Midpoint)

                Dim PixelBorderpoint As Point = MathpointToPixel(New ClsMathpoint(Midpoint.X + a, Midpoint.Y + b))

                'Axis-size in pixel coordinates
                Dim PixelA As Integer = PixelBorderpoint.X - PixelMidpoint.X
                Dim PixelB As Integer = PixelBorderpoint.Y - PixelMidpoint.Y

                'The object Graphs expects a rectangle where the ellipse is drawed into
                Dim Rect As New Rectangle(PixelMidpoint.X - PixelA, PixelMidpoint.Y - PixelB, 2 * PixelA, 2 * PixelB)
                Graphs.DrawEllipse(Pen, Rect)
            End Using
        End If

    End Sub

    Public Sub FillEllipse(Midpoint As ClsMathpoint, a As Decimal, b As Decimal, Brush As Brush)

        If MyMathXInterval.IsNumberInInterval(Midpoint.X) And
            MyMathYInterval.IsNumberInInterval(Midpoint.Y) Then
            'Draws an ellipse with MidPoint, major axis a and minor axis b
            'given in mathematical coordinates and fills it with Brush

            Dim PixelMidpoint As Point = MathpointToPixel(Midpoint)
            Dim PixelBorderpoint As Point = MathpointToPixel(New ClsMathpoint(Midpoint.X + a, Midpoint.Y + b))

            'Axis-size in pixel coordinates
            Dim PixelA As Integer = PixelBorderpoint.X - PixelMidpoint.X
            Dim PixelB As Integer = PixelBorderpoint.Y - PixelMidpoint.Y

            'The object Graphs expects a rectangle where the ellipse is drawed into
            Dim Rect As New Rectangle(PixelMidpoint.X - PixelA, PixelMidpoint.Y - PixelB, 2 * PixelA, 2 * PixelB)
            Graphs.FillEllipse(Brush, Rect)
        End If

    End Sub

    Public Sub FillEllipse(Midpoint As ClsMathpoint, a As Decimal, b As Decimal, Brush As SolidBrush)

        If MyMathXInterval.IsNumberInInterval(Midpoint.X) And
            MyMathYInterval.IsNumberInInterval(Midpoint.Y) Then
            'Draws an ellipse with MidPoint, major axis a and minor axis b
            'given in mathematical coordinates and fills it with SolidBrush

            Dim PixelMidpoint As Point = MathpointToPixel(Midpoint)
            Dim PixelBorderpoint As Point = MathpointToPixel(New ClsMathpoint(Midpoint.X + a, Midpoint.Y + b))

            'Axis-size in pixel coordinates
            Dim PixelA As Integer = PixelBorderpoint.X - PixelMidpoint.X
            Dim PixelB As Integer = PixelBorderpoint.Y - PixelMidpoint.Y

            'The object Graphs expects a rectangle where the ellipse is drawed into
            Dim Rect As New Rectangle(PixelMidpoint.X - PixelA, PixelMidpoint.Y - PixelB, 2 * PixelA, 2 * PixelB)
            Graphs.FillEllipse(Brush, Rect)
        End If

    End Sub

    Public Sub DrawCircleArc(Midpoint As ClsMathpoint, Radius As Decimal, Arc As Decimal, ArcLength As Decimal, Color As Color, Wide As Integer)

        'Draws a circular arc around MidPoint and Radius in mathematical coordinates
        'The angle starts at StartArc and has the lenghts ArcLangth
        'all in radian measure contained in [0, 2*Pi[

        Using Pen As New Pen(Color, Wide)
                Dim PixelMidpoint As Point = MathpointToPixel(Midpoint)
                Dim PixelBorderpoint As Point = MathpointToPixel(New ClsMathpoint(Midpoint.X + Radius, Midpoint.Y))
                Dim PixelRadius As Integer = PixelBorderpoint.X - PixelMidpoint.X

                'The object Graphs expects the angles in Degrees
                Dim PixelStartarc As Integer = RadiantToDegree(Arc)
                Dim PixelArclength As Integer = RadiantToDegree(ArcLength)

                'The object Graphs expects a rectangle where the circular arc is drawed into
                Dim Rect As New Rectangle(PixelMidpoint.X - PixelRadius, PixelMidpoint.Y - PixelRadius, 2 * PixelRadius, 2 * PixelRadius)
                Graphs.DrawArc(Pen, Rect, PixelStartarc, PixelArclength)
            End Using

    End Sub

    Public Sub DrawEllipticArc(A As ClsMathpoint, C As ClsMathpoint, StartArc As Decimal, ArcLength As Decimal, Color As Color, Wide As Integer)

        'Draws an elliptic arc contained in a rectangle with left lower corner A
        'and right uppper corner B in mathematical coordinates
        'The angle starts at StartArc and has the lenghts ArcLangth
        'all in radian measure contained in [0, 2*Pi[

        'A, C can be out of MathIntervals

        Using Pen As New Pen(Color, Wide)
                Dim PixelA As Point = MathpointToPixel(A)
                Dim PixelC As Point = MathpointToPixel(C)

                'The object Graphs expects the angles in Degrees
                Dim PixelStartarc As Integer = RadiantToDegree(StartArc)
                Dim PixelArclength As Integer = RadiantToDegree(ArcLength)

                'The object Graphs expects a rectangle where the circular arc is drawed into
                Dim Rect As New Rectangle(PixelA.X, PixelC.Y, PixelC.X - PixelA.X, PixelA.Y - PixelC.Y)
                Graphs.DrawArc(Pen, Rect, PixelStartarc, PixelArclength)
            End Using

    End Sub

    Public Sub DrawCircleArc(Midpoint As ClsMathpoint, Radius As Decimal, Arc As Decimal, ArcLength As Decimal, Brush As Brush, Wide As Integer)

        'Draws a circular arc around MidPoint and Radius in mathematical coordinates
        'The angle starts at StartArc and has the lenghts ArcLangth
        'all in radian measure contained in [0, 2*Pi[

        Using Pen As New Pen(DirectCast(Brush, SolidBrush).Color, Wide)
                Dim PixelMidpoint As Point = MathpointToPixel(Midpoint)
                Dim PixelBorderpoint As Point = MathpointToPixel(New ClsMathpoint(Midpoint.X + Radius, Midpoint.Y))
                Dim PixelRadius As Integer = PixelBorderpoint.X - PixelMidpoint.X

                'The object Graphs expects the angles in Degrees
                Dim PixelStartarc As Integer = RadiantToDegree(Arc)
                Dim PixelArclength As Integer = RadiantToDegree(ArcLength)

                'The object Graphs expects a rectangle where the circular arc is drawed into
                Dim Rect As New Rectangle(PixelMidpoint.X - PixelRadius, PixelMidpoint.Y - PixelRadius, 2 * PixelRadius, 2 * PixelRadius)
                Graphs.DrawArc(Pen, Rect, PixelStartarc, PixelArclength)
            End Using

    End Sub

    Public Sub DrawEllipticArc(A As ClsMathpoint, C As ClsMathpoint, StartArc As Decimal, ArcLength As Decimal, Brush As Brush, Wide As Integer)

        'Draws an elliptic arc contained in a rectangle with left lower corner A
        'and right uppper corner B in mathematical coordinates
        'The angle starts at StartArc and has the lenghts ArcLangth
        'all in radian measure contained in [0, 2*Pi[

        Using Pen As New Pen(DirectCast(Brush, SolidBrush).Color, Wide)
                Dim PixelA As Point = MathpointToPixel(A)
                Dim PixelC As Point = MathpointToPixel(C)

                'The object Graphs expects the angles in Degrees
                Dim PixelStartarc As Integer = RadiantToDegree(StartArc)
                Dim PixelArclength As Integer = RadiantToDegree(ArcLength)

                'The object Graphs expects a rectangle where the circular arc is drawed into
                Dim rect As New Rectangle(PixelA.X, PixelC.Y, PixelC.X - PixelA.X, PixelA.Y - PixelC.Y)
                Graphs.DrawArc(Pen, rect, PixelStartarc, PixelArclength)
            End Using

    End Sub

    Public Sub DrawImage(Image As Image, XShift As Integer, YShift As Integer)

        'Draws an image on position (XShift, YShift) in Pixel Coordinates
        Graphs.DrawImage(Image, XShift, YShift)

    End Sub

    'SECTOR COORDINATE TRANSFORMATION

    'In the following sector, the range of the Pixel-coordinates is in
    '[0, MyDiagramSize.X] x [0,MyDiagramSize.Y]

    Public Function PixelToMathpoint(Pixelpoint As Point) As ClsMathpoint

        'Transformation of a PixelPoint in pixel-coordinates
        'into the equivalent mathematical coordinates
        '-1 because the DiagramSize is already reduced by -1 in the beginning

        Dim Mathpoint = New ClsMathpoint With {
            .X = MyMathXInterval.A + ((Pixelpoint.X - 1) * MyMathXInterval.IntervalWidth / DiagramCornerpoint.X),
            .Y = MyMathYInterval.B - ((Pixelpoint.Y - 1) * MyMathYInterval.IntervalWidth _
            / DiagramCornerpoint.Y)
        }

        Return Mathpoint

    End Function

    Public Function MathpointToPixel(Mathpoint As ClsMathpoint) As Point

        'Transformation of a MathPoint in mathematial coordinates 
        'into a Point in Pixel-Coordinates
        '+1 because we had a -1 in the inverse transformation

        Dim Pixelpoint = New Point With {
            .X = 1 + CInt((Mathpoint.X - MyMathXInterval.A) * DiagramCornerpoint.X / MyMathXInterval.IntervalWidth),
            .Y = 1 + CInt((MyMathYInterval.B - Mathpoint.Y) * DiagramCornerpoint.Y / MyMathYInterval.IntervalWidth)
        }

        Return Pixelpoint

    End Function

    Public Function RadiantToDegree(Arc As Decimal) As Integer

        'Transformation of Radian into Degree
        Dim Degree As Integer = CInt(180 * Arc / Math.PI)
        Return Degree

    End Function

End Class
