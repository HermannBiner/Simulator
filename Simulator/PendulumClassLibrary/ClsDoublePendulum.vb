'This class contains all properties and methods for the double pendulum
'See mathematical documentation

'important: this class works with mathematical coordinates
'the Instance of the GraphicTool transforms these in Pixel-Coordinates

'Attention: Runge Kutta is NOT representing a real Double Pendulum!!

'Status Checked

Public Class ClsDoublePendulum
    Implements IPendulum

    'The actual position of the Pendulum is drawn into this PictureBox
    'and shown by the Refresh-Method
    Private MyPicPendulum As PictureBox
    Private MyPicPendulumGraphics As ClsGraphicTool

    'The permanent Track of the Pendulum is drawn into the BitMap
    Private MyMapPendulum As Bitmap
    Private MyMapPendulumGraphics As ClsGraphicTool

    'The Pendulum draws as well into the Phase Portrait
    Private MyPicPhaseportrait As PictureBox
    Private MyPicPhaseportraitGraphics As ClsGraphicTool

    'Permanent Track in the Phaseportrait
    Private MyMapPhaseportrait As Bitmap
    Private MyMapPhaseportraitGraphics As ClsGraphicTool

    'Labeling
    Private MyPhaseportraitLabel As String
    Private ReadOnly MyLabelParameterC As String

    Private MyPhaseportraitType As TypeofPhaseportraitEnum

    Private ReadOnly MyAdditionalParameter As ClsValueParameter
    Private MyAdditionalParameterValue As Integer

    'and protocols its Parametervalues into a ListBox
    Private MyParameterlistbox As ListBox

    'Calculations
    Private ReadOnly MyMathhelper As ClsMathHelperPendulum

    'Factor C for the C-Diagram
    'this will be the Startenergy of the Double Pendulum
    Private MyC As Decimal

    'Mass ratio M: m2 = MyM*m1
    Private MyM As Decimal

    'and ratio Mu: Mu = MyM/(1+MyM)
    Private Mu As Decimal

    'Collection of the two ValueRanges for the C-Diagram
    Private ReadOnly MyValueParameters As List(Of ClsValueParameter)

    'The Value Range of the Mathematical Coordinates - Standard is the Interval [-1,1]
    'and the Coordinate System as Square [-1,1] x [-1,1]
    Private ReadOnly MyMathValuerange As ClsInterval

    'The Interval in whitch the Startenergy of the Pendulum can be
    Private MyStartenergyRange As ClsInterval

    'Constant parameters
    Private ReadOnly MyConstants As ClsVector

    'Variable parameters
    Private ReadOnly MyVariables As ClsVector

    'Size of Pendulums
    Private ReadOnly MyPendulumSize As ClsVector

    'Startparameter1 is Phi1
    Private MyIsStartparameter1Set As Boolean

    'Startparameter2 is Phi2
    Private MyIsStartparameter2Set As Boolean

    'To perform the iteration
    'Positions of the pendulums
    Private ReadOnly Position1 As ClsMathpoint
    Private ReadOnly Position2 As ClsMathpoint
    Private ReadOnly OldPosition1 As ClsMathpoint
    Private ReadOnly OldPosition2 As ClsMathpoint

    'Runge Kutta Parameters
    Private u1 As Decimal
    Private v1 As Decimal
    Private u2 As Decimal
    Private v2 As Decimal

    'For Poincaré Sections
    Private SignumChanged As Boolean

    'And their definition range
    Private UInterval As ClsInterval
    Private VInterval As ClsInterval

    'And additional Parameters for Runge Kutta
    Private ReadOnly x As ClsVector
    Private ReadOnly k1 As ClsVector
    Private ReadOnly h1 As ClsVector
    Private ReadOnly k2 As ClsVector
    Private ReadOnly h2 As ClsVector

    'Step Width
    Private d As Decimal

    Private IsTestMode As Boolean

    Private Enum TypeofPhaseportraitEnum
        Independent 'Both Pendulums are shown independently
        Torus 'Phi1, Phi2 are shown on a torus
        PoincareSection 'see math. doc.
    End Enum

    'Gravitation acceleration
    Const g As Decimal = CDec(9.81)

    'Level of the x-Axis in the Diagram as math. y-Coordinate
    Const MyY0 As Decimal = 0

    'SECTOR INITIALIZATION

    Public Sub New()

        MyMathhelper = New ClsMathHelperPendulum

        MyMathValuerange = New ClsInterval(-1, 1)

        MyValueParameters = New List(Of ClsValueParameter)

        Dim ValueParameter(3) As ClsValueParameter

        'Inizialize all parameters
        'Tag is the Number of the Label in the Pendulum Form
        'L1
        ValueParameter(0) = New ClsValueParameter(1, "L1", New ClsInterval(CDec(0.1), CDec(0.85)))
        MyValueParameters.Add(ValueParameter(0))

        'L2
        ValueParameter(1) = New ClsValueParameter(2, "L2", New ClsInterval(CDec(0.1), CDec(0.85)))
        MyValueParameters.Add(ValueParameter(1))

        'Phi1
        ValueParameter(2) = New ClsValueParameter(3, "Phi 1", New ClsInterval(-CDec(Math.PI), CDec(Math.PI)))
        MyValueParameters.Add(ValueParameter(2))

        'Phi2
        ValueParameter(3) = New ClsValueParameter(4, "Phi 2", New ClsInterval(-CDec(Math.PI), CDec(Math.PI)))
        MyValueParameters.Add(ValueParameter(3))

        'Labels
        MyPhaseportraitLabel = FrmMain.LM.GetString("PhasePortrait") & ": -- "
        MyLabelParameterC = FrmMain.LM.GetString("DoublePendulumC")

        'The interval for the Additional Parameter sets the range of the TrackBar AdditionalParameter
        'and the Tag its Value of the Additional PArameter as Standard
        MyAdditionalParameterValue = 2  'that means mass m2 = m1
        MyAdditionalParameter = New ClsValueParameter(MyAdditionalParameterValue,
                                                      FrmMain.LM.GetString("MassRatioM"), New ClsInterval(0, 4))

        'Calculates mass ratio M = m2/m1
        MyM = CalcValuefromTrbAddParameter(MyAdditionalParameterValue)
        Mu = MyM / (1 + MyM)

        'Vectors
        'We have two constant parameters: L1 = .Component(0), L2 = Component(1)
        MyConstants = New ClsVector(1)

        'Standardvalues
        With MyConstants
            .Component(0) = CDec(0.7)  'L1
            .Component(1) = CDec(0.2)  'L2
        End With

        'We have two variable parameters: Phi1 = MyVariables.Components(0), Phi2 = MyVariables.components(1)
        MyVariables = New ClsVector(1)

        'Standardvalues
        With MyVariables
            .Component(0) = CDec(Math.PI / 4) 'Phi1
            u1 = .Component(0)
            v1 = 0
            .Component(1) = CDec(Math.PI / 6) 'Phi2
            u2 = .Component(1)
            v2 = 0
        End With

        SetStartenergyRange()

        'For the Double Pendulum is the Factor C 
        'the Energy
        MyC = GetEnergy()

        'StandardSize
        MyPendulumSize = New ClsVector(1)
        SetPendulumSize()

        'To perform the iteration
        'Positions of the pendulums
        Position1 = New ClsMathpoint
        Position2 = New ClsMathpoint
        OldPosition1 = New ClsMathpoint
        OldPosition2 = New ClsMathpoint

        SetPosition()

        'Runge Kutta Parameters
        x = New ClsVector(3)
        k1 = New ClsVector(3)
        h1 = New ClsVector(3)
        k2 = New ClsVector(3)
        h2 = New ClsVector(3)

    End Sub

    'SECTOR INTERFACE

    WriteOnly Property PicPendulum As PictureBox Implements IPendulum.PicPendulum
        Set(value As PictureBox)
            MyPicPendulum = value
            MyPicPendulumGraphics = New ClsGraphicTool(MyPicPendulum, MyMathValuerange, MyMathValuerange)
        End Set
    End Property

    ReadOnly Property Y0 As Decimal Implements IPendulum.Y0
        Get
            Y0 = MyY0
        End Get
    End Property

    WriteOnly Property MapPendulum As Bitmap Implements IPendulum.MapPendulum
        Set(value As Bitmap)
            MyMapPendulum = value
            MyMapPendulumGraphics = New ClsGraphicTool(MyMapPendulum, MyMathValuerange, MyMathValuerange)
        End Set
    End Property

    WriteOnly Property PicPhaseportrait As PictureBox Implements IPendulum.PicPhaseportrait
        Set(value As PictureBox)
            MyPicPhaseportrait = value
        End Set
    End Property

    WriteOnly Property MapPhaseportrait As Bitmap Implements IPendulum.MapPhaseportrait
        Set(value As Bitmap)
            MyMapPhaseportrait = value
        End Set
    End Property

    ReadOnly Property LabelParameterlist As String Implements IPendulum.LabelParameterList
        Get
            LabelParameterlist = FrmMain.LM.GetString("Parameterlist") & ": u1, v1, u2, v2, Etot"
        End Get
    End Property
    WriteOnly Property ParameterListbox As ListBox Implements IPendulum.ParameterListbox
        Set(value As ListBox)
            MyParameterlistbox = value
        End Set
    End Property

    ReadOnly Property ValueParameters As List(Of ClsValueParameter) Implements IPendulum.ValueParameters
        Get
            ValueParameters = MyValueParameters
        End Get
    End Property

    ReadOnly Property LabelPhasePortrait As String Implements IPendulum.LabelPhasePortrait
        Get
            LabelPhasePortrait = MyPhaseportraitLabel
        End Get
    End Property

    ReadOnly Property AdditionalParameter As ClsValueParameter Implements IPendulum.AdditionalParameter
        Get
            AdditionalParameter = MyAdditionalParameter
        End Get
    End Property

    ReadOnly Property LabelParameterC As String Implements IPendulum.LabelParameterC
        Get
            LabelParameterC = MyLabelParameterC
        End Get
    End Property

    ReadOnly Property C As Decimal Implements IPendulum.C
        Get
            MyC = GetEnergy()
            C = MyC
        End Get
    End Property

    WriteOnly Property AdditionalParameterValue As Integer Implements IPendulum.AdditionalParameterValue
        Set(value As Integer)
            MyAdditionalParameterValue = value
            MyM = CalcValuefromTrbAddParameter(MyAdditionalParameterValue)

            'Factor Mu in Differential Equations
            Mu = MyM / (1 + MyM)
            SetPendulumSize()
            SetStartenergyRange()
        End Set
    End Property

    Property Constants As ClsVector Implements IPendulum.Constants
        Set(value As ClsVector)
            With MyConstants
                .Component(0) = value.Component(0)
                .Component(1) = value.Component(1)
            End With
            SetPosition()
        End Set
        Get
            Constants = New ClsVector(1)
            With Constants
                .Component(0) = MyConstants.Component(0)
                .Component(1) = MyConstants.Component(1)
            End With
        End Get
    End Property

    Property Variables As ClsVector Implements IPendulum.Variables
        Set(value As ClsVector)
            With MyVariables
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
            Variables = New ClsVector(1)
            With Variables
                .Component(0) = MyVariables.Component(0)
                .Component(1) = MyVariables.Component(1)
            End With
        End Get
    End Property

    Public Function GetTypesofPhaseportrait() As List(Of String) Implements IPendulum.GetTypesofPhaseportrait

        Return [Enum].GetNames(GetType(TypeofPhaseportraitEnum)).ToList
    End Function

    WriteOnly Property PhaseportraitIndex As Integer Implements IPendulum.PhaseportraitIndex
        Set(value As Integer)
            Dim PhaPorTypes As Array = [Enum].GetValues(GetType(TypeofPhaseportraitEnum))
            MyPhaseportraitType = CType(PhaPorTypes.GetValue(value), TypeofPhaseportraitEnum)
            'Labeling and preparing UInterval, VInterval and MapPhaseportraitGraphics
            Select Case MyPhaseportraitType
                Case TypeofPhaseportraitEnum.Torus
                    MyPhaseportraitLabel = FrmMain.LM.GetString("PhasePortrait") & ": Phi1, Phi2. Tangent: Phi1', Phi2'"
                    UInterval = New ClsInterval(CDec(-Math.PI), CDec(Math.PI))
                    VInterval = New ClsInterval(CDec(-Math.PI), CDec(Math.PI))
                Case TypeofPhaseportraitEnum.PoincareSection
                    MyPhaseportraitLabel = FrmMain.LM.GetString("PhasePortrait") & ": Phi1 = 0, Phi2, Phi2'"
                    UInterval = New ClsInterval(CDec(-Math.PI), CDec(Math.PI))
                    VInterval = New ClsInterval(CDec(-10), CDec(10))
                Case Else
                    MyPhaseportraitLabel = FrmMain.LM.GetString("PhasePortrait") & ": Red: Phi1, Phi1'. Green: Phi2, Phi2'"
                    UInterval = New ClsInterval(CDec(-Math.PI), CDec(Math.PI))
                    VInterval = New ClsInterval(CDec(-10), CDec(10))
            End Select
            MyPicPhaseportraitGraphics = New ClsGraphicTool(MyPicPhaseportrait, UInterval, VInterval)
            MyMapPhaseportraitGraphics = New ClsGraphicTool(MyMapPhaseportrait, UInterval, VInterval)
        End Set
    End Property

    Property IsStartparameter1Set As Boolean Implements IPendulum.IsStartparameter1Set
        Set(value As Boolean)
            MyIsStartparameter1Set = value
        End Set
        Get
            IsStartparameter1Set = MyIsStartparameter1Set
        End Get
    End Property

    Property IsStartparameter2Set As Boolean Implements IPendulum.IsStartparameter2Set
        Set(value As Boolean)
            MyIsStartparameter2Set = value
        End Set
        Get
            IsStartparameter2Set = MyIsStartparameter2Set
        End Get
    End Property

    WriteOnly Property TestMode As Boolean Implements IPendulum.TestMode
        Set(value As Boolean)
            IsTestMode = value
        End Set
    End Property

    WriteOnly Property StepWidth As Decimal Implements IPendulum.StepWidth
        Set(value As Decimal)
            d = value
        End Set
    End Property

    ReadOnly Property Energy As Decimal Implements IPendulum.Energy
        Get
            Energy = GetEnergy()
        End Get
    End Property

    ReadOnly Property StartEnergyRange As ClsInterval Implements IPendulum.StartEnergyRange
        Get
            StartEnergyRange = MyStartenergyRange
        End Get
    End Property

    'SECTOR CALCULATION AND DRAWING

    Public Function CalcValuefromTrbAddParameter(AddParameter As Integer) As Decimal _
        Implements IPendulum.CalcValuefromTrbAddParameter

        Dim Temp As Decimal = CDec(Math.Pow(2, AddParameter - 2))

        Return Temp

    End Function

    Private Sub DrawCoordinateSystem() Implements IPendulum.DrawCoordinateSystem

        If MyMapPendulumGraphics IsNot Nothing Then

            'x-Axis
            MyMapPendulumGraphics.DrawLine(New ClsMathpoint(-1, MyY0), New ClsMathpoint(1, MyY0), Color.Aquamarine, 1)
            'y-Axis
            MyMapPendulumGraphics.DrawLine(New ClsMathpoint(0, -1), New ClsMathpoint(0, 1), Color.Aquamarine, 1)
        End If

    End Sub

    Public Sub DrawPendulums() Implements IPendulum.DrawPendulums

        With MyPicPendulumGraphics

            'Clear Graphic
            MyPicPendulum.Refresh()

            'First Pendulum
            .DrawLine(New ClsMathpoint(0, 0), Position1, Color.Red, 2)
            .FillCircle(Position1, MyPendulumSize.Component(0), Brushes.Red)

            'Second Pendulum
            .DrawLine(Position1, Position2, Color.Green, 2)
            .FillCircle(Position2, MyPendulumSize.Component(1), Brushes.Green)

        End With

    End Sub

    Sub Reset() Implements IPendulum.Reset

        MyMapPendulumGraphics.Clear(Color.White)
        MyMapPhaseportraitGraphics?.Clear(Color.White)

    End Sub

    'Sets the position of the Pendulums
    Private Sub SetPosition()

        'See math. doc.
        With Position1
            .X = MyConstants.Component(0) * CDec(Math.Sin(MyVariables.Component(0)))
            .Y = -MyConstants.Component(0) * CDec(Math.Cos(MyVariables.Component(0)))
        End With

        With Position2
            .X = Position1.X + MyConstants.Component(1) * CDec(Math.Sin(MyVariables.Component(1)))
            .Y = Position1.Y - MyConstants.Component(1) * CDec(Math.Cos(MyVariables.Component(1)))
        End With

    End Sub

    Private Sub SetStartenergyRange()

        Dim Emin As Decimal
        Dim Emax As Decimal

        'Emin = g*((1-l1)*(1+MyM)-MyM*l2)
        'Emax = g*((1+l1)*(1+MyM)+MyM*l2)
        With Constants
            Emin = g * ((1 - .Component(0)) * (1 + MyM) - MyM * .Component(1))
            Emax = g * ((1 + .Component(0)) * (1 + MyM) + MyM * .Component(1))
        End With
        MyStartenergyRange = New ClsInterval(Emin, Emax)

    End Sub

    Private Sub SetPendulumSize()

        'The smaller Pendulum has about the Size 12 (in Pixels)
        'that is 12/1260 in Math. Coordinates - we set 0.01
        'and m2 = MyM*m1
        With MyPendulumSize
            If MyM >= 1 Then
                .Component(0) = CDec(0.01)
                .Component(1) = MyM * .Component(0)
            Else
                .Component(1) = CDec(0.01)
                .Component(0) = .Component(1) / MyM
            End If
        End With

        MyC = GetEnergy()

    End Sub

    'SECTOR SETSTARTPARAMETER
    Sub SetAndDrawStartparameter1(Mouseposition As Point) Implements IPendulum.SetAndDrawStartparameter1

        Dim ActualPosition As ClsMathpoint = MyPicPendulumGraphics.PixelToMathpoint(Mouseposition)

        With ActualPosition
            'L1 should be maximal 0.8 to reserve some place for L2 and minimal 0.01
            'because of the divisor in the Differential Equation
            Dim LocRange As ClsInterval
            'L1
            LocRange = New ClsInterval(MyValueParameters.Item(0).Range.A, MyValueParameters.Item(0).Range.B)
            Dim L1 As Decimal = CDec(Math.Max(LocRange.A, Math.Min(Math.Sqrt(.X * .X + .Y * .Y), LocRange.B)))

            'L2 standard
            Dim L2 As Decimal = CDec(Math.Min(MyConstants.Component(1), 0.95 - L1))

            'Phi1
            Dim Phi1 As Decimal = MyMathhelper.GetAngle(.X, .Y)

            'Set parameters
            MyConstants.Component(0) = L1
            MyConstants.Component(1) = L2
            MyVariables.Component(0) = MyMathhelper.AngleInMinusPiAndPi(Phi1)
            MyC = GetEnergy()

            SetPosition()

            SetStartenergyRange()

            'Draw pendulum
            DrawPendulums()

            'Runge Kutta
            u1 = Phi1
            v1 = 0

        End With

    End Sub

    Sub SetAndDrawStartparameter2(Mouseposition As Point) Implements IPendulum.SetAndDrawStartparameter2

        Dim ActualPosition As ClsMathpoint = MyPicPendulumGraphics.PixelToMathpoint(Mouseposition)

        With ActualPosition

            Dim DeltaX As Decimal = .X - Position1.X
            Dim DeltaY As Decimal = .Y - Position1.Y

            'L1 + L2 should be maximal 0.95 to be visible and minimal 0.01
            'because of the divisor in the Differential Equation
            Dim LocRange As ClsInterval
            'L2
            LocRange = New ClsInterval(MyValueParameters.Item(1).Range.A, MyValueParameters.Item(1).Range.B)
            Dim L2 As Decimal = CDec(Math.Max(LocRange.A, (Math.Min(Math.Sqrt(DeltaX * DeltaX + DeltaY * DeltaY),
                                                                    0.95 - MyConstants.Component(0)))))
            Dim Phi2 As Decimal = MyMathhelper.GetAngle(DeltaX, DeltaY)

            'Set parameters
            MyConstants.Component(1) = L2
            MyVariables.Component(1) = MyMathhelper.AngleInMinusPiAndPi(Phi2)
            MyC = GetEnergy()

            SetPosition()

            SetStartenergyRange()

            'Draw pendulum
            DrawPendulums()

            'Runge Kutta Parameters
            u2 = Phi2
            v2 = 0

        End With

    End Sub


    'SECTOR ITERATION

    Sub Iteration(TestMode As Boolean) Implements IPendulum.Iteration

        'Performs one iteration step
        'and does all drawings
        'all startparameters are already set
        'that is Position1 and Position2
        'and Runge Kutta u1, v1, u2, v2

        'See math. doc. for the Details of this Implementation

        'Set OldPosition = Position
        With OldPosition1
            .X = Position1.X
            .Y = Position1.Y
        End With

        With OldPosition2
            .X = Position2.X
            .Y = Position2.Y
        End With

        'Protocol Values to List
        ProtocolValues()

        'Set x1n
        With x
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
        k1.Component(0) = F1(x)
        k2.Component(0) = F2(x)
        If TestMode Then
            h1.Component(0) = G1Test(x)
            h2.Component(0) = G2Test(x)
        Else
            h1.Component(0) = G1(x)
            h2.Component(0) = G2(x)
        End If

        'Set x2n
        'd: global Runge Kutta
        With x
            .Component(0) = u1 + d * k1.Component(0) / 2
            .Component(1) = v1 + d * h1.Component(0) / 2
            .Component(2) = u2 + d * k2.Component(0) / 2
            .Component(3) = v2 + d * h2.Component(0) / 2
        End With

        'Second Runge Kutta Step
        k1.Component(1) = F1(x)
        k2.Component(1) = F2(x)
        If TestMode Then
            h1.Component(1) = G1Test(x)
            h2.Component(1) = G2Test(x)
        Else
            h1.Component(1) = G1(x)
            h2.Component(1) = G2(x)
        End If

        'Set x3n
        With x
            .Component(0) = u1 + d * k1.Component(1) / 2
            .Component(1) = v1 + d * h1.Component(1) / 2
            .Component(2) = u2 + d * k2.Component(1) / 2
            .Component(3) = v2 + d * h2.Component(1) / 2
        End With

        'Third Runge Kutta Step
        k1.Component(2) = F1(x)
        k2.Component(2) = F2(x)
        If TestMode Then
            h1.Component(2) = G1Test(x)
            h2.Component(2) = G2Test(x)
        Else
            h1.Component(2) = G1(x)
            h2.Component(2) = G2(x)
        End If

        'Set x4n
        With x
            .Component(0) = u1 + d * k1.Component(2)
            .Component(1) = v1 + d * h1.Component(2)
            .Component(2) = u2 + d * k2.Component(2)
            .Component(3) = v2 + d * h2.Component(2)
        End With

        'Fourth Runge Kutta Step
        k1.Component(3) = F1(x)
        k2.Component(3) = F2(x)
        If TestMode Then
            h1.Component(3) = G1Test(x)
            h2.Component(3) = G2Test(x)
        Else
            h1.Component(3) = G1(x)
            h2.Component(3) = G2(x)
        End If


        'Update u1, v1, u2, v2
        u1 += d * (k1.Component(0) + 2 * k1.Component(1) + 2 * k1.Component(2) + k1.Component(3)) / 6
        v1 += d * (h1.Component(0) + 2 * h1.Component(1) + 2 * h1.Component(2) + h1.Component(3)) / 6
        u2 += d * (k2.Component(0) + 2 * k2.Component(1) + 2 * k2.Component(2) + k2.Component(3)) / 6
        v2 += d * (h2.Component(0) + 2 * h2.Component(1) + 2 * h2.Component(2) + h2.Component(3)) / 6

        u1 = MyMathhelper.AngleInMinusPiAndPi(u1)
        u2 = MyMathhelper.AngleInMinusPiAndPi(u2)

        'New Values to MyVariables
        With MyVariables
            If .Component(0) * u1 <= 0 Then
                SignumChanged = True
            Else
                SignumChanged = False
            End If
            .Component(0) = u1
            .Component(1) = u2
        End With

        'Draw Phase Diagram
        DrawPhaseportrait()

        'Transfer new Values to Position
        SetPosition()

        'Draw Track
        DrawTrack()

        'Draw actual Pendulumposition
        DrawPendulums()

    End Sub

    Private Sub DrawTrack()

        'The track of Pendulum1 is always on a circle and not interesting
        'MyBitmapGraphics.DrawLine(OldPosition1, Position1, Color.Red, 1)
        MyMapPendulumGraphics.DrawLine(OldPosition2, Position2, Color.Green, 1)
        MyPicPendulum.Invalidate()

    End Sub

    Private Sub DrawPhaseportrait()
        Select Case MyPhaseportraitType
            Case TypeofPhaseportraitEnum.Torus
                MyPicPhaseportrait.Refresh()
                MyPicPhaseportraitGraphics.DrawLine(New ClsMathpoint(u1, u2), New ClsMathpoint(u1 + v1 / 10, u2 + v2 / 10), Color.Red, 1)
                MyMapPhaseportraitGraphics.DrawPoint(New ClsMathpoint(u1, u2), Brushes.Green, 1)
            Case TypeofPhaseportraitEnum.PoincareSection
                If SignumChanged Then
                    MyPicPhaseportraitGraphics.DrawPoint(New ClsMathpoint(u2, v2), Brushes.Green, 2)
                End If
            Case Else
                'Draw only into PicPhaseportrait
                MyPicPhaseportraitGraphics.DrawPoint(New ClsMathpoint(u1, v1), Brushes.Red, 1)
                MyPicPhaseportraitGraphics.DrawPoint(New ClsMathpoint(u2, v2), Brushes.Green, 1)
        End Select

    End Sub

    Private Sub ProtocolValues()

        MyParameterlistbox.Items.Add(u1.ToString("N11") & ", " & v1.ToString("N11") & ", " &
                                     u2.ToString("N11") & ", " & v2.ToString("N11") & ", " &
                                     GetEnergy.ToString("N11"))

    End Sub

    Private Function GetEnergy() As Decimal

        'This routine protocols the total Energy of the double pendulum
        'to have a control that it is constant
        'if that is not the case, the error of Runge Kutta Method is too big
        'the Zero level of the potential energy is set to y = -1
        Dim EKin As Decimal
        Dim EPot As Decimal
        Dim Etotal As Decimal

        With Constants
            'we set as norm m1 = 1, m2 = M
            'kinetic energy of m1: L1^2*v1^2/2
            EKin = CDec(Math.Pow(.Component(0) * v1, 2) / 2)

            'kinetic energy of m2: see math. doc.
            EKin += CDec(MyM * (Math.Pow(.Component(0) * v1, 2) +
                2 * .Component(0) * v1 * .Component(1) * v2 * Math.Cos(u1 - u2) +
                Math.Pow(.Component(1) * v2, 2)) / 2)

            'potential energy of m1 and m2: see math.doc.
            EPot = g * CDec((1 - .Component(0) * Math.Cos(u1)) * (1 + MyM) - MyM * .Component(1) * Math.Cos(u2))

            'Etotal in the possible interval of StartEnergyRange
            Etotal = Math.Min(EKin + EPot, StartEnergyRange.B)
            Etotal = Math.Max(Etotal, StartEnergyRange.A)

            Return EKin + EPot
        End With

    End Function

    Private Function F1(x As ClsVector) As Decimal

        'calculates next u1' = v1 = x.component(1)
        Return x.Component(1)

    End Function

    Private Function G1(x As ClsVector) As Decimal

        Dim Temp As Decimal

        With x
            'DeltaU = u2-u1
            Dim DeltaU As Decimal = .Component(2) - .Component(0)

            'L2*V2*V2 + L1*cos(DeltaU)*V1*V1
            Temp = CDec(MyConstants.Component(1) * Math.Pow(.Component(3), 2) +
                MyConstants.Component(0) * Math.Cos(DeltaU) * Math.Pow(.Component(1), 2))

            '*-Mu*sin(deltaU)
            Temp *= -Mu * CDec(Math.Sin(DeltaU))

            '+g*(Mu*cos(Deltau)*sin(U2)-sin(U1))
            Temp += g * CDec(Mu * Math.Cos(DeltaU) * Math.Sin(.Component(2)) - Math.Sin(.Component(0)))

            Dim Check1 As Decimal = CDec(Math.Cos(DeltaU) * Math.Sin(.Component(2)))
            Dim Check2 As Decimal = CDec(Math.Sin(.Component(0)))

            'Divisor L1*(1-Mu*cos2(Deltau))
            Temp /= MyConstants.Component(0) * (1 - Mu * CDec(Math.Pow(Math.Cos(DeltaU), 2)))
        End With

        Return Temp

    End Function

    Private Function F2(x As ClsVector) As Decimal

        'calculates next u2' = v2 = x.component(3)
        Return x.Component(3)
    End Function

    Private Function G2(x As ClsVector) As Decimal

        Dim Temp As Decimal

        With x
            'calculates next v2' = see math.doc.
            Dim DeltaU As Decimal = .Component(2) - .Component(0)

            'L1*V1*V1 + Mu*L2*cos(DeltaU)*V2*V2
            Temp = CDec(MyConstants.Component(0) * Math.Pow(.Component(1), 2) +
                Mu * MyConstants.Component(1) * Math.Cos(DeltaU) * Math.Pow(.Component(3), 2))

            '*sin(deltaU)
            Temp *= CDec(Math.Sin(DeltaU))

            '+g*(Mu*cos(Deltau)*sin(U1)-sin(U2))
            Temp += g * CDec(Math.Cos(DeltaU) * Math.Sin(.Component(0)) - Math.Sin(.Component(2)))

            Dim Check1 As Decimal = CDec(Math.Cos(DeltaU) * Math.Sin(.Component(2)))
            Dim Check2 As Decimal = CDec(Math.Sin(.Component(0)))

            'Divisor L2*(1-Mu*cos2(Deltau))
            Temp /= MyConstants.Component(1) * (1 - Mu * CDec(Math.Pow(Math.Cos(DeltaU), 2)))
        End With

        Return Temp

    End Function

    Private Function G1Test(x As ClsVector) As Decimal

        'This function corresponds to a simple Thread Pendulum
        Dim Temp As Decimal

        With x

            Temp = -g * CDec(Math.Sin(.Component(0)) / MyConstants.Component(0))

        End With

        Return Temp

    End Function

    Private Function G2Test(x As ClsVector) As Decimal

        'This function corresponds to a simple Thread Pendulum
        Dim Temp As Decimal

        With x

            Temp = -g * CDec(Math.Sin(.Component(2)) / MyConstants.Component(1))

        End With

        Return Temp

    End Function
End Class
