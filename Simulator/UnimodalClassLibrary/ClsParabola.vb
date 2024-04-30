'Implements the interface IIteration for the parabola
'with the Iteration Formula: f(x) = 1 - a*x*x, x in [-1,1], a in ]0,2]
'and "knows" everything about this kind of iteration

'Status Checked

Imports System.Globalization

Public Class ClsParabola
    Implements IIteration

    'This is the steering parameter for the iteration
    '"a" bzw. "mu" in the mathematical documentation
    Private MyParameter As Decimal

    'in whitch Interval the Parameter a should be
    Private ReadOnly MyParameterInterval As ClsInterval

    'in whitch Interval the iterated Value x should be
    Private ReadOnly MyIterationInterval As ClsInterval

    'Power of the iteration function F:
    'How many times the iteration function F is performed in one iteration step
    Private MyPower As Integer

    'Checking if the steering parameter is OK
    Private IsMyParametervalid As Boolean = False

    'SplitPoints
    Private ReadOnly MySplitpoints As List(Of Decimal)


    'SECTOR INITIALISATION
    Public Sub New()

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

    Public WriteOnly Property Parameter As Decimal Implements IIteration.Parameter
        Set(Value As Decimal)
            MyParameter = Value
            IsMyParametervalid = IsParameterAllowed(MyParameter)
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

        Dim IsIterationvaluevalid As Boolean = IterationInterval.IsNumberInInterval(x)

        If IsMyParametervalid And IsIterationvaluevalid Then

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
        Return 1 - (MyParameter * x * x)

    End Function

    'SECTOR CALCULATION

    Public Function CalculateStartValueForProtocol(TargetProtocol As String) As Decimal _
        Implements IIteration.CalculateStartValueForProtocol

        Dim Mathhelper As New ClsMathhelperUnimodal


        If IsMyParametervalid Then

            'First, a dual startvalue for the tentmap is calculated that generates the given protocol
            'See mathematical documentation
            Dim BinaryTentmapStartvalue As String =
                Mathhelper.ProcotolToTentmapStartValueAsString(TargetProtocol)

            'The next step converts the dual startvalue of the tentmap in its according decimal startvalue
            Dim DecimalTentmapStartvalue As Decimal =
                Mathhelper.DualStringToDecimalNumber(BinaryTentmapStartvalue, True)

            'Finally, we use the conjugation between the tentmap and the parabola
            Return TentmapToParabola(DecimalTentmapStartvalue)
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
        Dim TentmapDecimalStartvalue As Decimal = ParabolaToTentmap(StartValue)

        'As well, we conjugate the targetvalue
        Dim TentmapDecimalTargetvalue As Decimal = ParabolaToTentmap(TargetValue)

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
        Dim AdjustedParabolaStartvalue As Decimal = TentmapToParabola(sign * AdjustedTentmapStartvalue)

        Return AdjustedParabolaStartvalue

    End Function

    'SECTOR CONJUGATION

    Private Function ParabolaToTentmap(x As Decimal) As Decimal

        'This is the conjugation that transforms the parabola to the tentmap
        'see mathematical documentation

        'because of roundings, the value x can be a little above 1 or below -1
        'that has to be adjusted
        x = Math.Max(-1, Math.Min(1, x))

        Return CDec(1 - (Math.Acos(x) / Math.PI))

    End Function

    Private Function TentmapToParabola(u As Decimal) As Decimal

        'This is the conjugation that transforms the tentmap to the parabola
        'see mathematical documentation

        Return CDec(Math.Cos(Math.PI * (1 - u)))

    End Function
End Class
