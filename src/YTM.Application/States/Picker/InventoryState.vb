Friend Class InventoryState
    Inherits BasePickerState
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState, "Yer's Inventory", "Space/(A) - Select | Esc/(B) - Go Back", GameState.Neutral)
    End Sub

    Protected Overrides Sub OnActivateMenuItem(value As (String, String))
        Context.ItemName = value.Item2
        SetState(GameState.ChooseInventoryItem)
    End Sub

    Protected Overrides Function InitializeMenuItems() As List(Of (String, String))
        Return New List(Of (String, String))(World.Avatar.Items.GroupBy(Function(x) x.Name).Select(Function(x) ($"{x.Key}(x{x.Count})", x.Key)))
    End Function
End Class
