<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSpringPendulum
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSpringPendulum))
        Me.LstValueList = New System.Windows.Forms.ListBox()
        Me.PicDiagram = New System.Windows.Forms.PictureBox()
        Me.CboPendulum = New System.Windows.Forms.ComboBox()
        Me.LblPendulum = New System.Windows.Forms.Label()
        Me.LblStepWidth = New System.Windows.Forms.Label()
        Me.TrbStepWidth = New System.Windows.Forms.TrackBar()
        Me.BtnReset = New System.Windows.Forms.Button()
        Me.BtnStop = New System.Windows.Forms.Button()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.LblNumberOfSteps = New System.Windows.Forms.Label()
        Me.LblSteps = New System.Windows.Forms.Label()
        Me.ChkStretched = New System.Windows.Forms.CheckBox()
        Me.LblDifference = New System.Windows.Forms.Label()
        CType(Me.PicDiagram, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrbStepWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LstValueList
        '
        Me.LstValueList.FormattingEnabled = True
        Me.LstValueList.Location = New System.Drawing.Point(962, 33)
        Me.LstValueList.Name = "LstValueList"
        Me.LstValueList.Size = New System.Drawing.Size(150, 446)
        Me.LstValueList.TabIndex = 8
        '
        'PicDiagram
        '
        Me.PicDiagram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicDiagram.Location = New System.Drawing.Point(6, 7)
        Me.PicDiagram.Margin = New System.Windows.Forms.Padding(2)
        Me.PicDiagram.Name = "PicDiagram"
        Me.PicDiagram.Size = New System.Drawing.Size(739, 471)
        Me.PicDiagram.TabIndex = 7
        Me.PicDiagram.TabStop = False
        '
        'CboPendulum
        '
        Me.CboPendulum.FormattingEnabled = True
        Me.CboPendulum.Items.AddRange(New Object() {"RealSpringPendulum", "EulerExplicit", "EulerImplicit", "MidpointImplicit", "RungeKutta4"})
        Me.CboPendulum.Location = New System.Drawing.Point(762, 33)
        Me.CboPendulum.Margin = New System.Windows.Forms.Padding(2)
        Me.CboPendulum.Name = "CboPendulum"
        Me.CboPendulum.Size = New System.Drawing.Size(184, 21)
        Me.CboPendulum.TabIndex = 29
        '
        'LblPendulum
        '
        Me.LblPendulum.AutoSize = True
        Me.LblPendulum.Location = New System.Drawing.Point(760, 8)
        Me.LblPendulum.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblPendulum.Name = "LblPendulum"
        Me.LblPendulum.Size = New System.Drawing.Size(54, 13)
        Me.LblPendulum.TabIndex = 28
        Me.LblPendulum.Text = "Pendulum"
        '
        'LblStepWidth
        '
        Me.LblStepWidth.AutoSize = True
        Me.LblStepWidth.Location = New System.Drawing.Point(768, 66)
        Me.LblStepWidth.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblStepWidth.Name = "LblStepWidth"
        Me.LblStepWidth.Size = New System.Drawing.Size(57, 13)
        Me.LblStepWidth.TabIndex = 31
        Me.LblStepWidth.Text = "StepWidth"
        '
        'TrbStepWidth
        '
        Me.TrbStepWidth.Location = New System.Drawing.Point(762, 87)
        Me.TrbStepWidth.Margin = New System.Windows.Forms.Padding(2)
        Me.TrbStepWidth.Maximum = 15
        Me.TrbStepWidth.Minimum = 1
        Me.TrbStepWidth.Name = "TrbStepWidth"
        Me.TrbStepWidth.Size = New System.Drawing.Size(182, 45)
        Me.TrbStepWidth.TabIndex = 30
        Me.TrbStepWidth.Value = 5
        '
        'BtnReset
        '
        Me.BtnReset.Location = New System.Drawing.Point(762, 323)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(182, 34)
        Me.BtnReset.TabIndex = 34
        Me.BtnReset.Text = "Reset"
        Me.BtnReset.UseVisualStyleBackColor = True
        '
        'BtnStop
        '
        Me.BtnStop.Location = New System.Drawing.Point(762, 264)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(182, 34)
        Me.BtnStop.TabIndex = 33
        Me.BtnStop.Text = "Stop"
        Me.BtnStop.UseVisualStyleBackColor = True
        '
        'BtnStart
        '
        Me.BtnStart.Location = New System.Drawing.Point(763, 184)
        Me.BtnStart.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(182, 34)
        Me.BtnStart.TabIndex = 32
        Me.BtnStart.Text = "Start"
        Me.BtnStart.UseVisualStyleBackColor = True
        '
        'LblNumberOfSteps
        '
        Me.LblNumberOfSteps.AutoSize = True
        Me.LblNumberOfSteps.Location = New System.Drawing.Point(760, 234)
        Me.LblNumberOfSteps.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblNumberOfSteps.Name = "LblNumberOfSteps"
        Me.LblNumberOfSteps.Size = New System.Drawing.Size(89, 13)
        Me.LblNumberOfSteps.TabIndex = 35
        Me.LblNumberOfSteps.Text = "Number of Steps:"
        '
        'LblSteps
        '
        Me.LblSteps.AutoSize = True
        Me.LblSteps.Location = New System.Drawing.Point(857, 234)
        Me.LblSteps.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblSteps.Name = "LblSteps"
        Me.LblSteps.Size = New System.Drawing.Size(13, 13)
        Me.LblSteps.TabIndex = 36
        Me.LblSteps.Text = "0"
        '
        'ChkStretched
        '
        Me.ChkStretched.AutoSize = True
        Me.ChkStretched.Location = New System.Drawing.Point(763, 137)
        Me.ChkStretched.Name = "ChkStretched"
        Me.ChkStretched.Size = New System.Drawing.Size(99, 17)
        Me.ChkStretched.TabIndex = 37
        Me.ChkStretched.Text = "StretchedMode"
        Me.ChkStretched.UseVisualStyleBackColor = True
        '
        'LblDifference
        '
        Me.LblDifference.AutoSize = True
        Me.LblDifference.Location = New System.Drawing.Point(962, 9)
        Me.LblDifference.Name = "LblDifference"
        Me.LblDifference.Size = New System.Drawing.Size(56, 13)
        Me.LblDifference.TabIndex = 38
        Me.LblDifference.Text = "Difference"
        '
        'FrmSpringPendulum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1131, 488)
        Me.Controls.Add(Me.LblDifference)
        Me.Controls.Add(Me.ChkStretched)
        Me.Controls.Add(Me.LblSteps)
        Me.Controls.Add(Me.LblNumberOfSteps)
        Me.Controls.Add(Me.BtnReset)
        Me.Controls.Add(Me.BtnStop)
        Me.Controls.Add(Me.BtnStart)
        Me.Controls.Add(Me.LblStepWidth)
        Me.Controls.Add(Me.TrbStepWidth)
        Me.Controls.Add(Me.CboPendulum)
        Me.Controls.Add(Me.LblPendulum)
        Me.Controls.Add(Me.LstValueList)
        Me.Controls.Add(Me.PicDiagram)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmSpringPendulum"
        Me.Text = "SpringPendulum"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PicDiagram, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrbStepWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LstValueList As ListBox
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents CboPendulum As ComboBox
    Friend WithEvents LblPendulum As Label
    Friend WithEvents LblStepWidth As Label
    Friend WithEvents TrbStepWidth As TrackBar
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStop As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents LblSteps As Label
    Friend WithEvents ChkStretched As CheckBox
    Friend WithEvents LblDifference As Label
End Class
