'This is the controller for FrmMandelbrotMap

'Status

Public Class ClsMandelbrotMapController

    'Global variables
    Private ReadOnly MyForm As FrmMandelbrotMap
    Private PicMandelbrotGraphics As ClsGraphicTool

    Private ReadOnly LM As ClsLanguageManager

    Private DSJulia As IJulia
    Private DSMandelbrot As IJulia

    'Every picture has its own spiral (see DrawPicture)
    'The Mandelbrot set is drawn first, then the Julia set

    'Increases with every new drawing; an older drawing that is still running stops
    Private Generation As Integer

    'True while a picture is drawn
    Private IsRunning As Boolean

    'True if the Mandelbrot set is completely drawn
    Private IsMandelbrotDrawn As Boolean

    'Mouse Event
    Private IsMouseDown As Boolean
    Private MouseMathPoint As ClsMathpoint

    'SECTOR INITIALIZATION

    Public Sub New(Form As FrmMandelbrotMap)
        MyForm = Form
        LM = ClsLanguageManager.LM

    End Sub

    Public Sub SetDS()
        DSJulia = New ClsJuliaPN
        DSMandelbrot = New ClsMandelbrot
        InitializeMe()
        SetDefaultUserData()

    End Sub

    Public Sub InitializeMe()

        'a running drawing stops
        Generation += 1
        IsRunning = False
        IsMandelbrotDrawn = False

        'Prepare MandelbrotSet
        With DSMandelbrot
            .PicDiagram = MyForm.PicMandelbrot
            .N = 2
            .ActualXRange = .XValueParameter.Range
            .ActualYRange = .YValueParameter.Range
            .IsUseSystemColors = True
            .IsProtocol = False
            PicMandelbrotGraphics = New ClsGraphicTool(MyForm.PicMandelbrot, .XValueParameter.Range,
                    .YValueParameter.Range)
        End With

        MouseMathPoint = New ClsMathpoint(0, 0)

        'Prepare JuliaSet
        With DSJulia
            .PicDiagram = MyForm.PicJulia
            .N = 2
            .ActualXRange = .XValueParameter.Range
            .ActualYRange = .YValueParameter.Range
            .IsUseSystemColors = True
            .IsProtocol = False
        End With

        IsMouseDown = False

    End Sub

    Public Sub SetDefaultUserData()

        'These are the parameters for the Seahorse
        With MyForm
            .TxtA.Text = CDbl(0.32).ToString
            .TxtB.Text = CDbl(0.043).ToString
        End With

        DrawPictures()

    End Sub

    'SECTOR ITERATION

    Private Async Sub DrawPictures()

        'a drawing that is still running stops
        Generation += 1
        Dim MyGeneration As Integer = Generation

        If Not IsCParameterOK() Then
            'Message already generated
            IsRunning = False
            MyForm.Cursor = Cursors.Arrow
            Exit Sub
        End If

        Dim C As New ClsComplexNumber(CDbl(MyForm.TxtA.Text), CDbl(MyForm.TxtB.Text))

        IsRunning = True
        MyForm.Cursor = Cursors.WaitCursor

        'First the Mandelbrot set, if it is not yet drawn
        If Not IsMandelbrotDrawn Then
            DSMandelbrot.C = C
            DSMandelbrot.ResetIteration()
            If Not Await DrawPicture(DSMandelbrot, MyGeneration) Then
                Exit Sub
            End If
            IsMandelbrotDrawn = True
        End If

        'Then the Julia set
        DSJulia.C = C
        DSJulia.ResetIteration()
        If Not Await DrawPicture(DSJulia, MyGeneration) Then
            Exit Sub
        End If

        IsRunning = False
        MyForm.Cursor = Cursors.Arrow

    End Sub

    'Draws the picture of MyDS in a spiral starting in the midpoint
    'Returns False if a newer drawing has started meanwhile
    Private Async Function DrawPicture(MyDS As IJulia, MyGeneration As Integer) As Task(Of Boolean)

        Dim Spiral As New ClsSpiralScan(MyDS.PicDiagram.Width, MyDS.PicDiagram.Height)
        Dim PixelPoint As Point
        Dim Count As Integer = 0

        Do While Spiral.NextPixel(PixelPoint)

            If MyGeneration <> Generation Then
                Return False
            End If

            'Calculates the color of the PixelPoint
            'and draws it to MapCPlane
            MyDS.IterationStep(PixelPoint)
            Count += 1

            If Count Mod 1000 = 0 Then
                MyDS.PicDiagram.Refresh()
                Await Task.Delay(1)
            End If
        Loop

        MyDS.PicDiagram.Refresh()
        Return MyGeneration = Generation

    End Function

    'SECTOR SET STARTPARAMETER

    Public Sub MouseDown(e As MouseEventArgs)

        If Not IsRunning Then

            MyForm.Cursor = Cursors.Hand
            IsMouseDown = True

            'Now, Moving the Mouse moves the pendulum as well
            MouseMove(e)
        End If
    End Sub

    Public Sub MouseMove(e As MouseEventArgs)

        If IsMouseDown Then
            Dim Mouseposition As New Point With {
            .X = e.X,
            .Y = e.Y
        }

            'Set Parameter C
            MouseMathPoint = PicMandelbrotGraphics.PixelToMathpoint(Mouseposition)
            With MyForm
                .TxtA.Text = MouseMathPoint.X.ToString
                .TxtB.Text = MouseMathPoint.Y.ToString
            End With

        End If
    End Sub

    Public Sub MouseUp(e As MouseEventArgs)
        'Has only an effect, if the Mouse was down
        If IsMouseDown Then

            'The Mouse gets its normal behaviour again
            MyForm.Cursor = Cursors.Arrow
            IsMouseDown = False

            'The JuliaSet is generated with the new parameter C
            DrawPictures()
        End If
    End Sub

    'SECTOR CHECK USERDATA

    Private Function IsCParameterOK() As Boolean
        With MyForm
            'The parameter c has to be in the same area as the z-Values
            'for the MandelbrotMap, the Interval is a little bigger
            Dim CheckParameterA As New ClsCheckUserData(.TxtA, New ClsInterval(CDbl(-1.9), CDbl(1.9)))
            Dim CheckParameterB As New ClsCheckUserData(.TxtB, New ClsInterval(CDbl(-1.9), CDbl(1.9)))

            Return CheckParameterA.IsTxtValueAllowed And CheckParameterB.IsTxtValueAllowed
        End With
    End Function

End Class
