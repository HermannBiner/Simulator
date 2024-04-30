'Checks if the manual input in two textboxes represents an interval
'Status Checked

Public Class ClsCheckIsInterval

    'Textbox containing the left interval border
    Private ReadOnly MyTextboxA As TextBox

    'Left interval border
    Private MyA As Decimal

    'Textbox containing the right interval border
    Private ReadOnly MyTextboxB As TextBox

    'Right interval border
    Private MyB As Decimal

    Public Sub New(TextboxA As TextBox, TextboxB As TextBox)
        MyTextboxA = TextboxA
        MyTextboxB = TextboxB
    End Sub

    Public ReadOnly Property A As Decimal
        Get
            Return MyA
        End Get
    End Property

    Public ReadOnly Property B As Decimal
        Get
            Return MyB
        End Get
    End Property

    Public Function IsIntervalValid() As Boolean

        Dim IsAValid As Boolean
        Dim IsBValid As Boolean

        If Not IsNumeric(MyTextboxA.Text) Then
            MessageBox.Show(Main.LM.GetString("NumericValue"))
            MyTextboxA.Text = ""
            MyTextboxA.Select()
            IsAValid = False
        Else
            Try
                MyA = CDec(MyTextboxA.Text)
                IsAValid = True
            Catch ex As ArgumentException
                MessageBox.Show(ex.Message)
                MyTextboxA.Text = ""
                MyTextboxA.Select()
                IsAValid = False
            End Try
        End If

        If IsAValid Then
            If Not IsNumeric(MyTextboxB.Text) Then
                MessageBox.Show(Main.LM.GetString("NumericValue"))
                MyTextboxB.Text = ""
                MyTextboxB.Select()
                IsBValid = False
            Else
                Try
                    MyB = CDec(MyTextboxB.Text)
                    IsBValid = True
                Catch ex As ArgumentException
                    MessageBox.Show(ex.Message)
                    MyTextboxB.Text = ""
                    MyTextboxB.Select()
                    IsBValid = False
                End Try
            End If

            If IsBValid And MyA >= MyB Then
                MessageBox.Show(Main.LM.GetString("LeftSmallerRight"))
                MyTextboxA.Text = ""
                MyTextboxA.Select()
                IsAValid = False
            End If
        End If

        Return IsAValid And IsBValid

    End Function

End Class
