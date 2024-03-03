'This class represents just a spring
'the goal is, that the spring can draw itself into a picturebox
'if the initial point and the end point is given
'for the drawing the Graphictool is set as parameter

Public Class ClsSpring

    Private MyGraphics As ClsGraphicTool
    Private MyStartPoint As ClsMathpoint
    Private MyEndPoint As ClsMathpoint

    WriteOnly Property Graphics As ClsGraphicTool
        Set(value As ClsGraphicTool)
            MyGraphics = value
        End Set
    End Property

    Public Sub New(StartPoint As ClsMathpoint, EndPoint As ClsMathpoint)

        MyStartPoint = StartPoint
        MyEndPoint = EndPoint

    End Sub

    Public Sub DrawMe()

        'implemented later
        MyGraphics.DrawLine(MyStartPoint, MyEndPoint, Color.Green, 1)

    End Sub


End Class
