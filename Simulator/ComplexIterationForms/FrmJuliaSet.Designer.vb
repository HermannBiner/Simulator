<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmJuliaSet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmJuliaSet))
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
        CType(PicCPlane, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbRed, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbGreen, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbBlue, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicBright, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicDark, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PicCPlane
        ' 
        PicCPlane.Location = New Point(2, 0)
        PicCPlane.Margin = New Padding(2, 2, 2, 2)
        PicCPlane.Name = "PicCPlane"
        PicCPlane.Size = New Size(753, 744)
        PicCPlane.TabIndex = 1
        PicCPlane.TabStop = False
        ' 
        ' TxtTime
        ' 
        TxtTime.Location = New Point(969, 417)
        TxtTime.Margin = New Padding(2, 1, 2, 1)
        TxtTime.Name = "TxtTime"
        TxtTime.Size = New Size(130, 23)
        TxtTime.TabIndex = 62
        ' 
        ' TxtSteps
        ' 
        TxtSteps.Location = New Point(823, 417)
        TxtSteps.Margin = New Padding(2, 1, 2, 1)
        TxtSteps.Name = "TxtSteps"
        TxtSteps.Size = New Size(105, 23)
        TxtSteps.TabIndex = 61
        ' 
        ' LblTime
        ' 
        LblTime.AutoSize = True
        LblTime.Location = New Point(929, 420)
        LblTime.Margin = New Padding(2, 0, 2, 0)
        LblTime.Name = "LblTime"
        LblTime.Size = New Size(33, 15)
        LblTime.TabIndex = 60
        LblTime.Text = "Time"
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Location = New Point(781, 420)
        LblSteps.Margin = New Padding(2, 0, 2, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(35, 15)
        LblSteps.TabIndex = 59
        LblSteps.Text = "Steps"
        ' 
        ' LblI
        ' 
        LblI.AutoSize = True
        LblI.Location = New Point(951, 42)
        LblI.Margin = New Padding(2, 0, 2, 0)
        LblI.Name = "LblI"
        LblI.Size = New Size(21, 15)
        LblI.TabIndex = 58
        LblI.Text = "+ i"
        ' 
        ' LblC
        ' 
        LblC.AutoSize = True
        LblC.Location = New Point(781, 41)
        LblC.Margin = New Padding(2, 0, 2, 0)
        LblC.Name = "LblC"
        LblC.Size = New Size(24, 15)
        LblC.TabIndex = 57
        LblC.Text = "c ="
        ' 
        ' TxtA
        ' 
        TxtA.Location = New Point(831, 39)
        TxtA.Margin = New Padding(2, 1, 2, 1)
        TxtA.Name = "TxtA"
        TxtA.Size = New Size(117, 23)
        TxtA.TabIndex = 56
        TxtA.Text = "0"
        ' 
        ' TxtB
        ' 
        TxtB.Location = New Point(982, 39)
        TxtB.Margin = New Padding(2, 1, 2, 1)
        TxtB.Name = "TxtB"
        TxtB.Size = New Size(117, 23)
        TxtB.TabIndex = 55
        TxtB.Text = "0"
        ' 
        ' BtnStop
        ' 
        BtnStop.Location = New Point(777, 504)
        BtnStop.Margin = New Padding(2, 2, 2, 2)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(320, 35)
        BtnStop.TabIndex = 54
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Location = New Point(777, 458)
        BtnStart.Margin = New Padding(2, 2, 2, 2)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(320, 35)
        BtnStart.TabIndex = 53
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' TxtDeltaY
        ' 
        TxtDeltaY.Location = New Point(831, 224)
        TxtDeltaY.Margin = New Padding(2, 2, 2, 2)
        TxtDeltaY.Name = "TxtDeltaY"
        TxtDeltaY.Size = New Size(268, 23)
        TxtDeltaY.TabIndex = 50
        ' 
        ' LblDeltaY
        ' 
        LblDeltaY.AutoSize = True
        LblDeltaY.Location = New Point(777, 227)
        LblDeltaY.Margin = New Padding(2, 0, 2, 0)
        LblDeltaY.Name = "LblDeltaY"
        LblDeltaY.Size = New Size(41, 15)
        LblDeltaY.TabIndex = 49
        LblDeltaY.Text = "DeltaY"
        ' 
        ' TxtYMax
        ' 
        TxtYMax.Location = New Point(831, 194)
        TxtYMax.Margin = New Padding(2, 2, 2, 2)
        TxtYMax.Name = "TxtYMax"
        TxtYMax.Size = New Size(268, 23)
        TxtYMax.TabIndex = 48
        ' 
        ' LblYMax
        ' 
        LblYMax.AutoSize = True
        LblYMax.Location = New Point(777, 197)
        LblYMax.Margin = New Padding(2, 0, 2, 0)
        LblYMax.Name = "LblYMax"
        LblYMax.Size = New Size(37, 15)
        LblYMax.TabIndex = 47
        LblYMax.Text = "YMax"
        ' 
        ' TxtYMin
        ' 
        TxtYMin.Location = New Point(831, 165)
        TxtYMin.Margin = New Padding(2, 2, 2, 2)
        TxtYMin.Name = "TxtYMin"
        TxtYMin.Size = New Size(268, 23)
        TxtYMin.TabIndex = 46
        ' 
        ' LblYMin
        ' 
        LblYMin.AutoSize = True
        LblYMin.Location = New Point(777, 168)
        LblYMin.Margin = New Padding(2, 0, 2, 0)
        LblYMin.Name = "LblYMin"
        LblYMin.Size = New Size(35, 15)
        LblYMin.TabIndex = 45
        LblYMin.Text = "YMin"
        ' 
        ' TxtDeltaX
        ' 
        TxtDeltaX.Location = New Point(831, 131)
        TxtDeltaX.Margin = New Padding(2, 2, 2, 2)
        TxtDeltaX.Name = "TxtDeltaX"
        TxtDeltaX.Size = New Size(268, 23)
        TxtDeltaX.TabIndex = 44
        ' 
        ' LblDeltaX
        ' 
        LblDeltaX.AutoSize = True
        LblDeltaX.Location = New Point(777, 136)
        LblDeltaX.Margin = New Padding(2, 0, 2, 0)
        LblDeltaX.Name = "LblDeltaX"
        LblDeltaX.Size = New Size(41, 15)
        LblDeltaX.TabIndex = 43
        LblDeltaX.Text = "DeltaX"
        ' 
        ' TxtXMax
        ' 
        TxtXMax.Location = New Point(831, 101)
        TxtXMax.Margin = New Padding(2, 2, 2, 2)
        TxtXMax.Name = "TxtXMax"
        TxtXMax.Size = New Size(268, 23)
        TxtXMax.TabIndex = 42
        ' 
        ' LblXMax
        ' 
        LblXMax.AutoSize = True
        LblXMax.Location = New Point(777, 105)
        LblXMax.Margin = New Padding(2, 0, 2, 0)
        LblXMax.Name = "LblXMax"
        LblXMax.Size = New Size(37, 15)
        LblXMax.TabIndex = 41
        LblXMax.Text = "XMax"
        ' 
        ' TxtXMin
        ' 
        TxtXMin.Location = New Point(831, 73)
        TxtXMin.Margin = New Padding(2, 2, 2, 2)
        TxtXMin.Name = "TxtXMin"
        TxtXMin.Size = New Size(268, 23)
        TxtXMin.TabIndex = 40
        ' 
        ' LblXMin
        ' 
        LblXMin.AutoSize = True
        LblXMin.Location = New Point(777, 76)
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
        CboFunction.Location = New Point(780, 7)
        CboFunction.Margin = New Padding(2, 2, 2, 2)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(247, 23)
        CboFunction.TabIndex = 38
        ' 
        ' BtnReset
        ' 
        BtnReset.Location = New Point(777, 710)
        BtnReset.Margin = New Padding(2, 2, 2, 2)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(320, 35)
        BtnReset.TabIndex = 63
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' ChkProtocol
        ' 
        ChkProtocol.AutoSize = True
        ChkProtocol.Location = New Point(1025, 543)
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
        LblProtocol.Location = New Point(781, 545)
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
        LstProtocol.Location = New Point(777, 563)
        LstProtocol.Margin = New Padding(2, 2, 2, 2)
        LstProtocol.Name = "LstProtocol"
        LstProtocol.Size = New Size(322, 139)
        LstProtocol.TabIndex = 64
        ' 
        ' LblPower
        ' 
        LblPower.AutoSize = True
        LblPower.Location = New Point(1029, 8)
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
        CboN.Location = New Point(1060, 7)
        CboN.Margin = New Padding(2, 1, 2, 1)
        CboN.Name = "CboN"
        CboN.Size = New Size(39, 23)
        CboN.TabIndex = 67
        ' 
        ' TrbRed
        ' 
        TrbRed.BackColor = SystemColors.Control
        TrbRed.Location = New Point(781, 260)
        TrbRed.Margin = New Padding(2, 1, 2, 1)
        TrbRed.Name = "TrbRed"
        TrbRed.Size = New Size(219, 45)
        TrbRed.TabIndex = 69
        ' 
        ' TrbGreen
        ' 
        TrbGreen.BackColor = SystemColors.Control
        TrbGreen.Location = New Point(781, 314)
        TrbGreen.Margin = New Padding(2, 1, 2, 1)
        TrbGreen.Name = "TrbGreen"
        TrbGreen.Size = New Size(219, 45)
        TrbGreen.TabIndex = 70
        TrbGreen.Value = 10
        ' 
        ' TrbBlue
        ' 
        TrbBlue.BackColor = SystemColors.Control
        TrbBlue.Location = New Point(781, 365)
        TrbBlue.Margin = New Padding(2, 1, 2, 1)
        TrbBlue.Name = "TrbBlue"
        TrbBlue.Size = New Size(219, 45)
        TrbBlue.TabIndex = 71
        TrbBlue.Value = 2
        ' 
        ' PicBright
        ' 
        PicBright.Location = New Point(1023, 260)
        PicBright.Margin = New Padding(2, 1, 2, 1)
        PicBright.Name = "PicBright"
        PicBright.Size = New Size(74, 73)
        PicBright.TabIndex = 72
        PicBright.TabStop = False
        ' 
        ' PicDark
        ' 
        PicDark.Location = New Point(1023, 338)
        PicDark.Margin = New Padding(2, 1, 2, 1)
        PicDark.Name = "PicDark"
        PicDark.Size = New Size(74, 73)
        PicDark.TabIndex = 73
        PicDark.TabStop = False
        ' 
        ' FrmJuliaSet
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1126, 666)
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
        Margin = New Padding(2, 1, 2, 1)
        Name = "FrmJuliaSet"
        Text = "JuliaSet"
        WindowState = FormWindowState.Maximized
        CType(PicCPlane, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbRed, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbGreen, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbBlue, ComponentModel.ISupportInitialize).EndInit()
        CType(PicBright, ComponentModel.ISupportInitialize).EndInit()
        CType(PicDark, ComponentModel.ISupportInitialize).EndInit()
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
End Class
