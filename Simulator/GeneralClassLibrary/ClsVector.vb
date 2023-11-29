'This class allows to work with vectors
'which dimension is defined in the constructor

Public Class ClsVector
    Private Components As Decimal()

    Public Sub New(N As Integer)
        ReDim Components(N - 1)
    End Sub

    Public Property Component(index As Integer) As Decimal
        Get
            Return Components(index)
        End Get
        Set(value As Decimal)
            Components(index) = value
        End Set
    End Property

End Class

