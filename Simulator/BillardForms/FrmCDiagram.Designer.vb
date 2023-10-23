<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCDiagram
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCDiagram))
        Me.PicDiagram = New System.Windows.Forms.PictureBox()
        Me.LblDeltaV = New System.Windows.Forms.Label()
        Me.LblDeltaC = New System.Windows.Forms.Label()
        Me.TxtVMax = New System.Windows.Forms.TextBox()
        Me.LblVmax = New System.Windows.Forms.Label()
        Me.TxtVMin = New System.Windows.Forms.TextBox()
        Me.LblVmin = New System.Windows.Forms.Label()
        Me.LblValueRange = New System.Windows.Forms.Label()
        Me.LblPrecision = New System.Windows.Forms.Label()
        Me.TrbPrecision = New System.Windows.Forms.TrackBar()
        Me.CboFunction = New System.Windows.Forms.ComboBox()
        Me.TxtCMax = New System.Windows.Forms.TextBox()
        Me.LblCmax = New System.Windows.Forms.Label()
        Me.TxtCMin = New System.Windows.Forms.TextBox()
        Me.LblCmin = New System.Windows.Forms.Label()
        Me.LblParameterRange = New System.Windows.Forms.Label()
        Me.BtnReset = New System.Windows.Forms.Button()
        Me.BtnStartIteration = New System.Windows.Forms.Button()
        Me.CboValueRange = New System.Windows.Forms.ComboBox()
        CType(Me.PicDiagram, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrbPrecision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PicDiagram
        '
        Me.PicDiagram.BackColor = System.Drawing.Color.White
        Me.PicDiagram.Location = New System.Drawing.Point(13, 13)
        Me.PicDiagram.Margin = New System.Windows.Forms.Padding(4)
        Me.PicDiagram.Name = "PicDiagram"
        Me.PicDiagram.Size = New System.Drawing.Size(1243, 1150)
        Me.PicDiagram.TabIndex = 3
        Me.PicDiagram.TabStop = False
        '
        'LblDeltaV
        '
        Me.LblDeltaV.AutoSize = True
        Me.LblDeltaV.Location = New System.Drawing.Point(1275, 510)
        Me.LblDeltaV.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDeltaV.Name = "LblDeltaV"
        Me.LblDeltaV.Size = New System.Drawing.Size(86, 25)
        Me.LblDeltaV.TabIndex = 60
        Me.LblDeltaV.Text = "Delta = "
        '
        'LblDeltaC
        '
        Me.LblDeltaC.AutoSize = True
        Me.LblDeltaC.Location = New System.Drawing.Point(1277, 247)
        Me.LblDeltaC.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDeltaC.Name = "LblDeltaC"
        Me.LblDeltaC.Size = New System.Drawing.Size(86, 25)
        Me.LblDeltaC.TabIndex = 59
        Me.LblDeltaC.Text = "Delta = "
        '
        'TxtVMax
        '
        Me.TxtVMax.AcceptsReturn = True
        Me.TxtVMax.AcceptsTab = True
        Me.TxtVMax.Location = New System.Drawing.Point(1360, 449)
        Me.TxtVMax.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtVMax.Name = "TxtVMax"
        Me.TxtVMax.Size = New System.Drawing.Size(317, 31)
        Me.TxtVMax.TabIndex = 55
        '
        'LblVmax
        '
        Me.LblVmax.AutoSize = True
        Me.LblVmax.Location = New System.Drawing.Point(1277, 456)
        Me.LblVmax.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblVmax.Name = "LblVmax"
        Me.LblVmax.Size = New System.Drawing.Size(91, 25)
        Me.LblVmax.TabIndex = 58
        Me.LblVmax.Text = "V Max ="
        '
        'TxtVMin
        '
        Me.TxtVMin.AcceptsReturn = True
        Me.TxtVMin.AcceptsTab = True
        Me.TxtVMin.Location = New System.Drawing.Point(1360, 395)
        Me.TxtVMin.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtVMin.Name = "TxtVMin"
        Me.TxtVMin.Size = New System.Drawing.Size(317, 31)
        Me.TxtVMin.TabIndex = 54
        '
        'LblVmin
        '
        Me.LblVmin.AutoSize = True
        Me.LblVmin.Location = New System.Drawing.Point(1277, 403)
        Me.LblVmin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblVmin.Name = "LblVmin"
        Me.LblVmin.Size = New System.Drawing.Size(85, 25)
        Me.LblVmin.TabIndex = 57
        Me.LblVmin.Text = "V Min ="
        '
        'LblValueRange
        '
        Me.LblValueRange.AutoSize = True
        Me.LblValueRange.Location = New System.Drawing.Point(1277, 302)
        Me.LblValueRange.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblValueRange.Name = "LblValueRange"
        Me.LblValueRange.Size = New System.Drawing.Size(243, 25)
        Me.LblValueRange.TabIndex = 56
        Me.LblValueRange.Text = "ExaminatedValueRange"
        '
        'LblPrecision
        '
        Me.LblPrecision.AutoSize = True
        Me.LblPrecision.Location = New System.Drawing.Point(1277, 570)
        Me.LblPrecision.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPrecision.Name = "LblPrecision"
        Me.LblPrecision.Size = New System.Drawing.Size(173, 25)
        Me.LblPrecision.TabIndex = 53
        Me.LblPrecision.Text = "Precision: 25000"
        '
        'TrbPrecision
        '
        Me.TrbPrecision.Location = New System.Drawing.Point(1283, 623)
        Me.TrbPrecision.Margin = New System.Windows.Forms.Padding(4)
        Me.TrbPrecision.Maximum = 100
        Me.TrbPrecision.Minimum = 1
        Me.TrbPrecision.Name = "TrbPrecision"
        Me.TrbPrecision.Size = New System.Drawing.Size(396, 90)
        Me.TrbPrecision.TabIndex = 52
        Me.TrbPrecision.Value = 25
        '
        'CboFunction
        '
        Me.CboFunction.FormattingEnabled = True
        Me.CboFunction.Items.AddRange(New Object() {"Elliptic Billard", "Stadium Billard", "Oval Billard"})
        Me.CboFunction.Location = New System.Drawing.Point(1285, 13)
        Me.CboFunction.Margin = New System.Windows.Forms.Padding(4)
        Me.CboFunction.Name = "CboFunction"
        Me.CboFunction.Size = New System.Drawing.Size(395, 33)
        Me.CboFunction.TabIndex = 51
        '
        'TxtCMax
        '
        Me.TxtCMax.AcceptsReturn = True
        Me.TxtCMax.AcceptsTab = True
        Me.TxtCMax.Location = New System.Drawing.Point(1362, 184)
        Me.TxtCMax.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCMax.Name = "TxtCMax"
        Me.TxtCMax.Size = New System.Drawing.Size(315, 31)
        Me.TxtCMax.TabIndex = 45
        '
        'LblCmax
        '
        Me.LblCmax.AutoSize = True
        Me.LblCmax.Location = New System.Drawing.Point(1277, 192)
        Me.LblCmax.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCmax.Name = "LblCmax"
        Me.LblCmax.Size = New System.Drawing.Size(92, 25)
        Me.LblCmax.TabIndex = 50
        Me.LblCmax.Text = "C Max ="
        '
        'TxtCMin
        '
        Me.TxtCMin.AcceptsReturn = True
        Me.TxtCMin.AcceptsTab = True
        Me.TxtCMin.Location = New System.Drawing.Point(1362, 132)
        Me.TxtCMin.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCMin.Name = "TxtCMin"
        Me.TxtCMin.Size = New System.Drawing.Size(315, 31)
        Me.TxtCMin.TabIndex = 44
        '
        'LblCmin
        '
        Me.LblCmin.AutoSize = True
        Me.LblCmin.Location = New System.Drawing.Point(1279, 139)
        Me.LblCmin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCmin.Name = "LblCmin"
        Me.LblCmin.Size = New System.Drawing.Size(86, 25)
        Me.LblCmin.TabIndex = 49
        Me.LblCmin.Text = "C Min ="
        '
        'LblParameterRange
        '
        Me.LblParameterRange.AutoSize = True
        Me.LblParameterRange.Location = New System.Drawing.Point(1279, 92)
        Me.LblParameterRange.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblParameterRange.Name = "LblParameterRange"
        Me.LblParameterRange.Size = New System.Drawing.Size(287, 25)
        Me.LblParameterRange.TabIndex = 48
        Me.LblParameterRange.Text = "ExaminatedParameterRange"
        '
        'BtnReset
        '
        Me.BtnReset.Location = New System.Drawing.Point(1285, 1112)
        Me.BtnReset.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(396, 51)
        Me.BtnReset.TabIndex = 47
        Me.BtnReset.Text = "ResetIteration"
        Me.BtnReset.UseVisualStyleBackColor = True
        '
        'BtnStartIteration
        '
        Me.BtnStartIteration.Location = New System.Drawing.Point(1285, 782)
        Me.BtnStartIteration.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnStartIteration.Name = "BtnStartIteration"
        Me.BtnStartIteration.Size = New System.Drawing.Size(396, 51)
        Me.BtnStartIteration.TabIndex = 46
        Me.BtnStartIteration.Text = "StartIteration"
        Me.BtnStartIteration.UseVisualStyleBackColor = True
        '
        'CboValueRange
        '
        Me.CboValueRange.FormattingEnabled = True
        Me.CboValueRange.Items.AddRange(New Object() {"ValueRange1", "ValueRange2"})
        Me.CboValueRange.Location = New System.Drawing.Point(1360, 342)
        Me.CboValueRange.Name = "CboValueRange"
        Me.CboValueRange.Size = New System.Drawing.Size(317, 33)
        Me.CboValueRange.TabIndex = 61
        '
        'FrmCDiagram
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2349, 1180)
        Me.Controls.Add(Me.CboValueRange)
        Me.Controls.Add(Me.LblDeltaV)
        Me.Controls.Add(Me.LblDeltaC)
        Me.Controls.Add(Me.TxtVMax)
        Me.Controls.Add(Me.LblVmax)
        Me.Controls.Add(Me.TxtVMin)
        Me.Controls.Add(Me.LblVmin)
        Me.Controls.Add(Me.LblValueRange)
        Me.Controls.Add(Me.LblPrecision)
        Me.Controls.Add(Me.TrbPrecision)
        Me.Controls.Add(Me.CboFunction)
        Me.Controls.Add(Me.TxtCMax)
        Me.Controls.Add(Me.LblCmax)
        Me.Controls.Add(Me.TxtCMin)
        Me.Controls.Add(Me.LblCmin)
        Me.Controls.Add(Me.LblParameterRange)
        Me.Controls.Add(Me.BtnReset)
        Me.Controls.Add(Me.BtnStartIteration)
        Me.Controls.Add(Me.PicDiagram)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmCDiagram"
        Me.Text = "C-Diagram"
        CType(Me.PicDiagram, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrbPrecision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents LblDeltaV As Label
    Friend WithEvents LblDeltaC As Label
    Friend WithEvents TxtVMax As TextBox
    Friend WithEvents LblVmax As Label
    Friend WithEvents TxtVMin As TextBox
    Friend WithEvents LblVmin As Label
    Friend WithEvents LblValueRange As Label
    Friend WithEvents LblPrecision As Label
    Friend WithEvents TrbPrecision As TrackBar
    Friend WithEvents CboFunction As ComboBox
    Friend WithEvents TxtCMax As TextBox
    Friend WithEvents LblCmax As Label
    Friend WithEvents TxtCMin As TextBox
    Friend WithEvents LblCmin As Label
    Friend WithEvents LblParameterRange As Label
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStartIteration As Button
    Friend WithEvents CboValueRange As ComboBox
End Class
