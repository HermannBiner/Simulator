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
        Me.LblPersonalData = New System.Windows.Forms.Label()
        Me.LblFeedback = New System.Windows.Forms.Label()
        Me.LblMail = New System.Windows.Forms.Label()
        Me.LblVersion = New System.Windows.Forms.Label()
        Me.PicZermatt = New System.Windows.Forms.PictureBox()
        CType(Me.PicZermatt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblPersonalData
        '
        Me.LblPersonalData.AutoSize = True
        Me.LblPersonalData.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPersonalData.Location = New System.Drawing.Point(16, 169)
        Me.LblPersonalData.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPersonalData.Name = "LblPersonalData"
        Me.LblPersonalData.Size = New System.Drawing.Size(540, 36)
        Me.LblPersonalData.TabIndex = 0
        Me.LblPersonalData.Text = "Dr.Math.ETHZ"
        '
        'LblFeedback
        '
        Me.LblFeedback.AutoSize = True
        Me.LblFeedback.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFeedback.Location = New System.Drawing.Point(16, 61)
        Me.LblFeedback.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFeedback.Name = "LblFeedback"
        Me.LblFeedback.Size = New System.Drawing.Size(426, 36)
        Me.LblFeedback.TabIndex = 1
        Me.LblFeedback.Text = "Feedback"
        '
        'LblMail
        '
        Me.LblMail.AutoSize = True
        Me.LblMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMail.Location = New System.Drawing.Point(17, 114)
        Me.LblMail.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblMail.Name = "LblMail"
        Me.LblMail.Size = New System.Drawing.Size(514, 36)
        Me.LblMail.TabIndex = 2
        Me.LblMail.Text = "MailTo"
        '
        'LblVersion
        '
        Me.LblVersion.AutoSize = True
        Me.LblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVersion.Location = New System.Drawing.Point(16, 11)
        Me.LblVersion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblVersion.Name = "LblVersion"
        Me.LblVersion.Size = New System.Drawing.Size(476, 36)
        Me.LblVersion.TabIndex = 3
        Me.LblVersion.Text = "ProgramVersion"
        '
        'PicZermatt
        '
        Me.PicZermatt.Image = Global.Simulator.My.Resources.Resources.Zermatt
        Me.PicZermatt.Location = New System.Drawing.Point(764, 11)
        Me.PicZermatt.Margin = New System.Windows.Forms.Padding(4)
        Me.PicZermatt.Name = "PicZermatt"
        Me.PicZermatt.Size = New System.Drawing.Size(791, 518)
        Me.PicZermatt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicZermatt.TabIndex = 4
        Me.PicZermatt.TabStop = False
        '
        'FrmInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1580, 541)
        Me.Controls.Add(Me.PicZermatt)
        Me.Controls.Add(Me.LblVersion)
        Me.Controls.Add(Me.LblMail)
        Me.Controls.Add(Me.LblFeedback)
        Me.Controls.Add(Me.LblPersonalData)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmInfo"
        Me.Text = "AboutSimulator"
        CType(Me.PicZermatt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblPersonalData As Label
    Friend WithEvents LblFeedback As Label
    Friend WithEvents LblMail As Label
    Friend WithEvents LblVersion As Label
    Friend WithEvents PicZermatt As PictureBox
End Class
