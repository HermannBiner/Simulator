'This Form is the User Interface for all Investigations of different Billiards
'like elliptic, stadium or oval
'it is based on the interfaces IBilliardBall
'that are implemented by the according classes ClsEllipticBilliardTable, ClsEllipticBilliardBall, etc.
'see mathematical documentation
'if other Billiards are programmed, the according classes have just to implement this interface

'Status Checked

Imports System.Globalization
Imports System.Reflection

Public Class FrmBilliardtable

    'Controlling Form Load
    Private IsFormLoaded As Boolean

    'Default for drawing BilliardTable etc.
    Private DS As IBilliardTable

    'Tha active BilliardBall
    Private ActiveBilliardball As IBilliardball

    'Properties of the Ball
    Private Ballcolor As Brush

    'The Startposition of the Ball is set by the Mouse
    Private IsMousedown As Boolean = False

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub InitializeLanguage()

        Text = FrmMain.LM.GetString("Billiard")
        BtnPhasePortrait.Text = FrmMain.LM.GetString("FillPhasePortrait")
        LblNumberOfSteps.Text = FrmMain.LM.GetString("NumberOfSteps")
        LblBilliardTable.Text = FrmMain.LM.GetString("BilliardTable")
        LblAlfa.Text = FrmMain.LM.GetString("Alfa")
        BtnTakeOverStartParameter.Text = FrmMain.LM.GetString("TakeOver")
        GrpStartParameter.Text = FrmMain.LM.GetString("StartParameter")
        LblPhasePortrait.Text = FrmMain.LM.GetString("PhasePortrait") & ": t, alfa"
        LblSpeed.Text = FrmMain.LM.GetString("BallSpeed") & " " & TrbSpeed.Value.ToString
        LblBallColor.Text = FrmMain.LM.GetString("BallColor")
        BtnNewBall.Text = FrmMain.LM.GetString("NewBall")
        BtnStart.Text = FrmMain.LM.GetString("Start")
        BtnReset.Text = FrmMain.LM.GetString("ResetIteration")
        BtnNextStep.Text = FrmMain.LM.GetString("NextStep")
        LblParameterc.Text = FrmMain.LM.GetString("FactorC")

        CboBallColor.Items.Clear()

        'the following order of adding the iteration type is relevant!
        'there is at the moment no better concept implemented to identify the type of Billiard
        CboBallColor.Items.Add(FrmMain.LM.GetString("Red"))
        CboBallColor.Items.Add(FrmMain.LM.GetString("Green"))
        CboBallColor.Items.Add(FrmMain.LM.GetString("Blue"))
        CboBallColor.Items.Add(FrmMain.LM.GetString("Black"))
        CboBallColor.Items.Add(FrmMain.LM.GetString("Magenta"))

    End Sub

    Private Sub FrmBilliardTable_Load(sender As Object, e As EventArgs) Handles Me.Load

        IsFormLoaded = False

        'No Controller needed

        'Initialize Language
        InitializeLanguage()

        FillDynamicSystem()

    End Sub

    Private Sub FrmBilliardtable_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        'Setting Standard Values
        CboBallColor.SelectedIndex = 0
        Ballcolor = Brushes.Red
        CboBilliardTable.SelectedIndex = 0

        SetDS()
        IsFormLoaded = True

    End Sub

    Private Sub FillDynamicSystem()

        CboBilliardTable.Items.Clear()

        'Add the classes implementing IBilliardBall
        'to the Combobox CboBilliardTable by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IBilliardTable)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If types.Count > 0 Then
            Dim DSName As String
            For Each type In types

                'GetString is calle dwith the option IsClass = true
                'That effects that - if there is no Entry in the Resource files LabelsEN, LabelsDE -
                'the name of the Class implementing an Interface is used as default
                'suppressing the extension "Cls"
                DSName = FrmMain.LM.GetString(type.Name, True)
                CboBilliardTable.Items.Add(DSName)
            Next

        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If
    End Sub

    Private Sub SetDS()

        'This sets the type of BilliardTable by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IBilliardTable)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If CboBilliardTable.SelectedIndex >= 0 Then

            Dim SelectedName As String = CboBilliardTable.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If FrmMain.LM.GetString(type.Name, True) = SelectedName Then
                        DS = CType(Activator.CreateInstance(type), IBilliardTable)
                    End If
                Next
            End If

        End If

        InitializeDS()


        SetDefaultUserData()

        'If the type of iteration changes, everything has to be reset
        ResetIteration()

    End Sub

    Private Sub InitializeDS()
        With DS
            .PicDiagram = PicDiagram
            .LblN = LblSteps
            .PhasePortrait = PicPhasePortrait
            .ValueProtocol = LstValueList
            .C = CDec(TrbParameterC.Value * 0.01)
        End With
    End Sub

    Private Sub SetDefaultUserData()
        TxtT.Text = "0"
        TxtAlfa.Text = "1"
        TxtParameter.Text = DS.C.ToString
    End Sub

    Private Sub ResetIteration()

        DS.ResetIteration()
        PicPhasePortrait.Refresh()
        LstValueList.Items.Clear()

        BtnStart.Text = FrmMain.LM.GetString("Start")
        BtnPhasePortrait.Text = FrmMain.LM.GetString("FillPhasePortrait")

        BtnNewBall.Enabled = True
        BtnNextStep.Enabled = True

        'preparediagram
        DS.DrawBilliardtable()

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        If IsFormLoaded Then
            ResetIteration()
        End If
    End Sub

    Private Sub CboBilliardTable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboBilliardTable.SelectedIndexChanged
        If IsFormLoaded Then
            SetDS()
        End If
    End Sub

    Private Sub CboBallColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboBallColor.SelectedIndexChanged
        If IsFormLoaded Then
            'Is this needed??
            'The generated Balls can have different colors to be distinguished
            Select Case CboBallColor.SelectedIndex
                Case 0
                    LblColor.BackColor = Color.Red
                    Ballcolor = Brushes.Red
                Case 1
                    LblColor.BackColor = Color.Green
                    Ballcolor = Brushes.Green
                Case 2
                    LblColor.BackColor = Color.Blue
                    Ballcolor = Brushes.Blue
                Case 3
                    LblColor.BackColor = Color.Black
                    Ballcolor = Brushes.Black
                Case Else
                    LblColor.BackColor = Color.Magenta
                    Ballcolor = Brushes.Magenta
            End Select
        End If
    End Sub

    Private Sub TrbSpeed_ValueChanged(sender As Object, e As EventArgs) Handles TrbSpeed.ValueChanged
        If IsFormLoaded Then
            LblSpeed.Text = FrmMain.LM.GetString("BallSpeed") & " " & TrbSpeed.Value.ToString

            'All Billiard Balls have the same speed
            For Each Ball As IBilliardball In DS.BilliardBallCollection
                Ball.BallSpeed = TrbSpeed.Value
            Next
        End If
    End Sub

    Private Sub TrbParameterC_Scroll(sender As Object, e As EventArgs) Handles TrbParameterC.Scroll
        If IsFormLoaded Then
            DS.C = CDec(TrbParameterC.Value * 0.01)
            TxtParameter.Text = DS.C.ToString
            ResetIteration()
        End If
    End Sub

    Private Sub TxtParameter_LostFocus(sender As Object, e As EventArgs) Handles TxtParameter.LostFocus
        If IsFormLoaded Then
            If IsParameterOK() Then
                DS.C = CDec(TxtParameter.Text)
                ResetIteration()
            End If
        End If
    End Sub

    'SECTOR GENERATE A NEW BALL

    Private Sub BtnNewBall_Click(sender As Object, e As EventArgs) Handles BtnNewBall.Click
        If IsFormLoaded Then
            If IsUserDataOK() Then
                CreateNewBall()
            End If
        End If
    End Sub

    Public Sub CreateNewBall()
        ActiveBilliardball = DS.GetBilliardBall
        'Set GUI Parameters
        With ActiveBilliardball
            .BallColor = Ballcolor
            .BallSpeed = TrbSpeed.Value
            .DrawFirstUserStartposition()
        End With

        'All the other parameters are set by DS

    End Sub

    'SECTOR SET STARTPOSITION AND POSITION OF THE FIRST HIT

    Private Sub PicBilliardTable_MouseDown(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseDown

        If ActiveBilliardball IsNot Nothing Then

            If Not (ActiveBilliardball.IsStartpositionSet And ActiveBilliardball.IsStartangleSet) Then

                Cursor = Cursors.Hand
                IsMousedown = True

                'Now, Moving the Mouse moves the Ball as well
                MouseMoving(e)

            End If
        End If

    End Sub

    Private Sub PicBilliardTable_MouseUp(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseUp

        'Has only an effect, if the Mouse was down
        If IsMousedown Then

            'The Position of the Mouse sets the Position of the Ball below
            'e: Mouseposition is relative to PicBilliardTable
            Dim Mouseposition As Point
            Mouseposition.X = e.X + 2
            Mouseposition.Y = e.Y - 25

            If Not ActiveBilliardball.IsStartpositionSet Then

                'This is the first Time that the MouseUp event happens
                'and the Position of the Mouse sets the Start Position of the Ball
                'This Start Position is defined by the according Parameter t
                Dim t As Decimal = ActiveBilliardball.SetAndDrawUserStartposition(Mouseposition, True)
                TxtT.Text = t.ToString(CultureInfo.CurrentCulture)

                't is as well transmitted to the Ball
                ActiveBilliardball.Startparameter = t
                ActiveBilliardball.IsStartpositionSet = True

            ElseIf Not ActiveBilliardball.IsStartangleSet Then

                'This is the second time that the MouseUp event happens
                'and the Position of the first Hit is set
                'This is defined by the Angle Phi,
                'that is the Angle between the Direction of the first Ball Movement and the x-Axis
                Dim phi As Decimal = ActiveBilliardball.SetAndDrawUserEndposition(Mouseposition, True)

                'For the PhasePortrait, we need the Hit-Angle Alfa as well
                Dim alfa = ActiveBilliardball.CalculateAlfa(ActiveBilliardball.Startparameter, phi)
                TxtAlfa.Text = alfa.ToString(CultureInfo.CurrentCulture)
                ActiveBilliardball.Startangle = alfa
                ActiveBilliardball.IsStartangleSet = True
                DS.BilliardBallCollection.Add(ActiveBilliardball)
            End If

            'The Mouse gets its normal behaviour again
            Cursor = Cursors.Arrow
            IsMousedown = False

        End If


    End Sub

    Private Sub PicBilliardTable_MouseMove(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseMove

        If IsMousedown Then
            MouseMoving(e)
        End If

    End Sub

    Private Sub MouseMoving(e As MouseEventArgs)

        'Because the Cursor is "Hand", the Mouse Position is adjusted a bit
        Dim Mouseposition As New Point With {
            .X = e.X + 2,
            .Y = e.Y - 25
        }

        If ActiveBilliardball IsNot Nothing Then

            If Not ActiveBilliardball.IsStartpositionSet Then

                'The actual Position of the Mouse is hold by the Parameter t
                ActiveBilliardball.SetAndDrawUserStartposition(Mouseposition, False)

            ElseIf Not ActiveBilliardball.IsStartangleSet Then

                'The actual Start Angle is hold by Phi, the Angle between the first Ball Movement and the x-Axis
                ActiveBilliardball.SetAndDrawUserEndposition(Mouseposition, False)

            End If
        End If
    End Sub

    'SECTOR CHECKS

    Private Function IsUserDataOK() As Boolean

        Dim CheckStartposition = New ClsCheckUserData(TxtT, DS.TValueRange)
        Dim CheckStartangle = New ClsCheckUserData(TxtAlfa, DS.AlfaValueRange)

        Return CheckStartposition.IsTxtValueAllowed And CheckStartangle.IsTxtValueAllowed _
            And IsParameterOK()
    End Function

    Private Function IsParameterOK() As Boolean

        Dim CheckParameter = New ClsCheckUserData(TxtParameter, DS.ParameterRange)

        Return CheckParameter.IsTxtValueAllowed
    End Function

    Private Function IsBilliardballExisting() As Boolean

        If DS.BilliardBallCollection.Count > 0 Then
            Return True
        Else
            MessageBox.Show(FrmMain.LM.GetString("NoBallsOnTable"))
            Return False
        End If

    End Function

    Private Sub BtnTakeOverStartParameter_Click(sender As Object, e As EventArgs) Handles BtnTakeOverStartParameter.Click

        If IsFormLoaded Then
            If ActiveBilliardball IsNot Nothing Then
                If IsUserDataOK() Then

                    'Parameter of the Start Point
                    Dim t As Decimal = CDec(TxtT.Text)
                    ActiveBilliardball.Startparameter = t

                    'Start Angle
                    Dim alfa As Decimal = CDec(TxtAlfa.Text)
                    ActiveBilliardball.Startangle = alfa

                    DS.BilliardBallCollection.Add(ActiveBilliardball)
                Else
                    'There are already Error messages generated
                End If
            Else
                MessageBox.Show(FrmMain.LM.GetString("NoBallsOnTable"))
            End If
        End If

    End Sub

    'SECTOR ITERATION

    Private Sub BtnNextStep_Click(sender As Object, e As EventArgs) Handles BtnNextStep.Click

        If IsFormLoaded Then
            If DS.IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
                If IsBilliardballExisting() Then
                    If IsUserDataOK() Then
                        DS.IterationStatus = ClsDynamics.EnIterationStatus.Ready
                    Else
                        'Message already generated
                    End If
                End If
            End If

            If DS.IterationStatus = ClsDynamics.EnIterationStatus.Ready Then

                DS.IterationStep()

            End If

            'The iterationstatus is set to stopped by ResetIteration

        End If
    End Sub

    Private Async Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click

        If IsFormLoaded Then
            If DS.IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
                If IsBilliardballExisting() Then
                    If IsUserDataOK() Then
                        BtnStart.Text = FrmMain.LM.GetString("Continue")
                        BtnStart.Enabled = False
                        BtnReset.Enabled = False
                        BtnTakeOverStartParameter.Enabled = False
                        BtnNewBall.Enabled = False
                        BtnNextStep.Enabled = False
                        DS.IterationStatus = ClsDynamics.EnIterationStatus.Ready
                    Else
                        'Message already generated
                    End If
                End If
            End If

            If DS.IterationStatus = ClsDynamics.EnIterationStatus.Ready Or
                        DS.IterationStatus = ClsDynamics.EnIterationStatus.Interrupted Then
                DS.IterationStatus = ClsDynamics.EnIterationStatus.Running
                Application.DoEvents()

                Await DS.IterationLoop()

            End If
        End If

    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click

        If IsFormLoaded Then
            DS.IterationStatus = ClsDynamics.EnIterationStatus.Interrupted
            BtnStart.Enabled = True
            BtnReset.Enabled = True
            BtnTakeOverStartParameter.Enabled = True
        End If
    End Sub

    Private Sub BtnPhasePortrait_Click(sender As Object, e As EventArgs) Handles BtnPhasePortrait.Click

        If IsFormLoaded Then
            If IsUserDataOK() Then
                ResetIteration()
                DS.PrepareBallsForPhaseportrait()
            End If
        End If
    End Sub

End Class