Public Module WorldInitializer
    Public Sub Initialize(world As IWorld)
        Dim swamp = SwampInitializer.Initialize(world)
        Dim lair = LairInitializer.Initialize(world)
        TerrainInitializer.Initialize(world)
        ItemInitializer.Initialize(world)
        StitchSwampToLair(world, swamp, lair)
    End Sub

    Private Sub StitchSwampToLair(world As IWorld, swamp As IMap, lair As IMap)
        Dim swampCell = RNG.FromEnumerable(swamp.Cells.Where(Function(x) x.TerrainType = TerrainTypes.Empty AndAlso Not x.HasEffect))
        Dim lairCell = lair.Cells.Single(Function(x) x.TerrainType = TerrainTypes.UpStairs)
        swampCell.TerrainType = TerrainTypes.DownStairs
        Dim enterLair = world.CreateEffect(EffectTypes.Teleport)
        enterLair.SetTeleport(lairCell)
        swampCell.Effect = enterLair
        Dim exitLair = world.CreateEffect(EffectTypes.Teleport)
        exitLair.SetTeleport(swampCell)
        lairCell.Effect = exitLair
    End Sub
End Module
