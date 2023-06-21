Friend Class Character
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
    Public Property Location As ILocation Implements ICharacter.Location
        Get
            Return New Location(WorldData, CharacterData.LocationId)
        End Get
        Set(value As ILocation)
            CharacterData.LocationId = value.Id
        End Set
    End Property

    Public ReadOnly Property HasItems As Boolean Implements ICharacter.HasItems
        Get
            Return CharacterData.ItemIds.Any
        End Get
    End Property

    Public ReadOnly Property Items As IEnumerable(Of IItem) Implements ICharacter.Items
        Get
            Return CharacterData.ItemIds.Select(Function(x) New Item(WorldData, x))
        End Get
    End Property

    Public Property Statistic(statisticType As String) As Integer Implements ICharacter.Statistic
        Get
            Return CharacterData.Statistics(statisticType)
        End Get
        Set(value As Integer)
            CharacterData.Statistics(statisticType) = value
        End Set
    End Property

    Public Property MapCell As IMapCell Implements ICharacter.MapCell
        Get
            Return New MapCell(WorldData, CharacterData.MapName, CharacterData.Column, CharacterData.Row)
        End Get
        Set(value As IMapCell)
            CharacterData.MapName = value.Map.Name
            CharacterData.Column = value.Column
            CharacterData.Row = value.Row
        End Set
    End Property

    Public Sub AddItem(item As IItem) Implements ICharacter.AddItem
        CharacterData.ItemIds.Add(item.Id)
    End Sub

    Public Sub AddMessage(ParamArray lines() As String) Implements ICharacter.AddMessage
        If WorldData.AvatarCharacterId.HasValue AndAlso WorldData.AvatarCharacterId.Value = Id Then
            WorldData.Messages.Add(
                New MessageData With
                {
                    .Lines = lines.ToList
                })
        End If
    End Sub
End Class
