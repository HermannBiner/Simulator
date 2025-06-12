'Represents an interval of real numbers [A,B] with A < B

'Status Checked

Public Class ClsInterval

    Private ReadOnly LM As ClsLanguageManager

    'left and right interval border
    Private ReadOnly MyA As Decimal
    Private ReadOnly MyB As Decimal

    Private MyDblA As Double
    Private MyDblB As Double

    Public Sub New(a As Decimal, b As Decimal)
        LM = ClsLanguageManager.LM

        'The interval borders A and B are committed

        If a >= b Then
            Throw New ArgumentException(LM.GetString("LeftSmallerRight"))
        Else
            MyA = a
            MyB = b
            MyDblA = CDbl(a)
            MyDblB = CDbl(b)
        End If

    End Sub

    Public Sub New(DblA As Double, DblB As Double)
        LM = ClsLanguageManager.LM
        'The interval borders A and B are committed

        If DblA >= DblB Then
            Throw New ArgumentException(LM.GetString("LeftSmallerRight"))
        Else
            MyA = CDec(DblA)
            MyB = CDec(DblB)
            MyDblA = DblA
            MyDblB = DblB
        End If
    End Sub

    Public Sub New(MyInterval As ClsInterval)
        LM = ClsLanguageManager.LM
        'Alternatively, an existing interval is transmitted

        MyA = MyInterval.A
        MyB = MyInterval.B

    End Sub

    Public ReadOnly Property A As Decimal
        Get
            A = MyA
        End Get
    End Property

    Public ReadOnly Property B As Decimal
        Get
            B = MyB
        End Get
    End Property

    Public ReadOnly Property DblA As Double
        Get
            DblA = MyDblA
        End Get
    End Property

    Public ReadOnly Property DblB As Double
        Get
            DblB = MyDblB
        End Get
    End Property

    Public ReadOnly Property IntervalWidth As Decimal
        Get
            Return MyB - MyA
        End Get
    End Property

    Public ReadOnly Property DblIntervalWidth As Double
        Get
            Return MyDblB - MyDblA
        End Get
    End Property

    Public Function IsNumberInInterval(Number As Object) As Boolean

        'Checks if the Number is in the interval [A,B]

        If TypeOf Number Is Integer Then
            Dim IntNumber As Integer = DirectCast(Number, Integer)
            Return IntNumber >= MyA And IntNumber <= MyB
        ElseIf TypeOf Number Is Decimal Then
            Dim DecNumber As Decimal = DirectCast(Number, Decimal)
            Return DecNumber >= MyA And DecNumber <= MyB
        ElseIf TypeOf Number Is Double Then
            Dim DblNumber As Double = DirectCast(Number, Double)
            Return DblNumber >= MyDblA And DblNumber <= MyDblB
        Else
            MessageBox.Show(LM.GetString("OnlyDecAndIntAndDbl"))
            Return False
        End If

    End Function

    Public Function IsInterval2PartOfInterval(Interval2 As ClsInterval) As Boolean

        'Checks if an Interval2 is contained in the Interval

        Return (Interval2.A >= MyA) And (Interval2.B <= MyB)

    End Function

End Class
