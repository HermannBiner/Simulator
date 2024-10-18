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
        PicDiagram.Location = New Point(14, 10)
        PicDiagram.Margin = New Padding(4, 5, 4, 5)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(1400, 1510)
        PicDiagram.TabIndex = 2
        PicDiagram.TabStop = False
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Segoe UI", 11F)
        BtnReset.Location = New Point(1430, 1462)
        BtnReset.Margin = New Padding(4, 5, 4, 5)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(460, 58)
        BtnReset.TabIndex = 4
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Segoe UI", 11F)
        BtnStart.Location = New Point(1426, 762)
        BtnStart.Margin = New Padding(4, 5, 4, 5)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(460, 58)
        BtnStart.TabIndex = 3
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' LblParameterRange
        ' 
        LblParameterRange.AutoSize = True
        LblParameterRange.Font = New Font("Segoe UI", 11F)
        LblParameterRange.Location = New Point(1432, 82)
        LblParameterRange.Margin = New Padding(4, 0, 4, 0)
        LblParameterRange.Name = "LblParameterRange"
        LblParameterRange.Size = New Size(337, 36)
        LblParameterRange.TabIndex = 11
        LblParameterRange.Text = "ExaminatedParameterRange"
        ' 
        ' LblAmin
        ' 
        LblAmin.AutoSize = True
        LblAmin.Font = New Font("Segoe UI", 11F)
        LblAmin.Location = New Point(1432, 152)
        LblAmin.Margin = New Padding(4, 0, 4, 0)
        LblAmin.Name = "LblAmin"
        LblAmin.Size = New Size(97, 36)
        LblAmin.TabIndex = 12
        LblAmin.Text = "aMin ="
        ' 
        ' TxtAMin
        ' 
        TxtAMin.AcceptsReturn = True
        TxtAMin.AcceptsTab = True
        TxtAMin.Font = New Font("Segoe UI", 11F)
        TxtAMin.Location = New Point(1542, 141)
        TxtAMin.Margin = New Padding(4, 5, 4, 5)
        TxtAMin.Name = "TxtAMin"
        TxtAMin.Size = New Size(354, 42)
        TxtAMin.TabIndex = 1
        ' 
        ' TxtAMax
        ' 
        TxtAMax.AcceptsReturn = True
        TxtAMax.AcceptsTab = True
        TxtAMax.Font = New Font("Segoe UI", 11F)
        TxtAMax.Location = New Point(1542, 216)
        TxtAMax.Margin = New Padding(4, 5, 4, 5)
        TxtAMax.Name = "TxtAMax"
        TxtAMax.Size = New Size(354, 42)
        TxtAMax.TabIndex = 2
        ' 
        ' LblAmax
        ' 
        LblAmax.AutoSize = True
        LblAmax.Font = New Font("Segoe UI", 11F)
        LblAmax.Location = New Point(1430, 216)
        LblAmax.Margin = New Padding(4, 0, 4, 0)
        LblAmax.Name = "LblAmax"
        LblAmax.Size = New Size(101, 36)
        LblAmax.TabIndex = 14
        LblAmax.Text = "aMax ="
        ' 
        ' CboFunction
        ' 
        CboFunction.Font = New Font("Segoe UI", 11F)
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic Growth", "Parabola"})
        CboFunction.Location = New Point(1440, 15)
        CboFunction.Margin = New Padding(4, 5, 4, 5)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(460, 44)
        CboFunction.TabIndex = 30
        ' 
        ' TxtXMax
        ' 
        TxtXMax.AcceptsReturn = True
        TxtXMax.AcceptsTab = True
        TxtXMax.Font = New Font("Segoe UI", 11F)
        TxtXMax.Location = New Point(1538, 469)
        TxtXMax.Margin = New Padding(4, 5, 4, 5)
        TxtXMax.Name = "TxtXMax"
        TxtXMax.Size = New Size(358, 42)
        TxtXMax.TabIndex = 36
        ' 
        ' LblXmax
        ' 
        LblXmax.AutoSize = True
        LblXmax.Font = New Font("Segoe UI", 11F)
        LblXmax.Location = New Point(1428, 469)
        LblXmax.Margin = New Padding(4, 0, 4, 0)
        LblXmax.Name = "LblXmax"
        LblXmax.Size = New Size(102, 36)
        LblXmax.TabIndex = 39
        LblXmax.Text = "Xmax ="
        ' 
        ' TxtXMin
        ' 
        TxtXMin.AcceptsReturn = True
        TxtXMin.AcceptsTab = True
        TxtXMin.Font = New Font("Segoe UI", 11F)
        TxtXMin.Location = New Point(1538, 392)
        TxtXMin.Margin = New Padding(4, 5, 4, 5)
        TxtXMin.Name = "TxtXMin"
        TxtXMin.Size = New Size(358, 42)
        TxtXMin.TabIndex = 35
        ' 
        ' LblXmin
        ' 
        LblXmin.AutoSize = True
        LblXmin.Font = New Font("Segoe UI", 11F)
        LblXmin.Location = New Point(1426, 395)
        LblXmin.Margin = New Padding(4, 0, 4, 0)
        LblXmin.Name = "LblXmin"
        LblXmin.Size = New Size(98, 36)
        LblXmin.TabIndex = 38
        LblXmin.Text = "Xmin ="
        ' 
        ' LblValueRange
        ' 
        LblValueRange.AutoSize = True
        LblValueRange.Font = New Font("Segoe UI", 11F)
        LblValueRange.Location = New Point(1426, 338)
        LblValueRange.Margin = New Padding(4, 0, 4, 0)
        LblValueRange.Name = "LblValueRange"
        LblValueRange.Size = New Size(282, 36)
        LblValueRange.TabIndex = 37
        LblValueRange.Text = "ExaminatedValueRange"
        ' 
        ' LblDeltaA
        ' 
        LblDeltaA.AutoSize = True
        LblDeltaA.Font = New Font("Segoe UI", 11F)
        LblDeltaA.Location = New Point(1432, 279)
        LblDeltaA.Margin = New Padding(4, 0, 4, 0)
        LblDeltaA.Name = "LblDeltaA"
        LblDeltaA.Size = New Size(107, 36)
        LblDeltaA.TabIndex = 41
        LblDeltaA.Text = "Delta = "
        ' 
        ' LblDeltaX
        ' 
        LblDeltaX.AutoSize = True
        LblDeltaX.Font = New Font("Segoe UI", 11F)
        LblDeltaX.Location = New Point(1426, 550)
        LblDeltaX.Margin = New Padding(4, 0, 4, 0)
        LblDeltaX.Name = "LblDeltaX"
        LblDeltaX.Size = New Size(107, 36)
        LblDeltaX.TabIndex = 43
        LblDeltaX.Text = "Delta = "
        ' 
        ' ChkSplitPoints
        ' 
        ChkSplitPoints.AutoSize = True
        ChkSplitPoints.Checked = True
        ChkSplitPoints.CheckState = CheckState.Checked
        ChkSplitPoints.Font = New Font("Segoe UI", 11F)
        ChkSplitPoints.Location = New Point(1432, 625)
        ChkSplitPoints.Margin = New Padding(4, 5, 4, 5)
        ChkSplitPoints.Name = "ChkSplitPoints"
        ChkSplitPoints.Size = New Size(224, 40)
        ChkSplitPoints.TabIndex = 44
        ChkSplitPoints.Text = "ShowSplitPoints"
        ChkSplitPoints.UseVisualStyleBackColor = True
        ' 
        ' ChkColored
        ' 
        ChkColored.AutoSize = True
        ChkColored.Font = New Font("Segoe UI", 11F)
        ChkColored.Location = New Point(1430, 692)
        ChkColored.Margin = New Padding(4, 5, 4, 5)
        ChkColored.Name = "ChkColored"
        ChkColored.Size = New Size(227, 40)
        ChkColored.TabIndex = 46
        ChkColored.Text = "ColoredDiagram"
        ChkColored.UseVisualStyleBackColor = True
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Segoe UI", 11F)
        BtnDefault.Location = New Point(1430, 1384)
        BtnDefault.Margin = New Padding(4, 5, 4, 5)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(460, 58)
        BtnDefault.TabIndex = 47
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' FrmFeigenbaum
        ' 
        AutoScaleDimensions = New SizeF(14F, 36F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1924, 1535)
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
        Margin = New Padding(4, 5, 4, 5)
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
