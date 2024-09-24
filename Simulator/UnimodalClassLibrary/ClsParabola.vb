'Implements the interface IIteration for the parabola
'with the Iteration Formula: f(x) = 1 - a*x*x, x in [-1,1], a in ]0,2]
'and "knows" everything about this kind of iteration

'Status Checked

Public Class ClsParabola
    Inherits ClsIterationAbstract

    Protected Overrides Sub InitializeIterator()

        'Generate the needed objects
        MyFormulaParameter = New ClsGeneralParameter(1, "Parameter a", New ClsInterval(0, 2),
                                                     ClsGeneralParameter.TypeOfParameterEnum.Formula, 2)

        MyValueParameter = New ClsGeneralParameter(2, "Value x", New ClsInterval(-1, 1),
                                                   ClsGeneralParameter.TypeOfParameterEnum.Formula, CDec(0.314159))

        MyCriticalPoint = 0
        MyChaoticParameterValue = 2

        'Setting split points to be drawn in the image
        MySplitpoints = New List(Of Decimal) From {
            CDec(0.75), 'first 2-cycle
        CDec(1.24995), 'first 4-cycle
            CDec(1.3681), 'first 8-cycle
            CDec(1.39405), 'first 16-cycle
            CDec(1.401155) 'limit value of the period doubling
            }

    End Sub

    Protected Overrides Function F(x As Decimal) As Decimal

        'This is the original iteration function
        Return 1 - (MyParameterA * x * x)

    End Function

    Protected Overrides Function IterationToTentmap(x As Decimal) As Decimal

        'This is the conjugation that transforms the parabola to the tentmap
        'see mathematical documentation

        'because of roundings, the value x can be a little above 1 or below -1
        'that has to be adjusted
        x = Math.Max(-1, Math.Min(1, x))

        Return CDec(1 - (Math.Acos(x) / Math.PI))

    End Function

    Protected Overrides Function TentmapToIteration(u As Decimal) As Decimal

        'This is the conjugation that transforms the tentmap to the parabola
        'see mathematical documentation

        Return CDec(Math.Cos(Math.PI * (1 - u)))

    End Function
End Class
