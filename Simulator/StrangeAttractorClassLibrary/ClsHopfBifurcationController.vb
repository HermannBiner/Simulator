'This class contains the iteration controller for FrmHopfBifurcation

'Status Tested

Imports System.Globalization
Imports System.Reflection

Public Class ClsHopfBifurcationController

    'The dynamic System
    Private DS As IStrangeAttractor
    Private ReadOnly MyForm As FrmHopfBifurcation

    Private ReadOnly DiagramAreaSelector As ClsDiagramAreaSelector

    Private ReadOnly LM As ClsLanguageManager

    'PicDiagram and Bitmasp
    Private ReadOnly BmpDiagram As Bitmap

    'The Graphic Helper for the Graphics
    Private BmpGraphics As ClsGraphicTool

    'User Selection
    Private ActualParameterRange As ClsInterval
    Private ActualValueRange As ClsInterval

    'IterationStatus
    Private IterationStatus As ClsDynamics.EnIterationStatus
    Private StartPoint As ClsIterationPoint
    Private IterationPointSet As ClsPointSet

    'To draw the circle
    'x is the chosen coordinate
    Private x As Decimal

    'Iteration Parameters
    Private Const RunTimeUntilCycle As Integer = 10000
    Private LengthOfCycle As Integer
    Private CyclePoint As ClsMathpoint

    'Iterationsteps
    Private n As Integer


    'SECTOR INITIALIZATION

    Public Sub New(Form As FrmHopfBifurcation)
        LM = ClsLanguageManager.LM

        MyForm = Form
        DiagramAreaSelector = New ClsDiagramAreaSelector

        BmpDiagram = New Bitmap(MyForm.PicDiagram.Width, MyForm.PicDiagram.Height)
        MyForm.PicDiagram.Image = BmpDiagram

        IterationPointSet = New ClsPointSet

        StartPoint = New ClsIterationPoint(CDec(0.1), CDec(0.1), CDec(0.1), Brushes.Blue)
        IterationPointSet.AddPoint(StartPoint)
        StartPoint = New ClsIterationPoint(CDec(-0.1), CDec(-0.1), CDec(0.1), Brushes.Red)
        IterationPointSet.AddPoint(StartPoint)

        CyclePoint = New ClsMathpoint

    End Sub

    Public Sub FillDynamicSystem()

        MyForm.CboSystem.Items.Clear()

        'Add the classes implementing IIteration
        'to the Combobox CboPendulum by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IStrangeAttractor)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If types.Count > 0 Then
            Dim DSName As String
            For Each type In types

                'GetString is calle dwith the option IsClass = true
                'That effects that - if there is no Entry in the Resource files LabelsEN, LabelsDE -
                'the name of the Class implementing an Interface is used as default
                'suppressing the extension "Cls"
                DSName = LM.GetString(type.Name, True)
                MyForm.CboSystem.Items.Add(DSName)
            Next
        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If
        MyForm.CboSystem.SelectedIndex = 1

    End Sub

    Public Sub SetDS()

        'This sets the type of Iterator by Reflection

        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IStrangeAttractor)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If MyForm.CboSystem.SelectedIndex >= 0 Then

            Dim SelectedName As String = MyForm.CboSystem.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If LM.GetString(type.Name, True) = SelectedName Then
                        DS = CType(Activator.CreateInstance(type), IStrangeAttractor)
                        Exit For
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

    Public Sub InitializeMe()

        ActualParameterRange = DS.DSParameter.Range
        MyForm.TxtAMax.Text = ActualParameterRange.B.ToString(CultureInfo.CurrentCulture)
        MyForm.TxtXMin.Text = ActualParameterRange.A.ToString(CultureInfo.CurrentCulture)
        MyForm.OptX.Checked = True
        SetActualValueRange()

        With MyForm
            .LblAmax.Text = DS.DSParameter.Name & "Max"
            .LblAMin.Text = DS.DSParameter.Name & "Min"
        End With

        With DiagramAreaSelector
            .XRange = ActualParameterRange
            .YRange = ActualValueRange
            .PicDiagram = MyForm.PicDiagram
            .TxtXMin = MyForm.TxtAMin
            .TxtXMax = MyForm.TxtAMax
            .TxtYMin = MyForm.TxtXMin
            .TxtYMax = MyForm.TxtXMax
        End With

        BmpGraphics = New ClsGraphicTool(BmpDiagram, ActualParameterRange, ActualValueRange)

    End Sub

    Public Sub SetActualValueRange()
        With MyForm
            Select Case True
                Case .OptX.Checked
                    ActualValueRange = DS.XValueParameter.Range
                    .LblXmax.Text = DS.XValueParameter.Name & "Max"
                    .LblXmin.Text = DS.XValueParameter.Name & "Min"
                Case .OptY.Checked
                    ActualValueRange = DS.YValueParameter.Range
                    .LblXmax.Text = DS.YValueParameter.Name & "Max"
                    .LblXmin.Text = DS.YValueParameter.Name & "Min"
                Case Else
                    ActualValueRange = DS.ZValueParameter.Range
                    .LblXmax.Text = DS.ZValueParameter.Name & "Max"
                    .LblXmin.Text = DS.ZValueParameter.Name & "Min"
            End Select
            .TxtXMax.Text = ActualValueRange.B.ToString(CultureInfo.CurrentCulture)
            .TxtXMin.Text = ActualValueRange.A.ToString(CultureInfo.CurrentCulture)
        End With
        DiagramAreaSelector.YRange = ActualValueRange
    End Sub

    Public Sub ResetIteration()

        SetControlsEnabled(True)
        BmpGraphics.Clear(Color.White)
        MyForm.PicDiagram.Refresh()

        IterationStatus = ClsDynamics.EnIterationStatus.Stopped

    End Sub

    Public Sub SetDefaultUserData()

        ActualParameterRange = DS.DSParameter.Range
        SetActualValueRange()

        'if there where User-defined ranges,
        'or the iterator has changed
        'the ranges are reset to the standard
        With MyForm
            .TxtAMin.Text = ActualParameterRange.A.ToString(CultureInfo.CurrentCulture)
            .TxtAMax.Text = ActualParameterRange.B.ToString(CultureInfo.CurrentCulture)

            .TxtXMin.Text = ActualValueRange.A.ToString(CultureInfo.CurrentCulture)
            .TxtXMax.Text = ActualValueRange.B.ToString(CultureInfo.CurrentCulture)
        End With

        SetDelta()

    End Sub

    Public Sub SetDelta()
        With MyForm
            If IsNumeric(.TxtAMax.Text) And IsNumeric(.TxtAMin.Text) Then
                .LblDeltaA.Text = "Delta = " & (CDec(.TxtAMax.Text) - CDec(.TxtAMin.Text)).ToString(CultureInfo.CurrentCulture)
            End If
            If IsNumeric(.TxtXMax.Text) And IsNumeric(.TxtXMin.Text) Then
                .LblDeltaX.Text = "Delta = " & (CDec(.TxtXMax.Text) - CDec(.TxtXMin.Text)).ToString(CultureInfo.CurrentCulture)
            End If
        End With
    End Sub

    Private Sub SetControlsEnabled(IsEnabled As Boolean)
        With MyForm
            .BtnStart.Enabled = IsEnabled
            .BtnReset.Enabled = IsEnabled
            .BtnDefault.Enabled = IsEnabled
            .CboSystem.Enabled = IsEnabled
            .TxtAMax.Enabled = IsEnabled
            .TxtAMin.Enabled = IsEnabled
            .TxtXMax.Enabled = IsEnabled
            .TxtXMin.Enabled = IsEnabled
            .OptX.Enabled = IsEnabled
            .OptY.Enabled = IsEnabled
            .OptZ.Enabled = IsEnabled
        End With
    End Sub

    'SECTOR ITERATION

    Public Sub StartIteration()

        ResetIteration()
        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            If IsUserDataOK() Then
                With MyForm
                    DiagramAreaSelector.IsActivated = False
                    IterationStatus = ClsDynamics.EnIterationStatus.Ready
                    ActualParameterRange = New ClsInterval(CDec(.TxtAMin.Text), CDec(.TxtAMax.Text))
                    BmpGraphics.MathXInterval = ActualParameterRange
                    ActualValueRange = New ClsInterval(CDec(.TxtXMin.Text), CDec(.TxtXMax.Text))
                    BmpGraphics.MathYInterval = ActualValueRange
                    DiagramAreaSelector.UserXRange = ActualParameterRange
                    DiagramAreaSelector.UserYRange = ActualValueRange
                End With
            Else
                'Message already generated
            End If
        End If

        If IterationStatus = ClsDynamics.EnIterationStatus.Ready Then
            SetControlsEnabled(False)
            MyForm.Cursor = Cursors.WaitCursor
            PerformIteration()
        End If

        DiagramAreaSelector.IsActivated = True
        IterationStatus = ClsDynamics.EnIterationStatus.Stopped
        SetControlsEnabled(True)
        MyForm.Cursor = Cursors.Arrow

    End Sub

    Private Sub PerformIteration()

        'In the direction of the x-axis, we work with pixel coordinates
        Dim p As Integer

        For p = 1 To MyForm.PicDiagram.Width

            'for each p, the according parametervalue a is calculated
            'and then, the iteration runs until RuntimeUntilCycle
            'finally, the iteration cycle is drawn
            IterationLoop(p)

        Next

        DrawSplitPoints()

    End Sub

    Private Sub IterationLoop(p As Integer)

        If IterationStatus = ClsDynamics.EnIterationStatus.Ready Then

            'enough but not bigger than the y-axis allows
            LengthOfCycle = CInt(MyForm.PicDiagram.Height)

        End If

        IterationStatus = ClsDynamics.EnIterationStatus.Running

        'Calculate the parameter a for the iteration depending on p
        DS.DSParameterValue = ActualParameterRange.A + (ActualParameterRange.IntervalWidth * p / MyForm.PicDiagram.Width)
        CyclePoint.X = DS.DSParameterValue

        For Each aPoint In IterationPointSet.Points

            'Initialize Iteration
            'The startvalue x for the iteration should be the same for all values of a
            'aPoint is the StartPoint
            DS.ActualMathPoint = aPoint.ActualPoint

            n = 1

            Do
                DS.IterationStep()
                n += 1
            Loop Until (n > RunTimeUntilCycle - 1)

            n = RunTimeUntilCycle

            Do

                DS.IterationStep()
                With MyForm
                    Select Case True
                        Case .OptX.Checked
                            x = DS.ActualMathPoint.X
                        Case .OptY.Checked
                            x = DS.ActualMathPoint.Y
                        Case Else
                            x = DS.ActualMathPoint.Z
                    End Select
                End With

                CyclePoint.Y = Math.Max(ActualValueRange.A, Math.Min(x, ActualValueRange.B))
                BmpGraphics.DrawPoint(CyclePoint, aPoint.Color, 1)

                n += 1
            Loop Until (n > RunTimeUntilCycle + LengthOfCycle)
        Next

        MyForm.PicDiagram.Refresh()

    End Sub

    Private Sub DrawSplitPoints()

        'the first split points are marked by vertical lines
        Dim Splitpoints As List(Of Decimal) = DS.Splitpoints
        Dim i As Integer

        If Splitpoints.Count > 0 Then
            For i = 0 To Splitpoints.Count - 1
                If DS.DSParameter.Range.IsNumberInInterval(Splitpoints(i)) Then
                    If i < Splitpoints.Count - 1 Then
                        BmpGraphics.DrawVerticalLine(Splitpoints(i), Color.Green, 1)
                    Else
                        BmpGraphics.DrawVerticalLine(Splitpoints(i), Color.Red, 1)
                    End If
                End If
            Next
            MyForm.PicDiagram.Refresh()
        End If

    End Sub

    'SECTOR CHECK USERDATA

    Private Function IsUserDataOK() As Boolean

        Dim CheckParameterRange As New ClsCheckUserData(MyForm.TxtAMin, MyForm.TxtAMax, DS.DSParameter.Range)

        Dim CheckValueRange As ClsCheckUserData

        With MyForm
            Select Case True
                Case .OptX.Checked
                    CheckValueRange = New ClsCheckUserData(.TxtXMin, .TxtXMax, DS.XValueParameter.Range)
                Case .OptY.Checked
                    CheckValueRange = New ClsCheckUserData(.TxtXMin, .TxtXMax, DS.YValueParameter.Range)
                Case Else
                    CheckValueRange = New ClsCheckUserData(.TxtXMin, .TxtXMax, DS.ZValueParameter.Range)
            End Select
        End With

        Return CheckParameterRange.IsIntervalAllowed And CheckValueRange.IsIntervalAllowed

    End Function

End Class
