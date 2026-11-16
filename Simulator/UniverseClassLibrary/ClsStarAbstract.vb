'This is an abstract class for all stars
'a star holds its Originalposition (Default - defined by perihel)
'its Startposition (maybe changed by the user)
'and its actualposition (during the movement)
'it holds as well all status variables needed for RK4
'the calculation of RK4 is part of the implementation of the universe
'as well of the drawing of all starpositions

'Status Checked

Public MustInherit Class ClsStarAbstract
    Implements IStar

    'to which universe belongs the star
    Protected Property MyUniverse As IUniverse

    'the star draws into different diagrams
    Protected MyPicDiagram As PictureBox
    Protected MyPicGraphics As ClsGraphicTool
    Protected MyBmpDiagram As Bitmap
    Protected MyBmpGraphics As ClsGraphicTool

    Protected MyPicPhasePortrait As PictureBox
    Protected MyPicPhasePortraitGraphics As ClsGraphicTool
    Protected PhasePortraitPoint As ClsMathpoint

    Protected MathHelper As ClsMathHelperAngles

    'for the description of the following parameters
    'see interface IStar

    'Mass
    Protected MyOriginalMass As Double
    Protected MyUserMass As Double

    'Positions
    Protected MyOriginalStartPosition As ClsVector
    Protected MyUserStartPosition As ClsVector
    Protected MyActualPosition As ClsVector

    'Calculated during the movement
    Protected NewPosition As ClsVector

    'Position in the actual stage of the Runge Kutta step
    Protected MyStagePosition As ClsVector

    'Velocities
    Protected MyOriginalStartVelocity As ClsVector
    Protected MyUserStartVelocity As ClsVector
    Protected MyActualVelocity As ClsVector
    'needed when calcuating the pulse as vector
    Protected ActualPulse As ClsVector

    'To calculate the gravity point
    Protected MyTotalMassOfOtherStars As Double

    'Other
    Protected MyStarColor As Brush
    Protected MyName As String
    Protected MySize As Integer

    'Iteration
    Protected MyActualStepWidth As Double
    Protected MyProposedStepWidth As Double

    'Runge Kutta Parameters
    Protected u1 As Double 'Position.X
    Protected v1 As Double 'Velocity.X
    Protected u2 As Double 'Position.Y
    Protected v2 As Double 'Velocity.Y

    'And additional Parameters for Runge Kutta
    Protected ReadOnly z As ClsNTupel
    Protected ReadOnly k1 As ClsNTupel
    Protected ReadOnly h1 As ClsNTupel
    Protected ReadOnly k2 As ClsNTupel
    Protected ReadOnly h2 As ClsNTupel

    'Drawings
    Protected ActualMathPointPosition As ClsMathpoint
    Protected NewMathPointPosition As ClsMathpoint

    Public Sub New()
        MyOriginalStartPosition = New ClsVector
        MyUserStartPosition = New ClsVector
        MyActualPosition = New ClsVector
        MyOriginalStartVelocity = New ClsVector
        MyUserStartVelocity = New ClsVector
        MyActualVelocity = New ClsVector
        ActualPulse = New ClsVector
        MathHelper = New ClsMathHelperAngles
        NewPosition = New ClsVector
        MyStagePosition = New ClsVector

        z = New ClsNTupel(3)
        k1 = New ClsNTupel(3)
        h1 = New ClsNTupel(3)
        k2 = New ClsNTupel(3)
        h2 = New ClsNTupel(3)

        ActualMathPointPosition = New ClsMathpoint
        NewMathPointPosition = New ClsMathpoint
        PhasePortraitPoint = New ClsMathpoint
    End Sub

    Property Universe As IUniverse Implements IStar.Universe
        Get
            Universe = MyUniverse
        End Get
        Set(value As IUniverse)
            MyUniverse = value
        End Set
    End Property

    Property PicDiagram As PictureBox Implements IStar.PicDiagram
        Get
            PicDiagram = MyPicDiagram
        End Get
        Set(value As PictureBox)
            MyPicDiagram = value
        End Set
    End Property

    Property PicGraphics As ClsGraphicTool Implements IStar.PicGraphics
        Get
            PicGraphics = MyPicGraphics
        End Get
        Set(value As ClsGraphicTool)
            MyPicGraphics = value
        End Set
    End Property

    Property BmpDiagram As Bitmap Implements IStar.BmpDiagram
        Get
            BmpDiagram = MyBmpDiagram
        End Get
        Set(value As Bitmap)
            MyBmpDiagram = value
        End Set
    End Property

    Property BmpGraphics As ClsGraphicTool Implements IStar.BmpGraphics
        Get
            BmpGraphics = MyBmpGraphics
        End Get
        Set(value As ClsGraphicTool)
            MyBmpGraphics = value
        End Set
    End Property

    Property PicPhasePortrait As PictureBox Implements IStar.PicPhaseportrait
        Get
            PicPhasePortrait = MyPicPhasePortrait
        End Get
        Set(value As PictureBox)
            MyPicPhasePortrait = value
        End Set
    End Property

    Property PicPhasePortraitGraphics As ClsGraphicTool Implements IStar.PicPhasePortraitGraphics
        Get
            PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
        End Get
        Set(value As ClsGraphicTool)
            MyPicPhasePortraitGraphics = value
        End Set
    End Property

    Property OriginalMass As Double Implements IStar.OriginalMass
        Get
            OriginalMass = MyOriginalMass
        End Get
        Set(value As Double)
            MyOriginalMass = value
        End Set
    End Property

    Property UserMass As Double Implements IStar.UserMass
        Get
            UserMass = MyUserMass
        End Get
        Set(value As Double)
            MyUserMass = value
        End Set
    End Property

    Property StarColor As Brush Implements IStar.StarColor
        Get
            StarColor = MyStarColor
        End Get
        Set
            MyStarColor = Value
        End Set
    End Property

    Property Name As String Implements IStar.Name
        Get
            Name = MyName
        End Get
        Set(value As String)
            MyName = value
        End Set
    End Property

    Property Size As Integer Implements IStar.Size
        Get
            Size = MySize
        End Get
        Set(value As Integer)
            MySize = value
        End Set
    End Property

    Property ProposedStepWidth As Double Implements IStar.ProposedStepWidth
        Get
            ProposedStepWidth = MyProposedStepWidth
        End Get
        Set(value As Double)
            MyProposedStepWidth = value
        End Set
    End Property

    Property ActualStepWidth As Double Implements IStar.ActualStepWidth
        Get
            ActualStepWidth = MyActualStepWidth
        End Get
        Set(value As Double)
            MyActualStepWidth = value
        End Set
    End Property

    Property TotalMassOfOtherStars As Double Implements IStar.TotalMassOfOtherStars
        Get
            TotalMassOfOtherStars = MyTotalMassOfOtherStars
        End Get
        Set(value As Double)
            MyTotalMassOfOtherStars = value
        End Set
    End Property

    ReadOnly Property OriginalStartPosition As ClsVector Implements IStar.OriginalStartPosition
        Get
            'by reference
            OriginalStartPosition = MyOriginalStartPosition
        End Get
    End Property

    ReadOnly Property UserStartPosition As ClsVector Implements IStar.UserStartPosition
        Get
            'by reference
            UserStartPosition = MyUserStartPosition
        End Get
    End Property

    ReadOnly Property ActualPosition As ClsVector Implements IStar.ActualPosition
        Get
            ActualPosition = MyActualPosition
        End Get
    End Property

    ReadOnly Property OriginalStartVelocity As ClsVector Implements IStar.OriginalStartVelocity
        Get
            OriginalStartVelocity = MyOriginalStartVelocity
        End Get
    End Property

    ReadOnly Property UserStartVelocity As ClsVector Implements IStar.UserStartVelocity
        Get
            UserStartVelocity = MyUserStartVelocity
        End Get
    End Property

    ReadOnly Property ActualVelocity As ClsVector Implements IStar.ActualVelocity
        Get
            ActualVelocity = MyActualVelocity
        End Get
    End Property


    Protected Sub DrawTrack()

        ActualMathPointPosition.X = ActualPosition.X * MyUniverse.DiagramZoom
        ActualMathPointPosition.Y = ActualPosition.Y * MyUniverse.DiagramZoom
        NewMathPointPosition.X = NewPosition.X * MyUniverse.DiagramZoom
        NewMathPointPosition.Y = NewPosition.Y * MyUniverse.DiagramZoom

        MyBmpGraphics.DrawLine(NewMathPointPosition, ActualMathPointPosition, MyStarColor, 2)

    End Sub

    Public Sub ResetIteration() Implements IStar.ResetIteration
        MyActualPosition.Equal(MyUserStartPosition)
        u1 = MyActualPosition.X
        u2 = MyActualPosition.Y
        MyActualVelocity.Equal(MyUserStartVelocity)
        v1 = MyActualVelocity.X
        v2 = MyActualVelocity.Y
    End Sub

    Public Sub SetDefaultUserData() Implements IStar.SetDefaultUserData
        'Startparameter und Actualparameter are set to Default
        MyUserStartPosition.Equal(MyOriginalStartPosition)
        '!! ToDo RelativeStartposition is calculated by RedrawUniverse
        MyActualPosition.Equal(MyOriginalStartPosition)
        MyUserMass = MyOriginalMass
        MyUserStartVelocity.Equal(MyOriginalStartVelocity)
        MyActualVelocity.Equal(MyUserStartVelocity)
        MyTotalMassOfOtherStars = 0
        MyActualStepWidth = CDbl(MyProposedStepWidth)
    End Sub

    Public Sub SetUserStartPosition(MousePosition As Point) Implements IStar.SetUserStartPosition

        With MyPicGraphics.PixelToMathpoint(MousePosition)
            MyUserStartPosition.X = .X / MyUniverse.DiagramZoom
            MyUserStartPosition.Y = .Y / MyUniverse.DiagramZoom
            MyActualPosition.Equal(MyUserStartPosition)
        End With

        MyPicDiagram.Refresh()
        DrawStar(False)
        DrawOrbit(False)
    End Sub

    Public Sub DrawStar(IsDefinitive As Boolean) Implements IStar.DrawStar
        Dim DrawPosition As New ClsMathpoint(MyActualPosition.X *
                   MyUniverse.DiagramZoom, MyActualPosition.Y * MyUniverse.DiagramZoom)
        If IsDefinitive Then
            MyBmpGraphics.DrawPoint(DrawPosition, MyStarColor, MySize)
            MyPicDiagram.Refresh()
        Else
            MyPicGraphics.DrawPoint(DrawPosition, MyStarColor, MySize)
        End If
    End Sub

    'SECTOR RUNGE KUTTA
    'One Runge Kutta step is performed for all stars together (see ClsUniverseAbstract.IterationStep):
    'in each of the four stages, the accelerations are calculated
    'with the stage positions of all stars

    Public Sub BeginIterationStep() Implements IStar.BeginIterationStep

        'u1, u2, v1, v2 are already set
        'when starting the iteration
        MyActualVelocity.X = v1
        MyActualVelocity.Y = v2

        'Set z1n, n is the nth iterationstep
        SetStage(u1, v1, u2, v2)

    End Sub

    Public Sub CalculateStage(Stage As Integer) Implements IStar.CalculateStage

        'k1: belongs to u1' and F1
        'k2: belongs to u2' and F2
        'h1: belongs to v1' abd G1
        'h2: belongs to v2' and G2
        'k,h.component(i): step i in Runge Kutta (0..3)
        k1.Component(Stage) = F1(z) ' z.Component(1)
        k2.Component(Stage) = F2(z) ' z.Component(3)
        h1.Component(Stage) = G1(z)
        h2.Component(Stage) = G2(z)

    End Sub

    Public Sub PrepareStage(Stage As Integer) Implements IStar.PrepareStage

        'Sets z for the stage 1, 2 or 3 with the slopes of the previous stage
        'Stage 1 and 2: half step, stage 3: full step
        Dim Factor As Double = If(Stage = 3, MyActualStepWidth, MyActualStepWidth / 2)

        SetStage(u1 + Factor * k1.Component(Stage - 1),
                 v1 + Factor * h1.Component(Stage - 1),
                 u2 + Factor * k2.Component(Stage - 1),
                 v2 + Factor * h2.Component(Stage - 1))

    End Sub

    Private Sub SetStage(Stageu1 As Double, Stagev1 As Double, Stageu2 As Double, Stagev2 As Double)
        With z
            .Component(0) = Stageu1
            .Component(1) = Stagev1
            .Component(2) = Stageu2
            .Component(3) = Stagev2
        End With

        'the other stars use this position in the same stage
        MyStagePosition.X = Stageu1
        MyStagePosition.Y = Stageu2
    End Sub

    ReadOnly Property StagePosition As ClsVector Implements IStar.StagePosition
        Get
            StagePosition = MyStagePosition
        End Get
    End Property

    Public Sub FinishIterationStep(IsPhasePortrait As Boolean) Implements IStar.FinishIterationStep

        'See math. doc. for the Details of this Implementation

        'the new actual position is set for all stars
        'to the new position
        'at the same time when all of them have finished
        'the iterationstep (MoveActualPosition)

        'Update u1, v1, u2, v2
        u1 += MyActualStepWidth * (k1.Component(0) + 2 * k1.Component(1) + 2 * k1.Component(2) + k1.Component(3)) / 6
        v1 += MyActualStepWidth * (h1.Component(0) + 2 * h1.Component(1) + 2 * h1.Component(2) + h1.Component(3)) / 6
        u2 += MyActualStepWidth * (k2.Component(0) + 2 * k2.Component(1) + 2 * k2.Component(2) + k2.Component(3)) / 6
        v2 += MyActualStepWidth * (h2.Component(0) + 2 * h2.Component(1) + 2 * h2.Component(2) + h2.Component(3)) / 6

        With NewPosition
            .X = u1
            .Y = u2
        End With

        If IsPhasePortrait Then
            'Draw Phase Diagram
            DrawPhaseportrait()
        End If

        DrawStar(False)

    End Sub

    Public Sub MoveActualPosition() Implements IStar.MoveActualPosition

        DrawTrack()
        With MyActualPosition
            .X = NewPosition.X
            .Y = NewPosition.Y
        End With

    End Sub

    Private Sub DrawPhaseportrait()

        'the following scales were found by experiments
        PhasePortraitPoint.X = CDbl(Math.Sqrt(u1 * u1 + u2 * u2)) * MyUniverse.DiagramZoom  'rho
        PhasePortraitPoint.Y = CDbl(Math.Sqrt(v1 * v1 + v2 * v2)) * MyUniverse.VFactor 'vAbs
        PicPhasePortraitGraphics.DrawPoint(PhasePortraitPoint, MyStarColor, 1)

    End Sub

    Public Function GetAngularMomentum() As Double Implements IStar.GetAngularMomentum
        Return MyUserMass * (u1 * v2 - u2 * v1)
    End Function

    Public Function GetPulse() As ClsVector Implements IStar.GetPulse
        ActualPulse.X = CDbl(MyUserMass * MyActualVelocity.X)
        ActualPulse.Y = CDbl(MyUserMass * MyActualVelocity.Y)
        Return ActualPulse
    End Function

    'the following is depending of the type of the universe
    'and the force law between stars

    Public MustOverride Sub DrawOrbit(IsDefinitive As Boolean) Implements IStar.DrawOrbit

    Public MustOverride Function GetEnergy() As Double Implements IStar.GetEnergy

    Protected MustOverride Function F1(LocZ As ClsNTupel) As Double
    Protected MustOverride Function G1(LocZ As ClsNTupel) As Double
    Protected MustOverride Function F2(LocZ As ClsNTupel) As Double
    Protected MustOverride Function G2(LocZ As ClsNTupel) As Double


End Class
