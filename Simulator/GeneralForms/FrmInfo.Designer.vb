<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInfo))
        SplitContainer = New SplitContainer()
        BtnReleaseNotes = New Button()
        LblVersion = New Label()
        LblMail = New Label()
        LblFeedback = New Label()
        LblPersonalData = New Label()
        PicZermatt = New PictureBox()
        CType(SplitContainer, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer.Panel1.SuspendLayout()
        SplitContainer.Panel2.SuspendLayout()
        SplitContainer.SuspendLayout()
        CType(PicZermatt, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' SplitContainer
        ' 
        SplitContainer.Dock = DockStyle.Fill
        SplitContainer.FixedPanel = FixedPanel.Panel1
        SplitContainer.Location = New Point(0, 0)
        SplitContainer.Name = "SplitContainer"
        ' 
        ' SplitContainer.Panel1
        ' 
        SplitContainer.Panel1.BackColor = SystemColors.Control
        SplitContainer.Panel1.Controls.Add(BtnReleaseNotes)
        SplitContainer.Panel1.Controls.Add(LblVersion)
        SplitContainer.Panel1.Controls.Add(LblMail)
        SplitContainer.Panel1.Controls.Add(LblFeedback)
        SplitContainer.Panel1.Controls.Add(LblPersonalData)
        ' 
        ' SplitContainer.Panel2
        ' 
        SplitContainer.Panel2.BackColor = SystemColors.ControlLight
        SplitContainer.Panel2.Controls.Add(PicZermatt)
        SplitContainer.Size = New Size(784, 417)
        SplitContainer.SplitterDistance = 256
        SplitContainer.SplitterWidth = 6
        SplitContainer.TabIndex = 0
        ' 
        ' BtnReleaseNotes
        ' 
        BtnReleaseNotes.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReleaseNotes.Location = New Point(3, 99)
        BtnReleaseNotes.Name = "BtnReleaseNotes"
        BtnReleaseNotes.Size = New Size(250, 30)
        BtnReleaseNotes.TabIndex = 10
        BtnReleaseNotes.Text = "ReleaseNotes"
        BtnReleaseNotes.UseVisualStyleBackColor = True
        ' 
        ' LblVersion
        ' 
        LblVersion.AutoSize = True
        LblVersion.Font = New Font("Microsoft Sans Serif", 9F)
        LblVersion.Location = New Point(12, -18)
        LblVersion.Margin = New Padding(4, 0, 4, 0)
        LblVersion.Name = "LblVersion"
        LblVersion.Size = New Size(96, 15)
        LblVersion.TabIndex = 9
        LblVersion.Text = "ProgramVersion"
        ' 
        ' LblMail
        ' 
        LblMail.AutoSize = True
        LblMail.Font = New Font("Microsoft Sans Serif", 9F)
        LblMail.Location = New Point(12, 40)
        LblMail.Margin = New Padding(4, 0, 4, 0)
        LblMail.Name = "LblMail"
        LblMail.Size = New Size(45, 15)
        LblMail.TabIndex = 8
        LblMail.Text = "MailTo"
        ' 
        ' LblFeedback
        ' 
        LblFeedback.AutoSize = True
        LblFeedback.Font = New Font("Microsoft Sans Serif", 9F)
        LblFeedback.Location = New Point(12, 9)
        LblFeedback.Margin = New Padding(4, 0, 4, 0)
        LblFeedback.Name = "LblFeedback"
        LblFeedback.Size = New Size(61, 15)
        LblFeedback.TabIndex = 7
        LblFeedback.Text = "Feedback"
        ' 
        ' LblPersonalData
        ' 
        LblPersonalData.AutoSize = True
        LblPersonalData.Font = New Font("Microsoft Sans Serif", 9F)
        LblPersonalData.Location = New Point(12, 71)
        LblPersonalData.Margin = New Padding(4, 0, 4, 0)
        LblPersonalData.Name = "LblPersonalData"
        LblPersonalData.Size = New Size(213, 15)
        LblPersonalData.TabIndex = 6
        LblPersonalData.Text = "Author: Dr.math.ETHZ Hermann Biner"
        ' 
        ' PicZermatt
        ' 
        PicZermatt.Image = CType(resources.GetObject("PicZermatt.Image"), Image)
        PicZermatt.Location = New Point(4, 5)
        PicZermatt.Margin = New Padding(4, 5, 4, 5)
        PicZermatt.Name = "PicZermatt"
        PicZermatt.Size = New Size(500, 400)
        PicZermatt.SizeMode = PictureBoxSizeMode.StretchImage
        PicZermatt.TabIndex = 5
        PicZermatt.TabStop = False
        ' 
        ' FrmInfo
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(784, 417)
        Controls.Add(SplitContainer)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimumSize = New Size(282, 183)
        Name = "FrmInfo"
        StartPosition = FormStartPosition.WindowsDefaultBounds
        Text = "AboutSimulator"
        WindowState = FormWindowState.Maximized
        SplitContainer.Panel1.ResumeLayout(False)
        SplitContainer.Panel1.PerformLayout()
        SplitContainer.Panel2.ResumeLayout(False)
        CType(SplitContainer, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer.ResumeLayout(False)
        CType(PicZermatt, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer As SplitContainer
    Friend WithEvents BtnReleaseNotes As Button
    Friend WithEvents LblVersion As Label
    Friend WithEvents LblMail As Label
    Friend WithEvents LblFeedback As Label
    Friend WithEvents LblPersonalData As Label
    Friend WithEvents PicZermatt As PictureBox
End Class
