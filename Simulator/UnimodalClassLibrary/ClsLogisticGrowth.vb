'Implements the interface IIteration for the logistic growth
'with the iteration formula: f(x) = a*x*(1-x), x in [0,1], a in ]0,4]
'and "knows" everything about this kind of iteration

'Status Checked

Imports System.Globalization

Public Class ClsLogisticGrowth
    Implements IIteration

    'This is the steering parameter for the iteration
    '"a" in the mathematical documentation 
    Private MyParameter As Decimal

    'in whitch Interval the Parameter a should be
    Private ReadOnly MyParameterInterval As ClsInterval

    'in whitch Interval the iterated Value x should be
    Private ReadOnly MyIterationInterval As ClsInterval

    'Power of the iteration function f:
    'How many times the iteration function f is performed in one iteration step
    Private MyPower As Integer

    'Checking if the steering parameter is OK
    Private IsMyParameterValid As Boolean

    'SplitPoints
    Private ReadOnly MySplitpoints As List(Of Decimal)


    'SECTOR INITIALISATION

    Public Sub New()

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

    Public WriteOnly Property Parameter As Decimal Implements IIteration.Parameter
        Set(Value As Decimal)
            MyParameter = Value
            IsMyParameterValid = IsParameterAllowed(MyParameter)
        End Set
    End Property

    Public WriteOnly Property Power As Integer Implements IIteration.Power
        Set(value As Integer)
            MyPower = value
        End Set
    End Property

    Public ReadOnly Property ParameterInterval As ClsInterval Implements IIteration.ParameterInterval
        Get
            ParameterInterval = MyParameterInterval
        End Get
    End Property

    Public ReadOnly Property IterationInterval As ClsInterval Implements IIteration.IterationInterval
        Get
            IterationInterval = MyIterationInterval
        End Get
    End Property

    Public ReadOnly Property Splitpoints As List(Of Decimal) Implements IIteration.Splitpoints
        Get
            Splitpoints = MySplitpoints
        End Get
    End Property

    Public Function IsParameterAllowed(Parameter As Decimal) As Boolean _
        Implements IIteration.IsParameterAllowed

        If Not ParameterInterval.IsNumberInInterval(Parameter) Then
            MessageBox.Show(Main.LM.GetString("TheValue") & Parameter.ToString(CultureInfo.CurrentCulture) &
                            Main.LM.GetString("NotAlllowedValue") & "[" &
                            ParameterInterval.A.ToString(CultureInfo.CurrentCulture) &
                            ", " & ParameterInterval.B.ToString(CultureInfo.CurrentCulture) & "]!")
            Return False
        Else
            Return True
        End If

    End Function

    Public Function IsIterationvalueAllowed(x As Decimal) As Boolean _
        Implements IIteration.IsIterationvalueAllowed

        If Not IterationInterval.IsNumberInInterval(x) Then
            MessageBox.Show(Main.LM.GetString("TheValue") & x.ToString(CultureInfo.CurrentCulture) &
                            Main.LM.GetString("NotAlllowedValue") & "[" &
                            IterationInterval.A.ToString(CultureInfo.CurrentCulture) &
                            ", " & IterationInterval.B.ToString(CultureInfo.CurrentCulture) & "]!")
            Return False
        Else
            Return True
        End If

    End Function

    Public Function IsBehaviourChaotic() As Boolean _
        Implements IIteration.IsBehaviourChaotic

        'Chaotic behaviour is only guaranteed for the right border of the parameter interval
        'see mathematical documentation
        If MyParameter < ParameterInterval.B Then
            MessageBox.Show(Main.LM.GetString("NonChaoticBehaviour"))
            Return False
        Else
            Return True
        End If

    End Function

    'SECTOR ITERATION

    Public Function FN(x As Decimal) As Decimal _
        Implements IIteration.FN

        'This Function is the
        'Power-iterated function of the original function

        Dim IsIterationswertValid As Boolean = IterationInterval.IsNumberInInterval(x)

        If IsMyParameterValid And IsIterationswertValid Then

            Dim i As Integer

            For i = 1 To MyPower
                x = F(x)
            Next
        Else
            MessageBox.Show(Main.LM.GetString("InvalidParameterOrIterationValue"))
        End If

        Return x

    End Function

    Private Function F(x As Decimal) As Decimal

        'This is the original iteration function
        Return MyParameter * x * (1 - x)

    End Function

    'SECTOR CALCULATION

    Public Function CalculateStartValueForProtocol(TargetProtocol As String) As Decimal _
        Implements IIteration.CalculateStartValueForProtocol

        Dim Mathhelper As New ClsMathhelperUnimodal

        If IsMyParameterValid Then

            'First, a dual startvalue for the tentmap is calculated that generates the given protocol
            'See mathematical documentation
            Dim BinaryTentmapStartvalue As String =
                Mathhelper.ProcotolToTentmapStartValueAsString(TargetProtocol)

            'The next step converts the dual startvalue of the tentmap in its according decimal startvalue
            'for the tent map
            Dim DecimalTentmapStartvalue As Decimal =
                Mathhelper.DualStringToDecimalNumber(BinaryTentmapStartvalue, True)

            'Finally, we use the conjugation between the tentmap and the logistic growth
            Return TentmapToLogisticGrowth(DecimalTentmapStartvalue)

        Else
            MessageBox.Show(Main.LM.GetString("InvalidParameterOrIterationValue"))
            Return 0
        End If

    End Function

    Public Function CalculateStartValueForTargetValue(StartValue As Decimal, TargetValue As Decimal) As Decimal _
        Implements IIteration.CalculateStartValueForTargetValue

        Dim Mathhelper As New ClsMathhelperUnimodal

        'Startvalue is the original start value 
        'We need the conjugated startvalue of the tentmap
        Dim TentmapDecimalStartvalue As Decimal = LogisticGrowthToTentmap(StartValue)

        'As well, we need the conjugated targetvalue of the tentmap
        Dim TentmapDecimalTargetvalue As Decimal = LogisticGrowthToTentmap(TargetValue)

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
        Dim AdjustedLogisticStartvalue As Decimal = TentmapToLogisticGrowth(AdjustedTentmapStartvalue)

        Return AdjustedLogisticStartvalue

    End Function

    'SECTOR CONJUGATION
    Private Function LogisticGrowthToTentmap(x As Decimal) As Decimal

        'This is the conjugation that transforms the logistic growth to the tentmap
        'see mathematical documentation
        Return CDec(2 * Math.Asin(Math.Sqrt(x)) / Math.PI)

    End Function

    Private Function TentmapToLogisticGrowth(u As Decimal) As Decimal

        'This is the conjugation that transforms the tentmap to the logistic growth
        'see mathematical documentation
        Dim x As Decimal = CDec(Math.Sin(Math.PI * u / 2))

        Return x * x

    End Function
End Class
