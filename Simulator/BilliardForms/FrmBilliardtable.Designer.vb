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
        PicDiagram.Location = New Point(0, 2)
        PicDiagram.Margin = New Padding(4, 4, 4, 4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(1300, 1493)
        PicDiagram.TabIndex = 3
        PicDiagram.TabStop = False
        ' 
        ' LblParameterc
        ' 
        LblParameterc.AutoSize = True
        LblParameterc.Location = New Point(1317, 115)
        LblParameterc.Margin = New Padding(4, 0, 4, 0)
        LblParameterc.Name = "LblParameterc"
        LblParameterc.Size = New Size(143, 32)
        LblParameterc.TabIndex = 9
        LblParameterc.Text = "Parameter C"
        ' 
        ' BtnNextStep
        ' 
        BtnNextStep.Location = New Point(1309, 932)
        BtnNextStep.Margin = New Padding(4, 4, 4, 4)
        BtnNextStep.Name = "BtnNextStep"
        BtnNextStep.Size = New Size(394, 73)
        BtnNextStep.TabIndex = 11
        BtnNextStep.Text = "NextStep"
        BtnNextStep.UseVisualStyleBackColor = True
        ' 
        ' BtnReset
        ' 
        BtnReset.Location = New Point(1307, 1414)
        BtnReset.Margin = New Padding(4, 4, 4, 4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(394, 73)
        BtnReset.TabIndex = 12
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Location = New Point(1307, 1084)
        BtnStart.Margin = New Padding(4, 4, 4, 4)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(394, 73)
        BtnStart.TabIndex = 13
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' PicPhasePortrait
        ' 
        PicPhasePortrait.BackColor = Color.White
        PicPhasePortrait.Location = New Point(1718, 49)
        PicPhasePortrait.Margin = New Padding(4, 4, 4, 4)
        PicPhasePortrait.Name = "PicPhasePortrait"
        PicPhasePortrait.Size = New Size(929, 1067)
        PicPhasePortrait.TabIndex = 16
        PicPhasePortrait.TabStop = False
        ' 
        ' BtnNewBall
        ' 
        BtnNewBall.Location = New Point(1317, 380)
        BtnNewBall.Margin = New Padding(4, 4, 4, 4)
        BtnNewBall.Name = "BtnNewBall"
        BtnNewBall.Size = New Size(394, 73)
        BtnNewBall.TabIndex = 17
        BtnNewBall.Text = "NewBall"
        BtnNewBall.UseVisualStyleBackColor = True
        ' 
        ' CboBallColor
        ' 
        CboBallColor.BackColor = SystemColors.Window
        CboBallColor.FormattingEnabled = True
        CboBallColor.Items.AddRange(New Object() {"Red", "Green", "Blue", "Black", "Magenta"})
        CboBallColor.Location = New Point(1317, 322)
        CboBallColor.Margin = New Padding(4, 4, 4, 4)
        CboBallColor.Name = "CboBallColor"
        CboBallColor.Size = New Size(316, 40)
        CboBallColor.TabIndex = 18
        ' 
        ' LblBallColor
        ' 
        LblBallColor.AutoSize = True
        LblBallColor.Location = New Point(1317, 286)
        LblBallColor.Margin = New Padding(4, 0, 4, 0)
        LblBallColor.Name = "LblBallColor"
        LblBallColor.Size = New Size(109, 32)
        LblBallColor.TabIndex = 19
        LblBallColor.Text = "BallColor"
        ' 
        ' TrbSpeed
        ' 
        TrbSpeed.Location = New Point(1317, 828)
        TrbSpeed.Margin = New Padding(4, 4, 4, 4)
        TrbSpeed.Maximum = 500
        TrbSpeed.Minimum = 1
        TrbSpeed.Name = "TrbSpeed"
        TrbSpeed.Size = New Size(394, 90)
        TrbSpeed.TabIndex = 20
        TrbSpeed.Value = 50
        ' 
        ' LblSpeed
        ' 
        LblSpeed.AutoSize = True
        LblSpeed.Location = New Point(1319, 785)
        LblSpeed.Margin = New Padding(4, 0, 4, 0)
        LblSpeed.Name = "LblSpeed"
        LblSpeed.Size = New Size(119, 32)
        LblSpeed.TabIndex = 21
        LblSpeed.Text = "BallSpeed"
        ' 
        ' LblColor
        ' 
        LblColor.BackColor = Color.Red
        LblColor.Location = New Point(1642, 322)
        LblColor.Margin = New Padding(4, 0, 4, 0)
        LblColor.Name = "LblColor"
        LblColor.Size = New Size(69, 45)
        LblColor.TabIndex = 22
        ' 
        ' LblPhasePortrait
        ' 
        LblPhasePortrait.AutoSize = True
        LblPhasePortrait.Location = New Point(1718, 13)
        LblPhasePortrait.Margin = New Padding(4, 0, 4, 0)
        LblPhasePortrait.Name = "LblPhasePortrait"
        LblPhasePortrait.Size = New Size(152, 32)
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
        GrpStartParameter.Location = New Point(1317, 489)
        GrpStartParameter.Margin = New Padding(4, 4, 4, 4)
        GrpStartParameter.Name = "GrpStartParameter"
        GrpStartParameter.Padding = New Padding(4, 4, 4, 4)
        GrpStartParameter.Size = New Size(394, 269)
        GrpStartParameter.TabIndex = 24
        GrpStartParameter.TabStop = False
        GrpStartParameter.Text = "StartParameter"
        ' 
        ' BtnTakeOverStartParameter
        ' 
        BtnTakeOverStartParameter.Location = New Point(17, 179)
        BtnTakeOverStartParameter.Margin = New Padding(4, 4, 4, 4)
        BtnTakeOverStartParameter.Name = "BtnTakeOverStartParameter"
        BtnTakeOverStartParameter.Size = New Size(368, 73)
        BtnTakeOverStartParameter.TabIndex = 4
        BtnTakeOverStartParameter.Text = "TakeOver"
        BtnTakeOverStartParameter.UseVisualStyleBackColor = True
        ' 
        ' TxtAlfa
        ' 
        TxtAlfa.Location = New Point(91, 113)
        TxtAlfa.Margin = New Padding(4, 4, 4, 4)
        TxtAlfa.Name = "TxtAlfa"
        TxtAlfa.Size = New Size(225, 39)
        TxtAlfa.TabIndex = 3
        ' 
        ' TxtT
        ' 
        TxtT.Location = New Point(91, 51)
        TxtT.Margin = New Padding(4, 4, 4, 4)
        TxtT.Name = "TxtT"
        TxtT.Size = New Size(225, 39)
        TxtT.TabIndex = 2
        ' 
        ' LblAlfa
        ' 
        LblAlfa.AutoSize = True
        LblAlfa.Location = New Point(13, 119)
        LblAlfa.Margin = New Padding(4, 0, 4, 0)
        LblAlfa.Name = "LblAlfa"
        LblAlfa.Size = New Size(55, 32)
        LblAlfa.TabIndex = 1
        LblAlfa.Text = "Alfa"
        ' 
        ' LblT
        ' 
        LblT.AutoSize = True
        LblT.Location = New Point(13, 62)
        LblT.Margin = New Padding(4, 0, 4, 0)
        LblT.Name = "LblT"
        LblT.Size = New Size(22, 32)
        LblT.TabIndex = 0
        LblT.Text = "t"
        ' 
        ' LstValueList
        ' 
        LstValueList.FormattingEnabled = True
        LstValueList.Location = New Point(1718, 1190)
        LstValueList.Margin = New Padding(4, 4, 4, 4)
        LstValueList.Name = "LstValueList"
        LstValueList.Size = New Size(925, 292)
        LstValueList.TabIndex = 25
        ' 
        ' LblBilliardTable
        ' 
        LblBilliardTable.AutoSize = True
        LblBilliardTable.Location = New Point(1313, 13)
        LblBilliardTable.Margin = New Padding(4, 0, 4, 0)
        LblBilliardTable.Name = "LblBilliardTable"
        LblBilliardTable.Size = New Size(141, 32)
        LblBilliardTable.TabIndex = 26
        LblBilliardTable.Text = "BilliardTable"
        ' 
        ' CboBilliardTable
        ' 
        CboBilliardTable.FormattingEnabled = True
        CboBilliardTable.Items.AddRange(New Object() {"Elliptic", "Stadium", "Oval"})
        CboBilliardTable.Location = New Point(1317, 49)
        CboBilliardTable.Margin = New Padding(4, 4, 4, 4)
        CboBilliardTable.Name = "CboBilliardTable"
        CboBilliardTable.Size = New Size(394, 40)
        CboBilliardTable.TabIndex = 27
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Location = New Point(1309, 1030)
        LblNumberOfSteps.Margin = New Padding(4, 0, 4, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(185, 32)
        LblNumberOfSteps.TabIndex = 28
        LblNumberOfSteps.Text = "NumberOfSteps"
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Location = New Point(1517, 1030)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(27, 32)
        LblSteps.TabIndex = 29
        LblSteps.Text = "0"
        ' 
        ' BtnPhasePortrait
        ' 
        BtnPhasePortrait.Location = New Point(1307, 1252)
        BtnPhasePortrait.Margin = New Padding(4, 4, 4, 4)
        BtnPhasePortrait.Name = "BtnPhasePortrait"
        BtnPhasePortrait.Size = New Size(394, 73)
        BtnPhasePortrait.TabIndex = 30
        BtnPhasePortrait.Text = "FillPhasePortrait"
        BtnPhasePortrait.UseVisualStyleBackColor = True
        ' 
        ' BtnStop
        ' 
        BtnStop.Location = New Point(1307, 1165)
        BtnStop.Margin = New Padding(4, 4, 4, 4)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(394, 73)
        BtnStop.TabIndex = 52
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' TrbParameterC
        ' 
        TrbParameterC.LargeChange = 10
        TrbParameterC.Location = New Point(1319, 166)
        TrbParameterC.Margin = New Padding(4, 2, 4, 2)
        TrbParameterC.Maximum = 300
        TrbParameterC.Minimum = 30
        TrbParameterC.Name = "TrbParameterC"
        TrbParameterC.Size = New Size(392, 90)
        TrbParameterC.TabIndex = 53
        TrbParameterC.Value = 80
        ' 
        ' TxtParameter
        ' 
        TxtParameter.Location = New Point(1462, 109)
        TxtParameter.Margin = New Padding(6, 6, 6, 6)
        TxtParameter.Name = "TxtParameter"
        TxtParameter.Size = New Size(249, 39)
        TxtParameter.TabIndex = 54
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Location = New Point(1307, 1333)
        BtnDefault.Margin = New Padding(4, 4, 4, 4)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(394, 73)
        BtnDefault.TabIndex = 55
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' LblProtocol
        ' 
        LblProtocol.AutoSize = True
        LblProtocol.Location = New Point(1709, 1139)
        LblProtocol.Margin = New Padding(4, 0, 4, 0)
        LblProtocol.Name = "LblProtocol"
        LblProtocol.Size = New Size(102, 32)
        LblProtocol.TabIndex = 56
        LblProtocol.Text = "Procotol"
        ' 
        ' ChkProtocol
        ' 
        ChkProtocol.AutoSize = True
        ChkProtocol.Location = New Point(2509, 1135)
        ChkProtocol.Margin = New Padding(4, 2, 4, 2)
        ChkProtocol.Name = "ChkProtocol"
        ChkProtocol.Size = New Size(134, 36)
        ChkProtocol.TabIndex = 67
        ChkProtocol.Text = "Protocol"
        ChkProtocol.UseVisualStyleBackColor = True
        ' 
        ' FrmBilliardtable
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(2656, 1495)
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
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4, 4, 4, 4)
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
