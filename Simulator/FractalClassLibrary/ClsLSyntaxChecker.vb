'This class checks the syntax of an L-System

'Status Checked

Imports System.Text
Imports System.Text.RegularExpressions

Public Class ClsLSyntaxChecker

    Private MyForm As FrmLSystems
    Private ReadOnly LM As ClsLanguageManager
    Private MyActualSystem As ClsLSystem
    Private MySystemEditMode As ClsDynamics.EnEditMode
    Private MyLSystemCollection As New List(Of ClsLSystem)

    Public Sub New(ByRef Form As FrmLSystems)
        MyForm = Form
        LM = ClsLanguageManager.LM
    End Sub

    Public WriteOnly Property ActualSystem As ClsLSystem
        Set(value As ClsLSystem)
            MyActualSystem = value
        End Set
    End Property

    Public WriteOnly Property LSystemCollection As List(Of ClsLSystem)
        Set(value As List(Of ClsLSystem))
            MyLSystemCollection = value
        End Set
    End Property

    Public WriteOnly Property SystemEditMode As ClsDynamics.EnEditMode
        Set(value As ClsDynamics.EnEditMode)
            MySystemEditMode = value
        End Set
    End Property

    Public Function ParameterValuesAreAllowed() As Boolean
        'Check the Syntax of the L-System
        Dim IsOK As Boolean = True
        Dim ErrorMessage As New StringBuilder

        With MyForm

            'Check if the name is empty
            If .TxtName.Text = "" Then
                IsOK = False
                ErrorMessage.AppendLine(LM.GetString("NameMissing"))
            Else
                If MySystemEditMode = ClsDynamics.EnEditMode.Add Then
                    'Check if the name is already used
                    Dim LSystem As ClsLSystem = MyLSystemCollection.Find(Function(x) x.Name = .TxtName.Text)
                    If LSystem IsNot Nothing Then
                        IsOK = False
                        ErrorMessage.AppendLine(LM.GetString("NameAlreadyUsed"))
                    End If
                End If
            End If

            'Check if the axiom is empty
            If .TxtAxiom.Text = "" Then
                IsOK = False
                ErrorMessage.AppendLine(LM.GetString("AxiomMissing"))
            Else
                'Check if the axiom contains only allowed characters
                Dim AllowedAxiomChars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZfg+-"
                For Each C As Char In .TxtAxiom.Text
                    If Not AllowedAxiomChars.Contains(C) Then
                        IsOK = False
                        ErrorMessage.AppendLine(LM.GetString("AxiomContainsIllegalCharacters"))
                        Exit For
                    End If
                Next
            End If

            'Check if the scale factor is a number in [0,1]
            If Not IsNumeric(.TxtScaleFactor.Text) Then
                IsOK = False
                ErrorMessage.AppendLine(LM.GetString("ScaleFactorMissing"))
            Else
                If CDec(.TxtScaleFactor.Text) <= 0 Or CDec(.TxtScaleFactor.Text) > 1 Then
                    IsOK = False
                    ErrorMessage.AppendLine(LM.GetString("ScaleFactorIn0to1"))
                End If
            End If


            'Check if the StartLength is a number in [0,13]
            If Not IsNumeric(.TxtStartLength.Text) Then
                IsOK = False
                ErrorMessage.AppendLine(LM.GetString("StartLengthMissing"))
            Else
                If CDec(.TxtScaleFactor.Text) <= 0 Or CDec(.TxtScaleFactor.Text) > 13 Then
                    IsOK = False
                    ErrorMessage.AppendLine(LM.GetString("InvalidStartLength"))
                End If
            End If

            'Check if the angle is a number in [0, 360[
            If Not IsNumeric(.TxtAngleLeft.Text) Or Not IsNumeric(.TxtAngleRight.Text) Then
                IsOK = False
                ErrorMessage.AppendLine(LM.GetString("AngleMissing"))
            Else
                If CDec(.TxtAngleLeft.Text) < 0 Or CDec(.TxtAngleLeft.Text) > 360 Then
                    IsOK = False
                    ErrorMessage.AppendLine(LM.GetString("AngleIn0to360"))
                End If
                If CDec(.TxtAngleRight.Text) < 0 Or CDec(.TxtAngleRight.Text) > 360 Then
                    IsOK = False
                    ErrorMessage.AppendLine(LM.GetString("AngleIn0to360"))
                End If
            End If

            'Check if the rules are empty
            If MyActualSystem.Rules.Count = 0 Then
                IsOK = False
                ErrorMessage.AppendLine(LM.GetString("NoRulesExisting"))
            Else
                'Check if the rules contain only allowed characters
                Dim AllowedRuleChars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZfg+-()[]0123456789"
                For Each Rule In MyActualSystem.Rules
                    Dim Source As String = Rule.Key
                    Dim Target As String = Rule.Value
                    For Each C As Char In Source
                        If Not AllowedRuleChars.Contains(C) Then
                            IsOK = False
                            ErrorMessage.AppendLine(LM.GetString("SourceContainsIllegalCharacters"))
                            Exit For
                        End If
                    Next
                    For Each C As Char In Target
                        If Not AllowedRuleChars.Contains(C) Then
                            IsOK = False
                            ErrorMessage.AppendLine(LM.GetString("TargetContainsIllegalCharacters"))
                            Exit For
                        End If
                    Next
                Next
            End If

            'Show error message if there are errors
            If Not IsOK Then
                MessageBox.Show(ErrorMessage.ToString(), LM.GetString("Error"),
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End With

        Return IsOK

    End Function

    Public Function RulesAreConsistent() As Boolean

        Dim IsOK As Boolean = True
        Dim ErrorMessage As New StringBuilder

        'Check if the rules are complete
        'For Each Character in Axiom and Target, 
        'Check if there is a rule for it
        'that means, there is a source with this character
        'Build the string with all characters in the axiom and target
        Dim AllTargetChars As String = MyActualSystem.Axiom
        For Each Rule In MyActualSystem.Rules
            Dim Target As String = Rule.Value
            AllTargetChars += Target
        Next

        'Check if there is a rule for each character in AllChars
        'that means, there is a source with this character
        Dim AllSourceCharsString As String = ""
        For Each Rule In MyActualSystem.Rules
            Dim Source As String = Rule.Key
            AllSourceCharsString += Source
        Next

        For Each C As Char In AllTargetChars
            If C <> "+" And C <> "-" And C <> "(" And C <> ")" And C <> "[" And C <> "]" And UCase(C) <> "F" _
                And Not IsNumeric(C) Then
                'Check if the character is in the source
                If Not AllSourceCharsString.Contains(C) Then
                    IsOK = False
                    ErrorMessage.AppendLine(LM.GetString("NoRuleForChar") & ": " & C)
                End If
            End If
        Next

        '(..) in the Target contains only color-values, that is an integer between 0 and 25
        'First, the number of "(" and ")" must be the same
        Dim OpenBrackets As Integer = 0
        Dim CloseBrackets As Integer = 0
        For Each Rule In MyActualSystem.Rules
            Dim Target As String = Rule.Value
            OpenBrackets += Target.Count(Function(c) c = "(")
            CloseBrackets += Target.Count(Function(c) c = ")")
        Next

        If OpenBrackets <> CloseBrackets Then
            IsOK = False
            ErrorMessage.AppendLine(LM.GetString("BracketsMissing()"))
        Else
            For Each Rule In MyActualSystem.Rules
                Dim Target As String = Rule.Value
                Dim regexAllBrackets As New Regex("\([^\)]*\)") ' Find all (...) – including invalid contents
                Dim regexValidColor As New Regex("^\((\d{1,2})\)$") ' Find valid ColorCodes (0)-(25)

                For Each match As Match In regexAllBrackets.Matches(Target)
                    Dim bracketContent As String = match.Value
                    If regexValidColor.IsMatch(bracketContent) Then
                        Dim number As Integer = Integer.Parse(regexValidColor.Match(bracketContent).Groups(1).Value)
                        If number < 0 OrElse number > 25 Then
                            IsOK = False
                            ErrorMessage.AppendLine(LM.GetString("ColorCodeInvalid") & ": " & number)
                        End If
                    Else
                        IsOK = False
                        'Invalid content in brackets
                        ErrorMessage.AppendLine(LM.GetString("ColorCodeInvalid"))
                    End If
                Next
            Next
        End If

        'dito for []
        OpenBrackets = 0
        CloseBrackets = 0
        For Each Rule In MyActualSystem.Rules
            Dim Target As String = Rule.Value
            OpenBrackets += Target.Count(Function(c) c = "[")
            CloseBrackets += Target.Count(Function(c) c = "]")
        Next
        If OpenBrackets <> CloseBrackets Then
            IsOK = False
            ErrorMessage.AppendLine(LM.GetString("BracketsMissing[]"))
        End If

        'Show error message if there are errors
        If Not IsOK Then
            MessageBox.Show(ErrorMessage.ToString(), LM.GetString("Error"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Return IsOK

    End Function
End Class
