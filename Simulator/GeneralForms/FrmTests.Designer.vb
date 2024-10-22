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
        BtnTest = New Button()
        PicDiagram = New PictureBox()
        BtnStop = New Button()
        LstValues = New ListBox()
        BtnReset = New Button()
        CType(PicDiagram, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BtnTest
        ' 
        BtnTest.Location = New Point(631, 5)
        BtnTest.Margin = New Padding(4, 5, 4, 5)
        BtnTest.Name = "BtnTest"
        BtnTest.Size = New Size(273, 52)
        BtnTest.TabIndex = 2
        BtnTest.Text = "Start"
        BtnTest.UseVisualStyleBackColor = True
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.BorderStyle = BorderStyle.FixedSingle
        PicDiagram.Location = New Point(4, 5)
        PicDiagram.Margin = New Padding(4, 5, 4, 5)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(591, 621)
        PicDiagram.TabIndex = 4
        PicDiagram.TabStop = False
        ' 
        ' BtnStop
        ' 
        BtnStop.Location = New Point(631, 70)
        BtnStop.Margin = New Padding(6, 8, 6, 8)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(273, 51)
        BtnStop.TabIndex = 5
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' LstValues
        ' 
        LstValues.FormattingEnabled = True
        LstValues.ItemHeight = 18
        LstValues.Location = New Point(631, 206)
        LstValues.Margin = New Padding(6, 8, 6, 8)
        LstValues.Name = "LstValues"
        LstValues.Size = New Size(273, 418)
        LstValues.TabIndex = 6
        ' 
        ' BtnReset
        ' 
        BtnReset.Location = New Point(631, 137)
        BtnReset.Margin = New Padding(6, 8, 6, 8)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(273, 53)
        BtnReset.TabIndex = 7
        BtnReset.Text = "Reset"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' FrmTests
        ' 
        AutoScaleDimensions = New SizeF(9F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        BackgroundImageLayout = ImageLayout.None
        ClientSize = New Size(925, 640)
        Controls.Add(BtnReset)
        Controls.Add(LstValues)
        Controls.Add(BtnStop)
        Controls.Add(PicDiagram)
        Controls.Add(BtnTest)
        Font = New Font("Microsoft Sans Serif", 11.1428576F)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4, 5, 4, 5)
        Name = "FrmTests"
        Text = "Test"
        WindowState = FormWindowState.Maximized
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub
    Friend WithEvents BtnTest As Button
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents BtnStop As Button
    Friend WithEvents LstValues As ListBox
    Friend WithEvents BtnReset As Button
End Class
