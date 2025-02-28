'In cases where the dynamic system is described by a Value-Pair
'This class allows to treat this pair as one object

'Status Checked

Public Class ClsDblValuePair

    Private MyX As Double
    Private MyY As Double

    Public Sub New(X As Double, Y As Double)

        MyX = X
        MyY = Y

    End Sub

    Property X As Double
        Get
            X = MyX
        End Get
        Set(value As Double)
            MyX = value
        End Set
    End Property

    Property Y As Double
        Get
            Y = MyY
        End Get
        Set(value As Double)
            MyY = value
        End Set
    End Property

End Class
