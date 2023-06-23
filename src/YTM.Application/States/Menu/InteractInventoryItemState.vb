Friend Class InteractInventoryItemState
    Inherits BasePickerState

    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState, "<placeholder>", "Space/(A) - Select | Esc/(B) - Go Back", GameState.ChooseInventoryItem)
    End Sub

    Protected Overrides Sub OnActivateMenuItem(value As (String, String))
        Select Case value.Item2
            Case NeverMindText
                SetState(GameState.Inventory)
        End Select
    End Sub

    Protected Overrides Function InitializeMenuItems() As List(Of (String, String))
        HeaderText = Context.ItemName
        Dim item = World.Item(Context.ItemId)
        Dim result As New List(Of (String, String)) From
            {
                (NeverMindText, NeverMindText)
            }
        For Each verb In item.AvailableVerbs
            result.Add((verb.ToVerbTypeDescriptor.Name, verb))
        Next
        Return result
    End Function
End Class
