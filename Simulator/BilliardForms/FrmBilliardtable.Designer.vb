<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBilliardTable
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBilliardtable))
        SplitContainer1 = New SplitContainer()
        PicDiagram = New PictureBox()
        SplitContainer2 = New SplitContainer()
        BtnDefault = New Button()
        TxtParameter = New TextBox()
        TrbParameterC = New TrackBar()
        BtnStop = New Button()
        BtnPhasePortrait = New Button()
        LblSteps = New Label()
        LblNumberOfSteps = New Label()
        CboBilliardTable = New ComboBox()
        LblBilliardTable = New Label()
        GrpStartParameter = New GroupBox()
        BtnTakeOverStartParameter = New Button()
        TxtAlfa = New TextBox()
        TxtT = New TextBox()
        LblAlfa = New Label()
        LblT = New Label()
        LblColor = New Label()
        LblSpeed = New Label()
        TrbSpeed = New TrackBar()
        LblBallColor = New Label()
        CboBallColor = New ComboBox()
        BtnNewBall = New Button()
        BtnStart = New Button()
        BtnReset = New Button()
        BtnNextStep = New Button()
        LblParameterc = New Label()
        ChkProtocol = New CheckBox()
        LblProtocol = New Label()
        LstValueList = New ListBox()
        LblPhasePortrait = New Label()
        PicPhasePortrait = New PictureBox()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        CType(SplitContainer2, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer2.Panel1.SuspendLayout()
        SplitContainer2.Panel2.SuspendLayout()
        SplitContainer2.SuspendLayout()
        CType(TrbParameterC, ComponentModel.ISupportInitialize).BeginInit()
        GrpStartParameter.SuspendLayout()
        CType(TrbSpeed, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicPhasePortrait, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.FixedPanel = FixedPanel.Panel2
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(PicDiagram)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(SplitContainer2)
        SplitContainer1.Size = New Size(1180, 614)
        SplitContainer1.SplitterDistance = 608
        SplitContainer1.SplitterWidth = 6
        SplitContainer1.TabIndex = 0
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(6, 7)
        PicDiagram.Margin = New Padding(4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(600, 600)
        PicDiagram.TabIndex = 4
        PicDiagram.TabStop = False
        ' 
        ' SplitContainer2
        ' 
        SplitContainer2.Dock = DockStyle.Fill
        SplitContainer2.Location = New Point(0, 0)
        SplitContainer2.Name = "SplitContainer2"
        ' 
        ' SplitContainer2.Panel1
        ' 
        SplitContainer2.Panel1.Controls.Add(BtnDefault)
        SplitContainer2.Panel1.Controls.Add(TxtParameter)
        SplitContainer2.Panel1.Controls.Add(TrbParameterC)
        SplitContainer2.Panel1.Controls.Add(BtnStop)
        SplitContainer2.Panel1.Controls.Add(BtnPhasePortrait)
        SplitContainer2.Panel1.Controls.Add(LblSteps)
        SplitContainer2.Panel1.Controls.Add(LblNumberOfSteps)
        SplitContainer2.Panel1.Controls.Add(CboBilliardTable)
        SplitContainer2.Panel1.Controls.Add(LblBilliardTable)
        SplitContainer2.Panel1.Controls.Add(GrpStartParameter)
        SplitContainer2.Panel1.Controls.Add(LblColor)
        SplitContainer2.Panel1.Controls.Add(LblSpeed)
        SplitContainer2.Panel1.Controls.Add(TrbSpeed)
        SplitContainer2.Panel1.Controls.Add(LblBallColor)
        SplitContainer2.Panel1.Controls.Add(CboBallColor)
        SplitContainer2.Panel1.Controls.Add(BtnNewBall)
        SplitContainer2.Panel1.Controls.Add(BtnStart)
        SplitContainer2.Panel1.Controls.Add(BtnReset)
        SplitContainer2.Panel1.Controls.Add(BtnNextStep)
        SplitContainer2.Panel1.Controls.Add(LblParameterc)
        ' 
        ' SplitContainer2.Panel2
        ' 
        SplitContainer2.Panel2.Controls.Add(ChkProtocol)
        SplitContainer2.Panel2.Controls.Add(LblProtocol)
        SplitContainer2.Panel2.Controls.Add(LstValueList)
        SplitContainer2.Panel2.Controls.Add(LblPhasePortrait)
        SplitContainer2.Panel2.Controls.Add(PicPhasePortrait)
        SplitContainer2.Size = New Size(566, 614)
        SplitContainer2.SplitterDistance = 227
        SplitContainer2.TabIndex = 0
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(0, 539)
        BtnDefault.Margin = New Padding(4)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(210, 30)
        BtnDefault.TabIndex = 75
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' TxtParameter
        ' 
        TxtParameter.Font = New Font("Microsoft Sans Serif", 9F)
        TxtParameter.Location = New Point(90, 50)
        TxtParameter.Margin = New Padding(6)
        TxtParameter.Name = "TxtParameter"
        TxtParameter.Size = New Size(120, 21)
        TxtParameter.TabIndex = 74
        ' 
        ' TrbParameterC
        ' 
        TrbParameterC.LargeChange = 10
        TrbParameterC.Location = New Point(4, 77)
        TrbParameterC.Margin = New Padding(4, 2, 4, 2)
        TrbParameterC.Maximum = 300
        TrbParameterC.Minimum = 30
        TrbParameterC.Name = "TrbParameterC"
        TrbParameterC.Size = New Size(206, 45)
        TrbParameterC.TabIndex = 73
        TrbParameterC.Value = 80
        ' 
        ' BtnStop
        ' 
        BtnStop.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStop.Location = New Point(110, 461)
        BtnStop.Margin = New Padding(4)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(100, 31)
        BtnStop.TabIndex = 72
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' BtnPhasePortrait
        ' 
        BtnPhasePortrait.Font = New Font("Microsoft Sans Serif", 9F)
        BtnPhasePortrait.Location = New Point(0, 500)
        BtnPhasePortrait.Margin = New Padding(4)
        BtnPhasePortrait.Name = "BtnPhasePortrait"
        BtnPhasePortrait.Size = New Size(210, 31)
        BtnPhasePortrait.TabIndex = 71
        BtnPhasePortrait.Text = "FillPhasePortrait"
        BtnPhasePortrait.UseVisualStyleBackColor = True
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblSteps.Location = New Point(110, 430)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(14, 15)
        LblSteps.TabIndex = 70
        LblSteps.Text = "0"
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblNumberOfSteps.Location = New Point(5, 430)
        LblNumberOfSteps.Margin = New Padding(4, 0, 4, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(95, 15)
        LblNumberOfSteps.TabIndex = 69
        LblNumberOfSteps.Text = "NumberOfSteps"
        ' 
        ' CboBilliardTable
        ' 
        CboBilliardTable.Font = New Font("Microsoft Sans Serif", 9F)
        CboBilliardTable.FormattingEnabled = True
        CboBilliardTable.Items.AddRange(New Object() {"Elliptic", "Stadium", "Oval"})
        CboBilliardTable.Location = New Point(4, 25)
        CboBilliardTable.Margin = New Padding(4)
        CboBilliardTable.Name = "CboBilliardTable"
        CboBilliardTable.Size = New Size(206, 23)
        CboBilliardTable.TabIndex = 68
        ' 
        ' LblBilliardTable
        ' 
        LblBilliardTable.AutoSize = True
        LblBilliardTable.Font = New Font("Microsoft Sans Serif", 9F)
        LblBilliardTable.Location = New Point(4, 7)
        LblBilliardTable.Margin = New Padding(4, 0, 4, 0)
        LblBilliardTable.Name = "LblBilliardTable"
        LblBilliardTable.Size = New Size(76, 15)
        LblBilliardTable.TabIndex = 67
        LblBilliardTable.Text = "BilliardTable"
        ' 
        ' GrpStartParameter
        ' 
        GrpStartParameter.Controls.Add(BtnTakeOverStartParameter)
        GrpStartParameter.Controls.Add(TxtAlfa)
        GrpStartParameter.Controls.Add(TxtT)
        GrpStartParameter.Controls.Add(LblAlfa)
        GrpStartParameter.Controls.Add(LblT)
        GrpStartParameter.Font = New Font("Microsoft Sans Serif", 9F)
        GrpStartParameter.Location = New Point(4, 208)
        GrpStartParameter.Margin = New Padding(4)
        GrpStartParameter.Name = "GrpStartParameter"
        GrpStartParameter.Padding = New Padding(4)
        GrpStartParameter.Size = New Size(206, 109)
        GrpStartParameter.TabIndex = 66
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
        LblAlfa.Location = New Point(9, 44)
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
        LblT.Location = New Point(16, 19)
        LblT.Margin = New Padding(4, 0, 4, 0)
        LblT.Name = "LblT"
        LblT.Size = New Size(10, 15)
        LblT.TabIndex = 0
        LblT.Text = "t"
        ' 
        ' LblColor
        ' 
        LblColor.BackColor = Color.Red
        LblColor.Location = New Point(162, 143)
        LblColor.Margin = New Padding(4, 0, 4, 0)
        LblColor.Name = "LblColor"
        LblColor.Size = New Size(48, 23)
        LblColor.TabIndex = 65
        ' 
        ' LblSpeed
        ' 
        LblSpeed.AutoSize = True
        LblSpeed.Font = New Font("Microsoft Sans Serif", 9F)
        LblSpeed.Location = New Point(4, 321)
        LblSpeed.Margin = New Padding(4, 0, 4, 0)
        LblSpeed.Name = "LblSpeed"
        LblSpeed.Size = New Size(64, 15)
        LblSpeed.TabIndex = 64
        LblSpeed.Text = "BallSpeed"
        ' 
        ' TrbSpeed
        ' 
        TrbSpeed.Location = New Point(4, 344)
        TrbSpeed.Margin = New Padding(4)
        TrbSpeed.Maximum = 500
        TrbSpeed.Minimum = 1
        TrbSpeed.Name = "TrbSpeed"
        TrbSpeed.Size = New Size(206, 45)
        TrbSpeed.TabIndex = 63
        TrbSpeed.Value = 50
        ' 
        ' LblBallColor
        ' 
        LblBallColor.AutoSize = True
        LblBallColor.Font = New Font("Microsoft Sans Serif", 9F)
        LblBallColor.Location = New Point(4, 124)
        LblBallColor.Margin = New Padding(4, 0, 4, 0)
        LblBallColor.Name = "LblBallColor"
        LblBallColor.Size = New Size(57, 15)
        LblBallColor.TabIndex = 62
        LblBallColor.Text = "BallColor"
        ' 
        ' CboBallColor
        ' 
        CboBallColor.BackColor = SystemColors.Window
        CboBallColor.Font = New Font("Microsoft Sans Serif", 9F)
        CboBallColor.FormattingEnabled = True
        CboBallColor.Items.AddRange(New Object() {"Red", "Green", "Blue", "Black", "Magenta"})
        CboBallColor.Location = New Point(4, 143)
        CboBallColor.Margin = New Padding(4)
        CboBallColor.Name = "CboBallColor"
        CboBallColor.Size = New Size(152, 23)
        CboBallColor.TabIndex = 61
        ' 
        ' BtnNewBall
        ' 
        BtnNewBall.Font = New Font("Microsoft Sans Serif", 9F)
        BtnNewBall.Location = New Point(4, 173)
        BtnNewBall.Margin = New Padding(4)
        BtnNewBall.Name = "BtnNewBall"
        BtnNewBall.Size = New Size(206, 30)
        BtnNewBall.TabIndex = 60
        BtnNewBall.Text = "NewBall"
        BtnNewBall.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStart.Location = New Point(0, 461)
        BtnStart.Margin = New Padding(4)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(100, 31)
        BtnStart.TabIndex = 59
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(0, 577)
        BtnReset.Margin = New Padding(4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(210, 30)
        BtnReset.TabIndex = 58
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnNextStep
        ' 
        BtnNextStep.Font = New Font("Microsoft Sans Serif", 9F)
        BtnNextStep.Location = New Point(0, 396)
        BtnNextStep.Margin = New Padding(4)
        BtnNextStep.Name = "BtnNextStep"
        BtnNextStep.Size = New Size(210, 30)
        BtnNextStep.TabIndex = 57
        BtnNextStep.Text = "NextStep"
        BtnNextStep.UseVisualStyleBackColor = True
        ' 
        ' LblParameterc
        ' 
        LblParameterc.AutoSize = True
        LblParameterc.Font = New Font("Microsoft Sans Serif", 9F)
        LblParameterc.Location = New Point(4, 52)
        LblParameterc.Margin = New Padding(4, 0, 4, 0)
        LblParameterc.Name = "LblParameterc"
        LblParameterc.Size = New Size(76, 15)
        LblParameterc.TabIndex = 56
        LblParameterc.Text = "Parameter C"
        ' 
        ' ChkProtocol
        ' 
        ChkProtocol.AutoSize = True
        ChkProtocol.Font = New Font("Microsoft Sans Serif", 9F)
        ChkProtocol.Location = New Point(255, 353)
        ChkProtocol.Margin = New Padding(4, 2, 4, 2)
        ChkProtocol.Name = "ChkProtocol"
        ChkProtocol.Size = New Size(71, 19)
        ChkProtocol.TabIndex = 72
        ChkProtocol.Text = "Protocol"
        ChkProtocol.UseVisualStyleBackColor = True
        ' 
        ' LblProtocol
        ' 
        LblProtocol.AutoSize = True
        LblProtocol.Font = New Font("Microsoft Sans Serif", 9F)
        LblProtocol.Location = New Point(6, 354)
        LblProtocol.Margin = New Padding(4, 0, 4, 0)
        LblProtocol.Name = "LblProtocol"
        LblProtocol.Size = New Size(52, 15)
        LblProtocol.TabIndex = 71
        LblProtocol.Text = "Procotol"
        ' 
        ' LstValueList
        ' 
        LstValueList.Font = New Font("Microsoft Sans Serif", 9F)
        LstValueList.FormattingEnabled = True
        LstValueList.ItemHeight = 15
        LstValueList.Location = New Point(3, 378)
        LstValueList.Margin = New Padding(4)
        LstValueList.Name = "LstValueList"
        LstValueList.Size = New Size(320, 229)
        LstValueList.TabIndex = 70
        ' 
        ' LblPhasePortrait
        ' 
        LblPhasePortrait.AutoSize = True
        LblPhasePortrait.Font = New Font("Microsoft Sans Serif", 9F)
        LblPhasePortrait.Location = New Point(6, 8)
        LblPhasePortrait.Margin = New Padding(4, 0, 4, 0)
        LblPhasePortrait.Name = "LblPhasePortrait"
        LblPhasePortrait.Size = New Size(81, 15)
        LblPhasePortrait.TabIndex = 69
        LblPhasePortrait.Text = "PhasePortrait"
        ' 
        ' PicPhasePortrait
        ' 
        PicPhasePortrait.BackColor = Color.White
        PicPhasePortrait.Location = New Point(3, 27)
        PicPhasePortrait.Margin = New Padding(4)
        PicPhasePortrait.Name = "PicPhasePortrait"
        PicPhasePortrait.Size = New Size(320, 320)
        PicPhasePortrait.TabIndex = 68
        PicPhasePortrait.TabStop = False
        ' 
        ' FrmBilliardtable
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1180, 614)
        Controls.Add(SplitContainer1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "FrmBilliardtable"
        StartPosition = FormStartPosition.WindowsDefaultBounds
        Text = "Billilard"
        WindowState = FormWindowState.Maximized
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer2.Panel1.ResumeLayout(False)
        SplitContainer2.Panel1.PerformLayout()
        SplitContainer2.Panel2.ResumeLayout(False)
        SplitContainer2.Panel2.PerformLayout()
        CType(SplitContainer2, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer2.ResumeLayout(False)
        CType(TrbParameterC, ComponentModel.ISupportInitialize).EndInit()
        GrpStartParameter.ResumeLayout(False)
        GrpStartParameter.PerformLayout()
        CType(TrbSpeed, ComponentModel.ISupportInitialize).EndInit()
        CType(PicPhasePortrait, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents BtnDefault As Button
    Friend WithEvents TxtParameter As TextBox
    Friend WithEvents TrbParameterC As TrackBar
    Friend WithEvents BtnStop As Button
    Friend WithEvents BtnPhasePortrait As Button
    Friend WithEvents LblSteps As Label
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents CboBilliardTable As ComboBox
    Friend WithEvents LblBilliardTable As Label
    Friend WithEvents GrpStartParameter As GroupBox
    Friend WithEvents BtnTakeOverStartParameter As Button
    Friend WithEvents TxtAlfa As TextBox
    Friend WithEvents TxtT As TextBox
    Friend WithEvents LblAlfa As Label
    Friend WithEvents LblT As Label
    Friend WithEvents LblColor As Label
    Friend WithEvents LblSpeed As Label
    Friend WithEvents TrbSpeed As TrackBar
    Friend WithEvents LblBallColor As Label
    Friend WithEvents CboBallColor As ComboBox
    Friend WithEvents BtnNewBall As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnNextStep As Button
    Friend WithEvents LblParameterc As Label
    Friend WithEvents ChkProtocol As CheckBox
    Friend WithEvents LblProtocol As Label
    Friend WithEvents LstValueList As ListBox
    Friend WithEvents LblPhasePortrait As Label
    Friend WithEvents PicPhasePortrait As PictureBox
End Class
