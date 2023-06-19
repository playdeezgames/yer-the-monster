Public Class CharacterData
    Public Property Name As String
    Public Property Recycled As Boolean
    Public Property LocationId As Integer
    Public Property ItemIds As New HashSet(Of Integer)
End Class
