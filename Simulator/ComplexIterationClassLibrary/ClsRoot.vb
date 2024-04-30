'This Class represents a root of a complex polynom
'That is a complex number combined with a color

'Status Checked

Public Class ClsRoot
    Inherits ClsComplexNumber

    Private MyColor As Brush

    Property Color As Brush
        Get
            Color = MyColor
        End Get
        Set(value As Brush)
            MyColor = Color
        End Set
    End Property

    Public Sub New(x As Double, y As Double, Color As Brush)

        'If the math. coordinates of the point are set when initializing
        MyX = x
        MyY = y
        MyColor = Color

    End Sub

    Public Sub New(Z As ClsComplexNumber, color As Brush)

        'If a complex number is given when initializing
        MyX = Z.X
        MyY = Z.Y
        MyColor = color

    End Sub

    Public Sub New()

        'If the math. coordinates X and Y are set after the Initialization

    End Sub

End Class
