'Interface for all kind of billiard balls
'a ball knows the profile of "its" billiard table and all rules for its movement
'the billiard ball can move itself on the billiard table

'Status Checked

Public Interface IBilliardball

    WriteOnly Property PicDiagram As PictureBox
    WriteOnly Property PicGraphics As ClsGraphicTool

    WriteOnly Property BmpDiagram As Bitmap
    WriteOnly Property BmpGraphics As ClsGraphicTool

    'MathValue for graphic calculation
    WriteOnly Property MathInterval As ClsInterval

    'These parameters are set by the user 
    'when selecting a diagram area
    'the Defaults are hold by the BilliardTable
    WriteOnly Property TValueRange As ClsInterval
    WriteOnly Property AlfaValueRange As ClsInterval
    WriteOnly Property ParameterRange As ClsInterval

    'Status Parameters
    WriteOnly Property PhasePortrait As PictureBox
    WriteOnly Property ValueProtocol As ListBox
    WriteOnly Property IsProtocol As Boolean

    'The profile of the billiard table is defined by the parameter a,b
    WriteOnly Property A As Decimal
    WriteOnly Property B As Decimal

    'Properties of the ball
    WriteOnly Property BallColor As Brush
    WriteOnly Property BallSpeed As Integer

    'Parameter of the start
    Property Startparameter As Decimal 'defines the start point
    WriteOnly Property Startangle As Decimal 'defines the start angle in [0, 2pi[
    Property IsStartParameterSet As Boolean
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

    Sub DrawFirstUserStartposition()

    'starts the iteration
    Sub IterationStep()

    'This is the main Function to get the next Iteration Point
    'especially used in the C-Diagram
    Function GetNextValuePair(ActualPoint As ClsValuePair) As ClsValuePair

    'Alfa is the hit angle: that is the angle between the ball orbit
    'and the tangent on the billiard table in the hit point
    Function CalculateAlfa(t As Decimal, phi As Decimal) As Decimal

End Interface
