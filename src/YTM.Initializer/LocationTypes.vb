Friend Module LocationTypes
    Friend Const Lair = "Lair"
    Friend Const Swamp = "Swamp"
    Friend ReadOnly Descriptors As IReadOnlyDictionary(Of String, LocationTypeDescriptor) =
        New Dictionary(Of String, LocationTypeDescriptor) From
        {
            {Lair, New LocationTypeDescriptor()},
            {Swamp, New LocationTypeDescriptor()}
        }
    Friend ReadOnly Property All As IEnumerable(Of String)
        Get
            Return Descriptors.Keys
        End Get
    End Property
End Module
