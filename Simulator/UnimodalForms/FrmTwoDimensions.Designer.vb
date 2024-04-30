<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTwoDimensions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTwoDimensions))
        Me.PicDiagram = New System.Windows.Forms.PictureBox()
        Me.GrpStartpoint = New System.Windows.Forms.GroupBox()
        Me.TxtY = New System.Windows.Forms.TextBox()
        Me.TxtX = New System.Windows.Forms.TextBox()
        Me.LblY = New System.Windows.Forms.Label()
        Me.LblX = New System.Windows.Forms.Label()
        Me.BtnNext10 = New System.Windows.Forms.Button()
        Me.BtnReset = New System.Windows.Forms.Button()
        Me.BtnNextStep = New System.Windows.Forms.Button()
        Me.GrpExperiment = New System.Windows.Forms.GroupBox()
        Me.CboExperiment = New System.Windows.Forms.ComboBox()
        Me.GrpParameter = New System.Windows.Forms.GroupBox()
        Me.TxtParameter = New System.Windows.Forms.TextBox()
        Me.LblParameter = New System.Windows.Forms.Label()
        Me.CboFunction = New System.Windows.Forms.ComboBox()
        CType(Me.PicDiagram, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpStartpoint.SuspendLayout()
        Me.GrpExperiment.SuspendLayout()
        Me.GrpParameter.SuspendLayout()
        Me.SuspendLayout()
        '
        'PicDiagram
        '
        Me.PicDiagram.BackColor = System.Drawing.Color.White
        Me.PicDiagram.Location = New System.Drawing.Point(1, 0)
        Me.PicDiagram.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PicDiagram.Name = "PicDiagram"
        Me.PicDiagram.Size = New System.Drawing.Size(1243, 1165)
        Me.PicDiagram.TabIndex = 1
        Me.PicDiagram.TabStop = False
        '
        'GrpStartpoint
        '
        Me.GrpStartpoint.Controls.Add(Me.TxtY)
        Me.GrpStartpoint.Controls.Add(Me.TxtX)
        Me.GrpStartpoint.Controls.Add(Me.LblY)
        Me.GrpStartpoint.Controls.Add(Me.LblX)
        Me.GrpStartpoint.Location = New System.Drawing.Point(1263, 191)
        Me.GrpStartpoint.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GrpStartpoint.Name = "GrpStartpoint"
        Me.GrpStartpoint.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GrpStartpoint.Size = New System.Drawing.Size(363, 136)
        Me.GrpStartpoint.TabIndex = 1
        Me.GrpStartpoint.TabStop = False
        Me.GrpStartpoint.Text = "CoordinatesStartpoint"
        '
        'TxtY
        '
        Me.TxtY.AcceptsReturn = True
        Me.TxtY.AcceptsTab = True
        Me.TxtY.Location = New System.Drawing.Point(84, 96)
        Me.TxtY.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtY.Name = "TxtY"
        Me.TxtY.Size = New System.Drawing.Size(255, 31)
        Me.TxtY.TabIndex = 3
        '
        'TxtX
        '
        Me.TxtX.AcceptsReturn = True
        Me.TxtX.AcceptsTab = True
        Me.TxtX.Location = New System.Drawing.Point(84, 52)
        Me.TxtX.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtX.Name = "TxtX"
        Me.TxtX.Size = New System.Drawing.Size(255, 31)
        Me.TxtX.TabIndex = 2
        '
        'LblY
        '
        Me.LblY.AutoSize = True
        Me.LblY.Location = New System.Drawing.Point(25, 100)
        Me.LblY.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblY.Name = "LblY"
        Me.LblY.Size = New System.Drawing.Size(41, 25)
        Me.LblY.TabIndex = 5
        Me.LblY.Text = "y ="
        '
        'LblX
        '
        Me.LblX.AutoSize = True
        Me.LblX.Location = New System.Drawing.Point(25, 60)
        Me.LblX.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblX.Name = "LblX"
        Me.LblX.Size = New System.Drawing.Size(41, 25)
        Me.LblX.TabIndex = 4
        Me.LblX.Text = "x ="
        '
        'BtnNext10
        '
        Me.BtnNext10.Location = New System.Drawing.Point(1273, 575)
        Me.BtnNext10.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnNext10.Name = "BtnNext10"
        Me.BtnNext10.Size = New System.Drawing.Size(357, 51)
        Me.BtnNext10.TabIndex = 9
        Me.BtnNext10.Text = "Next10Steps"
        Me.BtnNext10.UseVisualStyleBackColor = True
        '
        'BtnReset
        '
        Me.BtnReset.Location = New System.Drawing.Point(1273, 1114)
        Me.BtnReset.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(357, 51)
        Me.BtnReset.TabIndex = 10
        Me.BtnReset.Text = "ResetIteration"
        Me.BtnReset.UseVisualStyleBackColor = True
        '
        'BtnNextStep
        '
        Me.BtnNextStep.Location = New System.Drawing.Point(1273, 500)
        Me.BtnNextStep.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnNextStep.Name = "BtnNextStep"
        Me.BtnNextStep.Size = New System.Drawing.Size(357, 51)
        Me.BtnNextStep.TabIndex = 8
        Me.BtnNextStep.Text = "NextStep"
        Me.BtnNextStep.UseVisualStyleBackColor = True
        '
        'GrpExperiment
        '
        Me.GrpExperiment.Controls.Add(Me.CboExperiment)
        Me.GrpExperiment.Location = New System.Drawing.Point(1263, 348)
        Me.GrpExperiment.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GrpExperiment.Name = "GrpExperiment"
        Me.GrpExperiment.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GrpExperiment.Size = New System.Drawing.Size(363, 129)
        Me.GrpExperiment.TabIndex = 6
        Me.GrpExperiment.TabStop = False
        Me.GrpExperiment.Text = "ExperimentNo"
        '
        'CboExperiment
        '
        Me.CboExperiment.FormattingEnabled = True
        Me.CboExperiment.Items.AddRange(New Object() {"Experiment 1", "Experiment 2", "Experiment 3", "Experiment 4", "Experiment 5"})
        Me.CboExperiment.Location = New System.Drawing.Point(21, 51)
        Me.CboExperiment.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CboExperiment.Name = "CboExperiment"
        Me.CboExperiment.Size = New System.Drawing.Size(317, 33)
        Me.CboExperiment.TabIndex = 7
        '
        'GrpParameter
        '
        Me.GrpParameter.Controls.Add(Me.TxtParameter)
        Me.GrpParameter.Controls.Add(Me.LblParameter)
        Me.GrpParameter.Location = New System.Drawing.Point(1263, 82)
        Me.GrpParameter.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GrpParameter.Name = "GrpParameter"
        Me.GrpParameter.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GrpParameter.Size = New System.Drawing.Size(363, 101)
        Me.GrpParameter.TabIndex = 4
        Me.GrpParameter.TabStop = False
        Me.GrpParameter.Text = "Parameter"
        '
        'TxtParameter
        '
        Me.TxtParameter.AcceptsReturn = True
        Me.TxtParameter.AcceptsTab = True
        Me.TxtParameter.Location = New System.Drawing.Point(80, 34)
        Me.TxtParameter.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtParameter.Name = "TxtParameter"
        Me.TxtParameter.Size = New System.Drawing.Size(253, 31)
        Me.TxtParameter.TabIndex = 5
        '
        'LblParameter
        '
        Me.LblParameter.AutoSize = True
        Me.LblParameter.Location = New System.Drawing.Point(21, 41)
        Me.LblParameter.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblParameter.Name = "LblParameter"
        Me.LblParameter.Size = New System.Drawing.Size(42, 25)
        Me.LblParameter.TabIndex = 0
        Me.LblParameter.Text = "a ="
        '
        'CboFunction
        '
        Me.CboFunction.FormattingEnabled = True
        Me.CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic growth", "Parabola"})
        Me.CboFunction.Location = New System.Drawing.Point(1263, 15)
        Me.CboFunction.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CboFunction.Name = "CboFunction"
        Me.CboFunction.Size = New System.Drawing.Size(361, 33)
        Me.CboFunction.TabIndex = 11
        '
        'FrmTwoDimensions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1665, 1180)
        Me.Controls.Add(Me.CboFunction)
        Me.Controls.Add(Me.GrpParameter)
        Me.Controls.Add(Me.GrpExperiment)
        Me.Controls.Add(Me.BtnNextStep)
        Me.Controls.Add(Me.BtnReset)
        Me.Controls.Add(Me.BtnNext10)
        Me.Controls.Add(Me.GrpStartpoint)
        Me.Controls.Add(Me.PicDiagram)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmTwoDimensions"
        Me.Text = "TwoDimensions"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PicDiagram, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpStartpoint.ResumeLayout(False)
        Me.GrpStartpoint.PerformLayout()
        Me.GrpExperiment.ResumeLayout(False)
        Me.GrpParameter.ResumeLayout(False)
        Me.GrpParameter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents GrpStartpoint As GroupBox
    Friend WithEvents TxtY As TextBox
    Friend WithEvents TxtX As TextBox
    Friend WithEvents LblY As Label
    Friend WithEvents LblX As Label
    Friend WithEvents BtnNext10 As Button
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnNextStep As Button
    Friend WithEvents GrpExperiment As GroupBox
    Friend WithEvents CboExperiment As ComboBox
    Friend WithEvents GrpParameter As GroupBox
    Friend WithEvents TxtParameter As TextBox
    Friend WithEvents LblParameter As Label
    Friend WithEvents CboFunction As ComboBox
End Class
