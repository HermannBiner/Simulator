﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        PicCPlane = New PictureBox()
        TxtTime = New TextBox()
        TxtSteps = New TextBox()
        LblTime = New Label()
        LblSteps = New Label()
        LblI = New Label()
        LblC = New Label()
        TxtA = New TextBox()
        TxtB = New TextBox()
        BtnStop = New Button()
        BtnStart = New Button()
        TxtDeltaY = New TextBox()
        LblDeltaY = New Label()
        TxtYMax = New TextBox()
        LblYMax = New Label()
        TxtYMin = New TextBox()
        LblYMin = New Label()
        TxtDeltaX = New TextBox()
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
        ChkTrack = New CheckBox()
        CType(PicCPlane, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbRed, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbGreen, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbBlue, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicBright, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicDark, ComponentModel.ISupportInitialize).BeginInit()
        GrpColors.SuspendLayout()
        SuspendLayout()
        ' 
        ' PicCPlane
        ' 
        PicCPlane.Location = New Point(-2, 15)
        PicCPlane.Margin = New Padding(4)
        PicCPlane.Name = "PicCPlane"
        PicCPlane.Size = New Size(1398, 1587)
        PicCPlane.TabIndex = 1
        PicCPlane.TabStop = False
        ' 
        ' TxtTime
        ' 
        TxtTime.Location = New Point(1824, 966)
        TxtTime.Margin = New Padding(4, 2, 4, 2)
        TxtTime.Name = "TxtTime"
        TxtTime.Size = New Size(214, 39)
        TxtTime.TabIndex = 62
        ' 
        ' TxtSteps
        ' 
        TxtSteps.Location = New Point(1543, 966)
        TxtSteps.Margin = New Padding(4, 2, 4, 2)
        TxtSteps.Name = "TxtSteps"
        TxtSteps.Size = New Size(177, 39)
        TxtSteps.TabIndex = 61
        ' 
        ' LblTime
        ' 
        LblTime.AutoSize = True
        LblTime.Location = New Point(1737, 972)
        LblTime.Margin = New Padding(4, 0, 4, 0)
        LblTime.Name = "LblTime"
        LblTime.Size = New Size(67, 32)
        LblTime.TabIndex = 60
        LblTime.Text = "Time"
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Location = New Point(1450, 972)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(71, 32)
        LblSteps.TabIndex = 59
        LblSteps.Text = "Steps"
        ' 
        ' LblI
        ' 
        LblI.AutoSize = True
        LblI.Location = New Point(1766, 88)
        LblI.Margin = New Padding(4, 0, 4, 0)
        LblI.Name = "LblI"
        LblI.Size = New Size(43, 32)
        LblI.TabIndex = 58
        LblI.Text = "+ i"
        ' 
        ' LblC
        ' 
        LblC.AutoSize = True
        LblC.Location = New Point(1450, 85)
        LblC.Margin = New Padding(4, 0, 4, 0)
        LblC.Name = "LblC"
        LblC.Size = New Size(48, 32)
        LblC.TabIndex = 57
        LblC.Text = "c ="
        ' 
        ' TxtA
        ' 
        TxtA.Location = New Point(1543, 81)
        TxtA.Margin = New Padding(4, 2, 4, 2)
        TxtA.Name = "TxtA"
        TxtA.Size = New Size(214, 39)
        TxtA.TabIndex = 56
        TxtA.Text = "0"
        ' 
        ' TxtB
        ' 
        TxtB.Location = New Point(1824, 81)
        TxtB.Margin = New Padding(4, 2, 4, 2)
        TxtB.Name = "TxtB"
        TxtB.Size = New Size(214, 39)
        TxtB.TabIndex = 55
        TxtB.Text = "0"
        ' 
        ' BtnStop
        ' 
        BtnStop.Location = New Point(1443, 1126)
        BtnStop.Margin = New Padding(4)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(594, 75)
        BtnStop.TabIndex = 54
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Location = New Point(1443, 1030)
        BtnStart.Margin = New Padding(4)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(594, 75)
        BtnStart.TabIndex = 53
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' TxtDeltaY
        ' 
        TxtDeltaY.Location = New Point(1543, 402)
        TxtDeltaY.Margin = New Padding(4)
        TxtDeltaY.Name = "TxtDeltaY"
        TxtDeltaY.Size = New Size(494, 39)
        TxtDeltaY.TabIndex = 50
        ' 
        ' LblDeltaY
        ' 
        LblDeltaY.AutoSize = True
        LblDeltaY.Location = New Point(1443, 408)
        LblDeltaY.Margin = New Padding(4, 0, 4, 0)
        LblDeltaY.Name = "LblDeltaY"
        LblDeltaY.Size = New Size(83, 32)
        LblDeltaY.TabIndex = 49
        LblDeltaY.Text = "DeltaY"
        ' 
        ' TxtYMax
        ' 
        TxtYMax.Location = New Point(1543, 349)
        TxtYMax.Margin = New Padding(4)
        TxtYMax.Name = "TxtYMax"
        TxtYMax.Size = New Size(494, 39)
        TxtYMax.TabIndex = 48
        ' 
        ' LblYMax
        ' 
        LblYMax.AutoSize = True
        LblYMax.Location = New Point(1443, 355)
        LblYMax.Margin = New Padding(4, 0, 4, 0)
        LblYMax.Name = "LblYMax"
        LblYMax.Size = New Size(72, 32)
        LblYMax.TabIndex = 47
        LblYMax.Text = "YMax"
        ' 
        ' TxtYMin
        ' 
        TxtYMin.Location = New Point(1543, 294)
        TxtYMin.Margin = New Padding(4)
        TxtYMin.Name = "TxtYMin"
        TxtYMin.Size = New Size(494, 39)
        TxtYMin.TabIndex = 46
        ' 
        ' LblYMin
        ' 
        LblYMin.AutoSize = True
        LblYMin.Location = New Point(1443, 300)
        LblYMin.Margin = New Padding(4, 0, 4, 0)
        LblYMin.Name = "LblYMin"
        LblYMin.Size = New Size(69, 32)
        LblYMin.TabIndex = 45
        LblYMin.Text = "YMin"
        ' 
        ' TxtDeltaX
        ' 
        TxtDeltaX.Location = New Point(1543, 241)
        TxtDeltaX.Margin = New Padding(4)
        TxtDeltaX.Name = "TxtDeltaX"
        TxtDeltaX.Size = New Size(494, 39)
        TxtDeltaX.TabIndex = 44
        ' 
        ' LblDeltaX
        ' 
        LblDeltaX.AutoSize = True
        LblDeltaX.Location = New Point(1443, 252)
        LblDeltaX.Margin = New Padding(4, 0, 4, 0)
        LblDeltaX.Name = "LblDeltaX"
        LblDeltaX.Size = New Size(84, 32)
        LblDeltaX.TabIndex = 43
        LblDeltaX.Text = "DeltaX"
        ' 
        ' TxtXMax
        ' 
        TxtXMax.Location = New Point(1543, 188)
        TxtXMax.Margin = New Padding(4)
        TxtXMax.Name = "TxtXMax"
        TxtXMax.Size = New Size(494, 39)
        TxtXMax.TabIndex = 42
        ' 
        ' LblXMax
        ' 
        LblXMax.AutoSize = True
        LblXMax.Location = New Point(1443, 197)
        LblXMax.Margin = New Padding(4, 0, 4, 0)
        LblXMax.Name = "LblXMax"
        LblXMax.Size = New Size(73, 32)
        LblXMax.TabIndex = 41
        LblXMax.Text = "XMax"
        ' 
        ' TxtXMin
        ' 
        TxtXMin.Location = New Point(1543, 138)
        TxtXMin.Margin = New Padding(4)
        TxtXMin.Name = "TxtXMin"
        TxtXMin.Size = New Size(494, 39)
        TxtXMin.TabIndex = 40
        ' 
        ' LblXMin
        ' 
        LblXMin.AutoSize = True
        LblXMin.Location = New Point(1443, 144)
        LblXMin.Margin = New Padding(4, 0, 4, 0)
        LblXMin.Name = "LblXMin"
        LblXMin.Size = New Size(70, 32)
        LblXMin.TabIndex = 39
        LblXMin.Text = "XMin"
        ' 
        ' CboFunction
        ' 
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"JuliaSet", "MandelbrotSet"})
        CboFunction.Location = New Point(1449, 15)
        CboFunction.Margin = New Padding(4)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(455, 40)
        CboFunction.TabIndex = 38
        ' 
        ' BtnReset
        ' 
        BtnReset.Location = New Point(1443, 1515)
        BtnReset.Margin = New Padding(4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(594, 75)
        BtnReset.TabIndex = 63
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' ChkProtocol
        ' 
        ChkProtocol.AutoSize = True
        ChkProtocol.Location = New Point(1904, 1209)
        ChkProtocol.Margin = New Padding(4, 2, 4, 2)
        ChkProtocol.Name = "ChkProtocol"
        ChkProtocol.Size = New Size(134, 36)
        ChkProtocol.TabIndex = 66
        ChkProtocol.Text = "Protocol"
        ChkProtocol.UseVisualStyleBackColor = True
        ' 
        ' LblProtocol
        ' 
        LblProtocol.AutoSize = True
        LblProtocol.Location = New Point(1450, 1214)
        LblProtocol.Margin = New Padding(4, 0, 4, 0)
        LblProtocol.Name = "LblProtocol"
        LblProtocol.Size = New Size(102, 32)
        LblProtocol.TabIndex = 65
        LblProtocol.Text = "Protocol"
        ' 
        ' LstProtocol
        ' 
        LstProtocol.FormattingEnabled = True
        LstProtocol.HorizontalScrollbar = True
        LstProtocol.Location = New Point(1443, 1265)
        LstProtocol.Margin = New Padding(4)
        LstProtocol.Name = "LstProtocol"
        LstProtocol.Size = New Size(595, 228)
        LstProtocol.TabIndex = 64
        ' 
        ' LblPower
        ' 
        LblPower.AutoSize = True
        LblPower.Location = New Point(1911, 17)
        LblPower.Margin = New Padding(4, 0, 4, 0)
        LblPower.Name = "LblPower"
        LblPower.Size = New Size(51, 32)
        LblPower.TabIndex = 68
        LblPower.Text = "n ="
        ' 
        ' CboN
        ' 
        CboN.FormattingEnabled = True
        CboN.Items.AddRange(New Object() {"2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        CboN.Location = New Point(1969, 15)
        CboN.Margin = New Padding(4, 2, 4, 2)
        CboN.Name = "CboN"
        CboN.Size = New Size(69, 40)
        CboN.TabIndex = 67
        ' 
        ' TrbRed
        ' 
        TrbRed.BackColor = SystemColors.Control
        TrbRed.Location = New Point(1443, 623)
        TrbRed.Margin = New Padding(4, 2, 4, 2)
        TrbRed.Name = "TrbRed"
        TrbRed.Size = New Size(407, 90)
        TrbRed.TabIndex = 69
        ' 
        ' TrbGreen
        ' 
        TrbGreen.BackColor = SystemColors.Control
        TrbGreen.Location = New Point(1443, 738)
        TrbGreen.Margin = New Padding(4, 2, 4, 2)
        TrbGreen.Name = "TrbGreen"
        TrbGreen.Size = New Size(407, 90)
        TrbGreen.TabIndex = 70
        TrbGreen.Value = 10
        ' 
        ' TrbBlue
        ' 
        TrbBlue.BackColor = SystemColors.Control
        TrbBlue.Location = New Point(1443, 847)
        TrbBlue.Margin = New Padding(4, 2, 4, 2)
        TrbBlue.Name = "TrbBlue"
        TrbBlue.Size = New Size(407, 90)
        TrbBlue.TabIndex = 71
        TrbBlue.Value = 2
        ' 
        ' PicBright
        ' 
        PicBright.Location = New Point(1893, 623)
        PicBright.Margin = New Padding(4, 2, 4, 2)
        PicBright.Name = "PicBright"
        PicBright.Size = New Size(137, 156)
        PicBright.TabIndex = 72
        PicBright.TabStop = False
        ' 
        ' PicDark
        ' 
        PicDark.Location = New Point(1893, 789)
        PicDark.Margin = New Padding(4, 2, 4, 2)
        PicDark.Name = "PicDark"
        PicDark.Size = New Size(137, 156)
        PicDark.TabIndex = 73
        PicDark.TabStop = False
        ' 
        ' GrpColors
        ' 
        GrpColors.Controls.Add(OptSystem)
        GrpColors.Controls.Add(OptUser)
        GrpColors.Location = New Point(1450, 464)
        GrpColors.Name = "GrpColors"
        GrpColors.Size = New Size(587, 140)
        GrpColors.TabIndex = 74
        GrpColors.TabStop = False
        GrpColors.Text = "Colors"
        ' 
        ' OptSystem
        ' 
        OptSystem.AutoSize = True
        OptSystem.Checked = True
        OptSystem.Location = New Point(20, 57)
        OptSystem.Name = "OptSystem"
        OptSystem.Size = New Size(121, 36)
        OptSystem.TabIndex = 75
        OptSystem.TabStop = True
        OptSystem.Text = "System"
        OptSystem.UseVisualStyleBackColor = True
        ' 
        ' OptUser
        ' 
        OptUser.AutoSize = True
        OptUser.Location = New Point(290, 57)
        OptUser.Name = "OptUser"
        OptUser.Size = New Size(177, 36)
        OptUser.TabIndex = 76
        OptUser.Text = "UserDefined"
        OptUser.UseVisualStyleBackColor = True
        ' 
        ' ChkTrack
        ' 
        ChkTrack.AutoSize = True
        ChkTrack.Location = New Point(1766, 1207)
        ChkTrack.Margin = New Padding(4, 2, 4, 2)
        ChkTrack.Name = "ChkTrack"
        ChkTrack.Size = New Size(115, 36)
        ChkTrack.TabIndex = 75
        ChkTrack.Text = "CTrack"
        ChkTrack.UseVisualStyleBackColor = True
        ' 
        ' FrmJulia
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(2058, 1625)
        Controls.Add(ChkTrack)
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
        Controls.Add(LblSteps)
        Controls.Add(LblI)
        Controls.Add(LblC)
        Controls.Add(TxtA)
        Controls.Add(TxtB)
        Controls.Add(BtnStop)
        Controls.Add(BtnStart)
        Controls.Add(TxtDeltaY)
        Controls.Add(LblDeltaY)
        Controls.Add(TxtYMax)
        Controls.Add(LblYMax)
        Controls.Add(TxtYMin)
        Controls.Add(LblYMin)
        Controls.Add(TxtDeltaX)
        Controls.Add(LblDeltaX)
        Controls.Add(TxtXMax)
        Controls.Add(LblXMax)
        Controls.Add(TxtXMin)
        Controls.Add(LblXMin)
        Controls.Add(CboFunction)
        Controls.Add(PicCPlane)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4, 2, 4, 2)
        Name = "FrmJulia"
        Text = "QuadraticFunction"
        WindowState = FormWindowState.Maximized
        CType(PicCPlane, ComponentModel.ISupportInitialize).EndInit()
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

    Friend WithEvents PicCPlane As PictureBox
    Friend WithEvents TxtTime As TextBox
    Friend WithEvents TxtSteps As TextBox
    Friend WithEvents LblTime As Label
    Friend WithEvents LblSteps As Label
    Friend WithEvents LblI As Label
    Friend WithEvents LblC As Label
    Friend WithEvents TxtA As TextBox
    Friend WithEvents TxtB As TextBox
    Friend WithEvents BtnStop As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents TxtDeltaY As TextBox
    Friend WithEvents LblDeltaY As Label
    Friend WithEvents TxtYMax As TextBox
    Friend WithEvents LblYMax As Label
    Friend WithEvents TxtYMin As TextBox
    Friend WithEvents LblYMin As Label
    Friend WithEvents TxtDeltaX As TextBox
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
    Friend WithEvents ChkTrack As CheckBox
End Class