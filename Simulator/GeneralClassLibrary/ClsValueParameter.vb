'This Class hold all information about a value-range of a dynamic system
'like the reflexion angle alfa of a billiard or its t-parameter
'describing the hitpoint of a billiard ball
'other examples are the two angles of a double pendulum
'or the dilatation and angle of an oscillating spring pendulum

'Status checked

Public Class ClsValueParameter

    'To identify the parameter
    Private ReadOnly MyID As Integer
    Private ReadOnly MyName As String

    'The definition interval of the parameter
    Private MyRange As ClsInterval

    Public Sub New(Tag As Integer, Name As String, Range As ClsInterval)
        MyID = Tag
        MyName = Name
        MyRange = Range
    End Sub

    ReadOnly Property Tag As Integer
        Get
            Tag = MyID
        End Get
    End Property

    ReadOnly Property Name As String
        Get
            Return MyName
        End Get
    End Property

    'whitch interval is allowed for the value-parameter
    Public Property Range As ClsInterval
        Get
            Return MyRange
        End Get
        Set(value As ClsInterval)
            MyRange = value
        End Set
    End Property

End Class
