Public Module WorldInitializer
    Public Sub Initialize(world As IWorld)
        Dim swamp = SwampInitializer.Initialize(world)
        Dim lair = LairInitializer.Initialize(world)
        'TODO: stitch swamp and lair together
    End Sub
End Module
