<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNumericMethods
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNumericMethods))
        LstValueList = New ListBox()
        PicDiagram = New PictureBox()
        CboPendulum = New ComboBox()
        LblNumMethod = New Label()
        LblStepWidth = New Label()
        TrbStepWidth = New TrackBar()
        BtnReset = New Button()
        BtnStop = New Button()
        BtnStart = New Button()
        LblNumberOfSteps = New Label()
        LblSteps = New Label()
        ChkStretched = New CheckBox()
        LblDifference = New Label()
        BtnDefault = New Button()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrbStepWidth, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LstValueList
        ' 
        LstValueList.FormattingEnabled = True
        LstValueList.Location = New Point(2084, 61)
        LstValueList.Margin = New Padding(7, 6, 7, 6)
        LstValueList.Name = "LstValueList"
        LstValueList.Size = New Size(265, 1151)
        LstValueList.TabIndex = 8
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BorderStyle = BorderStyle.FixedSingle
        PicDiagram.Location = New Point(13, 17)
        PicDiagram.Margin = New Padding(4, 4, 4, 4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(1626, 1200)
        PicDiagram.TabIndex = 7
        PicDiagram.TabStop = False
        ' 
        ' CboPendulum
        ' 
        CboPendulum.FormattingEnabled = True
        CboPendulum.Items.AddRange(New Object() {"RealSpringPendulum", "EulerExplicit", "EulerImplicit", "MidpointImplicit", "RungeKutta4"})
        CboPendulum.Location = New Point(1649, 61)
        CboPendulum.Margin = New Padding(4, 4, 4, 4)
        CboPendulum.Name = "CboPendulum"
        CboPendulum.Size = New Size(424, 39)
        CboPendulum.TabIndex = 29
        ' 
        ' LblNumMethod
        ' 
        LblNumMethod.AutoSize = True
        LblNumMethod.Location = New Point(1650, 17)
        LblNumMethod.Margin = New Padding(4, 0, 4, 0)
        LblNumMethod.Name = "LblNumMethod"
        LblNumMethod.Size = New Size(182, 31)
        LblNumMethod.TabIndex = 28
        LblNumMethod.Text = "NumericMethod"
        ' 
        ' LblStepWidth
        ' 
        LblStepWidth.AutoSize = True
        LblStepWidth.Location = New Point(1650, 121)
        LblStepWidth.Margin = New Padding(4, 0, 4, 0)
        LblStepWidth.Name = "LblStepWidth"
        LblStepWidth.Size = New Size(121, 31)
        LblStepWidth.TabIndex = 31
        LblStepWidth.Text = "StepWidth"
        ' 
        ' TrbStepWidth
        ' 
        TrbStepWidth.Location = New Point(1650, 167)
        TrbStepWidth.Margin = New Padding(4, 4, 4, 4)
        TrbStepWidth.Maximum = 15
        TrbStepWidth.Minimum = 1
        TrbStepWidth.Name = "TrbStepWidth"
        TrbStepWidth.Size = New Size(423, 69)
        TrbStepWidth.TabIndex = 30
        TrbStepWidth.Value = 5
        ' 
        ' BtnReset
        ' 
        BtnReset.Location = New Point(1646, 1173)
        BtnReset.Margin = New Padding(7, 6, 7, 6)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(427, 50)
        BtnReset.TabIndex = 34
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStop
        ' 
        BtnStop.Location = New Point(1646, 430)
        BtnStop.Margin = New Padding(7, 6, 7, 6)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(427, 50)
        BtnStop.TabIndex = 33
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Location = New Point(1646, 370)
        BtnStart.Margin = New Padding(4, 4, 4, 4)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(427, 50)
        BtnStart.TabIndex = 32
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Location = New Point(1650, 321)
        LblNumberOfSteps.Margin = New Padding(4, 0, 4, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(190, 31)
        LblNumberOfSteps.TabIndex = 35
        LblNumberOfSteps.Text = "Number of Steps:"
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Location = New Point(1873, 321)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(26, 31)
        LblSteps.TabIndex = 36
        LblSteps.Text = "0"
        ' 
        ' ChkStretched
        ' 
        ChkStretched.AutoSize = True
        ChkStretched.Location = New Point(1650, 259)
        ChkStretched.Margin = New Padding(7, 6, 7, 6)
        ChkStretched.Name = "ChkStretched"
        ChkStretched.Size = New Size(197, 35)
        ChkStretched.TabIndex = 37
        ChkStretched.Text = "StretchedMode"
        ChkStretched.UseVisualStyleBackColor = True
        ' 
        ' LblDifference
        ' 
        LblDifference.AutoSize = True
        LblDifference.Location = New Point(2084, 24)
        LblDifference.Margin = New Padding(7, 0, 7, 0)
        LblDifference.Name = "LblDifference"
        LblDifference.Size = New Size(118, 31)
        LblDifference.TabIndex = 38
        LblDifference.Text = "Difference"
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Location = New Point(1649, 1111)
        BtnDefault.Margin = New Padding(7, 6, 7, 6)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(427, 50)
        BtnDefault.TabIndex = 39
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' FrmNumericMethods
        ' 
        AutoScaleDimensions = New SizeF(13F, 31F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(2371, 1238)
        Controls.Add(BtnDefault)
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
        Controls.Add(LblNumMethod)
        Controls.Add(LstValueList)
        Controls.Add(PicDiagram)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4, 4, 4, 4)
        Name = "FrmNumericMethods"
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
    Friend WithEvents LblNumMethod As Label
    Friend WithEvents LblStepWidth As Label
    Friend WithEvents TrbStepWidth As TrackBar
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStop As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents LblSteps As Label
    Friend WithEvents ChkStretched As CheckBox
    Friend WithEvents LblDifference As Label
    Friend WithEvents BtnDefault As Button
End Class
