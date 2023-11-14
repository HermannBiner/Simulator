'This Form is the User Interface for all Investigations of different Billiards
'like elliptic, stadium or oval
'it is based on the interfaces IBilliardTable and IBilliardBall
'that are implemented by the according classes ClsEllipticBilliardTable, ClsEllipticBilliardBall, etc.
'see mathematical documentation
'if other Billiards are programmed, the according classes have just to implement these interfaces

'Status Checked

Imports System.Globalization

Public Class FrmBilliardtable

    'Prepare objects
    Private Billiardtable As IBilliardtable
    Private MapBilliardtable As Bitmap
    Private Billiardball As IBilliardball
    Private MyBilliardballCollection As List(Of IBilliardball)

    'BilliardTable
    Private IsBilliardtableDrawn As Boolean = False
    Private IsFirstIterationstep As Boolean = True

    'Number of Steps
    Private n As Integer

    'Properties of the Ball
    Private Ballcolor As Brush

    'The Startposition of the Ball is set by the Mouse
    Private IsMousedown As Boolean = False

    'Standard Value for Parameter C
    Private StandardC As Decimal = CDec(0.8)

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

        'Initialize Language
        InitializeLanguage()

    End Sub

    Private Sub InitializeLanguage()

        Text = Main.LM.GetString("Billiard")
        BtnNext100.Text = Main.LM.GetString("Next100Steps")
        LblNumber.Text = Main.LM.GetString("NumberOfSteps")
        LblBilliardTable.Text = Main.LM.GetString("BilliardTable")
        LblAlfa.Text = Main.LM.GetString("Alfa")
        BtnUseStartParameter.Text = Main.LM.GetString("TakeOver")
        GrpStartParameter.Text = Main.LM.GetString("StartParameter")
        LblPhasePortrait.Text = Main.LM.GetString("PhasePortrait")
        LblSpeed.Text = Main.LM.GetString("BallSpeed")
        LblBallColor.Text = Main.LM.GetString("BallColor")
        BtnNewBall.Text = Main.LM.GetString("NewBall")
        BtnNext10.Text = Main.LM.GetString("Next10Steps")
        BtnReset.Text = Main.LM.GetString("ResetIteration")
        BtnNextStep.Text = Main.LM.GetString("NextStep")
        LblParameterc.Text = Main.LM.GetString("FactorC")
        BtnDrawBilliardTable.Text = Main.LM.GetString("DrawBilliardTable")

        CboBallColor.Items.Clear()

        'the following order of adding the iteration type is relevant!
        'there is at the moment no better concept implemented to identify the type of Billiard
        CboBallColor.Items.Add(Main.LM.GetString("Red"))
        CboBallColor.Items.Add(Main.LM.GetString("Green"))
        CboBallColor.Items.Add(Main.LM.GetString("Blue"))
        CboBallColor.Items.Add(Main.LM.GetString("Black"))
        CboBallColor.Items.Add(Main.LM.GetString("Magenta"))

        CboBilliardTable.Items.Clear()

        'the following order of adding the iteration type is relevant!
        'there is at the moment no better concept implemented to identify the type of Billiard
        CboBilliardTable.Items.Add(Main.LM.GetString("Elliptic"))
        CboBilliardTable.Items.Add(Main.LM.GetString("Stadium"))
        CboBilliardTable.Items.Add(Main.LM.GetString("Oval"))

    End Sub

    Private Sub FrmBilliardTable_Load(sender As Object, e As EventArgs) Handles Me.Load

        'The Bitmap "MapBilliardTable" contains the profile of the BilliardTable
        'and shows the Trace of each Ball
        'the movement of the Ball is shown in the PicBilliardTable and 
        'actualized by refreshing PicBilliardTable
        'the Bitmap and PixDiagram are Squares
        Dim Squareside As Integer = Math.Min(PicBilliardTable.Width, PicBilliardTable.Height)
        PicBilliardTable.Width = Squareside
        PicBilliardTable.Height = Squareside
        MapBilliardtable = New Bitmap(Squareside, Squareside)

        'The Bitmap MapBilliardTable is then shown as Image of PicBilliardTable
        PicBilliardTable.Image = MapBilliardtable

        'BilliardTable
        Billiardtable = New ClsEllipseBilliardtable With {
            .MapBilliardtable = MapBilliardtable
        }
        CboBilliardTable.SelectedIndex = 0

        'The Phase Portrait is a square
        Squareside = Math.Min(PicPhasePortrait.Width, PicPhasePortrait.Height)
        PicPhasePortrait.Width = Squareside
        PicPhasePortrait.Height = Squareside

        'The collection of all Billiard Balls on the Table
        MyBilliardballCollection = New List(Of IBilliardball)

        'Setting Standard Values
        TxtFactor.Text = StandardC.ToString(CultureInfo.CurrentCulture)
        CboBallColor.SelectedIndex = 0

    End Sub

    Private Sub BtnDrawBilliardTable_Click(sender As Object, e As EventArgs) Handles BtnDrawBilliardTable.Click

        Reset()
        If CheckFactorC() Then
            Billiardtable.C = CDec(TxtFactor.Text)
            Billiardtable.DrawBilliardtable()
            PicBilliardTable.Refresh()
        End If

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        Reset()
    End Sub

    Private Sub Reset()

        Billiardtable.Clear()
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
        LblNumberofSteps.Text = "0"

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
                Billiardtable.C = CDec(TxtFactor.Text)
                Billiardtable.DrawBilliardtable()
                PicBilliardTable.Refresh()
            End If

            'The Type of the Billiard Ball is depending of the Type of Billiard
            Select Case CboBilliardTable.SelectedIndex
                Case 0
                    Billiardball = New ClsEllipseBilliardball
                Case 1
                    Billiardball = New ClsStadiumBilliardball
                Case Else
                    Billiardball = New ClsOvalBilliardball
            End Select

            Billiardball.Billiardtable = PicBilliardTable
            Billiardball.MapBilliardtable = MapBilliardtable

            'Setting the properties of the Ball
            Billiardball.Ballcolor = Ballcolor
            Billiardball.Ballsize = 4
            Billiardball.Ballspeed = TrbSpeed.Value
            Billiardball.ParameterProtocol = LstParameterList

            'C influences the Value Range of the Parameter t
            'Therefore C is set first
            Billiardball.C = CDec(TxtFactor.Text)

            'and then the Phase Portrait containing the Parameter
            Billiardball.Phaseportrait = PicPhasePortrait

            'The Startpostition of the Ball is set later by the Mouse Position
            Billiardball.IsStartpositionSet = False
            Billiardball.IsStartangleSet = False

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

            Cursor = Cursors.Hand
            IsMousedown = True

            'Now, Moving the Mouse moves the Ball as well
            MouseMoving(e)

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
        End If

        'The Mouse gets its normal behaviour again
        Cursor = Cursors.Arrow
        IsMousedown = False

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

    Private Sub BtnUseStartParameter_Click(sender As Object, e As EventArgs) Handles BtnUseStartParameter.Click

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

    Private Sub BtnNextStep_Click(sender As Object, e As EventArgs) Handles BtnNextStep.Click
        Iteration(1)
    End Sub

    Private Sub BtnNext10_Click(sender As Object, e As EventArgs) Handles BtnNext10.Click
        Iteration(10)
    End Sub

    Private Sub BtnNext100_Click(sender As Object, e As EventArgs) Handles BtnNext100.Click

        Iteration(100)

    End Sub

    Private Sub TrbSpeed_Scroll(sender As Object, e As EventArgs) Handles TrbSpeed.Scroll

        'All Billiard Balls have the same speed
        For Each Ball As IBilliardball In MyBilliardballCollection
            Ball.Ballspeed = TrbSpeed.Value
        Next

    End Sub

    Private Sub CboBilliardTable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboBilliardTable.SelectedIndexChanged

        'Here, the User sets the Type of Billiard
        Select Case CboBilliardTable.SelectedIndex
            Case 0
                Billiardtable = New ClsEllipseBilliardtable
                StandardC = CDec(0.8)
                TxtFactor.Text = StandardC.ToString(CultureInfo.CurrentCulture)
            Case 1
                Billiardtable = New ClsStadiumBilliardtable
                StandardC = 2
                TxtFactor.Text = StandardC.ToString(CultureInfo.CurrentCulture)
            Case Else
                Billiardtable = New ClsOvalBilliardtable
                StandardC = CDec(0.5)
                TxtFactor.Text = StandardC.ToString(CultureInfo.CurrentCulture)
        End Select

        Billiardtable.MapBilliardtable = MapBilliardtable

        Reset()

    End Sub

    Private Sub TxtFactor_TextChanged(sender As Object, e As EventArgs) Handles TxtFactor.TextChanged
        If IsBilliardtableDrawn Then
            Reset()
        End If
    End Sub

    Private Sub Iteration(NumberOfSteps As Integer)

        If MyBilliardballCollection.Count > 0 Then
            PicBilliardTable.Refresh()

            Dim IsIteration As Boolean = False

            For Each Ball As IBilliardball In MyBilliardballCollection
                If Ball.IsStartpositionSet And Ball.IsStartangleSet Then
                    Ball.Iteration(NumberOfSteps)
                    LblNumber.Text = Main.LM.GetString("NumberOfSteps")
                    IsIteration = True
                Else
                    If IsFirstIterationstep Then
                        MessageBox.Show(Main.LM.GetString("StartPositionNotSet"))
                        MessageBox.Show(Main.LM.GetString("SetStartPosition"))
                        IsFirstIterationstep = False
                    End If
                End If
            Next

            If IsIteration Then
                n += NumberOfSteps
                LblNumberofSteps.Text = n.ToString(CultureInfo.CurrentCulture)
            End If
        Else
            MessageBox.Show(Main.LM.GetString("NoBallsOnTable"))
        End If

    End Sub

End Class