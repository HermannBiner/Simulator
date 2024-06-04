'This is the abstract class for all kind of polynom roots
'containing the common logic for all these classes
'all polynom classes inherit from this class
'including the UnitRootN classes

'Status Checked

Public MustInherit Class ClsPolynomAbstract
    Implements IPolynom

    'the radius where Zi is regarded as belonging to a root
    Protected Const MyRadius As Double = 0.1

    'How many steps should be iterated?
    Protected MyIterationDeepness As Integer

    'Drawing MapCPlane
    Protected MyMapCPlane As Bitmap
    Protected MyMapCPlaneGraphics As ClsGraphicTool

    'Allowed Interval for the x-Values
    Protected MyAllowedXRange As ClsInterval

    'Allowed Interval for the y-Values
    Protected MyAllowedYRange As ClsInterval

    'the actual range for the x-coordinate
    Protected MyActualXRange As ClsInterval

    'the actual range for the y-coordinate
    Protected MyActualYRange As ClsInterval

    'Protocol
    Protected MyProtocolList As ListBox
    Protected MyIsProtocol As Boolean

    'N (number of roots)
    Protected Property MyUseN As Boolean
    Protected Property MyN As Integer

    'Parameter C
    Protected Property MyUseC As Boolean
    Protected Property MyC As ClsComplexNumber

    'Mixing
    Protected Property MyMixing As IPolynom.EnMixing

    'Color
    Protected Property MyColor As IPolynom.EnColor

    'List of roots of the polynom
    Protected Roots As Collection

    'How many levels of colors
    Private MyColorDeepness As Integer

    Public Sub New()
        Roots = New Collection
    End Sub

    'SECTOR INTERFACE

    WriteOnly Property MapCPlane As Bitmap Implements IPolynom.MapCPlane
        Set(value As Bitmap)
            MyMapCPlane = value
            MyMapCPlaneGraphics = New ClsGraphicTool(MyMapCPlane, MyActualXRange, MyActualYRange)
        End Set
    End Property

    ReadOnly Property AllowedXRange As ClsInterval Implements IPolynom.AllowedXRange
        Get
            AllowedXRange = MyAllowedXRange
        End Get
    End Property

    ReadOnly Property AllowedYRange As ClsInterval Implements IPolynom.AllowedYRange
        Get
            AllowedYRange = MyAllowedYRange
        End Get
    End Property

    Property ActualXRange As ClsInterval Implements IPolynom.ActualXRange
        Get
            ActualXRange = MyActualXRange
        End Get
        Set(value As ClsInterval)
            MyActualXRange = value
        End Set
    End Property

    Property ActualYRange As ClsInterval Implements IPolynom.ActualYRange
        Get
            ActualYRange = MyActualYRange
        End Get
        Set(value As ClsInterval)
            MyActualYRange = value
        End Set
    End Property

    WriteOnly Property ProcotolList As ListBox Implements IPolynom.ProcotolList
        Set(value As ListBox)
            MyProtocolList = value
        End Set
    End Property

    WriteOnly Property IsProtocol As Boolean Implements IPolynom.IsProtocol
        Set(value As Boolean)
            MyIsProtocol = value
        End Set
    End Property

    ReadOnly Property UseN As Boolean Implements IPolynom.UseN
        Get
            UseN = MyUseN
        End Get
    End Property

    WriteOnly Property N As Integer Implements IPolynom.N
        Set(value As Integer)
            MyN = value
        End Set
    End Property

    ReadOnly Property UseC As Boolean Implements IPolynom.UseC
        Get
            UseC = MyUseC
        End Get
    End Property

    WriteOnly Property C As ClsComplexNumber Implements IPolynom.C
        Set(value As ClsComplexNumber)
            MyC = value
        End Set
    End Property

    WriteOnly Property UseMixing As IPolynom.EnMixing Implements IPolynom.UseMixing
        Set(value As IPolynom.EnMixing)
            MyMixing = value
        End Set
    End Property

    WriteOnly Property UseColor As IPolynom.EnColor Implements IPolynom.UseColor
        Set(value As IPolynom.EnColor)
            MyColor = value
        End Set
    End Property

    Public Sub DrawCoordinateSystem() Implements IPolynom.DrawCoordinateSystem

        If ActualXRange.IsNumberInInterval(0) Then

            'Draw y-axis
            MyMapCPlaneGraphics.DrawLine(New ClsMathpoint(0, ActualYRange.A),
                                             New ClsMathpoint(0, ActualYRange.B), Color.Black, 1)
        End If

        If ActualYRange.IsNumberInInterval(0) Then

            'Draw x-axis
            MyMapCPlaneGraphics.DrawLine(New ClsMathpoint(ActualXRange.A, 0),
                                         New ClsMathpoint(ActualXRange.B, 0), Color.Black, 1)
        End If

    End Sub

    Public Sub Iteration(Startpoint As Point) Implements IPolynom.Iteration

        'Transform the PixelPoint to a Complex Number
        Dim MathStartpoint As ClsComplexNumber

        With MyMapCPlaneGraphics.PixelToMathpoint(Startpoint)
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


            Do While i <= MyIterationDeepness And Not StopCondition(Zi)

                i += 1

                'Calculate Next Z
                Zi = Newton(Zi)

            Loop

            If (i > MyIterationDeepness) Or (Denominator(Zi).AbsoluteValue = 0) Then

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

        MyMapCPlaneGraphics.DrawPoint(Startpoint, MyBrush, 1)

        'Protocol of the PixelStartpoint and the Endpoint as Mathpoint
        If MyIsProtocol Then
            MyProtocolList.Items.Add(MathStartpoint.X.ToString("N5") & ", " & MathStartpoint.Y.ToString("N5") &
                ", " & Zi.X.ToString("N5") & ", " & Zi.Y.ToString("N5") & ", " &
                CType(MyBrush, SolidBrush).Color.ToString)
        End If
    End Sub

    Public Sub Reset() Implements IPolynom.Reset

        'Clear MapCPlane
        If MyMapCPlaneGraphics IsNot Nothing Then
            MyMapCPlaneGraphics.Clear(Color.White)
            DrawCoordinateSystem()
            DrawRoots(False)
        End If

        'Clear Protocol
        If MyProtocolList IsNot Nothing Then
            MyProtocolList.Items.Clear()
        End If
    End Sub


    'Draws roots of the polynom
    Public Sub DrawRoots(Finished As Boolean) Implements IPolynom.DrawRoots

        'The next value is set after experiments
        If MyN = 2 Then
            MyColorDeepness = 30
        Else
            MyColorDeepness = MyN * 100 - 270
        End If

        'Roots
        Dim Col As Brush

        'Finished = PicCPlane is generated
        If Finished Then
            Col = Brushes.Black

        Else
            For Each MyRoot As ClsRoot In Roots
                Col = MyRoot.GetColor(0)
                MyMapCPlaneGraphics.DrawPoint(New ClsMathpoint(CDec(MyRoot.X), CDec(MyRoot.Y)), Col, 3)
            Next
        End If

    End Sub

    Private Function GetBasin(Z As ClsComplexNumber, Steps As Integer) As Brush

        'If the stop condition is fullfilled, then the startpoint converges to a root
        'and we have to find out, which root that is
        'and get the appropriate color

        Dim Temp As Double = 1000
        Dim Difference As Double
        Dim RootBrush As Brush = Brushes.Black

        Dim FinalBrightness As Double

        If MyColor = IPolynom.EnColor.Bright Then
            FinalBrightness = 1
        Else

            FinalBrightness = (1 - Steps / MyColorDeepness) * 1.1

            'but the maximum is 1
            FinalBrightness = Math.Min(FinalBrightness, 1)
        End If


        For Each Root As ClsRoot In Roots
            Difference = Z.Add(Root.Stretch(-1)).AbsoluteValue
            If Difference < Temp Then
                Temp = Difference
                RootBrush = Root.GetColor(FinalBrightness)
            End If
        Next

        Return RootBrush

    End Function

    Public MustOverride Function StopCondition(Z As ClsComplexNumber) As Boolean

    Public MustOverride Function Newton(Z As ClsComplexNumber) As ClsComplexNumber

    Protected MustOverride Sub PrepareIteration() Implements IPolynom.PrepareIteration

    Public MustOverride Function Denominator(Z As ClsComplexNumber) As ClsComplexNumber

End Class


