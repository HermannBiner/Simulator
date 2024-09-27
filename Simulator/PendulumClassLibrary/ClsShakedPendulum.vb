'This class contains all properties and methods for the shaked pendulum
'See mathematical documentation

'important: this class works with mathematical coordinates
'the Instance of the GraphicTool transforms these in Pixel-Coordinates

'Status Checked

Imports System.Net

Public Class ClsShakedPendulum
    Inherits ClsPendulumAbstract


    Private ValueParameter(2) As ClsGeneralParameter

    'Spring constant of the shaking pendulum
    'set as additional parameter
    Private MyD As Decimal

    'Mass of the horizontal pendulum - set after experiments
    Const MSpring As Decimal = 10

    'Mass m
    Const m As Decimal = 1

    'Max Interval of the shaking pendulum
    Const MaxX As Decimal = CDec(0.95)


    'SECTOR INITIALIZATION

    Public Sub New()

        Y0 = 0

        'Labels
        MyLabelPhasePortrait = FrmMain.LM.GetString("PhasePortrait") & ": -- "
        MyLabelProtocol = FrmMain.LM.GetString("Protocol") & ": u1, v1, u2, v2, Etot"

        MyValueParameterDefinition = New List(Of ClsGeneralParameter)

        'Inizialize all parameters - variables and constants
        'Tag is the Number of the Label in the Pendulum Form

        'L
        ValueParameter(0) = New ClsGeneralParameter(1, "l", New ClsInterval(CDec(0.05), CDec(0.98)),
                                                    ClsGeneralParameter.TypeOfParameterEnum.Value, CDec(0.5))
        MyValueParameterDefinition.Add(ValueParameter(0))

        'x
        ValueParameter(1) = New ClsGeneralParameter(2, "x", New ClsInterval(-MaxX, MaxX),
                                                    ClsGeneralParameter.TypeOfParameterEnum.Value, MaxX / 2)
        MyValueParameterDefinition.Add(ValueParameter(1))

        'Phi
        ValueParameter(2) = New ClsGeneralParameter(3, "Phi", New ClsInterval(-CDec(Math.PI), CDec(Math.PI)),
                                                    ClsGeneralParameter.TypeOfParameterEnum.Value, CDec(Math.PI / 4))
        MyValueParameterDefinition.Add(ValueParameter(2))

        'The interval for the Additional Parameter sets the range of the TrackBar AdditionalParameter
        'and the Tag its Value of the Additional Parameter as Standard
        MyAdditionalParameterValue = 60  'that means MyM in the middle
        MyAdditionalParameter = New ClsGeneralParameter(MyAdditionalParameterValue,
                                                      FrmMain.LM.GetString("SpringConstant"), New ClsInterval(20, 100),
                                                      ClsGeneralParameter.TypeOfParameterEnum.Formula)
        MyD = MyAdditionalParameterValue

        'Vectors
        'We have one constant parameters l = .Component(0)
        MyCalculationConstants = New ClsNTupel(0)

        'We have one variable parameter: x = MyVariables.Components(0), Phi = MyVariables.Components(1)
        MyCalculationVariables = New ClsNTupel(1)
    End Sub

    'SECTOR CALCULATION AND DRAWING

    Public Overrides Function GetAddParameterValue(AddParameter As Integer) As Decimal

        Dim Temp As Decimal = AddParameter

        Return Temp

    End Function

    Protected Overrides Sub DrawCoordinateSystem()
        'x-Axis
        BmpGraphics.DrawLine(New ClsMathpoint(-1, Y0), New ClsMathpoint(1, Y0), Color.Aquamarine, 1)
        'y-Axis
        BmpGraphics.DrawLine(New ClsMathpoint(0, -1), New ClsMathpoint(0, 1), Color.Aquamarine, 1)
    End Sub

    Protected Overrides Sub DrawPendulums()

        With PicGraphics

            'Clear Graphic
            MyPicDiagram.Refresh()

            'Shaking Pendulum
            .DrawLine(New ClsMathpoint(-1, 0), Position1, Color.Red, 2)
            .FillCircle(Position1, CDec(0.02), Brushes.Red)

            'Vertical Pendulum
            .DrawLine(Position1, Position2, Color.Green, 2)
            .FillCircle(Position2, CDec(0.02), Brushes.Green)

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
            .X = Position1.X + MyCalculationConstants.Component(0) * CDec(Math.Sin(MyCalculationVariables.Component(1)))
            .Y = -MyCalculationConstants.Component(0) * CDec(Math.Cos(MyCalculationVariables.Component(1)))
        End With

    End Sub

    Protected Overrides Sub SetPhasePortraitParameters()
        Select Case TypeofPhasePortrait
            Case TypeofPhaseportraitEnum.TorusOrCylinder
                MyLabelPhasePortrait = FrmMain.LM.GetString("PhasePortrait") & ": x, Phi. Tangent: x', Phi'"
                UInterval = New ClsInterval(-1, 1)
                VInterval = New ClsInterval(CDec(-Math.PI), CDec(Math.PI))
            Case TypeofPhaseportraitEnum.PoincareSection
                MyLabelPhasePortrait = FrmMain.LM.GetString("PhasePortrait") & ": x = 0, Phi, Phi'"
                UInterval = New ClsInterval(CDec(-Math.PI), CDec(Math.PI))
                VInterval = New ClsInterval(-10, 10)
            Case Else 'independent
                MyLabelPhasePortrait = FrmMain.LM.GetString("PhasePortrait") & ": Red: x, x'. Green: Phi, Phi'"
                UInterval = New ClsInterval(CDec(-Math.PI), CDec(Math.PI))
                VInterval = New ClsInterval(-10, 10)
        End Select
    End Sub

    Protected Overrides Sub SetAdditionalParameters()
        MyD = GetAddParameterValue(MyAdditionalParameterValue)
        SetPosition()
        ResetIteration()
        SetStartEnergyRange()
    End Sub

    Protected Overrides Sub SetStartEnergyRange()

        Dim Emin As Decimal
        Dim Emax As Decimal

        With MyCalculationConstants
            Emin = -m * g * .Component(0)
            Emax = MyD / 2 + m * g * .Component(0)
        End With
        StartEnergyRange = New ClsInterval(Emin, Emax)

    End Sub

    'SECTOR SETSTARTPARAMETER
    Public Overrides Sub SetAndDrawStartparameter1(Mouseposition As Point)

        Dim ActualPosition As ClsMathpoint = PicGraphics.PixelToMathpoint(Mouseposition)

        With ActualPosition

            Dim x As Decimal = CDec(Math.Max(-MaxX, Math.Min(.X, MaxX)))

            'Set parameters
            MyCalculationVariables.Component(0) = x

            SetPosition()

            SetStartEnergyRange()

            'Draw pendulum
            DrawPendulums()

            'Runge Kutta Parameters
            u1 = x
            v1 = 0

        End With

    End Sub

    Public Overrides Sub SetAndDrawStartparameter2(Mouseposition As Point)

        Dim ActualPosition As ClsMathpoint = PicGraphics.PixelToMathpoint(Mouseposition)

        With ActualPosition

            Dim DeltaX As Decimal = .X - Position1.X
            Dim DeltaY As Decimal = .Y - Position1.Y

            'L should be maximal 0.98 to be visible and L minimal 0.1
            Dim L As Decimal = CDec(Math.Max(0.1, Math.Min(0.98, Math.Sqrt(DeltaX * DeltaX + DeltaY * DeltaY))))

            Dim Phi As Decimal = MathHelper.GetAngle(DeltaX, DeltaY)
            MyCalculationVariables.Component(1) = MathHelper.AngleInMinusPiAndPi(Phi)

            'Abs(x + L*sin(Phi)) should be maximal 0.98 to be visible
            'for symmetry reasons, we look at abs(phi) and abs(x)
            'and problematic is only the case, when sign(x) = sign(phi)
            If Math.Abs(Phi) > 1 - MaxX And Math.Sign(Phi) = Math.Sign(u1) Then
                L = CDec(Math.Min(L, (1 - Math.Abs(u1)) / Math.Sin(Math.Abs(Phi))))
            Else
                'nothing, phi is to small and l < 0.98 is enough
            End If

            'Set parameters
            MyCalculationConstants.Component(0) = L

            SetPosition()

            SetStartEnergyRange()

            'Draw pendulum
            DrawPendulums()

            'Runge Kutta Parameters
            u2 = Phi
            v2 = 0

        End With

    End Sub

    Protected Overrides Sub SetDefaultUserData()

        'Standardvalues
        With MyCalculationConstants
            .Component(0) = ValueParameter(0).DefaultValue 'L
        End With

        With MyCalculationVariables
            .Component(0) = ValueParameter(1).DefaultValue 'x
            .Component(1) = ValueParameter(2).DefaultValue 'Phi
            u1 = .Component(0)
            v1 = 0
            u2 = .Component(1)
            v2 = 0
        End With

        SetStartEnergyRange()
        SetPosition()

    End Sub

    'SECTOR ITERATION

    Protected Overrides Sub IterationStep(TestMode As Boolean)

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

        u2 = MathHelper.AngleInMinusPiAndPi(u2)

        'New Values to MyVariables
        With MyCalculationVariables
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

        'The track of the shaking Pendulum is always on a straight line and not interesting
        BmpGraphics.DrawLine(OldPosition2, Position2, Color.Green, 1)
        MyPicDiagram.Invalidate()

    End Sub

    Private Sub DrawPhaseportrait()
        Select Case TypeofPhasePortrait
            Case TypeofPhaseportraitEnum.TorusOrCylinder
                MyPicPhaseportrait.Refresh()
                PicPhaseportraitGraphics.DrawLine(New ClsMathpoint(u1, u2), New ClsMathpoint(u1 + v1 / 10, u2 + v2 / 10), Color.Red, 1)
                BmpPhaseportraitGraphics.DrawPoint(New ClsMathpoint(u1, u2), Brushes.Green, 1)
            Case TypeofPhaseportraitEnum.PoincareSection
                If SignumChanged Then
                    PicPhaseportraitGraphics.DrawPoint(New ClsMathpoint(u2, v2), Brushes.Green, 2)
                End If
            Case Else
                'Draw only into PicPhaseportrait
                PicPhaseportraitGraphics.DrawPoint(New ClsMathpoint(u1, v1), Brushes.Red, 1)
                PicPhaseportraitGraphics.DrawPoint(New ClsMathpoint(u2, v2), Brushes.Green, 1)
        End Select

    End Sub

    Protected Overrides Function GetEnergy() As Decimal

        'This routine protocols the total Energy of the shaked pendulum
        'it will normally increase if this pendulum takes over energy from the shaking pendulum

        Dim EKin As Decimal
        Dim EPot As Decimal
        Dim Etotal As Decimal

        With MyCalculationConstants

            EKin = m * (v1 * v1 + 2 * v1 * v2 * CDec(Math.Cos(u2)) * .Component(0) + CDec(Math.Pow(v2 * .Component(0), 2))) / 2
            EKin += MyD * v1 * v1 / 2

            'potential energy: see math.doc.
            EPot = MyD * u1 * u1 / 2 - m * g * CDec(Math.Cos(u2)) * .Component(0)

            'Etotal in the possible interval of StartEnergyRange
            Etotal = Math.Min(EKin + EPot, StartEnergyRange.B)
            Etotal = Math.Max(Etotal, StartEnergyRange.A)

            Return EKin + EPot
        End With

    End Function

    Private Function F1(x As ClsNTupel) As Decimal

        'calculates next u1' = v1 = x.component(1)
        Return x.Component(1)

    End Function

    Private Function G1(x As ClsNTupel) As Decimal

        Dim Temp As Decimal

        With x

            Temp = CDec(Math.Pow(.Component(3), 2) * MyCalculationConstants.Component(0) * Math.Sin(.Component(2)))
            Temp += g * CDec(Math.Sin(.Component(2) * Math.Cos(.Component(2))))
            Temp -= MyD * .Component(0)
            Temp /= m + MSpring - CDec(Math.Pow(Math.Cos(.Component(2)), 2))

        End With

        Return Temp

    End Function

    Private Function F2(x As ClsNTupel) As Decimal

        'calculates next u2' = v2 = x.component(3)
        Return x.Component(3)
    End Function

    Private Function G2(x As ClsNTupel) As Decimal

        Dim Temp As Decimal

        With x

            Temp = MyD * .Component(0) * CDec(Math.Cos(.Component(2)))
            Temp -= g * CDec(Math.Sin(.Component(2))) * (m + MSpring)
            Temp -= CDec(Math.Pow(.Component(3), 2) * MyCalculationConstants.Component(0) * Math.Sin(.Component(2)) * Math.Cos(.Component(2)))
            Temp /= MyCalculationConstants.Component(0) * (m + MSpring - CDec(Math.Pow(Math.Cos(.Component(2)), 2)))

        End With

        Return Temp

    End Function

    Private Function G1Test(x As ClsNTupel) As Decimal

        'This function corresponds to a simple Spring Pendulum
        Dim Temp As Decimal

        With x

            Temp = -MyD * u1 / MSpring

        End With

        Return Temp

    End Function

    Private Function G2Test(x As ClsNTupel) As Decimal

        'This function corresponds to a simple Thread Pendulum
        Dim Temp As Decimal

        With x

            Temp = -g * CDec(Math.Sin(.Component(2)) / MyCalculationConstants.Component(0))

        End With

        Return Temp

    End Function

End Class
