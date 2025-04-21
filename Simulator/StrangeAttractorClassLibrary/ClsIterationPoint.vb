'This class represents a point in the iteration process
'moving to a strange attractor

'Staus Tested

Public Class ClsIterationPoint

    Private MyDefaultStartPoint As ClsMathpoint
    Private MyUserStartPoint As ClsMathpoint
    Private MyActualPoint As ClsMathpoint
    Private MyColor As Brush

    Property DefaultStartPoint As ClsMathpoint
        Get
            Return MyDefaultStartPoint
        End Get
        Set(value As ClsMathpoint)
            MyDefaultStartPoint = value
        End Set
    End Property

    Property UserStartPoint As ClsMathpoint
        Get
            Return MyUserStartPoint
        End Get
        Set(value As ClsMathpoint)
            MyUserStartPoint = value
        End Set
    End Property

    Property ActualPoint As ClsMathpoint
        Get
            Return MyActualPoint
        End Get
        Set(value As ClsMathpoint)
            MyActualPoint = value
        End Set
    End Property

    Property Color As Brush
        Get
            Return MyColor
        End Get
        Set(value As Brush)
            MyColor = value
        End Set
    End Property

    Public Sub New(x As Decimal, y As Decimal, z As Decimal, Color As Brush)
        MyDefaultStartPoint = New ClsMathpoint(x, y, z)
        MyUserStartPoint = New ClsMathpoint(x, y, z)
        MyActualPoint = New ClsMathpoint(x, y, z)
        MyColor = Color
    End Sub

    Public Sub SetDefaultUserData()
        UserStartPoint.Equal(DefaultStartPoint)
        ActualPoint.Equal(DefaultStartPoint)
    End Sub

    Public Sub ResetIteration()
        ActualPoint.Equal(UserStartPoint)
    End Sub

End Class
