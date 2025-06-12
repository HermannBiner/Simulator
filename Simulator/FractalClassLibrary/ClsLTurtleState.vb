'This class contains a turtle state - used for the Stack

'Status Checked


Public Class ClsLTurtleState

    Private MyPosition As ClsMathpoint
    Private MyAngle As Integer
    Private MyColor As SolidBrush
    Private MyStepLength As Decimal

    Public Sub New()
        MyPosition = New ClsMathpoint(0, 0)
    End Sub

    Public Property Position As ClsMathpoint
        Get
            Return MyPosition
        End Get
        Set(value As ClsMathpoint)
            MyPosition = value
        End Set
    End Property

    Public Property Angle As Integer
        Get
            Return MyAngle
        End Get
        Set(value As Integer)
            MyAngle = value
        End Set
    End Property

    Public Property Color As SolidBrush
        Get
            Return MyColor
        End Get
        Set(value As SolidBrush)
            MyColor = value
        End Set
    End Property

    Public Property StepLength As Decimal
        Get
            Return MyStepLength
        End Get
        Set(value As Decimal)
            MyStepLength = value
        End Set
    End Property

End Class
