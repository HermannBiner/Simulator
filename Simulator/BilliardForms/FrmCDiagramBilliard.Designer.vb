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
        PicDiagram = New PictureBox()
        LblDeltaV = New Label()
        LblDeltaC = New Label()
        TxtVMax = New TextBox()
        LblVmax = New Label()
        TxtVMin = New TextBox()
        LblVmin = New Label()
        LblValueParameter = New Label()
        LblPrecision = New Label()
        TrbPrecision = New TrackBar()
        CboFunction = New ComboBox()
        TxtCMax = New TextBox()
        LblCmax = New Label()
        TxtCMin = New TextBox()
        LblCmin = New Label()
        LblParameterRange = New Label()
        BtnReset = New Button()
        BtnStartIteration = New Button()
        CboValueParameter = New ComboBox()
        LblStartValues = New Label()
        TrbPositionStartValues = New TrackBar()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbPrecision, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbPositionStartValues, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(13, 17)
        PicDiagram.Margin = New Padding(4, 5, 4, 5)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(1348, 1472)
        PicDiagram.TabIndex = 3
        PicDiagram.TabStop = False
        ' 
        ' LblDeltaV
        ' 
        LblDeltaV.AutoSize = True
        LblDeltaV.Location = New Point(1382, 652)
        LblDeltaV.Margin = New Padding(4, 0, 4, 0)
        LblDeltaV.Name = "LblDeltaV"
        LblDeltaV.Size = New Size(100, 32)
        LblDeltaV.TabIndex = 60
        LblDeltaV.Text = "Delta = "
        ' 
        ' LblDeltaC
        ' 
        LblDeltaC.AutoSize = True
        LblDeltaC.Location = New Point(1382, 315)
        LblDeltaC.Margin = New Padding(4, 0, 4, 0)
        LblDeltaC.Name = "LblDeltaC"
        LblDeltaC.Size = New Size(100, 32)
        LblDeltaC.TabIndex = 59
        LblDeltaC.Text = "Delta = "
        ' 
        ' TxtVMax
        ' 
        TxtVMax.AcceptsReturn = True
        TxtVMax.AcceptsTab = True
        TxtVMax.Location = New Point(1494, 576)
        TxtVMax.Margin = New Padding(4, 5, 4, 5)
        TxtVMax.Name = "TxtVMax"
        TxtVMax.Size = New Size(342, 39)
        TxtVMax.TabIndex = 55
        ' 
        ' LblVmax
        ' 
        LblVmax.AutoSize = True
        LblVmax.Location = New Point(1382, 583)
        LblVmax.Margin = New Padding(4, 0, 4, 0)
        LblVmax.Name = "LblVmax"
        LblVmax.Size = New Size(104, 32)
        LblVmax.TabIndex = 58
        LblVmax.Text = "V Max ="
        ' 
        ' TxtVMin
        ' 
        TxtVMin.AcceptsReturn = True
        TxtVMin.AcceptsTab = True
        TxtVMin.Location = New Point(1496, 510)
        TxtVMin.Margin = New Padding(4, 5, 4, 5)
        TxtVMin.Name = "TxtVMin"
        TxtVMin.Size = New Size(342, 39)
        TxtVMin.TabIndex = 54
        ' 
        ' LblVmin
        ' 
        LblVmin.AutoSize = True
        LblVmin.Location = New Point(1382, 517)
        LblVmin.Margin = New Padding(4, 0, 4, 0)
        LblVmin.Name = "LblVmin"
        LblVmin.Size = New Size(101, 32)
        LblVmin.TabIndex = 57
        LblVmin.Text = "V Min ="
        ' 
        ' LblValueParameter
        ' 
        LblValueParameter.AutoSize = True
        LblValueParameter.Location = New Point(1382, 386)
        LblValueParameter.Margin = New Padding(4, 0, 4, 0)
        LblValueParameter.Name = "LblValueParameter"
        LblValueParameter.Size = New Size(302, 32)
        LblValueParameter.TabIndex = 56
        LblValueParameter.Text = "ExaminatedValueParameter"
        ' 
        ' LblPrecision
        ' 
        LblPrecision.AutoSize = True
        LblPrecision.Location = New Point(1387, 967)
        LblPrecision.Margin = New Padding(4, 0, 4, 0)
        LblPrecision.Name = "LblPrecision"
        LblPrecision.Size = New Size(186, 32)
        LblPrecision.TabIndex = 53
        LblPrecision.Text = "Precision: 25000"
        ' 
        ' TrbPrecision
        ' 
        TrbPrecision.Location = New Point(1387, 1022)
        TrbPrecision.Margin = New Padding(4, 5, 4, 5)
        TrbPrecision.Maximum = 100
        TrbPrecision.Minimum = 1
        TrbPrecision.Name = "TrbPrecision"
        TrbPrecision.Size = New Size(429, 90)
        TrbPrecision.TabIndex = 52
        TrbPrecision.Value = 25
        ' 
        ' CboFunction
        ' 
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Elliptic Billiard", "Stadium Billiard", "Oval Billiard"})
        CboFunction.Location = New Point(1387, 17)
        CboFunction.Margin = New Padding(4, 5, 4, 5)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(451, 40)
        CboFunction.TabIndex = 51
        ' 
        ' TxtCMax
        ' 
        TxtCMax.AcceptsReturn = True
        TxtCMax.AcceptsTab = True
        TxtCMax.Location = New Point(1494, 239)
        TxtCMax.Margin = New Padding(4, 5, 4, 5)
        TxtCMax.Name = "TxtCMax"
        TxtCMax.Size = New Size(342, 39)
        TxtCMax.TabIndex = 45
        ' 
        ' LblCmax
        ' 
        LblCmax.AutoSize = True
        LblCmax.Location = New Point(1382, 246)
        LblCmax.Margin = New Padding(4, 0, 4, 0)
        LblCmax.Name = "LblCmax"
        LblCmax.Size = New Size(104, 32)
        LblCmax.TabIndex = 50
        LblCmax.Text = "C Max ="
        ' 
        ' TxtCMin
        ' 
        TxtCMin.AcceptsReturn = True
        TxtCMin.AcceptsTab = True
        TxtCMin.Location = New Point(1496, 170)
        TxtCMin.Margin = New Padding(4, 5, 4, 5)
        TxtCMin.Name = "TxtCMin"
        TxtCMin.Size = New Size(342, 39)
        TxtCMin.TabIndex = 44
        ' 
        ' LblCmin
        ' 
        LblCmin.AutoSize = True
        LblCmin.Location = New Point(1387, 177)
        LblCmin.Margin = New Padding(4, 0, 4, 0)
        LblCmin.Name = "LblCmin"
        LblCmin.Size = New Size(101, 32)
        LblCmin.TabIndex = 49
        LblCmin.Text = "C Min ="
        ' 
        ' LblParameterRange
        ' 
        LblParameterRange.AutoSize = True
        LblParameterRange.Location = New Point(1387, 117)
        LblParameterRange.Margin = New Padding(4, 0, 4, 0)
        LblParameterRange.Name = "LblParameterRange"
        LblParameterRange.Size = New Size(311, 32)
        LblParameterRange.TabIndex = 48
        LblParameterRange.Text = "ExaminatedParameterRange"
        ' 
        ' BtnReset
        ' 
        BtnReset.Location = New Point(1391, 1423)
        BtnReset.Margin = New Padding(4, 5, 4, 5)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(429, 66)
        BtnReset.TabIndex = 47
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStartIteration
        ' 
        BtnStartIteration.Location = New Point(1387, 1182)
        BtnStartIteration.Margin = New Padding(4, 5, 4, 5)
        BtnStartIteration.Name = "BtnStartIteration"
        BtnStartIteration.Size = New Size(429, 66)
        BtnStartIteration.TabIndex = 46
        BtnStartIteration.Text = "StartIteration"
        BtnStartIteration.UseVisualStyleBackColor = True
        ' 
        ' CboValueParameter
        ' 
        CboValueParameter.FormattingEnabled = True
        CboValueParameter.Items.AddRange(New Object() {"ValueRange1", "ValueRange2"})
        CboValueParameter.Location = New Point(1387, 438)
        CboValueParameter.Margin = New Padding(4, 5, 4, 5)
        CboValueParameter.Name = "CboValueParameter"
        CboValueParameter.Size = New Size(451, 40)
        CboValueParameter.TabIndex = 61
        ' 
        ' LblStartValues
        ' 
        LblStartValues.AutoSize = True
        LblStartValues.Location = New Point(1382, 711)
        LblStartValues.Margin = New Padding(4, 0, 4, 0)
        LblStartValues.Name = "LblStartValues"
        LblStartValues.Size = New Size(263, 32)
        LblStartValues.TabIndex = 62
        LblStartValues.Text = "Position Start Value 2: 4"
        ' 
        ' TrbPositionStartValues
        ' 
        TrbPositionStartValues.Location = New Point(1387, 780)
        TrbPositionStartValues.Margin = New Padding(4, 5, 4, 5)
        TrbPositionStartValues.Maximum = 119
        TrbPositionStartValues.Minimum = 1
        TrbPositionStartValues.Name = "TrbPositionStartValues"
        TrbPositionStartValues.Size = New Size(429, 90)
        TrbPositionStartValues.TabIndex = 63
        TrbPositionStartValues.Value = 60
        ' 
        ' FrmCDiagram
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(2544, 1511)
        Controls.Add(TrbPositionStartValues)
        Controls.Add(LblStartValues)
        Controls.Add(CboValueParameter)
        Controls.Add(LblDeltaV)
        Controls.Add(LblDeltaC)
        Controls.Add(TxtVMax)
        Controls.Add(LblVmax)
        Controls.Add(TxtVMin)
        Controls.Add(LblVmin)
        Controls.Add(LblValueParameter)
        Controls.Add(LblPrecision)
        Controls.Add(TrbPrecision)
        Controls.Add(CboFunction)
        Controls.Add(TxtCMax)
        Controls.Add(LblCmax)
        Controls.Add(TxtCMin)
        Controls.Add(LblCmin)
        Controls.Add(LblParameterRange)
        Controls.Add(BtnReset)
        Controls.Add(BtnStartIteration)
        Controls.Add(PicDiagram)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4, 5, 4, 5)
        Name = "FrmCDiagram"
        Text = "C-Diagram"
        WindowState = FormWindowState.Maximized
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbPrecision, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbPositionStartValues, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

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
