
'This class contains the iteration controller for FrmIteration

'Status Redesign Tested

Imports System.Globalization

Public Class ClsIterationController

    'The dynamic System
    Private MyDS As IIteration

    'The PicDiagram
    Private MyPicDiagram As PictureBox
    Private MyPicDiagramSize As Integer

    'The Graphic Helper for PicDiagram
    Private MyPicGraphics As ClsGraphicTool

    'Math Helper
    Private Mathhelper As New ClsMathhelperUnimodal

    'Actual value of the iteration
    Private MyX As Decimal

    'Calculated Startvalue
    Private MyCalculatedStartvalue As TextBox

    'Target value for the Iteration
    Private MyTargetValue As Decimal
    Private MyTargetProtocol As String
    Private MyTxtStartValue As TextBox
    'How is the protocol defined
    Private SignProtocol As Decimal

    'Status Parameters
    'Number of Iteration Steps
    Private n As Integer
    Private MyLblN As Label
    Private MyIterationStatus As ClsGeneral.EnIterationStatus
    Private MyValueList As ListBox
    Private MyProtocol As ListBox

    'X-Stretching: the x-axis can be stretched
    Private MyXStretching As Integer

    'Presentation in FrmIteration
    Public Enum PresentationEnum

        'The iteration is shown on the graph of the function
        Functionsgraph

        'The iteration is shown on the time-axis
        'the iteration steps increases on that X-axis and the iteration value is on the Y-axis
        TimeAxis

    End Enum

    Private MyPresentation As PresentationEnum

    WriteOnly Property DS As IIteration
        Set(value As IIteration)
            MyDS = value
        End Set
    End Property

    WriteOnly Property PicDiagram As PictureBox
        Set(value As PictureBox)
            MyPicDiagram = value
            MyPicGraphics = New ClsGraphicTool(MyPicDiagram, MyDS.IterationInterval, MyDS.IterationInterval)
            MyPicDiagramSize = Math.Min(MyPicDiagram.Width, MyPicDiagram.Height)
        End Set
    End Property

    WriteOnly Property StartValue As Decimal
        Set(value As Decimal)
            MyX = value
        End Set
    End Property

    Property IterationStatus As ClsGeneral.EnIterationStatus
        Set(value As ClsGeneral.EnIterationStatus)
            MyIterationStatus = value
        End Set
        Get
            IterationStatus = MyIterationStatus
        End Get
    End Property

    WriteOnly Property LblN As Label
        Set(value As Label)
            MyLblN = value
        End Set
    End Property

    WriteOnly Property XStretching As Integer
        Set(value As Integer)
            MyXStretching = value
        End Set
    End Property

    WriteOnly Property Presentation As PresentationEnum
        Set(value As PresentationEnum)
            MyPresentation = value
        End Set
    End Property

    WriteOnly Property TargetValue As Decimal
        Set(value As Decimal)
            MyTargetValue = value
        End Set
    End Property

    WriteOnly Property ValueList As ListBox
        Set(value As ListBox)
            MyValueList = value
        End Set
    End Property

    WriteOnly Property Protocol As ListBox
        Set(value As ListBox)
            MyProtocol = value
        End Set
    End Property

    WriteOnly Property TargetProtocol As String
        Set(value As String)
            MyTargetProtocol = value
            SignProtocol = Math.Sign(MyDS.ChaoticParameter)
        End Set
    End Property

    WriteOnly Property TxtStartValue As TextBox
        Set(value As TextBox)
            MyTxtStartValue = value
        End Set
    End Property

    Public Sub PrepareDiagram()

        'This method draws the Graph of the Function

        'Draw coordinate system
        MyPicGraphics.DrawCoordinateSystem(New ClsMathpoint(0, 0), Color.Black, 1)

        'Draw the 45° line - needed to show the iteration in the function graph
        MyPicGraphics.DrawLine(New ClsMathpoint(MyDS.IterationInterval.A, MyDS.IterationInterval.A),
                            New ClsMathpoint(MyDS.IterationInterval.B, MyDS.IterationInterval.B),
                            Color.Black, 1)

        'Draw function graph
        'The step-wide in X-direction is:
        Dim deltaX As Decimal = MyDS.IterationInterval.IntervalWidth / MyPicDiagramSize

        'actual mathpoint
        Dim X As New ClsMathpoint

        'next mathpoint
        Dim Xplus As New ClsMathpoint

        'counter
        Dim m As Integer

        'X and XPlus are increased stepwise and the line betweens these points is drawn
        For m = 0 To MyPicDiagramSize - 2

            X.X = MyDS.IterationInterval.A + (m * deltaX)
            X.Y = MyDS.FN(X.X)
            Xplus.X = X.X + deltaX
            Xplus.Y = MyDS.FN(Xplus.X)
            MyPicGraphics.DrawLine(X, Xplus, Color.Blue, 1)

        Next
    End Sub

    Public Sub CalculateStartvalueForProtocol()

        'Calculates a startvalue that produces a given protocol in case of chaotic behaviour
        If Mathhelper.CheckFormatDualzahl(MyTargetProtocol) Then 'Checks the format of the target protocol
            MyTxtStartValue.Text = MyDS.CalculateStartValueForProtocol(MyTargetProtocol).ToString(CultureInfo.CurrentCulture)
        Else
            'There is already an error message generated
        End If

    End Sub

    Public Sub CalculateStartvalueForTargetValue()

        MyTxtStartValue.Text = MyDS.CalculateStartValueForTargetValue(MyX, MyTargetValue).ToString(CultureInfo.CurrentCulture)

    End Sub

    Public Sub IterationLoop(EndOfLoop As Integer)

        'counter for EndOfLoop
        Dim i As Integer = 0

        'Point on the function graph
        Dim P As New ClsMathpoint(MyX, MyDS.FN(MyX))

        'Point on the 45° line
        Dim G As New ClsMathpoint(MyX, MyX)

        Do
            n += 1

            'Transmit the actual iteration value x to the LstValueList
            UpdateListboxes(MyX)

            'Connect the Point G on the 45° line to then Point P on the Function Graph
            MyPicGraphics.DrawLine(G, P, Color.Red, 1)

            'Set the next Point on the 45° Line
            G.X = MyDS.FN(MyX)
            G.Y = G.X

            'Connect the Point P on the Function Graph with G
            MyPicGraphics.DrawLine(P, G, Color.Red, 1)

            'Set the next Iteration Value
            MyX = MyDS.FN(MyX)

            '... and the next Point P
            P.X = MyX
            P.Y = MyDS.FN(MyX)

            i += 1

        Loop Until i >= EndOfLoop

        MyLblN.Text = n.ToString(CultureInfo.CurrentCulture)

    End Sub

    Public Sub ShowFullDiagram()

        'If a Target Value is set, it is already checked while the IsUserDataOK
        'in that case, a horizontal green line is set on the Diagram to mark the target value
        If MyTargetValue <> 0 Then
            Dim A As New ClsMathpoint(MyDS.IterationInterval.A, MyTargetValue)
            Dim B As New ClsMathpoint(MyDS.IterationInterval.B, MyTargetValue)
            MyPicGraphics.DrawLine(A, B, Color.Green, 1)
        End If

        'The variable in x-direction starts at the left interval border
        Dim u As Decimal = MyDS.IterationInterval.A

        'this is the step-wide in x-direction
        Dim deltaU As Decimal = MyDS.IterationInterval.IntervalWidth * MyXStretching / MyPicDiagramSize

        'and there are the two points of the graph to be connented
        Dim P As New ClsMathpoint(u, MyX)
        Dim NextP As New ClsMathpoint(u + deltaU, MyDS.FN(MyX))

        Do
            n += 1

            MyPicGraphics.DrawLine(P, NextP, Color.Red, 1)

            'transmit the actual iteration value to the LstValueList
            UpdateListboxes(MyX)

            'P takes over NextP
            P.X = NextP.X
            P.Y = NextP.Y

            'x and u are iterated
            MyX = MyDS.FN(MyX)
            u += deltaU

            'and NextP is set
            NextP.X = u
            NextP.Y = MyDS.FN(MyX)

        Loop Until u >= MyDS.IterationInterval.B

        MyLblN.Text = n.ToString(CultureInfo.CurrentCulture)

    End Sub

    Private Sub UpdateListboxes(u As Decimal)

        'LstValueList is filled with the actual iteration value
        MyValueList.Items.Add(u.ToString(CultureInfo.CurrentCulture))
        MyValueList.SelectedIndex = MyValueList.Items.Count - 1

        'LstProtocol is filled with the according protocol-value

        If SignProtocol * u < SignProtocol * (MyDS.IterationInterval.A + ((MyDS.IterationInterval.B - MyDS.IterationInterval.A) / 2)) Then
            MyProtocol.Items.Add("0")
        Else
            MyProtocol.Items.Add("1")
        End If

        MyProtocol.SelectedIndex = MyProtocol.Items.Count - 1

    End Sub

    Public Sub ResetIteration()

        'clear display
        MyPicGraphics.Clear(Color.White)
        MyValueList.Items.Clear()
        MyProtocol.Items.Clear()

        'Reset Number of steps
        MyLblN.Text = "0"
        n = 0

        'Clear Statusparameter
        MyIterationStatus = ClsGeneral.EnIterationStatus.Stopped

    End Sub



End Class
