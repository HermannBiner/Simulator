'This class contains all points of the actual constellation
'Thereby one can experiment with one point, two points or a cloud of points

'Status Tested

Public Class ClsPointSet

    Private MyName As String
    Private MyProposedStepWidth As Double
    Private MyIterationPoints As List(Of ClsIterationPoint)

    Public Sub New(Name As String)
        MyName = Name
        MyIterationPoints = New List(Of ClsIterationPoint)
    End Sub

    ReadOnly Property Name As String
        Get
            Name = MyName
        End Get
    End Property

    Property ProposedStepWidth As Double
        Get
            ProposedStepWidth = MyProposedStepWidth
        End Get
        Set(value As Double)
            MyProposedStepWidth = value
        End Set
    End Property

    ReadOnly Property Points As List(Of ClsIterationPoint)
        Get
            Points = MyIterationPoints
        End Get
    End Property

    Public Sub New()
        MyIterationPoints = New List(Of ClsIterationPoint)
    End Sub

    Public Sub AddPoint(IterationPoint As ClsIterationPoint)
        MyIterationPoints.Add(IterationPoint)
    End Sub

    Public Function Count() As Integer
        Return MyIterationPoints.Count
    End Function

End Class
