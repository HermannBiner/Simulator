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
    WriteOnly Property Procotol As ListBox

    'N (number of roots)
    WriteOnly Property N As Integer

    'Draws the coordinatesystem and the roots of the Polynom
    Sub DrawCoordinateSystem()

    'Draws the roots
    Sub DrawRoots(Finished As Boolean)

    'Iteration
    Sub Iteration(Startpoint As Point)

    'Reset
    Sub Reset()

    Sub PrepareIteration()


End Interface
