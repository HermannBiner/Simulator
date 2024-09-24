'This Class hold all information about a value-range of a dynamic system
'like the reflexion angle alfa of a billiard or its t-parameter
'describing the hitpoint of a billiard ball
'other examples are the two angles of a double pendulum
'or the dilatation and angle of an oscillating spring pendulum

'Status Checked

Public Class ClsGeneralParameter

    'To identify the parameter
    Private MyID As Integer
    Private MyName As String

    'The definition interval of the parameter
    Private MyRange As ClsInterval
    Private MyDefaultValue As Decimal
    Private MyTypeOfParameter As TypeOfParameterEnum

    Public Enum TypeOfParameterEnum
        Value
        Formula
    End Enum

    Public Sub New(ID As Integer, Name As String, Range As ClsInterval, TypeOfParameter As TypeOfParameterEnum)
        MyID = ID
        MyName = Name
        MyRange = Range
        MyTypeOfParameter = TypeOfParameter
        MyDefaultValue = 0
    End Sub

    Public Sub New(ID As Integer, Name As String, Range As ClsInterval, TypeOfParameter As TypeOfParameterEnum, DefaultValue As Decimal)
        MyID = ID
        MyName = Name
        MyRange = Range
        MyTypeOfParameter = TypeOfParameter
        MyDefaultValue = DefaultValue
    End Sub

    ReadOnly Property ID As Integer
        Get
            ID = MyID
        End Get
    End Property

    ReadOnly Property Name As String
        Get
            Return MyName
        End Get
    End Property

    'whitch interval is allowed for the value-parameter
    Property Range As ClsInterval
        Get
            Return MyRange
        End Get
        Set(value As ClsInterval)
            MyRange = value
        End Set
    End Property

    Property DefaultValue As Decimal
        Set(value As Decimal)
            MyDefaultValue = value
        End Set
        Get
            DefaultValue = MyDefaultValue
        End Get
    End Property

End Class
