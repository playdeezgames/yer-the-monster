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
End Class
