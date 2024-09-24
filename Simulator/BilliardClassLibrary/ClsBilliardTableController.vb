'This class would normally contain the controller

'Status Checked

Imports System.Globalization
Imports System.Reflection

Public Class ClsBilliardTableController

    Private MyForm As FrmBilliardtable

    Private DS As IBilliardTable

    'Tha active BilliardBall
    Private ActiveBilliardball As IBilliardball

    'Properties of the Ball
    Private Ballcolor As Brush

    'The Startposition of the Ball is set by the Mouse
    Private IsMousedown As Boolean = False

    Public Sub New(Form As FrmBilliardtable)
        MyForm = Form
    End Sub

    Public Sub FillDynamicSystem()

        MyForm.CboBilliardTable.Items.Clear()

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
                MyForm.CboBilliardTable.Items.Add(DSName)
            Next

        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If
        MyForm.CboBilliardTable.SelectedIndex = 0

    End Sub

    Public Sub SetDS()

        'This sets the type of BilliardTable by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IBilliardTable)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If MyForm.CboBilliardTable.SelectedIndex >= 0 Then

            Dim SelectedName As String = MyForm.CboBilliardTable.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If FrmMain.LM.GetString(type.Name, True) = SelectedName Then
                        DS = CType(Activator.CreateInstance(type), IBilliardTable)
                    End If
                Next
            End If

        End If

        InitializeMe()


        SetDefaultUserData()

        'If the type of iteration changes, everything has to be reset
        ResetIteration()

    End Sub

    Private Sub InitializeMe()
        With DS
            .PicDiagram = MyForm.PicDiagram
            .LblN = MyForm.LblSteps
            .PhasePortrait = MyForm.PicPhasePortrait
            .ValueProtocol = MyForm.LstValueList
            MyForm.TrbParameterC.Minimum = CInt(.FormulaParameter.Range.A * 100)
            MyForm.TrbParameterC.Maximum = CInt(.FormulaParameter.Range.B * 100)
            MyForm.TrbParameterC.Value = CInt(.FormulaParameter.Range.A + .FormulaParameter.Range.IntervalWidth * 0.5 * 100)
            .C = CDec(MyForm.TrbParameterC.Value * 0.01)
        End With

        'Setting Standard Values
        MyForm.CboBallColor.SelectedIndex = 0
        Ballcolor = Brushes.Red

        MyForm.TrbSpeed.Value = 10
        MyForm.LblSpeed.Text = "10"

    End Sub

    Public Sub SetDefaultUserData()
        With MyForm
            .TxtT.Text = "0"
            .TxtAlfa.Text = "1"
            .TxtParameter.Text = DS.C.ToString
        End With
    End Sub

    Public Sub ResetIteration()

        DS.ResetIteration()
        With MyForm
            .PicPhasePortrait.Refresh()
            .LstValueList.Items.Clear()

            .BtnStart.Text = FrmMain.LM.GetString("Start")
            .BtnPhasePortrait.Text = FrmMain.LM.GetString("FillPhasePortrait")

            .BtnNewBall.Enabled = True
            .BtnNextStep.Enabled = True
        End With

        'preparediagram
        DS.DrawBilliardtable()

    End Sub

    Public Sub SetParameterC()
        If IsParameterOK() Then
            DS.C = CDec(MyForm.TxtParameter.Text)
            ResetIteration()
        End If
    End Sub

    Public Sub SetSpeed()
        'All Billiard Balls have the same speed
        For Each Ball As IBilliardball In DS.BilliardBallCollection
            Ball.BallSpeed = MyForm.TrbSpeed.Value
        Next
    End Sub

    Public Sub SetColor()
        'Is this needed??
        'The generated Balls can have different colors to be distinguished
        Select Case MyForm.CboBallColor.SelectedIndex
            Case 0
                MyForm.LblColor.BackColor = Color.Red
                Ballcolor = Brushes.Red
            Case 1
                MyForm.LblColor.BackColor = Color.Green
                Ballcolor = Brushes.Green
            Case 2
                MyForm.LblColor.BackColor = Color.Blue
                Ballcolor = Brushes.Blue
            Case 3
                MyForm.LblColor.BackColor = Color.Black
                Ballcolor = Brushes.Black
            Case Else
                MyForm.LblColor.BackColor = Color.Magenta
                Ballcolor = Brushes.Magenta
        End Select
    End Sub

    Public Sub CreateNewBall()
        If IsUserDataOK() Then
            ActiveBilliardball = DS.GetBilliardBall
            'Set GUI Parameters
            With ActiveBilliardball
                .BallColor = Ballcolor
                .BallSpeed = MyForm.TrbSpeed.Value
                .DrawFirstUserStartposition()
            End With

            'All the other parameters are set by DS
        End If
    End Sub

    'SECTOR ITERATION

    Public Sub TakeOverStartParameter()

        If IsUserDataOK() Then
                DS.BilliardBallCollection.Clear()
                ResetIteration()

                CreateNewBall()

            'Parameter of the Start Point
            Dim t As Decimal = CDec(MyForm.TxtT.Text)
                ActiveBilliardball.Startparameter = t

                'Start Angle
                Dim alfa As Decimal = CDec(MyForm.TxtAlfa.Text)
                ActiveBilliardball.Startangle = alfa

                DS.BilliardBallCollection.Add(ActiveBilliardball)
            Else
                'There are already Error messages generated
            End If

    End Sub

    Public Sub NextStep()

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

            DS.IterationLoop(1)

        End If

        'The iterationstatus is set to stopped by ResetIteration

    End Sub

    Public Async Sub StartIteration()

        If DS.IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            If IsBilliardballExisting() Then
                If IsUserDataOK() Then
                    With MyForm
                        .BtnStart.Text = FrmMain.LM.GetString("Continue")
                        .BtnStart.Enabled = False
                        .BtnReset.Enabled = False
                        .BtnTakeOverStartParameter.Enabled = False
                        .BtnNewBall.Enabled = False
                        .BtnNextStep.Enabled = False
                        .BtnDefault.Enabled = False
                        .BtnPhasePortrait.Enabled = False
                    End With
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

            Await DS.IterationLoop(0)

        End If
    End Sub

    Public Sub StopIteration()
        DS.IterationStatus = ClsDynamics.EnIterationStatus.Interrupted
        With MyForm
            .BtnStart.Enabled = True
            .BtnReset.Enabled = True
            .BtnTakeOverStartParameter.Enabled = True
            .BtnDefault.Enabled = True
            .BtnPhasePortrait.Enabled = True
        End With
    End Sub

    Public Sub PrepareBallsForPhasePortrait()
        If IsUserDataOK() Then
            ResetIteration()
            DS.PrepareBallsForPhaseportrait()
        End If
    End Sub

    'SECTOR CHECKS

    Private Function IsUserDataOK() As Boolean

        Dim CheckStartposition = New ClsCheckUserData(MyForm.TxtT, DS.TValueParameter.Range)
        Dim CheckStartangle = New ClsCheckUserData(MyForm.TxtAlfa, DS.AlfaValueParameter.Range)

        Return CheckStartposition.IsTxtValueAllowed And CheckStartangle.IsTxtValueAllowed _
            And IsParameterOK()
    End Function

    Private Function IsParameterOK() As Boolean

        Dim CheckParameter = New ClsCheckUserData(MyForm.TxtParameter, DS.FormulaParameter.Range)

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

    'SECTOR SET USERSTARTPARAMETER

    Public Sub MouseDown(e As MouseEventArgs)
        If DS.IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            If ActiveBilliardball IsNot Nothing Then

                If Not (ActiveBilliardball.IsStartpositionSet And ActiveBilliardball.IsStartangleSet) Then

                    MyForm.Cursor = Cursors.Hand
                    IsMousedown = True

                    'Now, Moving the Mouse moves the Ball as well
                    MouseMoving(e)

                End If
            End If
        End If
    End Sub

    Public Sub MouseMoving(e As MouseEventArgs)
        If IsMousedown Then
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
        End If
    End Sub
    Public Sub MouseUp(e As MouseEventArgs)

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
                MyForm.TxtT.Text = t.ToString(CultureInfo.CurrentCulture)

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
                MyForm.TxtAlfa.Text = alfa.ToString(CultureInfo.CurrentCulture)
                ActiveBilliardball.Startangle = alfa
                ActiveBilliardball.IsStartangleSet = True
                DS.BilliardBallCollection.Add(ActiveBilliardball)
            End If

            'The Mouse gets its normal behaviour again
            MyForm.Cursor = Cursors.Arrow
            IsMousedown = False

        End If

    End Sub
End Class

