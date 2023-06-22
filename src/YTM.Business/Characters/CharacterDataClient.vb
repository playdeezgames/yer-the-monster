Friend Class CharacterDataClient
    Inherits WorldDataClient

    Protected Sub New(worldData As WorldData, characterId As Integer)
        MyBase.New(worldData)
        Me.CharacterId = characterId
    End Sub

    Protected ReadOnly Property CharacterId As Integer
    Protected ReadOnly Property CharacterData As CharacterData
        Get
            Return WorldData.Characters(CharacterId)
        End Get
    End Property
End Class
