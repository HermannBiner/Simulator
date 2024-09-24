'Implements the interface IIteration for the tentmap
'with the Iteration Formula: f(x) = a*x if x in [0,0.5] and f(x) = a*(1-x) if x in ]0.5,1]
'a in ]0,2]. Interesting is only the case a = 2
'and "knows" everything about this kind of iteration

'Status Checked

Public Class ClsTentmap
    Inherits ClsIterationAbstract

    Protected Overrides Sub InitializeIterator()

        'Generate the needed objects
        MyFormulaParameter = New ClsGeneralParameter(1, "Parameter a", New ClsInterval(0, 2),
                                                     ClsGeneralParameter.TypeOfParameterEnum.Formula, 2)

        MyValueParameter = New ClsGeneralParameter(2, "Value x", New ClsInterval(0, 1),
                                                   ClsGeneralParameter.TypeOfParameterEnum.Formula, CDec(0.314159))
        MyCriticalPoint = CDec(0.4999)
        MyChaoticParameterValue = 2 'is not used

        'Setting split points
        MySplitpoints = New List(Of Decimal) From {
            1
            }

    End Sub

    Protected Overrides Function F(u As Decimal) As Decimal

        'This is the original iteration function
        u = If(u < 0.5, MyParameterA * u, MyParameterA * (1 - u))

        Return u

    End Function

    Protected Overrides Function IterationToTentmap(x As Decimal) As Decimal

        Return x

    End Function

    Protected Overrides Function TentmapToIteration(u As Decimal) As Decimal

        Return u

    End Function
End Class
