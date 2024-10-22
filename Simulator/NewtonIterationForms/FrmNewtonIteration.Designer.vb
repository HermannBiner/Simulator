<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmNewtonIteration
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNewtonIteration))
        PicDiagram = New PictureBox()
        CboFunction = New ComboBox()
        LblXMin = New Label()
        TxtXMin = New TextBox()
        TxtXMax = New TextBox()
        LblXMax = New Label()
        LblDeltaX = New Label()
        LblDeltaY = New Label()
        TxtYMax = New TextBox()
        LblYMax = New Label()
        TxtYMin = New TextBox()
        LblYMin = New Label()
        BtnReset = New Button()
        BtnStop = New Button()
        LstProtocol = New ListBox()
        LblProtocol = New Label()
        CboN = New ComboBox()
        TxtB = New TextBox()
        TxtA = New TextBox()
        LblC = New Label()
        LblI = New Label()
        ChkProtocol = New CheckBox()
        LblPower = New Label()
        GrpMixing = New GroupBox()
        OptRotate = New RadioButton()
        OptConjugate = New RadioButton()
        OptNone = New RadioButton()
        GrpColor = New GroupBox()
        OptShaded = New RadioButton()
        OptBright = New RadioButton()
        BtnStart = New Button()
        LblSteps = New Label()
        LblTime = New Label()
        TxtSteps = New TextBox()
        TxtTime = New TextBox()
        BtnShowBasin = New Button()
        BtnDefault = New Button()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        GrpMixing.SuspendLayout()
        GrpColor.SuspendLayout()
        SuspendLayout()
        ' 
        ' PicDiagram
        ' 
        PicDiagram.Location = New Point(2, 3)
        PicDiagram.Margin = New Padding(4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(600, 600)
        PicDiagram.TabIndex = 0
        PicDiagram.TabStop = False
        ' 
        ' CboFunction
        ' 
        CboFunction.Font = New Font("Microsoft Sans Serif", 9F)
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"z^3-1", "z^4-1"})
        CboFunction.Location = New Point(625, 3)
        CboFunction.Margin = New Padding(4)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(263, 23)
        CboFunction.TabIndex = 1
        ' 
        ' LblXMin
        ' 
        LblXMin.AutoSize = True
        LblXMin.Font = New Font("Microsoft Sans Serif", 9F)
        LblXMin.Location = New Point(619, 63)
        LblXMin.Margin = New Padding(4, 0, 4, 0)
        LblXMin.Name = "LblXMin"
        LblXMin.Size = New Size(36, 15)
        LblXMin.TabIndex = 3
        LblXMin.Text = "XMin"
        ' 
        ' TxtXMin
        ' 
        TxtXMin.Font = New Font("Microsoft Sans Serif", 9F)
        TxtXMin.Location = New Point(662, 60)
        TxtXMin.Margin = New Padding(4)
        TxtXMin.Name = "TxtXMin"
        TxtXMin.Size = New Size(314, 21)
        TxtXMin.TabIndex = 4
        ' 
        ' TxtXMax
        ' 
        TxtXMax.Font = New Font("Microsoft Sans Serif", 9F)
        TxtXMax.Location = New Point(663, 89)
        TxtXMax.Margin = New Padding(4)
        TxtXMax.Name = "TxtXMax"
        TxtXMax.Size = New Size(313, 21)
        TxtXMax.TabIndex = 6
        ' 
        ' LblXMax
        ' 
        LblXMax.AutoSize = True
        LblXMax.Font = New Font("Microsoft Sans Serif", 9F)
        LblXMax.Location = New Point(619, 92)
        LblXMax.Margin = New Padding(4, 0, 4, 0)
        LblXMax.Name = "LblXMax"
        LblXMax.Size = New Size(39, 15)
        LblXMax.TabIndex = 5
        LblXMax.Text = "XMax"
        ' 
        ' LblDeltaX
        ' 
        LblDeltaX.AutoSize = True
        LblDeltaX.Font = New Font("Microsoft Sans Serif", 9F)
        LblDeltaX.Location = New Point(618, 116)
        LblDeltaX.Margin = New Padding(4, 0, 4, 0)
        LblDeltaX.Name = "LblDeltaX"
        LblDeltaX.Size = New Size(44, 15)
        LblDeltaX.TabIndex = 7
        LblDeltaX.Text = "DeltaX"
        ' 
        ' LblDeltaY
        ' 
        LblDeltaY.AutoSize = True
        LblDeltaY.Font = New Font("Microsoft Sans Serif", 9F)
        LblDeltaY.Location = New Point(619, 199)
        LblDeltaY.Margin = New Padding(4, 0, 4, 0)
        LblDeltaY.Name = "LblDeltaY"
        LblDeltaY.Size = New Size(43, 15)
        LblDeltaY.TabIndex = 13
        LblDeltaY.Text = "DeltaY"
        ' 
        ' TxtYMax
        ' 
        TxtYMax.Font = New Font("Microsoft Sans Serif", 9F)
        TxtYMax.Location = New Point(662, 171)
        TxtYMax.Margin = New Padding(4)
        TxtYMax.Name = "TxtYMax"
        TxtYMax.Size = New Size(314, 21)
        TxtYMax.TabIndex = 12
        ' 
        ' LblYMax
        ' 
        LblYMax.AutoSize = True
        LblYMax.Font = New Font("Microsoft Sans Serif", 9F)
        LblYMax.Location = New Point(619, 174)
        LblYMax.Margin = New Padding(4, 0, 4, 0)
        LblYMax.Name = "LblYMax"
        LblYMax.Size = New Size(38, 15)
        LblYMax.TabIndex = 11
        LblYMax.Text = "YMax"
        ' 
        ' TxtYMin
        ' 
        TxtYMin.Font = New Font("Microsoft Sans Serif", 9F)
        TxtYMin.Location = New Point(662, 142)
        TxtYMin.Margin = New Padding(4)
        TxtYMin.Name = "TxtYMin"
        TxtYMin.Size = New Size(314, 21)
        TxtYMin.TabIndex = 10
        ' 
        ' LblYMin
        ' 
        LblYMin.AutoSize = True
        LblYMin.Font = New Font("Microsoft Sans Serif", 9F)
        LblYMin.Location = New Point(618, 148)
        LblYMin.Margin = New Padding(4, 0, 4, 0)
        LblYMin.Name = "LblYMin"
        LblYMin.Size = New Size(35, 15)
        LblYMin.TabIndex = 9
        LblYMin.Text = "YMin"
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(627, 570)
        BtnReset.Margin = New Padding(4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(349, 30)
        BtnReset.TabIndex = 21
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStop
        ' 
        BtnStop.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStop.Location = New Point(806, 344)
        BtnStop.Margin = New Padding(4)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(170, 30)
        BtnStop.TabIndex = 24
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' LstProtocol
        ' 
        LstProtocol.Font = New Font("Microsoft Sans Serif", 9F)
        LstProtocol.FormattingEnabled = True
        LstProtocol.HorizontalScrollbar = True
        LstProtocol.ItemHeight = 15
        LstProtocol.Location = New Point(627, 435)
        LstProtocol.Margin = New Padding(4)
        LstProtocol.Name = "LstProtocol"
        LstProtocol.Size = New Size(349, 94)
        LstProtocol.TabIndex = 25
        ' 
        ' LblProtocol
        ' 
        LblProtocol.AutoSize = True
        LblProtocol.Font = New Font("Microsoft Sans Serif", 9F)
        LblProtocol.Location = New Point(625, 416)
        LblProtocol.Margin = New Padding(4, 0, 4, 0)
        LblProtocol.Name = "LblProtocol"
        LblProtocol.Size = New Size(52, 15)
        LblProtocol.TabIndex = 26
        LblProtocol.Text = "Protocol"
        ' 
        ' CboN
        ' 
        CboN.Font = New Font("Microsoft Sans Serif", 9F)
        CboN.FormattingEnabled = True
        CboN.Items.AddRange(New Object() {"2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        CboN.Location = New Point(928, 3)
        CboN.Margin = New Padding(4, 2, 4, 2)
        CboN.Name = "CboN"
        CboN.Size = New Size(48, 23)
        CboN.TabIndex = 27
        ' 
        ' TxtB
        ' 
        TxtB.Font = New Font("Microsoft Sans Serif", 9F)
        TxtB.Location = New Point(826, 33)
        TxtB.Margin = New Padding(4, 2, 4, 2)
        TxtB.Name = "TxtB"
        TxtB.Size = New Size(150, 21)
        TxtB.TabIndex = 28
        TxtB.Text = "1"
        ' 
        ' TxtA
        ' 
        TxtA.Font = New Font("Microsoft Sans Serif", 9F)
        TxtA.Location = New Point(662, 33)
        TxtA.Margin = New Padding(4, 2, 4, 2)
        TxtA.Name = "TxtA"
        TxtA.Size = New Size(124, 21)
        TxtA.TabIndex = 30
        TxtA.Text = "0"
        ' 
        ' LblC
        ' 
        LblC.AutoSize = True
        LblC.Font = New Font("Microsoft Sans Serif", 9F)
        LblC.Location = New Point(625, 36)
        LblC.Margin = New Padding(4, 0, 4, 0)
        LblC.Name = "LblC"
        LblC.Size = New Size(23, 15)
        LblC.TabIndex = 31
        LblC.Text = "c ="
        ' 
        ' LblI
        ' 
        LblI.AutoSize = True
        LblI.Font = New Font("Microsoft Sans Serif", 9F)
        LblI.Location = New Point(794, 36)
        LblI.Margin = New Padding(4, 0, 4, 0)
        LblI.Name = "LblI"
        LblI.Size = New Size(20, 15)
        LblI.TabIndex = 33
        LblI.Text = "+ i"
        ' 
        ' ChkProtocol
        ' 
        ChkProtocol.AutoSize = True
        ChkProtocol.Font = New Font("Microsoft Sans Serif", 9F)
        ChkProtocol.Location = New Point(896, 412)
        ChkProtocol.Margin = New Padding(4, 2, 4, 2)
        ChkProtocol.Name = "ChkProtocol"
        ChkProtocol.Size = New Size(71, 19)
        ChkProtocol.TabIndex = 38
        ChkProtocol.Text = "Protocol"
        ChkProtocol.UseVisualStyleBackColor = True
        ' 
        ' LblPower
        ' 
        LblPower.AutoSize = True
        LblPower.Font = New Font("Microsoft Sans Serif", 9F)
        LblPower.Location = New Point(896, 6)
        LblPower.Margin = New Padding(4, 0, 4, 0)
        LblPower.Name = "LblPower"
        LblPower.Size = New Size(24, 15)
        LblPower.TabIndex = 39
        LblPower.Text = "n ="
        ' 
        ' GrpMixing
        ' 
        GrpMixing.Controls.Add(OptRotate)
        GrpMixing.Controls.Add(OptConjugate)
        GrpMixing.Controls.Add(OptNone)
        GrpMixing.Font = New Font("Microsoft Sans Serif", 9F)
        GrpMixing.Location = New Point(613, 223)
        GrpMixing.Margin = New Padding(4, 2, 4, 2)
        GrpMixing.Name = "GrpMixing"
        GrpMixing.Padding = New Padding(4, 2, 4, 2)
        GrpMixing.Size = New Size(201, 84)
        GrpMixing.TabIndex = 40
        GrpMixing.TabStop = False
        GrpMixing.Text = "Mixing"
        ' 
        ' OptRotate
        ' 
        OptRotate.AutoSize = True
        OptRotate.Location = New Point(125, 27)
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
        OptConjugate.Location = New Point(14, 50)
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
        OptNone.Location = New Point(14, 27)
        OptNone.Margin = New Padding(4, 2, 4, 2)
        OptNone.Name = "OptNone"
        OptNone.Size = New Size(55, 19)
        OptNone.TabIndex = 0
        OptNone.TabStop = True
        OptNone.Text = "None"
        OptNone.UseVisualStyleBackColor = True
        ' 
        ' GrpColor
        ' 
        GrpColor.Controls.Add(OptShaded)
        GrpColor.Controls.Add(OptBright)
        GrpColor.Font = New Font("Microsoft Sans Serif", 9F)
        GrpColor.Location = New Point(826, 223)
        GrpColor.Margin = New Padding(4, 2, 4, 2)
        GrpColor.Name = "GrpColor"
        GrpColor.Padding = New Padding(4, 2, 4, 2)
        GrpColor.Size = New Size(150, 84)
        GrpColor.TabIndex = 41
        GrpColor.TabStop = False
        GrpColor.Text = "Color"
        ' 
        ' OptShaded
        ' 
        OptShaded.AutoSize = True
        OptShaded.Checked = True
        OptShaded.Location = New Point(19, 50)
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
        OptBright.Location = New Point(19, 27)
        OptBright.Margin = New Padding(4, 2, 4, 2)
        OptBright.Name = "OptBright"
        OptBright.Size = New Size(57, 19)
        OptBright.TabIndex = 0
        OptBright.Text = "Bright"
        OptBright.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStart.Location = New Point(625, 344)
        BtnStart.Margin = New Padding(4)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(170, 30)
        BtnStart.TabIndex = 20
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblSteps.Location = New Point(616, 320)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(38, 15)
        LblSteps.TabIndex = 34
        LblSteps.Text = "Steps"
        ' 
        ' LblTime
        ' 
        LblTime.AutoSize = True
        LblTime.Font = New Font("Microsoft Sans Serif", 9F)
        LblTime.Location = New Point(794, 320)
        LblTime.Margin = New Padding(4, 0, 4, 0)
        LblTime.Name = "LblTime"
        LblTime.Size = New Size(35, 15)
        LblTime.TabIndex = 35
        LblTime.Text = "Time"
        ' 
        ' TxtSteps
        ' 
        TxtSteps.Enabled = False
        TxtSteps.Font = New Font("Microsoft Sans Serif", 9F)
        TxtSteps.Location = New Point(662, 317)
        TxtSteps.Margin = New Padding(4, 2, 4, 2)
        TxtSteps.Name = "TxtSteps"
        TxtSteps.Size = New Size(124, 21)
        TxtSteps.TabIndex = 36
        ' 
        ' TxtTime
        ' 
        TxtTime.Enabled = False
        TxtTime.Font = New Font("Microsoft Sans Serif", 9F)
        TxtTime.Location = New Point(837, 317)
        TxtTime.Margin = New Padding(4, 2, 4, 2)
        TxtTime.Name = "TxtTime"
        TxtTime.Size = New Size(139, 21)
        TxtTime.TabIndex = 37
        ' 
        ' BtnShowBasin
        ' 
        BtnShowBasin.Font = New Font("Microsoft Sans Serif", 9F)
        BtnShowBasin.Location = New Point(625, 382)
        BtnShowBasin.Margin = New Padding(4)
        BtnShowBasin.Name = "BtnShowBasin"
        BtnShowBasin.Size = New Size(351, 30)
        BtnShowBasin.TabIndex = 42
        BtnShowBasin.Text = "ShowBasin"
        BtnShowBasin.UseVisualStyleBackColor = True
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(628, 534)
        BtnDefault.Margin = New Padding(4)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(349, 30)
        BtnDefault.TabIndex = 43
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' FrmNewtonIteration
        ' 
        AutoScaleDimensions = New SizeF(9F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(990, 607)
        Controls.Add(BtnDefault)
        Controls.Add(BtnShowBasin)
        Controls.Add(GrpColor)
        Controls.Add(GrpMixing)
        Controls.Add(LblPower)
        Controls.Add(ChkProtocol)
        Controls.Add(TxtTime)
        Controls.Add(TxtSteps)
        Controls.Add(LblTime)
        Controls.Add(LblSteps)
        Controls.Add(LblI)
        Controls.Add(LblC)
        Controls.Add(TxtA)
        Controls.Add(TxtB)
        Controls.Add(CboN)
        Controls.Add(LblProtocol)
        Controls.Add(LstProtocol)
        Controls.Add(BtnStop)
        Controls.Add(BtnStart)
        Controls.Add(BtnReset)
        Controls.Add(LblDeltaY)
        Controls.Add(TxtYMax)
        Controls.Add(LblYMax)
        Controls.Add(TxtYMin)
        Controls.Add(LblYMin)
        Controls.Add(LblDeltaX)
        Controls.Add(TxtXMax)
        Controls.Add(LblXMax)
        Controls.Add(TxtXMin)
        Controls.Add(LblXMin)
        Controls.Add(CboFunction)
        Controls.Add(PicDiagram)
        Font = New Font("Microsoft Sans Serif", 11.1428576F)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4)
        Name = "FrmNewtonIteration"
        Text = "NewtonIteration"
        WindowState = FormWindowState.Maximized
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        GrpMixing.ResumeLayout(False)
        GrpMixing.PerformLayout()
        GrpColor.ResumeLayout(False)
        GrpColor.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents CboFunction As ComboBox
    Friend WithEvents LblXMin As Label
    Friend WithEvents TxtXMin As TextBox
    Friend WithEvents TxtXMax As TextBox
    Friend WithEvents LblXMax As Label
    Friend WithEvents TxtDeltaX As TextBox
    Friend WithEvents LblDeltaX As Label
    Friend WithEvents TxtDeltaY As TextBox
    Friend WithEvents LblDeltaY As Label
    Friend WithEvents TxtYMax As TextBox
    Friend WithEvents LblYMax As Label
    Friend WithEvents TxtYMin As TextBox
    Friend WithEvents LblYMin As Label
    Friend WithEvents BtnStart As Button
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStop As Button
    Friend WithEvents LstProtocol As ListBox
    Friend WithEvents LblProtocol As Label
    Friend WithEvents CboN As ComboBox
    Friend WithEvents TxtB As TextBox
    Friend WithEvents TxtA As TextBox
    Friend WithEvents LblC As Label
    Friend WithEvents LblI As Label
    Friend WithEvents LblSteps As Label
    Friend WithEvents LblTime As Label
    Friend WithEvents TxtSteps As TextBox
    Friend WithEvents TxtTime As TextBox
    Friend WithEvents ChkProtocol As CheckBox
    Friend WithEvents LblPower As Label
    Friend WithEvents GrpMixing As GroupBox
    Friend WithEvents OptRotate As RadioButton
    Friend WithEvents OptConjugate As RadioButton
    Friend WithEvents OptNone As RadioButton
    Friend WithEvents GrpColor As GroupBox
    Friend WithEvents OptShaded As RadioButton
    Friend WithEvents OptBright As RadioButton
    Friend WithEvents BtnShowBasin As Button
    Friend WithEvents BtnDefault As Button
End Class
