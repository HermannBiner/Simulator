'Represents an interval of real numbers [A,B] with A < B

'Status Checked

Public Class ClsInterval

    Private ReadOnly LM As ClsLanguageManager

    'left and right interval border
    Private ReadOnly MyA As Double
    Private ReadOnly MyB As Double

    Public Sub New(a As Double, b As Double)
        LM = ClsLanguageManager.LM

        'The interval borders A and B are committed

        If a >= b Then
            Throw New ArgumentException(LM.GetString("LeftSmallerRight"))
        Else
            MyA = a
            MyB = b
        End If

    End Sub

    Public Sub New(MyInterval As ClsInterval)
        LM = ClsLanguageManager.LM
        'Alternatively, an existing interval is transmitted

        MyA = MyInterval.A
        MyB = MyInterval.B

    End Sub

    Public ReadOnly Property A As Double
        Get
            A = MyA
        End Get
    End Property

    Public ReadOnly Property B As Double
        Get
            B = MyB
        End Get
    End Property

    Public ReadOnly Property IntervalWidth As Double
        Get
            Return MyB - MyA
        End Get
    End Property

    Public Function IsNumberInInterval(Number As Object) As Boolean

        'Checks if the Number is in the interval [A,B]

        If TypeOf Number Is Integer Then
            Dim IntNumber As Integer = DirectCast(Number, Integer)
            Return IntNumber >= MyA And IntNumber <= MyB
        ElseIf TypeOf Number Is Double Then
            Dim DblNumber As Double = DirectCast(Number, Double)
            Return DblNumber >= MyA And DblNumber <= MyB
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