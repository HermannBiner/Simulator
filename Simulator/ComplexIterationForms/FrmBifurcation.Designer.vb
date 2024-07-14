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
        PicDiagram = New PictureBox()
        LblDeltaX = New Label()
        LblDeltaA = New Label()
        TxtXMax = New TextBox()
        LblXmax = New Label()
        TxtXMin = New TextBox()
        LblXmin = New Label()
        LblValueRange = New Label()
        TxtAMax = New TextBox()
        LblAmax = New Label()
        TxtAMin = New TextBox()
        LblAmin = New Label()
        LblParameterRange = New Label()
        BtnReset = New Button()
        BtnStartIteration = New Button()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PicDiagram
        ' 
        PicDiagram.Location = New Point(2, 2)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(1400, 1600)
        PicDiagram.TabIndex = 0
        PicDiagram.TabStop = False
        ' 
        ' LblDeltaX
        ' 
        LblDeltaX.AutoSize = True
        LblDeltaX.Location = New Point(1441, 484)
        LblDeltaX.Margin = New Padding(4, 0, 4, 0)
        LblDeltaX.Name = "LblDeltaX"
        LblDeltaX.Size = New Size(100, 32)
        LblDeltaX.TabIndex = 55
        LblDeltaX.Text = "Delta = "
        ' 
        ' LblDeltaA
        ' 
        LblDeltaA.AutoSize = True
        LblDeltaA.Location = New Point(1441, 219)
        LblDeltaA.Margin = New Padding(4, 0, 4, 0)
        LblDeltaA.Name = "LblDeltaA"
        LblDeltaA.Size = New Size(100, 32)
        LblDeltaA.TabIndex = 54
        LblDeltaA.Text = "Delta = "
        ' 
        ' TxtXMax
        ' 
        TxtXMax.AcceptsReturn = True
        TxtXMax.AcceptsTab = True
        TxtXMax.Location = New Point(1533, 406)
        TxtXMax.Margin = New Padding(4, 5, 4, 5)
        TxtXMax.Name = "TxtXMax"
        TxtXMax.Size = New Size(343, 39)
        TxtXMax.TabIndex = 50
        ' 
        ' LblXmax
        ' 
        LblXmax.AutoSize = True
        LblXmax.Location = New Point(1443, 415)
        LblXmax.Margin = New Padding(4, 0, 4, 0)
        LblXmax.Name = "LblXmax"
        LblXmax.Size = New Size(95, 32)
        LblXmax.TabIndex = 53
        LblXmax.Text = "Xmax ="
        ' 
        ' TxtXMin
        ' 
        TxtXMin.AcceptsReturn = True
        TxtXMin.AcceptsTab = True
        TxtXMin.Location = New Point(1533, 336)
        TxtXMin.Margin = New Padding(4, 5, 4, 5)
        TxtXMin.Name = "TxtXMin"
        TxtXMin.Size = New Size(343, 39)
        TxtXMin.TabIndex = 49
        ' 
        ' LblXmin
        ' 
        LblXmin.AutoSize = True
        LblXmin.Location = New Point(1443, 347)
        LblXmin.Margin = New Padding(4, 0, 4, 0)
        LblXmin.Name = "LblXmin"
        LblXmin.Size = New Size(92, 32)
        LblXmin.TabIndex = 52
        LblXmin.Text = "Xmin ="
        ' 
        ' LblValueRange
        ' 
        LblValueRange.AutoSize = True
        LblValueRange.Location = New Point(1441, 289)
        LblValueRange.Margin = New Padding(4, 0, 4, 0)
        LblValueRange.Name = "LblValueRange"
        LblValueRange.Size = New Size(262, 32)
        LblValueRange.TabIndex = 51
        LblValueRange.Text = "ExaminatedValueRange"
        ' 
        ' TxtAMax
        ' 
        TxtAMax.AcceptsReturn = True
        TxtAMax.AcceptsTab = True
        TxtAMax.Location = New Point(1533, 138)
        TxtAMax.Margin = New Padding(4, 5, 4, 5)
        TxtAMax.Name = "TxtAMax"
        TxtAMax.Size = New Size(341, 39)
        TxtAMax.TabIndex = 45
        ' 
        ' LblAmax
        ' 
        LblAmax.AutoSize = True
        LblAmax.Location = New Point(1441, 148)
        LblAmax.Margin = New Padding(4, 0, 4, 0)
        LblAmax.Name = "LblAmax"
        LblAmax.Size = New Size(94, 32)
        LblAmax.TabIndex = 48
        LblAmax.Text = "aMax ="
        ' 
        ' TxtAMin
        ' 
        TxtAMin.AcceptsReturn = True
        TxtAMin.AcceptsTab = True
        TxtAMin.Location = New Point(1533, 72)
        TxtAMin.Margin = New Padding(4, 5, 4, 5)
        TxtAMin.Name = "TxtAMin"
        TxtAMin.Size = New Size(341, 39)
        TxtAMin.TabIndex = 44
        ' 
        ' LblAmin
        ' 
        LblAmin.AutoSize = True
        LblAmin.Location = New Point(1443, 80)
        LblAmin.Margin = New Padding(4, 0, 4, 0)
        LblAmin.Name = "LblAmin"
        LblAmin.Size = New Size(91, 32)
        LblAmin.TabIndex = 47
        LblAmin.Text = "aMin ="
        ' 
        ' LblParameterRange
        ' 
        LblParameterRange.AutoSize = True
        LblParameterRange.Location = New Point(1443, 20)
        LblParameterRange.Margin = New Padding(4, 0, 4, 0)
        LblParameterRange.Name = "LblParameterRange"
        LblParameterRange.Size = New Size(290, 32)
        LblParameterRange.TabIndex = 46
        LblParameterRange.Text = "ExaminatedRealpartRange"
        ' 
        ' BtnReset
        ' 
        BtnReset.Location = New Point(1443, 1537)
        BtnReset.Margin = New Padding(4, 5, 4, 5)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(429, 65)
        BtnReset.TabIndex = 72
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStartIteration
        ' 
        BtnStartIteration.Location = New Point(1441, 552)
        BtnStartIteration.Margin = New Padding(4, 5, 4, 5)
        BtnStartIteration.Name = "BtnStartIteration"
        BtnStartIteration.Size = New Size(433, 65)
        BtnStartIteration.TabIndex = 71
        BtnStartIteration.Text = "StartIteration"
        BtnStartIteration.UseVisualStyleBackColor = True
        ' 
        ' FrmBifurcation
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1914, 1629)
        Controls.Add(BtnReset)
        Controls.Add(BtnStartIteration)
        Controls.Add(LblDeltaX)
        Controls.Add(LblDeltaA)
        Controls.Add(TxtXMax)
        Controls.Add(LblXmax)
        Controls.Add(TxtXMin)
        Controls.Add(LblXmin)
        Controls.Add(LblValueRange)
        Controls.Add(TxtAMax)
        Controls.Add(LblAmax)
        Controls.Add(TxtAMin)
        Controls.Add(LblAmin)
        Controls.Add(LblParameterRange)
        Controls.Add(PicDiagram)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "FrmBifurcation"
        Text = "BifurcationDiagram"
        WindowState = FormWindowState.Maximized
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents LblDeltaX As Label
    Friend WithEvents LblDeltaA As Label
    Friend WithEvents TxtXMax As TextBox
    Friend WithEvents LblXmax As Label
    Friend WithEvents TxtXMin As TextBox
    Friend WithEvents LblXmin As Label
    Friend WithEvents LblValueRange As Label
    Friend WithEvents TxtAMax As TextBox
    Friend WithEvents LblAmax As Label
    Friend WithEvents TxtAMin As TextBox
    Friend WithEvents LblAmin As Label
    Friend WithEvents LblParameterRange As Label
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStartIteration As Button
End Class
