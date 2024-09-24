'This class is the frame for Samples of special Julia Sets

'Status Checked

Public Class ClsJuliaSample

    Private MyName As String

    Private MyC As ClsComplexNumber

    Public Sub New(Name As String, C As ClsComplexNumber)
        MyName = Name
        MyC = C
    End Sub

    ReadOnly Property Name As String
        Get
            Name = MyName
        End Get
    End Property

    ReadOnly Property C As ClsComplexNumber
        Get
            C = MyC
        End Get
    End Property

End Class
