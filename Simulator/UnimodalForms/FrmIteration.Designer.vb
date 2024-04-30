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
        Me.PicDiagram = New System.Windows.Forms.PictureBox()
        Me.BtnReset = New System.Windows.Forms.Button()
        Me.LblParameter = New System.Windows.Forms.Label()
        Me.LblStartValue = New System.Windows.Forms.Label()
        Me.BtnNextStep = New System.Windows.Forms.Button()
        Me.BtnNext10Steps = New System.Windows.Forms.Button()
        Me.LstValueList = New System.Windows.Forms.ListBox()
        Me.LstProtocol = New System.Windows.Forms.ListBox()
        Me.GrpStep = New System.Windows.Forms.GroupBox()
        Me.LblSteps = New System.Windows.Forms.Label()
        Me.GrpTargetValue = New System.Windows.Forms.GroupBox()
        Me.BtnStartTransitive = New System.Windows.Forms.Button()
        Me.TxtTargetValue = New System.Windows.Forms.TextBox()
        Me.LblTargetValue = New System.Windows.Forms.Label()
        Me.GrpProtocol = New System.Windows.Forms.GroupBox()
        Me.BtnProtocolStartvalue = New System.Windows.Forms.Button()
        Me.TxtTargetProtocol = New System.Windows.Forms.TextBox()
        Me.TxtParameter = New System.Windows.Forms.TextBox()
        Me.TxtStartValue = New System.Windows.Forms.TextBox()
        Me.CboFunction = New System.Windows.Forms.ComboBox()
        Me.BtnDrawDiagram = New System.Windows.Forms.Button()
        Me.LblIterationDepth = New System.Windows.Forms.Label()
        Me.CboIterationDepth = New System.Windows.Forms.ComboBox()
        Me.LblNumberOfSteps = New System.Windows.Forms.Label()
        Me.LblXValues = New System.Windows.Forms.Label()
        Me.LblLog = New System.Windows.Forms.Label()
        Me.GrpPresentation = New System.Windows.Forms.GroupBox()
        Me.LblStretching = New System.Windows.Forms.Label()
        Me.TxtXStretching = New System.Windows.Forms.TextBox()
        Me.LblxStretching = New System.Windows.Forms.Label()
        Me.OptTimeAxis = New System.Windows.Forms.RadioButton()
        Me.OptFunctionGraph = New System.Windows.Forms.RadioButton()
        CType(Me.PicDiagram, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpStep.SuspendLayout()
        Me.GrpTargetValue.SuspendLayout()
        Me.GrpProtocol.SuspendLayout()
        Me.GrpPresentation.SuspendLayout()
        Me.SuspendLayout()
        '
        'PicDiagram
        '
        Me.PicDiagram.BackColor = System.Drawing.Color.White
        Me.PicDiagram.Location = New System.Drawing.Point(16, 65)
        Me.PicDiagram.Margin = New System.Windows.Forms.Padding(4)
        Me.PicDiagram.Name = "PicDiagram"
        Me.PicDiagram.Size = New System.Drawing.Size(1179, 1105)
        Me.PicDiagram.TabIndex = 0
        Me.PicDiagram.TabStop = False
        '
        'BtnReset
        '
        Me.BtnReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReset.Location = New System.Drawing.Point(1553, 1104)
        Me.BtnReset.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(520, 61)
        Me.BtnReset.TabIndex = 17
        Me.BtnReset.Text = "ResetIteration"
        Me.BtnReset.UseVisualStyleBackColor = True
        '
        'LblParameter
        '
        Me.LblParameter.AutoSize = True
        Me.LblParameter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblParameter.Location = New System.Drawing.Point(289, 20)
        Me.LblParameter.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblParameter.Name = "LblParameter"
        Me.LblParameter.Size = New System.Drawing.Size(43, 26)
        Me.LblParameter.TabIndex = 5
        Me.LblParameter.Text = "a ="
        '
        'LblStartValue
        '
        Me.LblStartValue.AutoSize = True
        Me.LblStartValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStartValue.Location = New System.Drawing.Point(1533, 28)
        Me.LblStartValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblStartValue.Name = "LblStartValue"
        Me.LblStartValue.Size = New System.Drawing.Size(129, 26)
        Me.LblStartValue.TabIndex = 7
        Me.LblStartValue.Text = "StartValue" & " = "
        '
        'BtnNextStep
        '
        Me.BtnNextStep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNextStep.Location = New System.Drawing.Point(12, 42)
        Me.BtnNextStep.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnNextStep.Name = "BtnNextStep"
        Me.BtnNextStep.Size = New System.Drawing.Size(245, 61)
        Me.BtnNextStep.TabIndex = 3
        Me.BtnNextStep.Text = "NextStep"
        Me.BtnNextStep.UseVisualStyleBackColor = True
        '
        'BtnNext10Steps
        '
        Me.BtnNext10Steps.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNext10Steps.Location = New System.Drawing.Point(285, 42)
        Me.BtnNext10Steps.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnNext10Steps.Name = "BtnNext10Steps"
        Me.BtnNext10Steps.Size = New System.Drawing.Size(245, 61)
        Me.BtnNext10Steps.TabIndex = 4
        Me.BtnNext10Steps.Text = "Next10Steps"
        Me.BtnNext10Steps.UseVisualStyleBackColor = True
        '
        'LstValueList
        '
        Me.LstValueList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstValueList.FormattingEnabled = True
        Me.LstValueList.ItemHeight = 25
        Me.LstValueList.Location = New System.Drawing.Point(1197, 65)
        Me.LstValueList.Margin = New System.Windows.Forms.Padding(4)
        Me.LstValueList.Name = "LstValueList"
        Me.LstValueList.ScrollAlwaysVisible = True
        Me.LstValueList.Size = New System.Drawing.Size(225, 1104)
        Me.LstValueList.TabIndex = 14
        '
        'LstProtocol
        '
        Me.LstProtocol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstProtocol.FormattingEnabled = True
        Me.LstProtocol.ItemHeight = 25
        Me.LstProtocol.Location = New System.Drawing.Point(1432, 65)
        Me.LstProtocol.Margin = New System.Windows.Forms.Padding(4)
        Me.LstProtocol.Name = "LstProtocol"
        Me.LstProtocol.ScrollAlwaysVisible = True
        Me.LstProtocol.Size = New System.Drawing.Size(69, 1104)
        Me.LstProtocol.TabIndex = 15
        '
        'GrpStep
        '
        Me.GrpStep.Controls.Add(Me.BtnNextStep)
        Me.GrpStep.Controls.Add(Me.BtnNext10Steps)
        Me.GrpStep.Location = New System.Drawing.Point(1539, 311)
        Me.GrpStep.Margin = New System.Windows.Forms.Padding(4)
        Me.GrpStep.Name = "GrpStep"
        Me.GrpStep.Padding = New System.Windows.Forms.Padding(4)
        Me.GrpStep.Size = New System.Drawing.Size(563, 122)
        Me.GrpStep.TabIndex = 17
        Me.GrpStep.TabStop = False
        Me.GrpStep.Text = "Iteration"
        '
        'LblSteps
        '
        Me.LblSteps.AutoSize = True
        Me.LblSteps.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSteps.Location = New System.Drawing.Point(1533, 80)
        Me.LblSteps.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSteps.Name = "LblSteps"
        Me.LblSteps.Size = New System.Drawing.Size(176, 26)
        Me.LblSteps.TabIndex = 7
        Me.LblSteps.Text = "NumberOfSteps"
        '
        'GrpTargetValue
        '
        Me.GrpTargetValue.Controls.Add(Me.BtnStartTransitive)
        Me.GrpTargetValue.Controls.Add(Me.TxtTargetValue)
        Me.GrpTargetValue.Controls.Add(Me.LblTargetValue)
        Me.GrpTargetValue.Location = New System.Drawing.Point(1539, 689)
        Me.GrpTargetValue.Margin = New System.Windows.Forms.Padding(4)
        Me.GrpTargetValue.Name = "GrpTargetValue"
        Me.GrpTargetValue.Padding = New System.Windows.Forms.Padding(4)
        Me.GrpTargetValue.Size = New System.Drawing.Size(563, 180)
        Me.GrpTargetValue.TabIndex = 11
        Me.GrpTargetValue.TabStop = False
        Me.GrpTargetValue.Text = "Transitivity"
        '
        'BtnStartTransitive
        '
        Me.BtnStartTransitive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStartTransitive.Location = New System.Drawing.Point(15, 92)
        Me.BtnStartTransitive.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnStartTransitive.Name = "BtnStartTransitive"
        Me.BtnStartTransitive.Size = New System.Drawing.Size(520, 61)
        Me.BtnStartTransitive.TabIndex = 13
        Me.BtnStartTransitive.Text = "StartvalueForTargetvalue"
        Me.BtnStartTransitive.UseVisualStyleBackColor = True
        '
        'TxtTargetValue
        '
        Me.TxtTargetValue.Location = New System.Drawing.Point(155, 39)
        Me.TxtTargetValue.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTargetValue.Name = "TxtTargetValue"
        Me.TxtTargetValue.Size = New System.Drawing.Size(379, 31)
        Me.TxtTargetValue.TabIndex = 12
        '
        'LblTargetValue
        '
        Me.LblTargetValue.AutoSize = True
        Me.LblTargetValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTargetValue.Location = New System.Drawing.Point(9, 46)
        Me.LblTargetValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTargetValue.Name = "LblTargetValue"
        Me.LblTargetValue.Size = New System.Drawing.Size(144, 26)
        Me.LblTargetValue.TabIndex = 17
        Me.LblTargetValue.Text = "TargetValue" & " = "
        '
        'GrpProtocol
        '
        Me.GrpProtocol.Controls.Add(Me.BtnProtocolStartvalue)
        Me.GrpProtocol.Controls.Add(Me.TxtTargetProtocol)
        Me.GrpProtocol.Location = New System.Drawing.Point(1539, 462)
        Me.GrpProtocol.Margin = New System.Windows.Forms.Padding(4)
        Me.GrpProtocol.Name = "GrpProtocol"
        Me.GrpProtocol.Padding = New System.Windows.Forms.Padding(4)
        Me.GrpProtocol.Size = New System.Drawing.Size(563, 199)
        Me.GrpProtocol.TabIndex = 9
        Me.GrpProtocol.TabStop = False
        Me.GrpProtocol.Text = "TargetProtocol"
        '
        'BtnProtocolStartvalue
        '
        Me.BtnProtocolStartvalue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProtocolStartvalue.Location = New System.Drawing.Point(12, 104)
        Me.BtnProtocolStartvalue.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnProtocolStartvalue.Name = "BtnProtocolStartvalue"
        Me.BtnProtocolStartvalue.Size = New System.Drawing.Size(523, 61)
        Me.BtnProtocolStartvalue.TabIndex = 8
        Me.BtnProtocolStartvalue.Text = "StartvalueForProtocol"
        Me.BtnProtocolStartvalue.UseVisualStyleBackColor = True
        '
        'TxtTargetProtocol
        '
        Me.TxtTargetProtocol.Location = New System.Drawing.Point(15, 42)
        Me.TxtTargetProtocol.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTargetProtocol.Name = "TxtTargetProtocol"
        Me.TxtTargetProtocol.Size = New System.Drawing.Size(519, 31)
        Me.TxtTargetProtocol.TabIndex = 10
        '
        'TxtParameter
        '
        Me.TxtParameter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtParameter.Location = New System.Drawing.Point(339, 15)
        Me.TxtParameter.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtParameter.Name = "TxtParameter"
        Me.TxtParameter.Size = New System.Drawing.Size(171, 32)
        Me.TxtParameter.TabIndex = 2
        '
        'TxtStartValue
        '
        Me.TxtStartValue.Location = New System.Drawing.Point(1657, 24)
        Me.TxtStartValue.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtStartValue.Name = "TxtStartValue"
        Me.TxtStartValue.Size = New System.Drawing.Size(411, 31)
        Me.TxtStartValue.TabIndex = 4
        '
        'CboFunction
        '
        Me.CboFunction.FormattingEnabled = True
        Me.CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic Growth", "Parabola"})
        Me.CboFunction.Location = New System.Drawing.Point(16, 15)
        Me.CboFunction.Margin = New System.Windows.Forms.Padding(4)
        Me.CboFunction.Name = "CboFunction"
        Me.CboFunction.Size = New System.Drawing.Size(264, 33)
        Me.CboFunction.TabIndex = 1
        '
        'BtnDrawDiagram
        '
        Me.BtnDrawDiagram.Location = New System.Drawing.Point(783, 11)
        Me.BtnDrawDiagram.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnDrawDiagram.Name = "BtnDrawDiagram"
        Me.BtnDrawDiagram.Size = New System.Drawing.Size(412, 41)
        Me.BtnDrawDiagram.TabIndex = 22
        Me.BtnDrawDiagram.Text = "DrawFunctionGraph"
        Me.BtnDrawDiagram.UseVisualStyleBackColor = True
        '
        'LblIterationDepth
        '
        Me.LblIterationDepth.AutoSize = True
        Me.LblIterationDepth.Location = New System.Drawing.Point(519, 20)
        Me.LblIterationDepth.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblIterationDepth.Name = "LblIterationDepth"
        Me.LblIterationDepth.Size = New System.Drawing.Size(146, 25)
        Me.LblIterationDepth.TabIndex = 23
        Me.LblIterationDepth.Text = "IterationDepth"
        '
        'CboIterationDepth
        '
        Me.CboIterationDepth.FormattingEnabled = True
        Me.CboIterationDepth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.CboIterationDepth.Location = New System.Drawing.Point(669, 15)
        Me.CboIterationDepth.Margin = New System.Windows.Forms.Padding(4)
        Me.CboIterationDepth.Name = "CboIterationDepth"
        Me.CboIterationDepth.Size = New System.Drawing.Size(84, 33)
        Me.CboIterationDepth.TabIndex = 3
        '
        'LblNumberOfSteps
        '
        Me.LblNumberOfSteps.AutoSize = True
        Me.LblNumberOfSteps.Location = New System.Drawing.Point(1708, 80)
        Me.LblNumberOfSteps.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNumberOfSteps.Name = "LblNumberOfSteps"
        Me.LblNumberOfSteps.Size = New System.Drawing.Size(24, 25)
        Me.LblNumberOfSteps.TabIndex = 26
        Me.LblNumberOfSteps.Text = "0"
        '
        'LblXValues
        '
        Me.LblXValues.AutoSize = True
        Me.LblXValues.Location = New System.Drawing.Point(1216, 25)
        Me.LblXValues.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblXValues.Name = "LblXValues"
        Me.LblXValues.Size = New System.Drawing.Size(99, 25)
        Me.LblXValues.TabIndex = 27
        Me.LblXValues.Text = "XValues"
        '
        'LblLog
        '
        Me.LblLog.AutoSize = True
        Me.LblLog.Location = New System.Drawing.Point(1409, 28)
        Me.LblLog.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblLog.Name = "LblLog"
        Me.LblLog.Size = New System.Drawing.Size(48, 25)
        Me.LblLog.TabIndex = 28
        Me.LblLog.Text = "Log"
        '
        'GrpPresentation
        '
        Me.GrpPresentation.Controls.Add(Me.LblStretching)
        Me.GrpPresentation.Controls.Add(Me.TxtXStretching)
        Me.GrpPresentation.Controls.Add(Me.LblxStretching)
        Me.GrpPresentation.Controls.Add(Me.OptTimeAxis)
        Me.GrpPresentation.Controls.Add(Me.OptFunctionGraph)
        Me.GrpPresentation.Location = New System.Drawing.Point(1539, 125)
        Me.GrpPresentation.Margin = New System.Windows.Forms.Padding(4)
        Me.GrpPresentation.Name = "GrpPresentation"
        Me.GrpPresentation.Padding = New System.Windows.Forms.Padding(4)
        Me.GrpPresentation.Size = New System.Drawing.Size(556, 160)
        Me.GrpPresentation.TabIndex = 34
        Me.GrpPresentation.TabStop = False
        Me.GrpPresentation.Text = "Presentation"
        '
        'LblStretching
        '
        Me.LblStretching.AutoSize = True
        Me.LblStretching.Location = New System.Drawing.Point(280, 108)
        Me.LblStretching.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblStretching.Name = "LblStretching"
        Me.LblStretching.Size = New System.Drawing.Size(107, 25)
        Me.LblStretching.TabIndex = 4
        Me.LblStretching.Text = "DinStretching"
        '
        'TxtXStretching
        '
        Me.TxtXStretching.Location = New System.Drawing.Point(407, 100)
        Me.TxtXStretching.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtXStretching.Name = "TxtXStretching"
        Me.TxtXStretching.Size = New System.Drawing.Size(120, 31)
        Me.TxtXStretching.TabIndex = 3
        '
        'LblxStretching
        '
        Me.LblxStretching.AutoSize = True
        Me.LblxStretching.Location = New System.Drawing.Point(280, 45)
        Me.LblxStretching.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblxStretching.Name = "LblxStretching"
        Me.LblxStretching.Size = New System.Drawing.Size(243, 25)
        Me.LblxStretching.TabIndex = 2
        Me.LblxStretching.Text = "xStretching"
        '
        'OptTimeAxis
        '
        Me.OptTimeAxis.AutoSize = True
        Me.OptTimeAxis.Location = New System.Drawing.Point(24, 102)
        Me.OptTimeAxis.Margin = New System.Windows.Forms.Padding(4)
        Me.OptTimeAxis.Name = "OptTimeAxis"
        Me.OptTimeAxis.Size = New System.Drawing.Size(137, 29)
        Me.OptTimeAxis.TabIndex = 1
        Me.OptTimeAxis.Text = "TimeAxis"
        Me.OptTimeAxis.UseVisualStyleBackColor = True
        '
        'OptFunctionGraph
        '
        Me.OptFunctionGraph.AutoSize = True
        Me.OptFunctionGraph.Checked = True
        Me.OptFunctionGraph.Location = New System.Drawing.Point(24, 42)
        Me.OptFunctionGraph.Margin = New System.Windows.Forms.Padding(4)
        Me.OptFunctionGraph.Name = "OptFunctionGraph"
        Me.OptFunctionGraph.Size = New System.Drawing.Size(191, 29)
        Me.OptFunctionGraph.TabIndex = 0
        Me.OptFunctionGraph.TabStop = True
        Me.OptFunctionGraph.Text = "FunctionGraph"
        Me.OptFunctionGraph.UseVisualStyleBackColor = True
        '
        'FrmIteration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2141, 1180)
        Me.Controls.Add(Me.GrpPresentation)
        Me.Controls.Add(Me.LblLog)
        Me.Controls.Add(Me.LblXValues)
        Me.Controls.Add(Me.LblNumberOfSteps)
        Me.Controls.Add(Me.LblSteps)
        Me.Controls.Add(Me.CboIterationDepth)
        Me.Controls.Add(Me.LblIterationDepth)
        Me.Controls.Add(Me.BtnDrawDiagram)
        Me.Controls.Add(Me.CboFunction)
        Me.Controls.Add(Me.TxtParameter)
        Me.Controls.Add(Me.GrpProtocol)
        Me.Controls.Add(Me.GrpTargetValue)
        Me.Controls.Add(Me.GrpStep)
        Me.Controls.Add(Me.TxtStartValue)
        Me.Controls.Add(Me.LstProtocol)
        Me.Controls.Add(Me.LstValueList)
        Me.Controls.Add(Me.LblStartValue)
        Me.Controls.Add(Me.LblParameter)
        Me.Controls.Add(Me.BtnReset)
        Me.Controls.Add(Me.PicDiagram)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmIteration"
        Me.Text = "UnimodalFunctions"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PicDiagram, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpStep.ResumeLayout(False)
        Me.GrpTargetValue.ResumeLayout(False)
        Me.GrpTargetValue.PerformLayout()
        Me.GrpProtocol.ResumeLayout(False)
        Me.GrpProtocol.PerformLayout()
        Me.GrpPresentation.ResumeLayout(False)
        Me.GrpPresentation.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents BtnStartTransitive As Button
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
