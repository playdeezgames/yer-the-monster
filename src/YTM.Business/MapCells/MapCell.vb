Friend Class MapCell
    Inherits MapCellDataClient
    Implements IMapCell
    Sub New(worldData As WorldData, mapId As Integer, column As Integer, row As Integer)
        MyBase.New(worldData, mapId, column, row)
    End Sub
    Public ReadOnly Property Map As IMap Implements IMapCell.Map
        Get
            Return New Map(WorldData, MapId)
        End Get
    End Property

    Public Property Character As ICharacter Implements IMapCell.Character
        Get
            If MapCellData.CharacterId.HasValue Then
                Return New Character(WorldData, MapCellData.CharacterId.Value)
            End If
            Return Nothing
        End Get
        Set(value As ICharacter)
            If value Is Nothing Then
                MapCellData.CharacterId = Nothing
                Return
            End If
            MapCellData.CharacterId = value.Id
        End Set
    End Property

    Public Property TerrainType As String Implements IMapCell.TerrainType
        Get
            Return MapCellData.TerrainType
        End Get
        Set(value As String)
            MapCellData.TerrainType = value
        End Set
    End Property

    Public ReadOnly Property HasEffect As Boolean Implements IMapCell.HasEffect
        Get
            Return MapCellData.EffectId.HasValue
        End Get
    End Property

    Public Property Effect As IEffect Implements IMapCell.Effect
        Get
            If HasEffect Then
                Return New Business.Effect(WorldData, MapCellData.EffectId.Value)
            End If
            Return Nothing
        End Get
        Set(value As IEffect)
            If value Is Nothing Then
                MapCellData.EffectId = Nothing
                Return
            End If
            MapCellData.EffectId = value.Id
        End Set
    End Property

    Public ReadOnly Property HasItem As Boolean Implements IMapCell.HasItem
        Get
            Return MapCellData.ItemId.HasValue
        End Get
    End Property

    Public Property Item As IItem Implements IMapCell.Item
        Get
            If MapCellData.ItemId.HasValue Then
                Return New Item(WorldData, MapCellData.ItemId.Value)
            End If
            Return Nothing
        End Get
        Set(value As IItem)
            If value Is Nothing Then
                MapCellData.ItemId = Nothing
                Return
            End If
            MapCellData.ItemId = value.Id
        End Set
    End Property

    Public ReadOnly Property HasCharacter As Boolean Implements IMapCell.HasCharacter
        Get
            Return MapCellData.CharacterId.HasValue
        End Get
    End Property

    Private ReadOnly Property IMapCell_Column As Integer Implements IMapCell.Column
        Get
            Return Column
        End Get
    End Property

    Private ReadOnly Property IMapCell_Row As Integer Implements IMapCell.Row
        Get
            Return Row
        End Get
    End Property

    Public Sub Bump(character As ICharacter) Implements IMapCell.Bump
        Dim effect = Me.Effect
        If effect Is Nothing Then
            Return
        End If
        Select Case effect.EffectType
            Case EffectTypes.Teleport
                DoTeleport(character, effect.GetTeleport())
            Case Else
                Throw New NotImplementedException
        End Select
    End Sub
    Private Sub DoTeleport(character As ICharacter, mapCell As IMapCell)
        character.MapCell.Character = Nothing
        character.MapCell = mapCell
        mapCell.Character = character
    End Sub
End Class
