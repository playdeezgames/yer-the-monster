Friend Class InventoryState
    Inherits BasePickerState
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState, "Yer's Inventory", "Space/(A) - Item Details | Esc/(B) - Go Back", GameState.Neutral)
    End Sub

    Protected Overrides Sub OnActivateMenuItem(value As (String, String))
        Select Case value.Item2
            Case NeverMindText
                SetState(GameState.Neutral)
        End Select
    End Sub

    Protected Overrides Function InitializeMenuItems() As List(Of (String, String))
        Dim result As New List(Of (String, String)) From
            {
                (NeverMindText, NeverMindText)
            }
        result.AddRange(World.Avatar.Items.GroupBy(Function(x) x.Name).Select(Function(x) ($"{x.Key}(x{x.Count})", x.Key)))
        Return result
    End Function
End Class
