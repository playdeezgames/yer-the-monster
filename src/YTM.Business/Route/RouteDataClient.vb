Friend Class RouteDataClient
    Inherits LocationDataClient
    Protected Sub New(worldData As WorldData, locationId As Integer, direction As String)
        MyBase.New(worldData, locationId)
        Me.Direction = direction
    End Sub
    Protected ReadOnly Property Direction As String
    Protected ReadOnly Property RouteData As RouteData
        Get
            Return WorldData.Locations(LocationId).Routes(Direction)
        End Get
    End Property
End Class
