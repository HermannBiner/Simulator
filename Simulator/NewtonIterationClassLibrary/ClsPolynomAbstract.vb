'This is the abstract class for all kind of polynom roots
'containing the common logic for all these classes
'all polynom classes inherit from this class
'including the UnitRootN classes

'Status Checked

Public MustInherit Class ClsPolynomAbstract
    Implements IPolynom

    'the radius where Zi is regarded as belonging to a root
    Protected MyRadius As Double

    'How many steps should be iterated?
    Protected MyIterationDeepness As Integer

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

    'Protocol
    Protected MyProtocolList As ListBox
    Protected MyIsProtocol As Boolean

    'N (number of roots)
    Protected Property MyUseN As Boolean
    Protected Property MyN As Integer

    'Parameter C
    Protected Property MyUseC As Boolean
    Protected Property MyC As ClsComplexNumber

    'Mixing
    Protected Property MyMixing As IPolynom.EnMixing

    'Color
    Protected Property MyColor As IPolynom.EnColor

    'List of roots of the polynom
    Protected Roots As Collection

    Public Sub New()
        Roots = New Collection
        Watch = New Stopwatch
    End Sub

    'SECTOR INTERFACE

    WriteOnly Property MapCPlane As Bitmap Implements IPolynom.MapCPlane
        Set(value As Bitmap)
            MyMapCPlane = value
            MyMapCPlaneGraphics = New ClsGraphicTool(MyMapCPlane, MyActualXRange, MyActualYRange)
        End Set
    End Property

    WriteOnly Property PicCPlane As PictureBox Implements IPolynom.PicCPlane
        Set(value As PictureBox)
            MyPicCPlane = value
            MyPicCPlaneGraphics = New ClsGraphicTool(MyPicCPlane, MyActualXRange, MyActualYRange)
        End Set
    End Property

    ReadOnly Property AllowedXRange As ClsInterval Implements IPolynom.AllowedXRange
        Get
            AllowedXRange = MyAllowedXRange
        End Get
    End Property

    ReadOnly Property AllowedYRange As ClsInterval Implements IPolynom.AllowedYRange
        Get
            AllowedYRange = MyAllowedYRange
        End Get
    End Property

    Property ActualXRange As ClsInterval Implements IPolynom.ActualXRange
        Get
            ActualXRange = MyActualXRange
        End Get
        Set(value As ClsInterval)
            MyActualXRange = value
        End Set
    End Property

    Property ActualYRange As ClsInterval Implements IPolynom.ActualYRange
        Get
            ActualYRange = MyActualYRange
        End Get
        Set(value As ClsInterval)
            MyActualYRange = value
        End Set
    End Property

    Property IterationStatus As ClsGeneral.EnIterationStatus Implements IPolynom.IterationStatus
        Get
            IterationStatus = MyIterationStatus
        End Get
        Set(value As ClsGeneral.EnIterationStatus)
            MyIterationStatus = value
        End Set
    End Property

    WriteOnly Property TxtNumberofSteps As TextBox Implements IPolynom.TxtNumberOfSteps
        Set(value As TextBox)
            MyTxtNumberofSteps = value
        End Set
    End Property

    WriteOnly Property TxtElapsedTime As TextBox Implements IPolynom.TxtElapsedTime
        Set(value As TextBox)
            MyTxtElapsedTime = value
        End Set
    End Property

    WriteOnly Property ProcotolList As ListBox Implements IPolynom.ProcotolList
        Set(value As ListBox)
            MyProtocolList = value
        End Set
    End Property

    WriteOnly Property IsProtocol As Boolean Implements IPolynom.IsProtocol
        Set(value As Boolean)
            MyIsProtocol = value
        End Set
    End Property

    ReadOnly Property UseN As Boolean Implements IPolynom.UseN
        Get
            UseN = MyUseN
        End Get
    End Property

    WriteOnly Property N As Integer Implements IPolynom.N
        Set(value As Integer)
            MyN = value
            MyRadius = Math.Min(0.1, 1 - Math.Pow(2, -1 / MyN))
        End Set
    End Property

    ReadOnly Property UseC As Boolean Implements IPolynom.UseC
        Get
            UseC = MyUseC
        End Get
    End Property

    WriteOnly Property C As ClsComplexNumber Implements IPolynom.C
        Set(value As ClsComplexNumber)
            MyC = value
        End Set
    End Property

    WriteOnly Property UseMixing As IPolynom.EnMixing Implements IPolynom.UseMixing
        Set(value As IPolynom.EnMixing)
            MyMixing = value
        End Set
    End Property

    WriteOnly Property UseColor As IPolynom.EnColor Implements IPolynom.UseColor
        Set(value As IPolynom.EnColor)
            MyColor = value
        End Set
    End Property

    Public Sub DrawCoordinateSystem() Implements IPolynom.DrawCoordinateSystem

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

    Public Sub Reset() Implements IPolynom.Reset

        'Clear MapCPlane
        If MyMapCPlaneGraphics IsNot Nothing Then
            MyMapCPlaneGraphics.Clear(Color.White)
            DrawCoordinateSystem()
            DrawRoots(False)
            L = 0
            Watch.Reset()
            ExaminatedPoints = 0
        End If

        'Clear Protocol
        If MyProtocolList IsNot Nothing Then
            MyProtocolList.Items.Clear()
        End If
    End Sub


    'Draws roots of the polynom
    Public Sub DrawRoots(Finished As Boolean) Implements IPolynom.DrawRoots

        'Roots
        Dim Col As Brush

        'Finished = PicCPlane is generated

        For Each MyRoot As ClsRoot In Roots
            If Finished Then
                Col = Brushes.Black
            Else
                Col = MyRoot.GetColor(0)
            End If
            MyMapCPlaneGraphics.DrawPoint(New ClsMathpoint(CDec(MyRoot.X), CDec(MyRoot.Y)), Col, 3)
        Next

    End Sub

    Private Function GetBasin(Z As ClsComplexNumber, Steps As Integer) As Brush

        'If the stop condition is fullfilled, then the startpoint converges to a root
        'and we have to find out, which root that is
        'and get the appropriate color

        Dim Temp As Double = 1000
        Dim Difference As Double
        Dim RootBrush As Brush = Brushes.Black

        Dim FinalBrightness As Double

        If MyColor = IPolynom.EnColor.Bright Then
            FinalBrightness = 1
        Else

            Dim MyColorDeepness As Integer
            'The next value is set after experiments:
            'MyN = 3 and MyColorDeepness = 30
            'MyN = 4 and ColorDeepness = 50
            'MyN = 5 and ColorDeepness = 80
            'MyN = 6 and ColorDeepness = 120
            '...
            'The Formula that delivers these values is
            'y = 5*x^2 - 15 x + 30

            If MyN = 2 Then
                MyColorDeepness = 30
            Else
                MyColorDeepness = 5 * MyN * MyN - 15 * MyN + 30
            End If

            FinalBrightness = (1 - Steps / MyColorDeepness) * 1.1

            'but the maximum is 1
            FinalBrightness = Math.Min(FinalBrightness, 1)
        End If


        For Each Root As ClsRoot In Roots
            Difference = Z.Add(Root.Stretch(-1)).AbsoluteValue
            If Difference < Temp Then
                Temp = Difference
                RootBrush = Root.GetColor(FinalBrightness)
            End If
        Next

        Return RootBrush

    End Function

    Public Function GenerateImage() As Task Implements IPolynom.GenerateImage

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

    Public Sub IterationStep(Startpoint As Point)

        'Transform the PixelPoint to a Complex Number
        Dim MathStartpoint As ClsComplexNumber

        With MyMapCPlaneGraphics.PixelToMathpoint(Startpoint)
            'Saved for debugging
            MathStartpoint = New ClsComplexNumber(.X, .Y)
        End With

        Dim Zi As New ClsComplexNumber(MathStartpoint.X, MathStartpoint.Y)

        Dim MyBrush As Brush = Brushes.White

        If Zi.AbsoluteValue > 0 Then

            'Protocol of the startpoint as Pixel and as Mathpoint
            'MyProtocol.Items.Add(Startpoint.X.ToString & ", " & Startpoint.Y.ToString & ", " &
            'Zi.X.ToString("N5") & ", " & Zi.Y.ToString("N5"))

            Dim i As Integer = 1


            Do While i <= MyIterationDeepness And Not StopCondition(Zi)

                i += 1

                'Calculate Next Z
                Zi = Newton(Zi)

            Loop

            If (i > MyIterationDeepness) Or (Denominator(Zi).AbsoluteValue = 0) Then

                'the point doesn't converge to a root
                MyBrush = Brushes.Black
            Else
                'the basin defines the type of color
                'and i influences its brightness
                MyBrush = GetBasin(Zi, i)
            End If
        Else

            MyBrush = Brushes.Black
        End If

        MyMapCPlaneGraphics.DrawPoint(Startpoint, MyBrush, 1)

        'Protocol of the PixelStartpoint and the Endpoint as Mathpoint
        If MyIsProtocol Then
            MyProtocolList.Items.Add(MathStartpoint.X.ToString("N5") & ", " & MathStartpoint.Y.ToString("N5") &
                ", " & Zi.X.ToString("N5") & ", " & Zi.Y.ToString("N5"))
        End If
    End Sub

    Public MustOverride Function StopCondition(Z As ClsComplexNumber) As Boolean

    Public MustOverride Function Newton(Z As ClsComplexNumber) As ClsComplexNumber

    Protected MustOverride Sub PrepareIteration() Implements IPolynom.PrepareIteration

    Public MustOverride Function Denominator(Z As ClsComplexNumber) As ClsComplexNumber

End Class


