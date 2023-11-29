
'This is the Billiard Table for the Billiard in a Stadium
'see mathematical documentation

'Status Checked

Public Class ClsStadiumBilliardtable
    Implements IBilliardtable

    Private MyBilliardtable As Bitmap

    'a and b are the half sides of the rectangle in the middle of the stadium
    'the corner points of this rectangle have the coordinates (+-a, +-b)
    'and the half circles on the border of the stadium the radius b
    Private a, b As Decimal

    'The parameter C defines the profile of the stadium: b = C*a
    Private MyC As Decimal

    'The table is dranw into the Bitmap
    Private MyBitmapGraphics As ClsGraphicTool

    'The Stadium is drawn into the square ValueRange x ValueRange, Standard is [-1,1] x [-1,1]
    Private Valuerange As ClsInterval

    Public WriteOnly Property C As Decimal Implements IBilliardtable.C
        Set(value As Decimal)
            MyC = value

            'a = 0.95 (instead of 1) because of better visibility
            a = CDec(0.95) / (1 + MyC)
            b = MyC * a

        End Set
    End Property

    Public WriteOnly Property MapBilliardtable As Bitmap Implements IBilliardtable.MapBilliardtable
        Set(value As Bitmap)

            MyBilliardtable = value

            'ValueRange 
            Valuerange = New ClsInterval(-1, 1)

            'The class draws into the Billiard Table
            MyBitmapGraphics = New ClsGraphicTool(MyBilliardtable, Valuerange, Valuerange)

        End Set
    End Property

    Public Sub DrawBilliardtable() Implements IBilliardtable.DrawBilliardtable

        'Coordinate System
        MyBitmapGraphics.DrawCoordinateSystem(New ClsMathpoint(0, 0), Color.Black, 1)

        'Draw the rectangle in the middle of the stadium
        MyBitmapGraphics.DrawLine(New ClsMathpoint(-a, -b), New ClsMathpoint(a, -b), Color.Blue, 1)
        MyBitmapGraphics.DrawLine(New ClsMathpoint(-a, b), New ClsMathpoint(a, b), Color.Blue, 1)

        'Draw the half-circles including their midpoints
        MyBitmapGraphics.DrawCircleArc(New ClsMathpoint(-a, 0), b, CDec(Math.PI / 2), CDec(Math.PI), Color.Blue, 1)
        MyBitmapGraphics.DrawPoint(New ClsMathpoint(-a, 0), Brushes.Blue, 2)
        MyBitmapGraphics.DrawCircleArc(New ClsMathpoint(a, 0), b, CDec(3 * Math.PI / 2), CDec(Math.PI), Color.Blue, 1)
        MyBitmapGraphics.DrawPoint(New ClsMathpoint(a, 0), Brushes.Blue, 2)

    End Sub

    Public Sub Clear() Implements IBilliardtable.Clear
        MyBitmapGraphics.Clear(Color.White)
    End Sub

End Class
