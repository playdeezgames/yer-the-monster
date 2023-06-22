Public Class ItemTypeDescriptor
    ReadOnly Property ItemName As String
    ReadOnly Property Character As Char
    ReadOnly Property Hue As Hue
    ReadOnly Property SpawnTerrainTypes As HashSet(Of String)
    Sub New(name As String, character As Char, hue As Hue, spawnTerrainTypes As IEnumerable(Of String))
        Me.ItemName = name
        Me.Character = character
        Me.Hue = hue
        Me.SpawnTerrainTypes = New HashSet(Of String)(spawnTerrainTypes)
    End Sub
End Class
