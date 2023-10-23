'This is the Billard Table for the oval Billard
'see mathematical documentation
'Status Checked

Public Class ClsOvalBillardtable
    Implements IBillardtable

    Private MyBillardtable As Bitmap

    'a = Major axis of the Ellipse
    'b = Minor axis of the Ellipse and radius of the circle
    Private a, b As Decimal

    'The Parameter C defines the profile of the Oval: relation b = C*a
    Private MyC As Decimal

    'The table is dranw into the Bitmap
    Private MyBitmapGraphics As ClsGraphicTool

    'The Oval is drawn into the square ValueRange x ValueRange, STandard is [-1,1] x [-1,1]
    Private Valuerange As ClsInterval

    Public WriteOnly Property C As Decimal Implements IBillardtable.C
        Set(value As Decimal)
            MyC = value

            'a + b = 1.9 (instead of 2) because of better visibility
            a = CDec(1.9) * Math.Min(1 / (1 + MyC), 1 / (2 * MyC))
            b = MyC * a

        End Set
    End Property


    Public WriteOnly Property MapBillardtable As Bitmap Implements IBillardtable.MapBillardtable
        Set(value As Bitmap)
            MyBillardtable = value

            'ValueRange
            Valuerange = New ClsInterval(-1, 1)

            'The class draws into the Billard Table
            MyBitmapGraphics = New ClsGraphicTool(MyBillardtable, Valuerange, Valuerange)

        End Set
    End Property

    Public Sub DrawBillardtable() Implements IBillardtable.DrawBillardtable

        'Coordinate System
        MyBitmapGraphics.DrawCoordinateSystem(New ClsMathpoint(0, 0), Color.Black, 1)

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
        MyBitmapGraphics.DrawPoint(Midpoint, Brushes.Blue, 2)
        MyBitmapGraphics.DrawPoint(Focalpoint, Brushes.Blue, 2)

        'Draw half-Circle
        MyBitmapGraphics.DrawCircleArc(Midpoint, b, CDec(3 * Math.PI / 2), CDec(Math.PI), Color.Blue, 1)

        'Draw half-Ellipse
        'Rectangle for the Ellipse bottom-left
        Dim BottomLeft As New ClsMathpoint(Midpoint.X - a, -b)

        'Rectangle for the Ellipse top-right
        Dim TopRight As New ClsMathpoint(Midpoint.X + a, b)

        MyBitmapGraphics.DrawEllipticArc(BottomLeft, TopRight, CDec(Math.PI / 2), CDec(Math.PI), Color.Blue, 1)

    End Sub

    Sub Clear() Implements IBillardtable.Clear
        MyBitmapGraphics.Clear(Color.White)
    End Sub

End Class
