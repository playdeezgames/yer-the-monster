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
                SetState(GameState.Options)
            Case Else
                Throw New NotImplementedException()
        End Select
    End Sub
End Class
