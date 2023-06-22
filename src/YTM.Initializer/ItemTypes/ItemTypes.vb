Imports System.Runtime.CompilerServices

Public Module ItemTypes
    Friend Const Nihil = "Nihil"
    Friend Const BigShroom = "BigShroom"
    Friend ReadOnly Descriptors As IReadOnlyDictionary(Of String, ItemTypeDescriptor) =
        New Dictionary(Of String, ItemTypeDescriptor) From
        {
            {Nihil, New ItemTypeDescriptor("Nothing", "!"c, Hue.Cyan, Array.Empty(Of String))},
            {BigShroom, New ItemTypeDescriptor("Big Shroom", "$"c, Hue.Magenta, {TerrainTypes.Empty})}
        }
    Friend ReadOnly Property All As IEnumerable(Of String)
        Get
            Return Descriptors.Keys
        End Get
    End Property
    <Extension>
    Public Function ToItemTypeDescriptor(itemType As String) As ItemTypeDescriptor
        Return Descriptors(itemType)
    End Function
End Module
