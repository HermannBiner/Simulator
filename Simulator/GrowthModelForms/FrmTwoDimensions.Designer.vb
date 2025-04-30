<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTwoDimensions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTwoDimensions))
        SplitContainer = New SplitContainer()
        PicDiagram = New PictureBox()
        GrpFunction = New GroupBox()
        OptTransitivity = New RadioButton()
        OptSensitivity = New RadioButton()
        BtnDefault = New Button()
        GrpParameter = New GroupBox()
        TxtParameter = New TextBox()
        LblParameter = New Label()
        GrpExperiment = New GroupBox()
        CboExperiment = New ComboBox()
        BtnNextStep = New Button()
        BtnReset = New Button()
        BtnNext10 = New Button()
        GrpStartpoint = New GroupBox()
        TxtY = New TextBox()
        TxtX = New TextBox()
        LblY = New Label()
        LblX = New Label()
        CboFunction = New ComboBox()
        CType(SplitContainer, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer.Panel1.SuspendLayout()
        SplitContainer.Panel2.SuspendLayout()
        SplitContainer.SuspendLayout()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        GrpFunction.SuspendLayout()
        GrpParameter.SuspendLayout()
        GrpExperiment.SuspendLayout()
        GrpStartpoint.SuspendLayout()
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
        SplitContainer.Panel2.Controls.Add(GrpFunction)
        SplitContainer.Panel2.Controls.Add(BtnDefault)
        SplitContainer.Panel2.Controls.Add(GrpParameter)
        SplitContainer.Panel2.Controls.Add(GrpExperiment)
        SplitContainer.Panel2.Controls.Add(BtnNextStep)
        SplitContainer.Panel2.Controls.Add(BtnReset)
        SplitContainer.Panel2.Controls.Add(BtnNext10)
        SplitContainer.Panel2.Controls.Add(GrpStartpoint)
        SplitContainer.Panel2.Controls.Add(CboFunction)
        SplitContainer.Size = New Size(878, 615)
        SplitContainer.SplitterDistance = 607
        SplitContainer.SplitterWidth = 6
        SplitContainer.TabIndex = 0
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(4, 7)
        PicDiagram.Margin = New Padding(4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(600, 600)
        PicDiagram.TabIndex = 2
        PicDiagram.TabStop = False
        ' 
        ' GrpFunction
        ' 
        GrpFunction.Controls.Add(OptTransitivity)
        GrpFunction.Controls.Add(OptSensitivity)
        GrpFunction.Font = New Font("Microsoft Sans Serif", 9F)
        GrpFunction.Location = New Point(7, 104)
        GrpFunction.Name = "GrpFunction"
        GrpFunction.Size = New Size(254, 63)
        GrpFunction.TabIndex = 21
        GrpFunction.TabStop = False
        GrpFunction.Text = "Function"
        ' 
        ' OptTransitivity
        ' 
        OptTransitivity.AutoSize = True
        OptTransitivity.Location = New Point(117, 25)
        OptTransitivity.Name = "OptTransitivity"
        OptTransitivity.Size = New Size(81, 19)
        OptTransitivity.TabIndex = 1
        OptTransitivity.Text = "Transitivity"
        OptTransitivity.UseVisualStyleBackColor = True
        ' 
        ' OptSensitivity
        ' 
        OptSensitivity.AutoSize = True
        OptSensitivity.Checked = True
        OptSensitivity.Location = New Point(13, 25)
        OptSensitivity.Name = "OptSensitivity"
        OptSensitivity.Size = New Size(78, 19)
        OptSensitivity.TabIndex = 0
        OptSensitivity.TabStop = True
        OptSensitivity.Text = "Sensitivity"
        OptSensitivity.UseVisualStyleBackColor = True
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(7, 538)
        BtnDefault.Margin = New Padding(4)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(254, 30)
        BtnDefault.TabIndex = 20
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' GrpParameter
        ' 
        GrpParameter.Controls.Add(TxtParameter)
        GrpParameter.Controls.Add(LblParameter)
        GrpParameter.Font = New Font("Microsoft Sans Serif", 9F)
        GrpParameter.Location = New Point(7, 38)
        GrpParameter.Margin = New Padding(4)
        GrpParameter.Name = "GrpParameter"
        GrpParameter.Padding = New Padding(4)
        GrpParameter.Size = New Size(254, 59)
        GrpParameter.TabIndex = 15
        GrpParameter.TabStop = False
        GrpParameter.Text = "Parameter"
        ' 
        ' TxtParameter
        ' 
        TxtParameter.AcceptsReturn = True
        TxtParameter.AcceptsTab = True
        TxtParameter.Location = New Point(53, 24)
        TxtParameter.Margin = New Padding(4)
        TxtParameter.Name = "TxtParameter"
        TxtParameter.Size = New Size(193, 21)
        TxtParameter.TabIndex = 5
        ' 
        ' LblParameter
        ' 
        LblParameter.AutoSize = True
        LblParameter.Location = New Point(22, 28)
        LblParameter.Margin = New Padding(4, 0, 4, 0)
        LblParameter.Name = "LblParameter"
        LblParameter.Size = New Size(24, 15)
        LblParameter.TabIndex = 0
        LblParameter.Text = "a ="
        ' 
        ' GrpExperiment
        ' 
        GrpExperiment.Controls.Add(CboExperiment)
        GrpExperiment.Font = New Font("Microsoft Sans Serif", 9F)
        GrpExperiment.Location = New Point(7, 270)
        GrpExperiment.Margin = New Padding(4)
        GrpExperiment.Name = "GrpExperiment"
        GrpExperiment.Padding = New Padding(4)
        GrpExperiment.Size = New Size(254, 63)
        GrpExperiment.TabIndex = 16
        GrpExperiment.TabStop = False
        GrpExperiment.Text = "ExperimentNo"
        ' 
        ' CboExperiment
        ' 
        CboExperiment.FormattingEnabled = True
        CboExperiment.Items.AddRange(New Object() {"Experiment 1", "Experiment 2", "Experiment 3", "Experiment 4", "Experiment 5"})
        CboExperiment.Location = New Point(8, 22)
        CboExperiment.Margin = New Padding(4)
        CboExperiment.Name = "CboExperiment"
        CboExperiment.Size = New Size(238, 23)
        CboExperiment.TabIndex = 7
        ' 
        ' BtnNextStep
        ' 
        BtnNextStep.Font = New Font("Microsoft Sans Serif", 9F)
        BtnNextStep.Location = New Point(7, 462)
        BtnNextStep.Margin = New Padding(4)
        BtnNextStep.Name = "BtnNextStep"
        BtnNextStep.Size = New Size(254, 30)
        BtnNextStep.TabIndex = 17
        BtnNextStep.Text = "NextStep"
        BtnNextStep.UseVisualStyleBackColor = True
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(7, 576)
        BtnReset.Margin = New Padding(4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(254, 30)
        BtnReset.TabIndex = 19
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnNext10
        ' 
        BtnNext10.Font = New Font("Microsoft Sans Serif", 9F)
        BtnNext10.Location = New Point(7, 500)
        BtnNext10.Margin = New Padding(4)
        BtnNext10.Name = "BtnNext10"
        BtnNext10.Size = New Size(254, 30)
        BtnNext10.TabIndex = 18
        BtnNext10.Text = "Next10Steps"
        BtnNext10.UseVisualStyleBackColor = True
        ' 
        ' GrpStartpoint
        ' 
        GrpStartpoint.Controls.Add(TxtY)
        GrpStartpoint.Controls.Add(TxtX)
        GrpStartpoint.Controls.Add(LblY)
        GrpStartpoint.Controls.Add(LblX)
        GrpStartpoint.Font = New Font("Microsoft Sans Serif", 9F)
        GrpStartpoint.Location = New Point(7, 174)
        GrpStartpoint.Margin = New Padding(4)
        GrpStartpoint.Name = "GrpStartpoint"
        GrpStartpoint.Padding = New Padding(4)
        GrpStartpoint.Size = New Size(254, 88)
        GrpStartpoint.TabIndex = 14
        GrpStartpoint.TabStop = False
        GrpStartpoint.Text = "CoordinatesStartpoint"
        ' 
        ' TxtY
        ' 
        TxtY.AcceptsReturn = True
        TxtY.AcceptsTab = True
        TxtY.Location = New Point(53, 51)
        TxtY.Margin = New Padding(4)
        TxtY.Name = "TxtY"
        TxtY.Size = New Size(193, 21)
        TxtY.TabIndex = 3
        ' 
        ' TxtX
        ' 
        TxtX.AcceptsReturn = True
        TxtX.AcceptsTab = True
        TxtX.Location = New Point(53, 22)
        TxtX.Margin = New Padding(4)
        TxtX.Name = "TxtX"
        TxtX.Size = New Size(193, 21)
        TxtX.TabIndex = 2
        ' 
        ' LblY
        ' 
        LblY.AutoSize = True
        LblY.Location = New Point(24, 58)
        LblY.Margin = New Padding(4, 0, 4, 0)
        LblY.Name = "LblY"
        LblY.Size = New Size(22, 15)
        LblY.TabIndex = 5
        LblY.Text = "y ="
        ' 
        ' LblX
        ' 
        LblX.AutoSize = True
        LblX.Location = New Point(22, 29)
        LblX.Margin = New Padding(4, 0, 4, 0)
        LblX.Name = "LblX"
        LblX.Size = New Size(23, 15)
        LblX.TabIndex = 4
        LblX.Text = "x ="
        ' 
        ' CboFunction
        ' 
        CboFunction.Font = New Font("Microsoft Sans Serif", 9F)
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic growth", "Parabola"})
        CboFunction.Location = New Point(7, 4)
        CboFunction.Margin = New Padding(4)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(254, 23)
        CboFunction.TabIndex = 12
        ' 
        ' FrmTwoDimensions
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(878, 615)
        Controls.Add(SplitContainer)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "FrmTwoDimensions"
        StartPosition = FormStartPosition.WindowsDefaultBounds
        Text = "TwoDimensions"
        WindowState = FormWindowState.Maximized
        SplitContainer.Panel1.ResumeLayout(False)
        SplitContainer.Panel2.ResumeLayout(False)
        CType(SplitContainer, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer.ResumeLayout(False)
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        GrpFunction.ResumeLayout(False)
        GrpFunction.PerformLayout()
        GrpParameter.ResumeLayout(False)
        GrpParameter.PerformLayout()
        GrpExperiment.ResumeLayout(False)
        GrpStartpoint.ResumeLayout(False)
        GrpStartpoint.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer As SplitContainer
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents GrpFunction As GroupBox
    Friend WithEvents OptTransitivity As RadioButton
    Friend WithEvents OptSensitivity As RadioButton
    Friend WithEvents BtnDefault As Button
    Friend WithEvents GrpParameter As GroupBox
    Friend WithEvents TxtParameter As TextBox
    Friend WithEvents LblParameter As Label
    Friend WithEvents GrpExperiment As GroupBox
    Friend WithEvents CboExperiment As ComboBox
    Friend WithEvents BtnNextStep As Button
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnNext10 As Button
    Friend WithEvents GrpStartpoint As GroupBox
    Friend WithEvents TxtY As TextBox
    Friend WithEvents TxtX As TextBox
    Friend WithEvents LblY As Label
    Friend WithEvents LblX As Label
    Friend WithEvents CboFunction As ComboBox
End Class
