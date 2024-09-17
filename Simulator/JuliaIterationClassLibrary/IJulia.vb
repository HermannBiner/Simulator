'Is the interface for any kind of Julia sets
'To program a new Julia set
'just this interface has to be implemented

'Status Checked

Public Interface IJulia

    WriteOnly Property PicDiagram As PictureBox

    'Allowed Interval for the x-Values
    ReadOnly Property AllowedXRange As ClsInterval

    'Allowed Interval for the y-Values
    ReadOnly Property AllowedYRange As ClsInterval

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
    WriteOnly Property UseSystemColors As Boolean

    'Draw Track
    ReadOnly Property IsTrackImplemented As Boolean

    'Iteration Control
    Property IterationStatus As ClsDynamics.EnIterationStatus

    WriteOnly Property TxtNumberOfSteps As TextBox
    WriteOnly Property TxtElapsedTime As TextBox

    'Draws the coordinatesystem
    Sub DrawCoordinateSystem()

    'Iteration
    Function GenerateImage() As Task

    'C-Track - Orbit with STartpoint c
    Sub ShowCTrack()

    'Reset
    Sub ResetIteration()

End Interface
