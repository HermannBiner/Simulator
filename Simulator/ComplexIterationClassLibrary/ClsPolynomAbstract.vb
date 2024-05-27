'This is the abstract class for all kind of polynom roots
'containing the common logic for all these classes
'all polynom classes inherit from this class
'including the UnitRootN classes

'Status Checked

Public MustInherit Class ClsPolynomAbstract
    Implements IPolynom

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

    Protected MyDeepness As Integer

    'Protocol
    Protected MyProtocolList As ListBox
    Protected MyIsProtocol As Boolean

    'N (number of roots)
    Protected Property MyUseN As Boolean
    Protected Property MyN As Integer

    'Parameter C
    Protected Property MyUseC As Boolean
    Protected Property MyC As ClsComplexNumber

    'Conjugate Z
    Protected Property MyConjugateZ As Boolean

    'List of roots of the polynom
    Protected Root() As ClsRoot

    'SECTOR INTERFACE

    MustOverride WriteOnly Property Deepness As Integer Implements IPolynom.Deepness

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

    WriteOnly Property ConjugateZ As Boolean Implements IPolynom.ConjugateZ
        Set(value As Boolean)
            MyConjugateZ = value
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


            Do While i <= MyDeepness And Not StopCondition(Zi)

                i += 1

                'Calculate Next Z
                Zi = Newton(Zi)

            Loop

            If (i > MyDeepness) Or (Denominator(Zi).AbsoluteValue = 0) Then

                'the point doesn't converge to a root
                MyBrush = Brushes.Black
            Else

                MyBrush = GetBasin(Zi)
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

    Protected MustOverride Sub DrawRoots(Finished As Boolean) Implements IPolynom.DrawRoots

    Public MustOverride Function StopCondition(Z As ClsComplexNumber) As Boolean

    Protected MustOverride Function GetBasin(Z As ClsComplexNumber) As Brush

    Public MustOverride Function Newton(Z As ClsComplexNumber) As ClsComplexNumber

    Protected MustOverride Sub PrepareIteration() Implements IPolynom.PrepareIteration

    Public MustOverride Function Denominator(Z As ClsComplexNumber) As ClsComplexNumber

End Class


