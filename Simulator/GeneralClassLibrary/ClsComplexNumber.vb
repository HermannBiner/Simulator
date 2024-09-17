'This class represents a complex number
'z = x+iy
'x and y are represented as ClsMathPoint

'Status Checked

Public Class ClsComplexNumber

    Property MyX As Double
    Property MyY As Double

    Private ReadOnly MathHelper As ClsMathHelperComplex

    Public Sub New(x As Double, y As Double)

        'If the math. coordinates of the point are set when initializing
        MyX = x
        MyY = y
        MathHelper = New ClsMathHelperComplex
    End Sub

    Public Sub New()

        'If the math. coordinates X and Y are set after the Initialization
        MathHelper = New ClsMathHelperComplex
    End Sub

    Property X As Double
        Get
            X = MyX
        End Get
        Set(value As Double)
            MyX = value
        End Set
    End Property

    Property Y As Double
        Get
            Y = MyY
        End Get
        Set(value As Double)
            MyY = value
        End Set
    End Property

    'Calculates the absolute value of the complex number
    ReadOnly Property AbsoluteValue As Double
        Get
            AbsoluteValue = Math.Sqrt(MyX * MyX + MyY * MyY)
        End Get
    End Property

    'Calculates the argument (i.e. the angle phi) of the complex number
    ReadOnly Property Argument As Double
        Get
            Argument = MathHelper.GetArgument(MyX, MyY)
        End Get
    End Property

    'Calculates the conjugate complex number
    ReadOnly Property Conjugate As ClsComplexNumber
        Get
            Conjugate = New ClsComplexNumber(MyX, -MyY)
        End Get
    End Property

    'Adds the complex value a to the complex number
    ReadOnly Property Add(a As ClsComplexNumber) As ClsComplexNumber
        Get
            Add = New ClsComplexNumber(MyX + a.X, MyY + a.Y)
        End Get
    End Property

    'Multiplies the complex number ba the real value a
    ReadOnly Property Stretch(a As Double) As ClsComplexNumber
        Get
            Stretch = New ClsComplexNumber(MyX * a, MyY * a)
        End Get
    End Property

    'Calculates the product of the complex number and u
    ReadOnly Property Mult(u As ClsComplexNumber) As ClsComplexNumber
        Get
            Mult = Multiply(u)
        End Get
    End Property

    'Divides the complex number by c
    ReadOnly Property Div(c As ClsComplexNumber) As ClsComplexNumber
        Get
            If c.AbsoluteValue = 0 Then
                Throw New DivideByZeroException("Division by Zero")
                Return Nothing
            Else
                Div = Divide(c)
            End If
        End Get
    End Property

    'rotates the complex number by the angle phi
    ReadOnly Property Rotate(phi As Double) As ClsComplexNumber
        Get
            Rotate = New ClsComplexNumber(MyX, MyY).Mult(New ClsComplexNumber(Math.Cos(phi), Math.Sin(phi)))
        End Get
    End Property

    'Calculates the invers value of the complex number
    ReadOnly Property Invers() As ClsComplexNumber
        Get
            Dim Result = New ClsComplexNumber(MyX, MyY).Conjugate
            Invers = Result.Stretch(1 / (Result.AbsoluteValue * Result.AbsoluteValue))
        End Get
    End Property

    'Calculates the square of the complex number
    ReadOnly Property Power2 As ClsComplexNumber
        Get
            Power2 = GetPower2(MyX, MyY)
        End Get
    End Property

    'Calculates the n-th power of the complex number
    ReadOnly Property Power(n As Integer) As ClsComplexNumber
        Get
            Power = GetPower(New ClsComplexNumber(MyX, MyY), n)
        End Get
    End Property

    'Calculates the product of the complex number and u
    Private Function Multiply(u As ClsComplexNumber) As ClsComplexNumber

        Dim Result = New ClsComplexNumber(MyX * u.X - MyY * u.Y, MyX * u.Y + MyY * u.X)
        Return Result

    End Function

    'Divides the complex number by c
    Private Function Divide(c As ClsComplexNumber) As ClsComplexNumber

        Dim Nominator = New ClsComplexNumber(c.X * MyX + c.Y * MyY, c.X * MyY - c.Y * MyX)
        Dim Divisor As Decimal = CDec(Math.Pow(c.AbsoluteValue, 2))
        Return Nominator.Stretch(1 / Divisor)

    End Function

    'Calculates the n-th power of the complex number
    Private Shared Function GetPower(u As ClsComplexNumber, n As Integer) As ClsComplexNumber

        Dim k As Integer
        Dim Result As New ClsComplexNumber

        Select Case n
            Case < 0
                Result = u.Invers
                n = -n
            Case 0
                Result.X = 0
                Result.Y = 0
            Case Else
                Result = u
        End Select

        If n > 0 Then
            Do While k < n - 1
                k += 1
                Result = Result.Multiply(u)
            Loop
        End If

        Return Result

    End Function

    'Calculates the square of the complex number
    Private Shared Function GetPower2(X As Double, Y As Double) As ClsComplexNumber

        Dim Result = New ClsComplexNumber(X * X - Y * Y, 2 * X * Y)
        Return Result

    End Function

End Class
