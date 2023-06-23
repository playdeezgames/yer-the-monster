Public Class ItemTypeDescriptor
    ReadOnly Property ItemName As String
    ReadOnly Property Character As Char
    ReadOnly Property Hue As Hue
    ReadOnly Property SpawnTerrainTypes As HashSet(Of String)
    ReadOnly Property PickUpEnergyCost As Integer
    ReadOnly Property Verbs As IReadOnlyDictionary(Of String, Action(Of ICharacter, IItem))
    Sub New(
           name As String,
           character As Char,
           hue As Hue,
           spawnTerrainTypes As IEnumerable(Of String),
           verbs As IReadOnlyDictionary(Of String, Action(Of ICharacter, IItem)),
           Optional pickUpEnergyCost As Integer = 1)
        Me.ItemName = name
        Me.Character = character
        Me.Hue = hue
        Me.SpawnTerrainTypes = New HashSet(Of String)(spawnTerrainTypes)
        Me.PickUpEnergyCost = pickUpEnergyCost
        Me.Verbs = verbs
    End Sub
End Class
