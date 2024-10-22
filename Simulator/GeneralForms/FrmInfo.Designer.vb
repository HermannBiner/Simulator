<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInfo))
        LblPersonalData = New Label()
        LblFeedback = New Label()
        LblMail = New Label()
        LblVersion = New Label()
        PicZermatt = New PictureBox()
        CType(PicZermatt, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LblPersonalData
        ' 
        LblPersonalData.AutoSize = True
        LblPersonalData.Font = New Font("Microsoft Sans Serif", 9F)
        LblPersonalData.Location = New Point(19, 103)
        LblPersonalData.Margin = New Padding(4, 0, 4, 0)
        LblPersonalData.Name = "LblPersonalData"
        LblPersonalData.Size = New Size(213, 15)
        LblPersonalData.TabIndex = 0
        LblPersonalData.Text = "Author: Dr.math.ETHZ Hermann Biner"
        ' 
        ' LblFeedback
        ' 
        LblFeedback.AutoSize = True
        LblFeedback.Font = New Font("Microsoft Sans Serif", 9F)
        LblFeedback.Location = New Point(19, 41)
        LblFeedback.Margin = New Padding(4, 0, 4, 0)
        LblFeedback.Name = "LblFeedback"
        LblFeedback.Size = New Size(61, 15)
        LblFeedback.TabIndex = 1
        LblFeedback.Text = "Feedback"
        ' 
        ' LblMail
        ' 
        LblMail.AutoSize = True
        LblMail.Font = New Font("Microsoft Sans Serif", 9F)
        LblMail.Location = New Point(19, 72)
        LblMail.Margin = New Padding(4, 0, 4, 0)
        LblMail.Name = "LblMail"
        LblMail.Size = New Size(45, 15)
        LblMail.TabIndex = 2
        LblMail.Text = "MailTo"
        ' 
        ' LblVersion
        ' 
        LblVersion.AutoSize = True
        LblVersion.Font = New Font("Microsoft Sans Serif", 9F)
        LblVersion.Location = New Point(19, 14)
        LblVersion.Margin = New Padding(4, 0, 4, 0)
        LblVersion.Name = "LblVersion"
        LblVersion.Size = New Size(96, 15)
        LblVersion.TabIndex = 3
        LblVersion.Text = "ProgramVersion"
        ' 
        ' PicZermatt
        ' 
        PicZermatt.Image = CType(resources.GetObject("PicZermatt.Image"), Image)
        PicZermatt.Location = New Point(294, 13)
        PicZermatt.Margin = New Padding(4)
        PicZermatt.Name = "PicZermatt"
        PicZermatt.Size = New Size(283, 198)
        PicZermatt.SizeMode = PictureBoxSizeMode.StretchImage
        PicZermatt.TabIndex = 4
        PicZermatt.TabStop = False
        ' 
        ' FrmInfo
        ' 
        AutoScaleDimensions = New SizeF(9F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(586, 215)
        Controls.Add(PicZermatt)
        Controls.Add(LblVersion)
        Controls.Add(LblMail)
        Controls.Add(LblFeedback)
        Controls.Add(LblPersonalData)
        Font = New Font("Microsoft Sans Serif", 11F)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4)
        Name = "FrmInfo"
        Text = "AboutSimulator"
        CType(PicZermatt, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents LblPersonalData As Label
    Friend WithEvents LblFeedback As Label
    Friend WithEvents LblMail As Label
    Friend WithEvents LblVersion As Label
    Friend WithEvents PicZermatt As PictureBox
End Class
