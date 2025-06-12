'This class contains the Iteration Controller for FrmLSystems

'Status Checked

Imports System.IO

'JSON = Java Script Object Notation
'This is a lightweight data interchange format
Imports System.Text.Json

Public Class ClsLSystemsController

    Private ReadOnly MyForm As FrmLSystems
    Private ReadOnly LM As ClsLanguageManager

    'JSON L-System File and actual Fractal-File
    Private FileName As String = "LSystemsXX.json"

    'XX stands for EN or DE (the actual language
    Private UserApplicationFilePath As String
    Private UserLSystemFile As String

    'Contains the actual itinerary of the turtle
    Private Itinerary As String
    Private Expander As ClsLsystemExpander
    Private Turtles As List(Of ClsLTurtle)

    'SyntaxChecker and Editor
    Private LSyntaxChecker As ClsLSyntaxChecker

    'EditMode
    Private SystemEditMode As ClsDynamics.EnEditMode
    Private RuleEditMode As ClsDynamics.EnEditMode

    'Iteration status
    Private IterationStatus As ClsDynamics.EnIterationStatus

    'Dictionaries and Lists
    Private LSystemCollection As New List(Of ClsLSystem)
    Private ActualSystem As ClsLSystem

    'Colors
    Private ColorList As ClsColorList
    Private ColorName As String

    'Draws into PicDiagram
    'this is drawing the fractal set
    Private PicGraphics As ClsGraphicTool

    'Status Parameters
    Private n As Integer '#Steps

    'Scaling
    Enum EnScaling
        ByIteration
        ByBranch
    End Enum

    'SECTOR INITIALIZATION

    Public Sub New(Form As FrmLSystems)
        MyForm = Form
        LM = ClsLanguageManager.LM
        LSyntaxChecker = New ClsLSyntaxChecker(MyForm)
        Turtles = New List(Of ClsLTurtle)
        Expander = New ClsLsystemExpander
        IterationStatus = ClsDynamics.EnIterationStatus.Stopped
        ColorList = New ClsColorList
        LoadColors()
        FileName = LM.GetString(FileName)

    End Sub

    Private Sub LoadColors()

        'Fill Colors
        With MyForm.CboColor
            .Items.Clear()
            For Each Pair In ColorList.Colors
                .Items.Add(Pair.Key.ToString & " " & CType(Pair.Value, SolidBrush).Color.Name)
            Next
            .SelectedIndex = 0
            ShowColor(CInt(MyForm.CboColor.SelectedItem.ToString.Split(" "c)(0)))
        End With
    End Sub

    'SECTOR FILE HANDLING

    Public Sub LoadFileToLSystemCollection(LastIndex As Integer)

        'The file "LSystems.json" holds all definitions of fractals
        'The file is loaded form the %App% folder of the user
        'if it doesn't exist, then the file from the Application/Data folder is copied
        'to the user folder
        Dim JSONFile As String = Path.Combine(Application.StartupPath, "Data\" & FileName)
        UserApplicationFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Simulator")
        If Not Directory.Exists(UserApplicationFilePath) Then
            Directory.CreateDirectory(UserApplicationFilePath)
        End If

        UserLSystemFile = Path.Combine(UserApplicationFilePath, FileName)
        If Not File.Exists(UserLSystemFile) Then
            GetDefaultSystems(False)
        End If

        'After that, the content of this file is loaded and copied to the Dictionary
        Dim JSONContent As String = File.ReadAllText(UserLSystemFile)
        LSystemCollection.Clear()
        LSystemCollection = JsonSerializer.Deserialize(Of List(Of ClsLSystem))(JSONContent)

        MyForm.CboSystem.Items.Clear()
        For Each LSystem As ClsLSystem In LSystemCollection
            MyForm.CboSystem.Items.Add(LSystem.Name)
        Next

        If LastIndex <= LSystemCollection.Count - 1 Then
            'The last index is not out of range
            MyForm.CboSystem.SelectedIndex = LastIndex
            ActualSystem = LSystemCollection(LastIndex)
        Else
            'The last index is out of range, select the first one
            MyForm.CboSystem.SelectedIndex = 0
            ActualSystem = LSystemCollection(0)
        End If
    End Sub

    Private Sub WriteLSystemToFile()

        'The LSystemCollection is written into the file LSystems.json
        Dim Options As New JsonSerializerOptions With {
            .WriteIndented = True ' << imporant for a structured LSystem-File
        }

        'Write LSystem into the file LSystems.json
        Dim JSONContent As String = JsonSerializer.Serialize(LSystemCollection, Options)
        File.WriteAllText(UserLSystemFile, JSONContent)

    End Sub

    Public Sub GetDefaultSystems(IsDialog As Boolean)

        'The original L-Systems are loaded from the file "LSystems.json"
        'in the Application/Data folder
        'and copied to the user folder

        Dim Result As DialogResult
        If IsDialog Then
            Result = MessageBox.Show(LM.GetString("GetOriginalSystem"), LM.GetString("Info"),
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        Else
            Result = DialogResult.Yes
        End If

        If Result = DialogResult.Yes Then
            If File.Exists(UserLSystemFile) Then
                File.Copy(UserLSystemFile, UserLSystemFile & ".bak", True)
                File.Delete(UserLSystemFile)
            End If

            Dim SimulatorFile As String = Path.Combine(Application.StartupPath, "Data\" & FileName)
            If File.Exists(SimulatorFile) Then
                File.Copy(SimulatorFile, UserLSystemFile, True)
                LoadFileToLSystemCollection(0)
                SetLSystem()
            Else
                MessageBox.Show(LM.GetString("OriginalFileMissing" & ": " & SimulatorFile), LM.GetString("Error"),
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        If ActualSystem IsNot Nothing Then
            ResetIteration()
        End If
    End Sub

    Public Sub RestoreCopy()
        If File.Exists(UserLSystemFile & ".bak") Then
            File.Copy(UserLSystemFile & ".bak", UserLSystemFile, True)
        Else
            MessageBox.Show(LM.GetString("NoBackupFile"), LM.GetString("Error"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    'SECTOR SHOW LSYSTEMS IN MYFORM

    Public Sub SetLSystem()

        'SetLSystem is called when the user selects an L-System
        'and should be performed only if the EditMode is None
        'because it is called by a Klick-Event on the ComboBox as well
        If SystemEditMode = ClsDynamics.EnEditMode.None Then

            'the actual L-System has changed
            'The content of the chosen fractal system is shown in the form
            For Each LSystem As ClsLSystem In LSystemCollection
                If LSystem.Name = MyForm.CboSystem.Text Then
                    ActualSystem = LSystem
                    If ActualSystem.Type = ClsLSystem.EnLSystemType.Dragon Then
                        MyForm.ChkExtended.Text = LM.GetString("Extended")
                    ElseIf ActualSystem.Type = ClsLSystem.EnLSystemType.Tree Then
                        MyForm.ChkExtended.Text = LM.GetString("Budding")
                    Else
                        MyForm.ChkExtended.Text = ""
                    End If 'Dragon curve
                    ShowActualSystem()
                    Exit For
                End If
            Next

            'Expander
            Expander.Rules = ActualSystem.Rules

            'Sets Rule and SystemEditMode to .None
            ResetIteration()

            'Turtle
            Turtles.Clear()
            Dim Turtle As New ClsLTurtle
            Turtles.Add(Turtle)

            If ActualSystem.Type = ClsLSystem.EnLSystemType.Dragon And ActualSystem.IsExtended Then
                ActualSystem.IsColorFixed = True
                'Dragon curve with four turtles
                Turtle.DefaultColor = ColorList.GetColor(2) 'red
                Dim Turtle2 As New ClsLTurtle
                Turtle2.DefaultColor = ColorList.GetColor(12) 'forestgreen
                Turtles.Add(Turtle2)
                Dim Turtle3 As New ClsLTurtle
                Turtle3.DefaultColor = ColorList.GetColor(23) 'purple
                Turtles.Add(Turtle3)
                Dim Turtle4 As New ClsLTurtle
                Turtle4.DefaultColor = ColorList.GetColor(20) 'blue
                Turtles.Add(Turtle4)
            Else
                ActualSystem.IsColorFixed = False
            End If
            For Each Turtle In Turtles
                With Turtle
                    .PicDiagram = MyForm.PicDiagram
                    .ScaleFactor = ActualSystem.ScaleFactor
                    .AngleLeft = ActualSystem.AngleLeft
                    .AngleRight = ActualSystem.AngleRight
                    .IsBudding = ActualSystem.IsBudding
                    .IsColorFixed = ActualSystem.IsColorFixed
                    If Not .IsColorFixed Then
                        .DefaultColor = ColorList.GetColor(ActualSystem.Color)
                    End If
                    .Scaling = ActualSystem.Scaling
                    .StartLength = ActualSystem.StartLength
                    .LstDebug = MyForm.LstDebug
                End With
            Next
        End If

    End Sub

    Private Sub ShowActualSystem()
        With MyForm
            'The content of the selected system is shown in the form
            .TxtName.Text = ActualSystem.Name
            .TxtAxiom.Text = ActualSystem.Axiom
            .ChkExtended.Visible = (ActualSystem.Type <> ClsLSystem.EnLSystemType.Standard)
            .TxtScaleFactor.Text = ActualSystem.ScaleFactor.ToString()
            .TxtAngleLeft.Text = ActualSystem.AngleLeft.ToString()
            .TxtAngleRight.Text = ActualSystem.AngleRight.ToString()
            .CboColor.SelectedIndex = ActualSystem.Color
            .TxtStartLength.Text = ActualSystem.StartLength.ToString()
            Select Case ActualSystem.Scaling
                Case ClsLSystemsController.EnScaling.ByIteration
                    .CboScaling.SelectedIndex = 0
                Case ClsLSystemsController.EnScaling.ByBranch
                    .CboScaling.SelectedIndex = 1
            End Select
            Select Case ActualSystem.Type
                Case ClsLSystem.EnLSystemType.Standard
                    .ChkExtended.Checked = False
                    .ChkExtended.Visible = False
                    .CboType.SelectedIndex = 0
                    .ChkExtended.Checked = False
                Case ClsLSystem.EnLSystemType.Tree
                    .ChkExtended.Checked = ActualSystem.IsBudding
                    .ChkExtended.Visible = True
                    .CboType.SelectedIndex = 1
                    .ChkExtended.Text = LM.GetString("Budding") 'Budding
                    .ChkExtended.Checked = ActualSystem.IsBudding
                Case ClsLSystem.EnLSystemType.Dragon
                    .ChkExtended.Checked = ActualSystem.IsExtended
                    .ChkExtended.Visible = True
                    .CboType.SelectedIndex = 2
                    .ChkExtended.Text = LM.GetString("Extended") 'Extended
                    .ChkExtended.Checked = ActualSystem.IsExtended
            End Select
            .TxtX.Text = ActualSystem.StartPositionX.ToString()
            .TxtY.Text = ActualSystem.StartPositionY.ToString()
            ShowColor(ActualSystem.Color)
            ShowActualRules()
        End With
    End Sub

    Public Sub ShowOptions()
        With MyForm
            .ChkExtended.Checked = False 'Standard
            Select Case .CboType.SelectedIndex
                Case 0
                    ActualSystem.Type = ClsLSystem.EnLSystemType.Standard
                    .ChkExtended.Visible = False
                Case 1
                    ActualSystem.Type = ClsLSystem.EnLSystemType.Tree
                    .ChkExtended.Visible = True
                    .ChkExtended.Text = LM.GetString("Budding") 'Budding
                Case Else
                    ActualSystem.Type = ClsLSystem.EnLSystemType.Dragon
                    .ChkExtended.Visible = True
                    .ChkExtended.Text = LM.GetString("Extended") 'Extended
            End Select
        End With
    End Sub

    Private Sub ShowActualRules()
        With MyForm
            .CboRules.Items.Clear()
            For Each Rule In ActualSystem.Rules
                .CboRules.Items.Add(Rule.Key & "->" & Rule.Value)
            Next
            .CboRules.SelectedIndex = 0
        End With
        ShowRuleDetails()
    End Sub

    Public Sub ShowRuleDetails()
        If MyForm.CboRules.SelectedItem IsNot Nothing Then
            'Show the selected rule in the textboxes
            Dim Rule As String = MyForm.CboRules.SelectedItem.ToString()
            Dim Source As String = Rule.Split("->")(0)
            Dim Target As String = Rule.Split("->")(1)
            MyForm.TxtSource.Text = Source
            MyForm.TxtTarget.Text = Target
        End If
    End Sub

    Public Sub ShowColor(Color As Integer)
        'Set the color in LblColor
        MyForm.LblShowColor.BackColor = CType(ColorList.Colors(Color), SolidBrush).Color
    End Sub

    'SECTOR EDIT SYSTEMS

    Private Sub SetButtonsToEditMode()
        With MyForm
            Select Case SystemEditMode
                Case ClsDynamics.EnEditMode.None
                    .BtnAddSystem.Enabled = True
                    .BtnEditSystem.Enabled = True
                    .BtnDeleteSystem.Enabled = True
                    .BtnSaveSystem.Enabled = False
                    .BtnCancel.Enabled = False
                    .BtnAddRule.Enabled = False
                    .BtnDeleteRule.Enabled = False
                    .BtnSaveRule.Enabled = False
                    .BtnStart.Enabled = True
                    .BtnStop.Enabled = False
                    .BtnGetDefaultSystems.Enabled = True
                    .BtnReset.Enabled = True
                Case ClsDynamics.EnEditMode.Add
                    .BtnAddSystem.Enabled = False
                    .BtnEditSystem.Enabled = False
                    .BtnDeleteSystem.Enabled = False
                    .BtnSaveSystem.Enabled = True
                    .BtnCancel.Enabled = True
                    .BtnAddRule.Enabled = True
                    .BtnSaveRule.Enabled = True
                    .BtnDeleteRule.Enabled = True
                    .BtnStart.Enabled = False
                    .BtnStop.Enabled = False
                    .BtnGetDefaultSystems.Enabled = False
                    .BtnReset.Enabled = False
                Case ClsDynamics.EnEditMode.Edit
                    .BtnAddSystem.Enabled = False
                    .BtnEditSystem.Enabled = False
                    .BtnDeleteSystem.Enabled = False
                    .BtnSaveSystem.Enabled = True
                    .BtnCancel.Enabled = True
                    .BtnAddRule.Enabled = True
                    .BtnSaveRule.Enabled = True
                    .BtnDeleteRule.Enabled = True
                    .BtnStart.Enabled = False
                    .BtnStop.Enabled = False
                    .BtnGetDefaultSystems.Enabled = False
                    .BtnReset.Enabled = False
            End Select

        End With
    End Sub

    Private Sub SetButtonsEnabled(IsEnabled As Boolean)
        With MyForm
            .BtnAddSystem.Enabled = IsEnabled
            .BtnEditSystem.Enabled = IsEnabled
            .BtnDeleteSystem.Enabled = IsEnabled
            .BtnSaveSystem.Enabled = IsEnabled
            .BtnCancel.Enabled = IsEnabled
            .BtnAddRule.Enabled = IsEnabled
            .BtnDeleteRule.Enabled = IsEnabled
            .BtnSaveRule.Enabled = IsEnabled
            .CboSystem.Enabled = IsEnabled
            .BtnGetDefaultSystems.Enabled = IsEnabled
            .BtnReset.Enabled = IsEnabled
            .BtnStart.Enabled = IsEnabled
            .BtnStop.Enabled = Not IsEnabled
        End With
    End Sub

    Public Sub AddSystem()

        ResetIteration()

        SystemEditMode = ClsDynamics.EnEditMode.Add
        'a Rule must be added
        'if the user Klicks in addition "AddRule" nothing happens
        AddRule()

        SetButtonsToEditMode()

        EnableSystemParameters(True)
        EnableRuleParameters(True)
        MyForm.CboSystem.Enabled = False

        ActualSystem = New ClsLSystem
        ActualSystem.ID = 0
        ActualSystem.Rules = New Dictionary(Of String, String)

        With MyForm
            .TxtName.Text = ""
            .CboSystem.Enabled = False
            .TxtAxiom.Text = ""
            .TxtScaleFactor.Text = "1"
            .TxtAngleLeft.Text = "0"
            .TxtAngleRight.Text = "0"
            .CboColor.SelectedIndex = 0
            .CboType.SelectedIndex = 0 'Standard
            .ChkExtended.Checked = False
            .TxtSource.Text = ""
            .TxtTarget.Text = ""
            .CboRules.Items.Clear()
            .CboRules.SelectedIndex = -1
            .TxtStartLength.Text = "1"
            .TxtX.Text = "1"
            .TxtY.Text = "1"
        End With

    End Sub

    Public Sub EditSystem()

        ResetIteration()

        SystemEditMode = ClsDynamics.EnEditMode.Edit
        RuleEditMode = ClsDynamics.EnEditMode.Edit
        SetButtonsToEditMode()

        EnableSystemParameters(True)
        EnableRuleParameters(True)
        MyForm.CboSystem.Enabled = False

    End Sub

    Public Sub DeleteSystem()

        ResetIteration()

        Dim Result As DialogResult
        Result = MessageBox.Show(LM.GetString("DeleteLSystem"), LM.GetString("Delete"),
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If Result = DialogResult.Yes Then
            'The user has confirmed the deletion of the system

            'The selected system is deleted from the list
            Dim LSystem As ClsLSystem = LSystemCollection.Find(Function(x) x.Name = MyForm.CboSystem.Text)
            If LSystem IsNot Nothing And LSystemCollection.Count > 1 Then
                LSystemCollection.Remove(LSystem)

                'MyForm.CboSystem.Items.Remove(MyForm.CboSystem.Text)
                'MyForm.CboSystem.SelectedIndex = 0
                WriteLSystemToFile()
                LoadFileToLSystemCollection(0)
                SetLSystem()

            Else
                'If there is only one system left, we can't delete it
                MessageBox.Show(LM.GetString("LastSystemNotDeleted"))
            End If
        End If
    End Sub

    Public Sub SaveSystem()

        If SystemEditMode = ClsDynamics.EnEditMode.Add Or SystemEditMode = ClsDynamics.EnEditMode.Edit Then
            'Check the Syntax

            With ActualSystem
                .Name = MyForm.TxtName.Text
                .Axiom = MyForm.TxtAxiom.Text
                .ScaleFactor = CDec(MyForm.TxtScaleFactor.Text)
                .AngleLeft = CInt(MyForm.TxtAngleLeft.Text)
                .AngleRight = CInt(MyForm.TxtAngleRight.Text)
                .Color = CInt(MyForm.CboColor.SelectedItem.ToString.Split(" ")(0))
                .StartLength = CDec(MyForm.TxtStartLength.Text)
                Select Case MyForm.CboScaling.SelectedIndex
                    Case 0
                        .Scaling = ClsLSystemsController.EnScaling.ByIteration
                    Case 1
                        .Scaling = ClsLSystemsController.EnScaling.ByBranch
                End Select
                Select Case MyForm.CboType.SelectedIndex
                    Case 0
                        .IsExtended = False
                        .Type = ClsLSystem.EnLSystemType.Standard
                    Case 1
                        .IsExtended = False
                        .IsBudding = MyForm.ChkExtended.Checked
                        .Type = ClsLSystem.EnLSystemType.Tree
                    Case 2
                        .IsExtended = MyForm.ChkExtended.Checked
                        .IsBudding = False
                        .Type = ClsLSystem.EnLSystemType.Dragon
                End Select
                .StartPositionX = CDec(MyForm.TxtX.Text)
                .StartPositionY = CDec(MyForm.TxtY.Text)

            End With

            If SyntaxIsOK() Then

                'Rules are already added

                If ActualSystem.ID = 0 Then
                    'the system is new generated and not part of LSystemCollection
                    ActualSystem.ID = GetLSystemID()
                    LSystemCollection.Add(ActualSystem)
                End If

                EnableSystemParameters(False)
                EnableRuleParameters(False)
                WriteLSystemToFile()

                MyForm.CboSystem.Enabled = True

                Dim SystemIndex As Integer

                If SystemEditMode = ClsDynamics.EnEditMode.Add Then
                    SystemIndex = LSystemCollection.Count - 1
                Else
                    SystemIndex = LSystemCollection.FindIndex(Function(x) x.Name = ActualSystem.Name)
                End If

                If SystemIndex > LSystemCollection.Count - 1 Then
                    SystemIndex = 0
                End If

                LoadFileToLSystemCollection(SystemIndex)

                SystemEditMode = ClsDynamics.EnEditMode.None
                RuleEditMode = ClsDynamics.EnEditMode.None
                SetButtonsToEditMode()
            Else
                'Syntax Error Messages are allready generated
            End If
            SetLSystem()
        End If

    End Sub

    'SECTOR EDIT RULES

    Public Sub AddRule()
        RuleEditMode = ClsDynamics.EnEditMode.Add
        MyForm.TxtSource.Text = ""
        MyForm.TxtTarget.Text = ""
        MyForm.CboRules.SelectedIndex = -1
    End Sub

    Public Sub SaveRule()
        If RuleEditMode = ClsDynamics.EnEditMode.Add Then
            'The Key must be unique
            If ActualSystem.Rules.ContainsKey(MyForm.TxtSource.Text) Then
                MessageBox.Show(LM.GetString("RuleAlreadyExists"), LM.GetString("Error"),
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            ActualSystem.Rules.Add(MyForm.TxtSource.Text, MyForm.TxtTarget.Text)
            ShowActualRules()
        Else
            If RuleEditMode = ClsDynamics.EnEditMode.Edit And MyForm.CboRules.Items.Count > 0 Then
                ActualSystem.Rules.Remove(MyForm.CboRules.Text.Split("->")(0))
                'The Key must be unique
                If ActualSystem.Rules.ContainsKey(MyForm.TxtSource.Text) Then
                    MessageBox.Show(LM.GetString("RuleAlreadyExists"), LM.GetString("Error"),
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                ActualSystem.Rules.Add(MyForm.TxtSource.Text, MyForm.TxtTarget.Text)
                ShowActualRules()
            End If
        End If
    End Sub

    Public Sub DeleteRule()
        'The selected rule is deleted from the list
        Dim Rule As String = MyForm.CboRules.SelectedItem.ToString()
        Dim Source As String = Rule.Split("->")(0)
        Dim Target As String = Rule.Split("->")(1)
        Dim LSystem As ClsLSystem = LSystemCollection.Find(Function(x) x.Name = MyForm.CboSystem.Text)
        If LSystem IsNot Nothing Then
            LSystem.Rules.Remove(Source)
            ShowActualSystem()
        End If
    End Sub

    Public Sub Cancel()

        SystemEditMode = ClsDynamics.EnEditMode.None
        RuleEditMode = ClsDynamics.EnEditMode.None
        SetButtonsToEditMode()
        EnableSystemParameters(False)
        MyForm.CboSystem.Enabled = True

    End Sub

    Private Sub EnableSystemParameters(IsEnabled As Boolean)
        With MyForm
            .TxtName.Enabled = IsEnabled
            .TxtAxiom.Enabled = IsEnabled
            .TxtScaleFactor.Enabled = IsEnabled
            .TxtAngleLeft.Enabled = IsEnabled
            .TxtAngleRight.Enabled = IsEnabled
            .CboColor.Enabled = IsEnabled
            .ChkExtended.Enabled = IsEnabled
            .TxtStartLength.Enabled = IsEnabled
            .CboScaling.Enabled = IsEnabled
            .CboType.Enabled = IsEnabled
            .TxtX.Enabled = IsEnabled
            .TxtY.Enabled = IsEnabled
        End With
    End Sub

    Private Sub EnableRuleParameters(IsEnabled As Boolean)
        With MyForm
            .TxtSource.Enabled = IsEnabled
            .TxtTarget.Enabled = IsEnabled
        End With
    End Sub

    Function GetLSystemID() As Integer
        'this generates an ID for a new L-System
        'We don't expect tousands of L-Systems, therefore:
        Dim MaxID As Integer = 0
        For Each LSystem As ClsLSystem In LSystemCollection
            If LSystem.ID > MaxID Then
                MaxID = LSystem.ID
            End If
        Next
        Return MaxID + 1
    End Function


    'SECTOR CHECKSYNTAX

    Private Function SyntaxIsOK() As Boolean

        Dim OK As Boolean

        LSyntaxChecker.ActualSystem = ActualSystem
        LSyntaxChecker.LSystemCollection = LSystemCollection
        LSyntaxChecker.SystemEditMode = SystemEditMode

        OK = LSyntaxChecker.ParameterValuesAreAllowed()

        If OK Then
            OK = LSyntaxChecker.RulesAreConsistent()
        End If

        Return OK

    End Function

    'SECTOR ITERATION

    Public Async Sub StartIteration()

        'the Iteration is not running and is actually stopped
        'we prepare the iteration with the axiom as start
        'and set the Iterationstatus to ready
        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then

            SetButtonsEnabled(False)

            'Turtle
            For Each Turtle As ClsLTurtle In Turtles
                Turtle.WorkingStatus = ClsLTurtle.EnWorkingStatus.Ready
            Next

            'Turtle
            For Each Turtle As ClsLTurtle In Turtles
                Turtle.WorkingStatus = ClsLTurtle.EnWorkingStatus.Ready
                Turtle.StartPosition = New ClsMathpoint(ActualSystem.StartPositionX, ActualSystem.StartPositionY)
                'this sets the angle of the turtle
                'if there are more than one turtle, they are distributed around the start position
                Turtle.CurrentAngle = Turtles.IndexOf(Turtle) * 90
                Turtle.Generation += 1
            Next

            If Not (Itinerary.Contains("F"c) OrElse Itinerary.Contains("G"c)) Then
                'the Axiom does not contain a "F" or "G"
                'we have first to expand so that anything is drawn
                Itinerary = Expander.ExpandItinerary(Itinerary)
                For Each Turtle As ClsLTurtle In Turtles
                    Turtle.Scale()
                Next
            End If

            'Prepare Diagram
            MyForm.PicDiagram.Refresh()
            MyForm.LstDebug.Items.Clear()

            IterationStatus = ClsDynamics.EnIterationStatus.Ready

        End If

        'the Iteration was prepared and is ready
        'we start the iteration an set the iteration status to running
        'running means also that the number of the generation is >= 1
        If IterationStatus = ClsDynamics.EnIterationStatus.Ready _
            Or IterationStatus = ClsDynamics.EnIterationStatus.Interrupted Then

            IterationStatus = ClsDynamics.EnIterationStatus.Running
            SetButtonsEnabled(False)

            'Turtle
            For Each Turtle As ClsLTurtle In Turtles
                Await Turtle.DrawNextGeneration(Itinerary)
                'maybe the iteration was interrupted
                If IterationStatus = ClsDynamics.EnIterationStatus.Interrupted Then
                    Exit For
                End If
            Next
        End If


        If IterationStatus <> ClsDynamics.EnIterationStatus.Interrupted Then
            'Generation is finished
            Itinerary = Expander.ExpandItinerary(Itinerary)
            For Each Turtle In Turtles
                Turtle.Scale()
            Next
            MyForm.BtnStart.Text = LM.GetString("Start")
            SetButtonsEnabled(True)
            MyForm.BtnStart.Enabled = True
            IterationStatus = ClsDynamics.EnIterationStatus.Stopped
        End If

    End Sub

    Public Sub StopIteration()
        'the Stop-Button was pressed
        'Stop the iteration
        IterationStatus = ClsDynamics.EnIterationStatus.Interrupted
        For Each Turtle As ClsLTurtle In Turtles
            If Turtle.WorkingStatus = ClsLTurtle.EnWorkingStatus.Running Then
                Turtle.WorkingStatus = ClsLTurtle.EnWorkingStatus.Interrupted
            End If
        Next
        MyForm.BtnStart.Text = LM.GetString("Continue")
        SetButtonsEnabled(True)
    End Sub

    Public Sub ResetIteration()

        'PicDiagram is cleared
        MyForm.PicDiagram.Refresh()
        EnableSystemParameters(False)
        SystemEditMode = ClsDynamics.EnEditMode.None
        RuleEditMode = ClsDynamics.EnEditMode.None
        SetButtonsToEditMode()

        Itinerary = ActualSystem.Axiom
        IterationStatus = ClsDynamics.EnIterationStatus.Stopped
        MyForm.BtnStart.Text = LM.GetString("Start")

        MyForm.LstDebug.Items.Clear()

        For Each Turtle As ClsLTurtle In Turtles
            Turtle.Reset()
            Turtle.StartLength = ActualSystem.StartLength
        Next

        'Itinerary
        Itinerary = ActualSystem.Axiom

    End Sub

End Class
