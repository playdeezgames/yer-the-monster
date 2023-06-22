Public Interface IMap
    ReadOnly Property Columns As Integer
    ReadOnly Property Rows As Integer
    ReadOnly Property Cell(column As Integer, row As Integer) As IMapCell
    ReadOnly Property Cells As IEnumerable(Of IMapCell)
    ReadOnly Property Id As Integer
    ReadOnly Property DisplayName As String
    ReadOnly Property World As IWorld
    ReadOnly Property MapType As String
End Interface
