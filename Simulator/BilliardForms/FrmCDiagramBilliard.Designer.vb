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
        SplitContainer = New SplitContainer()
        PicDiagram = New PictureBox()
        BtnDefault = New Button()
        TrbPositionStartValues = New TrackBar()
        LblStartValues = New Label()
        CboValueParameter = New ComboBox()
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
        CType(SplitContainer, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer.Panel1.SuspendLayout()
        SplitContainer.Panel2.SuspendLayout()
        SplitContainer.SuspendLayout()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbPositionStartValues, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' SplitContainer
        ' 
        SplitContainer.Dock = DockStyle.Fill
        SplitContainer.FixedPanel = FixedPanel.Panel2
        SplitContainer.Location = New Point(0, 0)
        SplitContainer.Name = "SplitContainer"
        ' 
        ' SplitContainer.Panel1
        ' 
        SplitContainer.Panel1.Controls.Add(PicDiagram)
        ' 
        ' SplitContainer.Panel2
        ' 
        SplitContainer.Panel2.Controls.Add(BtnDefault)
        SplitContainer.Panel2.Controls.Add(TrbPositionStartValues)
        SplitContainer.Panel2.Controls.Add(LblStartValues)
        SplitContainer.Panel2.Controls.Add(CboValueParameter)
        SplitContainer.Panel2.Controls.Add(LblDeltaV)
        SplitContainer.Panel2.Controls.Add(LblDeltaC)
        SplitContainer.Panel2.Controls.Add(TxtVMax)
        SplitContainer.Panel2.Controls.Add(LblVmax)
        SplitContainer.Panel2.Controls.Add(TxtVMin)
        SplitContainer.Panel2.Controls.Add(LblVmin)
        SplitContainer.Panel2.Controls.Add(LblValueParameter)
        SplitContainer.Panel2.Controls.Add(CboFunction)
        SplitContainer.Panel2.Controls.Add(TxtCMax)
        SplitContainer.Panel2.Controls.Add(LblCmax)
        SplitContainer.Panel2.Controls.Add(TxtCMin)
        SplitContainer.Panel2.Controls.Add(LblCmin)
        SplitContainer.Panel2.Controls.Add(LblParameterRange)
        SplitContainer.Panel2.Controls.Add(BtnReset)
        SplitContainer.Panel2.Controls.Add(BtnStart)
        SplitContainer.Size = New Size(891, 594)
        SplitContainer.SplitterDistance = 586
        SplitContainer.SplitterWidth = 6
        SplitContainer.TabIndex = 0
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(4, 8)
        PicDiagram.Margin = New Padding(4, 2, 4, 2)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(580, 580)
        PicDiagram.TabIndex = 4
        PicDiagram.TabStop = False
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(10, 395)
        BtnDefault.Margin = New Padding(4, 2, 4, 2)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(270, 30)
        BtnDefault.TabIndex = 83
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' TrbPositionStartValues
        ' 
        TrbPositionStartValues.Location = New Point(10, 311)
        TrbPositionStartValues.Margin = New Padding(4, 2, 4, 2)
        TrbPositionStartValues.Maximum = 119
        TrbPositionStartValues.Minimum = 1
        TrbPositionStartValues.Name = "TrbPositionStartValues"
        TrbPositionStartValues.Size = New Size(270, 45)
        TrbPositionStartValues.TabIndex = 82
        TrbPositionStartValues.Value = 60
        ' 
        ' LblStartValues
        ' 
        LblStartValues.AutoSize = True
        LblStartValues.Font = New Font("Microsoft Sans Serif", 9F)
        LblStartValues.Location = New Point(10, 284)
        LblStartValues.Margin = New Padding(4, 0, 4, 0)
        LblStartValues.Name = "LblStartValues"
        LblStartValues.Size = New Size(136, 15)
        LblStartValues.TabIndex = 81
        LblStartValues.Text = "Position Start Value 2: 4"
        ' 
        ' CboValueParameter
        ' 
        CboValueParameter.DropDownStyle = ComboBoxStyle.DropDownList
        CboValueParameter.Font = New Font("Microsoft Sans Serif", 9F)
        CboValueParameter.FormattingEnabled = True
        CboValueParameter.Items.AddRange(New Object() {"ValueRange1", "ValueRange2"})
        CboValueParameter.Location = New Point(3, 159)
        CboValueParameter.Margin = New Padding(4, 2, 4, 2)
        CboValueParameter.Name = "CboValueParameter"
        CboValueParameter.Size = New Size(277, 23)
        CboValueParameter.TabIndex = 80
        ' 
        ' LblDeltaV
        ' 
        LblDeltaV.AutoSize = True
        LblDeltaV.Font = New Font("Microsoft Sans Serif", 9F)
        LblDeltaV.Location = New Point(8, 249)
        LblDeltaV.Margin = New Padding(4, 0, 4, 0)
        LblDeltaV.Name = "LblDeltaV"
        LblDeltaV.Size = New Size(49, 15)
        LblDeltaV.TabIndex = 79
        LblDeltaV.Text = "Delta = "
        ' 
        ' LblDeltaC
        ' 
        LblDeltaC.AutoSize = True
        LblDeltaC.Font = New Font("Microsoft Sans Serif", 9F)
        LblDeltaC.Location = New Point(4, 117)
        LblDeltaC.Margin = New Padding(4, 0, 4, 0)
        LblDeltaC.Name = "LblDeltaC"
        LblDeltaC.Size = New Size(49, 15)
        LblDeltaC.TabIndex = 78
        LblDeltaC.Text = "Delta = "
        ' 
        ' TxtVMax
        ' 
        TxtVMax.AcceptsReturn = True
        TxtVMax.AcceptsTab = True
        TxtVMax.Font = New Font("Microsoft Sans Serif", 9F)
        TxtVMax.Location = New Point(64, 221)
        TxtVMax.Margin = New Padding(4, 2, 4, 2)
        TxtVMax.Name = "TxtVMax"
        TxtVMax.Size = New Size(216, 21)
        TxtVMax.TabIndex = 74
        ' 
        ' LblVmax
        ' 
        LblVmax.AutoSize = True
        LblVmax.Font = New Font("Microsoft Sans Serif", 9F)
        LblVmax.Location = New Point(6, 224)
        LblVmax.Margin = New Padding(4, 0, 4, 0)
        LblVmax.Name = "LblVmax"
        LblVmax.Size = New Size(51, 15)
        LblVmax.TabIndex = 77
        LblVmax.Text = "V Max ="
        ' 
        ' TxtVMin
        ' 
        TxtVMin.AcceptsReturn = True
        TxtVMin.AcceptsTab = True
        TxtVMin.Font = New Font("Microsoft Sans Serif", 9F)
        TxtVMin.Location = New Point(64, 193)
        TxtVMin.Margin = New Padding(4, 2, 4, 2)
        TxtVMin.Name = "TxtVMin"
        TxtVMin.Size = New Size(216, 21)
        TxtVMin.TabIndex = 73
        ' 
        ' LblVmin
        ' 
        LblVmin.AutoSize = True
        LblVmin.Font = New Font("Microsoft Sans Serif", 9F)
        LblVmin.Location = New Point(3, 195)
        LblVmin.Margin = New Padding(4, 0, 4, 0)
        LblVmin.Name = "LblVmin"
        LblVmin.Size = New Size(48, 15)
        LblVmin.TabIndex = 76
        LblVmin.Text = "V Min ="
        ' 
        ' LblValueParameter
        ' 
        LblValueParameter.AutoSize = True
        LblValueParameter.Font = New Font("Microsoft Sans Serif", 9F)
        LblValueParameter.Location = New Point(4, 142)
        LblValueParameter.Margin = New Padding(4, 0, 4, 0)
        LblValueParameter.Name = "LblValueParameter"
        LblValueParameter.Size = New Size(162, 15)
        LblValueParameter.TabIndex = 75
        LblValueParameter.Text = "ExaminatedValueParameter"
        ' 
        ' CboFunction
        ' 
        CboFunction.DropDownStyle = ComboBoxStyle.DropDownList
        CboFunction.Font = New Font("Microsoft Sans Serif", 9F)
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Elliptic Billiard", "Stadium Billiard", "Oval Billiard"})
        CboFunction.Location = New Point(8, 8)
        CboFunction.Margin = New Padding(4, 2, 4, 2)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(272, 23)
        CboFunction.TabIndex = 72
        ' 
        ' TxtCMax
        ' 
        TxtCMax.AcceptsReturn = True
        TxtCMax.AcceptsTab = True
        TxtCMax.Font = New Font("Microsoft Sans Serif", 9F)
        TxtCMax.Location = New Point(64, 89)
        TxtCMax.Margin = New Padding(4, 2, 4, 2)
        TxtCMax.Name = "TxtCMax"
        TxtCMax.Size = New Size(216, 21)
        TxtCMax.TabIndex = 66
        ' 
        ' LblCmax
        ' 
        LblCmax.AutoSize = True
        LblCmax.Font = New Font("Microsoft Sans Serif", 9F)
        LblCmax.Location = New Point(4, 92)
        LblCmax.Margin = New Padding(4, 0, 4, 0)
        LblCmax.Name = "LblCmax"
        LblCmax.Size = New Size(52, 15)
        LblCmax.TabIndex = 71
        LblCmax.Text = "C Max ="
        ' 
        ' TxtCMin
        ' 
        TxtCMin.AcceptsReturn = True
        TxtCMin.AcceptsTab = True
        TxtCMin.Font = New Font("Microsoft Sans Serif", 9F)
        TxtCMin.Location = New Point(64, 59)
        TxtCMin.Margin = New Padding(4, 2, 4, 2)
        TxtCMin.Name = "TxtCMin"
        TxtCMin.Size = New Size(216, 21)
        TxtCMin.TabIndex = 65
        ' 
        ' LblCmin
        ' 
        LblCmin.AutoSize = True
        LblCmin.Font = New Font("Microsoft Sans Serif", 9F)
        LblCmin.Location = New Point(6, 62)
        LblCmin.Margin = New Padding(4, 0, 4, 0)
        LblCmin.Name = "LblCmin"
        LblCmin.Size = New Size(49, 15)
        LblCmin.TabIndex = 70
        LblCmin.Text = "C Min ="
        ' 
        ' LblParameterRange
        ' 
        LblParameterRange.AutoSize = True
        LblParameterRange.Font = New Font("Microsoft Sans Serif", 9F)
        LblParameterRange.Location = New Point(3, 38)
        LblParameterRange.Margin = New Padding(4, 0, 4, 0)
        LblParameterRange.Name = "LblParameterRange"
        LblParameterRange.Size = New Size(168, 15)
        LblParameterRange.TabIndex = 69
        LblParameterRange.Text = "ExaminatedParameterRange"
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(10, 429)
        BtnReset.Margin = New Padding(4, 2, 4, 2)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(270, 30)
        BtnReset.TabIndex = 68
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStart.Location = New Point(10, 361)
        BtnStart.Margin = New Padding(4, 2, 4, 2)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(270, 30)
        BtnStart.TabIndex = 67
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' FrmCDiagramBilliard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(891, 594)
        Controls.Add(SplitContainer)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimumSize = New Size(350, 515)
        Name = "FrmCDiagramBilliard"
        StartPosition = FormStartPosition.WindowsDefaultBounds
        Text = "C-Diagram"
        WindowState = FormWindowState.Maximized
        SplitContainer.Panel1.ResumeLayout(False)
        SplitContainer.Panel2.ResumeLayout(False)
        SplitContainer.Panel2.PerformLayout()
        CType(SplitContainer, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer.ResumeLayout(False)
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbPositionStartValues, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer As SplitContainer
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents BtnDefault As Button
    Friend WithEvents TrbPositionStartValues As TrackBar
    Friend WithEvents LblStartValues As Label
    Friend WithEvents CboValueParameter As ComboBox
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
End Class
