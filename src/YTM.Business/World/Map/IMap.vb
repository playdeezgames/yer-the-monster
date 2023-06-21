Public Interface IMap
    ReadOnly Property Columns As Integer
    ReadOnly Property Rows As Integer
    ReadOnly Property Cell(column As Integer, row As Integer) As IMapCell
    ReadOnly Property Name As String
    ReadOnly Property DisplayName As String
    ReadOnly Property World As IWorld
End Interface
