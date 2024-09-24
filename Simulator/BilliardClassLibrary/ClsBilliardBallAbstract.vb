'This is the abstract class for all kind of BilliardBalls

Public MustInherit Class ClsBilliardBallAbstract
    Implements IBilliardball

    'The actual position of the Ball is drawn into this PictureBox
    'and shown by the Refresh-Method
    Protected MyPicDiagram As PictureBox
    Protected MyPicGraphics As ClsGraphicTool

    'The permanent Orbit of the Ball is drawn into the BitMap
    Protected MyBmpDiagram As Bitmap
    Protected MyBmpGraphics As ClsGraphicTool

    'Used for calculations
    Protected MyMathInterval As ClsInterval
    Protected MyTValueRange As ClsInterval
    Protected MyAlfaValueRange As ClsInterval
    Protected MyParameterRange As ClsInterval

    'The ball draws as well into the Phase Portrait
    Protected MyPhaseportrait As PictureBox
    Protected PhaseportraitGraphics As ClsGraphicTool

    'and protocols its Position (Parameter t and reflexion-angle Alfa) into a ListBox
    Protected MyValueProtocol As ListBox

    'form of the BilliardTable
    Protected MyA As Decimal
    Protected MyB As Decimal

    'The class for general mathematical Calculations
    Protected Mathhelper As ClsMathhelperBilliard

    'Parameter that defines the actual hit point
    'see mathematical documentation
    Protected T As Decimal

    'This is the angle between the actual moving-direction and the positive x-axis
    Protected Phi As Decimal

    'Properties of the Ball
    Protected MyColor As Brush

    'Size in pixel units
    Protected Const Size As Integer = 4
    Protected MySpeed As Integer = 5

    'Size of the point in the phase portrait
    Protected Const p As Integer = 2

    'StartParameters
    Protected MyStartParameter As Decimal
    Protected MyStartAngle As Decimal

    'Start Position of the Ball, set by the User
    Protected UserStartposition As ClsMathpoint
    Protected UserEndposition As ClsMathpoint

    'Control ot Setting these Start Parameters
    Protected MyStartPositionSet As Boolean
    Protected MyStartAngleSet As Boolean

    WriteOnly Property PicDiagram As PictureBox Implements IBilliardball.PicDiagram
        Set(value As PictureBox)
            MyPicDiagram = value
        End Set
    End Property

    WriteOnly Property PicGraphics As ClsGraphicTool Implements IBilliardball.PicGraphics
        Set(value As ClsGraphicTool)
            MyPicGraphics = value
        End Set
    End Property

    WriteOnly Property BmpDiagram As Bitmap Implements IBilliardball.BmpDiagram
        Set(value As Bitmap)
            MyBmpDiagram = value
        End Set
    End Property

    WriteOnly Property BmpGraphics As ClsGraphicTool Implements IBilliardball.BmpGraphics
        Set(value As ClsGraphicTool)
            MyBmpGraphics = value
        End Set
    End Property

    WriteOnly Property MathInterval As ClsInterval Implements IBilliardball.MathInterval
        Set(value As ClsInterval)
            MyMathInterval = value
        End Set
    End Property

    WriteOnly Property TValueRange As ClsInterval Implements IBilliardball.TValueRange
        Set(value As ClsInterval)
            MyTValueRange = value
        End Set
    End Property

    WriteOnly Property AlfaValueRange As ClsInterval Implements IBilliardball.AlfaValueRange
        Set(value As ClsInterval)
            MyAlfaValueRange = value
        End Set
    End Property
    WriteOnly Property ParameterRange As ClsInterval Implements IBilliardball.ParameterRange
        Set(value As ClsInterval)
            MyParameterRange = value
        End Set
    End Property

    WriteOnly Property A As Decimal Implements IBilliardball.A
        Set(value As Decimal)
            MyA = value
        End Set
    End Property

    WriteOnly Property B As Decimal Implements IBilliardball.B
        Set(value As Decimal)
            MyB = value
        End Set
    End Property

    Public WriteOnly Property PhasePortrait As PictureBox Implements IBilliardball.PhasePortrait
        Set(value As PictureBox)
            MyPhaseportrait = value
            PhaseportraitGraphics = New ClsGraphicTool(MyPhaseportrait, MyTValueRange, MyAlfaValueRange)
        End Set
    End Property

    WriteOnly Property ValueProtocol As ListBox Implements IBilliardball.ValueProtocol
        Set(value As ListBox)
            MyValueProtocol = value
        End Set
    End Property

    WriteOnly Property Ballcolor As Brush Implements IBilliardball.BallColor
        Set(value As Brush)
            MyColor = value
        End Set
    End Property

    WriteOnly Property Ballspeed As Integer Implements IBilliardball.BallSpeed
        Set(value As Integer)
            MySpeed = value
        End Set
    End Property

    Property IsStartpositionSet As Boolean Implements IBilliardball.IsStartpositionSet
        Get
            IsStartpositionSet = MyStartPositionSet
        End Get
        Set(value As Boolean)
            MyStartPositionSet = value
        End Set
    End Property

    Property IsStartangleSet As Boolean Implements IBilliardball.IsStartangleSet
        Get
            IsStartangleSet = MyStartAngleSet
        End Get
        Set(value As Boolean)
            MyStartAngleSet = value
        End Set
    End Property

    Public Sub New()
        Mathhelper = New ClsMathhelperBilliard
    End Sub

    MustOverride Property Startparameter As Decimal Implements IBilliardball.Startparameter

    MustOverride WriteOnly Property Startangle As Decimal Implements IBilliardball.Startangle

    Public MustOverride Sub IterationStep() Implements IBilliardball.IterationStep

    Public MustOverride Function SetAndDrawUserStartposition(Mouseposition As Point, definitive As Boolean) As Decimal Implements IBilliardball.SetAndDrawUserStartposition

    Public MustOverride Function SetAndDrawUserEndposition(Mouseposition As Point, definitive As Boolean) As Decimal Implements IBilliardball.SetAndDrawUserEndposition

    Public MustOverride Function GetNextValuePair(ActualPoint As ClsValuePair) As ClsValuePair Implements IBilliardball.GetNextValuePair

    Public MustOverride Sub DrawFirstUserStartposition() Implements IBilliardball.DrawFirstUserStartposition

    Public MustOverride Function CalculateAlfa(t As Decimal, phi As Decimal) As Decimal Implements IBilliardball.CalculateAlfa
End Class
