'This class allows to select an area of a PicDiagram
'by using the mouse

Imports System.Globalization

Public Class ClsDiagramAreaSelector

    'For allowed Parameterranges and Valueranges
    Private MyDS As IIteration

    'PicDiagram from where the selection is done
    Private WithEvents MyPicDiagram As PictureBox

    'Selected UserRanges
    Private MyUserParameterRange As ClsInterval
    Private MyUserValueRange As ClsInterval

    'Result of the Selection
    'A is the Parameter, X is the Iterationvalue
    Private MyTxtAMin As TextBox
    Private MyTxtAMax As TextBox
    Private MyTxtXMin As TextBox
    Private MyTxtXMax As TextBox

    'Mouse Status
    Private IsMouseDown As Boolean

    'Point where the left mouse button was pushed down
    Private UserSelectionStartpoint As Point

    'Point where the left mouse button was released
    Private UserSelectionEndpoint As Point

    WriteOnly Property DS As IIteration
        Set(value As IIteration)
            MyDS = value
        End Set
    End Property

    WriteOnly Property PicDiagram As PictureBox
        Set(value As PictureBox)
            MyPicDiagram = value
            AddHandler MyPicDiagram.MouseDown, AddressOf PicDiagram_MouseDown
            AddHandler MyPicDiagram.MouseMove, AddressOf PicDiagram_MouseMove
            AddHandler MyPicDiagram.Paint, AddressOf PicDiagram_Paint
            AddHandler MyPicDiagram.MouseUp, AddressOf PicDiagram_MouseUp
        End Set
    End Property

    WriteOnly Property UserParameterRange As ClsInterval
        Set(value As ClsInterval)
            MyUserParameterRange = value
        End Set
    End Property

    WriteOnly Property UserValueRange As ClsInterval
        Set(value As ClsInterval)
            MyUserValueRange = value
        End Set
    End Property

    WriteOnly Property TxtAMin As TextBox
        Set(value As TextBox)
            MyTxtAMin = value
        End Set
    End Property

    WriteOnly Property TxtAMax As TextBox
        Set(value As TextBox)
            MyTxtAMax = value
        End Set
    End Property

    WriteOnly Property TxtXMin As TextBox
        Set(value As TextBox)
            MyTxtXMin = value
        End Set
    End Property

    WriteOnly Property TxtXMax As TextBox
        Set(value As TextBox)
            MyTxtXMax = value
        End Set
    End Property

    Private Sub PicDiagram_MouseDown(sender As Object, e As MouseEventArgs)

        'The user can choose a range by a flexible rectangle
        IsMouseDown = True

        'e guarantees, that the mouse position is relative to PicDiagram
        'and the Startpoint is the position, where the left mouse button was first pushed down
        UserSelectionStartpoint = e.Location

    End Sub

    Private Sub PicDiagram_MouseMove(sender As Object, e As MouseEventArgs)

        If IsMouseDown Then

            'the endpoint is on the actual mouse position
            UserSelectionEndpoint = e.Location

            'this refreshing launches the paint-event of e and the selection-rectangle is drawn
            'in the actual position
            MyPicDiagram.Refresh()

        End If

    End Sub

    Private Sub PicDiagram_Paint(sender As Object, e As PaintEventArgs)

        If IsMouseDown Then

            'the selection-rectangle is drawn in its actual position
            Dim rect As New Rectangle(Math.Min(UserSelectionStartpoint.X, UserSelectionEndpoint.X), Math.Min(UserSelectionStartpoint.Y, UserSelectionEndpoint.Y),
                                      Math.Abs(UserSelectionStartpoint.X - UserSelectionEndpoint.X), Math.Abs(UserSelectionStartpoint.Y - UserSelectionEndpoint.Y))
            Using MyPen As New Pen(Color.Red, 2)
                e.Graphics.DrawRectangle(MyPen, rect)
            End Using

        End If

    End Sub

    Private Sub PicDiagram_MouseUp(sender As Object, e As MouseEventArgs)

        If IsMouseDown Then
            IsMouseDown = False

            'Now, the final EndPoint is set on the position, where the mouse button was released
            UserSelectionEndpoint = e.Location

            'We have to check, if the selection-rectangle shows a valid selection
            If UserSelectionStartpoint <> UserSelectionEndpoint Then

                'The selection is OK

                'Now, we adjust the interval of p. p moves between pMin and pMax
                Dim pMin As Integer = Math.Min(UserSelectionStartpoint.X, UserSelectionEndpoint.X)
                Dim pMax As Integer = Math.Max(UserSelectionStartpoint.X, UserSelectionEndpoint.X)

                'as well, in direction of the y-axis we have to adjust the relevant interval
                Dim qMin As Integer = Math.Min(MyPicDiagram.Height - UserSelectionStartpoint.Y, MyPicDiagram.Height - UserSelectionEndpoint.Y)
                Dim qMax As Integer = Math.Max(MyPicDiagram.Height - UserSelectionStartpoint.Y, MyPicDiagram.Height - UserSelectionEndpoint.Y)

                'transmit the selection to the parameter range
                MyTxtAMin.Text = Math.Max(PixelToA(pMin), MyDS.ParameterInterval.A).ToString(CultureInfo.CurrentCulture)
                MyTxtAMax.Text = Math.Min(PixelToA(pMax), MyDS.ParameterInterval.B).ToString(CultureInfo.CurrentCulture)

                'transmit the selection to the value range of x
                MyTxtXMin.Text = Math.Max(PixelToX(qMin), MyDS.IterationInterval.A).ToString(CultureInfo.CurrentCulture)
                MyTxtXMax.Text = Math.Min(PixelToX(qMax), MyDS.IterationInterval.B).ToString(CultureInfo.CurrentCulture)

            End If
        End If

    End Sub

    Private Function PixelToA(p As Integer) As Decimal

        'calculates the parametervalue a according to p
        Dim a As Decimal = MyUserParameterRange.A + ((p - 1) * MyUserParameterRange.IntervalWidth / MyPicDiagram.Width)
        Return a

    End Function

    Private Function PixelToX(q As Integer) As Decimal

        'calculates the x-value that belongs to a q-pixel coordinate in y-axis direction
        Dim x As Decimal = CDec(MyUserValueRange.A + (q * MyUserValueRange.IntervalWidth / (MyPicDiagram.Height * 0.99)))

        Return x

    End Function

End Class
