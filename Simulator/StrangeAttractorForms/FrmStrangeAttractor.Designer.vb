<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStrangeAttractor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmStrangeAttractor))
        PicDiagram = New PictureBox()
        LblStrangeAttractor = New Label()
        CboStrangeAttractor = New ComboBox()
        TxtDSParameter = New TextBox()
        LblDSParameter = New Label()
        TrbDSParameter = New TrackBar()
        TxtY = New TextBox()
        TxtX = New TextBox()
        TxtZ = New TextBox()
        LblX = New Label()
        LblY = New Label()
        LblZ = New Label()
        LblSteps = New Label()
        LblNumberOfSteps = New Label()
        BtnStop = New Button()
        BtnStart = New Button()
        BtnDefault = New Button()
        BtnReset = New Button()
        LblStepWidth = New Label()
        TrbStepWidth = New TrackBar()
        GrpStartPoint = New GroupBox()
        BtnTakeOverPointSet = New Button()
        CboStartpointSets = New ComboBox()
        LblStartpointSets = New Label()
        GrpView = New GroupBox()
        OptXZ = New RadioButton()
        OptXY = New RadioButton()
        Opt3D = New RadioButton()
        LblTheta = New Label()
        LblPhi = New Label()
        TxtTheta = New TextBox()
        TxtPhi = New TextBox()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbDSParameter, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbStepWidth, ComponentModel.ISupportInitialize).BeginInit()
        GrpStartPoint.SuspendLayout()
        GrpView.SuspendLayout()
        SuspendLayout()
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(6, 5)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(600, 600)
        PicDiagram.TabIndex = 0
        PicDiagram.TabStop = False
        ' 
        ' LblStrangeAttractor
        ' 
        LblStrangeAttractor.AutoSize = True
        LblStrangeAttractor.Font = New Font("Microsoft Sans Serif", 9F)
        LblStrangeAttractor.Location = New Point(613, 5)
        LblStrangeAttractor.Margin = New Padding(4, 0, 4, 0)
        LblStrangeAttractor.Name = "LblStrangeAttractor"
        LblStrangeAttractor.Size = New Size(94, 15)
        LblStrangeAttractor.TabIndex = 70
        LblStrangeAttractor.Text = "StrangeAttractor"
        ' 
        ' CboStrangeAttractor
        ' 
        CboStrangeAttractor.Font = New Font("Microsoft Sans Serif", 9F)
        CboStrangeAttractor.FormattingEnabled = True
        CboStrangeAttractor.Items.AddRange(New Object() {"DoublePendulum", "CombiPendulum", "ShakePendulum"})
        CboStrangeAttractor.Location = New Point(613, 22)
        CboStrangeAttractor.Margin = New Padding(4)
        CboStrangeAttractor.Name = "CboStrangeAttractor"
        CboStrangeAttractor.Size = New Size(219, 23)
        CboStrangeAttractor.TabIndex = 69
        ' 
        ' TxtDSParameter
        ' 
        TxtDSParameter.Enabled = False
        TxtDSParameter.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TxtDSParameter.Location = New Point(710, 237)
        TxtDSParameter.Name = "TxtDSParameter"
        TxtDSParameter.Size = New Size(121, 21)
        TxtDSParameter.TabIndex = 87
        ' 
        ' LblDSParameter
        ' 
        LblDSParameter.AutoSize = True
        LblDSParameter.Font = New Font("Microsoft Sans Serif", 9F)
        LblDSParameter.Location = New Point(613, 237)
        LblDSParameter.Margin = New Padding(4, 0, 4, 0)
        LblDSParameter.Name = "LblDSParameter"
        LblDSParameter.Size = New Size(82, 15)
        LblDSParameter.TabIndex = 86
        LblDSParameter.Text = "DSParameter"
        ' 
        ' TrbDSParameter
        ' 
        TrbDSParameter.Location = New Point(613, 263)
        TrbDSParameter.Margin = New Padding(4)
        TrbDSParameter.Maximum = 1000
        TrbDSParameter.Name = "TrbDSParameter"
        TrbDSParameter.Size = New Size(219, 45)
        TrbDSParameter.TabIndex = 85
        TrbDSParameter.Value = 1
        ' 
        ' TxtY
        ' 
        TxtY.Font = New Font("Microsoft Sans Serif", 9F)
        TxtY.Location = New Point(27, 46)
        TxtY.Margin = New Padding(4)
        TxtY.Name = "TxtY"
        TxtY.Size = New Size(185, 21)
        TxtY.TabIndex = 98
        ' 
        ' TxtX
        ' 
        TxtX.Font = New Font("Microsoft Sans Serif", 9F)
        TxtX.Location = New Point(27, 21)
        TxtX.Margin = New Padding(4)
        TxtX.Name = "TxtX"
        TxtX.Size = New Size(186, 21)
        TxtX.TabIndex = 96
        ' 
        ' TxtZ
        ' 
        TxtZ.Font = New Font("Microsoft Sans Serif", 9F)
        TxtZ.Location = New Point(27, 73)
        TxtZ.Margin = New Padding(4)
        TxtZ.Name = "TxtZ"
        TxtZ.Size = New Size(185, 21)
        TxtZ.TabIndex = 99
        ' 
        ' LblX
        ' 
        LblX.AutoSize = True
        LblX.Font = New Font("Microsoft Sans Serif", 9F)
        LblX.Location = New Point(4, 24)
        LblX.Margin = New Padding(4, 0, 4, 0)
        LblX.Name = "LblX"
        LblX.Size = New Size(15, 15)
        LblX.TabIndex = 100
        LblX.Text = "X"
        ' 
        ' LblY
        ' 
        LblY.AutoSize = True
        LblY.Font = New Font("Microsoft Sans Serif", 9F)
        LblY.Location = New Point(5, 49)
        LblY.Margin = New Padding(4, 0, 4, 0)
        LblY.Name = "LblY"
        LblY.Size = New Size(14, 15)
        LblY.TabIndex = 101
        LblY.Text = "Y"
        ' 
        ' LblZ
        ' 
        LblZ.AutoSize = True
        LblZ.Font = New Font("Microsoft Sans Serif", 9F)
        LblZ.Location = New Point(5, 76)
        LblZ.Margin = New Padding(4, 0, 4, 0)
        LblZ.Name = "LblZ"
        LblZ.Size = New Size(14, 15)
        LblZ.TabIndex = 102
        LblZ.Text = "Z"
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblSteps.Location = New Point(718, 487)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(14, 15)
        LblSteps.TabIndex = 111
        LblSteps.Text = "0"
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblNumberOfSteps.Location = New Point(613, 487)
        LblNumberOfSteps.Margin = New Padding(4, 0, 4, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(102, 15)
        LblNumberOfSteps.TabIndex = 110
        LblNumberOfSteps.Text = "Number of Steps:"
        ' 
        ' BtnStop
        ' 
        BtnStop.Enabled = False
        BtnStop.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStop.Location = New Point(727, 508)
        BtnStop.Margin = New Padding(4)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(105, 30)
        BtnStop.TabIndex = 109
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStart.Location = New Point(613, 508)
        BtnStart.Margin = New Padding(4)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(105, 30)
        BtnStart.TabIndex = 108
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(613, 541)
        BtnDefault.Margin = New Padding(6, 8, 6, 8)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(219, 30)
        BtnDefault.TabIndex = 114
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(613, 575)
        BtnReset.Margin = New Padding(6, 8, 6, 8)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(219, 30)
        BtnReset.TabIndex = 113
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' LblStepWidth
        ' 
        LblStepWidth.AutoSize = True
        LblStepWidth.Font = New Font("Microsoft Sans Serif", 9F)
        LblStepWidth.Location = New Point(617, 418)
        LblStepWidth.Margin = New Padding(4, 0, 4, 0)
        LblStepWidth.Name = "LblStepWidth"
        LblStepWidth.Size = New Size(86, 15)
        LblStepWidth.TabIndex = 116
        LblStepWidth.Text = "StepWidth: 0.1"
        ' 
        ' TrbStepWidth
        ' 
        TrbStepWidth.LargeChange = 1
        TrbStepWidth.Location = New Point(613, 439)
        TrbStepWidth.Maximum = 9
        TrbStepWidth.Minimum = 1
        TrbStepWidth.Name = "TrbStepWidth"
        TrbStepWidth.Size = New Size(219, 45)
        TrbStepWidth.TabIndex = 115
        TrbStepWidth.Value = 5
        ' 
        ' GrpStartPoint
        ' 
        GrpStartPoint.Controls.Add(TxtX)
        GrpStartPoint.Controls.Add(LblX)
        GrpStartPoint.Controls.Add(TxtY)
        GrpStartPoint.Controls.Add(LblY)
        GrpStartPoint.Controls.Add(TxtZ)
        GrpStartPoint.Controls.Add(LblZ)
        GrpStartPoint.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GrpStartPoint.Location = New Point(613, 92)
        GrpStartPoint.Name = "GrpStartPoint"
        GrpStartPoint.Size = New Size(219, 102)
        GrpStartPoint.TabIndex = 119
        GrpStartPoint.TabStop = False
        GrpStartPoint.Text = "StartPointCoordinates"
        ' 
        ' BtnTakeOverPointSet
        ' 
        BtnTakeOverPointSet.Font = New Font("Microsoft Sans Serif", 9F)
        BtnTakeOverPointSet.Location = New Point(613, 200)
        BtnTakeOverPointSet.Margin = New Padding(6, 8, 6, 8)
        BtnTakeOverPointSet.Name = "BtnTakeOverPointSet"
        BtnTakeOverPointSet.Size = New Size(220, 30)
        BtnTakeOverPointSet.TabIndex = 120
        BtnTakeOverPointSet.Text = "TakeOverPointSet"
        BtnTakeOverPointSet.UseVisualStyleBackColor = True
        ' 
        ' CboStartpointSets
        ' 
        CboStartpointSets.Font = New Font("Microsoft Sans Serif", 9F)
        CboStartpointSets.FormattingEnabled = True
        CboStartpointSets.Items.AddRange(New Object() {"DoublePendulum", "CombiPendulum", "ShakePendulum"})
        CboStartpointSets.Location = New Point(613, 66)
        CboStartpointSets.Margin = New Padding(4)
        CboStartpointSets.Name = "CboStartpointSets"
        CboStartpointSets.Size = New Size(219, 23)
        CboStartpointSets.TabIndex = 118
        ' 
        ' LblStartpointSets
        ' 
        LblStartpointSets.AutoSize = True
        LblStartpointSets.Font = New Font("Microsoft Sans Serif", 9F)
        LblStartpointSets.Location = New Point(613, 48)
        LblStartpointSets.Margin = New Padding(4, 0, 4, 0)
        LblStartpointSets.Name = "LblStartpointSets"
        LblStartpointSets.Size = New Size(83, 15)
        LblStartpointSets.TabIndex = 117
        LblStartpointSets.Text = "StartpointSets"
        ' 
        ' GrpView
        ' 
        GrpView.Controls.Add(OptXZ)
        GrpView.Controls.Add(OptXY)
        GrpView.Controls.Add(Opt3D)
        GrpView.Controls.Add(LblTheta)
        GrpView.Controls.Add(LblPhi)
        GrpView.Controls.Add(TxtTheta)
        GrpView.Controls.Add(TxtPhi)
        GrpView.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GrpView.Location = New Point(614, 315)
        GrpView.Name = "GrpView"
        GrpView.Size = New Size(219, 92)
        GrpView.TabIndex = 121
        GrpView.TabStop = False
        GrpView.Text = "View"
        ' 
        ' OptXZ
        ' 
        OptXZ.AutoSize = True
        OptXZ.Location = New Point(164, 27)
        OptXZ.Name = "OptXZ"
        OptXZ.Size = New Size(40, 19)
        OptXZ.TabIndex = 114
        OptXZ.Text = "XZ"
        OptXZ.UseVisualStyleBackColor = True
        ' 
        ' OptXY
        ' 
        OptXY.AutoSize = True
        OptXY.Location = New Point(96, 27)
        OptXY.Name = "OptXY"
        OptXY.Size = New Size(40, 19)
        OptXY.TabIndex = 113
        OptXY.Text = "XY"
        OptXY.UseVisualStyleBackColor = True
        ' 
        ' Opt3D
        ' 
        Opt3D.AutoSize = True
        Opt3D.Checked = True
        Opt3D.Location = New Point(16, 27)
        Opt3D.Name = "Opt3D"
        Opt3D.Size = New Size(41, 19)
        Opt3D.TabIndex = 112
        Opt3D.TabStop = True
        Opt3D.Text = "3D"
        Opt3D.UseVisualStyleBackColor = True
        ' 
        ' LblTheta
        ' 
        LblTheta.AutoSize = True
        LblTheta.Font = New Font("Microsoft Sans Serif", 9F)
        LblTheta.Location = New Point(98, 63)
        LblTheta.Margin = New Padding(4, 0, 4, 0)
        LblTheta.Name = "LblTheta"
        LblTheta.Size = New Size(38, 15)
        LblTheta.TabIndex = 111
        LblTheta.Text = "Theta"
        ' 
        ' LblPhi
        ' 
        LblPhi.AutoSize = True
        LblPhi.Font = New Font("Microsoft Sans Serif", 9F)
        LblPhi.Location = New Point(6, 63)
        LblPhi.Margin = New Padding(4, 0, 4, 0)
        LblPhi.Name = "LblPhi"
        LblPhi.Size = New Size(25, 15)
        LblPhi.TabIndex = 110
        LblPhi.Text = "Phi"
        ' 
        ' TxtTheta
        ' 
        TxtTheta.Enabled = False
        TxtTheta.Font = New Font("Microsoft Sans Serif", 9F)
        TxtTheta.Location = New Point(144, 60)
        TxtTheta.Margin = New Padding(4)
        TxtTheta.Name = "TxtTheta"
        TxtTheta.Size = New Size(60, 21)
        TxtTheta.TabIndex = 109
        TxtTheta.Text = "0"
        ' 
        ' TxtPhi
        ' 
        TxtPhi.Enabled = False
        TxtPhi.Font = New Font("Microsoft Sans Serif", 9F)
        TxtPhi.Location = New Point(36, 60)
        TxtPhi.Margin = New Padding(4)
        TxtPhi.Name = "TxtPhi"
        TxtPhi.Size = New Size(60, 21)
        TxtPhi.TabIndex = 108
        TxtPhi.Text = "0"
        ' 
        ' FrmStrangeAttractor
        ' 
        AutoScaleDimensions = New SizeF(9F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(838, 611)
        Controls.Add(GrpView)
        Controls.Add(BtnTakeOverPointSet)
        Controls.Add(GrpStartPoint)
        Controls.Add(CboStartpointSets)
        Controls.Add(LblStartpointSets)
        Controls.Add(LblStepWidth)
        Controls.Add(TrbStepWidth)
        Controls.Add(BtnDefault)
        Controls.Add(BtnReset)
        Controls.Add(LblSteps)
        Controls.Add(LblNumberOfSteps)
        Controls.Add(BtnStop)
        Controls.Add(BtnStart)
        Controls.Add(TxtDSParameter)
        Controls.Add(LblDSParameter)
        Controls.Add(TrbDSParameter)
        Controls.Add(LblStrangeAttractor)
        Controls.Add(CboStrangeAttractor)
        Controls.Add(PicDiagram)
        Font = New Font("Microsoft Sans Serif", 11.14F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4)
        Name = "FrmStrangeAttractor"
        Text = "StrangeAttractor"
        WindowState = FormWindowState.Maximized
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbDSParameter, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbStepWidth, ComponentModel.ISupportInitialize).EndInit()
        GrpStartPoint.ResumeLayout(False)
        GrpStartPoint.PerformLayout()
        GrpView.ResumeLayout(False)
        GrpView.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents LblStrangeAttractor As Label
    Friend WithEvents CboStrangeAttractor As ComboBox
    Friend WithEvents TxtDSParameter As TextBox
    Friend WithEvents LblDSParameter As Label
    Friend WithEvents TrbDSParameter As TrackBar
    Friend WithEvents TxtY As TextBox
    Friend WithEvents TxtX As TextBox
    Friend WithEvents TxtZ As TextBox
    Friend WithEvents LblX As Label
    Friend WithEvents LblY As Label
    Friend WithEvents LblZ As Label
    Friend WithEvents LblSteps As Label
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents BtnStop As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents BtnDefault As Button
    Friend WithEvents BtnReset As Button
    Friend WithEvents LblStepWidth As Label
    Friend WithEvents TrbStepWidth As TrackBar
    Friend WithEvents GrpStartPoint As GroupBox
    Friend WithEvents BtnTakeOverPointSet As Button
    Friend WithEvents CboStartpointSets As ComboBox
    Friend WithEvents LblStartpointSets As Label
    Friend WithEvents GrpView As GroupBox
    Friend WithEvents LblTheta As Label
    Friend WithEvents LblPhi As Label
    Friend WithEvents TxtTheta As TextBox
    Friend WithEvents TxtPhi As TextBox
    Friend WithEvents OptXZ As RadioButton
    Friend WithEvents OptXY As RadioButton
    Friend WithEvents Opt3D As RadioButton
End Class
