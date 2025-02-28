'This is the abstract class for all kind of Julia Sets
'containing the common logic for all these classes

'Status Checked

Public MustInherit Class ClsJuliaAbstract
    Implements IJulia

    Protected ReadOnly LM As ClsLanguageManager

    'Drawing PicCPlane
    Protected MyPicDiagram As PictureBox
    Protected PicGraphics As ClsGraphicTool

    'Drawing MapCPlane
    Protected BmpDiagram As Bitmap
    Protected BmpGraphics As ClsGraphicTool

    'ValueParameter Definition for the x-Values
    Protected MyXValueParameter As ClsGeneralParameter

    'ValueParameter Definition  for the y-Values
    Protected MyYValueParameter As ClsGeneralParameter

    'the actual range for the x-coordinate
    Protected MyActualXRange As ClsInterval

    'the actual range for the y-coordinate
    Protected MyActualYRange As ClsInterval

    'Parameter C
    Protected Property MyC As ClsComplexNumber

    'Power of z
    Protected MustOverride WriteOnly Property N As Integer Implements IJulia.N

    Protected MustOverride ReadOnly Property IsMandelbrot As Boolean Implements IJulia.IsMandelbrot

    'Color Intensity
    Protected Property MyRedPercent As Double
    Protected Property MyGreenPercent As Double
    Protected Property MyBluePercent As Double

    'Use SystemColors
    Protected Property MyIsUseSystemColors As Boolean

    'Protocol
    Protected MyProtocolList As ListBox
    Protected MyIsProtocol As Boolean

    Public Sub New()

        LM = ClsLanguageManager.LM
    End Sub

    'SECTOR INTERFACE

    Property PicDiagram As PictureBox Implements IJulia.PicDiagram
        Get
            PicDiagram = MyPicDiagram
        End Get
        Set(value As PictureBox)
            MyPicDiagram = value
            PicGraphics = New ClsGraphicTool(MyPicDiagram, MyActualXRange, MyActualYRange)

            'The PictureBox should be a square
            Dim Square As Integer = Math.Min(MyPicDiagram.Height, MyPicDiagram.Width)

            MyPicDiagram.Height = Square
            MyPicDiagram.Width = Square

            BmpDiagram = New Bitmap(Square, Square)
            MyPicDiagram.Image = BmpDiagram

            PicGraphics = New ClsGraphicTool(MyPicDiagram, MyActualXRange, MyActualYRange)
            BmpGraphics = New ClsGraphicTool(BmpDiagram, MyActualXRange, MyActualYRange)
        End Set
    End Property

    ReadOnly Property XValueParameter As ClsGeneralParameter Implements IJulia.XValueParameter
        Get
            XValueParameter = MyXValueParameter
        End Get
    End Property

    ReadOnly Property YValueParameter As ClsGeneralParameter Implements IJulia.YValueParameter
        Get
            YValueParameter = MyYValueParameter
        End Get
    End Property

    Property ActualXRange As ClsInterval Implements IJulia.ActualXRange
        Get
            ActualXRange = MyActualXRange
        End Get
        Set(value As ClsInterval)
            MyActualXRange = value
            PicGraphics.MathXInterval = value
            BmpGraphics.MathXInterval = value
        End Set
    End Property

    Property ActualYRange As ClsInterval Implements IJulia.ActualYRange
        Get
            ActualYRange = MyActualYRange
        End Get
        Set(value As ClsInterval)
            MyActualYRange = value
            PicGraphics.MathYInterval = value
            BmpGraphics.MathYInterval = value
        End Set
    End Property

    WriteOnly Property C As ClsComplexNumber Implements IJulia.C
        Set(value As ClsComplexNumber)
            MyC = value
        End Set
    End Property

    WriteOnly Property RedPercent As Double Implements IJulia.RedPercent
        Set(value As Double)
            MyRedPercent = value
        End Set
    End Property

    WriteOnly Property GreenPercent As Double Implements IJulia.GreenPercent
        Set(value As Double)
            MyGreenPercent = value
        End Set
    End Property

    WriteOnly Property BluePercent As Double Implements IJulia.BluePercent
        Set(value As Double)
            MyBluePercent = value
        End Set
    End Property

    WriteOnly Property IsUseSystemColors As Boolean Implements IJulia.IsUseSystemColors
        Set(value As Boolean)
            MyIsUseSystemColors = value
        End Set
    End Property

    WriteOnly Property ProcotolList As ListBox Implements IJulia.ProcotolList
        Set(value As ListBox)
            MyProtocolList = value
        End Set
    End Property

    WriteOnly Property IsProtocol As Boolean Implements IJulia.IsProtocol
        Set(value As Boolean)
            MyIsProtocol = value
        End Set
    End Property

    Public Sub DrawCoordinateSystem() Implements IJulia.DrawCoordinateSystem

        If MyActualXRange.IsNumberInInterval(0) Then

            BmpGraphics.MathXInterval = MyActualXRange

            'Draw y-axis
            BmpGraphics.DrawLine(New ClsMathpoint(0, ActualYRange.A),
                                             New ClsMathpoint(0, ActualYRange.B), Color.Black, 1)
        End If

        If MyActualYRange.IsNumberInInterval(0) Then

            BmpGraphics.MathYInterval = MyActualYRange

            'Draw x-axis
            BmpGraphics.DrawLine(New ClsMathpoint(ActualXRange.A, 0),
                                         New ClsMathpoint(ActualXRange.B, 0), Color.Black, 1)
        End If

        MyPicDiagram.Refresh()

    End Sub

    Public Sub ResetIteration() Implements IJulia.ResetIteration

        'Clear MapCPlane

        BmpGraphics.Clear(Color.White)
        DrawCoordinateSystem()

        'Clear Protocol
        If MyProtocolList IsNot Nothing Then
            MyProtocolList.Items.Clear()
        End If

        MyPicDiagram.Refresh()

    End Sub

    Public MustOverride Sub IterationStep(PicelPoint As Point) Implements IJulia.IterationStep

End Class
