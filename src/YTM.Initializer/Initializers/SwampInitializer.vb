Friend Module SwampInitializer
    Friend Sub Initialize(world As IWorld)
        Dim mapDescriptor = MapTypes.Swamp.ToMapDescriptor
        Dim swampMap = world.CreateMap(MapTypes.Swamp, "The Swamp", mapDescriptor.Columns, mapDescriptor.Rows, mapDescriptor.DefaultTerrain)
    End Sub
End Module
