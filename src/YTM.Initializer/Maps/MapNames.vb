Imports System.Runtime.CompilerServices

Friend Module MapNames
    Friend Const Lair = "Lair"
    Friend Const Swamp = "Swamp"
    Private ReadOnly Descriptors As IReadOnlyDictionary(Of String, MapDescriptor) =
        New Dictionary(Of String, MapDescriptor) From
        {
            {MapNames.Lair, New MapDescriptor(5, 5, TerrainTypes.Empty)},
            {MapNames.Swamp, New MapDescriptor(50, 50, TerrainTypes.Empty)}
        }
    <Extension>
    Friend Function ToMapDescriptor(mapName As String) As MapDescriptor
        Return Descriptors(mapName)
    End Function
End Module
