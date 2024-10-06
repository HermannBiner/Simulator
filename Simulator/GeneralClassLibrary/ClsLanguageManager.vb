'This class provides Labels, Messages and any other text in the actual language

'Status Checked

Imports System.Resources
Imports Simulator.My.Resources

Public Class ClsLanguageManager

    Public Enum LanguageEnum
        English
        Deutsch
    End Enum

    Private MyLanguage As LanguageEnum
    Private RM As ResourceManager
    Private Shared MyLM As ClsLanguageManager

    'The private constructor prohibits the direct instantiation
    Private Sub New()
        'Standard
        MyLanguage = LanguageEnum.Deutsch
        RM = New ResourceManager("Simulator.LabelsDE", GetType(LabelsEN).Assembly)
    End Sub

    ' Stellt die einzige Instanz bereit.
    Public Shared ReadOnly Property LM As ClsLanguageManager
        Get
            If MyLM Is Nothing Then
                MyLM = New ClsLanguageManager()
            End If
            Return MyLM
        End Get
    End Property

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
            Text = Identifier
        End If

        Return Text

    End Function

    Public Function GetString(Identifier As String, IsClass As Boolean) As String

        'If the user programms its own Class to implement an Interface
        'of a dynamic system, he did maybe not fill the Resource-File
        'with the name of its class in Germann and/or English
        'In this case, the Name is added automatically to the resource files
        'the user can change these entries later manually

        'The texts are in the resource-files LabelsDE and LabelsEN
        Dim Text As String = RM.GetString(Identifier)

        If Text = "" Then
            If IsClass Then

                Text = Identifier

                'Cut the 'CLS' part of the class name
                'It is expected in the beginning of the ClassName
                Dim ClsPosition = Text.IndexOf("Cls")
                If ClsPosition = 0 And Text.Length > 3 Then
                    Text = Text.Substring(3)
                Else
                    Throw New FormatException(LM.GetString("ClassNamingViolation"))
                End If

            Else
                Text = Identifier

            End If
        End If

        Return Text

    End Function

End Class
