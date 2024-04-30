'Interface for all kind of billiard balls
'a ball knows the profile of "its" billiard table and all rules for its movement
'the billiard ball can move itself on the billiard table

'Status Checked

Public Interface IBilliardball

    WriteOnly Property Billiardtable As PictureBox


    WriteOnly Property MapBilliardtable As Bitmap


    'The profile of the billiard table is defined by the parameter C
    Property C As Decimal

    'in addtion, the ball protocols its movement in a phase portrait
    WriteOnly Property Phaseportrait As PictureBox

    WriteOnly Property ParameterProtocol As ListBox


    'Properties of the ball
    WriteOnly Property Ballcolor As Brush
    WriteOnly Property Ballsize As Integer
    WriteOnly Property Ballspeed As Integer


    'Parameter of the start
    Property Startparameter As Decimal 'defines the start point
    WriteOnly Property Startangle As Decimal 'defines the start angle in [0, 2pi[
    Property IsStartpositionSet As Boolean
    Property IsStartangleSet As Boolean

    'Drawing the Billiard Table
    Sub DrawBilliardtable()

    'Clearing Billiard Table
    Sub ClearBilliardTable()

    'The following method receives a mouse position relative to the bitmap
    'It pulls the ball according to the mouse position on its start position
    'and gives the parameter t back that defines the start position of the Ball
    'see mathematical documentation
    Function SetAndDrawUserStartposition(Mouseposition As Point, definitive As Boolean) As Decimal

    'The following method receives a mouse position relative to the bitmap
    'It pulls the first hit point of the ball according to the mouse position
    'and gives the parameter phi for the start angle back
    'see mathematical documentation
    Function SetAndDrawUserEndposition(Mouseposition As Point, definitive As Boolean) As Decimal

    'Alfa is the hit angle: that is the angle between the ball orbit
    'and the tangent on the billiard table in the hit point
    Function CalculateAlfa(t As Decimal, phi As Decimal) As Decimal

    'starts the iteration
    Sub Iteration(NumberOfSteps As Integer)

End Interface
