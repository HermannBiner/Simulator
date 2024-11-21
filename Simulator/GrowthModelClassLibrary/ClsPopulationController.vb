'This class contains the iteration controller for FrmPopulation

'Status checked

Imports System.Globalization
Imports System.Reflection

Public Class ClsPopulationController

    'The dynamic System
    Private DS As IIteration
    Private MyForm As FrmPopulation

    Private LM As ClsLanguageManager

    'Graphics
    Private PicGraphics As ClsGraphicTool
    Private PicDiagramSize As Integer

    'Actual value of the iteration
    Private x As Decimal
    'Size of the population in percent between 0% and 100%
    Private Percent As Decimal

    'Diameter of an individuum in pixels
    Private Const D As Integer = 1

    'Variables for the ShowPopulation Algorithm: See math. doc.
    Private Individuum As ClsMathpoint
    Private RandomGenerator As Random
    Private NumberOfIndividuums As Integer
    'Radius of the Circle with Individuums
    Private R As Decimal
    'Polar coordinates of an individuum
    Private Rho As Decimal
    Private Alfa As Decimal


    'Status Parameters
    'Number of Iteration Steps
    Private n As Integer

    'Iterationstatus
    Private IterationStatus As ClsDynamics.EnIterationStatus


    Public Sub New(Form As FrmPopulation)
        MyForm = Form
        LM = ClsLanguageManager.LM
        Individuum = New ClsMathpoint(0, 0) 'Default
        RandomGenerator = New Random
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

                'GetString is called with the option IsClass = true
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
                    End If
                Next
            End If

        End If

        InitializeMe()

        'And the parameter and startvalue are depending on the tpe of iteration as well
        SetDefaultUserData()

        'If the type of iteration changes, everything has to be reset
        ResetIteration()

    End Sub

    Private Sub InitializeMe()
        PicDiagramSize = Math.Min(MyForm.PicDiagram.Width, MyForm.PicDiagram.Height)
        MyForm.PicDiagram.Height = PicDiagramSize
        MyForm.PicDiagram.Width = PicDiagramSize

        PicGraphics = New ClsGraphicTool(MyForm.PicDiagram, DS.ValueParameter.Range, DS.ValueParameter.Range)

        DS.Power = 1
    End Sub


    Public Sub SetDefaultUserData()

        With MyForm
            'default settings
            .TxtParameterA.Text = DS.ChaoticParameterValue.ToString(CultureInfo.CurrentCulture)

            'StartValue
            x = DS.ValueParameter.DefaultValue
            .TxtStartValue.Text = x.ToString(CultureInfo.CurrentCulture)

            Percent = 100 * CDec((x - DS.ValueParameter.Range.A) / (DS.ValueParameter.Range.B - DS.ValueParameter.Range.A))
            .TxtPopulationDensity.Text = Percent.ToString("#.000", CultureInfo.CurrentCulture)

            'Set TrabParameterA to the Default of DSParameter.Range
            DS.ParameterA = DS.DSParameter.DefaultValue
            Dim TrbValue As Integer = CInt((DS.ParameterA - DS.DSParameter.Range.A) * 999 / DS.DSParameter.Range.IntervalWidth + 1)
            .TrbParameterA.Value = TrbValue
            .TxtParameterA.Text = DS.DSParameter.DefaultValue.ToString(CultureInfo.CurrentCulture)
        End With

    End Sub
    Public Sub SetParameterA()
        DS.ParameterA = DS.DSParameter.Range.A + DS.DSParameter.Range.IntervalWidth * (MyForm.TrbParameterA.Value - 1) / 999
        MyForm.TxtParameterA.Text = DS.ParameterA.ToString
        PrepareDiagram()
    End Sub

    Public Sub SetTrbA()
        If IsUserDataOK() Then
            DS.ParameterA = CDec(MyForm.TxtParameterA.Text)
            MyForm.TrbParameterA.Value = CInt((DS.ParameterA - DS.DSParameter.Range.A) * 999 / DS.DSParameter.Range.IntervalWidth + 1)
            PrepareDiagram()
        End If
    End Sub
    Public Sub ResetIteration()

        SetControlsEnabled(True)

        With MyForm
            'clear display
            PicGraphics.Clear(Color.White)

            'Reset Number of steps
            .LblSteps.Text = "0"
            n = 0

            x = CDec(.TxtStartValue.Text)
            With DS.ValueParameter.Range
                Percent = 100 * CDec((x - .A) / (.B - .A))
            End With

            'Set Population Density
            .TxtPopulationDensity.Text = Percent.ToString("#.000", CultureInfo.CurrentCulture)

            'Clear Statusparameter
            IterationStatus = ClsDynamics.EnIterationStatus.Stopped

            PrepareDiagram()
            .BtnStart.Text = LM.GetString("Start")
        End With
    End Sub

    Private Function IsUserDataOK() As Boolean
        With MyForm
            'Checks all manual inputs of the user
            Dim CheckParameter = New ClsCheckUserData(.TxtParameterA, DS.DSParameter.Range)
            Dim CheckStartValue = New ClsCheckUserData(.TxtStartValue, DS.ValueParameter.Range)

            Return CheckParameter.IsTxtValueAllowed And CheckStartValue.IsTxtValueAllowed
        End With
    End Function

    Private Sub PrepareDiagram()
        'Show size of the Startpopulation
        With MyForm
            .PicDiagram.Refresh()
            If IsUserDataOK() Then
                ShowPopulation(CDec(.TxtStartValue.Text))
            End If
        End With
    End Sub

    'SECTOR ITERATION

    Public Sub NextStep()
        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            'Check User Data
            If IsUserDataOK() Then

                'Set Ds Parameters
                DS.ParameterA = CDec(MyForm.TxtParameterA.Text)
                x = CDec(MyForm.TxtStartValue.Text)
                IterationStatus = ClsDynamics.EnIterationStatus.Ready
            Else
                'Message already generated
            End If
        End If

        If IterationStatus = ClsDynamics.EnIterationStatus.Ready _
            Or IterationStatus = ClsDynamics.EnIterationStatus.Interrupted Then

            IterationStatus = ClsDynamics.EnIterationStatus.Running

            'increasing the number of iteration steps
            n += 1
            MyForm.LblSteps.Text = n.ToString(CultureInfo.CurrentCulture)

            'Next step of the iteration
            x = DS.FN(x)

            With DS.ValueParameter.Range
                Percent = 100 * CDec((x - .A) / (.B - .A))
            End With

            'Set Population Density
            MyForm.TxtPopulationDensity.Text = Percent.ToString("#.000", CultureInfo.CurrentCulture)
            MyForm.TxtPopulationDensity.Refresh()

            ShowPopulation(x)

            IterationStatus = ClsDynamics.EnIterationStatus.Interrupted

        Else
            SetDefaultUserData()
        End If


    End Sub

    Public Async Sub StartIteration()

        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            'Check User Data
            If IsUserDataOK() Then

                'Set Ds Parameters
                DS.ParameterA = CDec(MyForm.TxtParameterA.Text)
                x = CDec(MyForm.TxtStartValue.Text)
                IterationStatus = ClsDynamics.EnIterationStatus.Ready
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

    Private Function IterationLoop() As Task

        Do

            'increasing the number of iteration steps
            n += 1
            MyForm.LblSteps.Text = n.ToString(CultureInfo.CurrentCulture)

            'Next step of the iteration
            x = DS.FN(x)
            With DS.ValueParameter.Range
                Percent = 100 * CDec((x - .A) / (.B - .A))
            End With

            'Set Population Density
            MyForm.TxtPopulationDensity.Text = Percent.ToString("#.000", CultureInfo.CurrentCulture)
            MyForm.TxtPopulationDensity.Refresh()

            ShowPopulation(x)

            Application.DoEvents()
            Task.Delay(2)

        Loop Until IterationStatus = ClsDynamics.EnIterationStatus.Stopped _
            Or IterationStatus = ClsDynamics.EnIterationStatus.Interrupted

        Return Task.CompletedTask

    End Function

    Private Sub ShowPopulation(x As Decimal)

        MyForm.PicDiagram.Refresh()

        With DS.ValueParameter.Range

            'Radius of the population living circle
            R = (x - .A) / 2

            'midpoint of the living circle
            Individuum.X = (.A + .B) / 2
            Individuum.Y = Individuum.X

            'draw living circle
            PicGraphics.DrawCircle(Individuum, R, Brushes.Red, 1)

            'this is set after some experiments
            NumberOfIndividuums = CInt(5000 * (x - .A) / (.B - .A) / (D * D))

            For m = 1 To NumberOfIndividuums
                'Generate a Random Point
                'Polarcoordinates
                Rho = R * CDec(RandomGenerator.NextSingle)
                Alfa = CDec(2 * Math.PI * RandomGenerator.NextSingle)
                Individuum.X = (.A + .B) / 2 + Rho * CDec(Math.Cos(Alfa))
                Individuum.Y = (.A + .B) / 2 + Rho * CDec(Math.Sin(Alfa))

                PicGraphics.DrawPoint(Individuum, Brushes.Blue, D)

            Next
        End With

    End Sub

    Public Sub StopIteration()
        'the iteration is running and should be stopped
        IterationStatus = ClsDynamics.EnIterationStatus.Interrupted
        MyForm.BtnStart.Enabled = True
        MyForm.BtnReset.Enabled = True
        MyForm.Cursor = Cursors.Arrow
    End Sub

    Private Sub SetControlsEnabled(IsEnabled As Boolean)
        With MyForm
            .BtnStart.Enabled = IsEnabled
            .BtnReset.Enabled = IsEnabled
            .BtnDefault.Enabled = IsEnabled
            .CboFunction.Enabled = IsEnabled
            .TxtParameterA.Enabled = IsEnabled
            .TxtStartValue.Enabled = IsEnabled
            .TrbParameterA.Enabled = IsEnabled
        End With
    End Sub
End Class
