<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCDiagramBilliard
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            CDiagram.Dispose()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCDiagramBilliard))
        Me.PicDiagram = New System.Windows.Forms.PictureBox()
        Me.LblDeltaV = New System.Windows.Forms.Label()
        Me.LblDeltaC = New System.Windows.Forms.Label()
        Me.TxtVMax = New System.Windows.Forms.TextBox()
        Me.LblVmax = New System.Windows.Forms.Label()
        Me.TxtVMin = New System.Windows.Forms.TextBox()
        Me.LblVmin = New System.Windows.Forms.Label()
        Me.LblValueParameter = New System.Windows.Forms.Label()
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
        Me.CboValueParameter = New System.Windows.Forms.ComboBox()
        Me.LblStartValues = New System.Windows.Forms.Label()
        Me.TrbPositionStartValues = New System.Windows.Forms.TrackBar()
        CType(Me.PicDiagram, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrbPrecision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrbPositionStartValues, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PicDiagram
        '
        Me.PicDiagram.BackColor = System.Drawing.Color.White
        Me.PicDiagram.Location = New System.Drawing.Point(6, 7)
        Me.PicDiagram.Margin = New System.Windows.Forms.Padding(2)
        Me.PicDiagram.Name = "PicDiagram"
        Me.PicDiagram.Size = New System.Drawing.Size(622, 598)
        Me.PicDiagram.TabIndex = 3
        Me.PicDiagram.TabStop = False
        '
        'LblDeltaV
        '
        Me.LblDeltaV.AutoSize = True
        Me.LblDeltaV.Location = New System.Drawing.Point(638, 265)
        Me.LblDeltaV.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblDeltaV.Name = "LblDeltaV"
        Me.LblDeltaV.Size = New System.Drawing.Size(44, 13)
        Me.LblDeltaV.TabIndex = 60
        Me.LblDeltaV.Text = "Delta = "
        '
        'LblDeltaC
        '
        Me.LblDeltaC.AutoSize = True
        Me.LblDeltaC.Location = New System.Drawing.Point(638, 128)
        Me.LblDeltaC.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblDeltaC.Name = "LblDeltaC"
        Me.LblDeltaC.Size = New System.Drawing.Size(44, 13)
        Me.LblDeltaC.TabIndex = 59
        Me.LblDeltaC.Text = "Delta = "
        '
        'TxtVMax
        '
        Me.TxtVMax.AcceptsReturn = True
        Me.TxtVMax.AcceptsTab = True
        Me.TxtVMax.Location = New System.Drawing.Point(680, 233)
        Me.TxtVMax.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtVMax.Name = "TxtVMax"
        Me.TxtVMax.Size = New System.Drawing.Size(160, 20)
        Me.TxtVMax.TabIndex = 55
        '
        'LblVmax
        '
        Me.LblVmax.AutoSize = True
        Me.LblVmax.Location = New System.Drawing.Point(638, 237)
        Me.LblVmax.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblVmax.Name = "LblVmax"
        Me.LblVmax.Size = New System.Drawing.Size(46, 13)
        Me.LblVmax.TabIndex = 58
        Me.LblVmax.Text = "V Max ="
        '
        'TxtVMin
        '
        Me.TxtVMin.AcceptsReturn = True
        Me.TxtVMin.AcceptsTab = True
        Me.TxtVMin.Location = New System.Drawing.Point(680, 205)
        Me.TxtVMin.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtVMin.Name = "TxtVMin"
        Me.TxtVMin.Size = New System.Drawing.Size(160, 20)
        Me.TxtVMin.TabIndex = 54
        '
        'LblVmin
        '
        Me.LblVmin.AutoSize = True
        Me.LblVmin.Location = New System.Drawing.Point(638, 210)
        Me.LblVmin.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblVmin.Name = "LblVmin"
        Me.LblVmin.Size = New System.Drawing.Size(43, 13)
        Me.LblVmin.TabIndex = 57
        Me.LblVmin.Text = "V Min ="
        '
        'LblValueParameter
        '
        Me.LblValueParameter.AutoSize = True
        Me.LblValueParameter.Location = New System.Drawing.Point(638, 157)
        Me.LblValueParameter.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblValueParameter.Name = "LblValueParameter"
        Me.LblValueParameter.Size = New System.Drawing.Size(137, 13)
        Me.LblValueParameter.TabIndex = 56
        Me.LblValueParameter.Text = "ExaminatedValueParameter"
        '
        'LblPrecision
        '
        Me.LblPrecision.AutoSize = True
        Me.LblPrecision.Location = New System.Drawing.Point(640, 393)
        Me.LblPrecision.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblPrecision.Name = "LblPrecision"
        Me.LblPrecision.Size = New System.Drawing.Size(86, 13)
        Me.LblPrecision.TabIndex = 53
        Me.LblPrecision.Text = "Precision: 25000"
        '
        'TrbPrecision
        '
        Me.TrbPrecision.Location = New System.Drawing.Point(640, 415)
        Me.TrbPrecision.Margin = New System.Windows.Forms.Padding(2)
        Me.TrbPrecision.Maximum = 100
        Me.TrbPrecision.Minimum = 1
        Me.TrbPrecision.Name = "TrbPrecision"
        Me.TrbPrecision.Size = New System.Drawing.Size(198, 45)
        Me.TrbPrecision.TabIndex = 52
        Me.TrbPrecision.Value = 25
        '
        'CboFunction
        '
        Me.CboFunction.FormattingEnabled = True
        Me.CboFunction.Items.AddRange(New Object() {"Elliptic Billiard", "Stadium Billiard", "Oval Billiard"})
        Me.CboFunction.Location = New System.Drawing.Point(642, 7)
        Me.CboFunction.Margin = New System.Windows.Forms.Padding(2)
        Me.CboFunction.Name = "CboFunction"
        Me.CboFunction.Size = New System.Drawing.Size(200, 21)
        Me.CboFunction.TabIndex = 51
        '
        'TxtCMax
        '
        Me.TxtCMax.AcceptsReturn = True
        Me.TxtCMax.AcceptsTab = True
        Me.TxtCMax.Location = New System.Drawing.Point(681, 96)
        Me.TxtCMax.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtCMax.Name = "TxtCMax"
        Me.TxtCMax.Size = New System.Drawing.Size(160, 20)
        Me.TxtCMax.TabIndex = 45
        '
        'LblCmax
        '
        Me.LblCmax.AutoSize = True
        Me.LblCmax.Location = New System.Drawing.Point(638, 100)
        Me.LblCmax.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblCmax.Name = "LblCmax"
        Me.LblCmax.Size = New System.Drawing.Size(46, 13)
        Me.LblCmax.TabIndex = 50
        Me.LblCmax.Text = "C Max ="
        '
        'TxtCMin
        '
        Me.TxtCMin.AcceptsReturn = True
        Me.TxtCMin.AcceptsTab = True
        Me.TxtCMin.Location = New System.Drawing.Point(681, 69)
        Me.TxtCMin.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtCMin.Name = "TxtCMin"
        Me.TxtCMin.Size = New System.Drawing.Size(160, 20)
        Me.TxtCMin.TabIndex = 44
        '
        'LblCmin
        '
        Me.LblCmin.AutoSize = True
        Me.LblCmin.Location = New System.Drawing.Point(640, 72)
        Me.LblCmin.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblCmin.Name = "LblCmin"
        Me.LblCmin.Size = New System.Drawing.Size(43, 13)
        Me.LblCmin.TabIndex = 49
        Me.LblCmin.Text = "C Min ="
        '
        'LblParameterRange
        '
        Me.LblParameterRange.AutoSize = True
        Me.LblParameterRange.Location = New System.Drawing.Point(640, 48)
        Me.LblParameterRange.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblParameterRange.Name = "LblParameterRange"
        Me.LblParameterRange.Size = New System.Drawing.Size(142, 13)
        Me.LblParameterRange.TabIndex = 48
        Me.LblParameterRange.Text = "ExaminatedParameterRange"
        '
        'BtnReset
        '
        Me.BtnReset.Location = New System.Drawing.Point(642, 578)
        Me.BtnReset.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(198, 27)
        Me.BtnReset.TabIndex = 47
        Me.BtnReset.Text = "ResetIteration"
        Me.BtnReset.UseVisualStyleBackColor = True
        '
        'BtnStartIteration
        '
        Me.BtnStartIteration.Location = New System.Drawing.Point(640, 480)
        Me.BtnStartIteration.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnStartIteration.Name = "BtnStartIteration"
        Me.BtnStartIteration.Size = New System.Drawing.Size(198, 27)
        Me.BtnStartIteration.TabIndex = 46
        Me.BtnStartIteration.Text = "StartIteration"
        Me.BtnStartIteration.UseVisualStyleBackColor = True
        '
        'CboValueParameter
        '
        Me.CboValueParameter.FormattingEnabled = True
        Me.CboValueParameter.Items.AddRange(New Object() {"ValueRange1", "ValueRange2"})
        Me.CboValueParameter.Location = New System.Drawing.Point(680, 178)
        Me.CboValueParameter.Margin = New System.Windows.Forms.Padding(2)
        Me.CboValueParameter.Name = "CboValueParameter"
        Me.CboValueParameter.Size = New System.Drawing.Size(160, 21)
        Me.CboValueParameter.TabIndex = 61
        '
        'LblStartValues
        '
        Me.LblStartValues.AutoSize = True
        Me.LblStartValues.Location = New System.Drawing.Point(638, 289)
        Me.LblStartValues.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblStartValues.Name = "LblStartValues"
        Me.LblStartValues.Size = New System.Drawing.Size(120, 13)
        Me.LblStartValues.TabIndex = 62
        Me.LblStartValues.Text = "Position Start Value 2: 4"
        '
        'TrbPositionStartValues
        '
        Me.TrbPositionStartValues.Location = New System.Drawing.Point(640, 317)
        Me.TrbPositionStartValues.Margin = New System.Windows.Forms.Padding(2)
        Me.TrbPositionStartValues.Maximum = 119
        Me.TrbPositionStartValues.Minimum = 1
        Me.TrbPositionStartValues.Name = "TrbPositionStartValues"
        Me.TrbPositionStartValues.Size = New System.Drawing.Size(198, 45)
        Me.TrbPositionStartValues.TabIndex = 63
        Me.TrbPositionStartValues.Value = 60
        '
        'FrmCDiagramBilliard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1174, 614)
        Me.Controls.Add(Me.TrbPositionStartValues)
        Me.Controls.Add(Me.LblStartValues)
        Me.Controls.Add(Me.CboValueParameter)
        Me.Controls.Add(Me.LblDeltaV)
        Me.Controls.Add(Me.LblDeltaC)
        Me.Controls.Add(Me.TxtVMax)
        Me.Controls.Add(Me.LblVmax)
        Me.Controls.Add(Me.TxtVMin)
        Me.Controls.Add(Me.LblVmin)
        Me.Controls.Add(Me.LblValueParameter)
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
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmCDiagramBilliard"
        Me.Text = "C-Diagram"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PicDiagram, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrbPrecision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrbPositionStartValues, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents LblValueParameter As Label
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
    Friend WithEvents CboValueParameter As ComboBox
    Friend WithEvents LblStartValues As Label
    Friend WithEvents TrbPositionStartValues As TrackBar
End Class
