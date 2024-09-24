'This is the Interface for all kind of Billiardtables

Public Interface IBilliardTable

    'The Billiardballs on the table
    ReadOnly Property BilliardBallCollection As List(Of IBilliardball)

    'The Billiardtable can draw itself
    Property PicDiagram As PictureBox

    ReadOnly Property MathInterval As ClsInterval

    'Status Parameter
    WriteOnly Property LblN As Label

    'The parameter defining the form of the Billiardtable
    ReadOnly Property FormulaParameter As ClsGeneralParameter

    'The definition of the Iteration Parameter
    ReadOnly Property TValueParameter As ClsGeneralParameter
    ReadOnly Property AlfaValueParameter As ClsGeneralParameter

    ReadOnly Property ValueParameterList As List(Of ClsGeneralParameter)

    'Status protocol
    WriteOnly Property PhasePortrait As PictureBox
    WriteOnly Property ValueProtocol As ListBox

    'The parameter defining the form of the Billiardtable
    Property C As Decimal

    ReadOnly Property A As Decimal
    ReadOnly Property B As Decimal

    'IterationStatus
    Property IterationStatus As ClsDynamics.EnIterationStatus

    'Reset all diagrams and clear all balls
    Sub ResetIteration()

    'Get a BilliardBall for this table
    Function GetBilliardBall() As IBilliardball

    'Drawing the Billiard Table
    Sub DrawBilliardtable()

    Function IterationLoop(NumberOfSTeps As Integer) As Task

    Sub PrepareBallsForPhaseportrait()

End Interface
