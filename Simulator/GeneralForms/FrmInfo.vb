'This Form shows general information about this program

'Status checked

Public Class FrmInfo

    Private LM As ClsLanguageManager

    Public Sub New()

        LM = ClsLanguageManager.LM

        'This is necessary for the designer
        InitializeComponent()

        'Initialize Language
        InitializeLanguage()

    End Sub

    Private Sub InitializeLanguage()

        LblFeedback.Text = LM.GetString("Feedback")
        LblMail.Text = LM.GetString("MailTo")
        Text = LM.GetString("AboutSimulator")
        LblPersonalData.Text = "Author: " & LM.GetString("DrMathETH")
        BtnReleaseNotes.Text = LM.GetString("ReleaseNotes")

        Dim version As Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version
        LblVersion.Text = "Version " & String.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision)

    End Sub

    Private Sub BtnReleaseNotes_Click(sender As Object, e As EventArgs) Handles BtnReleaseNotes.Click
        FrmMain.OpenDocument("Documentation\" & LM.GetString("ReleaseNotesDoc"))
    End Sub
End Class