'This class contains the iteration controller for FrmSensitivity

'Status Redesign Tested

Imports System.Globalization

Public Class ClsSensitivityController

    'The dynamic System
    Private MyDS As IIteration

    'The PicDiagram
    Private MyPicDiagram As PictureBox

    'The x-axis in the PicDiagram
    Private XRange As ClsInterval

    'The Graphic Helper for PicDiagram
    Private MyPicGraphics As ClsGraphicTool

    'Status Parameters
    'Number of Iteration Steps
    Private n As Integer
    Private MyLblN As Label
    Private MyValueList1 As ListBox
    Private MyValueList2 As ListBox

    'Actual values of the iteration
    Private x1 As Decimal
    Private x2 As Decimal

    'X-Stretching: the x-axis can be stretched
    Private MyXStretching As Integer


    'Presentation in FrmSensitivity
    Public Enum PresentationEnum

        'the diagram shows the difference between the orbits of x1, x2
        Difference
        'The orbits of x1, x2 are shown separately
        SingleOrbits

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
            XRange = New ClsInterval(1, MyPicDiagram.Width)
            MyPicGraphics = New ClsGraphicTool(MyPicDiagram, XRange, MyDS.IterationInterval)
        End Set
    End Property

    WriteOnly Property LblN As Label
        Set(value As Label)
            MyLblN = value
        End Set
    End Property

    WriteOnly Property StartValue1 As Decimal
        Set(value As Decimal)
            x1 = value
        End Set
    End Property

    WriteOnly Property StartValue2 As Decimal
        Set(value As Decimal)
            x2 = value
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

    WriteOnly Property ValueList1 As ListBox
        Set(value As ListBox)
            MyValueList1 = value
        End Set
    End Property

    WriteOnly Property ValueList2 As ListBox
        Set(value As ListBox)
            MyValueList2 = value
        End Set
    End Property

    Public Sub IterationLoop()

        'Both orbits are initialized

        'P1 and NextP1 are the points for the interation of x1 = Startvalue1
        Dim P1 As New ClsMathpoint
        Dim nextP1 As New ClsMathpoint

        'P2 and NextP2 are the points for the interation of x2 = Startvalue2
        Dim P2 As New ClsMathpoint
        Dim nextP2 As New ClsMathpoint

        'This will be the variable of the x-axis
        Dim p As Decimal = 0

        Do

            'P1.X is the coordinate on the x-axis
            'and increased by one pixel*xstretching in each iteration step
            P1.X = p * MyXStretching
            'P1.Y is the y-coordinate and equal to the iteration of x1
            P1.Y = x1

            'similar settings for the next point
            nextP1.X = (p + 1) * MyXStretching
            nextP1.Y = MyDS.FN(x1)

            'and similar for the points P2, NextP2
            'for the iteration of x2
            P2.X = p * MyXStretching
            P2.Y = x2
            nextP2.X = (p + 1) * MyXStretching
            nextP2.Y = MyDS.FN(x1)

            'Increase number of steps
            n += 1

            'transmit the new values to the LstValueList1, 2
            UpdateListboxes(x1, x2)

            'and draw the diagram according to the points
            DrawDiagram(P1, nextP1, P2, nextP2)

            'do the ntext iteration step
            x1 = MyDS.FN(x1)
            x2 = MyDS.FN(x2)
            p += 1

        Loop Until p * MyXStretching >= MyPicDiagram.Width

        MyLblN.Text = n.ToString(CultureInfo.CurrentCulture)

    End Sub

    Private Sub UpdateListboxes(u1 As Decimal, u2 As Decimal)

        'LstValueList1 and 2 are filled with the actual iteration value
        MyValueList1.Items.Add(u1.ToString(CultureInfo.CurrentCulture))
        MyValueList1.SelectedIndex = MyValueList1.Items.Count - 1

        MyValueList2.Items.Add(u2.ToString(CultureInfo.CurrentCulture))
        MyValueList2.SelectedIndex = MyValueList2.Items.Count - 1

    End Sub

    'Overloading if u2 is not relevant
    Private Sub UpdateListboxes(u1 As Decimal)

        UpdateListboxes(u1, -1)

    End Sub

    Private Sub DrawDiagram(P1 As ClsMathpoint, nextP1 As ClsMathpoint, P2 As ClsMathpoint, nextP2 As ClsMathpoint)

        If MyPresentation = PresentationEnum.Difference Then

            'Draw the difference of the orbits: x2 - x1
            Dim D As New ClsMathpoint(P1.X, MyDS.IterationInterval.A + Math.Abs(P2.Y - P1.Y))
            Dim NextD As New ClsMathpoint(nextP1.X, MyDS.IterationInterval.A + Math.Abs(nextP2.Y - nextP1.Y))
            MyPicGraphics.DrawLine(D, NextD, Color.Blue, 1)

        Else

            'Draw the single orbits x1, x2
            MyPicGraphics.DrawLine(P1, nextP1, Color.Red, 1)
            MyPicGraphics.DrawLine(P2, nextP2, Color.Green, 1)

        End If

    End Sub

    Public Sub ResetIteration()

        'clear display
        MyValueList1.Items.Clear()
        MyValueList2.Items.Clear()
        MyPicGraphics.Clear(Color.White)

        'Reset Number of steps
        MyLblN.Text = "0"
        n = 0
    End Sub
End Class
