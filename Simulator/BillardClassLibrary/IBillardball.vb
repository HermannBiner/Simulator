'Interface for all kind of billard balls
'a ball knows the profile of "its" billard table and all rules for its movement
'the billard ball can move itself on the billard table

'Status Checked

Public Interface IBillardball

    WriteOnly Property Billardtable As PictureBox


    WriteOnly Property MapBillardtable As Bitmap


    'The profile of the billard table is defined by the parameter C
    WriteOnly Property C As Decimal


    'in addtion, the ball protocols its movement in a phase portrait
    WriteOnly Property Phaseportrait As PictureBox

    WriteOnly Property ParameterProtocol As ListBox


    'Properties of the ball
    WriteOnly Property Ballcolor As Brush
    WriteOnly Property Ballsize As Integer
    WriteOnly Property Ballspeed As Integer


    'Parameter of the start
    Property Startparameter As Decimal ''bestimmt Startpunkt
    WriteOnly Property Startangle As Decimal ''Startwinkel in [0, 2pi[
    Property IsStartpositionSet As Boolean
    Property IsStartangleSet As Boolean

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
    'and the tangent on the billard table in the hit point
    Function CalculateAlfa(t As Decimal, phi As Decimal) As Decimal

    'starts the iteration loop
    Sub Iteration(NumberOfSteps As Integer)

End Interface
