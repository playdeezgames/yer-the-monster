Friend Module LairInitializer
    Friend Sub Initialize(world As IWorld)
        Dim mapDescriptor = MapNames.Lair.ToMapDescriptor
        Dim lairMap = world.CreateMap(MapNames.Lair, "Yer's Lair", mapDescriptor.Columns, mapDescriptor.Rows, mapDescriptor.DefaultTerrain)
        Dim oldSwampLocation = RNG.FromEnumerable(world.Locations.Where(Function(x) x.LocationType = LocationTypes.Swamp AndAlso Not x.HasRoute(Directions.Inward)))
        Dim oldLair = CreateLocation(world, LocationTypes.Lair, "Yer's Lair")
        oldSwampLocation.CreateRoute(Directions.Inward, RouteTypes.LairEntrance, oldLair)
        oldLair.CreateRoute(Directions.Outward, RouteTypes.LairEntrance, oldSwampLocation)
        Dim yer = CreateCharacter(oldLair, CharacterTypes.Monster, "Yer")
        Dim nihil = CreateItem(world, ItemTypes.Nihil)
        yer.AddItem(nihil)
        world.Avatar = yer
    End Sub
End Module
