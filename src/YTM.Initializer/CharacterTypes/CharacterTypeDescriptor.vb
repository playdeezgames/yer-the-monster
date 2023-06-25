Public Class CharacterTypeDescriptor
    Public ReadOnly Character As Char
    Public ReadOnly Hue As Hue
    Public ReadOnly Property Statistics As IReadOnlyDictionary(Of String, Integer)
    Public ReadOnly Property SpawnTerrainTypes As HashSet(Of String)
    Sub New(character As Char, hue As Hue, statistics As IReadOnlyDictionary(Of String, Integer), spawnTerrainTypes As IEnumerable(Of String))
        Me.Character = character
        Me.Hue = hue
        Me.Statistics = statistics
        Me.SpawnTerrainTypes = New HashSet(Of String)(spawnTerrainTypes)
    End Sub
End Class
