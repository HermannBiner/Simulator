﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        MnuComplexIteration = New ToolStripMenuItem()
        MnuNewton = New ToolStripMenuItem()
        MnuJuliaSet = New ToolStripMenuItem()
        MnuMechanics = New ToolStripMenuItem()
        MnuNumericMethods = New ToolStripMenuItem()
        MnuPendulum = New ToolStripMenuItem()
        MnuDocumentation = New ToolStripMenuItem()
        MnuManual = New ToolStripMenuItem()
        MnuTechnical = New ToolStripMenuItem()
        MnuMathematics = New ToolStripMenuItem()
        MnuInfo = New ToolStripMenuItem()
        MnuTest = New ToolStripMenuItem()
        MnuMain.SuspendLayout()
        SuspendLayout()
        ' 
        ' MnuMain
        ' 
        MnuMain.ImageScalingSize = New Size(24, 24)
        MnuMain.Items.AddRange(New ToolStripItem() {MnuLanguage, MnuBilliard, MnuGrowthModels, MnuComplexIteration, MnuMechanics, MnuDocumentation, MnuTest})
        MnuMain.Location = New Point(0, 0)
        MnuMain.Name = "MnuMain"
        MnuMain.Padding = New Padding(10, 2, 0, 2)
        MnuMain.Size = New Size(2366, 45)
        MnuMain.TabIndex = 0
        MnuMain.Text = "Main"
        ' 
        ' MnuLanguage
        ' 
        MnuLanguage.DropDownItems.AddRange(New ToolStripItem() {MnuEnglish, MnuGerman})
        MnuLanguage.Name = "MnuLanguage"
        MnuLanguage.Size = New Size(152, 41)
        MnuLanguage.Text = "Language"
        ' 
        ' MnuEnglish
        ' 
        MnuEnglish.Name = "MnuEnglish"
        MnuEnglish.Size = New Size(315, 46)
        MnuEnglish.Text = "Englisch"
        ' 
        ' MnuGerman
        ' 
        MnuGerman.Name = "MnuGerman"
        MnuGerman.Size = New Size(315, 46)
        MnuGerman.Text = "German"
        ' 
        ' MnuBilliard
        ' 
        MnuBilliard.DropDownItems.AddRange(New ToolStripItem() {MnuBilliardTable, MnuCDiagram})
        MnuBilliard.Name = "MnuBilliard"
        MnuBilliard.Size = New Size(117, 41)
        MnuBilliard.Text = "Billiard"
        ' 
        ' MnuBilliardTable
        ' 
        MnuBilliardTable.Name = "MnuBilliardTable"
        MnuBilliardTable.Size = New Size(315, 46)
        MnuBilliardTable.Text = "BilliardTable"
        ' 
        ' MnuCDiagram
        ' 
        MnuCDiagram.Name = "MnuCDiagram"
        MnuCDiagram.Size = New Size(315, 46)
        MnuCDiagram.Text = "CDiagram"
        ' 
        ' MnuGrowthModels
        ' 
        MnuGrowthModels.DropDownItems.AddRange(New ToolStripItem() {MnuIteration, MnuSensitivity, MnuHistogram, MnuTwoDimensions, MnuFeigenbaum})
        MnuGrowthModels.Name = "MnuGrowthModels"
        MnuGrowthModels.Size = New Size(211, 41)
        MnuGrowthModels.Text = "GrowthModels"
        ' 
        ' MnuIteration
        ' 
        MnuIteration.Name = "MnuIteration"
        MnuIteration.Size = New Size(326, 46)
        MnuIteration.Text = "Iteration"
        ' 
        ' MnuSensitivity
        ' 
        MnuSensitivity.Name = "MnuSensitivity"
        MnuSensitivity.Size = New Size(326, 46)
        MnuSensitivity.Text = "Sensitivity"
        ' 
        ' MnuHistogram
        ' 
        MnuHistogram.Name = "MnuHistogram"
        MnuHistogram.Size = New Size(326, 46)
        MnuHistogram.Text = "Histogram"
        ' 
        ' MnuTwoDimensions
        ' 
        MnuTwoDimensions.Name = "MnuTwoDimensions"
        MnuTwoDimensions.Size = New Size(326, 46)
        MnuTwoDimensions.Text = "TwoDimensions"
        ' 
        ' MnuFeigenbaum
        ' 
        MnuFeigenbaum.Name = "MnuFeigenbaum"
        MnuFeigenbaum.Size = New Size(326, 46)
        MnuFeigenbaum.Text = "Feigenbaum"
        ' 
        ' MnuComplexIteration
        ' 
        MnuComplexIteration.DropDownItems.AddRange(New ToolStripItem() {MnuNewton, MnuJuliaSet})
        MnuComplexIteration.Name = "MnuComplexIteration"
        MnuComplexIteration.Size = New Size(240, 41)
        MnuComplexIteration.Text = "ComplexIteration"
        ' 
        ' MnuNewton
        ' 
        MnuNewton.Name = "MnuNewton"
        MnuNewton.Size = New Size(233, 46)
        MnuNewton.Text = "Newton"
        ' 
        ' MnuJuliaSet
        ' 
        MnuJuliaSet.Name = "MnuJuliaSet"
        MnuJuliaSet.Size = New Size(233, 46)
        MnuJuliaSet.Text = "JuliaSet"
        ' 
        ' MnuMechanics
        ' 
        MnuMechanics.DropDownItems.AddRange(New ToolStripItem() {MnuNumericMethods, MnuPendulum})
        MnuMechanics.Name = "MnuMechanics"
        MnuMechanics.Size = New Size(159, 41)
        MnuMechanics.Text = "Mechanics"
        ' 
        ' MnuNumericMethods
        ' 
        MnuNumericMethods.Name = "MnuNumericMethods"
        MnuNumericMethods.Size = New Size(344, 46)
        MnuNumericMethods.Text = "NumericMethods"
        ' 
        ' MnuPendulum
        ' 
        MnuPendulum.Name = "MnuPendulum"
        MnuPendulum.Size = New Size(344, 46)
        MnuPendulum.Text = "Pendulum"
        ' 
        ' MnuDocumentation
        ' 
        MnuDocumentation.DropDownItems.AddRange(New ToolStripItem() {MnuManual, MnuTechnical, MnuMathematics, MnuInfo})
        MnuDocumentation.Name = "MnuDocumentation"
        MnuDocumentation.Size = New Size(219, 41)
        MnuDocumentation.Text = "Documentation"
        ' 
        ' MnuManual
        ' 
        MnuManual.Name = "MnuManual"
        MnuManual.Size = New Size(293, 46)
        MnuManual.Text = "Manual"
        ' 
        ' MnuTechnical
        ' 
        MnuTechnical.Name = "MnuTechnical"
        MnuTechnical.Size = New Size(293, 46)
        MnuTechnical.Text = "TechnicalDoc"
        ' 
        ' MnuMathematics
        ' 
        MnuMathematics.Name = "MnuMathematics"
        MnuMathematics.Size = New Size(293, 46)
        MnuMathematics.Text = "Mathematics"
        ' 
        ' MnuInfo
        ' 
        MnuInfo.Name = "MnuInfo"
        MnuInfo.Size = New Size(293, 46)
        MnuInfo.Text = "Info"
        ' 
        ' MnuTest
        ' 
        MnuTest.Name = "MnuTest"
        MnuTest.Size = New Size(80, 41)
        MnuTest.Text = "Test"
        MnuTest.Visible = False
        ' 
        ' FrmMain
        ' 
        AutoScaleDimensions = New SizeF(14F, 36F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(2366, 1599)
        Controls.Add(MnuMain)
        Font = New Font("Segoe UI", 11F)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = MnuMain
        Margin = New Padding(4)
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
End Class
