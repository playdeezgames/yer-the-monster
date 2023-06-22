Friend Class Map
    Inherits MapDataClient
    Implements IMap
    Public Sub New(worldData As WorldData, mapId As Integer)
        MyBase.New(worldData, mapId)
    End Sub
    Public ReadOnly Property Cell(column As Integer, row As Integer) As IMapCell Implements IMap.Cell
        Get
            If column < 0 OrElse row < 0 OrElse column >= Columns OrElse row >= Rows Then
                Return Nothing
            End If
            Return New MapCell(WorldData, MapId, column, row)
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

    Public ReadOnly Property Id As Integer Implements IMap.Id
        Get
            Return Me.MapId
        End Get
    End Property

    Public ReadOnly Property DisplayName As String Implements IMap.DisplayName
        Get
            Return MapData.DisplayName
        End Get
    End Property

    Public ReadOnly Property World As IWorld Implements IMap.World
        Get
            Return New World(WorldData)
        End Get
    End Property

    Public ReadOnly Property Cells As IEnumerable(Of IMapCell) Implements IMap.Cells
        Get
            Dim result As New List(Of IMapCell)
            For row = 0 To Rows - 1
                For column = 0 To Columns - 1
                    result.Add(New MapCell(WorldData, Id, column, row))
                Next
            Next
            Return result
        End Get
    End Property
End Class
