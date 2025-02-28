'This class contains the controller for the FrmNewtonIteration

'Status Checked

Imports System.Globalization
Imports System.Reflection
Imports Microsoft.VisualBasic.Devices

Public Class ClsNewtonIterationController

    Private DS As INewton

    Private ReadOnly MyForm As FrmNewtonIteration
    Private ReadOnly DiagramAreaSelector As ClsDiagramAreaSelector
    Private ReadOnly LM As ClsLanguageManager

    Private IterationStatus As ClsDynamics.EnIterationStatus

    'Line of examinated points in the complex plane
    Private ExaminatedCorner As Integer

    'Coordinates of the pixel with the startvalue
    Private p As Integer
    Private q As Integer
    Private PixelPoint As Point

    'Length of a branche of the spiral
    'see Sub IterationLoop
    Private L As Integer = 0

    'Sig = 1 if n odd, = -1 else
    Private Sig As Integer

    'Parameter k = 1...L
    Private k As Integer

    'Number of iteration steps per pixelpoint
    Private Steps As Integer
    Private ReadOnly Watch As Stopwatch

    'SECTOR INITIALIZATION

    Public Sub New(Form As FrmNewtonIteration)
        MyForm = Form
        LM = ClsLanguageManager.LM
        DiagramAreaSelector = New ClsDiagramAreaSelector
        Watch = New Stopwatch
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
                PolynomName = LM.GetString(type.Name, True)
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
                    If LM.GetString(type.Name, True) = SelectedName Then
                        DS = CType(Activator.CreateInstance(type), INewton)
                        Exit For
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
            .TxtXMin.Text = DS.XValueParameter.Range.A.ToString(CultureInfo.CurrentCulture)
            .TxtXMax.Text = DS.XValueParameter.Range.B.ToString(CultureInfo.CurrentCulture)
            .TxtYMin.Text = DS.YValueParameter.Range.A.ToString(CultureInfo.CurrentCulture)
            .TxtYMax.Text = DS.YValueParameter.Range.B.ToString(CultureInfo.CurrentCulture)

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

        SetControlsEnabled(True)
        With MyForm
            .BtnStart.Text = LM.GetString("Start")
            .BtnStart.Enabled = True
            .BtnReset.Enabled = True
        End With

        MyForm.TxtSteps.Text = "0"
        Steps = 0
        MyForm.TxtTime.Text = "0"
        L = 0
        Watch.Reset()
        ExaminatedCorner = 0

        IterationStatus = ClsDynamics.EnIterationStatus.Stopped

        DS.ResetIteration()
    End Sub

    Private Sub SetControlsEnabled(IsEnabled As Boolean)
        With MyForm
            .BtnStart.Enabled = IsEnabled
            .BtnReset.Enabled = IsEnabled
            .BtnDefault.Enabled = IsEnabled
            .BtnShowBasin.Enabled = IsEnabled
            .CboFunction.Enabled = IsEnabled
            .CboN.Enabled = IsEnabled
            .ChkProtocol.Enabled = IsEnabled
            .OptBright.Enabled = IsEnabled
            .OptConjugate.Enabled = IsEnabled
            .OptNone.Enabled = IsEnabled
            .OptRotate.Enabled = IsEnabled
            .OptShaded.Enabled = IsEnabled
            .TxtA.Enabled = IsEnabled
            .TxtB.Enabled = IsEnabled
            .TxtXMax.Enabled = IsEnabled
            .TxtXMin.Enabled = IsEnabled
            .TxtYMax.Enabled = IsEnabled
            .TxtYMin.Enabled = IsEnabled
        End With
    End Sub

    'SECTOR ITERATION

    Public Async Sub StartIteration()

        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            'the iteration was stopped or reset
            'and should start from the beginning
            If IsUserDataOK() Then
                ResetIteration()
                DiagramAreaSelector.IsActivated = False
                With DS
                    SetExponent()
                    IterationStatus = ClsDynamics.EnIterationStatus.Ready
                    .ActualXRange = New ClsInterval(CDec(MyForm.TxtXMin.Text), CDec(MyForm.TxtXMax.Text))
                    .ActualYRange = New ClsInterval(CDec(MyForm.TxtYMin.Text), CDec(MyForm.TxtYMax.Text))
                    DiagramAreaSelector.UserXRange = .ActualXRange
                    DiagramAreaSelector.UserYRange = .ActualYRange
                    .IsProtocol = MyForm.ChkProtocol.Checked

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

        If IterationStatus = ClsDynamics.EnIterationStatus.Ready _
                Or IterationStatus = ClsDynamics.EnIterationStatus.Interrupted Then
            IterationStatus = ClsDynamics.EnIterationStatus.Running

            SetControlsEnabled(False)
            With MyForm
                .BtnStart.Text = LM.GetString("Continue")
                .Cursor = Cursors.WaitCursor
            End With

            Await PerformIteration()

        End If

        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            SetControlsEnabled(True)
            With MyForm
                .BtnStart.Text = LM.GetString("Start")
                .Cursor = Cursors.Arrow
            End With
            DiagramAreaSelector.IsActivated = True
        End If

    End Sub

    Public Async Function PerformIteration() As Task

        'This algorithm goes through the CPlane in a spiral starting in the midpoint
        'In case of Symmetry, only the lower halfplane is examinated

        If ExaminatedCorner = 0 Then
            p = CInt(MyForm.PicDiagram.Width / 2)
            q = CInt(MyForm.PicDiagram.Height / 2)

            PixelPoint = New Point

            With PixelPoint
                .X = p
                .Y = q
            End With

            DS.IterationStep(PixelPoint)

            Steps = 1
            Watch.Start()

        End If


        Do
            ExaminatedCorner += 1

            IterationLoop()

            If p >= MyForm.PicDiagram.Width Or q >= MyForm.PicDiagram.Height Then

                IterationStatus = ClsDynamics.EnIterationStatus.Stopped
                Watch.Stop()
                MyForm.PicDiagram.Refresh()

            End If

            If ExaminatedCorner Mod 100 = 0 Then
                MyForm.TxtSteps.Text = Steps.ToString
                MyForm.TxtTime.Text = (Watch.ElapsedMilliseconds / 1000).ToString("F2")
                Await Task.Delay(1)
            End If

        Loop Until IterationStatus = ClsDynamics.EnIterationStatus.Interrupted _
            Or IterationStatus = ClsDynamics.EnIterationStatus.Stopped

        DS.DrawRoots(True)

    End Function

    Private Sub IterationLoop()

        If ExaminatedCorner Mod 2 = 0 Then
            Sig = -1
        Else
            Sig = 1
        End If

        L += 1

        k = 1
        Do While k < L
            p += Sig
            With PixelPoint
                .X = p
                .Y = q
            End With

            'Calculates the color of the PixelPoint
            'and draws it to MapCPlane
            DS.IterationStep(PixelPoint)

            If Steps Mod 10000 = 0 Then
                MyForm.PicDiagram.Refresh()
            End If

            Steps += 1
            k += 1
        Loop

        k = 1

        Do While k < L
            q += Sig

            With PixelPoint
                .X = p
                .Y = q
            End With

            'Calculates the color of the PixelPoint
            'and draws it to MapCPlane
            DS.IterationStep(PixelPoint)

            If Steps Mod 10000 = 0 Then
                MyForm.PicDiagram.Refresh()
            End If

            Steps += 1
            k += 1
        Loop

    End Sub
    Public Sub StopIteration()

        'the iteration was running and is interrupted
        IterationStatus = ClsDynamics.EnIterationStatus.Interrupted
        'the iteration is stopoped by reset the iteration
        MyForm.BtnStart.Enabled = True
        MyForm.BtnReset.Enabled = True
        MyForm.Cursor = Cursors.Arrow

    End Sub

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

    'SECTOR CHECK USERDATA

    Private Function IsUserDataOK() As Boolean

        With MyForm
            Dim CheckXUserData As New ClsCheckUserData(.TxtXMin, .TxtXMax, DS.XValueParameter.Range)
            Dim CheckYUserData As New ClsCheckUserData(.TxtYMin, .TxtYMax, DS.YValueParameter.Range)

            Return CheckXUserData.IsIntervalAllowed And CheckYUserData.IsIntervalAllowed
        End With

    End Function

    Private Function IsCParameterOK() As Boolean

        With MyForm
            'The parameter c has to be in the same area as the z-Values
            Dim CheckParameterA As New ClsCheckUserData(.TxtA, DS.XValueParameter.Range)
            Dim CheckParameterB As New ClsCheckUserData(.TxtB, DS.YValueParameter.Range)

            Return CheckParameterA.IsTxtValueAllowed And CheckParameterB.IsTxtValueAllowed
        End With

    End Function

End Class
