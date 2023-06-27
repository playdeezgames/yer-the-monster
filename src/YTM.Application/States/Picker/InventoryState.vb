Friend Class InventoryState
    Inherits BasePickerState
    Public Sub New(parent As IGameController(Of Hue), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState, "Yer's Inventory", ControlsText("Select", "Cancel"), GameState.Neutral)
    End Sub

    Protected Overrides Sub OnActivateMenuItem(value As (String, String))
        Context.ItemName = value.Item2
        Context.ItemId = World.Avatar.Items.First(Function(x) x.Name = value.Item2).Id
        SetState(GameState.InventoryDetail)
    End Sub

    Protected Overrides Function InitializeMenuItems() As List(Of (String, String))
        Return New List(Of (String, String))(World.Avatar.Items.GroupBy(Function(x) x.Name).Select(Function(x) ($"{x.Key}(x{x.Count})", x.Key)))
    End Function
End Class
