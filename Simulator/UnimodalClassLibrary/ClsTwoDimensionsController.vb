
'This class contains the iteration controller for FrmTwoDimensions

'Status Checked

Imports System.Globalization
Imports System.Reflection

Public Class ClsTwoDimensionsController

    'The dynamic System
    Private DS As IIteration
    Private MyForm As FrmTwoDimensions

    'The Graphic Helper for PicDiagram
    Private PicGraphics As ClsGraphicTool
    Private BmpDiagram As Bitmap
    Private BmpGraphics As ClsGraphicTool

    'Actual values of the iteration
    Private IterationPoint As ClsMathpoint

    'IterationDepth: 5 is optimal, due to eXperiments
    Private Const Standardpower As Integer = 5

    'Representing the raster for the measure eXactness of the eXperimentator in PiXels
    Private Const Rastersize As Integer = 5

    Private MyBrush As SolidBrush

    'Iteration Status
    Private IterationStatus As ClsDynamics.EnIterationStatus

    Public Sub New(Form As FrmTwoDimensions)
        MyForm = Form
        IterationPoint = New ClsMathpoint(0, 0)
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
                DSName = FrmMain.LM.GetString(type.Name, True)
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
                    If FrmMain.LM.GetString(type.Name, True) = SelectedName Then
                        DS = CType(Activator.CreateInstance(type), IIteration)
                    End If
                Next
            End If

        End If

        InitializeMe()

        'The parameter and startvalue are depending on the type of iteration
        SetDefaultUserData()

        'If the type of iteration changes, everything has to be reset
        ResetIteration()

    End Sub

    Private Sub InitializeMe()

        'Iteration Depth
        DS.Power = Standardpower

        PicGraphics = New ClsGraphicTool(MyForm.PicDiagram, DS.ValueParameter.Range, DS.ValueParameter.Range)
        BmpDiagram = New Bitmap(MyForm.PicDiagram.Width, MyForm.PicDiagram.Height)
        MyForm.PicDiagram.Image = BmpDiagram
        BmpGraphics = New ClsGraphicTool(BmpDiagram, DS.ValueParameter.Range, DS.ValueParameter.Range)
        PrepareDiagram()
        SetBrush()

    End Sub

    Public Sub SetDefaultUserData()
        With MyForm
            'default settings
            .TxtParameter.Text = DS.ChaoticParameterValue.ToString(CultureInfo.CurrentCulture)
            .TxtX.Text = (DS.ValueParameter.Range.A +
                (DS.ValueParameter.Range.IntervalWidth * 0.414)).ToString(CultureInfo.CurrentCulture)
            .TxtY.Text = (DS.ValueParameter.Range.A +
                (DS.ValueParameter.Range.IntervalWidth * 0.407)).ToString(CultureInfo.CurrentCulture)
            .CboExperiment.SelectedIndex = 0
            .TxtX.Select()
        End With
    End Sub

    Public Sub PrepareDiagram()

        'The raster shows the measure eXactness of the eXperimentator
        'one square in the raster has 5X5 piXel points
        'that corresponds to a measure eXactness of about 0.00825 for the X- and y-values

        'Counter
        Dim i As Integer

        'Corresponding X- and y-coordinates
        Dim u As Decimal

        'Adapting DeltaX to the Iteration.Interval.Width
        'that all type of Iteration Functions have the same Raster
        Dim Diagramsize As Integer = Math.Min(MyForm.PicDiagram.Width, MyForm.PicDiagram.Height)
        Dim DeltaX As Decimal = CDec(Rastersize / Diagramsize) * DS.ValueParameter.Range.IntervalWidth

        Do

            'lines parallel to the y-aXis
            u = DS.ValueParameter.Range.A + (i * DeltaX)
            Dim X1 As New ClsMathpoint(u, DS.ValueParameter.Range.A)
            Dim X2 As New ClsMathpoint(u, DS.ValueParameter.Range.B)
            BmpGraphics.DrawLine(X1, X2, Color.Aqua, 1)

            'lines parallel to the X-aXis
            Dim Y1 As New ClsMathpoint(DS.ValueParameter.Range.A, u)
            Dim Y2 As New ClsMathpoint(DS.ValueParameter.Range.B, u)
            BmpGraphics.DrawLine(Y1, Y2, Color.Aqua, 1)

            i += 1

        Loop Until i * DeltaX >= DS.ValueParameter.Range.IntervalWidth

    End Sub

    Public Sub StartIteration(EndOfLoop As Integer)

        'New Iteration
        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            If IsUserDataOK() Then
                PrepareDiagram()
                DS.ParameterA = CDec(MyForm.TxtParameter.Text)
                IterationPoint.X = CDec(MyForm.TxtX.Text)
                IterationPoint.Y = CDec(MyForm.TxtY.Text)
                IterationStatus = ClsDynamics.EnIterationStatus.Ready
            Else
                SetDefaultUserData()
            End If
        End If

        'New Experiment with new UserData
        If IterationStatus = ClsDynamics.EnIterationStatus.Interrupted Then
            If IsUserDataOK() Then
                IterationPoint.X = CDec(MyForm.TxtX.Text)
                IterationPoint.Y = CDec(MyForm.TxtY.Text)
                IterationStatus = ClsDynamics.EnIterationStatus.Ready
            Else
                SetDefaultUserData()
            End If
        End If

        'Next steps of a running Iteration
        If IterationStatus = ClsDynamics.EnIterationStatus.Ready Then
            IterationStatus = ClsDynamics.EnIterationStatus.Running
            IterationLoop(EndOfLoop)
            IterationStatus = ClsDynamics.EnIterationStatus.Ready
        End If

    End Sub

    Public Sub IterationLoop(EndOfLoop As Integer)

        With IterationPoint
            'Mark the startpoint
            Dim Startpoint As New ClsMathpoint(.X, .Y)
            PicGraphics.DrawPoint(Startpoint, MyBrush, 2)
            PicGraphics.DrawCircle(Startpoint, 5, MyBrush.Color, 1)

            'the neXt steps of the iteration are performed
            Dim i As Integer
            For i = 1 To EndOfLoop

                Dim P As New ClsMathpoint(.X, .Y)
                Dim neXtP As New ClsMathpoint(DS.FN(.X), DS.FN(.Y))

                'draw result
                PicGraphics.DrawPoint(neXtP, MyBrush, 1)
                PicGraphics.DrawLine(P, neXtP, MyBrush.Color, 1)
                .X = DS.FN(.X)
                .Y = DS.FN(.Y)

            Next
        End With
    End Sub

    Public Sub SetBrush()

        'To show the effect of different experiments,
        'there are 5 possible startpoints in different colors
        Select Case MyForm.CboExperiment.SelectedIndex
            Case 0
                MyBrush = CType(Brushes.Black, SolidBrush)
            Case 1
                MyBrush = CType(Brushes.Green, SolidBrush)
            Case 2
                MyBrush = CType(Brushes.Blue, SolidBrush)
            Case 3
                MyBrush = CType(Brushes.Magenta, SolidBrush)
            Case Else
                MyBrush = CType(Brushes.Red, SolidBrush)
        End Select
        IterationStatus = ClsDynamics.EnIterationStatus.Interrupted

    End Sub

    Public Sub ResetIteration()

        'Clear Display
        PicGraphics.Clear(Color.White)
        IterationStatus = ClsDynamics.EnIterationStatus.Stopped
        MyForm.PicDiagram.Refresh()
    End Sub

    Private Function IsUserDataOK() As Boolean

        'Checks all manual inputs of the user
        With MyForm
            'Is the value of TxtParameter in the Iteration Interval?
            Dim CheckParameter = New ClsCheckUserData(.TxtParameter, DS.FormulaParameter.Range)
            Dim CheckXStartvalue = New ClsCheckUserData(.TxtX, DS.ValueParameter.Range)
            Dim CheckYStartvalue = New ClsCheckUserData(.TxtY, DS.ValueParameter.Range)

            Return CheckParameter.IsTxtValueAllowed And CheckXStartvalue.IsTxtValueAllowed _
            And CheckYStartvalue.IsTxtValueAllowed
        End With

    End Function
End Class
