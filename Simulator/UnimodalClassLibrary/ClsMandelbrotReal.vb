'This class is only to generate the Feigenbaum Diagram in case of the Mandelbrot set
'It doesn't give any relevant result for the other forms except FrmFeigenbaum

Public Class ClsMandelbrotReal
    Inherits ClsIterationAbstract

    Protected Overrides Sub InitializeIterator()

        'Generate the needed objects
        MyParameterInterval = New ClsInterval(-2, 0)
        MyIterationInterval = New ClsInterval(-2, 2)
        MyCriticalPoint = 0
        MyChaoticParameter = -2

        'Setting split points to be drawn in the image
        MySplitpoints = New List(Of Decimal) From {
            CDec(-0.75), 'first 2-cycle
        CDec(-1.24995), 'first 4-cycle
            CDec(-1.3681), 'first 8-cycle
            CDec(-1.39405), 'first 16-cycle
            CDec(-1.401155) 'limit value of the period doubling
            }
    End Sub


    Protected Overrides Function F(x As Decimal) As Decimal

        'This is the original iteration function
        Return MyParameter + x * x

    End Function

    Protected Overrides Function IterationToTentmap(x As Decimal) As Decimal

        'This is the conjugation that transforms the MAndelbrot Real to the tentmap

        'because of roundings, the value x can be a little above 1 or below -1
        'that has to be adjusted
        x = Math.Max(-1, Math.Min(1, x))

        Return CDec(Math.Acos(x / 2) / Math.PI)

    End Function

    Protected Overrides Function TentmapToIteration(u As Decimal) As Decimal

        'This is the conjugation that transforms the tentmap to the Mandelbrot Real Function

        Return CDec(2 * Math.Cos(Math.PI * u))

    End Function
End Class
