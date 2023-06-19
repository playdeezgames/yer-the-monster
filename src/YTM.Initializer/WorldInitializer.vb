Public Module WorldInitializer
    Public Sub Initialize(world As IWorld)
        Dim lair = world.CreateLocation("Yer's Lair")
        Dim yer = world.CreateCharacter("Yer", lair)
        world.Avatar = yer
    End Sub
End Module
