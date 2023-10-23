'This class provides Labels, Messages and any other text in the actual language

Imports System.Resources

Public Class ClsLanguageManager

    Public Enum LanguageEnum
        English
        Deutsch
    End Enum

    Private MyLanguage As LanguageEnum
    Private RM As ResourceManager

    Property Language As LanguageEnum
        Set(value As LanguageEnum)
            MyLanguage = value
            Select Case MyLanguage
                Case LanguageEnum.Deutsch
                    RM = New ResourceManager("Simulator.LabelsDE", GetType(LabelsDE).Assembly)
                Case Else
                    RM = New ResourceManager("Simulator.LabelsEN", GetType(LabelsEN).Assembly)
            End Select
        End Set
        Get
            Return MyLanguage
        End Get
    End Property

    Public Function GetString(Identifier As String) As String

        Dim Text As String = RM.GetString(Identifier)

        If Text = "" Then
            Text = "Missing Text"
        End If

        Return Text

    End Function

End Class
