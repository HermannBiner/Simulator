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
        MnuFile = New ToolStripMenuItem()
        MnuLanguage = New ToolStripMenuItem()
        MnuEnglish = New ToolStripMenuItem()
        MnuGerman = New ToolStripMenuItem()
        MnuClose = New ToolStripMenuItem()
        MnuUnimodal = New ToolStripMenuItem()
        MnuIteration = New ToolStripMenuItem()
        MnuSensitivity = New ToolStripMenuItem()
        MnuHistogram = New ToolStripMenuItem()
        MnuTwoDimensions = New ToolStripMenuItem()
        MnuFeigenbaum = New ToolStripMenuItem()
        MnuMechanics = New ToolStripMenuItem()
        MnuBilliard = New ToolStripMenuItem()
        MnuCDiagram = New ToolStripMenuItem()
        MnuNumericMethods = New ToolStripMenuItem()
        MnuPendulum = New ToolStripMenuItem()
        MnuComplexIteration = New ToolStripMenuItem()
        MnuNewton = New ToolStripMenuItem()
        MnuJuliaSet = New ToolStripMenuItem()
        MnuTest = New ToolStripMenuItem()
        MnuDocumentation = New ToolStripMenuItem()
        MnuManual = New ToolStripMenuItem()
        MnuMathematics = New ToolStripMenuItem()
        MnuInfo = New ToolStripMenuItem()
        MnuMain.SuspendLayout()
        SuspendLayout()
        ' 
        ' MnuMain
        ' 
        MnuMain.ImageScalingSize = New Size(24, 24)
        MnuMain.Items.AddRange(New ToolStripItem() {MnuFile, MnuUnimodal, MnuMechanics, MnuComplexIteration, MnuTest, MnuDocumentation})
        MnuMain.Location = New Point(0, 0)
        MnuMain.Name = "MnuMain"
        MnuMain.Padding = New Padding(5, 1, 0, 1)
        MnuMain.Size = New Size(1183, 24)
        MnuMain.TabIndex = 0
        MnuMain.Text = "Main"
        ' 
        ' MnuFile
        ' 
        MnuFile.DropDownItems.AddRange(New ToolStripItem() {MnuLanguage, MnuClose})
        MnuFile.Name = "MnuFile"
        MnuFile.Size = New Size(37, 22)
        MnuFile.Text = "File"
        ' 
        ' MnuLanguage
        ' 
        MnuLanguage.DropDownItems.AddRange(New ToolStripItem() {MnuEnglish, MnuGerman})
        MnuLanguage.Name = "MnuLanguage"
        MnuLanguage.Size = New Size(126, 22)
        MnuLanguage.Text = "Language"
        ' 
        ' MnuEnglish
        ' 
        MnuEnglish.Name = "MnuEnglish"
        MnuEnglish.Size = New Size(116, 22)
        MnuEnglish.Text = "English"
        ' 
        ' MnuGerman
        ' 
        MnuGerman.Name = "MnuGerman"
        MnuGerman.Size = New Size(116, 22)
        MnuGerman.Text = "German"
        ' 
        ' MnuClose
        ' 
        MnuClose.Name = "MnuClose"
        MnuClose.Size = New Size(126, 22)
        MnuClose.Text = "Close"
        ' 
        ' MnuUnimodal
        ' 
        MnuUnimodal.DropDownItems.AddRange(New ToolStripItem() {MnuIteration, MnuSensitivity, MnuHistogram, MnuTwoDimensions, MnuFeigenbaum})
        MnuUnimodal.Name = "MnuUnimodal"
        MnuUnimodal.Size = New Size(71, 22)
        MnuUnimodal.Text = "Unimodal"
        ' 
        ' MnuIteration
        ' 
        MnuIteration.Name = "MnuIteration"
        MnuIteration.Size = New Size(157, 22)
        MnuIteration.Text = "Iteration"
        ' 
        ' MnuSensitivity
        ' 
        MnuSensitivity.Name = "MnuSensitivity"
        MnuSensitivity.Size = New Size(157, 22)
        MnuSensitivity.Text = "Sensitivity"
        ' 
        ' MnuHistogram
        ' 
        MnuHistogram.Name = "MnuHistogram"
        MnuHistogram.Size = New Size(157, 22)
        MnuHistogram.Text = "Histogram"
        ' 
        ' MnuTwoDimensions
        ' 
        MnuTwoDimensions.Name = "MnuTwoDimensions"
        MnuTwoDimensions.Size = New Size(157, 22)
        MnuTwoDimensions.Text = "TwoDimensions"
        ' 
        ' MnuFeigenbaum
        ' 
        MnuFeigenbaum.Name = "MnuFeigenbaum"
        MnuFeigenbaum.Size = New Size(157, 22)
        MnuFeigenbaum.Text = "Feigenbaum"
        ' 
        ' MnuMechanics
        ' 
        MnuMechanics.DropDownItems.AddRange(New ToolStripItem() {MnuBilliard, MnuCDiagram, MnuNumericMethods, MnuPendulum})
        MnuMechanics.Name = "MnuMechanics"
        MnuMechanics.Size = New Size(76, 22)
        MnuMechanics.Text = "Mechanics"
        ' 
        ' MnuBilliard
        ' 
        MnuBilliard.Name = "MnuBilliard"
        MnuBilliard.Size = New Size(167, 22)
        MnuBilliard.Text = "Billiard"
        ' 
        ' MnuCDiagram
        ' 
        MnuCDiagram.Name = "MnuCDiagram"
        MnuCDiagram.Size = New Size(167, 22)
        MnuCDiagram.Text = "CDiagramBilliard"
        ' 
        ' MnuNumericMethods
        ' 
        MnuNumericMethods.Name = "MnuNumericMethods"
        MnuNumericMethods.Size = New Size(167, 22)
        MnuNumericMethods.Text = "NumericMethods"
        ' 
        ' MnuPendulum
        ' 
        MnuPendulum.Name = "MnuPendulum"
        MnuPendulum.Size = New Size(167, 22)
        MnuPendulum.Text = "Pendulum"
        ' 
        ' MnuComplexIteration
        ' 
        MnuComplexIteration.DropDownItems.AddRange(New ToolStripItem() {MnuNewton, MnuJuliaSet})
        MnuComplexIteration.Name = "MnuComplexIteration"
        MnuComplexIteration.Size = New Size(111, 22)
        MnuComplexIteration.Text = "ComplexIteration"
        ' 
        ' MnuNewton
        ' 
        MnuNewton.Name = "MnuNewton"
        MnuNewton.Size = New Size(180, 22)
        MnuNewton.Text = "Newton"
        ' 
        ' MnuJuliaSet
        ' 
        MnuJuliaSet.Name = "MnuJuliaSet"
        MnuJuliaSet.Size = New Size(180, 22)
        MnuJuliaSet.Text = "JuliaSet"
        ' 
        ' MnuTest
        ' 
        MnuTest.Name = "MnuTest"
        MnuTest.Size = New Size(39, 22)
        MnuTest.Text = "Test"
        MnuTest.Visible = False
        ' 
        ' MnuDocumentation
        ' 
        MnuDocumentation.DropDownItems.AddRange(New ToolStripItem() {MnuManual, MnuMathematics, MnuInfo})
        MnuDocumentation.Name = "MnuDocumentation"
        MnuDocumentation.Size = New Size(102, 22)
        MnuDocumentation.Text = "Documentation"
        ' 
        ' MnuManual
        ' 
        MnuManual.Name = "MnuManual"
        MnuManual.Size = New Size(143, 22)
        MnuManual.Text = "Manual"
        ' 
        ' MnuMathematics
        ' 
        MnuMathematics.Name = "MnuMathematics"
        MnuMathematics.Size = New Size(143, 22)
        MnuMathematics.Text = "Mathematics"
        ' 
        ' MnuInfo
        ' 
        MnuInfo.Name = "MnuInfo"
        MnuInfo.Size = New Size(143, 22)
        MnuInfo.Text = "Info"
        ' 
        ' FrmMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1183, 666)
        Controls.Add(MnuMain)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = MnuMain
        Margin = New Padding(2)
        Name = "FrmMain"
        Text = "Simulator"
        WindowState = FormWindowState.Maximized
        MnuMain.ResumeLayout(False)
        MnuMain.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

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
    Friend WithEvents MnuJuliaSet As ToolStripMenuItem
    Friend WithEvents MnuBilliard As ToolStripMenuItem
    Friend WithEvents MnuCDiagram As ToolStripMenuItem
    Friend WithEvents MnuLanguage As ToolStripMenuItem
    Friend WithEvents MnuEnglish As ToolStripMenuItem
    Friend WithEvents MnuGerman As ToolStripMenuItem
    Friend WithEvents MnuNumericMethods As ToolStripMenuItem
End Class