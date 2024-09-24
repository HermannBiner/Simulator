'Is the interface for any kind of polynoms
'that are the base for the Newton Iteration
'To program a new polynom
'just this interface has to be implemented

'Status Checked

Public Interface INewton

    Enum EnColor
        Bright
        Shadowed
    End Enum

    Enum EnMixing
        None
        Conjugate
        Rotate
    End Enum

    'The Iteration needs the Picturebox as well
    WriteOnly Property PicDiagram As PictureBox

    'Value Parameter Definition for the x-Values
    ReadOnly Property XValueParameter As ClsGeneralParameter

    'Value Parameter Definition  for the y-Values
    ReadOnly Property YValueParameter As ClsGeneralParameter

    'Actual interval for the x-Values
    Property ActualXRange As ClsInterval

    'Actual interval for the y-Values
    Property ActualYRange As ClsInterval

    'Protocol
    WriteOnly Property ProcotolList As ListBox
    WriteOnly Property IsProtocol As Boolean

    'Using N as parameter
    ReadOnly Property IsUseN As Boolean

    'N (number of roots)
    Property N As Integer

    'Using C as parameter
    ReadOnly Property IsUseC As Boolean

    'Parameter C
    WriteOnly Property C As ClsComplexNumber

    'Mixing
    WriteOnly Property UseMixing As EnMixing

    'Color
    WriteOnly Property UseColor As EnColor

    'IsShowBasin
    ReadOnly Property IsShowBasin As Boolean

    'Iteration Control
    Property IterationStatus As ClsDynamics.EnIterationStatus

    WriteOnly Property TxtNumberOfSteps As TextBox
    WriteOnly Property TxtElapsedTime As TextBox

    'Draws the coordinatesystem
    Sub DrawCoordinateSystem()

    'Draws the roots
    Sub DrawRoots(Finished As Boolean)

    'Iteration
    'Prepare the Root-Colors
    Sub PrepareUnitRoots()

    Function GenerateImage() As Task

    'Reset
    Sub ResetIteration()

End Interface
