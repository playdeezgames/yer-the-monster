Friend Module LairInitializer
    Friend Sub Initialize(world As IWorld)
        Dim swampLocation = RNG.FromEnumerable(world.Locations.Where(Function(x) x.LocationType = LocationTypes.Swamp AndAlso Not x.HasRoute(Directions.Inward)))
        Dim lair = CreateLocation(world, LocationTypes.Lair, "Yer's Lair")
        swampLocation.CreateRoute(Directions.Inward, RouteTypes.LairEntrance, lair)
        lair.CreateRoute(Directions.Outward, RouteTypes.LairEntrance, swampLocation)
        Dim yer = CreateCharacter(lair, CharacterTypes.Monster, "Yer")
        Dim nihil = CreateItem(world, ItemTypes.Nihil)
        yer.AddItem(nihil)
        world.Avatar = yer
    End Sub
End Module
