<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLSystems
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLSystems))
        SplitContainer = New SplitContainer()
        PicDiagram = New PictureBox()
        BtnRestoreCopy = New Button()
        LstDebug = New ListBox()
        BtnGetDefaultSystems = New Button()
        GrpIteration = New GroupBox()
        BtnReset = New Button()
        BtnStart = New Button()
        GrpRules = New GroupBox()
        BtnSaveRule = New Button()
        BtnDeleteRule = New Button()
        BtnAddRule = New Button()
        TxtTarget = New TextBox()
        LblTarget = New Label()
        TxtSource = New TextBox()
        LblSource = New Label()
        CboRules = New ComboBox()
        GrpSystemParameters = New GroupBox()
        CboType = New ComboBox()
        LblType = New Label()
        TxtY = New TextBox()
        LblY = New Label()
        TxtX = New TextBox()
        LblX = New Label()
        LblStartPosition = New Label()
        CboScaling = New ComboBox()
        LblScaling = New Label()
        TxtStartLength = New TextBox()
        LblStartLength = New Label()
        TxtName = New TextBox()
        LblName = New Label()
        LblDegreeR = New Label()
        LblDegreeL = New Label()
        BtnCancel = New Button()
        BtnSaveSystem = New Button()
        BtnEditSystem = New Button()
        ChkExtended = New CheckBox()
        TxtScaleFactor = New TextBox()
        LblScaleFactor = New Label()
        BtnDeleteSystem = New Button()
        BtnAddSystem = New Button()
        LblShowColor = New Label()
        LblColor = New Label()
        CboColor = New ComboBox()
        TxtAngleRight = New TextBox()
        LblAngleRight = New Label()
        TxtAngleLeft = New TextBox()
        LblAngleLeft = New Label()
        TxtAxiom = New TextBox()
        LblAxiom = New Label()
        CboSystem = New ComboBox()
        BtnStop = New Button()
        CType(SplitContainer, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer.Panel1.SuspendLayout()
        SplitContainer.Panel2.SuspendLayout()
        SplitContainer.SuspendLayout()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        GrpIteration.SuspendLayout()
        GrpRules.SuspendLayout()
        GrpSystemParameters.SuspendLayout()
        SuspendLayout()
        ' 
        ' SplitContainer
        ' 
        SplitContainer.Dock = DockStyle.Fill
        SplitContainer.FixedPanel = FixedPanel.Panel2
        SplitContainer.Location = New Point(0, 0)
        SplitContainer.Name = "SplitContainer"
        ' 
        ' SplitContainer.Panel1
        ' 
        SplitContainer.Panel1.Controls.Add(PicDiagram)
        ' 
        ' SplitContainer.Panel2
        ' 
        SplitContainer.Panel2.Controls.Add(BtnRestoreCopy)
        SplitContainer.Panel2.Controls.Add(LstDebug)
        SplitContainer.Panel2.Controls.Add(BtnGetDefaultSystems)
        SplitContainer.Panel2.Controls.Add(GrpIteration)
        SplitContainer.Panel2.Controls.Add(GrpRules)
        SplitContainer.Panel2.Controls.Add(GrpSystemParameters)
        SplitContainer.Panel2.Controls.Add(CboSystem)
        SplitContainer.Size = New Size(1091, 613)
        SplitContainer.SplitterDistance = 613
        SplitContainer.SplitterWidth = 6
        SplitContainer.TabIndex = 0
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(3, 3)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(607, 605)
        PicDiagram.TabIndex = 0
        PicDiagram.TabStop = False
        ' 
        ' BtnRestoreCopy
        ' 
        BtnRestoreCopy.Location = New Point(237, 42)
        BtnRestoreCopy.Name = "BtnRestoreCopy"
        BtnRestoreCopy.Size = New Size(222, 28)
        BtnRestoreCopy.TabIndex = 73
        BtnRestoreCopy.Text = "RestoreCopy"
        BtnRestoreCopy.UseVisualStyleBackColor = True
        ' 
        ' LstDebug
        ' 
        LstDebug.FormattingEnabled = True
        LstDebug.ItemHeight = 15
        LstDebug.Location = New Point(10, 517)
        LstDebug.Name = "LstDebug"
        LstDebug.Size = New Size(449, 94)
        LstDebug.TabIndex = 72
        ' 
        ' BtnGetDefaultSystems
        ' 
        BtnGetDefaultSystems.Location = New Point(11, 42)
        BtnGetDefaultSystems.Name = "BtnGetDefaultSystems"
        BtnGetDefaultSystems.Size = New Size(222, 28)
        BtnGetDefaultSystems.TabIndex = 11
        BtnGetDefaultSystems.Text = "GetDefaultSystems"
        BtnGetDefaultSystems.UseVisualStyleBackColor = True
        ' 
        ' GrpIteration
        ' 
        GrpIteration.Controls.Add(BtnStop)
        GrpIteration.Controls.Add(BtnReset)
        GrpIteration.Controls.Add(BtnStart)
        GrpIteration.Location = New Point(5, 461)
        GrpIteration.Name = "GrpIteration"
        GrpIteration.Size = New Size(454, 52)
        GrpIteration.TabIndex = 71
        GrpIteration.TabStop = False
        GrpIteration.Text = "Iteration"
        ' 
        ' BtnReset
        ' 
        BtnReset.Location = New Point(316, 18)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(128, 28)
        BtnReset.TabIndex = 83
        BtnReset.Text = "Reset"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Location = New Point(5, 18)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(126, 28)
        BtnStart.TabIndex = 82
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' GrpRules
        ' 
        GrpRules.Controls.Add(BtnSaveRule)
        GrpRules.Controls.Add(BtnDeleteRule)
        GrpRules.Controls.Add(BtnAddRule)
        GrpRules.Controls.Add(TxtTarget)
        GrpRules.Controls.Add(LblTarget)
        GrpRules.Controls.Add(TxtSource)
        GrpRules.Controls.Add(LblSource)
        GrpRules.Controls.Add(CboRules)
        GrpRules.Location = New Point(5, 327)
        GrpRules.Name = "GrpRules"
        GrpRules.Size = New Size(454, 128)
        GrpRules.TabIndex = 70
        GrpRules.TabStop = False
        GrpRules.Text = "Rules"
        ' 
        ' BtnSaveRule
        ' 
        BtnSaveRule.Location = New Point(159, 88)
        BtnSaveRule.Name = "BtnSaveRule"
        BtnSaveRule.Size = New Size(129, 28)
        BtnSaveRule.TabIndex = 83
        BtnSaveRule.Text = "SaveRule"
        BtnSaveRule.UseVisualStyleBackColor = True
        ' 
        ' BtnDeleteRule
        ' 
        BtnDeleteRule.Location = New Point(316, 88)
        BtnDeleteRule.Name = "BtnDeleteRule"
        BtnDeleteRule.Size = New Size(128, 28)
        BtnDeleteRule.TabIndex = 82
        BtnDeleteRule.Text = "DeleteRule"
        BtnDeleteRule.UseVisualStyleBackColor = True
        ' 
        ' BtnAddRule
        ' 
        BtnAddRule.Location = New Point(6, 88)
        BtnAddRule.Name = "BtnAddRule"
        BtnAddRule.Size = New Size(129, 28)
        BtnAddRule.TabIndex = 81
        BtnAddRule.Text = "AddRule"
        BtnAddRule.UseVisualStyleBackColor = True
        ' 
        ' TxtTarget
        ' 
        TxtTarget.Location = New Point(162, 55)
        TxtTarget.Name = "TxtTarget"
        TxtTarget.Size = New Size(282, 23)
        TxtTarget.TabIndex = 8
        ' 
        ' LblTarget
        ' 
        LblTarget.AutoSize = True
        LblTarget.Location = New Point(116, 57)
        LblTarget.Name = "LblTarget"
        LblTarget.Size = New Size(40, 15)
        LblTarget.TabIndex = 11
        LblTarget.Text = "Target"
        ' 
        ' TxtSource
        ' 
        TxtSource.Location = New Point(65, 54)
        TxtSource.Name = "TxtSource"
        TxtSource.Size = New Size(45, 23)
        TxtSource.TabIndex = 7
        ' 
        ' LblSource
        ' 
        LblSource.AutoSize = True
        LblSource.Location = New Point(5, 58)
        LblSource.Name = "LblSource"
        LblSource.Size = New Size(43, 15)
        LblSource.TabIndex = 9
        LblSource.Text = "Source"
        ' 
        ' CboRules
        ' 
        CboRules.DropDownStyle = ComboBoxStyle.DropDownList
        CboRules.FormattingEnabled = True
        CboRules.Location = New Point(5, 22)
        CboRules.Name = "CboRules"
        CboRules.Size = New Size(439, 23)
        CboRules.TabIndex = 0
        ' 
        ' GrpSystemParameters
        ' 
        GrpSystemParameters.Controls.Add(CboType)
        GrpSystemParameters.Controls.Add(LblType)
        GrpSystemParameters.Controls.Add(TxtY)
        GrpSystemParameters.Controls.Add(LblY)
        GrpSystemParameters.Controls.Add(TxtX)
        GrpSystemParameters.Controls.Add(LblX)
        GrpSystemParameters.Controls.Add(LblStartPosition)
        GrpSystemParameters.Controls.Add(CboScaling)
        GrpSystemParameters.Controls.Add(LblScaling)
        GrpSystemParameters.Controls.Add(TxtStartLength)
        GrpSystemParameters.Controls.Add(LblStartLength)
        GrpSystemParameters.Controls.Add(TxtName)
        GrpSystemParameters.Controls.Add(LblName)
        GrpSystemParameters.Controls.Add(LblDegreeR)
        GrpSystemParameters.Controls.Add(LblDegreeL)
        GrpSystemParameters.Controls.Add(BtnCancel)
        GrpSystemParameters.Controls.Add(BtnSaveSystem)
        GrpSystemParameters.Controls.Add(BtnEditSystem)
        GrpSystemParameters.Controls.Add(ChkExtended)
        GrpSystemParameters.Controls.Add(TxtScaleFactor)
        GrpSystemParameters.Controls.Add(LblScaleFactor)
        GrpSystemParameters.Controls.Add(BtnDeleteSystem)
        GrpSystemParameters.Controls.Add(BtnAddSystem)
        GrpSystemParameters.Controls.Add(LblShowColor)
        GrpSystemParameters.Controls.Add(LblColor)
        GrpSystemParameters.Controls.Add(CboColor)
        GrpSystemParameters.Controls.Add(TxtAngleRight)
        GrpSystemParameters.Controls.Add(LblAngleRight)
        GrpSystemParameters.Controls.Add(TxtAngleLeft)
        GrpSystemParameters.Controls.Add(LblAngleLeft)
        GrpSystemParameters.Controls.Add(TxtAxiom)
        GrpSystemParameters.Controls.Add(LblAxiom)
        GrpSystemParameters.Location = New Point(5, 76)
        GrpSystemParameters.Name = "GrpSystemParameters"
        GrpSystemParameters.Size = New Size(454, 245)
        GrpSystemParameters.TabIndex = 0
        GrpSystemParameters.TabStop = False
        GrpSystemParameters.Text = "SystemParameters"
        ' 
        ' CboType
        ' 
        CboType.BackColor = SystemColors.Window
        CboType.Font = New Font("Microsoft Sans Serif", 9F)
        CboType.FormattingEnabled = True
        CboType.Location = New Point(336, 18)
        CboType.Margin = New Padding(4)
        CboType.Name = "CboType"
        CboType.Size = New Size(108, 23)
        CboType.TabIndex = 96
        ' 
        ' LblType
        ' 
        LblType.AutoSize = True
        LblType.Location = New Point(294, 22)
        LblType.Name = "LblType"
        LblType.Size = New Size(32, 15)
        LblType.TabIndex = 95
        LblType.Text = "Type"
        ' 
        ' TxtY
        ' 
        TxtY.Location = New Point(316, 144)
        TxtY.Name = "TxtY"
        TxtY.Size = New Size(32, 23)
        TxtY.TabIndex = 94
        ' 
        ' LblY
        ' 
        LblY.AutoSize = True
        LblY.Font = New Font("Microsoft Sans Serif", 9F)
        LblY.Location = New Point(288, 146)
        LblY.Margin = New Padding(4, 0, 4, 0)
        LblY.Name = "LblY"
        LblY.Size = New Size(21, 15)
        LblY.TabIndex = 93
        LblY.Text = "Y="
        ' 
        ' TxtX
        ' 
        TxtX.Location = New Point(230, 144)
        TxtX.Name = "TxtX"
        TxtX.Size = New Size(32, 23)
        TxtX.TabIndex = 92
        ' 
        ' LblX
        ' 
        LblX.AutoSize = True
        LblX.Font = New Font("Microsoft Sans Serif", 9F)
        LblX.Location = New Point(206, 146)
        LblX.Margin = New Padding(4, 0, 4, 0)
        LblX.Name = "LblX"
        LblX.Size = New Size(22, 15)
        LblX.TabIndex = 91
        LblX.Text = "X="
        ' 
        ' LblStartPosition
        ' 
        LblStartPosition.AutoSize = True
        LblStartPosition.Location = New Point(7, 147)
        LblStartPosition.Name = "LblStartPosition"
        LblStartPosition.Size = New Size(189, 15)
        LblStartPosition.TabIndex = 90
        LblStartPosition.Text = "StartPosition (X/Y) in [0,13] x [0,13]"
        ' 
        ' CboScaling
        ' 
        CboScaling.BackColor = SystemColors.Window
        CboScaling.Font = New Font("Microsoft Sans Serif", 9F)
        CboScaling.FormattingEnabled = True
        CboScaling.Location = New Point(336, 79)
        CboScaling.Margin = New Padding(4)
        CboScaling.Name = "CboScaling"
        CboScaling.Size = New Size(108, 23)
        CboScaling.TabIndex = 5
        ' 
        ' LblScaling
        ' 
        LblScaling.AutoSize = True
        LblScaling.Location = New Point(274, 83)
        LblScaling.Name = "LblScaling"
        LblScaling.Size = New Size(45, 15)
        LblScaling.TabIndex = 87
        LblScaling.Text = "Scaling"
        ' 
        ' TxtStartLength
        ' 
        TxtStartLength.Location = New Point(89, 80)
        TxtStartLength.Name = "TxtStartLength"
        TxtStartLength.Size = New Size(31, 23)
        TxtStartLength.TabIndex = 3
        ' 
        ' LblStartLength
        ' 
        LblStartLength.AutoSize = True
        LblStartLength.Location = New Point(6, 83)
        LblStartLength.Name = "LblStartLength"
        LblStartLength.Size = New Size(68, 15)
        LblStartLength.TabIndex = 86
        LblStartLength.Text = "StartLength"
        ' 
        ' TxtName
        ' 
        TxtName.Location = New Point(89, 19)
        TxtName.Name = "TxtName"
        TxtName.Size = New Size(190, 23)
        TxtName.TabIndex = 0
        TxtName.Text = "123456789012345678901234567890"
        ' 
        ' LblName
        ' 
        LblName.AutoSize = True
        LblName.Location = New Point(8, 28)
        LblName.Name = "LblName"
        LblName.Size = New Size(39, 15)
        LblName.TabIndex = 84
        LblName.Text = "Name"
        ' 
        ' LblDegreeR
        ' 
        LblDegreeR.AutoSize = True
        LblDegreeR.Location = New Point(256, 111)
        LblDegreeR.Name = "LblDegreeR"
        LblDegreeR.Size = New Size(12, 15)
        LblDegreeR.TabIndex = 83
        LblDegreeR.Text = "°"
        ' 
        ' LblDegreeL
        ' 
        LblDegreeL.AutoSize = True
        LblDegreeL.Location = New Point(122, 111)
        LblDegreeL.Name = "LblDegreeL"
        LblDegreeL.Size = New Size(12, 15)
        LblDegreeL.TabIndex = 82
        LblDegreeL.Text = "°"
        ' 
        ' BtnCancel
        ' 
        BtnCancel.Location = New Point(160, 207)
        BtnCancel.Name = "BtnCancel"
        BtnCancel.Size = New Size(129, 28)
        BtnCancel.TabIndex = 80
        BtnCancel.Text = "Cancel"
        BtnCancel.UseVisualStyleBackColor = True
        ' 
        ' BtnSaveSystem
        ' 
        BtnSaveSystem.Location = New Point(6, 207)
        BtnSaveSystem.Name = "BtnSaveSystem"
        BtnSaveSystem.Size = New Size(129, 28)
        BtnSaveSystem.TabIndex = 79
        BtnSaveSystem.Text = "SaveSystem"
        BtnSaveSystem.UseVisualStyleBackColor = True
        ' 
        ' BtnEditSystem
        ' 
        BtnEditSystem.Location = New Point(160, 173)
        BtnEditSystem.Name = "BtnEditSystem"
        BtnEditSystem.Size = New Size(129, 28)
        BtnEditSystem.TabIndex = 78
        BtnEditSystem.Text = "EditSystem"
        BtnEditSystem.UseVisualStyleBackColor = True
        ' 
        ' ChkExtended
        ' 
        ChkExtended.AutoSize = True
        ChkExtended.Location = New Point(336, 113)
        ChkExtended.Name = "ChkExtended"
        ChkExtended.Size = New Size(74, 19)
        ChkExtended.TabIndex = 8
        ChkExtended.Text = "Extended"
        ChkExtended.UseVisualStyleBackColor = True
        ' 
        ' TxtScaleFactor
        ' 
        TxtScaleFactor.Location = New Point(202, 80)
        TxtScaleFactor.Name = "TxtScaleFactor"
        TxtScaleFactor.Size = New Size(66, 23)
        TxtScaleFactor.TabIndex = 4
        ' 
        ' LblScaleFactor
        ' 
        LblScaleFactor.AutoSize = True
        LblScaleFactor.Location = New Point(129, 83)
        LblScaleFactor.Name = "LblScaleFactor"
        LblScaleFactor.Size = New Size(67, 15)
        LblScaleFactor.TabIndex = 74
        LblScaleFactor.Text = "ScaleFactor"
        ' 
        ' BtnDeleteSystem
        ' 
        BtnDeleteSystem.Location = New Point(317, 173)
        BtnDeleteSystem.Name = "BtnDeleteSystem"
        BtnDeleteSystem.Size = New Size(128, 28)
        BtnDeleteSystem.TabIndex = 73
        BtnDeleteSystem.Text = "DeleteSystem"
        BtnDeleteSystem.UseVisualStyleBackColor = True
        ' 
        ' BtnAddSystem
        ' 
        BtnAddSystem.Location = New Point(6, 173)
        BtnAddSystem.Name = "BtnAddSystem"
        BtnAddSystem.Size = New Size(129, 28)
        BtnAddSystem.TabIndex = 72
        BtnAddSystem.Text = "AddSystem"
        BtnAddSystem.UseVisualStyleBackColor = True
        ' 
        ' LblShowColor
        ' 
        LblShowColor.BackColor = Color.Tomato
        LblShowColor.Location = New Point(248, 50)
        LblShowColor.Margin = New Padding(4, 0, 4, 0)
        LblShowColor.Name = "LblShowColor"
        LblShowColor.Size = New Size(20, 23)
        LblShowColor.TabIndex = 71
        ' 
        ' LblColor
        ' 
        LblColor.AutoSize = True
        LblColor.Font = New Font("Microsoft Sans Serif", 9F)
        LblColor.Location = New Point(8, 55)
        LblColor.Margin = New Padding(4, 0, 4, 0)
        LblColor.Name = "LblColor"
        LblColor.Size = New Size(36, 15)
        LblColor.TabIndex = 70
        LblColor.Text = "Color"
        ' 
        ' CboColor
        ' 
        CboColor.BackColor = SystemColors.Window
        CboColor.Font = New Font("Microsoft Sans Serif", 9F)
        CboColor.FormattingEnabled = True
        CboColor.Location = New Point(89, 50)
        CboColor.Margin = New Padding(4)
        CboColor.Name = "CboColor"
        CboColor.Size = New Size(151, 23)
        CboColor.TabIndex = 2
        ' 
        ' TxtAngleRight
        ' 
        TxtAngleRight.Location = New Point(218, 109)
        TxtAngleRight.Name = "TxtAngleRight"
        TxtAngleRight.Size = New Size(32, 23)
        TxtAngleRight.TabIndex = 7
        ' 
        ' LblAngleRight
        ' 
        LblAngleRight.AutoSize = True
        LblAngleRight.Location = New Point(140, 114)
        LblAngleRight.Name = "LblAngleRight"
        LblAngleRight.Size = New Size(66, 15)
        LblAngleRight.TabIndex = 11
        LblAngleRight.Text = "AngleRight"
        ' 
        ' TxtAngleLeft
        ' 
        TxtAngleLeft.Location = New Point(89, 109)
        TxtAngleLeft.Name = "TxtAngleLeft"
        TxtAngleLeft.Size = New Size(31, 23)
        TxtAngleLeft.TabIndex = 6
        ' 
        ' LblAngleLeft
        ' 
        LblAngleLeft.AutoSize = True
        LblAngleLeft.Location = New Point(7, 114)
        LblAngleLeft.Name = "LblAngleLeft"
        LblAngleLeft.Size = New Size(58, 15)
        LblAngleLeft.TabIndex = 9
        LblAngleLeft.Text = "AngleLeft"
        ' 
        ' TxtAxiom
        ' 
        TxtAxiom.Location = New Point(336, 49)
        TxtAxiom.Name = "TxtAxiom"
        TxtAxiom.Size = New Size(109, 23)
        TxtAxiom.TabIndex = 1
        ' 
        ' LblAxiom
        ' 
        LblAxiom.AutoSize = True
        LblAxiom.Location = New Point(285, 52)
        LblAxiom.Name = "LblAxiom"
        LblAxiom.Size = New Size(41, 15)
        LblAxiom.TabIndex = 7
        LblAxiom.Text = "Axiom"
        ' 
        ' CboSystem
        ' 
        CboSystem.DropDownStyle = ComboBoxStyle.DropDownList
        CboSystem.FormattingEnabled = True
        CboSystem.Location = New Point(11, 12)
        CboSystem.Name = "CboSystem"
        CboSystem.Size = New Size(448, 23)
        CboSystem.TabIndex = 10
        ' 
        ' BtnStop
        ' 
        BtnStop.Location = New Point(159, 18)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(126, 28)
        BtnStop.TabIndex = 84
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' FrmLSystems
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1091, 613)
        Controls.Add(SplitContainer)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimumSize = New Size(521, 652)
        Name = "FrmLSystems"
        StartPosition = FormStartPosition.WindowsDefaultBounds
        Text = "FrmLSystems"
        WindowState = FormWindowState.Maximized
        SplitContainer.Panel1.ResumeLayout(False)
        SplitContainer.Panel2.ResumeLayout(False)
        CType(SplitContainer, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer.ResumeLayout(False)
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        GrpIteration.ResumeLayout(False)
        GrpRules.ResumeLayout(False)
        GrpRules.PerformLayout()
        GrpSystemParameters.ResumeLayout(False)
        GrpSystemParameters.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer As SplitContainer
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents CboSystem As ComboBox
    Friend WithEvents GrpSystemParameters As GroupBox
    Friend WithEvents LblShowColor As Label
    Friend WithEvents LblColor As Label
    Friend WithEvents CboColor As ComboBox
    Friend WithEvents TxtAngleRight As TextBox
    Friend WithEvents LblAngleRight As Label
    Friend WithEvents TxtAngleLeft As TextBox
    Friend WithEvents LblAngleLeft As Label
    Friend WithEvents TxtAxiom As TextBox
    Friend WithEvents LblAxiom As Label
    Friend WithEvents GrpRules As GroupBox
    Friend WithEvents CboRules As ComboBox
    Friend WithEvents BtnDeleteSystem As Button
    Friend WithEvents BtnAddSystem As Button
    Friend WithEvents TxtScaleFactor As TextBox
    Friend WithEvents LblScaleFactor As Label
    Friend WithEvents ChkExtended As CheckBox
    Friend WithEvents BtnEditSystem As Button
    Friend WithEvents TxtSource As TextBox
    Friend WithEvents LblSource As Label
    Friend WithEvents BtnCancel As Button
    Friend WithEvents BtnSaveSystem As Button
    Friend WithEvents LblTarget As Label
    Friend WithEvents TxtTarget As TextBox
    Friend WithEvents BtnDeleteRule As Button
    Friend WithEvents BtnAddRule As Button
    Friend WithEvents GrpIteration As GroupBox
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents LblDegreeR As Label
    Friend WithEvents LblDegreeL As Label
    Friend WithEvents TxtName As TextBox
    Friend WithEvents LblName As Label
    Friend WithEvents BtnSaveRule As Button
    Friend WithEvents BtnGetDefaultSystems As Button
    Friend WithEvents TxtStartLength As TextBox
    Friend WithEvents LblStartLength As Label
    Friend WithEvents LblStartPosition As Label
    Friend WithEvents CboScaling As ComboBox
    Friend WithEvents LblScaling As Label
    Friend WithEvents TxtY As TextBox
    Friend WithEvents LblY As Label
    Friend WithEvents TxtX As TextBox
    Friend WithEvents LblX As Label
    Friend WithEvents LstDebug As ListBox
    Friend WithEvents BtnRestoreCopy As Button
    Friend WithEvents CboType As ComboBox
    Friend WithEvents LblType As Label
    Friend WithEvents BtnStop As Button
End Class
