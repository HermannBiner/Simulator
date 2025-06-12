<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSingleNewtonIteration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSingleNewtonIteration))
        SplitContainer = New SplitContainer()
        PicDiagram = New PictureBox()
        BtnReset = New Button()
        BtnNextStep = New Button()
        LblStartpoint = New Label()
        LblI = New Label()
        LblC = New Label()
        TxtA = New TextBox()
        TxtB = New TextBox()
        LblPower = New Label()
        CboN = New ComboBox()
        CType(SplitContainer, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer.Panel1.SuspendLayout()
        SplitContainer.Panel2.SuspendLayout()
        SplitContainer.SuspendLayout()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' SplitContainer
        ' 
        SplitContainer.Dock = DockStyle.Fill
        SplitContainer.FixedPanel = FixedPanel.Panel2
        SplitContainer.Location = New Point(0, 0)
        SplitContainer.Name = "SplitContainer"
        ' 
        ' SplitContainer.Panel1
        ' 
        SplitContainer.Panel1.Controls.Add(PicDiagram)
        ' 
        ' SplitContainer.Panel2
        ' 
        SplitContainer.Panel2.Controls.Add(LblPower)
        SplitContainer.Panel2.Controls.Add(CboN)
        SplitContainer.Panel2.Controls.Add(BtnReset)
        SplitContainer.Panel2.Controls.Add(BtnNextStep)
        SplitContainer.Panel2.Controls.Add(LblStartpoint)
        SplitContainer.Panel2.Controls.Add(LblI)
        SplitContainer.Panel2.Controls.Add(LblC)
        SplitContainer.Panel2.Controls.Add(TxtA)
        SplitContainer.Panel2.Controls.Add(TxtB)
        SplitContainer.Size = New Size(869, 611)
        SplitContainer.SplitterDistance = 606
        SplitContainer.TabIndex = 0
        ' 
        ' PicDiagram
        ' 
        PicDiagram.Location = New Point(3, 3)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(600, 600)
        PicDiagram.TabIndex = 0
        PicDiagram.TabStop = False
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(12, 136)
        BtnReset.Margin = New Padding(4)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(234, 30)
        BtnReset.TabIndex = 62
        BtnReset.Text = "Reset"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' BtnNextStep
        ' 
        BtnNextStep.Font = New Font("Microsoft Sans Serif", 9F)
        BtnNextStep.Location = New Point(12, 98)
        BtnNextStep.Margin = New Padding(4)
        BtnNextStep.Name = "BtnNextStep"
        BtnNextStep.Size = New Size(234, 30)
        BtnNextStep.TabIndex = 61
        BtnNextStep.Text = "NextStep"
        BtnNextStep.UseVisualStyleBackColor = True
        ' 
        ' LblStartpoint
        ' 
        LblStartpoint.AutoSize = True
        LblStartpoint.Font = New Font("Microsoft Sans Serif", 9F)
        LblStartpoint.Location = New Point(12, 41)
        LblStartpoint.Margin = New Padding(4, 0, 4, 0)
        LblStartpoint.Name = "LblStartpoint"
        LblStartpoint.Size = New Size(59, 15)
        LblStartpoint.TabIndex = 60
        LblStartpoint.Text = "Startpoint"
        ' 
        ' LblI
        ' 
        LblI.AutoSize = True
        LblI.Font = New Font("Microsoft Sans Serif", 9F)
        LblI.Location = New Point(137, 63)
        LblI.Margin = New Padding(4, 0, 4, 0)
        LblI.Name = "LblI"
        LblI.Size = New Size(20, 15)
        LblI.TabIndex = 59
        LblI.Text = "+ i"
        ' 
        ' LblC
        ' 
        LblC.AutoSize = True
        LblC.Font = New Font("Microsoft Sans Serif", 9F)
        LblC.Location = New Point(12, 63)
        LblC.Margin = New Padding(4, 0, 4, 0)
        LblC.Name = "LblC"
        LblC.Size = New Size(23, 15)
        LblC.TabIndex = 58
        LblC.Text = "c ="
        ' 
        ' TxtA
        ' 
        TxtA.Font = New Font("Microsoft Sans Serif", 9F)
        TxtA.Location = New Point(46, 60)
        TxtA.Margin = New Padding(4, 2, 4, 2)
        TxtA.Name = "TxtA"
        TxtA.Size = New Size(83, 21)
        TxtA.TabIndex = 57
        TxtA.Text = "0"
        ' 
        ' TxtB
        ' 
        TxtB.Font = New Font("Microsoft Sans Serif", 9F)
        TxtB.Location = New Point(163, 60)
        TxtB.Margin = New Padding(4, 2, 4, 2)
        TxtB.Name = "TxtB"
        TxtB.Size = New Size(83, 21)
        TxtB.TabIndex = 56
        TxtB.Text = "1"
        ' 
        ' LblPower
        ' 
        LblPower.AutoSize = True
        LblPower.Font = New Font("Microsoft Sans Serif", 9F)
        LblPower.Location = New Point(12, 14)
        LblPower.Margin = New Padding(4, 0, 4, 0)
        LblPower.Name = "LblPower"
        LblPower.Size = New Size(24, 15)
        LblPower.TabIndex = 64
        LblPower.Text = "n ="
        ' 
        ' CboN
        ' 
        CboN.DropDownStyle = ComboBoxStyle.DropDownList
        CboN.Font = New Font("Microsoft Sans Serif", 9F)
        CboN.FormattingEnabled = True
        CboN.Items.AddRange(New Object() {"2", "3"})
        CboN.Location = New Point(46, 11)
        CboN.Margin = New Padding(4, 2, 4, 2)
        CboN.Name = "CboN"
        CboN.Size = New Size(48, 23)
        CboN.TabIndex = 63
        ' 
        ' FrmSingleNewtonIteration
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(869, 611)
        Controls.Add(SplitContainer)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "FrmSingleNewtonIteration"
        StartPosition = FormStartPosition.WindowsDefaultBounds
        Text = "SingleNewtonIteration"
        WindowState = FormWindowState.Maximized
        SplitContainer.Panel1.ResumeLayout(False)
        SplitContainer.Panel2.ResumeLayout(False)
        SplitContainer.Panel2.PerformLayout()
        CType(SplitContainer, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer.ResumeLayout(False)
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer As SplitContainer
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents LblStartpoint As Label
    Friend WithEvents LblI As Label
    Friend WithEvents LblC As Label
    Friend WithEvents TxtA As TextBox
    Friend WithEvents TxtB As TextBox
    Friend WithEvents BtnReset As Button
    Friend WithEvents BtnNextStep As Button
    Friend WithEvents LblPower As Label
    Friend WithEvents CboN As ComboBox
End Class
