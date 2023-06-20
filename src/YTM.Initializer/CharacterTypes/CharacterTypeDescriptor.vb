Public Class CharacterTypeDescriptor
    Public ReadOnly Property Statistics As IReadOnlyDictionary(Of String, Integer)
    Sub New(statistics As IReadOnlyDictionary(Of String, Integer))
        Me.Statistics = statistics
    End Sub
End Class
