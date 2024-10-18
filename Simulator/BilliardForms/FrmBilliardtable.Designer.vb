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
        PicDiagram.Location = New Point(13, 13)
        PicDiagram.Margin = New Padding(4, 5, 4, 5)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(1300, 1299)
        PicDiagram.TabIndex = 3
        PicDiagram.TabStop = False
        ' 
        ' LblParameterc
        ' 
        LblParameterc.AutoSize = True
        LblParameterc.Location = New Point(1328, 123)
        LblParameterc.Margin = New Padding(4, 0, 4, 0)
        LblParameterc.Name = "LblParameterc"
        LblParameterc.Size = New Size(155, 36)
        LblParameterc.TabIndex = 9
        LblParameterc.Text = "Parameter C"
        ' 
        ' BtnNextStep
        ' 
        BtnNextStep.Location = New Point(1329, 854)
        BtnNextStep.Margin = New Padding(4, 5, 4, 5)
        BtnNextStep.Name = "BtnNextStep"
        BtnNextStep.Size = New Size(425, 60)
        BtnNextStep.TabIndex = 11
        BtnNextStep.Text = "NextStep"
        BtnNextStep.UseVisualStyleBackColor = True
        ' 
        ' BtnReset
        ' 
        BtnReset.Location = New Point(1329, 1255)
        BtnReset.Margin = New Padding(4, 5, 4, 5)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(425, 60)
        BtnReset.TabIndex = 12
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Location = New Point(1328, 975)
        BtnStart.Margin = New Padding(4, 5, 4, 5)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(425, 60)
        BtnStart.TabIndex = 13
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' PicPhasePortrait
        ' 
        PicPhasePortrait.BackColor = Color.White
        PicPhasePortrait.Location = New Point(1779, 56)
        PicPhasePortrait.Margin = New Padding(4, 5, 4, 5)
        PicPhasePortrait.Name = "PicPhasePortrait"
        PicPhasePortrait.Size = New Size(900, 900)
        PicPhasePortrait.TabIndex = 16
        PicPhasePortrait.TabStop = False
        ' 
        ' BtnNewBall
        ' 
        BtnNewBall.Font = New Font("Segoe UI", 11F)
        BtnNewBall.Location = New Point(1328, 375)
        BtnNewBall.Margin = New Padding(4, 5, 4, 5)
        BtnNewBall.Name = "BtnNewBall"
        BtnNewBall.Size = New Size(428, 60)
        BtnNewBall.TabIndex = 17
        BtnNewBall.Text = "NewBall"
        BtnNewBall.UseVisualStyleBackColor = True
        ' 
        ' CboBallColor
        ' 
        CboBallColor.BackColor = SystemColors.Window
        CboBallColor.FormattingEnabled = True
        CboBallColor.Items.AddRange(New Object() {"Red", "Green", "Blue", "Black", "Magenta"})
        CboBallColor.Location = New Point(1332, 318)
        CboBallColor.Margin = New Padding(4, 5, 4, 5)
        CboBallColor.Name = "CboBallColor"
        CboBallColor.Size = New Size(340, 44)
        CboBallColor.TabIndex = 18
        ' 
        ' LblBallColor
        ' 
        LblBallColor.AutoSize = True
        LblBallColor.Location = New Point(1329, 275)
        LblBallColor.Margin = New Padding(4, 0, 4, 0)
        LblBallColor.Name = "LblBallColor"
        LblBallColor.Size = New Size(116, 36)
        LblBallColor.TabIndex = 19
        LblBallColor.Text = "BallColor"
        ' 
        ' TrbSpeed
        ' 
        TrbSpeed.Location = New Point(1326, 753)
        TrbSpeed.Margin = New Padding(4, 5, 4, 5)
        TrbSpeed.Maximum = 500
        TrbSpeed.Minimum = 1
        TrbSpeed.Name = "TrbSpeed"
        TrbSpeed.Size = New Size(424, 80)
        TrbSpeed.TabIndex = 20
        TrbSpeed.Value = 50
        ' 
        ' LblSpeed
        ' 
        LblSpeed.AutoSize = True
        LblSpeed.Location = New Point(1329, 711)
        LblSpeed.Margin = New Padding(4, 0, 4, 0)
        LblSpeed.Name = "LblSpeed"
        LblSpeed.Size = New Size(127, 36)
        LblSpeed.TabIndex = 21
        LblSpeed.Text = "BallSpeed"
        ' 
        ' LblColor
        ' 
        LblColor.BackColor = Color.Red
        LblColor.Location = New Point(1680, 318)
        LblColor.Margin = New Padding(4, 0, 4, 0)
        LblColor.Name = "LblColor"
        LblColor.Size = New Size(71, 44)
        LblColor.TabIndex = 22
        ' 
        ' LblPhasePortrait
        ' 
        LblPhasePortrait.AutoSize = True
        LblPhasePortrait.Location = New Point(1779, 9)
        LblPhasePortrait.Margin = New Padding(4, 0, 4, 0)
        LblPhasePortrait.Name = "LblPhasePortrait"
        LblPhasePortrait.Size = New Size(167, 36)
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
        GrpStartParameter.Location = New Point(1332, 454)
        GrpStartParameter.Margin = New Padding(4, 5, 4, 5)
        GrpStartParameter.Name = "GrpStartParameter"
        GrpStartParameter.Padding = New Padding(4, 5, 4, 5)
        GrpStartParameter.Size = New Size(424, 252)
        GrpStartParameter.TabIndex = 24
        GrpStartParameter.TabStop = False
        GrpStartParameter.Text = "StartParameter"
        ' 
        ' BtnTakeOverStartParameter
        ' 
        BtnTakeOverStartParameter.Location = New Point(14, 180)
        BtnTakeOverStartParameter.Margin = New Padding(4, 5, 4, 5)
        BtnTakeOverStartParameter.Name = "BtnTakeOverStartParameter"
        BtnTakeOverStartParameter.Size = New Size(396, 60)
        BtnTakeOverStartParameter.TabIndex = 4
        BtnTakeOverStartParameter.Text = "TakeOver"
        BtnTakeOverStartParameter.UseVisualStyleBackColor = True
        ' 
        ' TxtAlfa
        ' 
        TxtAlfa.Location = New Point(98, 128)
        TxtAlfa.Margin = New Padding(4, 5, 4, 5)
        TxtAlfa.Name = "TxtAlfa"
        TxtAlfa.Size = New Size(242, 42)
        TxtAlfa.TabIndex = 3
        ' 
        ' TxtT
        ' 
        TxtT.Location = New Point(98, 64)
        TxtT.Margin = New Padding(4, 5, 4, 5)
        TxtT.Name = "TxtT"
        TxtT.Size = New Size(242, 42)
        TxtT.TabIndex = 2
        ' 
        ' LblAlfa
        ' 
        LblAlfa.AutoSize = True
        LblAlfa.Location = New Point(14, 132)
        LblAlfa.Margin = New Padding(4, 0, 4, 0)
        LblAlfa.Name = "LblAlfa"
        LblAlfa.Size = New Size(59, 36)
        LblAlfa.TabIndex = 1
        LblAlfa.Text = "Alfa"
        ' 
        ' LblT
        ' 
        LblT.AutoSize = True
        LblT.Location = New Point(14, 70)
        LblT.Margin = New Padding(4, 0, 4, 0)
        LblT.Name = "LblT"
        LblT.Size = New Size(24, 36)
        LblT.TabIndex = 0
        LblT.Text = "t"
        ' 
        ' LstValueList
        ' 
        LstValueList.FormattingEnabled = True
        LstValueList.ItemHeight = 36
        LstValueList.Location = New Point(1779, 1013)
        LstValueList.Margin = New Padding(4, 5, 4, 5)
        LstValueList.Name = "LstValueList"
        LstValueList.Size = New Size(900, 292)
        LstValueList.TabIndex = 25
        ' 
        ' LblBilliardTable
        ' 
        LblBilliardTable.AutoSize = True
        LblBilliardTable.Font = New Font("Segoe UI", 11F)
        LblBilliardTable.Location = New Point(1328, 13)
        LblBilliardTable.Margin = New Padding(4, 0, 4, 0)
        LblBilliardTable.Name = "LblBilliardTable"
        LblBilliardTable.Size = New Size(150, 36)
        LblBilliardTable.TabIndex = 26
        LblBilliardTable.Text = "BilliardTable"
        ' 
        ' CboBilliardTable
        ' 
        CboBilliardTable.FormattingEnabled = True
        CboBilliardTable.Items.AddRange(New Object() {"Elliptic", "Stadium", "Oval"})
        CboBilliardTable.Location = New Point(1332, 53)
        CboBilliardTable.Margin = New Padding(4, 5, 4, 5)
        CboBilliardTable.Name = "CboBilliardTable"
        CboBilliardTable.Size = New Size(424, 44)
        CboBilliardTable.TabIndex = 27
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Location = New Point(1332, 919)
        LblNumberOfSteps.Margin = New Padding(4, 0, 4, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(199, 36)
        LblNumberOfSteps.TabIndex = 28
        LblNumberOfSteps.Text = "NumberOfSteps"
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Location = New Point(1556, 919)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(29, 36)
        LblSteps.TabIndex = 29
        LblSteps.Text = "0"
        ' 
        ' BtnPhasePortrait
        ' 
        BtnPhasePortrait.Location = New Point(1328, 1115)
        BtnPhasePortrait.Margin = New Padding(4, 5, 4, 5)
        BtnPhasePortrait.Name = "BtnPhasePortrait"
        BtnPhasePortrait.Size = New Size(425, 60)
        BtnPhasePortrait.TabIndex = 30
        BtnPhasePortrait.Text = "FillPhasePortrait"
        BtnPhasePortrait.UseVisualStyleBackColor = True
        ' 
        ' BtnStop
        ' 
        BtnStop.Location = New Point(1326, 1045)
        BtnStop.Margin = New Padding(4, 5, 4, 5)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(425, 60)
        BtnStop.TabIndex = 52
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' TrbParameterC
        ' 
        TrbParameterC.LargeChange = 10
        TrbParameterC.Location = New Point(1332, 183)
        TrbParameterC.Margin = New Padding(4, 2, 4, 2)
        TrbParameterC.Maximum = 300
        TrbParameterC.Minimum = 30
        TrbParameterC.Name = "TrbParameterC"
        TrbParameterC.Size = New Size(418, 80)
        TrbParameterC.TabIndex = 53
        TrbParameterC.Value = 80
        ' 
        ' TxtParameter
        ' 
        TxtParameter.Location = New Point(1499, 117)
        TxtParameter.Margin = New Padding(6, 7, 6, 7)
        TxtParameter.Name = "TxtParameter"
        TxtParameter.Size = New Size(254, 42)
        TxtParameter.TabIndex = 54
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Location = New Point(1329, 1185)
        BtnDefault.Margin = New Padding(4, 5, 4, 5)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(425, 60)
        BtnDefault.TabIndex = 55
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' LblProtocol
        ' 
        LblProtocol.AutoSize = True
        LblProtocol.Location = New Point(1779, 965)
        LblProtocol.Margin = New Padding(4, 0, 4, 0)
        LblProtocol.Name = "LblProtocol"
        LblProtocol.Size = New Size(111, 36)
        LblProtocol.TabIndex = 56
        LblProtocol.Text = "Procotol"
        ' 
        ' ChkProtocol
        ' 
        ChkProtocol.AutoSize = True
        ChkProtocol.Location = New Point(2536, 963)
        ChkProtocol.Margin = New Padding(4, 2, 4, 2)
        ChkProtocol.Name = "ChkProtocol"
        ChkProtocol.Size = New Size(137, 40)
        ChkProtocol.TabIndex = 67
        ChkProtocol.Text = "Protocol"
        ChkProtocol.UseVisualStyleBackColor = True
        ' 
        ' FrmBilliardtable
        ' 
        AutoScaleDimensions = New SizeF(14F, 36F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(2706, 1335)
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
        Font = New Font("Segoe UI", 11F)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4, 5, 4, 5)
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
