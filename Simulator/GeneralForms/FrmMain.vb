﻿'This is the start window for the program

'Status checked

Imports System.IO

Public Class FrmMain

    Private ReadOnly LM As ClsLanguageManager

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

        'Initialize Language - Standard Language Is English
        LM = ClsLanguageManager.LM

        InitializeLanguage()

    End Sub

    Private Sub InitializeLanguage()

        For Each frm As Form In Application.OpenForms.Cast(Of Form).ToList()
            If Not frm Is Me Then ' FrmMain ist die Hauptform
                frm.Close()
            End If
        Next

        MnuMain.Text = LM.GetString("MnuMain")
        MnuLanguage.Text = LM.GetString("MnuLanguage")
        MnuGrowthModels.Text = LM.GetString("MnuGrowthModels")
        MnuIteration.Text = LM.GetString("MnuIteration")
        MnuSensitivity.Text = LM.GetString("MnuSensitivity")
        MnuHistogram.Text = LM.GetString("MnuHistogram")
        MnuTwoDimensions.Text = LM.GetString("MnuTwoDimensions")
        MnuFeigenbaum.Text = LM.GetString("MnuFeigenbaum")
        MnuMechanics.Text = LM.GetString("MnuMechanics")
        MnuBilliard.Text = LM.GetString("MnuBilliard")
        MnuBilliardTable.Text = LM.GetString("MnuBilliardTable")
        MnuPendulum.Text = LM.GetString("MnuPendulum")
        MnuCDiagram.Text = LM.GetString("MnuCDiagram")
        MnuComplexIteration.Text = LM.GetString("MnuKomplexIteration")
        MnuNewton.Text = LM.GetString("MnuNewton")
        MnuJuliaSet.Text = LM.GetString("MnuJuliaSet")
        MnuTest.Text = LM.GetString("MnuTest")
        MnuDocumentation.Text = LM.GetString("MnuDocumentation")
        MnuManual.Text = LM.GetString("MnuManual")
        MnuMathematics.Text = LM.GetString("MnuMathematics")
        MnuTechnical.Text = LM.GetString("MnuTechnical")
        MnuInfo.Text = LM.GetString("MnuInfo")
        MnuLanguage.Text = LM.GetString("MnuLanguage")
        MnuEnglish.Text = LM.GetString("MnuEnglish")
        MnuGerman.Text = LM.GetString("MnuGerman")
        Text = LM.GetString("Simulator")
        MnuNumericMethods.Text = LM.GetString("MnuNumericMethods")
        MnuPopulationDensity.Text = LM.GetString("MnuPopulationDensity")
        MnuMandelbrotMap.Text = LM.GetString("MnuMandelbrotMap")
        MnuUniverse.Text = LM.GetString("MnuUniverse")
        MnuMathDocPart1.Text = LM.GetString("Part1")
        MnuMathDocPart2.Text = LM.GetString("Part2")
        Mnu3DAttractors.Text = LM.GetString("MnuGeometry")
        MnuStrangeAttractors.Text = LM.GetString("MnuStrangeAttractors")
        MnuFractals.Text = LM.GetString("MnuFractals")
        MnuBifurcation.Text = LM.GetString("MnuBifurcation")
        Mnu3DAttractors.Text = LM.GetString("Mnu3DAttractors")
        MnuLSystems.Text = LM.GetString("MnuLSystems")
        MnuSingleNewton.Text = LM.GetString("MnuSingleNewton")
    End Sub

    Private Sub MnuIteration_Click(sender As Object, e As EventArgs) Handles MnuIteration.Click
        FrmIteration.Show()
    End Sub

    Private Sub MnuSensitivity_Click(sender As Object, e As EventArgs) Handles MnuSensitivity.Click
        FrmSensitivity.Show()
    End Sub

    Private Sub MnuHistogram_Click(sender As Object, e As EventArgs) Handles MnuHistogram.Click
        FrmHistogram.Show()
    End Sub

    Private Sub MnuTwoDimensions_Click(sender As Object, e As EventArgs) Handles MnuTwoDimensions.Click
        FrmTwoDimensions.Show()
    End Sub

    Private Sub MnuFeigenbaum_Click(sender As Object, e As EventArgs) Handles MnuFeigenbaum.Click
        FrmFeigenbaum.Show()
    End Sub

    Private Sub MnuTest_Click(sender As Object, e As EventArgs) Handles MnuTest.Click
        FrmTests.Show()
    End Sub

    Private Sub MnuManual_Click(sender As Object, e As EventArgs) Handles MnuManual.Click
        OpenDocument("Documentation\" & LM.GetString("Manual"))
    End Sub

    Private Sub MnuInfo_Click(sender As Object, e As EventArgs) Handles MnuInfo.Click
        FrmInfo.Show()
    End Sub

    Private Sub MnuBilliardTable_Click(sender As Object, e As EventArgs) Handles MnuBilliardTable.Click
        FrmBilliardtable.Show()
    End Sub

    Private Sub MnuPendulum_Click(sender As Object, e As EventArgs) Handles MnuPendulum.Click
        FrmPendulum.Show()
    End Sub

    Private Sub MnuCDiagram_Click(sender As Object, e As EventArgs) Handles MnuCDiagram.Click
        FrmCDiagramBilliard.Show()
    End Sub

    Private Sub MnuEnglish_Click(sender As Object, e As EventArgs) Handles MnuEnglish.Click
        LM.Language = ClsLanguageManager.LanguageEnum.English
        InitializeLanguage()
    End Sub

    Private Sub MnuGerman_Click(sender As Object, e As EventArgs) Handles MnuGerman.Click
        LM.Language = ClsLanguageManager.LanguageEnum.Deutsch
        InitializeLanguage()
    End Sub

    Public Sub OpenDocument(DocumentName As String)

        'This is the path to the actual exe directory of the Simulator
        Dim currentDirectory As String = Environment.CurrentDirectory

        'This is the path to the document that is in the folder "bin/debug" of the Simulator
        Dim pdfPath As String = Path.Combine(currentDirectory, DocumentName)

        If File.Exists(pdfPath) Then
            Dim p As New ProcessStartInfo With {
                .FileName = pdfPath,
                .UseShellExecute = True
            }
            Try
                'open the document
                System.Diagnostics.Process.Start(p)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            'else error message
            MessageBox.Show(LM.GetString("DocumentNotFound") & DocumentName)
        End If
    End Sub

    Private Sub MnuNumericMethods_Click(sender As Object, e As EventArgs) Handles MnuNumericMethods.Click
        FrmNumericMethod.Show()
    End Sub

    Private Sub MnuNewton_Click(sender As Object, e As EventArgs) Handles MnuNewton.Click
        FrmNewtonIteration.Show()
    End Sub

    Private Sub MnuJuliaSet_Click(sender As Object, e As EventArgs) Handles MnuJuliaSet.Click
        FrmJulia.Show()
    End Sub

    Private Sub MnuTechnical_Click(sender As Object, e As EventArgs) Handles MnuTechnical.Click
        OpenDocument("Documentation\" & LM.GetString("TechDoc"))
    End Sub

    Private Sub MnuPopulationDensity_Click(sender As Object, e As EventArgs) Handles MnuPopulationDensity.Click
        FrmPopulation.Show()
    End Sub

    Private Sub MnuMandelbrotMap_Click(sender As Object, e As EventArgs) Handles MnuMandelbrotMap.Click
        FrmMandelbrotMap.Show()
    End Sub

    Private Sub MnuUniverse_Click(sender As Object, e As EventArgs) Handles MnuUniverse.Click
        FrmUniverse.Show()
    End Sub

    Private Sub MnuMathDocPart1_Click(sender As Object, e As EventArgs) Handles MnuMathDocPart1.Click
        OpenDocument("Documentation\" & LM.GetString("MathDocPart1"))
    End Sub

    Private Sub MnuMathDocPart2_Click(sender As Object, e As EventArgs) Handles MnuMathDocPart2.Click
        OpenDocument("Documentation\" & LM.GetString("MathDocPart2"))
    End Sub

    Private Sub MnuStrangeAttractors_Click(sender As Object, e As EventArgs) Handles MnuStrangeAttractors.Click
        FrmStrangeAttractor.Show()
    End Sub

    Private Sub MnuBifurcation_Click(sender As Object, e As EventArgs) Handles MnuBifurcation.Click
        FrmBifurcation.Show()
    End Sub

    Private Sub MnuLSystems_Click(sender As Object, e As EventArgs) Handles MnuLSystems.Click
        FrmLSystems.Show()
    End Sub

    Private Sub MnuSingleNewton_Click(sender As Object, e As EventArgs) Handles MnuSingleNewton.Click
        FrmSingleNewtonIteration.Show()
    End Sub
End Class