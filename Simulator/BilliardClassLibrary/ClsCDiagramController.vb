'This class contains the controller for the FrmCDiagram

Imports System.Reflection

Public Class ClsCDiagramController


    'The dynamic System
    Private MyDS As IBilliardTable
    Private ActualBilliardBall As IBilliardball

    'The PicDiagram and Bitmasp
    Private MyPicDiagram As PictureBox
    Private MyBmpDiagram As Bitmap

    'The Graphic Helper for the Graphics
    Private MyPicGraphics As ClsGraphicTool
    Private MyBmpGraphics As ClsGraphicTool

    'Precision
    Private MyPrecision As Integer
    Private MyTrbStartPosition As Integer

    'Value Range for the Iteration Value to be învestigated
    'selected in the CboValueRange
    Private MyValueParameter As ClsValueParameter

    'User Ranges for Parameter and Iteration
    Private MyParameterRange As ClsInterval = New ClsInterval(CDec(0.5), 2)
    Private MyValueRange As ClsInterval = New ClsInterval(0, 1) 'set later

    'IterationStatus
    Private MyIterationStatus As ClsDynamics.EnIterationStatus

    'Iteration Parameters
    'Startpoint
    Private ActualPair As ClsValuePair
    Private NextPair As ClsValuePair
    Private CyclePoint As ClsMathpoint
    Private LengthOfCycle As Integer


    WriteOnly Property DS As IBilliardTable
        Set(value As IBilliardTable)
            MyDS = value
            ActualBilliardBall = MyDS.GetBilliardBall
        End Set
    End Property

    WriteOnly Property PicDiagram As PictureBox
        Set(value As PictureBox)
            MyPicDiagram = value
            MyBmpDiagram = New Bitmap(MyPicDiagram.Width, MyPicDiagram.Height)
            MyPicDiagram.Image = MyBmpDiagram
            MyPicGraphics = New ClsGraphicTool(MyPicDiagram, MyParameterRange, MyValueParameter.Range)
            MyBmpGraphics = New ClsGraphicTool(MyBmpDiagram, MyParameterRange, MyValueParameter.Range)
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

    Property ValueRange As ClsInterval
        Get
            ValueRange = MyValueRange
        End Get
        Set(value As ClsInterval)
            MyValueRange = value
            If Not IsNothing(MyPicGraphics) Then
                'PicGraphics is existing and ValueParameter was changed
                MyPicGraphics.MathYInterval = MyValueRange
                MyBmpGraphics.MathYInterval = MyValueRange
            End If
        End Set
    End Property

    Property ValueParameter As ClsValueParameter
        Get
            ValueParameter = MyValueParameter
        End Get
        Set(value As ClsValueParameter)
            MyValueParameter = value
        End Set
    End Property

    WriteOnly Property Precision As Integer
        Set(value As Integer)
            MyPrecision = value
        End Set
    End Property

    WriteOnly Property TrbStartPosition As Integer
        Set(value As Integer)
            MyTrbStartPosition = value
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

    Public Sub DoIteration()

        'In the direction of the x-axis, we work with pixel coordinates
        Dim p As Integer

        For p = 1 To MyPicDiagram.Width

            'for each p, the according parametervalue a is calculated
            'and then, the iteration runs until RuntimeUntilCycle
            'finally, the iteration cycle is drawn
            IterationLoop(p)
        Next

        DrawSplitPoints()

    End Sub

    Private Sub IterationLoop(p As Integer)

        If MyIterationStatus = ClsDynamics.EnIterationStatus.Ready Then
            'Initialize

            ActualPair = New ClsValuePair(0, 0)
            CyclePoint = New ClsMathpoint(0, 0)

            'After that, the number of iterations must be big enough before drawing the cycle
            LengthOfCycle = CInt(MyPicDiagram.Height * MyValueParameter.Range.IntervalWidth _
                * MyTrbStartPosition / 25 / Math.Max(MyValueParameter.Range.IntervalWidth, 0.01))

            '..but not bigger than the y-axis allows
            LengthOfCycle = Math.Min(LengthOfCycle, 5 * MyPicDiagram.Height)
        End If

        MyIterationStatus = ClsDynamics.EnIterationStatus.Running

        'Calculate the parameter C for the iteration depending on p
        MyDS.C = MyParameterRange.A + (MyParameterRange.IntervalWidth * p / MyPicDiagram.Width)

        ActualBilliardBall.A = MyDS.A
        ActualBilliardBall.B = MyDS.B

        'Setting the Start-Parameterpair for the Iteration

        With ActualPair
            'The Startpoint has to be the same for all Values of C to avoid side effects
            .X = MyDS.ValueParameters.Item(0).Range.A +
                MyDS.ValueParameters.Item(0).Range.IntervalWidth / 3

            '.. and the second value depending on TrbPositionStartValues
            .Y = MyDS.ValueParameters.Item(1).Range.A +
                    MyTrbStartPosition * MyDS.ValueParameters.Item(1).Range.IntervalWidth / 120
        End With

        'the cycle is drawn

        CyclePoint.X = MyDS.C

        For n = 0 To LengthOfCycle

            Select Case MyValueParameter.ID
                Case 1
                    CyclePoint.Y = ActualPair.X
                Case Else
                    CyclePoint.Y = ActualPair.Y
            End Select

            MyBmpGraphics.DrawPoint(CyclePoint, Brushes.Blue, 1)

            NextPair = ActualBilliardBall.GetNextValuePair(ActualPair)
            ActualPair.X = NextPair.X
            ActualPair.Y = NextPair.Y

        Next

        MyPicDiagram.Refresh()

    End Sub

    Public Sub DrawSplitPoints()

        'Draw the C = 1 Line
        Dim A As New ClsMathpoint(1, 0)
        Dim B As New ClsMathpoint(1, MyPicDiagram.Height)
        MyBmpGraphics.DrawLine(A, B, Color.Red, 1)
        MyPicDiagram.Refresh()

    End Sub

    Public Sub ResetIteration()

        MyBmpGraphics.Clear(Color.White)
        MyPicDiagram.Refresh()

        MyIterationStatus = ClsDynamics.EnIterationStatus.Stopped

    End Sub

End Class

