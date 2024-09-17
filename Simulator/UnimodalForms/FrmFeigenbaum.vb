'This form is the user interface for the so called Feigenbaum Diagram
'It shows the dependence of the behaviour of the iteration
'from the parameter a
'for certain parameter values, the behaviour is chaotic
'see as well the mathematical documentation

'The form is based on the Interface IIteration 
'that is implemented by ClsTentmap, ClsLogisticGrowth, ClsParabola
'Therefore, more cases of unimodal functions could be easely programmed
'by implementing this interface

'Status Redesign Tested

Imports System.Globalization
Imports System.Reflection

Public Class FrmFeigenbaum

    Private IsFormLoaded As Boolean
    Private FeigenbaumController As ClsFeigenbaumController
    Private DiagramAreaSelector As ClsDiagramAreaSelector

    'MyBitmapGraphics draws into the Feigenbaum Diagram
    Private FeigenbaumDiagram As Bitmap
    Private MyBitMapGraphics As ClsGraphicTool

    Private DS As IIteration

    'SECTOR INITIALIZATION

    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub FrmFeigenbaum_Load(sender As Object, e As EventArgs) Handles Me.Load

        IsFormLoaded = False
        FeigenbaumController = New ClsFeigenbaumController

        DiagramAreaSelector = New ClsDiagramAreaSelector

        'Initialize Language
        InitializeLanguage()

        FillDynamicSystem()

    End Sub

    Private Sub FrmFeigenbaum_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        CboFunction.SelectedIndex = 0
        LblPrecision.Text = FrmMain.LM.GetString("Precision") & ": " & (1000 * TrbPrecision.Value).ToString(CultureInfo.CurrentCulture)

        SetDS()
        IsFormLoaded = True

    End Sub

    Private Sub InitializeLanguage()

        Text = FrmMain.LM.GetString("FeigenbaumDiagram")
        ChkColored.Text = FrmMain.LM.GetString("ColoredDiagram")
        ChkSplitPoints.Text = FrmMain.LM.GetString("ShowSplitPoints")
        LblDeltaX.Text = FrmMain.LM.GetString("Delta") & " = "
        LblDeltaA.Text = FrmMain.LM.GetString("Delta") & " = "
        LblValueRange.Text = FrmMain.LM.GetString("ExaminatedValueRange")
        LblPrecision.Text = FrmMain.LM.GetString("Precision") & "; " & (TrbPrecision.Value * 100).ToString(CultureInfo.CurrentCulture)
        LblParameterRange.Text = FrmMain.LM.GetString("ExaminatedParameterRange")
        BtnStartIteration.Text = FrmMain.LM.GetString("StartIteration")
        BtnReset.Text = FrmMain.LM.GetString("ResetIteration")

    End Sub

    Private Sub FillDynamicSystem()

        CboFunction.Items.Clear()

        'Add the classes implementing IIteration
        'to the Combobox CboPendulum by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IIteration)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If types.Count > 0 Then
            Dim DSName As String
            For Each type In types

                'GetString is calle dwith the option IsClass = true
                'That effects that - if there is no Entry in the Resource files LabelsEN, LabelsDE -
                'the name of the Class implementing an Interface is used as default
                'suppressing the extension "Cls"
                DSName = FrmMain.LM.GetString(type.Name, True)
                CboFunction.Items.Add(DSName)
            Next
        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If
    End Sub

    Private Sub SetDS()

        'This sets the type of Iterator by Reflection

        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IIteration)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If CboFunction.SelectedIndex >= 0 Then

            Dim SelectedName As String = CboFunction.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If FrmMain.LM.GetString(type.Name, True) = SelectedName Then
                        DS = CType(Activator.CreateInstance(type), IIteration)
                    End If
                Next
            End If

        End If


        InitializeDS()

        'The parameter and startvalue are depending on the type of iteration
        SetDefaultUserData()

        'If the type of iteration changes, everything has to be reset
        ResetIteration()

    End Sub

    Private Sub InitializeDS()

        DS.Power = 1

        With FeigenbaumController
            .DS = DS
            .PicDiagram = PicDiagram
            .IsColored = ChkColored.Checked
            .Precision = TrbPrecision.Value
        End With

        With DiagramAreaSelector
            .XRange = DS.ParameterInterval
            .YRange = DS.IterationInterval
            .PicDiagram = PicDiagram
            .TxtXMin = TxtAMin
            .TxtXMax = TxtAMax
            .TxtYMin = TxtXMin
            .TxtYMax = TxtXMax
        End With

    End Sub

    Private Sub SetDefaultUserData()

        'if there where User-defined ranges,
        'or the iterator has changed
        'the ranges are reset to the standard
        FeigenbaumController.ParameterRange = DS.ParameterInterval
        FeigenbaumController.IterationRange = DS.IterationInterval

        TxtAMin.Text = DS.ParameterInterval.A.ToString(CultureInfo.CurrentCulture)
        TxtAMax.Text = DS.ParameterInterval.B.ToString(CultureInfo.CurrentCulture)

        TxtXMin.Text = DS.IterationInterval.A.ToString(CultureInfo.CurrentCulture)
        TxtXMax.Text = DS.IterationInterval.B.ToString(CultureInfo.CurrentCulture)

        SetDelta()

    End Sub

    Sub ResetIteration()

        FeigenbaumController.ResetIteration()
        SetDefaultUserData()

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        If IsFormLoaded Then
            ResetIteration()
        End If
    End Sub

    Private Sub CboFunction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboFunction.SelectedIndexChanged
        If IsFormLoaded Then
            SetDS()
        End If
    End Sub

    Private Sub TrbPrecision_ValueChanged(sender As Object, e As EventArgs) Handles TrbPrecision.ValueChanged
        If IsFormLoaded Then
            'The precision defines how precise the diagram is generated
            LblPrecision.Text = FrmMain.LM.GetString("Precision") & ": " & (1000 * TrbPrecision.Value).ToString(CultureInfo.CurrentCulture)
            FeigenbaumController.Precision = TrbPrecision.Value
        End If
    End Sub

    Private Sub SetDelta()
        If IsNumeric(TxtAMax.Text) And IsNumeric(TxtAMin.Text) Then
            LblDeltaA.Text = "Delta = " & (CDec(TxtAMax.Text) - CDec(TxtAMin.Text)).ToString(CultureInfo.CurrentCulture)
        End If
        If IsNumeric(TxtXMax.Text) And IsNumeric(TxtXMin.Text) Then
            LblDeltaX.Text = "Delta = " & (CDec(TxtXMax.Text) - CDec(TxtXMin.Text)).ToString(CultureInfo.CurrentCulture)
        End If
    End Sub

    Private Sub ChkColored_CheckedChanged(sender As Object, e As EventArgs) Handles ChkColored.CheckedChanged
        If IsFormLoaded Then
            FeigenbaumController.IsColored = ChkColored.Checked
        End If
    End Sub

    Private Sub TxtAMax_LostFocus(sender As Object, e As EventArgs) Handles TxtAMax.LostFocus
        If IsFormLoaded Then
            SetDelta()
        End If
    End Sub

    Private Sub TxtAMin_LostFocus(sender As Object, e As EventArgs) Handles TxtAMin.LostFocus
        If IsFormLoaded Then
            SetDelta()
        End If
    End Sub

    Private Sub TxtXMax_LostFocus(sender As Object, e As EventArgs) Handles TxtXMax.LostFocus
        If IsFormLoaded Then
            SetDelta()
        End If
    End Sub

    Private Sub TxtXMin_LostFocus(sender As Object, e As EventArgs) Handles TxtXMin.LostFocus
        If IsFormLoaded Then
            SetDelta()
        End If
    End Sub

    'SECTOR ITERATION

    Private Sub BtnStartIteration_Click(sender As Object, e As EventArgs) Handles BtnStartIteration.Click

        If IsFormLoaded Then
            With FeigenbaumController
                .ResetIteration()
                If .IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
                    If IsUserDataOK() Then
                        DiagramAreaSelector.IsActivated = False
                        .IterationStatus = ClsDynamics.EnIterationStatus.Ready
                        .ParameterRange = New ClsInterval(CDec(TxtAMin.Text), CDec(TxtAMax.Text))
                        .IterationRange = New ClsInterval(CDec(TxtXMin.Text), CDec(TxtXMax.Text))
                        DiagramAreaSelector.UserXRange = .ParameterRange
                        DiagramAreaSelector.UserYRange = .IterationRange
                        BtnStartIteration.Enabled = False
                        BtnReset.Enabled = False
                        BtnStartIteration.Enabled = True
                        BtnReset.Enabled = True
                    Else
                        SetDefaultUserData()
                    End If
                End If

                If .IterationStatus = ClsDynamics.EnIterationStatus.Ready Then
                    DoIteration()
                End If

                DiagramAreaSelector.IsActivated = True
                .IterationStatus = ClsDynamics.EnIterationStatus.Stopped

            End With
        End If

    End Sub

    Private Sub DoIteration()

        'In the direction of the x-axis, we work with pixel coordinates
        Dim p As Integer

        For p = 1 To PicDiagram.Width

            'for each p, the according parametervalue a is calculated
            'and then, the iteration runs until RuntimeUntilCycle
            'finally, the iteration cycle is drawn
            FeigenbaumController.IterationLoop(p)

        Next

        'Draw Splitpoints
        If ChkSplitPoints.Checked Then
            FeigenbaumController.DrawSplitPoints()
        End If

    End Sub

    Private Function IsUserDataOK() As Boolean

        Dim CheckParameterRange As New ClsCheckUserData(TxtAMin, TxtAMax, DS.ParameterInterval)
        Dim CheckValueRange As New ClsCheckUserData(TxtXMin, TxtXMax, DS.IterationInterval)

        Return CheckParameterRange.IsIntervalAllowed And CheckValueRange.IsIntervalAllowed

    End Function

End Class