<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBilliardtable
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MapBilliardtable.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBilliardtable))
        Me.PicBilliardTable = New System.Windows.Forms.PictureBox()
        Me.BtnDrawBilliardTable = New System.Windows.Forms.Button()
        Me.LblParameterc = New System.Windows.Forms.Label()
        Me.TxtFactor = New System.Windows.Forms.TextBox()
        Me.BtnNextStep = New System.Windows.Forms.Button()
        Me.BtnReset = New System.Windows.Forms.Button()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.PicPhasePortrait = New System.Windows.Forms.PictureBox()
        Me.BtnNewBall = New System.Windows.Forms.Button()
        Me.CboBallColor = New System.Windows.Forms.ComboBox()
        Me.LblBallColor = New System.Windows.Forms.Label()
        Me.TrbSpeed = New System.Windows.Forms.TrackBar()
        Me.LblSpeed = New System.Windows.Forms.Label()
        Me.LblColor = New System.Windows.Forms.Label()
        Me.LblPhasePortrait = New System.Windows.Forms.Label()
        Me.GrpStartParameter = New System.Windows.Forms.GroupBox()
        Me.BtnTakeOverStartParameter = New System.Windows.Forms.Button()
        Me.TxtAlfa = New System.Windows.Forms.TextBox()
        Me.TxtT = New System.Windows.Forms.TextBox()
        Me.LblAlfa = New System.Windows.Forms.Label()
        Me.LblT = New System.Windows.Forms.Label()
        Me.LstParameterList = New System.Windows.Forms.ListBox()
        Me.LblBilliardTable = New System.Windows.Forms.Label()
        Me.CboBilliardTable = New System.Windows.Forms.ComboBox()
        Me.LblNumberOfSteps = New System.Windows.Forms.Label()
        Me.LblIterationSteps = New System.Windows.Forms.Label()
        Me.BtnPhasePortrait = New System.Windows.Forms.Button()
        Me.BtnStop = New System.Windows.Forms.Button()
        CType(Me.PicBilliardTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicPhasePortrait, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrbSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpStartParameter.SuspendLayout()
        Me.SuspendLayout()
        '
        'PicBilliardTable
        '
        Me.PicBilliardTable.BackColor = System.Drawing.Color.White
        Me.PicBilliardTable.Location = New System.Drawing.Point(0, 2)
        Me.PicBilliardTable.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PicBilliardTable.Name = "PicBilliardTable"
        Me.PicBilliardTable.Size = New System.Drawing.Size(1240, 1162)
        Me.PicBilliardTable.TabIndex = 3
        Me.PicBilliardTable.TabStop = False
        '
        'BtnDrawBilliardTable
        '
        Me.BtnDrawBilliardTable.Location = New System.Drawing.Point(1260, 181)
        Me.BtnDrawBilliardTable.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnDrawBilliardTable.Name = "BtnDrawBilliardTable"
        Me.BtnDrawBilliardTable.Size = New System.Drawing.Size(364, 56)
        Me.BtnDrawBilliardTable.TabIndex = 4
        Me.BtnDrawBilliardTable.Text = "DrawBilliardTable"
        Me.BtnDrawBilliardTable.UseVisualStyleBackColor = True
        '
        'LblParameterc
        '
        Me.LblParameterc.AutoSize = True
        Me.LblParameterc.Location = New System.Drawing.Point(1256, 131)
        Me.LblParameterc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblParameterc.Name = "LblParameterc"
        Me.LblParameterc.Size = New System.Drawing.Size(88, 25)
        Me.LblParameterc.TabIndex = 9
        Me.LblParameterc.Text = "FactorC"
        '
        'TxtFactor
        '
        Me.TxtFactor.Location = New System.Drawing.Point(1472, 129)
        Me.TxtFactor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtFactor.Name = "TxtFactor"
        Me.TxtFactor.Size = New System.Drawing.Size(152, 31)
        Me.TxtFactor.TabIndex = 10
        '
        'BtnNextStep
        '
        Me.BtnNextStep.Location = New System.Drawing.Point(1260, 771)
        Me.BtnNextStep.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnNextStep.Name = "BtnNextStep"
        Me.BtnNextStep.Size = New System.Drawing.Size(364, 56)
        Me.BtnNextStep.TabIndex = 11
        Me.BtnNextStep.Text = "NextStep"
        Me.BtnNextStep.UseVisualStyleBackColor = True
        '
        'BtnReset
        '
        Me.BtnReset.Location = New System.Drawing.Point(1260, 1110)
        Me.BtnReset.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(364, 56)
        Me.BtnReset.TabIndex = 12
        Me.BtnReset.Text = "ResetIteration"
        Me.BtnReset.UseVisualStyleBackColor = True
        '
        'BtnStart
        '
        Me.BtnStart.Location = New System.Drawing.Point(1260, 895)
        Me.BtnStart.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(364, 56)
        Me.BtnStart.TabIndex = 13
        Me.BtnStart.Text = "Start"
        Me.BtnStart.UseVisualStyleBackColor = True
        '
        'PicPhasePortrait
        '
        Me.PicPhasePortrait.BackColor = System.Drawing.Color.White
        Me.PicPhasePortrait.Location = New System.Drawing.Point(1652, 2)
        Me.PicPhasePortrait.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PicPhasePortrait.Name = "PicPhasePortrait"
        Me.PicPhasePortrait.Size = New System.Drawing.Size(820, 769)
        Me.PicPhasePortrait.TabIndex = 16
        Me.PicPhasePortrait.TabStop = False
        '
        'BtnNewBall
        '
        Me.BtnNewBall.Location = New System.Drawing.Point(1260, 354)
        Me.BtnNewBall.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnNewBall.Name = "BtnNewBall"
        Me.BtnNewBall.Size = New System.Drawing.Size(364, 56)
        Me.BtnNewBall.TabIndex = 17
        Me.BtnNewBall.Text = "NewBall"
        Me.BtnNewBall.UseVisualStyleBackColor = True
        '
        'CboBallColor
        '
        Me.CboBallColor.BackColor = System.Drawing.SystemColors.Window
        Me.CboBallColor.FormattingEnabled = True
        Me.CboBallColor.Items.AddRange(New Object() {"Red", "Green", "Blue", "Black", "Magenta"})
        Me.CboBallColor.Location = New System.Drawing.Point(1260, 300)
        Me.CboBallColor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CboBallColor.Name = "CboBallColor"
        Me.CboBallColor.Size = New System.Drawing.Size(292, 33)
        Me.CboBallColor.TabIndex = 18
        '
        'LblBallColor
        '
        Me.LblBallColor.AutoSize = True
        Me.LblBallColor.Location = New System.Drawing.Point(1256, 252)
        Me.LblBallColor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBallColor.Name = "LblBallColor"
        Me.LblBallColor.Size = New System.Drawing.Size(99, 25)
        Me.LblBallColor.TabIndex = 19
        Me.LblBallColor.Text = "BallColor"
        '
        'TrbSpeed
        '
        Me.TrbSpeed.Location = New System.Drawing.Point(1261, 681)
        Me.TrbSpeed.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TrbSpeed.Maximum = 100
        Me.TrbSpeed.Minimum = 1
        Me.TrbSpeed.Name = "TrbSpeed"
        Me.TrbSpeed.Size = New System.Drawing.Size(364, 90)
        Me.TrbSpeed.TabIndex = 20
        Me.TrbSpeed.Value = 50
        '
        'LblSpeed
        '
        Me.LblSpeed.AutoSize = True
        Me.LblSpeed.Location = New System.Drawing.Point(1271, 651)
        Me.LblSpeed.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSpeed.Name = "LblSpeed"
        Me.LblSpeed.Size = New System.Drawing.Size(110, 25)
        Me.LblSpeed.TabIndex = 21
        Me.LblSpeed.Text = "BallSpeed"
        '
        'LblColor
        '
        Me.LblColor.BackColor = System.Drawing.Color.Red
        Me.LblColor.Location = New System.Drawing.Point(1560, 300)
        Me.LblColor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblColor.Name = "LblColor"
        Me.LblColor.Size = New System.Drawing.Size(64, 35)
        Me.LblColor.TabIndex = 22
        '
        'LblPhasePortrait
        '
        Me.LblPhasePortrait.AutoSize = True
        Me.LblPhasePortrait.Location = New System.Drawing.Point(1980, 802)
        Me.LblPhasePortrait.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPhasePortrait.Name = "LblPhasePortrait"
        Me.LblPhasePortrait.Size = New System.Drawing.Size(142, 25)
        Me.LblPhasePortrait.TabIndex = 23
        Me.LblPhasePortrait.Text = "PhasePortrait"
        '
        'GrpStartParameter
        '
        Me.GrpStartParameter.Controls.Add(Me.BtnTakeOverStartParameter)
        Me.GrpStartParameter.Controls.Add(Me.TxtAlfa)
        Me.GrpStartParameter.Controls.Add(Me.TxtT)
        Me.GrpStartParameter.Controls.Add(Me.LblAlfa)
        Me.GrpStartParameter.Controls.Add(Me.LblT)
        Me.GrpStartParameter.Location = New System.Drawing.Point(1260, 438)
        Me.GrpStartParameter.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GrpStartParameter.Name = "GrpStartParameter"
        Me.GrpStartParameter.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GrpStartParameter.Size = New System.Drawing.Size(364, 199)
        Me.GrpStartParameter.TabIndex = 24
        Me.GrpStartParameter.TabStop = False
        Me.GrpStartParameter.Text = "StartParameter"
        '
        'BtnTakeOverStartParameter
        '
        Me.BtnTakeOverStartParameter.Location = New System.Drawing.Point(16, 140)
        Me.BtnTakeOverStartParameter.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnTakeOverStartParameter.Name = "BtnTakeOverStartParameter"
        Me.BtnTakeOverStartParameter.Size = New System.Drawing.Size(340, 48)
        Me.BtnTakeOverStartParameter.TabIndex = 4
        Me.BtnTakeOverStartParameter.Text = "TakeOver"
        Me.BtnTakeOverStartParameter.UseVisualStyleBackColor = True
        '
        'TxtAlfa
        '
        Me.TxtAlfa.Location = New System.Drawing.Point(84, 88)
        Me.TxtAlfa.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtAlfa.Name = "TxtAlfa"
        Me.TxtAlfa.Size = New System.Drawing.Size(208, 31)
        Me.TxtAlfa.TabIndex = 3
        '
        'TxtT
        '
        Me.TxtT.Location = New System.Drawing.Point(84, 40)
        Me.TxtT.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtT.Name = "TxtT"
        Me.TxtT.Size = New System.Drawing.Size(208, 31)
        Me.TxtT.TabIndex = 2
        '
        'LblAlfa
        '
        Me.LblAlfa.AutoSize = True
        Me.LblAlfa.Location = New System.Drawing.Point(12, 94)
        Me.LblAlfa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAlfa.Name = "LblAlfa"
        Me.LblAlfa.Size = New System.Drawing.Size(49, 25)
        Me.LblAlfa.TabIndex = 1
        Me.LblAlfa.Text = "Alfa"
        '
        'LblT
        '
        Me.LblT.AutoSize = True
        Me.LblT.Location = New System.Drawing.Point(12, 48)
        Me.LblT.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblT.Name = "LblT"
        Me.LblT.Size = New System.Drawing.Size(18, 25)
        Me.LblT.TabIndex = 0
        Me.LblT.Text = "t"
        '
        'LstParameterList
        '
        Me.LstParameterList.FormattingEnabled = True
        Me.LstParameterList.ItemHeight = 25
        Me.LstParameterList.Location = New System.Drawing.Point(1652, 835)
        Me.LstParameterList.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LstParameterList.Name = "LstParameterList"
        Me.LstParameterList.Size = New System.Drawing.Size(820, 329)
        Me.LstParameterList.TabIndex = 25
        '
        'LblBilliardTable
        '
        Me.LblBilliardTable.AutoSize = True
        Me.LblBilliardTable.Location = New System.Drawing.Point(1256, 12)
        Me.LblBilliardTable.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBilliardTable.Name = "LblBilliardTable"
        Me.LblBilliardTable.Size = New System.Drawing.Size(131, 25)
        Me.LblBilliardTable.TabIndex = 26
        Me.LblBilliardTable.Text = "BilliardTable"
        '
        'CboBilliardTable
        '
        Me.CboBilliardTable.FormattingEnabled = True
        Me.CboBilliardTable.Items.AddRange(New Object() {"Elliptic", "Stadium", "Oval"})
        Me.CboBilliardTable.Location = New System.Drawing.Point(1260, 60)
        Me.CboBilliardTable.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CboBilliardTable.Name = "CboBilliardTable"
        Me.CboBilliardTable.Size = New System.Drawing.Size(364, 33)
        Me.CboBilliardTable.TabIndex = 27
        '
        'LblNumberOfSteps
        '
        Me.LblNumberOfSteps.AutoSize = True
        Me.LblNumberOfSteps.Location = New System.Drawing.Point(1255, 852)
        Me.LblNumberOfSteps.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNumberOfSteps.Name = "LblNumberOfSteps"
        Me.LblNumberOfSteps.Size = New System.Drawing.Size(164, 25)
        Me.LblNumberOfSteps.TabIndex = 28
        Me.LblNumberOfSteps.Text = "NumberOfSteps"
        '
        'LblIterationSteps
        '
        Me.LblIterationSteps.AutoSize = True
        Me.LblIterationSteps.Location = New System.Drawing.Point(1447, 852)
        Me.LblIterationSteps.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblIterationSteps.Name = "LblIterationSteps"
        Me.LblIterationSteps.Size = New System.Drawing.Size(24, 25)
        Me.LblIterationSteps.TabIndex = 29
        Me.LblIterationSteps.Text = "0"
        '
        'BtnPhasePortrait
        '
        Me.BtnPhasePortrait.Location = New System.Drawing.Point(1261, 1023)
        Me.BtnPhasePortrait.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnPhasePortrait.Name = "BtnPhasePortrait"
        Me.BtnPhasePortrait.Size = New System.Drawing.Size(364, 56)
        Me.BtnPhasePortrait.TabIndex = 30
        Me.BtnPhasePortrait.Text = "FillPhasePortrait"
        Me.BtnPhasePortrait.UseVisualStyleBackColor = True
        '
        'BtnStop
        '
        Me.BtnStop.Location = New System.Drawing.Point(1260, 959)
        Me.BtnStop.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(364, 56)
        Me.BtnStop.TabIndex = 52
        Me.BtnStop.Text = "Stop"
        Me.BtnStop.UseVisualStyleBackColor = True
        '
        'FrmBilliardtable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2564, 1185)
        Me.Controls.Add(Me.BtnStop)
        Me.Controls.Add(Me.BtnPhasePortrait)
        Me.Controls.Add(Me.LblIterationSteps)
        Me.Controls.Add(Me.LblNumberOfSteps)
        Me.Controls.Add(Me.CboBilliardTable)
        Me.Controls.Add(Me.LblBilliardTable)
        Me.Controls.Add(Me.LstParameterList)
        Me.Controls.Add(Me.GrpStartParameter)
        Me.Controls.Add(Me.LblPhasePortrait)
        Me.Controls.Add(Me.LblColor)
        Me.Controls.Add(Me.LblSpeed)
        Me.Controls.Add(Me.TrbSpeed)
        Me.Controls.Add(Me.LblBallColor)
        Me.Controls.Add(Me.CboBallColor)
        Me.Controls.Add(Me.BtnNewBall)
        Me.Controls.Add(Me.PicPhasePortrait)
        Me.Controls.Add(Me.BtnStart)
        Me.Controls.Add(Me.BtnReset)
        Me.Controls.Add(Me.BtnNextStep)
        Me.Controls.Add(Me.TxtFactor)
        Me.Controls.Add(Me.LblParameterc)
        Me.Controls.Add(Me.BtnDrawBilliardTable)
        Me.Controls.Add(Me.PicBilliardTable)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmBilliardtable"
        Me.Text = "Billiard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PicBilliardTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicPhasePortrait, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrbSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpStartParameter.ResumeLayout(False)
        Me.GrpStartParameter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PicBilliardTable As PictureBox
    Friend WithEvents BtnDrawBilliardTable As Button
    Friend WithEvents LblParameterc As Label
    Friend WithEvents TxtFactor As TextBox
    Friend WithEvents BtnNextStep As Button
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents PicPhasePortrait As PictureBox
    Friend WithEvents BtnNewBall As Button
    Friend WithEvents CboBallColor As ComboBox
    Friend WithEvents LblBallColor As Label
    Friend WithEvents TrbSpeed As TrackBar
    Friend WithEvents LblSpeed As Label
    Friend WithEvents LblColor As Label
    Friend WithEvents LblPhasePortrait As Label
    Friend WithEvents GrpStartParameter As GroupBox
    Friend WithEvents BtnTakeOverStartParameter As Button
    Friend WithEvents TxtAlfa As TextBox
    Friend WithEvents TxtT As TextBox
    Friend WithEvents LblAlfa As Label
    Friend WithEvents LblT As Label
    Friend WithEvents LstParameterList As ListBox
    Friend WithEvents LblBilliardTable As Label
    Friend WithEvents CboBilliardTable As ComboBox
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents LblIterationSteps As Label
    Friend WithEvents BtnPhasePortrait As Button
    Friend WithEvents BtnStop As Button
End Class
