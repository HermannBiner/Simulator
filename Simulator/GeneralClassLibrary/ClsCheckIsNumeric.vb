'Checks if the manual input in a textbox is numeric
'Status Checked

Public Class ClsCheckIsNumeric

    Private ReadOnly MyTextbox As TextBox
    Private MyNumericValue As Decimal

    Public Sub New(Textbox As TextBox)
        MyTextbox = Textbox
    End Sub

    Public ReadOnly Property NumericValue As Decimal
        Get
            Return MyNumericValue
        End Get
    End Property

    Public Function IsInputValid() As Boolean

        Dim Valid As Boolean

        If Not IsNumeric(MyTextbox.Text) Then
            MessageBox.Show(Main.LM.GetString("NumericValue"))
            MyTextbox.Text = ""
            MyTextbox.Select()
            Valid = False
        Else
            Try
                MyNumericValue = CDec(MyTextbox.Text)
                Valid = True
            Catch ex As ArgumentException
                MessageBox.Show(ex.Message)
                MyTextbox.Text = ""
                MyTextbox.Select()
                Valid = False
            End Try
        End If

        Return Valid

    End Function

End Class
