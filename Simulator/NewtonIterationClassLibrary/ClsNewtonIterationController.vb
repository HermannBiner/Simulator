﻿'This class contains the controller for the FrmNewtonIteration

'Status Checked

Imports System.Globalization
Imports System.Reflection

Public Class ClsNewtonIterationController

    Private DS As INewton

    Private MyForm As FrmNewtonIteration
    Private DiagramAreaSelector As ClsDiagramAreaSelector

    Public Sub New(Form As FrmNewtonIteration)
        MyForm = Form
        DiagramAreaSelector = New ClsDiagramAreaSelector
    End Sub

    Public Sub FillDynamicSystem()

        MyForm.CboFunction.Items.Clear()

        'Add the classes implementing IPolynom
        'to the Combobox CboFunction by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(INewton)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If types.Count > 0 Then
            Dim PolynomName As String
            For Each type In types

                'GetString is called with the option IsClass = true
                'That effects that - if there is no Entry in the Resource files LabelsEN, LabelsDE -
                'the name of the Class implementing an Interface is used as default
                'suppressing the extension "Cls"
                PolynomName = FrmMain.LM.GetString(type.Name, True)
                MyForm.CboFunction.Items.Add(PolynomName)
            Next

        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If
        MyForm.CboFunction.SelectedIndex = MyForm.CboFunction.Items.Count - 1

    End Sub

    Public Sub SetDS()

        'This sets the type of Polynom by Reflection

        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(INewton)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If MyForm.CboFunction.SelectedIndex >= 0 Then

            Dim SelectedName As String = MyForm.CboFunction.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If FrmMain.LM.GetString(type.Name, True) = SelectedName Then
                        DS = CType(Activator.CreateInstance(type), INewton)
                    End If
                Next
            End If

        End If

        InitializeMe()

        SetDefaultUserData()

        ResetIteration()

    End Sub

    Private Sub InitializeMe()

        With MyForm
            .CboN.Visible = DS.IsUseN
            .LblPower.Visible = DS.IsUseN

            .LblC.Visible = DS.IsUseC
            .LblI.Visible = DS.IsUseC
            .TxtA.Visible = DS.IsUseC
            .TxtB.Visible = DS.IsUseC

            DS.PicDiagram = .PicDiagram
            DS.ProcotolList = .LstProtocol
            DS.TxtElapsedTime = .TxtTime
            DS.TxtNumberOfSteps = .TxtSteps

            MyForm.CboN.SelectedIndex = 1

            'In the beginning, the ActualRanges as set to the 
            'defined ValueParameterRanges
            'later, the ActualRanges are changed by the DiagramAreaSelector
            DS.ActualXRange = DS.XValueParameter.Range
            DS.ActualYRange = DS.YValueParameter.Range

            If DS.IsShowBasin Then
                .BtnShowBasin.Visible = True
            Else
                .BtnShowBasin.Visible = False
            End If
        End With

        With DiagramAreaSelector
            .XRange = DS.XValueParameter.Range
            .YRange = DS.YValueParameter.Range
            .PicDiagram = MyForm.PicDiagram
            .TxtXMin = MyForm.TxtXMin
            .TxtXMax = MyForm.TxtXMax
            .TxtYMin = MyForm.TxtYMin
            .TxtYMax = MyForm.TxtYMax
        End With

        SetExponent()

    End Sub

    Public Sub SetDefaultUserData()

        With MyForm
            .TxtXMin.Text = DS.ActualXRange.A.ToString(CultureInfo.CurrentCulture)
            .TxtXMax.Text = DS.ActualXRange.B.ToString(CultureInfo.CurrentCulture)
            .TxtYMin.Text = DS.ActualYRange.A.ToString(CultureInfo.CurrentCulture)
            .TxtYMax.Text = DS.ActualYRange.B.ToString(CultureInfo.CurrentCulture)

            If DS.IsUseC Then
                .TxtA.Text = "0.5"
                .TxtB.Text = "1"
            End If
        End With
        SetDelta()

    End Sub

    Public Sub SetDelta()
        With MyForm
            If IsNumeric(.TxtXMax.Text) And IsNumeric(.TxtXMin.Text) Then
                .LblDeltaX.Text = "Delta = " & (CDec(.TxtXMax.Text) - CDec(.TxtXMin.Text)).ToString(CultureInfo.CurrentCulture)
            End If
            If IsNumeric(.TxtYMax.Text) And IsNumeric(.TxtYMin.Text) Then
                .LblDeltaY.Text = "Delta = " & (CDec(.TxtYMax.Text) - CDec(.TxtYMin.Text)).ToString(CultureInfo.CurrentCulture)
            End If
        End With
    End Sub

    Public Sub SetExponent()
        With DS
            If .IsUseN Then
                .N = CInt(MyForm.CboN.SelectedItem)
            Else
                .N = 3
            End If
        End With
        ResetIteration()
    End Sub

    Public Sub SetOptions()

        'The Option Shadowed together with Rotate or Conjugate is not the Standard
        With MyForm
            If .OptRotate.Checked Or .OptConjugate.Checked Then
                .OptBright.Checked = True
            Else
                .OptShaded.Checked = True
            End If
        End With
    End Sub

    Public Sub ResetIteration()

        With MyForm
            .BtnStart.Text = FrmMain.LM.GetString("Start")
            .BtnStart.Enabled = True
            .BtnReset.Enabled = True
        End With

        DS.ResetIteration()
    End Sub

    Public Async Sub StartIteration()

        If DS.IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            'the iteration was stopped or reset
            'and should start from the beginning
            If IsUserDataOK() Then
                ResetIteration()
                MyForm.BtnStart.Text = FrmMain.LM.GetString("Continue")
                DiagramAreaSelector.IsActivated = False
                With DS
                    SetExponent()
                    .IterationStatus = ClsDynamics.EnIterationStatus.Ready
                    .ActualXRange = New ClsInterval(CDec(MyForm.TxtXMin.Text), CDec(MyForm.TxtXMax.Text))
                    .ActualYRange = New ClsInterval(CDec(MyForm.TxtYMin.Text), CDec(MyForm.TxtYMax.Text))
                    DiagramAreaSelector.UserXRange = .ActualXRange
                    DiagramAreaSelector.UserYRange = .ActualYRange

                    If MyForm.OptConjugate.Checked Then
                        .UseMixing = INewton.EnMixing.Conjugate
                    ElseIf MyForm.OptRotate.Checked Then
                        .UseMixing = INewton.EnMixing.Rotate
                    Else
                        .UseMixing = INewton.EnMixing.None
                    End If

                    If MyForm.OptBright.Checked Then
                        .UseColor = INewton.EnColor.Bright
                    Else
                        .UseColor = INewton.EnColor.Shadowed
                    End If

                    If .IsUseC Then
                        'Check if c=a+ib is a complex number and part if the square ActualXRange X ActualYRange
                        'if not, the standard value is set: c=i
                        If IsCParameterOK() Then
                            .C = New ClsComplexNumber(CDbl(MyForm.TxtA.Text), CDbl(MyForm.TxtB.Text))
                        End If
                    End If

                End With
            Else
                'Message already generated
            End If
        End If

        If DS.IterationStatus = ClsDynamics.EnIterationStatus.Ready _
                Or DS.IterationStatus = ClsDynamics.EnIterationStatus.Interrupted Then
            DS.IterationStatus = ClsDynamics.EnIterationStatus.Running

            With MyForm
                .BtnStart.Enabled = False
                .BtnReset.Enabled = False
                .ChkProtocol.Enabled = False
                .BtnDefault.Enabled = False
                .BtnShowBasin.Enabled = False
            End With

            Await DS.GenerateImage()

        End If

        If DS.IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            With MyForm
                .BtnStart.Enabled = True
                .BtnReset.Enabled = True
                .ChkProtocol.Enabled = True
                .BtnDefault.Enabled = True
                .BtnShowBasin.Enabled = True
                .BtnStart.Text = FrmMain.LM.GetString("Start")
            End With
            DiagramAreaSelector.IsActivated = True
        End If

    End Sub

    Public Sub StopIteration()

        'the iteration was running and is interrupted
        DS.IterationStatus = ClsDynamics.EnIterationStatus.Interrupted
        'the iteration is stopoped by reset the iteration
        With MyForm
            .BtnStart.Enabled = True
            .BtnReset.Enabled = True
            .ChkProtocol.Enabled = True
            .BtnDefault.Enabled = True
        End With
    End Sub

    'CHECK USER RANGES AND SET X- AND Y- RANGE

    Private Function IsUserDataOK() As Boolean

        With MyForm
            Dim CheckXUserData As New ClsCheckUserData(.TxtXMin, .TxtXMax, DS.XValueParameter.Range)
            Dim CheckYUserData As New ClsCheckUserData(.TxtYMin, .TxtYMax, DS.YValueParameter.Range)

            Return CheckXUserData.IsIntervalAllowed And CheckYUserData.IsIntervalAllowed
        End With

    End Function

    'Checks the Parameter C
    Private Function IsCParameterOK() As Boolean

        With MyForm
            'The parameter c has to be in the same area as the z-Values
            Dim CheckParameterA As New ClsCheckUserData(.TxtA, DS.XValueParameter.Range)
            Dim CheckParameterB As New ClsCheckUserData(.TxtB, DS.YValueParameter.Range)

            Return CheckParameterA.IsTxtValueAllowed And CheckParameterB.IsTxtValueAllowed
        End With

    End Function

    Public Sub ShowBasin()
        'Shows the approximated basin(1)
        'that is an area where |Np'(z)|<1

        DiagramAreaSelector.IsActivated = False

        SetExponent()

        Dim XInterval = New ClsInterval(CDec(0), CDec(2))
        Dim YInterval = New ClsInterval(CDec(-1), CDec(1))
        Dim MyGraphics = New ClsGraphicTool(MyForm.PicDiagram, XInterval, YInterval)

        Const StepWide As Double = 0.001

        MyGraphics.Clear(Color.White)

        'Draws the coordinate system and the circles
        MyGraphics.DrawLine(New ClsMathpoint(XInterval.A, 0), New ClsMathpoint(XInterval.B, 0),
            Color.Black, 1)
        MyGraphics.DrawLine(New ClsMathpoint(0, YInterval.A), New ClsMathpoint(0, YInterval.B),
                        Color.Black, 1)
        MyGraphics.DrawCircle(New ClsMathpoint(1, 0), 1, Color.Blue, 1)
        MyGraphics.DrawCircle(New ClsMathpoint(1, 0), CDec(1 - 1 / Math.Pow(2, 1 / DS.N)),
                                  Color.Green, 1)
        MyGraphics.DrawPoint(New ClsMathpoint(1, 0), Brushes.Black, 2)

        Dim Asymptote As New ClsMathpoint(CDec(2 * Math.Cos(Math.PI / (2 * DS.N))), CDec(2 * Math.Sin(Math.PI / (2 * DS.N))))
        MyGraphics.DrawLine(New ClsMathpoint(0, 0), Asymptote, Color.Green, 1)
        Asymptote.Y = -Asymptote.Y
        MyGraphics.DrawLine(New ClsMathpoint(0, 0), Asymptote, Color.Green, 1)


        Dim Phi As Double = 0
        Dim R As Double
        Dim Limit As Double = Math.Sqrt(Math.Pow(XInterval.B, 2) + Math.Pow(YInterval.B, 2))

        'Draws the real and approximated curve of |Np'(z)|<1

        Do
            R = GetR(Phi)

            If R < Limit Then
                MyGraphics.DrawPoint(New ClsMathpoint(CDec(R * Math.Cos(Phi)), CDec(R * Math.Sin(Phi))), Brushes.Red, 1)
                MyGraphics.DrawPoint(New ClsMathpoint(CDec(R * Math.Cos(Phi)), CDec(-R * Math.Sin(Phi))), Brushes.Red, 1)
            End If

            R = GetApproximativeR(Phi)

            If R < Limit Then
                MyGraphics.DrawPoint(New ClsMathpoint(CDec(R * Math.Cos(Phi)), CDec(R * Math.Sin(Phi))), Brushes.Red, 1)
                MyGraphics.DrawPoint(New ClsMathpoint(CDec(R * Math.Cos(Phi)), CDec(-R * Math.Sin(Phi))), Brushes.Red, 1)
            End If

            'This is the result of experiments:
            Phi += StepWide / (2 * R)

        Loop Until (R > Limit) Or (Phi > Math.PI / (2 * DS.N))

    End Sub

    Private Function GetR(phi As Double) As Double

        Dim rTemp As Double

        'Prepare Root
        rTemp = Math.Pow(Math.Cos(DS.N * phi) * (DS.N - 1) / (2 * DS.N - 1), 2) + 1 / (2 * DS.N - 1)

        'Root
        rTemp = (DS.N - 1) * Math.Sqrt(rTemp)

        'Add
        rTemp += -Math.Cos(DS.N * phi) * (DS.N - 1) * (DS.N - 1) / (2 * DS.N - 1)

        'n-th root
        rTemp = Math.Pow(rTemp, 1 / DS.N)

        Return rTemp

    End Function

    Private Function GetApproximativeR(phi As Double) As Double

        Dim rTemp As Double

        rTemp = 1 / Math.Pow(2 * Math.Cos(DS.N * phi), 1 / DS.N)

        Return rTemp
    End Function

End Class