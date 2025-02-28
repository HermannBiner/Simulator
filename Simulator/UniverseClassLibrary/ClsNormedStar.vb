'this is a concrete star moving in the normed universe

'Status Checked

Public Class ClsNormedStar
    Inherits ClsNewtonStar

    Protected Overrides ReadOnly Property GravConst As Decimal
        Get
            Return CDec(1 * Tau * Tau)
        End Get
    End Property

    Public Overrides ReadOnly Property Tau As Decimal
        Get
            Return CDec(0.05)
        End Get
    End Property

End Class

