'This class contains the iteration controller for FrmFeigenbaum

'Status Redesign Tested

Public Class ClsFeigenbaumController


    'The dynamic System
    Private MyDS As IIteration

    'The PicDiagram and Bitmasp
    Private MyPicDiagram As PictureBox
    Private MyBmpDiagram As Bitmap

    'The Graphic Helper for the Graphics
    Private MyBmpDiagramGraphics As ClsGraphicTool
    Private MyIsColored As Boolean

    'User Ranges for Parameter and Iteration
    Private MyParameterRange As ClsInterval
    Private MyIterationRange As ClsInterval

    'Precision
    Private MyPrecision As Integer

    WriteOnly Property DS As IIteration
        Set(value As IIteration)
            MyDS = value
        End Set
    End Property

    WriteOnly Property PicDiagram As PictureBox
        Set(value As PictureBox)
            MyPicDiagram = value
            MyBmpDiagram = New Bitmap(MyPicDiagram.Width, MyPicDiagram.Height)
            MyPicDiagram.Image = MyBmpDiagram
            MyBmpDiagramGraphics = New ClsGraphicTool(MyBmpDiagram, MyParameterRange, MyIterationRange)
        End Set
    End Property

    Property ParameterRange As ClsInterval
        Get
            ParameterRange = MyParameterRange
        End Get
        Set(value As ClsInterval)
            MyParameterRange = value
            MyBmpDiagramGraphics.MathXInterval = MyParameterRange
        End Set
    End Property

    Property IterationRange As ClsInterval
        Get
            IterationRange = MyIterationRange
        End Get
        Set(value As ClsInterval)
            MyIterationRange = value
            MyBmpDiagramGraphics.MathYInterval = MyIterationRange
        End Set
    End Property

    WriteOnly Property IsColored As Boolean
        Set(value As Boolean)
            MyIsColored = value
        End Set
    End Property

    WriteOnly Property Precision As Integer
        Set(value As Integer)
            MyPrecision = value
        End Set
    End Property

    Public Sub IterationLoop(p As Integer)

        'The startvalue x for the iteration should be the same for all values of a
        Dim x As Decimal = CDec(MyDS.IterationInterval.A + (MyIterationRange.IntervalWidth * 0.31415926535))

        'Calculate the parameter a for the iteration depending on p
        Dim a As Decimal = MyParameterRange.A + (MyParameterRange.IntervalWidth * p / MyPicDiagram.Width)
        MyDS.Parameter = a

        'First, the iteration runs a while until it gets periodic (if the behaviour is not chaotic)
        Dim RuntimeUntilCycle As Integer = 1000 * MyPrecision
        For n = 1 To RuntimeUntilCycle - 1
            x = MyDS.FN(x)
        Next

        'After that, the number of iterations must be big enough to draw the cycle
        Dim LengthOfCycle As Integer = CInt(MyPicDiagram.Height * MyIterationRange.IntervalWidth _
            * MyPrecision / 25 / Math.Max(MyIterationRange.IntervalWidth, 0.01))

        '..but not bigger than the y-axis allows
        LengthOfCycle = Math.Min(LengthOfCycle, 5 * MyPicDiagram.Height)

        'Finally , the cycle is drawn
        Dim Z As New ClsMathpoint(a, x)

        For n = RuntimeUntilCycle To RuntimeUntilCycle + LengthOfCycle
            MyBmpDiagramGraphics.DrawPoint(Z, SetColor(n), 1)
            x = MyDS.FN(x)
            Z.Y = x
        Next

        MyPicDiagram.Refresh()

    End Sub

    Private Function SetColor(n As Integer) As Brush

        'It's possible to use two colors for the image
        'The reader can add more colors by programming

        Dim MyBrush As Brush

        If MyIsColored Then
            Select Case n Mod 2
                Case 0
                    MyBrush = Brushes.Blue
                Case Else
                    MyBrush = Brushes.Green
            End Select
        Else
            MyBrush = Brushes.Blue
        End If

        Return MyBrush

    End Function

    Public Sub DrawSplitPoints()

        'the first split points are marked by vertical lines
        Dim Splitpoints As List(Of Decimal) = MyDS.Splitpoints
        Dim i As Integer
        Dim A As New ClsMathpoint
        Dim B As New ClsMathpoint

        For i = 0 To Splitpoints.Count - 1
            If MyDS.ParameterInterval.IsNumberInInterval(Splitpoints(i)) Then
                A.X = Splitpoints(i)
                A.Y = MyDS.IterationInterval.A
                B.X = Splitpoints(i)
                B.Y = MyDS.IterationInterval.B
                If i < Splitpoints.Count - 1 Then
                    MyBmpDiagramGraphics.DrawLine(A, B, Color.Green, 1)
                Else
                    MyBmpDiagramGraphics.DrawLine(A, B, Color.Red, 1)
                End If
            End If
        Next
        MyPicDiagram.Refresh()

    End Sub

    Public Sub ResetIteration()

        MyBmpDiagramGraphics.Clear(Color.White)
        MyPicDiagram.Refresh()

    End Sub

End Class
