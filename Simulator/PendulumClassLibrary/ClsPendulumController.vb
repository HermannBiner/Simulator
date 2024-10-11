'This class contains the controller for FrmPendulum

'Status Checked

Imports System.Reflection
Imports Simulator.ClsDynamics

Public Class ClsPendulumController

    'The dynamic System
    Private DS As IPendulum
    Private MyForm As FrmPendulum

    Private LM As ClsLanguageManager

    'The Graphic Helper for PicDiagram
    Private PicGraphics As ClsGraphicTool
    Private BmpDiagram As Bitmap
    Private BmpGraphics As ClsGraphicTool

    'Iteration Status
    Private IterationStatus As ClsDynamics.EnIterationStatus

    'Number of Steps
    Private N As Integer

    'Set Startposition by the mouse
    Private IsMouseDown As Boolean

    'MyEnergy
    Private PicEnergyGraphics As Graphics
    Private StartEnergy As Decimal

    Private Const EnergyTolerance As Decimal = CDec(0.1)

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
                        DS = CType(Activator.CreateInstance(type), IPendulum)
                    End If
                Next
            End If
        End If

        InitializeMe()

        SetDefaultUserData()

        ResetIteration()

    End Sub

    Private Sub InitializeMe()
        With DS
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

        IterationStatus = ClsDynamics.EnIterationStatus.Stopped
        IsMouseDown = False

    End Sub

    Public Sub SetDefaultUserData()
        With DS
            .SetDefaultUserData()
            .PrepareDiagram()

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
        End With

    End Sub

    Public Sub SetTrbAdditionalParameter()
        With MyForm
            .LblAdditionalParameter.Text = DS.AdditionalParameter.Name & ": " & DS.GetAddParameterValue(.TrbAdditionalParameter.Value).ToString
            DS.AdditionalParameterValue = .TrbAdditionalParameter.Value
        End With
    End Sub

    Public Sub SetTypeOfPhasePortrait()
        DS.PhaseportraitIndex = MyForm.CboTypeofPhaseportrait.SelectedIndex
        MyForm.LblPhasePortrait.Text = DS.LabelPhasePortrait
    End Sub

    Public Sub SetStepWidth()
        DS.StepWidth = MyForm.TrbStepWidth.Value
    End Sub

    Public Sub TakeOverStartParameter()
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

    Public Async Sub StartIteration()

        'UserData are always OK
        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            If IsUserDataOK() Then
                With DS
                    .IsStartparameter1Set = True
                    .IsStartparameter2Set = True
                    IterationStatus = ClsDynamics.EnIterationStatus.Ready
                    StartEnergy = .GetEnergy
                    .IsProtocol = MyForm.ChkProtocol.Checked
                End With
            End If
        End If

        If IterationStatus = ClsDynamics.EnIterationStatus.Ready _
            Or IterationStatus = ClsDynamics.EnIterationStatus.Interrupted Then
            With MyForm
                .BtnStart.Text = LM.GetString("Continue")
                .BtnStart.Enabled = False
                .BtnDefault.Enabled = False
                .BtnReset.Enabled = False
                .BtnTakeOverStartParameter.Enabled = False
                .TrbAdditionalParameter.Enabled = False
                .ChkProtocol.Enabled = False
                .CboPendulum.Enabled = False
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

            'Testmode for Debugging possible
            DS.IterationStep(IsTestmode)

            'Controlling the Energy Range
            ActualEnergy = DS.GetEnergy()

            Select Case True
                Case ActualEnergy > StartEnergy + EnergyTolerance * DS.StartEnergyRange.IntervalWidth
                    MyBrush = Brushes.Red
                Case ActualEnergy < StartEnergy - EnergyTolerance * DS.StartEnergyRange.IntervalWidth
                    MyBrush = Brushes.DarkViolet
                Case Else
                    MyBrush = Brushes.Green
            End Select

            MyForm.PicEnergy.Refresh()

            'Set the StatusBar of the Energy
            Value = CInt(Math.Min(MyForm.PicEnergy.Width, (ActualEnergy - DS.StartEnergyRange.A) * MyForm.PicEnergy.Width / DS.StartEnergyRange.IntervalWidth))
            PicEnergyGraphics.FillRectangle(MyBrush, New Rectangle(0, 0, Value, MyForm.PicEnergy.Height))

            If N Mod 100 = 0 Then

                MyForm.LblSteps.Text = N.ToString

                Await Task.Delay(2)
            End If

        Loop Until IterationStatus = ClsDynamics.EnIterationStatus.Interrupted _
            Or IterationStatus = ClsDynamics.EnIterationStatus.Stopped

    End Function

    Public Sub StopIteration()
        'the iteration was running and is interrupted
        IterationStatus = ClsDynamics.EnIterationStatus.Interrupted
        'the iteration is stooped by reset the iteration
        With MyForm
            .BtnStart.Enabled = True
            .BtnReset.Enabled = True
            .BtnDefault.Enabled = True
            .BtnTakeOverStartParameter.Enabled = True
            .TrbAdditionalParameter.Enabled = True
            .ChkProtocol.Enabled = True
            .CboPendulum.Enabled = True
            .Cursor = Cursors.Arrow
        End With
    End Sub

    Public Sub ResetIteration()
        'Clear Diagram and Bitmap and all Iteration Parameters in DS
        DS.ResetIteration()
        MyForm.BtnStart.Text = LM.GetString("Start")
        MyForm.BtnTakeOverStartParameter.Enabled = True
        MyForm.TrbAdditionalParameter.Enabled = True

        N = 0
        MyForm.LblSteps.Text = "0"
        StartEnergy = 0

        IterationStatus = EnIterationStatus.Stopped

    End Sub

    'SECTOR CHECKS

    Private Function IsUserDataOK() As Boolean

        Dim i As Integer
        Dim IsOK As Boolean = True

        With DS

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

    'SECTOR SET STARTPOSITION

    Public Sub MouseDown(e As MouseEventArgs)

        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            If Not (DS.IsStartparameter1Set And DS.IsStartparameter2Set) Then

                MyForm.Cursor = Cursors.Hand
                IsMouseDown = True

                'Now, Moving the Mouse moves the active Pendulum
                MouseMoving(e)

            End If
        End If

    End Sub

    Public Sub MouseMoving(e As MouseEventArgs)

        If IsMouseDown Then
            'Because the Cursor is "Hand", the Mouse Position is adjusted a bit
            Dim Mouseposition As New Point With {
            .X = e.X + 2,
            .Y = e.Y
        }

            Dim i As Integer

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
            MyForm.Cursor = Cursors.Arrow
            IsMouseDown = False

        End If
    End Sub

End Class
