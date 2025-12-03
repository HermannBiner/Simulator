<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPendulum
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPendulum))
        SplitContainer1 = New SplitContainer()
        PicDiagram = New PictureBox()
        SplitContainer2 = New SplitContainer()
        BtnCreatePendulum = New Button()
        BtnDefault = New Button()
        BtnStop = New Button()
        LblTypeofPhaseportrait = New Label()
        CboTypeofPhaseportrait = New ComboBox()
        LblStepWidth = New Label()
        TrbStepWidth = New TrackBar()
        LblSteps = New Label()
        LblNumberOfSteps = New Label()
        BtnReset = New Button()
        BtnStart = New Button()
        CboPendulum = New ComboBox()
        GrpStartParameter = New GroupBox()
        TxtP6 = New TextBox()
        LblP6 = New Label()
        TxtP5 = New TextBox()
        LblP5 = New Label()
        TxtP4 = New TextBox()
        TxtP3 = New TextBox()
        LblP4 = New Label()
        LblP3 = New Label()
        BtnTakeOverStartParameter = New Button()
        TxtP2 = New TextBox()
        TxtP1 = New TextBox()
        LblP2 = New Label()
        LblP1 = New Label()
        LblAdditionalParameter = New Label()
        TrbAdditionalParameter = New TrackBar()
        ChkProtocol = New CheckBox()
        LblProtocol = New Label()
        PicEnergy = New PictureBox()
        LstProtocol = New ListBox()
        LblPhasePortrait = New Label()
        PicPhasePortrait = New PictureBox()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        CType(SplitContainer2, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer2.Panel1.SuspendLayout()
        SplitContainer2.Panel2.SuspendLayout()
        SplitContainer2.SuspendLayout()
        CType(TrbStepWidth, ComponentModel.ISupportInitialize).BeginInit()
        GrpStartParameter.SuspendLayout()
        CType(TrbAdditionalParameter, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicEnergy, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicPhasePortrait, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.FixedPanel = FixedPanel.Panel2
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(PicDiagram)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(SplitContainer2)
        SplitContainer1.Size = New Size(1180, 612)
        SplitContainer1.SplitterDistance = 603
        SplitContainer1.SplitterWidth = 6
        SplitContainer1.TabIndex = 0
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(4, 4)
        PicDiagram.Margin = New Padding(4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(600, 600)
        PicDiagram.TabIndex = 29
        PicDiagram.TabStop = False
        ' 
        ' SplitContainer2
        ' 
        SplitContainer2.Dock = DockStyle.Fill
        SplitContainer2.Location = New Point(0, 0)
        SplitContainer2.Name = "SplitContainer2"
        ' 
        ' SplitContainer2.Panel1
        ' 
        SplitContainer2.Panel1.Controls.Add(BtnCreatePendulum)
        SplitContainer2.Panel1.Controls.Add(BtnDefault)
        SplitContainer2.Panel1.Controls.Add(BtnStop)
        SplitContainer2.Panel1.Controls.Add(LblTypeofPhaseportrait)
        SplitContainer2.Panel1.Controls.Add(CboTypeofPhaseportrait)
        SplitContainer2.Panel1.Controls.Add(LblStepWidth)
        SplitContainer2.Panel1.Controls.Add(TrbStepWidth)
        SplitContainer2.Panel1.Controls.Add(LblSteps)
        SplitContainer2.Panel1.Controls.Add(LblNumberOfSteps)
        SplitContainer2.Panel1.Controls.Add(BtnReset)
        SplitContainer2.Panel1.Controls.Add(BtnStart)
        SplitContainer2.Panel1.Controls.Add(CboPendulum)
        SplitContainer2.Panel1.Controls.Add(GrpStartParameter)
        SplitContainer2.Panel1.Controls.Add(LblAdditionalParameter)
        SplitContainer2.Panel1.Controls.Add(TrbAdditionalParameter)
        ' 
        ' SplitContainer2.Panel2
        ' 
        SplitContainer2.Panel2.Controls.Add(ChkProtocol)
        SplitContainer2.Panel2.Controls.Add(LblProtocol)
        SplitContainer2.Panel2.Controls.Add(PicEnergy)
        SplitContainer2.Panel2.Controls.Add(LstProtocol)
        SplitContainer2.Panel2.Controls.Add(LblPhasePortrait)
        SplitContainer2.Panel2.Controls.Add(PicPhasePortrait)
        SplitContainer2.Size = New Size(571, 612)
        SplitContainer2.SplitterDistance = 233
        SplitContainer2.TabIndex = 0
        ' 
        ' BtnCreatePendulum
        ' 
        BtnCreatePendulum.Font = New Font("Microsoft Sans Serif", 9F)
        BtnCreatePendulum.Location = New Point(13, 453)
        BtnCreatePendulum.Margin = New Padding(4)
        BtnCreatePendulum.Name = "BtnCreatePendulum"
        BtnCreatePendulum.Size = New Size(213, 30)
        BtnCreatePendulum.TabIndex = 79
        BtnCreatePendulum.Text = "CreatePendulum"
        BtnCreatePendulum.UseVisualStyleBackColor = True
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(13, 539)
        BtnDefault.Margin = New Padding(6, 8, 6, 8)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(213, 30)
        BtnDefault.TabIndex = 78
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' BtnStop
        ' 
        BtnStop.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStop.Location = New Point(121, 506)
        BtnStop.Margin = New Padding(4)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(105, 30)
        BtnStop.TabIndex = 77
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' LblTypeofPhaseportrait
        ' 
        LblTypeofPhaseportrait.AutoSize = True
        LblTypeofPhaseportrait.Font = New Font("Microsoft Sans Serif", 9F)
        LblTypeofPhaseportrait.Location = New Point(21, 403)
        LblTypeofPhaseportrait.Margin = New Padding(4, 0, 4, 0)
        LblTypeofPhaseportrait.Name = "LblTypeofPhaseportrait"
        LblTypeofPhaseportrait.Size = New Size(116, 15)
        LblTypeofPhaseportrait.TabIndex = 76
        LblTypeofPhaseportrait.Text = "TypeofPhaseportrait"
        ' 
        ' CboTypeofPhaseportrait
        ' 
        CboTypeofPhaseportrait.DropDownStyle = ComboBoxStyle.DropDownList
        CboTypeofPhaseportrait.Font = New Font("Microsoft Sans Serif", 9F)
        CboTypeofPhaseportrait.FormattingEnabled = True
        CboTypeofPhaseportrait.Items.AddRange(New Object() {"Independent", "PoincareSection"})
        CboTypeofPhaseportrait.Location = New Point(13, 425)
        CboTypeofPhaseportrait.Margin = New Padding(6, 8, 6, 8)
        CboTypeofPhaseportrait.Name = "CboTypeofPhaseportrait"
        CboTypeofPhaseportrait.Size = New Size(213, 23)
        CboTypeofPhaseportrait.TabIndex = 75
        ' 
        ' LblStepWidth
        ' 
        LblStepWidth.AutoSize = True
        LblStepWidth.Font = New Font("Microsoft Sans Serif", 9F)
        LblStepWidth.Location = New Point(13, 332)
        LblStepWidth.Margin = New Padding(4, 0, 4, 0)
        LblStepWidth.Name = "LblStepWidth"
        LblStepWidth.Size = New Size(63, 15)
        LblStepWidth.TabIndex = 74
        LblStepWidth.Text = "StepWidth"
        ' 
        ' TrbStepWidth
        ' 
        TrbStepWidth.Location = New Point(13, 354)
        TrbStepWidth.Margin = New Padding(4)
        TrbStepWidth.Maximum = 20
        TrbStepWidth.Minimum = 1
        TrbStepWidth.Name = "TrbStepWidth"
        TrbStepWidth.Size = New Size(213, 45)
        TrbStepWidth.TabIndex = 73
        TrbStepWidth.Value = 10
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblSteps.Location = New Point(118, 487)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(14, 15)
        LblSteps.TabIndex = 72
        LblSteps.Text = "0"
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblNumberOfSteps.Location = New Point(13, 487)
        LblNumberOfSteps.Margin = New Padding(4, 0, 4, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(102, 15)
        LblNumberOfSteps.TabIndex = 71
        LblNumberOfSteps.Text = "Number of Steps:"
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(13, 573)
        BtnReset.Margin = New Padding(6, 8, 6, 8)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(213, 30)
        BtnReset.TabIndex = 70
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStart.Location = New Point(13, 506)
        BtnStart.Margin = New Padding(4)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(105, 30)
        BtnStart.TabIndex = 69
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' CboPendulum
        ' 
        CboPendulum.DropDownStyle = ComboBoxStyle.DropDownList
        CboPendulum.Font = New Font("Microsoft Sans Serif", 9F)
        CboPendulum.FormattingEnabled = True
        CboPendulum.Items.AddRange(New Object() {"DoublePendulum", "CombiPendulum", "ShakePendulum"})
        CboPendulum.Location = New Point(15, 4)
        CboPendulum.Margin = New Padding(4)
        CboPendulum.Name = "CboPendulum"
        CboPendulum.Size = New Size(205, 23)
        CboPendulum.TabIndex = 42
        ' 
        ' GrpStartParameter
        ' 
        GrpStartParameter.Controls.Add(TxtP6)
        GrpStartParameter.Controls.Add(LblP6)
        GrpStartParameter.Controls.Add(TxtP5)
        GrpStartParameter.Controls.Add(LblP5)
        GrpStartParameter.Controls.Add(TxtP4)
        GrpStartParameter.Controls.Add(TxtP3)
        GrpStartParameter.Controls.Add(LblP4)
        GrpStartParameter.Controls.Add(LblP3)
        GrpStartParameter.Controls.Add(BtnTakeOverStartParameter)
        GrpStartParameter.Controls.Add(TxtP2)
        GrpStartParameter.Controls.Add(TxtP1)
        GrpStartParameter.Controls.Add(LblP2)
        GrpStartParameter.Controls.Add(LblP1)
        GrpStartParameter.Font = New Font("Microsoft Sans Serif", 9F)
        GrpStartParameter.Location = New Point(7, 94)
        GrpStartParameter.Margin = New Padding(4)
        GrpStartParameter.Name = "GrpStartParameter"
        GrpStartParameter.Padding = New Padding(4)
        GrpStartParameter.Size = New Size(213, 239)
        GrpStartParameter.TabIndex = 41
        GrpStartParameter.TabStop = False
        GrpStartParameter.Text = "StartParameter"
        ' 
        ' TxtP6
        ' 
        TxtP6.Location = New Point(38, 167)
        TxtP6.Margin = New Padding(4)
        TxtP6.Name = "TxtP6"
        TxtP6.Size = New Size(158, 21)
        TxtP6.TabIndex = 12
        TxtP6.Visible = False
        ' 
        ' LblP6
        ' 
        LblP6.AutoSize = True
        LblP6.Location = New Point(9, 171)
        LblP6.Margin = New Padding(4, 0, 4, 0)
        LblP6.Name = "LblP6"
        LblP6.Size = New Size(22, 15)
        LblP6.TabIndex = 11
        LblP6.Text = "P6"
        LblP6.Visible = False
        ' 
        ' TxtP5
        ' 
        TxtP5.Location = New Point(38, 138)
        TxtP5.Margin = New Padding(4)
        TxtP5.Name = "TxtP5"
        TxtP5.Size = New Size(158, 21)
        TxtP5.TabIndex = 10
        TxtP5.Visible = False
        ' 
        ' LblP5
        ' 
        LblP5.AutoSize = True
        LblP5.Location = New Point(9, 142)
        LblP5.Margin = New Padding(4, 0, 4, 0)
        LblP5.Name = "LblP5"
        LblP5.Size = New Size(22, 15)
        LblP5.TabIndex = 9
        LblP5.Text = "P5"
        LblP5.Visible = False
        ' 
        ' TxtP4
        ' 
        TxtP4.Location = New Point(38, 109)
        TxtP4.Margin = New Padding(4)
        TxtP4.Name = "TxtP4"
        TxtP4.Size = New Size(158, 21)
        TxtP4.TabIndex = 8
        TxtP4.Visible = False
        ' 
        ' TxtP3
        ' 
        TxtP3.Location = New Point(38, 80)
        TxtP3.Margin = New Padding(4)
        TxtP3.Name = "TxtP3"
        TxtP3.Size = New Size(158, 21)
        TxtP3.TabIndex = 7
        TxtP3.Visible = False
        ' 
        ' LblP4
        ' 
        LblP4.AutoSize = True
        LblP4.Location = New Point(9, 113)
        LblP4.Margin = New Padding(4, 0, 4, 0)
        LblP4.Name = "LblP4"
        LblP4.Size = New Size(22, 15)
        LblP4.TabIndex = 6
        LblP4.Text = "P4"
        LblP4.Visible = False
        ' 
        ' LblP3
        ' 
        LblP3.AutoSize = True
        LblP3.Location = New Point(9, 84)
        LblP3.Margin = New Padding(4, 0, 4, 0)
        LblP3.Name = "LblP3"
        LblP3.Size = New Size(22, 15)
        LblP3.TabIndex = 5
        LblP3.Text = "P3"
        LblP3.Visible = False
        ' 
        ' BtnTakeOverStartParameter
        ' 
        BtnTakeOverStartParameter.Location = New Point(8, 196)
        BtnTakeOverStartParameter.Margin = New Padding(4)
        BtnTakeOverStartParameter.Name = "BtnTakeOverStartParameter"
        BtnTakeOverStartParameter.Size = New Size(188, 30)
        BtnTakeOverStartParameter.TabIndex = 4
        BtnTakeOverStartParameter.Text = "TakeOver"
        BtnTakeOverStartParameter.UseVisualStyleBackColor = True
        ' 
        ' TxtP2
        ' 
        TxtP2.Location = New Point(38, 51)
        TxtP2.Margin = New Padding(4)
        TxtP2.Name = "TxtP2"
        TxtP2.Size = New Size(158, 21)
        TxtP2.TabIndex = 3
        TxtP2.Visible = False
        ' 
        ' TxtP1
        ' 
        TxtP1.Location = New Point(38, 22)
        TxtP1.Margin = New Padding(4)
        TxtP1.Name = "TxtP1"
        TxtP1.Size = New Size(158, 21)
        TxtP1.TabIndex = 2
        TxtP1.Visible = False
        ' 
        ' LblP2
        ' 
        LblP2.AutoSize = True
        LblP2.Location = New Point(9, 55)
        LblP2.Margin = New Padding(4, 0, 4, 0)
        LblP2.Name = "LblP2"
        LblP2.Size = New Size(22, 15)
        LblP2.TabIndex = 1
        LblP2.Text = "P2"
        LblP2.Visible = False
        ' 
        ' LblP1
        ' 
        LblP1.AutoSize = True
        LblP1.Location = New Point(9, 23)
        LblP1.Margin = New Padding(4, 0, 4, 0)
        LblP1.Name = "LblP1"
        LblP1.Size = New Size(22, 15)
        LblP1.TabIndex = 0
        LblP1.Text = "P1"
        LblP1.Visible = False
        ' 
        ' LblAdditionalParameter
        ' 
        LblAdditionalParameter.AutoSize = True
        LblAdditionalParameter.Font = New Font("Microsoft Sans Serif", 9F)
        LblAdditionalParameter.Location = New Point(13, 29)
        LblAdditionalParameter.Margin = New Padding(4, 0, 4, 0)
        LblAdditionalParameter.Name = "LblAdditionalParameter"
        LblAdditionalParameter.Size = New Size(119, 15)
        LblAdditionalParameter.TabIndex = 40
        LblAdditionalParameter.Text = "AdditionalParameter"
        ' 
        ' TrbAdditionalParameter
        ' 
        TrbAdditionalParameter.LargeChange = 1
        TrbAdditionalParameter.Location = New Point(7, 47)
        TrbAdditionalParameter.Margin = New Padding(4)
        TrbAdditionalParameter.Maximum = 20
        TrbAdditionalParameter.Minimum = 1
        TrbAdditionalParameter.Name = "TrbAdditionalParameter"
        TrbAdditionalParameter.Size = New Size(213, 45)
        TrbAdditionalParameter.TabIndex = 39
        TrbAdditionalParameter.Value = 10
        ' 
        ' ChkProtocol
        ' 
        ChkProtocol.AutoSize = True
        ChkProtocol.Font = New Font("Microsoft Sans Serif", 9F)
        ChkProtocol.Location = New Point(242, 348)
        ChkProtocol.Margin = New Padding(4, 2, 4, 2)
        ChkProtocol.Name = "ChkProtocol"
        ChkProtocol.Size = New Size(71, 19)
        ChkProtocol.TabIndex = 73
        ChkProtocol.Text = "Protocol"
        ChkProtocol.UseVisualStyleBackColor = True
        ' 
        ' LblProtocol
        ' 
        LblProtocol.AutoSize = True
        LblProtocol.Font = New Font("Microsoft Sans Serif", 9F)
        LblProtocol.Location = New Point(6, 349)
        LblProtocol.Margin = New Padding(4, 0, 4, 0)
        LblProtocol.Name = "LblProtocol"
        LblProtocol.Size = New Size(52, 15)
        LblProtocol.TabIndex = 72
        LblProtocol.Text = "Protocol"
        LblProtocol.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PicEnergy
        ' 
        PicEnergy.BackColor = Color.White
        PicEnergy.Location = New Point(0, 578)
        PicEnergy.Margin = New Padding(4)
        PicEnergy.Name = "PicEnergy"
        PicEnergy.Size = New Size(320, 27)
        PicEnergy.TabIndex = 71
        PicEnergy.TabStop = False
        ' 
        ' LstProtocol
        ' 
        LstProtocol.Font = New Font("Microsoft Sans Serif", 9F)
        LstProtocol.FormattingEnabled = True
        LstProtocol.ItemHeight = 15
        LstProtocol.Location = New Point(1, 372)
        LstProtocol.Margin = New Padding(4)
        LstProtocol.Name = "LstProtocol"
        LstProtocol.Size = New Size(319, 199)
        LstProtocol.TabIndex = 70
        ' 
        ' LblPhasePortrait
        ' 
        LblPhasePortrait.AutoSize = True
        LblPhasePortrait.Font = New Font("Microsoft Sans Serif", 9F)
        LblPhasePortrait.Location = New Point(1, 6)
        LblPhasePortrait.Margin = New Padding(4, 0, 4, 0)
        LblPhasePortrait.Name = "LblPhasePortrait"
        LblPhasePortrait.Size = New Size(81, 15)
        LblPhasePortrait.TabIndex = 69
        LblPhasePortrait.Text = "PhasePortrait"
        LblPhasePortrait.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PicPhasePortrait
        ' 
        PicPhasePortrait.BackColor = Color.White
        PicPhasePortrait.Location = New Point(0, 25)
        PicPhasePortrait.Margin = New Padding(4)
        PicPhasePortrait.Name = "PicPhasePortrait"
        PicPhasePortrait.Size = New Size(320, 320)
        PicPhasePortrait.TabIndex = 68
        PicPhasePortrait.TabStop = False
        ' 
        ' FrmPendulum
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1180, 612)
        Controls.Add(SplitContainer1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimumSize = New Size(603, 651)
        Name = "FrmPendulum"
        StartPosition = FormStartPosition.WindowsDefaultBounds
        Text = "Pendulum"
        WindowState = FormWindowState.Maximized
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer2.Panel1.ResumeLayout(False)
        SplitContainer2.Panel1.PerformLayout()
        SplitContainer2.Panel2.ResumeLayout(False)
        SplitContainer2.Panel2.PerformLayout()
        CType(SplitContainer2, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer2.ResumeLayout(False)
        CType(TrbStepWidth, ComponentModel.ISupportInitialize).EndInit()
        GrpStartParameter.ResumeLayout(False)
        GrpStartParameter.PerformLayout()
        CType(TrbAdditionalParameter, ComponentModel.ISupportInitialize).EndInit()
        CType(PicEnergy, ComponentModel.ISupportInitialize).EndInit()
        CType(PicPhasePortrait, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents BtnCreatePendulum As Button
    Friend WithEvents BtnDefault As Button
    Friend WithEvents BtnStop As Button
    Friend WithEvents LblTypeofPhaseportrait As Label
    Friend WithEvents CboTypeofPhaseportrait As ComboBox
    Friend WithEvents LblStepWidth As Label
    Friend WithEvents TrbStepWidth As TrackBar
    Friend WithEvents LblSteps As Label
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents CboPendulum As ComboBox
    Friend WithEvents GrpStartParameter As GroupBox
    Friend WithEvents TxtP6 As TextBox
    Friend WithEvents LblP6 As Label
    Friend WithEvents TxtP5 As TextBox
    Friend WithEvents LblP5 As Label
    Friend WithEvents TxtP4 As TextBox
    Friend WithEvents TxtP3 As TextBox
    Friend WithEvents LblP4 As Label
    Friend WithEvents LblP3 As Label
    Friend WithEvents BtnTakeOverStartParameter As Button
    Friend WithEvents TxtP2 As TextBox
    Friend WithEvents TxtP1 As TextBox
    Friend WithEvents LblP2 As Label
    Friend WithEvents LblP1 As Label
    Friend WithEvents LblAdditionalParameter As Label
    Friend WithEvents TrbAdditionalParameter As TrackBar
    Friend WithEvents ChkProtocol As CheckBox
    Friend WithEvents LblProtocol As Label
    Friend WithEvents PicEnergy As PictureBox
    Friend WithEvents LstProtocol As ListBox
    Friend WithEvents LblPhasePortrait As Label
    Friend WithEvents PicPhasePortrait As PictureBox
End Class
