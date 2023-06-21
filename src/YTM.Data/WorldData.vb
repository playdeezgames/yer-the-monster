Public Class WorldData
    Public Property AvatarCharacterId As Integer?
    Public Property Characters As New List(Of CharacterData)
    Public Property Locations As New List(Of LocationData)
    Public Property Items As New List(Of ItemData)
    Public Property Messages As New List(Of MessageData)
End Class
