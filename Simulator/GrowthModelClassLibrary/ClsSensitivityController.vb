﻿'This class contains the iteration controller for FrmSensitivity

'Status Checked

Imports System.Globalization
Imports System.Reflection

Public Class ClsSensitivityController

    'The dynamic System
    Private DS As IIteration
    Private ReadOnly MyForm As FrmSensitivity

    Private ReadOnly LM As ClsLanguageManager

    'Graphics
    Private PicGraphics As ClsGraphicTool

    'Status Parameters
    'Number of Iteration Steps
    Private n As Integer

    'Actual values of the iteration
    Private x1 As Decimal
    Private x2 As Decimal

    Private Const XStretchingDefault As Integer = 2

    'SECTOR INITIALIZATION

    Public Sub New(Form As FrmSensitivity)
        MyForm = Form
        LM = ClsLanguageManager.LM
    End Sub

    Public Sub FillDynamicSystem()

        MyForm.CboFunction.Items.Clear()

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
                DSName = LM.GetString(type.Name, True)
                'The case of Mandelbrot is only used for Feigenbaum Diagram
                If Not DSName.Contains("Mandel") Then
                    MyForm.CboFunction.Items.Add(DSName)
                End If
            Next
        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If
        MyForm.CboFunction.SelectedIndex = 0
        MyForm.CboIterationDepth.SelectedIndex = 0

    End Sub

    Public Sub SetDS()

        'This sets the type of Iterator by Reflection

        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                             Where(Function(t) t.GetInterfaces().Contains(GetType(IIteration)) AndAlso
                             t.IsClass AndAlso Not t.IsAbstract).ToList()

        If MyForm.CboFunction.SelectedIndex >= 0 Then

            Dim SelectedName As String = MyForm.CboFunction.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If LM.GetString(type.Name, True) = SelectedName Then
                        DS = CType(Activator.CreateInstance(type), IIteration)
                        Exit For
                    End If
                Next
            End If

        End If

        InitializeMe()

        'The parameter and startvalue are depending on the type of iteration
        SetDefaultUserData()

        'If the type of iteration changes, everything has to be reset
        ResetIteration()

    End Sub

    Public Sub InitializeMe()

        MyForm.CboIterationDepth.SelectedIndex = 0
        DS.Power = CInt(MyForm.CboIterationDepth.SelectedItem)
        Dim XRange As ClsInterval = New ClsInterval(1, MyForm.PicDiagram.Width)
        PicGraphics = New ClsGraphicTool(MyForm.PicDiagram, XRange, DS.ValueParameter.Range)

    End Sub

    Public Sub ResetIteration()

        SetControlsEnabled(True)
        With MyForm
            'clear display
            .LstValueList1.Items.Clear()
            .LstValueList2.Items.Clear()
            PicGraphics.Clear(Color.White)

            'Reset Number of steps
            .LblSteps.Text = "0"
        End With
        n = 0
    End Sub

    Public Sub SetDefaultUserData()

        With MyForm
            'default settings
            .TxtParameter.Text = DS.ChaoticParameterValue.ToString(CultureInfo.CurrentCulture)
            .TxtStartValue1.Text = "0.1"
            .TxtStartValue2.Text = "0.100000000000000000000000001"
            .TxtxStretching.Text = XStretchingDefault.ToString(CultureInfo.CurrentCulture)
        End With

    End Sub

    Private Sub SetControlsEnabled(IsEnabled As Boolean)
        With MyForm
            .BtnStart.Enabled = IsEnabled
            .BtnReset.Enabled = IsEnabled
            .BtnDefault.Enabled = IsEnabled
            .CboFunction.Enabled = IsEnabled
            .TxtParameter.Enabled = IsEnabled
            .CboIterationDepth.Enabled = IsEnabled
            .TxtParameter.Enabled = IsEnabled
            .TxtStartValue1.Enabled = IsEnabled
            .TxtStartValue2.Enabled = IsEnabled
            .TxtxStretching.Enabled = IsEnabled
        End With
    End Sub

    'SECTOR ITERATION

    Public Sub StartIteration()
        'This starts the whole iteration

        If IsUserDataOK() Then
            With MyForm
                'Set Ds Parameters
                DS.ParameterA = CDec(.TxtParameter.Text)
                DS.Power = CInt(.CboIterationDepth.SelectedItem)
                x1 = CDec(.TxtStartValue1.Text)
                x2 = CDec(.TxtStartValue2.Text)

                'The initialization was successful
                If DS.IsBehaviourChaotic Then
                    SetControlsEnabled(False)
                    IterationLoop()
                    SetControlsEnabled(True)
                Else
                    'nothing to do, a message is already generated by the test
                End If
            End With
        Else
            'there is already a message generated
        End If
    End Sub

    Public Sub IterationLoop()

        'Both orbits are initialized

        'P1 and NextP1 are the points for the interation of x1 = Startvalue1
        Dim P1 As New ClsMathpoint
        Dim NextP1 As New ClsMathpoint

        'P2 and NextP2 are the points for the interation of x2 = Startvalue2
        Dim P2 As New ClsMathpoint
        Dim NextP2 As New ClsMathpoint

        'This will be the variable of the x-axis
        Dim p As Decimal = 0

        'The check, is XStretching is numeric is done by IsUserDataOK
        Dim XStretching As Integer = CInt(MyForm.TxtxStretching.Text)

        MyForm.Cursor = Cursors.WaitCursor
        Do

            'P1.X is the coordinate on the x-axis
            'and increased by one pixel*xstretching in each iteration step
            P1.X = p * XStretching
            'P1.Y is the y-coordinate and equal to the iteration of x1
            P1.Y = x1

            'similar settings for the next point
            NextP1.X = (p + 1) * XStretching
            NextP1.Y = DS.FN(x1)

            'and similar for the points P2, NextP2
            'for the iteration of x2
            P2.X = p * XStretching
            P2.Y = x2
            NextP2.X = (p + 1) * XStretching
            NextP2.Y = DS.FN(x1)

            'Increase number of steps
            n += 1

            'transmit the new values to the LstValueList1, 2
            UpdateListboxes(x1, x2)

            'and draw the diagram according to the points
            DrawDiagram(P1, NextP1, P2, NextP2)

            'do the ntext iteration step
            x1 = DS.FN(x1)
            x2 = DS.FN(x2)
            p += 1

        Loop Until p * XStretching >= MyForm.PicDiagram.Width

        MyForm.Cursor = Cursors.Arrow
        MyForm.LblSteps.Text = n.ToString(CultureInfo.CurrentCulture)

    End Sub

    Private Sub UpdateListboxes(u1 As Decimal, u2 As Decimal)
        With MyForm
            'LstValueList1 and 2 are filled with the actual iteration value
            .LstValueList1.Items.Add(u1.ToString(CultureInfo.CurrentCulture))
            .LstValueList1.SelectedIndex = .LstValueList1.Items.Count - 1

            .LstValueList2.Items.Add(u2.ToString(CultureInfo.CurrentCulture))
            .LstValueList2.SelectedIndex = .LstValueList2.Items.Count - 1
        End With
    End Sub

    'Overloading if u2 is not relevant
    Private Sub UpdateListboxes(u1 As Decimal)
        UpdateListboxes(u1, -1)
    End Sub

    Private Sub DrawDiagram(P1 As ClsMathpoint, nextP1 As ClsMathpoint, P2 As ClsMathpoint, nextP2 As ClsMathpoint)

        If MyForm.OptDifference.Checked Then 'The difference of the two orbits is shown

            'Draw the difference of the orbits: x2 - x1
            Dim D As New ClsMathpoint(P1.X, DS.ValueParameter.Range.A + Math.Abs(P2.Y - P1.Y))
            Dim NextD As New ClsMathpoint(nextP1.X, DS.ValueParameter.Range.A + Math.Abs(nextP2.Y - nextP1.Y))
            PicGraphics.DrawLine(D, NextD, Color.Blue, 1)

        Else

            'Draw the single orbits x1, x2
            PicGraphics.DrawLine(P1, nextP1, Color.Red, 1)
            PicGraphics.DrawLine(P2, nextP2, Color.Green, 1)

        End If

    End Sub

    'SECTOR CHECK USERDATA

    Private Function IsUserDataOK() As Boolean

        'Is the value of TxtParameter in the Iteration Interval?
        Dim CheckParameter = New ClsCheckUserData(MyForm.TxtParameter, DS.DSParameter.Range)
        Dim CheckStartValue1 = New ClsCheckUserData(MyForm.TxtStartValue1, DS.ValueParameter.Range)
        Dim CheckStartValue2 = New ClsCheckUserData(MyForm.TxtStartValue2, DS.ValueParameter.Range)

        Dim StretchInterval = New ClsInterval(1, 10)
        Dim CheckStretchInterval = New ClsCheckUserData(MyForm.TxtxStretching, StretchInterval)

        Return CheckParameter.IsTxtValueAllowed And CheckStartValue1.IsTxtValueAllowed _
            And CheckStartValue2.IsTxtValueAllowed And CheckStretchInterval.IsTxtValueAllowed

    End Function

End Class
