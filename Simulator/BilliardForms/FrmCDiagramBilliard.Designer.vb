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
        CboFunction = New ComboBox()
        TxtCMax = New TextBox()
        LblCmax = New Label()
        TxtCMin = New TextBox()
        LblCmin = New Label()
        LblParameterRange = New Label()
        BtnReset = New Button()
        BtnStart = New Button()
        CboValueParameter = New ComboBox()
        LblStartValues = New Label()
        TrbPositionStartValues = New TrackBar()
        BtnDefault = New Button()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbPositionStartValues, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(14, 19)
        PicDiagram.Margin = New Padding(4, 3, 4, 3)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(1400, 1510)
        PicDiagram.TabIndex = 3
        PicDiagram.TabStop = False
        ' 
        ' LblDeltaV
        ' 
        LblDeltaV.AutoSize = True
        LblDeltaV.Location = New Point(1429, 730)
        LblDeltaV.Margin = New Padding(4, 0, 4, 0)
        LblDeltaV.Name = "LblDeltaV"
        LblDeltaV.Size = New Size(107, 36)
        LblDeltaV.TabIndex = 60
        LblDeltaV.Text = "Delta = "
        ' 
        ' LblDeltaC
        ' 
        LblDeltaC.AutoSize = True
        LblDeltaC.Location = New Point(1429, 352)
        LblDeltaC.Margin = New Padding(4, 0, 4, 0)
        LblDeltaC.Name = "LblDeltaC"
        LblDeltaC.Size = New Size(107, 36)
        LblDeltaC.TabIndex = 59
        LblDeltaC.Text = "Delta = "
        ' 
        ' TxtVMax
        ' 
        TxtVMax.AcceptsReturn = True
        TxtVMax.AcceptsTab = True
        TxtVMax.Location = New Point(1549, 643)
        TxtVMax.Margin = New Padding(4, 3, 4, 3)
        TxtVMax.Name = "TxtVMax"
        TxtVMax.Size = New Size(368, 42)
        TxtVMax.TabIndex = 55
        ' 
        ' LblVmax
        ' 
        LblVmax.AutoSize = True
        LblVmax.Location = New Point(1429, 650)
        LblVmax.Margin = New Padding(4, 0, 4, 0)
        LblVmax.Name = "LblVmax"
        LblVmax.Size = New Size(111, 36)
        LblVmax.TabIndex = 58
        LblVmax.Text = "V Max ="
        ' 
        ' TxtVMin
        ' 
        TxtVMin.AcceptsReturn = True
        TxtVMin.AcceptsTab = True
        TxtVMin.Location = New Point(1553, 569)
        TxtVMin.Margin = New Padding(4, 3, 4, 3)
        TxtVMin.Name = "TxtVMin"
        TxtVMin.Size = New Size(364, 42)
        TxtVMin.TabIndex = 54
        ' 
        ' LblVmin
        ' 
        LblVmin.AutoSize = True
        LblVmin.Location = New Point(1429, 575)
        LblVmin.Margin = New Padding(4, 0, 4, 0)
        LblVmin.Name = "LblVmin"
        LblVmin.Size = New Size(107, 36)
        LblVmin.TabIndex = 57
        LblVmin.Text = "V Min ="
        ' 
        ' LblValueParameter
        ' 
        LblValueParameter.AutoSize = True
        LblValueParameter.Location = New Point(1429, 430)
        LblValueParameter.Margin = New Padding(4, 0, 4, 0)
        LblValueParameter.Name = "LblValueParameter"
        LblValueParameter.Size = New Size(326, 36)
        LblValueParameter.TabIndex = 56
        LblValueParameter.Text = "ExaminatedValueParameter"
        ' 
        ' CboFunction
        ' 
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Elliptic Billiard", "Stadium Billiard", "Oval Billiard"})
        CboFunction.Location = New Point(1436, 19)
        CboFunction.Margin = New Padding(4, 3, 4, 3)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(481, 44)
        CboFunction.TabIndex = 51
        ' 
        ' TxtCMax
        ' 
        TxtCMax.AcceptsReturn = True
        TxtCMax.AcceptsTab = True
        TxtCMax.Location = New Point(1549, 265)
        TxtCMax.Margin = New Padding(4, 3, 4, 3)
        TxtCMax.Name = "TxtCMax"
        TxtCMax.Size = New Size(368, 42)
        TxtCMax.TabIndex = 45
        ' 
        ' LblCmax
        ' 
        LblCmax.AutoSize = True
        LblCmax.Location = New Point(1432, 271)
        LblCmax.Margin = New Padding(4, 0, 4, 0)
        LblCmax.Name = "LblCmax"
        LblCmax.Size = New Size(111, 36)
        LblCmax.TabIndex = 50
        LblCmax.Text = "C Max ="
        ' 
        ' TxtCMin
        ' 
        TxtCMin.AcceptsReturn = True
        TxtCMin.AcceptsTab = True
        TxtCMin.Location = New Point(1553, 194)
        TxtCMin.Margin = New Padding(4, 3, 4, 3)
        TxtCMin.Name = "TxtCMin"
        TxtCMin.Size = New Size(364, 42)
        TxtCMin.TabIndex = 44
        ' 
        ' LblCmin
        ' 
        LblCmin.AutoSize = True
        LblCmin.Location = New Point(1436, 194)
        LblCmin.Margin = New Padding(4, 0, 4, 0)
        LblCmin.Name = "LblCmin"
        LblCmin.Size = New Size(107, 36)
        LblCmin.TabIndex = 49
        LblCmin.Text = "C Min ="
        ' 
        ' LblParameterRange
        ' 
        LblParameterRange.AutoSize = True
        LblParameterRange.Location = New Point(1436, 128)
        LblParameterRange.Margin = New Padding(4, 0, 4, 0)
        LblParameterRange.Name = "LblParameterRange"
        LblParameterRange.Size = New Size(337, 36)
        LblParameterRange.TabIndex = 48
        LblParameterRange.Text = "ExaminatedParameterRange"
        ' 
        ' BtnReset
        ' 
        BtnReset.Location = New Point(1429, 1470)
        BtnReset.Margin = New Padding(4, 3, 4, 3)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(488, 58)
        BtnReset.TabIndex = 47
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Location = New Point(1429, 992)
        BtnStart.Margin = New Padding(4, 3, 4, 3)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(488, 58)
        BtnStart.TabIndex = 46
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' CboValueParameter
        ' 
        CboValueParameter.FormattingEnabled = True
        CboValueParameter.Items.AddRange(New Object() {"ValueRange1", "ValueRange2"})
        CboValueParameter.Location = New Point(1436, 488)
        CboValueParameter.Margin = New Padding(4, 3, 4, 3)
        CboValueParameter.Name = "CboValueParameter"
        CboValueParameter.Size = New Size(481, 44)
        CboValueParameter.TabIndex = 61
        ' 
        ' LblStartValues
        ' 
        LblStartValues.AutoSize = True
        LblStartValues.Location = New Point(1429, 794)
        LblStartValues.Margin = New Padding(4, 0, 4, 0)
        LblStartValues.Name = "LblStartValues"
        LblStartValues.Size = New Size(283, 36)
        LblStartValues.TabIndex = 62
        LblStartValues.Text = "Position Start Value 2: 4"
        ' 
        ' TrbPositionStartValues
        ' 
        TrbPositionStartValues.Location = New Point(1436, 874)
        TrbPositionStartValues.Margin = New Padding(4, 3, 4, 3)
        TrbPositionStartValues.Maximum = 119
        TrbPositionStartValues.Minimum = 1
        TrbPositionStartValues.Name = "TrbPositionStartValues"
        TrbPositionStartValues.Size = New Size(481, 80)
        TrbPositionStartValues.TabIndex = 63
        TrbPositionStartValues.Value = 60
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Location = New Point(1429, 1395)
        BtnDefault.Margin = New Padding(4, 3, 4, 3)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(488, 58)
        BtnDefault.TabIndex = 64
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' FrmCDiagramBilliard
        ' 
        AutoScaleDimensions = New SizeF(14F, 36F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1934, 1561)
        Controls.Add(BtnDefault)
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
        Controls.Add(CboFunction)
        Controls.Add(TxtCMax)
        Controls.Add(LblCmax)
        Controls.Add(TxtCMin)
        Controls.Add(LblCmin)
        Controls.Add(LblParameterRange)
        Controls.Add(BtnReset)
        Controls.Add(BtnStart)
        Controls.Add(PicDiagram)
        Font = New Font("Segoe UI", 11F)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4, 3, 4, 3)
        Name = "FrmCDiagramBilliard"
        Text = "C-Diagram"
        WindowState = FormWindowState.Maximized
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents CboFunction As ComboBox
    Friend WithEvents TxtCMax As TextBox
    Friend WithEvents LblCmax As Label
    Friend WithEvents TxtCMin As TextBox
    Friend WithEvents LblCmin As Label
    Friend WithEvents LblParameterRange As Label
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents CboValueParameter As ComboBox
    Friend WithEvents LblStartValues As Label
    Friend WithEvents TrbPositionStartValues As TrackBar
    Friend WithEvents BtnDefault As Button
End Class
