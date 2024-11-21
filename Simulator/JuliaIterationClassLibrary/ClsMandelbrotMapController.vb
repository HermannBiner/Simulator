'This is the controller for FrmMandelbrotMap

'Status

Public Class ClsMandelbrotMapController

    'Global variables
    Private MyForm As FrmMandelbrotMap
    Private PicMandelbrotGraphics As ClsGraphicTool

    Private LM As ClsLanguageManager

    Private DSJulia As IJulia
    Private DSMandelbrot As IJulia

    'Number of examinated points in the complex plane
    Private ExaminatedPoints As Integer

    'Coordinates of the pixel with the startvalue
    Private p As Integer
    Private q As Integer
    Private PixelPoint As Point

    'Length of a branche of the spiral
    'see Sub IterationLoop
    Private L As Integer = 0

    'Sig = 1 if n odd, = -1 else
    Private Sig As Integer

    'Parameter k = 1...L
    Private k As Integer

    'Mouse Event
    Private IsMouseDown As Boolean
    Private MouseMathPoint As ClsMathpoint

    Private Property IterationStatus As ClsDynamics.EnIterationStatus

    'SECTOR INITIALIZE

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


    Private Sub InitializeMe()

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

        IterationStatus = ClsDynamics.EnIterationStatus.Stopped
        DSMandelbrot.ResetIteration()
        Startiteration(DSMandelbrot)

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
            .TxtA.Text = CDec(0.32).ToString
            .TxtB.Text = CDec(0.043).ToString
        End With

        IterationStatus = ClsDynamics.EnIterationStatus.Stopped
        ExaminatedPoints = 0
        L = 0

        DSJulia.ResetIteration()
        Startiteration(DSJulia)

    End Sub

    'SECTOR ITERATION

    Public Async Sub Startiteration(MyDS As IJulia)

        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then

            'the iteration was stopped or reset
            'and should start from the beginning
            If IsCParameterOK() Then

                With MyDS
                    .C = New ClsComplexNumber(CDbl(MyForm.TxtA.Text), CDbl(MyForm.TxtB.Text))
                End With

                MyDS.ResetIteration()

                IterationStatus = ClsDynamics.EnIterationStatus.Ready
            Else
                'Message already generated
            End If
        End If

        If IterationStatus = ClsDynamics.EnIterationStatus.Ready Then
            IterationStatus = ClsDynamics.EnIterationStatus.Running
            MyForm.Cursor = Cursors.WaitCursor

            Await PerformIteration(MyDS)

            IterationStatus = ClsDynamics.EnIterationStatus.Stopped
        End If

        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            MyForm.Cursor = Cursors.Arrow
        End If

    End Sub

    Private Async Function PerformIteration(MyDS As IJulia) As Task

        'This algorithm goes through the CPlane in a spiral starting in the midpoint
        If ExaminatedPoints = 0 Then
            p = CInt(MyDS.PicDiagram.Width / 2)
            q = CInt(MyDS.PicDiagram.Height / 2)

            PixelPoint = New Point

            With PixelPoint
                .X = p
                .Y = q
            End With

            MyDS.IterationStep(PixelPoint)
        End If

        Do
            ExaminatedPoints += 1

            IterationLoop(MyDS)

            If p >= MyForm.PicMandelbrot.Width Or q >= MyForm.PicMandelbrot.Height Then

                IterationStatus = ClsDynamics.EnIterationStatus.Stopped
                MyDS.PicDiagram.Refresh()

            End If

            If ExaminatedPoints Mod 1000 = 0 Then
                Await Task.Delay(1)
            End If

        Loop Until IterationStatus = ClsDynamics.EnIterationStatus.Stopped

    End Function

    Private Sub IterationLoop(MyDS As IJulia)

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
            MyDS.IterationStep(PixelPoint)
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
            MyDS.IterationStep(PixelPoint)
            k += 1
        Loop

        MyDS.PicDiagram.Refresh()

    End Sub

    'SECTOR MOUSE EVENTS
    Public Sub MouseDown(e As MouseEventArgs)

        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then

            MyForm.Cursor = Cursors.Hand
            IsMouseDown = True

            'Now, Moving the Mouse moves the pendulum as well
            MouseMoving(e)
        End If
    End Sub

    Public Sub MouseMoving(e As MouseEventArgs)

        If IsMouseDown Then
            'Because the Cursor is "Hand", the Mouse Position is adjusted a bit
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

            ExaminatedPoints = 0
            L = 0
            DSJulia.ResetIteration()

            'The JuliaSet is generated with the new parameter C
            Startiteration(DSJulia)

            'The Mouse gets its normal behaviour again
            MyForm.Cursor = Cursors.Arrow
            IsMouseDown = False
        End If
    End Sub

    'SECTOR CHECKS
    Private Function IsCParameterOK() As Boolean
        With MyForm
            'The parameter c has to be in the same area as the z-Values
            'for the MandelbrotMap, the Interval is a little bigger
            Dim CheckParameterA As New ClsCheckUserData(.TxtA, New ClsInterval(CDec(-1.9), CDec(1.9)))
            Dim CheckParameterB As New ClsCheckUserData(.TxtB, New ClsInterval(CDec(-1.9), CDec(1.9)))

            Return CheckParameterA.IsTxtValueAllowed And CheckParameterB.IsTxtValueAllowed
        End With
    End Function

End Class
