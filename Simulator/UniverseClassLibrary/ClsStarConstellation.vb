'This class holds the data of a specific constellation in an universe
'as e.g. a stable set of stars

'Status Checked

Public Class ClsStarConstellation

    Private MyName As String
    Private MyProposedStepWidth As Double
    Private MyStars As List(Of IStar)

    'to show the phaseportrait, we need an individual 
    'factor for the velocity, because it is too small
    'depending on the constellation
    Private MyVFactor As Double

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

    Property ProposedStepWidth As Double
        Get
            ProposedStepWidth = MyProposedStepWidth
        End Get
        Set(value As Double)
            MyProposedStepWidth = value
        End Set
    End Property

    ReadOnly Property Stars As List(Of IStar)
        Get
            Stars = MyStars
        End Get
    End Property

    Property VFactor As Double
        Get
            VFactor = MyVFactor
        End Get
        Set(value As Double)
            MyVFactor = value
        End Set
    End Property

    Public Sub AddStar(Star As IStar)
        MyStars.Add(Star)
    End Sub

End Class
