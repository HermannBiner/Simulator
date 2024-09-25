'This is the abstract class for all kind of Julia Sets
'containing the common logic for all these classes

'Status Checked

Public MustInherit Class ClsJuliaAbstract
    Implements IJulia

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

    'Controlling the Iteration Loop
    Protected Property MyTxtNumberofSteps As TextBox
    Protected Property MyTxtElapsedTime As TextBox

    'Parameters for the Iteration

    Protected Property MyIterationStatus As ClsDynamics.EnIterationStatus

    'Number of examinated points in the complex plane
    Protected ExaminatedPoints As Integer

    'Coordinates of the pixel with the startvalue
    Protected p As Integer
    Protected q As Integer
    Protected PixelPoint As Point

    'Length of a branche of the spiral
    'see Sub IterationLoop
    Protected L As Integer = 0

    'Sig = 1 if n odd, = -1 else
    Protected Sig As Integer

    'Parameter k = 1...L
    Protected k As Integer

    'Number of iteration steps per pixelpoint
    Protected Steps As Integer
    Protected Watch As Stopwatch

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

        Watch = New Stopwatch
    End Sub

    'SECTOR INTERFACE

    WriteOnly Property PicDiagram As PictureBox Implements IJulia.PicDiagram
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

    Property IterationStatus As ClsDynamics.EnIterationStatus Implements IJulia.IterationStatus
        Get
            IterationStatus = MyIterationStatus
        End Get
        Set(value As ClsDynamics.EnIterationStatus)
            MyIterationStatus = value
        End Set
    End Property

    WriteOnly Property TxtNumberofSteps As TextBox Implements IJulia.TxtNumberOfSteps
        Set(value As TextBox)
            MyTxtNumberofSteps = value
        End Set
    End Property

    WriteOnly Property TxtElapsedTime As TextBox Implements IJulia.TxtElapsedTime
        Set(value As TextBox)
            MyTxtElapsedTime = value
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


        MyTxtNumberofSteps.Text = "0"
        MyTxtElapsedTime.Text = "0"
        L = 0
        Watch.Reset()
        ExaminatedPoints = 0

        'Clear Protocol
        If MyProtocolList IsNot Nothing Then
            MyProtocolList.Items.Clear()
        End If

        MyPicDiagram.Refresh()

        MyIterationStatus = ClsDynamics.EnIterationStatus.Stopped

    End Sub

    Public Async Function GenerateImage() As Task Implements IJulia.GenerateImage

        'This algorithm goes through the CPlane in a spiral starting in the midpoint
        If ExaminatedPoints = 0 Then
            p = CInt(MyPicDiagram.Width / 2)
            q = CInt(MyPicDiagram.Height / 2)

            PixelPoint = New Point

            With PixelPoint
                .X = p
                .Y = q
            End With

            IterationStep(PixelPoint)

            Steps = 1
            Watch.Start()

        End If


        Do
            ExaminatedPoints += 1

            IterationLoop()


            If p >= MyPicDiagram.Width Or q >= MyPicDiagram.Height Then

                MyIterationStatus = ClsDynamics.EnIterationStatus.Stopped
                Watch.Stop()
                MyPicDiagram.Refresh()

            End If

            If ExaminatedPoints Mod 100 = 0 Then
                MyTxtNumberofSteps.Text = Steps.ToString
                MyTxtElapsedTime.Text = Watch.Elapsed.ToString
                Await Task.Delay(1)
            End If

        Loop Until MyIterationStatus = ClsDynamics.EnIterationStatus.Interrupted _
            Or MyIterationStatus = ClsDynamics.EnIterationStatus.Stopped

    End Function

    Private Sub IterationLoop()

        If ExaminatedPoints Mod 2 = 0 Then
            Sig = -1
        Else
            Sig = 1
        End If

        L += 1

        k = 1
        Do While k < L
            p += Sig
            With PixelPoint
                .X = p
                .Y = q
            End With

            'Calculates the color of the PixelPoint
            'and draws it to MapCPlane
            IterationStep(PixelPoint)

            If Steps Mod 10000 = 0 Then
                MyPicDiagram.Refresh()
            End If

            Steps += 1
            k += 1
        Loop

        k = 1

        Do While k < L
            q += Sig

            With PixelPoint
                .X = p
                .Y = q
            End With

            'Calculates the color of the PixelPoint
            'and draws it to MapCPlane
            IterationStep(PixelPoint)

            If Steps Mod 10000 = 0 Then
                MyPicDiagram.Refresh()
            End If

            Steps += 1
            k += 1
        Loop

    End Sub

    'Public MustOverride Property IsSampelList As Boolean Implements IJulia.IsSampleList

    Public MustOverride Sub IterationStep(PicelPoint As Point)


End Class
