Friend Class GameMenuState
    Inherits BaseMenuState
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(
            parent,
            setState,
            GameMenuTitle,
            {
                ContinueGameText,
                SaveGameText,
                OptionsText,
                AbandonGameText
            },
            ContinueGameText)
    End Sub
    Protected Overrides Sub HandleMenuItem(menuItem As String)
        Select Case menuItem
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
End Class
