Friend Class MainMenuState
    Inherits BaseMenuState
    Public Sub New(parent As IGameController(Of Hue), setState As Action(Of String, Boolean))
        MyBase.New(
            parent,
            setState, MainMenuTitle, {EmbarkText, LoadText, OptionsText, AboutText}, QuitText)
    End Sub
    Protected Overrides Sub HandleMenuItem(menuItem As String)
        Select Case menuItem
            Case QuitText
                SetState(GameState.ConfirmQuit)
            Case OptionsText
                SetStates(GameState.Options, GameState.MainMenu)
            Case AboutText
                SetState(GameState.About)
            Case EmbarkText
                SetState(GameState.Embark)
            Case LoadText
                SetState(GameState.Load)
            Case Else
                Throw New NotImplementedException()
        End Select
    End Sub
    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        MyBase.Render(displayBuffer)
        Select Case MenuItemText
            Case EmbarkText
                Title = "Start a new game!"
            Case LoadText
                Title = "Continue a game!"
            Case QuitText
                Title = "I'll miss you! <3"
            Case AboutText
                Title = "Learn all the things about this fine game!"
            Case OptionsText
                Title = "Change Window Size and Volume!"
        End Select
        ShowStatusBar(displayBuffer, UIFont, ControlsText("Select", "Quit Game"), Hue.Black, Hue.LightGray)
    End Sub
End Class
