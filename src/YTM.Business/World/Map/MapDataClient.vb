Friend Class MapDataClient
    Inherits WorldDataClient
    Protected ReadOnly Property MapId As Integer
    Protected ReadOnly Property MapData As MapData
        Get
            Return WorldData.Maps(MapId)
        End Get
    End Property
    Protected Sub New(worldData As WorldData, mapId As Integer)
        MyBase.New(worldData)
        Me.MapId = mapId
    End Sub
End Class
