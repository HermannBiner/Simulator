<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIteration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIteration))
        SplitContainer1 = New SplitContainer()
        PicDiagram = New PictureBox()
        CboIterationDepth = New ComboBox()
        LblIterationDepth = New Label()
        CboFunction = New ComboBox()
        SplitContainer2 = New SplitContainer()
        LblLog = New Label()
        LblXValues = New Label()
        LstProtocol = New ListBox()
        LstValueList = New ListBox()
        BtnDefault = New Button()
        LblParameterA = New Label()
        TrbParameterA = New TrackBar()
        GrpPresentation = New GroupBox()
        LblStretching = New Label()
        TxtXStretching = New TextBox()
        LblxStretching = New Label()
        OptTimeAxis = New RadioButton()
        OptFunctionGraph = New RadioButton()
        GrpProtocol = New GroupBox()
        BtnProtocolStartvalue = New Button()
        TxtTargetProtocol = New TextBox()
        LblSteps = New Label()
        LblNumberOfSteps = New Label()
        TxtParameterA = New TextBox()
        GrpTargetValue = New GroupBox()
        BtnTransitiveStartValue = New Button()
        TxtTargetValue = New TextBox()
        LblTargetValue = New Label()
        GrpStep = New GroupBox()
        BtnNextStep = New Button()
        BtnNext10Steps = New Button()
        TxtStartValue = New TextBox()
        LblStartValue = New Label()
        LblParameter = New Label()
        BtnReset = New Button()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        CType(SplitContainer2, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer2.Panel1.SuspendLayout()
        SplitContainer2.Panel2.SuspendLayout()
        SplitContainer2.SuspendLayout()
        CType(TrbParameterA, ComponentModel.ISupportInitialize).BeginInit()
        GrpPresentation.SuspendLayout()
        GrpProtocol.SuspendLayout()
        GrpTargetValue.SuspendLayout()
        GrpStep.SuspendLayout()
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
        SplitContainer1.Panel1.Controls.Add(CboIterationDepth)
        SplitContainer1.Panel1.Controls.Add(LblIterationDepth)
        SplitContainer1.Panel1.Controls.Add(CboFunction)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(SplitContainer2)
        SplitContainer1.Size = New Size(1069, 576)
        SplitContainer1.SplitterDistance = 537
        SplitContainer1.SplitterWidth = 6
        SplitContainer1.TabIndex = 0
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.Location = New Point(4, 35)
        PicDiagram.Margin = New Padding(4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(530, 530)
        PicDiagram.TabIndex = 27
        PicDiagram.TabStop = False
        ' 
        ' CboIterationDepth
        ' 
        CboIterationDepth.DropDownStyle = ComboBoxStyle.DropDownList
        CboIterationDepth.Font = New Font("Microsoft Sans Serif", 9F)
        CboIterationDepth.FormattingEnabled = True
        CboIterationDepth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8"})
        CboIterationDepth.Location = New Point(362, 4)
        CboIterationDepth.Margin = New Padding(4)
        CboIterationDepth.Name = "CboIterationDepth"
        CboIterationDepth.Size = New Size(43, 23)
        CboIterationDepth.TabIndex = 25
        ' 
        ' LblIterationDepth
        ' 
        LblIterationDepth.AutoSize = True
        LblIterationDepth.Font = New Font("Microsoft Sans Serif", 9F)
        LblIterationDepth.Location = New Point(270, 4)
        LblIterationDepth.Margin = New Padding(4, 0, 4, 0)
        LblIterationDepth.Name = "LblIterationDepth"
        LblIterationDepth.Size = New Size(84, 15)
        LblIterationDepth.TabIndex = 26
        LblIterationDepth.Text = "IterationDepth"
        ' 
        ' CboFunction
        ' 
        CboFunction.DropDownStyle = ComboBoxStyle.DropDownList
        CboFunction.Font = New Font("Microsoft Sans Serif", 9F)
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic Growth", "Parabola"})
        CboFunction.Location = New Point(4, 4)
        CboFunction.Margin = New Padding(4)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(259, 23)
        CboFunction.TabIndex = 24
        ' 
        ' SplitContainer2
        ' 
        SplitContainer2.Dock = DockStyle.Fill
        SplitContainer2.Location = New Point(0, 0)
        SplitContainer2.Name = "SplitContainer2"
        ' 
        ' SplitContainer2.Panel1
        ' 
        SplitContainer2.Panel1.Controls.Add(LblLog)
        SplitContainer2.Panel1.Controls.Add(LblXValues)
        SplitContainer2.Panel1.Controls.Add(LstProtocol)
        SplitContainer2.Panel1.Controls.Add(LstValueList)
        ' 
        ' SplitContainer2.Panel2
        ' 
        SplitContainer2.Panel2.Controls.Add(BtnDefault)
        SplitContainer2.Panel2.Controls.Add(LblParameterA)
        SplitContainer2.Panel2.Controls.Add(TrbParameterA)
        SplitContainer2.Panel2.Controls.Add(GrpPresentation)
        SplitContainer2.Panel2.Controls.Add(GrpProtocol)
        SplitContainer2.Panel2.Controls.Add(LblSteps)
        SplitContainer2.Panel2.Controls.Add(LblNumberOfSteps)
        SplitContainer2.Panel2.Controls.Add(TxtParameterA)
        SplitContainer2.Panel2.Controls.Add(GrpTargetValue)
        SplitContainer2.Panel2.Controls.Add(GrpStep)
        SplitContainer2.Panel2.Controls.Add(TxtStartValue)
        SplitContainer2.Panel2.Controls.Add(LblStartValue)
        SplitContainer2.Panel2.Controls.Add(LblParameter)
        SplitContainer2.Panel2.Controls.Add(BtnReset)
        SplitContainer2.Size = New Size(526, 576)
        SplitContainer2.SplitterDistance = 173
        SplitContainer2.TabIndex = 0
        ' 
        ' LblLog
        ' 
        LblLog.AutoSize = True
        LblLog.Font = New Font("Microsoft Sans Serif", 9F)
        LblLog.Location = New Point(112, 12)
        LblLog.Margin = New Padding(4, 0, 4, 0)
        LblLog.Name = "LblLog"
        LblLog.Size = New Size(28, 15)
        LblLog.TabIndex = 32
        LblLog.Text = "Log"
        ' 
        ' LblXValues
        ' 
        LblXValues.AutoSize = True
        LblXValues.Font = New Font("Microsoft Sans Serif", 9F)
        LblXValues.Location = New Point(9, 12)
        LblXValues.Margin = New Padding(4, 0, 4, 0)
        LblXValues.Name = "LblXValues"
        LblXValues.Size = New Size(52, 15)
        LblXValues.TabIndex = 31
        LblXValues.Text = "XValues"
        ' 
        ' LstProtocol
        ' 
        LstProtocol.Font = New Font("Microsoft Sans Serif", 9F)
        LstProtocol.FormattingEnabled = True
        LstProtocol.ItemHeight = 15
        LstProtocol.Location = New Point(112, 36)
        LstProtocol.Margin = New Padding(4)
        LstProtocol.Name = "LstProtocol"
        LstProtocol.ScrollAlwaysVisible = True
        LstProtocol.Size = New Size(55, 529)
        LstProtocol.TabIndex = 30
        ' 
        ' LstValueList
        ' 
        LstValueList.Font = New Font("Microsoft Sans Serif", 9F)
        LstValueList.FormattingEnabled = True
        LstValueList.ItemHeight = 15
        LstValueList.Location = New Point(9, 36)
        LstValueList.Margin = New Padding(4)
        LstValueList.Name = "LstValueList"
        LstValueList.ScrollAlwaysVisible = True
        LstValueList.Size = New Size(95, 529)
        LstValueList.TabIndex = 29
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(2, 503)
        BtnDefault.Margin = New Padding(4)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(341, 30)
        BtnDefault.TabIndex = 51
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' LblParameterA
        ' 
        LblParameterA.AutoSize = True
        LblParameterA.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblParameterA.Location = New Point(2, 9)
        LblParameterA.Margin = New Padding(4, 0, 4, 0)
        LblParameterA.Name = "LblParameterA"
        LblParameterA.Size = New Size(75, 15)
        LblParameterA.TabIndex = 50
        LblParameterA.Text = "Parameter a"
        ' 
        ' TrbParameterA
        ' 
        TrbParameterA.Location = New Point(86, 9)
        TrbParameterA.Margin = New Padding(6)
        TrbParameterA.Maximum = 1000
        TrbParameterA.Minimum = 1
        TrbParameterA.Name = "TrbParameterA"
        TrbParameterA.Size = New Size(265, 45)
        TrbParameterA.TabIndex = 49
        TrbParameterA.Value = 500
        ' 
        ' GrpPresentation
        ' 
        GrpPresentation.Controls.Add(LblStretching)
        GrpPresentation.Controls.Add(TxtXStretching)
        GrpPresentation.Controls.Add(LblxStretching)
        GrpPresentation.Controls.Add(OptTimeAxis)
        GrpPresentation.Controls.Add(OptFunctionGraph)
        GrpPresentation.Font = New Font("Microsoft Sans Serif", 9F)
        GrpPresentation.Location = New Point(3, 107)
        GrpPresentation.Margin = New Padding(4)
        GrpPresentation.Name = "GrpPresentation"
        GrpPresentation.Padding = New Padding(4)
        GrpPresentation.Size = New Size(348, 71)
        GrpPresentation.TabIndex = 48
        GrpPresentation.TabStop = False
        GrpPresentation.Text = "Presentation"
        ' 
        ' LblStretching
        ' 
        LblStretching.AutoSize = True
        LblStretching.Location = New Point(181, 46)
        LblStretching.Margin = New Padding(4, 0, 4, 0)
        LblStretching.Name = "LblStretching"
        LblStretching.Size = New Size(81, 15)
        LblStretching.TabIndex = 4
        LblStretching.Text = "DinStretching"
        ' 
        ' TxtXStretching
        ' 
        TxtXStretching.Location = New Point(269, 42)
        TxtXStretching.Margin = New Padding(4)
        TxtXStretching.Name = "TxtXStretching"
        TxtXStretching.Size = New Size(71, 21)
        TxtXStretching.TabIndex = 3
        ' 
        ' LblxStretching
        ' 
        LblxStretching.AutoSize = True
        LblxStretching.Location = New Point(181, 23)
        LblxStretching.Margin = New Padding(4, 0, 4, 0)
        LblxStretching.Name = "LblxStretching"
        LblxStretching.Size = New Size(68, 15)
        LblxStretching.TabIndex = 2
        LblxStretching.Text = "xStretching"
        ' 
        ' OptTimeAxis
        ' 
        OptTimeAxis.AutoSize = True
        OptTimeAxis.Location = New Point(9, 50)
        OptTimeAxis.Margin = New Padding(4)
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
        OptFunctionGraph.Location = New Point(9, 23)
        OptFunctionGraph.Margin = New Padding(4)
        OptFunctionGraph.Name = "OptFunctionGraph"
        OptFunctionGraph.Size = New Size(106, 19)
        OptFunctionGraph.TabIndex = 0
        OptFunctionGraph.TabStop = True
        OptFunctionGraph.Text = "FunctionGraph"
        OptFunctionGraph.UseVisualStyleBackColor = True
        ' 
        ' GrpProtocol
        ' 
        GrpProtocol.Controls.Add(BtnProtocolStartvalue)
        GrpProtocol.Controls.Add(TxtTargetProtocol)
        GrpProtocol.Font = New Font("Microsoft Sans Serif", 9F)
        GrpProtocol.Location = New Point(3, 186)
        GrpProtocol.Margin = New Padding(4)
        GrpProtocol.Name = "GrpProtocol"
        GrpProtocol.Padding = New Padding(4)
        GrpProtocol.Size = New Size(348, 94)
        GrpProtocol.TabIndex = 43
        GrpProtocol.TabStop = False
        GrpProtocol.Text = "TargetProtocol"
        ' 
        ' BtnProtocolStartvalue
        ' 
        BtnProtocolStartvalue.Font = New Font("Microsoft Sans Serif", 9F)
        BtnProtocolStartvalue.Location = New Point(8, 50)
        BtnProtocolStartvalue.Margin = New Padding(4)
        BtnProtocolStartvalue.Name = "BtnProtocolStartvalue"
        BtnProtocolStartvalue.Size = New Size(332, 30)
        BtnProtocolStartvalue.TabIndex = 8
        BtnProtocolStartvalue.Text = "StartvalueForProtocol"
        BtnProtocolStartvalue.UseVisualStyleBackColor = True
        ' 
        ' TxtTargetProtocol
        ' 
        TxtTargetProtocol.Location = New Point(8, 26)
        TxtTargetProtocol.Margin = New Padding(4)
        TxtTargetProtocol.Name = "TxtTargetProtocol"
        TxtTargetProtocol.Size = New Size(332, 21)
        TxtTargetProtocol.TabIndex = 10
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblSteps.Location = New Point(106, 484)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(14, 15)
        LblSteps.TabIndex = 47
        LblSteps.Text = "0"
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Font = New Font("Microsoft Sans Serif", 9F)
        LblNumberOfSteps.Location = New Point(3, 484)
        LblNumberOfSteps.Margin = New Padding(4, 0, 4, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(95, 15)
        LblNumberOfSteps.TabIndex = 41
        LblNumberOfSteps.Text = "NumberOfSteps"
        ' 
        ' TxtParameterA
        ' 
        TxtParameterA.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TxtParameterA.Location = New Point(86, 54)
        TxtParameterA.Margin = New Padding(4)
        TxtParameterA.Name = "TxtParameterA"
        TxtParameterA.Size = New Size(257, 21)
        TxtParameterA.TabIndex = 38
        ' 
        ' GrpTargetValue
        ' 
        GrpTargetValue.Controls.Add(BtnTransitiveStartValue)
        GrpTargetValue.Controls.Add(TxtTargetValue)
        GrpTargetValue.Controls.Add(LblTargetValue)
        GrpTargetValue.Font = New Font("Microsoft Sans Serif", 9F)
        GrpTargetValue.Location = New Point(2, 287)
        GrpTargetValue.Margin = New Padding(4)
        GrpTargetValue.Name = "GrpTargetValue"
        GrpTargetValue.Padding = New Padding(4)
        GrpTargetValue.Size = New Size(349, 85)
        GrpTargetValue.TabIndex = 44
        GrpTargetValue.TabStop = False
        GrpTargetValue.Text = "Transitivity"
        ' 
        ' BtnTransitiveStartValue
        ' 
        BtnTransitiveStartValue.Font = New Font("Microsoft Sans Serif", 9F)
        BtnTransitiveStartValue.Location = New Point(8, 44)
        BtnTransitiveStartValue.Margin = New Padding(4)
        BtnTransitiveStartValue.Name = "BtnTransitiveStartValue"
        BtnTransitiveStartValue.Size = New Size(333, 30)
        BtnTransitiveStartValue.TabIndex = 13
        BtnTransitiveStartValue.Text = "StartvalueForTargetvalue"
        BtnTransitiveStartValue.UseVisualStyleBackColor = True
        ' 
        ' TxtTargetValue
        ' 
        TxtTargetValue.Font = New Font("Microsoft Sans Serif", 9F)
        TxtTargetValue.Location = New Point(102, 19)
        TxtTargetValue.Margin = New Padding(4)
        TxtTargetValue.Name = "TxtTargetValue"
        TxtTargetValue.Size = New Size(239, 21)
        TxtTargetValue.TabIndex = 12
        ' 
        ' LblTargetValue
        ' 
        LblTargetValue.AutoSize = True
        LblTargetValue.Font = New Font("Microsoft Sans Serif", 9F)
        LblTargetValue.Location = New Point(9, 19)
        LblTargetValue.Margin = New Padding(4, 0, 4, 0)
        LblTargetValue.Name = "LblTargetValue"
        LblTargetValue.Size = New Size(86, 15)
        LblTargetValue.TabIndex = 17
        LblTargetValue.Text = "TargetValue = "
        ' 
        ' GrpStep
        ' 
        GrpStep.Controls.Add(BtnNextStep)
        GrpStep.Controls.Add(BtnNext10Steps)
        GrpStep.Font = New Font("Microsoft Sans Serif", 9F)
        GrpStep.Location = New Point(3, 381)
        GrpStep.Margin = New Padding(4)
        GrpStep.Name = "GrpStep"
        GrpStep.Padding = New Padding(4)
        GrpStep.Size = New Size(348, 100)
        GrpStep.TabIndex = 45
        GrpStep.TabStop = False
        GrpStep.Text = "Iteration"
        ' 
        ' BtnNextStep
        ' 
        BtnNextStep.Font = New Font("Microsoft Sans Serif", 9F)
        BtnNextStep.Location = New Point(6, 22)
        BtnNextStep.Margin = New Padding(4)
        BtnNextStep.Name = "BtnNextStep"
        BtnNextStep.Size = New Size(334, 30)
        BtnNextStep.TabIndex = 3
        BtnNextStep.Text = "NextStep"
        BtnNextStep.UseVisualStyleBackColor = True
        ' 
        ' BtnNext10Steps
        ' 
        BtnNext10Steps.Font = New Font("Microsoft Sans Serif", 9F)
        BtnNext10Steps.Location = New Point(8, 60)
        BtnNext10Steps.Margin = New Padding(4)
        BtnNext10Steps.Name = "BtnNext10Steps"
        BtnNext10Steps.Size = New Size(332, 30)
        BtnNext10Steps.TabIndex = 4
        BtnNext10Steps.Text = "Next10Steps"
        BtnNext10Steps.UseVisualStyleBackColor = True
        ' 
        ' TxtStartValue
        ' 
        TxtStartValue.Font = New Font("Microsoft Sans Serif", 9F)
        TxtStartValue.Location = New Point(86, 78)
        TxtStartValue.Margin = New Padding(4)
        TxtStartValue.Name = "TxtStartValue"
        TxtStartValue.Size = New Size(257, 21)
        TxtStartValue.TabIndex = 39
        ' 
        ' LblStartValue
        ' 
        LblStartValue.AutoSize = True
        LblStartValue.Font = New Font("Microsoft Sans Serif", 9F)
        LblStartValue.Location = New Point(3, 81)
        LblStartValue.Margin = New Padding(4, 0, 4, 0)
        LblStartValue.Name = "LblStartValue"
        LblStartValue.Size = New Size(76, 15)
        LblStartValue.TabIndex = 42
        LblStartValue.Text = "StartValue = "
        ' 
        ' LblParameter
        ' 
        LblParameter.AutoSize = True
        LblParameter.Font = New Font("Microsoft Sans Serif", 9F)
        LblParameter.Location = New Point(53, 54)
        LblParameter.Margin = New Padding(4, 0, 4, 0)
        LblParameter.Name = "LblParameter"
        LblParameter.Size = New Size(24, 15)
        LblParameter.TabIndex = 40
        LblParameter.Text = "a ="
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(3, 537)
        BtnReset.Margin = New Padding(4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(340, 30)
        BtnReset.TabIndex = 46
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' FrmIteration
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1069, 576)
        Controls.Add(SplitContainer1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimumSize = New Size(615, 615)
        Name = "FrmIteration"
        StartPosition = FormStartPosition.WindowsDefaultBounds
        Text = "GrowthModels"
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
        CType(TrbParameterA, ComponentModel.ISupportInitialize).EndInit()
        GrpPresentation.ResumeLayout(False)
        GrpPresentation.PerformLayout()
        GrpProtocol.ResumeLayout(False)
        GrpProtocol.PerformLayout()
        GrpTargetValue.ResumeLayout(False)
        GrpTargetValue.PerformLayout()
        GrpStep.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents CboIterationDepth As ComboBox
    Friend WithEvents LblIterationDepth As Label
    Friend WithEvents CboFunction As ComboBox
    Friend WithEvents LblLog As Label
    Friend WithEvents LblXValues As Label
    Friend WithEvents LstProtocol As ListBox
    Friend WithEvents LstValueList As ListBox
    Friend WithEvents BtnDefault As Button
    Friend WithEvents LblParameterA As Label
    Friend WithEvents TrbParameterA As TrackBar
    Friend WithEvents GrpPresentation As GroupBox
    Friend WithEvents LblStretching As Label
    Friend WithEvents TxtXStretching As TextBox
    Friend WithEvents LblxStretching As Label
    Friend WithEvents OptTimeAxis As RadioButton
    Friend WithEvents OptFunctionGraph As RadioButton
    Friend WithEvents GrpProtocol As GroupBox
    Friend WithEvents BtnProtocolStartvalue As Button
    Friend WithEvents TxtTargetProtocol As TextBox
    Friend WithEvents LblSteps As Label
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents TxtParameterA As TextBox
    Friend WithEvents GrpTargetValue As GroupBox
    Friend WithEvents BtnTransitiveStartValue As Button
    Friend WithEvents TxtTargetValue As TextBox
    Friend WithEvents LblTargetValue As Label
    Friend WithEvents GrpStep As GroupBox
    Friend WithEvents BtnNextStep As Button
    Friend WithEvents BtnNext10Steps As Button
    Friend WithEvents TxtStartValue As TextBox
    Friend WithEvents LblStartValue As Label
    Friend WithEvents LblParameter As Label
    Friend WithEvents BtnReset As Button
End Class
