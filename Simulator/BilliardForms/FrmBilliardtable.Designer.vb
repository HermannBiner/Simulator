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
        PicDiagram.Location = New Point(8, 6)
        PicDiagram.Margin = New Padding(4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(600, 600)
        PicDiagram.TabIndex = 3
        PicDiagram.TabStop = False
        ' 
        ' LblParameterc
        ' 
        LblParameterc.AutoSize = True
        LblParameterc.Font = New Font("Microsoft Sans Serif", 9F)
        LblParameterc.Location = New Point(616, 52)
        LblParameterc.Margin = New Padding(4, 0, 4, 0)
        LblParameterc.Name = "LblParameterc"
        LblParameterc.Size = New Size(76, 15)
        LblParameterc.TabIndex = 9
        LblParameterc.Text = "Parameter C"
        ' 
        ' BtnNextStep
        ' 
        BtnNextStep.Font = New Font("Microsoft Sans Serif", 9F)
        BtnNextStep.Location = New Point(616, 395)
        BtnNextStep.Margin = New Padding(4)
        BtnNextStep.Name = "BtnNextStep"
        BtnNextStep.Size = New Size(210, 30)
        BtnNextStep.TabIndex = 11
        BtnNextStep.Text = "NextStep"
        BtnNextStep.UseVisualStyleBackColor = True
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(616, 576)
        BtnReset.Margin = New Padding(4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(210, 30)
        BtnReset.TabIndex = 12
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStart.Location = New Point(616, 460)
        BtnStart.Margin = New Padding(4)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(100, 31)
        BtnStart.TabIndex = 13
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' PicPhasePortrait
        ' 
        PicPhasePortrait.BackColor = Color.White
        PicPhasePortrait.Location = New Point(838, 25)
        PicPhasePortrait.Margin = New Padding(4)
        PicPhasePortrait.Name = "PicPhasePortrait"
        PicPhasePortrait.Size = New Size(320, 320)
        PicPhasePortrait.TabIndex = 16
        PicPhasePortrait.TabStop = False
        ' 
        ' BtnNewBall
        ' 
        BtnNewBall.Font = New Font("Microsoft Sans Serif", 9F)
        BtnNewBall.Location = New Point(616, 172)
        BtnNewBall.Margin = New Padding(4)
        BtnNewBall.Name = "BtnNewBall"
        BtnNewBall.Size = New Size(210, 30)
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
        CboBallColor.Location = New Point(616, 142)
        CboBallColor.Margin = New Padding(4)
        CboBallColor.Name = "CboBallColor"
        CboBallColor.Size = New Size(156, 23)
        CboBallColor.TabIndex = 18
        ' 
        ' LblBallColor
        ' 
        LblBallColor.AutoSize = True
        LblBallColor.Font = New Font("Microsoft Sans Serif", 9F)
        LblBallColor.Location = New Point(616, 123)
        LblBallColor.Margin = New Padding(4, 0, 4, 0)
        LblBallColor.Name = "LblBallColor"
        LblBallColor.Size = New Size(57, 15)
        LblBallColor.TabIndex = 19
        LblBallColor.Text = "BallColor"
        ' 
        ' TrbSpeed
        ' 
        TrbSpeed.Location = New Point(616, 343)
        TrbSpeed.Margin = New Padding(4)
        TrbSpeed.Maximum = 500
        TrbSpeed.Minimum = 1
        TrbSpeed.Name = "TrbSpeed"
        TrbSpeed.Size = New Size(210, 45)
        TrbSpeed.TabIndex = 20
        TrbSpeed.Value = 50
        ' 
        ' LblSpeed
        ' 
        LblSpeed.AutoSize = True
        LblSpeed.Font = New Font("Microsoft Sans Serif", 9F)
        LblSpeed.Location = New Point(616, 322)
        LblSpeed.Margin = New Padding(4, 0, 4, 0)
        LblSpeed.Name = "LblSpeed"
        LblSpeed.Size = New Size(64, 15)
        LblSpeed.TabIndex = 21
        LblSpeed.Text = "BallSpeed"
        ' 
        ' LblColor
        ' 
        LblColor.BackColor = Color.Red
        LblColor.Location = New Point(778, 139)
        LblColor.Margin = New Padding(4, 0, 4, 0)
        LblColor.Name = "LblColor"
        LblColor.Size = New Size(48, 26)
        LblColor.TabIndex = 22
        ' 
        ' LblPhasePortrait
        ' 
        LblPhasePortrait.AutoSize = True
        LblPhasePortrait.Font = New Font("Microsoft Sans Serif", 9F)
        LblPhasePortrait.Location = New Point(838, 6)
        LblPhasePortrait.Margin = New Padding(4, 0, 4, 0)
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
        GrpStartParameter.Location = New Point(616, 207)
        GrpStartParameter.Margin = New Padding(4)
        GrpStartParameter.Name = "GrpStartParameter"
        GrpStartParameter.Padding = New Padding(4)
        GrpStartParameter.Size = New Size(210, 109)
        GrpStartParameter.TabIndex = 24
        GrpStartParameter.TabStop = False
        GrpStartParameter.Text = "StartParameter"
        ' 
        ' BtnTakeOverStartParameter
        ' 
        BtnTakeOverStartParameter.Location = New Point(8, 70)
        BtnTakeOverStartParameter.Margin = New Padding(4)
        BtnTakeOverStartParameter.Name = "BtnTakeOverStartParameter"
        BtnTakeOverStartParameter.Size = New Size(186, 30)
        BtnTakeOverStartParameter.TabIndex = 4
        BtnTakeOverStartParameter.Text = "TakeOver"
        BtnTakeOverStartParameter.UseVisualStyleBackColor = True
        ' 
        ' TxtAlfa
        ' 
        TxtAlfa.Location = New Point(43, 43)
        TxtAlfa.Margin = New Padding(4)
        TxtAlfa.Name = "TxtAlfa"
        TxtAlfa.Size = New Size(151, 21)
        TxtAlfa.TabIndex = 3
        ' 
        ' TxtT
        ' 
        TxtT.Location = New Point(44, 18)
        TxtT.Margin = New Padding(4)
        TxtT.Name = "TxtT"
        TxtT.Size = New Size(150, 21)
        TxtT.TabIndex = 2
        ' 
        ' LblAlfa
        ' 
        LblAlfa.AutoSize = True
        LblAlfa.Location = New Point(8, 43)
        LblAlfa.Margin = New Padding(4, 0, 4, 0)
        LblAlfa.Name = "LblAlfa"
        LblAlfa.Size = New Size(27, 15)
        LblAlfa.TabIndex = 1
        LblAlfa.Text = "Alfa"
        ' 
        ' LblT
        ' 
        LblT.AutoSize = True
        LblT.Font = New Font("Microsoft Sans Serif", 9F)
        LblT.Location = New Point(15, 18)
        LblT.Margin = New Padding(4, 0, 4, 0)
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
        LstValueList.Location = New Point(838, 376)
        LstValueList.Margin = New Padding(4)
        LstValueList.Name = "LstValueList"
        LstValueList.Size = New Size(320, 229)
        LstValueList.TabIndex = 25
        ' 
        ' LblBilliardTable
        ' 
        LblBilliardTable.AutoSize = True
        LblBilliardTable.Font = New Font("Microsoft Sans Serif", 9F)
        LblBilliardTable.Location = New Point(616, 6)
        LblBilliardTable.Margin = New Padding(4, 0, 4, 0)
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
        CboBilliardTable.Location = New Point(616, 24)
        CboBilliardTable.Margin = New Padding(4)
        CboBilliardTable.Name = "CboBilliardTable"
        CboBilliardTable.Size = New Size(210, 23)
        CboBilliardTable.TabIndex = 27
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblNumberOfSteps.Location = New Point(616, 432)
        LblNumberOfSteps.Margin = New Padding(4, 0, 4, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(95, 15)
        LblNumberOfSteps.TabIndex = 28
        LblNumberOfSteps.Text = "NumberOfSteps"
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblSteps.Location = New Point(719, 432)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(14, 15)
        LblSteps.TabIndex = 29
        LblSteps.Text = "0"
        ' 
        ' BtnPhasePortrait
        ' 
        BtnPhasePortrait.Font = New Font("Microsoft Sans Serif", 9F)
        BtnPhasePortrait.Location = New Point(616, 499)
        BtnPhasePortrait.Margin = New Padding(4)
        BtnPhasePortrait.Name = "BtnPhasePortrait"
        BtnPhasePortrait.Size = New Size(210, 31)
        BtnPhasePortrait.TabIndex = 30
        BtnPhasePortrait.Text = "FillPhasePortrait"
        BtnPhasePortrait.UseVisualStyleBackColor = True
        ' 
        ' BtnStop
        ' 
        BtnStop.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStop.Location = New Point(726, 460)
        BtnStop.Margin = New Padding(4)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(100, 31)
        BtnStop.TabIndex = 52
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' TrbParameterC
        ' 
        TrbParameterC.LargeChange = 10
        TrbParameterC.Location = New Point(616, 76)
        TrbParameterC.Margin = New Padding(4, 2, 4, 2)
        TrbParameterC.Maximum = 300
        TrbParameterC.Minimum = 30
        TrbParameterC.Name = "TrbParameterC"
        TrbParameterC.Size = New Size(210, 45)
        TrbParameterC.TabIndex = 53
        TrbParameterC.Value = 80
        ' 
        ' TxtParameter
        ' 
        TxtParameter.Font = New Font("Microsoft Sans Serif", 9F)
        TxtParameter.Location = New Point(702, 49)
        TxtParameter.Margin = New Padding(6)
        TxtParameter.Name = "TxtParameter"
        TxtParameter.Size = New Size(124, 21)
        TxtParameter.TabIndex = 54
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(616, 538)
        BtnDefault.Margin = New Padding(4)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(210, 30)
        BtnDefault.TabIndex = 55
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' LblProtocol
        ' 
        LblProtocol.AutoSize = True
        LblProtocol.Font = New Font("Microsoft Sans Serif", 9F)
        LblProtocol.Location = New Point(838, 349)
        LblProtocol.Margin = New Padding(4, 0, 4, 0)
        LblProtocol.Name = "LblProtocol"
        LblProtocol.Size = New Size(52, 15)
        LblProtocol.TabIndex = 56
        LblProtocol.Text = "Procotol"
        ' 
        ' ChkProtocol
        ' 
        ChkProtocol.AutoSize = True
        ChkProtocol.Font = New Font("Microsoft Sans Serif", 9F)
        ChkProtocol.Location = New Point(1087, 351)
        ChkProtocol.Margin = New Padding(4, 2, 4, 2)
        ChkProtocol.Name = "ChkProtocol"
        ChkProtocol.Size = New Size(71, 19)
        ChkProtocol.TabIndex = 67
        ChkProtocol.Text = "Protocol"
        ChkProtocol.UseVisualStyleBackColor = True
        ' 
        ' FrmBilliardtable
        ' 
        AutoScaleDimensions = New SizeF(9F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1166, 614)
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
        Font = New Font("Microsoft Sans Serif", 11.14F)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4)
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
