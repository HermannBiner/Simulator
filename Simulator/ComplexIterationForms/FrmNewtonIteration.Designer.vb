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
        PicCPlane = New PictureBox()
        CboFunction = New ComboBox()
        LblXMin = New Label()
        TxtXMin = New TextBox()
        TxtXMax = New TextBox()
        LblXMax = New Label()
        TxtDeltaX = New TextBox()
        LblDeltaX = New Label()
        TxtDeltaY = New TextBox()
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
        OptShadowed = New RadioButton()
        OptBright = New RadioButton()
        BtnStart = New Button()
        LblSteps = New Label()
        LblTime = New Label()
        TxtSteps = New TextBox()
        TxtTime = New TextBox()
        CType(PicCPlane, ComponentModel.ISupportInitialize).BeginInit()
        GrpMixing.SuspendLayout()
        GrpColor.SuspendLayout()
        SuspendLayout()
        ' 
        ' PicCPlane
        ' 
        PicCPlane.Location = New Point(2, 12)
        PicCPlane.Margin = New Padding(4, 5, 4, 5)
        PicCPlane.Name = "PicCPlane"
        PicCPlane.Size = New Size(1398, 1588)
        PicCPlane.TabIndex = 0
        PicCPlane.TabStop = False
        ' 
        ' CboFunction
        ' 
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"z^3-1", "z^4-1"})
        CboFunction.Location = New Point(1465, 12)
        CboFunction.Margin = New Padding(4, 5, 4, 5)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(456, 40)
        CboFunction.TabIndex = 1
        ' 
        ' LblXMin
        ' 
        LblXMin.AutoSize = True
        LblXMin.Location = New Point(1460, 137)
        LblXMin.Margin = New Padding(4, 0, 4, 0)
        LblXMin.Name = "LblXMin"
        LblXMin.Size = New Size(70, 32)
        LblXMin.TabIndex = 3
        LblXMin.Text = "XMin"
        ' 
        ' TxtXMin
        ' 
        TxtXMin.Location = New Point(1560, 130)
        TxtXMin.Margin = New Padding(4, 5, 4, 5)
        TxtXMin.Name = "TxtXMin"
        TxtXMin.Size = New Size(494, 39)
        TxtXMin.TabIndex = 4
        ' 
        ' TxtXMax
        ' 
        TxtXMax.Location = New Point(1560, 191)
        TxtXMax.Margin = New Padding(4, 5, 4, 5)
        TxtXMax.Name = "TxtXMax"
        TxtXMax.Size = New Size(494, 39)
        TxtXMax.TabIndex = 6
        ' 
        ' LblXMax
        ' 
        LblXMax.AutoSize = True
        LblXMax.Location = New Point(1460, 199)
        LblXMax.Margin = New Padding(4, 0, 4, 0)
        LblXMax.Name = "LblXMax"
        LblXMax.Size = New Size(73, 32)
        LblXMax.TabIndex = 5
        LblXMax.Text = "XMax"
        ' 
        ' TxtDeltaX
        ' 
        TxtDeltaX.Location = New Point(1560, 255)
        TxtDeltaX.Margin = New Padding(4, 5, 4, 5)
        TxtDeltaX.Name = "TxtDeltaX"
        TxtDeltaX.Size = New Size(494, 39)
        TxtDeltaX.TabIndex = 8
        ' 
        ' LblDeltaX
        ' 
        LblDeltaX.AutoSize = True
        LblDeltaX.Location = New Point(1460, 265)
        LblDeltaX.Margin = New Padding(4, 0, 4, 0)
        LblDeltaX.Name = "LblDeltaX"
        LblDeltaX.Size = New Size(84, 32)
        LblDeltaX.TabIndex = 7
        LblDeltaX.Text = "DeltaX"
        ' 
        ' TxtDeltaY
        ' 
        TxtDeltaY.Location = New Point(1560, 444)
        TxtDeltaY.Margin = New Padding(4, 5, 4, 5)
        TxtDeltaY.Name = "TxtDeltaY"
        TxtDeltaY.Size = New Size(494, 39)
        TxtDeltaY.TabIndex = 14
        ' 
        ' LblDeltaY
        ' 
        LblDeltaY.AutoSize = True
        LblDeltaY.Location = New Point(1460, 452)
        LblDeltaY.Margin = New Padding(4, 0, 4, 0)
        LblDeltaY.Name = "LblDeltaY"
        LblDeltaY.Size = New Size(83, 32)
        LblDeltaY.TabIndex = 13
        LblDeltaY.Text = "DeltaY"
        ' 
        ' TxtYMax
        ' 
        TxtYMax.Location = New Point(1560, 380)
        TxtYMax.Margin = New Padding(4, 5, 4, 5)
        TxtYMax.Name = "TxtYMax"
        TxtYMax.Size = New Size(494, 39)
        TxtYMax.TabIndex = 12
        ' 
        ' LblYMax
        ' 
        LblYMax.AutoSize = True
        LblYMax.Location = New Point(1460, 388)
        LblYMax.Margin = New Padding(4, 0, 4, 0)
        LblYMax.Name = "LblYMax"
        LblYMax.Size = New Size(72, 32)
        LblYMax.TabIndex = 11
        LblYMax.Text = "YMax"
        ' 
        ' TxtYMin
        ' 
        TxtYMin.Location = New Point(1560, 319)
        TxtYMin.Margin = New Padding(4, 5, 4, 5)
        TxtYMin.Name = "TxtYMin"
        TxtYMin.Size = New Size(494, 39)
        TxtYMin.TabIndex = 10
        ' 
        ' LblYMin
        ' 
        LblYMin.AutoSize = True
        LblYMin.Location = New Point(1460, 326)
        LblYMin.Margin = New Padding(4, 0, 4, 0)
        LblYMin.Name = "LblYMin"
        LblYMin.Size = New Size(69, 32)
        LblYMin.TabIndex = 9
        LblYMin.Text = "YMin"
        ' 
        ' BtnReset
        ' 
        BtnReset.Location = New Point(1460, 1526)
        BtnReset.Margin = New Padding(4, 5, 4, 5)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(594, 74)
        BtnReset.TabIndex = 21
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStop
        ' 
        BtnStop.Location = New Point(1460, 917)
        BtnStop.Margin = New Padding(4, 5, 4, 5)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(594, 74)
        BtnStop.TabIndex = 24
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' LstProtocol
        ' 
        LstProtocol.FormattingEnabled = True
        LstProtocol.HorizontalScrollbar = True
        LstProtocol.Location = New Point(1460, 1064)
        LstProtocol.Margin = New Padding(4, 5, 4, 5)
        LstProtocol.Name = "LstProtocol"
        LstProtocol.Size = New Size(594, 452)
        LstProtocol.TabIndex = 25
        ' 
        ' LblProtocol
        ' 
        LblProtocol.AutoSize = True
        LblProtocol.Location = New Point(1460, 1015)
        LblProtocol.Margin = New Padding(4, 0, 4, 0)
        LblProtocol.Name = "LblProtocol"
        LblProtocol.Size = New Size(102, 32)
        LblProtocol.TabIndex = 26
        LblProtocol.Text = "Protocol"
        ' 
        ' CboN
        ' 
        CboN.FormattingEnabled = True
        CboN.Items.AddRange(New Object() {"2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        CboN.Location = New Point(1985, 12)
        CboN.Name = "CboN"
        CboN.Size = New Size(69, 40)
        CboN.TabIndex = 27
        ' 
        ' TxtB
        ' 
        TxtB.Location = New Point(1746, 74)
        TxtB.Name = "TxtB"
        TxtB.Size = New Size(130, 39)
        TxtB.TabIndex = 28
        TxtB.Text = "1"
        ' 
        ' TxtA
        ' 
        TxtA.Location = New Point(1560, 73)
        TxtA.Name = "TxtA"
        TxtA.Size = New Size(130, 39)
        TxtA.TabIndex = 30
        TxtA.Text = "0"
        ' 
        ' LblC
        ' 
        LblC.AutoSize = True
        LblC.Location = New Point(1468, 77)
        LblC.Name = "LblC"
        LblC.Size = New Size(48, 32)
        LblC.TabIndex = 31
        LblC.Text = "c ="
        ' 
        ' LblI
        ' 
        LblI.AutoSize = True
        LblI.Location = New Point(1697, 76)
        LblI.Name = "LblI"
        LblI.Size = New Size(43, 32)
        LblI.TabIndex = 33
        LblI.Text = "+ i"
        ' 
        ' ChkProtocol
        ' 
        ChkProtocol.AutoSize = True
        ChkProtocol.Location = New Point(1879, 1013)
        ChkProtocol.Name = "ChkProtocol"
        ChkProtocol.Size = New Size(134, 36)
        ChkProtocol.TabIndex = 38
        ChkProtocol.Text = "Protocol"
        ChkProtocol.UseVisualStyleBackColor = True
        ' 
        ' LblPower
        ' 
        LblPower.AutoSize = True
        LblPower.Location = New Point(1928, 15)
        LblPower.Name = "LblPower"
        LblPower.Size = New Size(51, 32)
        LblPower.TabIndex = 39
        LblPower.Text = "n ="
        ' 
        ' GrpMixing
        ' 
        GrpMixing.Controls.Add(OptRotate)
        GrpMixing.Controls.Add(OptConjugate)
        GrpMixing.Controls.Add(OptNone)
        GrpMixing.Location = New Point(1468, 513)
        GrpMixing.Name = "GrpMixing"
        GrpMixing.Size = New Size(313, 212)
        GrpMixing.TabIndex = 40
        GrpMixing.TabStop = False
        GrpMixing.Text = "Mixing"
        ' 
        ' OptRotate
        ' 
        OptRotate.AutoSize = True
        OptRotate.Location = New Point(32, 157)
        OptRotate.Name = "OptRotate"
        OptRotate.Size = New Size(113, 36)
        OptRotate.TabIndex = 2
        OptRotate.Text = "Rotate"
        OptRotate.UseVisualStyleBackColor = True
        ' 
        ' OptConjugate
        ' 
        OptConjugate.AutoSize = True
        OptConjugate.Location = New Point(34, 103)
        OptConjugate.Name = "OptConjugate"
        OptConjugate.Size = New Size(155, 36)
        OptConjugate.TabIndex = 1
        OptConjugate.Text = "Conjugate"
        OptConjugate.UseVisualStyleBackColor = True
        ' 
        ' OptNone
        ' 
        OptNone.AutoSize = True
        OptNone.Checked = True
        OptNone.Location = New Point(34, 48)
        OptNone.Name = "OptNone"
        OptNone.Size = New Size(104, 36)
        OptNone.TabIndex = 0
        OptNone.TabStop = True
        OptNone.Text = "None"
        OptNone.UseVisualStyleBackColor = True
        ' 
        ' GrpColor
        ' 
        GrpColor.Controls.Add(OptShadowed)
        GrpColor.Controls.Add(OptBright)
        GrpColor.Location = New Point(1787, 513)
        GrpColor.Name = "GrpColor"
        GrpColor.Size = New Size(267, 212)
        GrpColor.TabIndex = 41
        GrpColor.TabStop = False
        GrpColor.Text = "Color"
        ' 
        ' OptShadowed
        ' 
        OptShadowed.AutoSize = True
        OptShadowed.Location = New Point(17, 117)
        OptShadowed.Name = "OptShadowed"
        OptShadowed.Size = New Size(156, 36)
        OptShadowed.TabIndex = 1
        OptShadowed.Text = "Shadowed"
        OptShadowed.UseVisualStyleBackColor = True
        ' 
        ' OptBright
        ' 
        OptBright.AutoSize = True
        OptBright.Checked = True
        OptBright.Location = New Point(17, 57)
        OptBright.Name = "OptBright"
        OptBright.Size = New Size(109, 36)
        OptBright.TabIndex = 0
        OptBright.TabStop = True
        OptBright.Text = "Bright"
        OptBright.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Location = New Point(1460, 818)
        BtnStart.Margin = New Padding(4, 5, 4, 5)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(594, 74)
        BtnStart.TabIndex = 20
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Location = New Point(1462, 759)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(71, 32)
        LblSteps.TabIndex = 34
        LblSteps.Text = "Steps"
        ' 
        ' LblTime
        ' 
        LblTime.AutoSize = True
        LblTime.Location = New Point(1748, 759)
        LblTime.Name = "LblTime"
        LblTime.Size = New Size(67, 32)
        LblTime.TabIndex = 35
        LblTime.Text = "Time"
        ' 
        ' TxtSteps
        ' 
        TxtSteps.Location = New Point(1560, 752)
        TxtSteps.Name = "TxtSteps"
        TxtSteps.Size = New Size(187, 39)
        TxtSteps.TabIndex = 36
        ' 
        ' TxtTime
        ' 
        TxtTime.Location = New Point(1821, 752)
        TxtTime.Name = "TxtTime"
        TxtTime.Size = New Size(233, 39)
        TxtTime.TabIndex = 37
        ' 
        ' FrmNewtonIteration
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(2091, 1612)
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
        Margin = New Padding(4, 5, 4, 5)
        Name = "FrmNewtonIteration"
        Text = "NewtonIteration"
        WindowState = FormWindowState.Maximized
        CType(PicCPlane, ComponentModel.ISupportInitialize).EndInit()
        GrpMixing.ResumeLayout(False)
        GrpMixing.PerformLayout()
        GrpColor.ResumeLayout(False)
        GrpColor.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents PicCPlane As PictureBox
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
    Friend WithEvents OptShadowed As RadioButton
    Friend WithEvents OptBright As RadioButton
End Class
