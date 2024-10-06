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
    Protected MyDSParameter As ClsGeneralParameter

    'The whole List of ValueParameters
    Protected MyValueParameterList As List(Of ClsGeneralParameter)

    'Control of all BilliardBalls

    'Moving BilliardBalls
    Private Billiardball As IBilliardball
    Private MyBilliardballCollection As List(Of IBilliardball)

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

    ReadOnly Property AlfaValueParameter As ClsGeneralParameter Implements IBilliardTable.AlfaValueParameter
        Get
            AlfaValueParameter = MyAlfaValueParameter
        End Get
    End Property

    ReadOnly Property DSParameter As ClsGeneralParameter Implements IBilliardTable.DSParameter
        Get
            DSParameter = MyDSParameter
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

    Public Sub New()
        MyBilliardballCollection = New List(Of IBilliardball)

        'The DS Parameter is the same for all Billiard Tables
        MyDSParameter = New ClsGeneralParameter(3, "Parameter C", New ClsInterval(CDec(0.5), 2), ClsGeneralParameter.TypeOfParameterEnum.DS, CDec(0.8))

        MyValueParameterList = New List(Of ClsGeneralParameter)

    End Sub

    Public Sub ResetIteration() Implements IBilliardTable.ResetIteration

        If BilliardBallCollection IsNot Nothing Then
            For Each Billiardball In BilliardBallCollection
                Billiardball = Nothing
            Next
            BilliardBallCollection.Clear()
        End If

        MyBmpGraphics.Clear(Color.White)
        MyPicDiagram.Refresh()

    End Sub

    Public MustOverride Property C As Decimal Implements IBilliardTable.C

    Public MustOverride Sub DrawBilliardtable() Implements IBilliardTable.DrawBilliardtable

    Public MustOverride Function GetBilliardBall() As IBilliardball Implements IBilliardTable.GetBilliardBall

End Class
