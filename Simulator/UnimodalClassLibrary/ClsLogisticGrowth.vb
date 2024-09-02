'Implements the interface IIteration for the logistic growth
'with the iteration formula: f(x) = a*x*(1-x), x in [0,1], a in ]0,4]
'and "knows" everything about this kind of iteration

'Status Redesign Tested

Public Class ClsLogisticGrowth
    Inherits ClsIterationAbstract


    'SECTOR INITIALISATION

    Protected Overrides Sub InitializeIterator()

        'Generate the needed objects
        MyParameterInterval = New ClsInterval(0, 4)
        MyIterationInterval = New ClsInterval(0, 1)

        'Setting split points to be drawn in the image
        MySplitpoints = New List(Of Decimal) From {
            CDec(3), 'first 2-cycle
            CDec(3.449449), 'first 4-cycle
            CDec(3.54409), 'first 8-cycle
            CDec(3.564407), 'first 16-cycle
            CDec(3.569946) 'limit value of the period doubling
            }

    End Sub

    'SECTOR ITERATION

    Protected Overrides Function F(x As Decimal) As Decimal

        'This is the original iteration function
        Return MyParameter * x * (1 - x)

    End Function

    'SECTOR CALCULATION

    Public Overrides Function CalculateStartValueForProtocol(TargetProtocol As String) As Decimal

        Dim Mathhelper As New ClsMathhelperUnimodal


        'First, a dual startvalue for the tentmap is calculated that generates the given protocol
        'See mathematical documentation
        Dim BinaryTentmapStartvalue As String =
                Mathhelper.ProcotolToTentmapStartValueAsString(TargetProtocol)

        'The next step converts the dual startvalue of the tentmap in its according decimal startvalue
        'for the tent map
        Dim DecimalTentmapStartvalue As Decimal =
                Mathhelper.DualStringToDecimalNumber(BinaryTentmapStartvalue, True)

        'Finally, we use the conjugation between the tentmap and the logistic growth
        Return TentmapToIteration(DecimalTentmapStartvalue)


    End Function

    Public Overrides Function CalculateStartValueForTargetValue(StartValue As Decimal, TargetValue As Decimal) As Decimal

        Dim Mathhelper As New ClsMathhelperUnimodal

        'Startvalue is the original start value 
        'We need the conjugated startvalue of the tentmap
        Dim TentmapDecimalStartvalue As Decimal = IterationToTentmap(StartValue)

        'As well, we need the conjugated targetvalue of the tentmap
        Dim TentmapDecimalTargetvalue As Decimal = IterationToTentmap(TargetValue)

        'Next, we consider the tentmap startvalue in dual string format
        'The conjugates of the iteration chain of the tentmap is identical 
        'with the iteration chain of the logistic growth
        Dim TentmapDualStartvalue As String = Mathhelper.DecimalNumberToDualString(TentmapDecimalStartvalue)

        'Because we will add an adjusting dualstring at the end of the TentmapDualStartvalue
        'its number of digits has to be at minimum 20
        TentmapDualStartvalue = Mathhelper.FixNumberOfDigitsInDualNumber(TentmapDualStartvalue, 20)

        'For the further calculation, we need the conjugated target value as well as dual string
        Dim TentmapDualTargetvalue As String =
            Mathhelper.DecimalNumberToDualString(TentmapDecimalTargetvalue)

        'Now, we can calculate everything in case of the tentmap
        'that is easy - see mathematical documentation
        'For the number of complement-buildings we need first the number of "1"
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
        Dim AdjustedLogisticStartvalue As Decimal = TentmapToIteration(AdjustedTentmapStartvalue)

        Return AdjustedLogisticStartvalue

    End Function

    'SECTOR CONJUGATION
    Protected Overrides Function IterationToTentmap(x As Decimal) As Decimal

        'This is the conjugation that transforms the logistic growth to the tentmap
        'see mathematical documentation
        Return CDec(2 * Math.Asin(Math.Sqrt(x)) / Math.PI)

    End Function

    Protected Overrides Function TentmapToIteration(u As Decimal) As Decimal

        'This is the conjugation that transforms the tentmap to the logistic growth
        'see mathematical documentation
        Dim x As Decimal = CDec(Math.Sin(Math.PI * u / 2))

        Return x * x

    End Function
End Class
