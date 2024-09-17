'This class allows to work with vectors
'which dimension is defined in the constructor

'Status Checked

Public Class ClsNTupel
    Private MyComponents As Decimal()
    Private MyDimension As Integer

    Public Sub New(N As Integer)
        MyDimension = N
        ReDim MyComponents(N)
    End Sub

    Public Property Component(index As Integer) As Decimal
        Get
            Return MyComponents(index)
        End Get
        Set(value As Decimal)
            MyComponents(index) = value
        End Set
    End Property

    Public ReadOnly Property Dimension As Integer
        Get
            Dimension = MyDimension
        End Get
    End Property

End Class

