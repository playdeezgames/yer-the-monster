Friend Class MainMenuState
    Inherits BaseMenuState
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(
            parent,
            setState, MainMenuTitle, {EmbarkText, LoadText, OptionsText, AboutText, QuitText}, QuitText)
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
                Utility.ShowStatusBar(displayBuffer, UIFont, "Start a new game!", Hue.Black, Hue.LightGray)
            Case LoadText
                Utility.ShowStatusBar(displayBuffer, UIFont, "Continue a game!", Hue.Black, Hue.LightGray)
            Case QuitText
                Utility.ShowStatusBar(displayBuffer, UIFont, "I'll miss you! <3", Hue.Black, Hue.Red)
            Case AboutText
                Utility.ShowStatusBar(displayBuffer, UIFont, "Learn all the things about this fine game!", Hue.Black, Hue.LightGray)
            Case OptionsText
                Utility.ShowStatusBar(displayBuffer, UIFont, "Change Window Size and Volume!", Hue.Black, Hue.LightGray)
        End Select
    End Sub
End Class
