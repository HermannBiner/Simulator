<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTests
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTests))
        SplitContainer = New SplitContainer()
        PicDiagram = New PictureBox()
        BtnReset = New Button()
        LstValues = New ListBox()
        BtnStop = New Button()
        BtnTest = New Button()
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
        SplitContainer.Panel2.Controls.Add(BtnReset)
        SplitContainer.Panel2.Controls.Add(LstValues)
        SplitContainer.Panel2.Controls.Add(BtnStop)
        SplitContainer.Panel2.Controls.Add(BtnTest)
        SplitContainer.Size = New Size(778, 487)
        SplitContainer.SplitterDistance = 488
        SplitContainer.SplitterWidth = 6
        SplitContainer.TabIndex = 0
        ' 
        ' PicDiagram
        ' 
        PicDiagram.BackColor = Color.White
        PicDiagram.BorderStyle = BorderStyle.FixedSingle
        PicDiagram.Location = New Point(4, 5)
        PicDiagram.Margin = New Padding(4, 5, 4, 5)
        PicDiagram.Name = "PicDiagram"
        PicDiagram.Size = New Size(480, 480)
        PicDiagram.TabIndex = 5
        PicDiagram.TabStop = False
        ' 
        ' BtnReset
        ' 
        BtnReset.Font = New Font("Microsoft Sans Serif", 9F)
        BtnReset.Location = New Point(6, 69)
        BtnReset.Margin = New Padding(6, 8, 6, 8)
        BtnReset.Name = "BtnReset"
        BtnReset.Size = New Size(273, 30)
        BtnReset.TabIndex = 11
        BtnReset.Text = "Reset"
        BtnReset.UseVisualStyleBackColor = True
        ' 
        ' LstValues
        ' 
        LstValues.Font = New Font("Microsoft Sans Serif", 9F)
        LstValues.FormattingEnabled = True
        LstValues.ItemHeight = 15
        LstValues.Location = New Point(6, 104)
        LstValues.Margin = New Padding(6, 8, 6, 8)
        LstValues.Name = "LstValues"
        LstValues.Size = New Size(273, 379)
        LstValues.TabIndex = 10
        ' 
        ' BtnStop
        ' 
        BtnStop.Font = New Font("Microsoft Sans Serif", 9F)
        BtnStop.Location = New Point(6, 36)
        BtnStop.Margin = New Padding(6, 8, 6, 8)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(273, 30)
        BtnStop.TabIndex = 9
        BtnStop.Text = "Stop"
        BtnStop.UseVisualStyleBackColor = True
        ' 
        ' BtnTest
        ' 
        BtnTest.Font = New Font("Microsoft Sans Serif", 9F)
        BtnTest.Location = New Point(6, 3)
        BtnTest.Margin = New Padding(4, 5, 4, 5)
        BtnTest.Name = "BtnTest"
        BtnTest.Size = New Size(273, 30)
        BtnTest.TabIndex = 8
        BtnTest.Text = "Start"
        BtnTest.UseVisualStyleBackColor = True
        ' 
        ' FrmTests
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(778, 487)
        Controls.Add(SplitContainer)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "FrmTests"
        StartPosition = FormStartPosition.WindowsDefaultBounds
        Text = "Test"
        WindowState = FormWindowState.Maximized
        SplitContainer.Panel1.ResumeLayout(False)
        SplitContainer.Panel2.ResumeLayout(False)
        CType(SplitContainer, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer.ResumeLayout(False)
        CType(PicDiagram, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer As SplitContainer
    Friend WithEvents PicDiagram As PictureBox
    Friend WithEvents BtnReset As Button
    Friend WithEvents LstValues As ListBox
    Friend WithEvents BtnStop As Button
    Friend WithEvents BtnTest As Button
End Class
