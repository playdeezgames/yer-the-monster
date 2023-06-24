Friend Module TerrainInitializer
    Friend Sub Initialize(world As IWorld)
        For Each map In world.Maps
            Dim descriptor = map.MapType.ToMapTypeDescriptor
            For Each entry In descriptor.TerrainSpawns
                Dim terrainTypeDescriptor = entry.Key.ToTerrainTypeDescriptor
                Dim candidates = map.Cells.Where(Function(x) terrainTypeDescriptor.SpawnTerrainTypes.Contains(x.TerrainType) AndAlso Not x.HasItem).ToList
                Dim count = entry.Value
                While candidates.Any AndAlso count > 0
                    Dim candidate = RNG.FromEnumerable(candidates)
                    candidate.TerrainType = entry.Key
                    count -= 1
                End While
            Next
        Next
    End Sub
End Module
