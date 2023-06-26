Public Interface ICharacter
    ReadOnly Property Id As Integer
    ReadOnly Property Name As String
    Sub AddItem(item As IItem)
    ReadOnly Property HasItems As Boolean
    ReadOnly Property Items As IEnumerable(Of IItem)
    Property Statistic(statisticType As String) As Integer
    Sub AddMessage(ParamArray lines As String())
    Property MapCell As IMapCell
    ReadOnly Property CharacterType As String
    Sub RemoveItem(item As IItem)
    ReadOnly Property IsAvatar As Boolean
    Sub Recycle()
End Interface
