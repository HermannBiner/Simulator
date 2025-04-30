'This class contains the controller for the FrmJulia

'Status Checked

Imports System.Globalization
Imports System.Reflection

Public Class ClsJuliaController

    Private ReadOnly MyForm As FrmJulia

    Private ReadOnly LM As ClsLanguageManager

    'Prepare basic objects
    Private DS As IJulia

    Private ReadOnly DiagramAreaSelector As ClsDiagramAreaSelector

    'Stored C from Mandelbrotset
    Private StoredC As ClsComplexNumber

    'Julia Samples
    Private ReadOnly JuliaSampleList As List(Of ClsJuliaSample)

    'Parameters for the Iteration

    Private Property IterationStatus As ClsDynamics.EnIterationStatus

    'Number of examinated points in the complex plane
    Private ExaminatedPoints As Integer

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
    Private Watch As Stopwatch

    'SECTOR INITIALIZATION

    Public Sub New(Form As FrmJulia)
        MyForm = Form
        LM = ClsLanguageManager.LM
        DiagramAreaSelector = New ClsDiagramAreaSelector
        JuliaSampleList = New List(Of ClsJuliaSample)

        Watch = New Stopwatch

    End Sub

    Public Sub FillDynamicSystem()

        MyForm.CboFunction.Items.Clear()

        'Add the classes implementing IPolynom
        'to the Combobox CboFunction by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IJulia)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If types.Count > 0 Then
            Dim JuliaName As String
            For Each type In types

                'GetString is calle dwith the option IsClass = true
                'That effects that - if there is no Entry in the Resource files LabelsEN, LabelsDE -
                'the name of the Class implementing an Interface is used as default
                'suppressing the extension "Cls"
                JuliaName = LM.GetString(type.Name, True)
                MyForm.CboFunction.Items.Add(JuliaName)
            Next
        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If
        MyForm.CboFunction.SelectedIndex = 0

    End Sub

    Public Sub SetDS()

        'This sets the type of ClsJulia by Reflection

        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IJulia)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If MyForm.CboFunction.SelectedIndex >= 0 Then

            Dim SelectedName As String = MyForm.CboFunction.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If LM.GetString(type.Name, True) = SelectedName Then
                        DS = CType(Activator.CreateInstance(type), IJulia)
                        Exit For
                    End If
                Next
            End If
        End If

        InitializeMe()

        SetDefaultUserData()

        ResetIteration()

        If Not DS.IsMandelbrot Then
            MyForm.CboJuliaSamples.Visible = True
            MyForm.LblJuliaSets.Visible = True
            FillJuliaSamples()
        Else
            MyForm.CboJuliaSamples.Visible = False
            MyForm.LblJuliaSets.Visible = False
        End If

        'SetDefaultUserData() is contained in SetSample
        SetSample()

    End Sub

    Public Sub InitializeMe()

        'The following order is important
        'because changing .N
        'uses e.g. TxtNumberOfSteps
        With DS
            .PicDiagram = MyForm.PicDiagram
            MyForm.CboN.SelectedIndex = 0
            .N = CInt(MyForm.CboN.SelectedItem)
            .ActualXRange = .XValueParameter.Range
            .ActualYRange = .YValueParameter.Range
            .ProcotolList = MyForm.LstProtocol
            .IsProtocol = MyForm.ChkProtocol.Checked
            .RedPercent = MyForm.TrbRed.Value / 10
            .GreenPercent = MyForm.TrbGreen.Value / 10
            .BluePercent = MyForm.TrbBlue.Value / 10
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

    End Sub

    Public Sub SetDefaultUserData()
        With MyForm
            .TxtXMin.Text = DS.XValueParameter.Range.A.ToString(CultureInfo.CurrentCulture)
            .TxtXMax.Text = DS.XValueParameter.Range.B.ToString(CultureInfo.CurrentCulture)
            .TxtYMin.Text = DS.YValueParameter.Range.A.ToString(CultureInfo.CurrentCulture)
            .TxtYMax.Text = DS.YValueParameter.Range.B.ToString(CultureInfo.CurrentCulture)
        End With
        SetDelta()
        SetColors()
    End Sub

    Private Sub FillJuliaSamples()

        JuliaSampleList.Clear()

        If StoredC IsNot Nothing Then
            JuliaSampleList.Add(New ClsJuliaSample(LM.GetString("MandelbrotSelection"), StoredC))
        End If

        JuliaSampleList.Add(New ClsJuliaSample(LM.GetString("Seehorse"), New ClsComplexNumber(0.32, 0.043)))
        JuliaSampleList.Add(New ClsJuliaSample(LM.GetString("Rabbit"), New ClsComplexNumber(-0.12256117, 0.744861771)))
        JuliaSampleList.Add(New ClsJuliaSample(LM.GetString("Dragon"), New ClsComplexNumber(0.144, 0.6)))
        JuliaSampleList.Add(New ClsJuliaSample(LM.GetString("Hurrican"), New ClsComplexNumber(-0.447, 0.558)))
        JuliaSampleList.Add(New ClsJuliaSample(LM.GetString("Flake"), New ClsComplexNumber(-0.322, 0.628)))
        JuliaSampleList.Add(New ClsJuliaSample(LM.GetString("Spider"), New ClsComplexNumber(-0.106, 0.868)))
        JuliaSampleList.Add(New ClsJuliaSample(LM.GetString("Flash"), New ClsComplexNumber(-1.024, 0.289)))
        JuliaSampleList.Add(New ClsJuliaSample(LM.GetString("Needle"), New ClsComplexNumber(0, 1)))
        JuliaSampleList.Add(New ClsJuliaSample(LM.GetString("Cloud"), New ClsComplexNumber(-0.45, 0.6)))
        JuliaSampleList.Add(New ClsJuliaSample(LM.GetString("Galaxy"), New ClsComplexNumber(-0.71, 0.35)))
        JuliaSampleList.Add(New ClsJuliaSample(LM.GetString("Cristal"), New ClsComplexNumber(-1.5, 0)))
        JuliaSampleList.Add(New ClsJuliaSample(LM.GetString("Dust"), New ClsComplexNumber(0.005, 0.743)))

        MyForm.CboJuliaSamples.Items.Clear()

        For Each ClsJuliaSample In JuliaSampleList
            MyForm.CboJuliaSamples.Items.Add(ClsJuliaSample.Name)
        Next

        MyForm.CboJuliaSamples.SelectedIndex = 0

    End Sub

    Public Sub SetSample()

        SetDefaultUserData()

        Dim Name As String = MyForm.CboJuliaSamples.SelectedItem.ToString

        For Each JuliaSample In JuliaSampleList
            If JuliaSample.Name = Name Then
                MyForm.TxtA.Text = JuliaSample.C.X.ToString(CultureInfo.CurrentCulture)
                MyForm.TxtB.Text = JuliaSample.C.Y.ToString(CultureInfo.CurrentCulture)
                Exit For
            End If
        Next

    End Sub

    Public Sub SetExponent()
        If MyForm.CboN.SelectedIndex >= 0 Then
            DS.N = CInt(MyForm.CboN.SelectedItem)
            'The Acutalranges have changed
            'threfore
            DiagramAreaSelector.XRange = DS.XValueParameter.Range
            DiagramAreaSelector.YRange = DS.YValueParameter.Range
        End If
        SetDefaultUserData()
        ResetIteration()
    End Sub

    Public Sub ResetIteration()

        SetControlsEnabled(True)
        MyForm.BtnStart.Text = LM.GetString("Start")

        ExaminatedPoints = 0
        IterationStatus = ClsDynamics.EnIterationStatus.Stopped

        MyForm.TxtSteps.Text = "0"
        Steps = 0
        MyForm.TxtTime.Text = "0"
        L = 0
        Watch.Reset()

        DS.ResetIteration()
    End Sub

    Public Sub SetDelta()
        With MyForm

            Dim DeltaX As Decimal
            Dim DeltaY As Decimal

            If IsNumeric(.TxtXMax.Text) And IsNumeric(.TxtXMin.Text) Then
                .LblDeltaX.Text = "Delta = " & (CDec(.TxtXMax.Text) - CDec(.TxtXMin.Text)).ToString(CultureInfo.CurrentCulture)
                If DS.IsMandelbrot Then
                    'For the Mandelbrotset, we show the Midpoint of the Selection
                    'and transfer it to c = a + ib
                    DeltaX = CDec(.TxtXMax.Text) - CDec(.TxtXMin.Text)
                    .TxtA.Text = ((CDec(.TxtXMin.Text) + DeltaX) / 2).ToString(CultureInfo.CurrentCulture)
                Else
                    'TxtA is not changed
                End If
                If IsNumeric(.TxtYMax.Text) And IsNumeric(.TxtYMin.Text) Then
                    .LblDeltaY.Text = "Delta = " & (CDec(.TxtYMax.Text) - CDec(.TxtYMin.Text)).ToString(CultureInfo.CurrentCulture)
                    If DS.IsMandelbrot Then
                        DeltaY = CDec(.TxtYMax.Text) - CDec(.TxtYMin.Text)
                        .TxtB.Text = (CDec(.TxtYMin.Text) + DeltaY / 2).ToString(CultureInfo.CurrentCulture)

                        'The selection of a+ib is stored to Mandelbrot.C
                        StoredC = New ClsComplexNumber(CDec(.TxtA.Text), CDec(.TxtB.Text))
                    End If
                End If
            End If
        End With

    End Sub

    Public Sub SetColors()
        With MyForm
            If .OptSystem.Checked Then
                .PicBright.Visible = False
                .PicDark.Visible = False

                .TrbBlue.Visible = False
                .TrbGreen.Visible = False
                .TrbRed.Visible = False
                .PicBright.Visible = False
                .PicDark.Visible = False

            Else
                .PicBright.Visible = True
                .PicDark.Visible = True
                DS.BluePercent = .TrbBlue.Value / 10
                DS.GreenPercent = .TrbGreen.Value / 10
                DS.RedPercent = .TrbRed.Value / 10
                .PicBright.BackColor = Color.FromArgb(255, CInt(255 * .TrbRed.Value / 10), CInt(255 * .TrbGreen.Value / 10),
                                                     CInt(255 * .TrbBlue.Value / 10))
                .PicDark.BackColor = Color.FromArgb(255, CInt(150 * .TrbRed.Value / 10), CInt(150 * .TrbGreen.Value / 10),
                                                             CInt(150 * .TrbBlue.Value / 10))

                .TrbBlue.Visible = True
                .TrbGreen.Visible = True
                .TrbRed.Visible = True
                .PicBright.Visible = True
                .PicDark.Visible = True
            End If
        End With

    End Sub

    Private Sub SetControlsEnabled(IsEnabled As Boolean)
        With MyForm
            .BtnStart.Enabled = IsEnabled
            .BtnReset.Enabled = IsEnabled
            .BtnDefault.Enabled = IsEnabled
            .CboFunction.Enabled = IsEnabled
            .CboJuliaSamples.Enabled = IsEnabled
            .CboN.Enabled = IsEnabled
            .ChkProtocol.Enabled = IsEnabled
            .OptSystem.Enabled = IsEnabled
            .OptUser.Enabled = IsEnabled
            .TrbBlue.Enabled = IsEnabled
            .TrbGreen.Enabled = IsEnabled
            .TrbRed.Enabled = IsEnabled
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
            If IsUserDataOK() And IsCParameterOK() Then

                DiagramAreaSelector.IsActivated = False
                With DS
                    .ActualXRange = New ClsInterval(CDec(MyForm.TxtXMin.Text), CDec(MyForm.TxtXMax.Text))
                    .ActualYRange = New ClsInterval(CDec(MyForm.TxtYMin.Text), CDec(MyForm.TxtYMax.Text))
                    DiagramAreaSelector.UserXRange = .ActualXRange
                    DiagramAreaSelector.UserYRange = .ActualYRange
                    DS.C = New ClsComplexNumber(CDbl(MyForm.TxtA.Text), CDbl(MyForm.TxtB.Text))
                    .IsUseSystemColors = MyForm.OptSystem.Checked
                    .IsProtocol = MyForm.ChkProtocol.Checked
                End With

                'Resetiteration draws the coordinatesystem and needs the Actual XY Range
                ResetIteration()
                IterationStatus = ClsDynamics.EnIterationStatus.Ready
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

    Private Async Function PerformIteration() As Task

        'This algorithm goes through the CPlane in a spiral starting in the midpoint
        If ExaminatedPoints = 0 Then
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
            ExaminatedPoints += 1

            IterationLoop()

            If p >= MyForm.PicDiagram.Width Or q >= MyForm.PicDiagram.Height Then

                IterationStatus = ClsDynamics.EnIterationStatus.Stopped
                Watch.Stop()
                MyForm.PicDiagram.Refresh()

            End If

            If ExaminatedPoints Mod 100 = 0 Then
                MyForm.TxtSteps.Text = Steps.ToString
                MyForm.TxtTime.Text = (Watch.ElapsedMilliseconds / 1000).ToString("F2")
                Await Task.Delay(1)
            End If

        Loop Until IterationStatus = ClsDynamics.EnIterationStatus.Interrupted _
            Or IterationStatus = ClsDynamics.EnIterationStatus.Stopped

    End Function

    Private Sub IterationLoop()

        If ExaminatedPoints Mod 2 = 0 Then
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
        'the iteration is stooped by reset the iteration
        MyForm.BtnStart.Enabled = True
        MyForm.BtnReset.Enabled = True
        MyForm.Cursor = Cursors.Arrow
    End Sub

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
