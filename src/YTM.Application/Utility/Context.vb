Friend Module Context
    Friend Property World As IWorld
    Friend Property ItemName As String
    Friend Property ItemId As Integer
    Friend Property AttackTarget As IMapCell
    Friend ReadOnly Property Enemy As ICharacter
        Get
            Return AttackTarget?.Character
        End Get
    End Property

    Friend Sub Initialize()
    End Sub
    Friend Sub SaveToSlot(index As Integer)
        World.Save(SlotFilename(index))
    End Sub
    Friend Sub Embark()
        World = New World(New WorldData)
        WorldInitializer.Initialize(World)
        AttackTarget = Nothing
    End Sub
    Friend Sub LoadFromSlot(index As Integer)
        World = Business.World.Load(SlotFilename(index))
        AttackTarget = Nothing
    End Sub
    Friend Sub Abandon()
        AttackTarget = Nothing
        World = Nothing
    End Sub
    Function DoesSaveExist(index As Integer) As Boolean
        Return File.Exists(SlotFilename(index))
    End Function
    Private Function SlotFilename(index As Integer) As String
        Return $"slot{index}.json"
    End Function
End Module
