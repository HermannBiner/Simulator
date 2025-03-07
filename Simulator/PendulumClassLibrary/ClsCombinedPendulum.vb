﻿'This class contains all properties and methods for a combined pendulum
'oscillating as spring pendulum and thread pendulum
'See mathematical documentation

'important: this class works with mathematical coordinates
'the Instance of the GraphicTool transforms these in Pixel-Coordinates

'Status Checked

Public Class ClsCombinedPendulum
    Inherits ClsPendulumAbstract

    Private ReadOnly ValueParameter(1) As ClsGeneralParameter

    'Frequency of the Spring Pendulum alone
    'set as additional Parameter
    Private Omega As Decimal

    Private Origin As ClsMathpoint

    'Length of unstressed Spring - l0 in math.doc.
    Const L0 As Decimal = CDec(0.5)

    'Minimal length of the spring pendulum
    Const Lmin As Decimal = CDec(0.05)

    Public Sub New()

        Origin = New ClsMathpoint(0, 0)

        MyLabelProtocol = LM.GetString("Protocol") & ": u1, v1, u2, v2, Etot"

        'The interval for the Additional Parameter sets the range of the TrackBar AdditionalParameter
        'and the Tag its Value of the Additional Parameter as Standard

        'Omega has to be bigger than ... see math. doc.
        Dim LowerLimitOmega As Integer = CInt(Math.Ceiling(Math.Max(Math.Sqrt(g / (1 - L0)), Math.Sqrt(g / L0))))

        MyAdditionalParameterValue = LowerLimitOmega + 5
        MyAdditionalParameter = New ClsGeneralParameter(MyAdditionalParameterValue,
                                                      LM.GetString("SpringPendulumFrequency"),
                                                      New ClsInterval(LowerLimitOmega, LowerLimitOmega + 10),
                                                      ClsGeneralParameter.TypeOfParameterEnum.DS)

        MyValueParameterDefinition = New List(Of ClsGeneralParameter)

        'Inizialize all parameters
        'ID is the Number of the Label in the Pendulum Form
        'L
        ValueParameter(0) = New ClsGeneralParameter(1, "L", New ClsInterval(Lmin, CDec(2 - Y0)),
                                                    ClsGeneralParameter.TypeOfParameterEnum.Variable, L0)
        MyValueParameterDefinition.Add(ValueParameter(0))

        'Phi
        ValueParameter(1) = New ClsGeneralParameter(2, "Phi", New ClsInterval(-CDec(Math.PI), CDec(Math.PI)),
                                                    ClsGeneralParameter.TypeOfParameterEnum.Variable, CDec(Math.PI / 6))
        MyValueParameterDefinition.Add(ValueParameter(1))

        'We have two variable parameters: L = MyVariables.Components(0), Phi = MyVariables.components(1)
        MyCalculationVariables = New ClsNTupel(1)

    End Sub

    Public Overrides Function GetCopy() As IPendulum
        Return New ClsCombinedPendulum
    End Function

    'SECTOR CALCULATION AND DRAWING

    Public Overrides Function GetAddParameterValue(AddParameter As Integer) As Decimal

        'This is to adjust the value of TrbAdditionalParameter
        Dim Temp As Decimal = AddParameter
        Return Temp

    End Function

    Protected Overrides Sub DrawCoordinateSystem()

        'Show the equilibrium line where the spring compensates the gravitation
        Dim i As Integer

        'Parameters of the polar coordinates
        Dim r As Decimal
        Dim t As Decimal
        Dim NumberOfSteps As Integer = 500

        For i = 0 To NumberOfSteps
            t = ClsMathHelperPendulum.AngleInMinusPiAndPi(CDec(-Math.PI + i * 2 * Math.PI / NumberOfSteps))
            r = L0 + CDec(g * Math.Cos(t) / Math.Pow(Omega, 2))
            MyBmpGraphics.DrawPoint(New ClsMathpoint(r * CDec(Math.Sin(t)), Y0 - r * CDec(Math.Cos(t))), Brushes.Red, 1)
        Next

        'x-Axis
        MyBmpGraphics.DrawLine(New ClsMathpoint(MathInterval.A, 0),
                             New ClsMathpoint(MathInterval.B, 0), Color.Aquamarine, 1)
        'y0-Line
        MyBmpGraphics.DrawLine(New ClsMathpoint(MathInterval.A, Y0),
                             New ClsMathpoint(MathInterval.B, Y0), Color.Red, 1)
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

            'Pendulum
            .DrawLine(Origin, Position1, MyColor, 2)
            .FillCircle(Position1, CDec(0.02), MyColor)

        End With

    End Sub

    'Sets the position of the Pendulums
    Protected Overrides Sub SetPosition()
        'See math. doc.
        With Position1
            .X = MyCalculationVariables.Component(0) * CDec(Math.Sin(MyCalculationVariables.Component(1)))
            .Y = -MyCalculationVariables.Component(0) * CDec(Math.Cos(MyCalculationVariables.Component(1))) + Y0
        End With

    End Sub

    Protected Overrides Sub SetPhasePortraitParameters()

        Select Case TypeofPhasePortrait
            Case TypeofPhaseportraitEnum.TorusOrCylinder
                MyLabelPhasePortrait = LM.GetString("PhasePortrait") & ": l, Phi. Tangent: l', Phi'"
                UInterval = New ClsInterval(Lmin, 1)
                VInterval = New ClsInterval(CDec(-Math.PI), CDec(Math.PI))
            Case TypeofPhaseportraitEnum.PoincareSection
                MyLabelPhasePortrait = LM.GetString("PhasePortrait") & ": Phi = 0, l, l'"
                UInterval = New ClsInterval(Lmin, 1)
                VInterval = New ClsInterval(-10, 10)
            Case Else 'independent
                MyLabelPhasePortrait = LM.GetString("PhasePortrait") & ": Blue: l, l'. Red: Phi, Phi'"
                UInterval = New ClsInterval(CDec(-Math.PI), CDec(Math.PI))
                VInterval = New ClsInterval(-10, 10)
        End Select

    End Sub

    Protected Overrides Sub SetAdditionalParameters()

        Omega = GetAddParameterValue(MyAdditionalParameterValue)
        Y0 = CDec(g / Math.Pow(Omega, 2) / (1 - L0))
        Origin = New ClsMathpoint(0, Y0)

        If MyIsMainDS Then
            ResetIteration()
            SetStartEnergyRange()
        End If

        SetPosition()
    End Sub

    Protected Overrides Sub SetStartEnergyRange()

        Dim Emin As Decimal
        Dim Emax As Decimal

        Emin = -CDec(Math.Pow(g / Omega, 2)) / 2
        Emax = CDec(Math.Pow(Omega * (1 - Y0 - L0), 2)) / 2 + g * (L0 + 1 - Y0)

        MyStartEnergyRange = New ClsInterval(Emin, Emax)

    End Sub

    'SECTOR SETSTARTPARAMETER
    Public Overrides Sub SetAndDrawStartparameter1(Mouseposition As Point)

        Dim ActualPosition As ClsMathpoint = PicGraphics.PixelToMathpoint(Mouseposition)

        With ActualPosition

            .X = Math.Min(Math.Max(MathInterval.A * ShrinkFactor, .X), MathInterval.B * ShrinkFactor)
            .Y = Math.Min(Math.Max(MathInterval.A * ShrinkFactor, .Y), MathInterval.B * ShrinkFactor)
            .Y = .Y - Y0

            'L
            Dim LocL = Math.Min(ValueParameter(0).Range.B, CDec(Math.Sqrt(.X * .X + .Y * .Y)))
            MyCalculationVariables.Component(0) = LocL

            'Phi
            Dim Phi As Decimal = ClsMathHelperPendulum.GetAngle(.X, .Y)
            Phi = ClsMathHelperPendulum.AngleInMinusPiAndPi(Phi)

            MyCalculationVariables.Component(1) = Phi

            SetStartEnergyRange()

            SetPosition()

            'Draw pendulum
            DrawPendulum()

            'Runge Kutta
            u1 = LocL
            v1 = 0
            u2 = Phi
            v2 = 0

        End With

    End Sub

    Public Overrides Sub SetAndDrawStartparameter2(Mouseposition As Point)

        'nothing - the position is set on the first step
        'just implementing IPendulum
    End Sub


    'SECTOR ITERATION

    Public Overrides Sub IterationStep(IsTestMode As Boolean)

        'Performs one iteration step
        'and does all drawings
        'all startparameters are already set
        'that is Position
        'and Runge Kutta u1, v1, u2, v2

        'See math. doc. for the Details of this Implementation

        'Set OldPosition = Position
        With OldPosition1
            .X = Position1.X
            .Y = Position1.Y
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

        If u1 < Lmin Then
            u1 = Lmin
            v1 = -v1
        End If

        u2 = ClsMathHelperPendulum.AngleInMinusPiAndPi(u2)

        'New Values to MyVariables
        With MyCalculationVariables
            If .Component(1) * u2 <= 0 Then
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
        'and refresh PicDiagram
        DrawPendulum()

    End Sub

    Private Sub DrawTrack()

        'The track of Pendulum1 is always on a circle and not interesting
        'MyBitmapGraphics.DrawLine(OldPosition1, Position1, Color.Red, 1)
        MyBmpGraphics.DrawLine(OldPosition1, Position1, MyColor, 1)

    End Sub

    Private Sub DrawPhaseportrait()
        Select Case TypeofPhasePortrait
            Case TypeofPhaseportraitEnum.TorusOrCylinder
                MyPicPhaseportrait.Refresh()
                MyPicPhaseportraitGraphics.DrawLine(New ClsMathpoint(u1, u2), New ClsMathpoint(u1 + v1 / 10, u2 + v2 / 10), Color.Blue, 1)
                MyBmpPhaseportraitGraphics.DrawPoint(New ClsMathpoint(u1, u2), MyColor, 1)
            Case TypeofPhaseportraitEnum.PoincareSection
                If IsSignumChanged Then
                    MyPicPhaseportraitGraphics.DrawPoint(New ClsMathpoint(u1, v1), MyColor, 2)
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
        Dim ESpring As Decimal

        'we set as norm m = 1
        'kinetic energy of m: (v1^2 + l^2*v2^2)/2
        EKin = CDec(Math.Pow(v1, 2) + Math.Pow(u1 * v2, 2)) / 2

        'Potential Energy of m
        EPot = g * (L0 - CDec(u1 * Math.Cos(u2)))

        'potential energy of Spring Pendulum: see math.doc.
        'Spring constant id D, MyOmega = SQRT(D/m) => D = MyOmega^2
        ESpring = CDec(Math.Pow(Omega * (u1 - L0), 2)) / 2

        Return EKin + EPot + ESpring

    End Function

    Protected Overrides Sub SetDefaultUserData()
        'Standardvalues
        With MyCalculationVariables
            'Length of Pendulum l
            .Component(0) = ValueParameter(0).DefaultValue
            u1 = .Component(0)
            v1 = 0
            'Angle of Pendulum Phi
            .Component(1) = ValueParameter(1).DefaultValue
            u2 = .Component(1)
            v2 = 0
        End With

        'This will also set Omega, Y0, Origin
        'and ResetIteration, SetStartEnergyRange, SetPosition
        SetAdditionalParameters()

    End Sub

    Private Function F1(LocX As ClsNTupel) As Decimal

        'calculates next u1' = v1 = x.component(1)
        Return LocX.Component(1)

    End Function

    Private Function G1(LocX As ClsNTupel) As Decimal

        Dim Temp As Decimal


        With LocX
            Try
                Temp = .Component(0) * CDec(Math.Pow(.Component(3), 2))
                Temp += CDec(-Math.Pow(Omega, 2) * (.Component(0) - L0) + g * Math.Cos(.Component(2)))
            Catch ex As Exception
                MessageBox.Show("Overflow 0: " & .Component(0).ToString & ", 2: " & .Component(2).ToString & ", 3: " & .Component(3).ToString)
            End Try


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

    Private Function G1Test(LocX As ClsNTupel) As Decimal

        'This function corresponds to a simple Thread Pendulum
        Dim Temp As Decimal

        With LocX

            Temp = -g * CDec(Math.Sin(.Component(0))) / L0

        End With

        Return Temp

    End Function

    Private Function G2Test(LocX As ClsNTupel) As Decimal

        'This function corresponds to a simple Spring Pendulum
        Dim Temp As Decimal

        With LocX

            Temp = - .Component(2) * CDec(Math.Pow(Omega, 2))

        End With

        Return Temp

    End Function

End Class
