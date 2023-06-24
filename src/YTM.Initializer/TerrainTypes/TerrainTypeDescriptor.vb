Public Class TerrainTypeDescriptor
    ReadOnly Property Character As Char
    ReadOnly Property Hue As Hue
    ReadOnly Property Tenable As Boolean
    ReadOnly Property OnEnter As Action(Of ICharacter)
    ReadOnly Property SpawnTerrainTypes As HashSet(Of String)
    Sub New(character As Char, hue As Hue, tenable As Boolean, spawnTerrainTypes As IEnumerable(Of String), Optional onEnter As Action(Of ICharacter) = Nothing)
        Me.Character = character
        Me.Hue = hue
        Me.Tenable = tenable
        Me.OnEnter = onEnter
        Me.SpawnTerrainTypes = New HashSet(Of String)(spawnTerrainTypes)
    End Sub
End Class
