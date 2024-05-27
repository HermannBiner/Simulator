'Is the interface for any kind of polynoms
'that are the base for the Newton Iteration
'To program a new polynom
'just this interface has to be implemented

'Status Checked

Public Interface IPolynom

    'The Polynom plots the Orbit into MapCPlane
    WriteOnly Property MapCPlane As Bitmap

    'Allowed Interval for the x-Values
    ReadOnly Property AllowedXRange As ClsInterval

    'Allowed Interval for the y-Values
    ReadOnly Property AllowedYRange As ClsInterval

    'Actual interval for the x-Values
    Property ActualXRange As ClsInterval

    'Actual interval for the y-Values
    Property ActualYRange As ClsInterval

    'How deep should the iteration go
    WriteOnly Property Deepness As Integer

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

    'Conjugate Z
    'the Newton Iteration is replaced
    'and Z is conjugated in each step
    WriteOnly Property ConjugateZ As Boolean


    'Draws the coordinatesystem
    Sub DrawCoordinateSystem()

    'Draws the roots
    Sub DrawRoots(Finished As Boolean)

    'Iteration
    Sub Iteration(Startpoint As Point)

    'Reset
    Sub Reset()

    Sub PrepareIteration()


End Interface
