Public Class GameController
    Inherits BaseGameController(Of Hue, Command, Sfx, GameState)
    Private ReadOnly _configSink As Action(Of (Integer, Integer), Boolean, Single)
    Public Sub New(windowSize As (Integer, Integer), fullScreen As Boolean, volume As Single, configSink As Action(Of (Integer, Integer), Boolean, Single))
        MyBase.New(windowSize, fullScreen, volume)
        _configSink = configSink
        _configSink(Me.Size, Me.FullScreen, Me.Volume)
        Initialize()
        CreateBoilerplateStates()
        SetState(GameState.Neutral, New NeutralState(Me, AddressOf SetCurrentState))
        SetState(GameState.ActionMenu, New ActionMenuState(Me, AddressOf SetCurrentState))
        SetState(GameState.Inventory, New InventoryState(Me, AddressOf SetCurrentState))
        SetState(GameState.Dead, New DeadState(Me, AddressOf SetCurrentState))
        SetState(GameState.Message, New MessageState(Me, AddressOf SetCurrentState))
        SetState(GameState.Navigation, New NavigationState(Me, AddressOf SetCurrentState))

        SetCurrentState(GameState.Splash, True)
    End Sub

    Private Sub CreateBoilerplateStates()
        SetState(GameState.Splash, New SplashState(Me, AddressOf SetCurrentState))
        SetState(GameState.MainMenu, New MainMenuState(Me, AddressOf SetCurrentState))
        SetState(GameState.ConfirmQuit, New ConfirmQuitState(Me, AddressOf SetCurrentState))
        SetState(GameState.Options, New OptionsState(Me, AddressOf SetCurrentState, AddressOf SaveConfig))
        SetState(GameState.WindowSize, New WindowSizeState(Me, AddressOf SetCurrentState, AddressOf SaveConfig))
        SetState(GameState.Volume, New VolumeState(Me, AddressOf SetCurrentState, AddressOf SaveConfig))
        SetState(GameState.About, New AboutState(Me, AddressOf SetCurrentState))
        SetState(GameState.Embark, New EmbarkState(Me, AddressOf SetCurrentState))
        SetState(GameState.Load, New LoadState(Me, AddressOf SetCurrentState))
        SetState(GameState.GameMenu, New GameMenuState(Me, AddressOf SetCurrentState))
        SetState(GameState.Abandon, New ConfirmAbandonState(Me, AddressOf SetCurrentState))
        SetState(GameState.Save, New SaveState(Me, AddressOf SetCurrentState))
    End Sub

    Private Sub SaveConfig()
        _configSink(Size, FullScreen, Volume)
    End Sub
End Class
