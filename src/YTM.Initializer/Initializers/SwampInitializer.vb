Friend Module SwampInitializer
    Friend Function Initialize(world As IWorld) As IMap
        Dim mapDescriptor = MapTypes.Swamp.ToMapTypeDescriptor
        Dim swampMap = world.CreateMap(MapTypes.Swamp, "The Swamp", mapDescriptor.Columns, mapDescriptor.Rows, mapDescriptor.DefaultTerrain)
        Return swampMap
    End Function
End Module
