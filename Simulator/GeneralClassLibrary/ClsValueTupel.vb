'In cases where the dynamic system is described by multiple Value-Parameters
'This class allows to communicate these parameters in one object
'at the moment, there are only two parameters supported
'that is easy to change by overloading to mor that two parameters

Public Class ClsValueTupel

    Private MyX As Decimal
    Private MyY As Decimal

    Public Sub New(X As Decimal, Y As Decimal)

        MyX = X
        MyY = Y

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

End Class
