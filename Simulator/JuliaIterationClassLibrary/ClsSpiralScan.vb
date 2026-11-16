'This class goes through the pixels of a diagram in a spiral starting in the midpoint
'It is used by ClsJuliaController and ClsMandelbrotMapController
'Every picture has its own instance, so two pictures do not share the spiral

'A pixel (p, q) is drawn as 2 x 2 point at (p - 1, q - 1), that is into the bitmap pixels (p - 1, q) and (p, q)
'The spiral continues until every bitmap pixel was computed
'(before, it stopped when p or q left the diagram: for an odd size the top row stayed white)
'Pixels outside the bitmap are skipped

Public Class ClsSpiralScan

    Private ReadOnly Spiral As IEnumerator(Of Point)

    Public Sub New(Width As Integer, Height As Integer)
        Spiral = Pixels(Width, Height).GetEnumerator()
    End Sub

    'Returns the next pixel of the spiral; False if all pixels are computed
    Public Function NextPixel(ByRef PixelPoint As Point) As Boolean
        If Spiral.MoveNext() Then
            PixelPoint = Spiral.Current
            Return True
        Else
            Return False
        End If
    End Function

    Private Shared Iterator Function Pixels(Width As Integer, Height As Integer) As IEnumerable(Of Point)

        Dim Remaining As Integer = Width * Height

        For Each Pixel As Point In EndlessSpiral(Width, Height)

            'Bitmap position of the pixel (p, q) is (p - 1, q)
            If Pixel.X - 1 >= 0 And Pixel.X - 1 < Width And Pixel.Y >= 0 And Pixel.Y < Height Then
                Yield Pixel
                Remaining -= 1
                If Remaining = 0 Then
                    Return
                End If
            End If
        Next

    End Function

    Private Shared Iterator Function EndlessSpiral(Width As Integer, Height As Integer) As IEnumerable(Of Point)

        Dim p As Integer = CInt(Width / 2)
        Dim q As Integer = CInt(Height / 2)
        Yield New Point(p, q)

        Dim ExaminatedPoints As Integer = 0

        'Length of a branch of the spiral
        Dim L As Integer = 0

        'Sig = 1 if ExaminatedPoints is odd, = -1 else
        Dim Sig As Integer

        Do
            ExaminatedPoints += 1
            Sig = If(ExaminatedPoints Mod 2 = 0, -1, 1)
            L += 1

            For k As Integer = 1 To L - 1
                p += Sig
                Yield New Point(p, q)
            Next

            For k As Integer = 1 To L - 1
                q += Sig
                Yield New Point(p, q)
            Next
        Loop

    End Function

End Class
