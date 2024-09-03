'Implements the interface IIteration for the logistic growth
'with the iteration formula: f(x) = a*x*(1-x), x in [0,1], a in ]0,4]
'and "knows" everything about this kind of iteration

'Status Redesign Tested

Public Class ClsLogisticGrowth
    Inherits ClsIterationAbstract

    Protected Overrides Sub InitializeIterator()

        'Generate the needed objects
        MyParameterInterval = New ClsInterval(0, 4)
        MyIterationInterval = New ClsInterval(0, 1)
        MyCriticalPoint = CDec(0.5)
        MyChaoticParameter = 4

        'Setting split points to be drawn in the image
        MySplitpoints = New List(Of Decimal) From {
            CDec(3), 'first 2-cycle
            CDec(3.449449), 'first 4-cycle
            CDec(3.54409), 'first 8-cycle
            CDec(3.564407), 'first 16-cycle
            CDec(3.569946) 'limit value of the period doubling
            }

    End Sub

    Protected Overrides Function F(x As Decimal) As Decimal

        'This is the original iteration function
        Return MyParameter * x * (1 - x)

    End Function

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
