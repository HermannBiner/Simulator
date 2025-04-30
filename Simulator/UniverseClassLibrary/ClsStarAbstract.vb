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
    Protected MyOriginalMass As Decimal
    Protected MyUserMass As Decimal

    'Positions
    Protected MyOriginalStartPosition As ClsVector
    Protected MyUserStartPosition As ClsVector
    Protected MyActualPosition As ClsVector

    'Calculated during the movement
    Protected NewPosition As ClsVector

    'Velocities
    Protected MyOriginalStartVelocity As ClsVector
    Protected MyUserStartVelocity As ClsVector
    Protected MyActualVelocity As ClsVector
    'needed when calcuating the pulse as vector
    Protected ActualPulse As ClsVector

    'To calculate the gravity point
    Protected MyTotalMassOfOtherStars As Decimal

    'Other
    Protected MyStarColor As Brush
    Protected MyName As String
    Protected MySize As Integer

    'Iteration
    Protected MyActualStepWidth As Decimal
    Protected MyProposedStepWidth As Decimal

    'Runge Kutta Parameters
    Protected u1 As Decimal 'Position.X
    Protected v1 As Decimal 'Velocity.X
    Protected u2 As Decimal 'Position.Y
    Protected v2 As Decimal 'Velocity.Y

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

    Property OriginalMass As Decimal Implements IStar.OriginalMass
        Get
            OriginalMass = MyOriginalMass
        End Get
        Set(value As Decimal)
            MyOriginalMass = value
        End Set
    End Property

    Property UserMass As Decimal Implements IStar.UserMass
        Get
            UserMass = MyUserMass
        End Get
        Set(value As Decimal)
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

    Property ProposedStepWidth As Decimal Implements IStar.ProposedStepWidth
        Get
            ProposedStepWidth = MyProposedStepWidth
        End Get
        Set(value As Decimal)
            MyProposedStepWidth = value
        End Set
    End Property

    Property ActualStepWidth As Decimal Implements IStar.ActualStepWidth
        Get
            ActualStepWidth = MyActualStepWidth
        End Get
        Set(value As Decimal)
            MyActualStepWidth = value
        End Set
    End Property

    Property TotalMassOfOtherStars As Decimal Implements IStar.TotalMassOfOtherStars
        Get
            TotalMassOfOtherStars = MyTotalMassOfOtherStars
        End Get
        Set(value As Decimal)
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

        MyBmpGraphics.DrawLine(NewMathPointPosition, ActualMathPointPosition, MyStarColor, 1)

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
        MyActualStepWidth = CDec(MyProposedStepWidth)
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

    Public Sub IterationStep(IsPhasePortrait As Boolean) Implements IStar.IterationStep

        'Performs one iteration step
        'and does all drawings
        'all startparameters are already set
        'that is Position1 and Position2
        'and Runge Kutta u1, v1, u2, v2

        'See math. doc. for the Details of this Implementation

        'Calculate the new position
        'u1, u2, v1, v2 are already set
        'when starting the iteration

        MyActualVelocity.X = v1
        MyActualVelocity.Y = v2

        'the new actual position is set for all stars
        'to the new position
        'at the same time when all of them have finished
        'the iterationstep

        'Set z1n, n is the nth iterationstep
        With z
            .Component(0) = u1
            .Component(1) = v1
            .Component(2) = u2
            .Component(3) = v2
        End With

        'First Runge Kutta Step
        'k1: belongs to u1' and F1
        'k2: belongs to u2' and F2
        'h1: belongs to v1' abd G1
        'h2: belongs to v2' and G2
        'k,h.component(i): step i-1 in Runge Kutta
        k1.Component(0) = F1(z) ' z.Component(1)
        k2.Component(0) = F2(z) ' z.Component(3)
        h1.Component(0) = G1(z)
        h2.Component(0) = G2(z)

        'Set z2n
        With z
            .Component(0) = u1 + MyActualStepWidth * k1.Component(0) / 2
            .Component(1) = v1 + MyActualStepWidth * h1.Component(0) / 2
            .Component(2) = u2 + MyActualStepWidth * k2.Component(0) / 2
            .Component(3) = v2 + MyActualStepWidth * h2.Component(0) / 2
        End With

        'Second Runge Kutta Step
        k1.Component(1) = F1(z) ' z.Component(1)
        k2.Component(1) = F2(z) ' z.Component(3)
        h1.Component(1) = G1(z)
        h2.Component(1) = G2(z)

        'Set x3n
        With z
            .Component(0) = u1 + MyActualStepWidth * k1.Component(1) / 2
            .Component(1) = v1 + MyActualStepWidth * h1.Component(1) / 2
            .Component(2) = u2 + MyActualStepWidth * k2.Component(1) / 2
            .Component(3) = v2 + MyActualStepWidth * h2.Component(1) / 2
        End With

        'Third Runge Kutta Step
        k1.Component(2) = F1(z) ' z.Component(1)
        k2.Component(2) = F2(z) ' z.Component(3)
        h1.Component(2) = G1(z)
        h2.Component(2) = G2(z)

        'Set x4n
        With z
            .Component(0) = u1 + MyActualStepWidth * k1.Component(2)
            .Component(1) = v1 + MyActualStepWidth * h1.Component(2)
            .Component(2) = u2 + MyActualStepWidth * k2.Component(2)
            .Component(3) = v2 + MyActualStepWidth * h2.Component(2)
        End With

        'Fourth Runge Kutta Step
        k1.Component(3) = F1(z) ' z.Component(1)
        k2.Component(3) = F2(z) ' z.Component(3)
        h1.Component(3) = G1(z)
        h2.Component(3) = G2(z)

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
        PhasePortraitPoint.X = CDec(Math.Sqrt(u1 * u1 + u2 * u2)) * MyUniverse.DiagramZoom  'rho
        PhasePortraitPoint.Y = CDec(Math.Sqrt(v1 * v1 + v2 * v2)) * MyUniverse.VFactor 'vAbs
        PicPhasePortraitGraphics.DrawPoint(PhasePortraitPoint, MyStarColor, 1)

    End Sub

    Public Function GetAngularMomentum() As Decimal Implements IStar.GetAngularMomentum
        Return MyUserMass * (u1 * v2 - u2 * v1)
    End Function

    Public Function GetPulse() As ClsVector Implements IStar.GetPulse
        ActualPulse.X = CDec(MyUserMass * MyActualVelocity.X)
        ActualPulse.Y = CDec(MyUserMass * MyActualVelocity.Y)
        Return ActualPulse
    End Function

    'the following is depending of the type of the universe
    'and the force law between stars

    Public MustOverride Sub DrawOrbit(IsDefinitive As Boolean) Implements IStar.DrawOrbit

    Public MustOverride Function GetEnergy() As Decimal Implements IStar.GetEnergy

    Protected MustOverride Function F1(LocZ As ClsNTupel) As Decimal
    Protected MustOverride Function G1(LocZ As ClsNTupel) As Decimal
    Protected MustOverride Function F2(LocZ As ClsNTupel) As Decimal
    Protected MustOverride Function G2(LocZ As ClsNTupel) As Decimal


End Class
