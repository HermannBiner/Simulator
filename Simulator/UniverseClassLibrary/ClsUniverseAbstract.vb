'This is the abstract class of all types of Universes
'and hold only methods and properties that are independent
'of the type of universe, 
'that means the type of
'the potential that defines the force between stars

'the position, the mass and the velocity of a star
'is for all universes in the same range
'therefore the definition of the ValueParameters
'is part of the general universe

'the universe controls the iterationstep
'by calculating the next position of all stars
'and draws the new positions into the PicDiagram
'and updates PicPhasePortrait

'the update of PicEnergy and PicAngularMomentum is done
'by the ClsUniverseController

'Status Checked

Public MustInherit Class ClsUniverseAbstract
    Implements IUniverse

    Protected ReadOnly LM As ClsLanguageManager

    'PicDiagram
    Protected MyPicDiagram As PictureBox
    Protected MyPicGraphics As ClsGraphicTool
    Protected MyBmpDiagram As Bitmap
    Protected MyBmpGraphics As ClsGraphicTool

    Protected MyPicPhasePortrait As PictureBox
    Protected MyPicPhasePortraitGraphics As ClsGraphicTool

    'Ranges and ParameterDefinitions
    Protected MathInterval As ClsInterval
    Protected MyPositionParameterDefinition As ClsGeneralParameter
    Protected MyVelocityParameterDefinition As ClsGeneralParameter
    Protected MyMassParameterDefinition As ClsGeneralParameter

    'all constellations of the universe
    Protected MyConstellations As List(Of ClsConstellation)
    Protected MyActiveConstellation As ClsConstellation

    'all stars that are active in the universe
    Protected MyActiveStarCollection As List(Of IStar)

    'the centre of gravity that is the new origin of the coordinate system
    Protected MyGlobalCentreOfGravity As ClsVector

    Protected LocalCentreOfGravity As New ClsVector

    'To show an optimal diagram, the position coordinates are zoomed
    Protected MyMaxZoom As Decimal
    Protected MyDiagramZoom As Decimal
    Protected MyVFactor As Decimal

    'Each Universe has its own MathInterval, therefore:
    Protected MustOverride Property PicDiagram As PictureBox Implements IUniverse.PicDiagram
    Protected MustOverride Property PicPhasePortrait As PictureBox Implements IUniverse.PicPhaseportrait

    ReadOnly Property PicGraphics As ClsGraphicTool Implements IUniverse.PicGraphics
        Get
            PicGraphics = MyPicGraphics
        End Get
    End Property

    ReadOnly Property BmpDiagram As Bitmap Implements IUniverse.BmpDiagram
        Get
            BmpDiagram = MyBmpDiagram
        End Get
    End Property

    ReadOnly Property BmpGraphics As ClsGraphicTool Implements IUniverse.BmpGraphics
        Get
            BmpGraphics = MyBmpGraphics
        End Get
    End Property

    ReadOnly Property PicPhasePortraitGraphics As ClsGraphicTool Implements IUniverse.PicPhasePortraitGraphics
        Get
            PicPhasePortraitGraphics = MyPicPhasePortraitGraphics
        End Get
    End Property

    ReadOnly Property PositionParameterDefinition As ClsGeneralParameter _
        Implements IUniverse.PositionParameterDefinition
        Get
            PositionParameterDefinition = MyPositionParameterDefinition
        End Get
    End Property

    ReadOnly Property VelocityParameterDefinition As ClsGeneralParameter _
        Implements IUniverse.VelocityParameterDefinition
        Get
            VelocityParameterDefinition = MyVelocityParameterDefinition
        End Get
    End Property

    ReadOnly Property MassParameterDefinition As ClsGeneralParameter _
        Implements IUniverse.MassParameterDefinition
        Get
            MassParameterDefinition = MyMassParameterDefinition
        End Get
    End Property

    ReadOnly Property Constellations As List(Of ClsConstellation) _
        Implements IUniverse.Constellations
        Get
            Constellations = MyConstellations
        End Get
    End Property

    Property ActiveConstellation As ClsConstellation Implements IUniverse.ActiveConstellation
        Get
            ActiveConstellation = MyActiveConstellation
        End Get
        Set(value As ClsConstellation)
            MyActiveConstellation = value
        End Set
    End Property

    ReadOnly Property GlobalCentreOfGravity As ClsVector _
        Implements IUniverse.GlobalCentreOfGravity
        Get
            GlobalCentreOfGravity = New ClsVector
            GlobalCentreOfGravity.Equal(MyGlobalCentreOfGravity)
        End Get
    End Property

    Property ActiveStarCollection As List(Of IStar) _
        Implements IUniverse.ActiveStarCollection
        Get
            ActiveStarCollection = MyActiveStarCollection
        End Get
        Set(value As List(Of IStar))
            MyActiveStarCollection = value
        End Set
    End Property

    ReadOnly Property MaxZoom As Decimal Implements IUniverse.MaxZoom
        Get
            MaxZoom = MyMaxZoom
        End Get
    End Property

    Property DiagramZoom As Decimal Implements IUniverse.DiagramZoom
        Get
            DiagramZoom = MyDiagramZoom
        End Get
        Set(value As Decimal)
            MyDiagramZoom = value
        End Set
    End Property

    Property VFactor As Decimal Implements IUniverse.VFactor
        Get
            VFactor = MyVFactor
        End Get
        Set(value As Decimal)
            MyVFactor = value
        End Set
    End Property

    Public Sub New()

        LM = ClsLanguageManager.LM
        MyDiagramZoom = 1 'Default
        MyConstellations = New List(Of ClsConstellation)
        MyActiveStarCollection = New List(Of IStar)
        MyGlobalCentreOfGravity = New ClsVector
    End Sub

    Public Sub RedrawUniverse(NewStar As IStar, IsZoom As Boolean) Implements IUniverse.RedrawUniverse

        'this sub is executed only if the number of existing stars is > 0:

        If MyActiveStarCollection.Count > 0 Then
            'If a new star is added, the new gravitypoint is calculated
            'the new origine of the coordinatesystem is this gravitypoint
            'of all existing stars plus the new defaultstar
            'see formulas in math. doc

            Dim StarSummand As New ClsVector
            Dim NewPosition As New ClsVector
            Dim aStar As IStar

            'the centre of gravity is allways recalculated
            'relative to the existing masses
            'therefore "local"
            LocalCentreOfGravity.Reset()

            'The mass in this formula is independent on the units
            'first, the new gravitiy centre is calculated
            Dim TotalMass As Decimal = 0
            Dim NewStarMass As Decimal = 0

            If NewStar IsNot Nothing Then
                NewStarMass = NewStar.UserMass
                TotalMass = NewStarMass
            End If

            'the newstar is not contained in MyActiveStarCollection
            For Each aStar In MyActiveStarCollection
                TotalMass += aStar.UserMass
            Next

            If NewStar IsNot Nothing Then
                With NewStar
                    StarSummand.Equal(.UserStartPosition)
                    StarSummand.Mult(-CDec(NewStarMass / TotalMass))
                    LocalCentreOfGravity.Add(StarSummand)
                    .TotalMassOfOtherStars = TotalMass - NewStarMass
                End With
            End If

            For Each aStar In MyActiveStarCollection
                With aStar
                    StarSummand.Equal(.UserStartPosition)
                    StarSummand.Mult(-CDec(aStar.UserMass / TotalMass))
                    LocalCentreOfGravity.Add(StarSummand)
                    .TotalMassOfOtherStars = TotalMass - aStar.UserMass
                End With
            Next

            'now, the startposition of all stars has to be corrected by the gravitypoint
            'in addition, the diagram is zoomed so that the view is optimal

            If NewStar IsNot Nothing Then
                NewPosition.Equal(NewStar.UserStartPosition)
                NewPosition.Add(LocalCentreOfGravity)
                NewStar.UserStartPosition.Equal(NewPosition)
            End If

            For Each aStar In MyActiveStarCollection
                NewPosition.Equal(aStar.UserStartPosition)
                NewPosition.Add(LocalCentreOfGravity)
                aStar.UserStartPosition.Equal(NewPosition)
            Next

            'the GlobalCentreOfGravity sums all Local Translations
            'to move the Origin into the actual Gravity Centre up
            'and is used when placing an additional star
            MyGlobalCentreOfGravity.Add(LocalCentreOfGravity)

            'Finally the zoom is calculated

            'MaxDistance should be stretched to MyMatzInterval
            Dim MaxDistance As Decimal = 0

            If NewStar IsNot Nothing Then
                MaxDistance = NewStar.UserStartPosition.Abs
            End If

            For Each aStar In MyActiveStarCollection
                If aStar.UserStartPosition.Abs > MaxDistance Then
                    MaxDistance = aStar.UserStartPosition.Abs
                End If
            Next

            If MaxDistance > 0 And IsZoom Then
                MyDiagramZoom = MaxZoom / MaxDistance
            Else
                MyDiagramZoom = 1
            End If

        End If

        'Draw universe
        ClearDiagrams()

        For Each aStar As IStar In MyActiveStarCollection
            With aStar
                .ResetIteration()
                .DrawStar(True)
                .DrawOrbit(True)
            End With
        Next

        MyPicDiagram.Refresh()
        If NewStar IsNot Nothing Then
            With NewStar
                .ResetIteration()
                .DrawStar(False)
                .DrawOrbit(False)
            End With
        End If

    End Sub

    Public Sub ClearUniverse() Implements IUniverse.ClearUniverse

        'the universe is cleared completely
        ClearDiagrams()
        MyDiagramZoom = 1
        MyActiveStarCollection.Clear()
        MyGlobalCentreOfGravity.Reset()
    End Sub

    Public Sub ResetIteration() Implements IUniverse.ResetIteration

        ClearDiagrams()

        'ActiveStarCollection is nothing if there are no stars on the diagram
        If MyActiveStarCollection IsNot Nothing Then
            For Each aStar As IStar In MyActiveStarCollection
                aStar.ResetIteration()
                aStar.DrawStar(True)
                aStar.DrawOrbit(True)
            Next
        End If
    End Sub

    Public Sub ClearDiagrams() Implements IUniverse.ClearDiagrams
        MyBmpGraphics.Clear(Color.Black)
        MyPicDiagram.Refresh()
        MyPicPhasePortrait.Refresh()
    End Sub

    Protected Overridable Function StepWidthToTrbValue(locStepWidth As Decimal) As Integer _
        Implements IUniverse.StepWidthToTrbValue
        Select Case True
            Case locStepWidth < 0.01
                Return CInt(1 + (locStepWidth - 0.001) / 0.0005)
            Case locStepWidth < 0.1
                Return CInt(19 + (locStepWidth - 0.01) / 0.005)
            Case locStepWidth < 1
                Return CInt(37 + (locStepWidth - 0.1) / 0.05)
            Case Else
                Return CInt(55 + (locStepWidth - 1) / 0.5)
        End Select
    End Function

    Protected Overridable Function TrbValueToStepWidth(locTrbValue As Integer) As Decimal _
        Implements IUniverse.TrbValueToStepWidth
        Select Case True
            Case locTrbValue < 19
                Return CDec(0.001 + (locTrbValue - 1) * 0.0005)
            Case locTrbValue < 37
                Return CDec(0.01 + (locTrbValue - 19) * 0.005)
            Case locTrbValue < 55
                Return CDec(0.1 + (locTrbValue - 37) * 0.05)
            Case Else
                Return CDec(1 + (locTrbValue - 55) * 0.5)
        End Select
    End Function

    'Initializes the universe depending on its type
    'and fills all default-starcollections
    'and default constellations
    'they are different for each type of universe
    Protected MustOverride Sub CreateConstellations() _
        Implements IUniverse.CreateConstellations

    Protected MustOverride Function GetNewStar(Name As String) As IStar _
        Implements IUniverse.GetNewStar

End Class
