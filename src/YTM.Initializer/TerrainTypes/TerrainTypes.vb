Imports System.Runtime.CompilerServices

Public Module TerrainTypes
    Friend Const Empty = "Empty"
    Friend Const Wall = "Wall"
    Friend Const UpStairs = "UpStairs"
    Private ReadOnly Descriptors As IReadOnlyDictionary(Of String, TerrainTypeDescriptor) =
        New Dictionary(Of String, TerrainTypeDescriptor) From
        {
            {Empty, New TerrainTypeDescriptor("!"c, Hue.Cyan, True)},
            {UpStairs, New TerrainTypeDescriptor("("c, Hue.Magenta, False)},
            {Wall, New TerrainTypeDescriptor(")"c, Hue.White, False)}
        }
    <Extension>
    Public Function ToTerrainTypeDescriptor(terrainType As String) As TerrainTypeDescriptor
        Return Descriptors(terrainType)
    End Function
    Friend Function LookUpTerrainTypeByCharacter(character As Char) As String
        Return Descriptors.Single(Function(x) x.Value.Character = character).Key
    End Function
End Module
