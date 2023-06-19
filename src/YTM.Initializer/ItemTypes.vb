Friend Module ItemTypes
    Friend Const Nihil = "Nihil"
    Friend ReadOnly Descriptors As IReadOnlyDictionary(Of String, ItemTypeDescriptor) =
        New Dictionary(Of String, ItemTypeDescriptor) From
        {
            {Nihil, New ItemTypeDescriptor("Nothing")}
        }
    Friend ReadOnly Property All As IEnumerable(Of String)
        Get
            Return Descriptors.Keys
        End Get
    End Property
End Module
