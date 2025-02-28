'This Class is representig a vector in R3

'Status Checked

Public Class ClsVector

    'The components
    Protected MyX As Decimal
    Protected MyY As Decimal
    Protected MyZ As Decimal
    Protected MyMathpoint As ClsMathpoint

    Public Sub New()
        'Default
        MyX = 0
        MyY = 0
        MyZ = 0
        MyMathpoint = New ClsMathpoint
    End Sub

    Public Sub New(x As Decimal, y As Decimal, z As Decimal)
        MyX = x
        MyY = y
        MyZ = z
        MyMathpoint = New ClsMathpoint
    End Sub

    Public Sub New(x As Decimal, y As Decimal)
        MyX = x
        MyY = y
        MyZ = 0
        MyMathpoint = New ClsMathpoint
    End Sub

    Property X As Decimal
        Get
            X = MyX
        End Get
        Set(value As Decimal)
            MyX = value
        End Set
    End Property

    Property Y As Decimal
        Get
            Y = MyY
        End Get
        Set(value As Decimal)
            MyY = value
        End Set
    End Property

    Property Z As Decimal
        Get
            Z = MyZ
        End Get
        Set(value As Decimal)
            MyZ = value
        End Set
    End Property

    Public Sub Equal(aVector As ClsVector)
        With aVector
            MyX = .X
            MyY = .Y
            MyZ = .Z
        End With
    End Sub

    Public Sub Add(aVector As ClsVector)
        With aVector
            MyX += .X
            MyY += .Y
            MyZ += .Z
        End With
    End Sub

    Public Sub Minus(aVector As ClsVector)
        With aVector
            MyX -= .X
            MyY -= .Y
            MyZ -= .Z
        End With
    End Sub
    Public Sub Mult(aFactor As Decimal)
        MyX *= aFactor
        MyY *= aFactor
        MyZ *= aFactor
    End Sub

    Public Function Scalar(aVector As ClsVector) As Decimal
        With aVector
            Return MyX * .X + MyY * .Y + MyZ * .Z
        End With
    End Function

    Public Function Cross(aVector As ClsVector) As ClsVector
        Dim LocCross = New ClsVector
        With aVector
            LocCross.X = MyY * .Z - MyZ * .X
            LocCross.Y = MyZ * .X - MyX * .Z
            LocCross.Z = MyX * .Y - MyY * .X
        End With
        Return LocCross
    End Function

    Public Sub TurnInXYPlane(phi As Decimal)
        'Turns the vector projected to the x-y plane
        MyX = CDec(MyX * Math.Cos(phi) - MyY * Math.Sin(phi))
        MyY = CDec(MyX * Math.Sin(phi) + MyY * Math.Cos(phi))
        'MyZ is not changed
    End Sub

    Public Function Abs() As Decimal
        Return CDec(Math.Sqrt(MyX * MyX + MyY * MyY + MyZ * MyZ))
    End Function

    Public Function ToMathPoint() As ClsMathpoint
        MyMathpoint.X = MyX
        MyMathpoint.Y = MyY
        Return MyMathpoint
    End Function

    Public Sub Reset()
        MyX = 0
        MyY = 0
        MyZ = 0
    End Sub
End Class
