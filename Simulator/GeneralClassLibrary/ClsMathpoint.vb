'This class represents a point in mathematical coordinates
'See e.g. ClsGraphicTool

'Status Checked

Public Class ClsMathpoint

    'These Variables should be accessible as well for inerhited classes
    Protected MyX As Decimal
    Protected MyY As Decimal
    Protected MyZ As Decimal

    Public Sub New(x As Decimal, y As Decimal)

        'If the math. coordinates of the point are set when initializing
        MyX = x
        MyY = y

    End Sub

    Public Sub New()

        'If the math. coordinates X and Y are set later after the Initialization

    End Sub

    Public Sub New(x As Decimal, y As Decimal, z As Decimal)
        MyX = x
        MyY = y
        MyZ = z
    End Sub

    Public Property X As Decimal
        Get
            X = MyX
        End Get
        Set(value As Decimal)
            MyX = value
        End Set
    End Property

    Public Property Y As Decimal
        Get
            Y = MyY
        End Get
        Set(value As Decimal)
            MyY = value
        End Set
    End Property

    Public Property Z As Decimal
        Get
            Z = MyZ
        End Get
        Set(value As Decimal)
            MyZ = value
        End Set
    End Property

    Public Sub Equal(aMathPoint As ClsMathpoint)
        With aMathPoint
            MyX = .X
            MyY = .Y
            MyZ = .Z
        End With
    End Sub

End Class
