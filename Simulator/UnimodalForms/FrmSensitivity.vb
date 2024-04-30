'This form is the user interface for the investigation of the sensitivity
'of unimodal functions like Tentmap, Logistic Growth or Parabola
'if the behaviour of the iteration is chaotic, then a little differenc between two startvalues
'leads to big differences of their orbits
'see the mathematical documentation

'The form is based on an Interface IIteration 
'that is implemented by ClsTentmap, ClsLogisticGrowth, ClsParabola
'Therefore, more cases of unimodal functions could be easely programmed
'just by implementing this interface

'Status Checked

Imports System.Globalization
Imports System.Reflection

Public Class FrmSensitivity

    'Prepare basic objects
    Private MyGraphics As ClsGraphicTool
    Private Iterator As IIteration

    'in x-direction, we have pixel coordinates 
    'and we have to transmit the according interval to ClsGraphicTool
    Private MathXIntervall As ClsInterval

    'Private global variables

    'Number of Iteration Steps
    Private n As Integer

    'Actual values of the iteration
    Private x1 As Decimal
    Private x2 As Decimal

    'X-Stretching: the x-axis can be stretched
    Private XStretching As Integer
    Private Const XStretchingDefault As Integer = 2

    'Presentation
    Public Enum PresentationEnum

        'the diagram shows the difference between the orbits of x1, x2
        Difference

        'The orbits of x1, x2 are shown separately
        SingleOrbits

    End Enum

    Private Presentation As PresentationEnum

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub InitializeLanguage()

        Text = Main.LM.GetString("Sensitivity")
        LblSteps.Text = Main.LM.GetString("NumberOfSteps")
        BtnReset.Text = Main.LM.GetString("ResetIteration")
        BtnStartIteration.Text = Main.LM.GetString("StartIteration")
        OptDifference.Text = Main.LM.GetString("Difference12")
        OptSingleOrbit.Text = Main.LM.GetString("SingleOrbits")
        LblxStretching.Text = Main.LM.GetString("xStretching")
        LblStretching.Text = Main.LM.GetString("DinStretching")
        GrpPresentation.Text = Main.LM.GetString("Presentation")
        LblStartValue2.Text = Main.LM.GetString("StartValue2")
        LblStartValue1.Text = Main.LM.GetString("StartValue1")
        LblValueList2.Text = Main.LM.GetString("ValueList2")
        LblValueList1.Text = Main.LM.GetString("ValueList1")
        LblIterationDepth.Text = Main.LM.GetString("IterationDepth")
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

    Private Sub FrmSensitivity_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'set objects
        Iterator = New ClsLogisticGrowth
        MathXIntervall = New ClsInterval(1, PicDiagram.Width)
        MyGraphics = New ClsGraphicTool(PicDiagram, MathXIntervall, Iterator.IterationInterval)

        'Initialize Language
        InitializeLanguage()

        'Default settings
        CboIterationDepth.SelectedIndex = 0
        Iterator.Power = 1

        Presentation = PresentationEnum.Difference

        'Number of Iteration Steps
        LblNumberOfSteps.Text = "0"
        n = 0

        'additional Defaults
        SetDefaultValues()

    End Sub

    Private Sub SetDefaultValues()

        TxtParameter.Text = Iterator.ParameterInterval.B.ToString(CultureInfo.CurrentCulture)
        TxtStartValue1.Text = (Iterator.IterationInterval.A +
            (Iterator.IterationInterval.IntervalWidth * 0.314159)).ToString(CultureInfo.CurrentCulture)
        TxtStartValue2.Text = (Iterator.IterationInterval.A +
            (Iterator.IterationInterval.IntervalWidth * 0.31415926535)).ToString(CultureInfo.CurrentCulture)
        TxtxStretching.Text = XStretchingDefault.ToString(CultureInfo.CurrentCulture)

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click

        ResetIteration()

    End Sub

    Private Sub ResetIteration()

        'clear display
        LstValueList1.Items.Clear()
        LstValueList2.Items.Clear()
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
        Iterator.Power = 1

        'The MyGraphics Object needs to know the iteration interval depending on the type of iteration
        MyGraphics = New ClsGraphicTool(PicDiagram, MathXIntervall, Iterator.IterationInterval)

        'The parameter and startvalue are depending on the type of iteration
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

    Private Sub TxtStartValue1_TextChanged(sender As Object, e As EventArgs) Handles TxtStartValue1.TextChanged

        'If this value changes, the Iteration has to be reset
        ResetIteration()
    End Sub

    Private Sub TxtStartValue2_TextChanged(sender As Object, e As EventArgs) Handles TxtStartValue2.TextChanged

        'If this value changes, the Iteration has to be reset
        ResetIteration()
    End Sub

    Private Sub TxtxStretching_TextChanged(sender As Object, e As EventArgs) Handles TxtxStretching.TextChanged

        'If this value changes, the Iteration has to be reset
        ResetIteration()
    End Sub

    Private Sub OptDifference_CheckedChanged(sender As Object, e As EventArgs) Handles OptDifference.CheckedChanged
        SetPresentation()
    End Sub

    Private Sub OptSingleOrbit_CheckedChanged(sender As Object, e As EventArgs) Handles OptSingleOrbit.CheckedChanged
        SetPresentation()
    End Sub

    Private Sub SetPresentation()

        'The type of presentation has changed
        Presentation = If(OptDifference.Checked, PresentationEnum.Difference, PresentationEnum.SingleOrbits)

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

        'Checks and sets startvalue1
        If OK Then
            Dim CheckStartvalue1 As New ClsCheckIsNumeric(TxtStartValue1)
            If CheckStartvalue1.IsInputValid Then
                If Iterator.IsIterationvalueAllowed(CheckStartvalue1.NumericValue) Then
                    x1 = CheckStartvalue1.NumericValue
                Else
                    TxtStartValue1.Text = ""
                    TxtStartValue1.Select()
                    OK = False
                End If
            Else
                OK = False
            End If
        End If

        'Checks and sets startvalue2
        If OK Then
            Dim CheckStartvalue2 As New ClsCheckIsNumeric(TxtStartValue2)
            If CheckStartvalue2.IsInputValid Then
                If Iterator.IsIterationvalueAllowed(CheckStartvalue2.NumericValue) Then
                    x2 = CheckStartvalue2.NumericValue
                Else
                    TxtStartValue2.Text = ""
                    TxtStartValue2.Select()
                    OK = False
                End If
            Else
                OK = False
            End If
        End If

        'Checks and sets X-Stretching
        If OK Then
            Dim CheckxStretching As New ClsCheckIsNumeric(TxtxStretching)
            If CheckxStretching.IsInputValid Then
                XStretching = CInt(CheckxStretching.NumericValue)
                If XStretching < 1 Or XStretching > 10 Then
                    MessageBox.Show(Main.LM.GetString("StretchingParameterInterval") & " [1,10].")
                    TxtxStretching.Text = XStretchingDefault.ToString(CultureInfo.CurrentCulture)
                    TxtxStretching.Select()
                    XStretching = XStretchingDefault
                    OK = False
                End If
            Else
                OK = False
            End If
        End If

        Return OK

    End Function

    'SECTOR SENSITIVITY

    Private Sub BtnStartIteration_Click(sender As Object, e As EventArgs) Handles BtnStartIteration.Click

        'This starts the whole iteration

        If n = 0 Then

            'In this case the iteration has just started
            'and must be initialized
            If InitializeIteration() Then

                'The initialization was successful
                If Iterator.IsBehaviourChaotic Then
                    GenerateDiagram()
                Else
                    'nothing to do, a message is already generated by the test
                End If
            Else
                'there is already a message generated
                SetDefaultValues()
            End If
        Else
            GenerateDiagram()
        End If
    End Sub

    Private Sub GenerateDiagram()

        'Both orbits are initialized

        'P1 and NextP1 are the points for the interation of x1 = Startvalue1
        Dim P1 As New ClsMathpoint
        Dim nextP1 As New ClsMathpoint

        'P2 and NextP2 are the points for the interation of x2 = Startvalue2
        Dim P2 As New ClsMathpoint
        Dim nextP2 As New ClsMathpoint

        'Clear display
        MyGraphics.Clear(Color.White)

        'This will be the variable of the x-axis
        Dim p As Decimal = 0

        Do

            'P1.X is the coordinate on the x-axis
            'and increased by one pixel*xstretching in each iteration step
            P1.X = p * XStretching
            'P1.Y is the y-coordinate and equal to the iteration of x1
            P1.Y = x1

            'similar settings for the next point
            nextP1.X = (p + 1) * XStretching
            nextP1.Y = Iterator.FN(x1)

            'and similar for the points P2, NextP2
            'for the iteration of x2
            P2.X = p * XStretching
            P2.Y = x2
            nextP2.X = (p + 1) * XStretching
            nextP2.Y = Iterator.FN(x1)

            'Increase number of steps
            n += 1

            'transmit the new values to the LstValueList1, 2
            UpdateListboxes(x1, x2)

            'and draw the diagram according to the points
            DrawDiagram(P1, nextP1, P2, nextP2)

            'do the ntext iteration step
            x1 = Iterator.FN(x1)
            x2 = Iterator.FN(x2)
            p += 1

        Loop Until p * XStretching >= PicDiagram.Width

        LblNumberOfSteps.Text = n.ToString(CultureInfo.CurrentCulture)

    End Sub

    Private Sub UpdateListboxes(u1 As Decimal, u2 As Decimal)

        'LstValueList1 and 2 are filled with the actual iteration value
        LstValueList1.Items.Add(u1.ToString(CultureInfo.CurrentCulture))
        LstValueList1.SelectedIndex = LstValueList1.Items.Count - 1

        LstValueList2.Items.Add(u2.ToString(CultureInfo.CurrentCulture))
        LstValueList2.SelectedIndex = LstValueList2.Items.Count - 1

    End Sub

    'Overloading if u2 is not relevant
    Private Sub UpdateListboxes(u1 As Decimal)

        UpdateListboxes(u1, -1)

    End Sub

    Private Sub DrawDiagram(P1 As ClsMathpoint, nextP1 As ClsMathpoint, P2 As ClsMathpoint, nextP2 As ClsMathpoint)

        If Presentation = PresentationEnum.Difference Then

            'Draw the difference of the orbits: x2 - x1
            Dim D As New ClsMathpoint(P1.X, Iterator.IterationInterval.A + Math.Abs(P2.Y - P1.Y))
            Dim NextD As New ClsMathpoint(nextP1.X, Iterator.IterationInterval.A + Math.Abs(nextP2.Y - nextP1.Y))
            MyGraphics.DrawLine(D, NextD, Color.Blue, 1)

        Else

            'Draw the single orbits x1, x2
            MyGraphics.DrawLine(P1, nextP1, Color.Red, 1)
            MyGraphics.DrawLine(P2, nextP2, Color.Green, 1)

        End If

    End Sub

End Class