Public Class GameController
    Inherits BaseGameController(Of Hue, Command, Sfx, GameState)
    Private ReadOnly _configSink As Action(Of (Integer, Integer), Boolean, Single)
    Public Sub New(windowSize As (Integer, Integer), fullScreen As Boolean, volume As Single, configSink As Action(Of (Integer, Integer), Boolean, Single))
        MyBase.New(windowSize, fullScreen, volume)
        _configSink = configSink
        _configSink(Me.Size, Me.FullScreen, Me.Volume)
        Initialize()
        SetState(GameState.Splash, New SplashState(Me, AddressOf SetCurrentState))
        SetState(GameState.MainMenu, New MainMenuState(Me, AddressOf SetCurrentState))
        SetState(GameState.ConfirmQuit, New ConfirmQuitState(Me, AddressOf SetCurrentState))
        SetState(GameState.Options, New OptionsState(Me, AddressOf SetCurrentState))
        SetState(GameState.WindowSize, New WindowSizeState(Me, AddressOf SetCurrentState))
        SetState(GameState.Volume, New VolumeState(Me, AddressOf SetCurrentState))
        SetState(GameState.About, New AboutState(Me, AddressOf SetCurrentState))

        SetCurrentState(GameState.Splash, True)
    End Sub
End Class
