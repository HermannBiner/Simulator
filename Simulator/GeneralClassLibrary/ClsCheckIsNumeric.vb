'Checks if the manual input in a textbox is numeric
'Status Checked

Public Class ClsCheckIsNumeric

    Private MyTextbox As TextBox
    Private MyNumericValue As Decimal

    Public Sub New(Textbox As TextBox)
        MyTextbox = Textbox
    End Sub

    Public WriteOnly Property TxtBox As TextBox
        Set(value As TextBox)
            MyTextbox = value
        End Set
    End Property

    Public ReadOnly Property NumericValue As Decimal
        Get
            Return MyNumericValue
        End Get
    End Property

    Public Function IsInputValid() As Boolean

        Dim Valid As Boolean

        If Not IsNumeric(MyTextbox.Text) Then
            MessageBox.Show(FrmMain.LM.GetString("NumericValue"))
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
