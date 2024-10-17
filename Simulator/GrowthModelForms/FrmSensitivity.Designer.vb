<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSensitivity
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSensitivity))
        CboIterationDepth = New ComboBox()
        LblIterationDepth = New Label()
        CboFunction = New ComboBox()
        TxtParameter = New TextBox()
        LblParameter = New Label()
        PicDiagram = New PictureBox()
        LblValueList1 = New Label()
        LstValueList1 = New ListBox()
        LblValueList2 = New Label()
        LstValueList2 = New ListBox()
        TxtStartValue1 = New TextBox()
        LblStartValue1 = New Label()
        TxtStartValue2 = New TextBox()
        LblStartValue2 = New Label()
        GrpPresentation = New GroupBox()
        LblStretching = New Label()
        TxtxStretching = New TextBox()
        LblxStretching = New Label()
        OptSingleOrbit = New RadioButton()
        OptDifference = New RadioButton()
        BtnStart = New Button()
        BtnReset = New Button()
        LblSteps = New Label()
        LblNumberOfSteps = New Label()
        BtnDefault = New Button()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        GrpPresentation.SuspendLayout()
        SuspendLayout()
        ' 
        ' CboIterationDepth
        ' 
        CboIterationDepth.FormattingEnabled = True
        CboIterationDepth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        CboIterationDepth.Location = New Point(726, 13)
        CboIterationDepth.Margin = New Padding(4, 4, 4, 4)
        CboIterationDepth.Name = "CboIterationDepth"
        CboIterationDepth.Size = New Size(91, 40)
        CboIterationDepth.TabIndex = 27
        ' 
        ' LblIterationDepth
        ' 
        LblIterationDepth.AutoSize = True
        LblIterationDepth.Location = New Point(561, 19)
        LblIterationDepth.Margin = New Padding(4, 0, 4, 0)
        LblIterationDepth.Name = "LblIterationDepth"
        LblIterationDepth.Size = New Size(169, 32)
        LblIterationDepth.TabIndex = 29
        LblIterationDepth.Text = "IterationDepth"
        ' 
        ' CboFunction
        ' 
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic Growth", "Parabola"})
        CboFunction.Location = New Point(17, 13)
        CboFunction.Margin = New Padding(4, 4, 4, 4)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(286, 40)
        CboFunction.TabIndex = 25
        ' 
        ' TxtParameter
        ' 
        TxtParameter.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TxtParameter.Location = New Point(366, 13)
        TxtParameter.Margin = New Padding(4, 4, 4, 4)
        TxtParameter.Name = "TxtParameter"
        TxtParameter.Size = New Size(184, 32)
        TxtParameter.TabIndex = 26
        ' 
        ' LblParameter
        ' 
        LblParameter.AutoSize = True
        LblParameter.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblParameter.Location = New Point(314, 19)
        LblParameter.Margin = New Padding(4, 0, 4, 0)
        LblParameter.Name = "LblParameter"
        LblParameter.Size = New Size(43, 26)
        LblParameter.TabIndex = 28
        LblParameter.Text = "a ="
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(17, 77)
        PicDiagram.Margin = New Padding(4, 4, 4, 4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(1393, 1600)
        PicDiagram.TabIndex = 24
        PicDiagram.TabStop = False
        ' 
        ' LblValueList1
        ' 
        LblValueList1.AutoSize = True
        LblValueList1.Location = New Point(1434, 30)
        LblValueList1.Margin = New Padding(4, 0, 4, 0)
        LblValueList1.Name = "LblValueList1"
        LblValueList1.Size = New Size(120, 32)
        LblValueList1.TabIndex = 31
        LblValueList1.Text = "ValueList1"
        ' 
        ' LstValueList1
        ' 
        LstValueList1.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LstValueList1.FormattingEnabled = True
        LstValueList1.ItemHeight = 25
        LstValueList1.Location = New Point(1434, 77)
        LstValueList1.Margin = New Padding(4, 4, 4, 4)
        LstValueList1.Name = "LstValueList1"
        LstValueList1.ScrollAlwaysVisible = True
        LstValueList1.Size = New Size(275, 1579)
        LstValueList1.TabIndex = 30
        ' 
        ' LblValueList2
        ' 
        LblValueList2.AutoSize = True
        LblValueList2.Location = New Point(1720, 32)
        LblValueList2.Margin = New Padding(4, 0, 4, 0)
        LblValueList2.Name = "LblValueList2"
        LblValueList2.Size = New Size(120, 32)
        LblValueList2.TabIndex = 33
        LblValueList2.Text = "ValueList2"
        ' 
        ' LstValueList2
        ' 
        LstValueList2.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LstValueList2.FormattingEnabled = True
        LstValueList2.ItemHeight = 25
        LstValueList2.Location = New Point(1720, 77)
        LstValueList2.Margin = New Padding(4, 4, 4, 4)
        LstValueList2.Name = "LstValueList2"
        LstValueList2.ScrollAlwaysVisible = True
        LstValueList2.Size = New Size(275, 1579)
        LstValueList2.TabIndex = 32
        ' 
        ' TxtStartValue1
        ' 
        TxtStartValue1.Location = New Point(2186, 32)
        TxtStartValue1.Margin = New Padding(4, 4, 4, 4)
        TxtStartValue1.Name = "TxtStartValue1"
        TxtStartValue1.Size = New Size(461, 39)
        TxtStartValue1.TabIndex = 34
        ' 
        ' LblStartValue1
        ' 
        LblStartValue1.AutoSize = True
        LblStartValue1.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblStartValue1.Location = New Point(2024, 41)
        LblStartValue1.Margin = New Padding(4, 0, 4, 0)
        LblStartValue1.Name = "LblStartValue1"
        LblStartValue1.Size = New Size(126, 26)
        LblStartValue1.TabIndex = 35
        LblStartValue1.Text = "StartValue1"
        ' 
        ' TxtStartValue2
        ' 
        TxtStartValue2.Location = New Point(2186, 111)
        TxtStartValue2.Margin = New Padding(4, 4, 4, 4)
        TxtStartValue2.Name = "TxtStartValue2"
        TxtStartValue2.Size = New Size(453, 39)
        TxtStartValue2.TabIndex = 36
        ' 
        ' LblStartValue2
        ' 
        LblStartValue2.AutoSize = True
        LblStartValue2.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblStartValue2.Location = New Point(2024, 119)
        LblStartValue2.Margin = New Padding(4, 0, 4, 0)
        LblStartValue2.Name = "LblStartValue2"
        LblStartValue2.Size = New Size(126, 26)
        LblStartValue2.TabIndex = 37
        LblStartValue2.Text = "StartValue2"
        ' 
        ' GrpPresentation
        ' 
        GrpPresentation.Controls.Add(LblStretching)
        GrpPresentation.Controls.Add(TxtxStretching)
        GrpPresentation.Controls.Add(LblxStretching)
        GrpPresentation.Controls.Add(OptSingleOrbit)
        GrpPresentation.Controls.Add(OptDifference)
        GrpPresentation.Location = New Point(2048, 205)
        GrpPresentation.Margin = New Padding(4, 4, 4, 4)
        GrpPresentation.Name = "GrpPresentation"
        GrpPresentation.Padding = New Padding(4, 4, 4, 4)
        GrpPresentation.Size = New Size(602, 205)
        GrpPresentation.TabIndex = 38
        GrpPresentation.TabStop = False
        GrpPresentation.Text = "Presentation"
        ' 
        ' LblStretching
        ' 
        LblStretching.AutoSize = True
        LblStretching.Location = New Point(303, 139)
        LblStretching.Margin = New Padding(4, 0, 4, 0)
        LblStretching.Name = "LblStretching"
        LblStretching.Size = New Size(159, 32)
        LblStretching.TabIndex = 4
        LblStretching.Text = "DinStretching"
        ' 
        ' TxtxStretching
        ' 
        TxtxStretching.Location = New Point(440, 128)
        TxtxStretching.Margin = New Padding(4, 4, 4, 4)
        TxtxStretching.Name = "TxtxStretching"
        TxtxStretching.Size = New Size(130, 39)
        TxtxStretching.TabIndex = 3
        ' 
        ' LblxStretching
        ' 
        LblxStretching.AutoSize = True
        LblxStretching.Location = New Point(303, 58)
        LblxStretching.Margin = New Padding(4, 0, 4, 0)
        LblxStretching.Name = "LblxStretching"
        LblxStretching.Size = New Size(133, 32)
        LblxStretching.TabIndex = 2
        LblxStretching.Text = "xStretching"
        ' 
        ' OptSingleOrbit
        ' 
        OptSingleOrbit.AutoSize = True
        OptSingleOrbit.Location = New Point(26, 130)
        OptSingleOrbit.Margin = New Padding(4, 4, 4, 4)
        OptSingleOrbit.Name = "OptSingleOrbit"
        OptSingleOrbit.Size = New Size(175, 36)
        OptSingleOrbit.TabIndex = 1
        OptSingleOrbit.Text = "SingleOrbits"
        OptSingleOrbit.UseVisualStyleBackColor = True
        ' 
        ' OptDifference
        ' 
        OptDifference.AutoSize = True
        OptDifference.Checked = True
        OptDifference.Location = New Point(26, 53)
        OptDifference.Margin = New Padding(4, 4, 4, 4)
        OptDifference.Name = "OptDifference"
        OptDifference.Size = New Size(182, 36)
        OptDifference.TabIndex = 0
        OptDifference.TabStop = True
        OptDifference.Text = "Difference12"
        OptDifference.UseVisualStyleBackColor = True
        ' 
        ' BtnStart
        ' 
        BtnStart.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BtnStart.Location = New Point(2048, 512)
        BtnStart.Margin = New Padding(4, 4, 4, 4)
        BtnStart.Name = "BtnStart"
        BtnStart.Size = New Size(594, 73)
        BtnStart.TabIndex = 39
        BtnStart.Text = "Start"
        BtnStart.UseVisualStyleBackColor = True
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BtnReset.Location = New Point(2048, 1594)
        BtnReset.Margin = New Padding(4, 4, 4, 4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(594, 73)
        BtnReset.TabIndex = 40
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Location = New Point(2236, 457)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(27, 32)
        LblSteps.TabIndex = 42
        LblSteps.Text = "0"
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblNumberOfSteps.Location = New Point(2048, 457)
        LblNumberOfSteps.Margin = New Padding(4, 0, 4, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(169, 26)
        LblNumberOfSteps.TabIndex = 41
        LblNumberOfSteps.Text = "NumberOfSteps"
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BtnDefault.Location = New Point(2048, 1513)
        BtnDefault.Margin = New Padding(4, 4, 4, 4)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(594, 73)
        BtnDefault.TabIndex = 43
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' FrmSensitivity
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(2663, 1707)
        Controls.Add(BtnDefault)
        Controls.Add(LblSteps)
        Controls.Add(LblNumberOfSteps)
        Controls.Add(BtnReset)
        Controls.Add(BtnStart)
        Controls.Add(GrpPresentation)
        Controls.Add(TxtStartValue2)
        Controls.Add(LblStartValue2)
        Controls.Add(TxtStartValue1)
        Controls.Add(LblStartValue1)
        Controls.Add(LblValueList2)
        Controls.Add(LstValueList2)
        Controls.Add(LblValueList1)
        Controls.Add(LstValueList1)
        Controls.Add(CboIterationDepth)
        Controls.Add(LblIterationDepth)
        Controls.Add(CboFunction)
        Controls.Add(TxtParameter)
        Controls.Add(LblParameter)
        Controls.Add(PicDiagram)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4, 4, 4, 4)
        Name = "FrmSensitivity"
        Text = "Sensitivity"
        WindowState = FormWindowState.Maximized
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        GrpPresentation.ResumeLayout(False)
        GrpPresentation.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents CboIterationDepth As ComboBox
    Friend WithEvents LblIterationDepth As Label
    Friend WithEvents CboFunction As ComboBox
    Friend WithEvents TxtParameter As TextBox
    Friend WithEvents LblParameter As Label
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents LblValueList1 As Label
    Friend WithEvents LstValueList1 As ListBox
    Friend WithEvents LblValueList2 As Label
    Friend WithEvents LstValueList2 As ListBox
    Friend WithEvents TxtStartValue1 As TextBox
    Friend WithEvents LblStartValue1 As Label
    Friend WithEvents TxtStartValue2 As TextBox
    Friend WithEvents LblStartValue2 As Label
    Friend WithEvents GrpPresentation As GroupBox
    Friend WithEvents LblStretching As Label
    Friend WithEvents TxtxStretching As TextBox
    Friend WithEvents LblxStretching As Label
    Friend WithEvents OptSingleOrbit As RadioButton
    Friend WithEvents OptDifference As RadioButton
    Friend WithEvents BtnStart As Button
    Friend WithEvents BtnReset As Button
    Friend WithEvents LblSteps As Label
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents BtnDefault As Button
End Class
