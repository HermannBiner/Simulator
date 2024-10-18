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
        PicDiagram.Location = New Point(-2, 17)
        PicDiagram.Margin = New Padding(4, 5, 4, 5)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(1300, 1300)
        PicDiagram.TabIndex = 1
        PicDiagram.TabStop = False
        ' 
        ' TxtTime
        ' 
        TxtTime.Enabled = False
        TxtTime.Font = New Font("Segoe UI", 11F)
        TxtTime.Location = New Point(1718, 1003)
        TxtTime.Margin = New Padding(4, 2, 4, 2)
        TxtTime.Name = "TxtTime"
        TxtTime.Size = New Size(218, 42)
        TxtTime.TabIndex = 62
        ' 
        ' TxtSteps
        ' 
        TxtSteps.Enabled = False
        TxtSteps.Font = New Font("Segoe UI", 11F)
        TxtSteps.Location = New Point(1417, 1003)
        TxtSteps.Margin = New Padding(4, 2, 4, 2)
        TxtSteps.Name = "TxtSteps"
        TxtSteps.Size = New Size(190, 42)
        TxtSteps.TabIndex = 61
        ' 
        ' LblTime
        ' 
        LblTime.AutoSize = True
        LblTime.Font = New Font("Segoe UI", 11F)
        LblTime.Location = New Point(1625, 1010)
        LblTime.Margin = New Padding(4, 0, 4, 0)
        LblTime.Name = "LblTime"
        LblTime.Size = New Size(71, 36)
        LblTime.TabIndex = 60
        LblTime.Text = "Time"
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Font = New Font("Segoe UI", 11F)
        LblNumberOfSteps.Location = New Point(1317, 1010)
        LblNumberOfSteps.Margin = New Padding(4, 0, 4, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(77, 36)
        LblNumberOfSteps.TabIndex = 59
        LblNumberOfSteps.Text = "Steps"
        ' 
        ' LblI
        ' 
        LblI.AutoSize = True
        LblI.Font = New Font("Segoe UI", 11F)
        LblI.Location = New Point(1624, 81)
        LblI.Margin = New Padding(4, 0, 4, 0)
        LblI.Name = "LblI"
        LblI.Size = New Size(46, 36)
        LblI.TabIndex = 58
        LblI.Text = "+ i"
        ' 
        ' LblC
        ' 
        LblC.AutoSize = True
        LblC.Font = New Font("Segoe UI", 11F)
        LblC.Location = New Point(1312, 78)
        LblC.Margin = New Padding(4, 0, 4, 0)
        LblC.Name = "LblC"
        LblC.Size = New Size(52, 36)
        LblC.TabIndex = 57
        LblC.Text = "c ="
        ' 
        ' TxtA
        ' 
        TxtA.Font = New Font("Segoe UI", 11F)
        TxtA.Location = New Point(1386, 78)
        TxtA.Margin = New Padding(4, 2, 4, 2)
        TxtA.Name = "TxtA"
        TxtA.Size = New Size(230, 42)
        TxtA.TabIndex = 56
        TxtA.Text = "0"
        ' 
        ' TxtB
        ' 
        TxtB.Font = New Font("Segoe UI", 11F)
        TxtB.Location = New Point(1678, 78)
        TxtB.Margin = New Padding(4, 2, 4, 2)
        TxtB.Name = "TxtB"
        TxtB.Size = New Size(258, 42)
        TxtB.TabIndex = 55
        TxtB.Text = "0"
        ' 
        ' BtnStop
        ' 
        BtnStop.Font = New Font("Segoe UI", 11F)
        BtnStop.Location = New Point(1307, 1130)
        BtnStop.Margin = New Padding(4, 5, 4, 5)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(633, 58)
        BtnStop.TabIndex = 54
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Segoe UI", 11F)
        BtnStart.Location = New Point(1306, 1063)
        BtnStart.Margin = New Padding(4, 5, 4, 5)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(632, 58)
        BtnStart.TabIndex = 53
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' LblDeltaY
        ' 
        LblDeltaY.AutoSize = True
        LblDeltaY.Font = New Font("Segoe UI", 11F)
        LblDeltaY.Location = New Point(1300, 477)
        LblDeltaY.Margin = New Padding(4, 0, 4, 0)
        LblDeltaY.Name = "LblDeltaY"
        LblDeltaY.Size = New Size(89, 36)
        LblDeltaY.TabIndex = 49
        LblDeltaY.Text = "DeltaY"
        ' 
        ' TxtYMax
        ' 
        TxtYMax.Font = New Font("Segoe UI", 11F)
        TxtYMax.Location = New Point(1407, 420)
        TxtYMax.Margin = New Padding(4, 5, 4, 5)
        TxtYMax.Name = "TxtYMax"
        TxtYMax.Size = New Size(532, 42)
        TxtYMax.TabIndex = 48
        ' 
        ' LblYMax
        ' 
        LblYMax.AutoSize = True
        LblYMax.Font = New Font("Segoe UI", 11F)
        LblYMax.Location = New Point(1301, 423)
        LblYMax.Margin = New Padding(4, 0, 4, 0)
        LblYMax.Name = "LblYMax"
        LblYMax.Size = New Size(77, 36)
        LblYMax.TabIndex = 47
        LblYMax.Text = "YMax"
        ' 
        ' TxtYMin
        ' 
        TxtYMin.Font = New Font("Segoe UI", 11F)
        TxtYMin.Location = New Point(1408, 368)
        TxtYMin.Margin = New Padding(4, 5, 4, 5)
        TxtYMin.Name = "TxtYMin"
        TxtYMin.Size = New Size(532, 42)
        TxtYMin.TabIndex = 46
        ' 
        ' LblYMin
        ' 
        LblYMin.AutoSize = True
        LblYMin.Font = New Font("Segoe UI", 11F)
        LblYMin.Location = New Point(1301, 375)
        LblYMin.Margin = New Padding(4, 0, 4, 0)
        LblYMin.Name = "LblYMin"
        LblYMin.Size = New Size(73, 36)
        LblYMin.TabIndex = 45
        LblYMin.Text = "YMin"
        ' 
        ' LblDeltaX
        ' 
        LblDeltaX.AutoSize = True
        LblDeltaX.Font = New Font("Segoe UI", 11F)
        LblDeltaX.Location = New Point(1301, 319)
        LblDeltaX.Margin = New Padding(4, 0, 4, 0)
        LblDeltaX.Name = "LblDeltaX"
        LblDeltaX.Size = New Size(90, 36)
        LblDeltaX.TabIndex = 43
        LblDeltaX.Text = "DeltaX"
        ' 
        ' TxtXMax
        ' 
        TxtXMax.Font = New Font("Segoe UI", 11F)
        TxtXMax.Location = New Point(1408, 247)
        TxtXMax.Margin = New Padding(4, 5, 4, 5)
        TxtXMax.Name = "TxtXMax"
        TxtXMax.Size = New Size(532, 42)
        TxtXMax.TabIndex = 42
        ' 
        ' LblXMax
        ' 
        LblXMax.AutoSize = True
        LblXMax.Font = New Font("Segoe UI", 11F)
        LblXMax.Location = New Point(1301, 258)
        LblXMax.Margin = New Padding(4, 0, 4, 0)
        LblXMax.Name = "LblXMax"
        LblXMax.Size = New Size(78, 36)
        LblXMax.TabIndex = 41
        LblXMax.Text = "XMax"
        ' 
        ' TxtXMin
        ' 
        TxtXMin.Font = New Font("Segoe UI", 11F)
        TxtXMin.Location = New Point(1407, 193)
        TxtXMin.Margin = New Padding(4, 5, 4, 5)
        TxtXMin.Name = "TxtXMin"
        TxtXMin.Size = New Size(533, 42)
        TxtXMin.TabIndex = 40
        ' 
        ' LblXMin
        ' 
        LblXMin.AutoSize = True
        LblXMin.Font = New Font("Segoe UI", 11F)
        LblXMin.Location = New Point(1301, 200)
        LblXMin.Margin = New Padding(4, 0, 4, 0)
        LblXMin.Name = "LblXMin"
        LblXMin.Size = New Size(74, 36)
        LblXMin.TabIndex = 39
        LblXMin.Text = "XMin"
        ' 
        ' CboFunction
        ' 
        CboFunction.Font = New Font("Segoe UI", 11F)
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"JuliaSet", "MandelbrotSet"})
        CboFunction.Location = New Point(1306, 14)
        CboFunction.Margin = New Padding(4, 5, 4, 5)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(489, 44)
        CboFunction.TabIndex = 38
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Segoe UI", 11F)
        BtnReset.Location = New Point(13, 1342)
        BtnReset.Margin = New Padding(4, 5, 4, 5)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(615, 58)
        BtnReset.TabIndex = 63
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' ChkProtocol
        ' 
        ChkProtocol.AutoSize = True
        ChkProtocol.Font = New Font("Segoe UI", 11F)
        ChkProtocol.Location = New Point(1799, 1206)
        ChkProtocol.Margin = New Padding(4, 2, 4, 2)
        ChkProtocol.Name = "ChkProtocol"
        ChkProtocol.Size = New Size(137, 40)
        ChkProtocol.TabIndex = 66
        ChkProtocol.Text = "Protocol"
        ChkProtocol.UseVisualStyleBackColor = True
        ' 
        ' LblProtocol
        ' 
        LblProtocol.AutoSize = True
        LblProtocol.Font = New Font("Segoe UI", 11F)
        LblProtocol.Location = New Point(1307, 1206)
        LblProtocol.Margin = New Padding(4, 0, 4, 0)
        LblProtocol.Name = "LblProtocol"
        LblProtocol.Size = New Size(111, 36)
        LblProtocol.TabIndex = 65
        LblProtocol.Text = "Protocol"
        ' 
        ' LstProtocol
        ' 
        LstProtocol.Font = New Font("Segoe UI", 11F)
        LstProtocol.FormattingEnabled = True
        LstProtocol.HorizontalScrollbar = True
        LstProtocol.ItemHeight = 36
        LstProtocol.Location = New Point(1312, 1253)
        LstProtocol.Margin = New Padding(4, 5, 4, 5)
        LstProtocol.Name = "LstProtocol"
        LstProtocol.Size = New Size(624, 148)
        LstProtocol.TabIndex = 64
        ' 
        ' LblPower
        ' 
        LblPower.AutoSize = True
        LblPower.Font = New Font("Segoe UI", 11F)
        LblPower.Location = New Point(1804, 17)
        LblPower.Margin = New Padding(4, 0, 4, 0)
        LblPower.Name = "LblPower"
        LblPower.Size = New Size(55, 36)
        LblPower.TabIndex = 68
        LblPower.Text = "n ="
        ' 
        ' CboN
        ' 
        CboN.Font = New Font("Segoe UI", 11F)
        CboN.FormattingEnabled = True
        CboN.Items.AddRange(New Object() {"2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        CboN.Location = New Point(1866, 14)
        CboN.Margin = New Padding(4, 2, 4, 2)
        CboN.Name = "CboN"
        CboN.Size = New Size(74, 44)
        CboN.TabIndex = 67
        ' 
        ' TrbRed
        ' 
        TrbRed.BackColor = SystemColors.Control
        TrbRed.Location = New Point(1312, 674)
        TrbRed.Margin = New Padding(4, 2, 4, 2)
        TrbRed.Name = "TrbRed"
        TrbRed.Size = New Size(438, 80)
        TrbRed.TabIndex = 69
        ' 
        ' TrbGreen
        ' 
        TrbGreen.BackColor = SystemColors.Control
        TrbGreen.Location = New Point(1312, 788)
        TrbGreen.Margin = New Padding(4, 2, 4, 2)
        TrbGreen.Name = "TrbGreen"
        TrbGreen.Size = New Size(438, 80)
        TrbGreen.TabIndex = 70
        TrbGreen.Value = 10
        ' 
        ' TrbBlue
        ' 
        TrbBlue.BackColor = SystemColors.Control
        TrbBlue.Location = New Point(1312, 900)
        TrbBlue.Margin = New Padding(4, 2, 4, 2)
        TrbBlue.Name = "TrbBlue"
        TrbBlue.Size = New Size(438, 80)
        TrbBlue.TabIndex = 71
        TrbBlue.Value = 2
        ' 
        ' PicBright
        ' 
        PicBright.Location = New Point(1790, 674)
        PicBright.Margin = New Padding(4, 2, 4, 2)
        PicBright.Name = "PicBright"
        PicBright.Size = New Size(148, 144)
        PicBright.TabIndex = 72
        PicBright.TabStop = False
        ' 
        ' PicDark
        ' 
        PicDark.Location = New Point(1790, 834)
        PicDark.Margin = New Padding(4, 2, 4, 2)
        PicDark.Name = "PicDark"
        PicDark.Size = New Size(148, 146)
        PicDark.TabIndex = 73
        PicDark.TabStop = False
        ' 
        ' GrpColors
        ' 
        GrpColors.Controls.Add(OptSystem)
        GrpColors.Controls.Add(OptUser)
        GrpColors.Font = New Font("Segoe UI", 11F)
        GrpColors.Location = New Point(1304, 527)
        GrpColors.Margin = New Padding(4, 2, 4, 2)
        GrpColors.Name = "GrpColors"
        GrpColors.Padding = New Padding(4, 2, 4, 2)
        GrpColors.Size = New Size(632, 124)
        GrpColors.TabIndex = 74
        GrpColors.TabStop = False
        GrpColors.Text = "Colors"
        ' 
        ' OptSystem
        ' 
        OptSystem.AutoSize = True
        OptSystem.Checked = True
        OptSystem.Location = New Point(100, 65)
        OptSystem.Margin = New Padding(4, 2, 4, 2)
        OptSystem.Name = "OptSystem"
        OptSystem.Size = New Size(122, 40)
        OptSystem.TabIndex = 75
        OptSystem.TabStop = True
        OptSystem.Text = "System"
        OptSystem.UseVisualStyleBackColor = True
        ' 
        ' OptUser
        ' 
        OptUser.AutoSize = True
        OptUser.Location = New Point(340, 65)
        OptUser.Margin = New Padding(4, 2, 4, 2)
        OptUser.Name = "OptUser"
        OptUser.Size = New Size(182, 40)
        OptUser.TabIndex = 76
        OptUser.Text = "UserDefined"
        OptUser.UseVisualStyleBackColor = True
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Segoe UI", 11F)
        BtnDefault.Location = New Point(637, 1342)
        BtnDefault.Margin = New Padding(4, 5, 4, 5)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(621, 58)
        BtnDefault.TabIndex = 76
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' CboJuliaSamples
        ' 
        CboJuliaSamples.Font = New Font("Segoe UI", 11F)
        CboJuliaSamples.FormattingEnabled = True
        CboJuliaSamples.Location = New Point(1453, 139)
        CboJuliaSamples.Margin = New Padding(4, 5, 4, 5)
        CboJuliaSamples.Name = "CboJuliaSamples"
        CboJuliaSamples.Size = New Size(485, 44)
        CboJuliaSamples.TabIndex = 77
        ' 
        ' LblJuliaSets
        ' 
        LblJuliaSets.AutoSize = True
        LblJuliaSets.Font = New Font("Segoe UI", 11F)
        LblJuliaSets.Location = New Point(1312, 142)
        LblJuliaSets.Margin = New Padding(4, 0, 4, 0)
        LblJuliaSets.Name = "LblJuliaSets"
        LblJuliaSets.Size = New Size(110, 36)
        LblJuliaSets.TabIndex = 78
        LblJuliaSets.Text = "Samples"
        ' 
        ' FrmJulia
        ' 
        AutoScaleDimensions = New SizeF(14F, 36F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1961, 1414)
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
        Margin = New Padding(4, 2, 4, 2)
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
