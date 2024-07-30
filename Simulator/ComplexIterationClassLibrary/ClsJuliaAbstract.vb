'This is the abstract class for all kind of Julia Sets
'containing the common logic for all these classes

'Status Checked

Public MustInherit Class ClsJuliaAbstract
    Implements IJulia

    'Drawing MapCPlane
    Protected MyMapCPlane As Bitmap
    Protected MyMapCPlaneGraphics As ClsGraphicTool

    'Drawing PicCPlane
    Protected MyPicCPlane As PictureBox
    Protected MyPicCPlaneGraphics As ClsGraphicTool

    'Allowed Interval for the x-Values
    Protected MyAllowedXRange As ClsInterval

    'Allowed Interval for the y-Values
    Protected MyAllowedYRange As ClsInterval

    'the actual range for the x-coordinate
    Protected MyActualXRange As ClsInterval

    'the actual range for the y-coordinate
    Protected MyActualYRange As ClsInterval

    'Controlling the Iteration Loop
    Protected Property MyStopIteration As Boolean
    Protected Property MyTxtNumberofSteps As TextBox
    Protected Property MyTxtElapsedTime As TextBox

    'Parameters for the Iteration

    Protected Property MyIterationStatus As ClsGeneral.EnIterationStatus

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

    'Color Intensity
    Protected Property MyRedPercent As Double
    Protected Property MyGreenPercent As Double
    Protected Property MyBluePercent As Double

    'Use SystemColors
    Protected Property MyUseSystemColors As Boolean

    'Track
    Protected Property MyIsTrackImplemented As Boolean

    'Protocol
    Protected MyProtocolList As ListBox
    Protected MyIsProtocol As Boolean

    Public Sub New()

        Watch = New Stopwatch
    End Sub

    'SECTOR INTERFACE

    WriteOnly Property MapCPlane As Bitmap Implements IJulia.MapCPlane
        Set(value As Bitmap)
            MyMapCPlane = value
            MyMapCPlaneGraphics = New ClsGraphicTool(MyMapCPlane, MyActualXRange, MyActualYRange)
        End Set
    End Property

    WriteOnly Property PicCPlane As PictureBox Implements IJulia.PicCPlane
        Set(value As PictureBox)
            MyPicCPlane = value
            MyPicCPlaneGraphics = New ClsGraphicTool(MyPicCPlane, MyActualXRange, MyActualYRange)
        End Set
    End Property

    ReadOnly Property AllowedXRange As ClsInterval Implements IJulia.AllowedXRange
        Get
            AllowedXRange = MyAllowedXRange
        End Get
    End Property

    ReadOnly Property AllowedYRange As ClsInterval Implements IJulia.AllowedYRange
        Get
            AllowedYRange = MyAllowedYRange
        End Get
    End Property

    Property ActualXRange As ClsInterval Implements IJulia.ActualXRange
        Get
            ActualXRange = MyActualXRange
        End Get
        Set(value As ClsInterval)
            MyActualXRange = value
        End Set
    End Property

    Property ActualYRange As ClsInterval Implements IJulia.ActualYRange
        Get
            ActualYRange = MyActualYRange
        End Get
        Set(value As ClsInterval)
            MyActualYRange = value
        End Set
    End Property

    WriteOnly Property C As ClsComplexNumber Implements IJulia.C
        Set(value As ClsComplexNumber)
            MyC = value
        End Set
    End Property

    Property IterationStatus As ClsGeneral.EnIterationStatus Implements IJulia.IterationStatus
        Get
            IterationStatus = MyIterationStatus
        End Get
        Set(value As ClsGeneral.EnIterationStatus)
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

    WriteOnly Property UseSystemColors As Boolean Implements IJulia.UseSystemColors
        Set(value As Boolean)
            MyUseSystemColors = value
        End Set
    End Property

    ReadOnly Property IsTrackImplemented As Boolean Implements IJulia.IsTrackImplemented
        Get
            IsTrackImplemented = MyIsTrackImplemented
        End Get
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

        If ActualXRange.IsNumberInInterval(0) Then

            'Draw y-axis
            MyMapCPlaneGraphics.DrawLine(New ClsMathpoint(0, ActualYRange.A),
                                             New ClsMathpoint(0, ActualYRange.B), Color.Black, 1)
        End If

        If ActualYRange.IsNumberInInterval(0) Then

            'Draw x-axis
            MyMapCPlaneGraphics.DrawLine(New ClsMathpoint(ActualXRange.A, 0),
                                         New ClsMathpoint(ActualXRange.B, 0), Color.Black, 1)
        End If

    End Sub

    Public Sub Reset() Implements IJulia.Reset

        'Clear MapCPlane
        If MyMapCPlaneGraphics IsNot Nothing Then
            MyMapCPlaneGraphics.Clear(Color.White)
            DrawCoordinateSystem()
            L = 0
            Watch.Reset()
            ExaminatedPoints = 0
        End If

        'Clear Protocol
        If MyProtocolList IsNot Nothing Then
            MyProtocolList.Items.Clear()
        End If

    End Sub

    Public Function GenerateImage() As Task Implements IJulia.GenerateImage

        'This algorithm goes through the CPlane in a spiral starting in the midpoint
        'In case of Symmetry, only the lower halfplane is examinated
        If ExaminatedPoints = 0 Then
            p = CInt(MyPicCPlane.Width / 2)
            q = CInt(MyPicCPlane.Height / 2)

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


            If p >= MyPicCPlane.Width Or q >= MyPicCPlane.Height Then

                MyIterationStatus = ClsGeneral.EnIterationStatus.Stopped
                Watch.Stop()
                MyPicCPlane.Refresh()

            End If

            If ExaminatedPoints Mod 100 = 0 Then
                MyTxtNumberofSteps.Text = Steps.ToString
                MyTxtElapsedTime.Text = Watch.Elapsed.ToString
                Application.DoEvents()
                Task.Delay(2)
            End If

        Loop Until MyIterationStatus = ClsGeneral.EnIterationStatus.Interrupted _
            Or MyIterationStatus = ClsGeneral.EnIterationStatus.Stopped

        Return Task.CompletedTask

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
                MyPicCPlane.Refresh()
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
                MyPicCPlane.Refresh()
            End If

            Steps += 1
            k += 1
        Loop

    End Sub

    Public MustOverride Sub ShowCTrack() Implements IJulia.ShowCTrack

    Public MustOverride Sub IterationStep(PicelPoint As Point)

End Class
