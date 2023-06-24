Imports System.Runtime.CompilerServices

Public Module TerrainTypes
    Friend Const Empty = "Empty"
    Friend Const Lair = "Lair"
    Friend Const Wall = "Wall"
    Friend Const UpStairs = "UpStairs"
    Friend Const DownStairs = "DownStairs"
    Friend Const DeadTree = "DeadTree"
    Private ReadOnly Descriptors As IReadOnlyDictionary(Of String, TerrainTypeDescriptor) =
        New Dictionary(Of String, TerrainTypeDescriptor) From
        {
            {Empty, New TerrainTypeDescriptor("!"c, Hue.Green, True, Array.Empty(Of String))},
            {Lair, New TerrainTypeDescriptor("!"c, Hue.Green, True, Array.Empty(Of String), onEnter:=AddressOf OnEnterLair)},
            {DownStairs, New TerrainTypeDescriptor("'"c, Hue.DarkGray, False, Array.Empty(Of String))},
            {UpStairs, New TerrainTypeDescriptor("("c, Hue.DarkGray, False, Array.Empty(Of String))},
            {Wall, New TerrainTypeDescriptor(")"c, Hue.DarkGray, False, Array.Empty(Of String))},
            {DeadTree, New TerrainTypeDescriptor("#"c, Hue.Brown, False, {TerrainTypes.Empty})}
        }

    Private Sub OnEnterLair(character As ICharacter)
        character.SetEnergy(character.Energy + 1)
    End Sub

    <Extension>
    Public Function ToTerrainTypeDescriptor(terrainType As String) As TerrainTypeDescriptor
        Return Descriptors(terrainType)
    End Function
    Friend Function LookUpTerrainTypeByCharacter(character As Char) As String
        Return Descriptors.Single(Function(x) x.Value.Character = character).Key
    End Function
End Module
