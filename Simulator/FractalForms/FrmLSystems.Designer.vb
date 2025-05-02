<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLSystems
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLSystems))
        SplitContainer = New SplitContainer()
        PicDiagram = New PictureBox()
        GrpRules = New GroupBox()
        CboRules = New ComboBox()
        GrpSystemParameters = New GroupBox()
        BtnDeleteSystem = New Button()
        BtnCreate = New Button()
        LblShowColor = New Label()
        LblColor = New Label()
        CboBallColor = New ComboBox()
        TextBox1 = New TextBox()
        Label1 = New Label()
        TxtAngleLeft = New TextBox()
        LblAngleLeft = New Label()
        TxtAxiom = New TextBox()
        LblAxiom = New Label()
        CboSystem = New ComboBox()
        TextBox2 = New TextBox()
        LblScaleFactor = New Label()
        CType(SplitContainer, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer.Panel1.SuspendLayout()
        SplitContainer.Panel2.SuspendLayout()
        SplitContainer.SuspendLayout()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        GrpRules.SuspendLayout()
        GrpSystemParameters.SuspendLayout()
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
        SplitContainer.Panel2.Controls.Add(GrpRules)
        SplitContainer.Panel2.Controls.Add(GrpSystemParameters)
        SplitContainer.Panel2.Controls.Add(CboSystem)
        SplitContainer.Size = New Size(1164, 611)
        SplitContainer.SplitterDistance = 606
        SplitContainer.SplitterWidth = 6
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
        ' GrpRules
        ' 
        GrpRules.Controls.Add(CboRules)
        GrpRules.Location = New Point(10, 225)
        GrpRules.Name = "GrpRules"
        GrpRules.Size = New Size(347, 194)
        GrpRules.TabIndex = 70
        GrpRules.TabStop = False
        GrpRules.Text = "Rules"
        ' 
        ' CboRules
        ' 
        CboRules.FormattingEnabled = True
        CboRules.Location = New Point(5, 22)
        CboRules.Name = "CboRules"
        CboRules.Size = New Size(336, 23)
        CboRules.TabIndex = 0
        ' 
        ' GrpSystemParameters
        ' 
        GrpSystemParameters.Controls.Add(TextBox2)
        GrpSystemParameters.Controls.Add(LblScaleFactor)
        GrpSystemParameters.Controls.Add(BtnDeleteSystem)
        GrpSystemParameters.Controls.Add(BtnCreate)
        GrpSystemParameters.Controls.Add(LblShowColor)
        GrpSystemParameters.Controls.Add(LblColor)
        GrpSystemParameters.Controls.Add(CboBallColor)
        GrpSystemParameters.Controls.Add(TextBox1)
        GrpSystemParameters.Controls.Add(Label1)
        GrpSystemParameters.Controls.Add(TxtAngleLeft)
        GrpSystemParameters.Controls.Add(LblAngleLeft)
        GrpSystemParameters.Controls.Add(TxtAxiom)
        GrpSystemParameters.Controls.Add(LblAxiom)
        GrpSystemParameters.Location = New Point(10, 41)
        GrpSystemParameters.Name = "GrpSystemParameters"
        GrpSystemParameters.Size = New Size(347, 178)
        GrpSystemParameters.TabIndex = 69
        GrpSystemParameters.TabStop = False
        GrpSystemParameters.Text = "SystemParameters"
        ' 
        ' BtnDeleteSystem
        ' 
        BtnDeleteSystem.Location = New Point(181, 139)
        BtnDeleteSystem.Name = "BtnDeleteSystem"
        BtnDeleteSystem.Size = New Size(160, 28)
        BtnDeleteSystem.TabIndex = 73
        BtnDeleteSystem.Text = "DeleteSystem"
        BtnDeleteSystem.UseVisualStyleBackColor = True
        ' 
        ' BtnCreate
        ' 
        BtnCreate.Location = New Point(5, 139)
        BtnCreate.Name = "BtnCreate"
        BtnCreate.Size = New Size(160, 28)
        BtnCreate.TabIndex = 72
        BtnCreate.Text = "CreateSystem"
        BtnCreate.UseVisualStyleBackColor = True
        ' 
        ' LblShowColor
        ' 
        LblShowColor.BackColor = Color.Red
        LblShowColor.Location = New Point(248, 98)
        LblShowColor.Margin = New Padding(4, 0, 4, 0)
        LblShowColor.Name = "LblShowColor"
        LblShowColor.Size = New Size(48, 23)
        LblShowColor.TabIndex = 71
        ' 
        ' LblColor
        ' 
        LblColor.AutoSize = True
        LblColor.Font = New Font("Microsoft Sans Serif", 9F)
        LblColor.Location = New Point(7, 101)
        LblColor.Margin = New Padding(4, 0, 4, 0)
        LblColor.Name = "LblColor"
        LblColor.Size = New Size(36, 15)
        LblColor.TabIndex = 70
        LblColor.Text = "Color"
        ' 
        ' CboBallColor
        ' 
        CboBallColor.BackColor = SystemColors.Window
        CboBallColor.Font = New Font("Microsoft Sans Serif", 9F)
        CboBallColor.FormattingEnabled = True
        CboBallColor.Items.AddRange(New Object() {"Red", "Green", "Blue", "Black", "Magenta"})
        CboBallColor.Location = New Point(88, 98)
        CboBallColor.Margin = New Padding(4)
        CboBallColor.Name = "CboBallColor"
        CboBallColor.Size = New Size(152, 23)
        CboBallColor.TabIndex = 69
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(223, 58)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(45, 23)
        TextBox1.TabIndex = 12
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(140, 66)
        Label1.Name = "Label1"
        Label1.Size = New Size(66, 15)
        Label1.TabIndex = 11
        Label1.Text = "AngleRight"
        ' 
        ' TxtAngleLeft
        ' 
        TxtAngleLeft.Location = New Point(89, 58)
        TxtAngleLeft.Name = "TxtAngleLeft"
        TxtAngleLeft.Size = New Size(45, 23)
        TxtAngleLeft.TabIndex = 10
        ' 
        ' LblAngleLeft
        ' 
        LblAngleLeft.AutoSize = True
        LblAngleLeft.Location = New Point(5, 66)
        LblAngleLeft.Name = "LblAngleLeft"
        LblAngleLeft.Size = New Size(58, 15)
        LblAngleLeft.TabIndex = 9
        LblAngleLeft.Text = "AngleLeft"
        ' 
        ' TxtAxiom
        ' 
        TxtAxiom.Location = New Point(89, 22)
        TxtAxiom.Name = "TxtAxiom"
        TxtAxiom.Size = New Size(45, 23)
        TxtAxiom.TabIndex = 8
        ' 
        ' LblAxiom
        ' 
        LblAxiom.AutoSize = True
        LblAxiom.Location = New Point(6, 30)
        LblAxiom.Name = "LblAxiom"
        LblAxiom.Size = New Size(41, 15)
        LblAxiom.TabIndex = 7
        LblAxiom.Text = "Axiom"
        ' 
        ' CboSystem
        ' 
        CboSystem.FormattingEnabled = True
        CboSystem.Location = New Point(10, 12)
        CboSystem.Name = "CboSystem"
        CboSystem.Size = New Size(347, 23)
        CboSystem.TabIndex = 0
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(223, 22)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(45, 23)
        TextBox2.TabIndex = 75
        ' 
        ' LblScaleFactor
        ' 
        LblScaleFactor.AutoSize = True
        LblScaleFactor.Location = New Point(140, 30)
        LblScaleFactor.Name = "LblScaleFactor"
        LblScaleFactor.Size = New Size(67, 15)
        LblScaleFactor.TabIndex = 74
        LblScaleFactor.Text = "ScaleFactor"
        ' 
        ' FrmLSystems
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1164, 611)
        Controls.Add(SplitContainer)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "FrmLSystems"
        StartPosition = FormStartPosition.WindowsDefaultBounds
        Text = "FrmLSystems"
        WindowState = FormWindowState.Maximized
        SplitContainer.Panel1.ResumeLayout(False)
        SplitContainer.Panel2.ResumeLayout(False)
        CType(SplitContainer, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer.ResumeLayout(False)
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        GrpRules.ResumeLayout(False)
        GrpSystemParameters.ResumeLayout(False)
        GrpSystemParameters.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer As SplitContainer
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents CboSystem As ComboBox
    Friend WithEvents GrpSystemParameters As GroupBox
    Friend WithEvents LblShowColor As Label
    Friend WithEvents LblColor As Label
    Friend WithEvents CboBallColor As ComboBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtAngleLeft As TextBox
    Friend WithEvents LblAngleLeft As Label
    Friend WithEvents TxtAxiom As TextBox
    Friend WithEvents LblAxiom As Label
    Friend WithEvents GrpRules As GroupBox
    Friend WithEvents CboRules As ComboBox
    Friend WithEvents BtnDeleteSystem As Button
    Friend WithEvents BtnCreate As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents LblScaleFactor As Label
End Class
