'This class provides Labels, Messages and any other text in the actual language
'Status Checked

Imports System.Resources

Public Class ClsLanguageManager

    Public Enum LanguageEnum
        English
        Deutsch
    End Enum

    Private MyLanguage As LanguageEnum
    Private RM As ResourceManager

    Property Language As LanguageEnum

        'The language is set in the main menu of FrmMain
        Set(value As LanguageEnum)
            MyLanguage = value
            Select Case MyLanguage
                Case LanguageEnum.Deutsch
                    RM = New ResourceManager("Simulator.LabelsDE", GetType(LabelsDE).Assembly)
                Case Else 'English
                    RM = New ResourceManager("Simulator.LabelsEN", GetType(LabelsEN).Assembly)
            End Select
        End Set
        Get
            Return MyLanguage
        End Get
    End Property

    Public Function GetString(Identifier As String) As String

        'The texts are in the resource-files LabelsDE and LabelsEN
        Dim Text As String = RM.GetString(Identifier)

        If Text = "" Then
            Text = "Missing Text: " & Identifier
        End If

        Return Text

    End Function

End Class
