<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMandelbrotMap
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMandelbrotMap))
        PicMandelbrot = New PictureBox()
        PicJulia = New PictureBox()
        LblI = New Label()
        LblC = New Label()
        TxtA = New TextBox()
        TxtB = New TextBox()
        BtnDefault = New Button()
        CType(PicMandelbrot, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicJulia, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PicMandelbrot
        ' 
        PicMandelbrot.BackColor = Color.White
        PicMandelbrot.Location = New Point(4, 6)
        PicMandelbrot.Margin = New Padding(4)
        PicMandelbrot.Name = "PicMandelbrot"
        PicMandelbrot.Size = New Size(600, 600)
        PicMandelbrot.TabIndex = 29
        PicMandelbrot.TabStop = False
        ' 
        ' PicJulia
        ' 
        PicJulia.BackColor = Color.White
        PicJulia.Location = New Point(612, 43)
        PicJulia.Margin = New Padding(4)
        PicJulia.Name = "PicJulia"
        PicJulia.Size = New Size(563, 563)
        PicJulia.TabIndex = 30
        PicJulia.TabStop = False
        ' 
        ' LblI
        ' 
        LblI.AutoSize = True
        LblI.Font = New Font("Microsoft Sans Serif", 9F)
        LblI.Location = New Point(789, 14)
        LblI.Margin = New Padding(4, 0, 4, 0)
        LblI.Name = "LblI"
        LblI.Size = New Size(20, 15)
        LblI.TabIndex = 62
        LblI.Text = "+ i"
        ' 
        ' LblC
        ' 
        LblC.AutoSize = True
        LblC.Font = New Font("Segoe UI", 9F)
        LblC.Location = New Point(617, 14)
        LblC.Margin = New Padding(4, 0, 4, 0)
        LblC.Name = "LblC"
        LblC.Size = New Size(24, 15)
        LblC.TabIndex = 61
        LblC.Text = "c ="
        ' 
        ' TxtA
        ' 
        TxtA.Font = New Font("Microsoft Sans Serif", 9F)
        TxtA.Location = New Point(643, 11)
        TxtA.Margin = New Padding(4, 2, 4, 2)
        TxtA.Name = "TxtA"
        TxtA.Size = New Size(140, 21)
        TxtA.TabIndex = 60
        TxtA.Text = "0"
        ' 
        ' TxtB
        ' 
        TxtB.Font = New Font("Microsoft Sans Serif", 9F)
        TxtB.Location = New Point(813, 11)
        TxtB.Margin = New Padding(4, 2, 4, 2)
        TxtB.Name = "TxtB"
        TxtB.Size = New Size(140, 21)
        TxtB.TabIndex = 59
        TxtB.Text = "0"
        ' 
        ' BtnDefault
        ' 
        BtnDefault.Font = New Font("Microsoft Sans Serif", 9F)
        BtnDefault.Location = New Point(962, 5)
        BtnDefault.Margin = New Padding(6, 8, 6, 8)
        BtnDefault.Name = "BtnDefault"
        BtnDefault.Size = New Size(213, 30)
        BtnDefault.TabIndex = 63
        BtnDefault.Text = "DefaultUserData"
        BtnDefault.UseVisualStyleBackColor = True
        ' 
        ' FrmMandelbrotMap
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1184, 611)
        Controls.Add(BtnDefault)
        Controls.Add(LblI)
        Controls.Add(LblC)
        Controls.Add(TxtA)
        Controls.Add(TxtB)
        Controls.Add(PicJulia)
        Controls.Add(PicMandelbrot)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "FrmMandelbrotMap"
        Text = "MandelbrotMap"
        WindowState = FormWindowState.Maximized
        CType(PicMandelbrot, ComponentModel.ISupportInitialize).EndInit()
        CType(PicJulia, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PicMandelbrot As PictureBox
    Friend WithEvents PicJulia As PictureBox
    Friend WithEvents LblI As Label
    Friend WithEvents LblC As Label
    Friend WithEvents TxtA As TextBox
    Friend WithEvents TxtB As TextBox
    Friend WithEvents BtnDefault As Button
End Class
