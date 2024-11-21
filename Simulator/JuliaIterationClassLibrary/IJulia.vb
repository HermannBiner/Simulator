'Is the interface for any kind of Julia sets
'To program a new Julia set
'just this interface has to be implemented

'Status Checked

Public Interface IJulia

    Property PicDiagram As PictureBox

    'Value Parameter Definition for the x-Values
    ReadOnly Property XValueParameter As ClsGeneralParameter

    'Value Parameter Definition  for the y-Values
    ReadOnly Property YValueParameter As ClsGeneralParameter

    'Actual interval for the x-Values
    Property ActualXRange As ClsInterval

    'Actual interval for the y-Values
    Property ActualYRange As ClsInterval

    'Parameter C
    WriteOnly Property C As ClsComplexNumber

    'Power of Z
    WriteOnly Property N As Integer

    'Protocol
    WriteOnly Property ProcotolList As ListBox
    WriteOnly Property IsProtocol As Boolean

    'ARGB Colors Intensity
    WriteOnly Property RedPercent As Double
    WriteOnly Property GreenPercent As Double
    WriteOnly Property BluePercent As Double

    'Use the System Colors
    WriteOnly Property IsUseSystemColors As Boolean

    'That means, it is a landscape of Julia Parameters
    ReadOnly Property IsMandelbrot As Boolean

    'Draws the coordinatesystem
    Sub DrawCoordinateSystem()

    'Reset
    Sub ResetIteration()

    Sub IterationStep(PixelPoint As Point)

End Interface
