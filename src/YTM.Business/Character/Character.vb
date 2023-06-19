﻿Friend Class Character
    Inherits CharacterDataClient
    Implements ICharacter
    Sub New(worldData As WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub
    Public ReadOnly Property Id As Integer Implements ICharacter.Id
        Get
            Return CharacterId
        End Get
    End Property
    Public ReadOnly Property Name As String Implements ICharacter.Name
        Get
            Return CharacterData.Name
        End Get
    End Property
    Public ReadOnly Property Location As ILocation Implements ICharacter.Location
        Get
            Return New Location(WorldData, CharacterData.LocationId)
        End Get
    End Property
End Class