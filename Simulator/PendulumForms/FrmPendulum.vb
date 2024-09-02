'This Form is the User Interface for all Investigations of different Pendulums
'like Double Pendulum, Combined Pendulum or Shake Pendulum
'it is based on the interfaces IPendulum
'that are implemented by the according classes ClsDoublePendulum, ClsCombinedPendulum etc.
'see mathematical documentation
'if other Pendulums are programmed, the according classes have just to implement this interfaces

'Status Checked

Imports System.Reflection

Public Class FrmPendulum

    'Graphic object for local drawings
    Private MapPendulum As Bitmap
    Private MapPhaseportrait As Bitmap

    'To show the total energy
    Private StatusGraphics As Graphics

    'Active Pendulum
    Private ActivePendulum As IPendulum

    'Mathematical Coordinates
    Private MathInterval As ClsInterval

    'Iteration Control
    Private StopIteration As Boolean

    'Number of Steps
    Private n As Integer

    'Start Energy
    Private StartEnergy As Decimal

    'The Startposition of the Pendulum is set by the Mouse
    Private IsMousedown As Boolean = False

    Private Const EnergyTolerance As Decimal = CDec(0.1)
    Private Const StepWidthUnit As Decimal = CDec(0.0001)

    'For debugging issues
    Private Const IsTestMode As Boolean = False


    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub InitializeLanguage()

        Text = FrmMain.LM.GetString("Pendulum")
        LblPendulum.Text = FrmMain.LM.GetString("Pendulum")
        LblParameterc.Text = FrmMain.LM.GetString("Energy")

        'LblSteps contains the  #Steps
        LblNumberOfSteps.Text = FrmMain.LM.GetString("NumberOfSteps")

        'LblAdditionParameter, LblP1 ... LblP5 is set by the Active Pendulum
        BtnTakeOverStartParameter.Text = FrmMain.LM.GetString("TakeOver")
        GrpStartParameter.Text = FrmMain.LM.GetString("StartParameter")
        BtnReset.Text = FrmMain.LM.GetString("ResetIteration")
        TxtFactor.Text = ""
        BtnStart.Text = FrmMain.LM.GetString("Start")
        LblStepWidth.Text = FrmMain.LM.GetString("StepWidth") & ": " & (TrbStepWidth.Value * StepWidthUnit).ToString
        LblTypeofPhaseportrait.Text = FrmMain.LM.GetString("TypeofPhaseportrait")

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

            CboPendulum.SelectedIndex = CboPendulum.Items.Count - 1
            CboPendulum.Select()

        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If

    End Sub

    Private Sub FrmPendulum_Load(sender As Object, e As EventArgs) Handles Me.Load

        'The Bitmap "MapPendulum" shows the Trace of the Pendulum
        'the actual position of the Pendulum is shown in the PicPendulum and 
        'actualized by refreshing PicPendulum
        'the Bitmap and PicDiagram are Squares

        MathInterval = New ClsInterval(-1, 1)

        Dim Squareside As Integer = Math.Min(PicPendulum.Width, PicPendulum.Height)
        PicPendulum.Width = Squareside
        PicPendulum.Height = Squareside

        MapPendulum = New Bitmap(Squareside, Squareside)

        'The Bitmap MapPendulum is then shown as Image of PicPendulum
        PicPendulum.Image = MapPendulum

        'The Phase Portrait is a square
        Squareside = Math.Min(PicPhasePortrait.Width, PicPhasePortrait.Height)
        PicPhasePortrait.Width = Squareside
        PicPhasePortrait.Height = Squareside

        MapPhaseportrait = New Bitmap(Squareside, Squareside)
        PicPhasePortrait.Image = MapPhaseportrait

        'to show the total energy
        StatusGraphics = PicStatus.CreateGraphics

        'Initialize Language
        InitializeLanguage()

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click

        Reset()

    End Sub

    Sub Reset()

        'Clear Diagram and Bitmap
        ActivePendulum.Reset()
        PicPhasePortrait.Refresh()
        LstParameterList.Items.Clear()
        n = 0
        LblSteps.Text = "0"

        ActivePendulum.IsStartparameter1Set = False
        ActivePendulum.IsStartparameter2Set = False

        ActivePendulum.DrawCoordinateSystem()
        PicPendulum.Invalidate()

        'Draw active pendulum
        ActivePendulum.DrawPendulums()

        'Iteration Control
        StopIteration = True

        BtnStart.Text = FrmMain.LM.GetString("Start")
        BtnTakeOverStartParameter.Enabled = True
        TrbAdditionalParameter.Enabled = True

    End Sub

    Private Sub CboPendulum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboPendulum.SelectedIndexChanged

        ActivePendulum = InitializePendulum()
        Reset()

    End Sub

    Function InitializePendulum() As IPendulum

        'This sets the type of Pendulum by Reflection
        'Default is DoublePendulum
        Dim LocPendulum As IPendulum = New ClsDoublePendulum

        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IPendulum)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If CboPendulum.SelectedIndex >= 0 Then

            Dim SelectedName As String = CboPendulum.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If FrmMain.LM.GetString(type.Name, True) = SelectedName Then
                        LocPendulum = CType(Activator.CreateInstance(type), IPendulum)
                    End If
                Next
            End If

        End If

        With LocPendulum
            .PicPendulum = PicPendulum
            .MapPendulum = MapPendulum
            .PicPhaseportrait = PicPhasePortrait
            .MapPhaseportrait = MapPhaseportrait
            .ParameterListbox = LstParameterList

            TxtFactor.Text = .C.ToString("N10")
            LblParameterc.Text = .LabelParameterC
            TrbAdditionalParameter.Minimum = CInt(.AdditionalParameter.Range.A)
            TrbAdditionalParameter.Maximum = CInt(.AdditionalParameter.Range.B)
            TrbAdditionalParameter.Value = CInt(.AdditionalParameter.Tag)

            LblAdditionalParameter.Text = .AdditionalParameter.Name & ": " & .CalcValuefromTrbAddParameter(TrbAdditionalParameter.Value).ToString
            LblPhasePortrait.Text = .LabelPhasePortrait

            Dim i As Integer
            For i = 1 To 6
                GrpStartParameter.Controls.Item("LblP" & i.ToString).Visible = (i <= .ValueParameters.Count)
                GrpStartParameter.Controls.Item("TxtP" & i.ToString).Visible = (i <= .ValueParameters.Count)
            Next

            Dim LocValueParameter As ClsValueParameter
            For Each LocValueParameter In .ValueParameters
                GrpStartParameter.Controls.Item("LblP" & LocValueParameter.Tag).Text = LocValueParameter.Name
            Next

            Dim ConstantsDimension As Integer
            If .Constants IsNot Nothing Then
                ConstantsDimension = .Constants.Dimension
                For i = 0 To ConstantsDimension
                    GrpStartParameter.Controls.Item("TxtP" & (i + 1).ToString).Text = .Constants.Component(i).ToString
                Next
            Else
                ConstantsDimension = -1
            End If

            For i = 0 To .Variables.Dimension
                GrpStartParameter.Controls.Item("TxtP" & (i + 2 + ConstantsDimension).ToString).Text = .Variables.Component(i).ToString
            Next

            .AdditionalParameterValue = TrbAdditionalParameter.Value
            .StepWidth = TrbStepWidth.Value * StepWidthUnit
            .TestMode = IsTestMode
            StartEnergy = .Energy

            CboTypeofPhaseportrait.Items.Clear()

            Dim TypesofPhaseportrait As List(Of String) = .GetTypesofPhaseportrait
            For Each PhaPorType As String In TypesofPhaseportrait
                CboTypeofPhaseportrait.Items.Add(FrmMain.LM.GetString(PhaPorType))
            Next

            CboTypeofPhaseportrait.SelectedIndex = 0
            .PhaseportraitIndex = 0
            LblPhasePortrait.Text = .LabelPhasePortrait
            LblParameterlist.Text = .LabelParameterList
        End With

        Return LocPendulum

    End Function

    Private Sub TrbAdditionalParameter_Scroll(sender As Object, e As EventArgs) Handles TrbAdditionalParameter.Scroll

        With ActivePendulum
            LblAdditionalParameter.Text = .AdditionalParameter.Name & ": " & .CalcValuefromTrbAddParameter(TrbAdditionalParameter.Value).ToString
            .AdditionalParameterValue = TrbAdditionalParameter.Value
            .DrawCoordinateSystem()
            .DrawPendulums()
            TxtFactor.Text = .C.ToString("N10")
            StartEnergy = .Energy
        End With

    End Sub

    Private Sub CboTypeofPhaseportrait_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboTypeofPhaseportrait.SelectedIndexChanged

        If ActivePendulum IsNot Nothing Then
            ActivePendulum.PhaseportraitIndex = CboTypeofPhaseportrait.SelectedIndex
            LblPhasePortrait.Text = ActivePendulum.LabelPhasePortrait
            Reset()
        End If

    End Sub

    Private Sub TrbStepWide_Scroll(sender As Object, e As EventArgs) Handles TrbStepWidth.Scroll

        LblStepWidth.Text = FrmMain.LM.GetString("StepWidth") & ": " & (TrbStepWidth.Value * StepWidthUnit).ToString
        ActivePendulum.StepWidth = CDec(TrbStepWidth.Value * StepWidthUnit)

    End Sub

    Private Sub FrmPendulum_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Reset()

    End Sub

    'SECTOR SET STARTPOSITION

    Private Sub PicPendulum_MouseDown(sender As Object, e As MouseEventArgs) Handles PicPendulum.MouseDown

        If ActivePendulum IsNot Nothing Then

            If Not (ActivePendulum.IsStartparameter1Set And ActivePendulum.IsStartparameter2Set) Then

                Cursor = Cursors.Hand
                IsMousedown = True

                'Now, Moving the Mouse moves the active Pendulum
                MouseMoving(e)

            End If
        End If
    End Sub

    Private Sub PicPendulum_MouseMove(sender As Object, e As MouseEventArgs) Handles PicPendulum.MouseMove

        If IsMousedown Then
            MouseMoving(e)
        End If

    End Sub

    Private Sub PicPendulum_MouseUp(sender As Object, e As MouseEventArgs) Handles PicPendulum.MouseUp

        'Has only an effect, if the Mouse was down
        If IsMousedown Then

            With ActivePendulum
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

        If ActivePendulum IsNot Nothing Then

            With ActivePendulum
                If Not .IsStartparameter1Set Then

                    'The actual Position of the Mouse sets Parameter1
                    .SetAndDrawStartparameter1(Mouseposition)

                ElseIf Not .IsStartparameter2Set Then

                    'The actual Position of the Mouse sets Parameter2
                    .SetAndDrawStartparameter2(Mouseposition)

                End If

                Dim ConstantsDimension As Integer

                If .Constants IsNot Nothing Then
                    ConstantsDimension = .Constants.Dimension
                    For i = 0 To .Constants.Dimension
                        GrpStartParameter.Controls.Item("TxtP" & (i + 1).ToString).Text = .Constants.Component(i).ToString
                    Next
                Else
                    ConstantsDimension = -1
                End If

                For i = 0 To .Variables.Dimension
                    GrpStartParameter.Controls.Item("TxtP" & (i + 2 + ConstantsDimension).ToString).Text = .Variables.Component(i).ToString
                Next

                TxtFactor.Text = .C.ToString("N10")

            End With

        End If
    End Sub

    Private Sub BtnTakeOverStartParameter_Click(sender As Object, e As EventArgs) Handles BtnTakeOverStartParameter.Click

        If CheckParametersOK() Then

            With ActivePendulum

                Dim i As Integer
                Dim ConstantsDimension As Integer
                Dim LocVector As ClsVector

                If .Constants IsNot Nothing Then
                    LocVector = New ClsVector(.Constants.Dimension)

                    ConstantsDimension = .Constants.Dimension
                    'Constants
                    For i = 0 To .Constants.Dimension
                        LocVector.Component(i) = CDec(GrpStartParameter.Controls.Item("TxtP" & (i + 1)).Text)
                    Next
                    .Constants = LocVector
                Else
                    ConstantsDimension = -1
                End If


                LocVector = New ClsVector(.Variables.Dimension)

                'Variables
                For i = 0 To .Variables.Dimension
                    LocVector.Component(i) = CDec(GrpStartParameter.Controls.Item("TxtP" & (i + 2 + ConstantsDimension)).Text)
                Next
                .Variables = LocVector
                TxtFactor.Text = .C.ToString("N10")
                StartEnergy = .Energy
                .IsStartparameter1Set = True
                .IsStartparameter2Set = True

                .DrawPendulums()

            End With
        Else
            MessageBox.Show(FrmMain.LM.GetString("InvalidParameters"))
        End If

    End Sub

    'SECTOR CHECKS

    Private Function CheckParametersOK() As Boolean

        Dim i As Integer
        Dim LocValue As Decimal
        Dim OK As Boolean = True

        With ActivePendulum

            Dim ConstantsDimension As Integer

            'Maybe, in some pendulums are no constants needed
            If .Constants IsNot Nothing Then
                ConstantsDimension = .Constants.Dimension
                'Constants
                For i = 0 To .Constants.Dimension
                    LocValue = CDec(GrpStartParameter.Controls.Item("TxtP" & (i + 1)).Text)
                    OK = OK And .ValueParameters.Item(i).Range.A <= LocValue And LocValue <= .ValueParameters.Item(i).Range.B
                Next
            Else
                ConstantsDimension = -1
            End If

            'Variables
            For i = 0 To .Variables.Dimension
                LocValue = CDec(GrpStartParameter.Controls.Item("TxtP" & (i + 2 + ConstantsDimension)).Text)
                OK = OK And .ValueParameters.Item(i + 1 + ConstantsDimension).Range.A <= LocValue And LocValue <= .ValueParameters.Item(i + 1 + ConstantsDimension).Range.B
            Next

        End With

        Return OK

    End Function

    'SECTOR ITERATION

    Private Async Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click

        'the iteration was stopped or reset
        'and should start from the beginning
        StopIteration = False

        BtnStart.Text = FrmMain.LM.GetString("Continue")
        BtnStart.Enabled = False

        With ActivePendulum
            .IsStartparameter1Set = True
            .IsStartparameter2Set = True
            StartEnergy = .Energy
        End With

        BtnReset.Enabled = False
        BtnTakeOverStartParameter.Enabled = False
        TrbAdditionalParameter.Enabled = False

        Application.DoEvents()

        Await IterationLoop()

    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click

        'the iteration is running and should be stopped
        StopIteration = True

        BtnStart.Enabled = True
        BtnReset.Enabled = True
        BtnTakeOverStartParameter.Enabled = True
        TrbAdditionalParameter.Enabled = True

    End Sub

    Private Async Function IterationLoop() As Task

        Dim StartEnergyRange As ClsInterval = ActivePendulum.StartEnergyRange
        Dim ActualEnergy As Decimal
        Dim MyBrush As Brush
        Dim Value As Integer

        Do
            n += 1
            ActivePendulum.Iteration(IsTestMode)
            ActualEnergy = CDec(ActivePendulum.Energy)

            Select Case True
                Case ActualEnergy > StartEnergy + EnergyTolerance * StartEnergyRange.IntervalWidth
                    MyBrush = Brushes.Red
                Case ActualEnergy < StartEnergy - EnergyTolerance * StartEnergyRange.IntervalWidth
                    MyBrush = Brushes.DarkViolet
                Case Else
                    MyBrush = Brushes.Green
            End Select

            PicStatus.Refresh()

            'Set the StatusBar
            Value = CInt(Math.Min(PicStatus.Width, (ActualEnergy - StartEnergyRange.A) * PicStatus.Width / StartEnergyRange.IntervalWidth))
            StatusGraphics.FillRectangle(MyBrush, New Rectangle(0, 0, Value, PicStatus.Height))

            If n Mod 10 = 0 Then

                LblSteps.Text = n.ToString

                Await Task.Delay(2)
            End If

        Loop Until StopIteration

    End Function

End Class