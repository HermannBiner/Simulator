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
        BtnNext10 = New Button()
        BtnReset = New Button()
        BtnNextStep = New Button()
        GrpExperiment = New GroupBox()
        CboExperiment = New ComboBox()
        GrpParameter = New GroupBox()
        TxtParameter = New TextBox()
        LblParameter = New Label()
        CboFunction = New ComboBox()
        BtnDefault = New Button()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        GrpStartpoint.SuspendLayout()
        GrpExperiment.SuspendLayout()
        GrpParameter.SuspendLayout()
        SuspendLayout()
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(-1, 5)
        PicDiagram.Margin = New Padding(2)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(800, 800)
        PicDiagram.TabIndex = 1
        PicDiagram.TabStop = False
        ' 
        ' GrpStartpoint
        ' 
        GrpStartpoint.Controls.Add(TxtY)
        GrpStartpoint.Controls.Add(TxtX)
        GrpStartpoint.Controls.Add(LblY)
        GrpStartpoint.Controls.Add(LblX)
        GrpStartpoint.Location = New Point(814, 111)
        GrpStartpoint.Margin = New Padding(2)
        GrpStartpoint.Name = "GrpStartpoint"
        GrpStartpoint.Padding = New Padding(2)
        GrpStartpoint.Size = New Size(230, 99)
        GrpStartpoint.TabIndex = 1
        GrpStartpoint.TabStop = False
        GrpStartpoint.Text = "CoordinatesStartpoint"
        ' 
        ' TxtY
        ' 
        TxtY.AcceptsReturn = True
        TxtY.AcceptsTab = True
        TxtY.Location = New Point(49, 58)
        TxtY.Margin = New Padding(2)
        TxtY.Name = "TxtY"
        TxtY.Size = New Size(163, 23)
        TxtY.TabIndex = 3
        ' 
        ' TxtX
        ' 
        TxtX.AcceptsReturn = True
        TxtX.AcceptsTab = True
        TxtX.Location = New Point(49, 31)
        TxtX.Margin = New Padding(2)
        TxtX.Name = "TxtX"
        TxtX.Size = New Size(163, 23)
        TxtX.TabIndex = 2
        ' 
        ' LblY
        ' 
        LblY.AutoSize = True
        LblY.Location = New Point(15, 60)
        LblY.Margin = New Padding(2, 0, 2, 0)
        LblY.Name = "LblY"
        LblY.Size = New Size(24, 15)
        LblY.TabIndex = 5
        LblY.Text = "y ="
        ' 
        ' LblX
        ' 
        LblX.AutoSize = True
        LblX.Location = New Point(15, 36)
        LblX.Margin = New Padding(2, 0, 2, 0)
        LblX.Name = "LblX"
        LblX.Size = New Size(24, 15)
        LblX.TabIndex = 4
        LblX.Text = "x ="
        ' 
        ' BtnNext10
        ' 
        BtnNext10.Location = New Point(814, 353)
        BtnNext10.Margin = New Padding(2)
        BtnNext10.Name = "BtnNext10"
        BtnNext10.Size = New Size(230, 34)
        BtnNext10.TabIndex = 9
        BtnNext10.Text = "Next10Steps"
        BtnNext10.UseVisualStyleBackColor = True
        ' 
        ' BtnReset
        ' 
        BtnReset.Location = New Point(814, 772)
        BtnReset.Margin = New Padding(2)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(230, 34)
        BtnReset.TabIndex = 10
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnNextStep
        ' 
        BtnNextStep.Location = New Point(814, 315)
        BtnNextStep.Margin = New Padding(2)
        BtnNextStep.Name = "BtnNextStep"
        BtnNextStep.Size = New Size(230, 34)
        BtnNextStep.TabIndex = 8
        BtnNextStep.Text = "NextStep"
        BtnNextStep.UseVisualStyleBackColor = True
        ' 
        ' GrpExperiment
        ' 
        GrpExperiment.Controls.Add(CboExperiment)
        GrpExperiment.Location = New Point(810, 224)
        GrpExperiment.Margin = New Padding(2)
        GrpExperiment.Name = "GrpExperiment"
        GrpExperiment.Padding = New Padding(2)
        GrpExperiment.Size = New Size(230, 77)
        GrpExperiment.TabIndex = 6
        GrpExperiment.TabStop = False
        GrpExperiment.Text = "ExperimentNo"
        ' 
        ' CboExperiment
        ' 
        CboExperiment.FormattingEnabled = True
        CboExperiment.Items.AddRange(New Object() {"Experiment 1", "Experiment 2", "Experiment 3", "Experiment 4", "Experiment 5"})
        CboExperiment.Location = New Point(12, 31)
        CboExperiment.Margin = New Padding(2)
        CboExperiment.Name = "CboExperiment"
        CboExperiment.Size = New Size(200, 23)
        CboExperiment.TabIndex = 7
        ' 
        ' GrpParameter
        ' 
        GrpParameter.Controls.Add(TxtParameter)
        GrpParameter.Controls.Add(LblParameter)
        GrpParameter.Location = New Point(814, 45)
        GrpParameter.Margin = New Padding(2)
        GrpParameter.Name = "GrpParameter"
        GrpParameter.Padding = New Padding(2)
        GrpParameter.Size = New Size(230, 61)
        GrpParameter.TabIndex = 4
        GrpParameter.TabStop = False
        GrpParameter.Text = "Parameter"
        ' 
        ' TxtParameter
        ' 
        TxtParameter.AcceptsReturn = True
        TxtParameter.AcceptsTab = True
        TxtParameter.Location = New Point(47, 20)
        TxtParameter.Margin = New Padding(2)
        TxtParameter.Name = "TxtParameter"
        TxtParameter.Size = New Size(179, 23)
        TxtParameter.TabIndex = 5
        ' 
        ' LblParameter
        ' 
        LblParameter.AutoSize = True
        LblParameter.Location = New Point(12, 25)
        LblParameter.Margin = New Padding(2, 0, 2, 0)
        LblParameter.Name = "LblParameter"
        LblParameter.Size = New Size(24, 15)
        LblParameter.TabIndex = 0
        LblParameter.Text = "a ="
        ' 
        ' CboFunction
        ' 
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic growth", "Parabola"})
        CboFunction.Location = New Point(814, 5)
        CboFunction.Margin = New Padding(2)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(230, 23)
        CboFunction.TabIndex = 11
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Location = New Point(814, 734)
        BtnDefault.Margin = New Padding(2)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(230, 34)
        BtnDefault.TabIndex = 12
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' FrmTwoDimensions
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1059, 811)
        Controls.Add(BtnDefault)
        Controls.Add(CboFunction)
        Controls.Add(GrpParameter)
        Controls.Add(GrpExperiment)
        Controls.Add(BtnNextStep)
        Controls.Add(BtnReset)
        Controls.Add(BtnNext10)
        Controls.Add(GrpStartpoint)
        Controls.Add(PicDiagram)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(2)
        Name = "FrmTwoDimensions"
        Text = "TwoDimensions"
        WindowState = FormWindowState.Maximized
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        GrpStartpoint.ResumeLayout(False)
        GrpStartpoint.PerformLayout()
        GrpExperiment.ResumeLayout(False)
        GrpParameter.ResumeLayout(False)
        GrpParameter.PerformLayout()
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
End Class
