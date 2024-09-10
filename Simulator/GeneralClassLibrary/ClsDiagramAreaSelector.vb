'This class allows to select an area of a PicDiagram
'by using the mouse

Imports System.Globalization

Public Class ClsDiagramAreaSelector

    'PicDiagram from where the selection is done
    Private WithEvents MyPicDiagram As PictureBox

    'Allowed global Ranges
    'they are needed to check if the
    'UserRanges are in these ranges
    Private MyParameterRange As ClsInterval
    Private MyValueRange As ClsInterval

    'Selected UserRanges
    Private MyUserParameterRange As ClsInterval
    Private MyUserValueRange As ClsInterval

    'Result of the Selection
    'A is the Parameter, X is the Iterationvalue
    Private MyTxtParameterMin As TextBox
    Private MyTxtParameterMax As TextBox
    Private MyTxtValueMin As TextBox
    Private MyTxtValueMax As TextBox

    'Mouse Status
    Private IsMouseDown As Boolean

    'Point where the left mouse button was pushed down
    Private UserSelectionStartpoint As Point

    'Point where the left mouse button was released
    Private UserSelectionEndpoint As Point

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

    WriteOnly Property ParameterRange As ClsInterval
        Set(value As ClsInterval)
            MyParameterRange = value
        End Set
    End Property

    WriteOnly Property ValueRange As ClsInterval
        Set(value As ClsInterval)
            MyValueRange = value
        End Set
    End Property

    WriteOnly Property TxtParameterMin As TextBox
        Set(value As TextBox)
            MyTxtParameterMin = value
        End Set
    End Property

    WriteOnly Property TxtParameterMax As TextBox
        Set(value As TextBox)
            MyTxtParameterMax = value
        End Set
    End Property

    WriteOnly Property TxtValueMin As TextBox
        Set(value As TextBox)
            MyTxtValueMin = value
        End Set
    End Property

    WriteOnly Property TxtValueMax As TextBox
        Set(value As TextBox)
            MyTxtValueMax = value
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
                MyTxtParameterMin.Text = Math.Max(PixelToA(pMin), MyParameterRange.A).ToString(CultureInfo.CurrentCulture)
                MyTxtParameterMax.Text = Math.Min(PixelToA(pMax), MyParameterRange.B).ToString(CultureInfo.CurrentCulture)

                'transmit the selection to the value range of x
                MyTxtValueMin.Text = Math.Max(PixelToX(qMin), MyValueRange.A).ToString(CultureInfo.CurrentCulture)
                MyTxtValueMax.Text = Math.Min(PixelToX(qMax), MyValueRange.B).ToString(CultureInfo.CurrentCulture)

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
