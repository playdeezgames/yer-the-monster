Public Class GameController
    Inherits BaseGameController(Of Hue, Command, Sfx, GameState)

    Public Sub New(windowSize As (Integer, Integer), fullScreen As Boolean, volume As Single)
        MyBase.New(windowSize, fullScreen, volume)
        Initialize()
        SetState(GameState.Splash, New SplashState(Me, AddressOf SetCurrentState))
        SetState(GameState.MainMenu, New MainMenuState(Me, AddressOf SetCurrentState))
        SetState(GameState.ConfirmQuit, New ConfirmQuitState(Me, AddressOf SetCurrentState))
        SetCurrentState(GameState.Splash, True)
    End Sub
End Class
