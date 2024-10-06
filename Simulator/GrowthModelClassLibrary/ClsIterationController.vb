
'This class contains the iteration controller for FrmIteration

'Status Checked

Imports System.Globalization
Imports System.Reflection

Public Class ClsIterationController

    'The dynamic System
    Private DS As IIteration
    Private MyForm As FrmIteration

    Private LM As ClsLanguageManager

    'Graphics
    Private PicGraphics As ClsGraphicTool
    Private BmpDiagram As Bitmap
    Private BmpGraphics As ClsGraphicTool
    Private PicDiagramSize As Integer

    'Math Helper
    Private MathHelper As New ClsMathhelperUnimodal

    'Actual value of the iteration
    Private X As Decimal

    'How os the Protocol defined
    Private SignProtocol As Integer

    'Status Parameters
    'Number of Iteration Steps
    Private n As Integer

    'X-Stretching: the x-axis can be stretched
    Private Const XStretchingDefault As Integer = 2

    'Neighborhood of TargetValue
    Private Const TargetValuePrecision As Decimal = CDec(0.001)
    Private TargetValue As Decimal

    'Iterationstatus
    Private IterationStatus As ClsDynamics.EnIterationStatus

    'Presentation in FrmIteration
    Public Enum PresentationEnum

        'The iteration is shown on the graph of the function
        Functionsgraph

        'The iteration is shown on the time-axis
        'the iteration steps increases on that X-axis and the iteration value is on the Y-axis
        TimeAxis

    End Enum

    Private Presentation As PresentationEnum

    Public Sub New(Form As FrmIteration)
        MyForm = Form
        LM = ClsLanguageManager.LM
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
        PicGraphics = New ClsGraphicTool(MyForm.PicDiagram, DS.ValueParameter.Range, DS.ValueParameter.Range)
        PicDiagramSize = Math.Min(MyForm.PicDiagram.Width, MyForm.PicDiagram.Height)
        BmpDiagram = New Bitmap(PicDiagramSize, PicDiagramSize)
        MyForm.PicDiagram.Image = BmpDiagram
        BmpGraphics = New ClsGraphicTool(BmpDiagram, DS.ValueParameter.Range, DS.ValueParameter.Range)

        MyForm.CboIterationDepth.SelectedIndex = 0
        SignProtocol = Math.Sign(DS.ChaoticParameterValue)
        MyForm.OptFunctionGraph.Checked = True
        SetPresentation()

    End Sub

    Public Sub SetDefaultUserData()

        With MyForm
            'default settings
            .TxtParameterA.Text = DS.ChaoticParameterValue.ToString(CultureInfo.CurrentCulture)
            .TxtStartValue.Text = DS.ValueParameter.DefaultValue.ToString(CultureInfo.CurrentCulture)
            .TxtXStretching.Text = XStretchingDefault.ToString(CultureInfo.CurrentCulture)
            .TxtTargetValue.Text = "0"
            TargetValue = 0
            .TxtTargetProtocol.Text = ""

            MyForm.CboIterationDepth.SelectedIndex = 0
            DS.Power = CInt(MyForm.CboIterationDepth.SelectedItem)

            'Set TrabParameterA to the Default of DSParameter.Range
            DS.ParameterA = DS.DSParameter.DefaultValue
            Dim TrbValue As Integer = CInt((DS.ParameterA - DS.DSParameter.Range.A) * 999 / DS.DSParameter.Range.IntervalWidth + 1)
            .TrbParameterA.Value = TrbValue
            .TxtParameterA.Text = DS.DSParameter.DefaultValue.ToString(CultureInfo.CurrentCulture)
        End With

    End Sub

    Public Sub SetPresentation()
        With MyForm
            'The type of presentation has changed
            If .OptFunctionGraph.Checked Then
                Presentation = ClsIterationController.PresentationEnum.Functionsgraph
                .TxtXStretching.Visible = False
                .TxtXStretching.Text = XStretchingDefault.ToString(CultureInfo.CurrentCulture)
                .LblStretching.Visible = False
                .LblxStretching.Visible = False
                .BtnNext10Steps.Text = LM.GetString("Next10Steps")
                .BtnNextStep.Visible = True
            Else
                Presentation = ClsIterationController.PresentationEnum.TimeAxis
                .TxtXStretching.Visible = True
                .TxtXStretching.Text = XStretchingDefault.ToString(CultureInfo.CurrentCulture)
                .LblStretching.Visible = True
                .LblxStretching.Visible = True
                .BtnNextStep.Visible = False
                .BtnNext10Steps.Text = LM.GetString("NextDiagram")
            End If
        End With
    End Sub

    Public Sub PrepareDiagram()
        DrawCoordinateSystem()
        If Presentation = PresentationEnum.Functionsgraph Then
            DrawFunctionGraph()
        End If
    End Sub

    Private Sub DrawCoordinateSystem()

        BmpGraphics.Clear(Color.White)

        'Draw coordinate system
        BmpGraphics.DrawCoordinateSystem(New ClsMathpoint(0, 0), Color.Black, 1)

        If Presentation = PresentationEnum.Functionsgraph Then
            'Draw the 45° line - needed to show the iteration in the function graph
            BmpGraphics.DrawLine(New ClsMathpoint(DS.ValueParameter.Range.A, DS.ValueParameter.Range.A),
                            New ClsMathpoint(DS.ValueParameter.Range.B, DS.ValueParameter.Range.B),
                            Color.Black, 1)
        End If
        MyForm.PicDiagram.Refresh()

    End Sub

    Public Sub DrawFunctionGraph()

        MyForm.PicDiagram.Refresh()

        'Draw function graph
        'The step-wide in X-direction is:
        Dim deltaX As Decimal = DS.ValueParameter.Range.IntervalWidth / PicDiagramSize

        'actual mathpoint
        Dim X As New ClsMathpoint

        'next mathpoint
        Dim Xplus As New ClsMathpoint

        'counter
        Dim m As Integer

        'X and XPlus are increased stepwise and the line betweens these points is drawn
        For m = 0 To PicDiagramSize - 2
            X.X = DS.ValueParameter.Range.A + (m * deltaX)
            X.Y = DS.FN(X.X)
            Xplus.X = X.X + deltaX
            Xplus.Y = DS.FN(Xplus.X)
            PicGraphics.DrawLine(X, Xplus, Color.Blue, 1)
        Next
    End Sub

    Public Sub SetParameterA()
        DS.ParameterA = DS.DSParameter.Range.A + DS.DSParameter.Range.IntervalWidth * (MyForm.TrbParameterA.Value - 1) / 999
        MyForm.TxtParameterA.Text = DS.ParameterA.ToString
        If MyForm.OptFunctionGraph.Checked Then
            DrawFunctionGraph()
        End If
    End Sub

    Public Sub SetTrbA()
        If IsUserDataOK() Then
            DS.ParameterA = CDec(MyForm.TxtParameterA.Text)
            MyForm.TrbParameterA.Value = CInt((DS.ParameterA - DS.DSParameter.Range.A) * 999 / DS.DSParameter.Range.IntervalWidth + 1)
            If MyForm.OptFunctionGraph.Checked Then
                DrawFunctionGraph()
            End If
        End If
    End Sub

    Public Sub SetExponent()
        DS.Power = CInt(MyForm.CboIterationDepth.SelectedItem)
        If MyForm.OptFunctionGraph.Checked Then
            DrawFunctionGraph()
        End If
    End Sub

    Public Sub CalculateStartvalueForProtocol()

        If IsUserDataOK() Then

            ResetIteration()

            DS.ParameterA = CDec(MyForm.TxtParameterA.Text)

            'Initialization was successful
            If DS.IsBehaviourChaotic Then
                'OK, nothing to do
            Else
                'There is already a message generated
            End If

            'The power should be = 1 to produce the protocol
            MyForm.CboIterationDepth.SelectedIndex = 0
            DS.Power = 1

            Dim TargetProtocol As String = MyForm.TxtTargetProtocol.Text

            'Calculates a startvalue that produces a given protocol in case of chaotic behaviour
            If MathHelper.CheckFormatDualzahl(TargetProtocol) Then 'Checks the format of the target protocol
                MyForm.TxtStartValue.Text = DS.CalculateStartValueForProtocol(TargetProtocol).ToString(CultureInfo.CurrentCulture)
            Else
                'There is already an error message generated
            End If
        End If

    End Sub

    Public Sub CalculateStartvalueForTargetValue()

        'A target value for the iteration is given
        'The original startvalue should be adapted minimally
        'So that the target value will be reached nearly during the iteration

        Dim CheckTargetvalue As New ClsCheckIsNumeric(MyForm.TxtTargetValue)

        If IsUserDataOK() Then

            ResetIteration()

            DS.ParameterA = CDec(MyForm.TxtParameterA.Text)

            'Initialization was succesful
            If DS.IsBehaviourChaotic Then
                'OK, nothing to do
            Else
                'There is already a message generated
            End If

            'The power should be = 1 to produce the iteration to the target value
            MyForm.CboIterationDepth.SelectedIndex = 0
            DS.Power = 1
            X = CDec(MyForm.TxtStartValue.Text)
            TargetValue = CDec(MyForm.TxtTargetValue.Text)
            MyForm.TxtStartValue.Text = DS.CalculateStartValueForTargetValue(X, TargetValue).ToString(CultureInfo.CurrentCulture)
        Else
            'There is already a message generated
            SetDefaultUserData()
        End If

    End Sub

    Public Sub StartIteration(EndOfLoop As Integer)

        DS.Power = CInt(MyForm.CboIterationDepth.SelectedItem)
        'New iteration
        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then

            If IsUserDataOK() Then
                DS.ParameterA = CDec(MyForm.TxtParameterA.Text)
                X = CDec(MyForm.TxtStartValue.Text)
                IterationStatus = ClsDynamics.EnIterationStatus.Ready
                PrepareDiagram()
            Else
                'Message already generated
            End If

        End If

        If IterationStatus = ClsDynamics.EnIterationStatus.Ready Then
            IterationStatus = ClsDynamics.EnIterationStatus.Running
            If Presentation = ClsIterationController.PresentationEnum.Functionsgraph Then

                'This perfoms NumberOfSteps steps of the iteration
                'and draws the display in the Function Graph and 45° line
                IterationLoop(EndOfLoop)

            Else
                'Clean the diagram
                ResetIteration()

                'and draw the iteration on the time-axis (Number of Steps in x-Direction)
                ShowFullDiagram()
            End If
            IterationStatus = ClsDynamics.EnIterationStatus.Ready
        End If
    End Sub

    Private Sub IterationLoop(EndOfLoop As Integer)

        'counter for EndOfLoop
        Dim i As Integer = 0

        'Point on the function graph
        Dim P As New ClsMathpoint(X, DS.FN(X))

        'Point on the 45° line
        Dim G As New ClsMathpoint(X, X)

        MyForm.Cursor = Cursors.WaitCursor
        Do
            n += 1

            'Transmit the actual iteration value x to the LstValueList
            UpdateListboxes(X)

            'Connect the Point G on the 45° line to then Point P on the Function Graph
            PicGraphics.DrawLine(G, P, Color.Red, 1)

            'Set the next Point on the 45° Line
            G.X = DS.FN(X)
            G.Y = G.X

            'Connect the Point P on the Function Graph with G
            PicGraphics.DrawLine(P, G, Color.Red, 1)

            'Set the next Iteration Value
            X = DS.FN(X)

            '... and the next Point P
            P.X = X
            P.Y = DS.FN(X)

            i += 1

        Loop Until i >= EndOfLoop

        MyForm.Cursor = Cursors.Arrow
        MyForm.LblSteps.Text = n.ToString(CultureInfo.CurrentCulture)

    End Sub

    Private Sub ShowFullDiagram()

        'If a Target Value is set, it is already checked while the IsUserDataOK
        'in that case, a horizontal green line is set on the Diagram to mark the target value
        If TargetValue <> 0 Then
            Dim A As New ClsMathpoint(DS.ValueParameter.Range.A, TargetValue)
            Dim B As New ClsMathpoint(DS.ValueParameter.Range.B, TargetValue)
            PicGraphics.DrawLine(A, B, Color.Green, 1)
        End If

        'The variable in x-direction starts at the left interval border
        Dim u As Decimal = DS.ValueParameter.Range.A

        'this is the step-wide in x-direction
        Dim deltaU As Decimal = DS.ValueParameter.Range.IntervalWidth * CInt(MyForm.TxtXStretching.Text) / PicDiagramSize

        'and there are the two points of the graph to be connented
        Dim P As New ClsMathpoint(u, X)
        Dim NextP As New ClsMathpoint(u + deltaU, DS.FN(X))

        MyForm.Cursor = Cursors.WaitCursor
        Do
            n += 1

            PicGraphics.DrawLine(P, NextP, Color.Red, 1)

            'transmit the actual iteration value to the LstValueList
            UpdateListboxes(X)

            If TargetValue > 0 Then
                If Math.Abs(X - TargetValue) < TargetValuePrecision Then
                    u = DS.ValueParameter.Range.B + 1
                End If
            End If

            'P takes over NextP
            P.X = NextP.X
            P.Y = NextP.Y

            'x and u are iterated
            X = DS.FN(X)
            u += deltaU

            'and NextP is set
            NextP.X = u
            NextP.Y = DS.FN(X)

        Loop Until u >= DS.ValueParameter.Range.B

        MyForm.Cursor = Cursors.Arrow
        MyForm.LblSteps.Text = n.ToString(CultureInfo.CurrentCulture)

    End Sub

    Private Sub UpdateListboxes(u As Decimal)

        With MyForm
            'LstValueList is filled with the actual iteration value
            .LstValueList.Items.Add(u.ToString(CultureInfo.CurrentCulture))
            .LstValueList.SelectedIndex = .LstValueList.Items.Count - 1

            'LstProtocol is filled with the according protocol-value

            If SignProtocol * u < SignProtocol * (DS.ValueParameter.Range.A + ((DS.ValueParameter.Range.B - DS.ValueParameter.Range.A) / 2)) Then
                .LstProtocol.Items.Add("0")
            Else
                .LstProtocol.Items.Add("1")
            End If

            .LstProtocol.SelectedIndex = .LstProtocol.Items.Count - 1
        End With
    End Sub

    Public Sub ResetIteration()
        With MyForm
            'clear display
            PicGraphics.Clear(Color.White)
            .LstValueList.Items.Clear()
            .LstProtocol.Items.Clear()

            'Reset Number of steps
            .LblSteps.Text = "0"
            n = 0

            'Clear Statusparameter
            IterationStatus = ClsDynamics.EnIterationStatus.Stopped

            PrepareDiagram()
        End With
    End Sub

    Private Function IsUserDataOK() As Boolean
        With MyForm
            'Checks all manual inputs of the user
            Dim CheckParameter = New ClsCheckUserData(.TxtParameterA, DS.DSParameter.Range)
            Dim CheckStartValue = New ClsCheckUserData(.TxtStartValue, DS.ValueParameter.Range)
            Dim CheckTargetValue = New ClsCheckUserData(.TxtTargetValue, DS.ValueParameter.Range)
            Dim StretchInterval = New ClsInterval(1, 10)
            Dim CheckStretchInterval = New ClsCheckUserData(.TxtXStretching, StretchInterval)

            Return CheckParameter.IsTxtValueAllowed And CheckStartValue.IsTxtValueAllowed _
                And CheckTargetValue.IsTxtValueAllowed And CheckStretchInterval.IsTxtValueAllowed
        End With
    End Function
End Class
