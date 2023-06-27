Friend Class InventoryDetailItemState
    Inherits BasePickerState

    Public Sub New(parent As IGameController(Of Hue, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState, "<placeholder>", ControlsText("Select", "Cancel"), GameState.Inventory)
    End Sub

    Protected Overrides Sub OnActivateMenuItem(value As (String, String))
        Dim item = World.Item(Context.ItemId)
        World.Avatar.UseItem(item, value.Item1)
        SetState(GameState.Neutral)
    End Sub
    Protected Overrides Function InitializeMenuItems() As List(Of (String, String))
        Dim item = World.Item(Context.ItemId)
        HeaderText = item.Name
        Return New List(Of (String, String))(item.AvailableVerbs.Select(Function(verb) (verb.ToVerbTypeDescriptor.Name, verb)))
    End Function
End Class
