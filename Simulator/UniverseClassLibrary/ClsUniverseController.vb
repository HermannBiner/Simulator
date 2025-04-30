'This class contains the controller for FrmUniverse

'Status Checked

Imports System.Formats
Imports System.Globalization
Imports System.Reflection

Public Class ClsUniverseController

    Private ReadOnly MyForm As FrmUniverse

    Private ReadOnly LM As ClsLanguageManager

    Private ReadOnly MyMathhelper As ClsMathHelperAngles

    Private DS As IUniverse

    'the star that is actually selected in CboDefault
    'it is active as long it is not fixed and added to
    'ActiveStarCollection
    Private NewStar As IStar

    'Number of Steps
    Private N As Integer
    Private Watch As Stopwatch

    'when setting the Startposition by the mouse
    Private IsMouseDown As Boolean

    'the iterationstatus steeres the iteration
    Private IterationStatus As ClsDynamics.EnIterationStatus

    'is the Diagram Zoomed
    Private IsDiagramZoom As Boolean

    'to show the overall Pulse of the universe during the iteration
    Private PicPulseGraphics As Graphics
    Private StartPulse As ClsVector
    Private ActualPulse As ClsVector
    Private Const PulseTolerance As Decimal = CDec(0.1)

    'to show the overall Angular Momentum of the universe during the iteration
    Private PicAngularMomentumGraphics As Graphics
    Private StartAngularMomentum As Double
    Private ActualAngularMomentum As Double
    Private Const AngularMomentumTolerance As Decimal = CDec(0.1)

    'to show the overall Energy of the universe during the iteration
    Private PicEnergyGraphics As Graphics
    Private StartEnergy As Double
    Private ActualEnergy As Double
    Private Const EnergyTolerance As Decimal = CDec(0.1)
    Private ConservationBrush As Brush
    Private ConservationValue As Integer

    'SECTOR INITIALIZATION
    Public Sub New(Form As FrmUniverse)
        MyForm = Form
        LM = ClsLanguageManager.LM
        MyMathhelper = New ClsMathHelperAngles
        Watch = New Stopwatch
        IsDiagramZoom = (MyForm.ChkZoom.Checked)
        PicEnergyGraphics = MyForm.PicEnergy.CreateGraphics
        PicAngularMomentumGraphics = MyForm.PicAngularMomentum.CreateGraphics
        PicPulseGraphics = MyForm.PicPulse.CreateGraphics
        StartPulse = New ClsVector
        ActualPulse = New ClsVector
    End Sub

    Public Sub FillDynamicSystem()

        'a dynamic system is here an universe
        'with an individual formula for the potential energy
        'and the according gravity force law
        'standard is the NewtonUniverse

        MyForm.CboUniverse.Items.Clear()

        'Add the classes implementing IUniverse
        'to the Combobox CboUniverse by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IUniverse)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If types.Count > 0 Then
            Dim DSName As String
            For Each type In types

                'GetString is called with the option IsClass = true
                'That effects that - if there is no Entry in the Resource files LabelsEN, LabelsDE -
                'the name of the Class implementing an Interface is used as default
                'suppressing the extension "Cls"
                DSName = LM.GetString(type.Name, True)
                MyForm.CboUniverse.Items.Add(DSName)
            Next

        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If
        MyForm.CboUniverse.SelectedIndex = 0
    End Sub

    Public Sub SetDS()

        'This sets the type of Universe by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IUniverse)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If MyForm.CboUniverse.SelectedIndex >= 0 Then

            Dim SelectedName As String = MyForm.CboUniverse.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If LM.GetString(type.Name, True) = SelectedName Then
                        DS = CType(Activator.CreateInstance(type), IUniverse)
                        Exit For
                    End If
                Next
            End If

        End If

        'DS is the Universe
        With DS
            .PicDiagram = MyForm.PicDiagram
            .PicPhaseportrait = MyForm.PicPhasePortrait
        End With

        'a constellation is a set of stars or a system of planets
        'like our planet system with our sun 
        DS.CreateConstellations()

        'Setting the standard parameters
        InitializeMe()

    End Sub

    Public Sub InitializeMe()

        'after a resize, PicDiagram changes its size
        'and the size of the BmpDiagram has to be set again
        'the BmpGraphics is the same as PicGraphics
        DS.PicDiagram = MyForm.PicDiagram

        'Filling the available colors for stars
        With MyForm.CboStarColor
            .Items.Clear()

            .Items.Add(LM.GetString("Gold")) 'Standard for the Sun
            .Items.Add(LM.GetString("LightGray")) 'Standard für Merkur
            .Items.Add(LM.GetString("Yellow")) 'Standard for Venus
            .Items.Add(LM.GetString("SkyBlue")) 'Standard for the Earth
            .Items.Add(LM.GetString("Red")) 'Standard for Mars
            .Items.Add(LM.GetString("Magenta")) 'Standard for Jupiter
            .Items.Add(LM.GetString("Tomato")) 'Standard for Saturn
            .Items.Add(LM.GetString("Orange")) 'Standard for Uranus
            .Items.Add(LM.GetString("GreenYellow")) 'Standard for Neptun
            .Items.Add(LM.GetString("AquaMarine")) 'Reserve
            .Items.Add(LM.GetString("Snow")) 'Reserve
        End With

        'Setting Standard Values
        MyForm.CboStarColor.SelectedIndex = 0

        MyForm.CboConstellations.Items.Clear()

        For Each Constellation As ClsStarConstellation In DS.Constellations
            MyForm.CboConstellations.Items.Add(Constellation.Name)
        Next
        MyForm.CboConstellations.SelectedIndex = 0

        'each constellation has a set of stars or planets
        FillDefaultStars()

    End Sub

    Public Sub FillDefaultStars()

        'this routine is called if the constellation changes
        'and in the beginning, when everything is set to default

        'Fill CboDefaultStar with all stars of the Constellation
        MyForm.CboDefaultStar.Items.Clear()

        Dim Name As String = MyForm.CboConstellations.SelectedItem.ToString

        For Each Constellation As ClsStarConstellation In DS.Constellations
            If Constellation.Name = Name Then
                DS.ActiveConstellation = Constellation
                DS.VFactor = Constellation.VFactor
                For Each Star As IStar In DS.ActiveConstellation.Stars
                    MyForm.CboDefaultStar.Items.Add(Star.Name)
                Next
                Exit For
            End If
        Next

        'The ActualParameters and StartParameters are set to Default, 
        'defined by the Perihel data
        SetAllStarsDefaultUserData()

        MyForm.CboDefaultStar.SelectedIndex = 0

        'the role of the DefaultStar is the following:
        'it is nothing until the user creates a NewStar
        'its parameters can be changed by the user
        'in the end, it is added to ActiveStarCollection
        'and the NewStar is again = nothing
        'or the operation is canceled and the NewStar set to nothing
        'wihtout adding it to ActiveStarCollection
        'Standard is NewStar = nothing
        NewStar = Nothing
        SetColor(GetColor(MyForm.CboStarColor.SelectedItem.ToString))

        'If the type of constellation changes, everything has to be reset
        'and cleared
        ClearUniverse()

    End Sub

    Public Sub GetNewStar()

        'if a new star is created, then the standard vaule are set
        'the new star is part of the set of stars in the constellation

        NewStar = DS.GetNewStar(MyForm.CboDefaultStar.SelectedItem.ToString)

        If NewStar Is Nothing Then
            Throw New MissingMemberException("MissingDefaultStar")
        Else
            'All Pics and Graphics of the star are already set by generating the constellation
            'Show the parameters of the DefaultStar
            Dim ColorName As String
            ColorName = LM.GetString(DirectCast(NewStar.StarColor, SolidBrush).Color.Name)
            With MyForm
                If .CboStarColor.Items.Contains(ColorName) Then
                    .CboStarColor.SelectedItem = ColorName
                Else
                    Throw New MissingMemberException(LM.GetString("MissingColor"))
                End If
                'the positions of all existing stars are relative to the centre of gravity
                'for the new star, its coordinates have to be adapted as well
                Dim LocStartPosition As New ClsVector
                LocStartPosition.Equal(NewStar.UserStartPosition)
                LocStartPosition.Add(DS.GlobalCentreOfGravity)
                NewStar.UserStartPosition.Equal(LocStartPosition)
                NewStar.ActualPosition.Equal(NewStar.UserStartPosition)
                SetTrbFromVelocity(NewStar)
                UpdateTextFields(NewStar)
            End With

            SetTrbFromStepWidth(NewStar.ProposedStepWidth)
        End If
    End Sub

    Public Sub ResetIteration()

        With MyForm
            .LblSteps.Text = "0"
            N = 0
            IterationStatus = ClsDynamics.EnIterationStatus.Stopped

            .BtnStart.Text = LM.GetString("Start")

            MyForm.BtnNewStar.Enabled = False
            MyForm.BtnSave.Enabled = False
            EnableResetArea(True)

            .PicEnergy.Refresh()
            .PicAngularMomentum.Refresh()
            .PicPulse.Refresh()

            DS.ResetIteration()

            NewStar = Nothing
            Watch.Reset()
            .LblTime.Text = LM.GetString("Time")
        End With

    End Sub

    Public Sub SetAllStarsDefaultUserData()

        'ActiveStarCollection is nothing if there are no stars on the diagram
        If DS.ActiveStarCollection IsNot Nothing Then
            For Each aStar As IStar In DS.ActiveStarCollection
                aStar.SetDefaultUserData()
                aStar.PicDiagram = DS.PicDiagram
                aStar.PicGraphics = DS.PicGraphics
                aStar.BmpDiagram = DS.BmpDiagram
                aStar.BmpGraphics = DS.BmpGraphics
            Next
        End If
        DS.RedrawUniverse(NewStar, IsDiagramZoom)
        EnableStartArea()
        EnableResetArea(True)
    End Sub

    Public Sub ClearUniverse()

        'set in the middle
        MyForm.TrbMass.Value = 0

        DS.ClearUniverse()
        NewStar = Nothing

        ResetIteration()

        EnableClearArea()
        EnableNewStarArea(True)
        With MyForm
            .CboUniverse.Enabled = True
            .CboConstellations.Enabled = True
            .CboDefaultStar.Enabled = True
            .BtnStart.Enabled = False
            .BtnTakeOverConstellation.Enabled = True
            .BtnNewStar.Enabled = True
        End With
    End Sub

    Public Function GetColor(ColorName As String) As Brush

        Dim LocColor As Brush

        'The generated stars can have different colors to be distinguished
        Select Case ColorName
            Case LM.GetString("Yellow")
                MyForm.LblColor.BackColor = Color.Yellow
                LocColor = Brushes.Yellow
            Case LM.GetString("Gold")
                MyForm.LblColor.BackColor = Color.Gold
                LocColor = Brushes.Gold
            Case LM.GetString("Red")
                MyForm.LblColor.BackColor = Color.Red
                LocColor = Brushes.Red
            Case LM.GetString("LightGray")
                MyForm.LblColor.BackColor = Color.LightGray
                LocColor = Brushes.LightGray
            Case LM.GetString("GreenYellow")
                MyForm.LblColor.BackColor = Color.GreenYellow
                LocColor = Brushes.GreenYellow
            Case LM.GetString("Tomato")
                MyForm.LblColor.BackColor = Color.Tomato
                LocColor = Brushes.Tomato
            Case LM.GetString("Orange")
                MyForm.LblColor.BackColor = Color.Orange
                LocColor = Brushes.Orange
            Case LM.GetString("SkyBlue")
                MyForm.LblColor.BackColor = Color.SkyBlue
                LocColor = Brushes.SkyBlue
            Case LM.GetString("Snow")
                MyForm.LblColor.BackColor = Color.Snow
                LocColor = Brushes.Snow
            Case LM.GetString("Magenta")
                MyForm.LblColor.BackColor = Color.Magenta
                LocColor = Brushes.Magenta
            Case Else
                MyForm.LblColor.BackColor = Color.Aquamarine
                LocColor = Brushes.Aquamarine
        End Select

        Return LocColor
    End Function

    Public Sub SetColor(Color As Brush)

        If NewStar IsNot Nothing Then
            NewStar.StarColor = GetColor(MyForm.CboStarColor.SelectedItem.ToString)
            NewStar.DrawStar(False)
        End If

    End Sub

    Public Sub UpdateTextFields(aStar As IStar)
        With MyForm
            .TxtMass.Text = aStar.UserMass.ToString("0.0000")
            .TxtX.Text = aStar.UserStartPosition.X.ToString("0.0000")
            .TxtY.Text = aStar.UserStartPosition.Y.ToString("0.0000")
            .TxtVX.Text = aStar.UserStartVelocity.X.ToString("0.0000")
            .TxtVY.Text = aStar.UserStartVelocity.Y.ToString("0.0000")
        End With
    End Sub

    Public Sub SetTrbFromMass(aStar As IStar)
        'if the star has the original mass, then trb.value = 0
        MyForm.TrbMass.Value = 0
    End Sub

    Public Sub SetMassFromTrb()
        If NewStar IsNot Nothing Then
            With NewStar
                'TrbMass is between -20 and 20, that gives a factor of 0.6 ... 1.4 of the original mass
                .UserMass = NewStar.OriginalMass * CDec((100 + 2 * MyForm.TrbMass.Value) / 100)
                'the mass should be in the range
                .UserMass = CDec(Math.Max(0.05, .UserMass))
                .UserMass = CDec(Math.Min(500000, .UserMass))
                UpdateTextFields(NewStar)
                DS.RedrawUniverse(NewStar, IsDiagramZoom)
            End With
        End If
    End Sub

    Public Sub SetTrbFromVelocity(aStar As IStar)
        If aStar.OriginalStartVelocity.Abs > 0 Then
            MyForm.TrbVelocity.Value = CInt(2 * aStar.UserStartVelocity.Abs / aStar.OriginalStartVelocity.Abs - 10)
        Else
            MyForm.TrbVelocity.Value = -10
        End If
    End Sub

    Public Sub SetVelocityFromTrb()
        If NewStar IsNot Nothing Then

            'Trb.value is between -10 and 10
            'that gives a factor between 0 and 2
            Dim Factor As Decimal
            Factor = CDec((0.1 * MyForm.TrbVelocity.Value + 1))

            Dim NewVelocity As ClsVector
            With NewStar.OriginalStartVelocity
                NewVelocity = New ClsVector(.X * Factor, .Y * Factor)
            End With

            'but it should be in the allowed range
            With DS.VelocityParameter.Range
                NewVelocity.X = CDec(Math.Min(.B, Math.Max(.A, NewVelocity.X)))
                NewVelocity.Y = CDec(Math.Min(.B, Math.Max(.A, NewVelocity.Y)))
            End With
            NewStar.UserStartVelocity.Equal(NewVelocity)
            NewStar.ActualVelocity.Equal(NewVelocity)
            UpdateTextFields(NewStar)
            DS.RedrawUniverse(NewStar, IsDiagramZoom)
        End If
    End Sub

    Public Sub SetStepWidthFromTrb()
        Dim LocStepWidth As Decimal = DS.TrbValueToStepWidth(MyForm.TrbStepWidth.Value)
        MyForm.LblStepWidth.Text = LM.GetString("StepWidth") & ": " & LocStepWidth.ToString
        For Each aStar As IStar In DS.ActiveStarCollection
            aStar.ActualStepWidth = LocStepWidth
        Next
    End Sub

    Public Sub SetTrbFromStepWidth(locStepWidth As Decimal)
        If locStepWidth > 0 Then
            MyForm.LblStepWidth.Text = LM.GetString("StepWidth") & ": " & locStepWidth.ToString
            MyForm.TrbStepWidth.Value = DS.StepWidthToTrbValue(locStepWidth)
        End If
    End Sub

    'lila in documentation
    Private Sub EnableResetArea(IsEnabled As Boolean)
        'these are the controls depending on the iteration
        With MyForm
            .BtnDefault.Enabled = IsEnabled
            .BtnReset.Enabled = IsEnabled
            .BtnClearUniverse.Enabled = IsEnabled
            .BtnStop.Enabled = False
            .BtnTakeOverConstellation.Enabled = False
            .CboUniverse.Enabled = False
            .CboDefaultStar.Enabled = False
            .CboStarColor.Enabled = False
            .CboConstellations.Enabled = False
            .ChkZoom.Enabled = IsEnabled
            '.BtnNewStar.Enabled = False
        End With
    End Sub

    'rosa in documentation
    Private Sub EnableNewStarArea(IsEnabled As Boolean)
        'The controls, needed to define the parameters of a new star
        With MyForm
            .BtnNewStar.Enabled = True
            .BtnStart.Enabled = IsEnabled
            .BtnSave.Enabled = Not IsEnabled
            .CboDefaultStar.Enabled = IsEnabled
            .CboStarColor.Enabled = IsEnabled
        End With
    End Sub

    'light blue in documentation
    Private Sub EnableClearArea()
        With MyForm
            .BtnDefault.Enabled = False
            .BtnReset.Enabled = False
            .BtnClearUniverse.Enabled = True
            .BtnStop.Enabled = False
            .BtnTakeOverConstellation.Enabled = False
            .CboUniverse.Enabled = False
            .CboConstellations.Enabled = False
            .ChkZoom.Enabled = True
        End With
    End Sub

    'light green in documentation
    Private Sub EnableStartArea()
        With MyForm
            .BtnNewStar.Enabled = False
            .BtnSave.Enabled = False
            .BtnStart.Enabled = True
        End With
    End Sub

    'SECTOR CREATE NEW OBJECT

    Public Sub TakeOverConstellation()

        ClearUniverse()

        Dim TotalMassofAllStars As Decimal = 0
        'Fill the diagramm with all stars of the constellation
        For Each aStar As IStar In DS.ActiveConstellation.Stars
            With aStar
                .PicDiagram = DS.PicDiagram
                .PicGraphics = DS.PicGraphics
                .BmpDiagram = DS.BmpDiagram
                .BmpGraphics = DS.BmpGraphics
                .ActualStepWidth = 0
                .SetDefaultUserData()
                .DrawStar(True)
                TotalMassofAllStars += .OriginalMass
                SetTrbFromVelocity(aStar)
                UpdateTextFields(aStar)
            End With
            DS.ActiveStarCollection.Add(aStar)
        Next

        For Each aStar As IStar In DS.ActiveStarCollection
            With aStar
                .TotalMassOfOtherStars = TotalMassofAllStars - .OriginalMass
            End With
        Next

        DS.RedrawUniverse(NewStar, IsDiagramZoom)
        ResetIteration()

        'Buttons
        EnableStartArea()
        EnableClearArea()
        SetTrbFromStepWidth(DS.ActiveConstellation.ProposedStepWidth)
    End Sub

    Public Sub TakeOverNewStarOrCancel()

        If NewStar IsNot Nothing Then
            'The DefaultStar is actually in Edit mode
            'and the operation should be cancelled
            MyForm.BtnNewStar.Text = LM.GetString("NewStar")
            MyForm.TrbMass.Value = 0

            'the diagram is cleaned but the BmpDiagram stays
            MyForm.PicDiagram.Refresh()
            EnableNewStarArea(True)
            EnableClearArea()
            NewStar = Nothing

            RedrawUniverse()

        Else
            MyForm.BtnNewStar.Text = LM.GetString("Cancel")

            'The NewStar is activated
            GetNewStar()
            NewStar.PicDiagram = DS.PicDiagram
            NewStar.PicGraphics = DS.PicGraphics
            NewStar.BmpDiagram = DS.BmpDiagram
            NewStar.BmpGraphics = DS.BmpGraphics
            DS.RedrawUniverse(NewStar, IsDiagramZoom)
            EnableNewStarArea(False)
            EnableResetArea(False)
        End If
    End Sub

    'SECTOR SET STARTPARAMETER

    Public Sub MouseDown(e As MouseEventArgs)
        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            If NewStar IsNot Nothing Then
                MyForm.Cursor = Cursors.Hand
                IsMouseDown = True
                'Now, Moving the Mouse moves the Star or its Velocity as well
                MouseMove(e)
            End If
        End If
    End Sub

    Public Sub MouseMove(e As MouseEventArgs)
        If IsMouseDown Then
            'Because the Cursor is "Hand", the Mouse Position is adjusted a bit
            Dim Mouseposition As New Point With {
            .X = e.X + 2,
            .Y = e.Y - 25
        }

            If NewStar IsNot Nothing Then

                NewStar.SetUserStartPosition(Mouseposition)
                UpdateTextFields(NewStar)

            End If
        End If
    End Sub

    Public Sub MouseUp(e As MouseEventArgs)
        If IsMouseDown Then
            DS.RedrawUniverse(NewStar, IsDiagramZoom)
            UpdateTextFields(NewStar)
            'The Mouse gets its normal behaviour again
            MyForm.Cursor = Cursors.Arrow
            IsMouseDown = False
        End If
    End Sub

    Public Sub SaveStar()

        If IsUserDataOK() Then
            MyForm.BtnNewStar.Text = LM.GetString("NewStar")
            MyForm.TrbMass.Value = 0

            DS.ActiveStarCollection.Add(NewStar)

            EnableClearArea()
            EnableNewStarArea(True)

            SetTrbFromStepWidth(CDec(NewStar.ProposedStepWidth))
            NewStar = Nothing
        Else
            'Message already generated
        End If
    End Sub

    Public Sub RedrawUniverse()
        IsDiagramZoom = (MyForm.ChkZoom.Checked)
        DS.RedrawUniverse(NewStar, IsDiagramZoom)
    End Sub

    'SECTOR ITERATION

    Public Async Sub StartIteration()

        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            If IsStarExisting() Then
                If IsUserDataOK() Then

                    IterationStatus = ClsDynamics.EnIterationStatus.Ready

                    StartEnergy = 0
                    StartAngularMomentum = 0
                    StartPulse.Reset()

                    'Remove Orbits and show only stars
                    DS.ClearDiagrams()

                    Dim LocTotalmassOfOtherStars As Decimal

                    For Each aStar As IStar In DS.ActiveStarCollection
                        'Set Iteration to UserStart and draws the star in PicDiagram
                        aStar.ResetIteration()
                        aStar.DrawStar(False)
                        If MyForm.ChkConservationLaws.Checked Then
                            StartEnergy += aStar.GetEnergy
                            StartAngularMomentum += aStar.GetAngularMomentum
                            StartPulse.X += aStar.GetPulse.X
                            StartPulse.Y += aStar.GetPulse.Y
                        End If

                        LocTotalmassOfOtherStars += aStar.UserMass
                    Next

                    'normaly, the TotalMassOfOtherStars is set when creating new stars
                    'or taking over a constellation
                    'if there was a collision, we have to adjust TotalMassOfOther Stars
                    'and we have to avoid tiny negative masses created by rounding effecs
                    For Each aStar As IStar In DS.ActiveStarCollection
                        aStar.TotalMassOfOtherStars = Math.Max(0, LocTotalmassOfOtherStars - aStar.UserMass)
                    Next

                    StartEnergy = Math.Abs(StartEnergy * 100)
                    StartAngularMomentum = Math.Abs(StartAngularMomentum)
                    SetStepWidthFromTrb()
                    Watch.Start()
                Else
                    'Message already generated
                    ResetIteration()
                    SetAllStarsDefaultUserData()
                End If
            Else
                MsgBox(LM.GetString("NoStarsInTheUniverse"))
            End If
        End If

        If IterationStatus = ClsDynamics.EnIterationStatus.Ready Or
                    IterationStatus = ClsDynamics.EnIterationStatus.Interrupted Then
            IterationStatus = ClsDynamics.EnIterationStatus.Running
            With MyForm
                .BtnStart.Text = LM.GetString("Continue")
                .Cursor = Cursors.WaitCursor
            End With
            EnableStartArea()
            MyForm.BtnStart.Enabled = False
            EnableResetArea(False)
            MyForm.BtnStop.Enabled = True
            MyForm.CboUniverse.Enabled = False
            MyForm.CboConstellations.Enabled = False
            Application.DoEvents()

            Await IterationLoop()

        End If
    End Sub

    Public Async Function IterationLoop() As Task

        Do
            N += 1

            'Each Ball is now iterated 1x
            For Each aStar As IStar In DS.ActiveStarCollection
                aStar.IterationStep(MyForm.ChkPhasePortrait.Checked)
            Next

            ActualEnergy = 0
            ActualAngularMomentum = 0
            ActualPulse.Reset()

            For Each aStar As IStar In DS.ActiveStarCollection
                'all stars have to move similarly
                'to their new position
                'because the gravity is calculated relative to the old position
                aStar.MoveActualPosition()
                aStar.DrawStar(False)
                If MyForm.ChkConservationLaws.Checked Then
                    ActualEnergy += aStar.GetEnergy
                    ActualAngularMomentum += aStar.GetAngularMomentum
                    ActualPulse.X += aStar.GetPulse.X
                    ActualPulse.Y += aStar.GetPulse.Y
                End If
            Next

            If N Mod 5 = 0 Then
                MyForm.PicDiagram.Refresh()
                MyForm.LblSteps.Text = (DS.ActiveStarCollection.Count * N).ToString(CultureInfo.CurrentCulture)
                MyForm.LblTime.Text = (Watch.ElapsedMilliseconds / 1000).ToString("F2")
                If MyForm.ChkConservationLaws.Checked Then

                    'Energy
                    ActualEnergy = Math.Abs(100 * ActualEnergy)
                    Select Case True
                        Case ActualEnergy > StartEnergy * (1 + EnergyTolerance)
                            ConservationBrush = Brushes.Red
                        Case ActualEnergy < StartEnergy * (1 - EnergyTolerance)
                            ConservationBrush = Brushes.DarkViolet
                        Case Else
                            ConservationBrush = Brushes.Green
                    End Select

                    MyForm.PicEnergy.Refresh()

                    'Set the StatusBar of the Energy
                    If StartEnergy > 0 Then
                        ConservationValue = CInt(Math.Min(2 * StartEnergy, ActualEnergy) * MyForm.PicEnergy.Width / (2 * StartEnergy))
                    Else
                        ConservationValue = 0
                    End If
                    PicEnergyGraphics.FillRectangle(ConservationBrush, New Rectangle(0, 0,
                           ConservationValue, MyForm.PicEnergy.Height))

                    'AngularMomentum
                    ActualAngularMomentum = Math.Abs(ActualAngularMomentum)

                    Select Case True
                        Case ActualAngularMomentum > StartAngularMomentum * (1 + AngularMomentumTolerance)
                            ConservationBrush = Brushes.Red
                        Case ActualAngularMomentum < StartAngularMomentum * (1 - AngularMomentumTolerance)
                            ConservationBrush = Brushes.DarkViolet
                        Case Else
                            ConservationBrush = Brushes.Green
                    End Select

                    MyForm.PicAngularMomentum.Refresh()

                    'Set the StatusBar of the AngularMomentum
                    If StartAngularMomentum > 0 Then
                        ConservationValue = CInt(Math.Min(2 * StartAngularMomentum, ActualAngularMomentum) *
                            MyForm.PicAngularMomentum.Width / (2 * StartAngularMomentum))
                    Else
                        ConservationValue = 0
                    End If
                    PicAngularMomentumGraphics.FillRectangle(ConservationBrush, New Rectangle(0, 0,
                           ConservationValue, MyForm.PicAngularMomentum.Height))

                    'Pulse

                    Select Case True
                        Case ActualPulse.Abs > StartPulse.Abs * (1 + PulseTolerance)
                            ConservationBrush = Brushes.Red
                        Case ActualPulse.Abs < StartPulse.Abs * (1 - PulseTolerance)
                            ConservationBrush = Brushes.DarkViolet
                        Case Else
                            ConservationBrush = Brushes.Green
                    End Select

                    MyForm.PicPulse.Refresh()

                    'Set the StatusBar of the Pulse
                    If StartPulse.Abs > 0 Then
                        ConservationValue = CInt(Math.Min(2 * StartPulse.Abs, ActualPulse.Abs) *
                            MyForm.PicPulse.Width / (2 * StartPulse.Abs))
                    Else
                        ConservationValue = 0
                    End If
                    PicPulseGraphics.FillRectangle(ConservationBrush, New Rectangle(0, 0,
                           ConservationValue, MyForm.PicPulse.Height))

                End If
            End If

            If N Mod 200 = 0 Then
                Await Task.Delay(1)
            End If

        Loop Until IterationStatus = ClsDynamics.EnIterationStatus.Interrupted _
            Or IterationStatus = ClsDynamics.EnIterationStatus.Stopped

        For Each aStar As IStar In DS.ActiveStarCollection
            aStar.DrawStar(False)
        Next

    End Function

    Public Sub StopIteration()
        IterationStatus = ClsDynamics.EnIterationStatus.Interrupted
        MyForm.Cursor = Cursors.Arrow
        EnableStartArea()
        EnableResetArea(True)
        Watch.Stop()
    End Sub

    'SECTOR CHECK USERDATA

    Private Function IsUserDataOK() As Boolean

        Dim CheckPositionX = New ClsCheckUserData(MyForm.TxtX, DS.PositionParameter.Range)
        Dim CheckPositionY = New ClsCheckUserData(MyForm.TxtY, DS.PositionParameter.Range)
        Dim CheckMass = New ClsCheckUserData(MyForm.TxtMass, DS.MassParameter.Range)
        Dim CheckVelocityX = New ClsCheckUserData(MyForm.TxtVX, DS.VelocityParameter.Range)
        Dim CheckVelocityY = New ClsCheckUserData(MyForm.TxtVX, DS.VelocityParameter.Range)

        Return CheckPositionX.IsTxtValueAllowed And CheckPositionY.IsTxtValueAllowed And
            CheckVelocityX.IsTxtValueAllowed And CheckVelocityY.IsTxtValueAllowed And
            CheckMass.IsTxtValueAllowed

    End Function

    Private Function IsStarExisting() As Boolean
        Return DS.ActiveStarCollection.Count > 0
    End Function

End Class
