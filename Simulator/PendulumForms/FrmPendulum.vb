'This Form is the User Interface for all Investigations of different Pendulums
'like Double Pendulum, Combined Pendulum or Shake Pendulum
'it is based on the interfaces IPendulum
'that are implemented by the according classes ClsDoublePendulum, ClsCombinedPendulum etc.
'see mathematical documentation
'if other Pendulums are programmed, the according classes have just to implement this interfaces

'Status Checked

Imports System.Reflection

Public Class FrmPendulum

    Private IsFormLoaded As Boolean

    'Active Pendulum
    Private DS As IPendulum

    'The Startposition of the Pendulum is set by the Mouse
    Private IsMousedown As Boolean = False

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub FrmPendulum_Load(sender As Object, e As EventArgs) Handles Me.Load

        IsFormLoaded = False

        'Initialize Language
        InitializeLanguage()

        FillDynamicSystem()

    End Sub

    Private Sub FrmPendulum_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        CboPendulum.SelectedIndex = 0
        CboTypeofPhaseportrait.SelectedIndex = 0

        SetDS()
        IsFormLoaded = True

    End Sub

    Private Sub InitializeLanguage()

        Text = FrmMain.LM.GetString("Pendulum")
        LblPendulum.Text = FrmMain.LM.GetString("Pendulum")

        'LblSteps contains the  #Steps
        LblNumberOfSteps.Text = FrmMain.LM.GetString("NumberOfSteps")

        'LblAdditionParameter, LblP1 ... LblP5 is set by the Active Pendulum
        BtnTakeOverStartParameter.Text = FrmMain.LM.GetString("TakeOver")
        GrpStartParameter.Text = FrmMain.LM.GetString("StartParameter")
        BtnReset.Text = FrmMain.LM.GetString("ResetIteration")
        BtnStart.Text = FrmMain.LM.GetString("Start")
        LblStepWidth.Text = FrmMain.LM.GetString("StepWidth") & ": "
        LblTypeofPhaseportrait.Text = FrmMain.LM.GetString("TypeofPhaseportrait")
    End Sub

    Private Sub FillDynamicSystem()
        CboPendulum.Items.Clear()

        'Add the classes implementing IPendulum
        'to the Combobox CboPendulum by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IPendulum)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If types.Count > 0 Then
            Dim PendulumName As String
            For Each type In types

                'GetString is called with the option IsClass = true
                'That effects that - if there is no Entry in the Resource files LabelsEN, LabelsDE -
                'the name of the Class implementing an Interface is used as default
                'suppressing the extension "Cls"
                PendulumName = FrmMain.LM.GetString(type.Name, True)
                CboPendulum.Items.Add(PendulumName)
            Next
        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If
    End Sub

    Private Sub SetDS()
        'This sets the type of Pendulum by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IPendulum)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If CboPendulum.SelectedIndex >= 0 Then

            Dim SelectedName As String = CboPendulum.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If FrmMain.LM.GetString(type.Name, True) = SelectedName Then
                        DS = CType(Activator.CreateInstance(type), IPendulum)
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
            .PicPhaseportrait = PicPhasePortrait
            .PicEnergy = PicEnergy
            .Protocol = LstProtocol
            .LblStepWidth = LblStepWidth
            .LblN = LblSteps

            TrbAdditionalParameter.Minimum = CInt(.AdditionalParameter.Range.A)
            TrbAdditionalParameter.Maximum = CInt(.AdditionalParameter.Range.B)
            TrbAdditionalParameter.Value = CInt(.AdditionalParameter.ID)

            LblAdditionalParameter.Text = .AdditionalParameter.Name & ": " & .GetAddParameterValue(TrbAdditionalParameter.Value).ToString

            Dim i As Integer
            For i = 1 To 6
                GrpStartParameter.Controls.Item("LblP" & i.ToString).Visible = (i <= .ValueParameterDefinition.Count)
                GrpStartParameter.Controls.Item("TxtP" & i.ToString).Visible = (i <= .ValueParameterDefinition.Count)
            Next

            Dim LocValueParameter As ClsValueParameter
            For Each LocValueParameter In .ValueParameterDefinition
                GrpStartParameter.Controls.Item("LblP" & LocValueParameter.ID).Text = LocValueParameter.Name
            Next

            .StepWidth = TrbStepWidth.Value

            CboTypeofPhaseportrait.Items.Clear()

            Dim TypesofPhaseportrait As List(Of String) = .GetTypesofPhaseportrait
            For Each PhaPorType As String In TypesofPhaseportrait
                CboTypeofPhaseportrait.Items.Add(FrmMain.LM.GetString(PhaPorType))
            Next

            CboTypeofPhaseportrait.SelectedIndex = 0
            .PhaseportraitIndex = 0
            LblPhasePortrait.Text = .LabelPhasePortrait
            LblProtocol.Text = .LabelProtocol
        End With
    End Sub

    Private Sub SetDefaultUserData()
        With DS
            .SetDefaultUserData()

            Dim ConstantsDimension As Integer
            If .CalculationConstants IsNot Nothing Then
                ConstantsDimension = .CalculationConstants.Dimension
                For i = 0 To ConstantsDimension
                    GrpStartParameter.Controls.Item("TxtP" & (i + 1).ToString).Text = .CalculationConstants.Component(i).ToString
                Next
            Else
                ConstantsDimension = -1
            End If

            Dim Debug As Decimal

            For i = 0 To .CalculationVariables.Dimension
                Debug = .CalculationVariables.Component(i)
                GrpStartParameter.Controls.Item("TxtP" & (i + 2 + ConstantsDimension).ToString).Text = .CalculationVariables.Component(i).ToString
            Next

        End With
    End Sub

    Sub ResetIteration()

        'Clear Diagram and Bitmap and all Iteration Parameters
        DS.ResetIteration()
        BtnStart.Text = FrmMain.LM.GetString("Start")
        BtnTakeOverStartParameter.Enabled = True
        TrbAdditionalParameter.Enabled = True

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        If IsFormLoaded Then
            ResetIteration()
        End If
    End Sub

    Private Sub CboPendulum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboPendulum.SelectedIndexChanged
        If IsFormLoaded Then
            SetDS()
        End If
    End Sub

    Private Sub TrbAdditionalParameter_Scroll(sender As Object, e As EventArgs) Handles TrbAdditionalParameter.Scroll
        If IsFormLoaded Then
            With DS
                LblAdditionalParameter.Text = .AdditionalParameter.Name & ": " & .GetAddParameterValue(TrbAdditionalParameter.Value).ToString
                .AdditionalParameterValue = TrbAdditionalParameter.Value
            End With
        End If
    End Sub

    Private Sub CboTypeofPhaseportrait_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboTypeofPhaseportrait.SelectedIndexChanged
        If IsFormLoaded Then
            DS.PhaseportraitIndex = CboTypeofPhaseportrait.SelectedIndex
            LblPhasePortrait.Text = DS.LabelPhasePortrait
        End If
    End Sub

    Private Sub TrbStepWide_Scroll(sender As Object, e As EventArgs) Handles TrbStepWidth.Scroll
        If IsFormLoaded Then
            DS.StepWidth = TrbStepWidth.Value
        End If
    End Sub


    'SECTOR SET STARTPOSITION

    Private Sub PicPendulum_MouseDown(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseDown

        If DS IsNot Nothing Then

            If Not (DS.IsStartparameter1Set And DS.IsStartparameter2Set) Then

                Cursor = Cursors.Hand
                IsMousedown = True

                'Now, Moving the Mouse moves the active Pendulum
                MouseMoving(e)

            End If
        End If
    End Sub

    Private Sub PicPendulum_MouseMove(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseMove

        If IsMousedown Then
            MouseMoving(e)
        End If

    End Sub

    Private Sub PicPendulum_MouseUp(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseUp

        'Has only an effect, if the Mouse was down
        If IsMousedown Then

            With DS
                If Not .IsStartparameter1Set Then

                    'The setting of Parameter1 i now blocked
                    .IsStartparameter1Set = True

                ElseIf Not .IsStartparameter2Set Then

                    'nothing
                    'Startparameter2 is fixed when starting

                End If
            End With

            'The Mouse gets its normal behaviour again
            Cursor = Cursors.Arrow
            IsMousedown = False

        End If


    End Sub

    Private Sub MouseMoving(e As MouseEventArgs)

        'Because the Cursor is "Hand", the Mouse Position is adjusted a bit
        Dim Mouseposition As New Point With {
            .X = e.X + 2,
            .Y = e.Y
        }

        If DS IsNot Nothing Then

            With DS
                If Not .IsStartparameter1Set Then

                    'The actual Position of the Mouse sets Parameter1
                    .SetAndDrawStartparameter1(Mouseposition)

                ElseIf Not .IsStartparameter2Set Then

                    'The actual Position of the Mouse sets Parameter2
                    .SetAndDrawStartparameter2(Mouseposition)

                End If

                Dim ConstantsDimension As Integer

                If .CalculationConstants IsNot Nothing Then
                    ConstantsDimension = .CalculationConstants.Dimension
                    For i = 0 To .CalculationConstants.Dimension
                        GrpStartParameter.Controls.Item("TxtP" & (i + 1).ToString).Text = .CalculationConstants.Component(i).ToString
                    Next
                Else
                    ConstantsDimension = -1
                End If

                For i = 0 To .CalculationVariables.Dimension
                    GrpStartParameter.Controls.Item("TxtP" & (i + 2 + ConstantsDimension).ToString).Text = .CalculationVariables.Component(i).ToString
                Next

            End With

        End If
    End Sub

    Private Sub BtnTakeOverStartParameter_Click(sender As Object, e As EventArgs) Handles BtnTakeOverStartParameter.Click
        If IsFormLoaded Then
            If IsUserDataOK() Then

                With DS

                    Dim i As Integer
                    Dim ConstantsDimension As Integer
                    Dim LocVector As ClsNTupel

                    If .CalculationConstants IsNot Nothing Then
                        LocVector = New ClsNTupel(.CalculationConstants.Dimension)

                        ConstantsDimension = .CalculationConstants.Dimension
                        'Constants
                        For i = 0 To .CalculationConstants.Dimension
                            LocVector.Component(i) = CDec(GrpStartParameter.Controls.Item("TxtP" & (i + 1)).Text)
                        Next
                        .CalculationConstants = LocVector
                    Else
                        ConstantsDimension = -1
                    End If


                    LocVector = New ClsNTupel(.CalculationVariables.Dimension)

                    'Variables
                    For i = 0 To .CalculationVariables.Dimension
                        LocVector.Component(i) = CDec(GrpStartParameter.Controls.Item("TxtP" & (i + 2 + ConstantsDimension)).Text)
                    Next
                    .CalculationVariables = LocVector
                    .IsStartparameter1Set = True
                    .IsStartparameter2Set = True

                    .PrepareDiagram()

                End With
            Else
                MessageBox.Show(FrmMain.LM.GetString("InvalidParameters"))
            End If
        End If
    End Sub

    'SECTOR CHECKS

    Private Function IsUserDataOK() As Boolean

        Dim i As Integer
        Dim OK As Boolean = True

        With DS

            Dim ConstantsDimension As Integer

            'Maybe, in some pendulums are no constants needed
            If .CalculationConstants IsNot Nothing Then
                ConstantsDimension = .CalculationConstants.Dimension
                'Constants
                For i = 0 To .CalculationConstants.Dimension
                    Dim CheckUserData As New ClsCheckUserData(DirectCast(GrpStartParameter.Controls.Item("TxtP" & (i + 1)), TextBox),
                                                              .ValueParameterDefinition.Item(i).Range)
                    OK = OK And CheckUserData.IsTxtValueAllowed
                Next
            Else
                ConstantsDimension = -1
            End If

            'Variables
            For i = 0 To .CalculationVariables.Dimension
                Dim CheckUserData As New ClsCheckUserData(DirectCast(GrpStartParameter.Controls.Item("TxtP" & (i + 2 + ConstantsDimension)), TextBox),
                                                          .ValueParameterDefinition.Item(i + 1 + ConstantsDimension).Range)
                OK = OK And CheckUserData.IsTxtValueAllowed
            Next

        End With

        Return OK

    End Function

    'SECTOR ITERATION

    Private Async Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        If IsFormLoaded Then

            If DS.IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
                If IsUserDataOK() Then
                    BtnStart.Text = FrmMain.LM.GetString("Continue")
                    BtnStart.Enabled = False
                    With DS
                        .IsStartparameter1Set = True
                        .IsStartparameter2Set = True
                        .IterationStatus = ClsDynamics.EnIterationStatus.Ready
                    End With

                    BtnReset.Enabled = False
                    BtnTakeOverStartParameter.Enabled = False
                    TrbAdditionalParameter.Enabled = False
                End If
            End If

            If DS.IterationStatus = ClsDynamics.EnIterationStatus.Ready _
                Or DS.IterationStatus = ClsDynamics.EnIterationStatus.Interrupted Then
                DS.IterationStatus = ClsDynamics.EnIterationStatus.Running

                Application.DoEvents()

                Await DS.IterationLoop(False)
            End If

        End If
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click

        If IsFormLoaded Then
            'the iteration was running and is interrupted
            DS.IterationStatus = ClsDynamics.EnIterationStatus.Interrupted
            'the iteration is stooped by reset the iteration

            BtnStart.Enabled = True
            BtnReset.Enabled = True
            BtnTakeOverStartParameter.Enabled = True
            TrbAdditionalParameter.Enabled = True
        End If
    End Sub

End Class