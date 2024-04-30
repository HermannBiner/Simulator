'This class represents a complex number
'z = x+iy
'x and y are represented as ClsMathPoint

'Status Checked


Imports System.ComponentModel

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

    ReadOnly Property AbsoluteValue As Double
        Get
            AbsoluteValue = Math.Sqrt(MyX * MyX + MyY * MyY)
        End Get
    End Property

    ReadOnly Property Argument As Double
        Get
            Argument = MathHelper.GetArgument(MyX, MyY)
        End Get
    End Property

    ReadOnly Property Conjugate As ClsComplexNumber
        Get
            Conjugate = New ClsComplexNumber(MyX, -MyY)
        End Get
    End Property

    ReadOnly Property Add(a As ClsComplexNumber) As ClsComplexNumber
        Get
            Add = New ClsComplexNumber(MyX + a.X, MyY + a.Y)
        End Get
    End Property

    ReadOnly Property Stretch(a As Double) As ClsComplexNumber
        Get
            Stretch = New ClsComplexNumber(MyX * a, MyY * a)
        End Get
    End Property

    ReadOnly Property Mult(u As ClsComplexNumber) As ClsComplexNumber
        Get
            Mult = Multiply(u)
        End Get
    End Property

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

    ReadOnly Property Rotate(phi As Double) As ClsComplexNumber
        Get
            Rotate = New ClsComplexNumber(MyX, MyY).Mult(New ClsComplexNumber(Math.Cos(phi), Math.Sin(phi)))
        End Get
    End Property

    ReadOnly Property Invers() As ClsComplexNumber
        Get

            Dim Result = New ClsComplexNumber(MyX, MyY).Conjugate
            Invers = Result.Stretch(1 / (Result.AbsoluteValue * Result.AbsoluteValue))

        End Get
    End Property

    Private Function Multiply(u As ClsComplexNumber) As ClsComplexNumber

        Dim Result = New ClsComplexNumber(MyX * u.X - MyY * u.Y, MyX * u.Y + MyY * u.X)
        Return Result

    End Function

    Private Function Divide(c As ClsComplexNumber) As ClsComplexNumber

        Dim Nominator = New ClsComplexNumber(c.X * MyX + c.Y * MyY, c.X * MyY - c.Y * MyX)
        Dim Divisor As Decimal = CDec(Math.Pow(c.AbsoluteValue, 2))
        Return Nominator.Stretch(1 / Divisor)

    End Function

    'We prepare some powers of the Complex Number
    ReadOnly Property Power2 As ClsComplexNumber
        Get
            Power2 = GetPower2(MyX, MyY)
        End Get
    End Property

    ReadOnly Property Power3 As ClsComplexNumber
        Get
            Power3 = GetPower3(MyX, MyY)
        End Get
    End Property

    ReadOnly Property Power4 As ClsComplexNumber
        Get
            Power4 = GetPower4(MyX, MyY)
        End Get
    End Property

    ReadOnly Property Power5 As ClsComplexNumber
        Get
            Power5 = GetPower5(MyX, MyY)
        End Get
    End Property

    ReadOnly Property Power6 As ClsComplexNumber
        Get
            Power6 = GetPower6(MyX, MyY)
        End Get
    End Property

    ReadOnly Property Power7 As ClsComplexNumber
        Get
            Power7 = GetPower7(MyX, MyY)
        End Get
    End Property

    ReadOnly Property Power8 As ClsComplexNumber
        Get
            Power8 = GetPower8(MyX, MyY)
        End Get
    End Property

    ReadOnly Property Power9 As ClsComplexNumber
        Get
            Power9 = GetPower9(MyX, MyY)
        End Get
    End Property

    ReadOnly Property Power10 As ClsComplexNumber
        Get
            Power10 = GetPower10(MyX, MyY)
        End Get
    End Property
    Private Function GetPower2(X As Double, Y As Double) As ClsComplexNumber

        Dim Result = New ClsComplexNumber(X * X - Y * Y, 2 * X * Y)
        Return Result

    End Function

    Private Function GetPower3(X As Double, Y As Double) As ClsComplexNumber

        Dim Result = New ClsComplexNumber(X * X * X - 3 * X * Y * Y, 3 * X * X * Y - Y * Y * Y)
        Return Result

    End Function

    Private Function GetPower4(x As Double, y As Double) As ClsComplexNumber

        Return GetPower2(GetPower2(x, y).X, GetPower2(x, y).Y)

    End Function

    Private Function GetPower5(x As Double, y As Double) As ClsComplexNumber

        Dim W = New ClsComplexNumber(GetPower2(x, y).X, GetPower2(x, y).Y)
        Return W.Mult(New ClsComplexNumber(GetPower3(x, y).X, GetPower3(x, y).Y))

    End Function

    Private Function GetPower6(x As Double, y As Double) As ClsComplexNumber

        Dim W = New ClsComplexNumber(GetPower3(x, y).X, GetPower3(x, y).Y)
        Return W.Mult(New ClsComplexNumber(GetPower3(x, y).X, GetPower3(x, y).Y))

    End Function

    Private Function GetPower7(x As Double, y As Double) As ClsComplexNumber

        Dim W = New ClsComplexNumber(GetPower4(x, y).X, GetPower4(x, y).Y)
        Return W.Mult(New ClsComplexNumber(GetPower3(x, y).X, GetPower3(x, y).Y))

    End Function

    Private Function GetPower8(x As Double, y As Double) As ClsComplexNumber

        Dim W = New ClsComplexNumber(GetPower4(x, y).X, GetPower4(x, y).Y)
        Return W.Mult(New ClsComplexNumber(GetPower4(x, y).X, GetPower4(x, y).Y))

    End Function

    Private Function GetPower9(x As Double, y As Double) As ClsComplexNumber

        Dim W = New ClsComplexNumber(GetPower4(x, y).X, GetPower4(x, y).Y)
        Return W.Mult(New ClsComplexNumber(GetPower5(x, y).X, GetPower5(x, y).Y))

    End Function

    Private Function GetPower10(x As Double, y As Double) As ClsComplexNumber

        Dim W = New ClsComplexNumber(GetPower5(x, y).X, GetPower5(x, y).Y)
        Return W.Mult(New ClsComplexNumber(GetPower4(x, y).X, GetPower4(x, y).Y))

    End Function

    'if needed, it is easy to continue with this list

End Class
