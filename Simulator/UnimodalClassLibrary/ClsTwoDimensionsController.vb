
'This class contains the iteration controller for FrmTwoDimensions

'Status Redesign Tested

Public Class ClsTwoDimensionsController

    'The dynamic System
    Private MyDS As IIteration

    'The PicDiagram
    Private MyPicDiagram As PictureBox


    'The Graphic Helper for PicDiagram
    Private MyPicGraphics As ClsGraphicTool

    'Actual values of the iteration
    Private Myx As Decimal
    Private Myy As Decimal

    'Representing the raster for the measure exactness of the experimentator in Pixels
    Private Const Rastersize As Integer = 5

    'Corresponding x-Value
    Private deltaX As Decimal

    'Used for the Diagram
    Private Diagramsize As Integer
    Private MyBrush As SolidBrush

    'Iteration Status
    Private MyIterationStatus As ClsDynamics.EnIterationStatus

    WriteOnly Property DS As IIteration
        Set(value As IIteration)
            MyDS = value
        End Set
    End Property

    WriteOnly Property PicDiagram As PictureBox
        Set(value As PictureBox)
            MyPicDiagram = value
            MyPicGraphics = New ClsGraphicTool(MyPicDiagram, MyDS.IterationInterval, MyDS.IterationInterval)
            Diagramsize = Math.Min(MyPicDiagram.Width, MyPicDiagram.Height)
        End Set
    End Property

    WriteOnly Property StartValueX As Decimal
        Set(value As Decimal)
            Myx = value
        End Set
    End Property

    WriteOnly Property StartValueY As Decimal
        Set(value As Decimal)
            Myy = value
        End Set
    End Property

    WriteOnly Property Brush As SolidBrush
        Set(value As SolidBrush)
            MyBrush = value
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

    Public Sub PrepareDiagram()

        'The raster shows the measure exactness of the experimentator
        'one square in the raster has 5x5 pixel points
        'that corresponds to a measure exactness of about 0.00825 for the x- and y-values

        'Counter
        Dim i As Integer

        'Corresponding x- and y-coordinates
        Dim u As Decimal

        'Adapting DeltaX to the Iteration.Interval.Width
        'that all type of Iteration Functions have the same Raster
        deltaX = CDec(Rastersize / Diagramsize) * MyDS.IterationInterval.IntervalWidth

        Do

            'lines parallel to the y-axis
            u = MyDS.IterationInterval.A + (i * deltaX)
            Dim X1 As New ClsMathpoint(u, MyDS.IterationInterval.A)
            Dim X2 As New ClsMathpoint(u, MyDS.IterationInterval.B)
            MyPicGraphics.DrawLine(X1, X2, Color.Aqua, 1)

            'lines parallel to the x-axis
            Dim Y1 As New ClsMathpoint(MyDS.IterationInterval.A, u)
            Dim Y2 As New ClsMathpoint(MyDS.IterationInterval.B, u)
            MyPicGraphics.DrawLine(Y1, Y2, Color.Aqua, 1)

            i += 1

        Loop Until i * deltaX >= MyDS.IterationInterval.IntervalWidth

    End Sub

    Public Sub IterationLoop(EndOfLoop As Integer)

        'Mark the startpoint
        Dim Startpoint As New ClsMathpoint(Myx, Myy)
        MyPicGraphics.DrawPoint(Startpoint, MyBrush, 2)
        MyPicGraphics.DrawCircle(Startpoint, 5, MyBrush.Color, 1)

        'the next steps of the iteration are performed
        Dim i As Integer
        For i = 1 To EndOfLoop

            Dim P As New ClsMathpoint(Myx, Myy)
            Dim nextP As New ClsMathpoint(MyDS.FN(Myx), MyDS.FN(Myy))

            'draw result
            MyPicGraphics.DrawPoint(nextP, MyBrush, 1)
            MyPicGraphics.DrawLine(P, nextP, MyBrush.Color, 1)
            Myx = MyDS.FN(Myx)
            Myy = MyDS.FN(Myy)

        Next

    End Sub
    Public Sub ResetIteration()

        'Clear Display
        MyPicGraphics.Clear(Color.White)
        IterationStatus = ClsDynamics.EnIterationStatus.Stopped

    End Sub

End Class
