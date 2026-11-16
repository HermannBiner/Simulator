'This is the class for the Universe
'that follows Newtons law of Gravity
'and that is approximated by Runge Kutta 4

'Status Checked

Public Class ClsNewtonUniverse
    Inherits ClsUniverseAbstract

    Private OurPlanetSystem As ClsStarConstellation
    Private OurPlanetSystemDisturbed As ClsStarConstellation
    Private InnerPlanets As ClsStarConstellation
    Private InnerPlanetsDisturbed As ClsStarConstellation
    Private ThreeSymmetricBodies As ClsStarConstellation
    Private ThreeSymmetricBodiesDisturbed As ClsStarConstellation
    Private FourSymmetricBodies As ClsStarConstellation
    Private FourSymmetricBodiesDisturbed As ClsStarConstellation
    Private SixSymmetricBodies As ClsStarConstellation
    Private SixSymmetricBodiesDisturbed As ClsStarConstellation
    Private Netflix3Body As ClsStarConstellation

    Public Sub New()
        'Here are the defninitions of all ranges of the star-parameters

        Mathinterval = New ClsInterval(-32, 32)

        MyPositionParameter = New ClsGeneralParameter(1, "Position",
                  New ClsInterval(-32, 32), ClsGeneralParameter.TypeOfParameterEnum.Variable)
        MyVelocityParameter = New ClsGeneralParameter(2, "Velocity",
                  New ClsInterval(-1, 1), ClsGeneralParameter.TypeOfParameterEnum.Variable)
        MyMassParameter = New ClsGeneralParameter(3, "Mass",
                  New ClsInterval(CDbl(0.05), CDbl(500000)), ClsGeneralParameter.TypeOfParameterEnum.Variable)

        MyMaxZoom = 25

        OurPlanetSystem = New ClsStarConstellation
        OurPlanetSystemDisturbed = New ClsStarConstellation
        InnerPlanets = New ClsStarConstellation
        InnerPlanetsDisturbed = New ClsStarConstellation
        ThreeSymmetricBodies = New ClsStarConstellation
        ThreeSymmetricBodiesDisturbed = New ClsStarConstellation
        FourSymmetricBodies = New ClsStarConstellation
        FourSymmetricBodiesDisturbed = New ClsStarConstellation
        SixSymmetricBodies = New ClsStarConstellation
        SixSymmetricBodiesDisturbed = New ClsStarConstellation
        Netflix3Body = New ClsStarConstellation

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
            MyPicGraphics = New ClsGraphicTool(MyPicDiagram, Mathinterval, Mathinterval)
            MyBmpDiagram = New Bitmap(PicDiagramSize, PicDiagramSize)
            MyPicDiagram.Image = MyBmpDiagram
            MyBmpGraphics = New ClsGraphicTool(MyBmpDiagram, Mathinterval, Mathinterval)
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
            MyPicPhasePortraitGraphics = New ClsGraphicTool(MyPicPhasePortrait, New ClsInterval(0, 30), New ClsInterval(0, 10))
        End Set
    End Property

    Protected Overrides Sub CreateConstellations()

        'Our Planetsystem
        OurPlanetSystem.Name = LM.GetString("OurPlanetSystem")
        OurPlanetSystem.ProposedStepWidth = CDbl(1.2)
        OurPlanetSystem.VFactor = 500
        OurPlanetSystemDisturbed.Name = LM.GetString("OurPlanetSystemDisturbed")
        OurPlanetSystemDisturbed.ProposedStepWidth = CDbl(2)
        OurPlanetSystemDisturbed.VFactor = 500

        'Inner Planets whitout Mercury
        InnerPlanets.Name = LM.GetString("InnerPlanets")
        InnerPlanets.ProposedStepWidth = CDbl(0.05)
        InnerPlanets.VFactor = 500
        InnerPlanetsDisturbed.Name = LM.GetString("InnerPlanetsDisturbed")
        InnerPlanetsDisturbed.ProposedStepWidth = CDbl(1)
        InnerPlanetsDisturbed.VFactor = 500

        FillOurPlanetSystem()
        MyConstellations.Add(OurPlanetSystem)
        MyConstellations.Add(OurPlanetSystemDisturbed)
        MyConstellations.Add(InnerPlanets)
        MyConstellations.Add(InnerPlanetsDisturbed)

        '3 symmetric bodies
        ThreeSymmetricBodies.Name = LM.GetString("3SymmetricBodies")
        ThreeSymmetricBodies.ProposedStepWidth = CDbl(1.5)
        ThreeSymmetricBodies.VFactor = 1000
        Fill3SymmetricBodies(False)
        MyConstellations.Add(ThreeSymmetricBodies)

        '3 symmetric bodies disturbed
        ThreeSymmetricBodiesDisturbed.Name = LM.GetString("3SymmetricBodiesDisturbed")
        ThreeSymmetricBodiesDisturbed.ProposedStepWidth = CDbl(2)
        ThreeSymmetricBodiesDisturbed.VFactor = 1000
        Fill3SymmetricBodies(True)
        MyConstellations.Add(ThreeSymmetricBodiesDisturbed)

        '4 symmetric bodies
        FourSymmetricBodies.Name = LM.GetString("4SymmetricBodies")
        FourSymmetricBodies.ProposedStepWidth = CDbl(3)
        FourSymmetricBodies.VFactor = 1000
        Fill4SymmetricBodies(False)
        MyConstellations.Add(FourSymmetricBodies)

        '4 symmetric bodies disturbed
        FourSymmetricBodiesDisturbed.Name = LM.GetString("4SymmetricBodiesDisturbed")
        FourSymmetricBodiesDisturbed.ProposedStepWidth = CDbl(7)
        FourSymmetricBodiesDisturbed.VFactor = 1000
        Fill4SymmetricBodies(True)
        MyConstellations.Add(FourSymmetricBodiesDisturbed)

        '6 symmetric bodies
        SixSymmetricBodies.Name = LM.GetString("6SymmetricBodies")
        SixSymmetricBodies.ProposedStepWidth = CDbl(3)
        SixSymmetricBodies.VFactor = 1000
        Fill6SymmetricBodies(False)
        MyConstellations.Add(SixSymmetricBodies)

        '6 symmetric bodies disturbed
        SixSymmetricBodiesDisturbed.Name = LM.GetString("6SymmetricBodiesDisturbed")
        SixSymmetricBodiesDisturbed.ProposedStepWidth = CDbl(4)
        SixSymmetricBodiesDisturbed.VFactor = 1000
        Fill6SymmetricBodies(True)
        MyConstellations.Add(SixSymmetricBodiesDisturbed)

        'Netflix 3 body
        Netflix3Body.Name = LM.GetString("Netflix3Body")
        Netflix3Body.ProposedStepWidth = CDbl(1.5)
        Netflix3Body.VFactor = 1000
        FillNetflix3Body()
        MyConstellations.Add(Netflix3Body)

    End Sub

    Private Sub Fill3SymmetricBodies(IsDisturbed As Boolean)

        Dim Sun1 As New ClsNewtonStar

        'Sun1
        With Sun1
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Sun") & " 1"
            .StarColor = Brushes.Gold
            .OriginalMass = 333000
            .Size = 5
            .Perihel = 15
            .ArgumentPerihel = 0
            .PerihelVelocity = CDbl(0.002389 * .Tau)
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(1)
        End With
        If IsDisturbed Then
            ThreeSymmetricBodiesDisturbed.AddStar(Sun1)
        Else
            ThreeSymmetricBodies.AddStar(Sun1)
        End If

        Dim Sun2 As New ClsNewtonStar

        'Sun2
        With Sun2
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Sun") & " 2"
            .StarColor = Brushes.Gold
            .OriginalMass = 333000
            .Size = 5
            .Perihel = 15
            .ArgumentPerihel = CDbl(2 * Math.PI / 3)
            .PerihelVelocity = CDbl(0.002389 * .Tau)
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(1)
        End With
        If IsDisturbed Then
            ThreeSymmetricBodiesDisturbed.AddStar(Sun2)
        Else
            ThreeSymmetricBodies.AddStar(Sun2)
        End If

        Dim Sun3 As New ClsNewtonStar

        'Sun3
        With Sun3
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Sun") & " 3"
            .OriginalMass = 333000
            .Size = 5
            .ArgumentPerihel = CDbl(4 * Math.PI / 3)
            .PerihelVelocity = CDbl(0.002389 * .Tau)
            If IsDisturbed Then
                .StarColor = Brushes.GreenYellow
                .Perihel = CDbl(14.999999)
            Else
                .StarColor = Brushes.Gold
                .Perihel = 15
            End If
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(1)
        End With
        If IsDisturbed Then
            ThreeSymmetricBodiesDisturbed.AddStar(Sun3)
        Else
            ThreeSymmetricBodies.AddStar(Sun3)
        End If

    End Sub

    Private Sub Fill4SymmetricBodies(IsDisturbed As Boolean)

        Dim Sun1 As New ClsNewtonStar

        'Sun1
        With Sun1
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Sun") & " 1"
            .StarColor = Brushes.Gold
            .OriginalMass = 333000
            .Size = 5
            .Perihel = 20
            .ArgumentPerihel = 0
            .PerihelVelocity = CDbl(0.003185 * .Tau)
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(4)
        End With
        If IsDisturbed Then
            FourSymmetricBodiesDisturbed.AddStar(Sun1)
        Else
            FourSymmetricBodies.AddStar(Sun1)
        End If

        Dim Sun2 As New ClsNewtonStar

        'Sun2
        With Sun2
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Sun") & " 2"
            .StarColor = Brushes.Gold
            .OriginalMass = 333000
            .Size = 5
            .Perihel = 20
            .ArgumentPerihel = CDbl(Math.PI / 2)
            .PerihelVelocity = CDbl(0.003185 * .Tau)
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(4)
        End With
        If IsDisturbed Then
            FourSymmetricBodiesDisturbed.AddStar(Sun2)
        Else
            FourSymmetricBodies.AddStar(Sun2)
        End If

        Dim Sun3 As New ClsNewtonStar

        'Sun3
        With Sun3
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Sun") & " 3"
            .StarColor = Brushes.Gold
            .OriginalMass = 333000
            .Size = 5
            .Perihel = 20
            .ArgumentPerihel = CDbl(Math.PI)
            .PerihelVelocity = CDbl(0.003185 * .Tau)
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(4)
        End With
        If IsDisturbed Then
            FourSymmetricBodiesDisturbed.AddStar(Sun3)
        Else
            FourSymmetricBodies.AddStar(Sun3)
        End If

        Dim Sun4 As New ClsNewtonStar

        'Sun4
        With Sun4
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Sun") & " 4"
            .OriginalMass = 333000
            .Size = 5
            .ArgumentPerihel = CDbl(3 * Math.PI / 2)
            .PerihelVelocity = CDbl(0.003185)
            If IsDisturbed Then
                .StarColor = Brushes.GreenYellow
                .Perihel = CDbl(19.99999 * .Tau)
            Else
                .StarColor = Brushes.Gold
                .Perihel = CDbl(20)
            End If
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(4)
        End With
        If IsDisturbed Then
            FourSymmetricBodiesDisturbed.AddStar(Sun4)
        Else
            FourSymmetricBodies.AddStar(Sun4)
        End If

    End Sub

    Private Sub Fill6SymmetricBodies(IsDisturbed As Boolean)

        Dim Sun1 As New ClsNewtonStar

        'Sun1
        With Sun1
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Sun") & " 1"
            .StarColor = Brushes.Gold
            .OriginalMass = 165000
            .Size = 5
            .Perihel = 15
            .ArgumentPerihel = 0
            .PerihelVelocity = CDbl(0.003185 * .Tau)
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(1)
        End With
        If IsDisturbed Then
            SixSymmetricBodiesDisturbed.AddStar(Sun1)
        Else
            SixSymmetricBodies.AddStar(Sun1)
        End If

        Dim Sun2 As New ClsNewtonStar

        'Sun2
        With Sun2
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Sun") & " 2"
            .StarColor = Brushes.Gold
            .OriginalMass = 165000
            .Size = 5
            .Perihel = 15
            .ArgumentPerihel = CDbl(Math.PI / 3)
            .PerihelVelocity = CDbl(0.003185 * .Tau)
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(1)
        End With
        If IsDisturbed Then
            SixSymmetricBodiesDisturbed.AddStar(Sun2)
        Else
            SixSymmetricBodies.AddStar(Sun2)
        End If

        Dim Sun3 As New ClsNewtonStar

        'Sun3
        With Sun3
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Sun") & " 3"
            .StarColor = Brushes.Gold
            .OriginalMass = 165000
            .Size = 5
            .Perihel = 15
            .ArgumentPerihel = CDbl(2 * Math.PI / 3)
            .PerihelVelocity = CDbl(0.003185 * .Tau)
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(1)
        End With
        If IsDisturbed Then
            SixSymmetricBodiesDisturbed.AddStar(Sun3)
        Else
            SixSymmetricBodies.AddStar(Sun3)
        End If

        Dim Sun4 As New ClsNewtonStar

        'Sun4
        With Sun4
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Sun") & " 4"
            .StarColor = Brushes.Gold
            .OriginalMass = 165000
            .Size = 5
            .Perihel = 15
            .ArgumentPerihel = CDbl(Math.PI)
            .PerihelVelocity = CDbl(0.003185 * .Tau)
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(1)
        End With
        If IsDisturbed Then
            SixSymmetricBodiesDisturbed.AddStar(Sun4)
        Else
            SixSymmetricBodies.AddStar(Sun4)
        End If

        Dim Sun5 As New ClsNewtonStar

        'Sun5
        With Sun5
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Sun") & " 5"
            .StarColor = Brushes.Gold
            .OriginalMass = 165000
            .Size = 5
            .Perihel = 15
            .ArgumentPerihel = CDbl(4 * Math.PI / 3)
            .PerihelVelocity = CDbl(0.003185 * .Tau)
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(1)
        End With
        If IsDisturbed Then
            SixSymmetricBodiesDisturbed.AddStar(Sun5)
        Else
            SixSymmetricBodies.AddStar(Sun5)
        End If

        Dim Sun6 As New ClsNewtonStar

        'Sun6
        With Sun6
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Sun") & " 6"
            .OriginalMass = 165000
            .Size = 5
            .ArgumentPerihel = CDbl(5 * Math.PI / 3)
            .PerihelVelocity = CDbl(0.003185 * .Tau)
            If IsDisturbed Then
                .StarColor = Brushes.GreenYellow
                .Perihel = CDbl(14.999999)
            Else
                .StarColor = Brushes.Gold
                .Perihel = CDbl(15)
            End If
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(1)
        End With
        If IsDisturbed Then
            SixSymmetricBodiesDisturbed.AddStar(Sun6)
        Else
            SixSymmetricBodies.AddStar(Sun6)
        End If
    End Sub

    Private Sub FillOurPlanetSystem()

        Dim Sun As New ClsNewtonStar

        'Sun
        With Sun
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Sun")
            .StarColor = Brushes.Gold
            .OriginalMass = 332943
            .Size = 5
            .Perihel = 0
            .ArgumentPerihel = 0
            .PerihelVelocity = 0
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(1)
        End With
        OurPlanetSystem.AddStar(Sun)
        OurPlanetSystemDisturbed.AddStar(Sun)
        InnerPlanets.AddStar(Sun)
        InnerPlanetsDisturbed.AddStar(Sun)

        Dim Mercury As New ClsNewtonStar

        'Mercury
        With Mercury
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Mercury")
            .StarColor = Brushes.LightGray
            .OriginalMass = CDbl(0.055)
            .Size = 1
            .Perihel = CDbl(0.3075)
            .ArgumentPerihel = CDbl(1.3519)
            .PerihelVelocity = CDbl(0.034063 * .Tau)
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(0.01)
        End With
        InnerPlanets.AddStar(Mercury)
        InnerPlanetsDisturbed.AddStar(Mercury)

        Dim Venus As New ClsNewtonStar

        'Venus
        With Venus
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Venus")
            .StarColor = Brushes.Yellow
            .OriginalMass = CDbl(0.815)
            .Size = 2
            .Perihel = CDbl(0.7184)
            .ArgumentPerihel = CDbl(2.2956)
            .PerihelVelocity = CDbl(0.020364 * .Tau)
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(0.02)
        End With
        OurPlanetSystem.AddStar(Venus)
        OurPlanetSystemDisturbed.AddStar(Venus)
        InnerPlanets.AddStar(Venus)
        InnerPlanetsDisturbed.AddStar(Venus)

        Dim Earth As New ClsNewtonStar

        'Earth
        With Earth
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Earth")
            .StarColor = Brushes.SkyBlue
            .OriginalMass = CDbl(0.9833)
            .Size = 2
            .Perihel = CDbl(0.9833)
            .ArgumentPerihel = CDbl(1.7967)
            .PerihelVelocity = CDbl(0.017494 * .Tau)
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(0.03)
        End With
        OurPlanetSystem.AddStar(Earth)
        OurPlanetSystemDisturbed.AddStar(Earth)
        InnerPlanets.AddStar(Earth)
        InnerPlanetsDisturbed.AddStar(Earth)

        Dim Mars As New ClsNewtonStar

        'Mars
        With Mars
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Mars")
            .StarColor = Brushes.Red
            .OriginalMass = CDbl(0.107)
            .Size = 2
            .Perihel = CDbl(1.3814)
            .ArgumentPerihel = CDbl(5.865)
            .PerihelVelocity = CDbl(0.015305 * .Tau)
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(0.04)
        End With
        OurPlanetSystem.AddStar(Mars)
        OurPlanetSystemDisturbed.AddStar(Mars)
        InnerPlanets.AddStar(Mars)
        InnerPlanetsDisturbed.AddStar(Mars)

        Dim Jupiter As New ClsNewtonStar

        'Jupiter
        With Jupiter
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Jupiter")
            .StarColor = Brushes.GreenYellow
            .OriginalMass = CDbl(317.8)
            .Size = 3
            .Perihel = CDbl(4.9501)
            .ArgumentPerihel = CDbl(0.2575)
            .PerihelVelocity = CDbl(0.007924 * .Tau)
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(0.5)
        End With
        OurPlanetSystem.AddStar(Jupiter)

        Dim StrangeJupiter As New ClsNewtonStar

        'Strange Jupiter
        With StrangeJupiter
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Jupiter")
            .StarColor = Brushes.GreenYellow
            .OriginalMass = CDbl(31800)
            .Size = 4
            .Perihel = CDbl(5)
            .ArgumentPerihel = CDbl(0.7)
            .PerihelVelocity = CDbl(0.004813 * .Tau)
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(0.5)
        End With

        OurPlanetSystemDisturbed.AddStar(StrangeJupiter)
        InnerPlanetsDisturbed.AddStar(StrangeJupiter)

        Dim Saturn As New ClsNewtonStar

        'Saturn
        With Saturn
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Saturn")
            .StarColor = Brushes.Tomato
            .OriginalMass = CDbl(95.2)
            .Size = 3
            .Perihel = CDbl(9.0481)
            .ArgumentPerihel = CDbl(1.6132)
            .PerihelVelocity = CDbl(0.005879 * .Tau)
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(1.5)
        End With
        OurPlanetSystem.AddStar(Saturn)
        OurPlanetSystemDisturbed.AddStar(Saturn)

        Dim Uranus As New ClsNewtonStar

        'Uranus
        With Uranus
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Uranus")
            .StarColor = Brushes.Orange
            .OriginalMass = CDbl(14.5)
            .Size = 3
            .Perihel = CDbl(18.3755)
            .ArgumentPerihel = CDbl(2.9839)
            .PerihelVelocity = CDbl(0.004106 * .Tau)
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(3)
        End With
        OurPlanetSystem.AddStar(Uranus)
        OurPlanetSystemDisturbed.AddStar(Uranus)

        Dim Neptune As New ClsNewtonStar

        'Neptune
        With Neptune
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Neptune")
            .StarColor = Brushes.Cyan
            .OriginalMass = CDbl(16.8)
            .Size = 3
            .Perihel = CDbl(29.7667)
            .ArgumentPerihel = CDbl(0.7849)
            .PerihelVelocity = CDbl(0.003176 * .Tau)
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(5)
        End With
        OurPlanetSystem.AddStar(Neptune)
        OurPlanetSystemDisturbed.AddStar(Neptune)

        'StrangeJupiter

    End Sub

    Private Sub FillNetflix3Body()

        Dim Sun1 As New ClsNewtonStar

        'Sun1
        With Sun1
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Sun") & " 1"
            .StarColor = Brushes.Gold
            .OriginalMass = 333000
            .Size = 5
            .Perihel = 15
            .ArgumentPerihel = 0
            .PerihelVelocity = CDbl(0.002389 * .Tau)
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(1)
        End With
        Netflix3Body.AddStar(Sun1)


        Dim Sun2 As New ClsNewtonStar

        'Sun2
        With Sun2
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Sun") & " 2"
            .StarColor = Brushes.Gold
            .OriginalMass = 333000
            .Size = 5
            .Perihel = 15
            .ArgumentPerihel = CDbl(2 * Math.PI / 3)
            .PerihelVelocity = CDbl(0.002389 * .Tau)
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(1)
        End With
        Netflix3Body.AddStar(Sun2)


        Dim Sun3 As New ClsNewtonStar

        'Sun3
        With Sun3
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Sun") & " 3"
            .OriginalMass = 333000
            .Size = 5
            .ArgumentPerihel = CDbl(4 * Math.PI / 3)
            .PerihelVelocity = CDbl(0.002389 * .Tau)
            .StarColor = Brushes.Gold
            .Perihel = 15
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(1)
        End With
        Netflix3Body.AddStar(Sun3)

        Dim Planet As New ClsNewtonStar

        'Planet
        With Planet
            .PicDiagram = MyPicDiagram
            .PicGraphics = MyPicGraphics
            .BmpDiagram = MyBmpDiagram
            .BmpGraphics = MyBmpGraphics
            .PicPhasePortrait = MyPicPhasePortrait
            .PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
            .Name = LM.GetString("Planet")
            .OriginalMass = 1
            .Size = 4
            .ArgumentPerihel = CDbl(2 * Math.PI / 3)
            .PerihelVelocity = CDbl(0.01 * .Tau)
            .StarColor = Brushes.LightBlue
            .Perihel = 13
            .SetDefaultParameterByPerihelData()
            .SetDefaultUserData()
            .Universe = Me
            .ProposedStepWidth = CDbl(1)
        End With
        Netflix3Body.AddStar(Planet)

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
