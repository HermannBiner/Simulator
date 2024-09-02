'Implements the interface IIteration for the parabola
'with the Iteration Formula: f(x) = 1 - a*x*x, x in [-1,1], a in ]0,2]
'and "knows" everything about this kind of iteration

'Status Redesign Tested

Public Class ClsParabola
    Inherits ClsIterationAbstract

    'SECTOR INITIALISATION
    Protected Overrides Sub InitializeIterator()

        'Generate the needed objects
        MyParameterInterval = New ClsInterval(0, 2)
        MyIterationInterval = New ClsInterval(-1, 1)

        'Setting split points to be drawn in the image
        MySplitpoints = New List(Of Decimal) From {
            CDec(0.75), 'first 2-cycle
        CDec(1.24995), 'first 4-cycle
            CDec(1.3681), 'first 8-cycle
            CDec(1.39405), 'first 16-cycle
            CDec(1.401155) 'limit value of the period doubling
            }

    End Sub

    'SECTOR ITERATION

    Protected Overrides Function F(x As Decimal) As Decimal

        'This is the original iteration function
        Return 1 - (MyParameter * x * x)

    End Function

    'SECTOR CALCULATION

    Public Overrides Function CalculateStartValueForProtocol(TargetProtocol As String) As Decimal

        Dim Mathhelper As New ClsMathhelperUnimodal

        'First, a dual startvalue for the tentmap is calculated that generates the given protocol
        'See mathematical documentation
        Dim BinaryTentmapStartvalue As String =
                Mathhelper.ProcotolToTentmapStartValueAsString(TargetProtocol)

            'The next step converts the dual startvalue of the tentmap in its according decimal startvalue
            Dim DecimalTentmapStartvalue As Decimal =
                Mathhelper.DualStringToDecimalNumber(BinaryTentmapStartvalue, True)

        'Finally, we use the conjugation between the tentmap and the parabola
        Return TentmapToIteration(DecimalTentmapStartvalue)

    End Function

    Public Overrides Function CalculateStartValueForTargetValue(StartValue As Decimal, TargetValue As Decimal) As Decimal

        Dim Mathhelper As New ClsMathhelperUnimodal

        'Startvalue is the original start value 
        'We need the conjugated startvalue of the tentmap
        Dim TentmapDecimalStartvalue As Decimal = IterationToTentmap(StartValue)

        'As well, we conjugate the targetvalue
        Dim TentmapDecimalTargetvalue As Decimal = IterationToTentmap(TargetValue)

        'Next, we consider the tentmap startvalue in dual string format
        'The conjugates of the iteration chain of the tentmap is identical 
        'with the iteration chain of the logistic growth
        Dim TentmapDualStartvalue As String = Mathhelper.DecimalNumberToDualString(TentmapDecimalStartvalue)

        'Later, we need the sign of the TentmapDecimalStartvalue
        Dim sign As Integer = Math.Sign(TentmapDecimalStartvalue)

        'Because we will add an adjusting dualstring at the end of the TentmapDualStartvalue
        'its number of digits has to be at minimum 20
        TentmapDualStartvalue = Mathhelper.FixNumberOfDigitsInDualNumber(TentmapDualStartvalue, 20)

        'For the further calculation, we need the conjugated target value as well as dual string
        Dim TentmapDualTargetvalue As String =
            Mathhelper.DecimalNumberToDualString(TentmapDecimalTargetvalue)

        'Now, the target value is adapted - see mathematical documentation
        Dim NumerOfOnesInTentmapStartvalue As Integer =
            Mathhelper.NumberOfOnesInaDualNumber(TentmapDualStartvalue)
        If NumerOfOnesInTentmapStartvalue Mod 2 = 1 Then
            TentmapDualTargetvalue = Mathhelper.ComplementDualString(TentmapDualTargetvalue)
        End If

        'To minimize the error interval in the calculation, we set the last missing digit
        TentmapDualTargetvalue &= "1"

        'According to the mathematical documentation, the target value is set behind the original start value
        'That gives the adjusted startvalue for the tentmap in dual format
        TentmapDualStartvalue &= TentmapDualTargetvalue

        'We transform that dual string into the according decimal value
        Dim AdjustedTentmapStartvalue As Decimal =
            Mathhelper.DualStringToDecimalNumber(TentmapDualStartvalue, True)

        'Finally, we conjugate this value back to the logistic growth
        Dim AdjustedParabolaStartvalue As Decimal = TentmapToIteration(sign * AdjustedTentmapStartvalue)

        Return AdjustedParabolaStartvalue

    End Function

    'SECTOR CONJUGATION

    Protected Overrides Function IterationToTentmap(x As Decimal) As Decimal

        'This is the conjugation that transforms the parabola to the tentmap
        'see mathematical documentation

        'because of roundings, the value x can be a little above 1 or below -1
        'that has to be adjusted
        x = Math.Max(-1, Math.Min(1, x))

        Return CDec(1 - (Math.Acos(x) / Math.PI))

    End Function

    Protected Overrides Function TentmapToIteration(u As Decimal) As Decimal

        'This is the conjugation that transforms the tentmap to the parabola
        'see mathematical documentation

        Return CDec(Math.Cos(Math.PI * (1 - u)))

    End Function
End Class
