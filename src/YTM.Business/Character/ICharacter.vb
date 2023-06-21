Public Interface ICharacter
    ReadOnly Property Id As Integer
    ReadOnly Property Name As String
    Property Location As ILocation
    Sub AddItem(item As IItem)
    ReadOnly Property HasItems As Boolean
    ReadOnly Property Items As IEnumerable(Of IItem)
    Property Statistic(statisticType As String) As Integer
    Sub AddMessage(ParamArray lines As String())
End Interface
