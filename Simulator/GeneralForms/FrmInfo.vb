'This Form shows general information about this program

'Status checked

Public Class FrmInfo

    Private ReadOnly LM As ClsLanguageManager
    Private IsFormLoaded As Boolean
    Private IsAdjusting As Boolean

    Public Sub New()

        LM = ClsLanguageManager.LM

        'This is necessary for the designer
        InitializeComponent()

        'Initialize Language
        InitializeLanguage()

    End Sub

    Private Sub FrmInfo_Load(sender As Object, e As EventArgs) Handles Me.Load
        IsFormLoaded = False
    End Sub

    Private Sub FrmStrangeAttractor_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        AdjustLayout()
    End Sub

    Private Sub AdjustLayout()
        'to avoid a loop
        If IsAdjusting Then
            Exit Sub
        Else
            IsAdjusting = True
            If WindowState <> FormWindowState.Minimized Then
                'we have to make sure that the diagram is a square
                PicZermatt.Width = Math.Min(SplitContainer.Panel2.Width, SplitContainer.Panel2.Height)
                PicZermatt.Height = CInt(PicZermatt.Width * 0.75)
                PicZermatt.Left = (SplitContainer.Panel2.Width - PicZermatt.Width) \ 2
                PicZermatt.Top = (SplitContainer.Panel2.Height - PicZermatt.Height) \ 2
                SplitContainer.SplitterDistance = BtnReleaseNotes.Width + 10
            End If
            IsAdjusting = False
        End If
    End Sub

    Private Sub FrmInfo_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        IsFormLoaded = True
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

    'LAYOUT

    Private Sub SplitContainer_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer.SplitterMoved

        If IsFormLoaded Then
            AdjustLayout()
        End If
    End Sub

    Private Sub FrmInfo_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If IsFormLoaded Then
            AdjustLayout()
        End If
    End Sub

End Class