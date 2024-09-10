'This class contains the iteration controller for FrmFeigenbaum

'Status Redesign Tested

Public Class ClsFeigenbaumController

    'The dynamic System
    Private MyDS As IIteration

    'The PicDiagram and Bitmasp
    Private MyPicDiagram As PictureBox
    Private MyBmpDiagram As Bitmap

    'The Graphic Helper for the Graphics
    Private MyBmpGraphics As ClsGraphicTool
    Private MyIsColored As Boolean

    Private MyParameterRange As ClsInterval
    Private MyValueRange As ClsInterval

    'Precision
    Private MyPrecision As Integer

    'IterationStatus
    Private MyIterationStatus As ClsGeneral.EnIterationStatus

    'Iteration Parameters
    Private x As Decimal
    Private RunTimeUntilCycle As Integer
    Private LengthOfCycle As Integer
    Private CyclePoint As ClsMathpoint
    'Iterationsteps
    Private i As Integer

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
            MyBmpGraphics = New ClsGraphicTool(MyBmpDiagram, MyParameterRange, MyValueRange)
        End Set
    End Property

    Property ParameterRange As ClsInterval
        Get
            ParameterRange = MyParameterRange
        End Get
        Set(value As ClsInterval)
            MyParameterRange = value
            MyBmpGraphics.MathXInterval = MyParameterRange
        End Set
    End Property

    Property IterationRange As ClsInterval
        Get
            IterationRange = MyValueRange
        End Get
        Set(value As ClsInterval)
            MyValueRange = value
            MyBmpGraphics.MathYInterval = MyValueRange
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

    Property IterationStatus As ClsGeneral.EnIterationStatus
        Set(value As ClsGeneral.EnIterationStatus)
            MyIterationStatus = value
        End Set
        Get
            IterationStatus = MyIterationStatus
        End Get
    End Property

    Public Sub IterationLoop(p As Integer)

        If MyIterationStatus = ClsGeneral.EnIterationStatus.Ready Then
            'Initialize
            'First, the iteration runs a while until it gets periodic (if the behaviour is not chaotic)
            RunTimeUntilCycle = 1000 * MyPrecision

            'After that, the number of iterations must be big enough to draw the cycle
            LengthOfCycle = CInt(MyPicDiagram.Height * MyValueRange.IntervalWidth _
                * MyPrecision / 25 / Math.Max(MyValueRange.IntervalWidth, 0.01))

            '..but not bigger than the y-axis allows
            LengthOfCycle = Math.Min(LengthOfCycle, 5 * MyPicDiagram.Height)

            'To draw the cycle
            CyclePoint = New ClsMathpoint(MyDS.Parameter, x)
        End If

        MyIterationStatus = ClsGeneral.EnIterationStatus.Running

        'Calculate the parameter a for the iteration depending on p
        MyDS.Parameter = MyParameterRange.A + (MyParameterRange.IntervalWidth * p / MyPicDiagram.Width)
        CyclePoint.X = MyDS.Parameter

        'Initialize Iteration
        'The startvalue x for the iteration should be the same for all values of a
        x = MyDS.CriticalPoint

        i = 1

        Do
            x = MyDS.FN(x)
            i += 1
        Loop Until (i > RunTimeUntilCycle - 1)

        i = RunTimeUntilCycle

        CyclePoint.Y = x

        Do
            MyBmpGraphics.DrawPoint(CyclePoint, SetColor(i), 1)
            x = MyDS.FN(x)
            CyclePoint.Y = Math.Max(MyDS.IterationInterval.A, Math.Min(x, MyDS.IterationInterval.B))
            i += 1
        Loop Until (i > RunTimeUntilCycle + LengthOfCycle)

        MyPicDiagram.Refresh()

        MyIterationStatus = ClsGeneral.EnIterationStatus.Stopped

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
                    MyBmpGraphics.DrawLine(A, B, Color.Green, 1)
                Else
                    MyBmpGraphics.DrawLine(A, B, Color.Red, 1)
                End If
            End If
        Next
        MyPicDiagram.Refresh()

    End Sub

    Public Sub ResetIteration()

        MyBmpGraphics.Clear(Color.White)
        MyPicDiagram.Refresh()

        MyIterationStatus = ClsGeneral.EnIterationStatus.Stopped

    End Sub

End Class
