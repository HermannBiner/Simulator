'This form allows testing graphical or other methods
'normally, the menu to open this form in FrmMain is not visible
'Status checked

Imports System.ComponentModel
Imports System.Threading

Public Class FrmTests

    Private MyMathRange As ClsInterval
    Private MyDiagramSize As Integer

    Private MyPictureBoxDrawer As ClsGraphicTool

    Private MyBitmap As Bitmap
    Private MyShiftedBitmap As Bitmap
    Private MyBitmapDrawer As ClsGraphicTool

    Private StopIteration As Boolean
    Private Start As Boolean = True

    'Iteration
    Private Angle As Decimal
    Private XShift As Integer
    Private DeltaAngle As Decimal

    Private Pendulum As ClsMathpoint
    Private Trace As ClsMathpoint
    Private NextTrace As ClsMathpoint

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

        'Initialize Language
        InitializeLanguage()

    End Sub

    Private Sub InitializeLanguage()

        BtnTest.Text = Main.LM.GetString("Test")
        Text = Main.LM.GetString("Test")

    End Sub

    Private Sub FrmTests_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Initialize Bitmap
        MyDiagramSize = Math.Min(PicDiagram.Width, PicDiagram.Height)
        MyBitmap = New Bitmap(MyDiagramSize, MyDiagramSize)
        PicDiagram.Image = MyBitmap


        'Initialize GraphicTools
        MyMathRange = New ClsInterval(CDec(-1), CDec(1))
        MyPictureBoxDrawer = New ClsGraphicTool(PicDiagram, MyMathRange, MyMathRange)
        MyBitmapDrawer = New ClsGraphicTool(MyBitmap, MyMathRange, MyMathRange)
        MyBitmapDrawer.Clear(Color.White)

    End Sub


    Private Async Sub BtnTest_Click(sender As Object, e As EventArgs) Handles BtnTest.Click

        StopIteration = False
        Await IterationLoopTest()

        If Start Then
            Start = False
        End If


    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click

        StopIteration = True

    End Sub

    Private Async Function IterationLoopTest() As Task

        If Start Then

            'Initializing only in the beginning
            'that gives the possibility to continue after an interrupt
            Angle = 0
            DeltaAngle = CDec(0.05)
            XShift = 1

            Pendulum = New ClsMathpoint(CDec(-0.95), 0)
            Trace = New ClsMathpoint(Pendulum.X, 0)
            NextTrace = New ClsMathpoint(Pendulum.X - CDec(XShift * MyMathRange.IntervalWidth / MyDiagramSize), CDec(Math.Sin(DeltaAngle)))
            Start = False
        End If


        Do

            'copy the bitmap
            MyShiftedBitmap = New Bitmap(MyBitmap)

            'Draw the copy right-shifted into the bitmap
            MyBitmapDrawer.Clear(Color.White)
            MyBitmapDrawer.DrawImage(MyShiftedBitmap, XShift, 0)

            'Draw the line into the bitmap
            MyBitmapDrawer.DrawLine(Trace, NextTrace, Color.Blue, 1)

            'update the Picdiagram
            PicDiagram.Invalidate()
            MyPictureBoxDrawer.DrawPoint(Pendulum, Brushes.Red, 3)

            'prepare the next point
            Angle += DeltaAngle
            Angle = Angle Mod CDec(Math.PI * 2)

            Pendulum.Y = CDec(Math.Sin(Angle))

            Trace.Y = NextTrace.Y
            NextTrace.Y = Pendulum.Y

            LstValues.Items.Add(Trace.X.ToString & ", " & Trace.Y.ToString)

            Await Task.Delay(10)

        Loop Until StopIteration

    End Function

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        MyBitmapDrawer.Clear(Color.White)
        MyBitmapDrawer.Clear(Color.White)
        PicDiagram.Refresh()
        LstValues.Items.Clear()
        Start = True

    End Sub
End Class
