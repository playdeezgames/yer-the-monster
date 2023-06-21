Imports System.Runtime.CompilerServices

Public Module TerrainTypes
    Friend Const Empty = "Empty"
    Private ReadOnly Descriptors As IReadOnlyDictionary(Of String, TerrainTypeDescriptor) =
        New Dictionary(Of String, TerrainTypeDescriptor) From
        {
            {Empty, New TerrainTypeDescriptor("!"c, Hue.Cyan)}
        }
    <Extension>
    Public Function ToTerrainTypeDescriptor(terrainType As String) As TerrainTypeDescriptor
        Return Descriptors(terrainType)
    End Function
End Module
