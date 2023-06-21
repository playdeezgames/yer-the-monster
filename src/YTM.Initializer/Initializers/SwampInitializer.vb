Friend Module SwampInitializer
    Friend Sub Initialize(world As IWorld)
        Dim mapDescriptor = MapNames.Swamp.ToMapDescriptor
        Dim swampMap = world.CreateMap(MapNames.Swamp, "The Swamp", mapDescriptor.Columns, mapDescriptor.Rows, mapDescriptor.DefaultTerrain)
    End Sub
End Module
