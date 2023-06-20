Public Interface ILocation
    ReadOnly Property Id As Integer
    Sub AddCharacter(character As ICharacter)
    ReadOnly Property Name As String
    ReadOnly Property World As IWorld
    Function CreateRoute(direction As String, routeType As String, destination As ILocation) As IRoute
    ReadOnly Property LocationType As String
    Function HasRoute(direction As String) As Boolean
    ReadOnly Property Routes As IEnumerable(Of IRoute)
    ReadOnly Property Route(direction As String) As IRoute
End Interface
