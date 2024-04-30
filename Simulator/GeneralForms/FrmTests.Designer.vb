<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTests
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTests))
        Me.BtnTest = New System.Windows.Forms.Button()
        Me.PicDiagram = New System.Windows.Forms.PictureBox()
        Me.BtnStop = New System.Windows.Forms.Button()
        Me.LstValues = New System.Windows.Forms.ListBox()
        Me.BtnReset = New System.Windows.Forms.Button()
        CType(Me.PicDiagram, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnTest
        '
        Me.BtnTest.Location = New System.Drawing.Point(1240, 4)
        Me.BtnTest.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnTest.Name = "BtnTest"
        Me.BtnTest.Size = New System.Drawing.Size(308, 65)
        Me.BtnTest.TabIndex = 2
        Me.BtnTest.Text = "Start"
        Me.BtnTest.UseVisualStyleBackColor = True
        '
        'PicDiagram
        '
        Me.PicDiagram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicDiagram.Location = New System.Drawing.Point(16, 4)
        Me.PicDiagram.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PicDiagram.Name = "PicDiagram"
        Me.PicDiagram.Size = New System.Drawing.Size(1198, 1152)
        Me.PicDiagram.TabIndex = 4
        Me.PicDiagram.TabStop = False
        '
        'BtnStop
        '
        Me.BtnStop.Location = New System.Drawing.Point(1240, 100)
        Me.BtnStop.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(308, 65)
        Me.BtnStop.TabIndex = 5
        Me.BtnStop.Text = "Stop"
        Me.BtnStop.UseVisualStyleBackColor = True
        '
        'LstValues
        '
        Me.LstValues.FormattingEnabled = True
        Me.LstValues.ItemHeight = 25
        Me.LstValues.Location = New System.Drawing.Point(1240, 302)
        Me.LstValues.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.LstValues.Name = "LstValues"
        Me.LstValues.Size = New System.Drawing.Size(628, 854)
        Me.LstValues.TabIndex = 6
        '
        'BtnReset
        '
        Me.BtnReset.Location = New System.Drawing.Point(1240, 200)
        Me.BtnReset.Margin = New System.Windows.Forms.Padding(6)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(308, 65)
        Me.BtnReset.TabIndex = 7
        Me.BtnReset.Text = "Reset"
        Me.BtnReset.UseVisualStyleBackColor = True
        '
        'FrmTests
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1908, 1212)
        Me.Controls.Add(Me.BtnReset)
        Me.Controls.Add(Me.LstValues)
        Me.Controls.Add(Me.BtnStop)
        Me.Controls.Add(Me.PicDiagram)
        Me.Controls.Add(Me.BtnTest)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmTests"
        Me.Text = "Test"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PicDiagram, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnTest As Button
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents BtnStop As Button
    Friend WithEvents LstValues As ListBox
    Friend WithEvents BtnReset As Button
End Class
