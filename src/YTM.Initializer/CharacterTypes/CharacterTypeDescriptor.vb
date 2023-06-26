Public Class CharacterTypeDescriptor
    Public ReadOnly Character As Char
    Public ReadOnly Hue As Hue
    Public ReadOnly Property Statistics As IReadOnlyDictionary(Of String, Integer)
    Public ReadOnly Property SpawnTerrainTypes As HashSet(Of String)
    Public ReadOnly Property ItemTypeDrops As IReadOnlyDictionary(Of String, Integer)
    Sub New(
           character As Char,
           hue As Hue,
           statistics As IReadOnlyDictionary(Of String, Integer),
           spawnTerrainTypes As IEnumerable(Of String),
           itemTypeDrops As IReadOnlyDictionary(Of String, Integer))
        Me.Character = character
        Me.Hue = hue
        Me.Statistics = statistics
        Me.SpawnTerrainTypes = New HashSet(Of String)(spawnTerrainTypes)
        Me.ItemTypeDrops = itemTypeDrops
    End Sub
End Class
