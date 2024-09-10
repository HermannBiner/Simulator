'This is the Interface for all kind of Billiardtables

Public Interface IBilliardTable

    'The Billiardballs on the table
    ReadOnly Property BilliardBallCollection As List(Of IBilliardball)

    'The Billiardtable can draw itself
    Property PicDiagram As PictureBox

    'Status Parameter
    WriteOnly Property LblN As Label

    'For Checks in FrmBillardTable
    ReadOnly Property TValueRange As ClsInterval
    ReadOnly Property AlfaValueRange As ClsInterval
    WriteOnly Property PhasePortrait As PictureBox
    WriteOnly Property ValueProtocol As ListBox

    ReadOnly Property ValueParameters As List(Of ClsValueParameter)

    'The parameter defining the form of the Billiardtable
    Property C As Decimal
    ReadOnly Property ParameterRange As ClsInterval

    ReadOnly Property A As Decimal
    ReadOnly Property B As Decimal

    'IterationStatus
    Property IterationStatus As ClsGeneral.EnIterationStatus

    'Reset all diagrams and clear all balls
    Sub ResetIteration()

    'Get a BilliardBall for this table
    Function GetBilliardBall() As IBilliardball

    'Drawing the Billiard Table
    Sub DrawBilliardtable()

    Sub IterationStep()

    Function IterationLoop() As Task

    Sub PrepareBallsForPhaseportrait()

End Interface
