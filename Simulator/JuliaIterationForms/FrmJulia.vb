﻿'This form is the user interface for the study of the Julia Set
'generated by the iteration z -> z^2+c
'In addition, the Mandelbrot set can be generated as well

'The form is based on the Interface IJulia
'that is implemented by ClsJulia and ClsMandelbrot
'Therefore, more cases of polynoms could be easely programmed
'by implementing this interface

'Status Checked

Imports System.Globalization
Imports System.Reflection

Public Class FrmJulia

    'Private global variables

    'Prepare basic objects
    Private Julia As IJulia

    'The Julia Set is drawn into the bitmap by the Polynom
    Private MapCPlane As Bitmap

    'The FrmNewtonIteration draws into PicCPlane when moving the mouse
    Private PicCPlaneGraphics As ClsGraphicTool

    'Variables for the definition of the Ranges by a selection-rectangle
    Private IsMousedown As Boolean = False

    'Point where the left mouse button was pushed down
    Private UserSelectionStartpoint As Point

    'Point where the left mouse button was released
    Private UserSelectionEndpoint As Point

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub InitializeLanguage()

        Text = FrmMain.LM.GetString("JuliaMandelbrot")
        BtnStart.Text = FrmMain.LM.GetString("Start")
        BtnStop.Text = FrmMain.LM.GetString("Stop")
        BtnReset.Text = FrmMain.LM.GetString("ResetIteration")
        LblTime.Text = FrmMain.LM.GetString("Time")
        LblSteps.Text = FrmMain.LM.GetString("Steps")
        LblProtocol.Text = FrmMain.LM.GetString("ProtocolJulia")
        ChkProtocol.Text = FrmMain.LM.GetString("Protocol")
        GrpColors.Text = FrmMain.LM.GetString("Colors")
        OptSystem.Text = FrmMain.LM.GetString("System")
        OptUser.Text = FrmMain.LM.GetString("UserDefined")
        ChkTrack.Text = FrmMain.LM.GetString("CTrack")

        CboFunction.Items.Clear()

        'Add the classes implementing IPolynom
        'to the Combobox CboFunction by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IJulia)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If types.Count > 0 Then
            Dim JuliaName As String
            For Each type In types

                'GetString is calle dwith the option IsClass = true
                'That effects that - if there is no Entry in the Resource files LabelsEN, LabelsDE -
                'the name of the Class implementing an Interface is used as default
                'suppressing the extension "Cls"
                JuliaName = FrmMain.LM.GetString(type.Name, True)
                CboFunction.Items.Add(JuliaName)
            Next

            CboFunction.SelectedIndex = 0
            CboFunction.Select()

        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If

    End Sub

    Private Sub FrmJuliaSet_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Generate objects
        'The PictureBox shpuld be a square
        Dim Square As Integer = Math.Min(PicCPlane.Height, PicCPlane.Width)

        PicCPlane.Height = Square
        PicCPlane.Width = Square

        MapCPlane = New Bitmap(Square, Square)
        PicCPlane.Image = MapCPlane

        Julia = New ClsJuliaN
        With Julia
            .MapCPlane = MapCPlane
            .PicCPlane = PicCPlane
            .TxtNumberOfSteps = TxtSteps
            .TxtElapsedTime = TxtTime
        End With

        CboN.SelectedIndex = 0

        TxtA.Text = "-0.2"
        TxtB.Text = "0.7"

        'Initialize Language
        InitializeLanguage()

        'additional default settings
        SetDefaultValues()
    End Sub

    Private Sub SetDefaultValues()

        If Julia IsNot Nothing Then

            With Julia

                .N = CInt(CboN.SelectedItem)

                TxtXMin.Text = .ActualXRange.A.ToString(CultureInfo.CurrentCulture)
                TxtXMax.Text = .ActualXRange.B.ToString(CultureInfo.CurrentCulture)
                TxtDeltaX.Text = .ActualXRange.IntervalWidth.ToString(CultureInfo.CurrentCulture)

                TxtYMin.Text = .ActualYRange.A.ToString(CultureInfo.CurrentCulture)
                TxtYMax.Text = .ActualYRange.B.ToString(CultureInfo.CurrentCulture)
                TxtDeltaY.Text = .ActualYRange.IntervalWidth.ToString(CultureInfo.CurrentCulture)

                'Check if c=a+ib is a complex number and part if the square ActualXRange X ActualYRange
                'if not, the standard value is set: c=i
                CheckParameterC()

                .C = New ClsComplexNumber(CDbl(TxtA.Text), CDbl(TxtB.Text))
                .PicCPlane = PicCPlane
                .MapCPlane = MapCPlane
                .TxtElapsedTime = TxtTime
                .TxtNumberOfSteps = TxtSteps

                .ProcotolList = LstProtocol
                .IsProtocol = ChkProtocol.Checked

                .DrawCoordinateSystem()

                .RedPercent = TrbRed.Value / 10
                .GreenPercent = TrbGreen.Value / 10
                .BluePercent = TrbBlue.Value / 10

                .UseSystemColors = OptSystem.Checked

                If OptSystem.Checked Then
                    TrbBlue.Visible = False
                    TrbGreen.Visible = False
                    TrbRed.Visible = False
                    PicBright.Visible = False
                    PicDark.Visible = False
                Else
                    TrbBlue.Visible = True
                    TrbGreen.Visible = True
                    TrbRed.Visible = True
                    PicBright.Visible = True
                    PicDark.Visible = True
                    SetColors()
                End If

                .IterationStatus = ClsGeneral.EnIterationStatus.Stopped

            End With
            TxtSteps.Text = 0.ToString
            TxtTime.Text = 0.ToString
        End If

    End Sub

    Private Sub ResetIteration()

        BtnStart.Text = FrmMain.LM.GetString("Start")

        'The display is cleared
        If Julia IsNot Nothing Then
            Julia.Reset()
            Julia.IterationStatus = ClsGeneral.EnIterationStatus.Stopped
        End If
        PicCPlane.Refresh()
        LstProtocol.Items.Clear()

        ChkTrack.Visible = False
        ChkTrack.Checked = False

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click

        With Julia
            .ActualXRange = .AllowedXRange
            .ActualYRange = .AllowedYRange
        End With

        SetDefaultValues()
        ResetIteration()

    End Sub

    Private Sub CboFunction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboFunction.SelectedIndexChanged

        'This sets the type of ClsJulia by Reflection

        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IJulia)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If CboFunction.SelectedIndex >= 0 Then

            Dim SelectedName As String = CboFunction.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If FrmMain.LM.GetString(type.Name, True) = SelectedName Then
                        Julia = CType(Activator.CreateInstance(type), IJulia)
                        Julia.MapCPlane = MapCPlane
                        Julia.PicCPlane = PicCPlane
                    End If
                Next
            End If

        End If

        'Reset ranges and default Values
        SetDefaultValues()

    End Sub


    'SECTOR ITERATION

    Private Async Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click

        If Julia IsNot Nothing Then
            If ChkTrack.Checked Then

                Julia.C = New ClsComplexNumber(CDbl(TxtA.Text), CDbl(TxtB.Text))
                ShowCTrack()

            Else
                If Julia.IterationStatus = ClsGeneral.EnIterationStatus.Stopped Then

                    'the iteration was stopped or reset
                    'and should start from the beginning
                    CheckUserRanges()
                    SetDefaultValues()
                    ResetIteration()

                    BtnStart.Text = FrmMain.LM.GetString("Continue")
                End If

                Julia.IterationStatus = ClsGeneral.EnIterationStatus.Running

                BtnStart.Enabled = False
                BtnReset.Enabled = False
                ChkProtocol.Enabled = False

                Application.DoEvents()

                Await Julia.GenerateImage

                If Julia.IterationStatus = ClsGeneral.EnIterationStatus.Stopped Then
                    BtnStart.Text = FrmMain.LM.GetString("Start")
                    BtnStart.Enabled = True
                    BtnReset.Enabled = True

                    If Julia.IsTrackImplemented Then
                        ChkTrack.Visible = True
                    End If
                End If

            End If
        End If
    End Sub


    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click

        'the iteration was running and is interrupted
        Julia.IterationStatus = ClsGeneral.EnIterationStatus.Interrupted
        'the iteration is stopoped by reset the iteration

        BtnStart.Enabled = True
        BtnReset.Enabled = True
        ChkProtocol.Enabled = True

    End Sub

    Private Sub ShowCTrack()
        Julia.ShowCTrack
    End Sub

    'SECTOR MANAGE USER RANGES

    Private Sub PicDiagram_MouseDown(sender As Object, e As MouseEventArgs) Handles PicCPlane.MouseDown

        If Julia.IterationStatus = ClsGeneral.EnIterationStatus.Stopped Then
            'The user can choose a range by a flexible rectangle
            IsMousedown = True

            'e guarantees, that the mouse position is relative to PicCPlane
            'and the Startpoint is the position, where the left mouse button was first pushed down
            UserSelectionStartpoint = e.Location
        Else
            'The Iteration has to be stopped before the user can make a new selection
        End If
    End Sub

    Private Sub PicDiagram_MouseMove(sender As Object, e As MouseEventArgs) Handles PicCPlane.MouseMove

        If IsMousedown Then

            'the endpoint is on the actual mouse position
            UserSelectionEndpoint = e.Location

            'this refreshing launches the paint-event of e and the selection-rectangle is drawn
            'in the actual position
            PicCPlane.Refresh()

        End If

    End Sub

    Private Sub PicDiagram_Paint(sender As Object, e As PaintEventArgs) Handles PicCPlane.Paint

        If IsMousedown Then

            'the selection-rectangle is dranw in its actual position
            Dim rect As New Rectangle(Math.Min(UserSelectionStartpoint.X, UserSelectionEndpoint.X),
                                      Math.Min(UserSelectionStartpoint.Y, UserSelectionEndpoint.Y),
                                  Math.Abs(UserSelectionStartpoint.X - UserSelectionEndpoint.X),
                                  Math.Abs(UserSelectionStartpoint.Y - UserSelectionEndpoint.Y))
            Dim midpoint As New Rectangle(CInt((UserSelectionEndpoint.X + UserSelectionStartpoint.X) / 2),
                                          CInt((UserSelectionStartpoint.Y + UserSelectionEndpoint.Y) / 2), 1, 1)
            Using MyPen As New Pen(Color.Red, 2)
                    e.Graphics.DrawRectangle(MyPen, rect)
                e.Graphics.DrawEllipse(MyPen, midpoint)
            End Using

        End If

    End Sub

    Private Sub PicDiagram_MouseUp(sender As Object, e As MouseEventArgs) Handles PicCPlane.MouseUp

        If IsMousedown Then
            IsMousedown = False

            'Now, the final EndPoint is set on the position, where the mouse button was released
            UserSelectionEndpoint = e.Location

            'We have to check, if the selection-rectangle shows a valid selection
            If UserSelectionStartpoint <> UserSelectionEndpoint Then

                'The selection is OK

                'Now, we adjust the interval of x. x moves between xMin and xMax
                Dim xMin As Integer = Math.Min(UserSelectionStartpoint.X, UserSelectionEndpoint.X)
                Dim xMax As Integer = Math.Max(UserSelectionStartpoint.X, UserSelectionEndpoint.X)

                'as well, in direction of the y-axis we have to adjust the relevant interval
                Dim yMin As Integer = Math.Min(PicCPlane.Height - UserSelectionStartpoint.Y, PicCPlane.Height - UserSelectionEndpoint.Y)
                Dim yMax As Integer = Math.Max(PicCPlane.Height - UserSelectionStartpoint.Y, PicCPlane.Height - UserSelectionEndpoint.Y)

                'This rectangle surrounds the selected range
                Dim rect As New Rectangle(xMin, yMin, xMax - xMin, yMax - yMin)

                With Julia
                    'transmit the selection to the x-range
                    TxtXMin.Text = Math.Max(PixelToX(xMin), .ActualXRange.A).ToString(CultureInfo.CurrentCulture)
                    TxtXMax.Text = Math.Min(PixelToX(xMax), .ActualXRange.B).ToString(CultureInfo.CurrentCulture)
                    TxtDeltaX.Text = (PixelToX(xMax) - PixelToX(xMin)).ToString(CultureInfo.CurrentCulture)

                    'transmit the selection to the y-range
                    TxtYMin.Text = Math.Max(PixelToY(yMin), .ActualYRange.A).ToString(CultureInfo.CurrentCulture)
                    TxtYMax.Text = Math.Min(PixelToY(yMax), .ActualYRange.B).ToString(CultureInfo.CurrentCulture)
                    TxtDeltaY.Text = (PixelToY(yMax) - PixelToY(yMin)).ToString(CultureInfo.CurrentCulture)
                End With

                If Julia.IsTrackImplemented Then
                    'The parameter C is set as midpoint of the selection
                    TxtA.Text = ((CDbl(TxtXMax.Text) + CDbl(TxtXMin.Text)) / 2).ToString
                    TxtB.Text = ((CDbl(TxtYMax.Text) + CDbl(TxtYMin.Text)) / 2).ToString
                End If


                If Not ChkTrack.Checked Then

                    CheckUserRanges()

                    'Prepare new Iteration
                    SetDefaultValues()
                    BtnStart.Text = FrmMain.LM.GetString("Start")
                End If
            End If
        End If

    End Sub


    'SECTOR TRANSFORMATION OF USER RANGES

    Private Function PixelToX(p As Integer) As Decimal

        'calculates the x-coordinate according to p

        Dim x As Decimal = Julia.ActualXRange.A + ((p - 1) * Julia.ActualXRange.IntervalWidth / PicCPlane.Width)

        Return x

    End Function

    Private Function PixelToY(q As Integer) As Decimal

        'calculates the y-coordinate that belongs to a q-pixel coordinate in y-axis direction

        Dim y As Decimal = CDec(Julia.ActualYRange.A + (q * Julia.ActualYRange.IntervalWidth / PicCPlane.Height))

        Return y

    End Function

    'CHECK USER RANGES AND SET X- AND Y- RANGE

    Private Sub CheckUserRanges()

        'The parameter range has to be part of the allowed interval for the coordinate x
        'depending of the type of iteration
        Dim CheckXRange As New ClsCheckIsInterval(TxtXMin, TxtXMax)
        Dim IsXRangeValid As Boolean

        'The interval borders have to be numeric and a < b
        If CheckXRange.IsIntervalValid Then

            'if [a,b] is an interval, then the parameter interval is constructed
            Dim TempXRange = New ClsInterval(CheckXRange.A, CheckXRange.B)

            'is the parameter range part of the allowed parameter interval?
            If Julia.AllowedXRange.IsInterval2PartOfInterval(TempXRange) Then
                IsXRangeValid = True
                'take over
                Julia.ActualXRange = TempXRange
            Else
                MessageBox.Show(FrmMain.LM.GetString("X-RangeNotAllowed") & " [" &
                   Julia.AllowedXRange.A.ToString(CultureInfo.CurrentCulture) &
                   ", " & Julia.AllowedXRange.B.ToString(CultureInfo.CurrentCulture) &
                   "] ")
                IsXRangeValid = False
            End If
        Else
            IsXRangeValid = False
        End If

        If IsXRangeValid Then

            'Analogue, the range of the y-value is checked
            Dim CheckYRange As New ClsCheckIsInterval(TxtYMin, TxtYMax)

            'are the interval borders numeric and is a < b
            If CheckYRange.IsIntervalValid Then

                'in that case, the value range is constructed
                Dim TempYRange = New ClsInterval(CheckYRange.A, CheckYRange.B)

                'Is the value range part of the allowed value interval?
                If Julia.AllowedYRange.IsInterval2PartOfInterval(TempYRange) Then
                    'take over
                    Julia.ActualYRange = TempYRange
                Else
                    MessageBox.Show(FrmMain.LM.GetString("Y-RangeNotAllowed") & " [" &
                       Julia.AllowedYRange.A.ToString(CultureInfo.CurrentCulture) &
                       ", " & Julia.AllowedYRange.B.ToString(CultureInfo.CurrentCulture) &
                       "] ")
                End If
            End If
        End If

        TxtDeltaX.Text = Julia.ActualXRange.IntervalWidth.ToString(CultureInfo.CurrentCulture)
        TxtDeltaY.Text = Julia.ActualYRange.IntervalWidth.ToString(CultureInfo.CurrentCulture)

        Julia.MapCPlane = MapCPlane

    End Sub

    'Checks the Parameter C
    Private Sub CheckParameterC()

        Dim ParameterA = New ClsCheckIsNumeric(TxtA)

        'IsNumeric?
        If ParameterA.IsInputValid Then
            'Is in square?
            If Julia.AllowedXRange.IsNumberInInterval(ParameterA.NumericValue) Then
                'OK, nothing to do
            Else
                MessageBox.Show(FrmMain.LM.GetString("CXNotAllowed") & ": [" & Julia.AllowedXRange.A.ToString &
                                                  ", " & Julia.AllowedXRange.B.ToString & "]")
                TxtA.Text = "0" 'Standard
            End If
        Else
            TxtA.Text = "0"
        End If

        Dim ParameterB = New ClsCheckIsNumeric(TxtB)
        'IsNumeric?
        If ParameterB.IsInputValid Then
            'Is in square?
            If Julia.AllowedYRange.IsNumberInInterval(ParameterB.NumericValue) Then
                'OK, nothing to do
            Else
                MessageBox.Show(FrmMain.LM.GetString("CYNotAllowed") & ": [" & Julia.AllowedYRange.A.ToString &
                                                  ", " & Julia.AllowedYRange.B.ToString & "]")
                TxtB.Text = "1" 'Standard
            End If
        Else
            TxtB.Text = "1"
        End If

    End Sub

    Private Sub CboN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboN.SelectedIndexChanged

        If CboN.SelectedIndex >= 0 Then
            Julia.N = CInt(CboN.SelectedItem)
        End If

        With Julia
            .ActualXRange = .AllowedXRange
            .ActualYRange = .AllowedYRange
            .MapCPlane = MapCPlane
            .PicCPlane = PicCPlane
        End With

        SetDefaultValues()
        ResetIteration()
    End Sub

    Private Sub FrmJuliaSet_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        SetDefaultValues()
        ResetIteration()
    End Sub

    Private Sub TxtA_LostFocus(sender As Object, e As EventArgs) Handles TxtA.LostFocus
        If Not ChkTrack.Checked Then
            SetDefaultValues()
            ResetIteration()
        End If
    End Sub

    Private Sub TxtB_LostFocus(sender As Object, e As EventArgs) Handles TxtB.LostFocus
        If Not ChkTrack.Checked Then
            SetDefaultValues()
            ResetIteration()
        End If
    End Sub

    Private Sub ChkProtocol_CheckedChanged(sender As Object, e As EventArgs) Handles ChkProtocol.CheckedChanged
        SetDefaultValues
        ResetIteration
    End Sub

    Private Sub TrbBlue_ValueChanged(sender As Object, e As EventArgs) Handles TrbBlue.ValueChanged
        If Julia IsNot Nothing Then
            Julia.BluePercent = TrbBlue.Value / 10
            SetColors()
        End If
    End Sub

    Private Sub TrbGreen_ValueChanged(sender As Object, e As EventArgs) Handles TrbGreen.ValueChanged
        If Julia IsNot Nothing Then
            Julia.GreenPercent = TrbGreen.Value / 10
            SetColors()
        End If
    End Sub

    Private Sub TrbRed_ValueChanged(sender As Object, e As EventArgs) Handles TrbRed.ValueChanged
        If Julia IsNot Nothing Then
            Julia.RedPercent = TrbRed.Value / 10
            SetColors()
        End If
    End Sub

    Private Sub SetColors()
        PicBright.BackColor = Color.FromArgb(255, CInt(255 * TrbRed.Value / 10), CInt(255 * TrbGreen.Value / 10),
                                             CInt(255 * TrbBlue.Value / 10))
        PicDark.BackColor = Color.FromArgb(255, CInt(150 * TrbRed.Value / 10), CInt(150 * TrbGreen.Value / 10),
                                             CInt(150 * TrbBlue.Value / 10))
    End Sub

    Private Sub OptSystem_CheckedChanged(sender As Object, e As EventArgs) Handles OptSystem.CheckedChanged
        SetDefaultValues()
        ResetIteration()
    End Sub

    Private Sub OptUser_CheckedChanged(sender As Object, e As EventArgs) Handles OptUser.CheckedChanged
        SetDefaultValues()
        ResetIteration()
    End Sub
End Class