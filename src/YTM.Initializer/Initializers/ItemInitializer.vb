Friend Module ItemInitializer
    Friend Sub Initialize(world As IWorld)
        For Each map In world.Maps
            InitializeMap(world, map)
        Next
    End Sub
    Private Sub InitializeMap(world As IWorld, map As IMap)
        Dim mapTypeDescriptor = map.MapType.ToMapTypeDescriptor
        For Each entry In mapTypeDescriptor.ItemSpawns
            Dim itemTypeDescriptor = entry.Key.ToItemTypeDescriptor
            Dim candidates = map.Cells.Where(Function(x) itemTypeDescriptor.SpawnTerrainTypes.Contains(x.TerrainType) AndAlso Not x.HasItem).ToList
            Dim count = entry.Value
            While candidates.Any AndAlso count > 0
                Dim candidate = RNG.FromEnumerable(candidates)
                candidate.Item = InitializerUtility.CreateItem(world, entry.Key)
                count -= 1
            End While
        Next
    End Sub
End Module
