<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmJulia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmJulia))
        SplitContainer = New SplitContainer()
        PicDiagram = New PictureBox()
        BtnDefault = New Button()
        PicDark = New PictureBox()
        PicBright = New PictureBox()
        TrbBlue = New TrackBar()
        TrbGreen = New TrackBar()
        TrbRed = New TrackBar()
        ChkProtocol = New CheckBox()
        LblProtocol = New Label()
        LstProtocol = New ListBox()
        BtnReset = New Button()
        TxtTime = New TextBox()
        TxtSteps = New TextBox()
        LblTime = New Label()
        LblNumberOfSteps = New Label()
        BtnStop = New Button()
        BtnStart = New Button()
        LblJuliaSets = New Label()
        CboJuliaSamples = New ComboBox()
        GrpColors = New GroupBox()
        OptSystem = New RadioButton()
        OptUser = New RadioButton()
        LblPower = New Label()
        CboN = New ComboBox()
        LblI = New Label()
        LblC = New Label()
        TxtA = New TextBox()
        TxtB = New TextBox()
        LblDeltaY = New Label()
        TxtYMax = New TextBox()
        LblYMax = New Label()
        TxtYMin = New TextBox()
        LblYMin = New Label()
        LblDeltaX = New Label()
        TxtXMax = New TextBox()
        LblXMax = New Label()
        TxtXMin = New TextBox()
        LblXMin = New Label()
        CboFunction = New ComboBox()
        CType(SplitContainer, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer.Panel1.SuspendLayout()
        SplitContainer.Panel2.SuspendLayout()
        SplitContainer.SuspendLayout()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicDark, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicBright, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbBlue, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbGreen, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbRed, ComponentModel.ISupportInitialize).BeginInit()
        GrpColors.SuspendLayout()
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
        SplitContainer.Panel2.Controls.Add(BtnDefault)
        SplitContainer.Panel2.Controls.Add(PicDark)
        SplitContainer.Panel2.Controls.Add(PicBright)
        SplitContainer.Panel2.Controls.Add(TrbBlue)
        SplitContainer.Panel2.Controls.Add(TrbGreen)
        SplitContainer.Panel2.Controls.Add(TrbRed)
        SplitContainer.Panel2.Controls.Add(ChkProtocol)
        SplitContainer.Panel2.Controls.Add(LblProtocol)
        SplitContainer.Panel2.Controls.Add(LstProtocol)
        SplitContainer.Panel2.Controls.Add(BtnReset)
        SplitContainer.Panel2.Controls.Add(TxtTime)
        SplitContainer.Panel2.Controls.Add(TxtSteps)
        SplitContainer.Panel2.Controls.Add(LblTime)
        SplitContainer.Panel2.Controls.Add(LblNumberOfSteps)
        SplitContainer.Panel2.Controls.Add(BtnStop)
        SplitContainer.Panel2.Controls.Add(BtnStart)
        SplitContainer.Panel2.Controls.Add(LblJuliaSets)
        SplitContainer.Panel2.Controls.Add(CboJuliaSamples)
        SplitContainer.Panel2.Controls.Add(GrpColors)
        SplitContainer.Panel2.Controls.Add(LblPower)
        SplitContainer.Panel2.Controls.Add(CboN)
        SplitContainer.Panel2.Controls.Add(LblI)
        SplitContainer.Panel2.Controls.Add(LblC)
        SplitContainer.Panel2.Controls.Add(TxtA)
        SplitContainer.Panel2.Controls.Add(TxtB)
        SplitContainer.Panel2.Controls.Add(LblDeltaY)
        SplitContainer.Panel2.Controls.Add(TxtYMax)
        SplitContainer.Panel2.Controls.Add(LblYMax)
        SplitContainer.Panel2.Controls.Add(TxtYMin)
        SplitContainer.Panel2.Controls.Add(LblYMin)
        SplitContainer.Panel2.Controls.Add(LblDeltaX)
        SplitContainer.Panel2.Controls.Add(TxtXMax)
        SplitContainer.Panel2.Controls.Add(LblXMax)
        SplitContainer.Panel2.Controls.Add(TxtXMin)
        SplitContainer.Panel2.Controls.Add(LblXMin)
        SplitContainer.Panel2.Controls.Add(CboFunction)
        SplitContainer.Size = New Size(1138, 690)
        SplitContainer.SplitterDistance = 686
        SplitContainer.SplitterWidth = 6
        SplitContainer.TabIndex = 0
        ' 
        ' PicDiagram
        ' 
        PicDiagram.Location = New Point(4, 4)
        PicDiagram.Margin = New Padding(4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(680, 680)
        PicDiagram.TabIndex = 2
        PicDiagram.TabStop = False
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(4, 621)
        BtnDefault.Margin = New Padding(4)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(436, 30)
        BtnDefault.TabIndex = 114
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' PicDark
        ' 
        PicDark.Location = New Point(334, 388)
        PicDark.Margin = New Padding(4, 2, 4, 2)
        PicDark.Name = "PicDark"
        PicDark.Size = New Size(106, 70)
        PicDark.TabIndex = 113
        PicDark.TabStop = False
        ' 
        ' PicBright
        ' 
        PicBright.Location = New Point(334, 313)
        PicBright.Margin = New Padding(4, 2, 4, 2)
        PicBright.Name = "PicBright"
        PicBright.Size = New Size(106, 70)
        PicBright.TabIndex = 112
        PicBright.TabStop = False
        ' 
        ' TrbBlue
        ' 
        TrbBlue.BackColor = SystemColors.Control
        TrbBlue.Location = New Point(11, 410)
        TrbBlue.Margin = New Padding(4, 2, 4, 2)
        TrbBlue.Name = "TrbBlue"
        TrbBlue.Size = New Size(310, 45)
        TrbBlue.TabIndex = 111
        TrbBlue.Value = 2
        ' 
        ' TrbGreen
        ' 
        TrbGreen.BackColor = SystemColors.Control
        TrbGreen.Location = New Point(11, 359)
        TrbGreen.Margin = New Padding(4, 2, 4, 2)
        TrbGreen.Name = "TrbGreen"
        TrbGreen.Size = New Size(310, 45)
        TrbGreen.TabIndex = 110
        TrbGreen.Value = 10
        ' 
        ' TrbRed
        ' 
        TrbRed.BackColor = SystemColors.Control
        TrbRed.Location = New Point(11, 310)
        TrbRed.Margin = New Padding(4, 2, 4, 2)
        TrbRed.Name = "TrbRed"
        TrbRed.Size = New Size(310, 45)
        TrbRed.TabIndex = 109
        ' 
        ' ChkProtocol
        ' 
        ChkProtocol.AutoSize = True
        ChkProtocol.Font = New Font("Microsoft Sans Serif", 9F)
        ChkProtocol.Location = New Point(369, 519)
        ChkProtocol.Margin = New Padding(4, 2, 4, 2)
        ChkProtocol.Name = "ChkProtocol"
        ChkProtocol.Size = New Size(71, 19)
        ChkProtocol.TabIndex = 108
        ChkProtocol.Text = "Protocol"
        ChkProtocol.UseVisualStyleBackColor = True
        ' 
        ' LblProtocol
        ' 
        LblProtocol.AutoSize = True
        LblProtocol.Font = New Font("Microsoft Sans Serif", 9F)
        LblProtocol.Location = New Point(10, 520)
        LblProtocol.Margin = New Padding(4, 0, 4, 0)
        LblProtocol.Name = "LblProtocol"
        LblProtocol.Size = New Size(52, 15)
        LblProtocol.TabIndex = 107
        LblProtocol.Text = "Protocol"
        ' 
        ' LstProtocol
        ' 
        LstProtocol.Font = New Font("Microsoft Sans Serif", 9F)
        LstProtocol.FormattingEnabled = True
        LstProtocol.HorizontalScrollbar = True
        LstProtocol.ItemHeight = 15
        LstProtocol.Location = New Point(8, 539)
        LstProtocol.Margin = New Padding(4)
        LstProtocol.Name = "LstProtocol"
        LstProtocol.Size = New Size(432, 79)
        LstProtocol.TabIndex = 106
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(4, 654)
        BtnReset.Margin = New Padding(4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(436, 30)
        BtnReset.TabIndex = 105
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' TxtTime
        ' 
        TxtTime.Enabled = False
        TxtTime.Font = New Font("Microsoft Sans Serif", 9F)
        TxtTime.Location = New Point(255, 462)
        TxtTime.Margin = New Padding(4, 2, 4, 2)
        TxtTime.Name = "TxtTime"
        TxtTime.Size = New Size(185, 21)
        TxtTime.TabIndex = 104
        ' 
        ' TxtSteps
        ' 
        TxtSteps.Enabled = False
        TxtSteps.Font = New Font("Microsoft Sans Serif", 9F)
        TxtSteps.Location = New Point(60, 459)
        TxtSteps.Margin = New Padding(4, 2, 4, 2)
        TxtSteps.Name = "TxtSteps"
        TxtSteps.Size = New Size(144, 21)
        TxtSteps.TabIndex = 103
        ' 
        ' LblTime
        ' 
        LblTime.AutoSize = True
        LblTime.Font = New Font("Microsoft Sans Serif", 9F)
        LblTime.Location = New Point(212, 462)
        LblTime.Margin = New Padding(4, 0, 4, 0)
        LblTime.Name = "LblTime"
        LblTime.Size = New Size(35, 15)
        LblTime.TabIndex = 102
        LblTime.Text = "Time"
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblNumberOfSteps.Location = New Point(10, 462)
        LblNumberOfSteps.Margin = New Padding(4, 0, 4, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(38, 15)
        LblNumberOfSteps.TabIndex = 101
        LblNumberOfSteps.Text = "Steps"
        ' 
        ' BtnStop
        ' 
        BtnStop.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStop.Location = New Point(240, 486)
        BtnStop.Margin = New Padding(4)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(200, 30)
        BtnStop.TabIndex = 100
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStart.Location = New Point(8, 486)
        BtnStart.Margin = New Padding(4)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(200, 30)
        BtnStart.TabIndex = 99
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' LblJuliaSets
        ' 
        LblJuliaSets.AutoSize = True
        LblJuliaSets.Font = New Font("Microsoft Sans Serif", 9F)
        LblJuliaSets.Location = New Point(4, 63)
        LblJuliaSets.Margin = New Padding(4, 0, 4, 0)
        LblJuliaSets.Name = "LblJuliaSets"
        LblJuliaSets.Size = New Size(56, 15)
        LblJuliaSets.TabIndex = 98
        LblJuliaSets.Text = "Samples"
        ' 
        ' CboJuliaSamples
        ' 
        CboJuliaSamples.Font = New Font("Microsoft Sans Serif", 9F)
        CboJuliaSamples.FormattingEnabled = True
        CboJuliaSamples.Location = New Point(62, 58)
        CboJuliaSamples.Margin = New Padding(4)
        CboJuliaSamples.Name = "CboJuliaSamples"
        CboJuliaSamples.Size = New Size(378, 23)
        CboJuliaSamples.TabIndex = 97
        ' 
        ' GrpColors
        ' 
        GrpColors.Controls.Add(OptSystem)
        GrpColors.Controls.Add(OptUser)
        GrpColors.Font = New Font("Microsoft Sans Serif", 9F)
        GrpColors.Location = New Point(10, 252)
        GrpColors.Margin = New Padding(4, 2, 4, 2)
        GrpColors.Name = "GrpColors"
        GrpColors.Padding = New Padding(4, 2, 4, 2)
        GrpColors.Size = New Size(430, 54)
        GrpColors.TabIndex = 96
        GrpColors.TabStop = False
        GrpColors.Text = "Colors"
        ' 
        ' OptSystem
        ' 
        OptSystem.AutoSize = True
        OptSystem.Checked = True
        OptSystem.Location = New Point(63, 17)
        OptSystem.Margin = New Padding(4, 2, 4, 2)
        OptSystem.Name = "OptSystem"
        OptSystem.Size = New Size(65, 19)
        OptSystem.TabIndex = 75
        OptSystem.TabStop = True
        OptSystem.Text = "System"
        OptSystem.UseVisualStyleBackColor = True
        ' 
        ' OptUser
        ' 
        OptUser.AutoSize = True
        OptUser.Location = New Point(174, 17)
        OptUser.Margin = New Padding(4, 2, 4, 2)
        OptUser.Name = "OptUser"
        OptUser.Size = New Size(94, 19)
        OptUser.TabIndex = 76
        OptUser.Text = "UserDefined"
        OptUser.UseVisualStyleBackColor = True
        ' 
        ' LblPower
        ' 
        LblPower.AutoSize = True
        LblPower.Font = New Font("Microsoft Sans Serif", 9F)
        LblPower.Location = New Point(359, 7)
        LblPower.Margin = New Padding(4, 0, 4, 0)
        LblPower.Name = "LblPower"
        LblPower.Size = New Size(24, 15)
        LblPower.TabIndex = 95
        LblPower.Text = "n ="
        ' 
        ' CboN
        ' 
        CboN.Font = New Font("Microsoft Sans Serif", 9F)
        CboN.FormattingEnabled = True
        CboN.Items.AddRange(New Object() {"2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        CboN.Location = New Point(388, 4)
        CboN.Margin = New Padding(4, 2, 4, 2)
        CboN.Name = "CboN"
        CboN.Size = New Size(52, 23)
        CboN.TabIndex = 94
        ' 
        ' LblI
        ' 
        LblI.AutoSize = True
        LblI.Font = New Font("Microsoft Sans Serif", 9F)
        LblI.Location = New Point(201, 34)
        LblI.Margin = New Padding(4, 0, 4, 0)
        LblI.Name = "LblI"
        LblI.Size = New Size(20, 15)
        LblI.TabIndex = 93
        LblI.Text = "+ i"
        ' 
        ' LblC
        ' 
        LblC.AutoSize = True
        LblC.Font = New Font("Segoe UI", 9F)
        LblC.Location = New Point(8, 34)
        LblC.Margin = New Padding(4, 0, 4, 0)
        LblC.Name = "LblC"
        LblC.Size = New Size(24, 15)
        LblC.TabIndex = 92
        LblC.Text = "c ="
        ' 
        ' TxtA
        ' 
        TxtA.Font = New Font("Microsoft Sans Serif", 9F)
        TxtA.Location = New Point(42, 31)
        TxtA.Margin = New Padding(4, 2, 4, 2)
        TxtA.Name = "TxtA"
        TxtA.Size = New Size(151, 21)
        TxtA.TabIndex = 91
        TxtA.Text = "0"
        ' 
        ' TxtB
        ' 
        TxtB.Font = New Font("Microsoft Sans Serif", 9F)
        TxtB.Location = New Point(229, 31)
        TxtB.Margin = New Padding(4, 2, 4, 2)
        TxtB.Name = "TxtB"
        TxtB.Size = New Size(211, 21)
        TxtB.TabIndex = 90
        TxtB.Text = "0"
        ' 
        ' LblDeltaY
        ' 
        LblDeltaY.AutoSize = True
        LblDeltaY.Font = New Font("Microsoft Sans Serif", 9F)
        LblDeltaY.Location = New Point(8, 224)
        LblDeltaY.Margin = New Padding(4, 0, 4, 0)
        LblDeltaY.Name = "LblDeltaY"
        LblDeltaY.Size = New Size(43, 15)
        LblDeltaY.TabIndex = 89
        LblDeltaY.Text = "DeltaY"
        ' 
        ' TxtYMax
        ' 
        TxtYMax.Font = New Font("Microsoft Sans Serif", 9F)
        TxtYMax.Location = New Point(62, 195)
        TxtYMax.Margin = New Padding(4)
        TxtYMax.Name = "TxtYMax"
        TxtYMax.Size = New Size(378, 21)
        TxtYMax.TabIndex = 88
        ' 
        ' LblYMax
        ' 
        LblYMax.AutoSize = True
        LblYMax.Font = New Font("Microsoft Sans Serif", 9F)
        LblYMax.Location = New Point(11, 198)
        LblYMax.Margin = New Padding(4, 0, 4, 0)
        LblYMax.Name = "LblYMax"
        LblYMax.Size = New Size(38, 15)
        LblYMax.TabIndex = 87
        LblYMax.Text = "YMax"
        ' 
        ' TxtYMin
        ' 
        TxtYMin.Font = New Font("Microsoft Sans Serif", 9F)
        TxtYMin.Location = New Point(62, 166)
        TxtYMin.Margin = New Padding(4)
        TxtYMin.Name = "TxtYMin"
        TxtYMin.Size = New Size(378, 21)
        TxtYMin.TabIndex = 86
        ' 
        ' LblYMin
        ' 
        LblYMin.AutoSize = True
        LblYMin.Font = New Font("Microsoft Sans Serif", 9F)
        LblYMin.Location = New Point(11, 172)
        LblYMin.Margin = New Padding(4, 0, 4, 0)
        LblYMin.Name = "LblYMin"
        LblYMin.Size = New Size(35, 15)
        LblYMin.TabIndex = 85
        LblYMin.Text = "YMin"
        ' 
        ' LblDeltaX
        ' 
        LblDeltaX.AutoSize = True
        LblDeltaX.Font = New Font("Microsoft Sans Serif", 9F)
        LblDeltaX.Location = New Point(8, 148)
        LblDeltaX.Margin = New Padding(4, 0, 4, 0)
        LblDeltaX.Name = "LblDeltaX"
        LblDeltaX.Size = New Size(44, 15)
        LblDeltaX.TabIndex = 84
        LblDeltaX.Text = "DeltaX"
        ' 
        ' TxtXMax
        ' 
        TxtXMax.Font = New Font("Microsoft Sans Serif", 9F)
        TxtXMax.Location = New Point(62, 118)
        TxtXMax.Margin = New Padding(4)
        TxtXMax.Name = "TxtXMax"
        TxtXMax.Size = New Size(378, 21)
        TxtXMax.TabIndex = 83
        ' 
        ' LblXMax
        ' 
        LblXMax.AutoSize = True
        LblXMax.Font = New Font("Microsoft Sans Serif", 9F)
        LblXMax.Location = New Point(10, 121)
        LblXMax.Margin = New Padding(4, 0, 4, 0)
        LblXMax.Name = "LblXMax"
        LblXMax.Size = New Size(39, 15)
        LblXMax.TabIndex = 82
        LblXMax.Text = "XMax"
        ' 
        ' TxtXMin
        ' 
        TxtXMin.Font = New Font("Microsoft Sans Serif", 9F)
        TxtXMin.Location = New Point(62, 89)
        TxtXMin.Margin = New Padding(4)
        TxtXMin.Name = "TxtXMin"
        TxtXMin.Size = New Size(378, 21)
        TxtXMin.TabIndex = 81
        ' 
        ' LblXMin
        ' 
        LblXMin.AutoSize = True
        LblXMin.Font = New Font("Microsoft Sans Serif", 9F)
        LblXMin.Location = New Point(10, 89)
        LblXMin.Margin = New Padding(4, 0, 4, 0)
        LblXMin.Name = "LblXMin"
        LblXMin.Size = New Size(36, 15)
        LblXMin.TabIndex = 80
        LblXMin.Text = "XMin"
        ' 
        ' CboFunction
        ' 
        CboFunction.DropDownStyle = ComboBoxStyle.DropDownList
        CboFunction.Font = New Font("Microsoft Sans Serif", 9F)
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"JuliaSet", "MandelbrotSet"})
        CboFunction.Location = New Point(4, 4)
        CboFunction.Margin = New Padding(4)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(347, 23)
        CboFunction.TabIndex = 79
        ' 
        ' FrmJulia
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1138, 690)
        Controls.Add(SplitContainer)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimumSize = New Size(511, 729)
        Name = "FrmJulia"
        StartPosition = FormStartPosition.WindowsDefaultBounds
        Text = "JuliaSet"
        WindowState = FormWindowState.Maximized
        SplitContainer.Panel1.ResumeLayout(False)
        SplitContainer.Panel2.ResumeLayout(False)
        SplitContainer.Panel2.PerformLayout()
        CType(SplitContainer, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer.ResumeLayout(False)
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        CType(PicDark, ComponentModel.ISupportInitialize).EndInit()
        CType(PicBright, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbBlue, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbGreen, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbRed, ComponentModel.ISupportInitialize).EndInit()
        GrpColors.ResumeLayout(False)
        GrpColors.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer As SplitContainer
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents BtnDefault As Button
    Friend WithEvents PicDark As PictureBox
    Friend WithEvents PicBright As PictureBox
    Friend WithEvents TrbBlue As TrackBar
    Friend WithEvents TrbGreen As TrackBar
    Friend WithEvents TrbRed As TrackBar
    Friend WithEvents ChkProtocol As CheckBox
    Friend WithEvents LblProtocol As Label
    Friend WithEvents LstProtocol As ListBox
    Friend WithEvents BtnReset As Button
    Friend WithEvents TxtTime As TextBox
    Friend WithEvents TxtSteps As TextBox
    Friend WithEvents LblTime As Label
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents BtnStop As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents LblJuliaSets As Label
    Friend WithEvents CboJuliaSamples As ComboBox
    Friend WithEvents GrpColors As GroupBox
    Friend WithEvents OptSystem As RadioButton
    Friend WithEvents OptUser As RadioButton
    Friend WithEvents LblPower As Label
    Friend WithEvents CboN As ComboBox
    Friend WithEvents LblI As Label
    Friend WithEvents LblC As Label
    Friend WithEvents TxtA As TextBox
    Friend WithEvents TxtB As TextBox
    Friend WithEvents LblDeltaY As Label
    Friend WithEvents TxtYMax As TextBox
    Friend WithEvents LblYMax As Label
    Friend WithEvents TxtYMin As TextBox
    Friend WithEvents LblYMin As Label
    Friend WithEvents LblDeltaX As Label
    Friend WithEvents TxtXMax As TextBox
    Friend WithEvents LblXMax As Label
    Friend WithEvents TxtXMin As TextBox
    Friend WithEvents LblXMin As Label
    Friend WithEvents CboFunction As ComboBox
End Class
