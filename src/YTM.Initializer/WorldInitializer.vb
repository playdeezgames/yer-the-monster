Public Module WorldInitializer
    Public Sub Initialize(world As IWorld)
        Dim lair = world.CreateLocation("Yer's Lair")
        Dim yer = world.CreateCharacter("Yer", lair)
        Dim nihil = CreateItem(world, ItemTypes.Nihil)
        yer.AddItem(nihil)
        world.Avatar = yer
    End Sub
    Private Function CreateItem(world As IWorld, itemType As String) As IItem
        Dim item = world.CreateItem(ItemTypes.Nihil)
        item.Name = itemType
        Return item
    End Function
End Module
