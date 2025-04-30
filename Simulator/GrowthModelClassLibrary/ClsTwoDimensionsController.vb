
'This class contains the iteration controller for FrmTwoDimensions

'Status Checked

Imports System.Globalization
Imports System.IO
Imports System.Reflection

Public Class ClsTwoDimensionsController

    'The dynamic System
    Private DS As IIteration
    Private ReadOnly MyForm As FrmTwoDimensions

    Private ReadOnly LM As ClsLanguageManager

    'The Graphic Helper for PicDiagram
    Private PicGraphics As ClsGraphicTool
    Private BmpDiagram As Bitmap
    Private BmpGraphics As ClsGraphicTool

    'Actual values of the iteration
    Private ReadOnly IterationPoint As ClsMathpoint

    'IterationDepth: 5 is optimal, due to eXperiments
    Private Const Standardpower As Integer = 5

    'Representing the raster for the measure eXactness of the eXperimentator in PiXels
    Private Const Rastersize As Integer = 5

    'Size of a cell in math. units
    Private DeltaX As Decimal

    'Size of the diagram in Pixels
    Private Diagramsize As Integer

    Private MyBrush As SolidBrush

    'Iteration Status
    Private IterationStatus As ClsDynamics.EnIterationStatus

    Private Enum EnMode
        Sensitivity
        Transitivity
    End Enum

    Private Mode As EnMode

    'To mark start- and targetcell
    Private IsMouseDown As Boolean
    'the left bottom corner of a cell
    Private IsStartCellMarked As Boolean
    Private IsTargetCellMarked As Boolean
    Private StoredCell As ClsMathpoint

    'SECTOR INITIALIZATION

    Public Sub New(Form As FrmTwoDimensions)
        MyForm = Form
        LM = ClsLanguageManager.LM
        IterationPoint = New ClsMathpoint(0, 0)
        StoredCell = New ClsMathpoint(0, 0)
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

        'Iteration Depth
        DS.Power = Standardpower

        PicGraphics = New ClsGraphicTool(MyForm.PicDiagram, DS.ValueParameter.Range, DS.ValueParameter.Range)
        BmpDiagram = New Bitmap(MyForm.PicDiagram.Width, MyForm.PicDiagram.Height)
        MyForm.PicDiagram.Image = BmpDiagram
        BmpGraphics = New ClsGraphicTool(BmpDiagram, DS.ValueParameter.Range, DS.ValueParameter.Range)

        'Adapting DeltaX to the Iteration.Interval.Width
        'that all type of Iteration Functions have the same Raster
        Diagramsize = Math.Min(MyForm.PicDiagram.Width, MyForm.PicDiagram.Height)
        DeltaX = CDec(Rastersize / Diagramsize) * DS.ValueParameter.Range.IntervalWidth

        PrepareDiagram()
        SetBrush()

        MyForm.OptSensitivity.Checked = True
        Mode = EnMode.Sensitivity

    End Sub

    Public Sub SetDefaultUserData()
        With MyForm
            'default settings
            .TxtParameter.Text = DS.ChaoticParameterValue.ToString(CultureInfo.CurrentCulture)
            .TxtX.Text = (DS.ValueParameter.Range.A +
                (DS.ValueParameter.Range.IntervalWidth * 0.414)).ToString(CultureInfo.CurrentCulture)
            .TxtY.Text = (DS.ValueParameter.Range.A +
                (DS.ValueParameter.Range.IntervalWidth * 0.407)).ToString(CultureInfo.CurrentCulture)
            .CboExperiment.SelectedIndex = 0
            .TxtX.Select()
        End With
    End Sub

    Public Sub PrepareDiagram()

        'The raster shows the measure exactness of the experimentator
        'one square in the raster has 5X5 piXel points
        'that corresponds to a measure eXactness of about 0.00825 for the X- and y-values

        BmpGraphics.Clear(Color.White)

        'Counter
        Dim i As Integer = 0

        'Corresponding X- and y-coordinates
        Dim u As Decimal

        Do

            'lines parallel to the y-aXis
            u = DS.ValueParameter.Range.A + (i * DeltaX)
            Dim X1 As New ClsMathpoint(u, DS.ValueParameter.Range.A)
            Dim X2 As New ClsMathpoint(u, DS.ValueParameter.Range.B)
            BmpGraphics.DrawLine(X1, X2, Color.Aqua, 1)

            'lines parallel to the X-aXis
            Dim Y1 As New ClsMathpoint(DS.ValueParameter.Range.A, u)
            Dim Y2 As New ClsMathpoint(DS.ValueParameter.Range.B, u)
            BmpGraphics.DrawLine(Y1, Y2, Color.Aqua, 1)

            i += 1

        Loop Until i * DeltaX >= DS.ValueParameter.Range.IntervalWidth

        MyForm.PicDiagram.Refresh()

    End Sub

    Public Sub SetBrush()
        If Mode = EnMode.Sensitivity Then
            'To show the effect of different experiments,
            'there are 5 possible startpoints in different colors
            Select Case MyForm.CboExperiment.SelectedIndex
                Case 0
                    MyBrush = CType(Brushes.Black, SolidBrush)
                Case 1
                    MyBrush = CType(Brushes.Green, SolidBrush)
                Case 2
                    MyBrush = CType(Brushes.Blue, SolidBrush)
                Case 3
                    MyBrush = CType(Brushes.Magenta, SolidBrush)
                Case Else
                    MyBrush = CType(Brushes.Red, SolidBrush)
            End Select
        Else
            MyBrush = CType(Brushes.Blue, SolidBrush)
        End If

        IterationStatus = ClsDynamics.EnIterationStatus.Interrupted

    End Sub

    Public Sub SetFunction()
        With MyForm
            If .OptSensitivity.Checked Then
                Mode = EnMode.Sensitivity
                .BtnNextStep.Text = LM.GetString("NextStep")
                .BtnNext10.Text = LM.GetString("Next10Steps")
            Else
                Mode = EnMode.Transitivity
                .BtnNextStep.Text = LM.GetString("Start")
                .BtnNext10.Text = LM.GetString("Stop")
            End If
        End With
        SetBrush()
        ResetIteration()
    End Sub

    Public Sub ResetIteration()

        'Clear Display
        PicGraphics.Clear(Color.White)
        IterationStatus = ClsDynamics.EnIterationStatus.Stopped
        MyForm.PicDiagram.Refresh()
        IsStartCellMarked = False
        IsTargetCellMarked = False
        PrepareDiagram()
    End Sub

    'SECTOR SET START AND TARGET

    Public Sub MouseDown(e As MouseEventArgs)
        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped _
            Or IterationStatus = ClsDynamics.EnIterationStatus.Interrupted Then
            If Not IsTargetCellMarked Then
                MyForm.Cursor = Cursors.Hand
                IsMouseDown = True
                'Moving the Mouse to mark startcell and evtl. targetcell
                MouseMove(e)
            End If
        End If
    End Sub

    Public Sub MouseMove(e As MouseEventArgs)
        If IsMouseDown Then
            'Because the Cursor is "Hand", the Mouse Position is adjusted a bit
            Dim Mouseposition As New Point With {
            .X = e.X - 2,
            .Y = e.Y - 7
        }
            'Transformation from Mouse- to math. coordinates
            Dim MathMousePosition As New ClsMathpoint(PixelqToMathX(Mouseposition.X), PixelqToMathY(Mouseposition.Y))

            'Left bottom corner of the corresponding cell
            'k: Number of DeltaX to the cell
            Dim k As Integer
            'x coordinate
            k = CInt(Fix(MathMousePosition.X / DeltaX))
            MathMousePosition.X = k * DeltaX
            'y coordinate
            k = CInt(Fix(MathMousePosition.Y / DeltaX))
            MathMousePosition.Y = k * DeltaX

            If Not IsStartCellMarked Then
                MarkCell(MathMousePosition, Brushes.Blue, False)
            ElseIf Not IsTargetCellMarked Then
                MarkCell(MathMousePosition, Brushes.Red, False)

            Else
                'nothing
            End If

            'unmark stored cell
            MarkCell(StoredCell, Brushes.White, False)
            MyForm.PicDiagram.Refresh()

            'store actual cell
            StoredCell.Equal(MathMousePosition)

        End If
    End Sub

    Public Sub MouseUp(e As MouseEventArgs)

        'Has only an effect, if the Mouse was down
        If IsMouseDown Then



            If Not IsStartCellMarked Then
                'only Startcell relevant
                MarkCell(StoredCell, Brushes.Blue, True)
                IsStartCellMarked = True
                'Write MidPoint of the cell to TxtX, TxtY
                With MyForm
                    .TxtX.Text = Math.Round(StoredCell.X + DeltaX / 2, 3).ToString
                    .TxtY.Text = Math.Round(StoredCell.Y + DeltaX / 2, 3).ToString
                End With
                If Mode = EnMode.Sensitivity Then
                    IsTargetCellMarked = True
                End If
            Else
                'TargetCell is relevant
                If Not IsTargetCellMarked Then
                    MarkCell(StoredCell, Brushes.Red, True)
                    IsTargetCellMarked = True
                    If IsUserDataOK() Then
                        'Adapt Startpoint for Targetpoint
                        IterationPoint.X = CDec(MyForm.TxtX.Text)
                        IterationPoint.Y = CDec(MyForm.TxtY.Text)
                        IterationPoint.X = DS.CalculateStartValueForTargetValue(IterationPoint.X, Math.Round(StoredCell.X + DeltaX / 2, 3))
                        IterationPoint.Y = DS.CalculateStartValueForTargetValue(IterationPoint.Y, Math.Round(StoredCell.Y + DeltaX / 2, 3))
                        With MyForm
                            .TxtX.Text = IterationPoint.X.ToString
                            .TxtY.Text = IterationPoint.Y.ToString
                        End With
                    Else
                        'Message already generated
                    End If
                End If
            End If

            'The Mouse gets its normal behaviour again
            MyForm.Cursor = Cursors.Arrow
            IsMouseDown = False

        End If

    End Sub

    Private Function PixelqToMathX(p As Integer) As Decimal

        Dim x As Decimal = DS.ValueParameter.Range.A + (p * DS.ValueParameter.Range.IntervalWidth / Diagramsize)

        Return x
    End Function

    Private Function PixelqToMathY(q As Integer) As Decimal

        Dim y As Decimal = DS.ValueParameter.Range.B - (q * DS.ValueParameter.Range.IntervalWidth / Diagramsize)

        Return y
    End Function

    Private Sub MarkCell(LeftBottomCorner As ClsMathpoint, locBrush As Brush, IsDefinitive As Boolean)
        Dim RightUpperCorner = New ClsMathpoint(LeftBottomCorner.X + DeltaX, LeftBottomCorner.Y + DeltaX)

        If IsDefinitive Then
            BmpGraphics.FillRectangle(LeftBottomCorner, RightUpperCorner, locBrush)
            MyForm.PicDiagram.Refresh()
        Else
            PicGraphics.FillRectangle(LeftBottomCorner, RightUpperCorner, locBrush)
        End If
    End Sub

    'SECTOR ITERATION

    Public Async Sub StartIteration(EndOfLoop As Integer)

        'New Iteration if IterationStatus = ClsDynamics.EnIterationStatus.Stopped
        'in all cases: NExtStep, Next10, Start
        If IterationStatus = ClsDynamics.EnIterationStatus.Stopped Then
            If IsUserDataOK() Then
                'PrepareDiagram()
                DS.ParameterA = CDec(MyForm.TxtParameter.Text)
                IterationPoint.X = CDec(MyForm.TxtX.Text)
                IterationPoint.Y = CDec(MyForm.TxtY.Text)
                IterationStatus = ClsDynamics.EnIterationStatus.Ready
            Else
                'Message already generated
            End If
        End If

        'New Experiment with new UserData if iterationstatus = ClsDynamics.EnIterationStatus.Interrupted
        'in all cases: NExtStep, Next10, Start
        If IterationStatus = ClsDynamics.EnIterationStatus.Interrupted Then
            If IsUserDataOK() Then
                IterationPoint.X = CDec(MyForm.TxtX.Text)
                IterationPoint.Y = CDec(MyForm.TxtY.Text)
                IterationStatus = ClsDynamics.EnIterationStatus.Ready
            Else
                'Message already generated
            End If
        End If

        Select Case True
            Case EndOfLoop = 1 And Mode = EnMode.Sensitivity
                'BtnNextStep was calling
                'nothing to do
            Case EndOfLoop = 1 And Mode = EnMode.Transitivity
                'BtnStart was calling
                'the Iteration is then stopped by the stop-button
                'or after 100000 steps
                EndOfLoop = 100000
            Case EndOfLoop > 1 And Mode = EnMode.Sensitivity
                'BtnNext10 was calling
                'nothing to do
            Case Else
                'BtnStop was calling
                IterationStatus = ClsDynamics.EnIterationStatus.Stopped
        End Select


        'Next steps of a running Iteration
        If IterationStatus = ClsDynamics.EnIterationStatus.Ready Then
            IterationStatus = ClsDynamics.EnIterationStatus.Running
            Await IterationLoop(EndOfLoop)
            IterationStatus = ClsDynamics.EnIterationStatus.Ready
        End If

    End Sub

    Public Async Function IterationLoop(EndOfLoop As Integer) As Task

        'Mark the startpoint
        Dim Startpoint As New ClsMathpoint(IterationPoint.X, IterationPoint.Y)
        PicGraphics.DrawPoint(Startpoint, MyBrush, 2)
        PicGraphics.DrawCircle(Startpoint, 5, MyBrush.Color, 1)

        'the next steps of the iteration are performed
        Dim i As Integer
        Do
            With IterationPoint
                Dim P As New ClsMathpoint(.X, .Y)
                Dim nextP As New ClsMathpoint(DS.FN(.X), DS.FN(.Y))

                'draw result
                PicGraphics.DrawPoint(nextP, MyBrush, 1)
                PicGraphics.DrawLine(P, nextP, MyBrush.Color, 1)
                .X = DS.FN(.X)
                .Y = DS.FN(.Y)
                i += 1

                If Mode = EnMode.Transitivity Then
                    'Is the point in the targetcell?
                    'Because of limited calculation accuracy
                    'we set 4*DeltaX as condition
                    If Math.Abs(nextP.X - (StoredCell.X + DeltaX / 2)) <= 4 * DeltaX _
                                            And Math.Abs(nextP.Y - (StoredCell.Y + DeltaX / 2)) <= 4 * DeltaX Then
                        i = EndOfLoop
                        MarkCell(nextP, Brushes.Red, False)
                    End If
                End If

            End With
            Application.DoEvents()
            Await Task.Delay(2)

        Loop Until i >= EndOfLoop Or IterationStatus = ClsDynamics.EnIterationStatus.Stopped

    End Function

    'SECTOR CHECK USERDATA

    Private Function IsUserDataOK() As Boolean

        'Checks all manual inputs of the user
        With MyForm
            'Is the value of TxtParameter in the Iteration Interval?
            Dim CheckParameter = New ClsCheckUserData(.TxtParameter, DS.DSParameter.Range)
            Dim CheckXStartvalue = New ClsCheckUserData(.TxtX, DS.ValueParameter.Range)
            Dim CheckYStartvalue = New ClsCheckUserData(.TxtY, DS.ValueParameter.Range)

            Return CheckParameter.IsTxtValueAllowed And CheckXStartvalue.IsTxtValueAllowed _
            And CheckYStartvalue.IsTxtValueAllowed
        End With

    End Function
End Class
