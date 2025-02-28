'This class contains all properties and methods for the double pendulum
'See mathematical documentation

'important: this class works with mathematical coordinates
'the Instance of the GraphicTool transforms these in Pixel-Coordinates

'Attention: Runge Kutta is NOT representing a real Double Pendulum!!

'Status Checked


Public Class ClsDoublePendulum
    Inherits ClsPendulumAbstract

    Private ReadOnly ValueParameter(3) As ClsGeneralParameter

    'Mass ratio M: m2 = MyM*m1
    Private M As Decimal

    'and ratio Mu: Mu = MyM/(1+MyM)
    Private Mu As Decimal

    'Size of Pendulums
    Private ReadOnly PendulumSize As ClsNTupel

    Private ReadOnly Origin As ClsMathpoint

    'SECTOR INITIALIZATION

    Public Sub New()

        Origin = New ClsMathpoint(0, 0)

        MyLabelProtocol = LM.GetString("Parameterlist") & ": u1, v1, u2, v2, Etot"

        MyValueParameterDefinition = New List(Of ClsGeneralParameter)

        'Inizialize all parameters
        'Tag is the Number of the Label in the Pendulum Form
        'L1
        ValueParameter(0) = New ClsGeneralParameter(1, "L1", New ClsInterval(CDec(0.1), ShrinkedInterval.B),
                                                    ClsGeneralParameter.TypeOfParameterEnum.Constant, CDec(0.7))
        MyValueParameterDefinition.Add(ValueParameter(0))

        'L2
        ValueParameter(1) = New ClsGeneralParameter(2, "L2", New ClsInterval(CDec(0.1), ShrinkedInterval.B),
                                                    ClsGeneralParameter.TypeOfParameterEnum.Constant, CDec(0.2))
        MyValueParameterDefinition.Add(ValueParameter(1))

        'Phi1
        ValueParameter(2) = New ClsGeneralParameter(3, "Phi 1", New ClsInterval(-CDec(Math.PI), CDec(Math.PI)),
                                                    ClsGeneralParameter.TypeOfParameterEnum.Variable, CDec(Math.PI / 4))
        MyValueParameterDefinition.Add(ValueParameter(2))

        'Phi2
        ValueParameter(3) = New ClsGeneralParameter(4, "Phi 2", New ClsInterval(-CDec(Math.PI), CDec(Math.PI)),
                                                    ClsGeneralParameter.TypeOfParameterEnum.Variable, CDec(Math.PI / 6))
        MyValueParameterDefinition.Add(ValueParameter(3))

        'Labels
        MyLabelPhasePortrait = LM.GetString("PhasePortrait") & ": -- "

        'The interval for the Additional Parameter sets the range of the TrackBar AdditionalParameter
        'and the Tag its Value of the Additional Parameter as Standard
        MyAdditionalParameterValue = 2  'that means mass m2 = m1
        MyAdditionalParameter = New ClsGeneralParameter(MyAdditionalParameterValue,
                                                      LM.GetString("MassRatioM"), New ClsInterval(0, 4), ClsGeneralParameter.TypeOfParameterEnum.DS)

        'Vectors
        'We have two constant parameters: L1 = .Component(0), L2 = Component(1)
        MyCalculationConstants = New ClsNTupel(1)

        'We have two variable parameters: Phi1 = MyVariables.Components(0), Phi2 = MyVariables.components(1)
        MyCalculationVariables = New ClsNTupel(1)

        'StandardSize
        PendulumSize = New ClsNTupel(1)

    End Sub

    Public Overrides Function GetCopy() As IPendulum
        Return New ClsDoublePendulum
    End Function

    'SECTOR CALCULATION AND DRAWING

    Public Overrides Function GetAddParameterValue(AddParameter As Integer) As Decimal

        'This is to adjust the value of TrbAdditionalParameter
        Dim Temp As Decimal = CDec(Math.Pow(2, AddParameter - 2))
        Return Temp

    End Function

    Protected Overrides Sub DrawCoordinateSystem()
        'x-Axis
        MyBmpGraphics.DrawLine(New ClsMathpoint(MathInterval.A, Y0),
                             New ClsMathpoint(MathInterval.B, Y0), Color.Aquamarine, 1)
        'y-Axis
        MyBmpGraphics.DrawLine(New ClsMathpoint(0, MathInterval.A),
                             New ClsMathpoint(0, MathInterval.B), Color.Aquamarine, 1)
    End Sub

    Protected Overrides Sub DrawPendulum()

        With PicGraphics

            If MyIsMainDS Then
                'Clear Graphic
                MyPicDiagram.Refresh()
            End If

            'Upper Pendulum
            .DrawLine(Origin, Position1, Color.Blue, 2)
            .FillCircle(Position1, PendulumSize.Component(0), Brushes.Blue)

            'Lower Pendulum
            .DrawLine(Position1, Position2, MyColor, 2)
            .FillCircle(Position2, PendulumSize.Component(1), MyColor)

        End With

    End Sub

    'Sets the position of the Pendulums
    Protected Overrides Sub SetPosition()

        'See math. doc.
        With Position1
            .X = MyCalculationConstants.Component(0) * CDec(Math.Sin(MyCalculationVariables.Component(0)))
            .Y = -MyCalculationConstants.Component(0) * CDec(Math.Cos(MyCalculationVariables.Component(0)))
        End With

        With Position2
            .X = Position1.X + MyCalculationConstants.Component(1) * CDec(Math.Sin(MyCalculationVariables.Component(1)))
            .Y = Position1.Y - MyCalculationConstants.Component(1) * CDec(Math.Cos(MyCalculationVariables.Component(1)))
        End With

    End Sub

    Protected Overrides Sub SetPhasePortraitParameters()

        Select Case TypeofPhasePortrait
            Case TypeofPhaseportraitEnum.TorusOrCylinder
                MyLabelPhasePortrait = LM.GetString("PhasePortrait") & ": Phi1, Phi2. Tangent: Phi1', Phi2'"
                UInterval = New ClsInterval(CDec(-Math.PI), CDec(Math.PI))
                VInterval = New ClsInterval(CDec(-Math.PI), CDec(Math.PI))
            Case TypeofPhaseportraitEnum.PoincareSection
                MyLabelPhasePortrait = LM.GetString("PhasePortrait") & ": Phi1 = 0, Phi2, Phi2'"
                UInterval = New ClsInterval(CDec(-Math.PI), CDec(Math.PI))
                VInterval = New ClsInterval(CDec(-10), CDec(10))
            Case Else 'independent
                MyLabelPhasePortrait = LM.GetString("PhasePortrait") & ": Blue: Phi1, Phi1'. Red: Phi2, Phi2'"
                UInterval = New ClsInterval(CDec(-Math.PI), CDec(Math.PI))
                VInterval = New ClsInterval(CDec(-10), CDec(10))
        End Select

    End Sub

    Protected Overrides Sub SetAdditionalParameters()

        M = GetAddParameterValue(MyAdditionalParameterValue)

        'Factor Mu in Differential Equations
        Mu = M / (1 + M)
        SetPendulumSize()

        If MyIsMainDS Then
            ResetIteration()
            SetStartEnergyRange()
        End If

        SetPosition()
    End Sub

    Protected Overrides Sub SetStartEnergyRange()

        Dim Emin As Decimal
        Dim Emax As Decimal

        'Emin = g*((1-l1)*(1+MyM)-MyM*l2)
        'Emax = g*((1+l1)*(1+MyM)+MyM*l2)
        With MyCalculationConstants
            Emin = g * ((1 - .Component(0)) * (1 + M) - M * .Component(1))
            Emax = g * ((1 + .Component(0)) * (1 + M) + M * .Component(1))
        End With
        MyStartEnergyRange = New ClsInterval(Emin, Emax)

    End Sub

    Private Sub SetPendulumSize()

        'The smaller Pendulum has about the Size 12 (in Pixels)
        'that is 12/1260 in Math. Coordinates - we set 0.01
        'and m2 = MyM*m1
        With PendulumSize
            If M >= 1 Then
                .Component(0) = CDec(0.01)
                .Component(1) = M * .Component(0)
            Else
                .Component(1) = CDec(0.01)
                .Component(0) = .Component(1) / M
            End If
        End With
    End Sub

    'SECTOR SETSTARTPARAMETER
    Public Overrides Sub SetAndDrawStartparameter1(Mouseposition As Point)

        Dim ActualPosition As ClsMathpoint = PicGraphics.PixelToMathpoint(Mouseposition)

        With ActualPosition
            'L1 should be maximal 0.8 to reserve some place for L2 and minimal 0.01
            'because of the divisor in the Differential Equation
            Dim LocRange As ClsInterval
            'L1
            LocRange = New ClsInterval(MyValueParameterDefinition.Item(0).Range.A, MyValueParameterDefinition.Item(0).Range.B)
            Dim L1 As Decimal = CDec(Math.Max(LocRange.A, Math.Min(Math.Sqrt(.X * .X + .Y * .Y), LocRange.B)))

            'L2 standard
            Dim L2 As Decimal = CDec(Math.Min(MyCalculationConstants.Component(1), ShrinkFactor - L1))

            'Phi1
            Dim Phi1 As Decimal = ClsMathHelperPendulum.GetAngle(.X, .Y)

            'Set parameters
            MyCalculationConstants.Component(0) = L1
            MyCalculationConstants.Component(1) = L2
            MyCalculationVariables.Component(0) = ClsMathHelperPendulum.AngleInMinusPiAndPi(Phi1)

            SetPosition()

            SetStartEnergyRange()

            'Draw pendulum
            DrawPendulum()

            'Runge Kutta
            u1 = Phi1
            v1 = 0

        End With

    End Sub

    Public Overrides Sub SetAndDrawStartparameter2(Mouseposition As Point)

        Dim ActualPosition As ClsMathpoint = PicGraphics.PixelToMathpoint(Mouseposition)

        With ActualPosition

            Dim DeltaX As Decimal = .X - Position1.X
            Dim DeltaY As Decimal = .Y - Position1.Y

            'L1 + L2 should be maximal 0.95 to be visible and minimal 0.01
            'because of the divisor in the Differential Equation
            Dim LocRange As ClsInterval
            'L2
            LocRange = New ClsInterval(MyValueParameterDefinition.Item(1).Range.A, MyValueParameterDefinition.Item(1).Range.B)
            Dim L2 As Decimal = CDec(Math.Max(LocRange.A, (Math.Min(Math.Sqrt(DeltaX * DeltaX + DeltaY * DeltaY),
                                                                    0.95 - MyCalculationConstants.Component(0)))))
            Dim Phi2 As Decimal = ClsMathHelperPendulum.GetAngle(DeltaX, DeltaY)

            'Set parameters
            MyCalculationConstants.Component(1) = L2
            MyCalculationVariables.Component(1) = ClsMathHelperPendulum.AngleInMinusPiAndPi(Phi2)

            SetPosition()

            SetStartEnergyRange()

            'Draw pendulum
            DrawPendulum()

            'Runge Kutta Parameters
            u2 = Phi2
            v2 = 0

        End With

    End Sub

    Protected Overrides Sub SetDefaultUserData()

        'Standardvalues
        With MyCalculationConstants
            .Component(0) = ValueParameter(0).DefaultValue  'L1
            .Component(1) = ValueParameter(1).DefaultValue  'L2
        End With

        With MyCalculationVariables
            .Component(0) = ValueParameter(2).DefaultValue 'Phi1
            u1 = .Component(0)
            v1 = 0
            .Component(1) = ValueParameter(3).DefaultValue 'Phi2
            u2 = .Component(1)
            v2 = 0
        End With

        SetAdditionalParameters()
        'This is to adjust the value of TrbAdditionalParameter

        SetPendulumSize()

    End Sub

    'SECTOR ITERATION

    Public Overrides Sub IterationStep(IsTestMode As Boolean)

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
        If IsTestMode Then
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
        If IsTestMode Then
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
        If IsTestMode Then
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
        If IsTestMode Then
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

        u1 = ClsMathHelperPendulum.AngleInMinusPiAndPi(u1)
        u2 = ClsMathHelperPendulum.AngleInMinusPiAndPi(u2)

        'New Values to MyVariables
        With MyCalculationVariables
            If .Component(0) * u1 <= 0 Then
                IsSignumChanged = True
            Else
                IsSignumChanged = False
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
        DrawPendulum()

    End Sub

    Private Sub DrawTrack()

        'The track of Pendulum1 is always on a circle and not interesting
        'MyBitmapGraphics.DrawLine(OldPosition1, Position1, Color.Red, 1)
        MyBmpGraphics.DrawLine(OldPosition2, Position2, MyColor, 1)

    End Sub

    Private Sub DrawPhaseportrait()
        Select Case TypeofPhasePortrait
            Case TypeofPhaseportraitEnum.TorusOrCylinder
                MyPicPhaseportrait.Refresh()
                MyPicPhaseportraitGraphics.DrawLine(New ClsMathpoint(u1, u2), New ClsMathpoint(u1 + v1 / 10, u2 + v2 / 10), Color.Blue, 1)
                MyBmpPhaseportraitGraphics.DrawPoint(New ClsMathpoint(u1, u2), MyColor, 1)
            Case TypeofPhaseportraitEnum.PoincareSection
                If IsSignumChanged Then
                    MyPicPhaseportraitGraphics.DrawPoint(New ClsMathpoint(u2, v2), MyColor, 2)
                End If
            Case Else
                'Draw only into PicPhaseportrait
                MyPicPhaseportraitGraphics.DrawPoint(New ClsMathpoint(u1, v1), Brushes.Blue, 1)
                MyPicPhaseportraitGraphics.DrawPoint(New ClsMathpoint(u2, v2), MyColor, 1)
        End Select

    End Sub

    Protected Overrides Function GetEnergy() As Decimal

        'This routine protocols the total Energy of the double pendulum
        'to have a control that it is constant
        'if that is not the case, the error of Runge Kutta Method is too big
        'the Zero level of the potential energy is set to y = -1
        Dim EKin As Decimal
        Dim EPot As Decimal
        Dim Etotal As Decimal

        With MyCalculationConstants
            'we set as norm m1 = 1, m2 = M
            'kinetic energy of m1: L1^2*v1^2/2
            EKin = CDec(Math.Pow(.Component(0) * v1, 2) / 2)

            'kinetic energy of m2: see math. doc.
            EKin += CDec(M * (Math.Pow(.Component(0) * v1, 2) +
                2 * .Component(0) * v1 * .Component(1) * v2 * Math.Cos(u1 - u2) +
                Math.Pow(.Component(1) * v2, 2)) / 2)

            'potential energy of m1 and m2: see math.doc.
            EPot = g * CDec((1 - .Component(0) * Math.Cos(u1)) * (1 + M) - M * .Component(1) * Math.Cos(u2))

            'Etotal in the possible interval of StartEnergyRange
            Etotal = Math.Min(EKin + EPot, StartEnergyRange.B)
            Etotal = Math.Max(Etotal, StartEnergyRange.A)

            Return EKin + EPot
        End With

    End Function

    Private Function F1(LocX As ClsNTupel) As Decimal

        'calculates next u1' = v1 = x.component(1)
        Return LocX.Component(1)

    End Function

    Private Function G1(LocX As ClsNTupel) As Decimal

        Dim Temp As Decimal

        With LocX
            'DeltaU = u1-u2
            Dim DeltaU As Decimal = .Component(0) - .Component(2)

            'L2*V2*V2 + L1*cos(DeltaU)*V1*V1
            Temp = CDec(MyCalculationConstants.Component(1) * Math.Pow(.Component(3), 2) +
                MyCalculationConstants.Component(0) * Math.Cos(DeltaU) * Math.Pow(.Component(1), 2))

            '*-Mu*sin(deltaU)
            Temp *= -Mu * CDec(Math.Sin(DeltaU))

            '+g*(Mu*cos(Deltau)*sin(U2)-sin(U1))
            Temp += g * CDec(Mu * Math.Cos(DeltaU) * Math.Sin(.Component(2)) - Math.Sin(.Component(0)))

            Dim Check1 As Decimal = CDec(Math.Cos(DeltaU) * Math.Sin(.Component(2)))
            Dim Check2 As Decimal = CDec(Math.Sin(.Component(0)))

            'Divisor L1*(1-Mu*cos2(Deltau))
            Temp /= MyCalculationConstants.Component(0) * (1 - Mu * CDec(Math.Pow(Math.Cos(DeltaU), 2)))
        End With

        Return Temp

    End Function

    Private Function F2(LocX As ClsNTupel) As Decimal

        'calculates next u2' = v2 = x.component(3)
        Return LocX.Component(3)
    End Function

    Private Function G2(LocX As ClsNTupel) As Decimal

        Dim Temp As Decimal

        With LocX
            'calculates next v2' = see math.doc.
            Dim DeltaU As Decimal = .Component(0) - .Component(2)

            'L1*V1*V1 + Mu*L2*cos(DeltaU)*V2*V2
            Temp = CDec(MyCalculationConstants.Component(0) * Math.Pow(.Component(1), 2) +
                Mu * MyCalculationConstants.Component(1) * Math.Cos(DeltaU) * Math.Pow(.Component(3), 2))

            '*sin(deltaU)
            Temp *= CDec(Math.Sin(DeltaU))

            '+g*(Mu*cos(Deltau)*sin(U1)-sin(U2))
            Temp += g * CDec(Math.Cos(DeltaU) * Math.Sin(.Component(0)) - Math.Sin(.Component(2)))

            Dim Check1 As Decimal = CDec(Math.Cos(DeltaU) * Math.Sin(.Component(2)))
            Dim Check2 As Decimal = CDec(Math.Sin(.Component(0)))

            'Divisor L2*(1-Mu*cos2(Deltau))
            Temp /= MyCalculationConstants.Component(1) * (1 - Mu * CDec(Math.Pow(Math.Cos(DeltaU), 2)))
        End With

        Return Temp

    End Function

    Private Function G1Test(LocX As ClsNTupel) As Decimal

        'This function corresponds to a simple Thread Pendulum
        Dim Temp As Decimal

        With LocX

            Temp = -g * CDec(Math.Sin(.Component(0)) / MyCalculationConstants.Component(0))

        End With

        Return Temp

    End Function

    Private Function G2Test(LocX As ClsNTupel) As Decimal

        'This function corresponds to a simple Thread Pendulum
        Dim Temp As Decimal

        With LocX

            Temp = -g * CDec(Math.Sin(.Component(2)) / MyCalculationConstants.Component(1))

        End With

        Return Temp

    End Function
End Class
