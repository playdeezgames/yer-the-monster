﻿Imports System.Runtime.CompilerServices

Friend Module MapTypes
    Friend Const Lair = "Lair"
    Friend Const Swamp = "Swamp"
    Private ReadOnly Descriptors As IReadOnlyDictionary(Of String, MapTypeDescriptor) =
        New Dictionary(Of String, MapTypeDescriptor) From
        {
            {MapTypes.Lair, New MapTypeDescriptor(5, 5, TerrainTypes.Empty)},
            {MapTypes.Swamp, New MapTypeDescriptor(50, 50, TerrainTypes.Empty)}
        }
    <Extension>
    Friend Function ToMapDescriptor(mapName As String) As MapTypeDescriptor
        Return Descriptors(mapName)
    End Function
End Module
