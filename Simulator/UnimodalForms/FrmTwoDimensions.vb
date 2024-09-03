'Suppose an experimentator works in a two dimensional space and chooses a startpoint for his experiment
'and suppose, the exactness of his measure instruments is limited
'in that case, two startpoints that are a little bit different, are measured as identical startpoints
'but if the behaviour is chaotic, this little difference leads to completely different orbits
'for the experimentator, the experiment looks like random
'because in his view, he starts always at the same startpoint
'but the generated orbits are completely different
'Iterated are unimodal functions like Tentmap, Logistic Growth or Parabola
'see the mathematical documentation

'The form is based on an Interface IIteration 
'that is implemented by ClsTentmap, ClsLogisticGrowth, ClsParabola
'Therefore, more cases of unimodal functions could be easely programmed
'just by implementing hits interface

'Status Redesign Tested

Imports System.Globalization
Imports System.Reflection

Public Class FrmTwoDimensions

    Private IsFormLoaded As Boolean
    Private TwoDimensionsController As ClsTwoDimensionsController

    'Prepare basic objects
    Private DS As IIteration

    'IterationDepth: 5 is optimal, due to experiments
    Private Const Standardpower As Integer = 5

    'Color of the actual Experiment
    Private Brush As SolidBrush

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub FrmTwoDimensions_Load(sender As Object, e As EventArgs) Handles Me.Load

        IsFormLoaded = False
        TwoDimensionsController = New ClsTwoDimensionsController

        'Initialize Language
        InitializeLanguage()

        'Fill DS-List into CboFunction
        FillDynamicSystem()

    End Sub

    Private Sub FrmTwoDimensions_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        CboFunction.SelectedIndex = 0
        CboExperiment.SelectedIndex = 0
        IsFormLoaded = True

        SetBrush()
        SetDS()

    End Sub

    Private Sub InitializeLanguage()

        Text = FrmMain.LM.GetString("TwoDimensions")
        GrpParameter.Text = FrmMain.LM.GetString("Parameter")
        GrpExperiment.Text = FrmMain.LM.GetString("ExperimentNo")
        BtnNextStep.Text = FrmMain.LM.GetString("NextStep")
        BtnReset.Text = FrmMain.LM.GetString("ResetIteration")
        BtnNext10.Text = FrmMain.LM.GetString("Next10Steps")
        GrpStartpoint.Text = FrmMain.LM.GetString("CoordinatesStartpoint")
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

        'Iteration Depth
        DS.Power = Standardpower

        With TwoDimensionsController
            .DS = DS
            .PicDiagram = PicDiagram
        End With

    End Sub

    Private Sub SetDefaultUserData()

        'default settings
        TxtParameter.Text = DS.ChaoticParameter.ToString(CultureInfo.CurrentCulture)
        TxtX.Text = (DS.IterationInterval.A +
            (DS.IterationInterval.IntervalWidth * 0.414)).ToString(CultureInfo.CurrentCulture)
        TxtY.Text = (DS.IterationInterval.A +
            (DS.IterationInterval.IntervalWidth * 0.407)).ToString(CultureInfo.CurrentCulture)
        CboExperiment.SelectedIndex = 0
        TxtX.Select()

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        If IsFormLoaded Then
            ResetIteration()
        End If
    End Sub

    Private Sub ResetIteration()
        TwoDimensionsController.ResetIteration()
    End Sub

    Private Sub CboFunction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboFunction.SelectedIndexChanged

        If IsFormLoaded Then
            SetDS()
        End If

    End Sub

    Private Sub SetBrush()

        'To show the effect of different experiments,
        'there are 5 possible startpoints in different colors
        Select Case CboExperiment.SelectedIndex
            Case 0
                Brush = CType(Brushes.Black, SolidBrush)
            Case 1
                Brush = CType(Brushes.Green, SolidBrush)
            Case 2
                Brush = CType(Brushes.Blue, SolidBrush)
            Case 3
                Brush = CType(Brushes.Magenta, SolidBrush)
            Case Else
                Brush = CType(Brushes.Red, SolidBrush)
        End Select

        TwoDimensionsController.Brush = Brush

    End Sub

    Private Sub CboExperiment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboExperiment.SelectedIndexChanged

        If IsFormLoaded Then
            SetBrush()

            With TwoDimensionsController
                If .IterationStatus = ClsGeneral.EnIterationStatus.Ready Then
                    .IterationStatus = ClsGeneral.EnIterationStatus.Interrupted
                End If
            End With

        End If

    End Sub

    Private Function IsUserDataOK() As Boolean

        'Checks all manual inputs of the user

        'Is the value of TxtParameter in the Iteration Interval?
        Dim MyCheckParameter = New ClsCheckUserData(TxtParameter, DS.ParameterInterval)
        Dim MyCheckXStartvalue = New ClsCheckUserData(TxtX, DS.IterationInterval)
        Dim MyCheckYStartvalue = New ClsCheckUserData(TxtY, DS.IterationInterval)

        Return MyCheckParameter.IsTxtValueAllowed And MyCheckXStartvalue.IsTxtValueAllowed _
            And MyCheckYStartvalue.IsTxtValueAllowed

    End Function

    'SECTOR ITERATION

    Private Sub BtnNextStep_Click(sender As Object, e As EventArgs) Handles BtnNextStep.Click
        If IsFormLoaded Then
            'Perform one iteration step
            DoIteration(1)
        End If
    End Sub

    Private Sub BtnNext10_Click(sender As Object, e As EventArgs) Handles BtnNext10.Click
        If IsFormLoaded Then
            'Perform 10 iteration steps
            DoIteration(10)
        End If
    End Sub

    Private Sub DoIteration(EndOfLoop As Integer)

        With TwoDimensionsController

            'New Iteration
            If .IterationStatus = ClsGeneral.EnIterationStatus.Stopped Then
                If IsUserDataOK() Then
                    .PrepareDiagram()
                    DS.Parameter = CDec(TxtParameter.Text)
                    .StartValueX = CDec(TxtX.Text)
                    .StartValueY = CDec(TxtY.Text)
                    .IterationStatus = ClsGeneral.EnIterationStatus.Ready
                Else
                    SetDefaultUserData()
                End If
            End If

            'New Experiment with new UserData
            If .IterationStatus = ClsGeneral.EnIterationStatus.Interrupted Then
                If IsUserDataOK() Then
                    .StartValueX = CDec(TxtX.Text)
                    .StartValueY = CDec(TxtY.Text)
                    .IterationStatus = ClsGeneral.EnIterationStatus.Ready
                Else
                    SetDefaultUserData()
                End If
            End If

            'Next steps of a running Iteration
            If .IterationStatus = ClsGeneral.EnIterationStatus.Ready Then
                .IterationStatus = ClsGeneral.EnIterationStatus.Running
                .IterationLoop(EndOfLoop)
                .IterationStatus = ClsGeneral.EnIterationStatus.Ready
            End If
        End With

    End Sub


End Class