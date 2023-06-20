Friend Class Location
    Inherits LocationDataClient
    Implements ILocation
    Sub New(worldData As WorldData, locationId As Integer)
        MyBase.New(worldData, locationId)
    End Sub
    Public ReadOnly Property Id As Integer Implements ILocation.Id
        Get
            Return LocationId
        End Get
    End Property

    Public ReadOnly Property Name As String Implements ILocation.Name
        Get
            Return LocationData.Name
        End Get
    End Property

    Public ReadOnly Property World As IWorld Implements ILocation.World
        Get
            Return New World(WorldData)
        End Get
    End Property

    Public ReadOnly Property LocationType As String Implements ILocation.LocationType
        Get
            Return LocationData.LocationType
        End Get
    End Property

    Public ReadOnly Property Routes As IEnumerable(Of IRoute) Implements ILocation.Routes
        Get
            Return LocationData.Routes.Keys.Select(Function(x) New Route(WorldData, LocationId, x))
        End Get
    End Property

    Public ReadOnly Property Route(direction As String) As IRoute Implements ILocation.Route
        Get
            If Not HasRoute(direction) Then
                Return Nothing
            End If
            Return New Route(WorldData, LocationId, direction)
        End Get
    End Property

    Public Sub AddCharacter(character As ICharacter) Implements ILocation.AddCharacter
        LocationData.CharacterIds.Add(character.Id)
    End Sub

    Public Function CreateRoute(direction As String, routeType As String, destination As ILocation) As IRoute Implements ILocation.CreateRoute
        LocationData.Routes(direction) = New RouteData With
            {
                .RouteType = routeType,
                .DestinationId = destination.Id
            }
        Return New Route(WorldData, LocationId, direction)
    End Function

    Public Function HasRoute(direction As String) As Boolean Implements ILocation.HasRoute
        Return LocationData.Routes.ContainsKey(direction)
    End Function
End Class
