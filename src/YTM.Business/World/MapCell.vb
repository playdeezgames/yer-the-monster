Friend Class MapCell
    Inherits MapCellDataClient
    Implements IMapCell
    Sub New(worldData As WorldData, mapName As String, column As Integer, row As Integer)
        MyBase.New(worldData, mapName, column, row)
    End Sub
    Public ReadOnly Property Map As IMap Implements IMapCell.Map
        Get
            Return New Map(WorldData, MapName)
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
End Class
