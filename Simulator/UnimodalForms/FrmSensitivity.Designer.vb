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
        Me.CboIterationDepth = New System.Windows.Forms.ComboBox()
        Me.LblIterationDepth = New System.Windows.Forms.Label()
        Me.CboFunction = New System.Windows.Forms.ComboBox()
        Me.TxtParameter = New System.Windows.Forms.TextBox()
        Me.LblParameter = New System.Windows.Forms.Label()
        Me.PicDiagram = New System.Windows.Forms.PictureBox()
        Me.LblValueList1 = New System.Windows.Forms.Label()
        Me.LstValueList1 = New System.Windows.Forms.ListBox()
        Me.LblValueList2 = New System.Windows.Forms.Label()
        Me.LstValueList2 = New System.Windows.Forms.ListBox()
        Me.TxtStartValue1 = New System.Windows.Forms.TextBox()
        Me.LblStartValue1 = New System.Windows.Forms.Label()
        Me.TxtStartValue2 = New System.Windows.Forms.TextBox()
        Me.LblStartValue2 = New System.Windows.Forms.Label()
        Me.GrpPresentation = New System.Windows.Forms.GroupBox()
        Me.LblStretching = New System.Windows.Forms.Label()
        Me.TxtxStretching = New System.Windows.Forms.TextBox()
        Me.LblxStretching = New System.Windows.Forms.Label()
        Me.OptSingleOrbit = New System.Windows.Forms.RadioButton()
        Me.OptDifference = New System.Windows.Forms.RadioButton()
        Me.BtnStartIteration = New System.Windows.Forms.Button()
        Me.BtnReset = New System.Windows.Forms.Button()
        Me.LblNumberOfSteps = New System.Windows.Forms.Label()
        Me.LblSteps = New System.Windows.Forms.Label()
        CType(Me.PicDiagram, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpPresentation.SuspendLayout()
        Me.SuspendLayout()
        '
        'CboIterationDepth
        '
        Me.CboIterationDepth.FormattingEnabled = True
        Me.CboIterationDepth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.CboIterationDepth.Location = New System.Drawing.Point(335, 5)
        Me.CboIterationDepth.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CboIterationDepth.Name = "CboIterationDepth"
        Me.CboIterationDepth.Size = New System.Drawing.Size(44, 21)
        Me.CboIterationDepth.TabIndex = 27
        '
        'LblIterationDepth
        '
        Me.LblIterationDepth.AutoSize = True
        Me.LblIterationDepth.Location = New System.Drawing.Point(259, 8)
        Me.LblIterationDepth.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblIterationDepth.Name = "LblIterationDepth"
        Me.LblIterationDepth.Size = New System.Drawing.Size(77, 13)
        Me.LblIterationDepth.TabIndex = 29
        Me.LblIterationDepth.Text = "IterationDepth"
        '
        'CboFunction
        '
        Me.CboFunction.FormattingEnabled = True
        Me.CboFunction.Items.AddRange(New Object() {"Tentmap", "Logistic Growth", "Parabola"})
        Me.CboFunction.Location = New System.Drawing.Point(8, 5)
        Me.CboFunction.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CboFunction.Name = "CboFunction"
        Me.CboFunction.Size = New System.Drawing.Size(134, 21)
        Me.CboFunction.TabIndex = 25
        '
        'TxtParameter
        '
        Me.TxtParameter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtParameter.Location = New System.Drawing.Point(169, 5)
        Me.TxtParameter.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtParameter.Name = "TxtParameter"
        Me.TxtParameter.Size = New System.Drawing.Size(87, 20)
        Me.TxtParameter.TabIndex = 26
        '
        'LblParameter
        '
        Me.LblParameter.AutoSize = True
        Me.LblParameter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblParameter.Location = New System.Drawing.Point(145, 8)
        Me.LblParameter.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblParameter.Name = "LblParameter"
        Me.LblParameter.Size = New System.Drawing.Size(22, 13)
        Me.LblParameter.TabIndex = 28
        Me.LblParameter.Text = "a ="
        '
        'PicDiagram
        '
        Me.PicDiagram.BackColor = System.Drawing.Color.White
        Me.PicDiagram.Location = New System.Drawing.Point(8, 31)
        Me.PicDiagram.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PicDiagram.Name = "PicDiagram"
        Me.PicDiagram.Size = New System.Drawing.Size(589, 575)
        Me.PicDiagram.TabIndex = 24
        Me.PicDiagram.TabStop = False
        '
        'LblValueList1
        '
        Me.LblValueList1.AutoSize = True
        Me.LblValueList1.Location = New System.Drawing.Point(606, 10)
        Me.LblValueList1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblValueList1.Name = "LblValueList1"
        Me.LblValueList1.Size = New System.Drawing.Size(55, 13)
        Me.LblValueList1.TabIndex = 31
        Me.LblValueList1.Text = "ValueList1"
        '
        'LstValueList1
        '
        Me.LstValueList1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstValueList1.FormattingEnabled = True
        Me.LstValueList1.Location = New System.Drawing.Point(609, 31)
        Me.LstValueList1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.LstValueList1.Name = "LstValueList1"
        Me.LstValueList1.ScrollAlwaysVisible = True
        Me.LstValueList1.Size = New System.Drawing.Size(115, 576)
        Me.LstValueList1.TabIndex = 30
        '
        'LblValueList2
        '
        Me.LblValueList2.AutoSize = True
        Me.LblValueList2.Location = New System.Drawing.Point(733, 10)
        Me.LblValueList2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblValueList2.Name = "LblValueList2"
        Me.LblValueList2.Size = New System.Drawing.Size(55, 13)
        Me.LblValueList2.TabIndex = 33
        Me.LblValueList2.Text = "ValueList2"
        '
        'LstValueList2
        '
        Me.LstValueList2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstValueList2.FormattingEnabled = True
        Me.LstValueList2.Location = New System.Drawing.Point(735, 31)
        Me.LstValueList2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.LstValueList2.Name = "LstValueList2"
        Me.LstValueList2.ScrollAlwaysVisible = True
        Me.LstValueList2.Size = New System.Drawing.Size(115, 576)
        Me.LstValueList2.TabIndex = 32
        '
        'TxtStartValue1
        '
        Me.TxtStartValue1.Location = New System.Drawing.Point(938, 9)
        Me.TxtStartValue1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtStartValue1.Name = "TxtStartValue1"
        Me.TxtStartValue1.Size = New System.Drawing.Size(207, 20)
        Me.TxtStartValue1.TabIndex = 34
        '
        'LblStartValue1
        '
        Me.LblStartValue1.AutoSize = True
        Me.LblStartValue1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStartValue1.Location = New System.Drawing.Point(863, 12)
        Me.LblStartValue1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblStartValue1.Name = "LblStartValue1"
        Me.LblStartValue1.Size = New System.Drawing.Size(73, 13)
        Me.LblStartValue1.TabIndex = 35
        Me.LblStartValue1.Text = "StartValue1"
        '
        'TxtStartValue2
        '
        Me.TxtStartValue2.Location = New System.Drawing.Point(938, 41)
        Me.TxtStartValue2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtStartValue2.Name = "TxtStartValue2"
        Me.TxtStartValue2.Size = New System.Drawing.Size(207, 20)
        Me.TxtStartValue2.TabIndex = 36
        '
        'LblStartValue2
        '
        Me.LblStartValue2.AutoSize = True
        Me.LblStartValue2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStartValue2.Location = New System.Drawing.Point(863, 44)
        Me.LblStartValue2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblStartValue2.Name = "LblStartValue2"
        Me.LblStartValue2.Size = New System.Drawing.Size(73, 13)
        Me.LblStartValue2.TabIndex = 37
        Me.LblStartValue2.Text = "StartValue2"
        '
        'GrpPresentation
        '
        Me.GrpPresentation.Controls.Add(Me.LblStretching)
        Me.GrpPresentation.Controls.Add(Me.TxtxStretching)
        Me.GrpPresentation.Controls.Add(Me.LblxStretching)
        Me.GrpPresentation.Controls.Add(Me.OptSingleOrbit)
        Me.GrpPresentation.Controls.Add(Me.OptDifference)
        Me.GrpPresentation.Location = New System.Drawing.Point(874, 104)
        Me.GrpPresentation.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GrpPresentation.Name = "GrpPresentation"
        Me.GrpPresentation.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GrpPresentation.Size = New System.Drawing.Size(278, 83)
        Me.GrpPresentation.TabIndex = 38
        Me.GrpPresentation.TabStop = False
        Me.GrpPresentation.Text = "Presentation"
        '
        'LblStretching
        '
        Me.LblStretching.AutoSize = True
        Me.LblStretching.Location = New System.Drawing.Point(140, 56)
        Me.LblStretching.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblStretching.Name = "LblStretching"
        Me.LblStretching.Size = New System.Drawing.Size(54, 13)
        Me.LblStretching.TabIndex = 4
        Me.LblStretching.Text = "DinStretching"
        '
        'TxtxStretching
        '
        Me.TxtxStretching.Location = New System.Drawing.Point(203, 52)
        Me.TxtxStretching.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtxStretching.Name = "TxtxStretching"
        Me.TxtxStretching.Size = New System.Drawing.Size(62, 20)
        Me.TxtxStretching.TabIndex = 3
        '
        'LblxStretching
        '
        Me.LblxStretching.AutoSize = True
        Me.LblxStretching.Location = New System.Drawing.Point(140, 23)
        Me.LblxStretching.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblxStretching.Name = "LblxStretching"
        Me.LblxStretching.Size = New System.Drawing.Size(63, 13)
        Me.LblxStretching.TabIndex = 2
        Me.LblxStretching.Text = "xStretching"
        '
        'OptSingleOrbit
        '
        Me.OptSingleOrbit.AutoSize = True
        Me.OptSingleOrbit.Location = New System.Drawing.Point(12, 53)
        Me.OptSingleOrbit.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.OptSingleOrbit.Name = "OptSingleOrbit"
        Me.OptSingleOrbit.Size = New System.Drawing.Size(84, 17)
        Me.OptSingleOrbit.TabIndex = 1
        Me.OptSingleOrbit.Text = "SingleOrbits"
        Me.OptSingleOrbit.UseVisualStyleBackColor = True
        '
        'OptDifference
        '
        Me.OptDifference.AutoSize = True
        Me.OptDifference.Checked = True
        Me.OptDifference.Location = New System.Drawing.Point(12, 22)
        Me.OptDifference.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.OptDifference.Name = "OptDifference"
        Me.OptDifference.Size = New System.Drawing.Size(108, 17)
        Me.OptDifference.TabIndex = 0
        Me.OptDifference.TabStop = True
        Me.OptDifference.Text = "Difference12"
        Me.OptDifference.UseVisualStyleBackColor = True
        '
        'BtnStartIteration
        '
        Me.BtnStartIteration.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStartIteration.Location = New System.Drawing.Point(883, 198)
        Me.BtnStartIteration.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnStartIteration.Name = "BtnStartIteration"
        Me.BtnStartIteration.Size = New System.Drawing.Size(262, 32)
        Me.BtnStartIteration.TabIndex = 39
        Me.BtnStartIteration.Text = "StartIteration"
        Me.BtnStartIteration.UseVisualStyleBackColor = True
        '
        'BtnReset
        '
        Me.BtnReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReset.Location = New System.Drawing.Point(883, 574)
        Me.BtnReset.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(262, 32)
        Me.BtnReset.TabIndex = 40
        Me.BtnReset.Text = "ResetIteration"
        Me.BtnReset.UseVisualStyleBackColor = True
        '
        'LblNumberOfSteps
        '
        Me.LblNumberOfSteps.AutoSize = True
        Me.LblNumberOfSteps.Location = New System.Drawing.Point(950, 75)
        Me.LblNumberOfSteps.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblNumberOfSteps.Name = "LblNumberOfSteps"
        Me.LblNumberOfSteps.Size = New System.Drawing.Size(13, 13)
        Me.LblNumberOfSteps.TabIndex = 42
        Me.LblNumberOfSteps.Text = "0"
        '
        'LblSteps
        '
        Me.LblSteps.AutoSize = True
        Me.LblSteps.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSteps.Location = New System.Drawing.Point(863, 75)
        Me.LblSteps.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblSteps.Name = "LblSteps"
        Me.LblSteps.Size = New System.Drawing.Size(82, 13)
        Me.LblSteps.TabIndex = 41
        Me.LblSteps.Text = "NumberOfSteps"
        '
        'FrmSensitivity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1162, 611)
        Me.Controls.Add(Me.LblNumberOfSteps)
        Me.Controls.Add(Me.LblSteps)
        Me.Controls.Add(Me.BtnReset)
        Me.Controls.Add(Me.BtnStartIteration)
        Me.Controls.Add(Me.GrpPresentation)
        Me.Controls.Add(Me.TxtStartValue2)
        Me.Controls.Add(Me.LblStartValue2)
        Me.Controls.Add(Me.TxtStartValue1)
        Me.Controls.Add(Me.LblStartValue1)
        Me.Controls.Add(Me.LblValueList2)
        Me.Controls.Add(Me.LstValueList2)
        Me.Controls.Add(Me.LblValueList1)
        Me.Controls.Add(Me.LstValueList1)
        Me.Controls.Add(Me.CboIterationDepth)
        Me.Controls.Add(Me.LblIterationDepth)
        Me.Controls.Add(Me.CboFunction)
        Me.Controls.Add(Me.TxtParameter)
        Me.Controls.Add(Me.LblParameter)
        Me.Controls.Add(Me.PicDiagram)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "FrmSensitivity"
        Me.Text = "Sensitivity"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PicDiagram, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpPresentation.ResumeLayout(False)
        Me.GrpPresentation.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents BtnStartIteration As Button
    Friend WithEvents BtnReset As Button
    Friend WithEvents LblNumberOfSteps As Label
    Friend WithEvents LblSteps As Label
End Class
