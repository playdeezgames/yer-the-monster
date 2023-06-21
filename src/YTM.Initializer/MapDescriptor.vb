Friend Class MapDescriptor
    ReadOnly Property Columns As Integer
    ReadOnly Property Rows As Integer
    ReadOnly Property DefaultTerrain As String
    Sub New(columns As Integer, rows As Integer, defaultTerrain As String)
        Me.Columns = columns
        Me.Rows = rows
        Me.DefaultTerrain = defaultTerrain
    End Sub
End Class
