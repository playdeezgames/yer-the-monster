Imports System.Runtime.CompilerServices

Friend Module MapTypes
    Friend Const Lair = "Lair"
    Friend Const Swamp = "Swamp"
    Private ReadOnly Descriptors As IReadOnlyDictionary(Of String, MapTypeDescriptor) =
        New Dictionary(Of String, MapTypeDescriptor) From
        {
            {
                MapTypes.Lair,
                New MapTypeDescriptor(
                    5,
                    5,
                    TerrainTypes.Lair,
                    New Dictionary(Of String, Integer),
                    New Dictionary(Of String, Integer),
                    New Dictionary(Of String, Integer))
            },
            {
                MapTypes.Swamp,
                New MapTypeDescriptor(
                    50,
                    50,
                    TerrainTypes.Empty,
                    New Dictionary(Of String, Integer) From
                    {
                        {ItemTypes.BigShroom, 100}
                    },
                    New Dictionary(Of String, Integer) From
                    {
                        {TerrainTypes.DeadTree, 100}
                    },
                    New Dictionary(Of String, Integer) From
                    {
                        {CharacterTypes.Badger, 25},
                        {CharacterTypes.Snake, 25}
                    })
            }
        }
    <Extension>
    Friend Function ToMapTypeDescriptor(mapName As String) As MapTypeDescriptor
        Return Descriptors(mapName)
    End Function
End Module
