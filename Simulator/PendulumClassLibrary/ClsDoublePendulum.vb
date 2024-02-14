'This class contains all properties and methods for the double pendulum
'See mathematical documentation

'important: this class works with mathematical coordinates
'the Instance of the GraphicTool transforms these in Pixel-Coordinates

'Status UnChecked

Imports System.ComponentModel
Imports System.Globalization

Public Class ClsDoublePendulum
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
    Private ReadOnly MySetAdditionalParameter As ClsValueParameter
    Private MyAdditionalParameter As Integer

    'and protocols its Parametervalues into a ListBox
    Private MyParameterlistbox As ListBox

    'Calculations
    Private ReadOnly MyMathhelper As ClsMathHelperPendulum

    'Factor C for the C-Diagram
    Private MyC As Decimal

    'Mass ratio M
    Private MyM As Decimal

    'and ratio Mu
    Private Mu As Decimal

    'Collection of the two ValueRanges for the C-Diagram
    Private ReadOnly MyValueParameters As List(Of ClsValueParameter)

    'The Value Range of the Mathematical Coordinates - Standard is the Interval [-1,1]
    'and the Coordinate System as Square [-1,1] x [-1,1]
    Private ReadOnly MyMathValuerange As ClsInterval

    'Constant parameters
    Private ReadOnly MyConstants As ClsVector

    'Variable parameters
    Private ReadOnly MyVariables As ClsVector

    'Size of Pendulums
    Private ReadOnly MyPendulumSize As ClsVector

    Private MyIsStartparameter1Set As Boolean

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

    'SECTOR INITIALIZATION

    Public Sub New()

        MyMathhelper = New ClsMathHelperPendulum

        MyMathValuerange = New ClsInterval(-1, 1)

        MyValueParameters = New List(Of ClsValueParameter)

        Dim ValueParameter(3) As ClsValueParameter

        'Inizialize all parameters
        'Tag is the Number of the Label in the Pendulum Form
        'L1
        ValueParameter(0) = New ClsValueParameter(1, "L1", New ClsInterval(CDec(0.1), CDec(0.8)))
        MyValueParameters.Add(ValueParameter(0))

        'L2
        ValueParameter(1) = New ClsValueParameter(2, "L2", New ClsInterval(CDec(0.1), CDec(0.8)))
        MyValueParameters.Add(ValueParameter(1))

        'Phi1
        ValueParameter(2) = New ClsValueParameter(3, "Phi 1", New ClsInterval(-CDec(Math.PI), CDec(Math.PI)))
        MyValueParameters.Add(ValueParameter(2))

        'Phi2
        ValueParameter(3) = New ClsValueParameter(4, "Phi 2", New ClsInterval(-CDec(Math.PI), CDec(Math.PI)))
        MyValueParameters.Add(ValueParameter(3))

        'Labels
        MyPhaseportraitLabel = Main.LM.GetString("PhasePortrait") & ": u1, v1, u2, v2 -- Etot"
        MyLabelParameterC = Main.LM.GetString("DoublePendulumC")

        'The interval for the Additional Parameter sets the range of the TrackBar AdditionalParameter
        'and the Tag its Value of the Additional PArameter as Standard
        MyAdditionalParameter = 4  'that means mass m2 = m1
        MySetAdditionalParameter = New ClsValueParameter(MyAdditionalParameter, Main.LM.GetString("MassRatioM"), New ClsInterval(1, 7))

        'Calculates mass ratio M = m2/m1
        MyM = CalcMfromTrbAddParameter(MyAdditionalParameter)

        'Vectors
        'We have two constant parameters: L1 = .Component(0), L2 = Component(1)
        MyConstants = New ClsVector(1)

        'Standardvalues
        With MyConstants
            .Component(0) = CDec(0.45)  'L1
            .Component(1) = CDec(0.45)  'L2
            MyC = 1 'ratio L1/L2
        End With

        'We have two variable parameters: Phi1 = MyVariables.Components(0), Phi2 = MyVariables.components(1)
        MyVariables = New ClsVector(1)

        'Standardvalues
        With MyVariables
            .Component(0) = CDec(Math.PI / 3) 'Phi1
            u1 = .Component(0)
            v1 = 0
            .Component(1) = CDec(Math.PI / 6) 'Phi2
            u2 = .Component(1)
            v2 = 0
        End With

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
            MyPictureBox = value
            MyPictureboxGraphics = New ClsGraphicTool(MyPictureBox, MyMathValuerange, MyMathValuerange)
        End Set
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
            ValueParameters = MyValueParameters
        End Get
    End Property

    ReadOnly Property LabelPhasePortrait As String Implements IPendulum.LabelPhasePortrait
        Get
            LabelPhasePortrait = MyPhaseportraitLabel
        End Get
    End Property

    ReadOnly Property SetAdditionalParameter As ClsValueParameter Implements IPendulum.SetAdditionalParameter
        Get
            SetAdditionalParameter = MySetAdditionalParameter
        End Get
    End Property

    ReadOnly Property LabelParameterC As String Implements IPendulum.LabelParameterC
        Get
            LabelParameterC = MyLabelParameterC
        End Get
    End Property

    Property C As Decimal Implements IPendulum.C
        Get
            C = MyC
        End Get
        Set(value As Decimal)
            MyC = value
        End Set
    End Property

    WriteOnly Property AdditionalParameter As Integer Implements IPendulum.AdditionalParameter
        Set(value As Integer)
            MyAdditionalParameter = value
            MyM = CalcMfromTrbAddParameter(MyAdditionalParameter)
            SetPendulumSize()
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

    'SECTOR CALCULATION AND DRAWING

    Public Function CalcMfromTrbAddParameter(AddParameter As Integer) As Decimal Implements IPendulum.CalcMfromTrbAddParameter

        Dim Temp As Decimal = CDec(Math.Exp(Math.Log(2) * (AddParameter - 4)))

        Return Temp

    End Function

    Public Sub DrawPendulum() Implements IPendulum.DrawPendulum

        With MyPictureboxGraphics

            'Clear Graphic
            MyPictureBox.Refresh()

            'First Pendulum
            .DrawLine(New ClsMathpoint(0, 0), Position1, Color.Red, 2)
            .FillCircle(Position1, MyPendulumSize.Component(0), Brushes.Red)

            'Second Pendulum
            .DrawLine(Position1, Position2, Color.Green, 2)
            .FillCircle(Position2, MyPendulumSize.Component(1), Brushes.Green)

        End With

    End Sub

    Sub ClearBitmap() Implements IPendulum.ClearBitmap

        MyBitmapGraphics.Clear(Color.White)

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

    Private Sub SetPendulumSize()

        'The smaller Pendulum has always the Size 3 (in Pixels)
        'that is about 1/
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

        'Factor Mu in Differential Equations
        Mu = MyM / (1 + MyM)

    End Sub

    'SECTOR SETSTARTPARAMETER
    Sub SetAndDrawStartparameter1(Mouseposition As Point) Implements IPendulum.SetAndDrawStartparameter1

        Dim ActualPosition As ClsMathpoint = MyPictureboxGraphics.PixelToMathpoint(Mouseposition)

        With ActualPosition
            'L1 should be maximal 0.8 to reserve some place for L2 and minimal 0.01 because of the divisor in the Differential Equation
            Dim LocRange As ClsInterval
            'L1
            LocRange = New ClsInterval(MyValueParameters.Item(0).Range.A, MyValueParameters.Item(0).Range.B)
            Dim L1 As Decimal = CDec(Math.Max(LocRange.A, Math.Min(Math.Sqrt(.X * .X + .Y * .Y), LocRange.B)))

            'Phi1
            Dim Phi1 As Decimal = MyMathhelper.GetAngle(.X, .Y)

            'Set parameters
            MyConstants.Component(0) = L1
            MyVariables.Component(0) = MyMathhelper.AngleInMinusPiAndPi(Phi1)
            MyC = MyConstants.Component(0) / MyConstants.Component(1)

            SetPosition()

            'Draw pendulum
            DrawPendulum()

            'Runge Kutta
            u1 = Phi1
            v1 = 0

        End With

    End Sub

    Sub SetAndDrawStartparameter2(Mouseposition As Point) Implements IPendulum.SetAndDrawStartparameter2

        Dim ActualPosition As ClsMathpoint = MyPictureboxGraphics.PixelToMathpoint(Mouseposition)

        With ActualPosition

            Dim DeltaX As Decimal = .X - Position1.X
            Dim DeltaY As Decimal = .Y - Position1.Y

            'L1 + L2 should be maximal 0.95 to be visible and minimal 0.01 because of the divisor in the Differential Equation
            Dim LocRange As ClsInterval
            'L2
            LocRange = New ClsInterval(MyValueParameters.Item(1).Range.A, MyValueParameters.Item(1).Range.B)
            Dim L2 As Decimal = CDec(Math.Max(LocRange.A, (Math.Min(Math.Sqrt(DeltaX * DeltaX + DeltaY * DeltaY), 0.95 - MyConstants.Component(0)))))
            Dim Phi2 As Decimal = MyMathhelper.GetAngle(DeltaX, DeltaY)

            'Set parameters
            MyConstants.Component(1) = L2
            MyVariables.Component(1) = MyMathhelper.AngleInMinusPiAndPi(Phi2)
            MyC = MyConstants.Component(0) / MyConstants.Component(1)

            SetPosition()

            'Draw pendulum
            DrawPendulum()

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

        u1 = MyMathhelper.AngleInMinusPiAndPi(u1)
        u2 = MyMathhelper.AngleInMinusPiAndPi(u2)

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
        MyBitmapGraphics.DrawLine(OldPosition2, Position2, Color.Green, 1)
        MyPictureBox.Invalidate()

    End Sub

    Private Sub DrawPhaseDiagram()

        MyPhaseportraitGraphics.DrawPoint(New ClsMathpoint(u1, v1), Brushes.Red, 1)
        MyPhaseportraitGraphics.DrawPoint(New ClsMathpoint(u2, v2), Brushes.Green, 1)

    End Sub

    Private Sub ProtocolValues()

        MyParameterlistbox.Items.Add(u1.ToString("N11") & ", " & v1.ToString("N11") & ", " & u2.ToString("N11") & ", " & v2.ToString("N11") & ", " & GetEnergy.ToString("N11"))

    End Sub

    Private Function GetEnergy() As Decimal

        'This routine protocols the total Energy of the double pendulum
        'to have a control that it is constant
        'if that is not the case, the error of Runge Kutta Method is too big
        'the Zero level of the potential energy is set to y = -1
        Dim EKin As Decimal
        Dim EPot As Decimal

        With Constants
            'we set as norm m1 = 1, m2 = M
            'kinetic energy of m1: L1^2*v1^2/2
            EKin = CDec(Math.Pow(.Component(0), 2) * v1 * v1 / 2)

            'kinetic energy of m2: see math. doc.
            EKin += CDec(MyM * (Math.Pow(.Component(0), 2) * v1 * v1 + 2 * .Component(0) * .Component(1) * v1 * v2 * Math.Cos(u1 - u2) + Math.Pow(.Component(1), 2) * v2 * v2) / 2)

            'potential energy of m1 and m2: see math.doc.
            EPot = g * CDec((1 - .Component(0) * Math.Cos(u1)) * (1 + MyM) - MyM * .Component(1) * Math.Cos(u2))

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
            Temp = CDec(MyConstants.Component(1) * Math.Pow(.Component(3), 2) + MyConstants.Component(0) * Math.Cos(DeltaU) * Math.Pow(.Component(1), 2))

            '*-Mu*sin(deltaU)
            Temp = -Mu * CDec(Math.Sin(DeltaU)) * Temp

            '+g*(Mu*cos(Deltau)*sin(U2)-sin(U1))
            Temp += g * (Mu * CDec(Math.Cos(DeltaU) * Math.Sin(.Component(2)) - Math.Sin(.Component(0))))

            'Divisor L1*(1-Mu*cos2(Deltau))
            Temp = Temp / MyConstants.Component(0) * (1 - Mu * CDec(Math.Pow(Math.Cos(DeltaU), 2)))
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
            Temp = CDec(MyConstants.Component(0) * Math.Pow(.Component(1), 2) + Mu * MyConstants.Component(1) * Math.Cos(DeltaU) * Math.Pow(.Component(3), 2))

            '*sin(deltaU)
            Temp = CDec(Math.Sin(DeltaU)) * Temp

            '+g*(Mu*cos(Deltau)*sin(U1)-sin(U2))
            Temp += g * (CDec(Math.Cos(DeltaU) * Math.Sin(.Component(0)) - Math.Sin(.Component(2))))

            'Divisor L2*(1-Mu*cos2(Deltau))
            Temp = Temp / MyConstants.Component(1) * (1 - Mu * CDec(Math.Pow(Math.Cos(DeltaU), 2)))
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
