'This Form is the User Interface for all Investigations of different Pendulums
'like Double Pendulum, Combined Pendulum or Shake Pendulum
'it is based on the interfaces IPendulum
'that are implemented by the according classes ClsDoublePendulum, ClsCombinedPendulum etc.
'see mathematical documentation
'if other Pendulums are programmed, the according classes have just to implement this interfaces

'Status UnChecked

Imports System.Globalization
Imports System.Reflection

Public Class FrmPendulum

    'Graphic object for local drawings
    Private MyBitmapGraphics As ClsGraphicTool
    Private MapPendulum As Bitmap

    'Active Pendulum
    Private ActivePendulum As IPendulum

    'Mathematical Coordinates
    Private MathInterval As ClsInterval

    'Iteration Control
    Private StopIteration As Boolean
    Private InitializeIteration As Boolean

    'Number of Steps
    Private n As Integer

    'The Startposition of the Pendulum is set by the Mouse
    Private IsMousedown As Boolean = False


    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub InitializeLanguage()

        Text = Main.LM.GetString("Pendulum")
        LblPendulum.Text = Main.LM.GetString("Pendulum")
        LblParameterc.Text = Main.LM.GetString("FactorC")

        'LblSteps contains the  #Steps
        LblNumberOfSteps.Text = Main.LM.GetString("NumberOfSteps")

        'LblAdditionParameter, LblP1 ... LblP5 is set by the Active Pendulum
        BtnTakeOverStartParameter.Text = Main.LM.GetString("TakeOver")
        GrpStartParameter.Text = Main.LM.GetString("StartParameter")
        BtnReset.Text = Main.LM.GetString("ResetIteration")
        TxtFactor.Text = ""
        BtnStart.Text = Main.LM.GetString("Start")
        BtnStop.Text = Main.LM.GetString("Stop")
        ChkTestMode.Text = Main.LM.GetString("TestMode")
        LblStepWidth.Text = Main.LM.GetString("StepWidth") & ": " & (TrbStepWidth.Value * 0.002).ToString

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
                PendulumName = Main.LM.GetString(type.Name, True)
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
        Dim Squareside As Integer = Math.Min(PicPendulum.Width, PicPendulum.Height)
        PicPendulum.Width = Squareside
        PicPendulum.Height = Squareside

        MathInterval = New ClsInterval(-1, 1)

        MapPendulum = New Bitmap(Squareside, Squareside)
        MyBitmapGraphics = New ClsGraphicTool(MapPendulum, MathInterval, MathInterval)

        'The Bitmap MapPendulum is then shown as Image of PicPendulum
        PicPendulum.Image = MapPendulum

        'The Phase Portrait is a square
        Squareside = Math.Min(PicPhasePortrait.Width, PicPhasePortrait.Height)
        PicPhasePortrait.Width = Squareside
        PicPhasePortrait.Height = Squareside

        'Initialize Language
        InitializeLanguage()

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click

        Reset()

    End Sub

    Sub Reset()

        'This sets the active Pendulum by Reflection
        ActivePendulum = InitializePendulum()

        'Clear Diagram and Bitmap
        ActivePendulum.ClearBitmap()
        PicPhasePortrait.Refresh()
        LstParameterList.Items.Clear()
        n = 0
        LblSteps.Text = "0"

        ActivePendulum.IsStartparameter1Set = False
        ActivePendulum.IsStartparameter2Set = False

        DrawCoordinateSystem()
        PicPendulum.Invalidate()

        'Draw active pendulum
        ActivePendulum.DrawPendulum()

        'Iteration Control
        StopIteration = True
        InitializeIteration = True

        BtnStart.Text = Main.LM.GetString("Start")
        BtnTakeOverStartParameter.Enabled = True
        TrbAdditionalParameter.Enabled = True
        ChkTestMode.Enabled = True

    End Sub

    Private Sub CboPendulum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboPendulum.SelectedIndexChanged

        Reset()

    End Sub

    Function InitializePendulum() As IPendulum

        'This sets the type of Pendulum by Reflection
        'Default is DoublePendulum
        Dim LocPendulum As IPendulum = New ClsDoublePendulum

        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IBilliardball)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If CboPendulum.SelectedIndex >= 0 Then

            Dim SelectedName As String = CboPendulum.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If Main.LM.GetString(type.Name, True) = SelectedName Then
                        LocPendulum = CType(Activator.CreateInstance(type), IPendulum)
                    End If
                Next
            End If

        End If

        With LocPendulum
            .PicPendulum = PicPendulum
            .MapPendulum = MapPendulum
            .Phaseportrait = PicPhasePortrait
            .ParameterListbox = LstParameterList

            TxtFactor.Text = .C.ToString("N10")
            LblParameterc.Text = .LabelParameterC
            TrbAdditionalParameter.Minimum = CInt(.SetAdditionalParameter.Range.A)
            TrbAdditionalParameter.Maximum = CInt(.SetAdditionalParameter.Range.B)
            TrbAdditionalParameter.Value = CInt(.SetAdditionalParameter.Tag)

            LblAdditionalParameter.Text = .SetAdditionalParameter.Name & ": " & .CalcMfromTrbAddParameter(TrbAdditionalParameter.Value).ToString
            LblPhasePortrait.Text = .LabelPhasePortrait

            Dim i As Integer
            For i = 1 To 8
                GrpStartParameter.Controls.Item("LblP" & i.ToString).Visible = (i <= .ValueParameters.Count)
                GrpStartParameter.Controls.Item("TxtP" & i.ToString).Visible = (i <= .ValueParameters.Count)
            Next

            Dim LocValueParameter As ClsValueParameter
            For Each LocValueParameter In .ValueParameters
                GrpStartParameter.Controls.Item("LblP" & LocValueParameter.Tag).Text = LocValueParameter.Name
            Next

            For i = 0 To .Constants.Dimension
                GrpStartParameter.Controls.Item("TxtP" & (i + 1).ToString).Text = .Constants.Component(i).ToString
            Next

            For i = 0 To .Variables.Dimension
                GrpStartParameter.Controls.Item("TxtP" & (i + 2 + .Constants.Dimension).ToString).Text = .Variables.Component(i).ToString
            Next

            .AdditionalParameter = TrbAdditionalParameter.Value
            .StepWidth = TrbStepWidth.Value * CDec(0.002)
            .TestMode = ChkTestMode.Checked
        End With

        Return LocPendulum

    End Function

    Private Sub TrbAdditionalParameter_Scroll(sender As Object, e As EventArgs) Handles TrbAdditionalParameter.Scroll

        With ActivePendulum
            LblAdditionalParameter.Text = .SetAdditionalParameter.Name & ": " & .CalcMfromTrbAddParameter(TrbAdditionalParameter.Value).ToString
            .AdditionalParameter = TrbAdditionalParameter.Value
            .DrawPendulum()
        End With

    End Sub

    Private Sub TrbStepWide_Scroll(sender As Object, e As EventArgs) Handles TrbStepWidth.Scroll

        LblStepWidth.Text = Main.LM.GetString("StepWidth") & ": " & (TrbStepWidth.Value * 0.002).ToString
        ActivePendulum.StepWidth = CDec(TrbStepWidth.Value * 0.002)

    End Sub


    Private Sub DrawCoordinateSystem()

        'Draw Coordinate System
        MyBitmapGraphics?.DrawLine(New ClsMathpoint(-1, 0), New ClsMathpoint(1, 0), Color.Aquamarine, 1)
        MyBitmapGraphics?.DrawLine(New ClsMathpoint(0, -1), New ClsMathpoint(0, 1), Color.Aquamarine, 1)

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

                    If .Variables.Dimension = 0 Then

                        'Only one variable parameter
                        .IsStartparameter2Set = True
                    End If

                ElseIf Not .IsStartparameter2Set Then

                    .IsStartparameter2Set = True

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
            .Y = e.Y - 25
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

                For i = 0 To .Constants.Dimension
                    GrpStartParameter.Controls.Item("TxtP" & (i + 1).ToString).Text = .Constants.Component(i).ToString
                Next

                For i = 0 To .Variables.Dimension
                    GrpStartParameter.Controls.Item("TxtP" & (i + 2 + .Variables.Dimension).ToString).Text = .Variables.Component(i).ToString
                Next

                TxtFactor.Text = .C.ToString("N10")

            End With

        End If
    End Sub

    Private Sub BtnTakeOverStartParameter_Click(sender As Object, e As EventArgs) Handles BtnTakeOverStartParameter.Click

        If CheckParametersOK() Then

            With ActivePendulum

                Dim i As Integer
                Dim LocVector As New ClsVector(.Constants.Dimension)

                'Constants
                For i = 0 To .Constants.Dimension
                    LocVector.Component(i) = CDec(GrpStartParameter.Controls.Item("TxtP" & (i + 1)).Text)
                Next
                .Constants = LocVector
                .C = .Constants.Component(0) / .Constants.Component(1)
                TxtFactor.Text = .C.ToString("N10")

                LocVector = New ClsVector(.Variables.Dimension)

                'Variables
                For i = 0 To .Variables.Dimension
                    LocVector.Component(i) = CDec(GrpStartParameter.Controls.Item("TxtP" & (i + 2 + .Constants.Dimension)).Text)
                Next
                .Variables = LocVector

                .DrawPendulum()

            End With
        Else
            MessageBox.Show(Main.LM.GetString("InvalidParameters"))
        End If

    End Sub

    'SECTOR CHECKS

    Private Function CheckParametersOK() As Boolean

        Dim i As Integer
        Dim LocValue As Decimal
        Dim OK As Boolean = True

        With ActivePendulum

            'Constants
            For i = 0 To .Constants.Dimension
                LocValue = CDec(GrpStartParameter.Controls.Item("TxtP" & (i + 1)).Text)
                OK = OK And .ValueParameters.Item(i).Range.A <= LocValue And LocValue <= .ValueParameters.Item(i).Range.B
            Next

            'Variables
            For i = 0 To .Variables.Dimension
                LocValue = CDec(GrpStartParameter.Controls.Item("TxtP" & (i + 2 + .Constants.Dimension)).Text)
                OK = OK And .ValueParameters.Item(i + 1 + .Constants.Dimension).Range.A <= LocValue And LocValue <= .ValueParameters.Item(i + 1 + .Constants.Dimension).Range.B
            Next

        End With

        Return OK

    End Function

    'SECTOR ITERATION

    Private Async Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click

        With ActivePendulum
            .IsStartparameter1Set = True
            .IsStartparameter2Set = True
        End With
        StopIteration = False
        BtnStart.Enabled = False
        BtnStart.Text = Main.LM.GetString("Continue")
        BtnReset.Enabled = False
        BtnTakeOverStartParameter.Enabled = False
        TrbAdditionalParameter.Enabled = False
        ChkTestMode.Enabled = False

        Await IterationLoop()

    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click

        StopIteration = True
        BtnStart.Enabled = True
        BtnReset.Enabled = True

    End Sub

    Private Async Function IterationLoop() As Task

        'Initialize Iteration
        If InitializeIteration Then

            n = 0
            InitializeIteration = False

        End If


        Do
            n += 1
            ActivePendulum.Iteration(ChkTestMode.Checked)

            If n Mod 5 = 0 Then
                LblSteps.Text = n.ToString
                Await Task.Delay(2)
            End If

        Loop Until StopIteration

    End Function

End Class