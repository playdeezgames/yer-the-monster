Friend Class ActionMenuState
    Inherits BasePickerState
    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), fontSource As IFontSource)
        MyBase.New(parent, setState, fontSource, "Actions", ControlsText("Select", "Cancel"), GameState.Neutral)
    End Sub

    Protected Overrides Sub OnActivateMenuItem(value As (String, String))
        Select Case value.Item2
            Case InventoryText
                SetState(GameState.Inventory)
            Case Else
                SetState(GameState.PickUpItem)
        End Select
    End Sub

    Protected Overrides Function InitializeMenuItems() As List(Of (String, String))
        Return New List(Of (String, String)) From
            {
                (InventoryText, InventoryText),
                (PickUpItemText, PickUpItemText)
            }
    End Function
End Class
