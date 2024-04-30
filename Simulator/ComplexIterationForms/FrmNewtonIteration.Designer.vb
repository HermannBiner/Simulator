<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmNewtonIteration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNewtonIteration))
        Me.PicCPlane = New System.Windows.Forms.PictureBox()
        Me.CboFunction = New System.Windows.Forms.ComboBox()
        Me.LblXMin = New System.Windows.Forms.Label()
        Me.TxtXMin = New System.Windows.Forms.TextBox()
        Me.TxtXMax = New System.Windows.Forms.TextBox()
        Me.LblXMax = New System.Windows.Forms.Label()
        Me.TxtDeltaX = New System.Windows.Forms.TextBox()
        Me.LblDeltaX = New System.Windows.Forms.Label()
        Me.TxtDeltaY = New System.Windows.Forms.TextBox()
        Me.LblDeltaY = New System.Windows.Forms.Label()
        Me.TxtYMax = New System.Windows.Forms.TextBox()
        Me.LblYMax = New System.Windows.Forms.Label()
        Me.TxtYMin = New System.Windows.Forms.TextBox()
        Me.LblYMin = New System.Windows.Forms.Label()
        Me.LblPrecision = New System.Windows.Forms.Label()
        Me.TrbPrecision = New System.Windows.Forms.TrackBar()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.BtnReset = New System.Windows.Forms.Button()
        Me.BtnStop = New System.Windows.Forms.Button()
        Me.LstProtocol = New System.Windows.Forms.ListBox()
        Me.LblProtocol = New System.Windows.Forms.Label()
        CType(Me.PicCPlane, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrbPrecision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PicCPlane
        '
        Me.PicCPlane.Location = New System.Drawing.Point(1, 5)
        Me.PicCPlane.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PicCPlane.Name = "PicCPlane"
        Me.PicCPlane.Size = New System.Drawing.Size(645, 645)
        Me.PicCPlane.TabIndex = 0
        Me.PicCPlane.TabStop = False
        '
        'CboFunction
        '
        Me.CboFunction.FormattingEnabled = True
        Me.CboFunction.Items.AddRange(New Object() {"z^3-1", "z^4-1"})
        Me.CboFunction.Location = New System.Drawing.Point(676, 5)
        Me.CboFunction.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CboFunction.Name = "CboFunction"
        Me.CboFunction.Size = New System.Drawing.Size(273, 21)
        Me.CboFunction.TabIndex = 1
        '
        'LblXMin
        '
        Me.LblXMin.AutoSize = True
        Me.LblXMin.Location = New System.Drawing.Point(674, 44)
        Me.LblXMin.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblXMin.Name = "LblXMin"
        Me.LblXMin.Size = New System.Drawing.Size(31, 13)
        Me.LblXMin.TabIndex = 3
        Me.LblXMin.Text = "XMin"
        '
        'TxtXMin
        '
        Me.TxtXMin.Location = New System.Drawing.Point(720, 41)
        Me.TxtXMin.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtXMin.Name = "TxtXMin"
        Me.TxtXMin.Size = New System.Drawing.Size(230, 20)
        Me.TxtXMin.TabIndex = 4
        '
        'TxtXMax
        '
        Me.TxtXMax.Location = New System.Drawing.Point(720, 66)
        Me.TxtXMax.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtXMax.Name = "TxtXMax"
        Me.TxtXMax.Size = New System.Drawing.Size(230, 20)
        Me.TxtXMax.TabIndex = 6
        '
        'LblXMax
        '
        Me.LblXMax.AutoSize = True
        Me.LblXMax.Location = New System.Drawing.Point(674, 69)
        Me.LblXMax.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblXMax.Name = "LblXMax"
        Me.LblXMax.Size = New System.Drawing.Size(34, 13)
        Me.LblXMax.TabIndex = 5
        Me.LblXMax.Text = "XMax"
        '
        'TxtDeltaX
        '
        Me.TxtDeltaX.Location = New System.Drawing.Point(720, 92)
        Me.TxtDeltaX.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtDeltaX.Name = "TxtDeltaX"
        Me.TxtDeltaX.Size = New System.Drawing.Size(230, 20)
        Me.TxtDeltaX.TabIndex = 8
        '
        'LblDeltaX
        '
        Me.LblDeltaX.AutoSize = True
        Me.LblDeltaX.Location = New System.Drawing.Point(674, 96)
        Me.LblDeltaX.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblDeltaX.Name = "LblDeltaX"
        Me.LblDeltaX.Size = New System.Drawing.Size(39, 13)
        Me.LblDeltaX.TabIndex = 7
        Me.LblDeltaX.Text = "DeltaX"
        '
        'TxtDeltaY
        '
        Me.TxtDeltaY.Location = New System.Drawing.Point(720, 172)
        Me.TxtDeltaY.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtDeltaY.Name = "TxtDeltaY"
        Me.TxtDeltaY.Size = New System.Drawing.Size(230, 20)
        Me.TxtDeltaY.TabIndex = 14
        '
        'LblDeltaY
        '
        Me.LblDeltaY.AutoSize = True
        Me.LblDeltaY.Location = New System.Drawing.Point(674, 175)
        Me.LblDeltaY.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblDeltaY.Name = "LblDeltaY"
        Me.LblDeltaY.Size = New System.Drawing.Size(39, 13)
        Me.LblDeltaY.TabIndex = 13
        Me.LblDeltaY.Text = "DeltaY"
        '
        'TxtYMax
        '
        Me.TxtYMax.Location = New System.Drawing.Point(720, 146)
        Me.TxtYMax.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtYMax.Name = "TxtYMax"
        Me.TxtYMax.Size = New System.Drawing.Size(230, 20)
        Me.TxtYMax.TabIndex = 12
        '
        'LblYMax
        '
        Me.LblYMax.AutoSize = True
        Me.LblYMax.Location = New System.Drawing.Point(674, 149)
        Me.LblYMax.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblYMax.Name = "LblYMax"
        Me.LblYMax.Size = New System.Drawing.Size(34, 13)
        Me.LblYMax.TabIndex = 11
        Me.LblYMax.Text = "YMax"
        '
        'TxtYMin
        '
        Me.TxtYMin.Location = New System.Drawing.Point(720, 121)
        Me.TxtYMin.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtYMin.Name = "TxtYMin"
        Me.TxtYMin.Size = New System.Drawing.Size(230, 20)
        Me.TxtYMin.TabIndex = 10
        '
        'LblYMin
        '
        Me.LblYMin.AutoSize = True
        Me.LblYMin.Location = New System.Drawing.Point(674, 124)
        Me.LblYMin.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblYMin.Name = "LblYMin"
        Me.LblYMin.Size = New System.Drawing.Size(31, 13)
        Me.LblYMin.TabIndex = 9
        Me.LblYMin.Text = "YMin"
        '
        'LblPrecision
        '
        Me.LblPrecision.AutoSize = True
        Me.LblPrecision.Location = New System.Drawing.Point(676, 208)
        Me.LblPrecision.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblPrecision.Name = "LblPrecision"
        Me.LblPrecision.Size = New System.Drawing.Size(50, 13)
        Me.LblPrecision.TabIndex = 19
        Me.LblPrecision.Text = "Precision"
        '
        'TrbPrecision
        '
        Me.TrbPrecision.Location = New System.Drawing.Point(676, 232)
        Me.TrbPrecision.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TrbPrecision.Maximum = 5
        Me.TrbPrecision.Minimum = 1
        Me.TrbPrecision.Name = "TrbPrecision"
        Me.TrbPrecision.Size = New System.Drawing.Size(272, 45)
        Me.TrbPrecision.TabIndex = 18
        Me.TrbPrecision.Value = 2
        '
        'BtnStart
        '
        Me.BtnStart.Location = New System.Drawing.Point(676, 287)
        Me.BtnStart.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(270, 30)
        Me.BtnStart.TabIndex = 20
        Me.BtnStart.Text = "Start"
        Me.BtnStart.UseVisualStyleBackColor = True
        '
        'BtnReset
        '
        Me.BtnReset.Location = New System.Drawing.Point(678, 620)
        Me.BtnReset.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(270, 30)
        Me.BtnReset.TabIndex = 21
        Me.BtnReset.Text = "ResetIteration"
        Me.BtnReset.UseVisualStyleBackColor = True
        '
        'BtnStop
        '
        Me.BtnStop.Location = New System.Drawing.Point(676, 324)
        Me.BtnStop.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(270, 30)
        Me.BtnStop.TabIndex = 24
        Me.BtnStop.Text = "Stop"
        Me.BtnStop.UseVisualStyleBackColor = True
        '
        'LstProtocol
        '
        Me.LstProtocol.FormattingEnabled = True
        Me.LstProtocol.Location = New System.Drawing.Point(678, 384)
        Me.LstProtocol.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.LstProtocol.Name = "LstProtocol"
        Me.LstProtocol.Size = New System.Drawing.Size(271, 225)
        Me.LstProtocol.TabIndex = 25
        '
        'LblProtocol
        '
        Me.LblProtocol.AutoSize = True
        Me.LblProtocol.Location = New System.Drawing.Point(676, 364)
        Me.LblProtocol.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblProtocol.Name = "LblProtocol"
        Me.LblProtocol.Size = New System.Drawing.Size(46, 13)
        Me.LblProtocol.TabIndex = 26
        Me.LblProtocol.Text = "Protocol"
        '
        'FrmNewtonIteration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(965, 655)
        Me.Controls.Add(Me.LblProtocol)
        Me.Controls.Add(Me.LstProtocol)
        Me.Controls.Add(Me.BtnStop)
        Me.Controls.Add(Me.BtnReset)
        Me.Controls.Add(Me.BtnStart)
        Me.Controls.Add(Me.LblPrecision)
        Me.Controls.Add(Me.TrbPrecision)
        Me.Controls.Add(Me.TxtDeltaY)
        Me.Controls.Add(Me.LblDeltaY)
        Me.Controls.Add(Me.TxtYMax)
        Me.Controls.Add(Me.LblYMax)
        Me.Controls.Add(Me.TxtYMin)
        Me.Controls.Add(Me.LblYMin)
        Me.Controls.Add(Me.TxtDeltaX)
        Me.Controls.Add(Me.LblDeltaX)
        Me.Controls.Add(Me.TxtXMax)
        Me.Controls.Add(Me.LblXMax)
        Me.Controls.Add(Me.TxtXMin)
        Me.Controls.Add(Me.LblXMin)
        Me.Controls.Add(Me.CboFunction)
        Me.Controls.Add(Me.PicCPlane)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "FrmNewtonIteration"
        Me.Text = "NewtonIteration"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PicCPlane, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrbPrecision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PicCPlane As PictureBox
    Friend WithEvents CboFunction As ComboBox
    Friend WithEvents LblXMin As Label
    Friend WithEvents TxtXMin As TextBox
    Friend WithEvents TxtXMax As TextBox
    Friend WithEvents LblXMax As Label
    Friend WithEvents TxtDeltaX As TextBox
    Friend WithEvents LblDeltaX As Label
    Friend WithEvents TxtDeltaY As TextBox
    Friend WithEvents LblDeltaY As Label
    Friend WithEvents TxtYMax As TextBox
    Friend WithEvents LblYMax As Label
    Friend WithEvents TxtYMin As TextBox
    Friend WithEvents LblYMin As Label
    Friend WithEvents LblPrecision As Label
    Friend WithEvents TrbPrecision As TrackBar
    Friend WithEvents BtnStart As Button
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStop As Button
    Friend WithEvents LstProtocol As ListBox
    Friend WithEvents LblProtocol As Label
End Class
