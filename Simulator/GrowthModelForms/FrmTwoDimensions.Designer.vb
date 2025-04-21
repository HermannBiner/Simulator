<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTwoDimensions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTwoDimensions))
        PicDiagram = New PictureBox()
        GrpStartpoint = New GroupBox()
        TxtY = New TextBox()
        TxtX = New TextBox()
        LblY = New Label()
        LblX = New Label()
        GrpExperiment = New GroupBox()
        CboExperiment = New ComboBox()
        BtnNext10 = New Button()
        BtnReset = New Button()
        BtnNextStep = New Button()
        GrpParameter = New GroupBox()
        TxtParameter = New TextBox()
        LblParameter = New Label()
        CboFunction = New ComboBox()
        BtnDefault = New Button()
        GrpFunction = New GroupBox()
        OptSensitivity = New RadioButton()
        OptTransitivity = New RadioButton()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        GrpStartpoint.SuspendLayout()
        GrpExperiment.SuspendLayout()
        GrpParameter.SuspendLayout()
        GrpFunction.SuspendLayout()
        SuspendLayout()
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(6, 6)
        PicDiagram.Margin = New Padding(4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(600, 600)
        PicDiagram.TabIndex = 1
        PicDiagram.TabStop = False
        ' 
        ' GrpStartpoint
        ' 
        GrpStartpoint.Controls.Add(TxtY)
        GrpStartpoint.Controls.Add(TxtX)
        GrpStartpoint.Controls.Add(LblY)
        GrpStartpoint.Controls.Add(LblX)
        GrpStartpoint.Font = New Font("Microsoft Sans Serif", 9F)
        GrpStartpoint.Location = New Point(614, 173)
        GrpStartpoint.Margin = New Padding(4)
        GrpStartpoint.Name = "GrpStartpoint"
        GrpStartpoint.Padding = New Padding(4)
        GrpStartpoint.Size = New Size(254, 88)
        GrpStartpoint.TabIndex = 1
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
        LblY.Location = New Point(23, 57)
        LblY.Margin = New Padding(4, 0, 4, 0)
        LblY.Name = "LblY"
        LblY.Size = New Size(22, 15)
        LblY.TabIndex = 5
        LblY.Text = "y ="
        ' 
        ' LblX
        ' 
        LblX.AutoSize = True
        LblX.Location = New Point(21, 28)
        LblX.Margin = New Padding(4, 0, 4, 0)
        LblX.Name = "LblX"
        LblX.Size = New Size(23, 15)
        LblX.TabIndex = 4
        LblX.Text = "x ="
        ' 
        ' GrpExperiment
        ' 
        GrpExperiment.Controls.Add(CboExperiment)
        GrpExperiment.Font = New Font("Microsoft Sans Serif", 9F)
        GrpExperiment.Location = New Point(614, 269)
        GrpExperiment.Margin = New Padding(4)
        GrpExperiment.Name = "GrpExperiment"
        GrpExperiment.Padding = New Padding(4)
        GrpExperiment.Size = New Size(254, 63)
        GrpExperiment.TabIndex = 6
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
        ' BtnNext10
        ' 
        BtnNext10.Font = New Font("Microsoft Sans Serif", 9F)
        BtnNext10.Location = New Point(614, 499)
        BtnNext10.Margin = New Padding(4)
        BtnNext10.Name = "BtnNext10"
        BtnNext10.Size = New Size(254, 30)
        BtnNext10.TabIndex = 9
        BtnNext10.Text = "Next10Steps"
        BtnNext10.UseVisualStyleBackColor = True
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(614, 575)
        BtnReset.Margin = New Padding(4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(254, 30)
        BtnReset.TabIndex = 10
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnNextStep
        ' 
        BtnNextStep.Font = New Font("Microsoft Sans Serif", 9F)
        BtnNextStep.Location = New Point(614, 461)
        BtnNextStep.Margin = New Padding(4)
        BtnNextStep.Name = "BtnNextStep"
        BtnNextStep.Size = New Size(254, 30)
        BtnNextStep.TabIndex = 8
        BtnNextStep.Text = "NextStep"
        BtnNextStep.UseVisualStyleBackColor = True
        ' 
        ' GrpParameter
        ' 
        GrpParameter.Controls.Add(TxtParameter)
        GrpParameter.Controls.Add(LblParameter)
        GrpParameter.Font = New Font("Microsoft Sans Serif", 9F)
        GrpParameter.Location = New Point(614, 37)
        GrpParameter.Margin = New Padding(4)
        GrpParameter.Name = "GrpParameter"
        GrpParameter.Padding = New Padding(4)
        GrpParameter.Size = New Size(254, 59)
        GrpParameter.TabIndex = 4
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
        LblParameter.Location = New Point(21, 27)
        LblParameter.Margin = New Padding(4, 0, 4, 0)
        LblParameter.Name = "LblParameter"
        LblParameter.Size = New Size(24, 15)
        LblParameter.TabIndex = 0
        LblParameter.Text = "a ="
        ' 
        ' CboFunction
        ' 
        CboFunction.Font = New Font("Microsoft Sans Serif", 9F)
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic growth", "Parabola"})
        CboFunction.Location = New Point(614, 6)
        CboFunction.Margin = New Padding(4)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(254, 23)
        CboFunction.TabIndex = 11
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(614, 537)
        BtnDefault.Margin = New Padding(4)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(254, 30)
        BtnDefault.TabIndex = 12
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' GrpFunction
        ' 
        GrpFunction.Controls.Add(OptTransitivity)
        GrpFunction.Controls.Add(OptSensitivity)
        GrpFunction.Font = New Font("Microsoft Sans Serif", 9F)
        GrpFunction.Location = New Point(614, 103)
        GrpFunction.Name = "GrpFunction"
        GrpFunction.Size = New Size(254, 63)
        GrpFunction.TabIndex = 13
        GrpFunction.TabStop = False
        GrpFunction.Text = "Function"
        ' 
        ' OptSensitivity
        ' 
        OptSensitivity.AutoSize = True
        OptSensitivity.Checked = True
        OptSensitivity.Location = New Point(13, 25)
        OptSensitivity.Name = "OptSensitivity"
        OptSensitivity.Size = New Size(78, 19)
        OptSensitivity.TabIndex = 0
        OptSensitivity.Text = "Sensitivity"
        OptSensitivity.UseVisualStyleBackColor = True
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
        ' FrmTwoDimensions
        ' 
        AutoScaleDimensions = New SizeF(9F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(878, 615)
        Controls.Add(GrpFunction)
        Controls.Add(BtnDefault)
        Controls.Add(CboFunction)
        Controls.Add(GrpParameter)
        Controls.Add(GrpExperiment)
        Controls.Add(BtnNextStep)
        Controls.Add(BtnReset)
        Controls.Add(BtnNext10)
        Controls.Add(GrpStartpoint)
        Controls.Add(PicDiagram)
        Font = New Font("Microsoft Sans Serif", 11.1428576F)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4)
        Name = "FrmTwoDimensions"
        Text = "TwoDimensions"
        WindowState = FormWindowState.Maximized
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        GrpStartpoint.ResumeLayout(False)
        GrpStartpoint.PerformLayout()
        GrpExperiment.ResumeLayout(False)
        GrpParameter.ResumeLayout(False)
        GrpParameter.PerformLayout()
        GrpFunction.ResumeLayout(False)
        GrpFunction.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents GrpStartpoint As GroupBox
    Friend WithEvents TxtY As TextBox
    Friend WithEvents TxtX As TextBox
    Friend WithEvents LblY As Label
    Friend WithEvents LblX As Label
    Friend WithEvents BtnNext10 As Button
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnNextStep As Button
    Friend WithEvents GrpExperiment As GroupBox
    Friend WithEvents CboExperiment As ComboBox
    Friend WithEvents GrpParameter As GroupBox
    Friend WithEvents TxtParameter As TextBox
    Friend WithEvents LblParameter As Label
    Friend WithEvents CboFunction As ComboBox
    Friend WithEvents BtnDefault As Button
    Friend WithEvents GrpFunction As GroupBox
    Friend WithEvents OptSensitivity As RadioButton
    Friend WithEvents OptTransitivity As RadioButton
End Class
