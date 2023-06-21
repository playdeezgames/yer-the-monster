Friend Module InitializerUtility
    Friend Function CreateItem(world As IWorld, itemType As String) As IItem
        Dim descriptor = ItemTypes.Descriptors(itemType)
        Dim item = world.CreateItem(ItemTypes.Nihil, descriptor.ItemName)
        Return item
    End Function
    Friend Function CreateLocation(world As IWorld, locationType As String, name As String) As ILocation
        Return world.CreateLocation(locationType, name)
    End Function
    Friend Function CreateCharacter(location As ILocation, mapCell As IMapCell, characterType As String, name As String) As ICharacter
        Dim descriptor = characterType.ToCharacterTypeDescriptor()
        Return location.World.CreateCharacter(characterType, name, location, mapCell, descriptor.Statistics)
    End Function
End Module
