'This class provides the Standard System Brushes
'they are used e.g. to color Julia or Mandelbrot sets

'Status Checked

Public Class ClsSystemBrushes

    Private MyMaxSteps As Integer

    Public Sub New(MaxSteps As Integer)
        MyMaxSteps = MaxSteps
    End Sub

    Public Function GetSystemBrush(Steps As Integer) As Brush

        'Version explicitely programmed
        Dim LocBrush As Brush
        Const ColorNumber As Integer = 25

        Dim RedPart As Double
        Dim GreenPart As Double
        Dim BluePart As Double

        'To increase the brightness
        Dim Increase As Integer = 3

        Dim ScaledSteps As Integer
        ScaledSteps = Math.Min(CInt(Steps * ColorNumber * Increase / MyMaxSteps), MyMaxSteps)


        'Set RedPart
        Select Case ScaledSteps
            Case >= 14, 6, 7, 8, 9
                RedPart = 1
            Case 4, 5, 12, 13
                RedPart = 0.5
            Case Else
                RedPart = 0
        End Select

        'Set GreenPart
        Select Case ScaledSteps
            Case >= 20, 2, 3, 10, 11, 12, 13
                GreenPart = 1
            Case 1, 8, 9
                GreenPart = 0.5
            Case Else
                GreenPart = 0
        End Select

        'Set BluePart
        Select Case ScaledSteps
            Case <= 9, 24, 25
                BluePart = 1
            Case 14, 15, 22, 23
                BluePart = 0.5
            Case Else
                BluePart = 0
        End Select

        LocBrush = New SolidBrush(Color.FromArgb(CInt(RedPart * 255),
                                                 CInt(GreenPart * 255), CInt(BluePart * 255)))

        Return LocBrush

    End Function

End Class
