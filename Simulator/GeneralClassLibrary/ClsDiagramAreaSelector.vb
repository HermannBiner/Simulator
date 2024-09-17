'This class allows to select an area of a PicDiagram
'by using the mouse

'Status Checked

Imports System.Globalization

Public Class ClsDiagramAreaSelector

    'PicDiagram from where the selection is done
    Private WithEvents MyPicDiagram As PictureBox

    'Allowed global Ranges
    'they are needed to check if the
    'UserRanges are in these ranges
    Private MyXRange As ClsInterval
    Private MyYRange As ClsInterval

    'Selected UserRanges
    Private MyUserXRange As ClsInterval
    Private MyUserYRange As ClsInterval

    'Result of the Selection
    'A is the Parameter, X is the Iterationvalue
    Private MyTxtXMin As TextBox
    Private MyTxtXMax As TextBox
    Private MyTxtYMin As TextBox
    Private MyTxtYMax As TextBox

    'Mouse Status
    Private IsMouseDown As Boolean

    'Point where the left mouse button was pushed down
    Private UserSelectionStartpoint As Point

    'Point where the left mouse button was released
    Private UserSelectionEndpoint As Point

    Private MyIsActivated As Boolean

    WriteOnly Property PicDiagram As PictureBox
        Set(value As PictureBox)
            MyPicDiagram = value
            AddHandler MyPicDiagram.MouseDown, AddressOf PicDiagram_MouseDown
            AddHandler MyPicDiagram.MouseMove, AddressOf PicDiagram_MouseMove
            AddHandler MyPicDiagram.Paint, AddressOf PicDiagram_Paint
            AddHandler MyPicDiagram.MouseUp, AddressOf PicDiagram_MouseUp
        End Set
    End Property

    WriteOnly Property UserXRange As ClsInterval
        Set(value As ClsInterval)
            MyUserXRange = value
        End Set
    End Property

    WriteOnly Property UserYRange As ClsInterval
        Set(value As ClsInterval)
            MyUserYRange = value
        End Set
    End Property

    WriteOnly Property XRange As ClsInterval
        Set(value As ClsInterval)
            MyXRange = value
        End Set
    End Property

    WriteOnly Property YRange As ClsInterval
        Set(value As ClsInterval)
            MyYRange = value
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

    WriteOnly Property TxtYMin As TextBox
        Set(value As TextBox)
            MyTxtYMin = value
        End Set
    End Property

    WriteOnly Property TxtYMax As TextBox
        Set(value As TextBox)
            MyTxtYMax = value
        End Set
    End Property

    WriteOnly Property IsActivated As Boolean
        Set(value As Boolean)
            MyIsActivated = value
        End Set
    End Property

    Private Sub PicDiagram_MouseDown(sender As Object, e As MouseEventArgs)

        If MyIsActivated Then
            'The user can choose a range by a flexible rectangle
            IsMouseDown = True

            'e guarantees, that the mouse position is relative to PicDiagram
            'and the Startpoint is the position, where the left mouse button was first pushed down
            UserSelectionStartpoint = e.Location
        End If
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

                'Now, we adjust the interval of p in pixel coordinates. p moves between pMin and pMax
                Dim pMin As Integer = Math.Min(UserSelectionStartpoint.X, UserSelectionEndpoint.X)
                Dim pMax As Integer = Math.Max(UserSelectionStartpoint.X, UserSelectionEndpoint.X)

                'as well, in direction of the y-axis we have to adjust the relevant interval. That is q in Pixelcoordinates.
                Dim qMin As Integer = Math.Min(MyPicDiagram.Height - UserSelectionStartpoint.Y, MyPicDiagram.Height - UserSelectionEndpoint.Y)
                Dim qMax As Integer = Math.Max(MyPicDiagram.Height - UserSelectionStartpoint.Y, MyPicDiagram.Height - UserSelectionEndpoint.Y)

                'convert the selection to the mathematical coordinate x
                MyTxtXMin.Text = Math.Max(PixelToX(pMin), MyXRange.A).ToString(CultureInfo.CurrentCulture)
                MyTxtXMax.Text = Math.Min(PixelToX(pMax), MyXRange.B).ToString(CultureInfo.CurrentCulture)

                'convert the selection to the mathematical coordinate y
                MyTxtYMin.Text = Math.Max(PixelToY(qMin), MyYRange.A).ToString(CultureInfo.CurrentCulture)
                MyTxtYMax.Text = Math.Min(PixelToY(qMax), MyYRange.B).ToString(CultureInfo.CurrentCulture)

            End If
        End If

    End Sub

    Private Function PixelToX(p As Integer) As Decimal

        'calculates the x-parametervalue according to p in x-axis direction
        Dim x As Decimal = MyUserXRange.A + ((p - 1) * MyUserXRange.IntervalWidth / MyPicDiagram.Width)
        Return x

    End Function

    Private Function PixelToY(q As Integer) As Decimal

        'calculates the y-value that belongs to a q-pixel coordinate in y-axis direction
        Dim y As Decimal = CDec(MyUserYRange.A + (q * MyUserYRange.IntervalWidth / (MyPicDiagram.Height * 0.99)))

        Return y

    End Function

End Class
