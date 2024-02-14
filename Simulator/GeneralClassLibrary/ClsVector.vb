'This class allows to work with vectors
'which dimension is defined in the constructor

Public Class ClsVector
    Private ReadOnly Components As Decimal()
    Private MyDimension As Integer

    Public Sub New(N As Integer)
        MyDimension = N
        ReDim Components(N)
    End Sub

    Public Property Component(index As Integer) As Decimal
        Get
            Return Components(index)
        End Get
        Set(value As Decimal)
            Components(index) = value
        End Set
    End Property

    Public ReadOnly Property Dimension As Integer
        Get
            Dimension = MyDimension
        End Get
    End Property

End Class

