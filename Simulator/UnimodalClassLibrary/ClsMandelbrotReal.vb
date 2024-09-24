'This class is only to generate the Feigenbaum Diagram in case of the Mandelbrot set
'when the Mandelbrot set is only using real numbers

'Status Checked

Public Class ClsMandelbrotReal
    Inherits ClsIterationAbstract

    Protected Overrides Sub InitializeIterator()

        'Generate the needed objects

        MyFormulaParameter = New ClsGeneralParameter(1, "Parameter a", New ClsInterval(-2, 0),
                                                     ClsGeneralParameter.TypeOfParameterEnum.Formula, -1)

        MyValueParameter = New ClsGeneralParameter(2, "Value x", New ClsInterval(-2, 2),
                                                   ClsGeneralParameter.TypeOfParameterEnum.Formula, CDec(0.314159))

        MyCriticalPoint = 0
        MyChaoticParameterValue = -2

        'Setting split points to be drawn in the image
        MySplitpoints = New List(Of Decimal) From {
            CDec(-0.75), 'first 2-cycle
        CDec(-1.24995), 'first 4-cycle
            CDec(-1.3681), 'first 8-cycle
            CDec(-1.39405), 'first 16-cycle
            CDec(-1.401155) 'limit value of the period doubling
            }
    End Sub

    Overrides Property ParameterA As Decimal
        Get
            ParameterA = MyParameterA
        End Get
        Set(Value As Decimal)
            MyParameterA = Value
            'the following would be nessecary 
            'if the ClsMandelbrotReal should be ready
            'for FrmIteration etc.
            'Dim b As Decimal
            'b = CDec(1 + Math.Sqrt(1 - 4 * MyParameterA) / 2)
            'MyValueParameter.Range = New ClsInterval(-b, b)
        End Set
    End Property

    Protected Overrides Function F(x As Decimal) As Decimal

        'This is the original iteration function
        Return MyParameterA + x * x

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
