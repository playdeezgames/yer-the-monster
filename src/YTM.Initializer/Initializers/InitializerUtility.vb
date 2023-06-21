Friend Module InitializerUtility
    Friend Function CreateItem(world As IWorld, itemType As String) As IItem
        Dim descriptor = ItemTypes.Descriptors(itemType)
        Dim item = world.CreateItem(ItemTypes.Nihil, descriptor.ItemName)
        Return item
    End Function
    Friend Function CreateCharacter(mapCell As IMapCell, characterType As String, name As String) As ICharacter
        Dim descriptor = characterType.ToCharacterTypeDescriptor()
        Return mapCell.Map.World.CreateCharacter(characterType, name, mapCell, descriptor.Statistics)
    End Function
End Module
