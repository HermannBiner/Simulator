'Implements the interface IIteration for the tentmap
'with the Iteration Formula: f(x) = a*x if x in [0,0.5] and f(x) = a*(1-x) if x in ]0.5,1]
'a in ]0,2]. Interesting is only the case a = 2
'and "knows" everything about this kind of iteration

'Status Checked

Imports System.Globalization

Public Class ClsTentmap
    Implements IIteration

    'This is the steering parameter for the iteration
    '"a" in the mathematical documentation
    Private MyParameter As Decimal

    'in whitch Interval the Parameter a should be
    Private ReadOnly MyParameterInterval As ClsInterval

    'in whitch Interval the iterated Value x should be
    Private ReadOnly MyIterationInterval As ClsInterval

    'Power of the iteration function F:
    'How many times the iteration function F is performed in one iteration step
    Private MyPower As Integer

    'Checking if the steering parameter is OK
    Private IsMyParametervalid As Boolean

    'SplitPoints
    Private ReadOnly MySplitpoints As List(Of Decimal)

    'SECTOR INITIALISATION
    Public Sub New()

        'Generate the needed objects
        MyParameterInterval = New ClsInterval(0, 2)
        MyIterationInterval = New ClsInterval(0, 1)

        'Setting split points
        MySplitpoints = New List(Of Decimal) From {
            1
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

    Public Function IsParameterAllowed(Parameter As Decimal) As Boolean Implements IIteration.IsParameterAllowed

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
        Implements IIteration.IsIterationValueAllowed

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

    Public Function IsBehaviourChaotic() As Boolean Implements IIteration.IsBehaviourChaotic

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

    Private Function F(u As Decimal) As Decimal

        'This is the original iteration function
        u = If(u < 0.5, MyParameter * u, MyParameter * (1 - u))

        Return u

    End Function

    'SECTOR CALCULATION

    Public Function CalculateStartValueForProtocol(TargetProtocol As String) As Decimal _
        Implements IIteration.CalculateStartValueForProtocol

        Dim Mathhelper As New ClsMathhelperUnimodal

        'This dual startvalue in stringformat delivers the given protocol
        Dim DualStartvalue As String = Mathhelper.ProcotolToTentmapStartValueAsString(TargetProtocol)

        'the dual startvalue is transformed to the according decimal startvalue
        Dim DecimalStartvalue As Decimal = Mathhelper.DualStringToDecimalNumber(DualStartvalue, True)

        Return DecimalStartvalue
    End Function

    Public Function CalculateStartValueForTargetValue(StartValue As Decimal, TargetValue As Decimal) As Decimal _
        Implements IIteration.CalculateStartValueForTargetValue

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
End Class
