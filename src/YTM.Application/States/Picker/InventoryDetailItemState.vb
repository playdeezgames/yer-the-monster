Friend Class InventoryDetailItemState
    Inherits BasePickerState

    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState, "<placeholder>", "Space/(A) - Select | Esc/(B) - Go Back", GameState.Inventory)
    End Sub

    Protected Overrides Sub OnActivateMenuItem(value As (String, String))
        Select Case value.Item2
            Case NeverMindText
                SetState(GameState.Inventory)
            Case Else
                DoTheVerb(value.Item1)
        End Select
    End Sub

    Private Sub DoTheVerb(verbType As String)
        Dim item = World.Item(Context.ItemId)
        World.Avatar.UseItem(item, verbType)
        SetState(GameState.Neutral)
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
