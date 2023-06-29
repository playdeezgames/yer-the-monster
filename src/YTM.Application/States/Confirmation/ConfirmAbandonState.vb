Friend Class ConfirmAbandonState
    Inherits BasePickerState
    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), context As IUIContext)
        MyBase.New(parent, setState, context, "Are you sure you want to abandon the game?", ControlsText("Select", "Cancel"), GameState.GameMenu)
    End Sub
    Protected Overrides Sub OnActivateMenuItem(value As (String, String))
        Select Case value.Item2
            Case NoText
                SetState(GameState.GameMenu)
            Case YesText
                Application.Context.Abandon()
                SetState(GameState.MainMenu)
        End Select
    End Sub
    Protected Overrides Function InitializeMenuItems() As List(Of (String, String))
        Return New List(Of (String, String)) From
            {
                (NoText, NoText),
                (YesText, YesText)
            }
    End Function
End Class
