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
        PicDiagram.Location = New Point(2, 2)
        PicDiagram.Margin = New Padding(2)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(800, 800)
        PicDiagram.TabIndex = 1
        PicDiagram.TabStop = False
        ' 
        ' TxtParameter
        ' 
        TxtParameter.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TxtParameter.Location = New Point(898, 42)
        TxtParameter.Margin = New Padding(2)
        TxtParameter.Name = "TxtParameter"
        TxtParameter.Size = New Size(147, 20)
        TxtParameter.TabIndex = 10
        ' 
        ' LblParameter
        ' 
        LblParameter.AutoSize = True
        LblParameter.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblParameter.Location = New Point(815, 44)
        LblParameter.Margin = New Padding(2, 0, 2, 0)
        LblParameter.Name = "LblParameter"
        LblParameter.Size = New Size(67, 13)
        LblParameter.TabIndex = 11
        LblParameter.Text = "Parameter = "
        ' 
        ' TxtStartValue
        ' 
        TxtStartValue.Location = New Point(898, 73)
        TxtStartValue.Margin = New Padding(2)
        TxtStartValue.Name = "TxtStartValue"
        TxtStartValue.Size = New Size(147, 23)
        TxtStartValue.TabIndex = 12
        ' 
        ' LblStartValue
        ' 
        LblStartValue.AutoSize = True
        LblStartValue.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblStartValue.Location = New Point(815, 77)
        LblStartValue.Margin = New Padding(2, 0, 2, 0)
        LblStartValue.Name = "LblStartValue"
        LblStartValue.Size = New Size(65, 13)
        LblStartValue.TabIndex = 13
        LblStartValue.Text = "StartValue ="
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BtnStart.Location = New Point(815, 148)
        BtnStart.Margin = New Padding(2)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(230, 34)
        BtnStart.TabIndex = 18
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BtnReset.Location = New Point(815, 765)
        BtnReset.Margin = New Padding(2)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(230, 34)
        BtnReset.TabIndex = 19
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Location = New Point(917, 115)
        LblSteps.Margin = New Padding(2, 0, 2, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(13, 15)
        LblSteps.TabIndex = 28
        LblSteps.Text = "0"
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblNumberOfSteps.Location = New Point(815, 115)
        LblNumberOfSteps.Margin = New Padding(2, 0, 2, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(82, 13)
        LblNumberOfSteps.TabIndex = 27
        LblNumberOfSteps.Text = "NumberOfSteps"
        ' 
        ' CboFunction
        ' 
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic Growth", "Parabola"})
        CboFunction.Location = New Point(819, 2)
        CboFunction.Margin = New Padding(2)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(226, 23)
        CboFunction.TabIndex = 29
        ' 
        ' BtnStop
        ' 
        BtnStop.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BtnStop.Location = New Point(815, 196)
        BtnStop.Margin = New Padding(2)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(230, 34)
        BtnStop.TabIndex = 30
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BtnDefault.Location = New Point(815, 727)
        BtnDefault.Margin = New Padding(2)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(230, 34)
        BtnDefault.TabIndex = 31
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' FrmHistogram
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1061, 810)
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
        Margin = New Padding(2)
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
