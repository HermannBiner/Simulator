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
        PicDiagram.Location = New Point(1, 6)
        PicDiagram.Margin = New Padding(2)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(800, 800)
        PicDiagram.TabIndex = 0
        PicDiagram.TabStop = False
        ' 
        ' CboFunction
        ' 
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"z^3-1", "z^4-1"})
        CboFunction.Location = New Point(818, 6)
        CboFunction.Margin = New Padding(2)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(247, 23)
        CboFunction.TabIndex = 1
        ' 
        ' LblXMin
        ' 
        LblXMin.AutoSize = True
        LblXMin.Location = New Point(815, 64)
        LblXMin.Margin = New Padding(2, 0, 2, 0)
        LblXMin.Name = "LblXMin"
        LblXMin.Size = New Size(35, 15)
        LblXMin.TabIndex = 3
        LblXMin.Text = "XMin"
        ' 
        ' TxtXMin
        ' 
        TxtXMin.Location = New Point(869, 61)
        TxtXMin.Margin = New Padding(2)
        TxtXMin.Name = "TxtXMin"
        TxtXMin.Size = New Size(268, 23)
        TxtXMin.TabIndex = 4
        ' 
        ' TxtXMax
        ' 
        TxtXMax.Location = New Point(869, 90)
        TxtXMax.Margin = New Padding(2)
        TxtXMax.Name = "TxtXMax"
        TxtXMax.Size = New Size(268, 23)
        TxtXMax.TabIndex = 6
        ' 
        ' LblXMax
        ' 
        LblXMax.AutoSize = True
        LblXMax.Location = New Point(815, 93)
        LblXMax.Margin = New Padding(2, 0, 2, 0)
        LblXMax.Name = "LblXMax"
        LblXMax.Size = New Size(37, 15)
        LblXMax.TabIndex = 5
        LblXMax.Text = "XMax"
        ' 
        ' LblDeltaX
        ' 
        LblDeltaX.AutoSize = True
        LblDeltaX.Location = New Point(815, 124)
        LblDeltaX.Margin = New Padding(2, 0, 2, 0)
        LblDeltaX.Name = "LblDeltaX"
        LblDeltaX.Size = New Size(41, 15)
        LblDeltaX.TabIndex = 7
        LblDeltaX.Text = "DeltaX"
        ' 
        ' LblDeltaY
        ' 
        LblDeltaY.AutoSize = True
        LblDeltaY.Location = New Point(815, 212)
        LblDeltaY.Margin = New Padding(2, 0, 2, 0)
        LblDeltaY.Name = "LblDeltaY"
        LblDeltaY.Size = New Size(41, 15)
        LblDeltaY.TabIndex = 13
        LblDeltaY.Text = "DeltaY"
        ' 
        ' TxtYMax
        ' 
        TxtYMax.Location = New Point(869, 178)
        TxtYMax.Margin = New Padding(2)
        TxtYMax.Name = "TxtYMax"
        TxtYMax.Size = New Size(268, 23)
        TxtYMax.TabIndex = 12
        ' 
        ' LblYMax
        ' 
        LblYMax.AutoSize = True
        LblYMax.Location = New Point(815, 182)
        LblYMax.Margin = New Padding(2, 0, 2, 0)
        LblYMax.Name = "LblYMax"
        LblYMax.Size = New Size(37, 15)
        LblYMax.TabIndex = 11
        LblYMax.Text = "YMax"
        ' 
        ' TxtYMin
        ' 
        TxtYMin.Location = New Point(869, 150)
        TxtYMin.Margin = New Padding(2)
        TxtYMin.Name = "TxtYMin"
        TxtYMin.Size = New Size(268, 23)
        TxtYMin.TabIndex = 10
        ' 
        ' LblYMin
        ' 
        LblYMin.AutoSize = True
        LblYMin.Location = New Point(815, 153)
        LblYMin.Margin = New Padding(2, 0, 2, 0)
        LblYMin.Name = "LblYMin"
        LblYMin.Size = New Size(35, 15)
        LblYMin.TabIndex = 9
        LblYMin.Text = "YMin"
        ' 
        ' BtnReset
        ' 
        BtnReset.Location = New Point(813, 772)
        BtnReset.Margin = New Padding(2)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(320, 34)
        BtnReset.TabIndex = 21
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStop
        ' 
        BtnStop.Location = New Point(815, 421)
        BtnStop.Margin = New Padding(2)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(320, 34)
        BtnStop.TabIndex = 24
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' LstProtocol
        ' 
        LstProtocol.FormattingEnabled = True
        LstProtocol.HorizontalScrollbar = True
        LstProtocol.ItemHeight = 15
        LstProtocol.Location = New Point(813, 525)
        LstProtocol.Margin = New Padding(2)
        LstProtocol.Name = "LstProtocol"
        LstProtocol.Size = New Size(322, 199)
        LstProtocol.TabIndex = 25
        ' 
        ' LblProtocol
        ' 
        LblProtocol.AutoSize = True
        LblProtocol.Location = New Point(815, 504)
        LblProtocol.Margin = New Padding(2, 0, 2, 0)
        LblProtocol.Name = "LblProtocol"
        LblProtocol.Size = New Size(52, 15)
        LblProtocol.TabIndex = 26
        LblProtocol.Text = "Protocol"
        ' 
        ' CboN
        ' 
        CboN.FormattingEnabled = True
        CboN.Items.AddRange(New Object() {"2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        CboN.Location = New Point(1098, 6)
        CboN.Margin = New Padding(2, 1, 2, 1)
        CboN.Name = "CboN"
        CboN.Size = New Size(39, 23)
        CboN.TabIndex = 27
        ' 
        ' TxtB
        ' 
        TxtB.Location = New Point(969, 35)
        TxtB.Margin = New Padding(2, 1, 2, 1)
        TxtB.Name = "TxtB"
        TxtB.Size = New Size(72, 23)
        TxtB.TabIndex = 28
        TxtB.Text = "1"
        ' 
        ' TxtA
        ' 
        TxtA.Location = New Point(869, 34)
        TxtA.Margin = New Padding(2, 1, 2, 1)
        TxtA.Name = "TxtA"
        TxtA.Size = New Size(72, 23)
        TxtA.TabIndex = 30
        TxtA.Text = "0"
        ' 
        ' LblC
        ' 
        LblC.AutoSize = True
        LblC.Location = New Point(819, 36)
        LblC.Margin = New Padding(2, 0, 2, 0)
        LblC.Name = "LblC"
        LblC.Size = New Size(24, 15)
        LblC.TabIndex = 31
        LblC.Text = "c ="
        ' 
        ' LblI
        ' 
        LblI.AutoSize = True
        LblI.Location = New Point(943, 36)
        LblI.Margin = New Padding(2, 0, 2, 0)
        LblI.Name = "LblI"
        LblI.Size = New Size(21, 15)
        LblI.TabIndex = 33
        LblI.Text = "+ i"
        ' 
        ' ChkProtocol
        ' 
        ChkProtocol.AutoSize = True
        ChkProtocol.Location = New Point(1044, 503)
        ChkProtocol.Margin = New Padding(2, 1, 2, 1)
        ChkProtocol.Name = "ChkProtocol"
        ChkProtocol.Size = New Size(71, 19)
        ChkProtocol.TabIndex = 38
        ChkProtocol.Text = "Protocol"
        ChkProtocol.UseVisualStyleBackColor = True
        ' 
        ' LblPower
        ' 
        LblPower.AutoSize = True
        LblPower.Location = New Point(1067, 7)
        LblPower.Margin = New Padding(2, 0, 2, 0)
        LblPower.Name = "LblPower"
        LblPower.Size = New Size(25, 15)
        LblPower.TabIndex = 39
        LblPower.Text = "n ="
        ' 
        ' GrpMixing
        ' 
        GrpMixing.Controls.Add(OptRotate)
        GrpMixing.Controls.Add(OptConjugate)
        GrpMixing.Controls.Add(OptNone)
        GrpMixing.Location = New Point(819, 240)
        GrpMixing.Margin = New Padding(2, 1, 2, 1)
        GrpMixing.Name = "GrpMixing"
        GrpMixing.Padding = New Padding(2, 1, 2, 1)
        GrpMixing.Size = New Size(169, 99)
        GrpMixing.TabIndex = 40
        GrpMixing.TabStop = False
        GrpMixing.Text = "Mixing"
        ' 
        ' OptRotate
        ' 
        OptRotate.AutoSize = True
        OptRotate.Location = New Point(17, 74)
        OptRotate.Margin = New Padding(2, 1, 2, 1)
        OptRotate.Name = "OptRotate"
        OptRotate.Size = New Size(59, 19)
        OptRotate.TabIndex = 2
        OptRotate.Text = "Rotate"
        OptRotate.UseVisualStyleBackColor = True
        ' 
        ' OptConjugate
        ' 
        OptConjugate.AutoSize = True
        OptConjugate.Location = New Point(18, 48)
        OptConjugate.Margin = New Padding(2, 1, 2, 1)
        OptConjugate.Name = "OptConjugate"
        OptConjugate.Size = New Size(80, 19)
        OptConjugate.TabIndex = 1
        OptConjugate.Text = "Conjugate"
        OptConjugate.UseVisualStyleBackColor = True
        ' 
        ' OptNone
        ' 
        OptNone.AutoSize = True
        OptNone.Checked = True
        OptNone.Location = New Point(18, 22)
        OptNone.Margin = New Padding(2, 1, 2, 1)
        OptNone.Name = "OptNone"
        OptNone.Size = New Size(54, 19)
        OptNone.TabIndex = 0
        OptNone.TabStop = True
        OptNone.Text = "None"
        OptNone.UseVisualStyleBackColor = True
        ' 
        ' GrpColor
        ' 
        GrpColor.Controls.Add(OptShaded)
        GrpColor.Controls.Add(OptBright)
        GrpColor.Location = New Point(991, 240)
        GrpColor.Margin = New Padding(2, 1, 2, 1)
        GrpColor.Name = "GrpColor"
        GrpColor.Padding = New Padding(2, 1, 2, 1)
        GrpColor.Size = New Size(144, 99)
        GrpColor.TabIndex = 41
        GrpColor.TabStop = False
        GrpColor.Text = "Color"
        ' 
        ' OptShaded
        ' 
        OptShaded.AutoSize = True
        OptShaded.Checked = True
        OptShaded.Location = New Point(9, 55)
        OptShaded.Margin = New Padding(2, 1, 2, 1)
        OptShaded.Name = "OptShaded"
        OptShaded.Size = New Size(64, 19)
        OptShaded.TabIndex = 1
        OptShaded.TabStop = True
        OptShaded.Text = "Shaded"
        OptShaded.UseVisualStyleBackColor = True
        ' 
        ' OptBright
        ' 
        OptBright.AutoSize = True
        OptBright.Location = New Point(9, 27)
        OptBright.Margin = New Padding(2, 1, 2, 1)
        OptBright.Name = "OptBright"
        OptBright.Size = New Size(57, 19)
        OptBright.TabIndex = 0
        OptBright.Text = "Bright"
        OptBright.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Location = New Point(815, 383)
        BtnStart.Margin = New Padding(2)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(320, 34)
        BtnStart.TabIndex = 20
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Location = New Point(816, 356)
        LblSteps.Margin = New Padding(2, 0, 2, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(35, 15)
        LblSteps.TabIndex = 34
        LblSteps.Text = "Steps"
        ' 
        ' LblTime
        ' 
        LblTime.AutoSize = True
        LblTime.Location = New Point(970, 356)
        LblTime.Margin = New Padding(2, 0, 2, 0)
        LblTime.Name = "LblTime"
        LblTime.Size = New Size(33, 15)
        LblTime.TabIndex = 35
        LblTime.Text = "Time"
        ' 
        ' TxtSteps
        ' 
        TxtSteps.Location = New Point(869, 352)
        TxtSteps.Margin = New Padding(2, 1, 2, 1)
        TxtSteps.Name = "TxtSteps"
        TxtSteps.Size = New Size(103, 23)
        TxtSteps.TabIndex = 36
        ' 
        ' TxtTime
        ' 
        TxtTime.Location = New Point(1010, 352)
        TxtTime.Margin = New Padding(2, 1, 2, 1)
        TxtTime.Name = "TxtTime"
        TxtTime.Size = New Size(127, 23)
        TxtTime.TabIndex = 37
        ' 
        ' BtnShowBasin
        ' 
        BtnShowBasin.Location = New Point(815, 459)
        BtnShowBasin.Margin = New Padding(2)
        BtnShowBasin.Name = "BtnShowBasin"
        BtnShowBasin.Size = New Size(320, 34)
        BtnShowBasin.TabIndex = 42
        BtnShowBasin.Text = "ShowBasin"
        BtnShowBasin.UseVisualStyleBackColor = True
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Location = New Point(813, 734)
        BtnDefault.Margin = New Padding(2)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(320, 34)
        BtnDefault.TabIndex = 43
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' FrmNewtonIteration
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1147, 816)
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
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(2)
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
