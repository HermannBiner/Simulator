'This class is the controller for the strange attractor form

'Status Tested

Imports System.Globalization
Imports System.Reflection

Public Class ClsStrangeAttractorController

    Private ReadOnly MyForm As FrmStrangeAttractor

    Private ReadOnly LM As ClsLanguageManager

    Private DS As IStrangeAttractor

    'Iterated Points
    Private IterationPointSet As ClsPointSet

    'Number of Steps
    Private N As Integer

    'view angles
    Private Phi As Decimal
    Private Theta As Decimal

    'when setting the view by the mouse
    Private IsMouseDown As Boolean

    'the iterationstatus steeres the iteration
    Private IterationStatus As ClsDynamics.EnIterationStatus

    'Diagrams and Graphics
    Private MathInterval As ClsInterval
    Private PicGraphics As ClsGraphicTool
    Private BmpDiagram As Bitmap
    Private BmpGraphics As ClsGraphicTool

    'SECTOR INITIALIZATION

    Public Sub New(frm As FrmStrangeAttractor)
        MyForm = frm
        LM = ClsLanguageManager.LM
        IterationPointSet = New ClsPointSet
    End Sub

    Public Sub FillDynamicSystem()

        'a dynamic system is here a strange attractor
        'with an individual formula for the iteration

        MyForm.CboStrangeAttractor.Items.Clear()

        'Add the classes implementing IStrangeAttractor
        'to the Combobox CboUniverse by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IStrangeAttractor)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If types.Count > 0 Then
            Dim DSName As String
            For Each type In types

                'GetString is called with the option IsClass = true
                'That effects that - if there is no Entry in the Resource files LabelsEN, LabelsDE -
                'the name of the Class implementing an Interface is used as default
                'suppressing the extension "Cls"
                DSName = LM.GetString(type.Name, True)
                MyForm.CboStrangeAttractor.Items.Add(DSName)
            Next

        Else
            Throw New ArgumentNullException("MissingImplementation")
        End If
        MyForm.CboStrangeAttractor.SelectedIndex = 1

    End Sub

    Public Sub SetDS()

        'This sets the type of the StrangeAttractor by Reflection
        Dim types As List(Of Type) = Assembly.GetExecutingAssembly().GetTypes().
                                 Where(Function(t) t.GetInterfaces().Contains(GetType(IStrangeAttractor)) AndAlso
                                 t.IsClass AndAlso Not t.IsAbstract).ToList()

        If MyForm.CboStrangeAttractor.SelectedIndex >= 0 Then

            Dim SelectedName As String = MyForm.CboStrangeAttractor.SelectedItem.ToString

            If types.Count > 0 Then
                For Each type In types
                    If LM.GetString(type.Name, True) = SelectedName Then
                        DS = CType(Activator.CreateInstance(type), IStrangeAttractor)
                        Exit For
                    End If
                Next
            End If

        End If

        'Setting the standard parameters
        InitializeMe()

        SetDefaultUserData()

        ResetIteration()

    End Sub

    Private Sub InitializeMe()
        DS.CreateStartPointSets()

        MyForm.CboStartpointSets.Items.Clear()

        For Each StartConstellation As ClsPointSet In DS.StartPointSets
            MyForm.CboStartpointSets.Items.Add(StartConstellation.Name)
        Next
        MyForm.CboStartpointSets.SelectedIndex = 0
        SetStartPointSet()

        'Diagrams and Graphics
        MathInterval = DS.MathInterval
        PicGraphics = New ClsGraphicTool(MyForm.PicDiagram, MathInterval, MathInterval)
        BmpDiagram = New Bitmap(MyForm.PicDiagram.Width, MyForm.PicDiagram.Height)
        BmpGraphics = New ClsGraphicTool(BmpDiagram, MathInterval, MathInterval)
        MyForm.PicDiagram.Image = BmpDiagram

        MyForm.LblDSParameter.Text = DS.DSParameter.Name  'the same mathematical variable in any language

        'View
        MyForm.Opt3D.Checked = True
        Phi = CDec(-Math.PI / 15)
        Theta = CDec(Math.PI / 8)
        SetAngleText()
        DrawCoordinateCube()

        EnableTxt(True)

    End Sub

    Public Sub SetStartPointSet()

        Dim Name As String = MyForm.CboStartpointSets.SelectedItem.ToString

        For Each StartPointSet As ClsPointSet In DS.StartPointSets
            If StartPointSet.Name = Name Then
                IterationPointSet = StartPointSet
                Exit For
            End If
        Next

        SetTrbFromStepWidth(IterationPointSet.ProposedStepWidth)
        SetTrbFromDSParameter(DS.DSParameterValue)

        With MyForm
            .TxtX.Text = ""
            .TxtY.Text = ""
            .TxtZ.Text = ""
        End With

        For Each aPoint As ClsIterationPoint In IterationPointSet.Points
            With MyForm
                .TxtX.Text &= aPoint.ActualPoint.X.ToString(CultureInfo.CurrentCulture) & "/"
                .TxtY.Text &= aPoint.ActualPoint.Y.ToString(CultureInfo.CurrentCulture) & "/"
                .TxtZ.Text &= aPoint.ActualPoint.Z.ToString(CultureInfo.CurrentCulture) & "/"
            End With
        Next

        With MyForm
            .TxtX.Text = .TxtX.Text.Substring(0, Math.Max(0, .TxtX.Text.Length - 1))
            .TxtY.Text = .TxtY.Text.Substring(0, Math.Max(0, .TxtY.Text.Length - 1))
            .TxtZ.Text = .TxtZ.Text.Substring(0, Math.Max(0, .TxtZ.Text.Length - 1))
        End With

        EnableTxt(True)

    End Sub

    Public Sub SetDefaultUserData()
        For Each anIterationPoint As ClsIterationPoint In IterationPointSet.Points
            anIterationPoint.SetDefaultUserData()
        Next
        ResetIteration()
    End Sub

    Public Sub ResetIteration()
        With MyForm
            .LblSteps.Text = "0"
            N = 0
            IterationStatus = ClsDynamics.EnIterationStatus.Stopped
            .BtnStart.Text = LM.GetString("Start")
        End With
        BmpGraphics.Clear(Color.White)
        DrawCoordinateCube()

        For Each anIterationPoint As ClsIterationPoint In IterationPointSet.Points
            anIterationPoint.ResetIteration()
        Next

        With MyForm
            .BtnStart.Enabled = False
            .BtnStop.Enabled = False
            .BtnTakeOverPointSet.Enabled = True
            .BtnDefault.Enabled = True
            .BtnReset.Enabled = True
            .CboStrangeAttractor.Enabled = True
            .CboStartpointSets.Enabled = True
        End With

    End Sub

    Public Sub TakeOverPointSet()
        If IterationPointSet.Count = 1 Then
            IterationPointSet.Points(0).ActualPoint.X = CDec(MyForm.TxtX.Text)
            IterationPointSet.Points(0).ActualPoint.Y = CDec(MyForm.TxtY.Text)
            IterationPointSet.Points(0).ActualPoint.Z = CDec(MyForm.TxtZ.Text)
        End If
        SetStartPointSet()
        DrawStartpointSet()
        With MyForm
            .BtnStart.Enabled = True
            .BtnStop.Enabled = False
            .BtnTakeOverPointSet.Enabled = True
            .BtnDefault.Enabled = True
            .BtnReset.Enabled = True
        End With
    End Sub

    Private Sub DrawStartpointSet()
        Dim DrawPoint = New ClsMathpoint
        For Each Point As ClsIterationPoint In IterationPointSet.Points
            DrawPoint.X = Point.ActualPoint.X
            DrawPoint.Y = Point.ActualPoint.Y
            DrawPoint.Z = Point.ActualPoint.Z
            Select Case True
                Case MyForm.Opt3D.Checked
                    PicGraphics.DrawPoint(Projection3D(DrawPoint), Point.Color, 3)
                Case MyForm.OptXY.Checked
                    PicGraphics.DrawPoint(ProjectionXY(DrawPoint), Point.Color, 3)
                Case Else
                    PicGraphics.DrawPoint(ProjectionXZ(DrawPoint), Point.Color, 3)
            End Select
        Next
    End Sub

    Public Sub SetDSParameterFromTrb()
        DS.DSParameterValue = DS.DSParameter.Range.A + MyForm.TrbDSParameter.Value * (DS.DSParameter.Range.B - DS.DSParameter.Range.A) / 1000
        MyForm.TxtDSParameter.Text = DS.DSParameterValue.ToString(CultureInfo.CurrentCulture)
        ResetIteration()
    End Sub

    Private Sub SetTrbFromDSParameter(LocDSParameter As Decimal)
        MyForm.TrbDSParameter.Value = CInt((LocDSParameter - DS.DSParameter.Range.A) * 1000 / (DS.DSParameter.Range.B - DS.DSParameter.Range.A))
        MyForm.TxtDSParameter.Text = LocDSParameter.ToString(CultureInfo.CurrentCulture)
    End Sub

    Public Sub SetStepWidthFromTrb()
        With DS
            Select Case MyForm.TrbStepWidth.Value
                Case 1
                    .StepWidth = CDec(0.00001)
                Case 2
                    .StepWidth = CDec(0.00005)
                Case 3
                    .StepWidth = CDec(0.0001)
                Case 4
                    .StepWidth = CDec(0.0005)
                Case 5
                    .StepWidth = CDec(0.001)
                Case 6
                    .StepWidth = CDec(0.005)
                Case 7
                    .StepWidth = CDec(0.01)
                Case 8
                    .StepWidth = CDec(0.05)
                Case Else
                    .StepWidth = CDec(0.1)
            End Select
            MyForm.LblStepWidth.Text = LM.GetString("StepWidth") & ": " & .StepWidth.ToString(CultureInfo.CurrentCulture)
        End With
    End Sub

    Private Sub SetTrbFromStepWidth(LocStepwidth As Decimal)
        Select Case LocStepwidth
            Case CDec(0.00001)
                MyForm.TrbStepWidth.Value = 1
            Case CDec(0.00005)
                MyForm.TrbStepWidth.Value = 2
            Case CDec(0.0001)
                MyForm.TrbStepWidth.Value = 3
            Case CDec(0.0005)
                MyForm.TrbStepWidth.Value = 4
            Case CDec(0.001)
                MyForm.TrbStepWidth.Value = 5
            Case CDec(0.005)
                MyForm.TrbStepWidth.Value = 6
            Case CDec(0.01)
                MyForm.TrbStepWidth.Value = 7
            Case CDec(0.05)
                MyForm.TrbStepWidth.Value = 8
            Case Else
                MyForm.TrbStepWidth.Value = 9
        End Select
        MyForm.LblStepWidth.Text = LM.GetString("StepWidth") & ": " & LocStepwidth.ToString(CultureInfo.CurrentCulture)
    End Sub

    Private Sub SetAngleText()
        With MyForm
            .TxtPhi.Text = Phi.ToString("N5", CultureInfo.CurrentCulture)
            .TxtTheta.Text = Theta.ToString("N5", CultureInfo.CurrentCulture)
        End With
    End Sub

    'SECTOR SET VIEW

    Public Sub MouseDown(e As MouseEventArgs)
        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped And MyForm.Opt3D.Checked Then
            IsMouseDown = True
            MyForm.Cursor = Cursors.Hand
        End If
    End Sub

    Public Sub MouseMove(e As MouseEventArgs)
        If IsMouseDown Then
            'Because the Cursor is "Hand", the Mouse Position is adjusted a bit
            Dim Mouseposition As New Point With {
            .X = e.X + 2,
            .Y = e.Y - 25
        }

            Dim PlanePoint = New ClsMathpoint
            'first set PlanePoint to the mouseposition
            With DS.MathInterval
                PlanePoint.X = Math.Min(.B, Math.Max(.A, .A + (.B - .A) * Mouseposition.X / MyForm.PicDiagram.Width))
                'because of the inverted y-axis
                PlanePoint.Y = Math.Min(.B, Math.Max(.A, .B - ((.B - .A) * Mouseposition.Y / MyForm.PicDiagram.Height)))
            End With

            With PlanePoint
                MouseMoving(.X, .Y)
            End With

            SetAngleText()
            DrawCoordinateCube()
        End If
    End Sub

    Private Sub MouseMoving(X As Decimal, Y As Decimal)

        'phi is between -pi/2 and PI/2
        With DS.MathInterval
            Phi = Math.Max(CDec(-(Math.PI / 2)), Math.Min(CDec(Math.PI / 2), CDec(Math.PI) * (X - .A) / (.B - .A) - CDec(Math.PI / 2)))
        End With

        'Theta is between 1 (visibility) and 0.01
        With DS.MathInterval
            Theta = Math.Min(1, Math.Max(CDec(0.01), CDec(Math.PI / 2) * ((.B + 2 * .A - 3 * Y) / (.B - .A))))
        End With
    End Sub

    Public Sub MouseUp(e As MouseEventArgs)
        If IsMouseDown Then

            'The Mouse gets its normal behaviour again
            MyForm.Cursor = Cursors.Arrow
            IsMouseDown = False
        End If
    End Sub

    Private Sub DrawCoordinateCube()

        'Cornerpoints of the cube - see math.doc.
        'because of visibility: The floor-square has the diagonal of length 2*sqrt(2)
        Dim e As Decimal = CDec((DS.MathInterval.B - DS.MathInterval.A) / (2 * Math.Sqrt(2)))
            Dim CornerPoints(9) As ClsMathpoint
        CornerPoints(0) = New ClsMathpoint(e, e, 0)
        CornerPoints(1) = New ClsMathpoint(e, -e, 0)
        CornerPoints(2) = New ClsMathpoint(-e, -e, 0)
        CornerPoints(3) = New ClsMathpoint(-e, e, 0)
        CornerPoints(4) = New ClsMathpoint(e, -e, e)
        CornerPoints(5) = New ClsMathpoint(-e, -e, e)

        'Midpoint
        CornerPoints(6) = New ClsMathpoint(0, 0, 0)
        'x-axis
        CornerPoints(7) = New ClsMathpoint(e + 1, 0, 0)
        'y-axis
        CornerPoints(8) = New ClsMathpoint(0, e + 1, 0)
        'z-axis
        CornerPoints(9) = New ClsMathpoint(0, 0, e + 1)

        'Clear Bitmap
        BmpGraphics.Clear(Color.White)

        Select Case True
            Case MyForm.Opt3D.Checked
                'The cube is drawn in PicDiagram
                With BmpGraphics
                    'Floor space
                    .DrawLine(Projection3D(CornerPoints(0)), Projection3D(CornerPoints(1)), Color.Black, 1)
                    .DrawLine(Projection3D(CornerPoints(1)), Projection3D(CornerPoints(2)), Color.Black, 1)
                    .DrawLine(Projection3D(CornerPoints(2)), Projection3D(CornerPoints(3)), Color.Black, 1)
                    .DrawLine(Projection3D(CornerPoints(3)), Projection3D(CornerPoints(0)), Color.Black, 1)
                    'Branche lines
                    .DrawLine(Projection3D(CornerPoints(1)), Projection3D(CornerPoints(4)), Color.Black, 1)
                    .DrawLine(Projection3D(CornerPoints(2)), Projection3D(CornerPoints(5)), Color.Black, 1)
                    'Roof
                    .DrawLine(Projection3D(CornerPoints(4)), Projection3D(CornerPoints(5)), Color.Black, 1)
                    'Box
                    .DrawPoint(Projection3D(CornerPoints(0)), Brushes.Red, 3)
                    .DrawPoint(Projection3D(CornerPoints(1)), Brushes.Black, 2)
                    .DrawPoint(Projection3D(CornerPoints(2)), Brushes.Black, 2)
                    .DrawPoint(Projection3D(CornerPoints(3)), Brushes.Black, 2)
                    .DrawPoint(Projection3D(CornerPoints(4)), Brushes.Black, 2)
                    .DrawPoint(Projection3D(CornerPoints(5)), Brushes.Black, 2)
                    .DrawPoint(Projection3D(CornerPoints(6)), Brushes.Black, 3)
                    'CoordinateAxes
                    .DrawLine(Projection3D(CornerPoints(6)), Projection3D(CornerPoints(7)), Color.Red, 2)
                    .DrawLine(Projection3D(CornerPoints(6)), Projection3D(CornerPoints(8)), Color.Red, 2)
                    .DrawLine(Projection3D(CornerPoints(6)), Projection3D(CornerPoints(9)), Color.Red, 2)
                End With

            Case MyForm.OptXY.Checked
                With BmpGraphics
                    'only x-y-axis
                    .DrawLine(ProjectionXY(CornerPoints(6)), ProjectionXY(CornerPoints(7)), Color.Red, 2)
                    .DrawLine(ProjectionXY(CornerPoints(6)), ProjectionXY(CornerPoints(8)), Color.Red, 2)
                    .DrawLine(ProjectionXY(CornerPoints(6)), ProjectionXY(CornerPoints(9)), Color.Red, 2)
                End With
            Case Else
                With BmpGraphics
                    'only x-y-axis
                    .DrawLine(ProjectionXZ(CornerPoints(6)), ProjectionXZ(CornerPoints(7)), Color.Red, 2)
                    .DrawLine(ProjectionXZ(CornerPoints(6)), ProjectionXZ(CornerPoints(8)), Color.Red, 2)
                    .DrawLine(ProjectionXZ(CornerPoints(6)), ProjectionXZ(CornerPoints(9)), Color.Red, 2)
                End With
        End Select

        MyForm.PicDiagram.Refresh()

    End Sub

    Public Sub ShowProjectionAngles()
        With MyForm
            .LblPhi.Visible = .Opt3D.Checked
            .TxtPhi.Visible = .Opt3D.Checked
            .LblTheta.Visible = .Opt3D.Checked
            .TxtTheta.Visible = .Opt3D.Checked
        End With
        ResetIteration()
    End Sub

    Private Function Projection3D(ByRef RealPoint As ClsMathpoint) As ClsMathpoint

        Dim RotatedPoint = New ClsMathpoint

        'rotate see math.doc.
        With RealPoint
            RotatedPoint.X = CDec(.X * Math.Cos(Phi) - .Y * Math.Sin(Phi) * Math.Cos(Theta) - .Z * Math.Sin(Phi) * Math.Sin(Theta))
            RotatedPoint.Y = CDec(.X * Math.Sin(Phi) + .Y * Math.Cos(Phi) * Math.Cos(Theta) + .Z * Math.Cos(Phi) * Math.Sin(Theta))
            RotatedPoint.Z = CDec(- .Y * Math.Sin(Theta) + .Z * Math.Cos(Theta))
        End With

        'Projection to plane y = 1, and the x-direction is inverted
        Dim PlanePoint = New ClsMathpoint With {
            .X = -RotatedPoint.X,
            .Y = RotatedPoint.Z
        }

        'Finally translation to the new origin in the about middle of the plane
        With DS.MathInterval
            PlanePoint.X += (.A + .B) / 2
            PlanePoint.Y += (.A * 2 + .B) / 3 + DS.ViewCorrection.Component(0)
        End With

        'visibility of the y-axis
        PlanePoint.Y = Math.Max(DS.MathInterval.A, PlanePoint.Y)

        Return PlanePoint

    End Function

    Private Function ProjectionXY(ByRef RealPoint As ClsMathpoint) As ClsMathpoint

        Dim PlanePoint = New ClsMathpoint

        With PlanePoint
            .X = RealPoint.X
            .Y = RealPoint.Y
        End With

        'Finally translation to the new origin in the about middle of the plane
        With DS.MathInterval
            PlanePoint.X += (.A + .B) / 2
            PlanePoint.Y += (.A * 2 + .B) / 3 + DS.ViewCorrection.Component(1)
        End With

        Return PlanePoint

    End Function

    Private Function ProjectionXZ(ByRef RealPoint As ClsMathpoint) As ClsMathpoint

        Dim PlanePoint = New ClsMathpoint

        With PlanePoint
            .X = RealPoint.X
            .Y = RealPoint.Z
        End With

        'Finally translation to the new origin in the about middle of the plane
        With DS.MathInterval
            PlanePoint.X += (.A + .B) / 2
            PlanePoint.Y += (.A * 2 + .B) / 3 + DS.ViewCorrection.Component(2)
        End With

        Return PlanePoint

    End Function

    'SECTOR ITERATION

    Public Async Sub StartIteration()

        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            If IterationPointSet.Count > 0 Then
                If IsUserDataOK() Then
                    IterationStatus = ClsDynamics.EnIterationStatus.Ready
                    SetStepWidthFromTrb()
                    DS.SetIterationParameters()
                    MyForm.PicDiagram.Refresh()
                    With MyForm
                        .BtnStart.Enabled = False
                        .BtnStop.Enabled = True
                        .BtnTakeOverPointSet.Enabled = False
                        .BtnDefault.Enabled = False
                        .BtnReset.Enabled = False
                        .Opt3D.Enabled = False
                        .OptXY.Enabled = False
                        .OptXZ.Enabled = False
                        .CboStrangeAttractor.Enabled = False
                        .CboStartpointSets.Enabled = False
                    End With
                Else
                    'Message already generated
                    ResetIteration()
                End If
            Else
                MsgBox(LM.GetString("NoPointSet"))
            End If
        End If

        If IterationStatus = ClsDynamics.EnIterationStatus.Ready Or
                    IterationStatus = ClsDynamics.EnIterationStatus.Interrupted Then
            IterationStatus = ClsDynamics.EnIterationStatus.Running
            With MyForm
                .BtnStart.Text = LM.GetString("Continue")
                .Cursor = Cursors.WaitCursor
            End With
            MyForm.BtnStart.Enabled = False
            MyForm.BtnStop.Enabled = True

            Application.DoEvents()

            Await IterationLoop()

        End If

    End Sub

    Public Sub StopIteration()
        IterationStatus = ClsDynamics.EnIterationStatus.Interrupted
        MyForm.Cursor = Cursors.Arrow
        With MyForm
            .BtnStart.Enabled = True
            .BtnStop.Enabled = True
            .BtnTakeOverPointSet.Enabled = False
            .BtnDefault.Enabled = True
            .BtnReset.Enabled = True
            .Opt3D.Enabled = True
            .OptXY.Enabled = True
            .OptXZ.Enabled = True
        End With
    End Sub

    Public Async Function IterationLoop() As Task
        Do

            For Each aPoint As ClsIterationPoint In IterationPointSet.Points
                DS.ActualMathPoint = aPoint.ActualPoint
                DS.IterationStep()
                aPoint.ActualPoint.Equal(DS.ActualMathPoint)
                N += 1

                With MyForm
                    .LblSteps.Text = N.ToString(CultureInfo.CurrentCulture)
                    Select Case True
                        Case .Opt3D.Checked
                            PicGraphics.DrawPoint(Projection3D(aPoint.ActualPoint), aPoint.Color, 1)
                        Case .OptXY.Checked
                            PicGraphics.DrawPoint(ProjectionXY(aPoint.ActualPoint), aPoint.Color, 1)
                        Case Else
                            PicGraphics.DrawPoint(ProjectionXZ(aPoint.ActualPoint), aPoint.Color, 1)
                    End Select
                End With
            Next

            If N Mod 200 = 0 Then
                Await Task.Delay(1)
            End If

        Loop Until IterationStatus = ClsDynamics.EnIterationStatus.Interrupted _
            Or IterationStatus = ClsDynamics.EnIterationStatus.Stopped
    End Function

    Private Sub EnableTxt(IsEnabled As Boolean)
        With MyForm
            If IterationPointSet.Count = 1 Then
                .TxtX.Enabled = IsEnabled
                .TxtY.Enabled = IsEnabled
                .TxtZ.Enabled = IsEnabled
            Else
                .TxtX.Enabled = False
                .TxtY.Enabled = False
                .TxtZ.Enabled = False
            End If

        End With
    End Sub

    'SECTOR CHECK USERDATA

    Private Function IsUserDataOK() As Boolean

        If MyForm.TxtX.Enabled Then
            'the user can make changes
            Dim CheckX = New ClsCheckUserData(MyForm.TxtX, DS.XValueParameter.Range)
            Dim CheckY = New ClsCheckUserData(MyForm.TxtY, DS.YValueParameter.Range)
            Dim CheckZ = New ClsCheckUserData(MyForm.TxtZ, DS.ZValueParameter.Range)

            'Return CheckX.IsTxtValueAllowed And CheckY.IsTxtValueAllowed And CheckZ.IsTxtValueAllowed
            Return True
        Else
            Return True
        End If


    End Function

End Class
