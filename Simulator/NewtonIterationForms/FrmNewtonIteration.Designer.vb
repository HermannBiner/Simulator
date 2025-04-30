<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNewtonIteration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNewtonIteration))
        SplitContainer = New SplitContainer()
        PicDiagram = New PictureBox()
        BtnDefault = New Button()
        BtnShowBasin = New Button()
        GrpColor = New GroupBox()
        OptShaded = New RadioButton()
        OptBright = New RadioButton()
        GrpMixing = New GroupBox()
        OptRotate = New RadioButton()
        OptConjugate = New RadioButton()
        OptNone = New RadioButton()
        ChkProtocol = New CheckBox()
        TxtTime = New TextBox()
        TxtSteps = New TextBox()
        LblTime = New Label()
        LblSteps = New Label()
        LblProtocol = New Label()
        LstProtocol = New ListBox()
        BtnStop = New Button()
        BtnStart = New Button()
        BtnReset = New Button()
        LblPower = New Label()
        LblI = New Label()
        LblC = New Label()
        TxtA = New TextBox()
        TxtB = New TextBox()
        CboN = New ComboBox()
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
        GrpColor.SuspendLayout()
        GrpMixing.SuspendLayout()
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
        SplitContainer.Panel2.Controls.Add(BtnShowBasin)
        SplitContainer.Panel2.Controls.Add(GrpColor)
        SplitContainer.Panel2.Controls.Add(GrpMixing)
        SplitContainer.Panel2.Controls.Add(ChkProtocol)
        SplitContainer.Panel2.Controls.Add(TxtTime)
        SplitContainer.Panel2.Controls.Add(TxtSteps)
        SplitContainer.Panel2.Controls.Add(LblTime)
        SplitContainer.Panel2.Controls.Add(LblSteps)
        SplitContainer.Panel2.Controls.Add(LblProtocol)
        SplitContainer.Panel2.Controls.Add(LstProtocol)
        SplitContainer.Panel2.Controls.Add(BtnStop)
        SplitContainer.Panel2.Controls.Add(BtnStart)
        SplitContainer.Panel2.Controls.Add(BtnReset)
        SplitContainer.Panel2.Controls.Add(LblPower)
        SplitContainer.Panel2.Controls.Add(LblI)
        SplitContainer.Panel2.Controls.Add(LblC)
        SplitContainer.Panel2.Controls.Add(TxtA)
        SplitContainer.Panel2.Controls.Add(TxtB)
        SplitContainer.Panel2.Controls.Add(CboN)
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
        SplitContainer.Size = New Size(990, 607)
        SplitContainer.SplitterDistance = 605
        SplitContainer.SplitterWidth = 6
        SplitContainer.TabIndex = 0
        ' 
        ' PicDiagram
        ' 
        PicDiagram.Location = New Point(4, 4)
        PicDiagram.Margin = New Padding(4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(600, 600)
        PicDiagram.TabIndex = 1
        PicDiagram.TabStop = False
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(19, 537)
        BtnDefault.Margin = New Padding(4)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(349, 30)
        BtnDefault.TabIndex = 70
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' BtnShowBasin
        ' 
        BtnShowBasin.Font = New Font("Microsoft Sans Serif", 9F)
        BtnShowBasin.Location = New Point(16, 385)
        BtnShowBasin.Margin = New Padding(4)
        BtnShowBasin.Name = "BtnShowBasin"
        BtnShowBasin.Size = New Size(351, 30)
        BtnShowBasin.TabIndex = 69
        BtnShowBasin.Text = "ShowBasin"
        BtnShowBasin.UseVisualStyleBackColor = True
        ' 
        ' GrpColor
        ' 
        GrpColor.Controls.Add(OptShaded)
        GrpColor.Controls.Add(OptBright)
        GrpColor.Font = New Font("Microsoft Sans Serif", 9F)
        GrpColor.Location = New Point(217, 226)
        GrpColor.Margin = New Padding(4, 2, 4, 2)
        GrpColor.Name = "GrpColor"
        GrpColor.Padding = New Padding(4, 2, 4, 2)
        GrpColor.Size = New Size(150, 84)
        GrpColor.TabIndex = 68
        GrpColor.TabStop = False
        GrpColor.Text = "Color"
        ' 
        ' OptShaded
        ' 
        OptShaded.AutoSize = True
        OptShaded.Checked = True
        OptShaded.Location = New Point(20, 49)
        OptShaded.Margin = New Padding(4, 2, 4, 2)
        OptShaded.Name = "OptShaded"
        OptShaded.Size = New Size(68, 19)
        OptShaded.TabIndex = 1
        OptShaded.TabStop = True
        OptShaded.Text = "Shaded"
        OptShaded.UseVisualStyleBackColor = True
        ' 
        ' OptBright
        ' 
        OptBright.AutoSize = True
        OptBright.Location = New Point(20, 26)
        OptBright.Margin = New Padding(4, 2, 4, 2)
        OptBright.Name = "OptBright"
        OptBright.Size = New Size(57, 19)
        OptBright.TabIndex = 0
        OptBright.Text = "Bright"
        OptBright.UseVisualStyleBackColor = True
        ' 
        ' GrpMixing
        ' 
        GrpMixing.Controls.Add(OptRotate)
        GrpMixing.Controls.Add(OptConjugate)
        GrpMixing.Controls.Add(OptNone)
        GrpMixing.Font = New Font("Microsoft Sans Serif", 9F)
        GrpMixing.Location = New Point(4, 226)
        GrpMixing.Margin = New Padding(4, 2, 4, 2)
        GrpMixing.Name = "GrpMixing"
        GrpMixing.Padding = New Padding(4, 2, 4, 2)
        GrpMixing.Size = New Size(201, 84)
        GrpMixing.TabIndex = 67
        GrpMixing.TabStop = False
        GrpMixing.Text = "Mixing"
        ' 
        ' OptRotate
        ' 
        OptRotate.AutoSize = True
        OptRotate.Location = New Point(126, 26)
        OptRotate.Margin = New Padding(4, 2, 4, 2)
        OptRotate.Name = "OptRotate"
        OptRotate.Size = New Size(61, 19)
        OptRotate.TabIndex = 2
        OptRotate.Text = "Rotate"
        OptRotate.UseVisualStyleBackColor = True
        ' 
        ' OptConjugate
        ' 
        OptConjugate.AutoSize = True
        OptConjugate.Location = New Point(15, 49)
        OptConjugate.Margin = New Padding(4, 2, 4, 2)
        OptConjugate.Name = "OptConjugate"
        OptConjugate.Size = New Size(81, 19)
        OptConjugate.TabIndex = 1
        OptConjugate.Text = "Conjugate"
        OptConjugate.UseVisualStyleBackColor = True
        ' 
        ' OptNone
        ' 
        OptNone.AutoSize = True
        OptNone.Checked = True
        OptNone.Location = New Point(15, 26)
        OptNone.Margin = New Padding(4, 2, 4, 2)
        OptNone.Name = "OptNone"
        OptNone.Size = New Size(55, 19)
        OptNone.TabIndex = 0
        OptNone.TabStop = True
        OptNone.Text = "None"
        OptNone.UseVisualStyleBackColor = True
        ' 
        ' ChkProtocol
        ' 
        ChkProtocol.AutoSize = True
        ChkProtocol.Font = New Font("Microsoft Sans Serif", 9F)
        ChkProtocol.Location = New Point(287, 415)
        ChkProtocol.Margin = New Padding(4, 2, 4, 2)
        ChkProtocol.Name = "ChkProtocol"
        ChkProtocol.Size = New Size(71, 19)
        ChkProtocol.TabIndex = 66
        ChkProtocol.Text = "Protocol"
        ChkProtocol.UseVisualStyleBackColor = True
        ' 
        ' TxtTime
        ' 
        TxtTime.Enabled = False
        TxtTime.Font = New Font("Microsoft Sans Serif", 9F)
        TxtTime.Location = New Point(228, 320)
        TxtTime.Margin = New Padding(4, 2, 4, 2)
        TxtTime.Name = "TxtTime"
        TxtTime.Size = New Size(139, 21)
        TxtTime.TabIndex = 65
        ' 
        ' TxtSteps
        ' 
        TxtSteps.Enabled = False
        TxtSteps.Font = New Font("Microsoft Sans Serif", 9F)
        TxtSteps.Location = New Point(53, 320)
        TxtSteps.Margin = New Padding(4, 2, 4, 2)
        TxtSteps.Name = "TxtSteps"
        TxtSteps.Size = New Size(124, 21)
        TxtSteps.TabIndex = 64
        ' 
        ' LblTime
        ' 
        LblTime.AutoSize = True
        LblTime.Font = New Font("Microsoft Sans Serif", 9F)
        LblTime.Location = New Point(185, 323)
        LblTime.Margin = New Padding(4, 0, 4, 0)
        LblTime.Name = "LblTime"
        LblTime.Size = New Size(35, 15)
        LblTime.TabIndex = 63
        LblTime.Text = "Time"
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblSteps.Location = New Point(7, 323)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(38, 15)
        LblSteps.TabIndex = 62
        LblSteps.Text = "Steps"
        ' 
        ' LblProtocol
        ' 
        LblProtocol.AutoSize = True
        LblProtocol.Font = New Font("Microsoft Sans Serif", 9F)
        LblProtocol.Location = New Point(16, 419)
        LblProtocol.Margin = New Padding(4, 0, 4, 0)
        LblProtocol.Name = "LblProtocol"
        LblProtocol.Size = New Size(52, 15)
        LblProtocol.TabIndex = 61
        LblProtocol.Text = "Protocol"
        ' 
        ' LstProtocol
        ' 
        LstProtocol.Font = New Font("Microsoft Sans Serif", 9F)
        LstProtocol.FormattingEnabled = True
        LstProtocol.HorizontalScrollbar = True
        LstProtocol.ItemHeight = 15
        LstProtocol.Location = New Point(18, 438)
        LstProtocol.Margin = New Padding(4)
        LstProtocol.Name = "LstProtocol"
        LstProtocol.Size = New Size(349, 94)
        LstProtocol.TabIndex = 60
        ' 
        ' BtnStop
        ' 
        BtnStop.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStop.Location = New Point(197, 347)
        BtnStop.Margin = New Padding(4)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(170, 30)
        BtnStop.TabIndex = 59
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStart.Location = New Point(16, 347)
        BtnStart.Margin = New Padding(4)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(170, 30)
        BtnStart.TabIndex = 57
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(18, 573)
        BtnReset.Margin = New Padding(4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(349, 30)
        BtnReset.TabIndex = 58
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' LblPower
        ' 
        LblPower.AutoSize = True
        LblPower.Font = New Font("Microsoft Sans Serif", 9F)
        LblPower.Location = New Point(287, 7)
        LblPower.Margin = New Padding(4, 0, 4, 0)
        LblPower.Name = "LblPower"
        LblPower.Size = New Size(24, 15)
        LblPower.TabIndex = 56
        LblPower.Text = "n ="
        ' 
        ' LblI
        ' 
        LblI.AutoSize = True
        LblI.Font = New Font("Microsoft Sans Serif", 9F)
        LblI.Location = New Point(185, 37)
        LblI.Margin = New Padding(4, 0, 4, 0)
        LblI.Name = "LblI"
        LblI.Size = New Size(20, 15)
        LblI.TabIndex = 55
        LblI.Text = "+ i"
        ' 
        ' LblC
        ' 
        LblC.AutoSize = True
        LblC.Font = New Font("Microsoft Sans Serif", 9F)
        LblC.Location = New Point(16, 37)
        LblC.Margin = New Padding(4, 0, 4, 0)
        LblC.Name = "LblC"
        LblC.Size = New Size(23, 15)
        LblC.TabIndex = 54
        LblC.Text = "c ="
        ' 
        ' TxtA
        ' 
        TxtA.Font = New Font("Microsoft Sans Serif", 9F)
        TxtA.Location = New Point(53, 34)
        TxtA.Margin = New Padding(4, 2, 4, 2)
        TxtA.Name = "TxtA"
        TxtA.Size = New Size(124, 21)
        TxtA.TabIndex = 53
        TxtA.Text = "0"
        ' 
        ' TxtB
        ' 
        TxtB.Font = New Font("Microsoft Sans Serif", 9F)
        TxtB.Location = New Point(217, 34)
        TxtB.Margin = New Padding(4, 2, 4, 2)
        TxtB.Name = "TxtB"
        TxtB.Size = New Size(150, 21)
        TxtB.TabIndex = 52
        TxtB.Text = "1"
        ' 
        ' CboN
        ' 
        CboN.Font = New Font("Microsoft Sans Serif", 9F)
        CboN.FormattingEnabled = True
        CboN.Items.AddRange(New Object() {"2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        CboN.Location = New Point(319, 4)
        CboN.Margin = New Padding(4, 2, 4, 2)
        CboN.Name = "CboN"
        CboN.Size = New Size(48, 23)
        CboN.TabIndex = 51
        ' 
        ' LblDeltaY
        ' 
        LblDeltaY.AutoSize = True
        LblDeltaY.Font = New Font("Microsoft Sans Serif", 9F)
        LblDeltaY.Location = New Point(10, 200)
        LblDeltaY.Margin = New Padding(4, 0, 4, 0)
        LblDeltaY.Name = "LblDeltaY"
        LblDeltaY.Size = New Size(43, 15)
        LblDeltaY.TabIndex = 50
        LblDeltaY.Text = "DeltaY"
        ' 
        ' TxtYMax
        ' 
        TxtYMax.Font = New Font("Microsoft Sans Serif", 9F)
        TxtYMax.Location = New Point(53, 172)
        TxtYMax.Margin = New Padding(4)
        TxtYMax.Name = "TxtYMax"
        TxtYMax.Size = New Size(314, 21)
        TxtYMax.TabIndex = 49
        ' 
        ' LblYMax
        ' 
        LblYMax.AutoSize = True
        LblYMax.Font = New Font("Microsoft Sans Serif", 9F)
        LblYMax.Location = New Point(10, 175)
        LblYMax.Margin = New Padding(4, 0, 4, 0)
        LblYMax.Name = "LblYMax"
        LblYMax.Size = New Size(38, 15)
        LblYMax.TabIndex = 48
        LblYMax.Text = "YMax"
        ' 
        ' TxtYMin
        ' 
        TxtYMin.Font = New Font("Microsoft Sans Serif", 9F)
        TxtYMin.Location = New Point(53, 143)
        TxtYMin.Margin = New Padding(4)
        TxtYMin.Name = "TxtYMin"
        TxtYMin.Size = New Size(314, 21)
        TxtYMin.TabIndex = 47
        ' 
        ' LblYMin
        ' 
        LblYMin.AutoSize = True
        LblYMin.Font = New Font("Microsoft Sans Serif", 9F)
        LblYMin.Location = New Point(9, 149)
        LblYMin.Margin = New Padding(4, 0, 4, 0)
        LblYMin.Name = "LblYMin"
        LblYMin.Size = New Size(35, 15)
        LblYMin.TabIndex = 46
        LblYMin.Text = "YMin"
        ' 
        ' LblDeltaX
        ' 
        LblDeltaX.AutoSize = True
        LblDeltaX.Font = New Font("Microsoft Sans Serif", 9F)
        LblDeltaX.Location = New Point(9, 117)
        LblDeltaX.Margin = New Padding(4, 0, 4, 0)
        LblDeltaX.Name = "LblDeltaX"
        LblDeltaX.Size = New Size(44, 15)
        LblDeltaX.TabIndex = 45
        LblDeltaX.Text = "DeltaX"
        ' 
        ' TxtXMax
        ' 
        TxtXMax.Font = New Font("Microsoft Sans Serif", 9F)
        TxtXMax.Location = New Point(54, 90)
        TxtXMax.Margin = New Padding(4)
        TxtXMax.Name = "TxtXMax"
        TxtXMax.Size = New Size(313, 21)
        TxtXMax.TabIndex = 44
        ' 
        ' LblXMax
        ' 
        LblXMax.AutoSize = True
        LblXMax.Font = New Font("Microsoft Sans Serif", 9F)
        LblXMax.Location = New Point(10, 93)
        LblXMax.Margin = New Padding(4, 0, 4, 0)
        LblXMax.Name = "LblXMax"
        LblXMax.Size = New Size(39, 15)
        LblXMax.TabIndex = 43
        LblXMax.Text = "XMax"
        ' 
        ' TxtXMin
        ' 
        TxtXMin.Font = New Font("Microsoft Sans Serif", 9F)
        TxtXMin.Location = New Point(53, 61)
        TxtXMin.Margin = New Padding(4)
        TxtXMin.Name = "TxtXMin"
        TxtXMin.Size = New Size(314, 21)
        TxtXMin.TabIndex = 42
        ' 
        ' LblXMin
        ' 
        LblXMin.AutoSize = True
        LblXMin.Font = New Font("Microsoft Sans Serif", 9F)
        LblXMin.Location = New Point(10, 64)
        LblXMin.Margin = New Padding(4, 0, 4, 0)
        LblXMin.Name = "LblXMin"
        LblXMin.Size = New Size(36, 15)
        LblXMin.TabIndex = 41
        LblXMin.Text = "XMin"
        ' 
        ' CboFunction
        ' 
        CboFunction.Font = New Font("Microsoft Sans Serif", 9F)
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"z^3-1", "z^4-1"})
        CboFunction.Location = New Point(16, 4)
        CboFunction.Margin = New Padding(4)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(263, 23)
        CboFunction.TabIndex = 40
        ' 
        ' FrmNewtonIteration
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(990, 607)
        Controls.Add(SplitContainer)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "FrmNewtonIteration"
        StartPosition = FormStartPosition.WindowsDefaultBounds
        Text = "NewtonIteration"
        WindowState = FormWindowState.Maximized
        SplitContainer.Panel1.ResumeLayout(False)
        SplitContainer.Panel2.ResumeLayout(False)
        SplitContainer.Panel2.PerformLayout()
        CType(SplitContainer, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer.ResumeLayout(False)
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        GrpColor.ResumeLayout(False)
        GrpColor.PerformLayout()
        GrpMixing.ResumeLayout(False)
        GrpMixing.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer As SplitContainer
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents LblPower As Label
    Friend WithEvents LblI As Label
    Friend WithEvents LblC As Label
    Friend WithEvents TxtA As TextBox
    Friend WithEvents TxtB As TextBox
    Friend WithEvents CboN As ComboBox
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
    Friend WithEvents BtnDefault As Button
    Friend WithEvents BtnShowBasin As Button
    Friend WithEvents GrpColor As GroupBox
    Friend WithEvents OptShaded As RadioButton
    Friend WithEvents OptBright As RadioButton
    Friend WithEvents GrpMixing As GroupBox
    Friend WithEvents OptRotate As RadioButton
    Friend WithEvents OptConjugate As RadioButton
    Friend WithEvents OptNone As RadioButton
    Friend WithEvents ChkProtocol As CheckBox
    Friend WithEvents TxtTime As TextBox
    Friend WithEvents TxtSteps As TextBox
    Friend WithEvents LblTime As Label
    Friend WithEvents LblSteps As Label
    Friend WithEvents LblProtocol As Label
    Friend WithEvents LstProtocol As ListBox
    Friend WithEvents BtnStop As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents BtnReset As Button
End Class
