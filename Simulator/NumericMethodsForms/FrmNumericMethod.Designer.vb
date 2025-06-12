<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNumericMethod
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNumericMethod))
        SplitContainer1 = New SplitContainer()
        PicDiagram = New PictureBox()
        SplitContainer2 = New SplitContainer()
        LblDifference = New Label()
        LstValueList = New ListBox()
        BtnDefault = New Button()
        ChkStretched = New CheckBox()
        LblSteps = New Label()
        LblNumberOfSteps = New Label()
        BtnReset = New Button()
        BtnStop = New Button()
        BtnStart = New Button()
        LblStepWidth = New Label()
        TrbStepWidth = New TrackBar()
        CboPendulum = New ComboBox()
        LblNumMethod = New Label()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        CType(SplitContainer2, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer2.Panel1.SuspendLayout()
        SplitContainer2.Panel2.SuspendLayout()
        SplitContainer2.SuspendLayout()
        CType(TrbStepWidth, ComponentModel.ISupportInitialize).BeginInit()
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
        SplitContainer1.Size = New Size(1143, 614)
        SplitContainer1.SplitterDistance = 685
        SplitContainer1.SplitterWidth = 6
        SplitContainer1.TabIndex = 0
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BorderStyle = BorderStyle.FixedSingle
        PicDiagram.Location = New Point(4, 4)
        PicDiagram.Margin = New Padding(4, 5, 4, 5)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(686, 600)
        PicDiagram.TabIndex = 8
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
        SplitContainer2.Panel1.Controls.Add(LblDifference)
        SplitContainer2.Panel1.Controls.Add(LstValueList)
        ' 
        ' SplitContainer2.Panel2
        ' 
        SplitContainer2.Panel2.Controls.Add(BtnDefault)
        SplitContainer2.Panel2.Controls.Add(ChkStretched)
        SplitContainer2.Panel2.Controls.Add(LblSteps)
        SplitContainer2.Panel2.Controls.Add(LblNumberOfSteps)
        SplitContainer2.Panel2.Controls.Add(BtnReset)
        SplitContainer2.Panel2.Controls.Add(BtnStop)
        SplitContainer2.Panel2.Controls.Add(BtnStart)
        SplitContainer2.Panel2.Controls.Add(LblStepWidth)
        SplitContainer2.Panel2.Controls.Add(TrbStepWidth)
        SplitContainer2.Panel2.Controls.Add(CboPendulum)
        SplitContainer2.Panel2.Controls.Add(LblNumMethod)
        SplitContainer2.Size = New Size(452, 614)
        SplitContainer2.SplitterDistance = 186
        SplitContainer2.TabIndex = 0
        ' 
        ' LblDifference
        ' 
        LblDifference.AutoSize = True
        LblDifference.Font = New Font("Microsoft Sans Serif", 9F)
        LblDifference.Location = New Point(5, 4)
        LblDifference.Margin = New Padding(9, 0, 9, 0)
        LblDifference.Name = "LblDifference"
        LblDifference.Size = New Size(63, 15)
        LblDifference.TabIndex = 42
        LblDifference.Text = "Difference"
        ' 
        ' LstValueList
        ' 
        LstValueList.Font = New Font("Microsoft Sans Serif", 9F)
        LstValueList.FormattingEnabled = True
        LstValueList.ItemHeight = 15
        LstValueList.Location = New Point(5, 24)
        LstValueList.Margin = New Padding(9, 5, 9, 5)
        LstValueList.Name = "LstValueList"
        LstValueList.Size = New Size(173, 574)
        LstValueList.TabIndex = 41
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(9, 252)
        BtnDefault.Margin = New Padding(9, 5, 9, 5)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(243, 30)
        BtnDefault.TabIndex = 61
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' ChkStretched
        ' 
        ChkStretched.AutoSize = True
        ChkStretched.Font = New Font("Microsoft Sans Serif", 9F)
        ChkStretched.Location = New Point(5, 117)
        ChkStretched.Margin = New Padding(9, 5, 9, 5)
        ChkStretched.Name = "ChkStretched"
        ChkStretched.Size = New Size(110, 19)
        ChkStretched.TabIndex = 60
        ChkStretched.Text = "StretchedMode"
        ChkStretched.UseVisualStyleBackColor = True
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblSteps.Location = New Point(115, 152)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(14, 15)
        LblSteps.TabIndex = 59
        LblSteps.Text = "0"
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblNumberOfSteps.Location = New Point(5, 152)
        LblNumberOfSteps.Margin = New Padding(4, 0, 4, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(102, 15)
        LblNumberOfSteps.TabIndex = 58
        LblNumberOfSteps.Text = "Number of Steps:"
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(9, 292)
        BtnReset.Margin = New Padding(9, 5, 9, 5)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(243, 30)
        BtnReset.TabIndex = 57
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStop
        ' 
        BtnStop.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStop.Location = New Point(9, 212)
        BtnStop.Margin = New Padding(9, 5, 9, 5)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(243, 30)
        BtnStop.TabIndex = 56
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStart.Location = New Point(9, 172)
        BtnStart.Margin = New Padding(4, 5, 4, 5)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(243, 30)
        BtnStart.TabIndex = 55
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' LblStepWidth
        ' 
        LblStepWidth.AutoSize = True
        LblStepWidth.Font = New Font("Microsoft Sans Serif", 9F)
        LblStepWidth.Location = New Point(4, 52)
        LblStepWidth.Margin = New Padding(4, 0, 4, 0)
        LblStepWidth.Name = "LblStepWidth"
        LblStepWidth.Size = New Size(63, 15)
        LblStepWidth.TabIndex = 54
        LblStepWidth.Text = "StepWidth"
        ' 
        ' TrbStepWidth
        ' 
        TrbStepWidth.Location = New Point(9, 72)
        TrbStepWidth.Margin = New Padding(4, 5, 4, 5)
        TrbStepWidth.Maximum = 15
        TrbStepWidth.Minimum = 1
        TrbStepWidth.Name = "TrbStepWidth"
        TrbStepWidth.Size = New Size(243, 45)
        TrbStepWidth.TabIndex = 53
        TrbStepWidth.Value = 5
        ' 
        ' CboPendulum
        ' 
        CboPendulum.DropDownStyle = ComboBoxStyle.DropDownList
        CboPendulum.Font = New Font("Microsoft Sans Serif", 9F)
        CboPendulum.FormattingEnabled = True
        CboPendulum.Items.AddRange(New Object() {"RealSpringPendulum", "EulerExplicit", "EulerImplicit", "MidpointImplicit", "RungeKutta4"})
        CboPendulum.Location = New Point(5, 24)
        CboPendulum.Margin = New Padding(4, 5, 4, 5)
        CboPendulum.Name = "CboPendulum"
        CboPendulum.Size = New Size(247, 23)
        CboPendulum.TabIndex = 52
        ' 
        ' LblNumMethod
        ' 
        LblNumMethod.AutoSize = True
        LblNumMethod.Font = New Font("Microsoft Sans Serif", 9F)
        LblNumMethod.Location = New Point(5, 4)
        LblNumMethod.Margin = New Padding(4, 0, 4, 0)
        LblNumMethod.Name = "LblNumMethod"
        LblNumMethod.Size = New Size(96, 15)
        LblNumMethod.TabIndex = 51
        LblNumMethod.Text = "NumericMethod"
        ' 
        ' FrmNumericMethod
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1143, 614)
        Controls.Add(SplitContainer1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimumSize = New Size(508, 450)
        Name = "FrmNumericMethod"
        StartPosition = FormStartPosition.WindowsDefaultBounds
        Text = "NumericMethod"
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
        CType(TrbStepWidth, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents LblDifference As Label
    Friend WithEvents LstValueList As ListBox
    Friend WithEvents BtnDefault As Button
    Friend WithEvents ChkStretched As CheckBox
    Friend WithEvents LblSteps As Label
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStop As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents LblStepWidth As Label
    Friend WithEvents TrbStepWidth As TrackBar
    Friend WithEvents CboPendulum As ComboBox
    Friend WithEvents LblNumMethod As Label
End Class
