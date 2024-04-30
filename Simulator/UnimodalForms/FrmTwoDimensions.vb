'Suppose an experimentator works in a two dimensional space and chooses a startpoint for his experiment
'and suppose, the exactness of his measure instruments is limited
'in that case, two startpoints that are a little bit different, are measured as identical startpoints
'but if the behaviour is chaotic, this little difference leads to completely different orbits
'for the experimentator, the experiment looks like random
'because in his view, he starts always at the same startpoint
'but the generated orbits are completely different
'Iterated are unimodal functions like Tentmap, Logistic Growth or Parabola
'see the mathematical documentation

'The form is based on an Interface IIteration 
'that is implemented by ClsTentmap, ClsLogisticGrowth, ClsParabola
'Therefore, more cases of unimodal functions could be easely programmed
'just by implementing hits interface

'Status Checked

Imports System.Globalization
Imports System.Reflection

Public Class FrmTwoDimensions

    'Prepare basic objects
    Private MyGraphics As ClsGraphicTool
    Private Iterator As IIteration

    'Private global variables

    'Number of Iteration Steps
    Private n As Integer

    'Actual values of the iteration
    Private x As Decimal
    Private y As Decimal

    'Representing the raster for the measure exactness of the experimentator in Pixels
    Private Const Rastersize As Integer = 5

    'Corresponding x-Value
    Private deltaX As Decimal

    'additional
    Private Diagramsize As Integer
    Private MyBrush As Brush
    Private MyColor As Color
    Private IsNewExperiment As Boolean

    'IterationDepth: 5 is optimal, due to experiments
    Private Const Standardpower As Integer = 5

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub InitializeLanguage()

        Text = Main.LM.GetString("TwoDimensions")
        GrpParameter.Text = Main.LM.GetString("Parameter")
        GrpExperiment.Text = Main.LM.GetString("ExperimentNo")
        BtnNextStep.Text = Main.LM.GetString("NextStep")
        BtnReset.Text = Main.LM.GetString("ResetIteration")
        BtnNext10.Text = Main.LM.GetString("Next10Steps")
        GrpStartpoint.Text = Main.LM.GetString("CoordinatesStartpoint")
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

    Private Sub FrmZweidimensional_Load(sender As Object, e As EventArgs) Handles Me.Load

        'set objects
        'the same Iterator iterates the x- and y-values
        Iterator = New ClsLogisticGrowth
        MyGraphics = New ClsGraphicTool(PicDiagram, Iterator.IterationInterval, Iterator.IterationInterval)

        'Iteration Depth
        Iterator.Power = Standardpower

        'Initialize Language
        InitializeLanguage()

        'Default settings
        Diagramsize = Math.Min(PicDiagram.Width, PicDiagram.Height)

        'additional Defaults
        SetDefaultValues()

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

        Iterator.Power = Standardpower

        MyGraphics = New ClsGraphicTool(PicDiagram, Iterator.IterationInterval, Iterator.IterationInterval)

        TxtParameter.Text = Iterator.ParameterInterval.B.ToString(CultureInfo.CurrentCulture)

        ResetIteration()

    End Sub

    Private Sub SetDefaultValues()

        TxtX.Text = (Iterator.IterationInterval.A +
            (Iterator.IterationInterval.IntervalWidth * 0.414)).ToString(CultureInfo.CurrentCulture)
        TxtY.Text = (Iterator.IterationInterval.A +
            (Iterator.IterationInterval.IntervalWidth * 0.407)).ToString(CultureInfo.CurrentCulture)
        TxtParameter.Text = Iterator.ParameterInterval.B.ToString(CultureInfo.CurrentCulture)
        CboExperiment.SelectedIndex = 0
        MyBrush = Brushes.Black
        MyColor = Color.Black
        IsNewExperiment = True
        TxtX.Select()

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        ResetIteration()
    End Sub

    Private Sub ResetIteration()

        'Clear Display
        MyGraphics.Clear(Color.White)

        'Reset Number of Steps
        n = 0

        IsNewExperiment = True

    End Sub

    Private Sub CboExperiment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboExperiment.SelectedIndexChanged

        'To show the effect of different experiments,
        'there are 5 possible startpoints in different colors

        IsNewExperiment = True
        Select Case CboExperiment.SelectedIndex
            Case 0
                MyBrush = Brushes.Black
                MyColor = Color.Black
                n = 0
            Case 1
                MyBrush = Brushes.Green
                MyColor = Color.Green
            Case 2
                MyBrush = Brushes.Blue
                MyColor = Color.Blue
            Case 3
                MyBrush = Brushes.Magenta
                MyColor = Color.Magenta
            Case Else
                MyBrush = Brushes.Red
                MyColor = Color.Red
        End Select
    End Sub

    Private Sub DrawRaster()

        'The raster shows the measure exactness of the experimentator
        'one square in the raster has 5x5 pixel points
        'that corresponds to a measure exactness of about 0.00825 for the x- and y-values

        'Counter
        Dim i As Integer

        'Corresponding x- and y-coordinates
        Dim u As Decimal

        'Adapting DeltaX to the Iteration.Interval.Width
        'that all type of Iteration Functions have the same Raster
        deltaX = CDec(Rastersize / Diagramsize) * Iterator.IterationInterval.IntervalWidth

        Do

            'lines parallel to the y-axis
            u = Iterator.IterationInterval.A + (i * deltaX)
            Dim X1 As New ClsMathpoint(u, Iterator.IterationInterval.A)
            Dim X2 As New ClsMathpoint(u, Iterator.IterationInterval.B)
            MyGraphics.DrawLine(X1, X2, Color.Aqua, 1)

            'lines parallel to the x-axis
            Dim Y1 As New ClsMathpoint(Iterator.IterationInterval.A, u)
            Dim Y2 As New ClsMathpoint(Iterator.IterationInterval.B, u)
            MyGraphics.DrawLine(Y1, Y2, Color.Aqua, 1)

            i += 1

        Loop Until i * deltaX >= Iterator.IterationInterval.IntervalWidth

    End Sub

    Private Sub TxtX_TextChanged(sender As Object, e As EventArgs) Handles TxtX.TextChanged

        'If this value changes, the Iteration has to be reset
        IsNewExperiment = True
    End Sub

    Private Sub TxtY_TextChanged(sender As Object, e As EventArgs) Handles TxtY.TextChanged

        'If this value changes, the Iteration has to be reset
        IsNewExperiment = True
    End Sub

    Private Function InitializeIteration() As Boolean

        'Checks all manual inputs of the user

        Dim IsAllvalid As Boolean

        'Checks and sets the value of the parameter
        Dim CheckParameter As New ClsCheckIsNumeric(TxtParameter)

        If CheckParameter.IsInputValid Then
            If Iterator.IsParameterAllowed(CheckParameter.NumericValue) Then
                Iterator.Parameter = CheckParameter.NumericValue
                IsAllvalid = True
            Else
                TxtParameter.Text = ""
                TxtParameter.Select()
                IsAllvalid = False
            End If
        Else
            IsAllvalid = False
        End If

        'Checks and sets the x-startvalue
        If IsAllvalid Then
            Dim CheckXStartvalue As New ClsCheckIsNumeric(TxtX)
            If CheckXStartvalue.IsInputValid Then
                If Iterator.IsIterationvalueAllowed(CheckXStartvalue.NumericValue) Then
                    x = CheckXStartvalue.NumericValue
                Else
                    TxtX.Text = ""
                    TxtX.Select()
                    IsAllvalid = False
                End If
            Else
                IsAllvalid = False
            End If
        End If

        'Checks and sets the y-startvalue
        If IsAllvalid Then
            Dim CheckYStartvalue As New ClsCheckIsNumeric(TxtY)
            If CheckYStartvalue.IsInputValid Then
                If Iterator.IsIterationvalueAllowed(CheckYStartvalue.NumericValue) Then
                    y = CheckYStartvalue.NumericValue
                Else
                    TxtY.Text = ""
                    TxtY.Select()
                    IsAllvalid = False
                End If
            Else
                IsAllvalid = False
            End If
        End If

        'Prepare the iteration
        If IsAllvalid Then
            If n = 0 Then
                DrawRaster()
            End If

            'Mark the startpoint
            Dim Startpoint As New ClsMathpoint(x, y)
            MyGraphics.DrawPoint(Startpoint, MyBrush, 2)
            MyGraphics.DrawCircle(Startpoint, 5, MyColor, 1)
            n += 1
        Else
            MessageBox.Show(Main.LM.GetString("ActionStopped"))

            SetDefaultValues()
        End If

        Return IsAllvalid

    End Function

    'SECTOR ITERATION

    Private Sub BtnNextStep_Click(sender As Object, e As EventArgs) Handles BtnNextStep.Click

        'Perform one iteration step
        DoIteration(1)
    End Sub

    Private Sub BtnNext10_Click(sender As Object, e As EventArgs) Handles BtnNext10.Click

        'Perform 10 iteration steps
        DoIteration(10)
    End Sub

    Private Sub DoIteration(EndOfLoop As Integer)

        'steering the iteration
        If IsNewExperiment Then
            If InitializeIteration() Then
                IsNewExperiment = False
                IterationLoop(EndOfLoop)
            End If
        Else
            IterationLoop(EndOfLoop)
        End If

    End Sub

    Private Sub IterationLoop(EndOfLoop As Integer)

        'the next steps of the iteration are performed
        Dim i As Integer
        For i = 1 To EndOfLoop

            Dim P As New ClsMathpoint(x, y)
            Dim nextP As New ClsMathpoint(Iterator.FN(x), Iterator.FN(y))

            'draw result
            MyGraphics.DrawPoint(nextP, MyBrush, 1)
            MyGraphics.DrawLine(P, nextP, MyColor, 1)
            x = Iterator.FN(x)
            y = Iterator.FN(y)

        Next
        n += EndOfLoop

    End Sub
End Class