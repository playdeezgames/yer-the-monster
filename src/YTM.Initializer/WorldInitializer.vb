Public Module WorldInitializer
    Public Sub Initialize(world As IWorld)
        Dim lair = world.CreateLocation("Yer's Lair")
        Dim yer = world.CreateCharacter("Yer", lair)
        Dim nihil = world.CreateItem(ItemTypes.Nihil)
        yer.AddItem(nihil)
        world.Avatar = yer
    End Sub
End Module
