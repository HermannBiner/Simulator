'This class contains the controller for the FrmNewtonIteration

Public Class ClsNewtonIterationController

    'The PicDiagram and Bitmasp
    Private MyPicDiagram As PictureBox
    Private MyN As Integer

    WriteOnly Property PicDiagram As PictureBox
        Set(value As PictureBox)
            MyPicDiagram = value
        End Set
    End Property

    WriteOnly Property N As Integer
        Set(value As Integer)
            MyN = value
        End Set
    End Property

    Public Sub ShowBasin()
        'Shows the approximated basin(1)
        'that is an area where |Np'(z)|<1


        Dim XInterval = New ClsInterval(CDec(0), CDec(2))
        Dim YInterval = New ClsInterval(CDec(-1), CDec(1))
        Dim MyGraphics = New ClsGraphicTool(MyPicDiagram, XInterval, YInterval)

        Const StepWide As Double = 0.001

        MyGraphics.Clear(Color.White)

        'Draws the coordinate system and the circles
        MyGraphics.DrawLine(New ClsMathpoint(XInterval.A, 0), New ClsMathpoint(XInterval.B, 0),
            Color.Black, 1)
        MyGraphics.DrawLine(New ClsMathpoint(0, YInterval.A), New ClsMathpoint(0, YInterval.B),
                        Color.Black, 1)
        MyGraphics.DrawCircle(New ClsMathpoint(1, 0), 1, Color.Blue, 1)
        MyGraphics.DrawCircle(New ClsMathpoint(1, 0), CDec(1 - 1 / Math.Pow(2, 1 / MyN)),
                                  Color.Green, 1)
        MyGraphics.DrawPoint(New ClsMathpoint(1, 0), Brushes.Black, 2)

        Dim Asymptote As New ClsMathpoint(CDec(2 * Math.Cos(Math.PI / (2 * MyN))), CDec(2 * Math.Sin(Math.PI / (2 * MyN))))
        MyGraphics.DrawLine(New ClsMathpoint(0, 0), Asymptote, Color.Green, 1)
        Asymptote.Y = -Asymptote.Y
        MyGraphics.DrawLine(New ClsMathpoint(0, 0), Asymptote, Color.Green, 1)


        Dim Phi As Double = 0
        Dim R As Double
        Dim Limit As Double = Math.Sqrt(Math.Pow(XInterval.B, 2) + Math.Pow(YInterval.B, 2))

        'Draws the real and approximated curve of |Np'(z)|<1

        Do
            R = GetR(Phi)

            If R < Limit Then
                MyGraphics.DrawPoint(New ClsMathpoint(CDec(R * Math.Cos(Phi)), CDec(R * Math.Sin(Phi))), Brushes.Red, 1)
                MyGraphics.DrawPoint(New ClsMathpoint(CDec(R * Math.Cos(Phi)), CDec(-R * Math.Sin(Phi))), Brushes.Red, 1)
            End If

            R = GetRApprox(Phi)

            If R < Limit Then
                MyGraphics.DrawPoint(New ClsMathpoint(CDec(R * Math.Cos(Phi)), CDec(R * Math.Sin(Phi))), Brushes.Red, 1)
                MyGraphics.DrawPoint(New ClsMathpoint(CDec(R * Math.Cos(Phi)), CDec(-R * Math.Sin(Phi))), Brushes.Red, 1)
            End If

            'This is the result of experiments:
            Phi += StepWide / (2 * R)

        Loop Until (R > Limit) Or (Phi > Math.PI / (2 * MyN))

    End Sub

    Private Function GetR(phi As Double) As Double

        Dim rTemp As Double

        'Prepare Root
        rTemp = Math.Pow(Math.Cos(MyN * phi) * (MyN - 1) / (2 * MyN - 1), 2) + 1 / (2 * MyN - 1)

        'Root
        rTemp = (MyN - 1) * Math.Sqrt(rTemp)

        'Add
        rTemp += -Math.Cos(MyN * phi) * (MyN - 1) * (MyN - 1) / (2 * MyN - 1)

        'n-th root
        rTemp = Math.Pow(rTemp, 1 / MyN)

        Return rTemp

    End Function

    Private Function GetRApprox(phi As Double) As Double

        Dim rTemp As Double

        rTemp = 1 / Math.Pow(2 * Math.Cos(MyN * phi), 1 / MyN)

        Return rTemp
    End Function

End Class
