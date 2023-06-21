Friend Class Map
    Inherits MapDataClient
    Implements IMap
    Public Sub New(worldData As WorldData, mapName As String)
        MyBase.New(worldData, mapName)
    End Sub
End Class
