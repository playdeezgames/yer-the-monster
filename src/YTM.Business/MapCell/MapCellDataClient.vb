Friend Class MapCellDataClient
    Inherits MapDataClient
    Protected ReadOnly Property Column As Integer
    Protected ReadOnly Property Row As Integer
    Private ReadOnly Property Index As Integer
    Protected ReadOnly Property MapCellData As MapCellData
        Get
            Return MapData.MapCells(Index)
        End Get
    End Property
    Protected Sub New(worldData As WorldData, mapId As Integer, column As Integer, row As Integer)
        MyBase.New(worldData, mapId)
        Me.Column = column
        Me.Row = row
        Me.Index = column + row * worldData.Maps(mapId).Columns
    End Sub
End Class
