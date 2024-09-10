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
    Protected MyMathValueRange As New ClsInterval(-1, 1)
    Protected MyValueParameters As List(Of ClsValueParameter)
    Protected MyTValueRange As ClsInterval
    Protected MyAlfaValueRange As ClsInterval
    Protected MyParameterRange As New ClsInterval(CDec(0.5), 2)

    'Control of all BilliardBalls

    'Moving BilliardBalls
    Private Billiardball As IBilliardball
    Private MyBilliardballCollection As List(Of IBilliardball)

    'Status of the Iteration
    'Number of Steps
    Private n As Integer
    Private MyLblN As Label

    'Iteration Control
    Private MyIterationStatus As ClsGeneral.EnIterationStatus

    Public Sub New()
        MyBilliardballCollection = New List(Of IBilliardball)
    End Sub

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

    ReadOnly Property MathValueRange As ClsInterval
        Get
            MathValueRange = MyMathValueRange
        End Get
    End Property

    ReadOnly Property ValueParameters As List(Of ClsValueParameter) Implements IBilliardTable.ValueParameters
        Get
            ValueParameters = MyValueParameters
        End Get
    End Property

    ReadOnly Property TValueRange As ClsInterval Implements IBilliardTable.TValueRange
        Get
            TValueRange = MyTValueRange
        End Get
    End Property

    ReadOnly Property AlfaValueRange As ClsInterval Implements IBilliardTable.AlfaValueRange
        Get
            AlfaValueRange = MyAlfaValueRange
        End Get
    End Property

    ReadOnly Property ParameterRange As ClsInterval Implements IBilliardTable.ParameterRange
        Get
            ParameterRange = MyParameterRange
        End Get
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
            MyPicGraphics = New ClsGraphicTool(MyPicDiagram, MyMathValueRange, MyMathValueRange)
            MyBmpDiagram = New Bitmap(PicDiagramSize, PicDiagramSize)
            MyPicDiagram.Image = MyBmpDiagram
            MyBmpGraphics = New ClsGraphicTool(MyBmpDiagram, MyMathValueRange, MyMathValueRange)
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

    Property IterationStatus As ClsGeneral.EnIterationStatus Implements IBilliardTable.IterationStatus
        Get
            IterationStatus = MyIterationStatus
        End Get
        Set(value As ClsGeneral.EnIterationStatus)
            MyIterationStatus = value
        End Set
    End Property

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

        MyIterationStatus = ClsGeneral.EnIterationStatus.Stopped

    End Sub

    Public Sub IterationStep() Implements IBilliardTable.IterationStep

        n += 1
        MyLblN.Text = n.ToString(CultureInfo.CurrentCulture)

        'Each Ball is now iterated 1x
        For Each Ball As IBilliardball In BilliardBallCollection
            Ball.IterationStep()
        Next

    End Sub

    Public Async Function IterationLoop() As Task Implements IBilliardTable.IterationLoop

        Do
            IterationStep()

            If n Mod 2 = 0 Then
                Application.DoEvents()
                Await Task.Delay(2)
            End If

        Loop Until MyIterationStatus = ClsGeneral.EnIterationStatus.Interrupted

    End Function

    Public Sub PrepareBallsForPhaseportrait() Implements IBilliardTable.PrepareBallsForPhaseportrait

        'Generate Balls with startposition (0,b)
        'that is the zenith of the billardtable
        'and different startangles

        Dim NumberOfBalls As Integer = 30
        Dim i As Integer

        'Startparameter
        Dim t As Decimal
        Dim Alfa As Decimal

        Dim LocBilliardBall As IBilliardball
        'First Billardball to prepare general parameters
        LocBilliardBall = GetBilliardBall()
        C = MyC

        'the next start parameters are chosen that the phaseportrait gets a nice image
        Select Case True
            Case TypeOf LocBilliardBall Is ClsEllipseBilliardball
                t = CDec(Math.PI / 2)
                Alfa = CDec(0.001)
            Case TypeOf LocBilliardBall Is ClsOvalBilliardball
                t = CDec(Math.PI / 2)
                Alfa = CDec(Math.PI / NumberOfBalls)
            Case Else
                t = CDec(0.95) / (1 + MyC)
                Alfa = CDec(Math.PI / NumberOfBalls)
        End Select

        For i = 0 To NumberOfBalls
            LocBilliardBall = GetBilliardBall()
            Alfa += CDec(Math.PI / NumberOfBalls)
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
