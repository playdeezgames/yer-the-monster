Public Interface ICharacter
    ReadOnly Property Id As Integer
    ReadOnly Property Name As String
    ReadOnly Property Location As ILocation
    Sub AddItem(item As IItem)
End Interface
