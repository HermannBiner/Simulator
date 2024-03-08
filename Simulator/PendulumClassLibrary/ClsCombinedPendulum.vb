'This class contains all properties and methods for a combined pendulum
'oscillating as spring pendulum and thread pendulum
'See mathematical documentation

'important: this class works with mathematical coordinates
'the Instance of the GraphicTool transforms these in Pixel-Coordinates

'Status UnChecked

Imports System.ComponentModel
Imports System.Globalization
Imports System.Linq.Expressions

Public Class ClsCombinedPendulum
    Implements IPendulum

    'The actual position of the Pendulum is drawn into this PictureBox
    'and shown by the Refresh-Method
    Private MyPictureBox As PictureBox
    Private MyPictureboxGraphics As ClsGraphicTool

    'The permanent Track of the Pendulum is drawn into the BitMap
    Private MyBitmap As Bitmap
    Private MyBitmapGraphics As ClsGraphicTool


    'The Pendulum draws as well into the Phase Portrait
    Private MyPhaseportrait As PictureBox
    Private MyPhaseportraitGraphics As ClsGraphicTool

    'Labeling
    Private ReadOnly MyPhaseportraitLabel As String
    Private ReadOnly MyLabelParameterC As String
    Private ReadOnly MyAdditionalParameter As ClsValueParameter
    Private MyAdditionalParameterValue As Integer

    'and protocols its Parametervalues into a ListBox
    Private MyParameterlistbox As ListBox

    'Calculations
    Private ReadOnly MyMathhelper As ClsMathHelperPendulum

    'Factor C for the C-Diagram
    'This will be the Startenergy of the Combined Pendulum
    Private MyC As Decimal

    'Frequency of the Spring Pendulum alone
    'set as additional Parameter
    Private MyOmega As Decimal

    'Collection of the two ValueRanges for the C-Diagram
    Private ReadOnly MyValueParameters As List(Of ClsValueParameter)

    'The Value Range of the Mathematical Coordinates - Standard is the Interval [-1,1]
    'and the Coordinate System as Square [-1,1] x [-1,1]
    Private ReadOnly MyMathValuerange As ClsInterval

    'The Interval of the StartEnergy
    Private MyStartEnergyRange As ClsInterval

    'We have no constants with the Combined Pendulum

    'Variable parameters
    Private ReadOnly MyVariables As ClsVector

    Private MyIsStartparameter1Set As Boolean

    Private MyIsStartparameter2Set As Boolean

    'To perform the iteration
    'Positions of the Pendulum Mass
    Private ReadOnly Position As ClsMathpoint
    Private ReadOnly OldPosition As ClsMathpoint

    'Runge Kutta Parameters
    Private u1 As Decimal
    Private v1 As Decimal
    Private u2 As Decimal
    Private v2 As Decimal

    'And additional Parameters for Runge Kutta
    Private ReadOnly x As ClsVector
    Private ReadOnly k1 As ClsVector
    Private ReadOnly h1 As ClsVector
    Private ReadOnly k2 As ClsVector
    Private ReadOnly h2 As ClsVector

    'Step Width
    Private d As Decimal

    Private IsTestMode As Boolean

    'Gravitation acceleration
    Const g As Decimal = CDec(9.81)

    'Length of unstressed Spring
    Const StartL As Decimal = CDec(0.5)

    'Minimal length of the spring pendulum
    Const Lmin As Decimal = CDec(0.05)

    'Level of the x-Axis in the Diagram as math. y-Coordinate
    'y0 in math. dok.
    Private MyY0 As Decimal

    'SECTOR INITIALIZATION

    Public Sub New()

        MyMathhelper = New ClsMathHelperPendulum

        MyMathValuerange = New ClsInterval(-1, 1)

        'The interval for the Additional Parameter sets the range of the TrackBar AdditionalParameter
        'and the Tag its Value of the Additional Parameter as Standard

        'Omega has to be bigger than ... see math. doc.
        Dim LowerLimitOmega As Integer = CInt(Math.Ceiling(Math.Max(Math.Sqrt(g / (1 - StartL)), Math.Sqrt(g / StartL))))

        MyAdditionalParameterValue = LowerLimitOmega + 5
        MyAdditionalParameter = New ClsValueParameter(MyAdditionalParameterValue,
                                                      Main.LM.GetString("SpringPendulumFrequency"),
                                                      New ClsInterval(LowerLimitOmega, LowerLimitOmega + 10))

        MyOmega = CalcValuefromTrbAddParameter(MyAdditionalParameterValue)

        'This is an optimal value that the movement of the pendulum has place in the diagram
        MyY0 = CDec(g / Math.Pow(MyOmega, 2) / (1 - StartL))

        MyValueParameters = New List(Of ClsValueParameter)

        Dim ValueParameter(1) As ClsValueParameter

        'Inizialize all parameters
        'Tag is the Number of the Label in the Pendulum Form
        'L
        ValueParameter(0) = New ClsValueParameter(1, "L", New ClsInterval(Lmin, CDec(0.95)))
        MyValueParameters.Add(ValueParameter(0))

        'Phi
        ValueParameter(1) = New ClsValueParameter(2, "Phi", New ClsInterval(-CDec(Math.PI), CDec(Math.PI)))
        MyValueParameters.Add(ValueParameter(1))

        'Labels
        MyPhaseportraitLabel = Main.LM.GetString("PhasePortrait") & ": red: u1, v1, green: u2, v2 -- Etot"
        MyLabelParameterC = Main.LM.GetString("CombinedPendulumC")

        DrawCoordinateSystem()

        'We have two variable parameters: L = MyVariables.Components(0), Phi = MyVariables.components(1)
        MyVariables = New ClsVector(1)

        'Standardvalues
        With MyVariables
            .Component(0) = StartL + MyY0
            u1 = .Component(0)
            v1 = 0
            .Component(1) = CDec(Math.PI / 6) 'Phi
            u2 = .Component(1)
            v2 = 0
        End With

        SetStartenergyRange()

        'For the Combined Pendulum is the Factor C 
        'the Energy
        MyC = GetEnergy()

        'To perform the iteration
        'Positions of the pendulums
        Position = New ClsMathpoint
        OldPosition = New ClsMathpoint

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
            MyPictureBox = value
            MyPictureboxGraphics = New ClsGraphicTool(MyPictureBox, MyMathValuerange, MyMathValuerange)
        End Set
    End Property

    ReadOnly Property Y0 As Decimal Implements IPendulum.Y0
        Get
            Y0 = MyY0
        End Get
    End Property

    WriteOnly Property MapPendulum As Bitmap Implements IPendulum.MapPendulum
        Set(value As Bitmap)
            MyBitmap = value
            MyBitmapGraphics = New ClsGraphicTool(MyBitmap, MyMathValuerange, MyMathValuerange)
        End Set
    End Property

    WriteOnly Property Phaseportrait As PictureBox Implements IPendulum.Phaseportrait
        Set(value As PictureBox)
            MyPhaseportrait = value
            Dim UInterval = New ClsInterval(-CDec(Math.PI), CDec(Math.PI))
            Dim VInterval = New ClsInterval(-8, 8)
            MyPhaseportraitGraphics = New ClsGraphicTool(MyPhaseportrait, UInterval, VInterval)
        End Set
    End Property

    WriteOnly Property ParameterListbox As ListBox Implements IPendulum.ParameterListbox
        Set(value As ListBox)
            MyParameterlistbox = value
        End Set
    End Property

    ReadOnly Property ValueParameters As List(Of ClsValueParameter) Implements IPendulum.ValueParameters
        Get
            'Lmax must be adapted depending on Phi
            MyValueParameters.Item(0) = New ClsValueParameter(1, "L", New ClsInterval(CDec(0.2), CDec(0.95 + MyY0 * Math.Cos(MyVariables.Component(1)))))

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
            MyOmega = CalcValuefromTrbAddParameter(MyAdditionalParameterValue)
            MyY0 = CDec(g / Math.Pow(MyOmega, 2) / (1 - StartL))
            'Variables.Component(0) = 0
            SetPosition()
            DrawCoordinateSystem()
            DrawPendulum()
            SetStartenergyRange()
        End Set
    End Property

    Property Constants As ClsVector Implements IPendulum.Constants
        Set(value As ClsVector)
            'nothing to set - just implement IPendulum
        End Set
        Get
            Constants = Nothing
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
            StartEnergyRange = MyStartEnergyRange
        End Get
    End Property

    'SECTOR CALCULATION AND DRAWING

    Public Function CalcValuefromTrbAddParameter(AddParameter As Integer) As Decimal Implements IPendulum.CalcValuefromTrbAddParameter

        Dim Temp As Decimal = AddParameter

        Return Temp

    End Function

    Private Sub DrawCoordinateSystem() Implements IPendulum.DrawCoordinateSystem

        If MyBitmapGraphics IsNot Nothing Then
            ClearBitmap()
            'x-Axis
            MyBitmapGraphics.DrawLine(New ClsMathpoint(-1, 0), New ClsMathpoint(1, 0), Color.Aquamarine, 1)
            'y0-Line
            MyBitmapGraphics.DrawLine(New ClsMathpoint(-1, MyY0), New ClsMathpoint(1, MyY0), Color.Red, 1)
            'y-Axis
            MyBitmapGraphics.DrawLine(New ClsMathpoint(0, -1), New ClsMathpoint(0, 1), Color.Aquamarine, 1)

            'Show the equilibrium line where the spring compensates the gravitation
            Dim i As Integer

            'Parameters of the polar coordinates
            Dim r As Decimal
            Dim t As Decimal
            Dim NumberOfSteps As Integer = 500

            For i = 0 To NumberOfSteps
                t = MyMathhelper.AngleInMinusPiAndPi(CDec(-Math.PI + i * 2 * Math.PI / NumberOfSteps))
                r = StartL + CDec(g * Math.Cos(t) / Math.Pow(MyOmega, 2))
                MyBitmapGraphics.DrawPoint(New ClsMathpoint(r * CDec(Math.Sin(t)), MyY0 - r * CDec(Math.Cos(t))), Brushes.Red, 1)
            Next

        End If

    End Sub

    Public Sub DrawPendulum() Implements IPendulum.DrawPendulum

        With MyPictureboxGraphics

            'Clear Graphic
            MyPictureBox.Refresh()

            'Pendulum
            .DrawLine(New ClsMathpoint(0, MyY0), Position, Color.Green, 2)
            .FillCircle(Position, CDec(0.02), Brushes.Green)

        End With

    End Sub

    Sub ClearBitmap() Implements IPendulum.ClearBitmap

        MyBitmapGraphics.Clear(Color.White)

    End Sub

    'Sets the position of the Pendulums
    Private Sub SetPosition()

        'See math. doc.
        With Position
            .X = MyVariables.Component(0) * CDec(Math.Sin(MyVariables.Component(1)))
            .Y = -MyVariables.Component(0) * CDec(Math.Cos(MyVariables.Component(1))) + MyY0
        End With

    End Sub

    Private Sub SetStartenergyRange()

        Dim Emin As Decimal
        Dim Emax As Decimal

        Emin = -CDec(Math.Pow(g / MyOmega, 2)) / 2
        Emax = CDec(Math.Pow(MyOmega * (1 - MyY0 - StartL), 2)) / 2 + g * (StartL + 1 - MyY0)

        MyStartEnergyRange = New ClsInterval(Emin, Emax)

    End Sub

    'SECTOR SETSTARTPARAMETER
    Sub SetAndDrawStartparameter1(Mouseposition As Point) Implements IPendulum.SetAndDrawStartparameter1

        Dim ActualPosition As ClsMathpoint = MyPictureboxGraphics.PixelToMathpoint(Mouseposition)

        With ActualPosition

            .Y = .Y - MyY0

            'Phi
            Dim Phi As Decimal = MyMathhelper.GetAngle(.X, .Y)
            Phi = MyMathhelper.AngleInMinusPiAndPi(Phi)

            'L should be in [MyValueParameters.Item(0).Range.A, MyValueParameters.Item(0).Range.B]
            Dim LocL As Decimal
            LocL = CDec(Math.Sqrt(.X * .X + .Y * .Y))
            LocL = Math.Max(MyValueParameters.Item(0).Range.A, LocL)
            LocL = Math.Min(LocL, CDec(0.95) + MyY0 * CDec(Math.Cos(Phi)))


            'Set parameters
            MyVariables.Component(0) = LocL
            MyVariables.Component(1) = Phi
            MyC = GetEnergy()

            SetPosition()

            SetStartenergyRange()

            'Draw pendulum
            DrawPendulum()

            'Runge Kutta
            u1 = LocL
            v1 = 0
            u2 = Phi
            v2 = 0

        End With

    End Sub

    Sub SetAndDrawStartparameter2(Mouseposition As Point) Implements IPendulum.SetAndDrawStartparameter2

        'nothing - the position is set on the first step
        'just implementing IPendulum
    End Sub


    'SECTOR ITERATION

    Sub Iteration(TestMode As Boolean) Implements IPendulum.Iteration

        'Performs one iteration step
        'and does all drawings
        'all startparameters are already set
        'that is Position
        'and Runge Kutta u1, v1, u2, v2

        'See math. doc. for the Details of this Implementation

        'Set OldPosition = Position
        With OldPosition
            .X = Position.X
            .Y = Position.Y
        End With

        'Draw Phase Diagram
        DrawPhaseDiagram()

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

        If u1 < Lmin Then
            u1 = Lmin
            v1 = -v1
        End If

        u2 = MyMathhelper.AngleInMinusPiAndPi(u2)

        'For debug issues
        'If Math.Abs(u1) > 500 Or Math.Abs(u2) > 500 Then Stop

        'New Values to MyVariables
        With MyVariables
            .Component(0) = u1
            .Component(1) = u2
        End With

        'Transfer new Values to Position
        SetPosition()

        'Draw Track
        DrawTrack()

        'Draw actual Pendulumposition
        DrawPendulum()

    End Sub

    Private Sub DrawTrack()

        'The track of Pendulum1 is always on a circle and not interesting
        'MyBitmapGraphics.DrawLine(OldPosition1, Position1, Color.Red, 1)
        MyBitmapGraphics.DrawLine(OldPosition, Position, Color.Green, 1)
        MyPictureBox.Invalidate()

    End Sub

    Private Sub DrawPhaseDiagram()

        MyPhaseportraitGraphics.DrawPoint(New ClsMathpoint(u1, v1), Brushes.Red, 1)
        MyPhaseportraitGraphics.DrawPoint(New ClsMathpoint(u2, v2), Brushes.Green, 1)

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
        Dim ESpring As Decimal

        'we set as norm m = 1
        'kinetic energy of m: (v1^2 + l^2*v2^2)/2
        EKin = CDec(Math.Pow(v1, 2) + Math.Pow(u1 * v2, 2)) / 2

        'Potential Energy of m
        EPot = g * (StartL - CDec(u1 * Math.Cos(u2)))

        'potential energy of Spring Pendulum: see math.doc.
        'Spring constant id D, MyOmega = SQRT(D/m) => D = MyOmega^2
        ESpring = CDec(Math.Pow(MyOmega * (u1 - StartL), 2)) / 2

        Return EKin + EPot + ESpring

    End Function

    Private Function F1(x As ClsVector) As Decimal

        'calculates next u1' = v1 = x.component(1)
        Return x.Component(1)

    End Function

    Private Function G1(x As ClsVector) As Decimal

        Dim Temp As Decimal


        With x
            Try
                Temp = .Component(0) * CDec(Math.Pow(.Component(3), 2))
                Temp += CDec(-Math.Pow(MyOmega, 2) * (.Component(0) - StartL) + g * Math.Cos(.Component(2)))
            Catch ex As Exception
                MessageBox.Show("Overflow 0: " & .Component(0).ToString & ", 2: " & .Component(2).ToString & ", 3: " & .Component(3).ToString)
            End Try


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
            'see math.doc: (-2*v2*v1-g*sinu2)/u1
            'and: u1 = l > 0
            Try
                Temp = (-2 * .Component(3) * .Component(1) - g * CDec(Math.Sin(.Component(2)))) / .Component(0)
            Catch ex As Exception
                MessageBox.Show("Overflow 0: " & .Component(0).ToString & ", 1: " & .Component(1).ToString & ", 2: " & .Component(2).ToString & ", 3: " & .Component(3).ToString)
            End Try

        End With

        Return Temp

    End Function

    Private Function G1Test(x As ClsVector) As Decimal

        'This function corresponds to a simple Thread Pendulum
        Dim Temp As Decimal

        With x

            Temp = -g * CDec(Math.Sin(.Component(0))) / StartL

        End With

        Return Temp

    End Function

    Private Function G2Test(x As ClsVector) As Decimal

        'This function corresponds to a simple Spring Pendulum
        Dim Temp As Decimal

        With x

            Temp = - .Component(2) * CDec(Math.Pow(MyOmega, 2))

        End With

        Return Temp

    End Function


End Class
