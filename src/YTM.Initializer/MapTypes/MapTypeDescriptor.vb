Friend Class MapTypeDescriptor
    ReadOnly Property Columns As Integer
    ReadOnly Property Rows As Integer
    ReadOnly Property DefaultTerrain As String
    ReadOnly Property ItemSpawns As IReadOnlyDictionary(Of String, Integer)
    ReadOnly Property TerrainSpawns As IReadOnlyDictionary(Of String, Integer)
    Sub New(
           columns As Integer,
           rows As Integer,
           defaultTerrain As String,
           itemSpawns As IReadOnlyDictionary(Of String, Integer),
           terrainSpawns As IReadOnlyDictionary(Of String, Integer))
        Me.Columns = columns
        Me.Rows = rows
        Me.DefaultTerrain = defaultTerrain
        Me.ItemSpawns = itemSpawns
        Me.TerrainSpawns = terrainSpawns
    End Sub
End Class
