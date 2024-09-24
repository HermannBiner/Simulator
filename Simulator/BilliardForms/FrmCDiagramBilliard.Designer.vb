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
        BtnStartIteration = New Button()
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
        PicDiagram.Location = New Point(7, 8)
        PicDiagram.Margin = New Padding(2)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(800, 800)
        PicDiagram.TabIndex = 3
        PicDiagram.TabStop = False
        ' 
        ' LblDeltaV
        ' 
        LblDeltaV.AutoSize = True
        LblDeltaV.Location = New Point(819, 306)
        LblDeltaV.Margin = New Padding(2, 0, 2, 0)
        LblDeltaV.Name = "LblDeltaV"
        LblDeltaV.Size = New Size(48, 15)
        LblDeltaV.TabIndex = 60
        LblDeltaV.Text = "Delta = "
        ' 
        ' LblDeltaC
        ' 
        LblDeltaC.AutoSize = True
        LblDeltaC.Location = New Point(819, 148)
        LblDeltaC.Margin = New Padding(2, 0, 2, 0)
        LblDeltaC.Name = "LblDeltaC"
        LblDeltaC.Size = New Size(48, 15)
        LblDeltaC.TabIndex = 59
        LblDeltaC.Text = "Delta = "
        ' 
        ' TxtVMax
        ' 
        TxtVMax.AcceptsReturn = True
        TxtVMax.AcceptsTab = True
        TxtVMax.Location = New Point(879, 270)
        TxtVMax.Margin = New Padding(2)
        TxtVMax.Name = "TxtVMax"
        TxtVMax.Size = New Size(186, 23)
        TxtVMax.TabIndex = 55
        ' 
        ' LblVmax
        ' 
        LblVmax.AutoSize = True
        LblVmax.Location = New Point(819, 273)
        LblVmax.Margin = New Padding(2, 0, 2, 0)
        LblVmax.Name = "LblVmax"
        LblVmax.Size = New Size(51, 15)
        LblVmax.TabIndex = 58
        LblVmax.Text = "V Max ="
        ' 
        ' TxtVMin
        ' 
        TxtVMin.AcceptsReturn = True
        TxtVMin.AcceptsTab = True
        TxtVMin.Location = New Point(881, 239)
        TxtVMin.Margin = New Padding(2)
        TxtVMin.Name = "TxtVMin"
        TxtVMin.Size = New Size(186, 23)
        TxtVMin.TabIndex = 54
        ' 
        ' LblVmin
        ' 
        LblVmin.AutoSize = True
        LblVmin.Location = New Point(819, 242)
        LblVmin.Margin = New Padding(2, 0, 2, 0)
        LblVmin.Name = "LblVmin"
        LblVmin.Size = New Size(49, 15)
        LblVmin.TabIndex = 57
        LblVmin.Text = "V Min ="
        ' 
        ' LblValueParameter
        ' 
        LblValueParameter.AutoSize = True
        LblValueParameter.Location = New Point(819, 181)
        LblValueParameter.Margin = New Padding(2, 0, 2, 0)
        LblValueParameter.Name = "LblValueParameter"
        LblValueParameter.Size = New Size(151, 15)
        LblValueParameter.TabIndex = 56
        LblValueParameter.Text = "ExaminatedValueParameter"
        ' 
        ' CboFunction
        ' 
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Elliptic Billiard", "Stadium Billiard", "Oval Billiard"})
        CboFunction.Location = New Point(822, 8)
        CboFunction.Margin = New Padding(2)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(245, 23)
        CboFunction.TabIndex = 51
        ' 
        ' TxtCMax
        ' 
        TxtCMax.AcceptsReturn = True
        TxtCMax.AcceptsTab = True
        TxtCMax.Location = New Point(879, 112)
        TxtCMax.Margin = New Padding(2)
        TxtCMax.Name = "TxtCMax"
        TxtCMax.Size = New Size(186, 23)
        TxtCMax.TabIndex = 45
        ' 
        ' LblCmax
        ' 
        LblCmax.AutoSize = True
        LblCmax.Location = New Point(819, 115)
        LblCmax.Margin = New Padding(2, 0, 2, 0)
        LblCmax.Name = "LblCmax"
        LblCmax.Size = New Size(52, 15)
        LblCmax.TabIndex = 50
        LblCmax.Text = "C Max ="
        ' 
        ' TxtCMin
        ' 
        TxtCMin.AcceptsReturn = True
        TxtCMin.AcceptsTab = True
        TxtCMin.Location = New Point(881, 80)
        TxtCMin.Margin = New Padding(2)
        TxtCMin.Name = "TxtCMin"
        TxtCMin.Size = New Size(186, 23)
        TxtCMin.TabIndex = 44
        ' 
        ' LblCmin
        ' 
        LblCmin.AutoSize = True
        LblCmin.Location = New Point(822, 83)
        LblCmin.Margin = New Padding(2, 0, 2, 0)
        LblCmin.Name = "LblCmin"
        LblCmin.Size = New Size(50, 15)
        LblCmin.TabIndex = 49
        LblCmin.Text = "C Min ="
        ' 
        ' LblParameterRange
        ' 
        LblParameterRange.AutoSize = True
        LblParameterRange.Location = New Point(822, 55)
        LblParameterRange.Margin = New Padding(2, 0, 2, 0)
        LblParameterRange.Name = "LblParameterRange"
        LblParameterRange.Size = New Size(156, 15)
        LblParameterRange.TabIndex = 48
        LblParameterRange.Text = "ExaminatedParameterRange"
        ' 
        ' BtnReset
        ' 
        BtnReset.Location = New Point(819, 774)
        BtnReset.Margin = New Padding(2)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(230, 34)
        BtnReset.TabIndex = 47
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStartIteration
        ' 
        BtnStartIteration.Location = New Point(819, 415)
        BtnStartIteration.Margin = New Padding(2)
        BtnStartIteration.Name = "BtnStartIteration"
        BtnStartIteration.Size = New Size(230, 34)
        BtnStartIteration.TabIndex = 46
        BtnStartIteration.Text = "StartIteration"
        BtnStartIteration.UseVisualStyleBackColor = True
        ' 
        ' CboValueParameter
        ' 
        CboValueParameter.FormattingEnabled = True
        CboValueParameter.Items.AddRange(New Object() {"ValueRange1", "ValueRange2"})
        CboValueParameter.Location = New Point(822, 205)
        CboValueParameter.Margin = New Padding(2)
        CboValueParameter.Name = "CboValueParameter"
        CboValueParameter.Size = New Size(245, 23)
        CboValueParameter.TabIndex = 61
        ' 
        ' LblStartValues
        ' 
        LblStartValues.AutoSize = True
        LblStartValues.Location = New Point(819, 333)
        LblStartValues.Margin = New Padding(2, 0, 2, 0)
        LblStartValues.Name = "LblStartValues"
        LblStartValues.Size = New Size(129, 15)
        LblStartValues.TabIndex = 62
        LblStartValues.Text = "Position Start Value 2: 4"
        ' 
        ' TrbPositionStartValues
        ' 
        TrbPositionStartValues.Location = New Point(822, 366)
        TrbPositionStartValues.Margin = New Padding(2)
        TrbPositionStartValues.Maximum = 119
        TrbPositionStartValues.Minimum = 1
        TrbPositionStartValues.Name = "TrbPositionStartValues"
        TrbPositionStartValues.Size = New Size(231, 45)
        TrbPositionStartValues.TabIndex = 63
        TrbPositionStartValues.Value = 60
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Location = New Point(819, 736)
        BtnDefault.Margin = New Padding(2)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(230, 34)
        BtnDefault.TabIndex = 64
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' FrmCDiagramBilliard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1081, 821)
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
        Controls.Add(BtnStartIteration)
        Controls.Add(PicDiagram)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(2)
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
    Friend WithEvents BtnStartIteration As Button
    Friend WithEvents CboValueParameter As ComboBox
    Friend WithEvents LblStartValues As Label
    Friend WithEvents TrbPositionStartValues As TrackBar
    Friend WithEvents BtnDefault As Button
End Class
