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
        PicDiagram = New PictureBox()
        BtnDefault = New Button()
        BtnStop = New Button()
        BtnReset = New Button()
        BtnStart = New Button()
        PicPhasePortrait = New PictureBox()
        CboUniverse = New ComboBox()
        PicEnergy = New PictureBox()
        LblEnergy = New Label()
        LblAngularMomentum = New Label()
        PicAngularMomentum = New PictureBox()
        LblUniverse = New Label()
        GrpNewStar = New GroupBox()
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
        TrbVelocity = New TrackBar()
        TxtY = New TextBox()
        LblPosition = New Label()
        TxtVX = New TextBox()
        LblVelocity = New Label()
        TxtX = New TextBox()
        LblConstellation = New Label()
        CboConstellation = New ComboBox()
        TrbStepWidth = New TrackBar()
        LblPulse = New Label()
        PicPulse = New PictureBox()
        LblSteps = New Label()
        LblNumberOfSteps = New Label()
        LblStepWidth = New Label()
        ChkConservationLaws = New CheckBox()
        BtnTakeOverConstellation = New Button()
        BtnClearUniverse = New Button()
        LblTime = New Label()
        ChkZoom = New CheckBox()
        ChkPhasePortrait = New CheckBox()
        TxtVY = New TextBox()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicPhasePortrait, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicEnergy, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicAngularMomentum, ComponentModel.ISupportInitialize).BeginInit()
        GrpNewStar.SuspendLayout()
        CType(TrbMass, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbVelocity, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbStepWidth, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicPulse, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.Black
        PicDiagram.Location = New Point(4, 7)
        PicDiagram.Margin = New Padding(4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(600, 600)
        PicDiagram.TabIndex = 29
        PicDiagram.TabStop = False
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Enabled = False
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(837, 507)
        BtnDefault.Margin = New Padding(6, 8, 6, 8)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(321, 30)
        BtnDefault.TabIndex = 58
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' BtnStop
        ' 
        BtnStop.Enabled = False
        BtnStop.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStop.Location = New Point(722, 577)
        BtnStop.Margin = New Padding(4)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(105, 30)
        BtnStop.TabIndex = 57
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' BtnReset
        ' 
        BtnReset.Enabled = False
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(837, 541)
        BtnReset.Margin = New Padding(6, 8, 6, 8)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(321, 30)
        BtnReset.TabIndex = 54
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Enabled = False
        BtnStart.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStart.Location = New Point(614, 577)
        BtnStart.Margin = New Padding(4)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(105, 30)
        BtnStart.TabIndex = 53
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' PicPhasePortrait
        ' 
        PicPhasePortrait.BackColor = Color.White
        PicPhasePortrait.Location = New Point(837, 7)
        PicPhasePortrait.Margin = New Padding(4)
        PicPhasePortrait.Name = "PicPhasePortrait"
        PicPhasePortrait.Size = New Size(321, 320)
        PicPhasePortrait.TabIndex = 59
        PicPhasePortrait.TabStop = False
        ' 
        ' CboUniverse
        ' 
        CboUniverse.Font = New Font("Microsoft Sans Serif", 9F)
        CboUniverse.FormattingEnabled = True
        CboUniverse.Items.AddRange(New Object() {"DoublePendulum", "CombiPendulum", "ShakePendulum"})
        CboUniverse.Location = New Point(621, 27)
        CboUniverse.Margin = New Padding(4)
        CboUniverse.Name = "CboUniverse"
        CboUniverse.Size = New Size(199, 23)
        CboUniverse.TabIndex = 61
        ' 
        ' PicEnergy
        ' 
        PicEnergy.BackColor = Color.White
        PicEnergy.Location = New Point(966, 476)
        PicEnergy.Margin = New Padding(4)
        PicEnergy.Name = "PicEnergy"
        PicEnergy.Size = New Size(193, 19)
        PicEnergy.TabIndex = 64
        PicEnergy.TabStop = False
        ' 
        ' LblEnergy
        ' 
        LblEnergy.AutoSize = True
        LblEnergy.Font = New Font("Microsoft Sans Serif", 9F)
        LblEnergy.Location = New Point(837, 476)
        LblEnergy.Margin = New Padding(4, 0, 4, 0)
        LblEnergy.Name = "LblEnergy"
        LblEnergy.Size = New Size(75, 15)
        LblEnergy.TabIndex = 65
        LblEnergy.Text = "Total Energy"
        ' 
        ' LblAngularMomentum
        ' 
        LblAngularMomentum.AutoSize = True
        LblAngularMomentum.Font = New Font("Microsoft Sans Serif", 9F)
        LblAngularMomentum.Location = New Point(837, 451)
        LblAngularMomentum.Margin = New Padding(4, 0, 4, 0)
        LblAngularMomentum.Name = "LblAngularMomentum"
        LblAngularMomentum.Size = New Size(128, 15)
        LblAngularMomentum.TabIndex = 67
        LblAngularMomentum.Text = "Total ang. Momentum"
        ' 
        ' PicAngularMomentum
        ' 
        PicAngularMomentum.BackColor = Color.White
        PicAngularMomentum.Location = New Point(966, 451)
        PicAngularMomentum.Margin = New Padding(4)
        PicAngularMomentum.Name = "PicAngularMomentum"
        PicAngularMomentum.Size = New Size(192, 19)
        PicAngularMomentum.TabIndex = 66
        PicAngularMomentum.TabStop = False
        ' 
        ' LblUniverse
        ' 
        LblUniverse.AutoSize = True
        LblUniverse.Font = New Font("Microsoft Sans Serif", 9F)
        LblUniverse.Location = New Point(618, 7)
        LblUniverse.Margin = New Padding(4, 0, 4, 0)
        LblUniverse.Name = "LblUniverse"
        LblUniverse.Size = New Size(55, 15)
        LblUniverse.TabIndex = 68
        LblUniverse.Text = "Universe"
        ' 
        ' GrpNewStar
        ' 
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
        GrpNewStar.Location = New Point(614, 141)
        GrpNewStar.Name = "GrpNewStar"
        GrpNewStar.Size = New Size(213, 414)
        GrpNewStar.TabIndex = 69
        GrpNewStar.TabStop = False
        GrpNewStar.Text = "NewStar"
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
        ' TrbVelocity
        ' 
        TrbVelocity.Location = New Point(618, 467)
        TrbVelocity.Margin = New Padding(4)
        TrbVelocity.Minimum = -10
        TrbVelocity.Name = "TrbVelocity"
        TrbVelocity.Size = New Size(199, 45)
        TrbVelocity.TabIndex = 97
        TrbVelocity.Value = -8
        ' 
        ' TxtY
        ' 
        TxtY.Enabled = False
        TxtY.Font = New Font("Microsoft Sans Serif", 9F)
        TxtY.Location = New Point(724, 390)
        TxtY.Margin = New Padding(4)
        TxtY.Name = "TxtY"
        TxtY.RightToLeft = RightToLeft.Yes
        TxtY.Size = New Size(93, 21)
        TxtY.TabIndex = 95
        TxtY.Text = "000.0000"
        ' 
        ' LblPosition
        ' 
        LblPosition.AutoSize = True
        LblPosition.Font = New Font("Microsoft Sans Serif", 9F)
        LblPosition.Location = New Point(622, 370)
        LblPosition.Margin = New Padding(4, 0, 4, 0)
        LblPosition.Name = "LblPosition"
        LblPosition.Size = New Size(51, 15)
        LblPosition.TabIndex = 94
        LblPosition.Text = "Position"
        ' 
        ' TxtVX
        ' 
        TxtVX.Enabled = False
        TxtVX.Font = New Font("Microsoft Sans Serif", 9F)
        TxtVX.Location = New Point(621, 439)
        TxtVX.Margin = New Padding(4)
        TxtVX.Name = "TxtVX"
        TxtVX.RightToLeft = RightToLeft.Yes
        TxtVX.Size = New Size(95, 21)
        TxtVX.TabIndex = 79
        TxtVX.Text = "000.0000"
        ' 
        ' LblVelocity
        ' 
        LblVelocity.AutoSize = True
        LblVelocity.Font = New Font("Microsoft Sans Serif", 9F)
        LblVelocity.Location = New Point(621, 417)
        LblVelocity.Margin = New Padding(4, 0, 4, 0)
        LblVelocity.Name = "LblVelocity"
        LblVelocity.Size = New Size(48, 15)
        LblVelocity.TabIndex = 77
        LblVelocity.Text = "Velocity"
        ' 
        ' TxtX
        ' 
        TxtX.Enabled = False
        TxtX.Font = New Font("Microsoft Sans Serif", 9F)
        TxtX.Location = New Point(621, 390)
        TxtX.Margin = New Padding(4)
        TxtX.Name = "TxtX"
        TxtX.RightToLeft = RightToLeft.Yes
        TxtX.Size = New Size(95, 21)
        TxtX.TabIndex = 75
        TxtX.Text = "000.0000"
        ' 
        ' LblConstellation
        ' 
        LblConstellation.AutoSize = True
        LblConstellation.Font = New Font("Microsoft Sans Serif", 9F)
        LblConstellation.Location = New Point(618, 54)
        LblConstellation.Margin = New Padding(4, 0, 4, 0)
        LblConstellation.Name = "LblConstellation"
        LblConstellation.Size = New Size(78, 15)
        LblConstellation.TabIndex = 71
        LblConstellation.Text = "Constellation"
        ' 
        ' CboConstellation
        ' 
        CboConstellation.Font = New Font("Microsoft Sans Serif", 9F)
        CboConstellation.FormattingEnabled = True
        CboConstellation.Items.AddRange(New Object() {"DoublePendulum", "CombiPendulum", "ShakePendulum"})
        CboConstellation.Location = New Point(621, 76)
        CboConstellation.Margin = New Padding(4)
        CboConstellation.Name = "CboConstellation"
        CboConstellation.Size = New Size(199, 23)
        CboConstellation.TabIndex = 70
        ' 
        ' TrbStepWidth
        ' 
        TrbStepWidth.LargeChange = 7
        TrbStepWidth.Location = New Point(838, 354)
        TrbStepWidth.Maximum = 72
        TrbStepWidth.Minimum = 1
        TrbStepWidth.Name = "TrbStepWidth"
        TrbStepWidth.Size = New Size(250, 45)
        TrbStepWidth.TabIndex = 72
        TrbStepWidth.Value = 10
        ' 
        ' LblPulse
        ' 
        LblPulse.AutoSize = True
        LblPulse.Font = New Font("Microsoft Sans Serif", 9F)
        LblPulse.Location = New Point(838, 427)
        LblPulse.Margin = New Padding(4, 0, 4, 0)
        LblPulse.Name = "LblPulse"
        LblPulse.Size = New Size(68, 15)
        LblPulse.TabIndex = 75
        LblPulse.Text = "Total Pulse"
        ' 
        ' PicPulse
        ' 
        PicPulse.BackColor = Color.White
        PicPulse.Location = New Point(966, 427)
        PicPulse.Margin = New Padding(4)
        PicPulse.Name = "PicPulse"
        PicPulse.Size = New Size(192, 19)
        PicPulse.TabIndex = 74
        PicPulse.TabStop = False
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblSteps.Location = New Point(719, 558)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(14, 15)
        LblSteps.TabIndex = 77
        LblSteps.Text = "0"
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblNumberOfSteps.Location = New Point(614, 558)
        LblNumberOfSteps.Margin = New Padding(4, 0, 4, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(102, 15)
        LblNumberOfSteps.TabIndex = 76
        LblNumberOfSteps.Text = "Number of Steps:"
        ' 
        ' LblStepWidth
        ' 
        LblStepWidth.AutoSize = True
        LblStepWidth.Font = New Font("Microsoft Sans Serif", 9F)
        LblStepWidth.Location = New Point(838, 335)
        LblStepWidth.Margin = New Padding(4, 0, 4, 0)
        LblStepWidth.Name = "LblStepWidth"
        LblStepWidth.Size = New Size(86, 15)
        LblStepWidth.TabIndex = 73
        LblStepWidth.Text = "StepWidth: 0.1"
        ' 
        ' ChkConservationLaws
        ' 
        ChkConservationLaws.AutoSize = True
        ChkConservationLaws.Font = New Font("Microsoft Sans Serif", 9F)
        ChkConservationLaws.Location = New Point(838, 401)
        ChkConservationLaws.Name = "ChkConservationLaws"
        ChkConservationLaws.Size = New Size(186, 19)
        ChkConservationLaws.TabIndex = 78
        ChkConservationLaws.Text = "Supervise Conservation Laws"
        ChkConservationLaws.UseVisualStyleBackColor = True
        ' 
        ' BtnTakeOverConstellation
        ' 
        BtnTakeOverConstellation.Font = New Font("Microsoft Sans Serif", 9F)
        BtnTakeOverConstellation.Location = New Point(621, 107)
        BtnTakeOverConstellation.Margin = New Padding(4)
        BtnTakeOverConstellation.Name = "BtnTakeOverConstellation"
        BtnTakeOverConstellation.Size = New Size(199, 30)
        BtnTakeOverConstellation.TabIndex = 82
        BtnTakeOverConstellation.Text = "TakeOverConstellation"
        BtnTakeOverConstellation.UseVisualStyleBackColor = True
        ' 
        ' BtnClearUniverse
        ' 
        BtnClearUniverse.Enabled = False
        BtnClearUniverse.Font = New Font("Microsoft Sans Serif", 9F)
        BtnClearUniverse.Location = New Point(837, 577)
        BtnClearUniverse.Margin = New Padding(6, 8, 6, 8)
        BtnClearUniverse.Name = "BtnClearUniverse"
        BtnClearUniverse.Size = New Size(321, 30)
        BtnClearUniverse.TabIndex = 83
        BtnClearUniverse.Text = "ClearUniverse"
        BtnClearUniverse.UseVisualStyleBackColor = True
        ' 
        ' LblTime
        ' 
        LblTime.AutoSize = True
        LblTime.Font = New Font("Microsoft Sans Serif", 9F)
        LblTime.Location = New Point(780, 558)
        LblTime.Name = "LblTime"
        LblTime.Size = New Size(35, 15)
        LblTime.TabIndex = 98
        LblTime.Text = "Time"
        ' 
        ' ChkZoom
        ' 
        ChkZoom.AutoSize = True
        ChkZoom.Checked = True
        ChkZoom.CheckState = CheckState.Checked
        ChkZoom.Font = New Font("Microsoft Sans Serif", 9F)
        ChkZoom.Location = New Point(1094, 372)
        ChkZoom.Name = "ChkZoom"
        ChkZoom.Size = New Size(58, 19)
        ChkZoom.TabIndex = 103
        ChkZoom.Text = "Zoom"
        ChkZoom.UseVisualStyleBackColor = True
        ' 
        ' ChkPhasePortrait
        ' 
        ChkPhasePortrait.AutoSize = True
        ChkPhasePortrait.Font = New Font("Microsoft Sans Serif", 9F)
        ChkPhasePortrait.Location = New Point(1052, 401)
        ChkPhasePortrait.Name = "ChkPhasePortrait"
        ChkPhasePortrait.Size = New Size(100, 19)
        ChkPhasePortrait.TabIndex = 104
        ChkPhasePortrait.Text = "PhasePortrait"
        ChkPhasePortrait.UseVisualStyleBackColor = True
        ' 
        ' TxtVY
        ' 
        TxtVY.Enabled = False
        TxtVY.Font = New Font("Microsoft Sans Serif", 9F)
        TxtVY.Location = New Point(724, 439)
        TxtVY.Margin = New Padding(4)
        TxtVY.Name = "TxtVY"
        TxtVY.RightToLeft = RightToLeft.Yes
        TxtVY.Size = New Size(95, 21)
        TxtVY.TabIndex = 85
        TxtVY.Text = "000.0000"
        ' 
        ' FrmUniverse
        ' 
        AutoScaleDimensions = New SizeF(9F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1168, 611)
        Controls.Add(TxtVY)
        Controls.Add(TrbVelocity)
        Controls.Add(ChkPhasePortrait)
        Controls.Add(TxtVX)
        Controls.Add(TxtY)
        Controls.Add(ChkZoom)
        Controls.Add(LblVelocity)
        Controls.Add(LblPosition)
        Controls.Add(LblTime)
        Controls.Add(BtnClearUniverse)
        Controls.Add(BtnTakeOverConstellation)
        Controls.Add(ChkConservationLaws)
        Controls.Add(TxtX)
        Controls.Add(LblSteps)
        Controls.Add(LblNumberOfSteps)
        Controls.Add(LblPulse)
        Controls.Add(PicPulse)
        Controls.Add(LblStepWidth)
        Controls.Add(TrbStepWidth)
        Controls.Add(LblConstellation)
        Controls.Add(CboConstellation)
        Controls.Add(GrpNewStar)
        Controls.Add(LblUniverse)
        Controls.Add(LblAngularMomentum)
        Controls.Add(PicAngularMomentum)
        Controls.Add(LblEnergy)
        Controls.Add(PicEnergy)
        Controls.Add(CboUniverse)
        Controls.Add(PicPhasePortrait)
        Controls.Add(BtnDefault)
        Controls.Add(BtnStop)
        Controls.Add(BtnReset)
        Controls.Add(BtnStart)
        Controls.Add(PicDiagram)
        Font = New Font("Microsoft Sans Serif", 11.14F)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 4, 3, 4)
        Name = "FrmUniverse"
        Text = "Universe"
        WindowState = FormWindowState.Maximized
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        CType(PicPhasePortrait, ComponentModel.ISupportInitialize).EndInit()
        CType(PicEnergy, ComponentModel.ISupportInitialize).EndInit()
        CType(PicAngularMomentum, ComponentModel.ISupportInitialize).EndInit()
        GrpNewStar.ResumeLayout(False)
        GrpNewStar.PerformLayout()
        CType(TrbMass, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbVelocity, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbStepWidth, ComponentModel.ISupportInitialize).EndInit()
        CType(PicPulse, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents BtnDefault As Button
    Friend WithEvents BtnStop As Button
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents PicPhasePortrait As PictureBox
    Friend WithEvents CboUniverse As ComboBox
    Friend WithEvents PicEnergy As PictureBox
    Friend WithEvents LblEnergy As Label
    Friend WithEvents LblAngularMomentum As Label
    Friend WithEvents PicAngularMomentum As PictureBox
    Friend WithEvents LblUniverse As Label
    Friend WithEvents GrpNewStar As GroupBox
    Friend WithEvents LblColor As Label
    Friend WithEvents LblStarColor As Label
    Friend WithEvents CboStarColor As ComboBox
    Friend WithEvents BtnNewStar As Button
    Friend WithEvents LblMass As Label
    Friend WithEvents TrbMass As TrackBar
    Friend WithEvents LblDefault As Label
    Friend WithEvents CboDefaultStar As ComboBox
    Friend WithEvents BtnSave As Button
    Friend WithEvents TxtVX As TextBox
    Friend WithEvents LblVelocity As Label
    Friend WithEvents TxtX As TextBox
    Friend WithEvents LblPerihel As Label
    Friend WithEvents LblConstellation As Label
    Friend WithEvents CboConstellation As ComboBox
    Friend WithEvents LblKg As Label
    Friend WithEvents TxtMass As TextBox
    Friend WithEvents LblAE As Label
    Friend WithEvents TrbStepWidth As TrackBar
    Friend WithEvents LblRad As Label
    Friend WithEvents TxtY As TextBox
    Friend WithEvents LblPosition As Label
    Friend WithEvents LblPulse As Label
    Friend WithEvents PicPulse As PictureBox
    Friend WithEvents LblSteps As Label
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents LblStepWidth As Label
    Friend WithEvents ChkConservationLaws As CheckBox
    Friend WithEvents BtnTakeOverConstellation As Button
    Friend WithEvents BtnClearUniverse As Button
    Friend WithEvents TrbVelocity As TrackBar
    Friend WithEvents LblTime As Label
    Friend WithEvents ChkZoom As CheckBox
    Friend WithEvents ChkPhasePortrait As CheckBox
    Friend WithEvents TxtVY As TextBox
    Friend WithEvents ChkCollisions As CheckBox
End Class
