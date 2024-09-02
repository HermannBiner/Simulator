'Implements the interface IIteration for the tentmap
'with the Iteration Formula: f(x) = a*x if x in [0,0.5] and f(x) = a*(1-x) if x in ]0.5,1]
'a in ]0,2]. Interesting is only the case a = 2
'and "knows" everything about this kind of iteration

'Status Redesign Tested

Public Class ClsTentmap
    Inherits ClsIterationAbstract

    'SECTOR INITIALISATION
    Protected Overrides Sub InitializeIterator()

        'Generate the needed objects
        MyParameterInterval = New ClsInterval(0, 2)
        MyIterationInterval = New ClsInterval(0, 1)

        'Setting split points
        MySplitpoints = New List(Of Decimal) From {
            1
            }

    End Sub

    'SECTOR ITERATION

    Protected Overrides Function F(u As Decimal) As Decimal

        'This is the original iteration function
        u = If(u < 0.5, MyParameter * u, MyParameter * (1 - u))

        Return u

    End Function

    'SECTOR CALCULATION

    Public Overrides Function CalculateStartValueForProtocol(TargetProtocol As String) As Decimal

        Dim Mathhelper As New ClsMathhelperUnimodal

        'This dual startvalue in stringformat delivers the given protocol
        Dim DualStartvalue As String = Mathhelper.ProcotolToTentmapStartValueAsString(TargetProtocol)

        'the dual startvalue is transformed to the according decimal startvalue
        Dim DecimalStartvalue As Decimal = Mathhelper.DualStringToDecimalNumber(DualStartvalue, True)

        Return DecimalStartvalue
    End Function

    Public Overrides Function CalculateStartValueForTargetValue(StartValue As Decimal, TargetValue As Decimal) As Decimal

        Dim Mathhelper As New ClsMathhelperUnimodal

        'DecimalStartValue is the original given start value in decimal format
        'It has to be transformed in the according dual start value
        Dim StartDualstring As String = Mathhelper.DecimalNumberToDualString(StartValue)

        'Because of building its complement, the number of digits has to be fixed
        StartDualstring = Mathhelper.FixNumberOfDigitsInDualNumber(StartDualstring, 20)

        'Now, we need the targetvalue as dual string
        Dim TargetDualstring As String = Mathhelper.DecimalNumberToDualString(TargetValue)

        'Because of #complements to build, we need the #"1" in the string
        'see mathematical documentation
        Dim NumberOfOnesInStartDualstring As Integer = Mathhelper.NumberOfOnesInaDualNumber(StartDualstring)

        If NumberOfOnesInStartDualstring Mod 2 = 1 Then
            TargetDualstring = Mathhelper.ComplementDualString(TargetDualstring)
        End If

        'To minimize the error interval in the calculation, we set the last missing digit
        TargetDualstring &= "1"

        'According to the mathematical documentation, the target value is set behind the original start value
        'That gives the adjusted startvalue for the tentmap in dual format
        StartDualstring &= TargetDualstring

        'This adjusted startvalue in stringformat is transformed into the according decimal format
        Dim AdjustedTentmapStartvalue As Decimal = Mathhelper.DualStringToDecimalNumber(StartDualstring, True)

        Return AdjustedTentmapStartvalue

    End Function

    'SECTOR CONJUGATION

    Protected Overrides Function IterationToTentmap(x As Decimal) As Decimal

        Return x

    End Function

    Protected Overrides Function TentmapToIteration(u As Decimal) As Decimal

        Return u

    End Function
End Class
