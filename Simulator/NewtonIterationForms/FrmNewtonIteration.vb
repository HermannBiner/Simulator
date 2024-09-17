'This form is the user interface for the complex Newton Iteration
'Different complex polynoms can be implemented
'the pixelpoints in the diagram CPlane are the startpoints of the iteration
'and they are colored depending to which root of the polynom they converge
'see as well the mathematical documentation

'The form is based on the Interface IPolynom 
'that is implemented by ClsUnitRoots3 and other
'Therefore, more cases of polynoms could be easely programmed
'by implementing this interface

'Status Checked

Imports System.Globalization
Imports System.Reflection


Public Class FrmNewtonIteration

    'Private global variables
    Private IsFormLoaded As Boolean
    Private NewtonIterationController As ClsNewtonIterationController
    Private DiagramAreaSelector As ClsDiagramAreaSelector

    'Prepare basic objects
    Private DS As INewton


    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub FrmNewtonIteration_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        IsFormLoaded = False

        NewtonIterationController = New ClsNewtonIterationController

        DiagramAreaSelector = New ClsDiagramAreaSelector

        'Initialize Language
        InitializeLanguage()

        FillDynamicSystem()

    End Sub

    Private Sub FrmNewtonIteration_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        CboN.SelectedIndex = 1
        CboFunction.SelectedIndex = CboFunction.Items.Count - 1

        SetDS()
        IsFormLoaded = True

    End Sub

    Private Sub InitializeLanguage()

        Text = FrmMain.LM.GetString("NewtonIteration")
        LblProtocol.Text = FrmMain.LM.GetString("ProtocolNewton")
        ChkProtocol.Text = FrmMain.LM.GetString("Protocol")
        BtnStart.Text = FrmMain.LM.GetString("Start")
        BtnStop.Text = FrmMain.LM.GetString("Stop")
        BtnShowBasin.Text = FrmMain.LM.GetString("ShowBasin")
        BtnReset.Text = FrmMain.LM.GetString("ResetIteration")
        LblTime.Text = FrmMain.LM.GetString("Time")
        LblSteps.Text = FrmMain.LM.GetString("Steps")
        GrpMixing.Text = FrmMain.LM.GetString("Mixing")
        OptNone.Text = FrmMain.LM.GetString("None")
        OptConjugate.Text = FrmMain.LM.GetString("Conjugate")
        OptRotate.Text = FrmMain.LM.GetString("Rotate")
        GrpColor.Text = FrmMain.LM.GetString("Color")
        OptBright.Text = FrmMain.LM.GetString("Bright")
        OptShadowed.Text = FrmMain.LM.GetString("Shadowed")

    End Sub

    Private Sub FillDynamicSystem()

        CboFunction.Items.Clear()

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
                CboFunction.Items.Add(PolynomName)
            Next

        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If

    End Sub

    Private Sub SetDS()

        'This sets the type of Polynom by Reflection

        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(INewton)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If CboFunction.SelectedIndex >= 0 Then

            Dim SelectedName As String = CboFunction.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If FrmMain.LM.GetString(type.Name, True) = SelectedName Then
                        DS = CType(Activator.CreateInstance(type), INewton)
                    End If
                Next
            End If

        End If

        InitializeDS()

        SetDefaultUserData()

        ResetIteration()

    End Sub

    Private Sub InitializeDS()

        With DS
            .PicDiagram = PicDiagram
            .TxtNumberOfSteps = TxtSteps
            .TxtElapsedTime = TxtTime
            .ProcotolList = LstProtocol
            CboN.Visible = .UseN
            LblPower.Visible = .UseN

            LblC.Visible = .UseC
            LblI.Visible = .UseC
            TxtA.Visible = .UseC
            TxtB.Visible = .UseC

            .ActualXRange = .AllowedXRange
            .ActualYRange = .AllowedYRange

            .IsProtocol = ChkProtocol.Checked

            If .UseN Then
                .N = CInt(CboN.SelectedItem)
            Else
                .N = 3
            End If

        End With

        If TypeOf (DS) Is ClsUnitRootCollection Then
            BtnShowBasin.Visible = True
        Else
            BtnShowBasin.Visible = False
        End If

        With DiagramAreaSelector
            .XRange = DS.AllowedXRange
            .YRange = DS.AllowedYRange
            .PicDiagram = PicDiagram
            .TxtXMin = TxtXMin
            .TxtXMax = TxtXMax
            .TxtYMin = TxtYMin
            .TxtYMax = TxtYMax
        End With

        NewtonIterationController.PicDiagram = PicDiagram

    End Sub

    Private Sub SetDefaultUserData()

        With DS
            TxtXMin.Text = .ActualXRange.A.ToString(CultureInfo.CurrentCulture)
            TxtXMax.Text = .ActualXRange.B.ToString(CultureInfo.CurrentCulture)
            TxtYMin.Text = .ActualYRange.A.ToString(CultureInfo.CurrentCulture)
            TxtYMax.Text = .ActualYRange.B.ToString(CultureInfo.CurrentCulture)
            SetDelta()
        End With
    End Sub

    Private Sub ResetIteration()

        BtnStart.Text = FrmMain.LM.GetString("Start")
        BtnStart.Enabled = True
        BtnReset.Enabled = True

        With DS
            .ResetIteration()
            .PrepareUnitRoots()
            .DrawRoots(False)
        End With

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        If IsFormLoaded Then
            ResetIteration()
        End If
    End Sub

    Private Sub CboFunction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboFunction.SelectedIndexChanged
        If IsFormLoaded Then
            SetDS()
        End If
    End Sub

    Private Sub CboN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboN.SelectedIndexChanged
        If IsFormLoaded Then
            With DS
                If .UseN Then
                    .N = CInt(CboN.SelectedItem)
                Else
                    .N = 3
                End If
            End With
            SetDefaultUserData()
            ResetIteration()
        End If
    End Sub

    'SECTOR ITERATION

    Private Async Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        If IsFormLoaded Then
            If DS.IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then

                'the iteration was stopped or reset
                'and should start from the beginning
                If IsUserDataOK() Then
                    ResetIteration()
                    BtnStart.Text = FrmMain.LM.GetString("Continue")
                    DiagramAreaSelector.IsActivated = False
                    With DS
                        .IterationStatus = ClsDynamics.EnIterationStatus.Ready
                        .ActualXRange = New ClsInterval(CDec(TxtXMin.Text), CDec(TxtXMax.Text))
                        .ActualYRange = New ClsInterval(CDec(TxtYMin.Text), CDec(TxtYMax.Text))
                        DiagramAreaSelector.UserXRange = .ActualXRange
                        DiagramAreaSelector.UserYRange = .ActualYRange

                        If OptConjugate.Checked Then
                            .UseMixing = INewton.EnMixing.Conjugate
                        ElseIf OptRotate.Checked Then
                            .UseMixing = INewton.EnMixing.Rotate
                        Else
                            .UseMixing = INewton.EnMixing.None
                        End If

                        If OptBright.Checked Then
                            .UseColor = INewton.EnColor.Bright
                        Else
                            .UseColor = INewton.EnColor.Shadowed
                        End If

                        If .UseC Then
                            'Check if c=a+ib is a complex number and part if the square ActualXRange X ActualYRange
                            'if not, the standard value is set: c=i
                            If IsCParameterOK() Then
                                .C = New ClsComplexNumber(CDbl(TxtA.Text), CDbl(TxtB.Text))
                            End If
                        End If

                    End With

                End If
            End If

            If DS.IterationStatus = ClsDynamics.EnIterationStatus.Ready _
                    Or DS.IterationStatus = ClsDynamics.EnIterationStatus.Interrupted Then
                DS.IterationStatus = ClsDynamics.EnIterationStatus.Running

                BtnStart.Enabled = False
                BtnReset.Enabled = False
                ChkProtocol.Enabled = False

                Await DS.GenerateImage()

            End If

            If DS.IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
                BtnStart.Enabled = True
                BtnReset.Enabled = True
                ChkProtocol.Enabled = True
                BtnStart.Text = FrmMain.LM.GetString("Start")
                DiagramAreaSelector.IsActivated = True
            End If
        End If
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click
        If IsFormLoaded Then
            'the iteration was running and is interrupted
            DS.IterationStatus = ClsDynamics.EnIterationStatus.Interrupted
            'the iteration is stopoped by reset the iteration

            BtnStart.Enabled = True
            BtnReset.Enabled = True
            ChkProtocol.Enabled = True
        End If
    End Sub


    'CHECK USER RANGES AND SET X- AND Y- RANGE

    Private Function IsUserDataOK() As Boolean

        Dim CheckXUserData As New ClsCheckUserData(TxtXMin, TxtXMax, DS.AllowedXRange)
        Dim CheckYUserData As New ClsCheckUserData(TxtYMin, TxtYMax, DS.AllowedYRange)

        Return CheckXUserData.IsIntervalAllowed And CheckYUserData.IsIntervalAllowed

    End Function

    'Checks the Parameter C
    Private Function IsCParameterOK() As Boolean

        Dim CheckParameterA As New ClsCheckUserData(TxtA, DS.AllowedXRange)
        Dim CheckParameterB As New ClsCheckUserData(TxtB, DS.AllowedYRange)

        Return CheckParameterA.IsTxtValueAllowed And CheckParameterB.IsTxtValueAllowed
    End Function

    Private Sub SetDelta()
        If IsNumeric(TxtXMax.Text) And IsNumeric(TxtXMin.Text) Then
            TxtDeltaX.Text = "Delta = " & (CDec(TxtXMax.Text) - CDec(TxtXMin.Text)).ToString(CultureInfo.CurrentCulture)
        End If
        If IsNumeric(TxtYMax.Text) And IsNumeric(TxtYMin.Text) Then
            TxtDeltaY.Text = "Delta = " & (CDec(TxtYMax.Text) - CDec(TxtYMin.Text)).ToString(CultureInfo.CurrentCulture)
        End If
    End Sub

    Private Sub TxtA_LostFocus(sender As Object, e As EventArgs) Handles TxtA.LostFocus
        If IsFormLoaded Then
            SetDefaultUserData()
            ResetIteration()
        End If
    End Sub

    Private Sub TxtB_LostFocus(sender As Object, e As EventArgs) Handles TxtB.LostFocus
        If IsFormLoaded Then
            SetDefaultUserData()
            ResetIteration()
        End If
    End Sub

    Private Sub BtnShowBasin_Click(sender As Object, e As EventArgs) Handles BtnShowBasin.Click
        If IsFormLoaded Then
            DS.ResetIteration()
            NewtonIterationController.N = CInt(CboN.SelectedItem)
            NewtonIterationController.ShowBasin()
        End If
    End Sub

    Private Sub TxtXMax_LostFocus(sender As Object, e As EventArgs) Handles TxtXMax.LostFocus
        If IsFormLoaded Then
            SetDelta()
        End If
    End Sub

    Private Sub TxtXMin_LostFocus(sender As Object, e As EventArgs) Handles TxtXMin.LostFocus
        If IsFormLoaded Then
            SetDelta()
        End If
    End Sub

    Private Sub TxtYMax_LostFocus(sender As Object, e As EventArgs) Handles TxtXMax.LostFocus
        If IsFormLoaded Then
            SetDelta()
        End If
    End Sub

    Private Sub TxtYMin_LostFocus(sender As Object, e As EventArgs) Handles TxtXMin.LostFocus
        If IsFormLoaded Then
            SetDelta()
        End If
    End Sub
End Class