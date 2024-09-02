'This is the abstract class for all kind of Growth-Models

'Status Redesign Tested

Public MustInherit Class ClsIterationAbstract
    Implements IIteration

    'This is the steering parameter for the iteration
    '"a" in the mathematical documentation 
    Protected MyParameter As Decimal

    'in whitch Interval the Parameter a should be
    Protected MyParameterInterval As ClsInterval

    'in whitch Interval the iterated Value x should be
    Protected MyIterationInterval As ClsInterval

    'Power of the iteration function f:
    'How many times the iteration function f is performed in one iteration step
    Protected MyPower As Integer

    'SplitPoints
    Protected MySplitpoints As List(Of Decimal)

    'SECTOR INITIALISATION

    Public Sub New()
        InitializeIterator()
    End Sub

    WriteOnly Property Power As Integer Implements IIteration.Power
        Set(value As Integer)
            MyPower = value
        End Set
    End Property

    WriteOnly Property Parameter As Decimal Implements IIteration.Parameter
        Set(Value As Decimal)
            MyParameter = Value
        End Set
    End Property

    ReadOnly Property ParameterInterval As ClsInterval Implements IIteration.ParameterInterval
        Get
            ParameterInterval = MyParameterInterval
        End Get
    End Property

    ReadOnly Property IterationInterval As ClsInterval Implements IIteration.IterationInterval
        Get
            IterationInterval = MyIterationInterval
        End Get
    End Property

    ReadOnly Property Splitpoints As List(Of Decimal) Implements IIteration.Splitpoints
        Get
            Splitpoints = MySplitpoints
        End Get
    End Property

    Public Function IsBehaviourChaotic() As Boolean _
        Implements IIteration.IsBehaviourChaotic

        'Chaotic behaviour is only guaranteed for the right border of the parameter interval
        'see mathematical documentation
        If MyParameter < ParameterInterval.B Then
            MessageBox.Show(FrmMain.LM.GetString("NonChaoticBehaviour"))
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

        Dim i As Integer

        For i = 1 To MyPower
            x = F(x)
        Next

        Return x

    End Function

    Protected MustOverride Sub InitializeIterator()

    Protected MustOverride Function F(x As Decimal) As Decimal

    Public MustOverride Function CalculateStartValueForProtocol(TargetProtocol As String) As Decimal _
        Implements IIteration.CalculateStartValueForProtocol

    Public MustOverride Function CalculateStartValueForTargetValue(StartValue As Decimal, TargetValue As Decimal) As Decimal _
        Implements IIteration.CalculateStartValueForTargetValue

    Protected MustOverride Function IterationToTentmap(x As Decimal) As Decimal

    Protected MustOverride Function TentmapToIteration(u As Decimal) As Decimal

End Class
