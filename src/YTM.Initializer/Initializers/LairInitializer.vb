Friend Module LairInitializer
    Friend Sub Initialize(world As IWorld)
        Dim mapDescriptor = MapTypes.Lair.ToMapDescriptor
        Dim lairMap = world.CreateMap(MapTypes.Lair, "Yer's Lair", mapDescriptor.Columns, mapDescriptor.Rows, mapDescriptor.DefaultTerrain)
        Dim yer = CreateCharacter(lairMap.Cell(lairMap.Columns \ 2, lairMap.Rows \ 2), CharacterTypes.Monster, "Yer")
        Dim nihil = CreateItem(world, ItemTypes.Nihil)
        yer.AddItem(nihil)
        world.Avatar = yer
    End Sub
End Module
