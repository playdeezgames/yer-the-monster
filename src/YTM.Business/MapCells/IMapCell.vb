﻿Public Interface IMapCell
    ReadOnly Property Column As Integer
    ReadOnly Property Row As Integer
    ReadOnly Property Map As IMap
    Property Character As ICharacter
    Property TerrainType As String
    ReadOnly Property HasEffect As Boolean
    Property Effect As IEffect
    Sub Bump(character As ICharacter)
    ReadOnly Property HasItem As Boolean
    Property Item As IItem
    ReadOnly Property HasCharacter As Boolean
End Interface
