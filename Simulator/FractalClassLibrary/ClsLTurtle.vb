'This class represents a turtle that can be used to draw L-systems.

'Status Checked


Public Class ClsLTurtle

    'Turtle Status
    Public Enum EnWorkingStatus
        'everything is reset
        Reset
        'ready to draw the next generation
        Ready
        'drawing the next generation
        Running
        'the drawing of the next generation is interrupted
        Interrupted
        'the drawing of the next generation is finished
        Finished
    End Enum

    'Default variables
    Private MyAngleLeft As Integer
    Private MyAngleRight As Integer
    Private MyScaleFactor As Decimal
    Private MyDefaultColor As SolidBrush
    Private MyIsColorFixed As Boolean
    Private MyIsBudding As Boolean
    Private MyScaling As ClsLSystemsController.EnScaling
    Private MyStartLength As Decimal
    Private MyStartPosition As ClsMathpoint
    Private MyColors As ClsColorList

    'Current status
    Private MyTurtleStatus As ClsLTurtleState
    Private MyGeneration As Integer
    Private MyWorkingStatus As EnWorkingStatus

    'PicDiagram
    Private MyPicDiagram As PictureBox
    Private PicGraphics As ClsGraphicTool
    Private MathInterval As ClsInterval

    'Stack for the turtle
    Private MyStack As New Stack(Of ClsLTurtleState)
    Private StackState As ClsLTurtleState

    'Debug
    Private MyLstDebug As ListBox
    'number of steps drawed in the current generation
    Private i As Integer = 0

    Property LstDebug As ListBox
        Get
            Return MyLstDebug
        End Get
        Set(value As ListBox)
            MyLstDebug = value
        End Set
    End Property

    WriteOnly Property AngleLeft As Integer
        Set(value As Integer)
            MyAngleLeft = value
        End Set
    End Property

    WriteOnly Property AngleRight As Integer
        Set(value As Integer)
            MyAngleRight = value
        End Set
    End Property

    WriteOnly Property ScaleFactor As Decimal
        Set(value As Decimal)
            MyScaleFactor = value
        End Set
    End Property

    WriteOnly Property DefaultColor As SolidBrush
        Set(value As SolidBrush)
            MyDefaultColor = value
            MyTurtleStatus.Color = value
        End Set
    End Property

    Property IsColorFixed As Boolean
        Get
            IsColorFixed = MyIsColorFixed
        End Get
        Set(value As Boolean)
            MyIsColorFixed = value
        End Set
    End Property

    Property IsBudding As Boolean
        Get
            Return MyIsBudding
        End Get
        Set(value As Boolean)
            MyIsBudding = value
        End Set
    End Property

    WriteOnly Property PicDiagram As PictureBox
        Set(value As PictureBox)
            MyPicDiagram = value
            PicGraphics = New ClsGraphicTool(MyPicDiagram, MathInterval, MathInterval)
        End Set
    End Property

    WriteOnly Property StartPosition As ClsMathpoint
        Set(value As ClsMathpoint)
            MyStartPosition.X = value.X
            MyStartPosition.Y = value.Y
            MyTurtleStatus.Position.X = value.X
            MyTurtleStatus.Position.Y = value.Y
        End Set
    End Property

    WriteOnly Property CurrentPosition As ClsMathpoint
        Set(value As ClsMathpoint)
            MyTurtleStatus.Position.X = value.X
            MyTurtleStatus.Position.Y = value.Y
        End Set
    End Property

    WriteOnly Property CurrentAngle As Integer
        Set(value As Integer)
            MyTurtleStatus.Angle = value
        End Set
    End Property

    Property Generation As Integer
        Get
            Return MyGeneration
        End Get
        Set(value As Integer)
            MyGeneration = value
        End Set
    End Property

    WriteOnly Property Scaling As ClsLSystemsController.EnScaling
        Set(value As ClsLSystemsController.EnScaling)
            MyScaling = value
        End Set
    End Property

    WriteOnly Property StartLength As Decimal
        Set(value As Decimal)
            MyStartLength = value
            MyTurtleStatus.StepLength = value
        End Set
    End Property

    Property WorkingStatus As EnWorkingStatus
        Get
            Return MyWorkingStatus
        End Get
        Set(value As EnWorkingStatus)
            MyWorkingStatus = value
        End Set
    End Property

    Public Sub New()
        MathInterval = New ClsInterval(0, 13)
        MyTurtleStatus = New ClsLTurtleState
        MyColors = New ClsColorList
        MyStartPosition = New ClsMathpoint
        MyTurtleStatus.Position = New ClsMathpoint
    End Sub

    Public Sub SaveTurtleStatus()

        StackState = New ClsLTurtleState
        With StackState
            .Position.X = MyTurtleStatus.Position.X
            .Position.Y = MyTurtleStatus.Position.Y
            .Angle = MyTurtleStatus.Angle
            .Color = MyTurtleStatus.Color
            .StepLength = MyTurtleStatus.StepLength
        End With
        MyStack.Push(StackState)
    End Sub

    Public Sub RestoreTurtleStatus()
        If MyStack.Count > 0 Then
            StackState = MyStack.Pop()
            MyTurtleStatus.Position.X = StackState.Position.X
            MyTurtleStatus.Position.Y = StackState.Position.Y
            MyTurtleStatus.Angle = StackState.Angle
            MyTurtleStatus.Color = StackState.Color
            MyTurtleStatus.StepLength = StackState.StepLength
        End If
    End Sub

    Public Sub ClearAll()
        MyPicDiagram.Refresh()
        MyLstDebug.Items.Clear()
    End Sub

    Public Sub Reset()
        'No Iteration running
        MyWorkingStatus = EnWorkingStatus.Reset
        i = 0
        MyGeneration = 0
    End Sub

    Public Async Function DrawNextGeneration(Itinerary As String) As Task

        'One Iterationstep implies the interpretation of the whole itinerary
        'The turtle is moved according to the itinerary
        If MyWorkingStatus = EnWorkingStatus.Ready Or
            MyWorkingStatus = EnWorkingStatus.Interrupted Then

            'Perform Itinerary
            MyWorkingStatus = EnWorkingStatus.Running

            'if the workingstatus is ready, the turtle didn't begin to draw
            'and i = 0
            'if the workingstatus is interrupted
            'the turtle has already drawn some parts of the itinerary
            'and i shows the actual position in the itinerary

            While i < Itinerary.Length

                Dim ch As Char = Itinerary(i)

                'Check for color change
                If Not MyIsColorFixed Then
                    If ch = "("c Then
                        'set color
                        i += 1
                        Dim numStr As String = ""
                        While i < Itinerary.Length AndAlso Char.IsDigit(Itinerary(i))
                            numStr &= Itinerary(i)
                            i += 1
                        End While
                        If numStr.Length = 0 Then
                            'Fehler
                            Throw New Exception("InvalidColorDefinition")
                        End If
                        MyTurtleStatus.Color = MyColors.GetColor(CInt(numStr))
                        ch = Itinerary(i)
                        If ch <> ")"c Then
                            'Fehler
                            Throw New Exception("MissingBracketInColorDefinition")
                        End If
                        i += 1
                        ch = Itinerary(i)
                    End If
                End If
                Select Case ch
                    Case "+"c : MyTurtleStatus.Angle += MyAngleLeft
                    Case "-"c : MyTurtleStatus.Angle -= MyAngleRight
                    Case "F"c : Move(True)
                    Case "G"c : Move(True)
                    Case "f"c : Move(False)
                    Case "g"c : Move(False)
                    Case "["c : SaveTurtleStatus()
                        If MyScaling = ClsLSystemsController.EnScaling.ByBranch Then
                            MyTurtleStatus.StepLength *= MyScaleFactor
                        End If
                    Case "]"c
                        If MyIsBudding Then
                            PicGraphics.DrawPoint(MyTurtleStatus.Position, MyTurtleStatus.Color, 3)
                        End If
                        RestoreTurtleStatus()
                End Select

                i += 1
                If i Mod 5000 = 0 Then
                    Await Task.Delay(1)
                End If

                'If a StopRequest was made, exit the loop
                If MyWorkingStatus = EnWorkingStatus.Interrupted Then
                    Exit While
                End If

            End While

            'Finishing the generation
            'Adjust Parameters after the actual generation is drawed
            If MyWorkingStatus = EnWorkingStatus.Running Then
                'not interrupted, therefore the iteration is finished

                'the actual generation is drawed, therefore ready for the next
                MyWorkingStatus = EnWorkingStatus.Finished
                i = 0
            End If
        End If

    End Function

    Public Sub Scale()
        If MyWorkingStatus <> EnWorkingStatus.Interrupted Then
            If MyScaling = ClsLSystemsController.EnScaling.ByIteration Then
                MyTurtleStatus.StepLength *= MyScaleFactor
            Else
                MyScaling = ClsLSystemsController.EnScaling.ByBranch
                MyTurtleStatus.StepLength = MyStartLength
            End If
        End If

    End Sub

    Private Sub Move(Drawing As Boolean)
        'Move the turtle and draw a line
        Dim NewPos As New ClsMathpoint
        NewPos.X = MyTurtleStatus.Position.X
        NewPos.Y = MyTurtleStatus.Position.Y

        NewPos.X += CDec(MyTurtleStatus.StepLength * Math.Cos(CDec(MyTurtleStatus.Angle * Math.PI / 180)))
        NewPos.Y += CDec(MyTurtleStatus.StepLength * Math.Sin(CDec(MyTurtleStatus.Angle * Math.PI / 180)))

        MyLstDebug.Items.Add("C: " & MyTurtleStatus.Position.X.ToString("N2") &
                             "/" & MyTurtleStatus.Position.Y.ToString("N2") &
                             "-> N: " & NewPos.X.ToString("N2") & "/" & NewPos.Y.ToString("N2"))

        'Draw the line
        Dim Wide As Integer
        If MyScaling = ClsLSystemsController.EnScaling.ByIteration Then
            Wide = 1
        Else
            Wide = CInt(1 + MyTurtleStatus.StepLength / 2)
        End If

        If Drawing Then
            PicGraphics.DrawLine(MyTurtleStatus.Position, NewPos, MyTurtleStatus.Color, Wide)
        End If
        'Update the position of the turtle
        MyTurtleStatus.Position.X = NewPos.X
        MyTurtleStatus.Position.Y = NewPos.Y
    End Sub

End Class
