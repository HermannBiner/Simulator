<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPopulation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPopulation))
        SplitContainer = New SplitContainer()
        PicDiagram = New PictureBox()
        LblSteps = New Label()
        LblPercent = New Label()
        TxtPopulationDensity = New TextBox()
        LblPopulationDensity = New Label()
        BtnNextStep = New Button()
        BtnStop = New Button()
        BtnStart = New Button()
        BtnDefault = New Button()
        LblNumberOfSteps = New Label()
        BtnReset = New Button()
        LblParameterA = New Label()
        TrbParameterA = New TrackBar()
        TxtParameterA = New TextBox()
        TxtStartValue = New TextBox()
        LblStartValue = New Label()
        LblParameter = New Label()
        CboFunction = New ComboBox()
        CType(SplitContainer, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer.Panel1.SuspendLayout()
        SplitContainer.Panel2.SuspendLayout()
        SplitContainer.SuspendLayout()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbParameterA, ComponentModel.ISupportInitialize).BeginInit()
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
        SplitContainer.Panel2.Controls.Add(LblSteps)
        SplitContainer.Panel2.Controls.Add(LblPercent)
        SplitContainer.Panel2.Controls.Add(TxtPopulationDensity)
        SplitContainer.Panel2.Controls.Add(LblPopulationDensity)
        SplitContainer.Panel2.Controls.Add(BtnNextStep)
        SplitContainer.Panel2.Controls.Add(BtnStop)
        SplitContainer.Panel2.Controls.Add(BtnStart)
        SplitContainer.Panel2.Controls.Add(BtnDefault)
        SplitContainer.Panel2.Controls.Add(LblNumberOfSteps)
        SplitContainer.Panel2.Controls.Add(BtnReset)
        SplitContainer.Panel2.Controls.Add(LblParameterA)
        SplitContainer.Panel2.Controls.Add(TrbParameterA)
        SplitContainer.Panel2.Controls.Add(TxtParameterA)
        SplitContainer.Panel2.Controls.Add(TxtStartValue)
        SplitContainer.Panel2.Controls.Add(LblStartValue)
        SplitContainer.Panel2.Controls.Add(LblParameter)
        SplitContainer.Panel2.Controls.Add(CboFunction)
        SplitContainer.Size = New Size(884, 589)
        SplitContainer.SplitterDistance = 590
        SplitContainer.SplitterWidth = 6
        SplitContainer.TabIndex = 0
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(6, 5)
        PicDiagram.Margin = New Padding(4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(580, 580)
        PicDiagram.TabIndex = 2
        PicDiagram.TabStop = False
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblSteps.Location = New Point(106, 171)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(14, 15)
        LblSteps.TabIndex = 69
        LblSteps.Text = "0"
        ' 
        ' LblPercent
        ' 
        LblPercent.AutoSize = True
        LblPercent.Location = New Point(260, 143)
        LblPercent.Name = "LblPercent"
        LblPercent.Size = New Size(17, 15)
        LblPercent.TabIndex = 68
        LblPercent.Text = "%"
        ' 
        ' TxtPopulationDensity
        ' 
        TxtPopulationDensity.Location = New Point(168, 140)
        TxtPopulationDensity.Name = "TxtPopulationDensity"
        TxtPopulationDensity.ReadOnly = True
        TxtPopulationDensity.Size = New Size(86, 23)
        TxtPopulationDensity.TabIndex = 67
        TxtPopulationDensity.TextAlign = HorizontalAlignment.Right
        ' 
        ' LblPopulationDensity
        ' 
        LblPopulationDensity.AutoSize = True
        LblPopulationDensity.Location = New Point(3, 145)
        LblPopulationDensity.Name = "LblPopulationDensity"
        LblPopulationDensity.Size = New Size(104, 15)
        LblPopulationDensity.TabIndex = 66
        LblPopulationDensity.Text = "PopulationDensity"
        ' 
        ' BtnNextStep
        ' 
        BtnNextStep.Font = New Font("Microsoft Sans Serif", 9F)
        BtnNextStep.Location = New Point(3, 199)
        BtnNextStep.Margin = New Padding(4)
        BtnNextStep.Name = "BtnNextStep"
        BtnNextStep.Size = New Size(280, 30)
        BtnNextStep.TabIndex = 65
        BtnNextStep.Text = "NextStep"
        BtnNextStep.UseVisualStyleBackColor = True
        ' 
        ' BtnStop
        ' 
        BtnStop.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStop.Location = New Point(3, 275)
        BtnStop.Margin = New Padding(4)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(280, 30)
        BtnStop.TabIndex = 64
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStart.Location = New Point(3, 237)
        BtnStart.Margin = New Padding(4)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(280, 30)
        BtnStart.TabIndex = 63
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(4, 313)
        BtnDefault.Margin = New Padding(4)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(279, 30)
        BtnDefault.TabIndex = 62
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblNumberOfSteps.Location = New Point(3, 171)
        LblNumberOfSteps.Margin = New Padding(4, 0, 4, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(95, 15)
        LblNumberOfSteps.TabIndex = 60
        LblNumberOfSteps.Text = "NumberOfSteps"
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(4, 348)
        BtnReset.Margin = New Padding(4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(279, 30)
        BtnReset.TabIndex = 61
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' LblParameterA
        ' 
        LblParameterA.AutoSize = True
        LblParameterA.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblParameterA.Location = New Point(3, 38)
        LblParameterA.Margin = New Padding(4, 0, 4, 0)
        LblParameterA.Name = "LblParameterA"
        LblParameterA.Size = New Size(75, 15)
        LblParameterA.TabIndex = 59
        LblParameterA.Text = "Parameter a"
        ' 
        ' TrbParameterA
        ' 
        TrbParameterA.Location = New Point(87, 38)
        TrbParameterA.Margin = New Padding(6)
        TrbParameterA.Maximum = 1000
        TrbParameterA.Minimum = 1
        TrbParameterA.Name = "TrbParameterA"
        TrbParameterA.Size = New Size(196, 45)
        TrbParameterA.TabIndex = 58
        TrbParameterA.Value = 500
        ' 
        ' TxtParameterA
        ' 
        TxtParameterA.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TxtParameterA.Location = New Point(87, 83)
        TxtParameterA.Margin = New Padding(4)
        TxtParameterA.Name = "TxtParameterA"
        TxtParameterA.Size = New Size(196, 21)
        TxtParameterA.TabIndex = 54
        ' 
        ' TxtStartValue
        ' 
        TxtStartValue.Font = New Font("Microsoft Sans Serif", 9F)
        TxtStartValue.Location = New Point(87, 107)
        TxtStartValue.Margin = New Padding(4)
        TxtStartValue.Name = "TxtStartValue"
        TxtStartValue.Size = New Size(196, 21)
        TxtStartValue.TabIndex = 55
        ' 
        ' LblStartValue
        ' 
        LblStartValue.AutoSize = True
        LblStartValue.Font = New Font("Microsoft Sans Serif", 9F)
        LblStartValue.Location = New Point(4, 110)
        LblStartValue.Margin = New Padding(4, 0, 4, 0)
        LblStartValue.Name = "LblStartValue"
        LblStartValue.Size = New Size(76, 15)
        LblStartValue.TabIndex = 57
        LblStartValue.Text = "StartValue = "
        ' 
        ' LblParameter
        ' 
        LblParameter.AutoSize = True
        LblParameter.Font = New Font("Microsoft Sans Serif", 9F)
        LblParameter.Location = New Point(54, 86)
        LblParameter.Margin = New Padding(4, 0, 4, 0)
        LblParameter.Name = "LblParameter"
        LblParameter.Size = New Size(24, 15)
        LblParameter.TabIndex = 56
        LblParameter.Text = "a ="
        ' 
        ' CboFunction
        ' 
        CboFunction.Font = New Font("Microsoft Sans Serif", 9F)
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic Growth", "Parabola"})
        CboFunction.Location = New Point(4, 5)
        CboFunction.Margin = New Padding(4)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(279, 23)
        CboFunction.TabIndex = 53
        ' 
        ' FrmPopulation
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(884, 589)
        Controls.Add(SplitContainer)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimumSize = New Size(353, 420)
        Name = "FrmPopulation"
        StartPosition = FormStartPosition.WindowsDefaultBounds
        Text = "PopulationDensity"
        WindowState = FormWindowState.Maximized
        SplitContainer.Panel1.ResumeLayout(False)
        SplitContainer.Panel2.ResumeLayout(False)
        SplitContainer.Panel2.PerformLayout()
        CType(SplitContainer, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer.ResumeLayout(False)
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbParameterA, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer As SplitContainer
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents LblPercent As Label
    Friend WithEvents TxtPopulationDensity As TextBox
    Friend WithEvents LblPopulationDensity As Label
    Friend WithEvents BtnNextStep As Button
    Friend WithEvents BtnStop As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents BtnDefault As Button
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents BtnReset As Button
    Friend WithEvents LblParameterA As Label
    Friend WithEvents TrbParameterA As TrackBar
    Friend WithEvents TxtParameterA As TextBox
    Friend WithEvents TxtStartValue As TextBox
    Friend WithEvents LblStartValue As Label
    Friend WithEvents LblParameter As Label
    Friend WithEvents CboFunction As ComboBox
    Friend WithEvents LblSteps As Label
End Class
