'This form is the user interface for the investigation
'of the relation of the parameters of Billiard, Pendulum or similar systems
'and the parmeter C (see math. doc.) that defines its profile
'the implementation follows the concept of the Feigenbaum Diagram

'The form is based on an Interface ICDiagram 
'that is implemented by the Billiard-Classes, Pendulum-Classes and other

Imports System.Globalization
Imports System.Reflection

Public Class FrmCDiagramBilliard


    Private IsFormLoaded As Boolean
    Private CDiagramController As ClsCDiagramController
    Private DiagramAreaSelector As ClsDiagramAreaSelector

    'Prepare basic objects
    Private DS As IBilliardTable
    Private ActiveBilliardBall As IBilliardball
    Private SelectedValueParameter As ClsValueParameter

    'SECTOR INITIALIZATION
    Public Sub New()

        'This is necessary for the designer
        InitializeComponent()

    End Sub

    Private Sub FrmCDiagram_Load(sender As Object, e As EventArgs) Handles Me.Load

        IsFormLoaded = False

        CDiagramController = New ClsCDiagramController

        DiagramAreaSelector = New ClsDiagramAreaSelector

        'Initialize Language
        InitializeLanguage()

        FillDynamicSystem()

    End Sub

    Private Sub FrmCDiagram_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        CboFunction.SelectedIndex = 1
        LblPrecision.Text = FrmMain.LM.GetString("Precision") & ": " & (1000 * TrbPrecision.Value).ToString(CultureInfo.CurrentCulture)

        SetDS()

        FillValueParameters()
        CboValueParameter.SelectedIndex = CboValueParameter.Items.Count - 1
        SelectedValueParameter = DS.ValueParameters(CboValueParameter.SelectedIndex)

        InitializeDS()

        'The parameter and startvalue are depending on the type of iteration
        SetDefaultUserData()

        'If the type of iteration changes, everything has to be reset
        ResetIteration()

        IsFormLoaded = True

    End Sub

    Private Sub InitializeLanguage()

        Text = FrmMain.LM.GetString("C-Diagram")
        LblDeltaV.Text = FrmMain.LM.GetString("Delta") & " = "
        LblDeltaC.Text = FrmMain.LM.GetString("Delta") & " = "
        LblValueParameter.Text = FrmMain.LM.GetString("ExaminatedValueParameter")
        LblPrecision.Text = FrmMain.LM.GetString("Precision") & ": " & (TrbPrecision.Value * 1000).ToString(CultureInfo.CurrentCulture)
        LblStartValues.Text = FrmMain.LM.GetString("PositionStartValue2") &
            TrbPositionStartValues.Value.ToString(CultureInfo.CurrentCulture) & "/120"
        LblParameterRange.Text = FrmMain.LM.GetString("ExaminatedParameterRange")
        BtnStartIteration.Text = FrmMain.LM.GetString("StartIteration")

        BtnReset.Text = FrmMain.LM.GetString("ResetIteration")

    End Sub

    Private Sub FillDynamicSystem()
        CboFunction.Items.Clear()

        'Add the classes implementing IBilliardBall
        'to the Combobox CboBilliardTable by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IBilliardTable)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If types.Count > 0 Then
            Dim BilliardName As String
            For Each type In types

                'GetString is calle dwith the option IsClass = true
                'That effects that - if there is no Entry in the Resource files LabelsEN, LabelsDE -
                'the name of the Class implementing an Interface is used as default
                'suppressing the extension "Cls"
                BilliardName = FrmMain.LM.GetString(type.Name, True)
                CboFunction.Items.Add(BilliardName)
            Next
        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If

        'The identifier of the ValueParameter into the CboValueParameters
        'is added when the ValueParameters are known
        'depending on the type of iteration

    End Sub

    Private Sub SetDS()

        'This sets the type of BilliardBall by Reflection

        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IBilliardTable)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If CboFunction.SelectedIndex >= 0 Then

            Dim SelectedName As String = CboFunction.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If FrmMain.LM.GetString(type.Name, True) = SelectedName Then
                        DS = CType(Activator.CreateInstance(type), IBilliardTable)
                    End If
                Next
            End If

        End If

    End Sub

    Private Sub FillValueParameters()

        CboValueParameter.Items.Clear()

        For Each VP As ClsValueParameter In DS.ValueParameters
            CboValueParameter.Items.Add(VP.Name)
        Next

    End Sub

    Public Sub InitializeDS()

        With CDiagramController
            .DS = DS
            .ValueParameter = SelectedValueParameter
            .ValueRange = SelectedValueParameter.Range
            .Precision = TrbPrecision.Value
            .TrbStartPosition = TrbPositionStartValues.Value
            .PicDiagram = PicDiagram
        End With

        With DiagramAreaSelector
            .XRange = DS.ParameterRange
            .YRange = SelectedValueParameter.Range
            .PicDiagram = PicDiagram
            .TxtXMin = TxtCMin
            .TxtXMax = TxtCMax
            .TxtYMin = TxtVMin
            .TxtYMax = TxtVMax
        End With

    End Sub

    Private Sub SetDefaultUserData()

        With CDiagramController
            .ParameterRange = DS.ParameterRange
            .ValueParameter = SelectedValueParameter
            .ValueRange = SelectedValueParameter.Range
            .Precision = TrbPrecision.Value
            .TrbStartPosition = TrbPositionStartValues.Value
        End With

        TxtCMin.Text = DS.ParameterRange.A.ToString(CultureInfo.CurrentCulture)
        TxtCMax.Text = DS.ParameterRange.B.ToString(CultureInfo.CurrentCulture)

        TxtVMin.Text = DS.ValueParameters(CboValueParameter.SelectedIndex).Range.A.ToString(CultureInfo.CurrentCulture)
        TxtVMax.Text = DS.ValueParameters(CboValueParameter.SelectedIndex).Range.B.ToString(CultureInfo.CurrentCulture)
        SetDelta()
    End Sub

    Private Sub SetDelta()
        If IsNumeric(TxtCMax.Text) And IsNumeric(TxtCMin.Text) Then
            LblDeltaC.Text = "Delta = " & (CDec(TxtCMax.Text) - CDec(TxtCMin.Text)).ToString(CultureInfo.CurrentCulture)
        End If
        If IsNumeric(TxtVMax.Text) And IsNumeric(TxtVMin.Text) Then
            LblDeltaV.Text = "Delta = " & (CDec(TxtVMax.Text) - CDec(TxtVMin.Text)).ToString(CultureInfo.CurrentCulture)
        End If
    End Sub

    Sub ResetIteration()
        CDiagramController.ResetIteration()
        SetDefaultUserData()
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        If IsFormLoaded Then
            ResetIteration()
        End If
    End Sub

    Private Sub CboFunktion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboFunction.SelectedIndexChanged
        If IsFormLoaded Then
            SetDS()

            InitializeDS()

            'The parameter and startvalue are depending on the type of iteration
            SetDefaultUserData()

            'If the type of iteration changes, everything has to be reset
            ResetIteration()
        End If
    End Sub

    Private Sub CboValueParameter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboValueParameter.SelectedIndexChanged

        If IsFormLoaded Then
            SelectedValueParameter = DS.ValueParameters(CboValueParameter.SelectedIndex)
            With CDiagramController
                .ValueParameter = SelectedValueParameter
                .ValueRange = SelectedValueParameter.Range
            End With

            InitializeDS()

            'The parameter and startvalue are depending on the type of iteration
            SetDefaultUserData()

            'If the type of iteration changes, everything has to be reset
            ResetIteration()
        End If
    End Sub

    Private Sub TrbPrecision_ValueChanged(sender As Object, e As EventArgs) Handles TrbPrecision.ValueChanged
        If IsFormLoaded Then
            'The precision defines how precise the diagram is generated
            LblPrecision.Text = FrmMain.LM.GetString("Precision") & ": " & (1000 * TrbPrecision.Value).ToString(CultureInfo.CurrentCulture)
            CDiagramController.Precision = TrbPrecision.Value
        End If
    End Sub

    Private Sub TrbPositionStartValues_ValueChanged(sender As Object, e As EventArgs) Handles TrbPositionStartValues.ValueChanged
        If IsFormLoaded Then
            'The position of the start values is a number "pos" between 1 and 11
            'each startvalue is then set = ValueRange.A + pos * ValueRange.IntervalWidth / 120
            LblStartValues.Text = FrmMain.LM.GetString("PositionStartValue2") &
            TrbPositionStartValues.Value.ToString(CultureInfo.CurrentCulture) & "/120"
            CDiagramController.TrbStartPosition = TrbPositionStartValues.Value
        End If
    End Sub


    Private Sub TxtCMin_LostFocus(sender As Object, e As EventArgs) Handles TxtCMin.LostFocus
        If IsFormLoaded Then
            SetDelta()
        End If
    End Sub

    Private Sub TxtCMax_LostFocus(sender As Object, e As EventArgs) Handles TxtCMax.LostFocus
        If IsFormLoaded Then
            SetDelta()
        End If
    End Sub

    Private Sub TxtVMin_LostFocus(sender As Object, e As EventArgs) Handles TxtVMin.LostFocus
        If IsFormLoaded Then
            SetDelta()
        End If
    End Sub

    Private Sub TxtVMax_LostFocus(sender As Object, e As EventArgs) Handles TxtVMax.LostFocus
        If IsFormLoaded Then
            SetDelta()
        End If
    End Sub

    'SECTOR ITERATION

    Private Sub BtnStartIteration_Click(sender As Object, e As EventArgs) Handles BtnStartIteration.Click

        If IsFormLoaded Then
            With CDiagramController
                .ResetIteration()
                If .IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
                    If IsUserDataOK() Then
                        DiagramAreaSelector.IsActivated = False
                        BtnStartIteration.Enabled = False
                        BtnReset.Enabled = False
                        .IterationStatus = ClsDynamics.EnIterationStatus.Ready
                        .ParameterRange = New ClsInterval(CDec(TxtCMin.Text), CDec(TxtCMax.Text))
                        .ValueRange = New ClsInterval(CDec(TxtVMin.Text), CDec(TxtVMax.Text))
                        DiagramAreaSelector.UserXRange = .ParameterRange
                        DiagramAreaSelector.UserYRange = .ValueRange
                    Else
                        SetDefaultUserData()
                    End If
                End If

                If .IterationStatus = ClsDynamics.EnIterationStatus.Ready Then
                    CDiagramController.DoIteration()
                End If

                BtnStartIteration.Enabled = True
                BtnReset.Enabled = True
                .IterationStatus = ClsDynamics.EnIterationStatus.Stopped
                DiagramAreaSelector.IsActivated = True
            End With
        End If

    End Sub


    'CHECK USER RANGES AND SET PARAMETER AND VALUE INTERVAL

    Private Function IsUserDataOK() As Boolean


        Dim CheckParameterRange As New ClsCheckUserData(TxtCMin, TxtCMax, CDiagramController.ParameterRange)
        Dim CheckValueRange As New ClsCheckUserData(TxtVMin, TxtVMax, CDiagramController.ValueParameter.Range)

        Return CheckParameterRange.IsIntervalAllowed And CheckValueRange.IsIntervalAllowed

    End Function

End Class
