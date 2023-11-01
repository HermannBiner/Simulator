'This form is the user interface for the investigation
'of the relation of the parameters of Billard, Pendulum oder similar systems
'and the parmeter C (see math. doc.) that defines its profile
'the implementation followa the concept of the Feigenbaum Diagram

'The form is based on an Interface ICDiagram 
'that is implemented by the Billard-Classes, Pendulum-Classes and other

Imports System.Globalization

Public Class FrmCDiagram

    'Prepare basic objects

    'MyBitmapGraphics draws into the C-Diagram
    Private CDiagram As Bitmap
    Private MyBitmapGraphics As ClsGraphicTool
    Private Iterator As ICDiagram

    'Private global variables

    'Parameter Range for the Parameter C
    Private MyParameterRange As ClsInterval

    'List of ValueRanges
    'e.g. Hitpoint Parameter t and Reflexion Angle Alfa
    Private MyValueParameters As List(Of ClsValueParameter)

    'Value Range for the Iteration Value to be învestigated
    'selected by the CboValueRange
    Private MyValueParameter As ClsValueParameter

    'Aktuelles Parameter-Paar
    Private MyParameterPair As ClsValueTupel

    'For the Check if the Definitions of the Ranges by the User is OK
    Private IsUserSelectionValid As Boolean

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

        'Initialize Language
        InitializeLanguage()

    End Sub

    Private Sub InitializeLanguage()

        Text = Main.LM.GetString("C-Diagram")
        LblDeltaV.Text = Main.LM.GetString("Delta") & " = "
        LblDeltaC.Text = Main.LM.GetString("Delta") & " = "
        LblValueParameter.Text = Main.LM.GetString("ExaminatedValueParameter")
        LblPrecision.Text = Main.LM.GetString("Precision") & ": " & (TrbPrecision.Value * 1000).ToString(CultureInfo.CurrentCulture)
        LblStartValues.Text = Main.LM.GetString("PositionStartValue2") &
            TrbPositionStartValues.Value.ToString(CultureInfo.CurrentCulture) & "/12"
        LblParameterRange.Text = Main.LM.GetString("ExaminatedParameterRange")
        BtnStartIteration.Text = Main.LM.GetString("StartIteration")
        BtnReset.Text = Main.LM.GetString("ResetIteration")
        CboFunction.Items.Clear()

        'the following order of adding the iteration type is relevant!
        CboFunction.Items.Add(Main.LM.GetString("EllipticBillard"))
        CboFunction.Items.Add(Main.LM.GetString("StadiumBillard"))
        CboFunction.Items.Add(Main.LM.GetString("OvalBillard"))

        'Note: The name of the ValueParameter into CboValueParameters
        'is added when the ValueParameters are known
        'depending on the type of iteration

    End Sub

    Private Sub FrmCDiagram_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Generate objects
        CDiagram = New Bitmap(PicDiagram.Width, PicDiagram.Height)
        PicDiagram.Image = CDiagram

        'set the standard
        Iterator = New ClsEllipseBillardball

        'additional default settings
        SetDefaultValues()

        CboFunction.SelectedIndex = 0
        CboFunction.Select()

    End Sub

    Private Sub SetDefaultValues()

        'if there where User-defined ranges,
        'or the iterator had changed
        'the ranges are reset to the standard

        'Setting not by reference to not change the original CParameterRange of the Iterator
        MyParameterRange = New ClsInterval(Iterator.CParameterRange.A, Iterator.CParameterRange.B)
        MyValueParameters = Iterator.ValueParameters

        CboValueParameter.Items.Clear()

        For Each VP As ClsValueParameter In MyValueParameters
            CboValueParameter.Items.Add(VP.Name)
        Next

        If CboValueParameter.SelectedIndex < 0 Then
            If MyValueParameter Is Nothing Then
                CboValueParameter.SelectedIndex = 1
            Else
                If MyValueParameter.Tag = 1 Then
                    CboValueParameter.SelectedIndex = 0
                Else
                    CboValueParameter.SelectedIndex = 1
                End If
            End If
        End If

        'Setting not by reference to not change the original ValueParameter of the Iterator
        SetMyValueParameterByValue(MyValueParameters.Item(CboValueParameter.SelectedIndex))

        MyBitmapGraphics = New ClsGraphicTool(CDiagram, MyParameterRange, MyValueParameter.Range)

        TxtCMin.Text = MyParameterRange.A.ToString(CultureInfo.CurrentCulture)
        TxtCMax.Text = MyParameterRange.B.ToString(CultureInfo.CurrentCulture)
        LblDeltaC.Text = Main.LM.GetString("Delta") & " = " & MyParameterRange.IntervalWidth.ToString(CultureInfo.CurrentCulture)

        TxtVMin.Text = MyValueParameter.Range.A.ToString(CultureInfo.CurrentCulture)
        TxtVMax.Text = MyValueParameter.Range.B.ToString(CultureInfo.CurrentCulture)
        LblDeltaV.Text = Main.LM.GetString("Delta") & " = " & MyValueParameter.Range.IntervalWidth.ToString(CultureInfo.CurrentCulture)

        'The display is cleared
        MyBitmapGraphics.Clear(Color.White)
        PicDiagram.Refresh()

        IsUserSelectionValid = True

    End Sub

    Sub SetMyValueParameterByValue(ValueParameter As ClsValueParameter)

        'If we set MyValueParameter to MyValueParameters(Index) by reference
        'then, the original data of MyValueParameters(Index) is changed as well
        'if MyValueParameter is changed
        'therefore, we set it like here
        MyValueParameter = New ClsValueParameter(ValueParameter.Tag, ValueParameter.Name, ValueParameter.Range)

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click

        'Reset ranges and Default Values
        SetDefaultValues()

    End Sub

    Private Sub CboFunktion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboFunction.SelectedIndexChanged

        Dim type As Integer

        'The user chooses the type of iteration
        type = CboFunction.SelectedIndex
        Select Case type
            Case 0  'Elliptic Billard
                Iterator = New ClsEllipseBillardball
            Case 1 'Stadium Billard
                Iterator = New ClsStadiumBillardball
            Case Else  'Oval Billard
                Iterator = New ClsOvalBillardball
        End Select

        'Reset ranges and Default Values
        SetDefaultValues()

    End Sub

    Private Sub CboValueRange_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboValueParameter.SelectedIndexChanged

        'The ValueParameter to be investigated
        'Setting not by reference to not change the original ValueParameter of the Iterator
        SetMyValueParameterByValue(MyValueParameters.Item(CboValueParameter.SelectedIndex))

        TxtVMin.Text = MyValueParameter.Range.A.ToString(CultureInfo.CurrentCulture)
        TxtVMax.Text = MyValueParameter.Range.B.ToString(CultureInfo.CurrentCulture)
        LblDeltaV.Text = Main.LM.GetString("Delta") & " = " & MyValueParameter.Range.IntervalWidth.ToString(CultureInfo.CurrentCulture)

    End Sub

    Private Sub TrbPrecision_ValueChanged(sender As Object, e As EventArgs) Handles TrbPrecision.ValueChanged

        'The precision defines how precise the diagram is generated
        LblPrecision.Text = Main.LM.GetString("Precision") & ": " & (1000 * TrbPrecision.Value).ToString(CultureInfo.CurrentCulture)

    End Sub

    Private Sub TrbPositionStartValues_ValueChanged(sender As Object, e As EventArgs) Handles TrbPositionStartValues.ValueChanged

        'The position of the start values is a number "pos" between 0 and 12
        'each startvalue is then set = ValueRange.A + pos * ValueRange.IntervalWidth / 12
        LblStartValues.Text = Main.LM.GetString("PositionStartValue2") &
            TrbPositionStartValues.Value.ToString(CultureInfo.CurrentCulture) & "/12"

    End Sub

    'SECTOR ITERATION

    Private Sub BtnStartIteration_Click(sender As Object, e As EventArgs) Handles BtnStartIteration.Click

        'Check and set the Ranges, defined by the user
        CheckUserRanges()

        If IsUserSelectionValid Then

            MyBitmapGraphics.Clear(Color.White)

            'Setting the Start-Parameterpair for the Iteration
            'Standard for the first Value
            Dim V1 As Decimal = MyValueParameters.Item(0).Range.A + MyValueParameters.Item(0).Range.IntervalWidth / 3
            '.. and the second value depending on TrbPositionSTartValues
            Dim V2 As Decimal = MyValueParameters.Item(1).Range.A + TrbPositionStartValues.Value * MyValueParameters.Item(1).Range.IntervalWidth / 12

            'Now overwrite V1, V2 depending on the selected ValueParameter
            If MyValueParameter.Tag = 1 Then
                'the selected ValueParameter is Item(0)
                V1 = MyValueParameter.Range.A + MyValueParameter.Range.IntervalWidth / 3
                'V2 is already set
            Else
                'the selected ValueParameter is Item(1)
                'V1 is already set
                V2 = MyValueParameter.Range.A + TrbPositionStartValues.Value * MyValueParameter.Range.IntervalWidth / 12
            End If

            MyParameterPair = New ClsValueTupel(V1, V2)

            'In the direction of the x-axis, we work with pixel coordinates
            Dim p As Integer

            For p = 1 To PicDiagram.Width

                'for each p, the according paranmetervalue a is calculated
                'and then the iteration runs until RuntimeUntilCycle
                'finally, the iteration values are drawn
                DrawIterationValues(p)

            Next

            'Draw the C = 1 Line
            Dim A As New ClsMathpoint(1, 0)
            Dim B As New ClsMathpoint(1, PicDiagram.Height)
            MyBitmapGraphics.DrawLine(A, B, Color.Red, 1)
            PicDiagram.Refresh()

        Else

            MessageBox.Show(Main.LM.GetString("ActionStopped"))
            SetDefaultValues()
        End If

    End Sub

    Private Sub DrawIterationValues(p As Integer)

        'Calculate the parameter C for the iteration depending on p
        Dim C As Decimal = MyParameterRange.A + (MyParameterRange.IntervalWidth * p / PicDiagram.Width)
        Iterator.CParameter = C

        Dim NextPair As ClsValueTupel

        'After that, the number of iterations must be big enough to draw the cycle
        Dim LengthOfCycle As Integer = CInt(PicDiagram.Height * MyValueParameter.Range.IntervalWidth _
            * TrbPrecision.Value / 25 / Math.Max(MyValueParameter.Range.IntervalWidth, 0.01))

        '..but not bigger than the y-axis allows
        LengthOfCycle = Math.Min(LengthOfCycle, 5 * PicDiagram.Height)

        'Finally , the cycle is drawn

        Dim DrawPoint As New ClsMathpoint(C, 0)

        For n = 0 To LengthOfCycle

            Select Case MyValueParameter.Tag
                Case 1
                    DrawPoint.Y = MyParameterPair.X
                Case Else
                    DrawPoint.Y = MyParameterPair.Y
            End Select

            MyBitmapGraphics.DrawPoint(DrawPoint, Brushes.Blue, 1)

            NextPair = Iterator.GetNextPoint(MyParameterPair)
            MyParameterPair.X = NextPair.X
            MyParameterPair.Y = NextPair.Y

        Next

        PicDiagram.Refresh()

    End Sub

    'SECTOR MANAGE USER RANGES

    Private Sub PicDiagram_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PicDiagram.MouseDown

        'The user can choose a range by a flexible rectangle
        IsMousedown = True

        'e guarantees, that the mouse position is relative to PicDiagram
        'and the Startpoint is the position, where the left mouse button was first pushed down
        UserSelectionStartpoint = e.Location

    End Sub

    Private Sub PicDiagram_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PicDiagram.MouseMove

        If IsMousedown Then

            'the endpoint is on the actual mouse position
            UserSelectionEndpoint = e.Location

            'this refreshing launches the paint-event of e and the selection-rectangle is drawn
            'in the actual position
            PicDiagram.Refresh()

        End If

    End Sub

    Private Sub PicDiagram_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles PicDiagram.Paint

        If IsMousedown Then

            'the selection-rectangle is dranw in its actual position
            Dim rect As New Rectangle(Math.Min(UserSelectionStartpoint.X, UserSelectionEndpoint.X), Math.Min(UserSelectionStartpoint.Y, UserSelectionEndpoint.Y),
                                      Math.Abs(UserSelectionStartpoint.X - UserSelectionEndpoint.X), Math.Abs(UserSelectionStartpoint.Y - UserSelectionEndpoint.Y))
            Using MyPen As New Pen(Color.Red)
                e.Graphics.DrawRectangle(MyPen, rect)
            End Using

        End If

    End Sub

    Private Sub PicDiagram_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PicDiagram.MouseUp

        IsMousedown = False

        'Now, the final EndPoint is set on the position, where the mouse button was released
        UserSelectionEndpoint = e.Location

        'We have to check, if the selection-rectangle shows a valid selection
        If UserSelectionStartpoint <> UserSelectionEndpoint Then

            'The selection is OK

            'Now, we adjust the interval of p. p moves between pMin and pMax
            Dim pMin As Integer = Math.Min(UserSelectionStartpoint.X, UserSelectionEndpoint.X)
            Dim pMax As Integer = Math.Max(UserSelectionStartpoint.X, UserSelectionEndpoint.X)

            'as well, in direction of the y-axis we have to adjust the relevant interval
            Dim qMin As Integer = Math.Min(PicDiagram.Height - UserSelectionStartpoint.Y, PicDiagram.Height - UserSelectionEndpoint.Y)
            Dim qMax As Integer = Math.Max(PicDiagram.Height - UserSelectionStartpoint.Y, PicDiagram.Height - UserSelectionEndpoint.Y)

            'This rectangle surrounds the selected range
            Dim rect As New Rectangle(pMin, qMin, pMax - pMin, qMax - qMin)

            'transmit the selection to the parameter range
            TxtCMin.Text = Math.Max(PixelToA(pMin), MyParameterRange.A).ToString(CultureInfo.CurrentCulture)
            TxtCMax.Text = Math.Min(PixelToA(pMax), MyParameterRange.B).ToString(CultureInfo.CurrentCulture)
            LblDeltaC.Text = "Delta = " & (PixelToA(pMax) - PixelToA(pMin)).ToString(CultureInfo.CurrentCulture)

            'transmit the selection to the value range of x
            TxtVMin.Text = Math.Max(PixelToX(qMin), MyValueParameter.Range.A).ToString(CultureInfo.CurrentCulture)
            TxtVMax.Text = Math.Min(PixelToX(qMax), MyValueParameter.Range.B).ToString(CultureInfo.CurrentCulture)
            LblDeltaV.Text = "Delta = " & (PixelToX(qMax) - PixelToX(qMin)).ToString(CultureInfo.CurrentCulture)

        End If
    End Sub

    'SECTOR TRANSFORMATION OF USER RANGES

    Private Function PixelToA(p As Integer) As Decimal

        'calculates the parametervalue a according to 
        Dim a As Decimal = MyParameterRange.A + ((p - 1) * MyParameterRange.IntervalWidth / PicDiagram.Width)
        Return a

    End Function

    Private Function PixelToX(q As Integer) As Decimal

        'calculates the x-value that belongs to a q-pixel coordinate in y-axis direction
        Dim x As Decimal = CDec(MyValueParameter.Range.A + (q * MyValueParameter.Range.IntervalWidth / (PicDiagram.Height * 0.99)))

        Return x

    End Function

    'MANUALLY SET USER RANGES

    Private Sub TxtCMax_LostFocus(sender As Object, e As EventArgs) Handles TxtCMax.LostFocus
        CheckUserRanges()
    End Sub

    Private Sub TxtCMin_LostFocus(sender As Object, e As EventArgs) Handles TxtCMin.LostFocus
        CheckUserRanges()
    End Sub

    Private Sub TxtVMax_LostFocus(sender As Object, e As EventArgs) Handles TxtVMax.LostFocus
        CheckUserRanges()
    End Sub

    Private Sub TxtVMin_LostFocus(sender As Object, e As EventArgs) Handles TxtVMin.LostFocus
        CheckUserRanges()
    End Sub

    'CHECK USER RANGES AND SET PARAMETER AND VALUE INTERVAL

    Private Sub CheckUserRanges()

        'The parameter range has to be part of the allowed interval for the parameter a
        'depending of the type of iteration
        Dim CheckParameterrange As New ClsCheckIsInterval(TxtCMin, TxtCMax)
        Dim IsParameterrangeValid As Boolean

        'The interval borders have to be numeric and a < b
        If CheckParameterrange.IsIntervalValid Then

            'if [a,b] is an interval, then the parameter interval is constructed
            Dim TempParameterrange = New ClsInterval(CheckParameterrange.A, CheckParameterrange.B)

            'is the parameter range part of the allowed parameter interval?
            If Iterator.CParameterRange.IsInterval2PartOfInterval(MyParameterRange) Then
                IsParameterrangeValid = True
                'take over
                MyParameterRange = TempParameterrange
            Else
                MessageBox.Show(Main.LM.GetString("ParameterRangeNotAllowed") & " [" &
                   Iterator.CParameterRange.A.ToString(CultureInfo.CurrentCulture) &
                   ", " & Iterator.CParameterRange.B.ToString(CultureInfo.CurrentCulture) &
                   "] ")
                IsParameterrangeValid = False
            End If
        Else
            IsParameterrangeValid = False
        End If

        Dim IsValuerangeValid As Boolean

        If IsParameterrangeValid Then
            'Analogue, the range of the x-value is checked
            Dim CheckValuerange As New ClsCheckIsInterval(TxtVMin, TxtVMax)

            'are the interval borders numeric and is a < b
            If CheckValuerange.IsIntervalValid Then

                'in that case, the value range is constructed
                Dim TempValuerange = New ClsInterval(CheckValuerange.A, CheckValuerange.B)

                'Is the value range part of the allowed value interval?
                If MyValueParameter.Range.IsInterval2PartOfInterval(TempValuerange) Then
                    IsValuerangeValid = True
                    'take over
                    MyValueParameter.Range = TempValuerange
                Else
                    MessageBox.Show(Main.LM.GetString("ParameterRangeNotAllowed") & " [" &
                   MyValueParameter.Range.A.ToString(CultureInfo.CurrentCulture) &
                   ", " & MyValueParameter.Range.B.ToString(CultureInfo.CurrentCulture) &
                   "] ")
                    IsValuerangeValid = False
                End If
            Else
                IsValuerangeValid = False
            End If
        End If

        IsUserSelectionValid = IsParameterrangeValid And IsValuerangeValid

        If IsUserSelectionValid Then
            LblDeltaC.Text = Main.LM.GetString("Delta") & " = " & MyParameterRange.IntervalWidth.ToString(CultureInfo.CurrentCulture)
            LblDeltaV.Text = Main.LM.GetString("Delta") & " = " & MyValueParameter.Range.IntervalWidth.ToString(CultureInfo.CurrentCulture)
            MyBitmapGraphics = New ClsGraphicTool(CDiagram, MyParameterRange, MyValueParameter.Range)
        Else
            'reset to default
            SetDefaultValues()
        End If

    End Sub

End Class
