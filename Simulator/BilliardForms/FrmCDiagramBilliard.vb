'This form is the user interface for the investigation
'of the relation of the parameters of Billiard, Pendulum or similar systems
'and the parmeter C (see math. doc.) that defines its profile
'the implementation follows the concept of the Feigenbaum Diagram

'The form is based on an Interface ICDiagram 
'that is implemented by the Billiard-Classes, Pendulum-Classes and other

Imports System.Globalization
Imports System.Reflection

Public Class FrmCDiagramBilliard

    'Prepare basic objects

    'MyBitmapGraphics draws into the C-Diagram
    Private CDiagram As Bitmap
    Private MyBitmapGraphics As ClsGraphicTool
    Private Iterator As ICDiagramBilliard

    'Private global variables

    'Parameter Range for the Parameter C
    Private MyParameterRange As ClsInterval

    'List of ValueRanges
    'e.g. Hitpoint Parameter t and Reflexion Angle Alfa
    Private MyValueParameters As List(Of ClsValueParameter)

    'Value Range for the Iteration Value to be învestigated
    'selected by the CboValueRange
    'This is the original ValueParameter
    Private MyValueParameter As ClsValueParameter

    'And this is the one changed by the user when doing a selection in the Diagram
    Private MyUserValueParameter As ClsValueParameter

    'Actual parameter pair
    Private MyParameterPair As ClsValuePair

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

    End Sub

    Private Sub InitializeLanguage()

        Text = FrmMain.LM.GetString("C-Diagram")
        LblDeltaV.Text = FrmMain.LM.GetString("Delta") & " = "
        LblDeltaC.Text = FrmMain.LM.GetString("Delta") & " = "
        LblValueParameter.Text = FrmMain.LM.GetString("ExaminatedValueParameter")
        LblPrecision.Text = FrmMain.LM.GetString("Precision") & ": " & (TrbPrecision.Value * 1000).ToString(CultureInfo.CurrentCulture)
        LblStartValues.Text = FrmMain.LM.GetString("PositionStartValue2") &
            TrbPositionStartValues.Value.ToString(CultureInfo.CurrentCulture) & "/120"
        LblParameterRange.Text = FrmMain.LM.GetString("ExaminatedParameterRange")
        BtnStartIteration.Text = FrmMain.LM.GetString("StartIteration")

        BtnReset.Text = FrmMain.LM.GetString("ResetIteration")
        CboFunction.Items.Clear()

        'Add the classes implementing IBilliardBall
        'to the Combobox CboBilliardTable by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(ICDiagramBilliard)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If types.Count > 0 Then
            Dim BilliardName As String
            For Each type In types

                'GetString is calle dwith the option IsClass = true
                'That effects that - if there is no Entry in the Resource files LabelsEN, LabelsDE -
                'the name of the Class implementing an Interface is used as default
                'suppressing the extension "Cls"
                BilliardName = FrmMain.LM.GetString(type.Name, True)
                CboFunction.Items.Add(BilliardName)
            Next

            CboFunction.SelectedIndex = CboFunction.Items.Count - 1
            CboFunction.Select()

        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If

        'Note: The name of the ValueParameter into the CboValueParameters
        'is added when the ValueParameters are known
        'depending on the type of iteration

    End Sub

    Private Sub FrmCDiagram_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Generate objects
        CDiagram = New Bitmap(PicDiagram.Width, PicDiagram.Height)
        PicDiagram.Image = CDiagram

        'set the standard
        Iterator = New ClsEllipseBilliardball

        'Setting not by reference that the original CParameterRange of the Iterator is not changed
        MyParameterRange = New ClsInterval(Iterator.CParameterRange.A, Iterator.CParameterRange.B)
        MyValueParameters = Iterator.ValueParameters

        CboValueParameter.Items.Clear()

        For Each VP As ClsValueParameter In MyValueParameters
            CboValueParameter.Items.Add(VP.Name)
        Next

        If CboValueParameter.SelectedIndex < 0 Then
            If MyUserValueParameter Is Nothing Then
                CboValueParameter.SelectedIndex = 1
            Else
                If MyUserValueParameter.Tag = 1 Then
                    CboValueParameter.SelectedIndex = 0
                Else
                    CboValueParameter.SelectedIndex = 1
                End If
            End If
        End If

        'Initialize Language
        InitializeLanguage()

        'additional default settings
        SetDefaultValues()


    End Sub

    Private Sub SetDefaultValues()

        'Setting not by reference that the original ValueParameter of the Iterator is not changed
        SetMyValueParameterByValue(MyValueParameters.Item(CboValueParameter.SelectedIndex))

        MyParameterRange = New ClsInterval(Iterator.CParameterRange.A, Iterator.CParameterRange.B)
        MyBitmapGraphics = New ClsGraphicTool(CDiagram, MyParameterRange, MyUserValueParameter.Range)

        TxtCMin.Text = MyParameterRange.A.ToString(CultureInfo.CurrentCulture)
        TxtCMax.Text = MyParameterRange.B.ToString(CultureInfo.CurrentCulture)
        LblDeltaC.Text = FrmMain.LM.GetString("Delta") & " = " & MyParameterRange.IntervalWidth.ToString(CultureInfo.CurrentCulture)

        TxtVMin.Text = MyValueParameter.Range.A.ToString(CultureInfo.CurrentCulture)
        TxtVMax.Text = MyValueParameter.Range.B.ToString(CultureInfo.CurrentCulture)
        LblDeltaV.Text = FrmMain.LM.GetString("Delta") & " = " & MyValueParameter.Range.IntervalWidth.ToString(CultureInfo.CurrentCulture)

        ResetIteration()

        IsUserSelectionValid = True

    End Sub

    Sub SetMyValueParameterByValue(ValueParameter As ClsValueParameter)

        'If we set MyValueParameter to MyValueParameters(Index) by reference
        'then, the original data of MyValueParameters(Index) is changed as well
        'if MyValueParameter is changed
        'therefore, we set it like here
        MyValueParameter = New ClsValueParameter(ValueParameter.Tag, ValueParameter.Name, ValueParameter.Range)
        MyUserValueParameter = New ClsValueParameter(ValueParameter.Tag, ValueParameter.Name, ValueParameter.Range)

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click

        SetDefaultValues()

    End Sub

    Sub ResetIteration()

        'The display is cleared
        'When loading the form, MyBitmapGraphics is maybe not inizialized
        If Not IsNothing(MyBitmapGraphics) Then
            MyBitmapGraphics.Clear(Color.White)
        End If

        PicDiagram.Refresh()

    End Sub

    Private Sub CboFunktion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboFunction.SelectedIndexChanged

        'This sets the type of BilliardBall by Reflection

        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(ICDiagramBilliard)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If CboFunction.SelectedIndex >= 0 Then

            Dim SelectedName As String = CboFunction.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If FrmMain.LM.GetString(type.Name, True) = SelectedName Then
                        Iterator = CType(Activator.CreateInstance(type), ICDiagramBilliard)
                    End If
                Next
            End If

        End If

        'Reset ranges and Default Values
        SetDefaultValues()

    End Sub

    Private Sub CboValueRange_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboValueParameter.SelectedIndexChanged

        'The ValueParameter to be investigated
        'Setting not by reference that the original ValueParameter of the Iterator is not changed
        SetMyValueParameterByValue(MyValueParameters.Item(CboValueParameter.SelectedIndex))

        TxtVMin.Text = MyUserValueParameter.Range.A.ToString(CultureInfo.CurrentCulture)
        TxtVMax.Text = MyUserValueParameter.Range.B.ToString(CultureInfo.CurrentCulture)
        LblDeltaV.Text = FrmMain.LM.GetString("Delta") & " = " & MyUserValueParameter.Range.IntervalWidth.ToString(CultureInfo.CurrentCulture)

    End Sub

    Private Sub TrbPrecision_ValueChanged(sender As Object, e As EventArgs) Handles TrbPrecision.ValueChanged

        'The precision defines how precise the diagram is generated
        LblPrecision.Text = FrmMain.LM.GetString("Precision") & ": " & (1000 * TrbPrecision.Value).ToString(CultureInfo.CurrentCulture)

    End Sub

    Private Sub TrbPositionStartValues_ValueChanged(sender As Object, e As EventArgs) Handles TrbPositionStartValues.ValueChanged

        'The position of the start values is a number "pos" between 1 and 11
        'each startvalue is then set = ValueRange.A + pos * ValueRange.IntervalWidth / 120
        LblStartValues.Text = FrmMain.LM.GetString("PositionStartValue2") &
            TrbPositionStartValues.Value.ToString(CultureInfo.CurrentCulture) & "/120"

    End Sub

    'SECTOR ITERATION

    Private Sub BtnStartIteration_Click(sender As Object, e As EventArgs) Handles BtnStartIteration.Click

        BtnStartIteration.Enabled = False
        BtnReset.Enabled = False

        'Check and set the Ranges, defined by the user
        CheckUserRanges()

        If IsUserSelectionValid Then

            MyBitmapGraphics.Clear(Color.White)

            'In the direction of the x-axis, we work with pixel coordinates
            Dim p As Integer

            For p = 1 To PicDiagram.Width

                'for each p, the according paranmetervalue C is calculated
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
            'there is already a message generated
        End If

        BtnStartIteration.Enabled = True
        BtnReset.Enabled = True

    End Sub

    Private Sub DrawIterationValues(p As Integer)

        'Calculate the parameter C for the iteration depending on p
        Dim C As Decimal = MyParameterRange.A + (MyParameterRange.IntervalWidth * p / PicDiagram.Width)
        Iterator.CParameter = C

        'Setting the Start-Parameterpair for the Iteration

        'The Startpoint has to be the same for all Values of C to avoid side effects
        Dim V1 As Decimal = MyValueParameters.Item(0).Range.A + MyValueParameters.Item(0).Range.IntervalWidth / 3

        '.. and the second value depending on TrbPositionStartValues
        Dim V2 As Decimal = MyValueParameters.Item(1).Range.A + TrbPositionStartValues.Value * MyValueParameters.Item(1).Range.IntervalWidth / 120

        MyParameterPair = New ClsValuePair(V1, V2)

        Dim NextPair As ClsValuePair

        'After that, the number of iterations must be big enough before drawing the cycle
        Dim LengthOfCycle As Integer = CInt(PicDiagram.Height * MyUserValueParameter.Range.IntervalWidth _
            * TrbPrecision.Value / 25 / Math.Max(MyUserValueParameter.Range.IntervalWidth, 0.01))

        '..but not bigger than the y-axis allows
        LengthOfCycle = Math.Min(LengthOfCycle, 5 * PicDiagram.Height)

        'Finally , the cycle is drawn

        Dim DrawPoint As New ClsMathpoint(C, 0)

        For n = 0 To LengthOfCycle

            Select Case MyUserValueParameter.Tag
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

    Private Sub PicDiagram_MouseDown(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseDown

        'The user can choose a range by a flexible rectangle
        IsMousedown = True

        'e guarantees, that the mouse position is relative to PicDiagram
        'and the Startpoint is the position, where the left mouse button was first pushed down
        UserSelectionStartpoint = e.Location

    End Sub

    Private Sub PicDiagram_MouseMove(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseMove

        If IsMousedown Then

            'the endpoint is on the actual mouse position
            UserSelectionEndpoint = e.Location

            'this refreshing launches the paint-event of e and the selection-rectangle is drawn
            'in the actual position
            PicDiagram.Refresh()

        End If

    End Sub

    Private Sub PicDiagram_Paint(sender As Object, e As PaintEventArgs) Handles PicDiagram.Paint

        If IsMousedown Then

            'the selection-rectangle is dranw in its actual position
            Dim rect As New Rectangle(Math.Min(UserSelectionStartpoint.X, UserSelectionEndpoint.X), Math.Min(UserSelectionStartpoint.Y, UserSelectionEndpoint.Y),
                                      Math.Abs(UserSelectionStartpoint.X - UserSelectionEndpoint.X), Math.Abs(UserSelectionStartpoint.Y - UserSelectionEndpoint.Y))
            Using MyPen As New Pen(Color.Red, 2)
                e.Graphics.DrawRectangle(MyPen, rect)
            End Using

        End If

    End Sub

    Private Sub PicDiagram_MouseUp(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseUp

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
            TxtVMin.Text = Math.Max(PixelToX(qMin), MyUserValueParameter.Range.A).ToString(CultureInfo.CurrentCulture)
            TxtVMax.Text = Math.Min(PixelToX(qMax), MyUserValueParameter.Range.B).ToString(CultureInfo.CurrentCulture)
            LblDeltaV.Text = "Delta = " & (PixelToX(qMax) - PixelToX(qMin)).ToString(CultureInfo.CurrentCulture)

        End If
    End Sub

    'SECTOR TRANSFORMATION OF USER RANGES

    Private Function PixelToA(p As Integer) As Decimal

        'calculates the parametervalue C according to 
        Dim C As Decimal = MyParameterRange.A + ((p - 1) * MyParameterRange.IntervalWidth / PicDiagram.Width)
        Return C

    End Function

    Private Function PixelToX(q As Integer) As Decimal

        'calculates the x-value that belongs to a q-pixel coordinate in y-axis direction
        Dim x As Decimal = CDec(MyUserValueParameter.Range.A + (q * MyUserValueParameter.Range.IntervalWidth / (PicDiagram.Height * 0.99)))

        Return x

    End Function

    'CHECK USER RANGES AND SET PARAMETER AND VALUE INTERVAL

    Private Sub CheckUserRanges()

        'The parameter range has to be part of the allowed interval for the parameter C
        'depending of the type of iteration
        Dim CheckParameterrange As New ClsCheckIsInterval(TxtCMin, TxtCMax)
        Dim IsParameterrangeValid As Boolean

        'The interval borders have to be numeric and a < b
        If CheckParameterrange.IsIntervalValid Then

            'if [a,b] is an interval, then the parameter interval is constructed
            Dim TempParameterrange = New ClsInterval(CheckParameterrange.A, CheckParameterrange.B)

            'is the parameter range part of the allowed parameter interval?
            If Iterator.CParameterRange.IsInterval2PartOfInterval(TempParameterrange) Then
                IsParameterrangeValid = True
                'take over
                MyParameterRange = TempParameterrange
            Else
                MessageBox.Show(FrmMain.LM.GetString("ParameterRangeNotAllowed") & " [" &
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
                    MyUserValueParameter.Range = TempValuerange
                Else
                    MessageBox.Show(FrmMain.LM.GetString("ParameterRangeNotAllowed") & " [" &
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
            LblDeltaC.Text = FrmMain.LM.GetString("Delta") & " = " & MyParameterRange.IntervalWidth.ToString(CultureInfo.CurrentCulture)
            LblDeltaV.Text = FrmMain.LM.GetString("Delta") & " = " & MyUserValueParameter.Range.IntervalWidth.ToString(CultureInfo.CurrentCulture)
            MyBitmapGraphics = New ClsGraphicTool(CDiagram, MyParameterRange, MyUserValueParameter.Range)
        Else
            'nothing
        End If

    End Sub

End Class
