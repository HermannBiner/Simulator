'This form allows to iterate a single startpoint
'for the third unit roots
'and the Newton Iteration
'it helps to explain what happens in the iteration
'for non-mathematicians

'Status Checked

Public Class FrmSingleNewtonIteration


    'Private global variables
    Private IsFormLoaded As Boolean
    Private FC As ClsSingleNewtonIterationController

    Private LM As ClsLanguageManager
    Private IsAdjusting As Boolean

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()
        LM = ClsLanguageManager.LM

    End Sub

    Private Sub FrmSingleNewtonIteration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IsFormLoaded = False
        FC = New ClsSingleNewtonIterationController(Me)
        'Initialize Language
        InitializeLanguage()

    End Sub

    Private Sub FrmSingleNewtonIteration_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        AdjustLayout()
    End Sub

    Private Sub AdjustLayout()
        'to avoid a loop
        If IsAdjusting Then
            Exit Sub
        Else
            IsAdjusting = True
            If WindowState <> FormWindowState.Minimized Then
                'we have to make sure that the diagram is square
                Dim DiagramSize As Integer = Math.Max(Math.Min(SplitContainer.Panel1.Width, SplitContainer.Panel1.Height), 10)
                PicDiagram.Width = DiagramSize
                PicDiagram.Height = DiagramSize
                SplitContainer.SplitterDistance = DiagramSize
                PicDiagram.Left = SplitContainer.SplitterDistance - DiagramSize
                PicDiagram.Top = 5
                If IsFormLoaded Then
                    FC.ResetIteration()
                End If
            End If
            IsAdjusting = False
        End If
    End Sub

    Private Sub InitializeLanguage()
        'Initialize Language
        Me.Text = LM.GetString("SingleNewtonIteration")
        LblStartpoint.Text = LM.GetString("StartPoint")
        BtnNextStep.Text = LM.GetString("NextStep")
        BtnReset.Text = LM.GetString("Reset")
    End Sub

    Private Sub FrmSingleNewtonIteration_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FC.ResetIteration()
        IsFormLoaded = True
    End Sub

    'SECTOR ITERATION

    Private Sub BtnNextStep_Click(sender As Object, e As EventArgs) Handles BtnNextStep.Click
        'Call the next step in the iteration
        FC.NextStep()
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        'Reset the iteration
        FC.ResetIteration()
    End Sub

    'SECTOR SET STARTPARAMETER

    Private Sub PicDiagram_MouseDown(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseDown
        If IsFormLoaded Then
            FC.MouseDown(e)
        End If
    End Sub

    Private Sub PicDiagram_MouseMove(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseMove
        If IsFormLoaded Then
            FC.MouseMove(e)
        End If
    End Sub

    Private Sub PicDiagram_MouseUp(sender As Object, e As MouseEventArgs) Handles PicDiagram.MouseUp
        If IsFormLoaded Then
            FC.MouseUp(e)
        End If
    End Sub

    Private Sub CboN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboN.SelectedIndexChanged
        If IsFormLoaded Then
            FC.LoadRoots()
            FC.ResetIteration()
        End If
    End Sub
End Class