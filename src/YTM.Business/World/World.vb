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
    Public ReadOnly Property HasMessages As Boolean Implements IWorld.HasMessages
        Get
            Return WorldData.Messages.Any
        End Get
    End Property

    Public ReadOnly Property CurrentMessage As IMessage Implements IWorld.CurrentMessage
        Get
            If Not HasMessages Then
                Return Nothing
            End If
            Return New Message(WorldData)
        End Get
    End Property

    Public Sub Save(filename As String) Implements IWorld.Save
        File.WriteAllText(filename, JsonSerializer.Serialize(WorldData))
    End Sub

    Public Sub NextMessage() Implements IWorld.NextMessage
        WorldData.Messages.RemoveAt(0)
    End Sub

    Public Shared Function Load(filename As String) As IWorld
        Try
            Return New World(JsonSerializer.Deserialize(Of WorldData)(File.ReadAllText(filename)))
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function CreateCharacter(
                                   characterType As String,
                                   name As String,
                                   mapCell As IMapCell,
                                   statistics As IReadOnlyDictionary(Of String, Integer)) As ICharacter Implements IWorld.CreateCharacter
        Dim data As New CharacterData With
            {
                .CharacterType = characterType,
                .Name = name,
                .Recycled = False,
                .Statistics = statistics.ToDictionary(Function(x) x.Key, Function(x) x.Value),
                .MapId = mapCell.Map.Id,
                .Column = mapCell.Column,
                .Row = mapCell.Row
            }
        Dim characterId = WorldData.Characters.FindIndex(Function(x) x.Recycled)
        If characterId < 0 Then
            characterId = WorldData.Characters.Count
            WorldData.Characters.Add(data)
        Else
            WorldData.Characters(characterId) = data
        End If
        Dim result = New Character(WorldData, characterId)
        mapCell.Character = result
        Return result
    End Function

    Public Function CreateItem(itemType As String, name As String) As IItem Implements IWorld.CreateItem
        Dim data As New ItemData With
            {
                .ItemType = itemType,
                .Name = name,
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

    Public Function CreateMap(
                             mapTypeName As String,
                             displayName As String,
                             columns As Integer,
                             rows As Integer,
                             defaultTerrain As String) As IMap Implements IWorld.CreateMap
        Dim map = New MapData With
            {
                .DisplayName = displayName,
                .Columns = columns
            }
        While map.MapCells.Count < columns * rows
            map.MapCells.Add(New MapCellData With {
                             .TerrainType = defaultTerrain,
                             .CharacterId = Nothing
                             })
        End While
        Dim mapId = WorldData.Maps.Count
        WorldData.Maps.Add(map)
        Return New Map(WorldData, mapId)
    End Function

    Public Function CreateEffect(effectType As String) As IEffect Implements IWorld.CreateEffect
        Dim effect As New EffectData With
            {
                .EffectType = effectType
            }
        Dim effectId = WorldData.Effects.Count
        WorldData.Effects.Add(effect)
        Return New Effect(WorldData, effectId)
    End Function
End Class
