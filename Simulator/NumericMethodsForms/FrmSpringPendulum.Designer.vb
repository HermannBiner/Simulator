<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSpringPendulum
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSpringPendulum))
        LstValueList = New ListBox()
        PicDiagram = New PictureBox()
        CboPendulum = New ComboBox()
        LblPendulum = New Label()
        LblStepWidth = New Label()
        TrbStepWidth = New TrackBar()
        BtnReset = New Button()
        BtnStop = New Button()
        BtnStart = New Button()
        LblNumberOfSteps = New Label()
        LblSteps = New Label()
        ChkStretched = New CheckBox()
        LblDifference = New Label()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbStepWidth, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LstValueList
        ' 
        LstValueList.FormattingEnabled = True
        LstValueList.ItemHeight = 15
        LstValueList.Location = New Point(1122, 38)
        LstValueList.Margin = New Padding(4, 3, 4, 3)
        LstValueList.Name = "LstValueList"
        LstValueList.Size = New Size(174, 514)
        LstValueList.TabIndex = 8
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BorderStyle = BorderStyle.FixedSingle
        PicDiagram.Location = New Point(7, 8)
        PicDiagram.Margin = New Padding(2)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(862, 543)
        PicDiagram.TabIndex = 7
        PicDiagram.TabStop = False
        ' 
        ' CboPendulum
        ' 
        CboPendulum.FormattingEnabled = True
        CboPendulum.Items.AddRange(New Object() {"RealSpringPendulum", "EulerExplicit", "EulerImplicit", "MidpointImplicit", "RungeKutta4"})
        CboPendulum.Location = New Point(889, 38)
        CboPendulum.Margin = New Padding(2)
        CboPendulum.Name = "CboPendulum"
        CboPendulum.Size = New Size(214, 23)
        CboPendulum.TabIndex = 29
        ' 
        ' LblPendulum
        ' 
        LblPendulum.AutoSize = True
        LblPendulum.Location = New Point(887, 9)
        LblPendulum.Margin = New Padding(2, 0, 2, 0)
        LblPendulum.Name = "LblPendulum"
        LblPendulum.Size = New Size(62, 15)
        LblPendulum.TabIndex = 28
        LblPendulum.Text = "Pendulum"
        ' 
        ' LblStepWidth
        ' 
        LblStepWidth.AutoSize = True
        LblStepWidth.Location = New Point(896, 76)
        LblStepWidth.Margin = New Padding(2, 0, 2, 0)
        LblStepWidth.Name = "LblStepWidth"
        LblStepWidth.Size = New Size(62, 15)
        LblStepWidth.TabIndex = 31
        LblStepWidth.Text = "StepWidth"
        ' 
        ' TrbStepWidth
        ' 
        TrbStepWidth.Location = New Point(889, 100)
        TrbStepWidth.Margin = New Padding(2)
        TrbStepWidth.Maximum = 15
        TrbStepWidth.Minimum = 1
        TrbStepWidth.Name = "TrbStepWidth"
        TrbStepWidth.Size = New Size(212, 45)
        TrbStepWidth.TabIndex = 30
        TrbStepWidth.Value = 5
        ' 
        ' BtnReset
        ' 
        BtnReset.Location = New Point(889, 373)
        BtnReset.Margin = New Padding(4, 3, 4, 3)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(212, 39)
        BtnReset.TabIndex = 34
        BtnReset.Text = "Reset"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStop
        ' 
        BtnStop.Location = New Point(889, 305)
        BtnStop.Margin = New Padding(4, 3, 4, 3)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(212, 39)
        BtnStop.TabIndex = 33
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Location = New Point(890, 212)
        BtnStart.Margin = New Padding(2)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(212, 39)
        BtnStart.TabIndex = 32
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Location = New Point(887, 270)
        LblNumberOfSteps.Margin = New Padding(2, 0, 2, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(99, 15)
        LblNumberOfSteps.TabIndex = 35
        LblNumberOfSteps.Text = "Number of Steps:"
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Location = New Point(1000, 270)
        LblSteps.Margin = New Padding(2, 0, 2, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(13, 15)
        LblSteps.TabIndex = 36
        LblSteps.Text = "0"
        ' 
        ' ChkStretched
        ' 
        ChkStretched.AutoSize = True
        ChkStretched.Location = New Point(890, 158)
        ChkStretched.Margin = New Padding(4, 3, 4, 3)
        ChkStretched.Name = "ChkStretched"
        ChkStretched.Size = New Size(107, 19)
        ChkStretched.TabIndex = 37
        ChkStretched.Text = "StretchedMode"
        ChkStretched.UseVisualStyleBackColor = True
        ' 
        ' LblDifference
        ' 
        LblDifference.AutoSize = True
        LblDifference.Location = New Point(1122, 10)
        LblDifference.Margin = New Padding(4, 0, 4, 0)
        LblDifference.Name = "LblDifference"
        LblDifference.Size = New Size(61, 15)
        LblDifference.TabIndex = 38
        LblDifference.Text = "Difference"
        ' 
        ' FrmSpringPendulum
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1320, 563)
        Controls.Add(LblDifference)
        Controls.Add(ChkStretched)
        Controls.Add(LblSteps)
        Controls.Add(LblNumberOfSteps)
        Controls.Add(BtnReset)
        Controls.Add(BtnStop)
        Controls.Add(BtnStart)
        Controls.Add(LblStepWidth)
        Controls.Add(TrbStepWidth)
        Controls.Add(CboPendulum)
        Controls.Add(LblPendulum)
        Controls.Add(LstValueList)
        Controls.Add(PicDiagram)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(2)
        Name = "FrmSpringPendulum"
        Text = "SpringPendulum"
        WindowState = FormWindowState.Maximized
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        CType(TrbStepWidth, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents LstValueList As ListBox
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents CboPendulum As ComboBox
    Friend WithEvents LblPendulum As Label
    Friend WithEvents LblStepWidth As Label
    Friend WithEvents TrbStepWidth As TrackBar
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStop As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents LblSteps As Label
    Friend WithEvents ChkStretched As CheckBox
    Friend WithEvents LblDifference As Label
End Class
