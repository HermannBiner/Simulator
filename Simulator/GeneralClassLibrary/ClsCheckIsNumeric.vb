'Checks if the manual input in a textbox is numeric

'Status Checked

Public Class ClsCheckIsNumeric

    Private LM As ClsLanguageManager

    Private MyTextbox As TextBox
    Private MyNumericValue As Decimal

    Public Sub New(Textbox As TextBox)
        LM = ClsLanguageManager.LM
        MyTextbox = Textbox
    End Sub

    WriteOnly Property TxtBox As TextBox
        Set(value As TextBox)
            MyTextbox = value
        End Set
    End Property

    ReadOnly Property NumericValue As Decimal
        Get
            Return MyNumericValue
        End Get
    End Property

    Public Function IsInputValid() As Boolean

        Dim IsValid As Boolean

        If Not IsNumeric(MyTextbox.Text) Then
            MessageBox.Show(LM.GetString("NumericValue"))
            MyTextbox.Text = ""
            MyTextbox.Select()
            IsValid = False
        Else
            Try
                MyNumericValue = CDec(MyTextbox.Text)
                IsValid = True
            Catch ex As ArgumentException
                MessageBox.Show(ex.Message)
                MyTextbox.Text = ""
                MyTextbox.Select()
                IsValid = False
            End Try
        End If

        Return IsValid

    End Function

End Class
