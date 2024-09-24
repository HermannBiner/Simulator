'This is the abstract class for all kind of Billiardtables

Imports System.Globalization

Public MustInherit Class ClsBilliardTableAbstract
    Implements IBilliardTable

    'PicDiagram
    Protected MyPicDiagram As PictureBox
    Protected MyPicGraphics As ClsGraphicTool
    Protected MyBmpDiagram As Bitmap
    Protected MyBmpGraphics As ClsGraphicTool
    Protected MyPhasePortrait As PictureBox
    Protected MyValueProtocol As ListBox

    'Profile of the BilliardTable
    Protected MyA As Decimal
    Protected MyB As Decimal

    'Parameter C 
    Protected MyC As Decimal

    'Ranges
    Protected MyMathInterval As New ClsInterval(-1, 1)
    Protected MyTValueParameter As ClsGeneralParameter
    Protected MyAlfaValueParameter As ClsGeneralParameter
    Protected MyFormulaParameter As ClsGeneralParameter

    'The whole List of ValueParameters
    Protected MyValueParameterList As List(Of ClsGeneralParameter)

    'Control of all BilliardBalls

    'Moving BilliardBalls
    Private Billiardball As IBilliardball
    Private MyBilliardballCollection As List(Of IBilliardball)

    'Status of the Iteration
    'Number of Steps
    Private n As Integer
    Private MyLblN As Label

    'Iteration Control
    Private MyIterationStatus As ClsDynamics.EnIterationStatus

    'When distributing BilliardBalls for the full PhasePortrait
    Protected Const NumberOfBilliardBalls As Integer = 30

    ReadOnly Property MathInterval As ClsInterval Implements IBilliardTable.MathInterval
        Get
            MathInterval = MyMathInterval
        End Get
    End Property

    ReadOnly Property TValueParameter As ClsGeneralParameter Implements IBilliardTable.TValueParameter
        Get
            TValueParameter = MyTValueParameter
        End Get
    End Property

    ReadOnly Property AlfaValueParameterr As ClsGeneralParameter Implements IBilliardTable.AlfaValueParameter
        Get
            AlfaValueParameterr = MyAlfaValueParameter
        End Get
    End Property

    ReadOnly Property FormulaParameter As ClsGeneralParameter Implements IBilliardTable.FormulaParameter
        Get
            FormulaParameter = MyFormulaParameter
        End Get
    End Property

    ReadOnly Property ValueParameterList As List(Of ClsGeneralParameter) Implements IBilliardTable.ValueParameterList
        Get
            ValueParameterList = MyValueParameterList
        End Get
    End Property

    ReadOnly Property BilliardBallCollection As List(Of IBilliardball) _
        Implements IBilliardTable.BilliardBallCollection
        Get
            BilliardBallCollection = MyBilliardballCollection
        End Get
    End Property

    ReadOnly Property A As Decimal Implements IBilliardTable.A
        Get
            A = MyA
        End Get
    End Property

    ReadOnly Property B As Decimal Implements IBilliardTable.B
        Get
            B = MyB
        End Get
    End Property

    WriteOnly Property LblN As Label Implements IBilliardTable.LblN
        Set(value As Label)
            MyLblN = value
        End Set
    End Property

    Property PicDiagram As PictureBox Implements IBilliardTable.PicDiagram
        Get
            PicDiagram = MyPicDiagram
        End Get
        Set(value As PictureBox)
            MyPicDiagram = value
            Dim PicDiagramSize As Integer = Math.Min(MyPicDiagram.Width, MyPicDiagram.Height)
            MyPicDiagram.Width = PicDiagramSize
            MyPicDiagram.Height = PicDiagramSize
            MyPicGraphics = New ClsGraphicTool(MyPicDiagram, MyMathInterval, MyMathInterval)
            MyBmpDiagram = New Bitmap(PicDiagramSize, PicDiagramSize)
            MyPicDiagram.Image = MyBmpDiagram
            MyBmpGraphics = New ClsGraphicTool(MyBmpDiagram, MyMathInterval, MyMathInterval)
        End Set
    End Property

    ReadOnly Property PicGraphics As ClsGraphicTool
        Get
            PicGraphics = MyPicGraphics
        End Get
    End Property

    ReadOnly Property BmpDiagram As Bitmap
        Get
            BmpDiagram = MyBmpDiagram
        End Get
    End Property

    ReadOnly Property BmpGraphics As ClsGraphicTool
        Get
            BmpGraphics = MyBmpGraphics
        End Get
    End Property

    WriteOnly Property PhasePortrait As PictureBox Implements IBilliardTable.PhasePortrait
        Set(value As PictureBox)
            MyPhasePortrait = value
        End Set
    End Property

    WriteOnly Property ValueProtocol As ListBox Implements IBilliardTable.ValueProtocol
        Set(value As ListBox)
            MyValueProtocol = value
        End Set
    End Property

    Property IterationStatus As ClsDynamics.EnIterationStatus Implements IBilliardTable.IterationStatus
        Get
            IterationStatus = MyIterationStatus
        End Get
        Set(value As ClsDynamics.EnIterationStatus)
            MyIterationStatus = value
        End Set
    End Property

    Public Sub New()
        MyBilliardballCollection = New List(Of IBilliardball)

        'The FormulaParameter is the same for all Billiaard Tables
        MyFormulaParameter = New ClsGeneralParameter(3, "Parameter C", New ClsInterval(CDec(0.5), 2), ClsGeneralParameter.TypeOfParameterEnum.Formula)

        MyValueParameterList = New List(Of ClsGeneralParameter)

    End Sub

    Public Sub ResetIteration() Implements IBilliardTable.ResetIteration

        If BilliardBallCollection IsNot Nothing Then
            For Each Billiardball In BilliardBallCollection
                Billiardball = Nothing
            Next
            BilliardBallCollection.Clear()
        End If

        n = 0
        MyLblN.Text = "0"

        MyBmpGraphics.Clear(Color.White)
        MyPicDiagram.Refresh()

        MyIterationStatus = ClsDynamics.EnIterationStatus.Stopped

    End Sub

    Public Async Function IterationLoop(NumberOfSteps As Integer) As Task Implements IBilliardTable.IterationLoop

        Do
            n += 1
            MyLblN.Text = n.ToString(CultureInfo.CurrentCulture)

            'Each Ball is now iterated 1x
            For Each Ball As IBilliardball In BilliardBallCollection
                Ball.IterationStep()
            Next

            Application.DoEvents()
            Await Task.Delay(2)

            If NumberOfSteps > 0 Then
                If n >= NumberOfSteps Then
                    MyIterationStatus = ClsDynamics.EnIterationStatus.Stopped
                End If
            End If

        Loop Until MyIterationStatus = ClsDynamics.EnIterationStatus.Interrupted _
            Or MyIterationStatus = ClsDynamics.EnIterationStatus.Stopped

    End Function

    Public Sub PrepareBallsForPhaseportrait() Implements IBilliardTable.PrepareBallsForPhaseportrait

        'Generate Balls with startposition (0,b)
        'that is the zenith of the billardtable
        'and different startangles

        Dim i As Integer

        'Startparameter
        Dim t As Decimal
        Dim Alfa As Decimal

        Dim LocBilliardBall As IBilliardball
        'First Billardball to prepare general parameters
        LocBilliardBall = GetBilliardBall()
        C = MyC

        'the next start parameters are chosen that the phaseportrait gets a nice image
        If C < 1 Then
            t = CDec(Math.PI / 2)
        Else
            t = 0
        End If

        Alfa = AlfaValueParameterr.DefaultValue

        With LocBilliardBall
            .BallColor = Brushes.Blue
            .Startparameter = t
            .IsStartpositionSet = True
            .Startangle = Alfa
            .IsStartangleSet = True
            .BallSpeed = 1000
            .IterationStep()
        End With

        For i = 0 To NumberOfBilliardBalls
            LocBilliardBall = GetBilliardBall()
            Alfa += CDec(Math.PI / NumberOfBilliardBalls)
            If Alfa < Math.PI Then
                With LocBilliardBall
                    Select Case i Mod 5
                        Case 1
                            .BallColor = Brushes.Red
                        Case 2
                            .BallColor = Brushes.Green
                        Case 3
                            .BallColor = Brushes.Blue
                        Case 4
                            .BallColor = Brushes.Black
                        Case Else
                            .BallColor = Brushes.Magenta
                    End Select

                    .BallSpeed = 10000
                    .PhasePortrait = MyPhasePortrait
                    'because of the performance, in thhis case
                    'no value protocol is generated
                    .ValueProtocol = Nothing
                    .Startparameter = t
                    .IsStartpositionSet = True
                    .Startangle = Alfa
                    .IsStartangleSet = True
                    .BallSpeed = 1000
                    .IterationStep()
                End With
                BilliardBallCollection.Add(LocBilliardBall)
            End If
        Next
    End Sub

    Public MustOverride Property C As Decimal Implements IBilliardTable.C

    Public MustOverride Sub DrawBilliardtable() Implements IBilliardTable.DrawBilliardtable

    Public MustOverride Function GetBilliardBall() As IBilliardball Implements IBilliardTable.GetBilliardBall

End Class
