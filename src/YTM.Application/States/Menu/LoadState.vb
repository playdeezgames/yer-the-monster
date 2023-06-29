Friend Class LoadState
    Inherits BasePickerState
    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), context As IUIContext)
        MyBase.New(parent, setState, context, "Load Game", ControlsText("Select", "Cancel"), GameState.MainMenu)
    End Sub

    Protected Overrides Sub OnActivateMenuItem(value As (String, String))
        Dim slotIndex = CInt(value.Item2)
        If slotIndex > 0 AndAlso DoesSaveExist(slotIndex) Then
            Application.LoadFromSlot(slotIndex)
            SetState(GameState.Neutral)
        Else
            PlaySfx(Sfx.Shucks)
            SetState(GameState.MainMenu)
        End If
    End Sub

    Protected Overrides Function InitializeMenuItems() As List(Of (String, String))
        Dim result = New List(Of (String, String))
        For slotIndex = 1 To 5
            If Application.DoesSaveExist(slotIndex) Then
                result.Add(($"Slot {slotIndex}", $"{slotIndex}"))
            End If
        Next
        If Not result.Any() Then
            result.Add(("No Saves Exist!", "0"))
        End If
        Return result
    End Function
End Class
