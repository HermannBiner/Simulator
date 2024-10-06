<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFeigenbaum
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFeigenbaum))
        PicDiagram = New PictureBox()
        BtnReset = New Button()
        BtnStartIteration = New Button()
        LblParameterRange = New Label()
        LblAmin = New Label()
        TxtAMin = New TextBox()
        TxtAMax = New TextBox()
        LblAmax = New Label()
        CboFunction = New ComboBox()
        TxtXMax = New TextBox()
        LblXmax = New Label()
        TxtXMin = New TextBox()
        LblXmin = New Label()
        LblValueRange = New Label()
        LblDeltaA = New Label()
        LblDeltaX = New Label()
        ChkSplitPoints = New CheckBox()
        ChkColored = New CheckBox()
        BtnDefault = New Button()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(9, 0)
        PicDiagram.Margin = New Padding(2)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(800, 800)
        PicDiagram.TabIndex = 2
        PicDiagram.TabStop = False
        ' 
        ' BtnReset
        ' 
        BtnReset.Location = New Point(818, 765)
        BtnReset.Margin = New Padding(2)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(230, 34)
        BtnReset.TabIndex = 4
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStartIteration
        ' 
        BtnStartIteration.Location = New Point(818, 396)
        BtnStartIteration.Margin = New Padding(2)
        BtnStartIteration.Name = "BtnStartIteration"
        BtnStartIteration.Size = New Size(230, 34)
        BtnStartIteration.TabIndex = 3
        BtnStartIteration.Text = "Start"
        BtnStartIteration.UseVisualStyleBackColor = True
        ' 
        ' LblParameterRange
        ' 
        LblParameterRange.AutoSize = True
        LblParameterRange.Location = New Point(814, 73)
        LblParameterRange.Margin = New Padding(2, 0, 2, 0)
        LblParameterRange.Name = "LblParameterRange"
        LblParameterRange.Size = New Size(156, 15)
        LblParameterRange.TabIndex = 11
        LblParameterRange.Text = "ExaminatedParameterRange"
        ' 
        ' LblAmin
        ' 
        LblAmin.AutoSize = True
        LblAmin.Location = New Point(814, 102)
        LblAmin.Margin = New Padding(2, 0, 2, 0)
        LblAmin.Name = "LblAmin"
        LblAmin.Size = New Size(45, 15)
        LblAmin.TabIndex = 12
        LblAmin.Text = "aMin ="
        ' 
        ' TxtAMin
        ' 
        TxtAMin.AcceptsReturn = True
        TxtAMin.AcceptsTab = True
        TxtAMin.Location = New Point(863, 97)
        TxtAMin.Margin = New Padding(2)
        TxtAMin.Name = "TxtAMin"
        TxtAMin.Size = New Size(185, 23)
        TxtAMin.TabIndex = 1
        ' 
        ' TxtAMax
        ' 
        TxtAMax.AcceptsReturn = True
        TxtAMax.AcceptsTab = True
        TxtAMax.Location = New Point(863, 129)
        TxtAMax.Margin = New Padding(2)
        TxtAMax.Name = "TxtAMax"
        TxtAMax.Size = New Size(185, 23)
        TxtAMax.TabIndex = 2
        ' 
        ' LblAmax
        ' 
        LblAmax.AutoSize = True
        LblAmax.Location = New Point(813, 133)
        LblAmax.Margin = New Padding(2, 0, 2, 0)
        LblAmax.Name = "LblAmax"
        LblAmax.Size = New Size(47, 15)
        LblAmax.TabIndex = 14
        LblAmax.Text = "aMax ="
        ' 
        ' CboFunction
        ' 
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic Growth", "Parabola"})
        CboFunction.Location = New Point(818, 0)
        CboFunction.Margin = New Padding(2)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(232, 23)
        CboFunction.TabIndex = 30
        ' 
        ' TxtXMax
        ' 
        TxtXMax.AcceptsReturn = True
        TxtXMax.AcceptsTab = True
        TxtXMax.Location = New Point(863, 254)
        TxtXMax.Margin = New Padding(2)
        TxtXMax.Name = "TxtXMax"
        TxtXMax.Size = New Size(187, 23)
        TxtXMax.TabIndex = 36
        ' 
        ' LblXmax
        ' 
        LblXmax.AutoSize = True
        LblXmax.Location = New Point(814, 258)
        LblXmax.Margin = New Padding(2, 0, 2, 0)
        LblXmax.Name = "LblXmax"
        LblXmax.Size = New Size(48, 15)
        LblXmax.TabIndex = 39
        LblXmax.Text = "Xmax ="
        ' 
        ' TxtXMin
        ' 
        TxtXMin.AcceptsReturn = True
        TxtXMin.AcceptsTab = True
        TxtXMin.Location = New Point(863, 222)
        TxtXMin.Margin = New Padding(2)
        TxtXMin.Name = "TxtXMin"
        TxtXMin.Size = New Size(187, 23)
        TxtXMin.TabIndex = 35
        ' 
        ' LblXmin
        ' 
        LblXmin.AutoSize = True
        LblXmin.Location = New Point(814, 226)
        LblXmin.Margin = New Padding(2, 0, 2, 0)
        LblXmin.Name = "LblXmin"
        LblXmin.Size = New Size(46, 15)
        LblXmin.TabIndex = 38
        LblXmin.Text = "Xmin ="
        ' 
        ' LblValueRange
        ' 
        LblValueRange.AutoSize = True
        LblValueRange.Location = New Point(813, 199)
        LblValueRange.Margin = New Padding(2, 0, 2, 0)
        LblValueRange.Name = "LblValueRange"
        LblValueRange.Size = New Size(130, 15)
        LblValueRange.TabIndex = 37
        LblValueRange.Text = "ExaminatedValueRange"
        ' 
        ' LblDeltaA
        ' 
        LblDeltaA.AutoSize = True
        LblDeltaA.Location = New Point(813, 166)
        LblDeltaA.Margin = New Padding(2, 0, 2, 0)
        LblDeltaA.Name = "LblDeltaA"
        LblDeltaA.Size = New Size(48, 15)
        LblDeltaA.TabIndex = 41
        LblDeltaA.Text = "Delta = "
        ' 
        ' LblDeltaX
        ' 
        LblDeltaX.AutoSize = True
        LblDeltaX.Location = New Point(813, 291)
        LblDeltaX.Margin = New Padding(2, 0, 2, 0)
        LblDeltaX.Name = "LblDeltaX"
        LblDeltaX.Size = New Size(48, 15)
        LblDeltaX.TabIndex = 43
        LblDeltaX.Text = "Delta = "
        ' 
        ' ChkSplitPoints
        ' 
        ChkSplitPoints.AutoSize = True
        ChkSplitPoints.Checked = True
        ChkSplitPoints.CheckState = CheckState.Checked
        ChkSplitPoints.Location = New Point(818, 319)
        ChkSplitPoints.Margin = New Padding(2)
        ChkSplitPoints.Name = "ChkSplitPoints"
        ChkSplitPoints.Size = New Size(111, 19)
        ChkSplitPoints.TabIndex = 44
        ChkSplitPoints.Text = "ShowSplitPoints"
        ChkSplitPoints.UseVisualStyleBackColor = True
        ' 
        ' ChkColored
        ' 
        ChkColored.AutoSize = True
        ChkColored.Location = New Point(818, 357)
        ChkColored.Margin = New Padding(2)
        ChkColored.Name = "ChkColored"
        ChkColored.Size = New Size(113, 19)
        ChkColored.TabIndex = 46
        ChkColored.Text = "ColoredDiagram"
        ChkColored.UseVisualStyleBackColor = True
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Location = New Point(818, 727)
        BtnDefault.Margin = New Padding(2)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(230, 34)
        BtnDefault.TabIndex = 47
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' FrmFeigenbaum
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1059, 808)
        Controls.Add(BtnDefault)
        Controls.Add(ChkColored)
        Controls.Add(ChkSplitPoints)
        Controls.Add(LblDeltaX)
        Controls.Add(LblDeltaA)
        Controls.Add(TxtXMax)
        Controls.Add(LblXmax)
        Controls.Add(TxtXMin)
        Controls.Add(LblXmin)
        Controls.Add(LblValueRange)
        Controls.Add(CboFunction)
        Controls.Add(TxtAMax)
        Controls.Add(LblAmax)
        Controls.Add(TxtAMin)
        Controls.Add(LblAmin)
        Controls.Add(LblParameterRange)
        Controls.Add(BtnReset)
        Controls.Add(BtnStartIteration)
        Controls.Add(PicDiagram)
        ForeColor = SystemColors.ControlText
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(2)
        Name = "FrmFeigenbaum"
        Text = "FeigenbaumDiagram"
        WindowState = FormWindowState.Maximized
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStartIteration As Button
    Friend WithEvents LblParameterRange As Label
    Friend WithEvents LblAmin As Label
    Friend WithEvents TxtAMin As TextBox
    Friend WithEvents TxtAMax As TextBox
    Friend WithEvents LblAmax As Label
    Friend WithEvents CboFunction As ComboBox
    Friend WithEvents TxtXMax As TextBox
    Friend WithEvents LblXmax As Label
    Friend WithEvents TxtXMin As TextBox
    Friend WithEvents LblXmin As Label
    Friend WithEvents LblValueRange As Label
    Friend WithEvents LblDeltaA As Label
    Friend WithEvents LblDeltaX As Label
    Friend WithEvents ChkSplitPoints As CheckBox
    Friend WithEvents ChkColored As CheckBox
    Friend WithEvents BtnDefault As Button
End Class
