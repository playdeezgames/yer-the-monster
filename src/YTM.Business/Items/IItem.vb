﻿Public Interface IItem
    ReadOnly Property Id As Integer
    Property Name As String
    ReadOnly Property ItemType As String
    Sub Recycle()
End Interface
