Public Module WorldInitializer
    Public Sub Initialize(world As IWorld)
        Dim lair = CreateLocation(world, LocationTypes.Lair, "Yer's Lair")
        Dim yer = CreateCharacter(lair, CharacterTypes.Monster, "Yer")
        Dim nihil = CreateItem(world, ItemTypes.Nihil)
        yer.AddItem(nihil)
        world.Avatar = yer
    End Sub
    Private Function CreateItem(world As IWorld, itemType As String) As IItem
        Dim descriptor = ItemTypes.Descriptors(itemType)
        Dim item = world.CreateItem(ItemTypes.Nihil, descriptor.ItemName)
        Return item
    End Function
    Private Function CreateLocation(world As IWorld, locationType As String, name As String) As ILocation
        Return world.CreateLocation(locationType, name)
    End Function
    Private Function CreateCharacter(location As ILocation, characterType As String, name As String) As ICharacter
        Return location.World.CreateCharacter(characterType, name, location)
    End Function
End Module
