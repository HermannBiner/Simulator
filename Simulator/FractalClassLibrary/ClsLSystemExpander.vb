'This class generates the next Generation of L-system string
'based on the rules defined in the ClsLsystem class.

'Status Checked

Public Class ClsLSystemExpander

    Private MyRules As Dictionary(Of String, String)

    WriteOnly Property Rules As Dictionary(Of String, String)
        Set(value As Dictionary(Of String, String))
            MyRules = value
        End Set
    End Property

    Public Function ExpandItinerary(ActualItinerary As String) As String

        Dim NextItinerary As New Text.StringBuilder

        For Each c As Char In ActualItinerary
            If MyRules.ContainsKey(c) Then
                NextItinerary.Append(MyRules(c))
            Else
                NextItinerary.Append(c)
            End If
        Next

        Return NextItinerary.ToString()

    End Function


End Class
