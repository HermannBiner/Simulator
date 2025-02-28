'This is the abstract class for all kind of polynom roots
'containing the common logic for all these classes
'all polynom classes inherit from this class
'including the UnitRootN classes

'Status Checked

Public MustInherit Class ClsNewtonAbstract
    Implements INewton

    Protected ReadOnly LM As ClsLanguageManager

    'the radius where Zi is regarded as belonging to a root
    Protected MyRadius As Double

    'How many steps should be iterated?
    Protected IterationDeepness As Integer

    'Drawing PicCPlane
    Protected MyPicDiagram As PictureBox
    Protected PicGraphics As ClsGraphicTool

    'Drawing permanently into the C-Plane
    Protected BmpDiagram As Bitmap
    Protected BmpGraphics As ClsGraphicTool

    'ValueParameter Definition for the x-Values
    Protected MyXValueParameter As ClsGeneralParameter

    'ValueParameter Definition  for the y-Values
    Protected MyYValueParameter As ClsGeneralParameter

    'the actual range for the x-coordinate
    Protected MyActualXRange As ClsInterval

    'the actual range for the y-coordinate
    Protected MyActualYRange As ClsInterval

    'Protocol
    Protected MyProtocolList As ListBox
    Protected MyIsProtocol As Boolean

    'N (number of roots)
    Protected Property MyIsUseN As Boolean
    Protected Property MyN As Integer

    'Parameter C
    Protected Property MyIsUseC As Boolean
    Protected Property MyC As ClsComplexNumber

    'Mixing
    Protected Property MyMixing As INewton.EnMixing

    'Color
    Protected Property MyColor As INewton.EnColor

    'List of roots of the polynom
    Protected UnitRootCollection As Collection

    Public Sub New()

        LM = ClsLanguageManager.LM

        MyXValueParameter = New ClsGeneralParameter(1, "x-Values", New ClsInterval(CDec(-1.5), CDec(1.5)), ClsGeneralParameter.TypeOfParameterEnum.Variable)
        MyYValueParameter = New ClsGeneralParameter(1, "y-Values", New ClsInterval(CDec(-1.5), CDec(1.5)), ClsGeneralParameter.TypeOfParameterEnum.Variable)

        MyActualXRange = MyXValueParameter.Range
        MyActualYRange = MyYValueParameter.Range

        UnitRootCollection = New Collection

    End Sub

    'SECTOR INTERFACE

    WriteOnly Property PicDiagram As PictureBox Implements INewton.PicDiagram
        Set(value As PictureBox)
            MyPicDiagram = value
            'Generate objects
            'The PictureBox should be a square
            Dim Square As Integer = Math.Min(MyPicDiagram.Height, MyPicDiagram.Width)

            MyPicDiagram.Height = Square
            MyPicDiagram.Width = Square

            BmpDiagram = New Bitmap(Square, Square)
            MyPicDiagram.Image = BmpDiagram

            PicGraphics = New ClsGraphicTool(MyPicDiagram, MyActualXRange, MyActualYRange)
            BmpGraphics = New ClsGraphicTool(BmpDiagram, MyActualXRange, MyActualYRange)
        End Set
    End Property

    ReadOnly Property XValueParameter As ClsGeneralParameter Implements INewton.XValueParameter
        Get
            XValueParameter = MyXValueParameter
        End Get
    End Property

    ReadOnly Property YValueParameter As ClsGeneralParameter Implements INewton.YValueParameter
        Get
            YValueParameter = MyYValueParameter
        End Get
    End Property

    Property ActualXRange As ClsInterval Implements INewton.ActualXRange
        Get
            ActualXRange = MyActualXRange
        End Get
        Set(value As ClsInterval)
            MyActualXRange = value
            PicGraphics.MathXInterval = value
            BmpGraphics.MathXInterval = value
        End Set
    End Property

    Property ActualYRange As ClsInterval Implements INewton.ActualYRange
        Get
            ActualYRange = MyActualYRange
        End Get
        Set(value As ClsInterval)
            MyActualYRange = value
            PicGraphics.MathYInterval = value
            BmpGraphics.MathYInterval = value
        End Set
    End Property

    WriteOnly Property ProcotolList As ListBox Implements INewton.ProcotolList
        Set(value As ListBox)
            MyProtocolList = value
        End Set
    End Property

    WriteOnly Property IsProtocol As Boolean Implements INewton.IsProtocol
        Set(value As Boolean)
            MyIsProtocol = value
        End Set
    End Property

    ReadOnly Property IsUseN As Boolean Implements INewton.IsUseN
        Get
            IsUseN = MyIsUseN
        End Get
    End Property

    Property N As Integer Implements INewton.N
        Get
            N = MyN
        End Get
        Set(value As Integer)
            MyN = value
            MyRadius = Math.Min(0.1, 1 - Math.Pow(2, -1 / MyN))
        End Set
    End Property

    ReadOnly Property IsUseC As Boolean Implements INewton.IsUseC
        Get
            IsUseC = MyIsUseC
        End Get
    End Property

    WriteOnly Property C As ClsComplexNumber Implements INewton.C
        Set(value As ClsComplexNumber)
            MyC = value
        End Set
    End Property

    WriteOnly Property UseMixing As INewton.EnMixing Implements INewton.UseMixing
        Set(value As INewton.EnMixing)
            MyMixing = value
        End Set
    End Property

    WriteOnly Property UseColor As INewton.EnColor Implements INewton.UseColor
        Set(value As INewton.EnColor)
            MyColor = value
        End Set
    End Property

    Public Sub DrawCoordinateSystem() Implements INewton.DrawCoordinateSystem

        If ActualXRange.IsNumberInInterval(0) Then

            'Draw y-axis
            BmpGraphics.DrawLine(New ClsMathpoint(0, ActualYRange.A),
                                             New ClsMathpoint(0, ActualYRange.B), Color.Black, 1)
        End If

        If ActualYRange.IsNumberInInterval(0) Then

            'Draw x-axis
            BmpGraphics.DrawLine(New ClsMathpoint(ActualXRange.A, 0),
                                         New ClsMathpoint(ActualXRange.B, 0), Color.Black, 1)
        End If

        MyPicDiagram.Refresh()

    End Sub

    Public Sub ResetIteration() Implements INewton.ResetIteration

        PrepareUnitRoots()

        'Clear MapCPlane
        If BmpGraphics IsNot Nothing Then
            BmpGraphics.Clear(Color.White)
            DrawCoordinateSystem()
            DrawRoots(False)
        End If
        MyPicDiagram.Refresh()

        'Clear Protocol
        If MyProtocolList IsNot Nothing Then
            MyProtocolList.Items.Clear()
        End If

    End Sub


    'Draws roots of the polynom
    Public Sub DrawRoots(Finished As Boolean) Implements INewton.DrawRoots

        'Roots
        Dim Col As Brush

        'Finished = PicCPlane is generated

        For Each MyRoot As ClsUnitRoot In UnitRootCollection
            If Finished Then
                Col = Brushes.Black
            Else
                Col = MyRoot.GetColor(1)
            End If
            BmpGraphics.DrawPoint(New ClsMathpoint(CDec(MyRoot.X), CDec(MyRoot.Y)), Col, 3)
        Next

        MyPicDiagram.Refresh()

    End Sub

    Private Function GetBasin(Z As ClsComplexNumber, Steps As Integer) As Brush

        'If the stop condition is fullfilled, then the startpoint converges to a root
        'and we have to find out, which root that is
        'and get the appropriate color

        Dim Temp As Double = 1000
        Dim Difference As Double
        Dim RootBrush As Brush = Brushes.Black

        Dim FinalBrightness As Double

        If MyColor = INewton.EnColor.Bright Then
            FinalBrightness = 1
        Else

            Dim MyColorDeepness As Integer
            'The next value is set after experiments:
            'MyN = 3 and MyColorDeepness = 30
            'MyN = 4 and ColorDeepness = 50
            'MyN = 5 and ColorDeepness = 80
            'MyN = 6 and ColorDeepness = 120
            '...
            'The Formula that delivers these values is
            'y = 5*x^2 - 15 x + 30

            If MyN = 2 Then
                MyColorDeepness = 30
            Else
                MyColorDeepness = 5 * MyN * MyN - 15 * MyN + 30
            End If

            FinalBrightness = (1 - Steps / MyColorDeepness) * 1.1

            'but the maximum is 1
            FinalBrightness = Math.Min(FinalBrightness, 1)
        End If

        For Each Root As ClsUnitRoot In UnitRootCollection
            Difference = Z.Add(Root.Stretch(-1)).AbsoluteValue
            If Difference < Temp Then
                Temp = Difference
                RootBrush = Root.GetColor(FinalBrightness)
            End If
        Next

        Return RootBrush

    End Function

    Public Sub IterationStep(Startpoint As Point) Implements INewton.IterationStep

        'Transform the PixelPoint to a Complex Number
        Dim MathStartpoint As ClsComplexNumber

        With BmpGraphics.PixelToMathpoint(Startpoint)
            'Saved for debugging
            MathStartpoint = New ClsComplexNumber(.X, .Y)
        End With

        Dim Zi As New ClsComplexNumber(MathStartpoint.X, MathStartpoint.Y)

        Dim MyBrush As Brush = Brushes.White

        If Zi.AbsoluteValue > 0 Then

            'Protocol of the startpoint as Pixel and as Mathpoint
            'MyProtocol.Items.Add(Startpoint.X.ToString & ", " & Startpoint.Y.ToString & ", " &
            'Zi.X.ToString("N5") & ", " & Zi.Y.ToString("N5"))

            Dim i As Integer = 1


            Do While i <= IterationDeepness And Not StopCondition(Zi)

                i += 1

                'Calculate Next Z
                Zi = Newton(Zi)

            Loop

            If (i > IterationDeepness) Or (Denominator(Zi).AbsoluteValue = 0) Then

                'the point doesn't converge to a root
                MyBrush = Brushes.Black
            Else
                'the basin defines the type of color
                'and i influences its brightness
                MyBrush = GetBasin(Zi, i)
            End If
        Else

            MyBrush = Brushes.Black
        End If

        BmpGraphics.DrawPoint(Startpoint, MyBrush, 1)

        'Protocol of the PixelStartpoint and the Endpoint as Mathpoint
        If MyIsProtocol Then
            MyProtocolList.Items.Add(MathStartpoint.X.ToString("N5") & ", " &
                                     MathStartpoint.Y.ToString("N5") &
                ", " & Zi.X.ToString("N5") & ", " & Zi.Y.ToString("N5"))
        End If
    End Sub

    MustOverride ReadOnly Property IsShowBasin As Boolean Implements INewton.IsShowBasin

    Public MustOverride Function StopCondition(Z As ClsComplexNumber) As Boolean

    Public MustOverride Function Newton(Z As ClsComplexNumber) As ClsComplexNumber

    Protected MustOverride Sub PrepareUnitRoots() Implements INewton.PrepareUnitRoots

    Public MustOverride Function Denominator(Z As ClsComplexNumber) As ClsComplexNumber

End Class


