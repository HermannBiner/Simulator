﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        PicDiagram.Location = New Point(17, 80)
        PicDiagram.Margin = New Padding(4)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(1300, 1300)
        PicDiagram.TabIndex = 0
        PicDiagram.TabStop = False
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Segoe UI", 11.5F)
        BtnReset.Location = New Point(1668, 1330)
        BtnReset.Margin = New Padding(4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(580, 50)
        BtnReset.TabIndex = 17
        BtnReset.Text = "ResetIteration"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' LblParameter
        ' 
        LblParameter.AutoSize = True
        LblParameter.Font = New Font("Segoe UI", 11.5F)
        LblParameter.Location = New Point(1768, 190)
        LblParameter.Margin = New Padding(4, 0, 4, 0)
        LblParameter.Name = "LblParameter"
        LblParameter.Size = New Size(48, 31)
        LblParameter.TabIndex = 5
        LblParameter.Text = "a ="
        ' 
        ' LblStartValue
        ' 
        LblStartValue.AutoSize = True
        LblStartValue.Font = New Font("Segoe UI", 11.5F)
        LblStartValue.Location = New Point(1689, 246)
        LblStartValue.Margin = New Padding(4, 0, 4, 0)
        LblStartValue.Name = "LblStartValue"
        LblStartValue.Size = New Size(144, 31)
        LblStartValue.TabIndex = 7
        LblStartValue.Text = "StartValue = "
        ' 
        ' BtnNextStep
        ' 
        BtnNextStep.Font = New Font("Segoe UI", 11.5F)
        BtnNextStep.Location = New Point(13, 51)
        BtnNextStep.Margin = New Padding(4)
        BtnNextStep.Name = "BtnNextStep"
        BtnNextStep.Size = New Size(266, 50)
        BtnNextStep.TabIndex = 3
        BtnNextStep.Text = "NextStep"
        BtnNextStep.UseVisualStyleBackColor = True
        ' 
        ' BtnNext10Steps
        ' 
        BtnNext10Steps.Font = New Font("Segoe UI", 11.5F)
        BtnNext10Steps.Location = New Point(306, 51)
        BtnNext10Steps.Margin = New Padding(4)
        BtnNext10Steps.Name = "BtnNext10Steps"
        BtnNext10Steps.Size = New Size(266, 50)
        BtnNext10Steps.TabIndex = 4
        BtnNext10Steps.Text = "Next10Steps"
        BtnNext10Steps.UseVisualStyleBackColor = True
        ' 
        ' LstValueList
        ' 
        LstValueList.Font = New Font("Segoe UI", 11.5F)
        LstValueList.FormattingEnabled = True
        LstValueList.Location = New Point(1333, 80)
        LstValueList.Margin = New Padding(4)
        LstValueList.Name = "LstValueList"
        LstValueList.ScrollAlwaysVisible = True
        LstValueList.Size = New Size(244, 1306)
        LstValueList.TabIndex = 14
        ' 
        ' LstProtocol
        ' 
        LstProtocol.Font = New Font("Segoe UI", 11.5F)
        LstProtocol.FormattingEnabled = True
        LstProtocol.Location = New Point(1585, 80)
        LstProtocol.Margin = New Padding(4)
        LstProtocol.Name = "LstProtocol"
        LstProtocol.ScrollAlwaysVisible = True
        LstProtocol.Size = New Size(64, 1306)
        LstProtocol.TabIndex = 15
        ' 
        ' GrpStep
        ' 
        GrpStep.Controls.Add(BtnNextStep)
        GrpStep.Controls.Add(BtnNext10Steps)
        GrpStep.Location = New Point(1665, 1019)
        GrpStep.Margin = New Padding(4)
        GrpStep.Name = "GrpStep"
        GrpStep.Padding = New Padding(4)
        GrpStep.Size = New Size(590, 127)
        GrpStep.TabIndex = 17
        GrpStep.TabStop = False
        GrpStep.Text = "Iteration"
        ' 
        ' LblNumberOfSteps
        ' 
        LblNumberOfSteps.AutoSize = True
        LblNumberOfSteps.Font = New Font("Segoe UI", 11.5F)
        LblNumberOfSteps.Location = New Point(1668, 945)
        LblNumberOfSteps.Margin = New Padding(4, 0, 4, 0)
        LblNumberOfSteps.Name = "LblNumberOfSteps"
        LblNumberOfSteps.Size = New Size(177, 31)
        LblNumberOfSteps.TabIndex = 7
        LblNumberOfSteps.Text = "NumberOfSteps"
        ' 
        ' GrpTargetValue
        ' 
        GrpTargetValue.Controls.Add(BtnTransitiveStartValue)
        GrpTargetValue.Controls.Add(TxtTargetValue)
        GrpTargetValue.Controls.Add(LblTargetValue)
        GrpTargetValue.Location = New Point(1657, 738)
        GrpTargetValue.Margin = New Padding(4)
        GrpTargetValue.Name = "GrpTargetValue"
        GrpTargetValue.Padding = New Padding(4)
        GrpTargetValue.Size = New Size(598, 182)
        GrpTargetValue.TabIndex = 11
        GrpTargetValue.TabStop = False
        GrpTargetValue.Text = "Transitivity"
        ' 
        ' BtnTransitiveStartValue
        ' 
        BtnTransitiveStartValue.Font = New Font("Segoe UI", 11.5F)
        BtnTransitiveStartValue.Location = New Point(17, 113)
        BtnTransitiveStartValue.Margin = New Padding(4)
        BtnTransitiveStartValue.Name = "BtnTransitiveStartValue"
        BtnTransitiveStartValue.Size = New Size(563, 50)
        BtnTransitiveStartValue.TabIndex = 13
        BtnTransitiveStartValue.Text = "StartvalueForTargetvalue"
        BtnTransitiveStartValue.UseVisualStyleBackColor = True
        ' 
        ' TxtTargetValue
        ' 
        TxtTargetValue.Location = New Point(171, 51)
        TxtTargetValue.Margin = New Padding(4)
        TxtTargetValue.Name = "TxtTargetValue"
        TxtTargetValue.Size = New Size(411, 38)
        TxtTargetValue.TabIndex = 12
        ' 
        ' LblTargetValue
        ' 
        LblTargetValue.AutoSize = True
        LblTargetValue.Font = New Font("Segoe UI", 11.5F)
        LblTargetValue.Location = New Point(9, 58)
        LblTargetValue.Margin = New Padding(4, 0, 4, 0)
        LblTargetValue.Name = "LblTargetValue"
        LblTargetValue.Size = New Size(160, 31)
        LblTargetValue.TabIndex = 17
        LblTargetValue.Text = "TargetValue = "
        ' 
        ' GrpProtocol
        ' 
        GrpProtocol.Controls.Add(BtnProtocolStartvalue)
        GrpProtocol.Controls.Add(TxtTargetProtocol)
        GrpProtocol.Location = New Point(1665, 521)
        GrpProtocol.Margin = New Padding(4)
        GrpProtocol.Name = "GrpProtocol"
        GrpProtocol.Padding = New Padding(4)
        GrpProtocol.Size = New Size(590, 186)
        GrpProtocol.TabIndex = 9
        GrpProtocol.TabStop = False
        GrpProtocol.Text = "TargetProtocol"
        ' 
        ' BtnProtocolStartvalue
        ' 
        BtnProtocolStartvalue.Font = New Font("Segoe UI", 11.5F)
        BtnProtocolStartvalue.Location = New Point(13, 108)
        BtnProtocolStartvalue.Margin = New Padding(4)
        BtnProtocolStartvalue.Name = "BtnProtocolStartvalue"
        BtnProtocolStartvalue.Size = New Size(565, 50)
        BtnProtocolStartvalue.TabIndex = 8
        BtnProtocolStartvalue.Text = "StartvalueForProtocol"
        BtnProtocolStartvalue.UseVisualStyleBackColor = True
        ' 
        ' TxtTargetProtocol
        ' 
        TxtTargetProtocol.Location = New Point(13, 62)
        TxtTargetProtocol.Margin = New Padding(4)
        TxtTargetProtocol.Name = "TxtTargetProtocol"
        TxtTargetProtocol.Size = New Size(561, 38)
        TxtTargetProtocol.TabIndex = 10
        ' 
        ' TxtParameterA
        ' 
        TxtParameterA.Font = New Font("Segoe UI", 11.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TxtParameterA.Location = New Point(1824, 190)
        TxtParameterA.Margin = New Padding(4)
        TxtParameterA.Name = "TxtParameterA"
        TxtParameterA.Size = New Size(419, 38)
        TxtParameterA.TabIndex = 2
        ' 
        ' TxtStartValue
        ' 
        TxtStartValue.Location = New Point(1824, 243)
        TxtStartValue.Margin = New Padding(4)
        TxtStartValue.Name = "TxtStartValue"
        TxtStartValue.Size = New Size(419, 38)
        TxtStartValue.TabIndex = 4
        ' 
        ' CboFunction
        ' 
        CboFunction.FormattingEnabled = True
        CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic Growth", "Parabola"})
        CboFunction.Location = New Point(17, 18)
        CboFunction.Margin = New Padding(4)
        CboFunction.Name = "CboFunction"
        CboFunction.Size = New Size(535, 39)
        CboFunction.TabIndex = 1
        ' 
        ' LblIterationDepth
        ' 
        LblIterationDepth.AutoSize = True
        LblIterationDepth.Location = New Point(563, 25)
        LblIterationDepth.Margin = New Padding(4, 0, 4, 0)
        LblIterationDepth.Name = "LblIterationDepth"
        LblIterationDepth.Size = New Size(163, 31)
        LblIterationDepth.TabIndex = 23
        LblIterationDepth.Text = "IterationDepth"
        ' 
        ' CboIterationDepth
        ' 
        CboIterationDepth.FormattingEnabled = True
        CboIterationDepth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        CboIterationDepth.Location = New Point(724, 18)
        CboIterationDepth.Margin = New Padding(4)
        CboIterationDepth.Name = "CboIterationDepth"
        CboIterationDepth.Size = New Size(91, 39)
        CboIterationDepth.TabIndex = 3
        ' 
        ' LblSteps
        ' 
        LblSteps.AutoSize = True
        LblSteps.Location = New Point(1843, 945)
        LblSteps.Margin = New Padding(4, 0, 4, 0)
        LblSteps.Name = "LblSteps"
        LblSteps.Size = New Size(26, 31)
        LblSteps.TabIndex = 26
        LblSteps.Text = "0"
        ' 
        ' LblXValues
        ' 
        LblXValues.AutoSize = True
        LblXValues.Location = New Point(1333, 35)
        LblXValues.Margin = New Padding(4, 0, 4, 0)
        LblXValues.Name = "LblXValues"
        LblXValues.Size = New Size(93, 31)
        LblXValues.TabIndex = 27
        LblXValues.Text = "XValues"
        ' 
        ' LblLog
        ' 
        LblLog.AutoSize = True
        LblLog.Location = New Point(1585, 35)
        LblLog.Margin = New Padding(4, 0, 4, 0)
        LblLog.Name = "LblLog"
        LblLog.Size = New Size(52, 31)
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
        GrpPresentation.Location = New Point(1665, 314)
        GrpPresentation.Margin = New Padding(4)
        GrpPresentation.Name = "GrpPresentation"
        GrpPresentation.Padding = New Padding(4)
        GrpPresentation.Size = New Size(590, 199)
        GrpPresentation.TabIndex = 34
        GrpPresentation.TabStop = False
        GrpPresentation.Text = "Presentation"
        ' 
        ' LblStretching
        ' 
        LblStretching.AutoSize = True
        LblStretching.Location = New Point(303, 135)
        LblStretching.Margin = New Padding(4, 0, 4, 0)
        LblStretching.Name = "LblStretching"
        LblStretching.Size = New Size(153, 31)
        LblStretching.TabIndex = 4
        LblStretching.Text = "DinStretching"
        ' 
        ' TxtXStretching
        ' 
        TxtXStretching.Location = New Point(464, 126)
        TxtXStretching.Margin = New Padding(4)
        TxtXStretching.Name = "TxtXStretching"
        TxtXStretching.Size = New Size(106, 38)
        TxtXStretching.TabIndex = 3
        ' 
        ' LblxStretching
        ' 
        LblxStretching.AutoSize = True
        LblxStretching.Location = New Point(303, 56)
        LblxStretching.Margin = New Padding(4, 0, 4, 0)
        LblxStretching.Name = "LblxStretching"
        LblxStretching.Size = New Size(129, 31)
        LblxStretching.TabIndex = 2
        LblxStretching.Text = "xStretching"
        ' 
        ' OptTimeAxis
        ' 
        OptTimeAxis.AutoSize = True
        OptTimeAxis.Location = New Point(26, 126)
        OptTimeAxis.Margin = New Padding(4)
        OptTimeAxis.Name = "OptTimeAxis"
        OptTimeAxis.Size = New Size(131, 35)
        OptTimeAxis.TabIndex = 1
        OptTimeAxis.Text = "TimeAxis"
        OptTimeAxis.UseVisualStyleBackColor = True
        ' 
        ' OptFunctionGraph
        ' 
        OptFunctionGraph.AutoSize = True
        OptFunctionGraph.Checked = True
        OptFunctionGraph.Location = New Point(26, 51)
        OptFunctionGraph.Margin = New Padding(4)
        OptFunctionGraph.Name = "OptFunctionGraph"
        OptFunctionGraph.Size = New Size(190, 35)
        OptFunctionGraph.TabIndex = 0
        OptFunctionGraph.TabStop = True
        OptFunctionGraph.Text = "FunctionGraph"
        OptFunctionGraph.UseVisualStyleBackColor = True
        ' 
        ' TrbParameterA
        ' 
        TrbParameterA.Location = New Point(1696, 80)
        TrbParameterA.Margin = New Padding(6)
        TrbParameterA.Maximum = 1000
        TrbParameterA.Minimum = 1
        TrbParameterA.Name = "TrbParameterA"
        TrbParameterA.Size = New Size(541, 69)
        TrbParameterA.TabIndex = 35
        TrbParameterA.Value = 500
        ' 
        ' LblParameterA
        ' 
        LblParameterA.AutoSize = True
        LblParameterA.Font = New Font("Segoe UI", 11.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblParameterA.Location = New Point(1685, 40)
        LblParameterA.Margin = New Padding(4, 0, 4, 0)
        LblParameterA.Name = "LblParameterA"
        LblParameterA.Size = New Size(136, 31)
        LblParameterA.TabIndex = 36
        LblParameterA.Text = "Parameter a"
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Segoe UI", 11.5F)
        BtnDefault.Location = New Point(1666, 1272)
        BtnDefault.Margin = New Padding(4)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(580, 50)
        BtnDefault.TabIndex = 37
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' FrmIteration
        ' 
        AutoScaleDimensions = New SizeF(13F, 31F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(2278, 1394)
        Controls.Add(BtnDefault)
        Controls.Add(LblParameterA)
        Controls.Add(TrbParameterA)
        Controls.Add(GrpPresentation)
        Controls.Add(LblLog)
        Controls.Add(LblXValues)
        Controls.Add(LblSteps)
        Controls.Add(LblNumberOfSteps)
        Controls.Add(CboIterationDepth)
        Controls.Add(LblIterationDepth)
        Controls.Add(CboFunction)
        Controls.Add(TxtParameterA)
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
        Margin = New Padding(4)
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