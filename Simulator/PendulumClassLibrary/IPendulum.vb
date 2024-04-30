'Interface for all kind of pendulums
'a pendulum knows all rules for its movement
'and can move itself on the screen

Public Interface IPendulum

    'the pendulum needs the following references to draw its movement
    WriteOnly Property PicPendulum As PictureBox

    'the permanent track of the orbit is drawn into a Bitmap
    WriteOnly Property MapPendulum As Bitmap

    ReadOnly Property Y0 As Decimal

    'in addtion, the ball protocols its movement in a phase portrait
    WriteOnly Property PicPhaseportrait As PictureBox

    'the permanent track of the orbit is drawn into a Bitmap
    WriteOnly Property MapPhaseportrait As Bitmap

    WriteOnly Property ParameterListbox As ListBox

    'To label fields P1...P8 and set the Valueranges
    ReadOnly Property ValueParameters As List(Of ClsValueParameter)

    'label the Phaseportrait
    ReadOnly Property LabelPhasePortrait As String

    'Label of the Parameterlist
    ReadOnly Property LabelParameterList As String

    'Label Parameter C
    ReadOnly Property LabelParameterC As String

    'To set the parameters of the TrbAdditionalParameter
    ReadOnly Property AdditionalParameter As ClsValueParameter

    'The total Energy of the Pendulum
    ReadOnly Property Energy As Decimal

    'The Interval of the StartEnergy
    ReadOnly Property StartEnergyRange As ClsInterval

    'contains the value of the trackbar TrbAdditionalParameter
    WriteOnly Property AdditionalParameterValue As Integer

    'The parameter C for the C-DiagraM
    ReadOnly Property C As Decimal

    'The constant parameters
    Property Constants As ClsVector

    'The variable Parameters
    Property Variables As ClsVector

    'To Calculate the Mass Ratio out of the Trackbar Value
    Function CalcValuefromTrbAddParameter(TbrValue As Integer) As Decimal

    Sub DrawCoordinateSystem()

    Sub DrawPendulums()

    Sub Reset()

    Property IsStartparameter1Set As Boolean

    Property IsStartparameter2Set As Boolean

    WriteOnly Property TestMode As Boolean

    WriteOnly Property StepWidth As Decimal

    Function GetTypesofPhaseportrait() As List(Of String)

    WriteOnly Property PhaseportraitIndex As Integer

    Sub SetAndDrawStartparameter1(Mouseposition As Point)

    Sub SetAndDrawStartparameter2(Mouseposition As Point)

    'The variable Parameters are changed during the iteration
    'Iteration performs one approximation step
    'and draws everything into Bitmaps and Pictureboxes
    Sub Iteration(TestMode As Boolean)

End Interface
