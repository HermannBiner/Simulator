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
        Me.TxtP8 = New System.Windows.Forms.TextBox()
        Me.LblP8 = New System.Windows.Forms.Label()
        Me.TxtP7 = New System.Windows.Forms.TextBox()
        Me.LblP7 = New System.Windows.Forms.Label()
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
        Me.BtnPhasePortrait = New System.Windows.Forms.Button()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.LblStepWidth = New System.Windows.Forms.Label()
        Me.TrbStepWidth = New System.Windows.Forms.TrackBar()
        Me.ChkTestMode = New System.Windows.Forms.CheckBox()
        Me.PicStatus = New System.Windows.Forms.PictureBox()
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
        Me.CboPendulum.Location = New System.Drawing.Point(642, 19)
        Me.CboPendulum.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CboPendulum.Name = "CboPendulum"
        Me.CboPendulum.Size = New System.Drawing.Size(184, 21)
        Me.CboPendulum.TabIndex = 38
        '
        'LblPendulum
        '
        Me.LblPendulum.AutoSize = True
        Me.LblPendulum.Location = New System.Drawing.Point(640, 4)
        Me.LblPendulum.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblPendulum.Name = "LblPendulum"
        Me.LblPendulum.Size = New System.Drawing.Size(54, 13)
        Me.LblPendulum.TabIndex = 37
        Me.LblPendulum.Text = "Pendulum"
        '
        'LstParameterList
        '
        Me.LstParameterList.FormattingEnabled = True
        Me.LstParameterList.Location = New System.Drawing.Point(831, 445)
        Me.LstParameterList.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.LstParameterList.Name = "LstParameterList"
        Me.LstParameterList.Size = New System.Drawing.Size(422, 173)
        Me.LstParameterList.TabIndex = 36
        '
        'GrpStartParameter
        '
        Me.GrpStartParameter.Controls.Add(Me.TxtP8)
        Me.GrpStartParameter.Controls.Add(Me.LblP8)
        Me.GrpStartParameter.Controls.Add(Me.TxtP7)
        Me.GrpStartParameter.Controls.Add(Me.LblP7)
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
        Me.GrpStartParameter.Location = New System.Drawing.Point(644, 139)
        Me.GrpStartParameter.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GrpStartParameter.Name = "GrpStartParameter"
        Me.GrpStartParameter.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GrpStartParameter.Size = New System.Drawing.Size(182, 250)
        Me.GrpStartParameter.TabIndex = 35
        Me.GrpStartParameter.TabStop = False
        Me.GrpStartParameter.Text = "StartParameter"
        '
        'TxtP8
        '
        Me.TxtP8.Location = New System.Drawing.Point(42, 192)
        Me.TxtP8.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtP8.Name = "TxtP8"
        Me.TxtP8.Size = New System.Drawing.Size(106, 20)
        Me.TxtP8.TabIndex = 16
        Me.TxtP8.Visible = False
        '
        'LblP8
        '
        Me.LblP8.AutoSize = True
        Me.LblP8.Location = New System.Drawing.Point(6, 195)
        Me.LblP8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblP8.Name = "LblP8"
        Me.LblP8.Size = New System.Drawing.Size(20, 13)
        Me.LblP8.TabIndex = 15
        Me.LblP8.Text = "P8"
        Me.LblP8.Visible = False
        '
        'TxtP7
        '
        Me.TxtP7.Location = New System.Drawing.Point(42, 168)
        Me.TxtP7.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtP7.Name = "TxtP7"
        Me.TxtP7.Size = New System.Drawing.Size(106, 20)
        Me.TxtP7.TabIndex = 14
        Me.TxtP7.Visible = False
        '
        'LblP7
        '
        Me.LblP7.AutoSize = True
        Me.LblP7.Location = New System.Drawing.Point(6, 171)
        Me.LblP7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblP7.Name = "LblP7"
        Me.LblP7.Size = New System.Drawing.Size(20, 13)
        Me.LblP7.TabIndex = 13
        Me.LblP7.Text = "P7"
        Me.LblP7.Visible = False
        '
        'TxtP6
        '
        Me.TxtP6.Location = New System.Drawing.Point(42, 144)
        Me.TxtP6.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtP6.Name = "TxtP6"
        Me.TxtP6.Size = New System.Drawing.Size(106, 20)
        Me.TxtP6.TabIndex = 12
        Me.TxtP6.Visible = False
        '
        'LblP6
        '
        Me.LblP6.AutoSize = True
        Me.LblP6.Location = New System.Drawing.Point(6, 147)
        Me.LblP6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblP6.Name = "LblP6"
        Me.LblP6.Size = New System.Drawing.Size(20, 13)
        Me.LblP6.TabIndex = 11
        Me.LblP6.Text = "P6"
        Me.LblP6.Visible = False
        '
        'TxtP5
        '
        Me.TxtP5.Location = New System.Drawing.Point(42, 120)
        Me.TxtP5.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtP5.Name = "TxtP5"
        Me.TxtP5.Size = New System.Drawing.Size(106, 20)
        Me.TxtP5.TabIndex = 10
        Me.TxtP5.Visible = False
        '
        'LblP5
        '
        Me.LblP5.AutoSize = True
        Me.LblP5.Location = New System.Drawing.Point(6, 123)
        Me.LblP5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblP5.Name = "LblP5"
        Me.LblP5.Size = New System.Drawing.Size(20, 13)
        Me.LblP5.TabIndex = 9
        Me.LblP5.Text = "P5"
        Me.LblP5.Visible = False
        '
        'TxtP4
        '
        Me.TxtP4.Location = New System.Drawing.Point(42, 95)
        Me.TxtP4.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtP4.Name = "TxtP4"
        Me.TxtP4.Size = New System.Drawing.Size(106, 20)
        Me.TxtP4.TabIndex = 8
        Me.TxtP4.Visible = False
        '
        'TxtP3
        '
        Me.TxtP3.Location = New System.Drawing.Point(42, 70)
        Me.TxtP3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtP3.Name = "TxtP3"
        Me.TxtP3.Size = New System.Drawing.Size(106, 20)
        Me.TxtP3.TabIndex = 7
        Me.TxtP3.Visible = False
        '
        'LblP4
        '
        Me.LblP4.AutoSize = True
        Me.LblP4.Location = New System.Drawing.Point(6, 98)
        Me.LblP4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblP4.Name = "LblP4"
        Me.LblP4.Size = New System.Drawing.Size(20, 13)
        Me.LblP4.TabIndex = 6
        Me.LblP4.Text = "P4"
        Me.LblP4.Visible = False
        '
        'LblP3
        '
        Me.LblP3.AutoSize = True
        Me.LblP3.Location = New System.Drawing.Point(6, 74)
        Me.LblP3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblP3.Name = "LblP3"
        Me.LblP3.Size = New System.Drawing.Size(20, 13)
        Me.LblP3.TabIndex = 5
        Me.LblP3.Text = "P3"
        Me.LblP3.Visible = False
        '
        'BtnTakeOverStartParameter
        '
        Me.BtnTakeOverStartParameter.Location = New System.Drawing.Point(4, 218)
        Me.BtnTakeOverStartParameter.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnTakeOverStartParameter.Name = "BtnTakeOverStartParameter"
        Me.BtnTakeOverStartParameter.Size = New System.Drawing.Size(170, 25)
        Me.BtnTakeOverStartParameter.TabIndex = 4
        Me.BtnTakeOverStartParameter.Text = "TakeOver"
        Me.BtnTakeOverStartParameter.UseVisualStyleBackColor = True
        '
        'TxtP2
        '
        Me.TxtP2.Location = New System.Drawing.Point(42, 46)
        Me.TxtP2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtP2.Name = "TxtP2"
        Me.TxtP2.Size = New System.Drawing.Size(106, 20)
        Me.TxtP2.TabIndex = 3
        Me.TxtP2.Visible = False
        '
        'TxtP1
        '
        Me.TxtP1.Location = New System.Drawing.Point(42, 21)
        Me.TxtP1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtP1.Name = "TxtP1"
        Me.TxtP1.Size = New System.Drawing.Size(106, 20)
        Me.TxtP1.TabIndex = 2
        Me.TxtP1.Visible = False
        '
        'LblP2
        '
        Me.LblP2.AutoSize = True
        Me.LblP2.Location = New System.Drawing.Point(6, 49)
        Me.LblP2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblP2.Name = "LblP2"
        Me.LblP2.Size = New System.Drawing.Size(20, 13)
        Me.LblP2.TabIndex = 1
        Me.LblP2.Text = "P2"
        Me.LblP2.Visible = False
        '
        'LblP1
        '
        Me.LblP1.AutoSize = True
        Me.LblP1.Location = New System.Drawing.Point(6, 25)
        Me.LblP1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblP1.Name = "LblP1"
        Me.LblP1.Size = New System.Drawing.Size(20, 13)
        Me.LblP1.TabIndex = 0
        Me.LblP1.Text = "P1"
        Me.LblP1.Visible = False
        '
        'LblPhasePortrait
        '
        Me.LblPhasePortrait.AutoSize = True
        Me.LblPhasePortrait.Location = New System.Drawing.Point(939, 426)
        Me.LblPhasePortrait.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblPhasePortrait.Name = "LblPhasePortrait"
        Me.LblPhasePortrait.Size = New System.Drawing.Size(70, 13)
        Me.LblPhasePortrait.TabIndex = 34
        Me.LblPhasePortrait.Text = "PhasePortrait"
        Me.LblPhasePortrait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblAdditionalParameter
        '
        Me.LblAdditionalParameter.AutoSize = True
        Me.LblAdditionalParameter.Location = New System.Drawing.Point(640, 73)
        Me.LblAdditionalParameter.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblAdditionalParameter.Name = "LblAdditionalParameter"
        Me.LblAdditionalParameter.Size = New System.Drawing.Size(101, 13)
        Me.LblAdditionalParameter.TabIndex = 33
        Me.LblAdditionalParameter.Text = "AdditionalParameter"
        '
        'TrbAdditionalParameter
        '
        Me.TrbAdditionalParameter.Location = New System.Drawing.Point(644, 90)
        Me.TrbAdditionalParameter.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TrbAdditionalParameter.Maximum = 100
        Me.TrbAdditionalParameter.Minimum = 1
        Me.TrbAdditionalParameter.Name = "TrbAdditionalParameter"
        Me.TrbAdditionalParameter.Size = New System.Drawing.Size(182, 45)
        Me.TrbAdditionalParameter.TabIndex = 32
        Me.TrbAdditionalParameter.Value = 50
        '
        'PicPhasePortrait
        '
        Me.PicPhasePortrait.BackColor = System.Drawing.Color.White
        Me.PicPhasePortrait.Location = New System.Drawing.Point(831, 1)
        Me.PicPhasePortrait.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PicPhasePortrait.Name = "PicPhasePortrait"
        Me.PicPhasePortrait.Size = New System.Drawing.Size(420, 420)
        Me.PicPhasePortrait.TabIndex = 31
        Me.PicPhasePortrait.TabStop = False
        '
        'TxtFactor
        '
        Me.TxtFactor.BackColor = System.Drawing.Color.White
        Me.TxtFactor.Enabled = False
        Me.TxtFactor.Location = New System.Drawing.Point(704, 47)
        Me.TxtFactor.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtFactor.Name = "TxtFactor"
        Me.TxtFactor.Size = New System.Drawing.Size(122, 20)
        Me.TxtFactor.TabIndex = 30
        '
        'LblParameterc
        '
        Me.LblParameterc.AutoSize = True
        Me.LblParameterc.Location = New System.Drawing.Point(640, 48)
        Me.LblParameterc.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblParameterc.Name = "LblParameterc"
        Me.LblParameterc.Size = New System.Drawing.Size(44, 13)
        Me.LblParameterc.TabIndex = 29
        Me.LblParameterc.Text = "FactorC"
        '
        'PicPendulum
        '
        Me.PicPendulum.BackColor = System.Drawing.Color.White
        Me.PicPendulum.Location = New System.Drawing.Point(0, 1)
        Me.PicPendulum.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PicPendulum.Name = "PicPendulum"
        Me.PicPendulum.Size = New System.Drawing.Size(630, 630)
        Me.PicPendulum.TabIndex = 28
        Me.PicPendulum.TabStop = False
        '
        'LblSteps
        '
        Me.LblSteps.AutoSize = True
        Me.LblSteps.Location = New System.Drawing.Point(732, 492)
        Me.LblSteps.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblSteps.Name = "LblSteps"
        Me.LblSteps.Size = New System.Drawing.Size(13, 13)
        Me.LblSteps.TabIndex = 43
        Me.LblSteps.Text = "0"
        '
        'LblNumberOfSteps
        '
        Me.LblNumberOfSteps.AutoSize = True
        Me.LblNumberOfSteps.Location = New System.Drawing.Point(641, 492)
        Me.LblNumberOfSteps.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblNumberOfSteps.Name = "LblNumberOfSteps"
        Me.LblNumberOfSteps.Size = New System.Drawing.Size(89, 13)
        Me.LblNumberOfSteps.TabIndex = 42
        Me.LblNumberOfSteps.Text = "Number of Steps:"
        '
        'BtnReset
        '
        Me.BtnReset.Location = New System.Drawing.Point(642, 597)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(182, 34)
        Me.BtnReset.TabIndex = 41
        Me.BtnReset.Text = "Reset"
        Me.BtnReset.UseVisualStyleBackColor = True
        '
        'BtnPhasePortrait
        '
        Me.BtnPhasePortrait.Location = New System.Drawing.Point(642, 557)
        Me.BtnPhasePortrait.Name = "BtnPhasePortrait"
        Me.BtnPhasePortrait.Size = New System.Drawing.Size(182, 34)
        Me.BtnPhasePortrait.TabIndex = 40
        Me.BtnPhasePortrait.Text = "FillPhaseportrait"
        Me.BtnPhasePortrait.UseVisualStyleBackColor = True
        Me.BtnPhasePortrait.Visible = False
        '
        'BtnStart
        '
        Me.BtnStart.Location = New System.Drawing.Point(642, 518)
        Me.BtnStart.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(182, 34)
        Me.BtnStart.TabIndex = 39
        Me.BtnStart.Text = "Start"
        Me.BtnStart.UseVisualStyleBackColor = True
        '
        'LblStepWidth
        '
        Me.LblStepWidth.AutoSize = True
        Me.LblStepWidth.Location = New System.Drawing.Point(641, 398)
        Me.LblStepWidth.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblStepWidth.Name = "LblStepWidth"
        Me.LblStepWidth.Size = New System.Drawing.Size(57, 13)
        Me.LblStepWidth.TabIndex = 45
        Me.LblStepWidth.Text = "StepWidth"
        '
        'TrbStepWidth
        '
        Me.TrbStepWidth.Location = New System.Drawing.Point(643, 413)
        Me.TrbStepWidth.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TrbStepWidth.Maximum = 25
        Me.TrbStepWidth.Minimum = 1
        Me.TrbStepWidth.Name = "TrbStepWidth"
        Me.TrbStepWidth.Size = New System.Drawing.Size(182, 45)
        Me.TrbStepWidth.TabIndex = 44
        Me.TrbStepWidth.Value = 10
        '
        'ChkTestMode
        '
        Me.ChkTestMode.AutoSize = True
        Me.ChkTestMode.Location = New System.Drawing.Point(644, 463)
        Me.ChkTestMode.Name = "ChkTestMode"
        Me.ChkTestMode.Size = New System.Drawing.Size(74, 17)
        Me.ChkTestMode.TabIndex = 46
        Me.ChkTestMode.Text = "TestMode"
        Me.ChkTestMode.UseVisualStyleBackColor = True
        '
        'PicStatus
        '
        Me.PicStatus.BackColor = System.Drawing.Color.White
        Me.PicStatus.Location = New System.Drawing.Point(831, 617)
        Me.PicStatus.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PicStatus.Name = "PicStatus"
        Me.PicStatus.Size = New System.Drawing.Size(420, 14)
        Me.PicStatus.TabIndex = 47
        Me.PicStatus.TabStop = False
        '
        'FrmPendulum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1262, 634)
        Me.Controls.Add(Me.PicStatus)
        Me.Controls.Add(Me.ChkTestMode)
        Me.Controls.Add(Me.LblStepWidth)
        Me.Controls.Add(Me.TrbStepWidth)
        Me.Controls.Add(Me.LblSteps)
        Me.Controls.Add(Me.LblNumberOfSteps)
        Me.Controls.Add(Me.BtnReset)
        Me.Controls.Add(Me.BtnPhasePortrait)
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
    Friend WithEvents BtnPhasePortrait As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents TxtP8 As TextBox
    Friend WithEvents LblP8 As Label
    Friend WithEvents TxtP7 As TextBox
    Friend WithEvents LblP7 As Label
    Friend WithEvents TxtP6 As TextBox
    Friend WithEvents LblP6 As Label
    Friend WithEvents LblStepWidth As Label
    Friend WithEvents TrbStepWidth As TrackBar
    Friend WithEvents ChkTestMode As CheckBox
    Friend WithEvents PicStatus As PictureBox
End Class
