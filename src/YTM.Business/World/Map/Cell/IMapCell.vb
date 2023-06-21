Public Interface IMapCell
    ReadOnly Property Column As Integer
    ReadOnly Property Row As Integer
    ReadOnly Property Map As IMap
    Property Character As ICharacter
    Property TerrainType As String
End Interface
