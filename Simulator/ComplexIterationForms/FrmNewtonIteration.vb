'This form is the user interface for the complex Newton Iteration
'Different complex polynoms can be implemented
'the pixelpoints in the diagram CPlane are the startpoints of the iteration
'and they are colored depending to which root of the polynom they converge
'see as well the mathematical documentation

'The form is based on the Interface IPolynom 
'that is implemented by ClsUnitRoots3 and other
'Therefore, more cases of polynoms could be easely programmed
'by implementing this interface

'Status Checked

Imports System.Globalization
Imports System.Reflection


Public Class FrmNewtonIteration

    'Private global variables

    'Prepare basic objects
    Private Polynom As IPolynom

    'The Julia Set is drawn into the bitmap by the Polynom
    Private MapCPlane As Bitmap

    'The FrmNewtonIteration fraws into PicCPlane when moving the mouse
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

        Text = Main.LM.GetString("NewtonIteration")
        LblProtocol.Text = Main.LM.GetString("ProtocolNewton")
        ChkProtocol.Text = Main.LM.GetString("Protocol")
        BtnStart.Text = Main.LM.GetString("Start")
        BtnStop.Text = Main.LM.GetString("Stop")
        BtnShowBasin.Text = Main.LM.GetString("ShowBasin")
        BtnReset.Text = Main.LM.GetString("ResetIteration")
        LblTime.Text = Main.LM.GetString("Time")
        LblSteps.Text = Main.LM.GetString("Steps")
        GrpMixing.Text = Main.LM.GetString("Mixing")
        OptNone.Text = Main.LM.GetString("None")
        OptConjugate.Text = Main.LM.GetString("Conjugate")
        OptRotate.Text = Main.LM.GetString("Rotate")
        GrpColor.Text = Main.LM.GetString("Color")
        OptBright.Text = Main.LM.GetString("Bright")
        OptShadowed.Text = Main.LM.GetString("Shadowed")

        CboFunction.Items.Clear()

        'Add the classes implementing IPolynom
        'to the Combobox CboFunction by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IPolynom)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If types.Count > 0 Then
            Dim PolynomName As String
            For Each type In types

                'GetString is calle dwith the option IsClass = true
                'That effects that - if there is no Entry in the Resource files LabelsEN, LabelsDE -
                'the name of the Class implementing an Interface is used as default
                'suppressing the extension "Cls"
                PolynomName = Main.LM.GetString(type.Name, True)
                CboFunction.Items.Add(PolynomName)
            Next

            CboFunction.SelectedIndex = CboFunction.Items.Count - 1
            CboFunction.Select()

        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If

    End Sub

    Private Sub FrmNewtonIteration_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Generate objects
        'The PictureBox shpuld be a square
        Dim Square As Integer = Math.Min(PicCPlane.Height, PicCPlane.Width)

        PicCPlane.Height = Square
        PicCPlane.Width = Square

        MapCPlane = New Bitmap(Square, Square)
        PicCPlane.Image = MapCPlane

        Polynom = New ClsUnitRoots
        With Polynom
            .MapCPlane = MapCPlane
            .PicCPlane = PicCPlane
            .TxtNumberOfSteps = TxtSteps
            .TxtElapsedTime = TxtTime
        End With


        CboN.SelectedIndex = 1

        'Initialize Language
        InitializeLanguage()

        'additional default settings
        SetDefaultValues()

    End Sub

    Private Sub SetDefaultValues()

        If Polynom IsNot Nothing Then

            With Polynom
                TxtXMin.Text = .ActualXRange.A.ToString(CultureInfo.CurrentCulture)
                TxtXMax.Text = .ActualXRange.B.ToString(CultureInfo.CurrentCulture)
                TxtDeltaX.Text = .ActualXRange.IntervalWidth.ToString(CultureInfo.CurrentCulture)

                TxtYMin.Text = .ActualYRange.A.ToString(CultureInfo.CurrentCulture)
                TxtYMax.Text = .ActualYRange.B.ToString(CultureInfo.CurrentCulture)
                TxtDeltaY.Text = .ActualYRange.IntervalWidth.ToString(CultureInfo.CurrentCulture)


                CboN.Visible = .UseN
                LblPower.Visible = .UseN

                LblC.Visible = .UseC
                LblI.Visible = .UseC
                TxtA.Visible = .UseC
                TxtB.Visible = .UseC


                If .UseN Then
                    .N = CInt(CboN.SelectedItem)
                Else
                    .N = 3
                End If

                If .UseC Then
                    'Check if c=a+ib is a complex number and part if the square ActualXRange X ActualYRange
                    'if not, the standard value is set: c=i
                    CheckParameterC()
                    .C = New ClsComplexNumber(CDbl(TxtA.Text), CDbl(TxtB.Text))
                End If

                .PicCPlane = PicCPlane
                .MapCPlane = MapCPlane
                .TxtElapsedTime = TxtTime
                .TxtNumberOfSteps = TxtSteps

                .ProcotolList = LstProtocol
                .IsProtocol = ChkProtocol.Checked

                .PrepareIteration()
                .DrawCoordinateSystem()
                .DrawRoots(False)

                If OptConjugate.Checked Then
                    Polynom.UseMixing = IPolynom.EnMixing.Conjugate
                ElseIf OptRotate.Checked Then
                    Polynom.UseMixing = IPolynom.EnMixing.Rotate
                Else
                    Polynom.UseMixing = IPolynom.EnMixing.None
                End If

                If OptBright.Checked Then
                    Polynom.UseColor = IPolynom.EnColor.Bright
                Else
                    Polynom.UseColor = IPolynom.EnColor.Shadowed
                End If

            End With

            If TypeOf (Polynom) Is ClsUnitRoots Then
                BtnShowBasin.Visible = True
            Else
                BtnShowBasin.Visible = False
            End If

            TxtSteps.Text = 0.ToString
            TxtTime.Text = 0.ToString

        End If

    End Sub

    Private Sub ResetIteration()

        BtnStart.Text = Main.LM.GetString("Start")

        'The display is cleared
        If Polynom IsNot Nothing Then
            Polynom.Reset()
            Polynom.IterationStatus = ClsGeneral.EnIterationStatus.Stopped
        End If
        LstProtocol.Items.Clear()
        PicCPlane.Refresh()

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click

        With Polynom
            .ActualXRange = .AllowedXRange
            .ActualYRange = .AllowedYRange
            .MapCPlane = MapCPlane
        End With

        SetDefaultValues()
        ResetIteration()

    End Sub

    Private Sub CboFunction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboFunction.SelectedIndexChanged

        'This sets the type of Polynom by Reflection

        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IPolynom)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If CboFunction.SelectedIndex >= 0 Then

            Dim SelectedName As String = CboFunction.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If Main.LM.GetString(type.Name, True) = SelectedName Then
                        Polynom = CType(Activator.CreateInstance(type), IPolynom)
                        Polynom.MapCPlane = MapCPlane
                        Polynom.PicCPlane = PicCPlane
                    End If
                Next
            End If

        End If

        'Reset ranges and default Values
        SetDefaultValues()
        ResetIteration()

    End Sub

    Private Sub CboN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboN.SelectedIndexChanged

        If CboN.SelectedIndex >= 0 Then
            Polynom.N = CInt(CboN.SelectedItem)
        End If

        SetDefaultValues()
        ResetIteration()
    End Sub

    'SECTOR ITERATION

    Private Async Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click

        If Polynom.IterationStatus = ClsGeneral.EnIterationStatus.Stopped Then

            'the iteration was stopped or reset
            'and should start from the beginning
            CheckUserRanges()
            SetDefaultValues()
            ResetIteration()

            BtnStart.Text = Main.LM.GetString("Continue")

        End If

        Polynom.IterationStatus = ClsGeneral.EnIterationStatus.Started

        BtnStart.Enabled = False
        BtnReset.Enabled = False
        ChkProtocol.Enabled = False

        Application.DoEvents()

        Await Polynom.GenerateImage

        If Polynom.IterationStatus = ClsGeneral.EnIterationStatus.Stopped Then
            BtnStart.Text = Main.LM.GetString("Start")
            BtnStart.Enabled = True
            BtnReset.Enabled = True

        End If

    End Sub

    Private Sub ShowBasin()
        'Shows the approximated basin(1)
        'that is an area where |Np'(z)|<1
        If Polynom IsNot Nothing Then

            Dim XInterval = New ClsInterval(CDec(0), CDec(2))
            Dim YInterval = New ClsInterval(CDec(-1), CDec(1))
            Dim MyGraphics = New ClsGraphicTool(PicCPlane, XInterval, YInterval)
            Dim locN As Integer = CInt(CboN.SelectedItem)

            Const StepWide As Double = 0.001

            MyGraphics.Clear(Color.White)
            LstProtocol.Items.Clear()

            'Draws the coordinate system and the circles
            MyGraphics.DrawLine(New ClsMathpoint(XInterval.A, 0), New ClsMathpoint(XInterval.B, 0),
            Color.Black, 1)
            MyGraphics.DrawLine(New ClsMathpoint(0, YInterval.A), New ClsMathpoint(0, YInterval.B),
                        Color.Black, 1)
            MyGraphics.DrawCircle(New ClsMathpoint(1, 0), 1, Color.Blue, 1)
            MyGraphics.DrawCircle(New ClsMathpoint(1, 0), CDec(1 - 1 / Math.Pow(2, 1 / locN)),
                                  Color.Green, 1)
            MyGraphics.DrawPoint(New ClsMathpoint(1, 0), Brushes.Black, 2)

            Dim Asymptote As New ClsMathpoint(CDec(2 * Math.Cos(Math.PI / (2 * locN))), CDec(2 * Math.Sin(Math.PI / (2 * locN))))
            MyGraphics.DrawLine(New ClsMathpoint(0, 0), Asymptote, Color.Green, 1)
            Asymptote.Y = -Asymptote.Y
            MyGraphics.DrawLine(New ClsMathpoint(0, 0), Asymptote, Color.Green, 1)


            Dim Phi As Double = 0
            Dim R As Double
            Dim Limit As Double = Math.Sqrt(Math.Pow(XInterval.B, 2) + Math.Pow(YInterval.B, 2))

            'Draws the real and approximated curve of |Np'(z)|<1

            Do
                R = GetR(Phi, locN)

                If R < Limit Then
                    MyGraphics.DrawPoint(New ClsMathpoint(CDec(R * Math.Cos(Phi)), CDec(R * Math.Sin(Phi))), Brushes.Red, 1)
                    MyGraphics.DrawPoint(New ClsMathpoint(CDec(R * Math.Cos(Phi)), CDec(-R * Math.Sin(Phi))), Brushes.Red, 1)
                End If

                R = GetRApprox(Phi, locN)

                If R < Limit Then
                    MyGraphics.DrawPoint(New ClsMathpoint(CDec(R * Math.Cos(Phi)), CDec(R * Math.Sin(Phi))), Brushes.Red, 1)
                    MyGraphics.DrawPoint(New ClsMathpoint(CDec(R * Math.Cos(Phi)), CDec(-R * Math.Sin(Phi))), Brushes.Red, 1)
                End If

                'This is the result of experiments:
                Phi += StepWide / (2 * R)

            Loop Until (R > Limit) Or (Phi > Math.PI / (2 * locN))

        End If

    End Sub

    Private Function GetR(phi As Double, lN As Integer) As Double

        Dim rTemp As Double

        'Prepare Root
        rTemp = Math.Pow(Math.Cos(lN * phi) * (lN - 1) / (2 * lN - 1), 2) + 1 / (2 * lN - 1)

        'Root
        rTemp = (lN - 1) * Math.Sqrt(rTemp)

        'Add
        rTemp += -Math.Cos(lN * phi) * (lN - 1) * (lN - 1) / (2 * lN - 1)

        'n-th root
        rTemp = Math.Pow(rTemp, 1 / lN)

        Return rTemp

    End Function

    Private Function GetRApprox(phi As Double, lN As Integer) As Double

        Dim rTemp As Double

        rTemp = 1 / Math.Pow(2 * Math.Cos(lN * phi), 1 / lN)

        Return rTemp
    End Function

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click

        'the iteration was running and is interrupted
        Polynom.IterationStatus = ClsGeneral.EnIterationStatus.Interrupted
        'the iteration is stopoped by reset the iteration

        BtnStart.Enabled = True
        BtnReset.Enabled = True
        ChkProtocol.Enabled = True

    End Sub


    'SECTOR MANAGE USER RANGES

    Private Sub PicDiagram_MouseDown(sender As Object, e As MouseEventArgs) Handles PicCPlane.MouseDown

        If Polynom.IterationStatus = ClsGeneral.EnIterationStatus.Stopped Then
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
            Dim rect As New Rectangle(Math.Min(UserSelectionStartpoint.X, UserSelectionEndpoint.X), Math.Min(UserSelectionStartpoint.Y, UserSelectionEndpoint.Y),
                                      Math.Abs(UserSelectionStartpoint.X - UserSelectionEndpoint.X), Math.Abs(UserSelectionStartpoint.Y - UserSelectionEndpoint.Y))
            Using MyPen As New Pen(Color.Red, 2)
                e.Graphics.DrawRectangle(MyPen, rect)
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

                With Polynom
                    'transmit the selection to the x-range
                    TxtXMin.Text = Math.Max(PixelToX(xMin), .ActualXRange.A).ToString(CultureInfo.CurrentCulture)
                    TxtXMax.Text = Math.Min(PixelToX(xMax), .ActualXRange.B).ToString(CultureInfo.CurrentCulture)
                    TxtDeltaX.Text = (PixelToX(xMax) - PixelToX(xMin)).ToString(CultureInfo.CurrentCulture)

                    'transmit the selection to the y-range
                    TxtYMin.Text = Math.Max(PixelToY(yMin), .ActualYRange.A).ToString(CultureInfo.CurrentCulture)
                    TxtYMax.Text = Math.Min(PixelToY(yMax), .ActualYRange.B).ToString(CultureInfo.CurrentCulture)
                    TxtDeltaY.Text = (PixelToY(yMax) - PixelToY(yMin)).ToString(CultureInfo.CurrentCulture)
                End With

                'TakeOver Userranges
                CheckUserRanges()

                'Prepare new Iteration
                SetDefaultValues()

                BtnStart.Text = Main.LM.GetString("Start")

            End If
        End If


    End Sub

    'SECTOR TRANSFORMATION OF USER RANGES

    Private Function PixelToX(p As Integer) As Decimal

        'calculates the x-coordinate according to p

        Dim x As Decimal = Polynom.ActualXRange.A + ((p - 1) * Polynom.ActualXRange.IntervalWidth / PicCPlane.Width)

        Return x

    End Function

    Private Function PixelToY(q As Integer) As Decimal

        'calculates the y-coordinate that belongs to a q-pixel coordinate in y-axis direction

        Dim y As Decimal = CDec(Polynom.ActualYRange.A + (q * Polynom.ActualYRange.IntervalWidth / PicCPlane.Height))

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
            If Polynom.AllowedXRange.IsInterval2PartOfInterval(TempXRange) Then
                IsXRangeValid = True
                'take over
                Polynom.ActualXRange = TempXRange
            Else
                MessageBox.Show(Main.LM.GetString("X-RangeNotAllowed") & " [" &
                   Polynom.AllowedXRange.A.ToString(CultureInfo.CurrentCulture) &
                   ", " & Polynom.AllowedXRange.B.ToString(CultureInfo.CurrentCulture) &
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
                If Polynom.AllowedYRange.IsInterval2PartOfInterval(TempYRange) Then
                    'take over
                    Polynom.ActualYRange = TempYRange
                Else
                    MessageBox.Show(Main.LM.GetString("Y-RangeNotAllowed") & " [" &
                       Polynom.AllowedYRange.A.ToString(CultureInfo.CurrentCulture) &
                       ", " & Polynom.AllowedYRange.B.ToString(CultureInfo.CurrentCulture) &
                       "] ")
                End If
            End If
        End If

        TxtDeltaX.Text = Polynom.ActualXRange.IntervalWidth.ToString(CultureInfo.CurrentCulture)
        TxtDeltaY.Text = Polynom.ActualYRange.IntervalWidth.ToString(CultureInfo.CurrentCulture)

        Polynom.MapCPlane = MapCPlane

    End Sub

    'Checks the Parameter C
    Private Sub CheckParameterC()

        Dim ParameterA = New ClsCheckIsNumeric(TxtA)

        'IsNumeric?
        If ParameterA.IsInputValid Then
            'Is in square?
            If Polynom.AllowedXRange.IsNumberInInterval(ParameterA.NumericValue) Then
                'OK, nothing to do
            Else
                MessageBox.Show(Main.LM.GetString("CXNotAllowed") & ": [" & Polynom.AllowedXRange.A.ToString &
                                                  ", " & Polynom.AllowedXRange.B.ToString & "]")
                TxtA.Text = "0" 'Standard
            End If
        Else
            TxtA.Text = "0"
        End If

        Dim ParameterB = New ClsCheckIsNumeric(TxtB)
        'IsNumeric?
        If ParameterB.IsInputValid Then
            'Is in square?
            If Polynom.AllowedYRange.IsNumberInInterval(ParameterB.NumericValue) Then
                'OK, nothing to do
            Else
                MessageBox.Show(Main.LM.GetString("CYNotAllowed") & ": [" & Polynom.AllowedYRange.A.ToString &
                                                  ", " & Polynom.AllowedYRange.B.ToString & "]")
                TxtB.Text = "1" 'Standard
            End If
        Else
            TxtB.Text = "1"
        End If

    End Sub

    Private Sub FrmNewtonIteration_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        SetDefaultValues()
        ResetIteration()
    End Sub

    Private Sub TxtA_LostFocus(sender As Object, e As EventArgs) Handles TxtA.LostFocus
        SetDefaultValues()
        ResetIteration()
    End Sub

    Private Sub TxtB_LostFocus(sender As Object, e As EventArgs) Handles TxtB.LostFocus
        SetDefaultValues()
        ResetIteration()
    End Sub

    Private Sub ChkConjugateZ_CheckedChanged(sender As Object, e As EventArgs)
        SetDefaultValues()
        ResetIteration()
    End Sub

    Private Sub ChkProtocol_CheckedChanged(sender As Object, e As EventArgs) Handles ChkProtocol.CheckedChanged
        SetDefaultValues()
        ResetIteration()
    End Sub

    Private Sub OptBright_CheckedChanged(sender As Object, e As EventArgs) Handles OptBright.CheckedChanged
        SetDefaultValues()
        ResetIteration()
    End Sub

    Private Sub OptShadowed_CheckedChanged(sender As Object, e As EventArgs) Handles OptShadowed.CheckedChanged
        SetDefaultValues()
        ResetIteration()
    End Sub

    Private Sub OptNone_CheckedChanged(sender As Object, e As EventArgs) Handles OptNone.CheckedChanged
        SetDefaultValues()
        ResetIteration()
    End Sub

    Private Sub OptConjugate_CheckedChanged(sender As Object, e As EventArgs) Handles OptConjugate.CheckedChanged
        SetDefaultValues()
        ResetIteration()
    End Sub

    Private Sub OptRotate_CheckedChanged(sender As Object, e As EventArgs) Handles OptRotate.CheckedChanged
        SetDefaultValues()
        ResetIteration()
    End Sub

    Private Sub BtnShowBasin_Click(sender As Object, e As EventArgs) Handles BtnShowBasin.Click
        ShowBasin()
    End Sub
End Class