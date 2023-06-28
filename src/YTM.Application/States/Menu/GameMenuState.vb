Friend Class GameMenuState
    Inherits BasePickerState
    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), fontSource As IFontSource)
        MyBase.New(parent, setState, fontSource, "Game Menu", ControlsText("Select", "Cancel"), GameState.Neutral)
    End Sub
    Protected Overrides Sub OnActivateMenuItem(value As (String, String))
        Select Case value.Item2
            Case ContinueGameText
                SetState(GameState.Neutral)
            Case SaveGameText
                SetState(GameState.Save)
            Case OptionsText
                SetStates(GameState.Options, GameState.GameMenu)
            Case AbandonGameText
                SetState(GameState.Abandon)
        End Select
    End Sub
    Protected Overrides Function InitializeMenuItems() As List(Of (String, String))
        Return New List(Of (String, String)) From
            {
                (ContinueGameText, ContinueGameText),
                (SaveGameText, SaveGameText),
                (OptionsText, OptionsText),
                (AbandonGameText, AbandonGameText)
            }
    End Function
End Class
