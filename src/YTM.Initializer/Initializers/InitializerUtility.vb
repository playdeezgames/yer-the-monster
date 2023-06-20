Friend Module InitializerUtility
    Friend Function CreateItem(world As IWorld, itemType As String) As IItem
        Dim descriptor = ItemTypes.Descriptors(itemType)
        Dim item = world.CreateItem(ItemTypes.Nihil, descriptor.ItemName)
        Return item
    End Function
    Friend Function CreateLocation(world As IWorld, locationType As String, name As String) As ILocation
        Return world.CreateLocation(locationType, name)
    End Function
    Friend Function CreateCharacter(location As ILocation, characterType As String, name As String) As ICharacter
        Return location.World.CreateCharacter(characterType, name, location)
    End Function
End Module
