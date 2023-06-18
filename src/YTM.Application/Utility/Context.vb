Friend Module Context
    Friend Sub Initialize()
        Fonts.Load()
    End Sub

    Friend Sub LoadFromSlot(index As Integer)
        Throw New NotImplementedException()
    End Sub

    Function DoesSaveExist(index As Integer) As Boolean
        Return File.Exists(SlotFilename(index))
    End Function
    Private Function SlotFilename(index As Integer) As String
        Return $"slot{index}.json"
    End Function
End Module
