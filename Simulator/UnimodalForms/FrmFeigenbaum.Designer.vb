<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFeigenbaum
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFeigenbaum))
        Me.PicDiagram = New System.Windows.Forms.PictureBox()
        Me.BtnReset = New System.Windows.Forms.Button()
        Me.BtnStartIteration = New System.Windows.Forms.Button()
        Me.LblParameterRange = New System.Windows.Forms.Label()
        Me.LblAmin = New System.Windows.Forms.Label()
        Me.TxtAMin = New System.Windows.Forms.TextBox()
        Me.TxtAMax = New System.Windows.Forms.TextBox()
        Me.LblAmax = New System.Windows.Forms.Label()
        Me.CboFunction = New System.Windows.Forms.ComboBox()
        Me.TrbPrecision = New System.Windows.Forms.TrackBar()
        Me.LblPrecision = New System.Windows.Forms.Label()
        Me.TxtXMax = New System.Windows.Forms.TextBox()
        Me.LblXmax = New System.Windows.Forms.Label()
        Me.TxtXMin = New System.Windows.Forms.TextBox()
        Me.LblXmin = New System.Windows.Forms.Label()
        Me.LblValueRange = New System.Windows.Forms.Label()
        Me.LblDeltaA = New System.Windows.Forms.Label()
        Me.LblDeltaX = New System.Windows.Forms.Label()
        Me.ChkSplitPoints = New System.Windows.Forms.CheckBox()
        Me.ChkColored = New System.Windows.Forms.CheckBox()
        CType(Me.PicDiagram, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrbPrecision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PicDiagram
        '
        Me.PicDiagram.BackColor = System.Drawing.Color.White
        Me.PicDiagram.Location = New System.Drawing.Point(4, 15)
        Me.PicDiagram.Margin = New System.Windows.Forms.Padding(4)
        Me.PicDiagram.Name = "PicDiagram"
        Me.PicDiagram.Size = New System.Drawing.Size(1243, 1150)
        Me.PicDiagram.TabIndex = 2
        Me.PicDiagram.TabStop = False
        '
        'BtnReset
        '
        Me.BtnReset.Location = New System.Drawing.Point(1287, 1114)
        Me.BtnReset.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(396, 51)
        Me.BtnReset.TabIndex = 4
        Me.BtnReset.Text = "ResetIteration"
        Me.BtnReset.UseVisualStyleBackColor = True
        '
        'BtnStartIteration
        '
        Me.BtnStartIteration.Location = New System.Drawing.Point(1287, 784)
        Me.BtnStartIteration.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnStartIteration.Name = "BtnStartIteration"
        Me.BtnStartIteration.Size = New System.Drawing.Size(396, 51)
        Me.BtnStartIteration.TabIndex = 3
        Me.BtnStartIteration.Text = "StartIteration"
        Me.BtnStartIteration.UseVisualStyleBackColor = True
        '
        'LblParameterRange
        '
        Me.LblParameterRange.AutoSize = True
        Me.LblParameterRange.Location = New System.Drawing.Point(1281, 94)
        Me.LblParameterRange.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblParameterRange.Name = "LblParameterRange"
        Me.LblParameterRange.Size = New System.Drawing.Size(287, 25)
        Me.LblParameterRange.TabIndex = 11
        Me.LblParameterRange.Text = "ExaminatedParameterRange"
        '
        'LblAmin
        '
        Me.LblAmin.AutoSize = True
        Me.LblAmin.Location = New System.Drawing.Point(1281, 141)
        Me.LblAmin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAmin.Name = "LblAmin"
        Me.LblAmin.Size = New System.Drawing.Size(77, 25)
        Me.LblAmin.TabIndex = 12
        Me.LblAmin.Text = "aMin ="
        '
        'TxtAMin
        '
        Me.TxtAMin.AcceptsReturn = True
        Me.TxtAMin.AcceptsTab = True
        Me.TxtAMin.Location = New System.Drawing.Point(1364, 134)
        Me.TxtAMin.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtAMin.Name = "TxtAMin"
        Me.TxtAMin.Size = New System.Drawing.Size(315, 31)
        Me.TxtAMin.TabIndex = 1
        '
        'TxtAMax
        '
        Me.TxtAMax.AcceptsReturn = True
        Me.TxtAMax.AcceptsTab = True
        Me.TxtAMax.Location = New System.Drawing.Point(1364, 186)
        Me.TxtAMax.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtAMax.Name = "TxtAMax"
        Me.TxtAMax.Size = New System.Drawing.Size(315, 31)
        Me.TxtAMax.TabIndex = 2
        '
        'LblAmax
        '
        Me.LblAmax.AutoSize = True
        Me.LblAmax.Location = New System.Drawing.Point(1279, 194)
        Me.LblAmax.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAmax.Name = "LblAmax"
        Me.LblAmax.Size = New System.Drawing.Size(83, 25)
        Me.LblAmax.TabIndex = 14
        Me.LblAmax.Text = "aMax ="
        '
        'CboFunction
        '
        Me.CboFunction.FormattingEnabled = True
        Me.CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic Growth", "Parabola"})
        Me.CboFunction.Location = New System.Drawing.Point(1287, 15)
        Me.CboFunction.Margin = New System.Windows.Forms.Padding(4)
        Me.CboFunction.Name = "CboFunction"
        Me.CboFunction.Size = New System.Drawing.Size(395, 33)
        Me.CboFunction.TabIndex = 30
        '
        'TrbPrecision
        '
        Me.TrbPrecision.Location = New System.Drawing.Point(1287, 569)
        Me.TrbPrecision.Margin = New System.Windows.Forms.Padding(4)
        Me.TrbPrecision.Maximum = 100
        Me.TrbPrecision.Minimum = 1
        Me.TrbPrecision.Name = "TrbPrecision"
        Me.TrbPrecision.Size = New System.Drawing.Size(396, 90)
        Me.TrbPrecision.TabIndex = 32
        Me.TrbPrecision.Value = 25
        '
        'LblPrecision
        '
        Me.LblPrecision.AutoSize = True
        Me.LblPrecision.Location = New System.Drawing.Point(1281, 516)
        Me.LblPrecision.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPrecision.Name = "LblPrecision"
        Me.LblPrecision.Size = New System.Drawing.Size(173, 25)
        Me.LblPrecision.TabIndex = 33
        Me.LblPrecision.Text = "Precision: 25000"
        '
        'TxtXMax
        '
        Me.TxtXMax.AcceptsReturn = True
        Me.TxtXMax.AcceptsTab = True
        Me.TxtXMax.Location = New System.Drawing.Point(1364, 395)
        Me.TxtXMax.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtXMax.Name = "TxtXMax"
        Me.TxtXMax.Size = New System.Drawing.Size(317, 31)
        Me.TxtXMax.TabIndex = 36
        '
        'LblXmax
        '
        Me.LblXmax.AutoSize = True
        Me.LblXmax.Location = New System.Drawing.Point(1281, 402)
        Me.LblXmax.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblXmax.Name = "LblXmax"
        Me.LblXmax.Size = New System.Drawing.Size(84, 25)
        Me.LblXmax.TabIndex = 39
        Me.LblXmax.Text = "Xmax ="
        '
        'TxtXMin
        '
        Me.TxtXMin.AcceptsReturn = True
        Me.TxtXMin.AcceptsTab = True
        Me.TxtXMin.Location = New System.Drawing.Point(1364, 341)
        Me.TxtXMin.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtXMin.Name = "TxtXMin"
        Me.TxtXMin.Size = New System.Drawing.Size(317, 31)
        Me.TxtXMin.TabIndex = 35
        '
        'LblXmin
        '
        Me.LblXmin.AutoSize = True
        Me.LblXmin.Location = New System.Drawing.Point(1281, 349)
        Me.LblXmin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblXmin.Name = "LblXmin"
        Me.LblXmin.Size = New System.Drawing.Size(78, 25)
        Me.LblXmin.TabIndex = 38
        Me.LblXmin.Text = "Xmin ="
        '
        'LblValueRange
        '
        Me.LblValueRange.AutoSize = True
        Me.LblValueRange.Location = New System.Drawing.Point(1279, 304)
        Me.LblValueRange.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblValueRange.Name = "LblValueRange"
        Me.LblValueRange.Size = New System.Drawing.Size(243, 25)
        Me.LblValueRange.TabIndex = 37
        Me.LblValueRange.Text = "ExaminatedValueRange"
        '
        'LblDeltaA
        '
        Me.LblDeltaA.AutoSize = True
        Me.LblDeltaA.Location = New System.Drawing.Point(1279, 249)
        Me.LblDeltaA.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDeltaA.Name = "LblDeltaA"
        Me.LblDeltaA.Size = New System.Drawing.Size(86, 25)
        Me.LblDeltaA.TabIndex = 41
        Me.LblDeltaA.Text = "Delta = "
        '
        'LblDeltaX
        '
        Me.LblDeltaX.AutoSize = True
        Me.LblDeltaX.Location = New System.Drawing.Point(1279, 456)
        Me.LblDeltaX.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDeltaX.Name = "LblDeltaX"
        Me.LblDeltaX.Size = New System.Drawing.Size(86, 25)
        Me.LblDeltaX.TabIndex = 43
        Me.LblDeltaX.Text = "Delta = "
        '
        'ChkSplitPoints
        '
        Me.ChkSplitPoints.AutoSize = True
        Me.ChkSplitPoints.Checked = True
        Me.ChkSplitPoints.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkSplitPoints.Location = New System.Drawing.Point(1287, 662)
        Me.ChkSplitPoints.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkSplitPoints.Name = "ChkSplitPoints"
        Me.ChkSplitPoints.Size = New System.Drawing.Size(199, 29)
        Me.ChkSplitPoints.TabIndex = 44
        Me.ChkSplitPoints.Text = "ShowSplitPoints"
        Me.ChkSplitPoints.UseVisualStyleBackColor = True
        '
        'ChkColored
        '
        Me.ChkColored.AutoSize = True
        Me.ChkColored.Location = New System.Drawing.Point(1287, 725)
        Me.ChkColored.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkColored.Name = "ChkColored"
        Me.ChkColored.Size = New System.Drawing.Size(199, 29)
        Me.ChkColored.TabIndex = 46
        Me.ChkColored.Text = "ColoredDiagram"
        Me.ChkColored.UseVisualStyleBackColor = True
        '
        'FrmFeigenbaum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2349, 1180)
        Me.Controls.Add(Me.ChkColored)
        Me.Controls.Add(Me.ChkSplitPoints)
        Me.Controls.Add(Me.LblDeltaX)
        Me.Controls.Add(Me.LblDeltaA)
        Me.Controls.Add(Me.TxtXMax)
        Me.Controls.Add(Me.LblXmax)
        Me.Controls.Add(Me.TxtXMin)
        Me.Controls.Add(Me.LblXmin)
        Me.Controls.Add(Me.LblValueRange)
        Me.Controls.Add(Me.LblPrecision)
        Me.Controls.Add(Me.TrbPrecision)
        Me.Controls.Add(Me.CboFunction)
        Me.Controls.Add(Me.TxtAMax)
        Me.Controls.Add(Me.LblAmax)
        Me.Controls.Add(Me.TxtAMin)
        Me.Controls.Add(Me.LblAmin)
        Me.Controls.Add(Me.LblParameterRange)
        Me.Controls.Add(Me.BtnReset)
        Me.Controls.Add(Me.BtnStartIteration)
        Me.Controls.Add(Me.PicDiagram)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmFeigenbaum"
        Me.Text = "FeigenbaumDiagram"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PicDiagram, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrbPrecision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStartIteration As Button
    Friend WithEvents LblParameterRange As Label
    Friend WithEvents LblAmin As Label
    Friend WithEvents TxtAMin As TextBox
    Friend WithEvents TxtAMax As TextBox
    Friend WithEvents LblAmax As Label
    Friend WithEvents CboFunction As ComboBox
    Friend WithEvents TrbPrecision As TrackBar
    Friend WithEvents LblPrecision As Label
    Friend WithEvents TxtXMax As TextBox
    Friend WithEvents LblXmax As Label
    Friend WithEvents TxtXMin As TextBox
    Friend WithEvents LblXmin As Label
    Friend WithEvents LblValueRange As Label
    Friend WithEvents LblDeltaA As Label
    Friend WithEvents LblDeltaX As Label
    Friend WithEvents ChkSplitPoints As CheckBox
    Friend WithEvents ChkColored As CheckBox
End Class
