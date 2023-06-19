Public Interface IWorld
    Sub Save(filename As String)
    Function CreateLocation(name As String) As ILocation
    Function CreateCharacter(name As String, location As ILocation) As ICharacter
    Property Avatar As ICharacter
End Interface
