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
            MyBitmap.Dispose()
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
        CType(Me.PicDiagram, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnTest
        '
        Me.BtnTest.Location = New System.Drawing.Point(620, 2)
        Me.BtnTest.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnTest.Name = "BtnTest"
        Me.BtnTest.Size = New System.Drawing.Size(154, 34)
        Me.BtnTest.TabIndex = 2
        Me.BtnTest.Text = "Start"
        Me.BtnTest.UseVisualStyleBackColor = True
        '
        'PicDiagram
        '
        Me.PicDiagram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicDiagram.Location = New System.Drawing.Point(8, 2)
        Me.PicDiagram.Margin = New System.Windows.Forms.Padding(2)
        Me.PicDiagram.Name = "PicDiagram"
        Me.PicDiagram.Size = New System.Drawing.Size(600, 600)
        Me.PicDiagram.TabIndex = 4
        Me.PicDiagram.TabStop = False
        '
        'BtnStop
        '
        Me.BtnStop.Location = New System.Drawing.Point(620, 59)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(154, 34)
        Me.BtnStop.TabIndex = 5
        Me.BtnStop.Text = "Stop"
        Me.BtnStop.UseVisualStyleBackColor = True
        '
        'LstValues
        '
        Me.LstValues.FormattingEnabled = True
        Me.LstValues.Location = New System.Drawing.Point(623, 107)
        Me.LstValues.Name = "LstValues"
        Me.LstValues.Size = New System.Drawing.Size(316, 485)
        Me.LstValues.TabIndex = 6
        '
        'FrmTests
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(954, 630)
        Me.Controls.Add(Me.LstValues)
        Me.Controls.Add(Me.BtnStop)
        Me.Controls.Add(Me.PicDiagram)
        Me.Controls.Add(Me.BtnTest)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
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
End Class
