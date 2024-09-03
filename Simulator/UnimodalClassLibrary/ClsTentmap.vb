'Implements the interface IIteration for the tentmap
'with the Iteration Formula: f(x) = a*x if x in [0,0.5] and f(x) = a*(1-x) if x in ]0.5,1]
'a in ]0,2]. Interesting is only the case a = 2
'and "knows" everything about this kind of iteration

'Status Redesign Tested

Public Class ClsTentmap
    Inherits ClsIterationAbstract

    Protected Overrides Sub InitializeIterator()

        'Generate the needed objects
        MyParameterInterval = New ClsInterval(0, 2)
        MyIterationInterval = New ClsInterval(0, 1)
        MyCriticalPoint = CDec(0.4999)
        MyChaoticParameter = 2 'is not used

        'Setting split points
        MySplitpoints = New List(Of Decimal) From {
            1
            }

    End Sub

    Protected Overrides Function F(u As Decimal) As Decimal

        'This is the original iteration function
        u = If(u < 0.5, MyParameter * u, MyParameter * (1 - u))

        Return u

    End Function

    Protected Overrides Function IterationToTentmap(x As Decimal) As Decimal

        Return x

    End Function

    Protected Overrides Function TentmapToIteration(u As Decimal) As Decimal

        Return u

    End Function
End Class
