'This class is the abstract Pendulum
'and contains parameters, that are needed for all kind of pendulums
'the iteration-Method is "MustOverride"

'Status Checked

Public MustInherit Class ClsPendulumAbstract
    Implements IPendulum

    'The actual position of the Pendulum is drawn into this PictureBox
    'and shown by the Refresh-Method
    Protected MyPicDiagram As PictureBox
    Protected PicGraphics As ClsGraphicTool

    'The permanent Track of the Pendulum is drawn into the BitMap
    Protected BmpDiagram As Bitmap
    Protected BmpGraphics As ClsGraphicTool

    'The Pendulum draws as well into the Phase Portrait
    Protected MyPicPhaseportrait As PictureBox
    Protected PicPhaseportraitGraphics As ClsGraphicTool

    'Permanent Track in the Phaseportrait
    Protected BmpPhaseportrait As Bitmap
    Protected BmpPhaseportraitGraphics As ClsGraphicTool

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

    'MyEnergy
    Protected MyPicEnergy As PictureBox
    Protected PicEnergyGraphics As Graphics
    Protected EnergyRange As ClsInterval
    Protected StartEnergy As Decimal
    Protected Energy As Decimal

    Protected MathInterval As ClsInterval

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
    Protected SignumChanged As Boolean

    'And their definition range
    Protected UInterval As ClsInterval
    Protected VInterval As ClsInterval

    'And additional Parameters for Runge Kutta
    Protected ReadOnly x As ClsNTupel
    Protected ReadOnly k1 As ClsNTupel
    Protected ReadOnly h1 As ClsNTupel
    Protected ReadOnly k2 As ClsNTupel
    Protected ReadOnly h2 As ClsNTupel

    'Number of Steps
    Protected N As Integer
    Protected MyLblN As Label

    'Global Constants
    Protected Const EnergyTolerance As Decimal = CDec(0.1)
    Protected Const StepWidthUnit As Decimal = CDec(0.0001)

    'Gravitation acceleration
    Protected Const g As Decimal = CDec(9.81)

    WriteOnly Property PicDiagram As PictureBox Implements IPendulum.PicDiagram
        Set(value As PictureBox)
            MyPicDiagram = value

            'MyPicDiagram should be a square
            Dim Squareside As Integer = Math.Min(MyPicDiagram.Width, MyPicDiagram.Height)
            MyPicDiagram.Width = Squareside
            MyPicDiagram.Height = Squareside

            BmpDiagram = New Bitmap(Squareside, Squareside)

            'The Bitmap MapPendulum is then shown as Image of PicPendulum
            MyPicDiagram.Image = BmpDiagram

            'Graphics
            'The MathInterval is the same for X and Y
            PicGraphics = New ClsGraphicTool(MyPicDiagram, MathInterval, MathInterval)
            BmpGraphics = New ClsGraphicTool(BmpDiagram, MathInterval, MathInterval)

        End Set
    End Property

    WriteOnly Property PicPhaseportrait As PictureBox Implements IPendulum.PicPhaseportrait
        Set(value As PictureBox)
            MyPicPhaseportrait = value

            'MyPicPhasePortrait should be a square
            Dim Squareside As Integer = Math.Min(MyPicPhaseportrait.Width, MyPicPhaseportrait.Height)
            MyPicPhaseportrait.Width = Squareside
            MyPicPhaseportrait.Height = Squareside
            PicPhaseportraitGraphics = New ClsGraphicTool(MyPicPhaseportrait, MathInterval, MathInterval)

            BmpPhaseportrait = New Bitmap(Squareside, Squareside)
            MyPicPhaseportrait.Image = BmpPhaseportrait
            BmpPhaseportraitGraphics = New ClsGraphicTool(BmpPhaseportrait, MathInterval, MathInterval)
        End Set
    End Property

    WriteOnly Property PhaseportraitIndex As Integer Implements IPendulum.PhaseportraitIndex
        Set(value As Integer)

            Dim PhaPorTypes As Array = [Enum].GetValues(GetType(TypeofPhaseportraitEnum))
            TypeofPhasePortrait = CType(PhaPorTypes.GetValue(value), TypeofPhaseportraitEnum)

            'just to label the PhasePortrait Parameters
            SetPhasePortraitParameters()

            PicPhaseportraitGraphics = New ClsGraphicTool(MyPicPhaseportrait, UInterval, VInterval)
            BmpPhaseportraitGraphics = New ClsGraphicTool(BmpPhaseportrait, UInterval, VInterval)
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

    WriteOnly Property PicEnergy As PictureBox Implements IPendulum.PicEnergy
        Set(value As PictureBox)
            MyPicEnergy = value
            PicEnergyGraphics = MyPicEnergy.CreateGraphics
        End Set
    End Property

    ReadOnly Property AdditionalParameter As ClsGeneralParameter Implements IPendulum.AdditionalParameter
        Get
            AdditionalParameter = MyAdditionalParameter
        End Get
    End Property

    WriteOnly Property AdditionalParameterValue As Integer Implements IPendulum.AdditionalParameterValue
        Set(value As Integer)
            MyAdditionalParameterValue = value
            SetAdditionalParameters()
            PrepareDiagram()
        End Set
    End Property

    Property IterationStatus As ClsDynamics.EnIterationStatus Implements IPendulum.IterationStatus
        Get
            IterationStatus = MyIterationStatus
        End Get
        Set(value As ClsDynamics.EnIterationStatus)
            MyIterationStatus = value
        End Set
    End Property

    ReadOnly Property ValueParameterDefinition As List(Of ClsGeneralParameter) Implements IPendulum.ValueParameterDefinition
        Get
            ValueParameterDefinition = MyValueParameterDefinition
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
            d = value * StepWidthUnit
            MyLblStepWidth.Text = FrmMain.LM.GetString("StepWidth") & ": " & d.ToString
        End Set
    End Property

    WriteOnly Property LblN As Label Implements IPendulum.LblN

        'Label in the form that shows the Number of Iterationsteps
        Set(value As Label)
            MyLblN = value
        End Set
    End Property

    Public Sub New()

        MathInterval = New ClsInterval(-1, 1)
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

        N = 0
        MyLblN.Text = "0"
        StartEnergy = 0
        MyProtocol.Items.Clear()

        BmpGraphics.Clear(Color.White)
        BmpPhaseportraitGraphics.Clear(Color.White)

        MyPicDiagram.Refresh()
        MyPicPhaseportrait.Refresh()

        PrepareDiagram()

        MyIterationStatus = ClsDynamics.EnIterationStatus.Stopped

        MyIsStartParameter1Set = False
        MyIsStartParameter2Set = False

    End Sub

    Public Function GetTypesofPhaseportrait() As List(Of String) Implements IPendulum.GetTypesofPhaseportrait
        Return [Enum].GetNames(GetType(TypeofPhaseportraitEnum)).ToList
    End Function

    Public Sub PrepareDiagram() Implements IPendulum.PrepareDiagram
        DrawCoordinateSystem()
        DrawPendulums()
    End Sub

    Protected Sub ProtocolValues()

        'For debugging e.g.
        MyProtocol.Items.Add(u1.ToString("N11") & ", " & v1.ToString("N11") & ", " &
            u2.ToString("N11") & ", " & v2.ToString("N11") & ", " &
                                     GetEnergy.ToString("N11"))
    End Sub

    Public Async Function IterationLoop(Testmode As Boolean) As Task Implements IPendulum.IterationLoop

        'This is the main Iteraion Loop
        Dim ActualEnergy As Decimal
        Dim MyBrush As Brush
        Dim Value As Integer

        Do
            N += 1

            'Testmode for Debugging possible
            IterationStep(Testmode)

            'Controlling the Energy Range
            ActualEnergy = GetEnergy()

            Select Case True
                Case ActualEnergy > StartEnergy + EnergyTolerance * EnergyRange.IntervalWidth
                    MyBrush = Brushes.Red
                Case ActualEnergy < StartEnergy - EnergyTolerance * EnergyRange.IntervalWidth
                    MyBrush = Brushes.DarkViolet
                Case Else
                    MyBrush = Brushes.Green
            End Select

            MyPicEnergy.Refresh()

            'Set the StatusBar of the Energy
            Value = CInt(Math.Min(MyPicEnergy.Width, (ActualEnergy - EnergyRange.A) * MyPicEnergy.Width / EnergyRange.IntervalWidth))
            PicEnergyGraphics.FillRectangle(MyBrush, New Rectangle(0, 0, Value, MyPicEnergy.Height))

            If N Mod 100 = 0 Then

                MyLblN.Text = N.ToString

                Await Task.Delay(2)
            End If

        Loop Until MyIterationStatus = ClsDynamics.EnIterationStatus.Interrupted _
            Or MyIterationStatus = ClsDynamics.EnIterationStatus.Stopped

    End Function

    Public MustOverride Function GetAddParameterValue(TbrValue As Integer) As Decimal Implements IPendulum.GetAddParameterValue
    'OK

    Public MustOverride Sub SetAndDrawStartparameter1(Mouseposition As Point) Implements IPendulum.SetAndDrawStartparameter1
    'OK

    Public MustOverride Sub SetAndDrawStartparameter2(Mouseposition As Point) Implements IPendulum.SetAndDrawStartparameter2
    'OK

    Protected MustOverride Sub IterationStep(TestMode As Boolean)

    Protected MustOverride Sub DrawPendulums()
    'OK

    Protected MustOverride Sub SetPosition()
    'OK

    Protected MustOverride Sub SetEnergyRange()
    'OK

    Protected MustOverride Sub SetPhasePortraitParameters()
    'OK

    Protected MustOverride Sub SetAdditionalParameters()
    'OK

    Protected MustOverride Function GetEnergy() As Decimal
    'OK

    Protected MustOverride Sub SetDefaultUserData() Implements IPendulum.SetDefaultUserData
    'OK

    Protected MustOverride Sub DrawCoordinateSystem()
    'OK

End Class
