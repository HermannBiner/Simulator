'This form is the user interface for investigations of the iteration
'of unimodal functions like Tentmap, Logistic Growth or Parabola
'a parameter a, that steeres the iteration function, can be defined
'the behaviour of the iteration depends on that parameter
'in certain cases, the behaviour is chaotic
'in that case, any protocol of the iteration is possible
'if an arbitrary protocol is given by the user
'the program calculates a startvalue for the iteration, that produces this protocol
'in addition, any target value can be defined by the user
'and the program adapts the startvalue a little bit different from the original one
'so that the iteration approaches the given target value during the iteration
'see the mathematical documentation

'The form is based on an Interface IIteration 
'that is implemented by ClsTentmap, ClsLogisticGrowth, ClsParabola
'Therefore, more cases of unimodal functions could be easely programmed
'just by implementing this interface

'Status Redesign Tested

Imports System.Globalization
Imports System.Reflection

Public Class FrmIteration

    Private IsFormLoaded As Boolean
    Private IterationController As ClsIterationController

    'Prepare basic objects
    Private DS As IIteration

    Private Const XStretchingDefault As Integer = 2

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub FrmIteration_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        IsFormLoaded = False
        IterationController = New ClsIterationController

        'Initialize Language
        InitializeLanguage()

        FillDynamicSystem()

    End Sub

    Private Sub FrmIteration_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        CboIterationDepth.SelectedIndex = 0
        CboFunction.SelectedIndex = 0
        OptFunctionGraph.Checked = True

        SetDS()
        IterationController.Presentation = ClsIterationController.PresentationEnum.Functionsgraph

        IsFormLoaded = True

    End Sub

    Private Sub InitializeLanguage()

        Text = FrmMain.LM.GetString("GrowthModels")
        OptFunctionGraph.Text = FrmMain.LM.GetString("FunctionGraph")
        OptTimeAxis.Text = FrmMain.LM.GetString("TimeAxis")
        LblxStretching.Text = FrmMain.LM.GetString("xStretching")
        LblStretching.Text = FrmMain.LM.GetString("DinStretching")
        GrpPresentation.Text = FrmMain.LM.GetString("Presentation")
        LblLog.Text = FrmMain.LM.GetString("Log")
        LblXValues.Text = FrmMain.LM.GetString("XValues")
        LblIterationDepth.Text = FrmMain.LM.GetString("IterationDepth")
        BtnProtocolStartvalue.Text = FrmMain.LM.GetString("StartvalueForProtocol")
        GrpProtocol.Text = FrmMain.LM.GetString("TargetProtocol")
        LblTargetValue.Text = FrmMain.LM.GetString("TargetValue") & " = "
        BtnTransitiveStartValue.Text = FrmMain.LM.GetString("StartvalueForTargetvalue")
        GrpTargetValue.Text = FrmMain.LM.GetString("Transitivity")
        LblNumberOfSteps.Text = FrmMain.LM.GetString("NumberOfSteps")
        GrpStep.Text = FrmMain.LM.GetString("Iteration")
        BtnNext10Steps.Text = FrmMain.LM.GetString("Next10Steps")
        BtnNextStep.Text = FrmMain.LM.GetString("NextStep")
        LblStartValue.Text = FrmMain.LM.GetString("StartValue") & " = "
        BtnReset.Text = FrmMain.LM.GetString("ResetIteration")
        LblParameterA.Text = FrmMain.LM.GetString("Parameter") & " a"
        BtnDefault.Text = FrmMain.LM.GetString("DefaultUserData")

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

        InitializeDS()

        'And the parameter and startvalue are depending on the tpe of iteration as well
        SetDefaultUserData()

        'If the type of iteration changes, everything has to be reset
        ResetIteration()

    End Sub

    Private Sub InitializeDS()

        'As standard, the function is repeated 1x in each iteration step
        DS.Power = CInt(CboIterationDepth.SelectedItem)

        With IterationController
            .DS = DS
            .LblN = LblSteps
            .PicDiagram = PicDiagram
            If OptFunctionGraph.Checked Then
                .Presentation = ClsIterationController.PresentationEnum.Functionsgraph
            Else
                .Presentation = ClsIterationController.PresentationEnum.TimeAxis
            End If
            .XStretching = XStretchingDefault
            .Protocol = LstProtocol
            .ValueList = LstValueList
            .TxtStartValue = TxtStartValue
        End With

    End Sub

    Private Sub SetDefaultUserData()

        'default settings
        TxtParameter.Text = DS.ChaoticParameter.ToString(CultureInfo.CurrentCulture)
        TxtStartValue.Text = (DS.IterationInterval.A +
            (DS.IterationInterval.IntervalWidth * 0.314159)).ToString(CultureInfo.CurrentCulture)
        TxtXStretching.Text = XStretchingDefault.ToString(CultureInfo.CurrentCulture)
        TxtTargetValue.Text = "0"
        IterationController.TargetValue = 0
        IterationController.TargetProtocol = ""
        TxtTargetProtocol.Text = ""
        DS.Parameter = DS.ParameterInterval.A + DS.ParameterInterval.IntervalWidth * TrbParameterA.Value / 1000
        TxtParameter.Text = DS.Parameter.ToString

    End Sub

    Private Sub ResetIteration()
        IterationController.ResetIteration()
        IterationController.PrepareDiagram()
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        If IsFormLoaded Then
            ResetIteration()
        End If
    End Sub

    Private Sub BtnDefault_Click(sender As Object, e As EventArgs) Handles BtnDefault.Click
        If IsFormLoaded Then
            SetDefaultUserData()
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

    Private Sub TxtStartValue_LostFocus(sender As Object, e As EventArgs) Handles TxtStartValue.LostFocus
        If IsFormLoaded Then
            'If this value changes, the Iteration has to be reset
            ResetIteration()
        End If
    End Sub

    Private Sub TxtXStretching_LostFocus(sender As Object, e As EventArgs) Handles TxtXStretching.LostFocus
        If IsFormLoaded Then 'If this value changes, the Iteration has to be reset
            ResetIteration()
        End If
    End Sub

    Private Sub OptFunctionGraph_CheckedChanged(sender As Object, e As EventArgs) Handles OptFunctionGraph.CheckedChanged
        If IsFormLoaded Then
            If OptFunctionGraph.Checked Then
                SetPresentation()
                ResetIteration()
            End If
        End If
    End Sub

    Private Sub OptTimeAxis_CheckedChanged(sender As Object, e As EventArgs) Handles OptTimeAxis.CheckedChanged
        If IsFormLoaded Then
            If OptTimeAxis.Checked Then
                SetPresentation()
                ResetIteration()
            End If
        End If
    End Sub

    Private Sub TrbParameterA_Scroll(sender As Object, e As EventArgs) Handles TrbParameterA.Scroll
        If IsFormLoaded Then
            DS.Parameter = DS.ParameterInterval.A + DS.ParameterInterval.IntervalWidth * TrbParameterA.Value / 1000
            TxtParameter.Text = DS.Parameter.ToString
            If OptFunctionGraph.Checked Then
                IterationController.DrawFunctionGraph()
            End If
        End If
    End Sub

    Private Sub SetPresentation()

        'The type of presentation has changed
        If OptFunctionGraph.Checked Then
            IterationController.Presentation = ClsIterationController.PresentationEnum.Functionsgraph
            TxtXStretching.Visible = False
            TxtXStretching.Text = XStretchingDefault.ToString(CultureInfo.CurrentCulture)
            LblStretching.Visible = False
            LblxStretching.Visible = False
            BtnNext10Steps.Text = FrmMain.LM.GetString("Next10Steps")
            BtnNextStep.Visible = True
        Else
            IterationController.Presentation = ClsIterationController.PresentationEnum.TimeAxis
            TxtXStretching.Visible = True
            TxtXStretching.Text = XStretchingDefault.ToString(CultureInfo.CurrentCulture)
            IterationController.XStretching = XStretchingDefault
            LblStretching.Visible = True
            LblxStretching.Visible = True
            BtnNextStep.Visible = False
            BtnNext10Steps.Text = FrmMain.LM.GetString("NextDiagram")
        End If

    End Sub

    Private Function IsUserDataOK() As Boolean

        'Checks all manual inputs of the user
        Dim CheckParameter = New ClsCheckUserData(TxtParameter, DS.ParameterInterval)
        Dim CheckStartValue = New ClsCheckUserData(TxtStartValue, DS.IterationInterval)
        Dim CheckTargetValue = New ClsCheckUserData(TxtTargetValue, DS.IterationInterval)
        Dim StretchInterval = New ClsInterval(1, 10)
        Dim CheckStretchInterval = New ClsCheckUserData(TxtXStretching, StretchInterval)

        Return CheckParameter.IsTxtValueAllowed And CheckStartValue.IsTxtValueAllowed _
            And CheckTargetValue.IsTxtValueAllowed And CheckStretchInterval.IsTxtValueAllowed

    End Function

    'SECTOR STARTVALUE FOR PROTOCOL

    Private Sub BtnProtocolStartvalue_Click(sender As Object, e As EventArgs) Handles BtnProtocolStartvalue.Click

        If IsFormLoaded Then
            If IsUserDataOK() Then

                DS.Parameter = CDec(TxtParameter.Text)

                'Initialization was successful
                If DS.IsBehaviourChaotic Then
                    'OK, nothing to do
                Else
                    'There is already a message generated
                End If

                'The power should be = 1 to produce the protocol
                CboIterationDepth.SelectedIndex = 0
                DS.Power = 1

                With IterationController
                    .TargetProtocol = TxtTargetProtocol.Text.ToString
                    .CalculateStartvalueForProtocol()
                End With
            End If
        End If

    End Sub

    'SECTOR ADAPTED STARTVALUE FOR THE TARGETVALUE

    Private Sub BtnTransitiveStartValue_Click(sender As Object, e As EventArgs) Handles BtnTransitiveStartValue.Click

        If IsFormLoaded Then
            'A target value for the iteration is given
            'The original startvalue should be adapted minimally
            'So that the target value will be reached nearly during the iteration

            Dim CheckTargetvalue As New ClsCheckIsNumeric(TxtTargetValue)

            If IsUserDataOK() Then

                DS.Parameter = CDec(TxtParameter.Text)

                'Initialization was succesful
                If DS.IsBehaviourChaotic Then
                    'OK, nothing to do
                Else
                    'There is already a message generated
                End If

                'The power should be = 1 to produce the iteration to the target value
                CboIterationDepth.SelectedIndex = 0
                DS.Power = 1

                With IterationController
                    .StartValue = CDec(TxtStartValue.Text)
                    .TargetValue = CDec(TxtTargetValue.Text)
                    .CalculateStartvalueForTargetValue()
                End With

            Else
                'There is already a message generated
                SetDefaultUserData()
            End If
        End If

    End Sub

    'SECTOR ITERATION

    Private Sub BtnNextStep_Click(sender As Object, e As EventArgs) Handles BtnNextStep.Click

        If IsFormLoaded Then

            'Perform one iteration step
            DoIteration(1)
        End If

    End Sub

    Private Sub BtnNext10Steps_Click(sender As Object, e As EventArgs) Handles BtnNext10Steps.Click

        If IsFormLoaded Then
            'Perform one iteration step
            DoIteration(10)
        End If
    End Sub

    Private Sub DoIteration(EndOfLoop As Integer)

        With IterationController

            'New iteration
            If .IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then

                If IsUserDataOK() Then
                    DS.Parameter = CDec(TxtParameter.Text)
                    .StartValue = CDec(TxtStartValue.Text)
                    .XStretching = CInt(TxtXStretching.Text)
                    .IterationStatus = ClsDynamics.EnIterationStatus.Ready
                    .PrepareDiagram()
                Else
                    SetDefaultUserData()
                End If

            End If

            If .IterationStatus = ClsDynamics.EnIterationStatus.Ready Then
                .IterationStatus = ClsDynamics.EnIterationStatus.Running
                If .Presentation = ClsIterationController.PresentationEnum.Functionsgraph Then

                    'This perfoms NumberOfSteps steps of the iteration
                    'and draws the display in the Function Graph and 45° line
                    .IterationLoop(EndOfLoop)

                Else
                    'Clean the diagram
                    .ResetIteration()

                    'and draw the iteration on the time-axis (Number of Steps in x-Direction)
                    .ShowFullDiagram()
                End If
                .IterationStatus = ClsDynamics.EnIterationStatus.Ready
            End If

        End With

    End Sub

End Class