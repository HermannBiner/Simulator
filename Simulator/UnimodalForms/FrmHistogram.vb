'This form is the user interface for investigations of a histogram
'counting, how many times a small part of the iteration interval
'is hit by an iteration value during the iteration
'Iterated are unimodal functions like Tentmap, Logistic Growth or Parabola.
'In case of chaotical behaviour, the histogram looks like random distributed
'see as well the mathematical documentation

'The form is based on an Interface IIteration 
'that is implemented by ClsTentmap, ClsLogisticGrowth, ClsParabola
'Therefore, more cases of unimodal functions could be easely programmed
'just by implementing this interface

'Status Checked

Imports System.Globalization

Public Class FrmHistogram

    'Prepare basic objects
    Private MyGraphics As ClsGraphicTool
    Private Iterator As IIteration
    Private DiagramSize As ClsInterval

    'Private global variables

    'Number of Iteration Steps
    Private n As Integer

    'Actual value of the iteration
    Private x As Decimal

    'Success if the initialization of the iteration
    Private IsInitialized As Boolean

    'How many times does the iterated value hit a small interval?
    'NumberOfHits is an array if those intervals
    Private NumberOfHits() As Integer ''Für Histogramm

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

        'Initialize Language
        InitializeLanguage()

    End Sub

    Private Sub InitializeLanguage()

        Text = Main.LM.GetString("Histogram")
        LblSteps.Text = Main.LM.GetString("NumberOfSteps")
        BtnReset.Text = Main.LM.GetString("ResetIteration")
        BtnNextSteps.Text = Main.LM.GetString("Next100Steps")
        LblStartValue.Text = Main.LM.GetString("StartValue") & " ="
        LblParameter.Text = Main.LM.GetString("Parameter") & " = "
        CboFunction.Items.Clear()

        'the following order of adding the iteration type is relevant!
        'at the moment, no better concept of identifying the unimodal function is implemented
        CboFunction.Items.Add(Main.LM.GetString("Tentmap"))
        CboFunction.Items.Add(Main.LM.GetString("LogisticGrowth"))
        CboFunction.Items.Add(Main.LM.GetString("Parabola"))


    End Sub

    Private Sub FrmHistogramm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Generate objects
        Iterator = New ClsLogisticGrowth
        DiagramSize = New ClsInterval(1, PicDiagram.Width)
        MyGraphics = New ClsGraphicTool(PicDiagram, DiagramSize, DiagramSize)

        'Now, the array of small intervals is defined (pixel-size)
        ReDim NumberOfHits(PicDiagram.Width)

        'Default settings
        CboFunction.SelectedIndex = 1
        CboFunction.Select()
        Iterator.Power = 1

        'Number of Iteration Steps
        LblNumberOfSteps.Text = "0"
        n = 0

        'additional default values
        SetDefaultValues()

    End Sub

    Private Sub SetDefaultValues()

        TxtParameter.Text = Iterator.ParameterInterval.B.ToString(CultureInfo.CurrentCulture)
        TxtStartValue.Text = (Iterator.IterationInterval.A +
            (Iterator.IterationInterval.IntervalWidth * 0.314159)).ToString(CultureInfo.CurrentCulture)

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click

        ResetIteration()

    End Sub

    Private Sub ResetIteration()

        'Clear dispblay
        MyGraphics.Clear(Color.White)
        IsInitialized = False

        'Reset Number of Steps
        n = 0
        LblNumberOfSteps.Text = "0"

        'and Number of Hits
        ReDim NumberOfHits(PicDiagram.Width)

    End Sub

    Private Sub CboFunction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboFunction.SelectedIndexChanged

        Dim type As Integer

        'The user chooses the type of iteration
        type = CboFunction.SelectedIndex
        Select Case type
            Case 0  'Tentmap
                Iterator = New ClsTentmap
            Case 1 'Logistic Growth
                Iterator = New ClsLogisticGrowth
            Case Else  'Parabola
                Iterator = New ClsParabola
        End Select

        'As standard, the function is repeated 1x in each iteration step
        Iterator.Power = 1

        'The parameter and startvalue are depending on the type of iteration
        SetDefaultValues()

        'If the type of iteration changes, everything has tp be reset
        ResetIteration()

    End Sub

    Private Sub TxtParameter_TextChanged(sender As Object, e As EventArgs) Handles TxtParameter.TextChanged

        'If this value changes, the Iteration has to be reset
        ResetIteration()
    End Sub

    Private Sub TxtStartWert_TextChanged(sender As Object, e As EventArgs) Handles TxtStartValue.TextChanged

        'If this value changes, the Iteration has to be reset
        ResetIteration()
    End Sub

    Private Sub InitializeIteration()

        'Checks all manual inputs of the user

        'Checks and sets the value of the parameter
        Dim CheckParameter As New ClsCheckIsNumeric(TxtParameter)

        If CheckParameter.IsInputValid Then
            If Iterator.IsParameterAllowed(CheckParameter.NumericValue) Then
                Iterator.Parameter = CheckParameter.NumericValue
                IsInitialized = True
            Else
                TxtParameter.Text = ""
                TxtParameter.Select()
                IsInitialized = False
            End If
        Else
            IsInitialized = False
        End If

        'Checks and sets the startvalue
        If IsInitialized Then
            Dim CheckStartValue As New ClsCheckIsNumeric(TxtStartValue)
            If CheckStartValue.IsInputValid Then
                If Iterator.IsIterationvalueAllowed(CheckStartValue.NumericValue) Then
                    x = CheckStartValue.NumericValue
                Else
                    TxtStartValue.Text = ""
                    TxtStartValue.Select()
                    IsInitialized = False
                End If
            Else
                IsInitialized = False
            End If
        End If

    End Sub

    'SECTOR HISTOGRAM

    Private Sub BtnNextSteps_Click(sender As Object, e As EventArgs) Handles BtnNextSteps.Click

        'Generates and draws the histogram

        'Counter for the number of the iteration steps of each process (500 steps)
        Dim i As Integer

        'p is the pixel coordinate of the x-axis and the number of the interval that is hit
        Dim p As Integer


        If n = 0 Then

            'In this case the iteration has just started
            'and must be initialized
            ResetIteration()
            InitializeIteration()

            If IsInitialized Then

                'The initialization was succesful
                If Iterator.IsBehaviourChaotic() Then
                    'OK
                Else
                    'nothing to do, a message is already generated
                End If
            End If
        End If


        If IsInitialized Then

            'Iteration of 500 steps
            For i = 1 To 500

                'calculating the location of the interval that is hit
                p = CInt((x - Iterator.IterationInterval.A) * PicDiagram.Width _
                    / Iterator.IterationInterval.IntervalWidth)

                'and increasing the number of hits for this interval
                NumberOfHits(p) += 1

                'increasing the number of iteration steps
                n += 1
                LblNumberOfSteps.Text = n.ToString(CultureInfo.CurrentCulture)

                'Next step of the iteration
                x = Iterator.FN(x)

            Next

            'Clear the display
            MyGraphics.Clear(Color.White)

            'and redraw the actualized histogram
            Dim Brush = Brushes.CadetBlue
            For i = 1 To PicDiagram.Width

                Dim A As New ClsMathpoint(i - 1, 0)
                Dim B As New ClsMathpoint(i, NumberOfHits(i))
                MyGraphics.FillRectangle(A, B, Brush)
            Next
        Else
            'there is already a message generated
            SetDefaultValues()
        End If
    End Sub

End Class