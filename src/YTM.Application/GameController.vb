Public Class GameController
    Inherits BaseGameController
    Public Sub New(settings As ISettings)
        MyBase.New(settings)
        Initialize()
        CreateBoilerplateStates()
        SetState(GameState.Neutral, New NeutralState(Me, AddressOf SetCurrentState))
        SetState(GameState.ActionMenu, New ActionMenuState(Me, AddressOf SetCurrentState))
        SetState(GameState.Inventory, New InventoryState(Me, AddressOf SetCurrentState))
        SetState(GameState.Dead, New DeadState(Me, AddressOf SetCurrentState))
        SetState(GameState.Message, New MessageState(Me, AddressOf SetCurrentState))
        SetState(GameState.Navigation, New NavigationState(Me, AddressOf SetCurrentState))
        SetState(GameState.PickUpItem, New PickUpItemState(Me, AddressOf SetCurrentState))
        SetState(GameState.InventoryDetail, New InventoryDetailItemState(Me, AddressOf SetCurrentState))
        SetState(GameState.Fight, New FightState(Me, AddressOf SetCurrentState))
        SetState(GameState.Run, New RunState(Me, AddressOf SetCurrentState))
        SetState(GameState.Attack, New AttackState(Me, AddressOf SetCurrentState))

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
        Settings.Save()
    End Sub
End Class
