'Interface for all tapes of billiard tables
'Status Checked

Public Interface IBilliardtable

    'the billiard table is drawn into the bitmap
    WriteOnly Property MapBilliardtable As Bitmap

    'the parameter C defines the profile of the billiard table
    WriteOnly Property C As Decimal

    Sub DrawBilliardtable()

    Sub Clear()

End Interface
