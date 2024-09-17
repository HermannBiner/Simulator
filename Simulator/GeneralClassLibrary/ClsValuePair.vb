'In cases where the dynamic system is described by a Value-Pair
'This class allows to treat this pair as one object

'Status Checked

Public Class ClsValuePair

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
