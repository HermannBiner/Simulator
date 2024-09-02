'This form is the user interface for investigations of a histogram
'counting, how many times a small part of the iteration interval
'is hit by an iteration value during the iteration
'Iterated are unimodal functions like Tentmap, Logistic Growth or Parabola.
'In case of chaotical behaviour, the histogram looks like random distributed
'see as well the mathematical documentation

'The form is based on an Interface IIteration 
'that is implemented by ClsTentmap, ClsLogisticGrowth, ClsParabola
'Therefore, more cases of unimodal functions could be easely programmed
'just by implementing this interface

'Status Redesign Tested

Imports System.Globalization
Imports System.Reflection

Public Class FrmHistogram

    'Loading Control
    Private IsFormLoaded As Boolean
    Private LM As ClsLanguageManager

    'Prepare basic objects
    Private DS As IIteration

    'Histogram Controller
    Private HistogramController As ClsHistogramController

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub FrmHistogramm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        IsFormLoaded = False

        'Form Controller
        HistogramController = New ClsHistogramController

        'Initialize Language
        InitializeLanguage()

        'Fill DS-List into CboFunction
        FillDynamicSystem()

    End Sub

    Private Sub FrmHistogram_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        CboFunction.SelectedIndex = 0

        IsFormLoaded = True
        SetDS()

    End Sub

    Private Sub InitializeLanguage()

        Text = FrmMain.LM.GetString("Histogram")
        LblSteps.Text = FrmMain.LM.GetString("NumberOfSteps")
        BtnReset.Text = FrmMain.LM.GetString("ResetIteration")
        BtnStart.Text = FrmMain.LM.GetString("Start")
        BtnStop.Text = FrmMain.LM.GetString("Stop")
        LblStartValue.Text = FrmMain.LM.GetString("StartValue") & " ="
        LblParameter.Text = FrmMain.LM.GetString("Parameter") & " = "

    End Sub

    Private Sub FillDynamicSystem()

        CboFunction.Items.Clear()

        'Add the classes implementing IIteration
        'to the Combobox CboPendulum by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IIteration)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If types.Count > 0 Then
            Dim DSName As String
            For Each type In types

                'GetString is calle dwith the option IsClass = true
                'That effects that - if there is no Entry in the Resource files LabelsEN, LabelsDE -
                'the name of the Class implementing an Interface is used as default
                'suppressing the extension "Cls"
                DSName = FrmMain.LM.GetString(type.Name, True)
                CboFunction.Items.Add(DSName)
            Next
        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If
    End Sub

    Private Sub SetDS()
        'This sets the type of Iterator by Reflection

        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                             Where(Function(t) t.GetInterfaces().Contains(GetType(IIteration)) AndAlso
                             t.IsClass AndAlso Not t.IsAbstract).ToList()

        If CboFunction.SelectedIndex >= 0 Then

            Dim SelectedName As String = CboFunction.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If FrmMain.LM.GetString(type.Name, True) = SelectedName Then
                        DS = CType(Activator.CreateInstance(type), IIteration)
                    End If
                Next
            End If

        End If

        'As standard, the function is repeated 1x in each iteration step
        InitializeDS()

        'The parameter and startvalue are depending on the type of iteration
        SetDefaultUserData()

        'If the type of iteration changes, everything has to be reset
        'especially the status parameters
        ResetIteration()
    End Sub

    'This routine sets the DS parameters to a default
    'the trigger is, that the DS has changed
    Private Sub InitializeDS()

        DS.Power = 1

        With HistogramController
            .DS = DS
            .LblN = LblNumberOfSteps
            .PicDiagram = PicDiagram
            .IterationStatus = ClsGeneral.EnIterationStatus.Stopped
        End With
    End Sub


    'This routine sets the user data to the default
    'the trigger is, that the DS has changed
    Private Sub SetDefaultUserData()

        TxtParameter.Text = DS.ParameterInterval.B.ToString(CultureInfo.CurrentCulture)
        TxtStartValue.Text = (DS.IterationInterval.A +
            (DS.IterationInterval.IntervalWidth * 0.314159)).ToString(CultureInfo.CurrentCulture)

    End Sub

    'This routine reset all iteration parameters
    'except user data and DS parameter
    'the meaning is, that DS has not changed
    'and the iteration is newly started
    Private Sub ResetIteration()

        'Clear display
        HistogramController.ResetIteration()
        BtnStart.Text = FrmMain.LM.GetString("Start")

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

    Private Sub TxtParameter_TextChanged(sender As Object, e As EventArgs) Handles TxtParameter.TextChanged
        If IsFormLoaded Then
            'If this value changes, the Iteration has to be reset
            ResetIteration()
        End If
    End Sub

    Private Sub TxtStartWert_TextChanged(sender As Object, e As EventArgs) Handles TxtStartValue.TextChanged
        If IsFormLoaded Then
            'If this value changes, the Iteration has to be reset
            ResetIteration()
        End If
    End Sub

    'SECTOR HISTOGRAM

    Private Async Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click

        If IsFormLoaded Then

            With HistogramController

                If .IterationStatus = ClsGeneral.EnIterationStatus.Stopped Then
                    'Check User Data
                    If IsUserDataOK() Then

                        'Set Ds Parameters
                        DS.Parameter = CDec(TxtParameter.Text)
                        .StartValue = CDec(TxtStartValue.Text)
                        .IterationStatus = ClsGeneral.EnIterationStatus.Ready

                        If DS.IsBehaviourChaotic() Then
                            'OK
                        Else
                            'nothing to do, a message is already generated
                        End If

                    Else
                        'nothing - Iterationstatus stays stopped
                    End If
                End If

                If .IterationStatus = ClsGeneral.EnIterationStatus.Ready _
                Or .IterationStatus = ClsGeneral.EnIterationStatus.Interrupted Then

                    .IterationStatus = ClsGeneral.EnIterationStatus.Running

                    BtnStart.Text = FrmMain.LM.GetString("Continue")
                    BtnStart.Enabled = False
                    BtnReset.Enabled = False

                    Application.DoEvents()

                    'Iteration loop
                    Await .IterationLoop()

                Else
                    SetDefaultUserData()
                End If
            End With
        End If

    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click

        If IsFormLoaded Then

            'the iteration is running and should be stopped
            HistogramController.IterationStatus = ClsGeneral.EnIterationStatus.Interrupted

            BtnStart.Enabled = True
            BtnReset.Enabled = True
        End If

    End Sub

    Private Function IsUserDataOK() As Boolean

        'Is the value of TxtParameter in the Iteration Interval?
        Dim MyCheckParameter = New ClsCheckUserData(TxtParameter, DS.ParameterInterval)
        Dim MyCheckStartValue = New ClsCheckUserData(TxtStartValue, DS.IterationInterval)

        Return MyCheckParameter.IsTxtValueAllowed And MyCheckStartValue.IsTxtValueAllowed

    End Function

End Class