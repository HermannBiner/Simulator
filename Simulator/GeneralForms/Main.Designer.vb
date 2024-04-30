<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.MnuMain = New System.Windows.Forms.MenuStrip()
        Me.MnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuLanguage = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuEnglish = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuGerman = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuUnimodal = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuIteration = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSensitivity = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuHistogram = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTwoDimensions = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFeigenbaum = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMechanics = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBilliard = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCDiagram = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuNumericMethods = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuPendulum = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuComplexIteration = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFractals = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuNewton = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMandelbrot = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTest = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDocumentation = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuManual = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMathematics = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'MnuMain
        '
        Me.MnuMain.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MnuMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFile, Me.MnuUnimodal, Me.MnuMechanics, Me.MnuComplexIteration, Me.MnuTest, Me.MnuDocumentation})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MnuMain.Size = New System.Drawing.Size(2028, 42)
        Me.MnuMain.TabIndex = 0
        Me.MnuMain.Text = "Main"
        '
        'MnuFile
        '
        Me.MnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuLanguage, Me.MnuClose})
        Me.MnuFile.Name = "MnuFile"
        Me.MnuFile.Size = New System.Drawing.Size(71, 38)
        Me.MnuFile.Text = "File"
        '
        'MnuLanguage
        '
        Me.MnuLanguage.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuEnglish, Me.MnuGerman})
        Me.MnuLanguage.Name = "MnuLanguage"
        Me.MnuLanguage.Size = New System.Drawing.Size(251, 44)
        Me.MnuLanguage.Text = "Language"
        '
        'MnuEnglish
        '
        Me.MnuEnglish.Name = "MnuEnglish"
        Me.MnuEnglish.Size = New System.Drawing.Size(231, 44)
        Me.MnuEnglish.Text = "English"
        '
        'MnuGerman
        '
        Me.MnuGerman.Name = "MnuGerman"
        Me.MnuGerman.Size = New System.Drawing.Size(231, 44)
        Me.MnuGerman.Text = "German"
        '
        'MnuClose
        '
        Me.MnuClose.Name = "MnuClose"
        Me.MnuClose.Size = New System.Drawing.Size(251, 44)
        Me.MnuClose.Text = "Close"
        '
        'MnuUnimodal
        '
        Me.MnuUnimodal.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuIteration, Me.MnuSensitivity, Me.MnuHistogram, Me.MnuTwoDimensions, Me.MnuFeigenbaum})
        Me.MnuUnimodal.Name = "MnuUnimodal"
        Me.MnuUnimodal.Size = New System.Drawing.Size(137, 38)
        Me.MnuUnimodal.Text = "Unimodal"
        '
        'MnuIteration
        '
        Me.MnuIteration.Name = "MnuIteration"
        Me.MnuIteration.Size = New System.Drawing.Size(315, 44)
        Me.MnuIteration.Text = "Iteration"
        '
        'MnuSensitivity
        '
        Me.MnuSensitivity.Name = "MnuSensitivity"
        Me.MnuSensitivity.Size = New System.Drawing.Size(315, 44)
        Me.MnuSensitivity.Text = "Sensitivity"
        '
        'MnuHistogram
        '
        Me.MnuHistogram.Name = "MnuHistogram"
        Me.MnuHistogram.Size = New System.Drawing.Size(315, 44)
        Me.MnuHistogram.Text = "Histogram"
        '
        'MnuTwoDimensions
        '
        Me.MnuTwoDimensions.Name = "MnuTwoDimensions"
        Me.MnuTwoDimensions.Size = New System.Drawing.Size(315, 44)
        Me.MnuTwoDimensions.Text = "TwoDimensions"
        '
        'MnuFeigenbaum
        '
        Me.MnuFeigenbaum.Name = "MnuFeigenbaum"
        Me.MnuFeigenbaum.Size = New System.Drawing.Size(315, 44)
        Me.MnuFeigenbaum.Text = "Feigenbaum"
        '
        'MnuMechanics
        '
        Me.MnuMechanics.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuBilliard, Me.MnuCDiagram, Me.MnuNumericMethods, Me.MnuPendulum})
        Me.MnuMechanics.Name = "MnuMechanics"
        Me.MnuMechanics.Size = New System.Drawing.Size(147, 38)
        Me.MnuMechanics.Text = "Mechanics"
        '
        'MnuBilliard
        '
        Me.MnuBilliard.Name = "MnuBilliard"
        Me.MnuBilliard.Size = New System.Drawing.Size(333, 44)
        Me.MnuBilliard.Text = "Billiard"
        '
        'MnuCDiagram
        '
        Me.MnuCDiagram.Name = "MnuCDiagram"
        Me.MnuCDiagram.Size = New System.Drawing.Size(333, 44)
        Me.MnuCDiagram.Text = "CDiagramBilliard"
        '
        'MnuNumericMethods
        '
        Me.MnuNumericMethods.Name = "MnuNumericMethods"
        Me.MnuNumericMethods.Size = New System.Drawing.Size(333, 44)
        Me.MnuNumericMethods.Text = "NumericMethods"
        '
        'MnuPendulum
        '
        Me.MnuPendulum.Name = "MnuPendulum"
        Me.MnuPendulum.Size = New System.Drawing.Size(333, 44)
        Me.MnuPendulum.Text = "Pendulum"
        '
        'MnuComplexIteration
        '
        Me.MnuComplexIteration.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFractals, Me.MnuNewton, Me.MnuMandelbrot})
        Me.MnuComplexIteration.Name = "MnuComplexIteration"
        Me.MnuComplexIteration.Size = New System.Drawing.Size(217, 38)
        Me.MnuComplexIteration.Text = "ComplexIteration"
        '
        'MnuFractals
        '
        Me.MnuFractals.Name = "MnuFractals"
        Me.MnuFractals.Size = New System.Drawing.Size(272, 44)
        Me.MnuFractals.Text = "Fractals"
        '
        'MnuNewton
        '
        Me.MnuNewton.Name = "MnuNewton"
        Me.MnuNewton.Size = New System.Drawing.Size(272, 44)
        Me.MnuNewton.Text = "Newton"
        '
        'MnuMandelbrot
        '
        Me.MnuMandelbrot.Name = "MnuMandelbrot"
        Me.MnuMandelbrot.Size = New System.Drawing.Size(272, 44)
        Me.MnuMandelbrot.Text = "Mandelbrot"
        '
        'MnuTest
        '
        Me.MnuTest.Name = "MnuTest"
        Me.MnuTest.Size = New System.Drawing.Size(76, 38)
        Me.MnuTest.Text = "Test"
        '
        'MnuDocumentation
        '
        Me.MnuDocumentation.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuManual, Me.MnuMathematics, Me.MnuInfo})
        Me.MnuDocumentation.Name = "MnuDocumentation"
        Me.MnuDocumentation.Size = New System.Drawing.Size(200, 38)
        Me.MnuDocumentation.Text = "Documentation"
        '
        'MnuManual
        '
        Me.MnuManual.Name = "MnuManual"
        Me.MnuManual.Size = New System.Drawing.Size(359, 44)
        Me.MnuManual.Text = "Manual"
        '
        'MnuMathematics
        '
        Me.MnuMathematics.Name = "MnuMathematics"
        Me.MnuMathematics.Size = New System.Drawing.Size(359, 44)
        Me.MnuMathematics.Text = "Mathematics"
        '
        'MnuInfo
        '
        Me.MnuInfo.Name = "MnuInfo"
        Me.MnuInfo.Size = New System.Drawing.Size(359, 44)
        Me.MnuInfo.Text = "Info"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2028, 1127)
        Me.Controls.Add(Me.MnuMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MnuMain
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Main"
        Me.Text = "Simulator"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MnuMain As MenuStrip
    Friend WithEvents MnuFile As ToolStripMenuItem
    Friend WithEvents MnuUnimodal As ToolStripMenuItem
    Friend WithEvents MnuIteration As ToolStripMenuItem
    Friend WithEvents MnuDocumentation As ToolStripMenuItem
    Friend WithEvents MnuClose As ToolStripMenuItem
    Friend WithEvents MnuManual As ToolStripMenuItem
    Friend WithEvents MnuMathematics As ToolStripMenuItem
    Friend WithEvents MnuFeigenbaum As ToolStripMenuItem
    Friend WithEvents MnuTwoDimensions As ToolStripMenuItem
    Friend WithEvents MnuInfo As ToolStripMenuItem
    Friend WithEvents MnuHistogram As ToolStripMenuItem
    Friend WithEvents MnuSensitivity As ToolStripMenuItem
    Friend WithEvents MnuTest As ToolStripMenuItem
    Friend WithEvents MnuMechanics As ToolStripMenuItem
    Friend WithEvents MnuPendulum As ToolStripMenuItem
    Friend WithEvents MnuComplexIteration As ToolStripMenuItem
    Friend WithEvents MnuNewton As ToolStripMenuItem
    Friend WithEvents MnuMandelbrot As ToolStripMenuItem
    Friend WithEvents MnuBilliard As ToolStripMenuItem
    Friend WithEvents MnuFractals As ToolStripMenuItem
    Friend WithEvents MnuCDiagram As ToolStripMenuItem
    Friend WithEvents MnuLanguage As ToolStripMenuItem
    Friend WithEvents MnuEnglish As ToolStripMenuItem
    Friend WithEvents MnuGerman As ToolStripMenuItem
    Friend WithEvents MnuNumericMethods As ToolStripMenuItem
End Class
