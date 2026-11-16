'This Class holds the L-System
'The file is loaded into a Dictionary

'Status Checked

Public Class ClsLSystem

    Enum EnLSystemType
        Standard 'wihtout a tree structure
        Tree 'with a tree structure
        Dragon 'in that case, extended options are available
    End Enum

    Private MyID As Integer
    Private MyName As String
    Private MyType As EnLSystemType

    Private MyAxiom As String
    Private MyScaleFactor As Double
    Private MyAngleLeft As Integer
    Private MyAngleRight As Integer
    Private MyColor As Integer

    'If = 1, before ending a branche by "]", a bud is created
    Private MyIsExtended As Boolean
    Private MyIsColorFixed As Boolean
    Private MyIsBudding As Boolean
    Private MyStartLength As Double
    Private MyScaling As ClsLSystemsController.EnScaling
    Private MyStartpositionX As Double
    Private MyStartpositionY As Double

    Private MyRules As Dictionary(Of String, String)

    Public Property ID As Integer
        Get
            Return MyID
        End Get
        Set(value As Integer)
            MyID = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return MyName
        End Get
        Set(value As String)
            MyName = value
        End Set
    End Property

    Public Property Type As EnLSystemType
        Get
            Return MyType
        End Get
        Set(value As EnLSystemType)
            MyType = value
        End Set
    End Property

    Public Property Axiom As String
        Get
            Return MyAxiom
        End Get
        Set(value As String)
            MyAxiom = value
        End Set
    End Property

    Public Property ScaleFactor As Double
        Get
            Return MyScaleFactor
        End Get
        Set(value As Double)
            MyScaleFactor = value
        End Set
    End Property

    'Angle in degrees
    Public Property AngleLeft As Integer
        Get
            Return MyAngleLeft
        End Get
        Set(value As Integer)
            MyAngleLeft = value
        End Set
    End Property

    'Angle in degrees
    Public Property AngleRight As Integer
        Get
            Return MyAngleRight
        End Get
        Set(value As Integer)
            MyAngleRight = value
        End Set
    End Property

    Public Property Color As Integer
        Get
            Return MyColor
        End Get
        Set(value As Integer)
            MyColor = value
        End Set
    End Property

    Public Property IsExtended As Boolean
        Get
            Return MyIsExtended
        End Get
        Set(value As Boolean)
            MyIsExtended = value
        End Set
    End Property

    Public Property IsColorFixed As Boolean
        Get
            Return MyIsColorFixed
        End Get
        Set(value As Boolean)
            MyIsColorFixed = value
        End Set
    End Property

    Public Property IsBudding As Boolean
        Get
            Return MyIsBudding
        End Get
        Set(value As Boolean)
            MyIsBudding = value
        End Set
    End Property

    Public Property StartLength As Double
        Get
            Return MyStartLength
        End Get
        Set(value As Double)
            MyStartLength = value
        End Set
    End Property

    Public Property Scaling As ClsLSystemsController.EnScaling
        Get
            Return MyScaling
        End Get
        Set(value As ClsLSystemsController.EnScaling)
            MyScaling = value
        End Set
    End Property

    Public Property StartPositionX As Double
        Get
            Return MyStartpositionX
        End Get
        Set(value As Double)
            MyStartpositionX = value
        End Set
    End Property

    Public Property StartPositionY As Double
        Get
            Return MyStartpositionY
        End Get
        Set(value As Double)
            MyStartpositionY = value
        End Set
    End Property

    Public Property Rules As Dictionary(Of String, String)
        Get
            Return MyRules
        End Get
        Set(value As Dictionary(Of String, String))
            MyRules = value
        End Set
    End Property

    'Returns a copy of the system with its own rules
    'the system is edited as a copy, so Cancel keeps the stored system
    Public Function Copy() As ClsLSystem
        Dim Result = CType(MemberwiseClone(), ClsLSystem)
        If MyRules IsNot Nothing Then
            Result.Rules = New Dictionary(Of String, String)(MyRules)
        End If
        Return Result
    End Function
End Class
