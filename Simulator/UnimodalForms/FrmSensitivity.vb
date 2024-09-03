'This form is the user interface for the investigation of the sensitivity
'of unimodal functions like Tentmap, Logistic Growth or Parabola
'if the behaviour of the iteration is chaotic, then a little differenc between two startvalues
'leads to big differences of their orbits
'see the mathematical documentation

'The form is based on an Interface IIteration 
'that is implemented by ClsTentmap, ClsLogisticGrowth, ClsParabola
'Therefore, more cases of unimodal functions could be easely programmed
'just by implementing this interface

'Status Redesign Tested

Imports System.Globalization
Imports System.Reflection

Public Class FrmSensitivity

    Private IsFormLoaded As Boolean
    Private SensitivityController As ClsSensitivityController

    'Prepare basic objects
    Private DS As IIteration

    Private Const XStretchingDefault As Integer = 2

    Private Presentation As ClsSensitivityController.PresentationEnum

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub FrmSensitivity_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        IsFormLoaded = False
        SensitivityController = New ClsSensitivityController

        'Initialize Language
        InitializeLanguage()

        FillDynamicSystem()

    End Sub

    Private Sub FrmSensitivity_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        CboFunction.SelectedIndex = 0
        CboIterationDepth.SelectedIndex = 0

        IsFormLoaded = True

        'Default Presentation
        SetPresentation()

        SetDS()

    End Sub

    Private Sub InitializeLanguage()

        Text = FrmMain.LM.GetString("Sensitivity")
        LblSteps.Text = FrmMain.LM.GetString("NumberOfSteps")
        BtnReset.Text = FrmMain.LM.GetString("ResetIteration")
        BtnStartIteration.Text = FrmMain.LM.GetString("StartIteration")
        OptDifference.Text = FrmMain.LM.GetString("Difference12")
        OptSingleOrbit.Text = FrmMain.LM.GetString("SingleOrbits")
        LblxStretching.Text = FrmMain.LM.GetString("xStretching")
        LblStretching.Text = FrmMain.LM.GetString("DinStretching")
        GrpPresentation.Text = FrmMain.LM.GetString("Presentation")
        LblStartValue2.Text = FrmMain.LM.GetString("StartValue2")
        LblStartValue1.Text = FrmMain.LM.GetString("StartValue1")
        LblValueList2.Text = FrmMain.LM.GetString("ValueList2")
        LblValueList1.Text = FrmMain.LM.GetString("ValueList1")
        LblIterationDepth.Text = FrmMain.LM.GetString("IterationDepth")

    End Sub

    Private Sub FillDynamicSystem()

        CboFunction.Items.Clear()

        'Add the classes implementing IIteration
        'to the Combobox CboPendulum by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IIteration)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If types.Count > 0 Then
            Dim IteratorName As String
            For Each type In types

                'GetString is calle dwith the option IsClass = true
                'That effects that - if there is no Entry in the Resource files LabelsEN, LabelsDE -
                'the name of the Class implementing an Interface is used as default
                'suppressing the extension "Cls"
                IteratorName = FrmMain.LM.GetString(type.Name, True)
                CboFunction.Items.Add(IteratorName)
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

        InitializeDS()

        'The parameter and startvalue are depending on the type of iteration
        SetDefaultUserData()

        'If the type of iteration changes, everything has to be reset
        ResetIteration()

    End Sub

    Private Sub InitializeDS()

        DS.Power = CInt(CboIterationDepth.SelectedItem)

        With SensitivityController
            .DS = DS
            .LblN = LblNumberOfSteps
            .PicDiagram = PicDiagram
            .Presentation = Presentation
            .ValueList1 = LstValueList1
            .ValueList2 = LstValueList2
            .XStretching = XStretchingDefault
        End With

    End Sub

    Private Sub SetDefaultUserData()

        'default settings
        TxtParameter.Text = DS.ChaoticParameter.ToString(CultureInfo.CurrentCulture)
        TxtStartValue1.Text = (DS.IterationInterval.A +
            (DS.IterationInterval.IntervalWidth * 0.314159)).ToString(CultureInfo.CurrentCulture)
        TxtStartValue2.Text = (DS.IterationInterval.A +
            (DS.IterationInterval.IntervalWidth * 0.3141590000001)).ToString(CultureInfo.CurrentCulture)
        TxtxStretching.Text = XStretchingDefault.ToString(CultureInfo.CurrentCulture)

    End Sub

    Private Sub ResetIteration()

        SensitivityController.ResetIteration()

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

    Private Sub CboIterationDepth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboIterationDepth.SelectedIndexChanged
        If IsFormLoaded Then
            'The iteration depth defines how many times the function is repeated in each iteration step
            DS.Power = CInt(CboIterationDepth.SelectedItem)
            'If this value changes, the Iteration has to be reset
            ResetIteration()
        End If
    End Sub

    Private Sub TxtParameter_TextChanged(sender As Object, e As EventArgs) Handles TxtParameter.TextChanged
        If IsFormLoaded Then
            'If this value changes, the Iteration has to be reset
            ResetIteration()
        End If
    End Sub

    Private Sub TxtStartValue1_TextChanged(sender As Object, e As EventArgs) Handles TxtStartValue1.TextChanged
        If IsFormLoaded Then
            'If this value changes, the Iteration has to be reset
            ResetIteration()
        End If
    End Sub

    Private Sub TxtStartValue2_TextChanged(sender As Object, e As EventArgs) Handles TxtStartValue2.TextChanged
        If IsFormLoaded Then
            'If this value changes, the Iteration has to be reset
            ResetIteration()
        End If
    End Sub

    Private Sub TxtxStretching_TextChanged(sender As Object, e As EventArgs) Handles TxtxStretching.TextChanged
        If IsFormLoaded Then
            'If this value changes, the Iteration has to be reset
            ResetIteration()
        End If
    End Sub

    Private Sub OptDifference_CheckedChanged(sender As Object, e As EventArgs) Handles OptDifference.CheckedChanged
        If IsFormLoaded Then
            SetPresentation()
            ResetIteration()
        End If
    End Sub

    Private Sub OptSingleOrbit_CheckedChanged(sender As Object, e As EventArgs) Handles OptSingleOrbit.CheckedChanged
        If IsFormLoaded Then
            SetPresentation()
            ResetIteration()
        End If
    End Sub

    Private Sub SetPresentation()

        'The type of presentation has changed
        Presentation = If(OptDifference.Checked, ClsSensitivityController.PresentationEnum.Difference,
            ClsSensitivityController.PresentationEnum.SingleOrbits)

    End Sub

    Private Function IsUserDataOK() As Boolean

        'Is the value of TxtParameter in the Iteration Interval?
        Dim MyCheckParameter = New ClsCheckUserData(TxtParameter, DS.ParameterInterval)
        Dim MyCheckStartValue1 = New ClsCheckUserData(TxtStartValue1, DS.IterationInterval)
        Dim MyCheckStartValue2 = New ClsCheckUserData(TxtStartValue2, DS.IterationInterval)

        Dim StretchInterval = New ClsInterval(1, 10)
        Dim MyCheckStretchInterval = New ClsCheckUserData(TxtxStretching, StretchInterval)

        Return MyCheckParameter.IsTxtValueAllowed And MyCheckStartValue1.IsTxtValueAllowed _
            And MyCheckStartValue2.IsTxtValueAllowed And MyCheckStretchInterval.IsTxtValueAllowed

    End Function

    'SECTOR SENSITIVITY

    Private Sub BtnStartIteration_Click(sender As Object, e As EventArgs) Handles BtnStartIteration.Click

        If IsFormLoaded Then

            'This starts the whole iteration

            If IsUserDataOK() Then

                With SensitivityController

                    'Set Ds Parameters
                    DS.Parameter = CDec(TxtParameter.Text)
                    .StartValue1 = CDec(TxtStartValue1.Text)
                    .StartValue2 = CDec(TxtStartValue2.Text)
                    .XStretching = CInt(TxtxStretching.Text)
                    .Presentation = Presentation

                    'The initialization was successful
                    If DS.IsBehaviourChaotic Then

                        BtnReset.Enabled = False
                        .IterationLoop()
                        BtnReset.Enabled = True

                    Else
                        'nothing to do, a message is already generated by the test
                    End If
                End With
            Else
                'there is already a message generated
                SetDefaultUserData()
            End If

        End If

    End Sub

End Class