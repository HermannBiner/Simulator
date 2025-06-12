'This class contains a list of colors

'Status Checked

Public Class ClsColorList

    Private MyColors As Dictionary(Of Integer, Brush)

    ReadOnly Property Colors As Dictionary(Of Integer, Brush)
        Get
            Return MyColors
        End Get
    End Property

    Public Sub New()

        'The ID Number of the Color is the same as the index in the Combobox
        MyColors = New Dictionary(Of Integer, Brush) From {
            {0, Brushes.Black},
            {1, Brushes.Brown},
            {2, Brushes.Red},
            {3, Brushes.Tomato},
            {4, Brushes.BurlyWood},
            {5, Brushes.Orange},
            {6, Brushes.Goldenrod},
            {7, Brushes.Gold},
            {8, Brushes.Olive},
            {9, Brushes.Yellow},
            {10, Brushes.OliveDrab},
            {11, Brushes.GreenYellow},
            {12, Brushes.ForestGreen},
            {13, Brushes.Lime},
            {14, Brushes.Turquoise},
            {15, Brushes.Aqua},
            {16, Brushes.DeepSkyBlue},
            {17, Brushes.SteelBlue},
            {18, Brushes.DodgerBlue},
            {19, Brushes.Navy},
            {20, Brushes.Blue},
            {21, Brushes.BlueViolet},
            {22, Brushes.Violet},
            {23, Brushes.Purple},
            {24, Brushes.Magenta},
            {25, Brushes.DeepPink}
        }
    End Sub

    Public Function GetColor(Key As Integer) As SolidBrush
        Return CType(Colors(Key), SolidBrush)
    End Function

End Class
