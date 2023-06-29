Friend Class InventoryDetailItemState
    Inherits BasePickerState

    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), context As IUIContext)
        MyBase.New(parent, setState, context, "<placeholder>", ControlsText("Select", "Cancel"), GameState.Inventory)
    End Sub

    Protected Overrides Sub OnActivateMenuItem(value As (String, String))
        Dim item = World.Item(Application.ItemId)
        World.Avatar.UseItem(item, value.Item1)
        SetState(GameState.Neutral)
    End Sub
    Protected Overrides Function InitializeMenuItems() As List(Of (String, String))
        Dim item = World.Item(Application.ItemId)
        HeaderText = item.Name
        Return New List(Of (String, String))(item.AvailableVerbs.Select(Function(verb) (verb.ToVerbTypeDescriptor.Name, verb)))
    End Function
End Class
