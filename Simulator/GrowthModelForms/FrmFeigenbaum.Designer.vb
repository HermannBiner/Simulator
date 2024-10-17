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
        PicDiagram.Location = New Point(17, 0)
        PicDiagram.Margin = New Padding(4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(1486, 1707)
        PicDiagram.TabIndex = 2
        PicDiagram.TabStop = False
        ' 
        ' BtnReset
        ' 
        BtnReset.Location = New Point(1519, 1632)
        BtnReset.Margin = New Padding(4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(427, 73)
        BtnReset.TabIndex = 4
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Location = New Point(1519, 845)
        BtnStart.Margin = New Padding(4)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(427, 73)
        BtnStart.TabIndex = 3
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' LblParameterRange
        ' 
        LblParameterRange.AutoSize = True
        LblParameterRange.Location = New Point(1512, 156)
        LblParameterRange.Margin = New Padding(4, 0, 4, 0)
        LblParameterRange.Name = "LblParameterRange"
        LblParameterRange.Size = New Size(311, 32)
        LblParameterRange.TabIndex = 11
        LblParameterRange.Text = "ExaminatedParameterRange"
        ' 
        ' LblAmin
        ' 
        LblAmin.AutoSize = True
        LblAmin.Location = New Point(1512, 218)
        LblAmin.Margin = New Padding(4, 0, 4, 0)
        LblAmin.Name = "LblAmin"
        LblAmin.Size = New Size(91, 32)
        LblAmin.TabIndex = 12
        LblAmin.Text = "aMin ="
        ' 
        ' TxtAMin
        ' 
        TxtAMin.AcceptsReturn = True
        TxtAMin.AcceptsTab = True
        TxtAMin.Location = New Point(1603, 207)
        TxtAMin.Margin = New Padding(4)
        TxtAMin.Name = "TxtAMin"
        TxtAMin.Size = New Size(340, 39)
        TxtAMin.TabIndex = 1
        ' 
        ' TxtAMax
        ' 
        TxtAMax.AcceptsReturn = True
        TxtAMax.AcceptsTab = True
        TxtAMax.Location = New Point(1603, 275)
        TxtAMax.Margin = New Padding(4)
        TxtAMax.Name = "TxtAMax"
        TxtAMax.Size = New Size(340, 39)
        TxtAMax.TabIndex = 2
        ' 
        ' LblAmax
        ' 
        LblAmax.AutoSize = True
        LblAmax.Location = New Point(1510, 284)
        LblAmax.Margin = New Padding(4, 0, 4, 0)
        LblAmax.Name = "LblAmax"
        LblAmax.Size = New Size(94, 32)
        LblAmax.TabIndex = 14
        LblAmax.Text = "aMax ="
        ' 
        ' CboFunction
        ' 
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic Growth", "Parabola"})
        CboFunction.Location = New Point(1519, 0)
        CboFunction.Margin = New Padding(4)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(427, 40)
        CboFunction.TabIndex = 30
        ' 
        ' TxtXMax
        ' 
        TxtXMax.AcceptsReturn = True
        TxtXMax.AcceptsTab = True
        TxtXMax.Location = New Point(1603, 542)
        TxtXMax.Margin = New Padding(4)
        TxtXMax.Name = "TxtXMax"
        TxtXMax.Size = New Size(344, 39)
        TxtXMax.TabIndex = 36
        ' 
        ' LblXmax
        ' 
        LblXmax.AutoSize = True
        LblXmax.Location = New Point(1512, 550)
        LblXmax.Margin = New Padding(4, 0, 4, 0)
        LblXmax.Name = "LblXmax"
        LblXmax.Size = New Size(95, 32)
        LblXmax.TabIndex = 39
        LblXmax.Text = "Xmax ="
        ' 
        ' TxtXMin
        ' 
        TxtXMin.AcceptsReturn = True
        TxtXMin.AcceptsTab = True
        TxtXMin.Location = New Point(1603, 474)
        TxtXMin.Margin = New Padding(4)
        TxtXMin.Name = "TxtXMin"
        TxtXMin.Size = New Size(344, 39)
        TxtXMin.TabIndex = 35
        ' 
        ' LblXmin
        ' 
        LblXmin.AutoSize = True
        LblXmin.Location = New Point(1512, 482)
        LblXmin.Margin = New Padding(4, 0, 4, 0)
        LblXmin.Name = "LblXmin"
        LblXmin.Size = New Size(92, 32)
        LblXmin.TabIndex = 38
        LblXmin.Text = "Xmin ="
        ' 
        ' LblValueRange
        ' 
        LblValueRange.AutoSize = True
        LblValueRange.Location = New Point(1510, 425)
        LblValueRange.Margin = New Padding(4, 0, 4, 0)
        LblValueRange.Name = "LblValueRange"
        LblValueRange.Size = New Size(262, 32)
        LblValueRange.TabIndex = 37
        LblValueRange.Text = "ExaminatedValueRange"
        ' 
        ' LblDeltaA
        ' 
        LblDeltaA.AutoSize = True
        LblDeltaA.Location = New Point(1510, 354)
        LblDeltaA.Margin = New Padding(4, 0, 4, 0)
        LblDeltaA.Name = "LblDeltaA"
        LblDeltaA.Size = New Size(100, 32)
        LblDeltaA.TabIndex = 41
        LblDeltaA.Text = "Delta = "
        ' 
        ' LblDeltaX
        ' 
        LblDeltaX.AutoSize = True
        LblDeltaX.Location = New Point(1510, 621)
        LblDeltaX.Margin = New Padding(4, 0, 4, 0)
        LblDeltaX.Name = "LblDeltaX"
        LblDeltaX.Size = New Size(100, 32)
        LblDeltaX.TabIndex = 43
        LblDeltaX.Text = "Delta = "
        ' 
        ' ChkSplitPoints
        ' 
        ChkSplitPoints.AutoSize = True
        ChkSplitPoints.Checked = True
        ChkSplitPoints.CheckState = CheckState.Checked
        ChkSplitPoints.Location = New Point(1519, 681)
        ChkSplitPoints.Margin = New Padding(4)
        ChkSplitPoints.Name = "ChkSplitPoints"
        ChkSplitPoints.Size = New Size(215, 36)
        ChkSplitPoints.TabIndex = 44
        ChkSplitPoints.Text = "ShowSplitPoints"
        ChkSplitPoints.UseVisualStyleBackColor = True
        ' 
        ' ChkColored
        ' 
        ChkColored.AutoSize = True
        ChkColored.Location = New Point(1519, 762)
        ChkColored.Margin = New Padding(4)
        ChkColored.Name = "ChkColored"
        ChkColored.Size = New Size(220, 36)
        ChkColored.TabIndex = 46
        ChkColored.Text = "ColoredDiagram"
        ChkColored.UseVisualStyleBackColor = True
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Location = New Point(1519, 1551)
        BtnDefault.Margin = New Padding(4)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(427, 73)
        BtnDefault.TabIndex = 47
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' FrmFeigenbaum
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1967, 1724)
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
