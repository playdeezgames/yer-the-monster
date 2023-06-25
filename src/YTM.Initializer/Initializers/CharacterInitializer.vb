Friend Module CharacterInitializer
    Friend Sub Initialize(world As IWorld)
        For Each map In world.Maps
            InitializeMap(world, map)
        Next
    End Sub
    Private Sub InitializeMap(world As IWorld, map As IMap)
        Dim mapTypeDescriptor = map.MapType.ToMapTypeDescriptor
        For Each entry In mapTypeDescriptor.CharacterSpawns
            Dim characterTypeDescriptor = entry.Key.ToCharacterTypeDescriptor
            Dim candidates = map.Cells.Where(Function(x) characterTypeDescriptor.SpawnTerrainTypes.Contains(x.TerrainType) AndAlso Not x.HasCharacter).ToList
            Dim count = entry.Value
            While candidates.Any AndAlso count > 0
                Dim candidate = RNG.FromEnumerable(candidates)
                InitializerUtility.CreateCharacter(candidate, entry.Key, entry.Key)
                candidates.Remove(candidate)
                count -= 1
            End While
        Next
    End Sub
End Module
