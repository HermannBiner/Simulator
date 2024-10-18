<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHistogram
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHistogram))
        PicDiagram = New PictureBox()
        TxtParameter = New TextBox()
        LblParameter = New Label()
        TxtStartValue = New TextBox()
        LblStartValue = New Label()
        BtnStart = New Button()
        BtnReset = New Button()
        LblSteps = New Label()
        LblNumberOfSteps = New Label()
        CboFunction = New ComboBox()
        BtnStop = New Button()
        BtnDefault = New Button()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(4, 5)
        PicDiagram.Margin = New Padding(4, 5, 4, 5)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(1300, 1300)
        PicDiagram.TabIndex = 1
        PicDiagram.TabStop = False
        ' 
        ' TxtParameter
        ' 
        TxtParameter.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TxtParameter.Location = New Point(1495, 89)
        TxtParameter.Margin = New Padding(4, 5, 4, 5)
        TxtParameter.Name = "TxtParameter"
        TxtParameter.Size = New Size(290, 42)
        TxtParameter.TabIndex = 10
        ' 
        ' LblParameter
        ' 
        LblParameter.AutoSize = True
        LblParameter.Font = New Font("Segoe UI", 11F)
        LblParameter.Location = New Point(1329, 81)
        LblParameter.Margin = New Padding(4, 0, 4, 0)
        LblParameter.Name = "LblParameter"
        LblParameter.Size = New Size(164, 36)
        LblParameter.TabIndex = 11
        LblParameter.Text = "Parameter = "
        ' 
        ' TxtStartValue
        ' 
        TxtStartValue.Font = New Font("Segoe UI", 11F)
        TxtStartValue.Location = New Point(1495, 156)
        TxtStartValue.Margin = New Padding(4, 5, 4, 5)
        TxtStartValue.Name = "TxtStartValue"
        TxtStartValue.Size = New Size(290, 42)
        TxtStartValue.TabIndex = 12
        ' 
        ' LblStartValue
        ' 
        LblStartValue.AutoSize = True
        LblStartValue.Font = New Font("Segoe UI", 11F)
        LblStartValue.Location = New Point(1332, 156)
        LblStartValue.Margin = New Padding(4, 0, 4, 0)
        LblStartValue.Name = "LblStartValue"
        LblStartValue.Size = New Size(155, 36)
        LblStartValue.TabIndex = 13
        LblStartValue.Text = "StartValue ="
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Segoe UI", 11F)
        BtnStart.Location = New Point(1332, 304)
        BtnStart.Margin = New Padding(4, 5, 4, 5)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(453, 50)
        BtnStart.TabIndex = 18
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Segoe UI", 11.5F)
        BtnReset.Location = New Point(1312, 1247)
        BtnReset.Margin = New Padding(4, 5, 4, 5)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(458, 58)
        BtnReset.TabIndex = 19
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Font = New Font("Segoe UI", 11.0F)
        LblSteps.Location = New Point(1536, 234)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(29, 36)
        LblSteps.TabIndex = 28
        LblSteps.Text = "0"
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Font = New Font("Segoe UI", 11.0F)
        LblNumberOfSteps.Location = New Point(1332, 234)
        LblNumberOfSteps.Margin = New Padding(4, 0, 4, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(199, 36)
        LblNumberOfSteps.TabIndex = 27
        LblNumberOfSteps.Text = "NumberOfSteps"
        ' 
        ' CboFunction
        ' 
        CboFunction.Font = New Font("Segoe UI", 11.0F)
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic Growth", "Parabola"})
        CboFunction.Location = New Point(1329, 5)
        CboFunction.Margin = New Padding(4, 5, 4, 5)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(456, 44)
        CboFunction.TabIndex = 29
        ' 
        ' BtnStop
        ' 
        BtnStop.Font = New Font("Segoe UI", 11.0F)
        BtnStop.Location = New Point(1332, 364)
        BtnStop.Margin = New Padding(4, 5, 4, 5)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(453, 50)
        BtnStop.TabIndex = 30
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Segoe UI", 11.0F)
        BtnDefault.Location = New Point(1312, 1187)
        BtnDefault.Margin = New Padding(4, 5, 4, 5)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(458, 50)
        BtnDefault.TabIndex = 31
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' FrmHistogram
        ' 
        AutoScaleDimensions = New SizeF(14.0F, 36.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1807, 1315)
        Controls.Add(BtnDefault)
        Controls.Add(BtnStop)
        Controls.Add(CboFunction)
        Controls.Add(LblSteps)
        Controls.Add(LblNumberOfSteps)
        Controls.Add(BtnStart)
        Controls.Add(BtnReset)
        Controls.Add(TxtStartValue)
        Controls.Add(LblStartValue)
        Controls.Add(TxtParameter)
        Controls.Add(LblParameter)
        Controls.Add(PicDiagram)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4, 5, 4, 5)
        Name = "FrmHistogram"
        RightToLeftLayout = True
        Text = "Histogram"
        WindowState = FormWindowState.Maximized
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents TxtParameter As TextBox
    Friend WithEvents LblParameter As Label
    Friend WithEvents TxtStartValue As TextBox
    Friend WithEvents LblStartValue As Label
    Friend WithEvents BtnStart As Button
    Friend WithEvents BtnReset As Button
    Friend WithEvents LblSteps As Label
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents CboFunction As ComboBox
    Friend WithEvents BtnStop As Button
    Friend WithEvents BtnDefault As Button
End Class
