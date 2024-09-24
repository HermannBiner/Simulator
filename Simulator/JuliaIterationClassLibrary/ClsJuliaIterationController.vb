'This class contains the controller for the FrmJulia

'Status Checked

Imports System.Globalization
Imports System.Reflection

Public Class ClsJuliaIterationController

    Private MyForm As FrmJulia

    'Prepare basic objects
    Private DS As IJulia

    Private DiagramAreaSelector As ClsDiagramAreaSelector

    'Julia Samples
    Private JuliaSampleList As List(Of ClsJuliaSample)

    Public Sub New(Form As FrmJulia)
        MyForm = Form
        DiagramAreaSelector = New ClsDiagramAreaSelector
        JuliaSampleList = New List(Of ClsJuliaSample)
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
                JuliaName = FrmMain.LM.GetString(type.Name, True)
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
                    If FrmMain.LM.GetString(type.Name, True) = SelectedName Then
                        DS = CType(Activator.CreateInstance(type), IJulia)
                    End If
                Next
            End If
        End If

        InitializeMe()

        SetDefaultUserData()

        ResetIteration()

        If DS.IsSampleList Then
            MyForm.CboJuliaSamples.Visible = True
            FillJuliaSamples()
        Else
            MyForm.CboJuliaSamples.Visible = False
        End If

    End Sub

    Private Sub InitializeMe()

        MyForm.CboN.SelectedIndex = 0

        With DS
            .PicDiagram = MyForm.PicDiagram
            .N = CInt(MyForm.CboN.SelectedItem)
            .ActualXRange = .XValueParameter.Range
            .ActualYRange = .YValueParameter.Range
            .TxtNumberOfSteps = MyForm.TxtSteps
            .TxtElapsedTime = MyForm.TxtTime
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
            .TxtA.Text = DS.XValueParameter.DefaultValue.ToString(CultureInfo.CurrentCulture)
            .TxtB.Text = DS.YValueParameter.DefaultValue.ToString(CultureInfo.CurrentCulture)
            .TxtXMin.Text = DS.XValueParameter.Range.A.ToString(CultureInfo.CurrentCulture)
            .TxtXMax.Text = DS.XValueParameter.Range.B.ToString(CultureInfo.CurrentCulture)
            .TxtYMin.Text = DS.YValueParameter.Range.A.ToString(CultureInfo.CurrentCulture)
            .TxtYMax.Text = DS.YValueParameter.Range.B.ToString(CultureInfo.CurrentCulture)
        End With
        SetDelta()
    End Sub

    Private Sub FillJuliaSamples()

        JuliaSampleList.Add(New ClsJuliaSample(FrmMain.LM.GetString("Seehorse"), New ClsComplexNumber(0.360284, 0.100367)))
        JuliaSampleList.Add(New ClsJuliaSample(FrmMain.LM.GetString("Rabbit"), New ClsComplexNumber(-0.12256117, 0.744861771)))
        JuliaSampleList.Add(New ClsJuliaSample(FrmMain.LM.GetString("Dragon"), New ClsComplexNumber(0.144, 0.6)))
        JuliaSampleList.Add(New ClsJuliaSample(FrmMain.LM.GetString("Tornado"), New ClsComplexNumber(-0.447, 0.558)))
        JuliaSampleList.Add(New ClsJuliaSample(FrmMain.LM.GetString("Flake"), New ClsComplexNumber(-0.322, 0.628)))
        JuliaSampleList.Add(New ClsJuliaSample(FrmMain.LM.GetString("Spider"), New ClsComplexNumber(-0.106, 0.868)))
        JuliaSampleList.Add(New ClsJuliaSample(FrmMain.LM.GetString("Flash"), New ClsComplexNumber(-1.024, 0.289)))

        MyForm.CboJuliaSamples.Items.Clear()

        Dim Name As String

        For Each ClsJuliaSample In JuliaSampleList
            Name = FrmMain.LM.GetString(ClsJuliaSample.Name)
            MyForm.CboJuliaSamples.Items.Add(Name)
        Next
        MyForm.CboJuliaSamples.SelectedIndex = 0

    End Sub

    Public Sub SetSample()
        Dim Name As String = MyForm.CboJuliaSamples.SelectedItem.ToString

        For Each JuliaSample In JuliaSampleList
            If FrmMain.LM.GetString(JuliaSample.Name) = Name Then
                MyForm.TxtA.Text = JuliaSample.C.X.ToString(CultureInfo.CurrentCulture)
                MyForm.TxtB.Text = JuliaSample.C.Y.ToString(CultureInfo.CurrentCulture)
            End If
        Next

    End Sub

    Public Sub SetExponent()
        If MyForm.CboN.SelectedIndex >= 0 Then
            DS.N = CInt(MyForm.CboN.SelectedItem)
        End If
        SetDefaultUserData()
        ResetIteration()
    End Sub

    Public Sub ResetIteration()
        MyForm.BtnStart.Text = FrmMain.LM.GetString("Start")
        DS.ResetIteration()
        MyForm.ChkTrack.Visible = False
        MyForm.ChkTrack.Checked = False
    End Sub

    Public Sub SetDelta()
        With MyForm
            If IsNumeric(.TxtXMax.Text) And IsNumeric(.TxtXMin.Text) Then
                .TxtDeltaX.Text = (CDec(.TxtXMax.Text) - CDec(.TxtXMin.Text)).ToString(CultureInfo.CurrentCulture)
            End If
            If IsNumeric(.TxtYMax.Text) And IsNumeric(.TxtYMin.Text) Then
                .TxtDeltaY.Text = (CDec(.TxtYMax.Text) - CDec(.TxtYMin.Text)).ToString(CultureInfo.CurrentCulture)
            End If
        End With
    End Sub

    Public Sub SetColors()
        With MyForm
            DS.BluePercent = .TrbBlue.Value / 10
            DS.GreenPercent = .TrbGreen.Value / 10
            DS.RedPercent = .TrbRed.Value / 10
            .PicBright.BackColor = Color.FromArgb(255, CInt(255 * .TrbRed.Value / 10), CInt(255 * .TrbGreen.Value / 10),
                                                 CInt(255 * .TrbBlue.Value / 10))
            .PicDark.BackColor = Color.FromArgb(255, CInt(150 * .TrbRed.Value / 10), CInt(150 * .TrbGreen.Value / 10),
                                                 CInt(150 * .TrbBlue.Value / 10))
        End With
    End Sub

    'SECTOR ITERATION
    Public Async Sub StartIteration()

        If MyForm.ChkTrack.Checked Then

            DS.C = New ClsComplexNumber(CDbl(MyForm.TxtA.Text), CDbl(MyForm.TxtB.Text))
            ShowCTrack()

        Else
            If DS.IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then

                'the iteration was stopped or reset
                'and should start from the beginning
                If IsUserDataOK() Then
                    ResetIteration()
                    DiagramAreaSelector.IsActivated = False
                    MyForm.BtnStart.Text = FrmMain.LM.GetString("Continue")

                    With DS
                        .IterationStatus = ClsDynamics.EnIterationStatus.Ready
                        .ActualXRange = New ClsInterval(CDec(MyForm.TxtXMin.Text), CDec(MyForm.TxtXMax.Text))
                        .ActualYRange = New ClsInterval(CDec(MyForm.TxtYMin.Text), CDec(MyForm.TxtYMax.Text))
                        DiagramAreaSelector.UserXRange = .ActualXRange
                        DiagramAreaSelector.UserYRange = .ActualYRange

                        'Check if c = a+ib is a complex number and part if the square ActualXRange x ActualYRange
                        'if not, the standard value is set: c=i
                        If IsCParameterOK() Then
                            DS.C = New ClsComplexNumber(CDbl(MyForm.TxtA.Text), CDbl(MyForm.TxtB.Text))
                        End If
                        .IsUseSystemColors = MyForm.OptSystem.Checked
                    End With

                    With MyForm
                        If .OptSystem.Checked Then
                            .TrbBlue.Visible = False
                            .TrbGreen.Visible = False
                            .TrbRed.Visible = False
                            .PicBright.Visible = False
                            .PicDark.Visible = False
                        Else
                            .TrbBlue.Visible = True
                            .TrbGreen.Visible = True
                            .TrbRed.Visible = True
                            .PicBright.Visible = True
                            .PicDark.Visible = True
                            SetColors()
                        End If
                    End With

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
                End With

                Await DS.GenerateImage()

            End If

            If DS.IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
                With MyForm
                    .BtnStart.Text = FrmMain.LM.GetString("Start")
                    .BtnStart.Enabled = True
                    .BtnReset.Enabled = True
                    .BtnDefault.Enabled = True

                    If DS.IsTrackImplemented Then
                        .ChkTrack.Visible = True
                    End If
                End With
                DiagramAreaSelector.IsActivated = True
            End If

        End If
    End Sub

    Public Sub StopIteration()
        'the iteration was running and is interrupted
        DS.IterationStatus = ClsDynamics.EnIterationStatus.Interrupted
        'the iteration is stooped by reset the iteration
        With MyForm
            .BtnStart.Enabled = True
            .BtnReset.Enabled = True
            .ChkProtocol.Enabled = True
            .BtnDefault.Enabled = True
        End With
    End Sub

    Private Sub ShowCTrack()
        DS.ShowCTrack()
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

End Class
