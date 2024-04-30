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
        Me.CboPendulum = New System.Windows.Forms.ComboBox()
        Me.LblPendulum = New System.Windows.Forms.Label()
        Me.LstParameterList = New System.Windows.Forms.ListBox()
        Me.GrpStartParameter = New System.Windows.Forms.GroupBox()
        Me.TxtP6 = New System.Windows.Forms.TextBox()
        Me.LblP6 = New System.Windows.Forms.Label()
        Me.TxtP5 = New System.Windows.Forms.TextBox()
        Me.LblP5 = New System.Windows.Forms.Label()
        Me.TxtP4 = New System.Windows.Forms.TextBox()
        Me.TxtP3 = New System.Windows.Forms.TextBox()
        Me.LblP4 = New System.Windows.Forms.Label()
        Me.LblP3 = New System.Windows.Forms.Label()
        Me.BtnTakeOverStartParameter = New System.Windows.Forms.Button()
        Me.TxtP2 = New System.Windows.Forms.TextBox()
        Me.TxtP1 = New System.Windows.Forms.TextBox()
        Me.LblP2 = New System.Windows.Forms.Label()
        Me.LblP1 = New System.Windows.Forms.Label()
        Me.LblPhasePortrait = New System.Windows.Forms.Label()
        Me.LblAdditionalParameter = New System.Windows.Forms.Label()
        Me.TrbAdditionalParameter = New System.Windows.Forms.TrackBar()
        Me.PicPhasePortrait = New System.Windows.Forms.PictureBox()
        Me.TxtFactor = New System.Windows.Forms.TextBox()
        Me.LblParameterc = New System.Windows.Forms.Label()
        Me.PicPendulum = New System.Windows.Forms.PictureBox()
        Me.LblSteps = New System.Windows.Forms.Label()
        Me.LblNumberOfSteps = New System.Windows.Forms.Label()
        Me.BtnReset = New System.Windows.Forms.Button()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.LblStepWidth = New System.Windows.Forms.Label()
        Me.TrbStepWidth = New System.Windows.Forms.TrackBar()
        Me.PicStatus = New System.Windows.Forms.PictureBox()
        Me.CboTypeofPhaseportrait = New System.Windows.Forms.ComboBox()
        Me.LblTypeofPhaseportrait = New System.Windows.Forms.Label()
        Me.LblParameterlist = New System.Windows.Forms.Label()
        Me.BtnStop = New System.Windows.Forms.Button()
        Me.GrpStartParameter.SuspendLayout()
        CType(Me.TrbAdditionalParameter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicPhasePortrait, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicPendulum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrbStepWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CboPendulum
        '
        Me.CboPendulum.FormattingEnabled = True
        Me.CboPendulum.Items.AddRange(New Object() {"DoublePendulum", "CombiPendulum", "ShakePendulum"})
        Me.CboPendulum.Location = New System.Drawing.Point(1284, 37)
        Me.CboPendulum.Margin = New System.Windows.Forms.Padding(4)
        Me.CboPendulum.Name = "CboPendulum"
        Me.CboPendulum.Size = New System.Drawing.Size(364, 33)
        Me.CboPendulum.TabIndex = 38
        '
        'LblPendulum
        '
        Me.LblPendulum.AutoSize = True
        Me.LblPendulum.Location = New System.Drawing.Point(1280, 8)
        Me.LblPendulum.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPendulum.Name = "LblPendulum"
        Me.LblPendulum.Size = New System.Drawing.Size(108, 25)
        Me.LblPendulum.TabIndex = 37
        Me.LblPendulum.Text = "Pendulum"
        '
        'LstParameterList
        '
        Me.LstParameterList.FormattingEnabled = True
        Me.LstParameterList.ItemHeight = 25
        Me.LstParameterList.Location = New System.Drawing.Point(1662, 881)
        Me.LstParameterList.Margin = New System.Windows.Forms.Padding(4)
        Me.LstParameterList.Name = "LstParameterList"
        Me.LstParameterList.Size = New System.Drawing.Size(840, 304)
        Me.LstParameterList.TabIndex = 36
        '
        'GrpStartParameter
        '
        Me.GrpStartParameter.Controls.Add(Me.TxtP6)
        Me.GrpStartParameter.Controls.Add(Me.LblP6)
        Me.GrpStartParameter.Controls.Add(Me.TxtP5)
        Me.GrpStartParameter.Controls.Add(Me.LblP5)
        Me.GrpStartParameter.Controls.Add(Me.TxtP4)
        Me.GrpStartParameter.Controls.Add(Me.TxtP3)
        Me.GrpStartParameter.Controls.Add(Me.LblP4)
        Me.GrpStartParameter.Controls.Add(Me.LblP3)
        Me.GrpStartParameter.Controls.Add(Me.BtnTakeOverStartParameter)
        Me.GrpStartParameter.Controls.Add(Me.TxtP2)
        Me.GrpStartParameter.Controls.Add(Me.TxtP1)
        Me.GrpStartParameter.Controls.Add(Me.LblP2)
        Me.GrpStartParameter.Controls.Add(Me.LblP1)
        Me.GrpStartParameter.Location = New System.Drawing.Point(1288, 267)
        Me.GrpStartParameter.Margin = New System.Windows.Forms.Padding(4)
        Me.GrpStartParameter.Name = "GrpStartParameter"
        Me.GrpStartParameter.Padding = New System.Windows.Forms.Padding(4)
        Me.GrpStartParameter.Size = New System.Drawing.Size(364, 387)
        Me.GrpStartParameter.TabIndex = 35
        Me.GrpStartParameter.TabStop = False
        Me.GrpStartParameter.Text = "StartParameter"
        '
        'TxtP6
        '
        Me.TxtP6.Location = New System.Drawing.Point(84, 277)
        Me.TxtP6.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtP6.Name = "TxtP6"
        Me.TxtP6.Size = New System.Drawing.Size(208, 31)
        Me.TxtP6.TabIndex = 12
        Me.TxtP6.Visible = False
        '
        'LblP6
        '
        Me.LblP6.AutoSize = True
        Me.LblP6.Location = New System.Drawing.Point(12, 283)
        Me.LblP6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblP6.Name = "LblP6"
        Me.LblP6.Size = New System.Drawing.Size(38, 25)
        Me.LblP6.TabIndex = 11
        Me.LblP6.Text = "P6"
        Me.LblP6.Visible = False
        '
        'TxtP5
        '
        Me.TxtP5.Location = New System.Drawing.Point(84, 231)
        Me.TxtP5.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtP5.Name = "TxtP5"
        Me.TxtP5.Size = New System.Drawing.Size(208, 31)
        Me.TxtP5.TabIndex = 10
        Me.TxtP5.Visible = False
        '
        'LblP5
        '
        Me.LblP5.AutoSize = True
        Me.LblP5.Location = New System.Drawing.Point(12, 237)
        Me.LblP5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblP5.Name = "LblP5"
        Me.LblP5.Size = New System.Drawing.Size(38, 25)
        Me.LblP5.TabIndex = 9
        Me.LblP5.Text = "P5"
        Me.LblP5.Visible = False
        '
        'TxtP4
        '
        Me.TxtP4.Location = New System.Drawing.Point(84, 183)
        Me.TxtP4.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtP4.Name = "TxtP4"
        Me.TxtP4.Size = New System.Drawing.Size(208, 31)
        Me.TxtP4.TabIndex = 8
        Me.TxtP4.Visible = False
        '
        'TxtP3
        '
        Me.TxtP3.Location = New System.Drawing.Point(84, 135)
        Me.TxtP3.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtP3.Name = "TxtP3"
        Me.TxtP3.Size = New System.Drawing.Size(208, 31)
        Me.TxtP3.TabIndex = 7
        Me.TxtP3.Visible = False
        '
        'LblP4
        '
        Me.LblP4.AutoSize = True
        Me.LblP4.Location = New System.Drawing.Point(12, 188)
        Me.LblP4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblP4.Name = "LblP4"
        Me.LblP4.Size = New System.Drawing.Size(38, 25)
        Me.LblP4.TabIndex = 6
        Me.LblP4.Text = "P4"
        Me.LblP4.Visible = False
        '
        'LblP3
        '
        Me.LblP3.AutoSize = True
        Me.LblP3.Location = New System.Drawing.Point(12, 142)
        Me.LblP3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblP3.Name = "LblP3"
        Me.LblP3.Size = New System.Drawing.Size(38, 25)
        Me.LblP3.TabIndex = 5
        Me.LblP3.Text = "P3"
        Me.LblP3.Visible = False
        '
        'BtnTakeOverStartParameter
        '
        Me.BtnTakeOverStartParameter.Location = New System.Drawing.Point(8, 323)
        Me.BtnTakeOverStartParameter.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnTakeOverStartParameter.Name = "BtnTakeOverStartParameter"
        Me.BtnTakeOverStartParameter.Size = New System.Drawing.Size(340, 48)
        Me.BtnTakeOverStartParameter.TabIndex = 4
        Me.BtnTakeOverStartParameter.Text = "TakeOver"
        Me.BtnTakeOverStartParameter.UseVisualStyleBackColor = True
        '
        'TxtP2
        '
        Me.TxtP2.Location = New System.Drawing.Point(84, 88)
        Me.TxtP2.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtP2.Name = "TxtP2"
        Me.TxtP2.Size = New System.Drawing.Size(208, 31)
        Me.TxtP2.TabIndex = 3
        Me.TxtP2.Visible = False
        '
        'TxtP1
        '
        Me.TxtP1.Location = New System.Drawing.Point(84, 40)
        Me.TxtP1.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtP1.Name = "TxtP1"
        Me.TxtP1.Size = New System.Drawing.Size(208, 31)
        Me.TxtP1.TabIndex = 2
        Me.TxtP1.Visible = False
        '
        'LblP2
        '
        Me.LblP2.AutoSize = True
        Me.LblP2.Location = New System.Drawing.Point(12, 94)
        Me.LblP2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblP2.Name = "LblP2"
        Me.LblP2.Size = New System.Drawing.Size(38, 25)
        Me.LblP2.TabIndex = 1
        Me.LblP2.Text = "P2"
        Me.LblP2.Visible = False
        '
        'LblP1
        '
        Me.LblP1.AutoSize = True
        Me.LblP1.Location = New System.Drawing.Point(12, 48)
        Me.LblP1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblP1.Name = "LblP1"
        Me.LblP1.Size = New System.Drawing.Size(38, 25)
        Me.LblP1.TabIndex = 0
        Me.LblP1.Text = "P1"
        Me.LblP1.Visible = False
        '
        'LblPhasePortrait
        '
        Me.LblPhasePortrait.AutoSize = True
        Me.LblPhasePortrait.Location = New System.Drawing.Point(1656, 819)
        Me.LblPhasePortrait.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPhasePortrait.Name = "LblPhasePortrait"
        Me.LblPhasePortrait.Size = New System.Drawing.Size(142, 25)
        Me.LblPhasePortrait.TabIndex = 34
        Me.LblPhasePortrait.Text = "PhasePortrait"
        Me.LblPhasePortrait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblAdditionalParameter
        '
        Me.LblAdditionalParameter.AutoSize = True
        Me.LblAdditionalParameter.Location = New System.Drawing.Point(1280, 140)
        Me.LblAdditionalParameter.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAdditionalParameter.Name = "LblAdditionalParameter"
        Me.LblAdditionalParameter.Size = New System.Drawing.Size(206, 25)
        Me.LblAdditionalParameter.TabIndex = 33
        Me.LblAdditionalParameter.Text = "AdditionalParameter"
        '
        'TrbAdditionalParameter
        '
        Me.TrbAdditionalParameter.Location = New System.Drawing.Point(1288, 173)
        Me.TrbAdditionalParameter.Margin = New System.Windows.Forms.Padding(4)
        Me.TrbAdditionalParameter.Maximum = 100
        Me.TrbAdditionalParameter.Minimum = 1
        Me.TrbAdditionalParameter.Name = "TrbAdditionalParameter"
        Me.TrbAdditionalParameter.Size = New System.Drawing.Size(364, 90)
        Me.TrbAdditionalParameter.TabIndex = 32
        Me.TrbAdditionalParameter.Value = 50
        '
        'PicPhasePortrait
        '
        Me.PicPhasePortrait.BackColor = System.Drawing.Color.White
        Me.PicPhasePortrait.Location = New System.Drawing.Point(1662, 2)
        Me.PicPhasePortrait.Margin = New System.Windows.Forms.Padding(4)
        Me.PicPhasePortrait.Name = "PicPhasePortrait"
        Me.PicPhasePortrait.Size = New System.Drawing.Size(840, 808)
        Me.PicPhasePortrait.TabIndex = 31
        Me.PicPhasePortrait.TabStop = False
        '
        'TxtFactor
        '
        Me.TxtFactor.BackColor = System.Drawing.Color.White
        Me.TxtFactor.Enabled = False
        Me.TxtFactor.Location = New System.Drawing.Point(1440, 90)
        Me.TxtFactor.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFactor.Name = "TxtFactor"
        Me.TxtFactor.Size = New System.Drawing.Size(208, 31)
        Me.TxtFactor.TabIndex = 30
        '
        'LblParameterc
        '
        Me.LblParameterc.AutoSize = True
        Me.LblParameterc.Location = New System.Drawing.Point(1280, 92)
        Me.LblParameterc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblParameterc.Name = "LblParameterc"
        Me.LblParameterc.Size = New System.Drawing.Size(128, 25)
        Me.LblParameterc.TabIndex = 29
        Me.LblParameterc.Text = "TotalEnergy"
        '
        'PicPendulum
        '
        Me.PicPendulum.BackColor = System.Drawing.Color.White
        Me.PicPendulum.Location = New System.Drawing.Point(0, 2)
        Me.PicPendulum.Margin = New System.Windows.Forms.Padding(4)
        Me.PicPendulum.Name = "PicPendulum"
        Me.PicPendulum.Size = New System.Drawing.Size(1260, 1212)
        Me.PicPendulum.TabIndex = 28
        Me.PicPendulum.TabStop = False
        '
        'LblSteps
        '
        Me.LblSteps.AutoSize = True
        Me.LblSteps.Location = New System.Drawing.Point(1465, 904)
        Me.LblSteps.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSteps.Name = "LblSteps"
        Me.LblSteps.Size = New System.Drawing.Size(24, 25)
        Me.LblSteps.TabIndex = 43
        Me.LblSteps.Text = "0"
        '
        'LblNumberOfSteps
        '
        Me.LblNumberOfSteps.AutoSize = True
        Me.LblNumberOfSteps.Location = New System.Drawing.Point(1283, 904)
        Me.LblNumberOfSteps.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNumberOfSteps.Name = "LblNumberOfSteps"
        Me.LblNumberOfSteps.Size = New System.Drawing.Size(178, 25)
        Me.LblNumberOfSteps.TabIndex = 42
        Me.LblNumberOfSteps.Text = "Number of Steps:"
        '
        'BtnReset
        '
        Me.BtnReset.Location = New System.Drawing.Point(1284, 1148)
        Me.BtnReset.Margin = New System.Windows.Forms.Padding(6)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(364, 65)
        Me.BtnReset.TabIndex = 41
        Me.BtnReset.Text = "Reset"
        Me.BtnReset.UseVisualStyleBackColor = True
        '
        'BtnStart
        '
        Me.BtnStart.Location = New System.Drawing.Point(1284, 950)
        Me.BtnStart.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(364, 65)
        Me.BtnStart.TabIndex = 39
        Me.BtnStart.Text = "Start"
        Me.BtnStart.UseVisualStyleBackColor = True
        '
        'LblStepWidth
        '
        Me.LblStepWidth.AutoSize = True
        Me.LblStepWidth.Location = New System.Drawing.Point(1284, 667)
        Me.LblStepWidth.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblStepWidth.Name = "LblStepWidth"
        Me.LblStepWidth.Size = New System.Drawing.Size(111, 25)
        Me.LblStepWidth.TabIndex = 45
        Me.LblStepWidth.Text = "StepWidth"
        '
        'TrbStepWidth
        '
        Me.TrbStepWidth.Location = New System.Drawing.Point(1288, 696)
        Me.TrbStepWidth.Margin = New System.Windows.Forms.Padding(4)
        Me.TrbStepWidth.Maximum = 50
        Me.TrbStepWidth.Minimum = 1
        Me.TrbStepWidth.Name = "TrbStepWidth"
        Me.TrbStepWidth.Size = New System.Drawing.Size(364, 90)
        Me.TrbStepWidth.TabIndex = 44
        Me.TrbStepWidth.Value = 15
        '
        'PicStatus
        '
        Me.PicStatus.BackColor = System.Drawing.Color.White
        Me.PicStatus.Location = New System.Drawing.Point(1662, 1187)
        Me.PicStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.PicStatus.Name = "PicStatus"
        Me.PicStatus.Size = New System.Drawing.Size(840, 27)
        Me.PicStatus.TabIndex = 47
        Me.PicStatus.TabStop = False
        '
        'CboTypeofPhaseportrait
        '
        Me.CboTypeofPhaseportrait.FormattingEnabled = True
        Me.CboTypeofPhaseportrait.Items.AddRange(New Object() {"Independent", "PoincareSection"})
        Me.CboTypeofPhaseportrait.Location = New System.Drawing.Point(1286, 819)
        Me.CboTypeofPhaseportrait.Margin = New System.Windows.Forms.Padding(6)
        Me.CboTypeofPhaseportrait.Name = "CboTypeofPhaseportrait"
        Me.CboTypeofPhaseportrait.Size = New System.Drawing.Size(344, 33)
        Me.CboTypeofPhaseportrait.TabIndex = 48
        '
        'LblTypeofPhaseportrait
        '
        Me.LblTypeofPhaseportrait.AutoSize = True
        Me.LblTypeofPhaseportrait.Location = New System.Drawing.Point(1284, 785)
        Me.LblTypeofPhaseportrait.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTypeofPhaseportrait.Name = "LblTypeofPhaseportrait"
        Me.LblTypeofPhaseportrait.Size = New System.Drawing.Size(206, 25)
        Me.LblTypeofPhaseportrait.TabIndex = 49
        Me.LblTypeofPhaseportrait.Text = "TypeofPhaseportrait"
        '
        'LblParameterlist
        '
        Me.LblParameterlist.AutoSize = True
        Me.LblParameterlist.Location = New System.Drawing.Point(1656, 850)
        Me.LblParameterlist.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblParameterlist.Name = "LblParameterlist"
        Me.LblParameterlist.Size = New System.Drawing.Size(145, 25)
        Me.LblParameterlist.TabIndex = 50
        Me.LblParameterlist.Text = "ParameterList"
        Me.LblParameterlist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnStop
        '
        Me.BtnStop.Location = New System.Drawing.Point(1284, 1032)
        Me.BtnStop.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(364, 65)
        Me.BtnStop.TabIndex = 51
        Me.BtnStop.Text = "Stop"
        Me.BtnStop.UseVisualStyleBackColor = True
        '
        'FrmPendulum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2524, 1219)
        Me.Controls.Add(Me.BtnStop)
        Me.Controls.Add(Me.LblParameterlist)
        Me.Controls.Add(Me.LblTypeofPhaseportrait)
        Me.Controls.Add(Me.CboTypeofPhaseportrait)
        Me.Controls.Add(Me.PicStatus)
        Me.Controls.Add(Me.LblStepWidth)
        Me.Controls.Add(Me.TrbStepWidth)
        Me.Controls.Add(Me.LblSteps)
        Me.Controls.Add(Me.LblNumberOfSteps)
        Me.Controls.Add(Me.BtnReset)
        Me.Controls.Add(Me.BtnStart)
        Me.Controls.Add(Me.CboPendulum)
        Me.Controls.Add(Me.LblPendulum)
        Me.Controls.Add(Me.LstParameterList)
        Me.Controls.Add(Me.GrpStartParameter)
        Me.Controls.Add(Me.LblPhasePortrait)
        Me.Controls.Add(Me.LblAdditionalParameter)
        Me.Controls.Add(Me.TrbAdditionalParameter)
        Me.Controls.Add(Me.PicPhasePortrait)
        Me.Controls.Add(Me.TxtFactor)
        Me.Controls.Add(Me.LblParameterc)
        Me.Controls.Add(Me.PicPendulum)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "FrmPendulum"
        Me.Text = "Pendulum"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpStartParameter.ResumeLayout(False)
        Me.GrpStartParameter.PerformLayout()
        CType(Me.TrbAdditionalParameter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicPhasePortrait, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicPendulum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrbStepWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CboPendulum As ComboBox
    Friend WithEvents LblPendulum As Label
    Friend WithEvents LstParameterList As ListBox
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
    Friend WithEvents TxtFactor As TextBox
    Friend WithEvents LblParameterc As Label
    Friend WithEvents PicPendulum As PictureBox
    Friend WithEvents LblSteps As Label
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents TxtP6 As TextBox
    Friend WithEvents LblP6 As Label
    Friend WithEvents LblStepWidth As Label
    Friend WithEvents TrbStepWidth As TrackBar
    Friend WithEvents PicStatus As PictureBox
    Friend WithEvents CboTypeofPhaseportrait As ComboBox
    Friend WithEvents LblTypeofPhaseportrait As Label
    Friend WithEvents LblParameterlist As Label
    Friend WithEvents BtnStop As Button
End Class
