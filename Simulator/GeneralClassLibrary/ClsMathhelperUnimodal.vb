'Contains mathematical help functions for all kind of unimodal functions
'see mathematical documentation

'Status Checked

Public Class ClsMathhelperUnimodal

    Private ReadOnly LM As ClsLanguageManager

    Public Sub New()
        LM = ClsLanguageManager.LM
    End Sub

    Public Function DualStringToDecimalNumber(DualString As String, IsMidOfInterval As Boolean) As Decimal

        'The dualstring represents a positive dual number < 1
        'this method calculates the according decimal number
        'because further digits "behind" the dualstring are not known
        'the method rounds the calculated decimal number to the middle of the next missing interval
        'of the dual number, if the option "MidOfInterval" is activated
        'therefore, the possible error of the returned decimal number
        'due to the missing dual digits is as small as possible

        Dim TempDecimalnumber As Decimal = 0 'Contains the decimal number
        Dim i As Integer 'Position of the actual digit
        Dim Factor As Decimal = 1 'Power of "2" according to the actual digit position

        For i = 1 To DualString.Length
            Factor /= 2
            Select Case Mid(DualString, i, 1)
                Case "1"
                    TempDecimalnumber += Factor
                Case "0"
                    'nothing to do
                Case Else
                    Throw New ArgumentException(LM.GetString("InvalidDualNumberDigits"))
                    Return 0
            End Select
        Next

        If IsMidOfInterval Then
            TempDecimalnumber += Factor / 4
        End If

        Return TempDecimalnumber

    End Function

    'Overloading if MidofInterval is not given
    Public Function DualStringToDecimalNumber(DualString As String) As Decimal

        Return DualStringToDecimalNumber(DualString, False)

    End Function

    Public Function DecimalNumberToDualString(DecNumber As Decimal, NumberOfDigits As Integer) As String

        'Transforms a decimal number to the according dual number in a string format
        'The default number of digits of the dual number behind the comma is 20
        'This limit is necessary if the dual number gets periodic
        'and the calculation has to be interrupted

        'Contains the actual dual string
        Dim TempDualstring As String = ""

        'Integer part of the decimal number
        Dim LeadingDecimaldigits As Decimal = Math.Floor(DecNumber)

        'Part behind the comma of the decimal number
        Dim MinorDecimalpart As Decimal = DecNumber - LeadingDecimaldigits

        If MinorDecimalpart > 0 And LeadingDecimaldigits > 0 Then
            TempDualstring = "."
        End If

        'Remaining part of the decimal number
        Dim remainder As Decimal

        Do While LeadingDecimaldigits >= 1
            remainder = LeadingDecimaldigits Mod 2
            If remainder = 1 Then
                TempDualstring = "1" & TempDualstring
                LeadingDecimaldigits -= 1
            Else
                TempDualstring = "0" & TempDualstring
            End If
            LeadingDecimaldigits = CInt(LeadingDecimaldigits / 2)
        Loop

        'Position of a digit behind the comma
        Dim counter As Integer = 0

        Do While MinorDecimalpart > 0 And counter <= NumberOfDigits
            MinorDecimalpart *= 2
            counter += 1
            If MinorDecimalpart >= 1 Then
                TempDualstring &= "1"
                MinorDecimalpart -= 1
            Else
                TempDualstring &= "0"
            End If
        Loop

        Return TempDualstring

    End Function

    'Overloading if numberofdigits is not given
    Public Function DecimalNumberToDualString(DecNumber As Decimal) As String

        Return DecimalNumberToDualString(DecNumber, 20)

    End Function

    Public Function FixNumberOfDigitsInDualNumber(DualNumber As String, NumberOfDigits As Integer) As String

        'Adds "0" to a string representing a dual number until the number of digits is achieved
        'This method is used if in some cases a additional dual number is added to the original one
        'but so far behind, that the new number is still very near to the original one
        'if the number of digits is already big enough, then nothing is done

        Dim i As Integer 'Position of the added "0"

        For i = DualNumber.Length + 1 To NumberOfDigits
            DualNumber &= "0"
        Next

        Return DualNumber

    End Function

    Public Function NumberOfOnesInaDualNumber(DualNumber As String) As Integer

        'Counts how many "1" are contained in a dual number represented by a string
        'This is used in a context of complementing a dual number
        'see mathematical documentation

        Dim i As Integer 'Position of the examinated digit
        Dim Counter As Integer = 0 'Counts the #"1"

        For i = 1 To DualNumber.Length
            Select Case Mid(DualNumber, i, 1)
                Case "0", "."
                    'nothing to do
                Case "1"
                    Counter += 1
                Case Else
                    Throw New ArgumentException(LM.GetString("InvalidDualNumberDigits"))
            End Select
        Next

        Return Counter

    End Function

    Public Function CheckFormatDualzahl(DualNumber As String) As Boolean

        'Check: A dual number can only contain the digits 0 and 1
        Dim Digit As String 'The examinated digit
        Dim Position As Integer 'Position of this digit
        Dim IsFormatValid As Boolean = (DualNumber.Length > 0)

        For Position = 1 To DualNumber.Length
            Digit = Mid(DualNumber, Position, 1)
            If Not (Digit = "0" Or Digit = "1") Then
                IsFormatValid = False
            End If
        Next

        If Not IsFormatValid Then
            MessageBox.Show(LM.GetString("InvalidDualNumberDigits"))
        End If

        Return IsFormatValid

    End Function

    Public Function ProcotolToTentmapStartValueAsString(Protocol As String) As String

        'Calculates a start value for the tentmap (see mathematical documentation)
        'that generates the given protocol during the iteration
        'this function is also used by conjugates of the tentmap
        'see mathematical documentation

        'Contains the actual part of the final string
        Dim TempDualString As String = ""

        'Position of the examinated position in the protocol
        Dim i As Integer

        For i = Protocol.Length To 1 Step -1
            Select Case Mid(Protocol, i, 1)
                Case "0"
                    TempDualString = "0" & TempDualString
                Case "1"
                    TempDualString = "1" & ComplementDualString(TempDualString)
                Case Else
                    Throw New ArgumentException(LM.GetString("InvalidProtocolDigits"))
            End Select
        Next

        Return TempDualString

    End Function

    Public Function ComplementDualString(DualNumber As String) As String

        'Transforms a string of "0" and "1" into its complement

        'Contains the actual part of the string
        Dim Tempstring As String = ""

        'Position of the digit that is transformed
        Dim i As Integer

        For i = 1 To DualNumber.Length
            Select Case Mid(DualNumber, i, 1)
                Case "0"
                    Tempstring &= "1"
                Case "1"
                    Tempstring &= "0"
                Case Else
                    Throw New ArgumentException(LM.GetString("InvalidDualNumberDigits"))
            End Select
        Next

        Return Tempstring

    End Function
End Class
