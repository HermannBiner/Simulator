<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        MnuMain = New MenuStrip()
        MnuLanguage = New ToolStripMenuItem()
        MnuEnglish = New ToolStripMenuItem()
        MnuGerman = New ToolStripMenuItem()
        MnuBilliard = New ToolStripMenuItem()
        MnuBilliardTable = New ToolStripMenuItem()
        MnuCDiagram = New ToolStripMenuItem()
        MnuGrowthModels = New ToolStripMenuItem()
        MnuIteration = New ToolStripMenuItem()
        MnuSensitivity = New ToolStripMenuItem()
        MnuHistogram = New ToolStripMenuItem()
        MnuTwoDimensions = New ToolStripMenuItem()
        MnuFeigenbaum = New ToolStripMenuItem()
        MnuPopulationDensity = New ToolStripMenuItem()
        MnuComplexIteration = New ToolStripMenuItem()
        MnuNewton = New ToolStripMenuItem()
        MnuJuliaSet = New ToolStripMenuItem()
        MnuMandelbrotMap = New ToolStripMenuItem()
        MnuMechanics = New ToolStripMenuItem()
        MnuNumericMethods = New ToolStripMenuItem()
        MnuPendulum = New ToolStripMenuItem()
        MnuUniverse = New ToolStripMenuItem()
        MnuGeometry = New ToolStripMenuItem()
        MnuStrangeAttractors = New ToolStripMenuItem()
        MnuHopfBifurcation = New ToolStripMenuItem()
        MnuFractals = New ToolStripMenuItem()
        MnuDocumentation = New ToolStripMenuItem()
        MnuManual = New ToolStripMenuItem()
        MnuTechnical = New ToolStripMenuItem()
        MnuMathematics = New ToolStripMenuItem()
        MnuMathDocPart1 = New ToolStripMenuItem()
        MnuMathDocPart2 = New ToolStripMenuItem()
        MnuInfo = New ToolStripMenuItem()
        MnuTest = New ToolStripMenuItem()
        MnuMain.SuspendLayout()
        SuspendLayout()
        ' 
        ' MnuMain
        ' 
        MnuMain.ImageScalingSize = New Size(24, 24)
        MnuMain.Items.AddRange(New ToolStripItem() {MnuLanguage, MnuBilliard, MnuGrowthModels, MnuComplexIteration, MnuMechanics, MnuGeometry, MnuDocumentation, MnuTest})
        MnuMain.Location = New Point(0, 0)
        MnuMain.Name = "MnuMain"
        MnuMain.Padding = New Padding(11, 2, 0, 2)
        MnuMain.Size = New Size(1284, 24)
        MnuMain.TabIndex = 0
        MnuMain.Text = "Main"
        ' 
        ' MnuLanguage
        ' 
        MnuLanguage.DropDownItems.AddRange(New ToolStripItem() {MnuEnglish, MnuGerman})
        MnuLanguage.Font = New Font("Microsoft Sans Serif", 9F)
        MnuLanguage.Name = "MnuLanguage"
        MnuLanguage.Size = New Size(75, 20)
        MnuLanguage.Text = "Language"
        ' 
        ' MnuEnglish
        ' 
        MnuEnglish.Name = "MnuEnglish"
        MnuEnglish.Size = New Size(121, 22)
        MnuEnglish.Text = "Englisch"
        ' 
        ' MnuGerman
        ' 
        MnuGerman.Name = "MnuGerman"
        MnuGerman.Size = New Size(121, 22)
        MnuGerman.Text = "German"
        ' 
        ' MnuBilliard
        ' 
        MnuBilliard.DropDownItems.AddRange(New ToolStripItem() {MnuBilliardTable, MnuCDiagram})
        MnuBilliard.Font = New Font("Microsoft Sans Serif", 9F)
        MnuBilliard.Name = "MnuBilliard"
        MnuBilliard.Size = New Size(57, 20)
        MnuBilliard.Text = "Billiard"
        ' 
        ' MnuBilliardTable
        ' 
        MnuBilliardTable.Name = "MnuBilliardTable"
        MnuBilliardTable.Size = New Size(143, 22)
        MnuBilliardTable.Text = "BilliardTable"
        ' 
        ' MnuCDiagram
        ' 
        MnuCDiagram.Name = "MnuCDiagram"
        MnuCDiagram.Size = New Size(143, 22)
        MnuCDiagram.Text = "CDiagram"
        ' 
        ' MnuGrowthModels
        ' 
        MnuGrowthModels.DropDownItems.AddRange(New ToolStripItem() {MnuIteration, MnuSensitivity, MnuHistogram, MnuTwoDimensions, MnuFeigenbaum, MnuPopulationDensity})
        MnuGrowthModels.Font = New Font("Microsoft Sans Serif", 9F)
        MnuGrowthModels.Name = "MnuGrowthModels"
        MnuGrowthModels.Size = New Size(99, 20)
        MnuGrowthModels.Text = "GrowthModels"
        ' 
        ' MnuIteration
        ' 
        MnuIteration.Name = "MnuIteration"
        MnuIteration.Size = New Size(173, 22)
        MnuIteration.Text = "Iteration"
        ' 
        ' MnuSensitivity
        ' 
        MnuSensitivity.Name = "MnuSensitivity"
        MnuSensitivity.Size = New Size(173, 22)
        MnuSensitivity.Text = "Sensitivity"
        ' 
        ' MnuHistogram
        ' 
        MnuHistogram.Name = "MnuHistogram"
        MnuHistogram.Size = New Size(173, 22)
        MnuHistogram.Text = "Histogram"
        ' 
        ' MnuTwoDimensions
        ' 
        MnuTwoDimensions.Name = "MnuTwoDimensions"
        MnuTwoDimensions.Size = New Size(173, 22)
        MnuTwoDimensions.Text = "TwoDimensions"
        ' 
        ' MnuFeigenbaum
        ' 
        MnuFeigenbaum.Name = "MnuFeigenbaum"
        MnuFeigenbaum.Size = New Size(173, 22)
        MnuFeigenbaum.Text = "Feigenbaum"
        ' 
        ' MnuPopulationDensity
        ' 
        MnuPopulationDensity.Name = "MnuPopulationDensity"
        MnuPopulationDensity.Size = New Size(173, 22)
        MnuPopulationDensity.Text = "PopulationDensity"
        ' 
        ' MnuComplexIteration
        ' 
        MnuComplexIteration.DropDownItems.AddRange(New ToolStripItem() {MnuNewton, MnuJuliaSet, MnuMandelbrotMap})
        MnuComplexIteration.Font = New Font("Microsoft Sans Serif", 9F)
        MnuComplexIteration.Name = "MnuComplexIteration"
        MnuComplexIteration.Size = New Size(112, 20)
        MnuComplexIteration.Text = "ComplexIteration"
        ' 
        ' MnuNewton
        ' 
        MnuNewton.Name = "MnuNewton"
        MnuNewton.Size = New Size(162, 22)
        MnuNewton.Text = "Newton"
        ' 
        ' MnuJuliaSet
        ' 
        MnuJuliaSet.Name = "MnuJuliaSet"
        MnuJuliaSet.Size = New Size(162, 22)
        MnuJuliaSet.Text = "JuliaSet"
        ' 
        ' MnuMandelbrotMap
        ' 
        MnuMandelbrotMap.Name = "MnuMandelbrotMap"
        MnuMandelbrotMap.Size = New Size(162, 22)
        MnuMandelbrotMap.Text = "MandelbrotMap"
        ' 
        ' MnuMechanics
        ' 
        MnuMechanics.DropDownItems.AddRange(New ToolStripItem() {MnuNumericMethods, MnuPendulum, MnuUniverse})
        MnuMechanics.Font = New Font("Microsoft Sans Serif", 9F)
        MnuMechanics.Name = "MnuMechanics"
        MnuMechanics.Size = New Size(79, 20)
        MnuMechanics.Text = "Mechanics"
        ' 
        ' MnuNumericMethods
        ' 
        MnuNumericMethods.Name = "MnuNumericMethods"
        MnuNumericMethods.Size = New Size(169, 22)
        MnuNumericMethods.Text = "NumericMethods"
        ' 
        ' MnuPendulum
        ' 
        MnuPendulum.Name = "MnuPendulum"
        MnuPendulum.Size = New Size(169, 22)
        MnuPendulum.Text = "Pendulum"
        ' 
        ' MnuUniverse
        ' 
        MnuUniverse.Name = "MnuUniverse"
        MnuUniverse.Size = New Size(169, 22)
        MnuUniverse.Text = "Universe"
        ' 
        ' MnuGeometry
        ' 
        MnuGeometry.DropDownItems.AddRange(New ToolStripItem() {MnuStrangeAttractors, MnuHopfBifurcation, MnuFractals})
        MnuGeometry.Name = "MnuGeometry"
        MnuGeometry.Size = New Size(71, 20)
        MnuGeometry.Text = "Geometry"
        ' 
        ' MnuStrangeAttractors
        ' 
        MnuStrangeAttractors.Name = "MnuStrangeAttractors"
        MnuStrangeAttractors.Size = New Size(166, 22)
        MnuStrangeAttractors.Text = "StrangeAttractors"
        ' 
        ' MnuHopfBifurcation
        ' 
        MnuHopfBifurcation.Name = "MnuHopfBifurcation"
        MnuHopfBifurcation.Size = New Size(166, 22)
        MnuHopfBifurcation.Text = "HopfBifurcation"
        ' 
        ' MnuFractals
        ' 
        MnuFractals.Name = "MnuFractals"
        MnuFractals.Size = New Size(166, 22)
        MnuFractals.Text = "Fractals"
        ' 
        ' MnuDocumentation
        ' 
        MnuDocumentation.DropDownItems.AddRange(New ToolStripItem() {MnuManual, MnuTechnical, MnuMathematics, MnuInfo})
        MnuDocumentation.Font = New Font("Microsoft Sans Serif", 9F)
        MnuDocumentation.Name = "MnuDocumentation"
        MnuDocumentation.Size = New Size(103, 20)
        MnuDocumentation.Text = "Documentation"
        ' 
        ' MnuManual
        ' 
        MnuManual.Name = "MnuManual"
        MnuManual.Size = New Size(149, 22)
        MnuManual.Text = "Manual"
        ' 
        ' MnuTechnical
        ' 
        MnuTechnical.Name = "MnuTechnical"
        MnuTechnical.Size = New Size(149, 22)
        MnuTechnical.Text = "TechnicalDoc"
        ' 
        ' MnuMathematics
        ' 
        MnuMathematics.DropDownItems.AddRange(New ToolStripItem() {MnuMathDocPart1, MnuMathDocPart2})
        MnuMathematics.Name = "MnuMathematics"
        MnuMathematics.Size = New Size(149, 22)
        MnuMathematics.Text = "Mathematics"
        ' 
        ' MnuMathDocPart1
        ' 
        MnuMathDocPart1.Name = "MnuMathDocPart1"
        MnuMathDocPart1.Size = New Size(103, 22)
        MnuMathDocPart1.Text = "Part1"
        ' 
        ' MnuMathDocPart2
        ' 
        MnuMathDocPart2.Name = "MnuMathDocPart2"
        MnuMathDocPart2.Size = New Size(103, 22)
        MnuMathDocPart2.Text = "Part2"
        ' 
        ' MnuInfo
        ' 
        MnuInfo.Name = "MnuInfo"
        MnuInfo.Size = New Size(149, 22)
        MnuInfo.Text = "Info"
        ' 
        ' MnuTest
        ' 
        MnuTest.Font = New Font("Microsoft Sans Serif", 9F)
        MnuTest.Name = "MnuTest"
        MnuTest.Size = New Size(42, 20)
        MnuTest.Text = "Test"
        MnuTest.Visible = False
        ' 
        ' FrmMain
        ' 
        AutoScaleDimensions = New SizeF(9F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1284, 781)
        Controls.Add(MnuMain)
        Font = New Font("Microsoft Sans Serif", 11.14F)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = MnuMain
        Margin = New Padding(4, 3, 4, 3)
        Name = "FrmMain"
        Text = "Simulator"
        WindowState = FormWindowState.Maximized
        MnuMain.ResumeLayout(False)
        MnuMain.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents MnuMain As MenuStrip
    Friend WithEvents MnuGrowthModels As ToolStripMenuItem
    Friend WithEvents MnuIteration As ToolStripMenuItem
    Friend WithEvents MnuDocumentation As ToolStripMenuItem
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
    Friend WithEvents MnuJuliaSet As ToolStripMenuItem
    Friend WithEvents MnuLanguage As ToolStripMenuItem
    Friend WithEvents MnuNumericMethods As ToolStripMenuItem
    Friend WithEvents MnuEnglish As ToolStripMenuItem
    Friend WithEvents MnuGerman As ToolStripMenuItem
    Friend WithEvents MnuBilliard As ToolStripMenuItem
    Friend WithEvents MnuBilliardTable As ToolStripMenuItem
    Friend WithEvents MnuCDiagram As ToolStripMenuItem
    Friend WithEvents MnuTechnical As ToolStripMenuItem
    Friend WithEvents MnuPopulationDensity As ToolStripMenuItem
    Friend WithEvents MnuMandelbrotMap As ToolStripMenuItem
    Friend WithEvents MnuUniverse As ToolStripMenuItem
    Friend WithEvents MnuMathDocPart1 As ToolStripMenuItem
    Friend WithEvents MnuMathDocPart2 As ToolStripMenuItem
    Friend WithEvents MnuGeometry As ToolStripMenuItem
    Friend WithEvents MnuStrangeAttractors As ToolStripMenuItem
    Friend WithEvents MnuFractals As ToolStripMenuItem
    Friend WithEvents MnuHopfBifurcation As ToolStripMenuItem
End Class
