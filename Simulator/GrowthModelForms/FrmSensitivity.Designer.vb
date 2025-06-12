<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSensitivity
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSensitivity))
        SplitContainer1 = New SplitContainer()
        CboIterationDepth = New ComboBox()
        LblIterationDepth = New Label()
        CboFunction = New ComboBox()
        TxtParameter = New TextBox()
        LblParameter = New Label()
        PicDiagram = New PictureBox()
        SplitContainer2 = New SplitContainer()
        LblValueList2 = New Label()
        LstValueList2 = New ListBox()
        LblValueList1 = New Label()
        LstValueList1 = New ListBox()
        BtnDefault = New Button()
        LblSteps = New Label()
        LblNumberOfSteps = New Label()
        BtnReset = New Button()
        BtnStart = New Button()
        GrpPresentation = New GroupBox()
        LblStretching = New Label()
        TxtxStretching = New TextBox()
        LblxStretching = New Label()
        OptSingleOrbit = New RadioButton()
        OptDifference = New RadioButton()
        TxtStartValue2 = New TextBox()
        LblStartValue2 = New Label()
        TxtStartValue1 = New TextBox()
        LblStartValue1 = New Label()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        CType(SplitContainer2, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer2.Panel1.SuspendLayout()
        SplitContainer2.Panel2.SuspendLayout()
        SplitContainer2.SuspendLayout()
        GrpPresentation.SuspendLayout()
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
        SplitContainer1.Panel1.Controls.Add(CboIterationDepth)
        SplitContainer1.Panel1.Controls.Add(LblIterationDepth)
        SplitContainer1.Panel1.Controls.Add(CboFunction)
        SplitContainer1.Panel1.Controls.Add(TxtParameter)
        SplitContainer1.Panel1.Controls.Add(LblParameter)
        SplitContainer1.Panel1.Controls.Add(PicDiagram)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(SplitContainer2)
        SplitContainer1.Size = New Size(1211, 592)
        SplitContainer1.SplitterDistance = 654
        SplitContainer1.SplitterWidth = 6
        SplitContainer1.TabIndex = 0
        ' 
        ' CboIterationDepth
        ' 
        CboIterationDepth.DropDownStyle = ComboBoxStyle.DropDownList
        CboIterationDepth.FormattingEnabled = True
        CboIterationDepth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        CboIterationDepth.Location = New Point(399, 6)
        CboIterationDepth.Margin = New Padding(4)
        CboIterationDepth.Name = "CboIterationDepth"
        CboIterationDepth.Size = New Size(57, 23)
        CboIterationDepth.TabIndex = 33
        ' 
        ' LblIterationDepth
        ' 
        LblIterationDepth.AutoSize = True
        LblIterationDepth.Font = New Font("Microsoft Sans Serif", 9F)
        LblIterationDepth.Location = New Point(307, 11)
        LblIterationDepth.Margin = New Padding(4, 0, 4, 0)
        LblIterationDepth.Name = "LblIterationDepth"
        LblIterationDepth.Size = New Size(84, 15)
        LblIterationDepth.TabIndex = 35
        LblIterationDepth.Text = "IterationDepth"
        ' 
        ' CboFunction
        ' 
        CboFunction.DropDownStyle = ComboBoxStyle.DropDownList
        CboFunction.Font = New Font("Microsoft Sans Serif", 9F)
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic Growth", "Parabola"})
        CboFunction.Location = New Point(6, 6)
        CboFunction.Margin = New Padding(4)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(181, 23)
        CboFunction.TabIndex = 31
        ' 
        ' TxtParameter
        ' 
        TxtParameter.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TxtParameter.Location = New Point(227, 8)
        TxtParameter.Margin = New Padding(4)
        TxtParameter.Name = "TxtParameter"
        TxtParameter.Size = New Size(72, 21)
        TxtParameter.TabIndex = 32
        ' 
        ' LblParameter
        ' 
        LblParameter.AutoSize = True
        LblParameter.Font = New Font("Microsoft Sans Serif", 9F)
        LblParameter.Location = New Point(195, 11)
        LblParameter.Margin = New Padding(4, 0, 4, 0)
        LblParameter.Name = "LblParameter"
        LblParameter.Size = New Size(24, 15)
        LblParameter.TabIndex = 34
        LblParameter.Text = "a ="
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(7, 33)
        PicDiagram.Margin = New Padding(4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(643, 554)
        PicDiagram.TabIndex = 30
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
        SplitContainer2.Panel1.Controls.Add(LblValueList2)
        SplitContainer2.Panel1.Controls.Add(LstValueList2)
        SplitContainer2.Panel1.Controls.Add(LblValueList1)
        SplitContainer2.Panel1.Controls.Add(LstValueList1)
        ' 
        ' SplitContainer2.Panel2
        ' 
        SplitContainer2.Panel2.Controls.Add(BtnDefault)
        SplitContainer2.Panel2.Controls.Add(LblSteps)
        SplitContainer2.Panel2.Controls.Add(LblNumberOfSteps)
        SplitContainer2.Panel2.Controls.Add(BtnReset)
        SplitContainer2.Panel2.Controls.Add(BtnStart)
        SplitContainer2.Panel2.Controls.Add(GrpPresentation)
        SplitContainer2.Panel2.Controls.Add(TxtStartValue2)
        SplitContainer2.Panel2.Controls.Add(LblStartValue2)
        SplitContainer2.Panel2.Controls.Add(TxtStartValue1)
        SplitContainer2.Panel2.Controls.Add(LblStartValue1)
        SplitContainer2.Size = New Size(551, 592)
        SplitContainer2.SplitterDistance = 216
        SplitContainer2.TabIndex = 0
        ' 
        ' LblValueList2
        ' 
        LblValueList2.AutoSize = True
        LblValueList2.Font = New Font("Microsoft Sans Serif", 9F)
        LblValueList2.Location = New Point(114, 8)
        LblValueList2.Margin = New Padding(4, 0, 4, 0)
        LblValueList2.Name = "LblValueList2"
        LblValueList2.Size = New Size(64, 15)
        LblValueList2.TabIndex = 37
        LblValueList2.Text = "ValueList2"
        ' 
        ' LstValueList2
        ' 
        LstValueList2.Font = New Font("Microsoft Sans Serif", 9F)
        LstValueList2.FormattingEnabled = True
        LstValueList2.ItemHeight = 15
        LstValueList2.Location = New Point(114, 29)
        LstValueList2.Margin = New Padding(4)
        LstValueList2.Name = "LstValueList2"
        LstValueList2.ScrollAlwaysVisible = True
        LstValueList2.Size = New Size(102, 559)
        LstValueList2.TabIndex = 36
        ' 
        ' LblValueList1
        ' 
        LblValueList1.AutoSize = True
        LblValueList1.Font = New Font("Microsoft Sans Serif", 9F)
        LblValueList1.Location = New Point(3, 8)
        LblValueList1.Margin = New Padding(4, 0, 4, 0)
        LblValueList1.Name = "LblValueList1"
        LblValueList1.Size = New Size(64, 15)
        LblValueList1.TabIndex = 35
        LblValueList1.Text = "ValueList1"
        ' 
        ' LstValueList1
        ' 
        LstValueList1.Font = New Font("Microsoft Sans Serif", 9F)
        LstValueList1.FormattingEnabled = True
        LstValueList1.ItemHeight = 15
        LstValueList1.Location = New Point(3, 28)
        LstValueList1.Margin = New Padding(4)
        LstValueList1.Name = "LstValueList1"
        LstValueList1.ScrollAlwaysVisible = True
        LstValueList1.Size = New Size(102, 559)
        LstValueList1.TabIndex = 34
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(8, 262)
        BtnDefault.Margin = New Padding(4)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(318, 30)
        BtnDefault.TabIndex = 53
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblSteps.Location = New Point(121, 189)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(14, 15)
        LblSteps.TabIndex = 52
        LblSteps.Text = "0"
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblNumberOfSteps.Location = New Point(16, 191)
        LblNumberOfSteps.Margin = New Padding(4, 0, 4, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(95, 15)
        LblNumberOfSteps.TabIndex = 51
        LblNumberOfSteps.Text = "NumberOfSteps"
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(8, 300)
        BtnReset.Margin = New Padding(4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(318, 30)
        BtnReset.TabIndex = 50
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BtnStart.Location = New Point(8, 224)
        BtnStart.Margin = New Padding(4)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(318, 30)
        BtnStart.TabIndex = 49
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' GrpPresentation
        ' 
        GrpPresentation.Controls.Add(LblStretching)
        GrpPresentation.Controls.Add(TxtxStretching)
        GrpPresentation.Controls.Add(LblxStretching)
        GrpPresentation.Controls.Add(OptSingleOrbit)
        GrpPresentation.Controls.Add(OptDifference)
        GrpPresentation.Font = New Font("Microsoft Sans Serif", 9F)
        GrpPresentation.Location = New Point(16, 71)
        GrpPresentation.Margin = New Padding(4)
        GrpPresentation.Name = "GrpPresentation"
        GrpPresentation.Padding = New Padding(4)
        GrpPresentation.Size = New Size(310, 106)
        GrpPresentation.TabIndex = 48
        GrpPresentation.TabStop = False
        GrpPresentation.Text = "Presentation"
        ' 
        ' LblStretching
        ' 
        LblStretching.AutoSize = True
        LblStretching.Location = New Point(131, 57)
        LblStretching.Margin = New Padding(4, 0, 4, 0)
        LblStretching.Name = "LblStretching"
        LblStretching.Size = New Size(81, 15)
        LblStretching.TabIndex = 4
        LblStretching.Text = "DinStretching"
        ' 
        ' TxtxStretching
        ' 
        TxtxStretching.Location = New Point(219, 50)
        TxtxStretching.Margin = New Padding(4)
        TxtxStretching.Name = "TxtxStretching"
        TxtxStretching.Size = New Size(80, 21)
        TxtxStretching.TabIndex = 3
        ' 
        ' LblxStretching
        ' 
        LblxStretching.AutoSize = True
        LblxStretching.Location = New Point(131, 25)
        LblxStretching.Margin = New Padding(4, 0, 4, 0)
        LblxStretching.Name = "LblxStretching"
        LblxStretching.Size = New Size(68, 15)
        LblxStretching.TabIndex = 2
        LblxStretching.Text = "xStretching"
        ' 
        ' OptSingleOrbit
        ' 
        OptSingleOrbit.AutoSize = True
        OptSingleOrbit.Location = New Point(27, 55)
        OptSingleOrbit.Margin = New Padding(4)
        OptSingleOrbit.Name = "OptSingleOrbit"
        OptSingleOrbit.Size = New Size(92, 19)
        OptSingleOrbit.TabIndex = 1
        OptSingleOrbit.Text = "SingleOrbits"
        OptSingleOrbit.UseVisualStyleBackColor = True
        ' 
        ' OptDifference
        ' 
        OptDifference.AutoSize = True
        OptDifference.Checked = True
        OptDifference.Location = New Point(27, 25)
        OptDifference.Margin = New Padding(4)
        OptDifference.Name = "OptDifference"
        OptDifference.Size = New Size(95, 19)
        OptDifference.TabIndex = 0
        OptDifference.TabStop = True
        OptDifference.Text = "Difference12"
        OptDifference.UseVisualStyleBackColor = True
        ' 
        ' TxtStartValue2
        ' 
        TxtStartValue2.Font = New Font("Microsoft Sans Serif", 9F)
        TxtStartValue2.Location = New Point(94, 38)
        TxtStartValue2.Margin = New Padding(4)
        TxtStartValue2.Name = "TxtStartValue2"
        TxtStartValue2.Size = New Size(223, 21)
        TxtStartValue2.TabIndex = 46
        ' 
        ' LblStartValue2
        ' 
        LblStartValue2.AutoSize = True
        LblStartValue2.Font = New Font("Microsoft Sans Serif", 9F)
        LblStartValue2.Location = New Point(16, 38)
        LblStartValue2.Margin = New Padding(4, 0, 4, 0)
        LblStartValue2.Name = "LblStartValue2"
        LblStartValue2.Size = New Size(70, 15)
        LblStartValue2.TabIndex = 47
        LblStartValue2.Text = "StartValue2"
        ' 
        ' TxtStartValue1
        ' 
        TxtStartValue1.Font = New Font("Microsoft Sans Serif", 9F)
        TxtStartValue1.Location = New Point(94, 6)
        TxtStartValue1.Margin = New Padding(4)
        TxtStartValue1.Name = "TxtStartValue1"
        TxtStartValue1.Size = New Size(223, 21)
        TxtStartValue1.TabIndex = 44
        ' 
        ' LblStartValue1
        ' 
        LblStartValue1.AutoSize = True
        LblStartValue1.Font = New Font("Microsoft Sans Serif", 9F)
        LblStartValue1.Location = New Point(16, 11)
        LblStartValue1.Margin = New Padding(4, 0, 4, 0)
        LblStartValue1.Name = "LblStartValue1"
        LblStartValue1.Size = New Size(70, 15)
        LblStartValue1.TabIndex = 45
        LblStartValue1.Text = "StartValue1"
        ' 
        ' FrmSensitivity
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1211, 592)
        Controls.Add(SplitContainer1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimumSize = New Size(610, 378)
        Name = "FrmSensitivity"
        StartPosition = FormStartPosition.WindowsDefaultBounds
        Text = "Sensitivity"
        WindowState = FormWindowState.Maximized
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel1.PerformLayout()
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
        GrpPresentation.ResumeLayout(False)
        GrpPresentation.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents CboIterationDepth As ComboBox
    Friend WithEvents LblIterationDepth As Label
    Friend WithEvents CboFunction As ComboBox
    Friend WithEvents TxtParameter As TextBox
    Friend WithEvents LblParameter As Label
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents LblValueList2 As Label
    Friend WithEvents LstValueList2 As ListBox
    Friend WithEvents LblValueList1 As Label
    Friend WithEvents LstValueList1 As ListBox
    Friend WithEvents BtnDefault As Button
    Friend WithEvents LblSteps As Label
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents GrpPresentation As GroupBox
    Friend WithEvents LblStretching As Label
    Friend WithEvents TxtxStretching As TextBox
    Friend WithEvents LblxStretching As Label
    Friend WithEvents OptSingleOrbit As RadioButton
    Friend WithEvents OptDifference As RadioButton
    Friend WithEvents TxtStartValue2 As TextBox
    Friend WithEvents LblStartValue2 As Label
    Friend WithEvents TxtStartValue1 As TextBox
    Friend WithEvents LblStartValue1 As Label
End Class
