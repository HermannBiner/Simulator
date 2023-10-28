<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBillardtable
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MapBillardtable.Dispose()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBillardtable))
        Me.PicBillardTable = New System.Windows.Forms.PictureBox()
        Me.BtnDrawBillardTable = New System.Windows.Forms.Button()
        Me.LblParameterc = New System.Windows.Forms.Label()
        Me.TxtFactor = New System.Windows.Forms.TextBox()
        Me.BtnNextStep = New System.Windows.Forms.Button()
        Me.BtnReset = New System.Windows.Forms.Button()
        Me.BtnNext10 = New System.Windows.Forms.Button()
        Me.PicPhasePortrait = New System.Windows.Forms.PictureBox()
        Me.BtnNewBall = New System.Windows.Forms.Button()
        Me.CboBallColor = New System.Windows.Forms.ComboBox()
        Me.LblBallColor = New System.Windows.Forms.Label()
        Me.TrbSpeed = New System.Windows.Forms.TrackBar()
        Me.LblSpeed = New System.Windows.Forms.Label()
        Me.LblColor = New System.Windows.Forms.Label()
        Me.LblPhasePortrait = New System.Windows.Forms.Label()
        Me.GrpStartParameter = New System.Windows.Forms.GroupBox()
        Me.BtnUseStartParameter = New System.Windows.Forms.Button()
        Me.TxtAlfa = New System.Windows.Forms.TextBox()
        Me.TxtT = New System.Windows.Forms.TextBox()
        Me.LblAlfa = New System.Windows.Forms.Label()
        Me.LblT = New System.Windows.Forms.Label()
        Me.LstParameterList = New System.Windows.Forms.ListBox()
        Me.LblBillardTable = New System.Windows.Forms.Label()
        Me.CboBillardTable = New System.Windows.Forms.ComboBox()
        Me.LblNumber = New System.Windows.Forms.Label()
        Me.LblNumberofSteps = New System.Windows.Forms.Label()
        Me.BtnNext100 = New System.Windows.Forms.Button()
        CType(Me.PicBillardTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicPhasePortrait, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrbSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpStartParameter.SuspendLayout()
        Me.SuspendLayout()
        '
        'PicBillardTable
        '
        Me.PicBillardTable.BackColor = System.Drawing.Color.White
        Me.PicBillardTable.Location = New System.Drawing.Point(0, 2)
        Me.PicBillardTable.Margin = New System.Windows.Forms.Padding(4)
        Me.PicBillardTable.Name = "PicBillardTable"
        Me.PicBillardTable.Size = New System.Drawing.Size(1240, 1162)
        Me.PicBillardTable.TabIndex = 3
        Me.PicBillardTable.TabStop = False
        '
        'BtnDrawBillardTable
        '
        Me.BtnDrawBillardTable.Location = New System.Drawing.Point(1260, 180)
        Me.BtnDrawBillardTable.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnDrawBillardTable.Name = "BtnDrawBillardTable"
        Me.BtnDrawBillardTable.Size = New System.Drawing.Size(364, 56)
        Me.BtnDrawBillardTable.TabIndex = 4
        Me.BtnDrawBillardTable.Text = "DrawBillardTable"
        Me.BtnDrawBillardTable.UseVisualStyleBackColor = True
        '
        'LblParameterc
        '
        Me.LblParameterc.AutoSize = True
        Me.LblParameterc.Location = New System.Drawing.Point(1255, 131)
        Me.LblParameterc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblParameterc.Name = "LblParameterc"
        Me.LblParameterc.Size = New System.Drawing.Size(94, 25)
        Me.LblParameterc.TabIndex = 9
        Me.LblParameterc.Text = "FactorC"
        '
        'TxtFactor
        '
        Me.TxtFactor.Location = New System.Drawing.Point(1471, 128)
        Me.TxtFactor.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFactor.Name = "TxtFactor"
        Me.TxtFactor.Size = New System.Drawing.Size(152, 31)
        Me.TxtFactor.TabIndex = 10
        '
        'BtnNextStep
        '
        Me.BtnNextStep.Location = New System.Drawing.Point(1260, 801)
        Me.BtnNextStep.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnNextStep.Name = "BtnNextStep"
        Me.BtnNextStep.Size = New System.Drawing.Size(364, 56)
        Me.BtnNextStep.TabIndex = 11
        Me.BtnNextStep.Text = "NextStep"
        Me.BtnNextStep.UseVisualStyleBackColor = True
        '
        'BtnReset
        '
        Me.BtnReset.Location = New System.Drawing.Point(1260, 1109)
        Me.BtnReset.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(364, 56)
        Me.BtnReset.TabIndex = 12
        Me.BtnReset.Text = "ResetIteration"
        Me.BtnReset.UseVisualStyleBackColor = True
        '
        'BtnNext10
        '
        Me.BtnNext10.Location = New System.Drawing.Point(1260, 886)
        Me.BtnNext10.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnNext10.Name = "BtnNext10"
        Me.BtnNext10.Size = New System.Drawing.Size(364, 56)
        Me.BtnNext10.TabIndex = 13
        Me.BtnNext10.Text = "Next10Steps"
        Me.BtnNext10.UseVisualStyleBackColor = True
        '
        'PicPhasePortrait
        '
        Me.PicPhasePortrait.BackColor = System.Drawing.Color.White
        Me.PicPhasePortrait.Location = New System.Drawing.Point(1652, 2)
        Me.PicPhasePortrait.Margin = New System.Windows.Forms.Padding(4)
        Me.PicPhasePortrait.Name = "PicPhasePortrait"
        Me.PicPhasePortrait.Size = New System.Drawing.Size(821, 770)
        Me.PicPhasePortrait.TabIndex = 16
        Me.PicPhasePortrait.TabStop = False
        '
        'BtnNewBall
        '
        Me.BtnNewBall.Location = New System.Drawing.Point(1260, 354)
        Me.BtnNewBall.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnNewBall.Name = "BtnNewBall"
        Me.BtnNewBall.Size = New System.Drawing.Size(364, 56)
        Me.BtnNewBall.TabIndex = 17
        Me.BtnNewBall.Text = "NewBall"
        Me.BtnNewBall.UseVisualStyleBackColor = True
        '
        'CboBallColor
        '
        Me.CboBallColor.BackColor = System.Drawing.Color.White
        Me.CboBallColor.FormattingEnabled = True
        Me.CboBallColor.Items.AddRange(New Object() {"Red", "Green", "Blue", "Black", "Magenta"})
        Me.CboBallColor.Location = New System.Drawing.Point(1260, 300)
        Me.CboBallColor.Margin = New System.Windows.Forms.Padding(4)
        Me.CboBallColor.Name = "CboBallColor"
        Me.CboBallColor.Size = New System.Drawing.Size(292, 33)
        Me.CboBallColor.TabIndex = 18
        '
        'LblBallColor
        '
        Me.LblBallColor.AutoSize = True
        Me.LblBallColor.Location = New System.Drawing.Point(1255, 252)
        Me.LblBallColor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBallColor.Name = "LblBallColor"
        Me.LblBallColor.Size = New System.Drawing.Size(212, 25)
        Me.LblBallColor.TabIndex = 19
        Me.LblBallColor.Text = "BallColor"
        '
        'TrbSpeed
        '
        Me.TrbSpeed.Location = New System.Drawing.Point(1260, 708)
        Me.TrbSpeed.Margin = New System.Windows.Forms.Padding(4)
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
        Me.LblSpeed.Location = New System.Drawing.Point(1272, 668)
        Me.LblSpeed.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSpeed.Name = "LblSpeed"
        Me.LblSpeed.Size = New System.Drawing.Size(179, 25)
        Me.LblSpeed.TabIndex = 21
        Me.LblSpeed.Text = "BallSpeed"
        '
        'LblColor
        '
        Me.LblColor.BackColor = System.Drawing.Color.Red
        Me.LblColor.Location = New System.Drawing.Point(1561, 300)
        Me.LblColor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblColor.Name = "LblColor"
        Me.LblColor.Size = New System.Drawing.Size(63, 35)
        Me.LblColor.TabIndex = 22
        '
        'LblPhasePortrait
        '
        Me.LblPhasePortrait.AutoSize = True
        Me.LblPhasePortrait.Location = New System.Drawing.Point(1981, 801)
        Me.LblPhasePortrait.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPhasePortrait.Name = "LblPhasePortrait"
        Me.LblPhasePortrait.Size = New System.Drawing.Size(207, 25)
        Me.LblPhasePortrait.TabIndex = 23
        Me.LblPhasePortrait.Text = "PhasePortrait"
        '
        'GrpStartParameter
        '
        Me.GrpStartParameter.Controls.Add(Me.BtnUseStartParameter)
        Me.GrpStartParameter.Controls.Add(Me.TxtAlfa)
        Me.GrpStartParameter.Controls.Add(Me.TxtT)
        Me.GrpStartParameter.Controls.Add(Me.LblAlfa)
        Me.GrpStartParameter.Controls.Add(Me.LblT)
        Me.GrpStartParameter.Location = New System.Drawing.Point(1260, 439)
        Me.GrpStartParameter.Margin = New System.Windows.Forms.Padding(4)
        Me.GrpStartParameter.Name = "GrpStartParameter"
        Me.GrpStartParameter.Padding = New System.Windows.Forms.Padding(4)
        Me.GrpStartParameter.Size = New System.Drawing.Size(364, 214)
        Me.GrpStartParameter.TabIndex = 24
        Me.GrpStartParameter.TabStop = False
        Me.GrpStartParameter.Text = "StartParameter"
        '
        'BtnUseStartParameter
        '
        Me.BtnUseStartParameter.Location = New System.Drawing.Point(17, 140)
        Me.BtnUseStartParameter.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnUseStartParameter.Name = "BtnUseStartParameter"
        Me.BtnUseStartParameter.Size = New System.Drawing.Size(339, 48)
        Me.BtnUseStartParameter.TabIndex = 4
        Me.BtnUseStartParameter.Text = "TakeOver"
        Me.BtnUseStartParameter.UseVisualStyleBackColor = True
        '
        'TxtAlfa
        '
        Me.TxtAlfa.Location = New System.Drawing.Point(84, 88)
        Me.TxtAlfa.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtAlfa.Name = "TxtAlfa"
        Me.TxtAlfa.Size = New System.Drawing.Size(208, 31)
        Me.TxtAlfa.TabIndex = 3
        '
        'TxtT
        '
        Me.TxtT.Location = New System.Drawing.Point(84, 40)
        Me.TxtT.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtT.Name = "TxtT"
        Me.TxtT.Size = New System.Drawing.Size(208, 31)
        Me.TxtT.TabIndex = 2
        '
        'LblAlfa
        '
        Me.LblAlfa.AutoSize = True
        Me.LblAlfa.Location = New System.Drawing.Point(12, 95)
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
        Me.LstParameterList.Margin = New System.Windows.Forms.Padding(4)
        Me.LstParameterList.Name = "LstParameterList"
        Me.LstParameterList.Size = New System.Drawing.Size(820, 329)
        Me.LstParameterList.TabIndex = 25
        '
        'LblBillardTable
        '
        Me.LblBillardTable.AutoSize = True
        Me.LblBillardTable.Location = New System.Drawing.Point(1255, 11)
        Me.LblBillardTable.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBillardTable.Name = "LblBillardTable"
        Me.LblBillardTable.Size = New System.Drawing.Size(132, 25)
        Me.LblBillardTable.TabIndex = 26
        Me.LblBillardTable.Text = "BillardTable"
        '
        'CboBillardTable
        '
        Me.CboBillardTable.FormattingEnabled = True
        Me.CboBillardTable.Items.AddRange(New Object() {"Elliptic", "Stadium", "Oval"})
        Me.CboBillardTable.Location = New System.Drawing.Point(1260, 59)
        Me.CboBillardTable.Margin = New System.Windows.Forms.Padding(4)
        Me.CboBillardTable.Name = "CboBillardTable"
        Me.CboBillardTable.Size = New System.Drawing.Size(363, 33)
        Me.CboBillardTable.TabIndex = 27
        '
        'LblNumber
        '
        Me.LblNumber.AutoSize = True
        Me.LblNumber.Location = New System.Drawing.Point(1272, 1062)
        Me.LblNumber.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNumber.Name = "LblNumber"
        Me.LblNumber.Size = New System.Drawing.Size(172, 25)
        Me.LblNumber.TabIndex = 28
        Me.LblNumber.Text = "NumberOfSteps"
        '
        'LblNumberofSteps
        '
        Me.LblNumberofSteps.AutoSize = True
        Me.LblNumberofSteps.Location = New System.Drawing.Point(1465, 1062)
        Me.LblNumberofSteps.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNumberofSteps.Name = "LblNumberofSteps"
        Me.LblNumberofSteps.Size = New System.Drawing.Size(24, 25)
        Me.LblNumberofSteps.TabIndex = 29
        Me.LblNumberofSteps.Text = "0"
        '
        'BtnNext100
        '
        Me.BtnNext100.Location = New System.Drawing.Point(1260, 978)
        Me.BtnNext100.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnNext100.Name = "BtnNext100"
        Me.BtnNext100.Size = New System.Drawing.Size(364, 56)
        Me.BtnNext100.TabIndex = 30
        Me.BtnNext100.Text = "Next100Steps"
        Me.BtnNext100.UseVisualStyleBackColor = True
        '
        'FrmBillardTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2565, 1185)
        Me.Controls.Add(Me.BtnNext100)
        Me.Controls.Add(Me.LblNumberofSteps)
        Me.Controls.Add(Me.LblNumber)
        Me.Controls.Add(Me.CboBillardTable)
        Me.Controls.Add(Me.LblBillardTable)
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
        Me.Controls.Add(Me.BtnNext10)
        Me.Controls.Add(Me.BtnReset)
        Me.Controls.Add(Me.BtnNextStep)
        Me.Controls.Add(Me.TxtFactor)
        Me.Controls.Add(Me.LblParameterc)
        Me.Controls.Add(Me.BtnDrawBillardTable)
        Me.Controls.Add(Me.PicBillardTable)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmBillardTable"
        Me.Text = "Billard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PicBillardTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicPhasePortrait, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrbSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpStartParameter.ResumeLayout(False)
        Me.GrpStartParameter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PicBillardTable As PictureBox
    Friend WithEvents BtnDrawBillardTable As Button
    Friend WithEvents LblParameterc As Label
    Friend WithEvents TxtFactor As TextBox
    Friend WithEvents BtnNextStep As Button
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnNext10 As Button
    Friend WithEvents PicPhasePortrait As PictureBox
    Friend WithEvents BtnNewBall As Button
    Friend WithEvents CboBallColor As ComboBox
    Friend WithEvents LblBallColor As Label
    Friend WithEvents TrbSpeed As TrackBar
    Friend WithEvents LblSpeed As Label
    Friend WithEvents LblColor As Label
    Friend WithEvents LblPhasePortrait As Label
    Friend WithEvents GrpStartParameter As GroupBox
    Friend WithEvents BtnUseStartParameter As Button
    Friend WithEvents TxtAlfa As TextBox
    Friend WithEvents TxtT As TextBox
    Friend WithEvents LblAlfa As Label
    Friend WithEvents LblT As Label
    Friend WithEvents LstParameterList As ListBox
    Friend WithEvents LblBillardTable As Label
    Friend WithEvents CboBillardTable As ComboBox
    Friend WithEvents LblNumber As Label
    Friend WithEvents LblNumberofSteps As Label
    Friend WithEvents BtnNext100 As Button
End Class
