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
        BtnStart = New Button()
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
        PicDiagram.Location = New Point(1, 5)
        PicDiagram.Margin = New Padding(4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(580, 580)
        PicDiagram.TabIndex = 2
        PicDiagram.TabStop = False
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(586, 555)
        BtnReset.Margin = New Padding(4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(276, 30)
        BtnReset.TabIndex = 4
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStart.Location = New Point(589, 293)
        BtnStart.Margin = New Padding(4)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(276, 30)
        BtnStart.TabIndex = 3
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' LblParameterRange
        ' 
        LblParameterRange.AutoSize = True
        LblParameterRange.Font = New Font("Microsoft Sans Serif", 9F)
        LblParameterRange.Location = New Point(589, 36)
        LblParameterRange.Margin = New Padding(4, 0, 4, 0)
        LblParameterRange.Name = "LblParameterRange"
        LblParameterRange.Size = New Size(168, 15)
        LblParameterRange.TabIndex = 11
        LblParameterRange.Text = "ExaminatedParameterRange"
        ' 
        ' LblAmin
        ' 
        LblAmin.AutoSize = True
        LblAmin.Font = New Font("Microsoft Sans Serif", 9F)
        LblAmin.Location = New Point(589, 60)
        LblAmin.Margin = New Padding(4, 0, 4, 0)
        LblAmin.Name = "LblAmin"
        LblAmin.Size = New Size(45, 15)
        LblAmin.TabIndex = 12
        LblAmin.Text = "aMin ="
        ' 
        ' TxtAMin
        ' 
        TxtAMin.AcceptsReturn = True
        TxtAMin.AcceptsTab = True
        TxtAMin.Font = New Font("Microsoft Sans Serif", 9F)
        TxtAMin.Location = New Point(636, 57)
        TxtAMin.Margin = New Padding(4)
        TxtAMin.Name = "TxtAMin"
        TxtAMin.Size = New Size(229, 21)
        TxtAMin.TabIndex = 1
        ' 
        ' TxtAMax
        ' 
        TxtAMax.AcceptsReturn = True
        TxtAMax.AcceptsTab = True
        TxtAMax.Font = New Font("Microsoft Sans Serif", 9F)
        TxtAMax.Location = New Point(636, 84)
        TxtAMax.Margin = New Padding(4)
        TxtAMax.Name = "TxtAMax"
        TxtAMax.Size = New Size(229, 21)
        TxtAMax.TabIndex = 2
        ' 
        ' LblAmax
        ' 
        LblAmax.AutoSize = True
        LblAmax.Font = New Font("Microsoft Sans Serif", 9F)
        LblAmax.Location = New Point(586, 87)
        LblAmax.Margin = New Padding(4, 0, 4, 0)
        LblAmax.Name = "LblAmax"
        LblAmax.Size = New Size(48, 15)
        LblAmax.TabIndex = 14
        LblAmax.Text = "aMax ="
        ' 
        ' CboFunction
        ' 
        CboFunction.Font = New Font("Microsoft Sans Serif", 9F)
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic Growth", "Parabola"})
        CboFunction.Location = New Point(589, 5)
        CboFunction.Margin = New Padding(4)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(276, 23)
        CboFunction.TabIndex = 30
        ' 
        ' TxtXMax
        ' 
        TxtXMax.AcceptsReturn = True
        TxtXMax.AcceptsTab = True
        TxtXMax.Font = New Font("Microsoft Sans Serif", 9F)
        TxtXMax.Location = New Point(636, 186)
        TxtXMax.Margin = New Padding(4)
        TxtXMax.Name = "TxtXMax"
        TxtXMax.Size = New Size(229, 21)
        TxtXMax.TabIndex = 36
        ' 
        ' LblXmax
        ' 
        LblXmax.AutoSize = True
        LblXmax.Font = New Font("Microsoft Sans Serif", 9F)
        LblXmax.Location = New Point(589, 186)
        LblXmax.Margin = New Padding(4, 0, 4, 0)
        LblXmax.Name = "LblXmax"
        LblXmax.Size = New Size(49, 15)
        LblXmax.TabIndex = 39
        LblXmax.Text = "Xmax ="
        ' 
        ' TxtXMin
        ' 
        TxtXMin.AcceptsReturn = True
        TxtXMin.AcceptsTab = True
        TxtXMin.Font = New Font("Microsoft Sans Serif", 9F)
        TxtXMin.Location = New Point(636, 159)
        TxtXMin.Margin = New Padding(4)
        TxtXMin.Name = "TxtXMin"
        TxtXMin.Size = New Size(229, 21)
        TxtXMin.TabIndex = 35
        ' 
        ' LblXmin
        ' 
        LblXmin.AutoSize = True
        LblXmin.Font = New Font("Microsoft Sans Serif", 9F)
        LblXmin.Location = New Point(586, 162)
        LblXmin.Margin = New Padding(4, 0, 4, 0)
        LblXmin.Name = "LblXmin"
        LblXmin.Size = New Size(46, 15)
        LblXmin.TabIndex = 38
        LblXmin.Text = "Xmin ="
        ' 
        ' LblValueRange
        ' 
        LblValueRange.AutoSize = True
        LblValueRange.Font = New Font("Microsoft Sans Serif", 9F)
        LblValueRange.Location = New Point(586, 138)
        LblValueRange.Margin = New Padding(4, 0, 4, 0)
        LblValueRange.Name = "LblValueRange"
        LblValueRange.Size = New Size(141, 15)
        LblValueRange.TabIndex = 37
        LblValueRange.Text = "ExaminatedValueRange"
        ' 
        ' LblDeltaA
        ' 
        LblDeltaA.AutoSize = True
        LblDeltaA.Font = New Font("Microsoft Sans Serif", 9F)
        LblDeltaA.Location = New Point(586, 116)
        LblDeltaA.Margin = New Padding(4, 0, 4, 0)
        LblDeltaA.Name = "LblDeltaA"
        LblDeltaA.Size = New Size(49, 15)
        LblDeltaA.TabIndex = 41
        LblDeltaA.Text = "Delta = "
        ' 
        ' LblDeltaX
        ' 
        LblDeltaX.AutoSize = True
        LblDeltaX.Font = New Font("Microsoft Sans Serif", 9F)
        LblDeltaX.Location = New Point(589, 211)
        LblDeltaX.Margin = New Padding(4, 0, 4, 0)
        LblDeltaX.Name = "LblDeltaX"
        LblDeltaX.Size = New Size(49, 15)
        LblDeltaX.TabIndex = 43
        LblDeltaX.Text = "Delta = "
        ' 
        ' ChkSplitPoints
        ' 
        ChkSplitPoints.AutoSize = True
        ChkSplitPoints.Checked = True
        ChkSplitPoints.CheckState = CheckState.Checked
        ChkSplitPoints.Font = New Font("Microsoft Sans Serif", 9F)
        ChkSplitPoints.Location = New Point(589, 239)
        ChkSplitPoints.Margin = New Padding(4)
        ChkSplitPoints.Name = "ChkSplitPoints"
        ChkSplitPoints.Size = New Size(115, 19)
        ChkSplitPoints.TabIndex = 44
        ChkSplitPoints.Text = "ShowSplitPoints"
        ChkSplitPoints.UseVisualStyleBackColor = True
        ' 
        ' ChkColored
        ' 
        ChkColored.AutoSize = True
        ChkColored.Font = New Font("Microsoft Sans Serif", 9F)
        ChkColored.Location = New Point(589, 266)
        ChkColored.Margin = New Padding(4)
        ChkColored.Name = "ChkColored"
        ChkColored.Size = New Size(117, 19)
        ChkColored.TabIndex = 46
        ChkColored.Text = "ColoredDiagram"
        ChkColored.UseVisualStyleBackColor = True
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(586, 517)
        BtnDefault.Margin = New Padding(4)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(276, 30)
        BtnDefault.TabIndex = 47
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' FrmFeigenbaum
        ' 
        AutoScaleDimensions = New SizeF(9F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(876, 593)
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
        Controls.Add(BtnStart)
        Controls.Add(PicDiagram)
        Font = New Font("Microsoft Sans Serif", 11.1428576F)
        ForeColor = SystemColors.ControlText
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4)
        Name = "FrmFeigenbaum"
        Text = "FeigenbaumDiagram"
        WindowState = FormWindowState.Maximized
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStart As Button
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
