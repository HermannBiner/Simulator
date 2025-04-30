'This class contains the controller for FrmPendulum

'Status Checked

Imports System.Reflection

Public Class ClsPendulumController

    'The dynamic System
    Private MainDS As IPendulum
    Private TypeOfMainDS As Type

    'ShadowDS is a pendulum that takes over all parameters
    'from MainDS, but with a very little difference in the StartParameters
    'ShadowDS is deleted, if the MainDS Parameters are changed
    'and ShadowDS is only generated, if the MainDS Parameters are all set
    Private ShadowDS As IPendulum

    Private ReadOnly MyForm As FrmPendulum

    Private ReadOnly LM As ClsLanguageManager

    'Iteration Status
    Private IterationStatus As ClsDynamics.EnIterationStatus

    'Number of Steps
    Private N As Integer

    'Set Startposition by the mouse
    Private IsMouseDown As Boolean

    'MyEnergy
    Private ReadOnly PicEnergyGraphics As Graphics
    Private StartEnergy As Decimal

    Private Const EnergyTolerance As Decimal = CDec(0.1)

    Private Const DeltaShadowDS As Decimal = CDec(0.005)

    'SECTOR INITIALIZATION

    Public Sub New(Form As FrmPendulum)
        MyForm = Form
        LM = ClsLanguageManager.LM
        PicEnergyGraphics = MyForm.PicEnergy.CreateGraphics
    End Sub

    Public Sub FillDynamicSystem()
        MyForm.CboPendulum.Items.Clear()

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
                PendulumName = LM.GetString(type.Name, True)
                MyForm.CboPendulum.Items.Add(PendulumName)
            Next
        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If
        MyForm.CboPendulum.SelectedIndex = 0

    End Sub

    Public Sub SetDS()

        'This sets the type of Pendulum by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IPendulum)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If MyForm.CboPendulum.SelectedIndex >= 0 Then

            Dim SelectedName As String = MyForm.CboPendulum.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If LM.GetString(type.Name, True) = SelectedName Then
                        TypeOfMainDS = type
                        MainDS = CType(Activator.CreateInstance(type), IPendulum)
                        Exit For
                    End If
                Next
            End If
        End If

        InitializeMe()

        SetDefaultUserData()

        ResetIteration()

    End Sub

    Public Sub InitializeMe()
        With MainDS
            .IsMainDS = True
            .PendulumColor = Brushes.Red
            .PicDiagram = MyForm.PicDiagram
            .PicPhaseportrait = MyForm.PicPhasePortrait
            .Protocol = MyForm.LstProtocol
            .LblStepWidth = MyForm.LblStepWidth

            MyForm.TrbAdditionalParameter.Minimum = CInt(.AdditionalParameter.Range.A)
            MyForm.TrbAdditionalParameter.Maximum = CInt(.AdditionalParameter.Range.B)
            MyForm.TrbAdditionalParameter.Value = CInt(.AdditionalParameter.Range.A + 0.5 *
                .AdditionalParameter.Range.IntervalWidth)

            MyForm.LblAdditionalParameter.Text = .AdditionalParameter.Name & ": " &
                .GetAddParameterValue(MyForm.TrbAdditionalParameter.Value).ToString

            Dim i As Integer
            For i = 1 To 6
                MyForm.GrpStartParameter.Controls.Item("LblP" & i.ToString).Visible = (i <= .ValueParameterDefinition.Count)
                MyForm.GrpStartParameter.Controls.Item("TxtP" & i.ToString).Visible = (i <= .ValueParameterDefinition.Count)
            Next

            Dim LocValueParameter As ClsGeneralParameter
            For Each LocValueParameter In .ValueParameterDefinition
                MyForm.GrpStartParameter.Controls.Item("LblP" & LocValueParameter.ID).Text = LocValueParameter.Name
            Next

            .StepWidth = MyForm.TrbStepWidth.Value

            MyForm.CboTypeofPhaseportrait.Items.Clear()

            Dim TypesofPhaseportrait As List(Of String) = .GetTypesofPhaseportrait
            For Each PhaPorType As String In TypesofPhaseportrait
                MyForm.CboTypeofPhaseportrait.Items.Add(LM.GetString(PhaPorType))
            Next

            MyForm.CboTypeofPhaseportrait.SelectedIndex = 0
            .PhaseportraitIndex = 0
            MyForm.LblPhasePortrait.Text = .LabelPhasePortrait
            MyForm.LblProtocol.Text = .LabelProtocol

        End With

        MyForm.BtnCreatePendulum.Text = LM.GetString("CreatePendulum")

        IterationStatus = ClsDynamics.EnIterationStatus.Stopped
        IsMouseDown = False

    End Sub

    Public Sub ResetIteration()

        'Clear Diagram and Bitmap and all Iteration Parameters in DS
        MainDS.ResetIteration()
        MyForm.BtnStart.Text = LM.GetString("Start")
        MyForm.BtnTakeOverStartParameter.Enabled = True
        MyForm.TrbAdditionalParameter.Enabled = True
        MyForm.BtnCreatePendulum.Text = LM.GetString("CreatePendulum")

        If ShadowDS IsNot Nothing Then
            RemoveShadowDS()
        End If

        MyForm.PicEnergy.Refresh()

        N = 0
        MyForm.LblSteps.Text = "0"
        StartEnergy = 0

        SetControlsEnabled(True)
        IterationStatus = ClsDynamics.EnIterationStatus.Stopped

    End Sub

    Public Sub SetDefaultUserData()

        With MainDS

            .SetDefaultUserData()

            Dim ConstantsDimension As Integer
            If .CalculationConstants IsNot Nothing Then
                ConstantsDimension = .CalculationConstants.Dimension
                For i = 0 To ConstantsDimension
                    MyForm.GrpStartParameter.Controls.Item("TxtP" & (i + 1).ToString).Text =
                        .CalculationConstants.Component(i).ToString
                Next
            Else
                ConstantsDimension = -1
            End If

            For i = 0 To .CalculationVariables.Dimension
                MyForm.GrpStartParameter.Controls.Item("TxtP" & (i + 2 + ConstantsDimension).ToString).Text =
                    .CalculationVariables.Component(i).ToString
            Next

            .SetAdditionalParameters()
            .PrepareDiagram()

        End With
    End Sub

    Public Sub SetTrbAdditionalParameter()
        With MyForm
            .LblAdditionalParameter.Text = MainDS.AdditionalParameter.Name & ": " & MainDS.GetAddParameterValue(.TrbAdditionalParameter.Value).ToString
            MainDS.AdditionalParameterValue = .TrbAdditionalParameter.Value
        End With

        'This will also SetAdditionalParameters
        MainDS.SetDefaultUserData()

        If ShadowDS IsNot Nothing Then
            ShadowDS = Nothing
        End If
        MainDS.PrepareDiagram()

    End Sub

    Public Sub SetTypeOfPhasePortrait()
        MainDS.PhaseportraitIndex = MyForm.CboTypeofPhaseportrait.SelectedIndex
        MyForm.LblPhasePortrait.Text = MainDS.LabelPhasePortrait
    End Sub

    Public Sub SetStepWidth()
        MainDS.StepWidth = MyForm.TrbStepWidth.Value
        If ShadowDS IsNot Nothing Then
            ShadowDS.StepWidth = MyForm.TrbStepWidth.Value
        End If
    End Sub

    Private Sub SetControlsEnabled(IsEnabled As Boolean)
        With MyForm
            .BtnStart.Enabled = IsEnabled
            .BtnDefault.Enabled = IsEnabled
            .BtnReset.Enabled = IsEnabled
            .BtnTakeOverStartParameter.Enabled = IsEnabled
            .BtnCreatePendulum.Enabled = IsEnabled
            .TrbAdditionalParameter.Enabled = IsEnabled
            .ChkProtocol.Enabled = IsEnabled
            .CboPendulum.Enabled = IsEnabled
            .CboTypeofPhaseportrait.Enabled = IsEnabled
            .TxtP1.Enabled = IsEnabled
            .TxtP2.Enabled = IsEnabled
            .TxtP3.Enabled = IsEnabled
            .TxtP4.Enabled = IsEnabled
            .TxtP5.Enabled = IsEnabled
            .TxtP6.Enabled = IsEnabled
        End With
    End Sub

    'SECTOR CREATE NEW OBJECT

    Public Sub CreateOrRemovePendulum()

        ResetIteration()

        If ShadowDS Is Nothing Then

            'The position of MainDS is fixed
            With MainDS
                .IsStartparameter1Set = True
                .IsStartparameter2Set = True
            End With

            ShadowDS = MainDS.GetCopy

            With ShadowDS
                .IsMainDS = False
                .PendulumColor = Brushes.Green
                .PicDiagram = MyForm.PicDiagram
                .PicGraphics = MainDS.PicGraphics
                .BmpDiagram = MainDS.BmpDiagram
                .BmpGraphics = MainDS.BmpGraphics
                .PicPhaseportrait = MyForm.PicPhasePortrait
                .PicPhasePortraitGraphics = MainDS.PicPhasePortraitGraphics
                .BmpPhasePortrait = MainDS.BmpPhasePortrait
                .BmpPhasePortraitGraphics = MainDS.BmpPhasePortraitGraphics
                .IsProtocol = False
                .StepWidth = MyForm.TrbStepWidth.Value
                .AdditionalParameterValue = MainDS.AdditionalParameterValue

                'Takeover Parameters from MainDS
                Dim i As Integer
                Dim ConstantsDimension As Integer
                Dim LocVector As ClsNTupel
                If MainDS.CalculationConstants IsNot Nothing Then
                    LocVector = New ClsNTupel(MainDS.CalculationConstants.Dimension)

                    ConstantsDimension = MainDS.CalculationConstants.Dimension

                    'Constants
                    For i = 0 To .CalculationConstants.Dimension
                        LocVector.Component(i) = MainDS.CalculationConstants.Component(i)
                    Next
                    .CalculationConstants = LocVector
                Else
                    ConstantsDimension = -1
                End If

                LocVector = New ClsNTupel(.CalculationVariables.Dimension)

                'Variables
                For i = 0 To MainDS.CalculationVariables.Dimension
                    LocVector.Component(i) = MainDS.CalculationVariables.Component(i) + DeltaShadowDS
                Next
                .CalculationVariables = LocVector
                .IsStartparameter1Set = True
                .IsStartparameter2Set = True
                .SetAdditionalParameters()
            End With
        Else
            RemoveShadowDS()
        End If

        If ShadowDS IsNot Nothing Then
            MyForm.BtnCreatePendulum.Enabled = False
        Else
            MyForm.BtnCreatePendulum.Enabled = True
            MyForm.BtnCreatePendulum.Text = LM.GetString("CreatePendulum")
        End If

    End Sub

    Private Sub RemoveShadowDS()
        If ShadowDS IsNot Nothing Then
            ShadowDS = Nothing
        End If
    End Sub

    'SECTOR ITERATION

    Public Async Sub StartIteration()

        'UserData are always OK
        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            If IsUserDataOK() Then

                If ShadowDS IsNot Nothing Then
                    With ShadowDS
                        .IsStartparameter1Set = True
                        .IsStartparameter2Set = True
                        .SetAdditionalParameters()
                    End With
                End If

                With MainDS
                        .IsStartparameter1Set = True
                        .IsStartparameter2Set = True
                        StartEnergy = .GetEnergy
                    .IsProtocol = MyForm.ChkProtocol.Checked
                    .SetAdditionalParameters()
                End With

                    IterationStatus = ClsDynamics.EnIterationStatus.Ready

                End If
            End If

        If IterationStatus = ClsDynamics.EnIterationStatus.Ready _
            Or IterationStatus = ClsDynamics.EnIterationStatus.Interrupted Then
            SetControlsEnabled(False)
            With MyForm
                .BtnStart.Text = LM.GetString("Continue")
                .Cursor = Cursors.WaitCursor
            End With

            IterationStatus = ClsDynamics.EnIterationStatus.Running

            Application.DoEvents()
            Await IterationLoop(False)
        End If
    End Sub

    Public Async Function IterationLoop(IsTestmode As Boolean) As Task

        'This is the main Iteraion Loop
        Dim ActualEnergy As Decimal
        Dim MyBrush As Brush
        Dim Value As Integer

        Do
            N += 1

            MainDS.IterationStep(IsTestmode)

            If ShadowDS IsNot Nothing Then
                ShadowDS.IterationStep(IsTestmode)
            End If


            'Controlling the Energy Range
            ActualEnergy = MainDS.GetEnergy()

            Select Case True
                Case ActualEnergy > StartEnergy + EnergyTolerance * MainDS.StartEnergyRange.IntervalWidth
                    MyBrush = Brushes.Red
                Case ActualEnergy < StartEnergy - EnergyTolerance * MainDS.StartEnergyRange.IntervalWidth
                    MyBrush = Brushes.DarkViolet
                Case Else
                    MyBrush = Brushes.Green
            End Select

            MyForm.PicEnergy.Refresh()

            'Set the StatusBar of the Energy
            Value = CInt(Math.Min(MyForm.PicEnergy.Width, (ActualEnergy - MainDS.StartEnergyRange.A) * MyForm.PicEnergy.Width / MainDS.StartEnergyRange.IntervalWidth))
            PicEnergyGraphics.FillRectangle(MyBrush, New Rectangle(0, 0, Value, MyForm.PicEnergy.Height))

            If N Mod 100 = 0 Then

                MyForm.LblSteps.Text = N.ToString

                Await Task.Delay(1)
            End If

        Loop Until IterationStatus = ClsDynamics.EnIterationStatus.Interrupted _
            Or IterationStatus = ClsDynamics.EnIterationStatus.Stopped

    End Function

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

        Dim i As Integer
        Dim IsOK As Boolean = True

        With MainDS

            Dim ConstantsDimension As Integer

            'Maybe, in some pendulums are no constants needed
            If .CalculationConstants IsNot Nothing Then
                ConstantsDimension = .CalculationConstants.Dimension
                'Constants
                For i = 0 To .CalculationConstants.Dimension
                    Dim CheckUserData As New ClsCheckUserData(DirectCast(MyForm.GrpStartParameter.Controls.Item("TxtP" & (i + 1)), TextBox),
                                                              .ValueParameterDefinition.Item(i).Range)
                    IsOK = IsOK And CheckUserData.IsTxtValueAllowed
                Next
            Else
                ConstantsDimension = -1
            End If

            'Variables
            For i = 0 To .CalculationVariables.Dimension
                Dim CheckUserData As New ClsCheckUserData(DirectCast(MyForm.GrpStartParameter.Controls.Item("TxtP" & (i + 2 + ConstantsDimension)), TextBox),
                                                          .ValueParameterDefinition.Item(i + 1 + ConstantsDimension).Range)
                IsOK = IsOK And CheckUserData.IsTxtValueAllowed
            Next

        End With

        Return IsOK

    End Function

    'SECTOR SET STARTPARAMETER

    Public Sub MouseDown(e As MouseEventArgs)

        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            If Not (MainDS.IsStartparameter1Set And MainDS.IsStartparameter2Set) Then

                MyForm.Cursor = Cursors.Hand
                IsMouseDown = True

                'Now, Moving the Mouse moves the active Pendulum
                MouseMove(e)

            End If
        End If

    End Sub

    Public Sub MouseMove(e As MouseEventArgs)

        If IsMouseDown Then
            'Because the Cursor is "Hand", the Mouse Position is adjusted a bit
            Dim Mouseposition As New Point With {
            .X = e.X + 2,
            .Y = e.Y
        }

            Dim i As Integer

            If MainDS IsNot Nothing Then

                With MainDS
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
                            MyForm.GrpStartParameter.Controls.Item("TxtP" & (i + 1).ToString).Text =
                                .CalculationConstants.Component(i).ToString
                        Next
                    Else
                        ConstantsDimension = -1
                    End If

                    For i = 0 To .CalculationVariables.Dimension
                        MyForm.GrpStartParameter.Controls.Item("TxtP" & (i + 2 + ConstantsDimension).ToString).Text =
                            .CalculationVariables.Component(i).ToString
                    Next

                End With

            End If
        End If
    End Sub

    Public Sub MouseUp()
        'Has only an effect, if the Mouse was down
        If IsMouseDown Then

            With MainDS
                If Not .IsStartparameter1Set Then

                    'The setting of Parameter1 i now blocked
                    .IsStartparameter1Set = True

                ElseIf Not .IsStartparameter2Set Then

                    'nothing
                    'Startparameter2 is fixed when starting

                End If
            End With

            'The Mouse gets its normal behaviour again
            MyForm.Cursor = Cursors.Arrow
            IsMouseDown = False

        End If
    End Sub
    Public Sub TakeOverStartParameter()
        If IsUserDataOK() Then

            Dim i As Integer
            Dim ConstantsDimension As Integer
            Dim LocVector As ClsNTupel

            'Delete ShadowDS
            If ShadowDS IsNot Nothing Then
                ShadowDS = Nothing
            End If

            With MainDS
                If .CalculationConstants IsNot Nothing Then
                    LocVector = New ClsNTupel(.CalculationConstants.Dimension)

                    ConstantsDimension = .CalculationConstants.Dimension
                    'Constants
                    For i = 0 To .CalculationConstants.Dimension
                        LocVector.Component(i) = CDec(MyForm.GrpStartParameter.Controls.Item("TxtP" & (i + 1)).Text)
                    Next
                    .CalculationConstants = LocVector
                Else
                    ConstantsDimension = -1
                End If

                LocVector = New ClsNTupel(.CalculationVariables.Dimension)

                'Variables
                For i = 0 To .CalculationVariables.Dimension
                    LocVector.Component(i) = CDec(MyForm.GrpStartParameter.Controls.Item("TxtP" & (i + 2 + ConstantsDimension)).Text)
                Next
                .CalculationVariables = LocVector
                .IsStartparameter1Set = True
                .IsStartparameter2Set = True

                .PrepareDiagram()

            End With

        Else
            MessageBox.Show(LM.GetString("InvalidParameters"))
        End If
    End Sub

End Class
