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
    'this intervals are committed to the constructor as well

    'the ClsGraphictool "knows" the size of the PictureBox / Bitmap
    'and when knowing the X-range and Y-range of the matemathical coordinates, they are transformed
    'to the pixel-coordinates of the PictureBox / Bitmap by the ClsGraphicTool automatically
    'See SECTOR COORDINATE TRANSFORMATION

    'therefore, the programmer has not to take care of coordinate-transformation
    'on higher architecture level
    'he just works with his mathematical coordinate system
    'and objects of type ClsMathPoint
    'ClsGraphicTool uses then objects of type Point in Pixel-coordinates

    'although in the mathematical coordinate-system the Y-axis shows uppwards
    'and the X-axis to the right
    'in the pixel-coordinate-system, the Y-axis shows downwards
    'but the programmer doesn't have to take care of that

    'but of course, of there is drawing in pixel coordinates needed
    'at least to draw a point is possible by overloading

    Private ReadOnly MyPicturebox As PictureBox
    Private ReadOnly MyBitmap As Bitmap
    Private ReadOnly MyImage As Image

    'the Graphic object of the .NET library
    Private ReadOnly Graphs As Graphics

    'The rectangle representing the Bitmap or PictureBox
    Private Imagerange As Rectangle

    Private MyMathXInterval As ClsInterval
    Private MyMathYInterval As ClsInterval

    'the upper right corner point of the PictureBox / Bitmap
    'it defines the size of the PictureBox / Bitmap
    Private MyDiagramCornerpoint As Point

    'SECTOR CONSTRUCTOR

    Public Sub New(Picturebox As PictureBox, MathXInterval As ClsInterval, MathYInterval As ClsInterval)

        'In this case, ClsGraphics draws into a PictureBox
        MyPicturebox = Picturebox
        Graphs = MyPicturebox.CreateGraphics

        'Because of better visibility in the User-Window,
        'the maximal ImageRange and DiagramSize are reduced by -1
        Imagerange = New Rectangle(1, MyPicturebox.Height - 1, MyPicturebox.Width - 1, MyPicturebox.Height - 1)
        MyDiagramCornerpoint = New Point(Picturebox.Width - 1, Picturebox.Height - 1)

        MyMathXInterval = MathXInterval
        MyMathYInterval = MathYInterval

    End Sub

    Public Sub New(Bitmap As Bitmap, MathXInterval As ClsInterval, MathYInterval As ClsInterval)

        'In this case, ClsGraphics draws into a Bitmap
        MyBitmap = Bitmap
        Graphs = Graphics.FromImage(MyBitmap)

        'Because of better visibility, the maximal ImageRange and DiagramSize are reduced by -1
        Imagerange = New Rectangle(1, MyBitmap.Height - 1, MyBitmap.Width - 1, MyBitmap.Height - 1)
        MyDiagramCornerpoint = New Point(MyBitmap.Width - 1, MyBitmap.Height - 1)

        MyMathXInterval = MathXInterval
        MyMathYInterval = MathYInterval

    End Sub

    Public Sub New(Image As Image, MathXInterval As ClsInterval, MathYInterval As ClsInterval)

        'In this case, ClsGraphics draws into a Bitmap
        MyImage = Image
        Graphs = Graphics.FromImage(MyImage)

        'Because of better visibility, the maximal ImageRange and DiagramSize are reduced by -1
        Imagerange = New Rectangle(1, MyImage.Height - 1, MyImage.Width - 1, MyImage.Height - 1)
        MyDiagramCornerpoint = New Point(MyImage.Width - 1, MyImage.Height - 1)

        MyMathXInterval = MathXInterval
        MyMathYInterval = MathYInterval

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

    Public Sub DrawCoordinateSystem(Midpoint As ClsMathpoint, color As Color, wide As Integer)

        'Draws the coordinate system with MidPoint in mathematial coordinates

        Using MyPen As New Pen(color, wide)

            'the midpoint is transferred in pixel-coordinates
            Dim PixelMidpoint As Point = MathpointToPixel(Midpoint)

            'Pixel X-axis
            Graphs.DrawLine(MyPen, 0, PixelMidpoint.Y, Imagerange.Width, PixelMidpoint.Y)

            'Pixel Y-axis
            Graphs.DrawLine(MyPen, PixelMidpoint.X, 0, PixelMidpoint.X, Imagerange.Height)
        End Using


    End Sub

    Public Sub DrawLine(A As ClsMathpoint, B As ClsMathpoint, color As Color, wide As Integer)

        'Draws a line between the points A and B in mathematical coordinates

        Using MyPen As New Pen(color, wide)
            Graphs.DrawLine(MyPen, MathpointToPixel(A), MathpointToPixel(B))
        End Using


    End Sub

    Public Sub DrawPoint(MathPoint As ClsMathpoint, brush As Brush, wide As Integer)

        'Draws a point in mathematical coordinates filled with Brush, Wide = 1 is about one pixel

        Dim size As Decimal = MyMathXInterval.IntervalWidth * wide / MyDiagramCornerpoint.X
        FillCircle(MathPoint, size, brush)

    End Sub

    Public Sub DrawPoint(PixelPoint As Point, brush As Brush, wide As Integer)

        'Draws a point in pixel coordinates filled with Brush, Wide = 1 is about one pixel

        FillCircle(PixelPoint, wide, brush)

    End Sub

    Public Sub DrawRectangle(A As ClsMathpoint, C As ClsMathpoint, color As Color, wide As Integer)

        'Draws a rectangle with left lower corner A and right upper corner C

        Using MyPen As New Pen(color, wide)
            Dim PixelA As Point = MathpointToPixel(A)
            Dim PixelC As Point = MathpointToPixel(C)

            'The object Graphs expects the upper left corner to be committed, therefore:
            Graphs.DrawRectangle(MyPen, PixelA.X, PixelC.Y, PixelC.X - PixelA.X, PixelA.Y - PixelC.Y)
        End Using


    End Sub

    Public Sub FillRectangle(A As ClsMathpoint, C As ClsMathpoint, brush As Brush)

        'Draws a rectangle with lower left corner A and upper right corner C
        'filled with Brush

        Dim PixelA As Point = MathpointToPixel(A)
        Dim PixelC As Point = MathpointToPixel(C)

        'The object Graphs expects the upper left corner to be committed, therefore:
        Graphs.FillRectangle(brush, PixelA.X, PixelC.Y, PixelC.X - PixelA.X, PixelA.Y - PixelC.Y)

    End Sub

    Public Sub DrawCircle(Midpoint As ClsMathpoint, radius As Decimal, color As Color, wide As Integer)

        'Draws a circle with MidPoint and Radius in mathematicel coordinates
        'Wide is the thickness of the line

        Using MyPen As New Pen(color, wide)
            Dim PixelMidpoint As Point = MathpointToPixel(Midpoint)
            Dim PixelBorderpoint As Point = MathpointToPixel(New ClsMathpoint(Midpoint.X + radius, Midpoint.Y))
            Dim PixelRadius As Integer = PixelBorderpoint.X - PixelMidpoint.X

            'The object Graphs expects a rectangle where the circle is drawed into
            Dim rect As New Rectangle(PixelMidpoint.X - PixelRadius, PixelMidpoint.Y - PixelRadius, 2 * PixelRadius, 2 * PixelRadius)
            Graphs.DrawEllipse(MyPen, rect)
        End Using


    End Sub

    Public Sub FillCircle(Midpoint As ClsMathpoint, radius As Decimal, brush As Brush)

        'Draws a circle with MidPoint and Radius in mathematicel coordinates
        'and fills the circle with Brush

        Dim PixelMidpoint As Point = MathpointToPixel(Midpoint)
        Dim PixelBorderpoint As Point = MathpointToPixel(New ClsMathpoint(Midpoint.X + radius, Midpoint.Y))
        Dim PixelRadius As Integer = PixelBorderpoint.X - PixelMidpoint.X

        'The object Graphs expects a rectangle where the circle is drawed into
        Dim rect As New Rectangle(PixelMidpoint.X - PixelRadius, PixelMidpoint.Y - PixelRadius, 2 * PixelRadius, 2 * PixelRadius)
        Graphs.FillEllipse(brush, rect)

    End Sub

    Public Sub FillCircle(PixelMidPoint As Point, radius As Integer, brush As Brush)

        'Draws a circle with MidPoint and Radius in pixel coordinates
        'and fills the circle with Brush

        'The object Graphs expects a rectangle where the circle is drawed into
        Dim rect As New Rectangle(PixelMidPoint.X - radius, PixelMidPoint.Y - radius, 2 * radius, 2 * radius)
        Graphs.FillEllipse(brush, rect)

    End Sub

    Public Sub DrawEllipse(Midpoint As ClsMathpoint, a As Decimal, b As Decimal, color As Color, wide As Integer)

        'Draws an ellipse with MidPoint, major axis a and minor axis b
        'in mathematical coordinates

        Using MyPen As New Pen(color, wide)
            Dim PixelMidpoint As Point = MathpointToPixel(Midpoint)

            Dim PixelBorderpoint As Point = MathpointToPixel(New ClsMathpoint(Midpoint.X + a, Midpoint.Y + b))

            'Axis-size in pixel coordinates
            Dim PixelA As Integer = PixelBorderpoint.X - PixelMidpoint.X
            Dim PixelB As Integer = PixelBorderpoint.Y - PixelMidpoint.Y

            'The object Graphs expects a rectangle where the ellipse is drawed into
            Dim rect As New Rectangle(PixelMidpoint.X - PixelA, PixelMidpoint.Y - PixelB, 2 * PixelA, 2 * PixelB)
            Graphs.DrawEllipse(MyPen, rect)
        End Using


    End Sub

    Public Sub FillEllipse(Midpoint As ClsMathpoint, a As Decimal, b As Decimal, brush As Brush)

        'Draws an ellipse with MidPoint, major axis a and minor axis b
        'in mathematical coordinates and fills it with Brush

        Dim PixelMidpoint As Point = MathpointToPixel(Midpoint)
        Dim PixelBorderpoint As Point = MathpointToPixel(New ClsMathpoint(Midpoint.X + a, Midpoint.Y + b))

        'Axis-size in pixel coordinates
        Dim PixelA As Integer = PixelBorderpoint.X - PixelMidpoint.X
        Dim PixelB As Integer = PixelBorderpoint.Y - PixelMidpoint.Y

        'The object Graphs expects a rectangle where the ellipse is drawed into
        Dim rect As New Rectangle(PixelMidpoint.X - PixelA, PixelMidpoint.Y - PixelB, 2 * PixelA, 2 * PixelB)
        Graphs.FillEllipse(brush, rect)

    End Sub

    Public Sub DrawCircleArc(Midpoint As ClsMathpoint, radius As Decimal, arc As Decimal, arclength As Decimal, color As Color, wide As Integer)

        'Draws a circular arc around MidPoint and Radius in mathematical coordinates
        'The angle starts at StartArc and has the lenghts ArcLangth
        'all in radian measure contained in [0, 2*Pi[

        Using MyPen As New Pen(color, wide)
            Dim PixelMidpoint As Point = MathpointToPixel(Midpoint)
            Dim PixelBorderpoint As Point = MathpointToPixel(New ClsMathpoint(Midpoint.X + radius, Midpoint.Y))
            Dim PixelRadius As Integer = PixelBorderpoint.X - PixelMidpoint.X

            'The object Graphs expects the angles in Degrees
            Dim PixelStartarc As Integer = RadiantToDegree(arc)
            Dim PixelArclength As Integer = RadiantToDegree(arclength)

            'The object Graphs expects a rectangle where the circular arc is drawed into
            Dim rect As New Rectangle(PixelMidpoint.X - PixelRadius, PixelMidpoint.Y - PixelRadius, 2 * PixelRadius, 2 * PixelRadius)
            Graphs.DrawArc(MyPen, rect, PixelStartarc, PixelArclength)
        End Using


    End Sub


    Public Sub DrawEllipticArc(A As ClsMathpoint, C As ClsMathpoint, startarc As Decimal, arclength As Decimal, color As Color, wide As Integer)

        'Draws an elliptic arc contained in a rectangle with left lower corner A
        'and right uppper corner B in mathematical coordinates
        'The angle starts at StartArc and has the lenghts ArcLangth
        'all in radian measure contained in [0, 2*Pi[

        Using MyPen As New Pen(color, wide)
            Dim PixelA As Point = MathpointToPixel(A)
            Dim PixelC As Point = MathpointToPixel(C)

            'The object Graphs expects the angles in Degrees
            Dim PixelStartarc As Integer = RadiantToDegree(startarc)
            Dim PixelArclength As Integer = RadiantToDegree(arclength)

            'The object Graphs expects a rectangle where the circular arc is drawed into
            Dim rect As New Rectangle(PixelA.X, PixelC.Y, PixelC.X - PixelA.X, PixelA.Y - PixelC.Y)
            Graphs.DrawArc(MyPen, rect, PixelStartarc, PixelArclength)
        End Using


    End Sub

    Public Sub DrawImage(Image As Image, XShift As Integer, YShift As Integer)

        'Draws an image on position (XShift, YShift) in Pixel Coordinates
        Graphs.DrawImage(Image, XShift, YShift)

    End Sub

    'SECTOR COORDINATE TRANSFORMATION

    'In the following sector, the range of the Pixel-coordinates is in
    '[0, MyDiagramSize.X]

    Public Function PixelToMathpoint(Pixelpoint As Point) As ClsMathpoint

        'Transformation of a PixelPoint in pixel-coordinates
        'into the equivalent mathematical coordinates
        '-1 because the DiagramSize is already reduced by -1 in the beginning

        Dim Mathpoint = New ClsMathpoint With {
            .X = MyMathXInterval.A + ((Pixelpoint.X - 1) * MyMathXInterval.IntervalWidth / MyDiagramCornerpoint.X),
            .Y = MyMathYInterval.B - ((Pixelpoint.Y - 1) * MyMathYInterval.IntervalWidth _
            / MyDiagramCornerpoint.Y)
        }

        Return Mathpoint

    End Function

    Public Function MathpointToPixel(Mathpoint As ClsMathpoint) As Point

        'Transformation of a MathPoint in mathematial coordinates 
        'into a Point in Pixel-Coordinates
        '+1 because we had a -1 in the inverse transformation

        Dim Pixelpoint = New Point With {
            .X = 1 + CInt((Mathpoint.X - MyMathXInterval.A) * MyDiagramCornerpoint.X / MyMathXInterval.IntervalWidth),
            .Y = 1 + CInt((MyMathYInterval.B - Mathpoint.Y) * MyDiagramCornerpoint.Y / MyMathYInterval.IntervalWidth)
        }

        Return Pixelpoint

    End Function

    Public Function RadiantToDegree(arc As Decimal) As Integer

        'Transformation of Radian into Degree
        Dim degree As Integer = CInt(180 * arc / Math.PI)
        Return degree

    End Function

End Class
