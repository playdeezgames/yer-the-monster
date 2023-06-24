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
    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        MyBase.Render(displayBuffer)
        ShowStatusBar(displayBuffer, Context.UIFont, _table(MenuItemText), Hue.Black, _hueTable(MenuItemText))
    End Sub
    Private ReadOnly _table As IReadOnlyDictionary(Of String, String) =
        New Dictionary(Of String, String) From
        {
                {ContinueGameText, "Get back to the action!"},
                {SaveGameText, "For save scumming!"},
                {OptionsText, "Change Window Size and Volume!"},
                {AbandonGameText, "Don't you dare!"}
        }
    Private ReadOnly _hueTable As IReadOnlyDictionary(Of String, Hue) =
        New Dictionary(Of String, Hue) From
        {
                {ContinueGameText, Hue.White},
                {SaveGameText, Hue.White},
                {OptionsText, Hue.White},
                {AbandonGameText, Hue.Purple}
        }
End Class
