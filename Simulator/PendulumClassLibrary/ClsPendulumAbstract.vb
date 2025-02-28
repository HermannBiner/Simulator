'This class is the abstract Pendulum
'and contains parameters, that are needed for all kind of pendulums
'the iteration-Method is "MustOverride"

'Status Checked

Public MustInherit Class ClsPendulumAbstract
    Implements IPendulum

    Protected ReadOnly LM As ClsLanguageManager

    Protected MyIsMainDS As Boolean
    Protected MyColor As Brush

    'The actual position of the Pendulum is drawn into this PictureBox
    'and shown by the Refresh-Method
    Protected MyPicDiagram As PictureBox
    Protected MyPicGraphics As ClsGraphicTool

    'The permanent Track of the Pendulum is drawn into the BitMap
    Protected MyBmpDiagram As Bitmap
    Protected MyBmpGraphics As ClsGraphicTool

    'The Pendulum draws as well into the Phase Portrait
    Protected MyPicPhaseportrait As PictureBox
    Protected MyPicPhaseportraitGraphics As ClsGraphicTool

    'Permanent Track in the Phaseportrait
    Protected MyBmpPhaseportrait As Bitmap
    Protected MyBmpPhaseportraitGraphics As ClsGraphicTool

    'PhasePortrait
    Protected Enum TypeofPhaseportraitEnum
        Independent 'Both Pendulums are shown independently
        TorusOrCylinder 'Phi1, Phi2 are shown on a torus or Cylinder
        PoincareSection 'see math. doc.
    End Enum

    'The selected PhasePortrait
    Protected TypeofPhasePortrait As TypeofPhaseportraitEnum

    'Labeling
    Protected MyLabelPhasePortrait As String
    Protected MyLabelProtocol As String

    'Status Parameters 
    Protected MyProtocol As ListBox
    Protected MyIsProtocol As Boolean

    Protected MathInterval As ClsInterval

    'For Visibility, the MathInterval is a little bit shrinked
    Protected ShrinkedInterval As ClsInterval
    Protected Const ShrinkFactor As Decimal = CDec(0.95)

    Protected MyAdditionalParameter As ClsGeneralParameter
    Protected MyAdditionalParameterValue As Integer

    'Parameters for the Iteration
    Protected MyIterationStatus As ClsDynamics.EnIterationStatus
    Protected MyValueParameterDefinition As List(Of ClsGeneralParameter)
    Protected MyCalculationConstants As ClsNTupel
    Protected MyCalculationVariables As ClsNTupel

    'Internal step Width
    Protected d As Decimal
    Protected MyLblStepWidth As Label

    'Y-Coordinate of the X-Axis
    Protected Y0 As Decimal

    Protected MathHelper As ClsMathHelperPendulum

    'Startpositions
    Protected MyIsStartParameter1Set As Boolean
    Protected MyIsStartParameter2Set As Boolean

    'Positions of the pendulums
    Protected ReadOnly Position1 As ClsMathpoint
    Protected ReadOnly Position2 As ClsMathpoint
    Protected ReadOnly OldPosition1 As ClsMathpoint
    Protected ReadOnly OldPosition2 As ClsMathpoint

    'Runge Kutta Parameters
    Protected u1 As Decimal
    Protected v1 As Decimal
    Protected u2 As Decimal
    Protected v2 As Decimal

    'For Poincaré Sections
    Protected IsSignumChanged As Boolean

    'And their definition range
    Protected UInterval As ClsInterval
    Protected VInterval As ClsInterval

    'And additional Parameters for Runge Kutta
    Protected ReadOnly x As ClsNTupel
    Protected ReadOnly k1 As ClsNTupel
    Protected ReadOnly h1 As ClsNTupel
    Protected ReadOnly k2 As ClsNTupel
    Protected ReadOnly h2 As ClsNTupel

    'Global Constants
    Protected Const StepWidthUnit As Decimal = CDec(0.0005)

    'Gravitation acceleration
    Protected Const g As Decimal = CDec(9.81)

    'StartEnergyRange
    Protected MyStartEnergyRange As ClsInterval

    WriteOnly Property PicDiagram As PictureBox Implements IPendulum.PicDiagram
        Set(value As PictureBox)
            MyPicDiagram = value

            If MyIsMainDS Then
                'MyPicDiagram should be a square
                Dim Squareside As Integer = Math.Min(MyPicDiagram.Width, MyPicDiagram.Height)
                MyPicDiagram.Width = Squareside
                MyPicDiagram.Height = Squareside

                MyBmpDiagram = New Bitmap(Squareside, Squareside)

                'The Bitmap MapPendulum is then shown as Image of PicPendulum
                MyPicDiagram.Image = MyBmpDiagram

                'Graphics
                'The MathInterval is the same for X and Y
                MyPicGraphics = New ClsGraphicTool(MyPicDiagram, MathInterval, MathInterval)
                MyBmpGraphics = New ClsGraphicTool(MyBmpDiagram, MathInterval, MathInterval)
            End If
        End Set
    End Property

    WriteOnly Property PendulumColor As Brush Implements IPendulum.PendulumColor
        Set(value As Brush)
            MyColor = value
        End Set
    End Property

    Property PicGraphics As ClsGraphicTool Implements IPendulum.PicGraphics
        Get
            PicGraphics = MyPicGraphics
        End Get
        Set(value As ClsGraphicTool)
            MyPicGraphics = value
        End Set
    End Property

    Property BmpDiagram As Bitmap Implements IPendulum.BmpDiagram
        Get
            BmpDiagram = MyBmpDiagram
        End Get
        Set(value As Bitmap)
            MyBmpDiagram = BmpDiagram
        End Set
    End Property

    Property BmpGraphics As ClsGraphicTool Implements IPendulum.BmpGraphics
        Get
            BmpGraphics = MyBmpGraphics
        End Get
        Set(value As ClsGraphicTool)
            MyBmpGraphics = value
        End Set
    End Property

    WriteOnly Property PicPhaseportrait As PictureBox Implements IPendulum.PicPhaseportrait
        Set(value As PictureBox)
            MyPicPhaseportrait = value

            If MyIsMainDS Then
                'MyPicPhasePortrait should be a square
                Dim Squareside As Integer = Math.Min(MyPicPhaseportrait.Width, MyPicPhaseportrait.Height)
                MyPicPhaseportrait.Width = Squareside
                MyPicPhaseportrait.Height = Squareside
                MyPicPhaseportraitGraphics = New ClsGraphicTool(MyPicPhaseportrait, MathInterval, MathInterval)

                MyBmpPhaseportrait = New Bitmap(Squareside, Squareside)
                MyPicPhaseportrait.Image = MyBmpPhaseportrait
                MyBmpPhaseportraitGraphics = New ClsGraphicTool(MyBmpPhaseportrait, MathInterval, MathInterval)
            End If
        End Set
    End Property

    Property PicPhasePortraitGraphics As ClsGraphicTool Implements IPendulum.PicPhasePortraitGraphics
        Get
            PicPhasePortraitGraphics = MyPicPhaseportraitGraphics
        End Get
        Set(value As ClsGraphicTool)
            MyPicPhaseportraitGraphics = value
        End Set
    End Property

    Property BmpPhasePortrait As Bitmap Implements IPendulum.BmpPhasePortrait
        Get
            BmpPhasePortrait = MyBmpPhaseportrait
        End Get
        Set(value As Bitmap)
            MyBmpPhaseportrait = value
        End Set
    End Property

    Property BmpPhasePortraitGraphics As ClsGraphicTool Implements IPendulum.BmpPhasePortraitGraphics
        Get
            BmpPhasePortraitGraphics = MyBmpPhaseportraitGraphics
        End Get
        Set(value As ClsGraphicTool)
            MyBmpPhaseportraitGraphics = value
        End Set
    End Property

    WriteOnly Property PhaseportraitIndex As Integer Implements IPendulum.PhaseportraitIndex
        Set(value As Integer)

            Dim PhaPorTypes As Array = [Enum].GetValues(GetType(TypeofPhaseportraitEnum))
            TypeofPhasePortrait = CType(PhaPorTypes.GetValue(value), TypeofPhaseportraitEnum)

            'just to label the PhasePortrait Parameters
            SetPhasePortraitParameters()

            MyPicPhaseportraitGraphics = New ClsGraphicTool(MyPicPhaseportrait, UInterval, VInterval)
            MyBmpPhaseportraitGraphics = New ClsGraphicTool(MyBmpPhaseportrait, UInterval, VInterval)
        End Set
    End Property

    ReadOnly Property LabelPhasePortrait As String Implements IPendulum.LabelPhasePortrait
        Get
            LabelPhasePortrait = MyLabelPhasePortrait
        End Get
    End Property

    ReadOnly Property LabelProtocol As String Implements IPendulum.LabelProtocol
        Get
            LabelProtocol = MyLabelProtocol
        End Get
    End Property

    WriteOnly Property IsProtocol As Boolean Implements IPendulum.IsProtocol
        Set(value As Boolean)
            MyIsProtocol = value
        End Set
    End Property
    WriteOnly Property LblStepWidth As Label Implements IPendulum.LblStepWidth
        Set(value As Label)
            MyLblStepWidth = value
        End Set
    End Property

    WriteOnly Property Protocol As ListBox Implements IPendulum.Protocol
        Set(value As ListBox)
            MyProtocol = value
        End Set
    End Property

    ReadOnly Property AdditionalParameter As ClsGeneralParameter Implements IPendulum.AdditionalParameter
        Get
            AdditionalParameter = MyAdditionalParameter
        End Get
    End Property

    Property AdditionalParameterValue As Integer Implements IPendulum.AdditionalParameterValue
        Get
            AdditionalParameterValue = MyAdditionalParameterValue
        End Get
        Set(value As Integer)
            MyAdditionalParameterValue = value
        End Set
    End Property

    Property IsMainDS As Boolean Implements IPendulum.IsMainDS
        Get
            IsMainDS = MyIsMainDS
        End Get
        Set(value As Boolean)
            MyIsMainDS = value
        End Set
    End Property

    ReadOnly Property ValueParameterDefinition As List(Of ClsGeneralParameter) Implements IPendulum.ValueParameterDefinition
        Get
            ValueParameterDefinition = MyValueParameterDefinition
        End Get
    End Property

    ReadOnly Property StartEnergyRange As ClsInterval Implements IPendulum.StartEnergyRange
        Get
            StartEnergyRange = MyStartEnergyRange
        End Get
    End Property

    Property CalculationConstants As ClsNTupel Implements IPendulum.CalculationConstants
        Set(value As ClsNTupel)

            'Calculation Constants are not changeable while the Iteration
            'Some Pendulums don't use CalculationConstants
            If MyCalculationConstants IsNot Nothing Then
                Dim i As Integer
                For i = 0 To MyCalculationConstants.Dimension
                    MyCalculationConstants.Component(i) = value.Component(i)
                    SetPosition()
                Next
            End If
        End Set
        Get
            If MyCalculationConstants IsNot Nothing Then
                CalculationConstants = New ClsNTupel(MyCalculationConstants.Dimension)
                For i = 0 To MyCalculationConstants.Dimension
                    CalculationConstants.Component(i) = MyCalculationConstants.Component(i)
                Next
            Else
                CalculationConstants = Nothing
            End If
        End Get
    End Property

    Property CalculationVariables As ClsNTupel Implements IPendulum.CalculationVariables
        Set(value As ClsNTupel)

            'CalculationVariables are changing while the Iteration
            'For our pendulums, the number of variables is fixed: 2
            'if this changes, the whole Runge Kutta Method has to be redesigned
            With MyCalculationVariables
                .Component(0) = value.Component(0)
                .Component(1) = value.Component(1)
                u1 = .Component(0)
                v1 = 0
                u2 = .Component(1)
                v2 = 0
            End With
            SetPosition()
        End Set
        Get
            CalculationVariables = New ClsNTupel(1)
            With CalculationVariables
                .Component(0) = MyCalculationVariables.Component(0)
                .Component(1) = MyCalculationVariables.Component(1)
            End With
        End Get
    End Property

    Property IsStartparameter1Set As Boolean Implements IPendulum.IsStartparameter1Set

        'Has the user the first Startparameter set by the mouse?
        Get
            IsStartparameter1Set = MyIsStartParameter1Set
        End Get
        Set(value As Boolean)
            MyIsStartParameter1Set = value
        End Set
    End Property

    Property IsStartparameter2Set As Boolean Implements IPendulum.IsStartparameter2Set

        'Has the user the second Startparameter set by the mouse?
        Get
            IsStartparameter2Set = MyIsStartParameter2Set
        End Get
        Set(value As Boolean)
            MyIsStartParameter2Set = value
        End Set
    End Property

    WriteOnly Property StepWidth As Integer Implements IPendulum.StepWidth

        'StepWidth of Runge Kutta
        Set(value As Integer)
            d = value *StepWidthUnit
            If MyIsMainDS Then
                MyLblStepWidth.Text = LM.GetString("StepWidth") & ": " & d.ToString
            End If
        End Set
    End Property

    Public Sub New()

        LM = ClsLanguageManager.LM

        'Because PicDiagram and BmpDiagram are squares
        'MathXInterval = MathYInterval =: MathInterval
        'a square also
        MathInterval = New ClsInterval(-1, 1)
        ShrinkedInterval = New ClsInterval(MathInterval.A * ShrinkFactor, MathInterval.B * ShrinkFactor)

        MathHelper = New ClsMathHelperPendulum

        'To perform the iteration
        'Positions of the pendulums
        Position1 = New ClsMathpoint
        Position2 = New ClsMathpoint
        OldPosition1 = New ClsMathpoint
        OldPosition2 = New ClsMathpoint

        'Runge Kutta Parameters
        x = New ClsNTupel(3)
        k1 = New ClsNTupel(3)
        h1 = New ClsNTupel(3)
        k2 = New ClsNTupel(3)
        h2 = New ClsNTupel(3)

    End Sub

    Public Sub ResetIteration() Implements IPendulum.ResetIteration

        If MyIsMainDS Then
            MyProtocol.Items.Clear()

            MyBmpGraphics.Clear(Color.White)
            MyBmpPhaseportraitGraphics.Clear(Color.White)

            MyPicDiagram.Refresh()
            MyPicPhaseportrait.Refresh()

            PrepareDiagram()

            MyIterationStatus = ClsDynamics.EnIterationStatus.Stopped

            MyIsStartParameter1Set = False
            MyIsStartParameter2Set = False
        End If

    End Sub

    Public Function GetTypesofPhaseportrait() As List(Of String) Implements IPendulum.GetTypesofPhaseportrait
        Return [Enum].GetNames(GetType(TypeofPhaseportraitEnum)).ToList
    End Function

    Public Sub PrepareDiagram() Implements IPendulum.PrepareDiagram
        If MyIsMainDS Then
            DrawCoordinateSystem()
            DrawPendulum()
        End If
    End Sub

    Protected Sub ProtocolValues()
        If MyIsMainDS Then
            'For debugging e.g.
            If MyIsProtocol Then
                MyProtocol.Items.Add(u1.ToString("N11") & ", " & v1.ToString("N11") & ", " &
            u2.ToString("N11") & ", " & v2.ToString("N11") & ", " &
                                         GetEnergy.ToString("N11"))
            End If
        End If
    End Sub

    Public MustOverride Function GetAddParameterValue(TbrValue As Integer) As Decimal _
        Implements IPendulum.GetAddParameterValue
    Public MustOverride Sub SetAndDrawStartparameter1(Mouseposition As Point) _
        Implements IPendulum.SetAndDrawStartparameter1
    Public MustOverride Sub SetAndDrawStartparameter2(Mouseposition As Point) _
        Implements IPendulum.SetAndDrawStartparameter2

    Public MustOverride Sub IterationStep(IsTestMode As Boolean) Implements IPendulum.IterationStep

    Protected MustOverride Sub DrawPendulum()
    Protected MustOverride Sub SetPosition()

    Protected MustOverride Sub SetStartEnergyRange()
    Protected MustOverride Sub SetPhasePortraitParameters()
    Protected MustOverride Sub SetAdditionalParameters() Implements IPendulum.SetAdditionalParameters

    Protected MustOverride Function GetEnergy() As Decimal Implements IPendulum.GetEnergy

    Protected MustOverride Sub SetDefaultUserData() Implements IPendulum.SetDefaultUserData
    Protected MustOverride Sub DrawCoordinateSystem()

    Public MustOverride Function GetCopy() As IPendulum Implements IPendulum.GetCopy

End Class
