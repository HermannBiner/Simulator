'This is the interface for any kind of stars, inclidung planets

'Status Checked

Public Interface IStar

    Property Universe As IUniverse

    'the star draws its position, the orbit and 
    'the status into the different diagrams
    Property PicDiagram As PictureBox
    Property PicGraphics As ClsGraphicTool

    Property BmpDiagram As Bitmap
    Property BmpGraphics As ClsGraphicTool

    Property PicPhaseportrait As PictureBox
    Property PicPhasePortraitGraphics As ClsGraphicTool

    'Parameters
    Property OriginalMass As Decimal 'in #Earth masses, set by default

    Property UserMass As Decimal 'in #earth masses, set by the user

    'The origina Startposition is calculated by the perihel data
    'and not changed. It is allways relative to the original 
    'coordinate system. The OriginalStartPosition is set by default
    ReadOnly Property OriginalStartPosition As ClsVector

    'the user startposition is relative to the new coordinatesystem
    'with the gravity centre as origin
    'but with the same direction ot the coordinate axis
    'when placing a new star, its OriginalStartPosition
    'that is relative to the original origin of the coordinatesystem
    'is adjusted relative to the centre of gravity
    'the relative start position can by set by the user as well
    'it is set by ResetIteration
    ReadOnly Property UserStartPosition As ClsVector

    'This is the actual position during the iteration
    'and recalculated in each iterationstep
    ReadOnly Property ActualPosition As ClsVector

    'the original velocity that is set by default
    ReadOnly Property OriginalStartVelocity As ClsVector

    'if the user changes the start velocity
    'it is set as well when resetting the iteration
    ReadOnly Property UserStartVelocity As ClsVector

    'this is the actual velocity that is
    'calculated in each iterationstep
    ReadOnly Property ActualVelocity As ClsVector

    'Needed to calculate the potential energy
    'and this energy is needed to calculate
    'the orbit when the movement of the planet or star
    'is regarded as a two-body problem
    'with the mass of all other stars in the origin
    'of the coordinate system
    Property TotalMassOfOtherStars As Decimal

    'other properties
    Property StarColor As Brush
    Property Name As String
    Property Size As Integer

    'Iteration
    'this is the StepWidth set by the user
    'and used when iterating
    Property ActualStepWidth As Decimal
    'this is a proposed stepwidth
    'that the movement and orbit is about what we expect
    Property ProposedStepWidth As Decimal

    'each star performs the iteration for its own movement
    'before starting the iteration, the parameters
    'u1, u2, v1, v2 are set according to the
    'position and velocity
    Sub ResetIteration()

    'the DefaultUserData is individually defined for each star/planet
    Sub SetDefaultUserData()

    'this is performed individually for each star
    'isdefinitive: then the star i drawed into the BmpDiagram
    'otherwise into the PicDiagram
    Sub DrawStar(IsDefinitive As Boolean)

    'this is the calculated orbit for the two-body problem
    'isdefinitive: drawed into the BmpDiagram
    'otherwise into PicDiagram
    Sub DrawOrbit(IsDefinitive As Boolean)

    'Calculates the next position and velocity
    'using the Runge-Kutta-4 method
    Sub IterationStep(IsPhasePortrait As Boolean)

    'Sets the actual position after a iterationstep
    'this has to be at the same time for all stars
    Sub MoveActualPosition()

    'when the user sets the startposition with the mouse
    Sub SetUserStartPosition(MousePosition As Point)

    'get the supervised data for each star/planet
    Function GetEnergy() As Decimal
    Function GetAngularMomentum() As Decimal
    Function GetPulse() As ClsVector

End Interface
