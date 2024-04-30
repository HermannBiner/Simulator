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
        LblPersonalData.Font = New Font("Microsoft Sans Serif", 11.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblPersonalData.Location = New Point(9, 101)
        LblPersonalData.Margin = New Padding(2, 0, 2, 0)
        LblPersonalData.Name = "LblPersonalData"
        LblPersonalData.Size = New Size(258, 18)
        LblPersonalData.TabIndex = 0
        LblPersonalData.Text = "Author: Dr.math.ETHZ Hermann Biner"
        ' 
        ' LblFeedback
        ' 
        LblFeedback.AutoSize = True
        LblFeedback.Font = New Font("Microsoft Sans Serif", 11.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblFeedback.Location = New Point(9, 37)
        LblFeedback.Margin = New Padding(2, 0, 2, 0)
        LblFeedback.Name = "LblFeedback"
        LblFeedback.Size = New Size(73, 18)
        LblFeedback.TabIndex = 1
        LblFeedback.Text = "Feedback"
        ' 
        ' LblMail
        ' 
        LblMail.AutoSize = True
        LblMail.Font = New Font("Microsoft Sans Serif", 11.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblMail.Location = New Point(10, 68)
        LblMail.Margin = New Padding(2, 0, 2, 0)
        LblMail.Name = "LblMail"
        LblMail.Size = New Size(53, 18)
        LblMail.TabIndex = 2
        LblMail.Text = "MailTo"
        ' 
        ' LblVersion
        ' 
        LblVersion.AutoSize = True
        LblVersion.Font = New Font("Microsoft Sans Serif", 11.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LblVersion.Location = New Point(9, 7)
        LblVersion.Margin = New Padding(2, 0, 2, 0)
        LblVersion.Name = "LblVersion"
        LblVersion.Size = New Size(116, 18)
        LblVersion.TabIndex = 3
        LblVersion.Text = "ProgramVersion"
        ' 
        ' PicZermatt
        ' 
        PicZermatt.Image = CType(resources.GetObject("PicZermatt.Image"), Image)
        PicZermatt.Location = New Point(446, 7)
        PicZermatt.Margin = New Padding(2, 2, 2, 2)
        PicZermatt.Name = "PicZermatt"
        PicZermatt.Size = New Size(461, 311)
        PicZermatt.SizeMode = PictureBoxSizeMode.StretchImage
        PicZermatt.TabIndex = 4
        PicZermatt.TabStop = False
        ' 
        ' FrmInfo
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(922, 325)
        Controls.Add(PicZermatt)
        Controls.Add(LblVersion)
        Controls.Add(LblMail)
        Controls.Add(LblFeedback)
        Controls.Add(LblPersonalData)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(2, 2, 2, 2)
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
