'This Class contains the iteration controller for FrmHistogram

'Status Checked

Imports System.Globalization
Imports System.Reflection

Public Class ClsHistogramController

    'The dynamic System
    Private DS As IIteration

    Private ReadOnly MyForm As FrmHistogram

    Private ReadOnly LM As ClsLanguageManager

    'The Graphic Helper for PicDiagram
    Private PicGraphics As ClsGraphicTool

    'Status Parameters
    'Number of Iteration Steps
    Private n As Integer
    Private IterationStatus As ClsDynamics.EnIterationStatus

    'Actual value of the iteration
    Private x As Decimal

    'How many times does the iterated value hit a small interval?
    'NumberOfHits is an array if those intervals
    Private NumberOfHits() As Integer

    'SECTOR INITIALIZATION

    Public Sub New(Form As FrmHistogram)
        MyForm = Form
        LM = ClsLanguageManager.LM
        IterationStatus = ClsDynamics.EnIterationStatus.Stopped

    End Sub

    Public Sub FillDynamicSystem()

        MyForm.CboFunction.Items.Clear()

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
                DSName = LM.GetString(type.Name, True)
                'The case of Mandelbrot is only used for Feigenbaum Diagram
                If Not DSName.Contains("Mandel") Then
                    MyForm.CboFunction.Items.Add(DSName)
                End If
            Next
        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If
        MyForm.CboFunction.SelectedIndex = 0

    End Sub

    Public Sub SetDS()
        'This sets the type of Iterator by Reflection

        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                             Where(Function(t) t.GetInterfaces().Contains(GetType(IIteration)) AndAlso
                             t.IsClass AndAlso Not t.IsAbstract).ToList()

        If MyForm.CboFunction.SelectedIndex >= 0 Then

            Dim SelectedName As String = MyForm.CboFunction.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If LM.GetString(type.Name, True) = SelectedName Then
                        DS = CType(Activator.CreateInstance(type), IIteration)
                        Exit For
                    End If
                Next
            End If

        End If

        'As standard, the function is repeated 1x in each iteration step
        InitializeMe()

        'The parameter and startvalue are depending on the type of iteration
        SetDefaultUserData()

        'If the type of iteration changes, everything has to be reset
        'especially the status parameters
        ResetIteration()

    End Sub

    'This routine sets the DS parameters to a default
    'the trigger is, that the DS has changed
    Public Sub InitializeMe()

        Dim XRange As New ClsInterval(0, MyForm.PicDiagram.Width)
        Dim YRange As New ClsInterval(0, MyForm.PicDiagram.Height)
        PicGraphics = New ClsGraphicTool(MyForm.PicDiagram, XRange, YRange)

        'the array of small intervals is defined (pixel-size)
        ReDim NumberOfHits(MyForm.PicDiagram.Width)
        DS.Power = 1

    End Sub

    Public Sub ResetIteration()

        SetControlsEnabled(True)
        'PicDiagram cleared
        PicGraphics.Clear(Color.White)

        'Status Parameters Cleared
        MyForm.LblSteps.Text = "0"
        n = 0

        IterationStatus = ClsDynamics.EnIterationStatus.Stopped
        ReDim NumberOfHits(MyForm.PicDiagram.Width)
        MyForm.BtnStart.Text = LM.GetString("Start")

    End Sub

    'This routine sets the user data to the default
    'the trigger is, that the DS has changed
    Public Sub SetDefaultUserData()
        'default settings
        MyForm.TxtParameter.Text = DS.ChaoticParameterValue.ToString(CultureInfo.CurrentCulture)
        MyForm.TxtStartValue.Text = DS.ValueParameter.DefaultValue.ToString(CultureInfo.CurrentCulture)

    End Sub

    Private Sub SetControlsEnabled(IsEnabled As Boolean)
        With MyForm
            .BtnStart.Enabled = IsEnabled
            .BtnReset.Enabled = IsEnabled
            .BtnDefault.Enabled = IsEnabled
            .CboFunction.Enabled = IsEnabled
            .TxtParameter.Enabled = IsEnabled
            .TxtStartValue.Enabled = IsEnabled
        End With
    End Sub


    'SECTOR ITERATION

    Public Async Sub StartIteration()

        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            'Check User Data
            If IsUserDataOK() Then

                'Set Ds Parameters
                DS.ParameterA = CDec(MyForm.TxtParameter.Text)
                x = CDec(MyForm.TxtStartValue.Text)
                IterationStatus = ClsDynamics.EnIterationStatus.Ready

                If DS.IsBehaviourChaotic() Then
                    'OK
                Else
                    'nothing to do, a message is already generated
                End If

            Else
                'Message already generated
            End If
        End If

        If IterationStatus = ClsDynamics.EnIterationStatus.Ready _
        Or IterationStatus = ClsDynamics.EnIterationStatus.Interrupted Then

            IterationStatus = ClsDynamics.EnIterationStatus.Running

            With MyForm
                .BtnStart.Text = LM.GetString("Continue")
                .Cursor = Cursors.WaitCursor
            End With
            SetControlsEnabled(False)

            Application.DoEvents()

            'Iteration loop
            Await IterationLoop()

        Else
            SetDefaultUserData()
        End If
    End Sub

    Public Sub StopIteration()
        'the iteration is running and should be stopped
        IterationStatus = ClsDynamics.EnIterationStatus.Interrupted
        MyForm.BtnStart.Enabled = True
        MyForm.BtnReset.Enabled = True
        MyForm.Cursor = Cursors.Arrow

    End Sub

    Private Function IterationLoop() As Task

        'p is the pixel coordinate of the x-axis and the number of the interval that is hit
        Dim p As Integer

        Do

            'calculating the location of the interval that is hit
            p = CInt((x - DS.ValueParameter.Range.A) * MyForm.PicDiagram.Width _
                / DS.ValueParameter.Range.IntervalWidth)

            'and increasing the number of hits for this interval
            NumberOfHits(p) += 1

            'increasing the number of iteration steps
            n += 1
            MyForm.LblSteps.Text = n.ToString(CultureInfo.CurrentCulture)

            'Next step of the iteration
            x = DS.FN(x)

            If n Mod 1000 = 0 Then

                'redraw the actualized histogram
                Dim Brush = Brushes.CadetBlue
                For i = 1 To MyForm.PicDiagram.Width

                    Dim A As New ClsMathpoint(i - 1, 0)
                    Dim B As New ClsMathpoint(i, NumberOfHits(i))
                    PicGraphics.FillRectangle(A, B, Brush)
                Next

                Application.DoEvents()
                Task.Delay(2)

            End If

        Loop Until IterationStatus = ClsDynamics.EnIterationStatus.Stopped _
            Or IterationStatus = ClsDynamics.EnIterationStatus.Interrupted

        Return Task.CompletedTask

    End Function

    'SECTOR CHECK USERDATA

    Private Function IsUserDataOK() As Boolean

        'Is the value of TxtParameter in the Iteration Interval?
        Dim CheckParameter = New ClsCheckUserData(MyForm.TxtParameter, DS.DSParameter.Range)
        Dim CheckStartValue = New ClsCheckUserData(MyForm.TxtStartValue, DS.ValueParameter.Range)

        Return CheckParameter.IsTxtValueAllowed And CheckStartValue.IsTxtValueAllowed

    End Function

End Class
