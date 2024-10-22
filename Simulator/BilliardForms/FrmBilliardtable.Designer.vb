<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBilliardtable
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBilliardtable))
        PicDiagram = New PictureBox()
        LblParameterc = New Label()
        BtnNextStep = New Button()
        BtnReset = New Button()
        BtnStart = New Button()
        PicPhasePortrait = New PictureBox()
        BtnNewBall = New Button()
        CboBallColor = New ComboBox()
        LblBallColor = New Label()
        TrbSpeed = New TrackBar()
        LblSpeed = New Label()
        LblColor = New Label()
        LblPhasePortrait = New Label()
        GrpStartParameter = New GroupBox()
        BtnTakeOverStartParameter = New Button()
        TxtAlfa = New TextBox()
        TxtT = New TextBox()
        LblAlfa = New Label()
        LblT = New Label()
        LstValueList = New ListBox()
        LblBilliardTable = New Label()
        CboBilliardTable = New ComboBox()
        LblNumberOfSteps = New Label()
        LblSteps = New Label()
        BtnPhasePortrait = New Button()
        BtnStop = New Button()
        TrbParameterC = New TrackBar()
        TxtParameter = New TextBox()
        BtnDefault = New Button()
        LblProtocol = New Label()
        ChkProtocol = New CheckBox()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicPhasePortrait, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbSpeed, ComponentModel.ISupportInitialize).BeginInit()
        GrpStartParameter.SuspendLayout()
        CType(TrbParameterC, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(6, 5)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(570, 570)
        PicDiagram.TabIndex = 3
        PicDiagram.TabStop = False
        ' 
        ' LblParameterc
        ' 
        LblParameterc.AutoSize = True
        LblParameterc.Font = New Font("Microsoft Sans Serif", 9F)
        LblParameterc.Location = New Point(579, 54)
        LblParameterc.Name = "LblParameterc"
        LblParameterc.Size = New Size(76, 15)
        LblParameterc.TabIndex = 9
        LblParameterc.Text = "Parameter C"
        ' 
        ' BtnNextStep
        ' 
        BtnNextStep.Font = New Font("Microsoft Sans Serif", 9F)
        BtnNextStep.Location = New Point(579, 400)
        BtnNextStep.Name = "BtnNextStep"
        BtnNextStep.Size = New Size(200, 25)
        BtnNextStep.TabIndex = 11
        BtnNextStep.Text = "NextStep"
        BtnNextStep.UseVisualStyleBackColor = True
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(579, 549)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(196, 25)
        BtnReset.TabIndex = 12
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStart.Location = New Point(579, 457)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(93, 26)
        BtnStart.TabIndex = 13
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' PicPhasePortrait
        ' 
        PicPhasePortrait.BackColor = Color.White
        PicPhasePortrait.Location = New Point(788, 23)
        PicPhasePortrait.Name = "PicPhasePortrait"
        PicPhasePortrait.Size = New Size(300, 300)
        PicPhasePortrait.TabIndex = 16
        PicPhasePortrait.TabStop = False
        ' 
        ' BtnNewBall
        ' 
        BtnNewBall.Font = New Font("Microsoft Sans Serif", 9F)
        BtnNewBall.Location = New Point(580, 169)
        BtnNewBall.Name = "BtnNewBall"
        BtnNewBall.Size = New Size(199, 25)
        BtnNewBall.TabIndex = 17
        BtnNewBall.Text = "NewBall"
        BtnNewBall.UseVisualStyleBackColor = True
        ' 
        ' CboBallColor
        ' 
        CboBallColor.BackColor = SystemColors.Window
        CboBallColor.Font = New Font("Microsoft Sans Serif", 9F)
        CboBallColor.FormattingEnabled = True
        CboBallColor.Items.AddRange(New Object() {"Red", "Green", "Blue", "Black", "Magenta"})
        CboBallColor.Location = New Point(582, 142)
        CboBallColor.Name = "CboBallColor"
        CboBallColor.Size = New Size(152, 23)
        CboBallColor.TabIndex = 18
        ' 
        ' LblBallColor
        ' 
        LblBallColor.AutoSize = True
        LblBallColor.Font = New Font("Microsoft Sans Serif", 9F)
        LblBallColor.Location = New Point(580, 125)
        LblBallColor.Name = "LblBallColor"
        LblBallColor.Size = New Size(57, 15)
        LblBallColor.TabIndex = 19
        LblBallColor.Text = "BallColor"
        ' 
        ' TrbSpeed
        ' 
        TrbSpeed.Location = New Point(580, 352)
        TrbSpeed.Maximum = 500
        TrbSpeed.Minimum = 1
        TrbSpeed.Name = "TrbSpeed"
        TrbSpeed.Size = New Size(203, 45)
        TrbSpeed.TabIndex = 20
        TrbSpeed.Value = 50
        ' 
        ' LblSpeed
        ' 
        LblSpeed.AutoSize = True
        LblSpeed.Font = New Font("Microsoft Sans Serif", 9F)
        LblSpeed.Location = New Point(580, 330)
        LblSpeed.Name = "LblSpeed"
        LblSpeed.Size = New Size(64, 15)
        LblSpeed.TabIndex = 21
        LblSpeed.Text = "BallSpeed"
        ' 
        ' LblColor
        ' 
        LblColor.BackColor = Color.Red
        LblColor.Location = New Point(740, 142)
        LblColor.Name = "LblColor"
        LblColor.Size = New Size(37, 22)
        LblColor.TabIndex = 22
        ' 
        ' LblPhasePortrait
        ' 
        LblPhasePortrait.AutoSize = True
        LblPhasePortrait.Location = New Point(787, 5)
        LblPhasePortrait.Name = "LblPhasePortrait"
        LblPhasePortrait.Size = New Size(81, 15)
        LblPhasePortrait.TabIndex = 23
        LblPhasePortrait.Text = "PhasePortrait"
        ' 
        ' GrpStartParameter
        ' 
        GrpStartParameter.Controls.Add(BtnTakeOverStartParameter)
        GrpStartParameter.Controls.Add(TxtAlfa)
        GrpStartParameter.Controls.Add(TxtT)
        GrpStartParameter.Controls.Add(LblAlfa)
        GrpStartParameter.Controls.Add(LblT)
        GrpStartParameter.Font = New Font("Microsoft Sans Serif", 9F)
        GrpStartParameter.Location = New Point(580, 202)
        GrpStartParameter.Name = "GrpStartParameter"
        GrpStartParameter.Size = New Size(203, 125)
        GrpStartParameter.TabIndex = 24
        GrpStartParameter.TabStop = False
        GrpStartParameter.Text = "StartParameter"
        ' 
        ' BtnTakeOverStartParameter
        ' 
        BtnTakeOverStartParameter.Location = New Point(0, 87)
        BtnTakeOverStartParameter.Name = "BtnTakeOverStartParameter"
        BtnTakeOverStartParameter.Size = New Size(196, 25)
        BtnTakeOverStartParameter.TabIndex = 4
        BtnTakeOverStartParameter.Text = "TakeOver"
        BtnTakeOverStartParameter.UseVisualStyleBackColor = True
        ' 
        ' TxtAlfa
        ' 
        TxtAlfa.Location = New Point(50, 54)
        TxtAlfa.Name = "TxtAlfa"
        TxtAlfa.Size = New Size(147, 21)
        TxtAlfa.TabIndex = 3
        ' 
        ' TxtT
        ' 
        TxtT.Location = New Point(50, 25)
        TxtT.Name = "TxtT"
        TxtT.Size = New Size(147, 21)
        TxtT.TabIndex = 2
        ' 
        ' LblAlfa
        ' 
        LblAlfa.AutoSize = True
        LblAlfa.Location = New Point(12, 55)
        LblAlfa.Name = "LblAlfa"
        LblAlfa.Size = New Size(27, 15)
        LblAlfa.TabIndex = 1
        LblAlfa.Text = "Alfa"
        ' 
        ' LblT
        ' 
        LblT.AutoSize = True
        LblT.Font = New Font("Microsoft Sans Serif", 9F)
        LblT.Location = New Point(25, 28)
        LblT.Name = "LblT"
        LblT.Size = New Size(10, 15)
        LblT.TabIndex = 0
        LblT.Text = "t"
        ' 
        ' LstValueList
        ' 
        LstValueList.Font = New Font("Microsoft Sans Serif", 9F)
        LstValueList.FormattingEnabled = True
        LstValueList.ItemHeight = 15
        LstValueList.Location = New Point(789, 352)
        LstValueList.Name = "LstValueList"
        LstValueList.Size = New Size(299, 214)
        LstValueList.TabIndex = 25
        ' 
        ' LblBilliardTable
        ' 
        LblBilliardTable.AutoSize = True
        LblBilliardTable.Font = New Font("Microsoft Sans Serif", 9F)
        LblBilliardTable.Location = New Point(581, 5)
        LblBilliardTable.Name = "LblBilliardTable"
        LblBilliardTable.Size = New Size(76, 15)
        LblBilliardTable.TabIndex = 26
        LblBilliardTable.Text = "BilliardTable"
        ' 
        ' CboBilliardTable
        ' 
        CboBilliardTable.Font = New Font("Microsoft Sans Serif", 9F)
        CboBilliardTable.FormattingEnabled = True
        CboBilliardTable.Items.AddRange(New Object() {"Elliptic", "Stadium", "Oval"})
        CboBilliardTable.Location = New Point(581, 23)
        CboBilliardTable.Name = "CboBilliardTable"
        CboBilliardTable.Size = New Size(202, 23)
        CboBilliardTable.TabIndex = 27
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblNumberOfSteps.Location = New Point(579, 436)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(95, 15)
        LblNumberOfSteps.TabIndex = 28
        LblNumberOfSteps.Text = "NumberOfSteps"
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblSteps.Location = New Point(675, 436)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(14, 15)
        LblSteps.TabIndex = 29
        LblSteps.Text = "0"
        ' 
        ' BtnPhasePortrait
        ' 
        BtnPhasePortrait.Font = New Font("Microsoft Sans Serif", 9F)
        BtnPhasePortrait.Location = New Point(581, 489)
        BtnPhasePortrait.Name = "BtnPhasePortrait"
        BtnPhasePortrait.Size = New Size(194, 26)
        BtnPhasePortrait.TabIndex = 30
        BtnPhasePortrait.Text = "FillPhasePortrait"
        BtnPhasePortrait.UseVisualStyleBackColor = True
        ' 
        ' BtnStop
        ' 
        BtnStop.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStop.Location = New Point(679, 457)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(93, 26)
        BtnStop.TabIndex = 52
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' TrbParameterC
        ' 
        TrbParameterC.LargeChange = 10
        TrbParameterC.Location = New Point(579, 80)
        TrbParameterC.Margin = New Padding(3, 2, 3, 2)
        TrbParameterC.Maximum = 300
        TrbParameterC.Minimum = 30
        TrbParameterC.Name = "TrbParameterC"
        TrbParameterC.Size = New Size(198, 45)
        TrbParameterC.TabIndex = 53
        TrbParameterC.Value = 80
        ' 
        ' TxtParameter
        ' 
        TxtParameter.Font = New Font("Microsoft Sans Serif", 9F)
        TxtParameter.Location = New Point(659, 54)
        TxtParameter.Margin = New Padding(5)
        TxtParameter.Name = "TxtParameter"
        TxtParameter.Size = New Size(121, 21)
        TxtParameter.TabIndex = 54
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(579, 519)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(196, 25)
        BtnDefault.TabIndex = 55
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' LblProtocol
        ' 
        LblProtocol.AutoSize = True
        LblProtocol.Font = New Font("Microsoft Sans Serif", 9F)
        LblProtocol.Location = New Point(789, 329)
        LblProtocol.Name = "LblProtocol"
        LblProtocol.Size = New Size(52, 15)
        LblProtocol.TabIndex = 56
        LblProtocol.Text = "Procotol"
        ' 
        ' ChkProtocol
        ' 
        ChkProtocol.AutoSize = True
        ChkProtocol.Location = New Point(1016, 327)
        ChkProtocol.Margin = New Padding(3, 2, 3, 2)
        ChkProtocol.Name = "ChkProtocol"
        ChkProtocol.Size = New Size(71, 19)
        ChkProtocol.TabIndex = 67
        ChkProtocol.Text = "Protocol"
        ChkProtocol.UseVisualStyleBackColor = True
        ' 
        ' FrmBilliardtable
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1095, 584)
        Controls.Add(ChkProtocol)
        Controls.Add(LblProtocol)
        Controls.Add(BtnDefault)
        Controls.Add(TxtParameter)
        Controls.Add(TrbParameterC)
        Controls.Add(BtnStop)
        Controls.Add(BtnPhasePortrait)
        Controls.Add(LblSteps)
        Controls.Add(LblNumberOfSteps)
        Controls.Add(CboBilliardTable)
        Controls.Add(LblBilliardTable)
        Controls.Add(LstValueList)
        Controls.Add(GrpStartParameter)
        Controls.Add(LblPhasePortrait)
        Controls.Add(LblColor)
        Controls.Add(LblSpeed)
        Controls.Add(TrbSpeed)
        Controls.Add(LblBallColor)
        Controls.Add(CboBallColor)
        Controls.Add(BtnNewBall)
        Controls.Add(PicPhasePortrait)
        Controls.Add(BtnStart)
        Controls.Add(BtnReset)
        Controls.Add(BtnNextStep)
        Controls.Add(LblParameterc)
        Controls.Add(PicDiagram)
        Font = New Font("Microsoft Sans Serif", 9F)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "FrmBilliardtable"
        Text = "Billiard"
        WindowState = FormWindowState.Maximized
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        CType(PicPhasePortrait, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbSpeed, ComponentModel.ISupportInitialize).EndInit()
        GrpStartParameter.ResumeLayout(False)
        GrpStartParameter.PerformLayout()
        CType(TrbParameterC, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents LblParameterc As Label
    Friend WithEvents BtnNextStep As Button
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents PicPhasePortrait As PictureBox
    Friend WithEvents BtnNewBall As Button
    Friend WithEvents CboBallColor As ComboBox
    Friend WithEvents LblBallColor As Label
    Friend WithEvents TrbSpeed As TrackBar
    Friend WithEvents LblSpeed As Label
    Friend WithEvents LblColor As Label
    Friend WithEvents LblPhasePortrait As Label
    Friend WithEvents GrpStartParameter As GroupBox
    Friend WithEvents BtnTakeOverStartParameter As Button
    Friend WithEvents TxtAlfa As TextBox
    Friend WithEvents TxtT As TextBox
    Friend WithEvents LblAlfa As Label
    Friend WithEvents LblT As Label
    Friend WithEvents LstValueList As ListBox
    Friend WithEvents LblBilliardTable As Label
    Friend WithEvents CboBilliardTable As ComboBox
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents LblSteps As Label
    Friend WithEvents BtnPhasePortrait As Button
    Friend WithEvents BtnStop As Button
    Friend WithEvents TrbParameterC As TrackBar
    Friend WithEvents TxtParameter As TextBox
    Friend WithEvents BtnDefault As Button
    Friend WithEvents LblProtocol As Label
    Friend WithEvents ChkProtocol As CheckBox
End Class
