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
        PicDiagram = New PictureBox()
        TxtTime = New TextBox()
        TxtSteps = New TextBox()
        LblTime = New Label()
        LblNumberOfSteps = New Label()
        LblI = New Label()
        LblC = New Label()
        TxtA = New TextBox()
        TxtB = New TextBox()
        BtnStop = New Button()
        BtnStart = New Button()
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
        BtnReset = New Button()
        ChkProtocol = New CheckBox()
        LblProtocol = New Label()
        LstProtocol = New ListBox()
        LblPower = New Label()
        CboN = New ComboBox()
        TrbRed = New TrackBar()
        TrbGreen = New TrackBar()
        TrbBlue = New TrackBar()
        PicBright = New PictureBox()
        PicDark = New PictureBox()
        GrpColors = New GroupBox()
        OptSystem = New RadioButton()
        OptUser = New RadioButton()
        BtnDefault = New Button()
        CboJuliaSamples = New ComboBox()
        LblJuliaSets = New Label()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbRed, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbGreen, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbBlue, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicBright, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicDark, ComponentModel.ISupportInitialize).BeginInit()
        GrpColors.SuspendLayout()
        SuspendLayout()
        ' 
        ' PicDiagram
        ' 
        PicDiagram.Location = New Point(-1, 7)
        PicDiagram.Margin = New Padding(2)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(800, 800)
        PicDiagram.TabIndex = 1
        PicDiagram.TabStop = False
        ' 
        ' TxtTime
        ' 
        TxtTime.Location = New Point(1012, 480)
        TxtTime.Margin = New Padding(2, 1, 2, 1)
        TxtTime.Name = "TxtTime"
        TxtTime.Size = New Size(111, 23)
        TxtTime.TabIndex = 62
        ' 
        ' TxtSteps
        ' 
        TxtSteps.Location = New Point(861, 480)
        TxtSteps.Margin = New Padding(2, 1, 2, 1)
        TxtSteps.Name = "TxtSteps"
        TxtSteps.Size = New Size(97, 23)
        TxtSteps.TabIndex = 61
        ' 
        ' LblTime
        ' 
        LblTime.AutoSize = True
        LblTime.Location = New Point(965, 483)
        LblTime.Margin = New Padding(2, 0, 2, 0)
        LblTime.Name = "LblTime"
        LblTime.Size = New Size(33, 15)
        LblTime.TabIndex = 60
        LblTime.Text = "Time"
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Location = New Point(811, 483)
        LblNumberOfSteps.Margin = New Padding(2, 0, 2, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(35, 15)
        LblNumberOfSteps.TabIndex = 59
        LblNumberOfSteps.Text = "Steps"
        ' 
        ' LblI
        ' 
        LblI.AutoSize = True
        LblI.Location = New Point(978, 42)
        LblI.Margin = New Padding(2, 0, 2, 0)
        LblI.Name = "LblI"
        LblI.Size = New Size(21, 15)
        LblI.TabIndex = 58
        LblI.Text = "+ i"
        ' 
        ' LblC
        ' 
        LblC.AutoSize = True
        LblC.Location = New Point(808, 41)
        LblC.Margin = New Padding(2, 0, 2, 0)
        LblC.Name = "LblC"
        LblC.Size = New Size(24, 15)
        LblC.TabIndex = 57
        LblC.Text = "c ="
        ' 
        ' TxtA
        ' 
        TxtA.Location = New Point(858, 39)
        TxtA.Margin = New Padding(2, 1, 2, 1)
        TxtA.Name = "TxtA"
        TxtA.Size = New Size(117, 23)
        TxtA.TabIndex = 56
        TxtA.Text = "0"
        ' 
        ' TxtB
        ' 
        TxtB.Location = New Point(1009, 39)
        TxtB.Margin = New Padding(2, 1, 2, 1)
        TxtB.Name = "TxtB"
        TxtB.Size = New Size(117, 23)
        TxtB.TabIndex = 55
        TxtB.Text = "0"
        ' 
        ' BtnStop
        ' 
        BtnStop.Location = New Point(804, 546)
        BtnStop.Margin = New Padding(2)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(320, 34)
        BtnStop.TabIndex = 54
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Location = New Point(804, 508)
        BtnStart.Margin = New Padding(2)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(320, 34)
        BtnStart.TabIndex = 53
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' LblDeltaY
        ' 
        LblDeltaY.AutoSize = True
        LblDeltaY.Location = New Point(804, 231)
        LblDeltaY.Margin = New Padding(2, 0, 2, 0)
        LblDeltaY.Name = "LblDeltaY"
        LblDeltaY.Size = New Size(41, 15)
        LblDeltaY.TabIndex = 49
        LblDeltaY.Text = "DeltaY"
        ' 
        ' TxtYMax
        ' 
        TxtYMax.Location = New Point(858, 204)
        TxtYMax.Margin = New Padding(2)
        TxtYMax.Name = "TxtYMax"
        TxtYMax.Size = New Size(268, 23)
        TxtYMax.TabIndex = 48
        ' 
        ' LblYMax
        ' 
        LblYMax.AutoSize = True
        LblYMax.Location = New Point(804, 206)
        LblYMax.Margin = New Padding(2, 0, 2, 0)
        LblYMax.Name = "LblYMax"
        LblYMax.Size = New Size(37, 15)
        LblYMax.TabIndex = 47
        LblYMax.Text = "YMax"
        ' 
        ' TxtYMin
        ' 
        TxtYMin.Location = New Point(858, 178)
        TxtYMin.Margin = New Padding(2)
        TxtYMin.Name = "TxtYMin"
        TxtYMin.Size = New Size(268, 23)
        TxtYMin.TabIndex = 46
        ' 
        ' LblYMin
        ' 
        LblYMin.AutoSize = True
        LblYMin.Location = New Point(804, 181)
        LblYMin.Margin = New Padding(2, 0, 2, 0)
        LblYMin.Name = "LblYMin"
        LblYMin.Size = New Size(35, 15)
        LblYMin.TabIndex = 45
        LblYMin.Text = "YMin"
        ' 
        ' LblDeltaX
        ' 
        LblDeltaX.AutoSize = True
        LblDeltaX.Location = New Point(804, 158)
        LblDeltaX.Margin = New Padding(2, 0, 2, 0)
        LblDeltaX.Name = "LblDeltaX"
        LblDeltaX.Size = New Size(41, 15)
        LblDeltaX.TabIndex = 43
        LblDeltaX.Text = "DeltaX"
        ' 
        ' TxtXMax
        ' 
        TxtXMax.Location = New Point(858, 128)
        TxtXMax.Margin = New Padding(2)
        TxtXMax.Name = "TxtXMax"
        TxtXMax.Size = New Size(268, 23)
        TxtXMax.TabIndex = 42
        ' 
        ' LblXMax
        ' 
        LblXMax.AutoSize = True
        LblXMax.Location = New Point(804, 132)
        LblXMax.Margin = New Padding(2, 0, 2, 0)
        LblXMax.Name = "LblXMax"
        LblXMax.Size = New Size(37, 15)
        LblXMax.TabIndex = 41
        LblXMax.Text = "XMax"
        ' 
        ' TxtXMin
        ' 
        TxtXMin.Location = New Point(858, 105)
        TxtXMin.Margin = New Padding(2)
        TxtXMin.Name = "TxtXMin"
        TxtXMin.Size = New Size(268, 23)
        TxtXMin.TabIndex = 40
        ' 
        ' LblXMin
        ' 
        LblXMin.AutoSize = True
        LblXMin.Location = New Point(804, 108)
        LblXMin.Margin = New Padding(2, 0, 2, 0)
        LblXMin.Name = "LblXMin"
        LblXMin.Size = New Size(35, 15)
        LblXMin.TabIndex = 39
        LblXMin.Text = "XMin"
        ' 
        ' CboFunction
        ' 
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"JuliaSet", "MandelbrotSet"})
        CboFunction.Location = New Point(807, 8)
        CboFunction.Margin = New Padding(2)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(247, 23)
        CboFunction.TabIndex = 38
        ' 
        ' BtnReset
        ' 
        BtnReset.Location = New Point(803, 772)
        BtnReset.Margin = New Padding(2)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(320, 34)
        BtnReset.TabIndex = 63
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' ChkProtocol
        ' 
        ChkProtocol.AutoSize = True
        ChkProtocol.Location = New Point(1053, 584)
        ChkProtocol.Margin = New Padding(2, 1, 2, 1)
        ChkProtocol.Name = "ChkProtocol"
        ChkProtocol.Size = New Size(71, 19)
        ChkProtocol.TabIndex = 66
        ChkProtocol.Text = "Protocol"
        ChkProtocol.UseVisualStyleBackColor = True
        ' 
        ' LblProtocol
        ' 
        LblProtocol.AutoSize = True
        LblProtocol.Location = New Point(807, 588)
        LblProtocol.Margin = New Padding(2, 0, 2, 0)
        LblProtocol.Name = "LblProtocol"
        LblProtocol.Size = New Size(52, 15)
        LblProtocol.TabIndex = 65
        LblProtocol.Text = "Protocol"
        ' 
        ' LstProtocol
        ' 
        LstProtocol.FormattingEnabled = True
        LstProtocol.HorizontalScrollbar = True
        LstProtocol.ItemHeight = 15
        LstProtocol.Location = New Point(804, 605)
        LstProtocol.Margin = New Padding(2)
        LstProtocol.Name = "LstProtocol"
        LstProtocol.Size = New Size(319, 124)
        LstProtocol.TabIndex = 64
        ' 
        ' LblPower
        ' 
        LblPower.AutoSize = True
        LblPower.Location = New Point(1056, 9)
        LblPower.Margin = New Padding(2, 0, 2, 0)
        LblPower.Name = "LblPower"
        LblPower.Size = New Size(25, 15)
        LblPower.TabIndex = 68
        LblPower.Text = "n ="
        ' 
        ' CboN
        ' 
        CboN.FormattingEnabled = True
        CboN.Items.AddRange(New Object() {"2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        CboN.Location = New Point(1087, 8)
        CboN.Margin = New Padding(2, 1, 2, 1)
        CboN.Name = "CboN"
        CboN.Size = New Size(39, 23)
        CboN.TabIndex = 67
        ' 
        ' TrbRed
        ' 
        TrbRed.BackColor = SystemColors.Control
        TrbRed.Location = New Point(804, 332)
        TrbRed.Margin = New Padding(2, 1, 2, 1)
        TrbRed.Name = "TrbRed"
        TrbRed.Size = New Size(219, 45)
        TrbRed.TabIndex = 69
        ' 
        ' TrbGreen
        ' 
        TrbGreen.BackColor = SystemColors.Control
        TrbGreen.Location = New Point(804, 379)
        TrbGreen.Margin = New Padding(2, 1, 2, 1)
        TrbGreen.Name = "TrbGreen"
        TrbGreen.Size = New Size(219, 45)
        TrbGreen.TabIndex = 70
        TrbGreen.Value = 10
        ' 
        ' TrbBlue
        ' 
        TrbBlue.BackColor = SystemColors.Control
        TrbBlue.Location = New Point(804, 426)
        TrbBlue.Margin = New Padding(2, 1, 2, 1)
        TrbBlue.Name = "TrbBlue"
        TrbBlue.Size = New Size(219, 45)
        TrbBlue.TabIndex = 71
        TrbBlue.Value = 2
        ' 
        ' PicBright
        ' 
        PicBright.Location = New Point(1046, 332)
        PicBright.Margin = New Padding(2, 1, 2, 1)
        PicBright.Name = "PicBright"
        PicBright.Size = New Size(74, 60)
        PicBright.TabIndex = 72
        PicBright.TabStop = False
        ' 
        ' PicDark
        ' 
        PicDark.Location = New Point(1046, 410)
        PicDark.Margin = New Padding(2, 1, 2, 1)
        PicDark.Name = "PicDark"
        PicDark.Size = New Size(74, 61)
        PicDark.TabIndex = 73
        PicDark.TabStop = False
        ' 
        ' GrpColors
        ' 
        GrpColors.Controls.Add(OptSystem)
        GrpColors.Controls.Add(OptUser)
        GrpColors.Location = New Point(808, 258)
        GrpColors.Margin = New Padding(2, 1, 2, 1)
        GrpColors.Name = "GrpColors"
        GrpColors.Padding = New Padding(2, 1, 2, 1)
        GrpColors.Size = New Size(316, 56)
        GrpColors.TabIndex = 74
        GrpColors.TabStop = False
        GrpColors.Text = "Colors"
        ' 
        ' OptSystem
        ' 
        OptSystem.AutoSize = True
        OptSystem.Checked = True
        OptSystem.Location = New Point(50, 27)
        OptSystem.Margin = New Padding(2, 1, 2, 1)
        OptSystem.Name = "OptSystem"
        OptSystem.Size = New Size(63, 19)
        OptSystem.TabIndex = 75
        OptSystem.TabStop = True
        OptSystem.Text = "System"
        OptSystem.UseVisualStyleBackColor = True
        ' 
        ' OptUser
        ' 
        OptUser.AutoSize = True
        OptUser.Location = New Point(170, 27)
        OptUser.Margin = New Padding(2, 1, 2, 1)
        OptUser.Name = "OptUser"
        OptUser.Size = New Size(89, 19)
        OptUser.TabIndex = 76
        OptUser.Text = "UserDefined"
        OptUser.UseVisualStyleBackColor = True
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Location = New Point(804, 734)
        BtnDefault.Margin = New Padding(2)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(320, 34)
        BtnDefault.TabIndex = 76
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' CboJuliaSamples
        ' 
        CboJuliaSamples.FormattingEnabled = True
        CboJuliaSamples.Location = New Point(858, 73)
        CboJuliaSamples.Margin = New Padding(2)
        CboJuliaSamples.Name = "CboJuliaSamples"
        CboJuliaSamples.Size = New Size(268, 23)
        CboJuliaSamples.TabIndex = 77
        ' 
        ' LblJuliaSets
        ' 
        LblJuliaSets.AutoSize = True
        LblJuliaSets.Location = New Point(803, 76)
        LblJuliaSets.Margin = New Padding(2, 0, 2, 0)
        LblJuliaSets.Name = "LblJuliaSets"
        LblJuliaSets.Size = New Size(51, 15)
        LblJuliaSets.TabIndex = 78
        LblJuliaSets.Text = "Samples"
        ' 
        ' FrmJulia
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1136, 815)
        Controls.Add(LblJuliaSets)
        Controls.Add(CboJuliaSamples)
        Controls.Add(BtnDefault)
        Controls.Add(GrpColors)
        Controls.Add(PicDark)
        Controls.Add(PicBright)
        Controls.Add(TrbBlue)
        Controls.Add(TrbGreen)
        Controls.Add(TrbRed)
        Controls.Add(LblPower)
        Controls.Add(CboN)
        Controls.Add(ChkProtocol)
        Controls.Add(LblProtocol)
        Controls.Add(LstProtocol)
        Controls.Add(BtnReset)
        Controls.Add(TxtTime)
        Controls.Add(TxtSteps)
        Controls.Add(LblTime)
        Controls.Add(LblNumberOfSteps)
        Controls.Add(LblI)
        Controls.Add(LblC)
        Controls.Add(TxtA)
        Controls.Add(TxtB)
        Controls.Add(BtnStop)
        Controls.Add(BtnStart)
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
        Margin = New Padding(2, 1, 2, 1)
        Name = "FrmJulia"
        Text = "JuliaSet"
        WindowState = FormWindowState.Maximized
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbRed, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbGreen, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbBlue, ComponentModel.ISupportInitialize).EndInit()
        CType(PicBright, ComponentModel.ISupportInitialize).EndInit()
        CType(PicDark, ComponentModel.ISupportInitialize).EndInit()
        GrpColors.ResumeLayout(False)
        GrpColors.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents TxtTime As TextBox
    Friend WithEvents TxtSteps As TextBox
    Friend WithEvents LblTime As Label
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents LblI As Label
    Friend WithEvents LblC As Label
    Friend WithEvents TxtA As TextBox
    Friend WithEvents TxtB As TextBox
    Friend WithEvents BtnStop As Button
    Friend WithEvents BtnStart As Button
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
    Friend WithEvents BtnReset As Button
    Friend WithEvents ChkProtocol As CheckBox
    Friend WithEvents LblProtocol As Label
    Friend WithEvents LstProtocol As ListBox
    Friend WithEvents LblPower As Label
    Friend WithEvents CboN As ComboBox
    Friend WithEvents TrbRed As TrackBar
    Friend WithEvents TrbGreen As TrackBar
    Friend WithEvents TrbBlue As TrackBar
    Friend WithEvents PicBright As PictureBox
    Friend WithEvents PicDark As PictureBox
    Friend WithEvents ChkUseSystemColors As CheckBox
    Friend WithEvents GrpColors As GroupBox
    Friend WithEvents OptSystem As RadioButton
    Friend WithEvents OptUser As RadioButton
    Friend WithEvents BtnDefault As Button
    Friend WithEvents CboJuliaSamples As ComboBox
    Friend WithEvents LblJuliaSets As Label
End Class
