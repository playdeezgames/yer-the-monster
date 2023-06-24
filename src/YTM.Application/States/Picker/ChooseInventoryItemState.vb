Friend Class ChooseInventoryItemState
    Inherits BasePickerState

    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState, "Choose Item", "Space/(A) - Select | Esc/(B) - Go Back", GameState.Inventory)
    End Sub

    Protected Overrides Sub OnActivateMenuItem(value As (String, String))
        Select Case value.Item2
            Case NeverMindText
                SetState(GameState.Inventory)
            Case Else
                Context.ItemId = CInt(value.Item2)
                SetState(GameState.InteractInventoryItem)
        End Select
    End Sub

    Protected Overrides Function InitializeMenuItems() As List(Of (String, String))
        Dim items = World.Avatar.Items.Where(Function(x) x.Name = Context.ItemName)
        Dim result = New List(Of (String, String)) From
            {
                (NeverMindText, NeverMindText)
            }
        Select Case items.Count
            Case 0
                SetState(GameState.Inventory)
            Case 1
                Context.ItemId = items.Single().Id
                SetState(GameState.InteractInventoryItem)
            Case Else
                result.AddRange(items.Select(Function(x) (x.Name, x.Id.ToString)))
        End Select
        Return result
    End Function
End Class
