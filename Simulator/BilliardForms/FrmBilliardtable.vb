'This Form is the User Interface for all Investigations of different Billiards
'like elliptic, stadium or oval
'it is based on the interfaces IBilliardBall
'that are implemented by the according classes ClsEllipticBilliardTable, ClsEllipticBilliardBall, etc.
'see mathematical documentation
'if other Billiards are programmed, the according classes have just to implement this interface

'Status Checked

Imports System.Globalization
Imports System.IO.Ports
Imports System.Reflection

Public Class FrmBilliardtable

    'Prepare objects
    Private MapBilliardtable As Bitmap

    'Default for drawing BilliardTable etc.
    Private DefaultBilliardBall As IBilliardball

    'Moving BilliardBalls
    Private Billiardball As IBilliardball
    Private MyBilliardballCollection As List(Of IBilliardball)

    'BilliardTable
    Private IsBilliardtableDrawn As Boolean = False
    Private IsFirstIterationstep As Boolean = True

    'Number of Steps
    Private n As Integer

    'Iteration Control
    Private StopIteration As Boolean

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

        Text = Main.LM.GetString("Billiard")
        BtnPhasePortrait.Text = Main.LM.GetString("FillPhasePortrait")
        LblNumberOfSteps.Text = Main.LM.GetString("NumberOfSteps")
        LblBilliardTable.Text = Main.LM.GetString("BilliardTable")
        LblAlfa.Text = Main.LM.GetString("Alfa")
        BtnTakeOverStartParameter.Text = Main.LM.GetString("TakeOver")
        GrpStartParameter.Text = Main.LM.GetString("StartParameter")
        LblPhasePortrait.Text = Main.LM.GetString("PhasePortrait") & ": t, alfa"
        LblSpeed.Text = Main.LM.GetString("BallSpeed") & " " & TrbSpeed.Value.ToString
        LblBallColor.Text = Main.LM.GetString("BallColor")
        BtnNewBall.Text = Main.LM.GetString("NewBall")
        BtnStart.Text = Main.LM.GetString("Start")
        BtnReset.Text = Main.LM.GetString("ResetIteration")
        BtnNextStep.Text = Main.LM.GetString("NextStep")
        LblParameterc.Text = Main.LM.GetString("FactorC")
        BtnDrawBilliardTable.Text = Main.LM.GetString("DrawBilliardTable")
        TxtFactor.Text = ""

        CboBallColor.Items.Clear()

        'the following order of adding the iteration type is relevant!
        'there is at the moment no better concept implemented to identify the type of Billiard
        CboBallColor.Items.Add(Main.LM.GetString("Red"))
        CboBallColor.Items.Add(Main.LM.GetString("Green"))
        CboBallColor.Items.Add(Main.LM.GetString("Blue"))
        CboBallColor.Items.Add(Main.LM.GetString("Black"))
        CboBallColor.Items.Add(Main.LM.GetString("Magenta"))

        CboBilliardTable.Items.Clear()

        'Add the classes implementing IBilliardBall
        'to the Combobox CboBilliardTable by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IBilliardball)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If types.Count > 0 Then
            Dim BilliardName As String
            For Each type In types

                'GetString is calle dwith the option IsClass = true
                'That effects that - if there is no Entry in the Resource files LabelsEN, LabelsDE -
                'the name of the Class implementing an Interface is used as default
                'suppressing the extension "Cls"
                BilliardName = Main.LM.GetString(type.Name, True)
                CboBilliardTable.Items.Add(BilliardName)
            Next

            CboBilliardTable.SelectedIndex = CboBilliardTable.Items.Count - 1
            CboBilliardTable.Select()

        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If


    End Sub

    Private Sub FrmBilliardTable_Load(sender As Object, e As EventArgs) Handles Me.Load

        'The Bitmap "MapBilliardTable" contains the profile of the BilliardTable
        'and shows the Trace of each Ball
        'the movement of the Ball is shown in the PicBilliardTable and 
        'actualized by refreshing PicBilliardTable
        'the Bitmap and PicDiagram are Squares
        Dim Squareside As Integer = Math.Min(PicBilliardTable.Width, PicBilliardTable.Height)
        PicBilliardTable.Width = Squareside
        PicBilliardTable.Height = Squareside
        MapBilliardtable = New Bitmap(Squareside, Squareside)

        'The Bitmap MapBilliardTable is then shown as Image of PicBilliardTable
        PicBilliardTable.Image = MapBilliardtable

        'The Phase Portrait is a square
        Squareside = Math.Min(PicPhasePortrait.Width, PicPhasePortrait.Height)
        PicPhasePortrait.Width = Squareside
        PicPhasePortrait.Height = Squareside

        'The collection of all Billiard Balls on the Table
        MyBilliardballCollection = New List(Of IBilliardball)

        'Setting Standard Values
        CboBallColor.SelectedIndex = 0

        'Initialize Language
        InitializeLanguage()

    End Sub

    Private Sub BtnDrawBilliardTable_Click(sender As Object, e As EventArgs) Handles BtnDrawBilliardTable.Click

        Reset()

        If CheckFactorC() Then
            DefaultBilliardBall.C = CDec(TxtFactor.Text)
            DefaultBilliardBall.DrawBilliardtable()
            PicBilliardTable.Refresh()
            IsBilliardtableDrawn = True
        End If

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        Reset()
    End Sub

    Private Sub Reset()

        DefaultBilliardBall.ClearBilliardTable()
        PicBilliardTable.Refresh()
        PicPhasePortrait.Refresh()

        If MyBilliardballCollection IsNot Nothing Then
            For Each Billiardball In MyBilliardballCollection
                Billiardball = Nothing
            Next
            MyBilliardballCollection.Clear()
        End If

        IsBilliardtableDrawn = False
        LstParameterList.Items.Clear()

        n = 0
        LblIterationSteps.Text = "0"
        StopIteration = True
        BtnStart.Text = Main.LM.GetString("Start")
        BtnPhasePortrait.Text = Main.LM.GetString("FillPhasePortrait")

        BtnDrawBilliardTable.Enabled = True
        BtnNewBall.Enabled = True
        BtnNextStep.Enabled = True

    End Sub

    Private Function GetBilliardBall() As IBilliardball

        'This sets the type of BilliardBall by Reflection
        'Default is EllipseBilliardball
        Dim LocBilliardBall As IBilliardball = New ClsEllipseBilliardball

        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IBilliardball)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If CboBilliardTable.SelectedIndex >= 0 Then

            Dim SelectedName As String = CboBilliardTable.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If Main.LM.GetString(type.Name, True) = SelectedName Then
                        LocBilliardBall = CType(Activator.CreateInstance(type), IBilliardball)
                    End If
                Next
            End If

        End If

        With LocBilliardBall
            .Billiardtable = PicBilliardTable
            .MapBilliardtable = MapBilliardtable

            'Setting the properties of the Ball
            .Ballcolor = Ballcolor
            .Ballsize = 4
            .Ballspeed = TrbSpeed.Value
            .ParameterProtocol = LstParameterList

            'C influences the Value Range of the Parameter t
            'Therefore C is set first
            If TxtFactor.Text = "" Then
                TxtFactor.Text = .C.ToString
            Else
                .C = CDec(TxtFactor.Text)
            End If

            'and then the Phase Portrait containing the Parameter
            .Phaseportrait = PicPhasePortrait

            'The Startpostition of the Ball is set later by the Mouse Position
            .IsStartpositionSet = False
            .IsStartangleSet = False
        End With


        Return LocBilliardBall

    End Function

    Private Sub CboBilliardTable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboBilliardTable.SelectedIndexChanged

        TxtFactor.Text = ""

        'This sets the type of Billiardball by Reflection
        DefaultBilliardBall = GetBilliardBall()
        TxtFactor.Text = DefaultBilliardBall.C.ToString

        Reset()

    End Sub

    Private Sub TxtFactor_TextChanged(sender As Object, e As EventArgs) Handles TxtFactor.TextChanged
        If IsBilliardtableDrawn Then
            Reset()
        End If
    End Sub

    'SECTOR CHECKS

    Private Function CheckFactorC() As Boolean

        Dim OK As Boolean

        'Depending of the Type of the Billiard Table, C defines the Profile of the Table
        'See the Code of the classes for the Billiard Table / -Ball
        Dim C As Decimal

        Dim FactorC = New ClsCheckIsNumeric(TxtFactor)

        If FactorC.IsInputValid Then
            C = FactorC.NumericValue
            If C <= 0 Then
                TxtFactor.Text = ""
                TxtFactor.Select()
                MessageBox.Show("C " & Main.LM.GetString("PositiveNumber"))
                OK = False
            Else
                OK = True
            End If
        Else
            OK = False
        End If

        Return OK

    End Function

    Private Function CheckStartparameter() As Boolean

        Dim OK As Boolean
        Dim ParameterT = New ClsCheckIsNumeric(TxtT)

        If ParameterT.IsInputValid Then
            Dim ParameterAlfa = New ClsCheckIsNumeric(TxtAlfa)
            If ParameterAlfa.IsInputValid Then
                OK = True
            Else
                OK = False
            End If
        Else
            OK = False
        End If

        Return OK

    End Function

    'SECTOR GENERATE A NEW BALL

    Private Sub BtnNewBall_Click(sender As Object, e As EventArgs) Handles BtnNewBall.Click

        GenerateNewball()

    End Sub

    Private Sub GenerateNewball()

        'The Factor C must be OK
        If CheckFactorC() Then

            If Not IsBilliardtableDrawn Then
                DefaultBilliardBall.C = CDec(TxtFactor.Text)
                DefaultBilliardBall.DrawBilliardtable()
                PicBilliardTable.Refresh()
            End If

            Billiardball = GetBilliardBall()

            MyBilliardballCollection.Add(Billiardball)

        Else
            'There is already a message generated
        End If

    End Sub

    Private Sub CboBallColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboBallColor.SelectedIndexChanged

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

    End Sub

    'SECTOR SET STARTPOSITION AND POSITION OF THE FIRST HIT

    Private Sub PicBilliardTable_MouseDown(sender As Object, e As MouseEventArgs) Handles PicBilliardTable.MouseDown

        If Billiardball IsNot Nothing Then

            If Not (Billiardball.IsStartpositionSet And Billiardball.IsStartangleSet) Then

                Cursor = Cursors.Hand
                IsMousedown = True

                'Now, Moving the Mouse moves the Ball as well
                MouseMoving(e)

            End If
        End If

    End Sub

    Private Sub PicBilliardTable_MouseUp(sender As Object, e As MouseEventArgs) Handles PicBilliardTable.MouseUp

        'Has only an effect, if the Mouse was down
        If IsMousedown Then

            'The Position of the Mouse sets the Position of the Ball below
            'e: Mouseposition is relative to PicBilliardTable
            Dim Mouseposition As Point
            Mouseposition.X = e.X + 2
            Mouseposition.Y = e.Y - 25

            If Not Billiardball.IsStartpositionSet Then

                'This is the first Time that the MouseUp event happens
                'and the Position of the Mouse sets the Start Position of the Ball
                'This Start Position is defined by the according Parameter t
                Dim t As Decimal = Billiardball.SetAndDrawUserStartposition(Mouseposition, True)
                TxtT.Text = t.ToString(CultureInfo.CurrentCulture)

                't is as well transmitted to the Ball
                Billiardball.Startparameter = t
                Billiardball.IsStartpositionSet = True

            ElseIf Not Billiardball.IsStartangleSet Then

                'This is the second time that the MouseUp event happens
                'and the Position of the first Hit is set
                'This is defined by the Angle Phi,
                'that is the Angle between the Direction of the first Ball Movement and the x-Axis
                Dim phi As Decimal = Billiardball.SetAndDrawUserEndposition(Mouseposition, True)

                'For the PhasePortrait, we need the Hit-Angle Alfa as well
                Dim alfa = Billiardball.CalculateAlfa(Billiardball.Startparameter, phi)
                TxtAlfa.Text = alfa.ToString(CultureInfo.CurrentCulture)
                Billiardball.Startangle = alfa
                Billiardball.IsStartangleSet = True
            End If

            'The Mouse gets its normal behaviour again
            Cursor = Cursors.Arrow
            IsMousedown = False

        End If


    End Sub

    Private Sub PicBilliardTable_MouseMove(sender As Object, e As MouseEventArgs) Handles PicBilliardTable.MouseMove

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

        If Billiardball IsNot Nothing Then

            If Not Billiardball.IsStartpositionSet Then

                'The actual Position of the Mouse is hold by the Parameter t
                Billiardball.SetAndDrawUserStartposition(Mouseposition, False)

            ElseIf Not Billiardball.IsStartangleSet Then

                'The actual Start Angle is hold by Phi, the Angle between the first Ball Movement and the x-Axis
                Billiardball.SetAndDrawUserEndposition(Mouseposition, False)

            End If
        End If
    End Sub

    Private Sub BtnTakeOverStartParameter_Click(sender As Object, e As EventArgs) Handles BtnTakeOverStartParameter.Click

        'The Start Parameters are transmitted to the Ball and then, the Ball uses them as Start Parameters
        If Billiardball Is Nothing Then
            GenerateNewball()
        End If

        If CheckStartparameter() Then

            'Parameter of the Start Point
            Dim t As Decimal = CDec(TxtT.Text)
            Billiardball.Startparameter = t

            'Start Angle
            Dim alfa As Decimal = CDec(TxtAlfa.Text)
            Billiardball.Startangle = alfa

        End If

    End Sub

    'SECTOR ITERATION

    Private Async Sub BtnNextStep_Click(sender As Object, e As EventArgs) Handles BtnNextStep.Click

        If IsIterationReady() Then
            Await Iteration(1)
        Else
            'Message already generated
        End If

    End Sub

    Private Async Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click

        If IsIterationReady() Then

            'the iteration was stopped or reset
            'and should start from the beginning
            StopIteration = False

            BtnStart.Text = Main.LM.GetString("Continue")
            BtnStart.Enabled = False
            BtnReset.Enabled = False
            BtnTakeOverStartParameter.Enabled = False
            BtnDrawBilliardTable.Enabled = False
            BtnNewBall.Enabled = False
            BtnNextStep.Enabled = False

            Application.DoEvents()

            Await Iteration(0)

        Else

            'Message already generated

        End If

    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click

        'the iteration is running and should be stopped
        StopIteration = True

        BtnStart.Enabled = True
        BtnReset.Enabled = True
        BtnTakeOverStartParameter.Enabled = True

    End Sub

    Private Sub BtnPhasePortrait_Click(sender As Object, e As EventArgs) Handles BtnPhasePortrait.Click

        PreparePhaseportraitBalls()

    End Sub

    Private Sub TrbSpeed_Scroll(sender As Object, e As EventArgs) Handles TrbSpeed.Scroll

        'All Billiard Balls have the same speed
        For Each Ball As IBilliardball In MyBilliardballCollection
            Ball.Ballspeed = TrbSpeed.Value
        Next

    End Sub

    Private Sub PreparePhaseportraitBalls()

        'Generate Balls with startposition (0,b)
        'that is the zenith of the billardtable
        'and different startangles

        Dim NumberOfBalls As Integer = 31
        Dim i As Integer

        'Startparameter
        Dim t As Decimal
        Dim Alfa As Decimal

        Dim LocBilliardBall As IBilliardball
        'First Billardball to prepare general parameters
        LocBilliardBall = GetBilliardBall()

        Reset()
        If CheckFactorC() Then
            LocBilliardBall.C = CDec(TxtFactor.Text)
            LocBilliardBall.DrawBilliardtable()
            PicBilliardTable.Refresh()
            IsBilliardtableDrawn = True

            'the next start parameters are chosen that the phaseportrait gets a nice image
            Select Case True
                Case TypeOf LocBilliardBall Is ClsEllipseBilliardball
                    t = CDec(Math.PI / 2)
                    Alfa = CDec(0.001)
                Case TypeOf LocBilliardBall Is ClsOvalBilliardball
                    t = CDec(Math.PI / 2)
                    Alfa = CDec(Math.PI / NumberOfBalls)
                Case Else
                    t = CDec(0.95) / (1 + LocBilliardBall.C)
                    Alfa = CDec(Math.PI / NumberOfBalls)
            End Select

            With LocBilliardBall
                .Ballcolor = Brushes.Blue
                .Startparameter = t
                .IsStartpositionSet = True
                .Startangle = Alfa
                .IsStartangleSet = True
                .Iteration(1)
            End With

            MyBilliardballCollection.Add(LocBilliardBall)

            For i = 1 To NumberOfBalls
                LocBilliardBall = GetBilliardBall()
                Alfa += CDec(Math.PI / NumberOfBalls)
                If Alfa < Math.PI Then
                    With LocBilliardBall
                        .Ballcolor = Brushes.Blue
                        .Startparameter = t
                        .IsStartpositionSet = True
                        .Startangle = Alfa
                        .IsStartangleSet = True
                        .Iteration(1)
                    End With
                    MyBilliardballCollection.Add(LocBilliardBall)
                End If
            Next

        End If
    End Sub

    Private Function IsIterationReady() As Boolean

        Dim LocIsReady As Boolean = True

        If MyBilliardballCollection.Count > 0 Then
            For Each Ball As IBilliardball In MyBilliardballCollection
                If Ball.IsStartpositionSet And Ball.IsStartangleSet Then
                    'nothing
                Else
                    MessageBox.Show(Main.LM.GetString("StartPositionNotSet"))
                    LocIsReady = False
                End If
            Next
        Else
            MessageBox.Show(Main.LM.GetString("NoBallsOnTable"))
            LocIsReady = False
        End If

        If LocIsReady Then
            PicBilliardTable.Refresh()
        End If

        Return LocIsReady

    End Function

    Private Async Function Iteration(NumberOfSteps As Integer) As Task

        Do
            n += 1
            LblIterationSteps.Text = n.ToString(CultureInfo.CurrentCulture)

            'If NumberOfSteps is > 0, then the iteration stops after NumberOfSteps
            If n = NumberOfSteps Then StopIteration = True

            'Each Ball is now iterated 1x
            For Each Ball As IBilliardball In MyBilliardballCollection
                Ball.Iteration(1)
            Next

            If n Mod 2 = 0 Then
                Await Task.Delay(2)
            End If

        Loop Until StopIteration

    End Function

    Private Sub TrbSpeed_ValueChanged(sender As Object, e As EventArgs) Handles TrbSpeed.ValueChanged
        LblSpeed.Text = Main.LM.GetString("BallSpeed") & " " & TrbSpeed.Value.ToString
    End Sub

End Class