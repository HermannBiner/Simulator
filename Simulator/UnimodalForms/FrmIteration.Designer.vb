<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmIteration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIteration))
        PicDiagram = New PictureBox()
        BtnReset = New Button()
        LblParameter = New Label()
        LblStartValue = New Label()
        BtnNextStep = New Button()
        BtnNext10Steps = New Button()
        LstValueList = New ListBox()
        LstProtocol = New ListBox()
        GrpStep = New GroupBox()
        LblSteps = New Label()
        GrpTargetValue = New GroupBox()
        BtnTransitiveStartValue = New Button()
        TxtTargetValue = New TextBox()
        LblTargetValue = New Label()
        GrpProtocol = New GroupBox()
        BtnProtocolStartvalue = New Button()
        TxtTargetProtocol = New TextBox()
        TxtParameter = New TextBox()
        TxtStartValue = New TextBox()
        CboFunction = New ComboBox()
        BtnDrawDiagram = New Button()
        LblIterationDepth = New Label()
        CboIterationDepth = New ComboBox()
        LblNumberOfSteps = New Label()
        LblXValues = New Label()
        LblLog = New Label()
        GrpPresentation = New GroupBox()
        LblStretching = New Label()
        TxtXStretching = New TextBox()
        LblxStretching = New Label()
        OptTimeAxis = New RadioButton()
        OptFunctionGraph = New RadioButton()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        GrpStep.SuspendLayout()
        GrpTargetValue.SuspendLayout()
        GrpProtocol.SuspendLayout()
        GrpPresentation.SuspendLayout()
        SuspendLayout()
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(9, 39)
        PicDiagram.Margin = New Padding(2)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(688, 667)
        PicDiagram.TabIndex = 0
        PicDiagram.TabStop = False
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BtnReset.Location = New Point(904, 669)
        BtnReset.Margin = New Padding(2)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(303, 37)
        BtnReset.TabIndex = 17
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' LblParameter
        ' 
        LblParameter.AutoSize = True
        LblParameter.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblParameter.Location = New Point(169, 12)
        LblParameter.Margin = New Padding(2, 0, 2, 0)
        LblParameter.Name = "LblParameter"
        LblParameter.Size = New Size(22, 13)
        LblParameter.TabIndex = 5
        LblParameter.Text = "a ="
        ' 
        ' LblStartValue
        ' 
        LblStartValue.AutoSize = True
        LblStartValue.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblStartValue.Location = New Point(894, 17)
        LblStartValue.Margin = New Padding(2, 0, 2, 0)
        LblStartValue.Name = "LblStartValue"
        LblStartValue.Size = New Size(68, 13)
        LblStartValue.TabIndex = 7
        LblStartValue.Text = "StartValue = "
        ' 
        ' BtnNextStep
        ' 
        BtnNextStep.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BtnNextStep.Location = New Point(7, 25)
        BtnNextStep.Margin = New Padding(2)
        BtnNextStep.Name = "BtnNextStep"
        BtnNextStep.Size = New Size(143, 37)
        BtnNextStep.TabIndex = 3
        BtnNextStep.Text = "NextStep"
        BtnNextStep.UseVisualStyleBackColor = True
        ' 
        ' BtnNext10Steps
        ' 
        BtnNext10Steps.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BtnNext10Steps.Location = New Point(166, 25)
        BtnNext10Steps.Margin = New Padding(2)
        BtnNext10Steps.Name = "BtnNext10Steps"
        BtnNext10Steps.Size = New Size(143, 37)
        BtnNext10Steps.TabIndex = 4
        BtnNext10Steps.Text = "Next10Steps"
        BtnNext10Steps.UseVisualStyleBackColor = True
        ' 
        ' LstValueList
        ' 
        LstValueList.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LstValueList.FormattingEnabled = True
        LstValueList.ItemHeight = 13
        LstValueList.Location = New Point(698, 39)
        LstValueList.Margin = New Padding(2)
        LstValueList.Name = "LstValueList"
        LstValueList.ScrollAlwaysVisible = True
        LstValueList.Size = New Size(133, 667)
        LstValueList.TabIndex = 14
        ' 
        ' LstProtocol
        ' 
        LstProtocol.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LstProtocol.FormattingEnabled = True
        LstProtocol.ItemHeight = 13
        LstProtocol.Location = New Point(835, 39)
        LstProtocol.Margin = New Padding(2)
        LstProtocol.Name = "LstProtocol"
        LstProtocol.ScrollAlwaysVisible = True
        LstProtocol.Size = New Size(42, 667)
        LstProtocol.TabIndex = 15
        ' 
        ' GrpStep
        ' 
        GrpStep.Controls.Add(BtnNextStep)
        GrpStep.Controls.Add(BtnNext10Steps)
        GrpStep.Location = New Point(898, 187)
        GrpStep.Margin = New Padding(2)
        GrpStep.Name = "GrpStep"
        GrpStep.Padding = New Padding(2)
        GrpStep.Size = New Size(328, 73)
        GrpStep.TabIndex = 17
        GrpStep.TabStop = False
        GrpStep.Text = "Iteration"
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblSteps.Location = New Point(894, 48)
        LblSteps.Margin = New Padding(2, 0, 2, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(82, 13)
        LblSteps.TabIndex = 7
        LblSteps.Text = "NumberOfSteps"
        ' 
        ' GrpTargetValue
        ' 
        GrpTargetValue.Controls.Add(BtnTransitiveStartValue)
        GrpTargetValue.Controls.Add(TxtTargetValue)
        GrpTargetValue.Controls.Add(LblTargetValue)
        GrpTargetValue.Location = New Point(898, 413)
        GrpTargetValue.Margin = New Padding(2)
        GrpTargetValue.Name = "GrpTargetValue"
        GrpTargetValue.Padding = New Padding(2)
        GrpTargetValue.Size = New Size(328, 108)
        GrpTargetValue.TabIndex = 11
        GrpTargetValue.TabStop = False
        GrpTargetValue.Text = "Transitivity"
        ' 
        ' BtnTransitiveStartValue
        ' 
        BtnTransitiveStartValue.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BtnTransitiveStartValue.Location = New Point(9, 55)
        BtnTransitiveStartValue.Margin = New Padding(2)
        BtnTransitiveStartValue.Name = "BtnTransitiveStartValue"
        BtnTransitiveStartValue.Size = New Size(303, 37)
        BtnTransitiveStartValue.TabIndex = 13
        BtnTransitiveStartValue.Text = "StartvalueForTargetvalue"
        BtnTransitiveStartValue.UseVisualStyleBackColor = True
        ' 
        ' TxtTargetValue
        ' 
        TxtTargetValue.Location = New Point(90, 23)
        TxtTargetValue.Margin = New Padding(2)
        TxtTargetValue.Name = "TxtTargetValue"
        TxtTargetValue.Size = New Size(223, 23)
        TxtTargetValue.TabIndex = 12
        ' 
        ' LblTargetValue
        ' 
        LblTargetValue.AutoSize = True
        LblTargetValue.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblTargetValue.Location = New Point(5, 28)
        LblTargetValue.Margin = New Padding(2, 0, 2, 0)
        LblTargetValue.Name = "LblTargetValue"
        LblTargetValue.Size = New Size(77, 13)
        LblTargetValue.TabIndex = 17
        LblTargetValue.Text = "TargetValue = "
        ' 
        ' GrpProtocol
        ' 
        GrpProtocol.Controls.Add(BtnProtocolStartvalue)
        GrpProtocol.Controls.Add(TxtTargetProtocol)
        GrpProtocol.Location = New Point(898, 277)
        GrpProtocol.Margin = New Padding(2)
        GrpProtocol.Name = "GrpProtocol"
        GrpProtocol.Padding = New Padding(2)
        GrpProtocol.Size = New Size(328, 119)
        GrpProtocol.TabIndex = 9
        GrpProtocol.TabStop = False
        GrpProtocol.Text = "TargetProtocol"
        ' 
        ' BtnProtocolStartvalue
        ' 
        BtnProtocolStartvalue.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BtnProtocolStartvalue.Location = New Point(7, 62)
        BtnProtocolStartvalue.Margin = New Padding(2)
        BtnProtocolStartvalue.Name = "BtnProtocolStartvalue"
        BtnProtocolStartvalue.Size = New Size(305, 37)
        BtnProtocolStartvalue.TabIndex = 8
        BtnProtocolStartvalue.Text = "StartvalueForProtocol"
        BtnProtocolStartvalue.UseVisualStyleBackColor = True
        ' 
        ' TxtTargetProtocol
        ' 
        TxtTargetProtocol.Location = New Point(9, 25)
        TxtTargetProtocol.Margin = New Padding(2)
        TxtTargetProtocol.Name = "TxtTargetProtocol"
        TxtTargetProtocol.Size = New Size(304, 23)
        TxtTargetProtocol.TabIndex = 10
        ' 
        ' TxtParameter
        ' 
        TxtParameter.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TxtParameter.Location = New Point(198, 9)
        TxtParameter.Margin = New Padding(2)
        TxtParameter.Name = "TxtParameter"
        TxtParameter.Size = New Size(101, 20)
        TxtParameter.TabIndex = 2
        ' 
        ' TxtStartValue
        ' 
        TxtStartValue.Location = New Point(967, 14)
        TxtStartValue.Margin = New Padding(2)
        TxtStartValue.Name = "TxtStartValue"
        TxtStartValue.Size = New Size(241, 23)
        TxtStartValue.TabIndex = 4
        ' 
        ' CboFunction
        ' 
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic Growth", "Parabola"})
        CboFunction.Location = New Point(9, 9)
        CboFunction.Margin = New Padding(2)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(156, 23)
        CboFunction.TabIndex = 1
        ' 
        ' BtnDrawDiagram
        ' 
        BtnDrawDiagram.Location = New Point(457, 7)
        BtnDrawDiagram.Margin = New Padding(2)
        BtnDrawDiagram.Name = "BtnDrawDiagram"
        BtnDrawDiagram.Size = New Size(240, 25)
        BtnDrawDiagram.TabIndex = 22
        BtnDrawDiagram.Text = "DrawFunctionGraph"
        BtnDrawDiagram.UseVisualStyleBackColor = True
        ' 
        ' LblIterationDepth
        ' 
        LblIterationDepth.AutoSize = True
        LblIterationDepth.Location = New Point(303, 12)
        LblIterationDepth.Margin = New Padding(2, 0, 2, 0)
        LblIterationDepth.Name = "LblIterationDepth"
        LblIterationDepth.Size = New Size(83, 15)
        LblIterationDepth.TabIndex = 23
        LblIterationDepth.Text = "IterationDepth"
        ' 
        ' CboIterationDepth
        ' 
        CboIterationDepth.FormattingEnabled = True
        CboIterationDepth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        CboIterationDepth.Location = New Point(390, 9)
        CboIterationDepth.Margin = New Padding(2)
        CboIterationDepth.Name = "CboIterationDepth"
        CboIterationDepth.Size = New Size(51, 23)
        CboIterationDepth.TabIndex = 3
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Location = New Point(996, 48)
        LblNumberOfSteps.Margin = New Padding(2, 0, 2, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(13, 15)
        LblNumberOfSteps.TabIndex = 26
        LblNumberOfSteps.Text = "0"
        ' 
        ' LblXValues
        ' 
        LblXValues.AutoSize = True
        LblXValues.Location = New Point(709, 15)
        LblXValues.Margin = New Padding(2, 0, 2, 0)
        LblXValues.Name = "LblXValues"
        LblXValues.Size = New Size(47, 15)
        LblXValues.TabIndex = 27
        LblXValues.Text = "XValues"
        ' 
        ' LblLog
        ' 
        LblLog.AutoSize = True
        LblLog.Location = New Point(822, 17)
        LblLog.Margin = New Padding(2, 0, 2, 0)
        LblLog.Name = "LblLog"
        LblLog.Size = New Size(27, 15)
        LblLog.TabIndex = 28
        LblLog.Text = "Log"
        ' 
        ' GrpPresentation
        ' 
        GrpPresentation.Controls.Add(LblStretching)
        GrpPresentation.Controls.Add(TxtXStretching)
        GrpPresentation.Controls.Add(LblxStretching)
        GrpPresentation.Controls.Add(OptTimeAxis)
        GrpPresentation.Controls.Add(OptFunctionGraph)
        GrpPresentation.Location = New Point(898, 75)
        GrpPresentation.Margin = New Padding(2)
        GrpPresentation.Name = "GrpPresentation"
        GrpPresentation.Padding = New Padding(2)
        GrpPresentation.Size = New Size(324, 96)
        GrpPresentation.TabIndex = 34
        GrpPresentation.TabStop = False
        GrpPresentation.Text = "Presentation"
        ' 
        ' LblStretching
        ' 
        LblStretching.AutoSize = True
        LblStretching.Location = New Point(163, 65)
        LblStretching.Margin = New Padding(2, 0, 2, 0)
        LblStretching.Name = "LblStretching"
        LblStretching.Size = New Size(79, 15)
        LblStretching.TabIndex = 4
        LblStretching.Text = "DinStretching"
        ' 
        ' TxtXStretching
        ' 
        TxtXStretching.Location = New Point(237, 60)
        TxtXStretching.Margin = New Padding(2)
        TxtXStretching.Name = "TxtXStretching"
        TxtXStretching.Size = New Size(72, 23)
        TxtXStretching.TabIndex = 3
        ' 
        ' LblxStretching
        ' 
        LblxStretching.AutoSize = True
        LblxStretching.Location = New Point(163, 27)
        LblxStretching.Margin = New Padding(2, 0, 2, 0)
        LblxStretching.Name = "LblxStretching"
        LblxStretching.Size = New Size(67, 15)
        LblxStretching.TabIndex = 2
        LblxStretching.Text = "xStretching"
        ' 
        ' OptTimeAxis
        ' 
        OptTimeAxis.AutoSize = True
        OptTimeAxis.Location = New Point(14, 61)
        OptTimeAxis.Margin = New Padding(2)
        OptTimeAxis.Name = "OptTimeAxis"
        OptTimeAxis.Size = New Size(73, 19)
        OptTimeAxis.TabIndex = 1
        OptTimeAxis.Text = "TimeAxis"
        OptTimeAxis.UseVisualStyleBackColor = True
        ' 
        ' OptFunctionGraph
        ' 
        OptFunctionGraph.AutoSize = True
        OptFunctionGraph.Checked = True
        OptFunctionGraph.Location = New Point(14, 25)
        OptFunctionGraph.Margin = New Padding(2)
        OptFunctionGraph.Name = "OptFunctionGraph"
        OptFunctionGraph.Size = New Size(104, 19)
        OptFunctionGraph.TabIndex = 0
        OptFunctionGraph.TabStop = True
        OptFunctionGraph.Text = "FunctionGraph"
        OptFunctionGraph.UseVisualStyleBackColor = True
        ' 
        ' FrmIteration
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1249, 708)
        Controls.Add(GrpPresentation)
        Controls.Add(LblLog)
        Controls.Add(LblXValues)
        Controls.Add(LblNumberOfSteps)
        Controls.Add(LblSteps)
        Controls.Add(CboIterationDepth)
        Controls.Add(LblIterationDepth)
        Controls.Add(BtnDrawDiagram)
        Controls.Add(CboFunction)
        Controls.Add(TxtParameter)
        Controls.Add(GrpProtocol)
        Controls.Add(GrpTargetValue)
        Controls.Add(GrpStep)
        Controls.Add(TxtStartValue)
        Controls.Add(LstProtocol)
        Controls.Add(LstValueList)
        Controls.Add(LblStartValue)
        Controls.Add(LblParameter)
        Controls.Add(BtnReset)
        Controls.Add(PicDiagram)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(2)
        Name = "FrmIteration"
        Text = "UnimodalFunctions"
        WindowState = FormWindowState.Maximized
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        GrpStep.ResumeLayout(False)
        GrpTargetValue.ResumeLayout(False)
        GrpTargetValue.PerformLayout()
        GrpProtocol.ResumeLayout(False)
        GrpProtocol.PerformLayout()
        GrpPresentation.ResumeLayout(False)
        GrpPresentation.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents BtnReset As Button
    Friend WithEvents LblParameter As Label
    Friend WithEvents LblStartValue As Label
    Friend WithEvents BtnNextStep As Button
    Friend WithEvents BtnNext10Steps As Button
    Friend WithEvents LstValueList As ListBox
    Friend WithEvents LstProtocol As ListBox
    Friend WithEvents GrpStep As GroupBox
    Friend WithEvents GrpTargetValue As GroupBox
    Friend WithEvents BtnTransitiveStartValue As Button
    Friend WithEvents TxtTargetValue As TextBox
    Friend WithEvents LblTargetValue As Label
    Friend WithEvents GrpProtocol As GroupBox
    Friend WithEvents BtnProtocolStartvalue As Button
    Friend WithEvents TxtTargetProtocol As TextBox
    Friend WithEvents LblSteps As Label
    Friend WithEvents TxtParameter As TextBox
    Friend WithEvents TxtStartValue As TextBox
    Friend WithEvents CboFunction As ComboBox
    Friend WithEvents BtnDrawDiagram As Button
    Friend WithEvents LblIterationDepth As Label
    Friend WithEvents CboIterationDepth As ComboBox
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents LblXValues As Label
    Friend WithEvents LblLog As Label
    Friend WithEvents GrpPresentation As GroupBox
    Friend WithEvents LblStretching As Label
    Friend WithEvents TxtXStretching As TextBox
    Friend WithEvents LblxStretching As Label
    Friend WithEvents OptTimeAxis As RadioButton
    Friend WithEvents OptFunctionGraph As RadioButton
End Class
