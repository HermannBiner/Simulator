'This is the Billard Table for the elliptic Billard
'see mathematical documentation

'Status Checked

Public Class ClsEllipseBillardtable
    Implements IBillardtable

    Private MyBillardtable As Bitmap

    'Major and minor axis of the Ellipse
    Private a, b As Decimal

    'The parameter C defines the profile of the ellipse: b = C*a
    Private MyC As Decimal

    'The table is drawn into the Bitmap
    Private MyBitmapGraphics As ClsGraphicTool

    'The Ellipse is drawn into the square ValueRange x ValueRange, Standard is [-1,1] x [-1,1]
    Private Valuerange As ClsInterval

    Public WriteOnly Property C As Decimal Implements IBillardtable.C
        Set(value As Decimal)
            MyC = value

            If MyC <= 1 Then

                'a > b, for better visibility a = 0.99 instead of 1
                a = CDec(0.99)
                b = MyC * a
            Else

                'b > a, for better visibility b = 0.99 instead of 1
                b = CDec(0.99)
                a = b / MyC
            End If
        End Set
    End Property

    Public ReadOnly Property MajorAxis As Decimal
        Get
            MajorAxis = a
        End Get
    End Property

    Public ReadOnly Property MinorAxis As Decimal
        Get
            MinorAxis = b
        End Get
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

        'The MidPoint of the Ellipse is always (0/0)
        MyBitmapGraphics.DrawEllipse(New ClsMathpoint(0, 0), a, b, Color.Blue, 1)

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
        MyBitmapGraphics.DrawPoint(F1, Brushes.DarkBlue, 3)
        MyBitmapGraphics.DrawPoint(F2, Brushes.DarkBlue, 3)

    End Sub

    Sub Clear() Implements IBillardtable.Clear
        MyBitmapGraphics.Clear(Color.White)
    End Sub

End Class
