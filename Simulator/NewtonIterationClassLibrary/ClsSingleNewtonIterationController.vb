'This class is the controller for the single Newton iteration

'Status checked

Imports System.Reflection

Public Class ClsSingleNewtonIterationController

    Private ReadOnly MyForm As FrmSingleNewtonIteration
    Private ReadOnly LM As ClsLanguageManager

    'Unit Roots
    Private N As Integer 'Exponent of unit roots, N = 2, 3
    Private UnitRoots As List(Of ClsComplexNumber)

    'Coordinates of the pixel with the startvalue
    Private p As Integer
    Private q As Integer
    Private StartPoint As ClsComplexNumber
    Private ActualPoint As ClsComplexNumber
    Private OldPoint As ClsComplexNumber

    'Mouse
    Private IsMouseDown As Boolean = False

    'Iteration
    Private IterationStatus As ClsDynamics.EnIterationStatus
    Const ConvergenceLimit As Decimal = CDec(0.01)
    Private Steps As Integer
    Const MaxSteps As Integer = 100

    'Drawing
    Private BmpDiagram As Bitmap
    Private BmpGraphics As ClsGraphicTool
    Private PicGraphics As ClsGraphicTool
    Private MathInterval As ClsInterval

    'SECTOR INITIALIZATION

    Public Sub New(Form As FrmSingleNewtonIteration)
        MyForm = Form
        LM = ClsLanguageManager.LM
        UnitRoots = New List(Of ClsComplexNumber)

        MathInterval = New ClsInterval(CDec(-1.5), CDec(1.5))
        PicGraphics = New ClsGraphicTool(MyForm.PicDiagram, MathInterval, MathInterval)
        BmpDiagram = New Bitmap(MyForm.PicDiagram.Width, MyForm.PicDiagram.Height)
        MyForm.PicDiagram.Image = BmpDiagram
        BmpGraphics = New ClsGraphicTool(BmpDiagram, MathInterval, MathInterval)

        N = 3 'Standard
        MyForm.CboN.SelectedIndex = 1
        LoadRoots()

        StartPoint = New ClsComplexNumber(0, 0)
        ActualPoint = New ClsComplexNumber(0, 0)
        OldPoint = New ClsComplexNumber(0, 0)
        MyForm.TxtA.Text = "0.5"
        MyForm.TxtB.Text = "1"
    End Sub

    Public Sub LoadRoots()

        BmpGraphics.Clear(Color.White)
        N = CInt(MyForm.CboN.SelectedItem)

        'Generate Roots
        UnitRoots.Clear()

        Dim W = New ClsComplexNumber(1, 0)
        UnitRoots.Add(W)

        For k = 2 To N
            W = W.Rotate(CDec(2 * Math.PI / N))
            UnitRoots.Add(W)
        Next
    End Sub

    Public Sub ResetIteration()
        MyForm.PicDiagram.Refresh()
        IterationStatus = ClsDynamics.EnIterationStatus.Stopped
        DrawCoordinateSystem()
        Steps = 0
        MyForm.BtnNextStep.Enabled = True
        MyForm.CboN.Enabled = True
    End Sub

    Private Sub DrawCoordinateSystem()

        'Coordinate System
        BmpGraphics.DrawLine(New ClsMathpoint(0, CDec(-1.5)), New ClsMathpoint(0, CDec(1.5)), Color.Black, 1)
        BmpGraphics.DrawLine(New ClsMathpoint(CDec(-1.5), 0), New ClsMathpoint(CDec(1.5), 0), Color.Black, 1)

        'Unit Roots
        BmpGraphics.DrawPoint(UnitRoots(0), Brushes.Red, 3)
        BmpGraphics.DrawPoint(UnitRoots(1), Brushes.Blue, 3)

        If N = 3 Then
            BmpGraphics.DrawPoint(UnitRoots(2), Brushes.Green, 3)
        End If

        'expected basins?
        Select Case N
            Case 2
                'Separated by y-axis
                BmpGraphics.DrawLine(New ClsMathpoint(0, CDec(-1.5)), New ClsMathpoint(0, CDec(1.5)), Color.Magenta, 1)
            Case 3
                'separated by 120° lines
                Dim BP As New ClsComplexNumber(-1.5, 0)
                Dim ZeroPoint As New ClsMathpoint(0, 0)
                BmpGraphics.DrawLine(ZeroPoint, New ClsMathpoint(CDec(BP.X), CDec(BP.Y)), Color.Magenta, 1)
                BP = BP.Rotate(2 * Math.PI / 3)
                BmpGraphics.DrawLine(ZeroPoint, New ClsMathpoint(CDec(BP.X), CDec(BP.Y)), Color.Magenta, 1)
                BP = BP.Rotate(2 * Math.PI / 3)
                BmpGraphics.DrawLine(ZeroPoint, New ClsMathpoint(CDec(BP.X), CDec(BP.Y)), Color.Magenta, 1)
        End Select

        MyForm.PicDiagram.Refresh()

    End Sub

    Public Sub NextStep()
        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            StartPoint.X = CDbl(MyForm.TxtA.Text)
            StartPoint.Y = CDbl(MyForm.TxtB.Text)
            ActualPoint.Equal(StartPoint)
            IterationStatus = ClsDynamics.EnIterationStatus.Ready
        End If

        If IterationStatus = ClsDynamics.EnIterationStatus.Ready Then
            IterationStep()
        End If
    End Sub

    Private Function IsConvergent() As Boolean

        Dim OK As Boolean = False
        If ActualPoint.Add(UnitRoots(0).Stretch(CDec(-1))).AbsoluteValue < ConvergenceLimit Then
            PicGraphics.DrawPoint(ActualPoint, Brushes.Red, 3)
            PicGraphics.DrawPoint(StartPoint, Brushes.Red, 3)
            OK = True
        ElseIf ActualPoint.Add(UnitRoots(1).Stretch(CDec(-1))).AbsoluteValue < ConvergenceLimit Then
            PicGraphics.DrawPoint(ActualPoint, Brushes.Blue, 3)
            PicGraphics.DrawPoint(StartPoint, Brushes.Blue, 3)
            OK = True
        End If

        If N = 3 Then
            If ActualPoint.Add(UnitRoots(2).Stretch(CDec(-1))).AbsoluteValue < ConvergenceLimit Then
                PicGraphics.DrawPoint(ActualPoint, Brushes.Green, 3)
                PicGraphics.DrawPoint(StartPoint, Brushes.Green, 3)
                OK = True
            End If
        End If

        Return OK

    End Function

    Private Sub IterationLoop()

        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then

            'Startpoint and Actualpoint are already set
            IterationStatus = ClsDynamics.EnIterationStatus.Running
            MyForm.BtnNextStep.Enabled = False
            MyForm.BtnReset.Enabled = False
            MyForm.Cursor = Cursors.WaitCursor
            MyForm.CboN.Enabled = False
        End If

        Do Until IterationStatus = ClsDynamics.EnIterationStatus.Interrupted
            IterationStep()
        Loop

        MyForm.BtnReset.Enabled = True
        MyForm.Cursor = Cursors.Arrow
        Steps = 0
    End Sub

    Private Sub IterationStep()
        Steps += 1
        PicGraphics.DrawPoint(ActualPoint, Brushes.Black, 3)
        OldPoint.Equal(ActualPoint)
        ActualPoint.Equal(Newton3N(ActualPoint))
        PicGraphics.DrawLine(OldPoint, ActualPoint, Brushes.Black, 1)
        If IsConvergent() Or Steps > MaxSteps Then
            IterationStatus = ClsDynamics.EnIterationStatus.Interrupted
        End If
    End Sub

    Private Function Newton3N(Z As ClsComplexNumber) As ClsComplexNumber

        Dim W As ClsComplexNumber = Z.Stretch((N - 1) / N).Add(Denominator(Z))

        Return W

    End Function


    Public Function Denominator(Z As ClsComplexNumber) As ClsComplexNumber

        Return Z.Power(N - 1).Invers.Stretch(1 / N)

    End Function

    'MOUSE SETTING STARTPOINT

    Public Sub MouseDown(e As MouseEventArgs)

        MyForm.Cursor = Cursors.Hand
        IsMouseDown = True

        'Get the coordinates of the mouse click
        p = e.X
        q = e.Y
        Dim PixelPoint As New Point(p, q)
        Dim MathPoint As ClsMathpoint = PicGraphics.PixelToMathpoint(PixelPoint)

        MyForm.PicDiagram.Refresh()
        StartPoint = New ClsComplexNumber(MathPoint.X, MathPoint.Y)
        ActualPoint.Equal(StartPoint)
        PicGraphics.DrawPoint(ActualPoint, Brushes.Black, 3)
        MyForm.TxtA.Text = MathPoint.X.ToString()
        MyForm.TxtB.Text = MathPoint.Y.ToString()

    End Sub

    Public Sub MouseMove(e As MouseEventArgs)
        If IsMouseDown Then
            'Get the coordinates of the mouse move
            p = e.X
            q = e.Y

            'Convert to a point
            Dim PixelPoint As New Point(p, q)
            Dim MathPoint As ClsMathpoint = PicGraphics.PixelToMathpoint(PixelPoint)

            MyForm.PicDiagram.Refresh()
            StartPoint = New ClsComplexNumber(MathPoint.X, MathPoint.Y)
            MyForm.TxtA.Text = MathPoint.X.ToString("N10")
            MyForm.TxtB.Text = MathPoint.Y.ToString("N10")
            ActualPoint.Equal(StartPoint)
            Steps = 0
            IterationStatus = ClsDynamics.EnIterationStatus.Stopped
            IterationLoop()
        End If
    End Sub

    Public Sub MouseUp(e As MouseEventArgs)

        'The Mouse gets its normal behaviour again
        MyForm.Cursor = Cursors.Arrow
        IsMouseDown = False

    End Sub


End Class
