<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFeigenbaum
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFeigenbaum))
        SplitContainer = New SplitContainer()
        PicDiagram = New PictureBox()
        BtnDefault = New Button()
        ChkColored = New CheckBox()
        ChkSplitPoints = New CheckBox()
        LblDeltaX = New Label()
        LblDeltaA = New Label()
        TxtXMax = New TextBox()
        LblXmax = New Label()
        TxtXMin = New TextBox()
        LblXmin = New Label()
        LblValueRange = New Label()
        CboFunction = New ComboBox()
        TxtAMax = New TextBox()
        LblAmax = New Label()
        TxtAMin = New TextBox()
        LblAmin = New Label()
        LblParameterRange = New Label()
        BtnReset = New Button()
        BtnStart = New Button()
        CType(SplitContainer, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer.Panel1.SuspendLayout()
        SplitContainer.Panel2.SuspendLayout()
        SplitContainer.SuspendLayout()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
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
        SplitContainer.Panel2.Controls.Add(ChkColored)
        SplitContainer.Panel2.Controls.Add(ChkSplitPoints)
        SplitContainer.Panel2.Controls.Add(LblDeltaX)
        SplitContainer.Panel2.Controls.Add(LblDeltaA)
        SplitContainer.Panel2.Controls.Add(TxtXMax)
        SplitContainer.Panel2.Controls.Add(LblXmax)
        SplitContainer.Panel2.Controls.Add(TxtXMin)
        SplitContainer.Panel2.Controls.Add(LblXmin)
        SplitContainer.Panel2.Controls.Add(LblValueRange)
        SplitContainer.Panel2.Controls.Add(CboFunction)
        SplitContainer.Panel2.Controls.Add(TxtAMax)
        SplitContainer.Panel2.Controls.Add(LblAmax)
        SplitContainer.Panel2.Controls.Add(TxtAMin)
        SplitContainer.Panel2.Controls.Add(LblAmin)
        SplitContainer.Panel2.Controls.Add(LblParameterRange)
        SplitContainer.Panel2.Controls.Add(BtnReset)
        SplitContainer.Panel2.Controls.Add(BtnStart)
        SplitContainer.Size = New Size(885, 590)
        SplitContainer.SplitterDistance = 587
        SplitContainer.SplitterWidth = 6
        SplitContainer.TabIndex = 0
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(4, 6)
        PicDiagram.Margin = New Padding(4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(580, 580)
        PicDiagram.TabIndex = 3
        PicDiagram.TabStop = False
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(5, 366)
        BtnDefault.Margin = New Padding(4)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(276, 30)
        BtnDefault.TabIndex = 65
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' ChkColored
        ' 
        ChkColored.AutoSize = True
        ChkColored.Font = New Font("Microsoft Sans Serif", 9F)
        ChkColored.Location = New Point(8, 301)
        ChkColored.Margin = New Padding(4)
        ChkColored.Name = "ChkColored"
        ChkColored.Size = New Size(117, 19)
        ChkColored.TabIndex = 64
        ChkColored.Text = "ColoredDiagram"
        ChkColored.UseVisualStyleBackColor = True
        ' 
        ' ChkSplitPoints
        ' 
        ChkSplitPoints.AutoSize = True
        ChkSplitPoints.Checked = True
        ChkSplitPoints.CheckState = CheckState.Checked
        ChkSplitPoints.Font = New Font("Microsoft Sans Serif", 9F)
        ChkSplitPoints.Location = New Point(8, 274)
        ChkSplitPoints.Margin = New Padding(4)
        ChkSplitPoints.Name = "ChkSplitPoints"
        ChkSplitPoints.Size = New Size(115, 19)
        ChkSplitPoints.TabIndex = 63
        ChkSplitPoints.Text = "ShowSplitPoints"
        ChkSplitPoints.UseVisualStyleBackColor = True
        ' 
        ' LblDeltaX
        ' 
        LblDeltaX.AutoSize = True
        LblDeltaX.Font = New Font("Microsoft Sans Serif", 9F)
        LblDeltaX.Location = New Point(8, 229)
        LblDeltaX.Margin = New Padding(4, 0, 4, 0)
        LblDeltaX.Name = "LblDeltaX"
        LblDeltaX.Size = New Size(49, 15)
        LblDeltaX.TabIndex = 62
        LblDeltaX.Text = "Delta = "
        ' 
        ' LblDeltaA
        ' 
        LblDeltaA.AutoSize = True
        LblDeltaA.Font = New Font("Microsoft Sans Serif", 9F)
        LblDeltaA.Location = New Point(5, 117)
        LblDeltaA.Margin = New Padding(4, 0, 4, 0)
        LblDeltaA.Name = "LblDeltaA"
        LblDeltaA.Size = New Size(49, 15)
        LblDeltaA.TabIndex = 61
        LblDeltaA.Text = "Delta = "
        ' 
        ' TxtXMax
        ' 
        TxtXMax.AcceptsReturn = True
        TxtXMax.AcceptsTab = True
        TxtXMax.Font = New Font("Microsoft Sans Serif", 9F)
        TxtXMax.Location = New Point(55, 204)
        TxtXMax.Margin = New Padding(4)
        TxtXMax.Name = "TxtXMax"
        TxtXMax.Size = New Size(226, 21)
        TxtXMax.TabIndex = 57
        ' 
        ' LblXmax
        ' 
        LblXmax.AutoSize = True
        LblXmax.Font = New Font("Microsoft Sans Serif", 9F)
        LblXmax.Location = New Point(8, 204)
        LblXmax.Margin = New Padding(4, 0, 4, 0)
        LblXmax.Name = "LblXmax"
        LblXmax.Size = New Size(49, 15)
        LblXmax.TabIndex = 60
        LblXmax.Text = "Xmax ="
        ' 
        ' TxtXMin
        ' 
        TxtXMin.AcceptsReturn = True
        TxtXMin.AcceptsTab = True
        TxtXMin.Font = New Font("Microsoft Sans Serif", 9F)
        TxtXMin.Location = New Point(55, 177)
        TxtXMin.Margin = New Padding(4)
        TxtXMin.Name = "TxtXMin"
        TxtXMin.Size = New Size(226, 21)
        TxtXMin.TabIndex = 56
        ' 
        ' LblXmin
        ' 
        LblXmin.AutoSize = True
        LblXmin.Font = New Font("Microsoft Sans Serif", 9F)
        LblXmin.Location = New Point(5, 180)
        LblXmin.Margin = New Padding(4, 0, 4, 0)
        LblXmin.Name = "LblXmin"
        LblXmin.Size = New Size(46, 15)
        LblXmin.TabIndex = 59
        LblXmin.Text = "Xmin ="
        ' 
        ' LblValueRange
        ' 
        LblValueRange.AutoSize = True
        LblValueRange.Font = New Font("Microsoft Sans Serif", 9F)
        LblValueRange.Location = New Point(5, 156)
        LblValueRange.Margin = New Padding(4, 0, 4, 0)
        LblValueRange.Name = "LblValueRange"
        LblValueRange.Size = New Size(141, 15)
        LblValueRange.TabIndex = 58
        LblValueRange.Text = "ExaminatedValueRange"
        ' 
        ' CboFunction
        ' 
        CboFunction.DropDownStyle = ComboBoxStyle.DropDownList
        CboFunction.Font = New Font("Microsoft Sans Serif", 9F)
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic Growth", "Parabola"})
        CboFunction.Location = New Point(8, 6)
        CboFunction.Margin = New Padding(4)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(273, 23)
        CboFunction.TabIndex = 55
        ' 
        ' TxtAMax
        ' 
        TxtAMax.AcceptsReturn = True
        TxtAMax.AcceptsTab = True
        TxtAMax.Font = New Font("Microsoft Sans Serif", 9F)
        TxtAMax.Location = New Point(55, 85)
        TxtAMax.Margin = New Padding(4)
        TxtAMax.Name = "TxtAMax"
        TxtAMax.Size = New Size(226, 21)
        TxtAMax.TabIndex = 49
        ' 
        ' LblAmax
        ' 
        LblAmax.AutoSize = True
        LblAmax.Font = New Font("Microsoft Sans Serif", 9F)
        LblAmax.Location = New Point(5, 88)
        LblAmax.Margin = New Padding(4, 0, 4, 0)
        LblAmax.Name = "LblAmax"
        LblAmax.Size = New Size(48, 15)
        LblAmax.TabIndex = 54
        LblAmax.Text = "aMax ="
        ' 
        ' TxtAMin
        ' 
        TxtAMin.AcceptsReturn = True
        TxtAMin.AcceptsTab = True
        TxtAMin.Font = New Font("Microsoft Sans Serif", 9F)
        TxtAMin.Location = New Point(55, 58)
        TxtAMin.Margin = New Padding(4)
        TxtAMin.Name = "TxtAMin"
        TxtAMin.Size = New Size(226, 21)
        TxtAMin.TabIndex = 48
        ' 
        ' LblAmin
        ' 
        LblAmin.AutoSize = True
        LblAmin.Font = New Font("Microsoft Sans Serif", 9F)
        LblAmin.Location = New Point(8, 61)
        LblAmin.Margin = New Padding(4, 0, 4, 0)
        LblAmin.Name = "LblAmin"
        LblAmin.Size = New Size(45, 15)
        LblAmin.TabIndex = 53
        LblAmin.Text = "aMin ="
        ' 
        ' LblParameterRange
        ' 
        LblParameterRange.AutoSize = True
        LblParameterRange.Font = New Font("Microsoft Sans Serif", 9F)
        LblParameterRange.Location = New Point(8, 37)
        LblParameterRange.Margin = New Padding(4, 0, 4, 0)
        LblParameterRange.Name = "LblParameterRange"
        LblParameterRange.Size = New Size(168, 15)
        LblParameterRange.TabIndex = 52
        LblParameterRange.Text = "ExaminatedParameterRange"
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(5, 404)
        BtnReset.Margin = New Padding(4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(276, 30)
        BtnReset.TabIndex = 51
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStart.Location = New Point(5, 328)
        BtnStart.Margin = New Padding(4)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(276, 30)
        BtnStart.TabIndex = 50
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' FrmFeigenbaum
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(885, 590)
        Controls.Add(SplitContainer)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimumSize = New Size(354, 480)
        Name = "FrmFeigenbaum"
        StartPosition = FormStartPosition.WindowsDefaultBounds
        Text = "Feigenbaum"
        WindowState = FormWindowState.Maximized
        SplitContainer.Panel1.ResumeLayout(False)
        SplitContainer.Panel2.ResumeLayout(False)
        SplitContainer.Panel2.PerformLayout()
        CType(SplitContainer, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer.ResumeLayout(False)
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer As SplitContainer
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents BtnDefault As Button
    Friend WithEvents ChkColored As CheckBox
    Friend WithEvents ChkSplitPoints As CheckBox
    Friend WithEvents LblDeltaX As Label
    Friend WithEvents LblDeltaA As Label
    Friend WithEvents TxtXMax As TextBox
    Friend WithEvents LblXmax As Label
    Friend WithEvents TxtXMin As TextBox
    Friend WithEvents LblXmin As Label
    Friend WithEvents LblValueRange As Label
    Friend WithEvents CboFunction As ComboBox
    Friend WithEvents TxtAMax As TextBox
    Friend WithEvents LblAmax As Label
    Friend WithEvents TxtAMin As TextBox
    Friend WithEvents LblAmin As Label
    Friend WithEvents LblParameterRange As Label
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStart As Button
End Class
