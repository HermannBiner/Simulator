'This is the abstract class for all kind of Julia Sets
'containing the common logic for all these classes

'Status Checked

Public MustInherit Class ClsJuliaAbstract
    Implements IJulia

    'Drawing MapCPlane
    Protected MyMapCPlane As Bitmap
    Protected MyMapCPlaneGraphics As ClsGraphicTool

    'Allowed Interval for the x-Values
    Protected MyAllowedXRange As ClsInterval

    'Allowed Interval for the y-Values
    Protected MyAllowedYRange As ClsInterval

    'the actual range for the x-coordinate
    Protected MyActualXRange As ClsInterval

    'the actual range for the y-coordinate
    Protected MyActualYRange As ClsInterval

    'Parameter C
    Protected Property MyC As ClsComplexNumber

    'Power of z
    Protected MustOverride WriteOnly Property N As Integer Implements IJulia.N

    'Color Intensity
    Protected Property MyRedPercent As Double
    Protected Property MyGreenPercent As Double
    Protected Property MyBluePercent As Double

    'Use SystemColors
    Protected Property MyUseSystemColors As Boolean

    'Protocol
    Protected MyProtocolList As ListBox
    Protected MyIsProtocol As Boolean

    'SECTOR INTERFACE

    WriteOnly Property MapCPlane As Bitmap Implements IJulia.MapCPlane
        Set(value As Bitmap)
            MyMapCPlane = value
            MyMapCPlaneGraphics = New ClsGraphicTool(MyMapCPlane, MyActualXRange, MyActualYRange)
        End Set
    End Property

    ReadOnly Property AllowedXRange As ClsInterval Implements IJulia.AllowedXRange
        Get
            AllowedXRange = MyAllowedXRange
        End Get
    End Property

    ReadOnly Property AllowedYRange As ClsInterval Implements IJulia.AllowedYRange
        Get
            AllowedYRange = MyAllowedYRange
        End Get
    End Property

    Property ActualXRange As ClsInterval Implements IJulia.ActualXRange
        Get
            ActualXRange = MyActualXRange
        End Get
        Set(value As ClsInterval)
            MyActualXRange = value
        End Set
    End Property

    Property ActualYRange As ClsInterval Implements IJulia.ActualYRange
        Get
            ActualYRange = MyActualYRange
        End Get
        Set(value As ClsInterval)
            MyActualYRange = value
        End Set
    End Property

    WriteOnly Property C As ClsComplexNumber Implements IJulia.C
        Set(value As ClsComplexNumber)
            MyC = value
        End Set
    End Property

    WriteOnly Property RedPercent As Double Implements IJulia.RedPercent
        Set(value As Double)
            MyRedPercent = value
        End Set
    End Property

    WriteOnly Property GreenPercent As Double Implements IJulia.GreenPercent
        Set(value As Double)
            MyGreenPercent = value
        End Set
    End Property

    WriteOnly Property BluePercent As Double Implements IJulia.BluePercent
        Set(value As Double)
            MyBluePercent = value
        End Set
    End Property

    WriteOnly Property UseSystemColors As Boolean Implements IJulia.UseSystemColors
        Set(value As Boolean)
            MyUseSystemColors = value
        End Set
    End Property

    WriteOnly Property ProcotolList As ListBox Implements IJulia.ProcotolList
        Set(value As ListBox)
            MyProtocolList = value
        End Set
    End Property

    WriteOnly Property IsProtocol As Boolean Implements IJulia.IsProtocol
        Set(value As Boolean)
            MyIsProtocol = value
        End Set
    End Property

    Public Sub DrawCoordinateSystem() Implements IJulia.DrawCoordinateSystem

        If ActualXRange.IsNumberInInterval(0) Then

            'Draw y-axis
            MyMapCPlaneGraphics.DrawLine(New ClsMathpoint(0, ActualYRange.A),
                                             New ClsMathpoint(0, ActualYRange.B), Color.Black, 1)
        End If

        If ActualYRange.IsNumberInInterval(0) Then

            'Draw x-axis
            MyMapCPlaneGraphics.DrawLine(New ClsMathpoint(ActualXRange.A, 0),
                                         New ClsMathpoint(ActualXRange.B, 0), Color.Black, 1)
        End If

    End Sub


    Public Sub Iteration(Startpoint As Point) Implements IJulia.Iteration

        'Transform the PixelPoint to a Complex Number
        Dim MathStartpoint As ClsComplexNumber

        With MyMapCPlaneGraphics.PixelToMathpoint(Startpoint)
            'Saved for debugging
            MathStartpoint = New ClsComplexNumber(.X, .Y)
        End With

        Dim Zi As New ClsComplexNumber(MathStartpoint.X, MathStartpoint.Y)

        Dim MyBrush As Brush = IterationFormula(Zi)

        MyMapCPlaneGraphics.DrawPoint(Startpoint, MyBrush, 1)
        MyBrush.Dispose()

    End Sub


    Public Sub Reset() Implements IJulia.Reset

        'Clear MapCPlane
        If MyMapCPlaneGraphics IsNot Nothing Then
            MyMapCPlaneGraphics.Clear(Color.White)
            DrawCoordinateSystem()
        End If

    End Sub

    Public MustOverride Function IterationFormula(Z As ClsComplexNumber) As Brush

End Class
