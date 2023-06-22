Friend Module LairInitializer
    Private ReadOnly lines As IReadOnlyList(Of String) =
        New List(Of String) From
        {
            ")))))",
            ")!!!)",
            ")!(!)",
            ")!!!)",
            ")))))"
        }
    Friend Function Initialize(world As IWorld) As IMap
        Dim mapDescriptor = MapTypes.Lair.ToMapTypeDescriptor
        Dim lairMap = world.CreateMap(MapTypes.Lair, "Yer's Lair", mapDescriptor.Columns, mapDescriptor.Rows, mapDescriptor.DefaultTerrain)
        Dim row = 0
        For Each line In lines
            Dim column = 0
            For Each character In line
                lairMap.Cell(column, row).TerrainType = TerrainTypes.LookUpTerrainTypeByCharacter(character)
                column += 1
            Next
            row += 1
        Next
        Dim yer = CreateCharacter(lairMap.Cell(lairMap.Columns \ 2, lairMap.Rows \ 2), CharacterTypes.Monster, "Yer")
        Dim nihil = CreateItem(world, ItemTypes.Nihil)
        yer.AddItem(nihil)
        world.Avatar = yer
        Return lairMap
    End Function
End Module
