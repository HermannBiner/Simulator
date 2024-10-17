'This class contains the iteration controller for FrmFeigenbaum

'Status Checked

Imports System.Globalization
Imports System.Reflection

Public Class ClsFeigenbaumController

    'The dynamic System
    Private DS As IIteration
    Private MyForm As FrmFeigenbaum
    Private DiagramAreaSelector As ClsDiagramAreaSelector

    Private LM As ClsLanguageManager

    'PicDiagram and Bitmasp
    Private BmpDiagram As Bitmap

    'The Graphic Helper for the Graphics
    Private BmpGraphics As ClsGraphicTool
    Private MyIsColored As Boolean

    'User Selection
    Private ActualParameterRange As ClsInterval
    Private ActualValueRange As ClsInterval

    'IterationStatus
    Private IterationStatus As ClsDynamics.EnIterationStatus

    'Iteration Parameters
    Private x As Decimal
    Private Const RunTimeUntilCycle As Integer = 1000
    Private LengthOfCycle As Integer
    Private CyclePoint As ClsMathpoint

    'Iterationsteps
    Private n As Integer

    Public Sub New(Form As FrmFeigenbaum)
        LM = ClsLanguageManager.LM

        MyForm = Form
        DiagramAreaSelector = New ClsDiagramAreaSelector

        BmpDiagram = New Bitmap(MyForm.PicDiagram.Width, MyForm.PicDiagram.Height)
        MyForm.PicDiagram.Image = BmpDiagram

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
                MyForm.CboFunction.Items.Add(DSName)
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

        'The parameter and startvalue are depending on the type of iteration
        SetDefaultUserData()

        'If the type of iteration changes, everything has to be reset
        ResetIteration()

    End Sub

    Private Sub InitializeMe()

        DS.Power = 1

        ActualParameterRange = DS.DSParameter.Range
        ActualValueRange = DS.ValueParameter.Range

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

    Public Sub SetDefaultUserData()

        ActualParameterRange = DS.DSParameter.Range
        ActualValueRange = DS.ValueParameter.Range

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

        'Draw Splitpoints
        If MyForm.ChkSplitPoints.Checked Then
            DrawSplitPoints()
        End If

    End Sub

    Private Sub IterationLoop(p As Integer)

        If IterationStatus = ClsDynamics.EnIterationStatus.Ready Then
            'Initialize
            'enough but not bigger than the y-axis allows
            LengthOfCycle = 4 * MyForm.PicDiagram.Height
            'To draw the cycle
            CyclePoint = New ClsMathpoint(DS.ParameterA, x)
        End If

        IterationStatus = ClsDynamics.EnIterationStatus.Running

        'Calculate the parameter a for the iteration depending on p
        DS.ParameterA = ActualParameterRange.A + (ActualParameterRange.IntervalWidth * p / MyForm.PicDiagram.Width)
        CyclePoint.X = DS.ParameterA

        'Initialize Iteration
        'The startvalue x for the iteration should be the same for all values of a
        x = DS.CriticalPoint
        n = 1

        Do
            x = DS.FN(x)
            n += 1
        Loop Until (n > RunTimeUntilCycle - 1)

        n = RunTimeUntilCycle
        CyclePoint.Y = x

        Do
            BmpGraphics.DrawPoint(CyclePoint, SetColor(n), 1)
            x = DS.FN(x)
            CyclePoint.Y = Math.Max(ActualValueRange.A, Math.Min(x, ActualValueRange.B))
            n += 1
        Loop Until (n > RunTimeUntilCycle + LengthOfCycle)

        MyForm.PicDiagram.Refresh()

    End Sub

    Private Function SetColor(n As Integer) As Brush

        'It's possible actually to use two colors for the image
        'The reader can add more colors by programming

        Dim MyBrush As Brush

        If MyForm.ChkColored.Checked Then
            Select Case n Mod 2
                Case 0
                    MyBrush = Brushes.Blue
                Case Else
                    MyBrush = Brushes.Green
            End Select
        Else
            MyBrush = Brushes.Blue
        End If

        Return MyBrush

    End Function

    Private Sub DrawSplitPoints()

        'the first split points are marked by vertical lines
        Dim Splitpoints As List(Of Decimal) = DS.Splitpoints
        Dim i As Integer

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

    End Sub

    Public Sub ResetIteration()

        SetControlsEnabled(True)
        BmpGraphics.Clear(Color.White)
        MyForm.PicDiagram.Refresh()

        IterationStatus = ClsDynamics.EnIterationStatus.Stopped

    End Sub

    Private Function IsUserDataOK() As Boolean

        Dim CheckParameterRange As New ClsCheckUserData(MyForm.TxtAMin, MyForm.TxtAMax, DS.DSParameter.Range)
        Dim CheckValueRange As New ClsCheckUserData(MyForm.TxtXMin, MyForm.TxtXMax, DS.ValueParameter.Range)

        Return CheckParameterRange.IsIntervalAllowed And CheckValueRange.IsIntervalAllowed

    End Function

    Private Sub SetControlsEnabled(IsEnabled As Boolean)
        With MyForm
            .BtnStart.Enabled = IsEnabled
            .BtnReset.Enabled = IsEnabled
            .BtnDefault.Enabled = IsEnabled
            .CboFunction.Enabled = IsEnabled
            .TxtAMax.Enabled = IsEnabled
            .TxtAMin.Enabled = IsEnabled
            .TxtXMax.Enabled = IsEnabled
            .TxtXMin.Enabled = IsEnabled
            .ChkColored.Enabled = IsEnabled
            .ChkSplitPoints.Enabled = IsEnabled
        End With
    End Sub

End Class
