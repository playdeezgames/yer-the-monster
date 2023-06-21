Friend Class Map
    Inherits MapDataClient
    Implements IMap
    Public Sub New(worldData As WorldData, mapName As String)
        MyBase.New(worldData, mapName)
    End Sub
    Public ReadOnly Property Cell(column As Integer, row As Integer) As IMapCell Implements IMap.Cell
        Get
            If column < 0 OrElse row < 0 OrElse column >= Columns OrElse row >= Rows Then
                Return Nothing
            End If
            Return New MapCell(WorldData, MapName, column, row)
        End Get
    End Property

    Public ReadOnly Property Columns As Integer Implements IMap.Columns
        Get
            Return MapData.Columns
        End Get
    End Property

    Public ReadOnly Property Rows As Integer Implements IMap.Rows
        Get
            Return MapData.MapCells.Count \ Columns
        End Get
    End Property

    Public ReadOnly Property Name As String Implements IMap.Name
        Get
            Throw New NotImplementedException()
        End Get
    End Property
End Class
