'this is the abstract class for all types of strange attractors
'it implements the interface IStrangeAttractors
'and must be inherited by all concrete strange attractors

'status Tested

Public MustInherit Class ClsStrangeAttractorAbstract
    Implements IStrangeAttractor


    Protected ReadOnly LM As ClsLanguageManager

    'For the individual Parameter Definitions
    Protected MyXValueParameter As ClsGeneralParameter 'Definition

    Protected MyYValueParameter As ClsGeneralParameter 'Definition

    Protected MyZValueParameter As ClsGeneralParameter 'Definition

    Protected MyDSParameter As ClsGeneralParameter 'Definition

    Protected MyDSParameterValue As Decimal 'Value


    'Constellat ions
    Protected MyStartPointSets As List(Of ClsPointSet)

    'Iteration
    Protected MyStepWidth As Decimal

    Protected MyMathInterval As ClsInterval

    'SplitPoints
    Protected MySplitpoints As List(Of Decimal)

    'Iteration
    Protected MyActualMathPoint As ClsMathpoint

    'ViewCorrection
    Protected MyViewCorrection As ClsNTupel

    ReadOnly Property XValueParameter As ClsGeneralParameter Implements IStrangeAttractor.XValueParameter
        Get
            XValueParameter = MyXValueParameter
        End Get
    End Property

    ReadOnly Property YValueParameter As ClsGeneralParameter Implements IStrangeAttractor.YValueParameter
        Get
            YValueParameter = MyYValueParameter
        End Get
    End Property

    ReadOnly Property ZValueParameter As ClsGeneralParameter Implements IStrangeAttractor.ZValueParameter
        Get
            ZValueParameter = MyZValueParameter
        End Get
    End Property

    ReadOnly Property DSParameter As ClsGeneralParameter Implements IStrangeAttractor.DSParameter
        Get
            DSParameter = MyDSParameter
        End Get
    End Property

    Property DSParameterValue As Decimal Implements IStrangeAttractor.DSParameterValue
        Get
            DSParameterValue = MyDSParameterValue
        End Get
        Set(value As Decimal)
            MyDSParameterValue = value
        End Set
    End Property

    Property StepWidth As Decimal Implements IStrangeAttractor.StepWidth
        Get
            StepWidth = MyStepWidth
        End Get
        Set(value As Decimal)
            MyStepWidth = value
        End Set
    End Property

    ReadOnly Property Mathinterval As ClsInterval Implements IStrangeAttractor.MathInterval
        Get
            Mathinterval = MyMathInterval
        End Get
    End Property

    ReadOnly Property Splitpoints As List(Of Decimal) Implements IStrangeAttractor.Splitpoints
        Get
            Splitpoints = MySplitpoints
        End Get
    End Property

    ReadOnly Property StartPointSets As List(Of ClsPointSet) Implements IStrangeAttractor.StartPointSets
        Get
            StartPointSets = MyStartPointSets
        End Get
    End Property

    Property ActualMathPoint As ClsMathpoint Implements IStrangeAttractor.ActualMathPoint
        Get
            ActualMathPoint = MyActualMathPoint
        End Get
        Set(value As ClsMathpoint)
            MyActualMathPoint.Equal(value)
        End Set
    End Property

    ReadOnly Property ViewCorrection As ClsNTupel Implements IStrangeAttractor.ViewCorrection
        Get
            ViewCorrection = MyViewCorrection
        End Get
    End Property

    Public Sub New()
        LM = ClsLanguageManager.LM
        MyStartPointSets = New List(Of ClsPointSet)
        MyActualMathPoint = New ClsMathpoint
        MyViewCorrection = New ClsNTupel(2)
    End Sub

    Public MustOverride Sub CreateStartPointSets() Implements IStrangeAttractor.CreateStartPointSets

    Public MustOverride Sub IterationStep() Implements IStrangeAttractor.IterationStep

    Public MustOverride Sub SetIterationParameters() Implements IStrangeAttractor.SetIterationParameters

End Class
