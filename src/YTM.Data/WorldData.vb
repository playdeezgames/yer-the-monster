Public Class WorldData
    Public Property AvatarCharacterId As Integer?
    Public Property Characters As New List(Of CharacterData)
    Public Property Items As New List(Of ItemData)
    Public Property Messages As New List(Of MessageData)
    Public Property Maps As New List(Of MapData)
End Class
