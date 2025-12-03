'Interface for all kind of pendulums
'a pendulum knows all rules for its movement
'and can move itself on the screen

Public Interface IPendulum

    'the pendulum needs the following references to draw its movement
    WriteOnly Property PicDiagram As PictureBox
    Property PicGraphics As ClsGraphicTool
    Property BmpDiagram As Bitmap
    Property BmpGraphics As ClsGraphicTool

    'in addtion, the pendulum protocols its movement in a phase portrait
    WriteOnly Property PicPhaseportrait As PictureBox
    Property PicPhasePortraitGraphics As ClsGraphicTool
    Property BmpPhasePortrait As Bitmap
    Property BmpPhasePortraitGraphics As ClsGraphicTool

    'the Type of PhasePortrait that is selected
    Property PhaseportraitIndex As Integer

    'label the Phaseportrait
    ReadOnly Property LabelPhasePortrait As String

    WriteOnly Property Protocol As ListBox

    WriteOnly Property IsProtocol As Boolean

    Property IsMainDS As Boolean

    WriteOnly Property PendulumColor As Brush

    'Label of the Parameterlist
    ReadOnly Property LabelProtocol As String

    'To set the parameters of the TrbAdditionalParameter
    ReadOnly Property AdditionalParameter As ClsGeneralParameter

    'contains the value of the trackbar TrbAdditionalParameter
    Property AdditionalParameterValue As Integer

    'To label fields P1...P8 and set the Valueranges
    ReadOnly Property ValueParameterDefinition As List(Of ClsGeneralParameter)

    'To TakeOverParameter
    Property CalculationConstants As ClsNTupel

    Property CalculationVariables As ClsNTupel

    Property IsStartparameter1Set As Boolean

    Property IsStartparameter2Set As Boolean

    WriteOnly Property StepWidth As Integer

    WriteOnly Property LblStepWidth As Label

    ReadOnly Property StartEnergyRange As ClsInterval

    'Calculate value od the additional Paremeter by the Trackbar Value
    Function GetAddParameterValue(TbrValue As Integer) As Decimal

    Sub PrepareDiagram()

    Sub ResetIteration()

    Function GetTypesofPhaseportrait() As List(Of String)

    Sub SetAndDrawStartparameter1(Mouseposition As Point)

    Sub SetAndDrawStartparameter2(Mouseposition As Point)

    Sub SetDefaultUserData()

    Sub SetAdditionalParameters()

    Function GetEnergy() As Decimal

    Sub IterationStep(IsTestmode As Boolean)

    Function GetCopy() As IPendulum

End Interface
