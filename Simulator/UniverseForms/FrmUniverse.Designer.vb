<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUniverse
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUniverse))
        SplitContainer1 = New SplitContainer()
        PicDiagram = New PictureBox()
        SplitContainer2 = New SplitContainer()
        LblTime = New Label()
        BtnTakeOverConstellation = New Button()
        LblSteps = New Label()
        LblNumberOfSteps = New Label()
        LblConstellations = New Label()
        CboConstellations = New ComboBox()
        GrpNewStar = New GroupBox()
        TxtVY = New TextBox()
        TrbVelocity = New TrackBar()
        TxtVX = New TextBox()
        TxtY = New TextBox()
        LblVelocity = New Label()
        LblPosition = New Label()
        TxtX = New TextBox()
        TxtMass = New TextBox()
        BtnSave = New Button()
        LblDefault = New Label()
        CboDefaultStar = New ComboBox()
        LblMass = New Label()
        TrbMass = New TrackBar()
        BtnNewStar = New Button()
        LblColor = New Label()
        LblStarColor = New Label()
        CboStarColor = New ComboBox()
        LblUniverse = New Label()
        CboUniverse = New ComboBox()
        BtnStop = New Button()
        BtnStart = New Button()
        ChkPhasePortrait = New CheckBox()
        ChkZoom = New CheckBox()
        BtnClearUniverse = New Button()
        ChkConservationLaws = New CheckBox()
        LblPulse = New Label()
        PicPulse = New PictureBox()
        LblStepWidth = New Label()
        TrbStepWidth = New TrackBar()
        LblAngularMomentum = New Label()
        PicAngularMomentum = New PictureBox()
        LblEnergy = New Label()
        PicEnergy = New PictureBox()
        PicPhasePortrait = New PictureBox()
        BtnDefault = New Button()
        BtnReset = New Button()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        CType(SplitContainer2, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer2.Panel1.SuspendLayout()
        SplitContainer2.Panel2.SuspendLayout()
        SplitContainer2.SuspendLayout()
        GrpNewStar.SuspendLayout()
        CType(TrbVelocity, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbMass, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicPulse, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbStepWidth, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicAngularMomentum, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicEnergy, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicPhasePortrait, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.FixedPanel = FixedPanel.Panel2
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(PicDiagram)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(SplitContainer2)
        SplitContainer1.Size = New Size(1168, 611)
        SplitContainer1.SplitterDistance = 602
        SplitContainer1.SplitterWidth = 6
        SplitContainer1.TabIndex = 0
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.Black
        PicDiagram.Location = New Point(4, 4)
        PicDiagram.Margin = New Padding(4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(600, 600)
        PicDiagram.TabIndex = 30
        PicDiagram.TabStop = False
        ' 
        ' SplitContainer2
        ' 
        SplitContainer2.Dock = DockStyle.Fill
        SplitContainer2.Location = New Point(0, 0)
        SplitContainer2.Name = "SplitContainer2"
        ' 
        ' SplitContainer2.Panel1
        ' 
        SplitContainer2.Panel1.Controls.Add(LblTime)
        SplitContainer2.Panel1.Controls.Add(BtnTakeOverConstellation)
        SplitContainer2.Panel1.Controls.Add(LblSteps)
        SplitContainer2.Panel1.Controls.Add(LblNumberOfSteps)
        SplitContainer2.Panel1.Controls.Add(LblConstellations)
        SplitContainer2.Panel1.Controls.Add(CboConstellations)
        SplitContainer2.Panel1.Controls.Add(GrpNewStar)
        SplitContainer2.Panel1.Controls.Add(LblUniverse)
        SplitContainer2.Panel1.Controls.Add(CboUniverse)
        SplitContainer2.Panel1.Controls.Add(BtnStop)
        SplitContainer2.Panel1.Controls.Add(BtnStart)
        ' 
        ' SplitContainer2.Panel2
        ' 
        SplitContainer2.Panel2.Controls.Add(ChkPhasePortrait)
        SplitContainer2.Panel2.Controls.Add(ChkZoom)
        SplitContainer2.Panel2.Controls.Add(BtnClearUniverse)
        SplitContainer2.Panel2.Controls.Add(ChkConservationLaws)
        SplitContainer2.Panel2.Controls.Add(LblPulse)
        SplitContainer2.Panel2.Controls.Add(PicPulse)
        SplitContainer2.Panel2.Controls.Add(LblStepWidth)
        SplitContainer2.Panel2.Controls.Add(TrbStepWidth)
        SplitContainer2.Panel2.Controls.Add(LblAngularMomentum)
        SplitContainer2.Panel2.Controls.Add(PicAngularMomentum)
        SplitContainer2.Panel2.Controls.Add(LblEnergy)
        SplitContainer2.Panel2.Controls.Add(PicEnergy)
        SplitContainer2.Panel2.Controls.Add(PicPhasePortrait)
        SplitContainer2.Panel2.Controls.Add(BtnDefault)
        SplitContainer2.Panel2.Controls.Add(BtnReset)
        SplitContainer2.Size = New Size(560, 611)
        SplitContainer2.SplitterDistance = 224
        SplitContainer2.TabIndex = 0
        ' 
        ' LblTime
        ' 
        LblTime.AutoSize = True
        LblTime.Font = New Font("Microsoft Sans Serif", 9F)
        LblTime.Location = New Point(172, 557)
        LblTime.Name = "LblTime"
        LblTime.Size = New Size(35, 15)
        LblTime.TabIndex = 109
        LblTime.Text = "Time"
        ' 
        ' BtnTakeOverConstellation
        ' 
        BtnTakeOverConstellation.Font = New Font("Microsoft Sans Serif", 9F)
        BtnTakeOverConstellation.Location = New Point(13, 106)
        BtnTakeOverConstellation.Margin = New Padding(4)
        BtnTakeOverConstellation.Name = "BtnTakeOverConstellation"
        BtnTakeOverConstellation.Size = New Size(199, 30)
        BtnTakeOverConstellation.TabIndex = 108
        BtnTakeOverConstellation.Text = "TakeOverConstellation"
        BtnTakeOverConstellation.UseVisualStyleBackColor = True
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblSteps.Location = New Point(111, 557)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(14, 15)
        LblSteps.TabIndex = 107
        LblSteps.Text = "0"
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblNumberOfSteps.Location = New Point(6, 557)
        LblNumberOfSteps.Margin = New Padding(4, 0, 4, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(102, 15)
        LblNumberOfSteps.TabIndex = 106
        LblNumberOfSteps.Text = "Number of Steps:"
        ' 
        ' LblConstellations
        ' 
        LblConstellations.AutoSize = True
        LblConstellations.Font = New Font("Microsoft Sans Serif", 9F)
        LblConstellations.Location = New Point(10, 53)
        LblConstellations.Margin = New Padding(4, 0, 4, 0)
        LblConstellations.Name = "LblConstellations"
        LblConstellations.Size = New Size(78, 15)
        LblConstellations.TabIndex = 105
        LblConstellations.Text = "Constellation"
        ' 
        ' CboConstellations
        ' 
        CboConstellations.Font = New Font("Microsoft Sans Serif", 9F)
        CboConstellations.FormattingEnabled = True
        CboConstellations.Items.AddRange(New Object() {"DoublePendulum", "CombiPendulum", "ShakePendulum"})
        CboConstellations.Location = New Point(13, 75)
        CboConstellations.Margin = New Padding(4)
        CboConstellations.Name = "CboConstellations"
        CboConstellations.Size = New Size(199, 23)
        CboConstellations.TabIndex = 104
        ' 
        ' GrpNewStar
        ' 
        GrpNewStar.Controls.Add(TxtVY)
        GrpNewStar.Controls.Add(TrbVelocity)
        GrpNewStar.Controls.Add(TxtVX)
        GrpNewStar.Controls.Add(TxtY)
        GrpNewStar.Controls.Add(LblVelocity)
        GrpNewStar.Controls.Add(LblPosition)
        GrpNewStar.Controls.Add(TxtX)
        GrpNewStar.Controls.Add(TxtMass)
        GrpNewStar.Controls.Add(BtnSave)
        GrpNewStar.Controls.Add(LblDefault)
        GrpNewStar.Controls.Add(CboDefaultStar)
        GrpNewStar.Controls.Add(LblMass)
        GrpNewStar.Controls.Add(TrbMass)
        GrpNewStar.Controls.Add(BtnNewStar)
        GrpNewStar.Controls.Add(LblColor)
        GrpNewStar.Controls.Add(LblStarColor)
        GrpNewStar.Controls.Add(CboStarColor)
        GrpNewStar.Font = New Font("Microsoft Sans Serif", 9F)
        GrpNewStar.Location = New Point(6, 140)
        GrpNewStar.Name = "GrpNewStar"
        GrpNewStar.Size = New Size(213, 414)
        GrpNewStar.TabIndex = 103
        GrpNewStar.TabStop = False
        GrpNewStar.Text = "NewStar"
        ' 
        ' TxtVY
        ' 
        TxtVY.Enabled = False
        TxtVY.Font = New Font("Microsoft Sans Serif", 9F)
        TxtVY.Location = New Point(113, 294)
        TxtVY.Margin = New Padding(4)
        TxtVY.Name = "TxtVY"
        TxtVY.Size = New Size(95, 21)
        TxtVY.TabIndex = 101
        TxtVY.Text = "000.0000"
        ' 
        ' TrbVelocity
        ' 
        TrbVelocity.Location = New Point(7, 322)
        TrbVelocity.Margin = New Padding(4)
        TrbVelocity.Minimum = -10
        TrbVelocity.Name = "TrbVelocity"
        TrbVelocity.Size = New Size(199, 45)
        TrbVelocity.TabIndex = 104
        TrbVelocity.Value = -8
        ' 
        ' TxtVX
        ' 
        TxtVX.Enabled = False
        TxtVX.Font = New Font("Microsoft Sans Serif", 9F)
        TxtVX.Location = New Point(10, 294)
        TxtVX.Margin = New Padding(4)
        TxtVX.Name = "TxtVX"
        TxtVX.Size = New Size(95, 21)
        TxtVX.TabIndex = 100
        TxtVX.Text = "000.0000"
        ' 
        ' TxtY
        ' 
        TxtY.Enabled = False
        TxtY.Font = New Font("Microsoft Sans Serif", 9F)
        TxtY.Location = New Point(113, 245)
        TxtY.Margin = New Padding(4)
        TxtY.Name = "TxtY"
        TxtY.Size = New Size(93, 21)
        TxtY.TabIndex = 103
        TxtY.Text = "000.0000"
        ' 
        ' LblVelocity
        ' 
        LblVelocity.AutoSize = True
        LblVelocity.Font = New Font("Microsoft Sans Serif", 9F)
        LblVelocity.Location = New Point(10, 272)
        LblVelocity.Margin = New Padding(4, 0, 4, 0)
        LblVelocity.Name = "LblVelocity"
        LblVelocity.Size = New Size(48, 15)
        LblVelocity.TabIndex = 99
        LblVelocity.Text = "Velocity"
        ' 
        ' LblPosition
        ' 
        LblPosition.AutoSize = True
        LblPosition.Font = New Font("Microsoft Sans Serif", 9F)
        LblPosition.Location = New Point(11, 225)
        LblPosition.Margin = New Padding(4, 0, 4, 0)
        LblPosition.Name = "LblPosition"
        LblPosition.Size = New Size(51, 15)
        LblPosition.TabIndex = 102
        LblPosition.Text = "Position"
        ' 
        ' TxtX
        ' 
        TxtX.Enabled = False
        TxtX.Font = New Font("Microsoft Sans Serif", 9F)
        TxtX.Location = New Point(10, 245)
        TxtX.Margin = New Padding(4)
        TxtX.Name = "TxtX"
        TxtX.Size = New Size(95, 21)
        TxtX.TabIndex = 98
        TxtX.Text = "000.0000"
        ' 
        ' TxtMass
        ' 
        TxtMass.Enabled = False
        TxtMass.Location = New Point(45, 146)
        TxtMass.Name = "TxtMass"
        TxtMass.RightToLeft = RightToLeft.Yes
        TxtMass.Size = New Size(102, 21)
        TxtMass.TabIndex = 84
        ' 
        ' BtnSave
        ' 
        BtnSave.Enabled = False
        BtnSave.Location = New Point(7, 375)
        BtnSave.Margin = New Padding(4)
        BtnSave.Name = "BtnSave"
        BtnSave.Size = New Size(199, 30)
        BtnSave.TabIndex = 81
        BtnSave.Text = "Save"
        BtnSave.UseVisualStyleBackColor = True
        ' 
        ' LblDefault
        ' 
        LblDefault.AutoSize = True
        LblDefault.Font = New Font("Microsoft Sans Serif", 9F)
        LblDefault.Location = New Point(7, 17)
        LblDefault.Margin = New Padding(4, 0, 4, 0)
        LblDefault.Name = "LblDefault"
        LblDefault.Size = New Size(46, 15)
        LblDefault.TabIndex = 72
        LblDefault.Text = "Default"
        ' 
        ' CboDefaultStar
        ' 
        CboDefaultStar.BackColor = SystemColors.Window
        CboDefaultStar.Font = New Font("Microsoft Sans Serif", 9F)
        CboDefaultStar.FormattingEnabled = True
        CboDefaultStar.Location = New Point(7, 35)
        CboDefaultStar.Margin = New Padding(4)
        CboDefaultStar.Name = "CboDefaultStar"
        CboDefaultStar.Size = New Size(199, 23)
        CboDefaultStar.TabIndex = 71
        ' 
        ' LblMass
        ' 
        LblMass.AutoSize = True
        LblMass.Font = New Font("Microsoft Sans Serif", 9F)
        LblMass.Location = New Point(4, 149)
        LblMass.Margin = New Padding(4, 0, 4, 0)
        LblMass.Name = "LblMass"
        LblMass.Size = New Size(37, 15)
        LblMass.TabIndex = 47
        LblMass.Text = "Mass"
        ' 
        ' TrbMass
        ' 
        TrbMass.Location = New Point(7, 179)
        TrbMass.Margin = New Padding(4)
        TrbMass.Maximum = 20
        TrbMass.Minimum = -20
        TrbMass.Name = "TrbMass"
        TrbMass.Size = New Size(199, 45)
        TrbMass.TabIndex = 46
        ' 
        ' BtnNewStar
        ' 
        BtnNewStar.Font = New Font("Microsoft Sans Serif", 9F)
        BtnNewStar.Location = New Point(7, 62)
        BtnNewStar.Margin = New Padding(4)
        BtnNewStar.Name = "BtnNewStar"
        BtnNewStar.Size = New Size(199, 30)
        BtnNewStar.TabIndex = 23
        BtnNewStar.Text = "NewStar"
        BtnNewStar.UseVisualStyleBackColor = True
        ' 
        ' LblColor
        ' 
        LblColor.BackColor = Color.Red
        LblColor.Location = New Point(153, 116)
        LblColor.Margin = New Padding(4, 0, 4, 0)
        LblColor.Name = "LblColor"
        LblColor.Size = New Size(48, 23)
        LblColor.TabIndex = 26
        ' 
        ' LblStarColor
        ' 
        LblStarColor.AutoSize = True
        LblStarColor.Font = New Font("Microsoft Sans Serif", 9F)
        LblStarColor.Location = New Point(7, 96)
        LblStarColor.Margin = New Padding(4, 0, 4, 0)
        LblStarColor.Name = "LblStarColor"
        LblStarColor.Size = New Size(58, 15)
        LblStarColor.TabIndex = 25
        LblStarColor.Text = "StarColor"
        ' 
        ' CboStarColor
        ' 
        CboStarColor.BackColor = SystemColors.Window
        CboStarColor.Font = New Font("Microsoft Sans Serif", 9F)
        CboStarColor.FormattingEnabled = True
        CboStarColor.Items.AddRange(New Object() {"Yellow", "Gold", "Red", "Brown", "Orange", "Tomato", "Green", "Blue", "Black", "Magenta", "Chocolate"})
        CboStarColor.Location = New Point(7, 116)
        CboStarColor.Margin = New Padding(4)
        CboStarColor.Name = "CboStarColor"
        CboStarColor.Size = New Size(140, 23)
        CboStarColor.TabIndex = 24
        ' 
        ' LblUniverse
        ' 
        LblUniverse.AutoSize = True
        LblUniverse.Font = New Font("Microsoft Sans Serif", 9F)
        LblUniverse.Location = New Point(10, 6)
        LblUniverse.Margin = New Padding(4, 0, 4, 0)
        LblUniverse.Name = "LblUniverse"
        LblUniverse.Size = New Size(55, 15)
        LblUniverse.TabIndex = 102
        LblUniverse.Text = "Universe"
        ' 
        ' CboUniverse
        ' 
        CboUniverse.Font = New Font("Microsoft Sans Serif", 9F)
        CboUniverse.FormattingEnabled = True
        CboUniverse.Items.AddRange(New Object() {"DoublePendulum", "CombiPendulum", "ShakePendulum"})
        CboUniverse.Location = New Point(13, 26)
        CboUniverse.Margin = New Padding(4)
        CboUniverse.Name = "CboUniverse"
        CboUniverse.Size = New Size(199, 23)
        CboUniverse.TabIndex = 101
        ' 
        ' BtnStop
        ' 
        BtnStop.Enabled = False
        BtnStop.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStop.Location = New Point(114, 576)
        BtnStop.Margin = New Padding(4)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(105, 30)
        BtnStop.TabIndex = 100
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Enabled = False
        BtnStart.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStart.Location = New Point(6, 576)
        BtnStart.Margin = New Padding(4)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(105, 30)
        BtnStart.TabIndex = 99
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' ChkPhasePortrait
        ' 
        ChkPhasePortrait.AutoSize = True
        ChkPhasePortrait.Font = New Font("Microsoft Sans Serif", 9F)
        ChkPhasePortrait.Location = New Point(220, 399)
        ChkPhasePortrait.Name = "ChkPhasePortrait"
        ChkPhasePortrait.Size = New Size(100, 19)
        ChkPhasePortrait.TabIndex = 119
        ChkPhasePortrait.Text = "PhasePortrait"
        ChkPhasePortrait.UseVisualStyleBackColor = True
        ' 
        ' ChkZoom
        ' 
        ChkZoom.AutoSize = True
        ChkZoom.Checked = True
        ChkZoom.CheckState = CheckState.Checked
        ChkZoom.Font = New Font("Microsoft Sans Serif", 9F)
        ChkZoom.Location = New Point(262, 370)
        ChkZoom.Name = "ChkZoom"
        ChkZoom.Size = New Size(58, 19)
        ChkZoom.TabIndex = 118
        ChkZoom.Text = "Zoom"
        ChkZoom.UseVisualStyleBackColor = True
        ' 
        ' BtnClearUniverse
        ' 
        BtnClearUniverse.Enabled = False
        BtnClearUniverse.Font = New Font("Microsoft Sans Serif", 9F)
        BtnClearUniverse.Location = New Point(5, 575)
        BtnClearUniverse.Margin = New Padding(6, 8, 6, 8)
        BtnClearUniverse.Name = "BtnClearUniverse"
        BtnClearUniverse.Size = New Size(321, 30)
        BtnClearUniverse.TabIndex = 117
        BtnClearUniverse.Text = "ClearUniverse"
        BtnClearUniverse.UseVisualStyleBackColor = True
        ' 
        ' ChkConservationLaws
        ' 
        ChkConservationLaws.AutoSize = True
        ChkConservationLaws.Font = New Font("Microsoft Sans Serif", 9F)
        ChkConservationLaws.Location = New Point(6, 399)
        ChkConservationLaws.Name = "ChkConservationLaws"
        ChkConservationLaws.Size = New Size(186, 19)
        ChkConservationLaws.TabIndex = 116
        ChkConservationLaws.Text = "Supervise Conservation Laws"
        ChkConservationLaws.UseVisualStyleBackColor = True
        ' 
        ' LblPulse
        ' 
        LblPulse.AutoSize = True
        LblPulse.Font = New Font("Microsoft Sans Serif", 9F)
        LblPulse.Location = New Point(6, 425)
        LblPulse.Margin = New Padding(4, 0, 4, 0)
        LblPulse.Name = "LblPulse"
        LblPulse.Size = New Size(68, 15)
        LblPulse.TabIndex = 115
        LblPulse.Text = "Total Pulse"
        ' 
        ' PicPulse
        ' 
        PicPulse.BackColor = Color.White
        PicPulse.Location = New Point(134, 425)
        PicPulse.Margin = New Padding(4)
        PicPulse.Name = "PicPulse"
        PicPulse.Size = New Size(192, 19)
        PicPulse.TabIndex = 114
        PicPulse.TabStop = False
        ' 
        ' LblStepWidth
        ' 
        LblStepWidth.AutoSize = True
        LblStepWidth.Font = New Font("Microsoft Sans Serif", 9F)
        LblStepWidth.Location = New Point(6, 333)
        LblStepWidth.Margin = New Padding(4, 0, 4, 0)
        LblStepWidth.Name = "LblStepWidth"
        LblStepWidth.Size = New Size(86, 15)
        LblStepWidth.TabIndex = 113
        LblStepWidth.Text = "StepWidth: 0.1"
        ' 
        ' TrbStepWidth
        ' 
        TrbStepWidth.LargeChange = 7
        TrbStepWidth.Location = New Point(6, 352)
        TrbStepWidth.Maximum = 72
        TrbStepWidth.Minimum = 1
        TrbStepWidth.Name = "TrbStepWidth"
        TrbStepWidth.Size = New Size(250, 45)
        TrbStepWidth.TabIndex = 112
        TrbStepWidth.Value = 10
        ' 
        ' LblAngularMomentum
        ' 
        LblAngularMomentum.AutoSize = True
        LblAngularMomentum.Font = New Font("Microsoft Sans Serif", 9F)
        LblAngularMomentum.Location = New Point(5, 449)
        LblAngularMomentum.Margin = New Padding(4, 0, 4, 0)
        LblAngularMomentum.Name = "LblAngularMomentum"
        LblAngularMomentum.Size = New Size(128, 15)
        LblAngularMomentum.TabIndex = 111
        LblAngularMomentum.Text = "Total ang. Momentum"
        ' 
        ' PicAngularMomentum
        ' 
        PicAngularMomentum.BackColor = Color.White
        PicAngularMomentum.Location = New Point(134, 449)
        PicAngularMomentum.Margin = New Padding(4)
        PicAngularMomentum.Name = "PicAngularMomentum"
        PicAngularMomentum.Size = New Size(192, 19)
        PicAngularMomentum.TabIndex = 110
        PicAngularMomentum.TabStop = False
        ' 
        ' LblEnergy
        ' 
        LblEnergy.AutoSize = True
        LblEnergy.Font = New Font("Microsoft Sans Serif", 9F)
        LblEnergy.Location = New Point(5, 474)
        LblEnergy.Margin = New Padding(4, 0, 4, 0)
        LblEnergy.Name = "LblEnergy"
        LblEnergy.Size = New Size(75, 15)
        LblEnergy.TabIndex = 109
        LblEnergy.Text = "Total Energy"
        ' 
        ' PicEnergy
        ' 
        PicEnergy.BackColor = Color.White
        PicEnergy.Location = New Point(134, 474)
        PicEnergy.Margin = New Padding(4)
        PicEnergy.Name = "PicEnergy"
        PicEnergy.Size = New Size(193, 19)
        PicEnergy.TabIndex = 108
        PicEnergy.TabStop = False
        ' 
        ' PicPhasePortrait
        ' 
        PicPhasePortrait.BackColor = Color.White
        PicPhasePortrait.Location = New Point(5, 5)
        PicPhasePortrait.Margin = New Padding(4)
        PicPhasePortrait.Name = "PicPhasePortrait"
        PicPhasePortrait.Size = New Size(321, 320)
        PicPhasePortrait.TabIndex = 107
        PicPhasePortrait.TabStop = False
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Enabled = False
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(5, 505)
        BtnDefault.Margin = New Padding(6, 8, 6, 8)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(321, 30)
        BtnDefault.TabIndex = 106
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' BtnReset
        ' 
        BtnReset.Enabled = False
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(5, 539)
        BtnReset.Margin = New Padding(6, 8, 6, 8)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(321, 30)
        BtnReset.TabIndex = 105
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' FrmUniverse
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1168, 611)
        Controls.Add(SplitContainer1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "FrmUniverse"
        StartPosition = FormStartPosition.WindowsDefaultBounds
        Text = "Universe"
        WindowState = FormWindowState.Maximized
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer2.Panel1.ResumeLayout(False)
        SplitContainer2.Panel1.PerformLayout()
        SplitContainer2.Panel2.ResumeLayout(False)
        SplitContainer2.Panel2.PerformLayout()
        CType(SplitContainer2, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer2.ResumeLayout(False)
        GrpNewStar.ResumeLayout(False)
        GrpNewStar.PerformLayout()
        CType(TrbVelocity, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbMass, ComponentModel.ISupportInitialize).EndInit()
        CType(PicPulse, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbStepWidth, ComponentModel.ISupportInitialize).EndInit()
        CType(PicAngularMomentum, ComponentModel.ISupportInitialize).EndInit()
        CType(PicEnergy, ComponentModel.ISupportInitialize).EndInit()
        CType(PicPhasePortrait, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents LblTime As Label
    Friend WithEvents BtnTakeOverConstellation As Button
    Friend WithEvents LblSteps As Label
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents LblConstellations As Label
    Friend WithEvents CboConstellations As ComboBox
    Friend WithEvents GrpNewStar As GroupBox
    Friend WithEvents TxtVY As TextBox
    Friend WithEvents TrbVelocity As TrackBar
    Friend WithEvents TxtVX As TextBox
    Friend WithEvents TxtY As TextBox
    Friend WithEvents LblVelocity As Label
    Friend WithEvents LblPosition As Label
    Friend WithEvents TxtX As TextBox
    Friend WithEvents TxtMass As TextBox
    Friend WithEvents BtnSave As Button
    Friend WithEvents LblDefault As Label
    Friend WithEvents CboDefaultStar As ComboBox
    Friend WithEvents LblMass As Label
    Friend WithEvents TrbMass As TrackBar
    Friend WithEvents BtnNewStar As Button
    Friend WithEvents LblColor As Label
    Friend WithEvents LblStarColor As Label
    Friend WithEvents CboStarColor As ComboBox
    Friend WithEvents LblUniverse As Label
    Friend WithEvents CboUniverse As ComboBox
    Friend WithEvents BtnStop As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents ChkPhasePortrait As CheckBox
    Friend WithEvents ChkZoom As CheckBox
    Friend WithEvents BtnClearUniverse As Button
    Friend WithEvents ChkConservationLaws As CheckBox
    Friend WithEvents LblPulse As Label
    Friend WithEvents PicPulse As PictureBox
    Friend WithEvents LblStepWidth As Label
    Friend WithEvents TrbStepWidth As TrackBar
    Friend WithEvents LblAngularMomentum As Label
    Friend WithEvents PicAngularMomentum As PictureBox
    Friend WithEvents LblEnergy As Label
    Friend WithEvents PicEnergy As PictureBox
    Friend WithEvents PicPhasePortrait As PictureBox
    Friend WithEvents BtnDefault As Button
    Friend WithEvents BtnReset As Button
End Class
