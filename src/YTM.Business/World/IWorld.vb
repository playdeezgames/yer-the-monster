Public Interface IWorld
    Sub Save(filename As String)
    Function CreateLocation(itemType As String, name As String) As ILocation
    Function CreateCharacter(
                            characterType As String,
                            name As String,
                            location As ILocation,
                            statistics As IReadOnlyDictionary(Of String, Integer)) As ICharacter
    Property Avatar As ICharacter
    Function CreateItem(itemType As String, name As String) As IItem
    ReadOnly Property Locations As IEnumerable(Of ILocation)
    ReadOnly Property HasMessages As Boolean
    Sub NextMessage()
    ReadOnly Property CurrentMessage As IMessage
End Interface
