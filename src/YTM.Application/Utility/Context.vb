Friend Module Context
    Friend Property World As IWorld
    Friend Property ItemName As String
    Friend Property ItemId As Integer
    Friend Property Enemy As ICharacter

    Friend Sub Initialize()
        Fonts.Load()
    End Sub
    Friend Sub SaveToSlot(index As Integer)
        World.Save(SlotFilename(index))
    End Sub
    Friend Sub Embark()
        World = New World(New WorldData)
        WorldInitializer.Initialize(World)
        Enemy = Nothing
    End Sub
    Friend Sub LoadFromSlot(index As Integer)
        World = Business.World.Load(SlotFilename(index))
        Enemy = Nothing
    End Sub
    Friend Sub Abandon()
        Enemy = Nothing
        World = Nothing
    End Sub
    Function DoesSaveExist(index As Integer) As Boolean
        Return File.Exists(SlotFilename(index))
    End Function
    Private Function SlotFilename(index As Integer) As String
        Return $"slot{index}.json"
    End Function
    Function UIFont() As Font
        Return Fonts.GetFont(GameFont.Font5x7)
    End Function
End Module
