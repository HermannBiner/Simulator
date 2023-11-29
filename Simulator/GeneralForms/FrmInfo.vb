'This Form shows general information about this program
'Status checked

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
        Text = Main.LM.GetString("AboutSimulator")
        LblPersonalData.Text = "Author: " & Main.LM.GetString("DrMathETH")

        Dim version As Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version
        LblVersion.Text = "Version " & String.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision)

    End Sub

End Class