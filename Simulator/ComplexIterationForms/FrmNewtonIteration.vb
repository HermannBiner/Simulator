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

    'Controlling the Iteration Loop
    Private StopIteration As Boolean

    'Number of Steps
    Private n As Integer

    'Coordinates of the pixel with the startvalue
    Dim p As Integer
    Dim q As Integer
    Dim PixelPoint As Point

    'Length of a branche of the spiral
    'see Sub IterationLoop
    Dim L As Integer = 0

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub InitializeLanguage()

        Text = Main.LM.GetString("NewtonIteration")
        LblPrecision.Text = Main.LM.GetString("Precision") & ": " & TrbPrecision.Value
        LblProtocol.Text = Main.LM.GetString("Protocol")
        BtnStart.Text = Main.LM.GetString("Start")
        BtnStop.Text = Main.LM.GetString("Stop")
        BtnReset.Text = Main.LM.GetString("ResetIteration")

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

        Polynom = New ClsUnitRoots3 With {
            .MapCPlane = MapCPlane
        }

        'Initialize Language
        InitializeLanguage()

        'additional default settings
        SetDefaultValues()

    End Sub

    Private Sub SetDefaultValues()

        With Polynom
            TxtXMin.Text = .ActualXRange.A.ToString(CultureInfo.CurrentCulture)
            TxtXMax.Text = .ActualXRange.B.ToString(CultureInfo.CurrentCulture)
            TxtDeltaX.Text = .ActualXRange.IntervalWidth.ToString(CultureInfo.CurrentCulture)

            TxtYMin.Text = .ActualYRange.A.ToString(CultureInfo.CurrentCulture)
            TxtYMax.Text = .ActualYRange.B.ToString(CultureInfo.CurrentCulture)
            TxtDeltaY.Text = .ActualYRange.IntervalWidth.ToString(CultureInfo.CurrentCulture)
        End With

        Polynom.Deepness = TrbPrecision.Value * 10
        Polynom.Procotol = LstProtocol

        ResetIteration()

        Polynom.DrawCoordinateSystem()

        n = 0
        L = 0

    End Sub

    Private Sub ResetIteration()

        BtnStart.Text = Main.LM.GetString("Start")

        'The display is cleared
        Polynom.Reset()
        PicCPlane.Refresh()

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click

        With Polynom
            .ActualXRange = .AllowedXRange
            .ActualYRange = .AllowedYRange
            .MapCPlane = MapCPlane
            .Deepness = TrbPrecision.Value * 10
        End With

        SetDefaultValues()

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
                    End If
                Next
            End If

        End If

        'Reset ranges and default Values
        SetDefaultValues()

    End Sub

    Private Sub TrbPrecision_ValueChanged(sender As Object, e As EventArgs) Handles TrbPrecision.ValueChanged
        LblPrecision.Text = Main.LM.GetString("Precision") & ": " & TrbPrecision.Value
        If Polynom IsNot Nothing Then
            Polynom.Deepness = TrbPrecision.Value * 10
        End If
    End Sub

    'SECTOR ITERATION

    Private Async Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click

        If n = 0 Then

            'the iteration was stopped or reset
            'and should start from the beginning
            CheckUserRanges()

            BtnStart.Text = Main.LM.GetString("Continue")

        End If

        StopIteration = False
        BtnStart.Enabled = False
        BtnReset.Enabled = False

        Application.DoEvents()

        Await IterationLoop()

    End Sub


    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click

        'the iteration is running and should be stopped
        StopIteration = True

        BtnStart.Enabled = True
        BtnReset.Enabled = True

    End Sub

    Private Async Function IterationLoop() As Task

        'Sig = 1 if n odd, = -1 else
        Dim Sig As Integer

        'Parameter k = 1...L
        Dim k As Integer

        'This algorithm goes through the CPlane in a spiral starting in the midpoint
        If n = 0 Then
            p = CInt(PicCPlane.Width / 2)
            q = CInt(PicCPlane.Height / 2)
            PixelPoint = New Point

            With PixelPoint
                .X = p
                .Y = q
            End With

            Polynom.Iteration(PixelPoint)
            PicCPlane.Refresh()

        End If


        Do

            n += 1

            If n Mod 2 = 0 Then
                Sig = -1
            Else
                Sig = 1
            End If

            L += 1

            For k = 1 To L
                p += Sig
                With PixelPoint
                    .X = p
                    .Y = q
                End With

                Polynom.Iteration(PixelPoint)
                PicCPlane.Refresh()

                If p Mod 10 = 0 Then
                    Await Task.Delay(2)
                End If

            Next

            For k = 1 To L
                q += Sig
                With PixelPoint
                    .X = p
                    .Y = q
                End With

                Polynom.Iteration(PixelPoint)
                PicCPlane.Refresh()

                If q Mod 10 = 0 Then
                    Await Task.Delay(2)
                End If

            Next



            If p >= PicCPlane.Width Or q >= PicCPlane.Height Then

                StopIteration = True
                BtnStart.Text = Main.LM.GetString("Start")
                BtnStart.Enabled = True
                BtnReset.Enabled = True

            End If

        Loop Until StopIteration

    End Function

    'SECTOR MANAGE USER RANGES

    Private Sub PicDiagram_MouseDown(sender As Object, e As MouseEventArgs) Handles PicCPlane.MouseDown

        If StopIteration Then
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
                Reset()

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

    Private Sub FrmNewtonIteration_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        SetDefaultValues()

    End Sub

End Class