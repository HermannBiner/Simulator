'this is a concrete star moving in the normed universe

'Status Checked

Public Class ClsNormedStar
    Inherits ClsNewtonStar

    Protected Overrides ReadOnly Property GravConst As Double
        Get
            Return CDbl(1 * Tau * Tau)
        End Get
    End Property

    Public Overrides ReadOnly Property Tau As Double
        Get
            Return CDbl(0.05)
        End Get
    End Property

End Class

