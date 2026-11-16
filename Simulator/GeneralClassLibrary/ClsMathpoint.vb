'This class represents a point in mathematical coordinates
'See e.g. ClsGraphicTool

'Status Checked

Public Class ClsMathpoint

    'These Variables should be accessible as well for inerhited classes
    Protected MyX As Double
    Protected MyY As Double
    Protected MyZ As Double

    Public Sub New(x As Double, y As Double)

        'If the math. coordinates of the point are set when initializing
        MyX = x
        MyY = y

    End Sub

    Public Sub New()

        'If the math. coordinates X and Y are set later after the Initialization

    End Sub

    Public Sub New(x As Double, y As Double, z As Double)
        MyX = x
        MyY = y
        MyZ = z
    End Sub

    Public Property X As Double
        Get
            X = MyX
        End Get
        Set(value As Double)
            MyX = value
        End Set
    End Property

    Public Property Y As Double
        Get
            Y = MyY
        End Get
        Set(value As Double)
            MyY = value
        End Set
    End Property

    Public Property Z As Double
        Get
            Z = MyZ
        End Get
        Set(value As Double)
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
