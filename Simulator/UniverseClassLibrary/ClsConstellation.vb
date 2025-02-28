'This class holds the data of a specific constellation in an universe
'as e.g. a stable set of stars

'Status Checked

Public Class ClsConstellation

    Private MyName As String
    Private MyProposedStepWidth As Decimal
    Private MyStars As List(Of IStar)

    'to show the phaseportrait, we need an individual 
    'factor for the velocity, because it is too small
    'depending on the constellation
    Private MyVFactor As Decimal

    Public Sub New()
        MyStars = New List(Of IStar)
    End Sub

    Property Name As String
        Get
            Name = MyName
        End Get
        Set(value As String)
            MyName = value
        End Set
    End Property

    Property ProposedStepWidth As Decimal
        Get
            ProposedStepWidth = MyProposedStepWidth
        End Get
        Set(value As Decimal)
            MyProposedStepWidth = value
        End Set
    End Property

    ReadOnly Property Stars As List(Of IStar)
        Get
            Stars = MyStars
        End Get
    End Property

    Property VFactor As Decimal
        Get
            VFactor = MyVFactor
        End Get
        Set(value As Decimal)
            MyVFactor = value
        End Set
    End Property

    Public Sub AddStar(Star As IStar)
        MyStars.Add(Star)
    End Sub

End Class
