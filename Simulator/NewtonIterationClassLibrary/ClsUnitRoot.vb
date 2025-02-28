'This Class represents a root of a complex polynom
'That is a complex number combined with a color defined FromARGB
'This color is as well depending of the #steps
'that the iteration needed to approach the root

'Status Checked

Public Class ClsUnitRoot
    Inherits ClsComplexNumber

    Private ReadOnly MyRedPart As Double
    Private ReadOnly MyGreenPart As Double
    Private ReadOnly MyBluePart As Double

    Public Sub New(Z As ClsComplexNumber, Index As Integer)

        'If a complex number is given when initializing
        MyX = Z.X
        MyY = Z.Y

        'The composition for the base color depending of an index
        'Parts in % of RGB

        'RedPart
        Select Case Index
            Case 1, 4, 6, 9, 10, 11, 12
                MyRedPart = 1
            Case 5, 7
                MyRedPart = 0.5
            Case Else
                MyRedPart = 0
        End Select

        'GreenPart
        Select Case Index
            Case 2, 4, 7, 8, 11
                MyGreenPart = 1
            Case 10, 12
                MyGreenPart = 0.5
            Case Else
                MyGreenPart = 0
        End Select

        'BluePart
        Select Case Index
            Case 3, 5, 8, 9, 12
                MyBluePart = 1
            Case 6, 11
                MyBluePart = 0.5
            Case Else
                MyBluePart = 0
        End Select

    End Sub

    Public Function GetColor(Brightness As Double) As Brush

        'Brightness should be in [0,1]

        Brightness = Math.Min(1, Brightness)
        Brightness = Math.Max(0, Brightness)

        Return New SolidBrush(Color.FromArgb(CInt(Brightness * MyRedPart * 255),
                              CInt(Brightness * MyGreenPart * 255), CInt(Brightness * MyBluePart * 255)))

    End Function

End Class
