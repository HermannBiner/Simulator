'Interface for all kind of billard tables
'Status Checked

Public Interface IBillardtable

    'the billard table is drawn into the bitmap
    WriteOnly Property MapBillardtable As Bitmap

    'the parameter C defines the profile of the billard table
    WriteOnly Property C As Decimal

    Sub DrawBillardtable()

    Sub Clear()

End Interface
