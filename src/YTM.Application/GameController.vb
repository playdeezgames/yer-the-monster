Public Class GameController
    Inherits BaseGameController(Of Hue, Command, Sfx, GameState)

    Public Sub New(windowSize As (Integer, Integer), fullScreen As Boolean, volume As Single)
        MyBase.New(windowSize, fullScreen, volume)
        SetState(GameState.Splash, New SplashState(Me, AddressOf SetCurrentState))
        SetCurrentState(GameState.Splash, True)
    End Sub
End Class
