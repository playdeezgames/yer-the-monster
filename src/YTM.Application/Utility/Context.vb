Friend Module Context
    Friend Property World As IWorld
    Friend Sub Initialize()
        Fonts.Load()
    End Sub
    Friend Sub SaveToSlot(index As Integer)
        World.Save(SlotFilename(index))
    End Sub
    Friend Sub Embark()
        World = New World(New WorldData)
        WorldInitializer.Initialize(World)
    End Sub
    Friend Sub LoadFromSlot(index As Integer)
        World = Business.World.Load(SlotFilename(index))
    End Sub
    Friend Sub Abandon()
        World = Nothing
    End Sub
    Function DoesSaveExist(index As Integer) As Boolean
        Return File.Exists(SlotFilename(index))
    End Function
    Private Function SlotFilename(index As Integer) As String
        Return $"slot{index}.json"
    End Function
End Module
