'This is the start window for the program
'Status checked

Imports System.IO

Public Class FrmMain

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
        MnuBilliard.Text = LM.GetString("MnuBilliard")
        MnuPendulum.Text = LM.GetString("MnuPendulum")
        MnuCDiagram.Text = LM.GetString("MnuCDiagramBilliard")
        MnuComplexIteration.Text = LM.GetString("MnuKomplexIteration")
        MnuNewton.Text = LM.GetString("MnuNewton")
        MnuJuliaSet.Text = LM.GetString("MnuJuliaSet")
        MnuBifurcation.Text = FrmMain.LM.GetString("Bifurcation")
        MnuTest.Text = LM.GetString("MnuTest")
        MnuDocumentation.Text = LM.GetString("MnuDocumentation")
        MnuManual.Text = LM.GetString("MnuManual")
        MnuMathematics.Text = LM.GetString("MnuMathematics")
        MnuInfo.Text = LM.GetString("MnuInfo")
        MnuLanguage.Text = LM.GetString("MnuLanguage")
        MnuEnglish.Text = LM.GetString("MnuEnglish")
        MnuGerman.Text = LM.GetString("MnuGerman")
        Text = LM.GetString("Simulator")
        MnuNumericMethods.Text = FrmMain.LM.GetString("NumericMethods")

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
        OpenDocument(LM.GetString("MathDoc"))
    End Sub

    Private Sub MnuManual_Click(sender As Object, e As EventArgs) Handles MnuManual.Click
        OpenDocument(LM.GetString("Manual"))
    End Sub

    Private Sub MnuInfo_Click(sender As Object, e As EventArgs) Handles MnuInfo.Click
        FrmInfo.Show()
    End Sub

    Private Sub MnuBilliard_Click(sender As Object, e As EventArgs) Handles MnuBilliard.Click
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

    Private Sub MnuDeutsch_Click(sender As Object, e As EventArgs) Handles MnuGerman.Click
        LM.Language = ClsLanguageManager.LanguageEnum.Deutsch
        InitializeLanguage()
    End Sub

    Sub OpenDocument(DocumentName As String)

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
        FrmSpringPendulum.Show()
    End Sub

    Private Sub MnuNewton_Click(sender As Object, e As EventArgs) Handles MnuNewton.Click
        FrmNewtonIteration.Show()
    End Sub

    Private Sub MnuJuliaSet_Click(sender As Object, e As EventArgs) Handles MnuJuliaSet.Click
        FrmJulia.Show()
    End Sub

    Private Sub MnuBifurcation_Click(sender As Object, e As EventArgs) Handles MnuBifurcation.Click
        FrmBifurcation.Show()
    End Sub
End Class