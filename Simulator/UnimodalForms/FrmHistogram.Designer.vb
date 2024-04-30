<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHistogram
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHistogram))
        Me.PicDiagram = New System.Windows.Forms.PictureBox()
        Me.TxtParameter = New System.Windows.Forms.TextBox()
        Me.LblParameter = New System.Windows.Forms.Label()
        Me.TxtStartValue = New System.Windows.Forms.TextBox()
        Me.LblStartValue = New System.Windows.Forms.Label()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.BtnReset = New System.Windows.Forms.Button()
        Me.LblNumberOfSteps = New System.Windows.Forms.Label()
        Me.LblSteps = New System.Windows.Forms.Label()
        Me.CboFunction = New System.Windows.Forms.ComboBox()
        Me.BtnStop = New System.Windows.Forms.Button()
        CType(Me.PicDiagram, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PicDiagram
        '
        Me.PicDiagram.BackColor = System.Drawing.Color.White
        Me.PicDiagram.Location = New System.Drawing.Point(3, 4)
        Me.PicDiagram.Margin = New System.Windows.Forms.Padding(4)
        Me.PicDiagram.Name = "PicDiagram"
        Me.PicDiagram.Size = New System.Drawing.Size(1227, 1174)
        Me.PicDiagram.TabIndex = 1
        Me.PicDiagram.TabStop = False
        '
        'TxtParameter
        '
        Me.TxtParameter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtParameter.Location = New System.Drawing.Point(1423, 96)
        Me.TxtParameter.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtParameter.Name = "TxtParameter"
        Me.TxtParameter.Size = New System.Drawing.Size(204, 32)
        Me.TxtParameter.TabIndex = 10
        '
        'LblParameter
        '
        Me.LblParameter.AutoSize = True
        Me.LblParameter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblParameter.Location = New System.Drawing.Point(1281, 100)
        Me.LblParameter.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblParameter.Name = "LblParameter"
        Me.LblParameter.Size = New System.Drawing.Size(139, 26)
        Me.LblParameter.TabIndex = 11
        Me.LblParameter.Text = "Parameter = "
        '
        'TxtStartValue
        '
        Me.TxtStartValue.Location = New System.Drawing.Point(1423, 148)
        Me.TxtStartValue.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtStartValue.Name = "TxtStartValue"
        Me.TxtStartValue.Size = New System.Drawing.Size(204, 31)
        Me.TxtStartValue.TabIndex = 12
        '
        'LblStartValue
        '
        Me.LblStartValue.AutoSize = True
        Me.LblStartValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStartValue.Location = New System.Drawing.Point(1281, 155)
        Me.LblStartValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblStartValue.Name = "LblStartValue"
        Me.LblStartValue.Size = New System.Drawing.Size(133, 26)
        Me.LblStartValue.TabIndex = 13
        Me.LblStartValue.Text = "StartValue ="
        '
        'BtnStart
        '
        Me.BtnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStart.Location = New System.Drawing.Point(1287, 272)
        Me.BtnStart.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(341, 61)
        Me.BtnStart.TabIndex = 18
        Me.BtnStart.Text = "Start"
        Me.BtnStart.UseVisualStyleBackColor = True
        '
        'BtnReset
        '
        Me.BtnReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReset.Location = New System.Drawing.Point(1286, 1117)
        Me.BtnReset.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(341, 61)
        Me.BtnReset.TabIndex = 19
        Me.BtnReset.Text = "ResetIteration"
        Me.BtnReset.UseVisualStyleBackColor = True
        '
        'LblNumberOfSteps
        '
        Me.LblNumberOfSteps.AutoSize = True
        Me.LblNumberOfSteps.Location = New System.Drawing.Point(1456, 219)
        Me.LblNumberOfSteps.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNumberOfSteps.Name = "LblNumberOfSteps"
        Me.LblNumberOfSteps.Size = New System.Drawing.Size(24, 25)
        Me.LblNumberOfSteps.TabIndex = 28
        Me.LblNumberOfSteps.Text = "0"
        '
        'LblSteps
        '
        Me.LblSteps.AutoSize = True
        Me.LblSteps.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSteps.Location = New System.Drawing.Point(1281, 219)
        Me.LblSteps.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSteps.Name = "LblSteps"
        Me.LblSteps.Size = New System.Drawing.Size(169, 26)
        Me.LblSteps.TabIndex = 27
        Me.LblSteps.Text = "NumberOfSteps"
        '
        'CboFunction
        '
        Me.CboFunction.FormattingEnabled = True
        Me.CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic Growth", "Parabola"})
        Me.CboFunction.Location = New System.Drawing.Point(1287, 30)
        Me.CboFunction.Margin = New System.Windows.Forms.Padding(4)
        Me.CboFunction.Name = "CboFunction"
        Me.CboFunction.Size = New System.Drawing.Size(340, 33)
        Me.CboFunction.TabIndex = 29
        '
        'BtnStop
        '
        Me.BtnStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStop.Location = New System.Drawing.Point(1286, 359)
        Me.BtnStop.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(341, 61)
        Me.BtnStop.TabIndex = 30
        Me.BtnStop.Text = "Stop"
        Me.BtnStop.UseVisualStyleBackColor = True
        '
        'FrmHistogram
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2349, 1193)
        Me.Controls.Add(Me.BtnStop)
        Me.Controls.Add(Me.CboFunction)
        Me.Controls.Add(Me.LblNumberOfSteps)
        Me.Controls.Add(Me.LblSteps)
        Me.Controls.Add(Me.BtnStart)
        Me.Controls.Add(Me.BtnReset)
        Me.Controls.Add(Me.TxtStartValue)
        Me.Controls.Add(Me.LblStartValue)
        Me.Controls.Add(Me.TxtParameter)
        Me.Controls.Add(Me.LblParameter)
        Me.Controls.Add(Me.PicDiagram)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmHistogram"
        Me.RightToLeftLayout = True
        Me.Text = "Histogram"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PicDiagram, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents TxtParameter As TextBox
    Friend WithEvents LblParameter As Label
    Friend WithEvents TxtStartValue As TextBox
    Friend WithEvents LblStartValue As Label
    Friend WithEvents BtnStart As Button
    Friend WithEvents BtnReset As Button
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents LblSteps As Label
    Friend WithEvents CboFunction As ComboBox
    Friend WithEvents BtnStop As Button
End Class
