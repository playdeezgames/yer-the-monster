Public Module WorldInitializer
    Public Sub Initialize(world As IWorld)
        SwampInitializer.Initialize(world)
        LairInitializer.Initialize(world)
    End Sub
End Module
