Friend Class GameMenuState
    Inherits BaseMenuState
    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), fontSource As IFontSource)
        MyBase.New(
            parent,
            setState,
            fontSource,
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
    Public Overrides Sub Render(displayBuffer As IPixelSink)
        MyBase.Render(displayBuffer)
        ShowStatusBar(displayBuffer, FontSource.GetFont(GameFont.Font5x7), ControlsText("Select", "Cancel"), Hue.Black, Hue.LightGray)
    End Sub
End Class
