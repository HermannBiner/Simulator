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
        LblNumberOfSteps = New Label()
        GrpTargetValue = New GroupBox()
        BtnTransitiveStartValue = New Button()
        TxtTargetValue = New TextBox()
        LblTargetValue = New Label()
        GrpProtocol = New GroupBox()
        BtnProtocolStartvalue = New Button()
        TxtTargetProtocol = New TextBox()
        TxtParameterA = New TextBox()
        TxtStartValue = New TextBox()
        CboFunction = New ComboBox()
        LblIterationDepth = New Label()
        CboIterationDepth = New ComboBox()
        LblSteps = New Label()
        LblXValues = New Label()
        LblLog = New Label()
        GrpPresentation = New GroupBox()
        LblStretching = New Label()
        TxtXStretching = New TextBox()
        LblxStretching = New Label()
        OptTimeAxis = New RadioButton()
        OptFunctionGraph = New RadioButton()
        TrbParameterA = New TrackBar()
        LblParameterA = New Label()
        BtnDefault = New Button()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        GrpStep.SuspendLayout()
        GrpTargetValue.SuspendLayout()
        GrpProtocol.SuspendLayout()
        GrpPresentation.SuspendLayout()
        CType(TrbParameterA, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(12, 38)
        PicDiagram.Margin = New Padding(4, 4, 4, 4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(530, 530)
        PicDiagram.TabIndex = 0
        PicDiagram.TabStop = False
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(715, 538)
        BtnReset.Margin = New Padding(4, 4, 4, 4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(267, 30)
        BtnReset.TabIndex = 17
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' LblParameter
        ' 
        LblParameter.AutoSize = True
        LblParameter.Font = New Font("Microsoft Sans Serif", 9F)
        LblParameter.Location = New Point(765, 55)
        LblParameter.Margin = New Padding(4, 0, 4, 0)
        LblParameter.Name = "LblParameter"
        LblParameter.Size = New Size(24, 15)
        LblParameter.TabIndex = 5
        LblParameter.Text = "a ="
        ' 
        ' LblStartValue
        ' 
        LblStartValue.AutoSize = True
        LblStartValue.Font = New Font("Microsoft Sans Serif", 9F)
        LblStartValue.Location = New Point(715, 82)
        LblStartValue.Margin = New Padding(4, 0, 4, 0)
        LblStartValue.Name = "LblStartValue"
        LblStartValue.Size = New Size(76, 15)
        LblStartValue.TabIndex = 7
        LblStartValue.Text = "StartValue = "
        ' 
        ' BtnNextStep
        ' 
        BtnNextStep.Font = New Font("Microsoft Sans Serif", 9F)
        BtnNextStep.Location = New Point(6, 22)
        BtnNextStep.Margin = New Padding(4, 4, 4, 4)
        BtnNextStep.Name = "BtnNextStep"
        BtnNextStep.Size = New Size(255, 30)
        BtnNextStep.TabIndex = 3
        BtnNextStep.Text = "NextStep"
        BtnNextStep.UseVisualStyleBackColor = True
        ' 
        ' BtnNext10Steps
        ' 
        BtnNext10Steps.Font = New Font("Microsoft Sans Serif", 9F)
        BtnNext10Steps.Location = New Point(8, 60)
        BtnNext10Steps.Margin = New Padding(4, 4, 4, 4)
        BtnNext10Steps.Name = "BtnNext10Steps"
        BtnNext10Steps.Size = New Size(255, 30)
        BtnNext10Steps.TabIndex = 4
        BtnNext10Steps.Text = "Next10Steps"
        BtnNext10Steps.UseVisualStyleBackColor = True
        ' 
        ' LstValueList
        ' 
        LstValueList.Font = New Font("Microsoft Sans Serif", 9F)
        LstValueList.FormattingEnabled = True
        LstValueList.ItemHeight = 15
        LstValueList.Location = New Point(549, 38)
        LstValueList.Margin = New Padding(4, 4, 4, 4)
        LstValueList.Name = "LstValueList"
        LstValueList.ScrollAlwaysVisible = True
        LstValueList.Size = New Size(95, 529)
        LstValueList.TabIndex = 14
        ' 
        ' LstProtocol
        ' 
        LstProtocol.Font = New Font("Microsoft Sans Serif", 9F)
        LstProtocol.FormattingEnabled = True
        LstProtocol.ItemHeight = 15
        LstProtocol.Location = New Point(652, 38)
        LstProtocol.Margin = New Padding(4, 4, 4, 4)
        LstProtocol.Name = "LstProtocol"
        LstProtocol.ScrollAlwaysVisible = True
        LstProtocol.Size = New Size(55, 529)
        LstProtocol.TabIndex = 15
        ' 
        ' GrpStep
        ' 
        GrpStep.Controls.Add(BtnNextStep)
        GrpStep.Controls.Add(BtnNext10Steps)
        GrpStep.Font = New Font("Microsoft Sans Serif", 9F)
        GrpStep.Location = New Point(715, 382)
        GrpStep.Margin = New Padding(4, 4, 4, 4)
        GrpStep.Name = "GrpStep"
        GrpStep.Padding = New Padding(4, 4, 4, 4)
        GrpStep.Size = New Size(267, 100)
        GrpStep.TabIndex = 17
        GrpStep.TabStop = False
        GrpStep.Text = "Iteration"
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblNumberOfSteps.Location = New Point(715, 485)
        LblNumberOfSteps.Margin = New Padding(4, 0, 4, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(95, 15)
        LblNumberOfSteps.TabIndex = 7
        LblNumberOfSteps.Text = "NumberOfSteps"
        ' 
        ' GrpTargetValue
        ' 
        GrpTargetValue.Controls.Add(BtnTransitiveStartValue)
        GrpTargetValue.Controls.Add(TxtTargetValue)
        GrpTargetValue.Controls.Add(LblTargetValue)
        GrpTargetValue.Font = New Font("Microsoft Sans Serif", 9F)
        GrpTargetValue.Location = New Point(714, 288)
        GrpTargetValue.Margin = New Padding(4, 4, 4, 4)
        GrpTargetValue.Name = "GrpTargetValue"
        GrpTargetValue.Padding = New Padding(4, 4, 4, 4)
        GrpTargetValue.Size = New Size(267, 85)
        GrpTargetValue.TabIndex = 11
        GrpTargetValue.TabStop = False
        GrpTargetValue.Text = "Transitivity"
        ' 
        ' BtnTransitiveStartValue
        ' 
        BtnTransitiveStartValue.Font = New Font("Microsoft Sans Serif", 9F)
        BtnTransitiveStartValue.Location = New Point(8, 44)
        BtnTransitiveStartValue.Margin = New Padding(4, 4, 4, 4)
        BtnTransitiveStartValue.Name = "BtnTransitiveStartValue"
        BtnTransitiveStartValue.Size = New Size(255, 30)
        BtnTransitiveStartValue.TabIndex = 13
        BtnTransitiveStartValue.Text = "StartvalueForTargetvalue"
        BtnTransitiveStartValue.UseVisualStyleBackColor = True
        ' 
        ' TxtTargetValue
        ' 
        TxtTargetValue.Font = New Font("Microsoft Sans Serif", 9F)
        TxtTargetValue.Location = New Point(102, 19)
        TxtTargetValue.Margin = New Padding(4, 4, 4, 4)
        TxtTargetValue.Name = "TxtTargetValue"
        TxtTargetValue.Size = New Size(162, 21)
        TxtTargetValue.TabIndex = 12
        ' 
        ' LblTargetValue
        ' 
        LblTargetValue.AutoSize = True
        LblTargetValue.Font = New Font("Microsoft Sans Serif", 9F)
        LblTargetValue.Location = New Point(8, 18)
        LblTargetValue.Margin = New Padding(4, 0, 4, 0)
        LblTargetValue.Name = "LblTargetValue"
        LblTargetValue.Size = New Size(86, 15)
        LblTargetValue.TabIndex = 17
        LblTargetValue.Text = "TargetValue = "
        ' 
        ' GrpProtocol
        ' 
        GrpProtocol.Controls.Add(BtnProtocolStartvalue)
        GrpProtocol.Controls.Add(TxtTargetProtocol)
        GrpProtocol.Font = New Font("Microsoft Sans Serif", 9F)
        GrpProtocol.Location = New Point(715, 187)
        GrpProtocol.Margin = New Padding(4, 4, 4, 4)
        GrpProtocol.Name = "GrpProtocol"
        GrpProtocol.Padding = New Padding(4, 4, 4, 4)
        GrpProtocol.Size = New Size(267, 94)
        GrpProtocol.TabIndex = 9
        GrpProtocol.TabStop = False
        GrpProtocol.Text = "TargetProtocol"
        ' 
        ' BtnProtocolStartvalue
        ' 
        BtnProtocolStartvalue.Font = New Font("Microsoft Sans Serif", 9F)
        BtnProtocolStartvalue.Location = New Point(8, 50)
        BtnProtocolStartvalue.Margin = New Padding(4, 4, 4, 4)
        BtnProtocolStartvalue.Name = "BtnProtocolStartvalue"
        BtnProtocolStartvalue.Size = New Size(255, 30)
        BtnProtocolStartvalue.TabIndex = 8
        BtnProtocolStartvalue.Text = "StartvalueForProtocol"
        BtnProtocolStartvalue.UseVisualStyleBackColor = True
        ' 
        ' TxtTargetProtocol
        ' 
        TxtTargetProtocol.Location = New Point(8, 26)
        TxtTargetProtocol.Margin = New Padding(4, 4, 4, 4)
        TxtTargetProtocol.Name = "TxtTargetProtocol"
        TxtTargetProtocol.Size = New Size(255, 21)
        TxtTargetProtocol.TabIndex = 10
        ' 
        ' TxtParameterA
        ' 
        TxtParameterA.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TxtParameterA.Location = New Point(798, 55)
        TxtParameterA.Margin = New Padding(4, 4, 4, 4)
        TxtParameterA.Name = "TxtParameterA"
        TxtParameterA.Size = New Size(183, 21)
        TxtParameterA.TabIndex = 2
        ' 
        ' TxtStartValue
        ' 
        TxtStartValue.Font = New Font("Microsoft Sans Serif", 9F)
        TxtStartValue.Location = New Point(798, 79)
        TxtStartValue.Margin = New Padding(4, 4, 4, 4)
        TxtStartValue.Name = "TxtStartValue"
        TxtStartValue.Size = New Size(183, 21)
        TxtStartValue.TabIndex = 4
        ' 
        ' CboFunction
        ' 
        CboFunction.Font = New Font("Microsoft Sans Serif", 9F)
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic Growth", "Parabola"})
        CboFunction.Location = New Point(12, 10)
        CboFunction.Margin = New Padding(4, 4, 4, 4)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(259, 23)
        CboFunction.TabIndex = 1
        ' 
        ' LblIterationDepth
        ' 
        LblIterationDepth.AutoSize = True
        LblIterationDepth.Font = New Font("Microsoft Sans Serif", 9F)
        LblIterationDepth.Location = New Point(278, 10)
        LblIterationDepth.Margin = New Padding(4, 0, 4, 0)
        LblIterationDepth.Name = "LblIterationDepth"
        LblIterationDepth.Size = New Size(84, 15)
        LblIterationDepth.TabIndex = 23
        LblIterationDepth.Text = "IterationDepth"
        ' 
        ' CboIterationDepth
        ' 
        CboIterationDepth.Font = New Font("Microsoft Sans Serif", 9F)
        CboIterationDepth.FormattingEnabled = True
        CboIterationDepth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8"})
        CboIterationDepth.Location = New Point(370, 6)
        CboIterationDepth.Margin = New Padding(4, 4, 4, 4)
        CboIterationDepth.Name = "CboIterationDepth"
        CboIterationDepth.Size = New Size(43, 23)
        CboIterationDepth.TabIndex = 3
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblSteps.Location = New Point(818, 485)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(14, 15)
        LblSteps.TabIndex = 26
        LblSteps.Text = "0"
        ' 
        ' LblXValues
        ' 
        LblXValues.AutoSize = True
        LblXValues.Font = New Font("Microsoft Sans Serif", 9F)
        LblXValues.Location = New Point(549, 14)
        LblXValues.Margin = New Padding(4, 0, 4, 0)
        LblXValues.Name = "LblXValues"
        LblXValues.Size = New Size(52, 15)
        LblXValues.TabIndex = 27
        LblXValues.Text = "XValues"
        ' 
        ' LblLog
        ' 
        LblLog.AutoSize = True
        LblLog.Font = New Font("Microsoft Sans Serif", 9F)
        LblLog.Location = New Point(652, 14)
        LblLog.Margin = New Padding(4, 0, 4, 0)
        LblLog.Name = "LblLog"
        LblLog.Size = New Size(28, 15)
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
        GrpPresentation.Font = New Font("Microsoft Sans Serif", 9F)
        GrpPresentation.Location = New Point(715, 108)
        GrpPresentation.Margin = New Padding(4, 4, 4, 4)
        GrpPresentation.Name = "GrpPresentation"
        GrpPresentation.Padding = New Padding(4, 4, 4, 4)
        GrpPresentation.Size = New Size(267, 71)
        GrpPresentation.TabIndex = 34
        GrpPresentation.TabStop = False
        GrpPresentation.Text = "Presentation"
        ' 
        ' LblStretching
        ' 
        LblStretching.AutoSize = True
        LblStretching.Location = New Point(123, 47)
        LblStretching.Margin = New Padding(4, 0, 4, 0)
        LblStretching.Name = "LblStretching"
        LblStretching.Size = New Size(81, 15)
        LblStretching.TabIndex = 4
        LblStretching.Text = "DinStretching"
        ' 
        ' TxtXStretching
        ' 
        TxtXStretching.Location = New Point(210, 41)
        TxtXStretching.Margin = New Padding(4, 4, 4, 4)
        TxtXStretching.Name = "TxtXStretching"
        TxtXStretching.Size = New Size(50, 21)
        TxtXStretching.TabIndex = 3
        ' 
        ' LblxStretching
        ' 
        LblxStretching.AutoSize = True
        LblxStretching.Location = New Point(122, 18)
        LblxStretching.Margin = New Padding(4, 0, 4, 0)
        LblxStretching.Name = "LblxStretching"
        LblxStretching.Size = New Size(68, 15)
        LblxStretching.TabIndex = 2
        LblxStretching.Text = "xStretching"
        ' 
        ' OptTimeAxis
        ' 
        OptTimeAxis.AutoSize = True
        OptTimeAxis.Location = New Point(8, 49)
        OptTimeAxis.Margin = New Padding(4, 4, 4, 4)
        OptTimeAxis.Name = "OptTimeAxis"
        OptTimeAxis.Size = New Size(75, 19)
        OptTimeAxis.TabIndex = 1
        OptTimeAxis.Text = "TimeAxis"
        OptTimeAxis.UseVisualStyleBackColor = True
        ' 
        ' OptFunctionGraph
        ' 
        OptFunctionGraph.AutoSize = True
        OptFunctionGraph.Checked = True
        OptFunctionGraph.Location = New Point(8, 22)
        OptFunctionGraph.Margin = New Padding(4, 4, 4, 4)
        OptFunctionGraph.Name = "OptFunctionGraph"
        OptFunctionGraph.Size = New Size(105, 19)
        OptFunctionGraph.TabIndex = 0
        OptFunctionGraph.TabStop = True
        OptFunctionGraph.Text = "FunctionGraph"
        OptFunctionGraph.UseVisualStyleBackColor = True
        ' 
        ' TrbParameterA
        ' 
        TrbParameterA.Location = New Point(798, 10)
        TrbParameterA.Margin = New Padding(6, 6, 6, 6)
        TrbParameterA.Maximum = 1000
        TrbParameterA.Minimum = 1
        TrbParameterA.Name = "TrbParameterA"
        TrbParameterA.Size = New Size(183, 45)
        TrbParameterA.TabIndex = 35
        TrbParameterA.Value = 500
        ' 
        ' LblParameterA
        ' 
        LblParameterA.AutoSize = True
        LblParameterA.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblParameterA.Location = New Point(714, 10)
        LblParameterA.Margin = New Padding(4, 0, 4, 0)
        LblParameterA.Name = "LblParameterA"
        LblParameterA.Size = New Size(75, 15)
        LblParameterA.TabIndex = 36
        LblParameterA.Text = "Parameter a"
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(714, 504)
        BtnDefault.Margin = New Padding(4, 4, 4, 4)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(267, 30)
        BtnDefault.TabIndex = 37
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' FrmIteration
        ' 
        AutoScaleDimensions = New SizeF(9F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(993, 576)
        Controls.Add(BtnDefault)
        Controls.Add(LblParameterA)
        Controls.Add(TrbParameterA)
        Controls.Add(GrpPresentation)
        Controls.Add(LblLog)
        Controls.Add(GrpProtocol)
        Controls.Add(LblXValues)
        Controls.Add(LblSteps)
        Controls.Add(LblNumberOfSteps)
        Controls.Add(CboIterationDepth)
        Controls.Add(LblIterationDepth)
        Controls.Add(CboFunction)
        Controls.Add(TxtParameterA)
        Controls.Add(GrpTargetValue)
        Controls.Add(GrpStep)
        Controls.Add(TxtStartValue)
        Controls.Add(LstProtocol)
        Controls.Add(LstValueList)
        Controls.Add(LblStartValue)
        Controls.Add(LblParameter)
        Controls.Add(BtnReset)
        Controls.Add(PicDiagram)
        Font = New Font("Microsoft Sans Serif", 11.14F)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4, 4, 4, 4)
        Name = "FrmIteration"
        Text = "GrowthModels"
        WindowState = FormWindowState.Maximized
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        GrpStep.ResumeLayout(False)
        GrpTargetValue.ResumeLayout(False)
        GrpTargetValue.PerformLayout()
        GrpProtocol.ResumeLayout(False)
        GrpProtocol.PerformLayout()
        GrpPresentation.ResumeLayout(False)
        GrpPresentation.PerformLayout()
        CType(TrbParameterA, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents TxtParameterA As TextBox
    Friend WithEvents TxtStartValue As TextBox
    Friend WithEvents CboFunction As ComboBox
    Friend WithEvents LblIterationDepth As Label
    Friend WithEvents CboIterationDepth As ComboBox
    Friend WithEvents LblSteps As Label
    Friend WithEvents LblXValues As Label
    Friend WithEvents LblLog As Label
    Friend WithEvents GrpPresentation As GroupBox
    Friend WithEvents LblStretching As Label
    Friend WithEvents TxtXStretching As TextBox
    Friend WithEvents LblxStretching As Label
    Friend WithEvents OptTimeAxis As RadioButton
    Friend WithEvents OptFunctionGraph As RadioButton
    Friend WithEvents TrbParameterA As TrackBar
    Friend WithEvents LblParameterA As Label
    Friend WithEvents BtnDefault As Button
End Class
