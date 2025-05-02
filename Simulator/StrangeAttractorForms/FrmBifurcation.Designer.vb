<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBifurcation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBifurcation))
        SplitContainer = New SplitContainer()
        PicDiagram = New PictureBox()
        GrpCoordinates = New GroupBox()
        OptZ = New RadioButton()
        OptY = New RadioButton()
        OptX = New RadioButton()
        LblDeltaX = New Label()
        LblDeltaA = New Label()
        TxtXMax = New TextBox()
        LblXmax = New Label()
        TxtXMin = New TextBox()
        LblXmin = New Label()
        LblValueRange = New Label()
        CboSystem = New ComboBox()
        TxtAMax = New TextBox()
        LblAmax = New Label()
        TxtAMin = New TextBox()
        LblAMin = New Label()
        LblParameterRange = New Label()
        BtnDefault = New Button()
        BtnReset = New Button()
        BtnStart = New Button()
        CType(SplitContainer, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer.Panel1.SuspendLayout()
        SplitContainer.Panel2.SuspendLayout()
        SplitContainer.SuspendLayout()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        GrpCoordinates.SuspendLayout()
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
        SplitContainer.Panel2.Controls.Add(GrpCoordinates)
        SplitContainer.Panel2.Controls.Add(LblDeltaX)
        SplitContainer.Panel2.Controls.Add(LblDeltaA)
        SplitContainer.Panel2.Controls.Add(TxtXMax)
        SplitContainer.Panel2.Controls.Add(LblXmax)
        SplitContainer.Panel2.Controls.Add(TxtXMin)
        SplitContainer.Panel2.Controls.Add(LblXmin)
        SplitContainer.Panel2.Controls.Add(LblValueRange)
        SplitContainer.Panel2.Controls.Add(CboSystem)
        SplitContainer.Panel2.Controls.Add(TxtAMax)
        SplitContainer.Panel2.Controls.Add(LblAmax)
        SplitContainer.Panel2.Controls.Add(TxtAMin)
        SplitContainer.Panel2.Controls.Add(LblAMin)
        SplitContainer.Panel2.Controls.Add(LblParameterRange)
        SplitContainer.Panel2.Controls.Add(BtnDefault)
        SplitContainer.Panel2.Controls.Add(BtnReset)
        SplitContainer.Panel2.Controls.Add(BtnStart)
        SplitContainer.Size = New Size(864, 589)
        SplitContainer.SplitterDistance = 588
        SplitContainer.SplitterWidth = 6
        SplitContainer.TabIndex = 0
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(4, 4)
        PicDiagram.Margin = New Padding(4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(580, 580)
        PicDiagram.TabIndex = 4
        PicDiagram.TabStop = False
        ' 
        ' GrpCoordinates
        ' 
        GrpCoordinates.Controls.Add(OptZ)
        GrpCoordinates.Controls.Add(OptY)
        GrpCoordinates.Controls.Add(OptX)
        GrpCoordinates.Location = New Point(6, 36)
        GrpCoordinates.Name = "GrpCoordinates"
        GrpCoordinates.Size = New Size(276, 55)
        GrpCoordinates.TabIndex = 81
        GrpCoordinates.TabStop = False
        GrpCoordinates.Text = "Coordinate"
        ' 
        ' OptZ
        ' 
        OptZ.AutoSize = True
        OptZ.Location = New Point(190, 22)
        OptZ.Name = "OptZ"
        OptZ.Size = New Size(32, 19)
        OptZ.TabIndex = 2
        OptZ.TabStop = True
        OptZ.Text = "Z"
        OptZ.UseVisualStyleBackColor = True
        ' 
        ' OptY
        ' 
        OptY.AutoSize = True
        OptY.Location = New Point(127, 22)
        OptY.Name = "OptY"
        OptY.Size = New Size(32, 19)
        OptY.TabIndex = 1
        OptY.TabStop = True
        OptY.Text = "Y"
        OptY.UseVisualStyleBackColor = True
        ' 
        ' OptX
        ' 
        OptX.AutoSize = True
        OptX.Location = New Point(62, 22)
        OptX.Name = "OptX"
        OptX.Size = New Size(32, 19)
        OptX.TabIndex = 0
        OptX.TabStop = True
        OptX.Text = "X"
        OptX.UseVisualStyleBackColor = True
        ' 
        ' LblDeltaX
        ' 
        LblDeltaX.AutoSize = True
        LblDeltaX.Font = New Font("Microsoft Sans Serif", 9F)
        LblDeltaX.Location = New Point(6, 273)
        LblDeltaX.Margin = New Padding(4, 0, 4, 0)
        LblDeltaX.Name = "LblDeltaX"
        LblDeltaX.Size = New Size(49, 15)
        LblDeltaX.TabIndex = 80
        LblDeltaX.Text = "Delta = "
        ' 
        ' LblDeltaA
        ' 
        LblDeltaA.AutoSize = True
        LblDeltaA.Font = New Font("Microsoft Sans Serif", 9F)
        LblDeltaA.Location = New Point(3, 171)
        LblDeltaA.Margin = New Padding(4, 0, 4, 0)
        LblDeltaA.Name = "LblDeltaA"
        LblDeltaA.Size = New Size(49, 15)
        LblDeltaA.TabIndex = 79
        LblDeltaA.Text = "Delta = "
        ' 
        ' TxtXMax
        ' 
        TxtXMax.AcceptsReturn = True
        TxtXMax.AcceptsTab = True
        TxtXMax.Font = New Font("Microsoft Sans Serif", 9F)
        TxtXMax.Location = New Point(68, 248)
        TxtXMax.Margin = New Padding(4)
        TxtXMax.Name = "TxtXMax"
        TxtXMax.Size = New Size(211, 21)
        TxtXMax.TabIndex = 75
        ' 
        ' LblXmax
        ' 
        LblXmax.AutoSize = True
        LblXmax.Font = New Font("Microsoft Sans Serif", 9F)
        LblXmax.Location = New Point(6, 248)
        LblXmax.Margin = New Padding(4, 0, 4, 0)
        LblXmax.Name = "LblXmax"
        LblXmax.Size = New Size(49, 15)
        LblXmax.TabIndex = 78
        LblXmax.Text = "Xmax ="
        ' 
        ' TxtXMin
        ' 
        TxtXMin.AcceptsReturn = True
        TxtXMin.AcceptsTab = True
        TxtXMin.Font = New Font("Microsoft Sans Serif", 9F)
        TxtXMin.Location = New Point(68, 221)
        TxtXMin.Margin = New Padding(4)
        TxtXMin.Name = "TxtXMin"
        TxtXMin.Size = New Size(211, 21)
        TxtXMin.TabIndex = 74
        ' 
        ' LblXmin
        ' 
        LblXmin.AutoSize = True
        LblXmin.Font = New Font("Microsoft Sans Serif", 9F)
        LblXmin.Location = New Point(6, 224)
        LblXmin.Margin = New Padding(4, 0, 4, 0)
        LblXmin.Name = "LblXmin"
        LblXmin.Size = New Size(46, 15)
        LblXmin.TabIndex = 77
        LblXmin.Text = "Xmin ="
        ' 
        ' LblValueRange
        ' 
        LblValueRange.AutoSize = True
        LblValueRange.Font = New Font("Microsoft Sans Serif", 9F)
        LblValueRange.Location = New Point(3, 200)
        LblValueRange.Margin = New Padding(4, 0, 4, 0)
        LblValueRange.Name = "LblValueRange"
        LblValueRange.Size = New Size(141, 15)
        LblValueRange.TabIndex = 76
        LblValueRange.Text = "ExaminatedValueRange"
        ' 
        ' CboSystem
        ' 
        CboSystem.Font = New Font("Microsoft Sans Serif", 9F)
        CboSystem.FormattingEnabled = True
        CboSystem.Items.AddRange(New Object() {"Tentmap", "Logistic Growth", "Parabola"})
        CboSystem.Location = New Point(6, 6)
        CboSystem.Margin = New Padding(4)
        CboSystem.Name = "CboSystem"
        CboSystem.Size = New Size(273, 23)
        CboSystem.TabIndex = 73
        ' 
        ' TxtAMax
        ' 
        TxtAMax.AcceptsReturn = True
        TxtAMax.AcceptsTab = True
        TxtAMax.Font = New Font("Microsoft Sans Serif", 9F)
        TxtAMax.Location = New Point(68, 144)
        TxtAMax.Margin = New Padding(4)
        TxtAMax.Name = "TxtAMax"
        TxtAMax.Size = New Size(211, 21)
        TxtAMax.TabIndex = 69
        ' 
        ' LblAmax
        ' 
        LblAmax.AutoSize = True
        LblAmax.Font = New Font("Microsoft Sans Serif", 9F)
        LblAmax.Location = New Point(7, 147)
        LblAmax.Margin = New Padding(4, 0, 4, 0)
        LblAmax.Name = "LblAmax"
        LblAmax.Size = New Size(48, 15)
        LblAmax.TabIndex = 72
        LblAmax.Text = "aMax ="
        ' 
        ' TxtAMin
        ' 
        TxtAMin.AcceptsReturn = True
        TxtAMin.AcceptsTab = True
        TxtAMin.Font = New Font("Microsoft Sans Serif", 9F)
        TxtAMin.Location = New Point(68, 117)
        TxtAMin.Margin = New Padding(4)
        TxtAMin.Name = "TxtAMin"
        TxtAMin.Size = New Size(211, 21)
        TxtAMin.TabIndex = 68
        ' 
        ' LblAMin
        ' 
        LblAMin.AutoSize = True
        LblAMin.Font = New Font("Microsoft Sans Serif", 9F)
        LblAMin.Location = New Point(6, 120)
        LblAMin.Margin = New Padding(4, 0, 4, 0)
        LblAMin.Name = "LblAMin"
        LblAMin.Size = New Size(45, 15)
        LblAMin.TabIndex = 71
        LblAMin.Text = "aMin ="
        ' 
        ' LblParameterRange
        ' 
        LblParameterRange.AutoSize = True
        LblParameterRange.Font = New Font("Microsoft Sans Serif", 9F)
        LblParameterRange.Location = New Point(6, 96)
        LblParameterRange.Margin = New Padding(4, 0, 4, 0)
        LblParameterRange.Name = "LblParameterRange"
        LblParameterRange.Size = New Size(168, 15)
        LblParameterRange.TabIndex = 70
        LblParameterRange.Text = "ExaminatedParameterRange"
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(3, 339)
        BtnDefault.Margin = New Padding(4)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(276, 30)
        BtnDefault.TabIndex = 67
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(3, 377)
        BtnReset.Margin = New Padding(4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(276, 30)
        BtnReset.TabIndex = 66
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStart.Location = New Point(3, 301)
        BtnStart.Margin = New Padding(4)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(276, 30)
        BtnStart.TabIndex = 65
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' FrmBifurcation
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(864, 589)
        Controls.Add(SplitContainer)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimumSize = New Size(344, 446)
        Name = "FrmBifurcation"
        StartPosition = FormStartPosition.WindowsDefaultBounds
        Text = "Bifurcation"
        WindowState = FormWindowState.Maximized
        SplitContainer.Panel1.ResumeLayout(False)
        SplitContainer.Panel2.ResumeLayout(False)
        SplitContainer.Panel2.PerformLayout()
        CType(SplitContainer, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer.ResumeLayout(False)
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        GrpCoordinates.ResumeLayout(False)
        GrpCoordinates.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer As SplitContainer
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents GrpCoordinates As GroupBox
    Friend WithEvents OptZ As RadioButton
    Friend WithEvents OptY As RadioButton
    Friend WithEvents OptX As RadioButton
    Friend WithEvents LblDeltaX As Label
    Friend WithEvents LblDeltaA As Label
    Friend WithEvents TxtXMax As TextBox
    Friend WithEvents LblXmax As Label
    Friend WithEvents TxtXMin As TextBox
    Friend WithEvents LblXmin As Label
    Friend WithEvents LblValueRange As Label
    Friend WithEvents CboSystem As ComboBox
    Friend WithEvents TxtAMax As TextBox
    Friend WithEvents LblAmax As Label
    Friend WithEvents TxtAMin As TextBox
    Friend WithEvents LblAMin As Label
    Friend WithEvents LblParameterRange As Label
    Friend WithEvents BtnDefault As Button
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStart As Button
End Class
