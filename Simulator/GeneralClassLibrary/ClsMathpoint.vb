﻿'This class represents a point in mathematical coordinates
'See ClsGraphicTool 
'Status Checked

Public Class ClsMathpoint

    Private MyX As Decimal
    Private MyY As Decimal

    Public Sub New(x As Decimal, y As Decimal)

        'If the math. coordinates of the point are set when initializing
        MyX = x
        MyY = y

    End Sub

    Public Sub New()

        'If the math. coordinates X and Y are set after the Initialization

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

End Class
