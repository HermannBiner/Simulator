'This Class contains the iteration controller for FrmHistogram

'Status Redesign Tested

Imports System.Globalization

Public Class ClsHistogramController

    'The dynamic System
    Private MyDS As IIteration

    'The PicDiagram
    Private MyPicDiagram As PictureBox

    'The x-axis in the PicDiagram
    Private XRange As ClsInterval

    'The Graphic Helper for PicDiagram
    Private MyPicGraphics As ClsGraphicTool

    'Status Parameters
    'Number of Iteration Steps
    Private n As Integer
    Private MyLblN As Label
    Private MyIterationStatus As ClsDynamics.EnIterationStatus

    'Actual value of the iteration
    Private x As Decimal

    'How many times does the iterated value hit a small interval?
    'NumberOfHits is an array if those intervals
    Private NumberOfHits() As Integer

    WriteOnly Property DS As IIteration
        Set(value As IIteration)
            MyDS = value
        End Set
    End Property

    WriteOnly Property PicDiagram As PictureBox
        Set(value As PictureBox)
            MyPicDiagram = value
            XRange = New ClsInterval(1, MyPicDiagram.Width)
            MyPicGraphics = New ClsGraphicTool(MyPicDiagram, XRange, XRange)

            'Now, the array of small intervals is defined (pixel-size)
            ReDim NumberOfHits(MyPicDiagram.Width)
        End Set
    End Property

    WriteOnly Property LblN As Label
        Set(value As Label)
            MyLblN = value
        End Set
    End Property

    Property IterationStatus As ClsDynamics.EnIterationStatus
        Set(value As ClsDynamics.EnIterationStatus)
            MyIterationStatus = value
        End Set
        Get
            IterationStatus = MyIterationStatus
        End Get
    End Property

    WriteOnly Property StartValue As Decimal
        Set(value As Decimal)
            x = value
        End Set
    End Property

    Public Function IterationLoop() As Task

        'p is the pixel coordinate of the x-axis and the number of the interval that is hit
        Dim p As Integer

        Do

            'calculating the location of the interval that is hit
            p = CInt((x - MyDS.IterationInterval.A) * MyPicDiagram.Width _
                / MyDS.IterationInterval.IntervalWidth)

            'and increasing the number of hits for this interval
            NumberOfHits(p) += 1

            'increasing the number of iteration steps
            n += 1
            MyLblN.Text = n.ToString(CultureInfo.CurrentCulture)

            'Next step of the iteration
            x = MyDS.FN(x)

            If n Mod 1000 = 0 Then

                'redraw the actualized histogram
                Dim Brush = Brushes.CadetBlue
                For i = 1 To MyPicDiagram.Width

                    Dim A As New ClsMathpoint(i - 1, 0)
                    Dim B As New ClsMathpoint(i, NumberOfHits(i))
                    MyPicGraphics.FillRectangle(A, B, Brush)
                Next

                Application.DoEvents()
                Task.Delay(2)

            End If

        Loop Until IterationStatus = ClsDynamics.EnIterationStatus.Stopped _
            Or IterationStatus = ClsDynamics.EnIterationStatus.Interrupted

        Return Task.CompletedTask

    End Function

    Public Sub ResetIteration()

        'PicDiagram cleared
        MyPicGraphics.Clear(Color.White)

        'Status Parameters Cleared
        MyLblN.Text = "0"
        n = 0

        MyIterationStatus = ClsDynamics.EnIterationStatus.Stopped
        ReDim NumberOfHits(MyPicDiagram.Width)

    End Sub

End Class
