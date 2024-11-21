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
        PicDiagram = New PictureBox()
        CboFunction = New ComboBox()
        LblParameterA = New Label()
        TrbParameterA = New TrackBar()
        TxtParameterA = New TextBox()
        TxtStartValue = New TextBox()
        LblStartValue = New Label()
        LblParameter = New Label()
        BtnDefault = New Button()
        LblSteps = New Label()
        LblNumberOfSteps = New Label()
        BtnReset = New Button()
        BtnStop = New Button()
        BtnStart = New Button()
        BtnNextStep = New Button()
        LblPopulationDensity = New Label()
        TxtPopulationDensity = New TextBox()
        LblPercent = New Label()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbParameterA, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(4, 5)
        PicDiagram.Margin = New Padding(4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(580, 580)
        PicDiagram.TabIndex = 1
        PicDiagram.TabStop = False
        ' 
        ' CboFunction
        ' 
        CboFunction.Font = New Font("Microsoft Sans Serif", 9F)
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic Growth", "Parabola"})
        CboFunction.Location = New Point(592, 5)
        CboFunction.Margin = New Padding(4)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(280, 23)
        CboFunction.TabIndex = 2
        ' 
        ' LblParameterA
        ' 
        LblParameterA.AutoSize = True
        LblParameterA.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblParameterA.Location = New Point(591, 38)
        LblParameterA.Margin = New Padding(4, 0, 4, 0)
        LblParameterA.Name = "LblParameterA"
        LblParameterA.Size = New Size(75, 15)
        LblParameterA.TabIndex = 42
        LblParameterA.Text = "Parameter a"
        ' 
        ' TrbParameterA
        ' 
        TrbParameterA.Location = New Point(675, 38)
        TrbParameterA.Margin = New Padding(6)
        TrbParameterA.Maximum = 1000
        TrbParameterA.Minimum = 1
        TrbParameterA.Name = "TrbParameterA"
        TrbParameterA.Size = New Size(197, 45)
        TrbParameterA.TabIndex = 41
        TrbParameterA.Value = 500
        ' 
        ' TxtParameterA
        ' 
        TxtParameterA.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TxtParameterA.Location = New Point(675, 83)
        TxtParameterA.Margin = New Padding(4)
        TxtParameterA.Name = "TxtParameterA"
        TxtParameterA.Size = New Size(197, 21)
        TxtParameterA.TabIndex = 37
        ' 
        ' TxtStartValue
        ' 
        TxtStartValue.Font = New Font("Microsoft Sans Serif", 9F)
        TxtStartValue.Location = New Point(675, 107)
        TxtStartValue.Margin = New Padding(4)
        TxtStartValue.Name = "TxtStartValue"
        TxtStartValue.Size = New Size(197, 21)
        TxtStartValue.TabIndex = 38
        ' 
        ' LblStartValue
        ' 
        LblStartValue.AutoSize = True
        LblStartValue.Font = New Font("Microsoft Sans Serif", 9F)
        LblStartValue.Location = New Point(592, 110)
        LblStartValue.Margin = New Padding(4, 0, 4, 0)
        LblStartValue.Name = "LblStartValue"
        LblStartValue.Size = New Size(76, 15)
        LblStartValue.TabIndex = 40
        LblStartValue.Text = "StartValue = "
        ' 
        ' LblParameter
        ' 
        LblParameter.AutoSize = True
        LblParameter.Font = New Font("Microsoft Sans Serif", 9F)
        LblParameter.Location = New Point(642, 86)
        LblParameter.Margin = New Padding(4, 0, 4, 0)
        LblParameter.Name = "LblParameter"
        LblParameter.Size = New Size(24, 15)
        LblParameter.TabIndex = 39
        LblParameter.Text = "a ="
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(591, 520)
        BtnDefault.Margin = New Padding(4)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(281, 30)
        BtnDefault.TabIndex = 46
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblSteps.Location = New Point(694, 170)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(14, 15)
        LblSteps.TabIndex = 45
        LblSteps.Text = "0"
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblNumberOfSteps.Location = New Point(591, 171)
        LblNumberOfSteps.Margin = New Padding(4, 0, 4, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(95, 15)
        LblNumberOfSteps.TabIndex = 43
        LblNumberOfSteps.Text = "NumberOfSteps"
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(591, 555)
        BtnReset.Margin = New Padding(4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(280, 30)
        BtnReset.TabIndex = 44
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStop
        ' 
        BtnStop.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStop.Location = New Point(591, 275)
        BtnStop.Margin = New Padding(4)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(280, 30)
        BtnStop.TabIndex = 48
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStart.Location = New Point(591, 237)
        BtnStart.Margin = New Padding(4)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(280, 30)
        BtnStart.TabIndex = 47
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' BtnNextStep
        ' 
        BtnNextStep.Font = New Font("Microsoft Sans Serif", 9F)
        BtnNextStep.Location = New Point(591, 199)
        BtnNextStep.Margin = New Padding(4)
        BtnNextStep.Name = "BtnNextStep"
        BtnNextStep.Size = New Size(280, 30)
        BtnNextStep.TabIndex = 49
        BtnNextStep.Text = "NextStep"
        BtnNextStep.UseVisualStyleBackColor = True
        ' 
        ' LblPopulationDensity
        ' 
        LblPopulationDensity.AutoSize = True
        LblPopulationDensity.Location = New Point(591, 145)
        LblPopulationDensity.Name = "LblPopulationDensity"
        LblPopulationDensity.Size = New Size(104, 15)
        LblPopulationDensity.TabIndex = 50
        LblPopulationDensity.Text = "PopulationDensity"
        ' 
        ' TxtPopulationDensity
        ' 
        TxtPopulationDensity.Location = New Point(756, 140)
        TxtPopulationDensity.Name = "TxtPopulationDensity"
        TxtPopulationDensity.ReadOnly = True
        TxtPopulationDensity.Size = New Size(92, 23)
        TxtPopulationDensity.TabIndex = 51
        TxtPopulationDensity.TextAlign = HorizontalAlignment.Right
        ' 
        ' LblPercent
        ' 
        LblPercent.AutoSize = True
        LblPercent.Location = New Point(854, 143)
        LblPercent.Name = "LblPercent"
        LblPercent.Size = New Size(17, 15)
        LblPercent.TabIndex = 52
        LblPercent.Text = "%"
        ' 
        ' FrmPopulation
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(880, 591)
        Controls.Add(LblPercent)
        Controls.Add(TxtPopulationDensity)
        Controls.Add(LblPopulationDensity)
        Controls.Add(BtnNextStep)
        Controls.Add(BtnStop)
        Controls.Add(BtnStart)
        Controls.Add(BtnDefault)
        Controls.Add(LblSteps)
        Controls.Add(LblNumberOfSteps)
        Controls.Add(BtnReset)
        Controls.Add(LblParameterA)
        Controls.Add(TrbParameterA)
        Controls.Add(TxtParameterA)
        Controls.Add(TxtStartValue)
        Controls.Add(LblStartValue)
        Controls.Add(LblParameter)
        Controls.Add(CboFunction)
        Controls.Add(PicDiagram)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "FrmPopulation"
        Text = "PopulationDensity"
        WindowState = FormWindowState.Maximized
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbParameterA, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents CboFunction As ComboBox
    Friend WithEvents LblParameterA As Label
    Friend WithEvents TrbParameterA As TrackBar
    Friend WithEvents TxtParameterA As TextBox
    Friend WithEvents TxtStartValue As TextBox
    Friend WithEvents LblStartValue As Label
    Friend WithEvents LblParameter As Label
    Friend WithEvents BtnDefault As Button
    Friend WithEvents LblSteps As Label
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStop As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents BtnNextStep As Button
    Friend WithEvents LblPopulationDensity As Label
    Friend WithEvents TxtPopulationDensity As TextBox
    Friend WithEvents LblPercent As Label
End Class
