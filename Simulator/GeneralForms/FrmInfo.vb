'This Form shows general information about this program
Public Class FrmInfo

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

        'Initialize Language
        InitializeLanguage()

    End Sub

    Private Sub InitializeLanguage()

        LblFeedback.Text = Main.LM.GetString("Feedback")
        LblMail.Text = Main.LM.GetString("MailTo")
        LblVersion.Text = Main.LM.GetString("ProgramVersion")
        Text = Main.LM.GetString("AboutSimulator")

    End Sub

End Class