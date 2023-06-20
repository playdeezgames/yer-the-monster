Friend Class Route
    Inherits RouteDataClient
    Implements IRoute
    Friend Sub New(worldData As WorldData, locationId As Integer, direction As String)
        MyBase.New(worldData, locationId, direction)
    End Sub
    Private ReadOnly Property IRoute_Direction As String Implements IRoute.Direction
        Get
            Return Direction
        End Get
    End Property
End Class
