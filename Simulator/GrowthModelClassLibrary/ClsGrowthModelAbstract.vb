'This is the abstract class for all kind of Growth-Models

'Status Checked

Public MustInherit Class ClsGrowthModelAbstract
    Implements IIteration

    Protected ReadOnly LM As ClsLanguageManager

    'This is the steering parameter for the iteration
    '"a" in the mathematical documentation 
    Protected MyParameterA As Double

    'in whitch Interval the Parameter a should be
    Protected MyDSParameter As ClsGeneralParameter

    'in whitch Interval the iterated Value x should be
    Protected MyValueParameter As ClsGeneralParameter

    'Power of the iteration function f:
    'How many times the iteration function f is performed in one iteration step
    Protected MyPower As Integer

    'SplitPoints
    Protected MySplitpoints As List(Of Double)

    'Critical Point
    Protected MyCriticalPoint As Double

    'Chaotic Parameter
    Protected MyChaoticParameterValue As Double

    'SECTOR INITIALISATION

    Public Sub New()
        InitializeIterator()
        LM = ClsLanguageManager.LM
    End Sub

    WriteOnly Property Power As Integer Implements IIteration.Power
        Set(value As Integer)
            MyPower = value
        End Set
    End Property

    Overridable Property ParameterA As Double Implements IIteration.ParameterA
        Get
            ParameterA = MyParameterA
        End Get
        Set(Value As Double)
            MyParameterA = Value
        End Set
    End Property

    ReadOnly Property DSParameter As ClsGeneralParameter Implements IIteration.DSParameter
        Get
            DSParameter = MyDSParameter
        End Get
    End Property

    ReadOnly Property ValueParameter As ClsGeneralParameter Implements IIteration.ValueParameter
        Get
            ValueParameter = MyValueParameter
        End Get
    End Property

    ReadOnly Property Splitpoints As List(Of Double) Implements IIteration.Splitpoints
        Get
            Splitpoints = MySplitpoints
        End Get
    End Property

    ReadOnly Property CriticalPoint As Double Implements IIteration.CriticalPoint
        Get
            CriticalPoint = MyCriticalPoint
        End Get
    End Property

    ReadOnly Property ChaoticParameterValue As Double Implements IIteration.ChaoticParameterValue
        Get
            ChaoticParameterValue = MyChaoticParameterValue
        End Get
    End Property

    Public Function IsBehaviourChaotic() As Boolean _
        Implements IIteration.IsBehaviourChaotic

        'Chaotic behaviour is only guaranteed for the right border of the parameter interval
        'see mathematical documentation
        If (0 <= MyParameterA And MyParameterA < MyDSParameter.Range.B) Or
            (MyDSParameter.Range.A < MyParameterA And MyParameterA <= 0) Then
            MessageBox.Show(LM.GetString("NonChaoticBehaviour"))
            Return False
        Else
            Return True
        End If

    End Function

    'SECTOR ITERATION

    Public Function FN(x As Double) As Double _
        Implements IIteration.FN

        'This Function is the
        'Power-iterated function of the original function

        Dim i As Integer

        For i = 1 To MyPower
            x = F(x)
        Next

        Return x

    End Function

    Public Overridable Function CalculateStartValueForProtocol(TargetProtocol As String) As Double _
        Implements IIteration.CalculateStartValueForProtocol

        Dim Mathhelper As New ClsMathhelperUnimodal

        'First, a dual startvalue for the tentmap is calculated that generates the given protocol
        'See mathematical documentation
        Dim BinaryTentmapStartvalue As String =
                Mathhelper.ProcotolToTentmapStartValueAsString(TargetProtocol)

        'The next step converts the dual startvalue of the tentmap in its according decimal startvalue
        Dim DecimalTentmapStartvalue As Double =
            Mathhelper.DualStringToDecimalNumber(BinaryTentmapStartvalue, True)

        'Finally, we use the conjugation between the tentmap and the parabola
        Return TentmapToIteration(DecimalTentmapStartvalue)

    End Function

    Public Overridable Function CalculateStartValueForTargetValue(StartValue As Double, TargetValue As Double) As Double _
        Implements IIteration.CalculateStartValueForTargetValue

        Dim Mathhelper As New ClsMathhelperUnimodal

        'Startvalue is the original start value 
        'We need the conjugated startvalue of the tentmap
        Dim TentmapDecimalStartvalue As Double = IterationToTentmap(StartValue)

        'As well, we conjugate the targetvalue
        Dim TentmapDecimalTargetvalue As Double = IterationToTentmap(TargetValue)

        'Next, we consider the tentmap startvalue in dual string format
        'The conjugates of the iteration chain of the tentmap is identical 
        'with the iteration chain of the logistic growth
        Dim TentmapDualStartvalue As String = Mathhelper.DecimalNumberToDualString(TentmapDecimalStartvalue)

        'Later, we need the sign of the TentmapDecimalStartvalue
        Dim sign As Integer = Math.Sign(TentmapDecimalStartvalue)

        'Because we will add an adjusting dualstring at the end of the TentmapDualStartvalue
        'its number of digits has to be exactly StartDigits = 20
        'so the orbit reaches the target after 20 steps of F
        '(4 steps of the two-dimensional iteration with power 5)
        Const StartDigits As Integer = 20
        TentmapDualStartvalue = Mathhelper.FixNumberOfDigitsInDualNumber(TentmapDualStartvalue, StartDigits).Substring(0, StartDigits)

        'For the further calculation, we need the conjugated target value as well as dual string
        'it is filled up to StartDigits digits, otherwise the "1" appended below
        'would move a short target far away (0.5 = 0.1 dual would become 0.111 dual)
        Dim TentmapDualTargetvalue As String = Mathhelper.FixNumberOfDigitsInDualNumber(
            Mathhelper.DecimalNumberToDualString(TentmapDecimalTargetvalue), StartDigits)

        'Now, the target value is adapted - see mathematical documentation
        'After k steps of the tentmap, the remaining digits are complemented
        'if and only if the k-th digit is 1
        'therefore, the target is complemented if the last digit of the start value is 1
        If TentmapDualStartvalue.EndsWith("1") Then
            TentmapDualTargetvalue = Mathhelper.ComplementDualString(TentmapDualTargetvalue)
        End If

        'To minimize the error interval in the calculation, we set the last missing digit
        TentmapDualTargetvalue &= "1"

        'According to the mathematical documentation, the target value is set behind the original start value
        'That gives the adjusted startvalue for the tentmap in dual format
        TentmapDualStartvalue &= TentmapDualTargetvalue

        'We transform that dual string into the according decimal value
        Dim AdjustedTentmapStartvalue As Double =
            Mathhelper.DualStringToDecimalNumber(TentmapDualStartvalue, True)

        'Finally, we conjugate this value back to the logistic growth
        Dim AdjustedParabolaStartvalue As Double = TentmapToIteration(sign * AdjustedTentmapStartvalue)

        Return AdjustedParabolaStartvalue

    End Function

    Protected MustOverride Sub InitializeIterator()

    Protected MustOverride Function F(x As Double) As Double

    Protected MustOverride Function IterationToTentmap(x As Double) As Double

    Protected MustOverride Function TentmapToIteration(u As Double) As Double

End Class
