'This is the class for the Universe
'that follows Newtons law of Gravity
'but in a normed universe: MassUnit = 1, Position in [-1,1]x[-1.5,1.5]
'G = 1, vx, vy in [-1,1]
'and that is approximated by Runge Kutta 4

'Status Checked

Public Class ClsNormedUniverse
    Inherits ClsUniverseAbstract

    Private IA1 As ClsConstellation
    Private IA2 As ClsConstellation
    Private IA3 As ClsConstellation
    Private IB1 As ClsConstellation
    Private IB2 As ClsConstellation
    Private IIC1 As ClsConstellation
    Private ParameterTupel As ClsVector

    Public Sub New()
        'Here are the defninitions of all ranges of the star-parameters
        ParameterTupel = New ClsVector

        MathInterval = New ClsInterval(-2, 2)
        MyPositionParameterDefinition = New ClsGeneralParameter(1, "Position",
                    New ClsInterval(-2, 2), ClsGeneralParameter.TypeOfParameterEnum.Variable)
        MyVelocityParameterDefinition = New ClsGeneralParameter(2, "Velocity",
                    New ClsInterval(-1, 1), ClsGeneralParameter.TypeOfParameterEnum.Variable)
        MyMassParameterDefinition = New ClsGeneralParameter(3, "Mass",
                    New ClsInterval(CDec(0.5), CDec(2)), ClsGeneralParameter.TypeOfParameterEnum.Variable)

        MyMaxZoom = CDec(1.5)

        IA1 = New ClsConstellation
        IA2 = New ClsConstellation
        IA3 = New ClsConstellation
        IB1 = New ClsConstellation
        IB2 = New ClsConstellation
        IIC1 = New ClsConstellation

    End Sub

    Protected Overrides Property PicDiagram As PictureBox
        Get
            PicDiagram = MyPicDiagram
        End Get
        Set(value As PictureBox)
            MyPicDiagram = value
            Dim PicDiagramSize As Integer = Math.Min(MyPicDiagram.Width, MyPicDiagram.Height)
            MyPicDiagram.Width = PicDiagramSize
            MyPicDiagram.Height = PicDiagramSize
            MyPicGraphics = New ClsGraphicTool(MyPicDiagram, MathInterval, MathInterval)
            MyBmpDiagram = New Bitmap(PicDiagramSize, PicDiagramSize)
            MyPicDiagram.Image = MyBmpDiagram
            MyBmpGraphics = New ClsGraphicTool(MyBmpDiagram, MathInterval, MathInterval)
        End Set
    End Property

    Protected Overrides Property PicPhasePortrait As PictureBox
        Get
            PicPhasePortrait = MyPicPhasePortrait
        End Get
        Set(value As PictureBox)
            MyPicPhasePortrait = value
            Dim Squareside As Integer = Math.Min(MyPicPhasePortrait.Width, MyPicPhasePortrait.Height)
            MyPicPhasePortrait.Width = Squareside
            MyPicPhasePortrait.Height = Squareside
            MyPicPhasePortraitGraphics = New ClsGraphicTool(MyPicPhasePortrait, New ClsInterval(0, 2),
                       New ClsInterval(0, 10))
        End Set
    End Property

    Protected Overrides Sub CreateConstellations()

        IA1.Name = "IA1"
        IA1.ProposedStepWidth = CDec(0.01)
        IA1.VFactor = 100
        IA2.Name = "IA2"
        IA2.ProposedStepWidth = CDec(0.01)
        IA2.VFactor = 100
        IA3.Name = "IA3"
        IA3.ProposedStepWidth = CDec(0.01)
        IA3.VFactor = 100
        IB1.Name = "IB1"
        IB1.ProposedStepWidth = CDec(0.01)
        IB1.VFactor = 100
        IB2.Name = "IB2"
        IB2.ProposedStepWidth = CDec(0.01)
        IB2.VFactor = 100
        IIC1.Name = "IIC1"
        IIC1.ProposedStepWidth = CDec(0.01)
        IIC1.VFactor = 100

        FillConstellation(IA1)
        FillConstellation(IA2)
        FillConstellation(IA3)
        FillConstellation(IB1)
        FillConstellation(IB2)
        FillConstellation(IIC1)
        With MyConstellations
            .Add(IA1)
            .Add(IA2)
            .Add(IA3)
            .Add(IB1)
            .Add(IB2)
            .Add(IIC1)
        End With
    End Sub

    Private Sub FillConstellation(LocConstellation As ClsConstellation)

        Dim Star1 As New ClsNormedStar
        With Star1
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Star") & " 1"
            .StarColor = Brushes.LightBlue
            .OriginalMass = 1
            .Size = 2
            'Position
            ParameterTupel.X = -1
            ParameterTupel.Y = 0
            .OriginalStartPosition.Equal(ParameterTupel)
            .UserStartPosition.Equal(ParameterTupel)
            .ActualPosition.Equal(ParameterTupel)
            'Velocity
            Select Case True
                Case LocConstellation Is IA1
                    ParameterTupel.X = CDec(0.3471168881 * .Tau)
                    ParameterTupel.Y = CDec(0.5327249454 * .Tau)
                    IA1.AddStar(Star1)
                Case LocConstellation Is IA2
                    ParameterTupel.X = CDec(0.3068934205 * .Tau)
                    ParameterTupel.Y = CDec(0.125506567 * .Tau)
                    IA2.AddStar(Star1)
                Case LocConstellation Is IA3
                    ParameterTupel.X = CDec(0.6150407229 * .Tau)
                    ParameterTupel.Y = CDec(0.5226158545 * .Tau)
                    IA3.AddStar(Star1)
                Case LocConstellation Is IB1
                    ParameterTupel.X = CDec(0.4644451728 * .Tau)
                    ParameterTupel.Y = CDec(0.3960600146 * .Tau)
                    IB1.AddStar(Star1)
                Case LocConstellation Is IB2
                    ParameterTupel.X = CDec(0.4059155671 * .Tau)
                    ParameterTupel.Y = CDec(0.230163126 * .Tau)
                    IB2.AddStar(Star1)
                Case Else 'IIC1
                    ParameterTupel.X = CDec(0.2827020949 * .Tau)
                    ParameterTupel.Y = CDec(0.3272089716 * .Tau)
                    IIC1.AddStar(Star1)
            End Select
            .OriginalStartVelocity.Equal(ParameterTupel)
            .UserStartVelocity.Equal(ParameterTupel)
            .ActualVelocity.Equals(ParameterTupel)
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDec(0.01)
        End With

        Dim Star2 As New ClsNormedStar
        With Star2
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Star") & " 2"
            .StarColor = Brushes.Red
            .OriginalMass = 1
            .Size = 2
            'Position
            ParameterTupel.X = 1
            ParameterTupel.Y = 0
            .OriginalStartPosition.Equal(ParameterTupel)
            .UserStartPosition.Equal(ParameterTupel)
            .ActualPosition.Equal(ParameterTupel)
            'Velocity
            Select Case True
                Case LocConstellation Is IA1
                    ParameterTupel.X = CDec(0.3471168881 * .Tau)
                    ParameterTupel.Y = CDec(0.5327249454 * .Tau)
                    IA1.AddStar(Star2)
                Case LocConstellation Is IA2
                    ParameterTupel.X = CDec(0.3068934205 * .Tau)
                    ParameterTupel.Y = CDec(0.125506567 * .Tau)
                    IA2.AddStar(Star2)
                Case LocConstellation Is IA3
                    ParameterTupel.X = CDec(0.6150407229 * .Tau)
                    ParameterTupel.Y = CDec(0.5226158545 * .Tau)
                    IA3.AddStar(Star2)
                Case LocConstellation Is IB1
                    ParameterTupel.X = CDec(0.4644451728 * .Tau)
                    ParameterTupel.Y = CDec(0.3960600146 * .Tau)
                    IB1.AddStar(Star2)
                Case LocConstellation Is IB2
                    ParameterTupel.X = CDec(0.4059155671 * .Tau)
                    ParameterTupel.Y = CDec(0.230163126 * .Tau)
                    IB2.AddStar(Star2)
                Case Else 'IB156
                    ParameterTupel.X = CDec(0.2827020949 * .Tau)
                    ParameterTupel.Y = CDec(0.3272089716 * .Tau)
                    IIC1.AddStar(Star2)
            End Select
            .OriginalStartVelocity.Equal(ParameterTupel)
            .UserStartVelocity.Equal(ParameterTupel)
            .ActualVelocity.Equals(ParameterTupel)
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDec(0.01)
        End With

        Dim Star3 As New ClsNormedStar
        With Star3
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Star") & " 3"
            .StarColor = Brushes.Gold
            .OriginalMass = 1
            .Size = 2
            'Position
            ParameterTupel.X = 0
            ParameterTupel.Y = 0
            .OriginalStartPosition.Equal(ParameterTupel)
            .UserStartPosition.Equal(ParameterTupel)
            .ActualPosition.Equal(ParameterTupel)
            'Velocity
            Select Case True
                Case LocConstellation Is IA1
                    ParameterTupel.X = CDec(-2 * 0.3471168881 * .Tau)
                    ParameterTupel.Y = CDec(-2 * 0.5327249454 * .Tau)
                    IA1.AddStar(Star3)
                Case LocConstellation Is IA2
                    ParameterTupel.X = CDec(-2 * 0.3068934205 * .Tau)
                    ParameterTupel.Y = CDec(-2 * 0.125506567 * .Tau)
                    IA2.AddStar(Star3)
                Case LocConstellation Is IA3
                    ParameterTupel.X = CDec(-2 * 0.6150407229 * .Tau)
                    ParameterTupel.Y = CDec(-2 * 0.5226158545 * .Tau)
                    IA3.AddStar(Star3)
                Case LocConstellation Is IB1
                    ParameterTupel.X = CDec(-2 * 0.4644451728 * .Tau)
                    ParameterTupel.Y = CDec(-2 * 0.3960600146 * .Tau)
                    IB1.AddStar(Star3)
                Case LocConstellation Is IB2
                    ParameterTupel.X = CDec(-2 * 0.4059155671 * .Tau)
                    ParameterTupel.Y = CDec(-2 * 0.230163126 * .Tau)
                    IB2.AddStar(Star3)
                Case Else 'IB156
                    ParameterTupel.X = CDec(-2 * 0.2827020949 * .Tau)
                    ParameterTupel.Y = CDec(-2 * 0.3272089716 * .Tau)
                    IIC1.AddStar(Star3)
            End Select
            .OriginalStartVelocity.Equal(ParameterTupel)
            .UserStartVelocity.Equal(ParameterTupel)
            .ActualVelocity.Equals(ParameterTupel)
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDec(0.01)
        End With

    End Sub

    Protected Overrides Function GetNewStar(Name As String) As IStar

        Dim NewStar As New ClsNewtonStar

        For Each aStar As IStar In MyActiveConstellation.Stars
            If aStar.Name = Name Then
                With NewStar
                    .PicDiagram = aStar.PicDiagram
                    .PicGraphics = aStar.PicGraphics
                    .BmpDiagram = aStar.BmpDiagram
                    .BmpGraphics = aStar.BmpGraphics
                    .PicPhasePortrait = aStar.PicPhaseportrait
                    .PicPhasePortraitGraphics = aStar.PicPhasePortraitGraphics
                    .Name = aStar.Name
                    .Size = aStar.Size
                    .StarColor = aStar.StarColor
                    .OriginalMass = aStar.OriginalMass
                    .OriginalStartPosition.Equal(aStar.OriginalStartPosition)
                    .UserStartPosition.Equal(aStar.UserStartPosition)
                    .ActualPosition.Equal(aStar.ActualPosition)
                    .OriginalStartVelocity.Equal(aStar.OriginalStartVelocity)
                    .UserStartVelocity.Equal(aStar.UserStartVelocity)
                    .ActualVelocity.Equal(aStar.ActualVelocity)
                    .SetDefaultUserData()
                    .Universe = Me
                    .ProposedStepWidth = aStar.ProposedStepWidth
                End With
                Exit For
            End If
        Next

        Return NewStar
    End Function

End Class
