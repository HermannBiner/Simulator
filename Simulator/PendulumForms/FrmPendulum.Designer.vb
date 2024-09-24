<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPendulum
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPendulum))
        CboPendulum = New ComboBox()
        LblPendulum = New Label()
        LstProtocol = New ListBox()
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
        LblPhasePortrait = New Label()
        LblAdditionalParameter = New Label()
        TrbAdditionalParameter = New TrackBar()
        PicPhasePortrait = New PictureBox()
        PicDiagram = New PictureBox()
        LblSteps = New Label()
        LblNumberOfSteps = New Label()
        BtnReset = New Button()
        BtnStart = New Button()
        LblStepWidth = New Label()
        TrbStepWidth = New TrackBar()
        PicEnergy = New PictureBox()
        CboTypeofPhaseportrait = New ComboBox()
        LblTypeofPhaseportrait = New Label()
        LblProtocol = New Label()
        BtnStop = New Button()
        BtnDefault = New Button()
        GrpStartParameter.SuspendLayout()
        CType(TrbAdditionalParameter, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicPhasePortrait, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbStepWidth, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicEnergy, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' CboPendulum
        ' 
        CboPendulum.FormattingEnabled = True
        CboPendulum.Items.AddRange(New Object() {"DoublePendulum", "CombiPendulum", "ShakePendulum"})
        CboPendulum.Location = New Point(726, 22)
        CboPendulum.Margin = New Padding(2)
        CboPendulum.Name = "CboPendulum"
        CboPendulum.Size = New Size(226, 23)
        CboPendulum.TabIndex = 38
        ' 
        ' LblPendulum
        ' 
        LblPendulum.AutoSize = True
        LblPendulum.Location = New Point(724, 5)
        LblPendulum.Margin = New Padding(2, 0, 2, 0)
        LblPendulum.Name = "LblPendulum"
        LblPendulum.Size = New Size(62, 15)
        LblPendulum.TabIndex = 37
        LblPendulum.Text = "Pendulum"
        ' 
        ' LstProtocol
        ' 
        LstProtocol.FormattingEnabled = True
        LstProtocol.ItemHeight = 15
        LstProtocol.Location = New Point(973, 497)
        LstProtocol.Margin = New Padding(2)
        LstProtocol.Name = "LstProtocol"
        LstProtocol.Size = New Size(450, 184)
        LstProtocol.TabIndex = 36
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
        GrpStartParameter.Location = New Point(726, 124)
        GrpStartParameter.Margin = New Padding(2)
        GrpStartParameter.Name = "GrpStartParameter"
        GrpStartParameter.Padding = New Padding(2)
        GrpStartParameter.Size = New Size(228, 232)
        GrpStartParameter.TabIndex = 35
        GrpStartParameter.TabStop = False
        GrpStartParameter.Text = "StartParameter"
        ' 
        ' TxtP6
        ' 
        TxtP6.Location = New Point(49, 166)
        TxtP6.Margin = New Padding(2)
        TxtP6.Name = "TxtP6"
        TxtP6.Size = New Size(163, 23)
        TxtP6.TabIndex = 12
        TxtP6.Visible = False
        ' 
        ' LblP6
        ' 
        LblP6.AutoSize = True
        LblP6.Location = New Point(7, 170)
        LblP6.Margin = New Padding(2, 0, 2, 0)
        LblP6.Name = "LblP6"
        LblP6.Size = New Size(20, 15)
        LblP6.TabIndex = 11
        LblP6.Text = "P6"
        LblP6.Visible = False
        ' 
        ' TxtP5
        ' 
        TxtP5.Location = New Point(49, 139)
        TxtP5.Margin = New Padding(2)
        TxtP5.Name = "TxtP5"
        TxtP5.Size = New Size(163, 23)
        TxtP5.TabIndex = 10
        TxtP5.Visible = False
        ' 
        ' LblP5
        ' 
        LblP5.AutoSize = True
        LblP5.Location = New Point(7, 142)
        LblP5.Margin = New Padding(2, 0, 2, 0)
        LblP5.Name = "LblP5"
        LblP5.Size = New Size(20, 15)
        LblP5.TabIndex = 9
        LblP5.Text = "P5"
        LblP5.Visible = False
        ' 
        ' TxtP4
        ' 
        TxtP4.Location = New Point(49, 110)
        TxtP4.Margin = New Padding(2)
        TxtP4.Name = "TxtP4"
        TxtP4.Size = New Size(163, 23)
        TxtP4.TabIndex = 8
        TxtP4.Visible = False
        ' 
        ' TxtP3
        ' 
        TxtP3.Location = New Point(49, 81)
        TxtP3.Margin = New Padding(2)
        TxtP3.Name = "TxtP3"
        TxtP3.Size = New Size(163, 23)
        TxtP3.TabIndex = 7
        TxtP3.Visible = False
        ' 
        ' LblP4
        ' 
        LblP4.AutoSize = True
        LblP4.Location = New Point(7, 113)
        LblP4.Margin = New Padding(2, 0, 2, 0)
        LblP4.Name = "LblP4"
        LblP4.Size = New Size(20, 15)
        LblP4.TabIndex = 6
        LblP4.Text = "P4"
        LblP4.Visible = False
        ' 
        ' LblP3
        ' 
        LblP3.AutoSize = True
        LblP3.Location = New Point(7, 85)
        LblP3.Margin = New Padding(2, 0, 2, 0)
        LblP3.Name = "LblP3"
        LblP3.Size = New Size(20, 15)
        LblP3.TabIndex = 5
        LblP3.Text = "P3"
        LblP3.Visible = False
        ' 
        ' BtnTakeOverStartParameter
        ' 
        BtnTakeOverStartParameter.Location = New Point(5, 194)
        BtnTakeOverStartParameter.Margin = New Padding(2)
        BtnTakeOverStartParameter.Name = "BtnTakeOverStartParameter"
        BtnTakeOverStartParameter.Size = New Size(209, 34)
        BtnTakeOverStartParameter.TabIndex = 4
        BtnTakeOverStartParameter.Text = "TakeOver"
        BtnTakeOverStartParameter.UseVisualStyleBackColor = True
        ' 
        ' TxtP2
        ' 
        TxtP2.Location = New Point(49, 53)
        TxtP2.Margin = New Padding(2)
        TxtP2.Name = "TxtP2"
        TxtP2.Size = New Size(163, 23)
        TxtP2.TabIndex = 3
        TxtP2.Visible = False
        ' 
        ' TxtP1
        ' 
        TxtP1.Location = New Point(49, 24)
        TxtP1.Margin = New Padding(2)
        TxtP1.Name = "TxtP1"
        TxtP1.Size = New Size(163, 23)
        TxtP1.TabIndex = 2
        TxtP1.Visible = False
        ' 
        ' LblP2
        ' 
        LblP2.AutoSize = True
        LblP2.Location = New Point(7, 56)
        LblP2.Margin = New Padding(2, 0, 2, 0)
        LblP2.Name = "LblP2"
        LblP2.Size = New Size(20, 15)
        LblP2.TabIndex = 1
        LblP2.Text = "P2"
        LblP2.Visible = False
        ' 
        ' LblP1
        ' 
        LblP1.AutoSize = True
        LblP1.Location = New Point(7, 29)
        LblP1.Margin = New Padding(2, 0, 2, 0)
        LblP1.Name = "LblP1"
        LblP1.Size = New Size(20, 15)
        LblP1.TabIndex = 0
        LblP1.Text = "P1"
        LblP1.Visible = False
        ' 
        ' LblPhasePortrait
        ' 
        LblPhasePortrait.AutoSize = True
        LblPhasePortrait.Location = New Point(973, 5)
        LblPhasePortrait.Margin = New Padding(2, 0, 2, 0)
        LblPhasePortrait.Name = "LblPhasePortrait"
        LblPhasePortrait.Size = New Size(77, 15)
        LblPhasePortrait.TabIndex = 34
        LblPhasePortrait.Text = "PhasePortrait"
        LblPhasePortrait.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblAdditionalParameter
        ' 
        LblAdditionalParameter.AutoSize = True
        LblAdditionalParameter.Location = New Point(724, 58)
        LblAdditionalParameter.Margin = New Padding(2, 0, 2, 0)
        LblAdditionalParameter.Name = "LblAdditionalParameter"
        LblAdditionalParameter.Size = New Size(116, 15)
        LblAdditionalParameter.TabIndex = 33
        LblAdditionalParameter.Text = "AdditionalParameter"
        ' 
        ' TrbAdditionalParameter
        ' 
        TrbAdditionalParameter.Location = New Point(726, 75)
        TrbAdditionalParameter.Margin = New Padding(2)
        TrbAdditionalParameter.Maximum = 100
        TrbAdditionalParameter.Minimum = 1
        TrbAdditionalParameter.Name = "TrbAdditionalParameter"
        TrbAdditionalParameter.Size = New Size(228, 45)
        TrbAdditionalParameter.TabIndex = 32
        TrbAdditionalParameter.Value = 50
        ' 
        ' PicPhasePortrait
        ' 
        PicPhasePortrait.BackColor = Color.White
        PicPhasePortrait.Location = New Point(973, 22)
        PicPhasePortrait.Margin = New Padding(2)
        PicPhasePortrait.Name = "PicPhasePortrait"
        PicPhasePortrait.Size = New Size(450, 450)
        PicPhasePortrait.TabIndex = 31
        PicPhasePortrait.TabStop = False
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(0, 1)
        PicDiagram.Margin = New Padding(2)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(700, 700)
        PicDiagram.TabIndex = 28
        PicDiagram.TabStop = False
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Location = New Point(827, 485)
        LblSteps.Margin = New Padding(2, 0, 2, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(13, 15)
        LblSteps.TabIndex = 43
        LblSteps.Text = "0"
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Location = New Point(722, 485)
        LblNumberOfSteps.Margin = New Padding(2, 0, 2, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(99, 15)
        LblNumberOfSteps.TabIndex = 42
        LblNumberOfSteps.Text = "Number of Steps:"
        ' 
        ' BtnReset
        ' 
        BtnReset.Location = New Point(722, 666)
        BtnReset.Margin = New Padding(3, 4, 3, 4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(230, 34)
        BtnReset.TabIndex = 41
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Location = New Point(722, 508)
        BtnStart.Margin = New Padding(2)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(230, 34)
        BtnStart.TabIndex = 39
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' LblStepWidth
        ' 
        LblStepWidth.AutoSize = True
        LblStepWidth.Location = New Point(724, 369)
        LblStepWidth.Margin = New Padding(2, 0, 2, 0)
        LblStepWidth.Name = "LblStepWidth"
        LblStepWidth.Size = New Size(62, 15)
        LblStepWidth.TabIndex = 45
        LblStepWidth.Text = "StepWidth"
        ' 
        ' TrbStepWidth
        ' 
        TrbStepWidth.Location = New Point(726, 386)
        TrbStepWidth.Margin = New Padding(2)
        TrbStepWidth.Maximum = 50
        TrbStepWidth.Minimum = 1
        TrbStepWidth.Name = "TrbStepWidth"
        TrbStepWidth.Size = New Size(226, 45)
        TrbStepWidth.TabIndex = 44
        TrbStepWidth.Value = 15
        ' 
        ' PicEnergy
        ' 
        PicEnergy.BackColor = Color.White
        PicEnergy.Location = New Point(973, 684)
        PicEnergy.Margin = New Padding(2)
        PicEnergy.Name = "PicEnergy"
        PicEnergy.Size = New Size(450, 16)
        PicEnergy.TabIndex = 47
        PicEnergy.TabStop = False
        ' 
        ' CboTypeofPhaseportrait
        ' 
        CboTypeofPhaseportrait.FormattingEnabled = True
        CboTypeofPhaseportrait.Items.AddRange(New Object() {"Independent", "PoincareSection"})
        CboTypeofPhaseportrait.Location = New Point(724, 453)
        CboTypeofPhaseportrait.Margin = New Padding(3, 4, 3, 4)
        CboTypeofPhaseportrait.Name = "CboTypeofPhaseportrait"
        CboTypeofPhaseportrait.Size = New Size(228, 23)
        CboTypeofPhaseportrait.TabIndex = 48
        ' 
        ' LblTypeofPhaseportrait
        ' 
        LblTypeofPhaseportrait.AutoSize = True
        LblTypeofPhaseportrait.Location = New Point(724, 434)
        LblTypeofPhaseportrait.Margin = New Padding(2, 0, 2, 0)
        LblTypeofPhaseportrait.Name = "LblTypeofPhaseportrait"
        LblTypeofPhaseportrait.Size = New Size(112, 15)
        LblTypeofPhaseportrait.TabIndex = 49
        LblTypeofPhaseportrait.Text = "TypeofPhaseportrait"
        ' 
        ' LblProtocol
        ' 
        LblProtocol.AutoSize = True
        LblProtocol.Location = New Point(973, 480)
        LblProtocol.Margin = New Padding(2, 0, 2, 0)
        LblProtocol.Name = "LblProtocol"
        LblProtocol.Size = New Size(52, 15)
        LblProtocol.TabIndex = 50
        LblProtocol.Text = "Protocol"
        LblProtocol.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' BtnStop
        ' 
        BtnStop.Location = New Point(722, 546)
        BtnStop.Margin = New Padding(2)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(230, 34)
        BtnStop.TabIndex = 51
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Location = New Point(724, 624)
        BtnDefault.Margin = New Padding(3, 4, 3, 4)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(230, 34)
        BtnDefault.TabIndex = 52
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' FrmPendulum
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1434, 709)
        Controls.Add(BtnDefault)
        Controls.Add(BtnStop)
        Controls.Add(LblProtocol)
        Controls.Add(LblTypeofPhaseportrait)
        Controls.Add(CboTypeofPhaseportrait)
        Controls.Add(PicEnergy)
        Controls.Add(LblStepWidth)
        Controls.Add(TrbStepWidth)
        Controls.Add(LblSteps)
        Controls.Add(LblNumberOfSteps)
        Controls.Add(BtnReset)
        Controls.Add(BtnStart)
        Controls.Add(CboPendulum)
        Controls.Add(LblPendulum)
        Controls.Add(LstProtocol)
        Controls.Add(GrpStartParameter)
        Controls.Add(LblPhasePortrait)
        Controls.Add(LblAdditionalParameter)
        Controls.Add(TrbAdditionalParameter)
        Controls.Add(PicPhasePortrait)
        Controls.Add(PicDiagram)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 4, 3, 4)
        Name = "FrmPendulum"
        Text = "Pendulum"
        WindowState = FormWindowState.Maximized
        GrpStartParameter.ResumeLayout(False)
        GrpStartParameter.PerformLayout()
        CType(TrbAdditionalParameter, ComponentModel.ISupportInitialize).EndInit()
        CType(PicPhasePortrait, ComponentModel.ISupportInitialize).EndInit()
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbStepWidth, ComponentModel.ISupportInitialize).EndInit()
        CType(PicEnergy, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents CboPendulum As ComboBox
    Friend WithEvents LblPendulum As Label
    Friend WithEvents LstProtocol As ListBox
    Friend WithEvents GrpStartParameter As GroupBox
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
    Friend WithEvents LblPhasePortrait As Label
    Friend WithEvents LblAdditionalParameter As Label
    Friend WithEvents TrbAdditionalParameter As TrackBar
    Friend WithEvents PicPhasePortrait As PictureBox
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents LblSteps As Label
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents TxtP6 As TextBox
    Friend WithEvents LblP6 As Label
    Friend WithEvents LblStepWidth As Label
    Friend WithEvents TrbStepWidth As TrackBar
    Friend WithEvents PicEnergy As PictureBox
    Friend WithEvents CboTypeofPhaseportrait As ComboBox
    Friend WithEvents LblTypeofPhaseportrait As Label
    Friend WithEvents LblProtocol As Label
    Friend WithEvents BtnStop As Button
    Friend WithEvents BtnDefault As Button
End Class
