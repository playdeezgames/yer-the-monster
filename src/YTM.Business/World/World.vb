Imports System.IO
Imports System.Text.Json

Public Class World
    Inherits WorldDataClient
    Implements IWorld
    Public Sub New(worldData As WorldData)
        MyBase.New(worldData)
    End Sub

    Public Property Avatar As ICharacter Implements IWorld.Avatar
        Get
            Return If(WorldData.AvatarCharacterId.HasValue, New Character(WorldData, WorldData.AvatarCharacterId.Value), Nothing)
        End Get
        Set(value As ICharacter)
            If value Is Nothing Then
                WorldData.AvatarCharacterId = Nothing
                Return
            End If
            WorldData.AvatarCharacterId = value.Id
        End Set
    End Property

    Public Sub Save(filename As String) Implements IWorld.Save
        File.WriteAllText(filename, JsonSerializer.Serialize(WorldData))
    End Sub
    Public Shared Function Load(filename As String) As IWorld
        Try
            Return New World(JsonSerializer.Deserialize(Of WorldData)(File.ReadAllText(filename)))
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function CreateLocation(name As String) As ILocation Implements IWorld.CreateLocation
        Dim data As New LocationData With
            {
                .Name = name
            }
        Dim locationId = WorldData.Locations.Count
        WorldData.Locations.Add(data)
        Return New Location(WorldData, locationId)
    End Function

    Public Function CreateCharacter(name As String, location As ILocation) As ICharacter Implements IWorld.CreateCharacter
        Dim data As New CharacterData With
            {
                .Name = name,
                .Recycled = False,
                .LocationId = location.Id
            }
        Dim characterId = WorldData.Characters.FindIndex(Function(x) x.Recycled)
        If characterId < 0 Then
            characterId = WorldData.Characters.Count
            WorldData.Characters.Add(data)
        Else
            WorldData.Characters(characterId) = data
        End If
        Dim result = New Character(WorldData, characterId)
        location.AddCharacter(result)
        Return result
    End Function

    Public Function CreateItem(itemType As String) As IItem Implements IWorld.CreateItem
        Dim data As New ItemData With
            {
                .ItemType = itemType,
                .Recycled = False
            }
        Dim itemId = WorldData.Items.FindIndex(Function(x) x.Recycled)
        If itemId < 0 Then
            itemId = WorldData.Items.Count
            WorldData.Items.Add(data)
        Else
            WorldData.Items(itemId) = data
        End If
        Dim result = New Item(WorldData, itemId)
        Return result
    End Function
End Class
