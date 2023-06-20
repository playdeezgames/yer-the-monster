Public Class LocationData
    Public Property LocationType As String
    Public Property Name As String
    Public Property CharacterIds As New HashSet(Of Integer)
    Public Property Routes As New Dictionary(Of String, RouteData)
End Class
