'This class would normally contain the controller

'Status Checked

Imports System.Globalization
Imports System.Reflection

Public Class ClsBilliardTableController

    Private MyForm As FrmBilliardtable

    Private LM As ClsLanguageManager

    Private DS As IBilliardTable

    'Tha active BilliardBall
    Private ActiveBilliardball As IBilliardball
    Private MyBilliardballCollection As List(Of IBilliardball)

    'Properties of the Ball
    Private Ballcolor As Brush

    'The Startposition of the Ball is set by the Mouse
    Private IsMousedown As Boolean = False

    'Iteration Control

    'Status of the Iteration
    'Number of Steps
    Private n As Integer

    Private IterationStatus As ClsDynamics.EnIterationStatus

    'When distributing BilliardBalls for the full PhasePortrait
    Private NumberOfBilliardBalls As Integer

    'SECTOR INITIALIZATION

    Public Sub New(Form As FrmBilliardtable)
        MyForm = Form
        LM = ClsLanguageManager.LM
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
                DSName = LM.GetString(type.Name, True)
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
                    If LM.GetString(type.Name, True) = SelectedName Then
                        DS = CType(Activator.CreateInstance(type), IBilliardTable)
                        Exit For
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
            .PhasePortrait = MyForm.PicPhasePortrait
            .ValueProtocol = MyForm.LstValueList
            MyForm.TrbParameterC.Minimum = CInt(.DSParameter.Range.A * 100)
            MyForm.TrbParameterC.Maximum = CInt(.DSParameter.Range.B * 100)
            MyForm.TrbParameterC.Value = CInt(.DSParameter.Range.A + .DSParameter.Range.IntervalWidth * 0.5 * 100)
            .C = .DSParameter.DefaultValue
        End With

        With MyForm.CboBallColor
            .Items.Clear()

            .Items.Add(LM.GetString("Red"))
            .Items.Add(LM.GetString("Green"))
            .Items.Add(LM.GetString("Blue"))
            .Items.Add(LM.GetString("Black"))
            .Items.Add(LM.GetString("Magenta"))
        End With

        'Setting Standard Values
        MyForm.CboBallColor.SelectedIndex = 0
        SetColor()

        MyForm.TrbSpeed.Value = 10
        MyForm.LblSpeed.Text = "10"

    End Sub

    Public Sub SetDefaultUserData()
        With MyForm
            .TxtT.Text = "0"
            .TxtAlfa.Text = "1"
            .TxtParameter.Text = DS.C.ToString
            .LblSpeed.Text = LM.GetString("BallSpeed") & " " & .TrbSpeed.Value.ToString
        End With
    End Sub

    Public Sub ResetIteration()

        DS.ResetIteration()
        With MyForm
            .PicPhasePortrait.Refresh()
            .LstValueList.Items.Clear()

            .BtnStart.Text = LM.GetString("Start")
            .BtnPhasePortrait.Text = LM.GetString("FillPhasePortrait")

            .BtnNewBall.Enabled = True
            .BtnNextStep.Enabled = True
        End With

        n = 0
        MyForm.LblSteps.Text = "0"
        IterationStatus = ClsDynamics.EnIterationStatus.Stopped

        SetControlsEnabled(True)

        'preparediagram
        DS.DrawBilliardtable()

    End Sub

    Public Sub SetParameterC()
        DS.C = CDec(MyForm.TxtParameter.Text)
        ResetIteration()
    End Sub

    Public Sub SetTrbC()
        If IsParameterOK() Then
            DS.C = CDec(MyForm.TxtParameter.Text)
            MyForm.TrbParameterC.Value = CInt(DS.C * 100)
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

        'The generated Balls can have different colors to be distinguished
        Select Case MyForm.CboBallColor.SelectedItem.ToString
            Case LM.GetString("Red")
                MyForm.LblColor.BackColor = Color.Red
                Ballcolor = Brushes.Red
            Case LM.GetString("Green")
                MyForm.LblColor.BackColor = Color.Green
                Ballcolor = Brushes.Green
            Case LM.GetString("Blue")
                MyForm.LblColor.BackColor = Color.Blue
                Ballcolor = Brushes.Blue
            Case LM.GetString("Black")
                MyForm.LblColor.BackColor = Color.Black
                Ballcolor = Brushes.Black
            Case Else
                MyForm.LblColor.BackColor = Color.Magenta
                Ballcolor = Brushes.Magenta
        End Select
    End Sub

    Private Sub SetControlsEnabled(IsEnabled As Boolean)
        With MyForm
            .BtnStart.Enabled = IsEnabled
            .BtnReset.Enabled = IsEnabled
            .BtnTakeOverStartParameter.Enabled = IsEnabled
            .BtnDefault.Enabled = IsEnabled
            .BtnPhasePortrait.Enabled = IsEnabled
            .BtnNewBall.Enabled = IsEnabled
            .BtnNextStep.Enabled = IsEnabled
            .TrbParameterC.Enabled = IsEnabled
            .ChkProtocol.Enabled = IsEnabled
            .CboBilliardTable.Enabled = IsEnabled
            .TxtParameter.Enabled = IsEnabled
            .CboBallColor.Enabled = IsEnabled
            .TxtAlfa.Enabled = IsEnabled
            .TxtT.Enabled = IsEnabled
        End With
    End Sub

    'SECTOR CREATE NEW OBJECT

    Public Sub CreateNewBall()
        If IsUserDataOK() Then
            ActiveBilliardball = DS.GetBilliardBall
            'Set GUI Parameters
            With ActiveBilliardball
                .BallColor = Ballcolor
                .BallSpeed = MyForm.TrbSpeed.Value
                .DrawFirstUserStartposition()
                .IsProtocol = MyForm.ChkProtocol.Checked
            End With

            'All the other parameters are set by DS
        End If
    End Sub

    Public Sub TakeOverStartParameter()

        If IsUserDataOK() Then

            If DS.BilliardBallCollection.Count = 0 Then
                CreateNewBall()
            End If

            If ActiveBilliardball.IsStartParameterSet Then
                CreateNewBall()
            End If

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

    Public Sub PrepareBallsForPhaseportrait()

        If IsUserDataOK() Then
            ResetIteration()

            'that gives a nice phaseportrait
            NumberOfBilliardBalls = 30

            'Generate Balls with startposition (0,b)
            'that is the zenith of the billardtable
            'and different startangles

            Dim i As Integer

            'Startparameter
            Dim t As Decimal
            Dim Alfa As Decimal

            Dim LocBilliardBall As IBilliardball
            'First Billardball to prepare general parameters
            LocBilliardBall = DS.GetBilliardBall()
            'C = MyC

            'the next start parameters are chosen that the phaseportrait gets a nice image
            If DS.C < 1 Then
                t = CDec(Math.PI / 2)
            Else
                t = 0
            End If

            Alfa = DS.AlfaValueParameter.DefaultValue

            With LocBilliardBall
                .BallColor = Brushes.Blue
                .Startparameter = t
                .IsStartParameterSet = True
                .Startangle = Alfa
                .IsStartangleSet = True
                .BallSpeed = 1000
                .IterationStep()
                .IsProtocol = False
            End With

            For i = 0 To NumberOfBilliardBalls
                LocBilliardBall = DS.GetBilliardBall()
                Alfa += CDec(Math.PI / NumberOfBilliardBalls)
                If Alfa < Math.PI Then
                    With LocBilliardBall
                        Select Case i Mod 5
                            Case 1
                                .BallColor = Brushes.Red
                            Case 2
                                .BallColor = Brushes.Green
                            Case 3
                                .BallColor = Brushes.Blue
                            Case 4
                                .BallColor = Brushes.Black
                            Case Else
                                .BallColor = Brushes.Magenta
                        End Select

                        .BallSpeed = 10000
                        .PhasePortrait = MyForm.PicPhasePortrait
                        'because of the performance, in thhis case
                        'no value protocol is generated
                        .ValueProtocol = Nothing
                        .Startparameter = t
                        .IsStartParameterSet = True
                        .Startangle = Alfa
                        .IsStartangleSet = True
                        .BallSpeed = 1000
                        .IterationStep()
                    End With
                    DS.BilliardBallCollection.Add(LocBilliardBall)
                End If
            Next
        End If
    End Sub

    'SECTOR ITERATION

    Public Async Sub NextStep()

        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            If IsBilliardballExisting() Then
                If IsUserDataOK() Then
                    IterationStatus = ClsDynamics.EnIterationStatus.Ready
                Else
                    'Message already generated
                End If
            End If
        End If

        If IterationStatus = ClsDynamics.EnIterationStatus.Ready Then

            Await IterationLoop(1)

        End If

        'The iterationstatus is set to stopped by ResetIteration

    End Sub

    Public Async Sub StartIteration()

        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            If IsBilliardballExisting() Then
                If IsUserDataOK() Then
                    SetControlsEnabled(False)
                    IterationStatus = ClsDynamics.EnIterationStatus.Ready
                Else
                    'Message already generated
                    ResetIteration()
                    SetDefaultUserData()
                End If
            End If
        End If

        If IterationStatus = ClsDynamics.EnIterationStatus.Ready Or
                    IterationStatus = ClsDynamics.EnIterationStatus.Interrupted Then
            IterationStatus = ClsDynamics.EnIterationStatus.Running
            With MyForm
                .BtnStart.Text = LM.GetString("Continue")
                .Cursor = Cursors.WaitCursor
            End With

            Application.DoEvents()

            Await IterationLoop(0)

        End If
    End Sub

    Public Async Function IterationLoop(NumberOfSteps As Integer) As Task

        Do
            n += 1

            If n Mod 5 = 0 Then
                MyForm.LblSteps.Text = (NumberOfBilliardBalls * n).ToString(CultureInfo.CurrentCulture)
            End If

            'Each Ball is now iterated 1x
            For Each Ball As IBilliardball In DS.BilliardBallCollection
                Ball.IterationStep()
            Next

            Application.DoEvents()
            Await Task.Delay(1)

            If NumberOfSteps > 0 Then
                If n >= NumberOfSteps Then
                    IterationStatus = ClsDynamics.EnIterationStatus.Stopped
                End If
            End If

        Loop Until IterationStatus = ClsDynamics.EnIterationStatus.Interrupted _
            Or IterationStatus = ClsDynamics.EnIterationStatus.Stopped

    End Function

    Public Sub StopIteration()
        IterationStatus = ClsDynamics.EnIterationStatus.Interrupted
        MyForm.Cursor = Cursors.Arrow
        MyForm.BtnStart.Enabled = True
        MyForm.BtnReset.Enabled = True
    End Sub

    'SECTOR CHECK USERDATA

    Private Function IsUserDataOK() As Boolean

        Dim CheckStartposition = New ClsCheckUserData(MyForm.TxtT, DS.TValueParameter.Range)
        Dim CheckStartangle = New ClsCheckUserData(MyForm.TxtAlfa, DS.AlfaValueParameter.Range)

        Return CheckStartposition.IsTxtValueAllowed And CheckStartangle.IsTxtValueAllowed _
            And IsParameterOK()
    End Function

    Private Function IsParameterOK() As Boolean

        Dim CheckParameter = New ClsCheckUserData(MyForm.TxtParameter, DS.DSParameter.Range)

        Return CheckParameter.IsTxtValueAllowed
    End Function

    Private Function IsBilliardballExisting() As Boolean

        If DS.BilliardBallCollection.Count > 0 Then
            For Each Ball As IBilliardball In DS.BilliardBallCollection
                Ball.IsProtocol = MyForm.ChkProtocol.Checked
            Next
            NumberOfBilliardBalls = DS.BilliardBallCollection.Count
            Return True
        Else
            MessageBox.Show(LM.GetString("NoBallsOnTable"))
            Return False
        End If

    End Function

    'SECTOR SET STARTPARAMETER

    Public Sub MouseDown(e As MouseEventArgs)
        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            If ActiveBilliardball IsNot Nothing Then

                If Not (ActiveBilliardball.IsStartParameterSet And ActiveBilliardball.IsStartangleSet) Then

                    MyForm.Cursor = Cursors.Hand
                    IsMousedown = True

                    'Now, Moving the Mouse moves the Ball as well
                    MouseMove(e)

                End If
            End If
        End If
    End Sub

    Public Sub MouseMove(e As MouseEventArgs)
        If IsMousedown Then
            'Because the Cursor is "Hand", the Mouse Position is adjusted a bit
            Dim Mouseposition As New Point With {
            .X = e.X + 2,
            .Y = e.Y - 25
        }

            If ActiveBilliardball IsNot Nothing Then

                If Not ActiveBilliardball.IsStartParameterSet Then

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

            If Not ActiveBilliardball.IsStartParameterSet Then

                'This is the first Time that the MouseUp event happens
                'and the Position of the Mouse sets the Start Position of the Ball
                'This Start Position is defined by the according Parameter t
                Dim t As Decimal = ActiveBilliardball.SetAndDrawUserStartposition(Mouseposition, True)
                MyForm.TxtT.Text = t.ToString(CultureInfo.CurrentCulture)

                't is as well transmitted to the Ball
                ActiveBilliardball.Startparameter = t
                ActiveBilliardball.IsStartParameterSet = True

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

