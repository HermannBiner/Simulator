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
        LstValueList.Font = New Font("Microsoft Sans Serif", 9F)
        LstValueList.FormattingEnabled = True
        LstValueList.ItemHeight = 15
        LstValueList.Location = New Point(959, 29)
        LstValueList.Margin = New Padding(9, 5, 9, 5)
        LstValueList.Name = "LstValueList"
        LstValueList.Size = New Size(173, 574)
        LstValueList.TabIndex = 8
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BorderStyle = BorderStyle.FixedSingle
        PicDiagram.Location = New Point(4, 5)
        PicDiagram.Margin = New Padding(4, 5, 4, 5)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(686, 600)
        PicDiagram.TabIndex = 7
        PicDiagram.TabStop = False
        ' 
        ' CboPendulum
        ' 
        CboPendulum.Font = New Font("Microsoft Sans Serif", 9F)
        CboPendulum.FormattingEnabled = True
        CboPendulum.Items.AddRange(New Object() {"RealSpringPendulum", "EulerExplicit", "EulerImplicit", "MidpointImplicit", "RungeKutta4"})
        CboPendulum.Location = New Point(699, 31)
        CboPendulum.Margin = New Padding(4, 5, 4, 5)
        CboPendulum.Name = "CboPendulum"
        CboPendulum.Size = New Size(247, 23)
        CboPendulum.TabIndex = 29
        ' 
        ' LblNumMethod
        ' 
        LblNumMethod.AutoSize = True
        LblNumMethod.Font = New Font("Microsoft Sans Serif", 9F)
        LblNumMethod.Location = New Point(698, 5)
        LblNumMethod.Margin = New Padding(4, 0, 4, 0)
        LblNumMethod.Name = "LblNumMethod"
        LblNumMethod.Size = New Size(96, 15)
        LblNumMethod.TabIndex = 28
        LblNumMethod.Text = "NumericMethod"
        ' 
        ' LblStepWidth
        ' 
        LblStepWidth.AutoSize = True
        LblStepWidth.Font = New Font("Microsoft Sans Serif", 9F)
        LblStepWidth.Location = New Point(699, 71)
        LblStepWidth.Margin = New Padding(4, 0, 4, 0)
        LblStepWidth.Name = "LblStepWidth"
        LblStepWidth.Size = New Size(63, 15)
        LblStepWidth.TabIndex = 31
        LblStepWidth.Text = "StepWidth"
        ' 
        ' TrbStepWidth
        ' 
        TrbStepWidth.Location = New Point(698, 91)
        TrbStepWidth.Margin = New Padding(4, 5, 4, 5)
        TrbStepWidth.Maximum = 15
        TrbStepWidth.Minimum = 1
        TrbStepWidth.Name = "TrbStepWidth"
        TrbStepWidth.Size = New Size(248, 45)
        TrbStepWidth.TabIndex = 30
        TrbStepWidth.Value = 5
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(697, 569)
        BtnReset.Margin = New Padding(9, 5, 9, 5)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(249, 30)
        BtnReset.TabIndex = 34
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStop
        ' 
        BtnStop.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStop.Location = New Point(698, 248)
        BtnStop.Margin = New Padding(9, 5, 9, 5)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(248, 30)
        BtnStop.TabIndex = 33
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStart.Location = New Point(698, 208)
        BtnStart.Margin = New Padding(4, 5, 4, 5)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(248, 30)
        BtnStart.TabIndex = 32
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblNumberOfSteps.Location = New Point(699, 179)
        LblNumberOfSteps.Margin = New Padding(4, 0, 4, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(102, 15)
        LblNumberOfSteps.TabIndex = 35
        LblNumberOfSteps.Text = "Number of Steps:"
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblSteps.Location = New Point(803, 179)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(14, 15)
        LblSteps.TabIndex = 36
        LblSteps.Text = "0"
        ' 
        ' ChkStretched
        ' 
        ChkStretched.AutoSize = True
        ChkStretched.Font = New Font("Microsoft Sans Serif", 9F)
        ChkStretched.Location = New Point(699, 146)
        ChkStretched.Margin = New Padding(9, 5, 9, 5)
        ChkStretched.Name = "ChkStretched"
        ChkStretched.Size = New Size(110, 19)
        ChkStretched.TabIndex = 37
        ChkStretched.Text = "StretchedMode"
        ChkStretched.UseVisualStyleBackColor = True
        ' 
        ' LblDifference
        ' 
        LblDifference.AutoSize = True
        LblDifference.Font = New Font("Microsoft Sans Serif", 9F)
        LblDifference.Location = New Point(959, 5)
        LblDifference.Margin = New Padding(9, 0, 9, 0)
        LblDifference.Name = "LblDifference"
        LblDifference.Size = New Size(63, 15)
        LblDifference.TabIndex = 38
        LblDifference.Text = "Difference"
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(697, 529)
        BtnDefault.Margin = New Padding(9, 5, 9, 5)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(249, 30)
        BtnDefault.TabIndex = 39
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' FrmNumericMethods
        ' 
        AutoScaleDimensions = New SizeF(9F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1140, 609)
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
        Font = New Font("Microsoft Sans Serif", 11.1428576F)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4, 5, 4, 5)
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
