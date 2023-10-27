'This is the start window for the program
Imports System.Resources

Public Class Main

    Public Shared LM As ClsLanguageManager

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

        'Initialize Language - Standard Language is English
        LM = New ClsLanguageManager With {
            .Language = ClsLanguageManager.LanguageEnum.English
        }

        InitializeLanguage()

    End Sub

    Private Sub InitializeLanguage()

        MnuMain.Text = LM.GetString("MnuMain")
        MnuFile.Text = LM.GetString("MnuFile")
        MnuClose.Text = LM.GetString("MnuClose")
        MnuUnimodal.Text = LM.GetString("MnuUnimodal")
        MnuIteration.Text = LM.GetString("MnuIteration")
        MnuSensitivity.Text = LM.GetString("MnuSensitivity")
        MnuHistogram.Text = LM.GetString("MnuHistogram")
        MnuTwoDimensions.Text = LM.GetString("MnuTwoDimensions")
        MnuFeigenbaum.Text = LM.GetString("MnuFeigenbaum")
        MnuMechanics.Text = LM.GetString("MnuMechanics")
        MnuBillard.Text = LM.GetString("MnuBillard")
        MnuPendulum.Text = LM.GetString("MnuPendulum")
        MnuCDiagram.Text = LM.GetString("MnuCDiagram")
        MnuKomplexIteration.Text = LM.GetString("MnuKomplexIteration")
        MnuFractals.Text = LM.GetString("MnuFractals")
        MnuJuliaSet.Text = LM.GetString("MnuJuliaSet")
        MnuMandelbrotSet.Text = LM.GetString("MnuMandelbrotSet")
        MnuTest.Text = LM.GetString("MnuTest")
        MnuDocumentation.Text = LM.GetString("MnuDocumentation")
        MnuManual.Text = LM.GetString("MnuManual")
        MnuMathematics.Text = LM.GetString("MnuMathematics")
        MnuInfo.Text = LM.GetString("MnuInfo")
        MnuLanguage.Text = LM.GetString("MnuLanguage")
        MnuEnglish.Text = LM.GetString("MnuEnglish")
        MnuGerman.Text = LM.GetString("MnuGerman")
        Text = LM.GetString("Simulator")

    End Sub

    Private Sub MnuClose_Click(sender As Object, e As EventArgs) Handles MnuClose.Click
        Close()
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

    Private Sub MnuMathematics_Click(sender As Object, e As EventArgs) Handles MnuMathematics.Click
        Try
            Process.Start(LM.GetString("MathDoc"))
        Catch ex As ArgumentException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub MnuManual_Click(sender As Object, e As EventArgs) Handles MnuManual.Click
        Try
            Process.Start(LM.GetString("Manual"))
        Catch ex As ArgumentException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub MnuInfo_Click(sender As Object, e As EventArgs) Handles MnuInfo.Click
        FrmInfo.Show()
    End Sub


    Private Sub MnuBillard_Click(sender As Object, e As EventArgs) Handles MnuBillard.Click
        FrmBillardTable.Show()
    End Sub

    Private Sub MnuPendulum_Click(sender As Object, e As EventArgs) Handles MnuPendulum.Click
        MessageBox.Show(LM.GetString("NotImplemented"))
    End Sub

    Private Sub MnuJuliaSet_Click(sender As Object, e As EventArgs) Handles MnuJuliaSet.Click
        MessageBox.Show(LM.GetString("NotImplemented"))
    End Sub

    Private Sub MnuFractals_Click(sender As Object, e As EventArgs) Handles MnuFractals.Click
        MessageBox.Show(LM.GetString("NotImplemented"))
    End Sub

    Private Sub MnuMandelbrotSet_Click(sender As Object, e As EventArgs) Handles MnuMandelbrotSet.Click
        MessageBox.Show(LM.GetString("NotImplemented"))
    End Sub

    Private Sub MnuCDiagram_Click(sender As Object, e As EventArgs) Handles MnuCDiagram.Click
        FrmCDiagram.Show()
    End Sub

    Private Sub MnuEnglish_Click(sender As Object, e As EventArgs) Handles MnuEnglish.Click
        LM.Language = ClsLanguageManager.LanguageEnum.English
        InitializeLanguage()
    End Sub

    Private Sub MnuDeutsch_Click(sender As Object, e As EventArgs) Handles MnuGerman.Click
        LM.Language = ClsLanguageManager.LanguageEnum.Deutsch
        InitializeLanguage()
    End Sub
End Class