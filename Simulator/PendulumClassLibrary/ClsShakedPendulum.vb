'This class contains all properties and methods for the shaked pendulum
'See mathematical documentation

'important: this class works with mathematical coordinates
'the Instance of the GraphicTool transforms these in Pixel-Coordinates

'Status Checked

Public Class ClsShakedPendulum
    Inherits ClsPendulumAbstract

    Private ReadOnly ValueParameter(3) As ClsGeneralParameter

    'Time
    Private t As Decimal

    'Frequency of the shaker
    Private Omega As Decimal

    Private ReadOnly Origin As ClsMathpoint

    'SECTOR INITIALIZATION

    Public Sub New()

        Origin = New ClsMathpoint(0, 0)

        'Labels
        MyLabelPhasePortrait = LM.GetString("PhasePortrait") & ": -- "
        MyLabelProtocol = LM.GetString("Protocol") & ": u, v, Etot"

        MyValueParameterDefinition = New List(Of ClsGeneralParameter)

        'Inizialize all parameters - variables and constants
        'Tag is the Number of the Label in the Pendulum Form

        'A
        ValueParameter(0) = New ClsGeneralParameter(1, "A", ShrinkedInterval,
                                                    ClsGeneralParameter.TypeOfParameterEnum.Constant, ShrinkFactor / 2)
        MyValueParameterDefinition.Add(ValueParameter(0))

        'L
        ValueParameter(1) = New ClsGeneralParameter(2, "l", New ClsInterval(CDec(0.05), CDec(0.98)),
                                                    ClsGeneralParameter.TypeOfParameterEnum.Constant, CDec(0.5))
        MyValueParameterDefinition.Add(ValueParameter(1))

        'x - position of the shaker
        ValueParameter(2) = New ClsGeneralParameter(3, "x", ShrinkedInterval,
                                                    ClsGeneralParameter.TypeOfParameterEnum.Variable, CDec(ShrinkFactor / 2))
        MyValueParameterDefinition.Add(ValueParameter(2))

        'Phi
        ValueParameter(3) = New ClsGeneralParameter(4, "Phi", New ClsInterval(-CDec(Math.PI), CDec(Math.PI)),
                                                    ClsGeneralParameter.TypeOfParameterEnum.Variable, CDec(Math.PI / 4))
        MyValueParameterDefinition.Add(ValueParameter(3))

        'The interval for the Additional Parameter sets the range of the TrackBar AdditionalParameter
        'and the Tag its Value of the Additional Parameter as Standard
        MyAdditionalParameterValue = 2  'that means Omega on the left side
        MyAdditionalParameter = New ClsGeneralParameter(MyAdditionalParameterValue,
                                                      LM.GetString("FrequencyRatio"), New ClsInterval(CDec(0.2), 10),
                                                      ClsGeneralParameter.TypeOfParameterEnum.DS)

        'Vectors
        'We have one constant parameters A = .Component(0), l = .Component(1)
        MyCalculationConstants = New ClsNTupel(1)

        'We have one variable parameter: x = .Component(0), Phi = .Components(1)
        MyCalculationVariables = New ClsNTupel(1)

    End Sub

    Public Overrides Function GetCopy() As IPendulum
        Return New ClsShakedPendulum
    End Function

    'SECTOR CALCULATION AND DRAWING

    Public Overrides Function GetAddParameterValue(AddParameter As Integer) As Decimal

        'This is to adjust the value of TrbAdditionalParameter
        Dim Temp As Decimal = CDec(AddParameter / 5)
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

            'Shaking Pendulum
            .DrawLine(Origin, Position1, Color.Blue, 2)
            .FillCircle(Position1, CDec(0.02), Brushes.Blue)

            'Vertical Pendulum
            .DrawLine(Position1, Position2, MyColor, 2)
            .FillCircle(Position2, CDec(0.02), MyColor)

        End With

    End Sub

    'Sets the position of the Pendulums
    Protected Overrides Sub SetPosition()

        'See math. doc.
        With Position1
            .X = MyCalculationVariables.Component(0)
            .Y = 0
        End With

        With Position2
            .X = Position1.X + MyCalculationConstants.Component(1) * CDec(Math.Sin(MyCalculationVariables.Component(1)))
            .Y = -MyCalculationConstants.Component(1) * CDec(Math.Cos(MyCalculationVariables.Component(1)))
        End With

    End Sub

    Protected Overrides Sub SetPhasePortraitParameters()
        Select Case TypeofPhasePortrait
            Case TypeofPhaseportraitEnum.TorusOrCylinder
                MyLabelPhasePortrait = LM.GetString("PhasePortrait") & ": x, Phi. Tangent: x', Phi'"
                UInterval = New ClsInterval(-1, 1)
                VInterval = New ClsInterval(CDec(-Math.PI), CDec(Math.PI))
            Case TypeofPhaseportraitEnum.PoincareSection
                MyLabelPhasePortrait = LM.GetString("PhasePortrait") & ": x = 0, Phi, Phi'"
                UInterval = New ClsInterval(CDec(-Math.PI), CDec(Math.PI))
                VInterval = New ClsInterval(-10, 10)
            Case Else 'independent
                MyLabelPhasePortrait = LM.GetString("PhasePortrait") & ": Blue: x, x'. Red: Phi, Phi'"
                UInterval = New ClsInterval(CDec(-Math.PI), CDec(Math.PI))
                VInterval = New ClsInterval(-10, 10)
        End Select
    End Sub

    Protected Overrides Sub SetAdditionalParameters()
        Omega = CDec(GetAddParameterValue(MyAdditionalParameterValue) *
            Math.Sqrt(g / MyCalculationConstants.Component(1)))

        If MyIsMainDS Then
            ResetIteration()
            SetStartEnergyRange()
        End If

        SetPosition()

    End Sub

    Protected Overrides Sub SetStartEnergyRange()

        Dim Emin As Decimal
        Dim Emax As Decimal

        With MyCalculationConstants
            'after experiments
            Emin = 0
            Emax = 30
        End With
        MyStartEnergyRange = New ClsInterval(Emin, Emax)

    End Sub

    'SECTOR SETSTARTPARAMETER
    Public Overrides Sub SetAndDrawStartparameter1(Mouseposition As Point)

        Dim ActualPosition As ClsMathpoint = PicGraphics.PixelToMathpoint(Mouseposition)

        With ActualPosition

            Dim A As Decimal = CDec(Math.Max(ShrinkedInterval.A * 0.6, Math.Min(.X, ShrinkedInterval.B * 0.6)))

            'Set parameters
            t = 0
            MyCalculationConstants.Component(0) = A
            MyCalculationVariables.Component(0) = A

            SetPosition()

            SetStartEnergyRange()

            'Draw pendulum
            DrawPendulum()

            'Runge Kutta Parameters
            'u1, v1 is not used because the position of the shaker is calculated directly
            u1 = 0
            v1 = 0

        End With

    End Sub

    Public Overrides Sub SetAndDrawStartparameter2(Mouseposition As Point)

        Dim ActualPosition As ClsMathpoint = PicGraphics.PixelToMathpoint(Mouseposition)

        With ActualPosition

            Dim DeltaX As Decimal = .X - Position1.X
            Dim DeltaY As Decimal = .Y - Position1.Y

            'L should be maximal 0.98 to be visible and L minimal 0.1
            Dim L As Decimal = CDec(Math.Max(0.1, Math.Min(0.98 - MyCalculationConstants.Component(0),
                                                           Math.Sqrt(DeltaX * DeltaX + DeltaY * DeltaY))))

            Dim Phi As Decimal = ClsMathHelperPendulum.GetAngle(DeltaX, DeltaY)
            MyCalculationVariables.Component(1) = ClsMathHelperPendulum.AngleInMinusPiAndPi(Phi)

            'Abs(x + L*sin(Phi)) should be maximal shrinkfactor to be visible
            'for symmetry reasons, we look at abs(phi) and abs(x)
            'and problematic is only the case, when sign(x) = sign(phi)
            If Math.Abs(.X + L * Math.Sin(Phi)) > ShrinkFactor And Math.Sign(Phi) = Math.Sign(u1) Then
                L = CDec(Math.Min(L, (1 - Math.Abs(u1)) / Math.Sin(Math.Abs(Phi))))
            Else
                'nothing, phi is to small and l < 0.98 is enough
            End If

            'Set parameters
            MyCalculationConstants.Component(1) = L

            SetPosition()

            SetStartEnergyRange()

            'Draw pendulum
            DrawPendulum()

            'Runge Kutta Parameters
            u2 = Phi
            v2 = 0

        End With

    End Sub

    Protected Overrides Sub SetDefaultUserData()

        'Standardvalues
        With MyCalculationConstants
            .Component(0) = ValueParameter(0).DefaultValue 'A
            .Component(1) = ValueParameter(1).DefaultValue 'L
        End With

        With MyCalculationVariables
            .Component(0) = ValueParameter(2).DefaultValue 'x
            .Component(1) = ValueParameter(3).DefaultValue 'Phi
            u2 = .Component(1)
            v2 = 0
        End With

        t = 0

        SetAdditionalParameters()
        'This will also ResetIteration, SetStartEnergyRange, SetPosition

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
            .Component(0) = 0
            .Component(1) = 0
            .Component(2) = u2
            .Component(3) = v2
        End With

        'First Runge Kutta Step
        'k1: belongs to u1' and F1 - not used here
        'k2: belongs to u2' and F2
        'h1: belongs to v1' abd G1 - not used here
        'h2: belongs to v2' and G2
        'k,h.component(i): step i-1 in Runge Kutta
        k1.Component(0) = 0
        k2.Component(0) = F2(x)
        If IsTestMode Then
            h1.Component(0) = 0
            h2.Component(0) = G2Test(x)
        Else
            h1.Component(0) = 0
            h2.Component(0) = G2(x)
        End If

        'Set x2n
        'd: global Runge Kutta
        With x
            .Component(0) = 0
            .Component(1) = 0
            .Component(2) = u2 + d * k2.Component(0) / 2
            .Component(3) = v2 + d * h2.Component(0) / 2
        End With

        'Second Runge Kutta Step
        k1.Component(1) = 0
        k2.Component(1) = F2(x)
        If IsTestMode Then
            h1.Component(1) = 0
            h2.Component(1) = G2Test(x)
        Else
            h1.Component(1) = 0
            h2.Component(1) = G2(x)
        End If

        'Set x3n
        With x
            .Component(0) = 0
            .Component(1) = 0
            .Component(2) = u2 + d * k2.Component(1) / 2
            .Component(3) = v2 + d * h2.Component(1) / 2
        End With

        'Third Runge Kutta Step
        k1.Component(2) = 0
        k2.Component(2) = F2(x)
        If IsTestMode Then
            h1.Component(2) = 0
            h2.Component(2) = G2Test(x)
        Else
            h1.Component(2) = 0
            h2.Component(2) = G2(x)
        End If

        'Set x4n
        With x
            .Component(0) = 0
            .Component(1) = 0
            .Component(2) = u2 + d * k2.Component(2)
            .Component(3) = v2 + d * h2.Component(2)
        End With

        'Fourth Runge Kutta Step
        k1.Component(3) = 0
        k2.Component(3) = F2(x)
        If IsTestMode Then
            h1.Component(3) = 0
            h2.Component(3) = G2Test(x)
        Else
            h1.Component(3) = 0
            h2.Component(3) = G2(x)
        End If

        t += d

        'Update u1, v1, u2, v2
        u1 = CDec(MyCalculationConstants.Component(0) * Math.Cos(Omega * t))
        v1 = -CDec(MyCalculationConstants.Component(0) * Math.Sin(Omega * t))
        u2 += d * (k2.Component(0) + 2 * k2.Component(1) + 2 * k2.Component(2) + k2.Component(3)) / 6
        v2 += d * (h2.Component(0) + 2 * h2.Component(1) + 2 * h2.Component(2) + h2.Component(3)) / 6

        u2 = ClsMathHelperPendulum.AngleInMinusPiAndPi(u2)

        'New Values to MyVariables
        'for Poincare Section
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

        'The track of the shaking Pendulum is always on a straight line and not interesting
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

        'This routine protocols the total Energy of the shaked pendulum
        'it will normally increase if this pendulum takes over energy from the shaking pendulum

        Dim EKin As Decimal
        Dim EPot As Decimal
        Dim Etotal As Decimal

        With MyCalculationConstants

            EKin = CDec(Math.Pow(.Component(0) * Omega * Math.Sin(Omega * t), 2))
            EKin -= CDec(2 * .Component(0) * Omega * Math.Sin(Omega * t) * .Component(1) * v2 * Math.Cos(u2))
            EKin += CDec(Math.Pow(.Component(1) * v2, 2))
            EKin /= 2

            'potential energy: see math.doc.
            EPot = -g * CDec(Math.Cos(u2)) * .Component(1)

            'Etotal in the possible interval of StartEnergyRange
            Etotal = Math.Min(EKin + EPot, StartEnergyRange.B)
            Etotal = Math.Max(Etotal, StartEnergyRange.A)

            Return EKin + EPot
        End With

    End Function

    Private Function F2(LocX As ClsNTupel) As Decimal

        'calculates next u2' = v2 = x.component(3)
        Return LocX.Component(3)
    End Function

    Private Function G2(LocX As ClsNTupel) As Decimal

        Dim Temp As Decimal

        With LocX

            Temp = CDec(MyCalculationConstants.Component(0) * Math.Pow(Omega, 2) / MyCalculationConstants.Component(1))
            Temp *= CDec(Math.Cos(Omega * t) * Math.Cos(.Component(2)))
            Temp -= CDec(g / MyCalculationConstants.Component(1) * Math.Sin(.Component(2)))

        End With

        Return Temp

    End Function

    Private Function G2Test(LocX As ClsNTupel) As Decimal

        'This function corresponds to a simple Thread Pendulum
        Dim Temp As Decimal

        With LocX

            Temp = -g * CDec(Math.Sin(.Component(2)) / MyCalculationConstants.Component(0))

        End With

        Return Temp

    End Function

End Class
