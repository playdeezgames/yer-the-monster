Friend Class MapDataClient
    Inherits WorldDataClient
    Protected ReadOnly Property MapName As String
    Protected ReadOnly Property MapData As MapData
        Get
            Return WorldData.Maps(MapName)
        End Get
    End Property
    Protected Sub New(worldData As WorldData, mapName As String)
        MyBase.New(worldData)
        Me.MapName = mapName
    End Sub
End Class
