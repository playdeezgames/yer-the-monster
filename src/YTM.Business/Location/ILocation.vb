Public Interface ILocation
    ReadOnly Property Id As Integer
    Sub AddCharacter(character As ICharacter)
    ReadOnly Property Name As String
    ReadOnly Property World As IWorld
End Interface
