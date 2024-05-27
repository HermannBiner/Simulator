'This class offers a list of colors
'that can serve as colors of different basins
'of attractive points
'the order of the colors is to support nice images

'Status Checked


Public Class ClsBasinColors

    'Prepare Brushlist
    Private BrushList(12) As Brush

    Public Sub New()
        BrushList(1) = Brushes.Red
        BrushList(2) = Brushes.Blue
        BrushList(3) = Brushes.Green
        BrushList(4) = Brushes.Yellow
        BrushList(5) = Brushes.Salmon
        BrushList(6) = Brushes.SkyBlue
        BrushList(7) = Brushes.Gold
        BrushList(8) = Brushes.Lime
        BrushList(9) = Brushes.DarkOrange
        BrushList(10) = Brushes.Aqua
        BrushList(11) = Brushes.Magenta
        BrushList(12) = Brushes.SpringGreen
    End Sub

    Public Function GetColor(i As Integer) As Brush
        Return BrushList(i)
    End Function

End Class
