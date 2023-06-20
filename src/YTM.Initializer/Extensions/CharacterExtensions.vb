Imports System.Runtime.CompilerServices

Public Module CharacterExtensions
    <Extension>
    Public Sub Move(character As ICharacter, direction As String)
        character.Location = character.Location.Route(direction).Destination
    End Sub
End Module
