'This form is the user interface for investigations of the iteration
'of unimodal functions like Tentmap, Logistic Growth or Parabola
'a parameter a, that steeres the iteration function, can be defined
'the behaviour of the iteration depends on that parameter
'in certain cases, the behaviour is chaotic
'in that case, any protocol of the iteration is possible
'if an arbitrary protocol is given by the user
'the program calculates a startvalue for the iteration, that produces this protocol
'in addition, any target value can be defined by the user
'and the program adapts the startvalue a little bit different from the original one
'so that the iteration approaches the given target value during the iteration
'see the mathematical documentation

'The form is based on an Interface IIteration 
'that is implemented by ClsTentmap, ClsLogisticGrowth, ClsParabola
'Therefore, more cases of unimodal functions could be easely programmed
'just by implementing this interface

'Status Checked

Imports System.Globalization
Imports System.Reflection

Public Class FrmIteration

    'Prepare basic objects
    Private MyGraphics As ClsGraphicTool
    Private Mathhelper As New ClsMathhelperUnimodal
    Private Iterator As IIteration

    'The upper right point of the diagram
    'because the left lower point is (0,0), the size of the Diagram is defined
    ''by the right upper point
    Private DiagramSize As Point

    'Private global variables

    'Actual value of the iteration
    Private x As Decimal

    'Number of Iteration Steps
    Private n As Integer

    'X-Stretching: In case of presentation = Timeaxis, this axis can be stretched
    Private XStretching As Integer
    Private Const XStretchingDefault As Integer = 2

    'In case of transitivity, a target value can be proposed
    Private Targetvalue As Decimal

    'Presentation
    Public Enum PresentationEnum

        'The iteration is shown on the graph of the function
        Functionsgraph

        'The iteration is shown on the time-axis
        'the iteration steps increases on that X-axis and the iteration value is on the Y-axis
        TimeAxis

    End Enum

    Private Presentation As PresentationEnum


    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub InitializeLanguage()

        Text = Main.LM.GetString("UnimodalFunctions")
        OptFunctionGraph.Text = Main.LM.GetString("FunctionGraph")
        OptTimeAxis.Text = Main.LM.GetString("TimeAxis")
        LblxStretching.Text = Main.LM.GetString("xStretching")
        LblStretching.Text = Main.LM.GetString("DinStretching")
        GrpPresentation.Text = Main.LM.GetString("Presentation")
        LblLog.Text = Main.LM.GetString("Log")
        LblXValues.Text = Main.LM.GetString("XValues")
        LblIterationDepth.Text = Main.LM.GetString("IterationDepth")
        BtnDrawDiagram.Text = Main.LM.GetString("DrawFunctionGraph")
        BtnProtocolStartvalue.Text = Main.LM.GetString("StartvalueForProtocol")
        GrpProtocol.Text = Main.LM.GetString("TargetProtocol")
        LblTargetValue.Text = Main.LM.GetString("TargetValue") & " = "
        BtnStartTransitive.Text = Main.LM.GetString("StartvalueForTargetvalue")
        GrpTargetValue.Text = Main.LM.GetString("Transitivity")
        LblSteps.Text = Main.LM.GetString("NumberOfSteps")
        GrpStep.Text = Main.LM.GetString("Iteration")
        BtnNext10Steps.Text = Main.LM.GetString("Next10Steps")
        BtnNextStep.Text = Main.LM.GetString("NextStep")
        LblStartValue.Text = Main.LM.GetString("StartValue") & " = "
        BtnReset.Text = Main.LM.GetString("ResetIteration")
        CboFunction.Items.Clear()

        'Add the classes implementing IIteration
        'to the Combobox CboPendulum by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IIteration)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If types.Count > 0 Then
            Dim IteratorName As String
            For Each type In types

                'GetString is calle dwith the option IsClass = true
                'That effects that - if there is no Entry in the Resource files LabelsEN, LabelsDE -
                'the name of the Class implementing an Interface is used as default
                'suppressing the extension "Cls"
                IteratorName = Main.LM.GetString(type.Name, True)
                CboFunction.Items.Add(IteratorName)
            Next

            CboFunction.SelectedIndex = CboFunction.Items.Count - 1
            CboFunction.Select()

        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If

    End Sub

    Private Sub FrmIteration_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Set objects
        Iterator = New ClsLogisticGrowth
        MyGraphics = New ClsGraphicTool(PicDiagram, Iterator.IterationInterval, Iterator.IterationInterval)

        'Because all iterations are in an interval that leads to a square coordinatesystem
        'the diagram (Bitmap or Picturebox) should be a square as well
        Dim Squareside As Integer = Math.Min(PicDiagram.Width, PicDiagram.Height)
        DiagramSize = New Point(Squareside, Squareside)

        'Initialize Language
        InitializeLanguage()

        'Default settings
        CboIterationDepth.SelectedIndex = 0
        Iterator.Power = 1

        Presentation = PresentationEnum.Functionsgraph
        TxtXStretching.Visible = False
        LblStretching.Visible = False
        LblxStretching.Visible = False

        LblNumberOfSteps.Text = "0"
        n = 0

        'additional default values
        SetDefaultValues()

    End Sub

    Private Sub SetDefaultValues()

        'default settings
        TxtParameter.Text = Iterator.ParameterInterval.B.ToString(CultureInfo.CurrentCulture) 'this is the chaotic case
        TxtStartValue.Text = (Iterator.IterationInterval.A +
            (Iterator.IterationInterval.IntervalWidth * 0.314159)).ToString(CultureInfo.CurrentCulture)
        TxtXStretching.Text = XStretchingDefault.ToString(CultureInfo.CurrentCulture)

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click

        ResetIteration()

    End Sub

    Private Sub ResetIteration()

        'clear display
        LstValueList.Items.Clear()
        LstProtocol.Items.Clear()
        MyGraphics.Clear(Color.White)

        'Reset Number of steps
        LblNumberOfSteps.Text = "0"
        n = 0

    End Sub

    Private Sub CboFunction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboFunction.SelectedIndexChanged

        'This sets the type of Iterator by Reflection

        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IIteration)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If CboFunction.SelectedIndex >= 0 Then

            Dim SelectedName As String = CboFunction.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If Main.LM.GetString(type.Name, True) = SelectedName Then
                        Iterator = CType(Activator.CreateInstance(type), IIteration)
                    End If
                Next
            End If

        End If

        'As standard, the function is repeated 1x in each iteration step
        Iterator.Power = CInt(CboIterationDepth.SelectedItem)

        'The MyGraphics Object needs to know the iteration interval depending on the type of iteration
        MyGraphics = New ClsGraphicTool(PicDiagram, Iterator.IterationInterval, Iterator.IterationInterval)

        'And the parameter and startvalue are depending on the tpe of iteration as well
        SetDefaultValues()

        'If the type of iteration changes, everything has to be reset
        ResetIteration()

    End Sub

    Private Sub CboIterationDepth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboIterationDepth.SelectedIndexChanged

        'The iteration depth defines how many times the function is repeated in each iteration step
        Iterator.Power = CInt(CboIterationDepth.SelectedItem)

        'If this value changes, the Iteration has to be reset
        ResetIteration()

    End Sub

    Private Sub TxtParameter_TextChanged(sender As Object, e As EventArgs) Handles TxtParameter.TextChanged
        'If this value changes, the Iteration has to be reset
        ResetIteration()
    End Sub

    Private Sub TxtStartValue_TextChanged(sender As Object, e As EventArgs) Handles TxtStartValue.TextChanged
        'If this value changes, the Iteration has to be reset
        ResetIteration()
    End Sub

    Private Sub TxtXStretching_TextChanged(sender As Object, e As EventArgs) Handles TxtXStretching.TextChanged
        'If this value changes, the Iteration has to be reset
        ResetIteration()
    End Sub

    Private Sub OptFunctionGraph_CheckedChanged(sender As Object, e As EventArgs) Handles OptFunctionGraph.CheckedChanged
        SetPresentation()
    End Sub

    Private Sub OptTimeAxis_CheckedChanged(sender As Object, e As EventArgs) Handles OptTimeAxis.CheckedChanged
        SetPresentation()
    End Sub

    Private Sub SetPresentation()

        'The type of presentation has changed
        If OptFunctionGraph.Checked Then
            Presentation = PresentationEnum.Functionsgraph
            TxtXStretching.Visible = False
            TxtXStretching.Text = ""
            LblStretching.Visible = False
            LblxStretching.Visible = False
            BtnNext10Steps.Text = Main.LM.GetString("Next10Steps")
            BtnNextStep.Visible = True
        Else
            Presentation = PresentationEnum.TimeAxis
            TxtXStretching.Visible = True
            TxtXStretching.Text = XStretchingDefault.ToString(CultureInfo.CurrentCulture)
            XStretching = XStretchingDefault
            LblStretching.Visible = True
            LblxStretching.Visible = True
            BtnNextStep.Visible = False
            BtnNext10Steps.Text = Main.LM.GetString("NextDiagram")
        End If

        If n > 0 Then
            'There was already an iteration running
            ResetIteration()
        End If

    End Sub

    Private Function InitializeIteration() As Boolean

        'Checks all manual inputs of the user

        'Checks and sets the value of the parameter
        Dim CheckParameter As New ClsCheckIsNumeric(TxtParameter)
        Dim OK As Boolean

        If CheckParameter.IsInputValid Then
            If Iterator.IsParameterAllowed(CheckParameter.NumericValue) Then
                Iterator.Parameter = CheckParameter.NumericValue
                OK = True
            Else
                TxtParameter.Text = ""
                TxtParameter.Select()
                OK = False
            End If
        Else
            OK = False
        End If

        'Checks and sets the start value
        If OK Then
            Dim CheckStartvalue As New ClsCheckIsNumeric(TxtStartValue)
            If CheckStartvalue.IsInputValid Then
                If Iterator.IsIterationvalueAllowed(CheckStartvalue.NumericValue) Then
                    x = CheckStartvalue.NumericValue
                Else
                    TxtStartValue.Text = ""
                    TxtStartValue.Select()
                    OK = False
                End If
            Else
                OK = False
            End If
        End If

        'Checks and sets the X-Stretching
        If Presentation = PresentationEnum.TimeAxis And OK Then

            Dim CheckXStretching As New ClsCheckIsNumeric(TxtXStretching)
            If CheckXStretching.IsInputValid Then
                XStretching = CInt(CheckXStretching.NumericValue)
                If XStretching < 1 Or XStretching > 10 Then
                    MessageBox.Show(Main.LM.GetString("StretchingParameterInterval") & " [1,10]")
                    TxtXStretching.Text = XStretchingDefault.ToString(CultureInfo.CurrentCulture)
                    TxtXStretching.Select()
                    XStretching = XStretchingDefault
                    OK = False
                End If
            Else
                OK = False
            End If
        End If

        Return OK

    End Function

    'SECTOR FUNCTIONSGRAPH

    Private Sub BtnDrawDiagramm_Click(sender As Object, e As EventArgs) Handles BtnDrawDiagram.Click

        'Checks the parametervalue and draws the graph of the function
        If InitializeIteration() Then

            'Initialization was successful
            PrepareDiagram()
        Else
            'There is already a message generated
            SetDefaultValues()
        End If

    End Sub

    Private Sub PrepareDiagram()

        'This method resets the Iteration 
        'and draws the Graph of the Function

        ResetIteration()

        'Draw coordinate system
        MyGraphics.DrawCoordinateSystem(New ClsMathpoint(0, 0), Color.Black, 1)

        'Draw the 45° line - needed to show the iteration in the function graph
        MyGraphics.DrawLine(New ClsMathpoint(Iterator.IterationInterval.A, Iterator.IterationInterval.A),
                            New ClsMathpoint(Iterator.IterationInterval.B, Iterator.IterationInterval.B),
                            Color.Black, 1)

        'Draw function graph
        'The step-wide in X-direction is:
        Dim deltaX As Decimal = Iterator.IterationInterval.IntervalWidth / DiagramSize.X

        'actual mathpoint
        Dim X As New ClsMathpoint

        'next mathpoint
        Dim Xplus As New ClsMathpoint

        'counter
        Dim m As Integer

        'X and XPlus are increased stepwise and the line betweens these points is drawn
        For m = 0 To DiagramSize.X - 2

            X.X = Iterator.IterationInterval.A + (m * deltaX)
            X.Y = Iterator.FN(X.X)
            Xplus.X = X.X + deltaX
            Xplus.Y = Iterator.FN(Xplus.X)
            MyGraphics.DrawLine(X, Xplus, Color.Blue, 1)

        Next

    End Sub

    'SECTOR STARTVALUE FOR PROTOCOL

    Private Sub BtnProtocolStartvalue_Click(sender As Object, e As EventArgs) Handles BtnProtocolStartvalue.Click

        'Calculates a startvalue that produces a given protocol
        ResetIteration()
        CboIterationDepth.SelectedIndex = 0
        Iterator.Power = 1
        CalculateStartvalueForProtocol()

    End Sub

    Private Sub CalculateStartvalueForProtocol()

        'Calculates a startvalue that produces a given protocol in case of chaotic behaviour

        If InitializeIteration() Then

            'Initialization was successful
            If Iterator.IsBehaviourChaotic Then
                'OK, nothing to do
            Else
                'There is already a message generated
            End If

            Dim targetprotocol As String = TxtTargetProtocol.Text

            If Mathhelper.CheckFormatDualzahl(targetprotocol) Then 'Checks the format of the target protocol
                TxtStartValue.Text = Iterator.CalculateStartValueForProtocol(targetprotocol).ToString(CultureInfo.CurrentCulture)
            Else
                TxtTargetProtocol.Clear()
                TxtTargetProtocol.Select()
            End If
        Else
            'There is already a message generated
            SetDefaultValues()
        End If

    End Sub

    'SECTOR ADAPTED STARTVALUE FOR THE TARGETVALUE

    Private Sub BtnStartTransitive_Click(sender As Object, e As EventArgs) Handles BtnStartTransitive.Click

        'A target value for the iteration is given
        'The original startvalue should be adapted minimally
        'So that the target value will be reached nearly during the iteration

        'Reset an existing iteration
        ResetIteration()
        CboIterationDepth.SelectedIndex = 0
        Iterator.Power = 1

        Dim CheckTargetvalue As New ClsCheckIsNumeric(TxtTargetValue)

        If InitializeIteration() Then

            'Initialization was succesful
            If Iterator.IsBehaviourChaotic Then
                'OK, nothing to do
            Else
                MessageBox.Show(Main.LM.GetString("NonChaoticBehaviour"))
            End If

            If CheckTargetvalue.IsInputValid Then
                Targetvalue = CheckTargetvalue.NumericValue
                If Iterator.IsIterationvalueAllowed(Targetvalue) Then
                    TxtStartValue.Text = Iterator.CalculateStartValueForTargetValue(x, Targetvalue).ToString(CultureInfo.CurrentCulture)
                Else
                    TxtTargetValue.Text = ""
                    TxtTargetValue.Select()
                End If
            Else
                'A message is already generated
            End If
        Else
            'There is already a message generated
            SetDefaultValues()
        End If

    End Sub

    'SECTOR ITERATION

    Private Sub BtnNextStep_Click(sender As Object, e As EventArgs) Handles BtnNextStep.Click

        'This performs one step of the iteration
        If n = 0 Then

            'In this case the iteration is just started
            'and has to be initialized
            If InitializeIteration() Then

                'The initialization was succesful
                If Presentation = PresentationEnum.Functionsgraph Then
                    PrepareDiagram()
                End If
                NextLoop(1)
            Else
                'There is already a message generated
                SetDefaultValues()
            End If
        Else
            'next step of the iteration
            NextLoop(1)
        End If

    End Sub

    Private Sub BtnNext10Steps_Click(sender As Object, e As EventArgs) Handles BtnNext10Steps.Click

        'This performs 10 steps of the iteraiton
        If n = 0 Then

            'In this case the iteration is just started
            'and has to be initialized
            If InitializeIteration() Then

                'The initialization was succesful
                If Presentation = PresentationEnum.Functionsgraph Then
                    PrepareDiagram()
                End If
                NextLoop(10)
            Else
                'There is already a message generated
                SetDefaultValues()
            End If
        Else
            'next 10 steps of the iteration
            NextLoop(10)
        End If
    End Sub

    Private Sub NextLoop(EndOfLoop As Integer)

        If Presentation = PresentationEnum.Functionsgraph Then

            'This perfoms NumberOfSteps steps of the iteration
            'and draws the display in the Function Graph and 45° line
            FunctionGraphIteration(EndOfLoop)

        Else

            'The diagram is cleared
            MyGraphics.Clear(Color.White)

            'and then drawed on the time-axis (Number of Steps in x-Direction)
            ShowFullDiagram()
        End If

    End Sub

    Private Sub FunctionGraphIteration(EndOfLoop As Integer)

        'counter for EndOfLoop
        Dim i As Integer = 0

        'Point on the function graph
        Dim P As New ClsMathpoint(x, Iterator.FN(x))

        'Point on the 45° line
        Dim G As New ClsMathpoint(x, x)

        Do
            n += 1

            'Transmit the actual iteration value x to the LstValueList
            UpdateListboxes(x)

            'Connect the Point G on the 45° line to then Point P on the Function Graph
            MyGraphics.DrawLine(G, P, Color.Red, 1)

            'Set the next Point on the 45° Line
            G.X = Iterator.FN(x)
            G.Y = G.X

            'Connect the Point P on the Function Graph with G
            MyGraphics.DrawLine(P, G, Color.Red, 1)

            'Set the next Iteration Value
            x = Iterator.FN(x)

            '... and the next Point P
            P.X = x
            P.Y = Iterator.FN(x)

            i += 1

        Loop Until i >= EndOfLoop

        LblNumberOfSteps.Text = n.ToString(CultureInfo.CurrentCulture)

    End Sub

    Private Sub ShowFullDiagram()

        'If a Target Value is set, it is already checked while the Initialization
        'in that case, a horizontal green line is set on the Diagram to mark the target value
        If TxtTargetValue.Text <> "" Then
            Dim A As New ClsMathpoint(Iterator.IterationInterval.A, Targetvalue)
            Dim B As New ClsMathpoint(Iterator.IterationInterval.B, Targetvalue)
            MyGraphics.DrawLine(A, B, Color.Green, 1)
        End If

        'The variable in x-direction starts at the left interval border
        Dim u As Decimal = Iterator.IterationInterval.A

        'this is the step-wide in x-direction
        Dim deltaU As Decimal = Iterator.IterationInterval.IntervalWidth * XStretching / DiagramSize.X

        'and there are the two points of the graph to be connented
        Dim P As New ClsMathpoint(u, x)
        Dim nextP As New ClsMathpoint(u + deltaU, Iterator.FN(x))

        Do
            n += 1

            MyGraphics.DrawLine(P, nextP, Color.Red, 1)

            'transmit the actual iteration value to the LstValueList
            UpdateListboxes(x)

            'P takes over NextP
            P.X = nextP.X
            P.Y = nextP.Y

            'x and u are iterated
            x = Iterator.FN(x)
            u += deltaU

            'and NextP is set
            nextP.X = u
            nextP.Y = Iterator.FN(x)

        Loop Until u >= Iterator.IterationInterval.B

        LblNumberOfSteps.Text = n.ToString(CultureInfo.CurrentCulture)

    End Sub

    Private Sub UpdateListboxes(u As Decimal)

        'LstValueList is filled with the actual iteration value
        LstValueList.Items.Add(u.ToString(CultureInfo.CurrentCulture))
        LstValueList.SelectedIndex = LstValueList.Items.Count - 1

        'LstProtocol is filled with the according protocol-value
        If u < Iterator.IterationInterval.A + ((Iterator.IterationInterval.B - Iterator.IterationInterval.A) / 2) Then
            LstProtocol.Items.Add("0")
        Else
            LstProtocol.Items.Add("1")
        End If
        LstProtocol.SelectedIndex = LstProtocol.Items.Count - 1

    End Sub
End Class