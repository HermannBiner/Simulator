﻿'Represents an interval of real numbers [A,B] with A < B
'Status Checked

Public Class ClsInterval

    'left and right interval border
    Private ReadOnly MyA As Decimal
    Private ReadOnly MyB As Decimal

    Public Sub New(a As Decimal, b As Decimal)

        'The interval borders A and B are committed

        If a >= b Then
            Throw New ArgumentException(Main.LM.GetString("LeftSmallerRight"))
        Else
            MyA = a
            MyB = b
        End If

    End Sub

    Public Sub New(MyInterval As ClsInterval)

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

    Public ReadOnly Property IntervalWidth As Decimal
        Get
            Return MyB - MyA
        End Get
    End Property

    Public Function IsNumberInInterval(number As Object) As Boolean

        'Checks if the Number belongs to the interval [A,B]

        If TypeOf number Is Integer Then
            Dim IntNumber As Integer = DirectCast(number, Integer)
            Return IntNumber >= MyA And IntNumber <= MyB
        ElseIf TypeOf number Is Decimal Then
            Dim DecNumber As Decimal = DirectCast(number, Decimal)
            Return DecNumber >= MyA And DecNumber <= MyB
        Else
            MessageBox.Show(Main.LM.GetString("OnlyDecAndInt"))
            Return False
        End If

    End Function

    Public Function IsInterval2PartOfInterval(Interval2 As ClsInterval) As Boolean

        'Checks if an Interval2 is contained in the Interval

        Return (Interval2.A >= MyA) And (Interval2.B <= MyB)

    End Function

End Class
