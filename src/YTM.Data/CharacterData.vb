Public Class CharacterData
    Public Property CharacterType As String
    Public Property Name As String
    Public Property Recycled As Boolean
    Public Property ItemIds As New HashSet(Of Integer)
    Public Property Statistics As New Dictionary(Of String, Integer)
    Public Property MapId As Integer
    Public Property Column As Integer
    Public Property Row As Integer
End Class
