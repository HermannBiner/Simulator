'Is the interface for any kind of polynoms
'that are the base for the Newton Iteration
'To program a new polynom
'just this interface has to be implemented

'Status Checked

Public Interface IPolynom

    Enum EnColor
        Bright
        Shadowed
    End Enum

    Enum EnMixing
        None
        Conjugate
        Rotate
    End Enum

    'The Polynom plots the Orbit into MapCPlane
    WriteOnly Property MapCPlane As Bitmap

    'The Iteration needs the Picturebox as well
    WriteOnly Property PicCPlane As PictureBox

    'Allowed Interval for the x-Values
    ReadOnly Property AllowedXRange As ClsInterval

    'Allowed Interval for the y-Values
    ReadOnly Property AllowedYRange As ClsInterval

    'Actual interval for the x-Values
    Property ActualXRange As ClsInterval

    'Actual interval for the y-Values
    Property ActualYRange As ClsInterval

    'Protocol
    WriteOnly Property ProcotolList As ListBox
    WriteOnly Property IsProtocol As Boolean

    'Using N as parameter
    ReadOnly Property UseN As Boolean

    'N (number of roots)
    WriteOnly Property N As Integer

    'Using C as parameter
    ReadOnly Property UseC As Boolean

    'Parameter C
    WriteOnly Property C As ClsComplexNumber

    'Mixing
    WriteOnly Property UseMixing As EnMixing

    'Color
    WriteOnly Property UseColor As EnColor

    'Iteration Control
    Property IterationStatus As ClsGeneral.EnIterationStatus

    WriteOnly Property TxtNumberOfSteps As TextBox
    WriteOnly Property TxtElapsedTime As TextBox

    'Draws the coordinatesystem
    Sub DrawCoordinateSystem()

    'Draws the roots
    Sub DrawRoots(Finished As Boolean)

    'Iteration
    'Prepare the Root-Colors
    Sub PrepareIteration()

    Function GenerateImage() As Task

    'Reset
    Sub Reset()

End Interface
