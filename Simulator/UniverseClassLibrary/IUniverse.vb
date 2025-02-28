'This is the Interface for all models of universe
'actually, the only one is the real one, following Newton's law
'approximated by Runge Kutta 4

'Status Checked

Public Interface IUniverse

    'The universe transmits all diagram references
    'to its stars
    Property PicDiagram As PictureBox

    ReadOnly Property PicGraphics As ClsGraphicTool

    ReadOnly Property BmpDiagram As Bitmap

    ReadOnly Property BmpGraphics As ClsGraphicTool

    Property PicPhaseportrait As PictureBox
    ReadOnly Property PicPhasePortraitGraphics As ClsGraphicTool

    'Parameter Definitions
    'these parameters are allowed when creatingnew stars in the universe
    ReadOnly Property PositionParameterDefinition As ClsGeneralParameter
    ReadOnly Property VelocityParameterDefinition As ClsGeneralParameter
    ReadOnly Property MassParameterDefinition As ClsGeneralParameter

    'this is the set of all predefined constellations of the universe
    ReadOnly Property Constellations As List(Of ClsConstellation)

    'the constellation that is active in the universe
    Property ActiveConstellation As ClsConstellation

    'this is the Collection of stars that are active in the universe
    Property ActiveStarCollection As List(Of IStar)

    'the CentreOfGravity is always recalculated if a new star is added
    'and/or if the new star is moved or if its mass has changed

    ReadOnly Property GlobalCentreOfGravity As ClsVector

    'the diagramzoom is calculated in sub RedrawUniverse
    'and zooms the diagram so that the view on the stars is
    'optimized. The maximal possible Zoom is the following
    ReadOnly Property MaxZoom As Decimal

    'the stars need access to this number when 
    'drawing themselves or drawing their orbit
    'the Actual Zoom is the following
    Property DiagramZoom As Decimal

    'to show the used VFactor - see VFacter in constellation
    Property VFactor As Decimal

    'each universe as a predefined set of constellations
    'and each constellation contains a predefined set of stars/planets
    Sub CreateConstellations()

    'a new star is created by the specific universe
    Function GetNewStar(Name As String) As IStar

    'This routine calculates the new centre of gravity
    'adjusts all ActualStartParameters of all Stars
    'in the universe
    'the NewStar plays a special role until it is added 
    'to the ActualStarCollection
    'after that, it is treated like a "normal" member of the universe
    'in addition, redraw universe calculates as well the zoom
    'that is used to show the position of all stars/planets
    Sub RedrawUniverse(NewStar As IStar, IsZoom As Boolean)

    'all diagrams are cleared and the universe
    'and removes all existing stars/planets
    Sub ClearUniverse()

    'if the universe is reset, all stars are set back
    'to the ActualStartPoint and all Diagrams are cleared
    Sub ResetIteration()

    'Only the Diagrams are cleared
    Sub ClearDiagrams()

    Function StepWidthToTrbValue(locStepWidth As Decimal) As Integer

    Function TrbValueToStepWidth(locTrbValue As Integer) As Decimal

End Interface
