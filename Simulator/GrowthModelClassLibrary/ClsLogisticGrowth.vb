'Implements the interface IIteration for the logistic growth
'with the iteration formula: f(x) = a*x*(1-x), x in [0,1], a in ]0,4]
'and "knows" everything about this kind of iteration

'Status Checked

Public Class ClsLogisticGrowth
    Inherits ClsGrowthModelAbstract

    Protected Overrides Sub InitializeIterator()

        'Generate the needed objects
        MyDSParameter = New ClsGeneralParameter(1, "Parameter a", New ClsInterval(0, 4),
                                                     ClsGeneralParameter.TypeOfParameterEnum.DS, CDbl(2.8))

        MyValueParameter = New ClsGeneralParameter(2, "Value x", New ClsInterval(0, 1),
                                                   ClsGeneralParameter.TypeOfParameterEnum.Variable, CDbl(0.314159))
        MyCriticalPoint = CDbl(0.5)
        MyChaoticParameterValue = 4

        'Setting split points to be drawn in the image
        MySplitpoints = New List(Of Double) From {
            CDbl(3), 'first 2-cycle
            CDbl(3.449449), 'first 4-cycle
            CDbl(3.54409), 'first 8-cycle
            CDbl(3.564407), 'first 16-cycle
            CDbl(3.569946) 'limit value of the period doubling
            }

    End Sub

    Protected Overrides Function F(x As Double) As Double

        'This is the original iteration function
        Return MyParameterA * x * (1 - x)

    End Function

    Protected Overrides Function IterationToTentmap(x As Double) As Double

        'This is the conjugation that transforms the logistic growth to the tentmap
        'see mathematical documentation
        Return CDbl(2 * Math.Asin(Math.Sqrt(x)) / Math.PI)

    End Function

    Protected Overrides Function TentmapToIteration(u As Double) As Double

        'This is the conjugation that transforms the tentmap to the logistic growth
        'see mathematical documentation
        Dim x As Double = CDbl(Math.Sin(Math.PI * u / 2))

        Return x * x

    End Function
End Class
