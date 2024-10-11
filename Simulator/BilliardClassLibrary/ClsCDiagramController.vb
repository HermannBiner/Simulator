'This class contains the controller for the FrmCDiagram

'Status Checked

Imports System.Globalization
Imports System.Reflection

Public Class ClsCDiagramController

    Private MyForm As FrmCDiagramBilliard

    Private LM As ClsLanguageManager

    'The dynamic System
    Private DS As IBilliardTable
    Private ActualBilliardBall As IBilliardball

    Private DiagramAreaSelector As ClsDiagramAreaSelector

    'Graphics
    Private MyBmpDiagram As Bitmap

    'The Graphic Helper
    'drawing into Bmp -
    'because the DiagramAreaSelector draws into Pic
    Private BmpGraphics As ClsGraphicTool

    'Diagram Ranges
    Private ActualParameterRange As ClsInterval
    Private ActualValueRange As ClsInterval
    Private SelectedValueParameter As ClsGeneralParameter

    'IterationStatus
    Private IterationStatus As ClsDynamics.EnIterationStatus

    'Iteration Parameters
    'Startpoint
    Private ActualPair As ClsValuePair
    Private NextPair As ClsValuePair
    Private CyclePoint As ClsMathpoint
    Private LengthOfCycle As Integer

    Public Sub New(Form As FrmCDiagramBilliard)
        MyForm = Form
        LM = ClsLanguageManager.LM
        DiagramAreaSelector = New ClsDiagramAreaSelector
    End Sub

    Public Sub FillDynamicSystem()

        MyForm.CboFunction.Items.Clear()

        'Add the classes implementing IBilliardBall
        'to the Combobox CboBilliardTable by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IBilliardTable)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If types.Count > 0 Then
            Dim BilliardName As String
            For Each type In types

                'GetString is calle dwith the option IsClass = true
                'That effects that - if there is no Entry in the Resource files LabelsEN, LabelsDE -
                'the name of the Class implementing an Interface is used as default
                'suppressing the extension "Cls"
                BilliardName = LM.GetString(type.Name, True)
                MyForm.CboFunction.Items.Add(BilliardName)
            Next
        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If
        MyForm.CboFunction.SelectedIndex = 1

        'The identifier of the ValueParameter into the CboValueParameters
        'is added when the ValueParameters are known
        'depending on the type of iteration

    End Sub

    Public Sub SetDS()

        'This sets the type of BilliardBall by Reflection

        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IBilliardTable)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If MyForm.CboFunction.SelectedIndex >= 0 Then

            Dim SelectedName As String = MyForm.CboFunction.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If LM.GetString(type.Name, True) = SelectedName Then
                        DS = CType(Activator.CreateInstance(type), IBilliardTable)
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

    Private Sub FillValueParameters()

        MyForm.CboValueParameter.Items.Clear()
        For Each VP As ClsGeneralParameter In DS.ValueParameterList
            MyForm.CboValueParameter.Items.Add(LM.GetString(VP.Name))
        Next
        MyForm.CboValueParameter.SelectedIndex = MyForm.CboValueParameter.Items.Count - 1
        SelectedValueParameter = DS.ValueParameterList(MyForm.CboValueParameter.SelectedIndex)

    End Sub

    Private Sub InitializeMe()

        FillValueParameters()

        ActualBilliardBall = DS.GetBilliardBall
        ActualParameterRange = DS.DSParameter.Range
        ActualValueRange = SelectedValueParameter.Range

        With DiagramAreaSelector
            .XRange = ActualParameterRange
            .YRange = ActualValueRange
            .PicDiagram = MyForm.PicDiagram
            .TxtXMin = MyForm.TxtCMin
            .TxtXMax = MyForm.TxtCMax
            .TxtYMin = MyForm.TxtVMin
            .TxtYMax = MyForm.TxtVMax
        End With

        MyBmpDiagram = New Bitmap(MyForm.PicDiagram.Width, MyForm.PicDiagram.Height)
        MyForm.PicDiagram.Image = MyBmpDiagram
        BmpGraphics = New ClsGraphicTool(MyBmpDiagram, ActualParameterRange, ActualValueRange)

    End Sub

    Public Sub SetDefaultUserData()

        ActualParameterRange = DS.DSParameter.Range
        ActualValueRange = SelectedValueParameter.Range
        With MyForm
            .TxtCMin.Text = ActualParameterRange.A.ToString(CultureInfo.CurrentCulture)
            .TxtCMax.Text = ActualParameterRange.B.ToString(CultureInfo.CurrentCulture)
            .TxtVMin.Text = ActualValueRange.A.ToString(CultureInfo.CurrentCulture)
            .TxtVMax.Text = ActualValueRange.B.ToString(CultureInfo.CurrentCulture)
        End With
        SetDelta()

        MyForm.TrbPositionStartValues.Value = 60
        MyForm.LblStartValues.Text = LM.GetString("PositionStartValue2") &
            MyForm.TrbPositionStartValues.Value.ToString(CultureInfo.CurrentCulture) & "/120"
    End Sub

    Public Sub SetValueParameter()
        SelectedValueParameter = DS.ValueParameterList(MyForm.CboValueParameter.SelectedIndex)

        SelectedValueParameter = SelectedValueParameter
        ActualValueRange = SelectedValueParameter.Range
        BmpGraphics.MathYInterval = ActualValueRange
        DiagramAreaSelector.YRange = ActualValueRange

        'If the type of iteration changes, everything has to be reset
        ResetIteration()
        SetDefaultUserData()
    End Sub

    Public Sub SetDelta()
        With MyForm
            If IsNumeric(.TxtCMax.Text) And IsNumeric(.TxtCMin.Text) Then
                .LblDeltaC.Text = "Delta = " & (CDec(.TxtCMax.Text) - CDec(.TxtCMin.Text)).ToString(CultureInfo.CurrentCulture)
            End If
            If IsNumeric(.TxtVMax.Text) And IsNumeric(.TxtVMin.Text) Then
                .LblDeltaV.Text = "Delta = " & (CDec(.TxtVMax.Text) - CDec(.TxtVMin.Text)).ToString(CultureInfo.CurrentCulture)
            End If
        End With
    End Sub

    Public Sub ResetIteration()

        BmpGraphics.Clear(Color.White)
        MyForm.PicDiagram.Refresh()

        IterationStatus = ClsDynamics.EnIterationStatus.Stopped

    End Sub

    'SECTOR ITERATION

    Public Async Sub StartIteration()

        ResetIteration()
        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            If IsUserDataOK() Then
                DiagramAreaSelector.IsActivated = False
                With MyForm
                    .BtnStartIteration.Enabled = False
                    .BtnReset.Enabled = False
                    .BtnDefault.Enabled = False
                    .CboFunction.Enabled = False
                    ActualParameterRange = New ClsInterval(CDec(.TxtCMin.Text), CDec(.TxtCMax.Text))
                    ActualValueRange = New ClsInterval(CDec(.TxtVMin.Text), CDec(.TxtVMax.Text))
                End With
                DiagramAreaSelector.UserXRange = ActualParameterRange
                DiagramAreaSelector.UserYRange = ActualValueRange
                BmpGraphics.MathXInterval = ActualParameterRange
                BmpGraphics.MathYInterval = ActualValueRange
                IterationStatus = ClsDynamics.EnIterationStatus.Ready
            Else
                'Message already generated
            End If
        End If

        If IterationStatus = ClsDynamics.EnIterationStatus.Ready Then
            MyForm.Cursor = Cursors.WaitCursor
            Await PerformIteration()
        End If

        With MyForm
            .BtnStartIteration.Enabled = True
            .BtnReset.Enabled = True
            .BtnDefault.Enabled = True
            .CboFunction.Enabled = True
            .Cursor = Cursors.Arrow
            IterationStatus = ClsDynamics.EnIterationStatus.Stopped
            DiagramAreaSelector.IsActivated = True
        End With
    End Sub

    Private Async Function PerformIteration() As Task

        'In the direction of the x-axis, we work with pixel coordinates
        Dim p As Integer

        For p = 1 To MyForm.PicDiagram.Width

            'for each p, the according parametervalue a is calculated
            'and then, the iteration runs until RuntimeUntilCycle
            'finally, the iteration cycle is drawn
            IterationLoop(p)
        Next

        DrawSplitPoints()

        Await Task.Delay(1)

    End Function

    Private Sub IterationLoop(p As Integer)

        If IterationStatus = ClsDynamics.EnIterationStatus.Ready Then
            'Initialize
            ActualPair = New ClsValuePair(0, 0)
            CyclePoint = New ClsMathpoint(0, 0)

            'enough, but not bigger than the y-axis allows
            LengthOfCycle = MyForm.PicDiagram.Height
        End If

        IterationStatus = ClsDynamics.EnIterationStatus.Running

        'Calculate the parameter C for the iteration depending on p
        DS.C = ActualParameterRange.A + (ActualParameterRange.IntervalWidth * p / MyForm.PicDiagram.Width)

        ActualBilliardBall.A = DS.A
        ActualBilliardBall.B = DS.B

        'Setting the Start-Parameterpair for the Iteration

        With ActualPair
            'The Startpoint has to be the same for all Values of C to avoid side effects
            .X = DS.ValueParameterList.Item(0).Range.A +
                DS.ValueParameterList.Item(0).Range.IntervalWidth / 3

            '.. and the second value depending on TrbPositionStartValues
            .Y = DS.ValueParameterList.Item(1).Range.A +
                    MyForm.TrbPositionStartValues.Value * DS.ValueParameterList.Item(1).Range.IntervalWidth / 120
        End With

        'the cycle is drawn

        CyclePoint.X = DS.C

        For n = 0 To LengthOfCycle

            Select Case SelectedValueParameter.ID
                Case 1
                    CyclePoint.Y = ActualPair.X
                Case Else
                    CyclePoint.Y = ActualPair.Y
            End Select

            BmpGraphics.DrawPoint(CyclePoint, Brushes.Blue, 1)

            NextPair = ActualBilliardBall.GetNextValuePair(ActualPair)
            ActualPair.X = NextPair.X
            ActualPair.Y = NextPair.Y

        Next

        MyForm.PicDiagram.Refresh()

    End Sub

    Private Sub DrawSplitPoints()

        'Draw the C = 1 Line
        BmpGraphics.DrawVerticalLine(1, Color.Red, 1)
        MyForm.PicDiagram.Refresh()

    End Sub

    'CHECK USER RANGES AND SET PARAMETER AND VALUE INTERVAL

    Private Function IsUserDataOK() As Boolean

        With MyForm
            Dim CheckParameterRange As New ClsCheckUserData(.TxtCMin, .TxtCMax, DS.DSParameter.Range)
            Dim CheckValueRange As New ClsCheckUserData(.TxtVMin, .TxtVMax, SelectedValueParameter.Range)

            Return CheckParameterRange.IsIntervalAllowed And CheckValueRange.IsIntervalAllowed
        End With

    End Function
End Class

