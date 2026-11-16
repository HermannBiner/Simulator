'Implements the interface IIteration for the tentmap
'with the Iteration Formula: f(x) = a*x if x in [0,0.5] and f(x) = a*(1-x) if x in ]0.5,1]
'a in ]0,2]. Interesting is only the case a = 2
'and "knows" everything about this kind of iteration

'Status Checked

Public Class ClsTentmap
    Inherits ClsGrowthModelAbstract

    Protected Overrides Sub InitializeIterator()

        'Generate the needed objects
        MyDSParameter = New ClsGeneralParameter(1, "Parameter a", New ClsInterval(0, 2),
                                                     ClsGeneralParameter.TypeOfParameterEnum.DS, 2)

        MyValueParameter = New ClsGeneralParameter(2, "Value x", New ClsInterval(0, 1),
                                                   ClsGeneralParameter.TypeOfParameterEnum.Variable, CDbl(0.314159))
        MyCriticalPoint = CDbl(0.4999)
        MyChaoticParameterValue = 2 'is not used

        'Setting split points
        MySplitpoints = New List(Of Double) From {
            1
            }

    End Sub

    Protected Overrides Function F(u As Double) As Double

        'This is the original iteration function
        'It is computed in Decimal: in binary Double, a = 2 shifts out one bit per step,
        'so every orbit would fall to the fixed point 0 after about 53 steps.
        'Double -> Decimal keeps 15 significant digits, so the orbit stays on the decimal grid of its start value
        Dim DecU As Decimal = CDec(u)
        Dim DecA As Decimal = CDec(MyParameterA)
        DecU = If(DecU < 0.5D, DecA * DecU, DecA * (1 - DecU))

        Return CDbl(DecU)

    End Function

    Protected Overrides Function IterationToTentmap(x As Double) As Double

        Return x

    End Function

    Protected Overrides Function TentmapToIteration(u As Double) As Double

        Return u

    End Function
End Class
