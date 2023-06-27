Public Class GameController
    Inherits BaseGameController
    Public Sub New(settings As ISettings, fontSource As IFontSource)
        MyBase.New(settings)
        Initialize()
        CreateBoilerplateStates(fontSource)
        SetState(GameState.Neutral, New NeutralState(Me, AddressOf SetCurrentState, fontSource))
        SetState(GameState.ActionMenu, New ActionMenuState(Me, AddressOf SetCurrentState, fontSource))
        SetState(GameState.Inventory, New InventoryState(Me, AddressOf SetCurrentState, fontSource))
        SetState(GameState.Dead, New DeadState(Me, AddressOf SetCurrentState, fontSource))
        SetState(GameState.Message, New MessageState(Me, AddressOf SetCurrentState, fontSource))
        SetState(GameState.Navigation, New NavigationState(Me, AddressOf SetCurrentState, fontSource))
        SetState(GameState.PickUpItem, New PickUpItemState(Me, AddressOf SetCurrentState, fontSource))
        SetState(GameState.InventoryDetail, New InventoryDetailItemState(Me, AddressOf SetCurrentState, fontSource))
        SetState(GameState.Fight, New FightState(Me, AddressOf SetCurrentState, fontSource))
        SetState(GameState.Run, New RunState(Me, AddressOf SetCurrentState, fontSource))
        SetState(GameState.Attack, New AttackState(Me, AddressOf SetCurrentState, fontSource))

        SetCurrentState(GameState.Splash, True)
    End Sub

    Private Sub CreateBoilerplateStates(fontSource As IFontSource)
        SetState(GameState.Splash, New SplashState(Me, AddressOf SetCurrentState, fontSource))
        SetState(GameState.MainMenu, New MainMenuState(Me, AddressOf SetCurrentState, fontSource))
        SetState(GameState.ConfirmQuit, New ConfirmQuitState(Me, AddressOf SetCurrentState, fontSource))
        SetState(GameState.Options, New OptionsState(Me, AddressOf SetCurrentState, fontSource, AddressOf SaveConfig))
        SetState(GameState.WindowSize, New WindowSizeState(Me, AddressOf SetCurrentState, fontSource, AddressOf SaveConfig))
        SetState(GameState.Volume, New VolumeState(Me, AddressOf SetCurrentState, fontSource, AddressOf SaveConfig))
        SetState(GameState.About, New AboutState(Me, AddressOf SetCurrentState, fontSource))
        SetState(GameState.Embark, New EmbarkState(Me, AddressOf SetCurrentState, fontSource))
        SetState(GameState.Load, New LoadState(Me, AddressOf SetCurrentState, fontSource))
        SetState(GameState.GameMenu, New GameMenuState(Me, AddressOf SetCurrentState, fontSource))
        SetState(GameState.Abandon, New ConfirmAbandonState(Me, AddressOf SetCurrentState, fontSource))
        SetState(GameState.Save, New SaveState(Me, AddressOf SetCurrentState, fontSource))
    End Sub

    Private Sub SaveConfig()
        Settings.Save()
    End Sub
End Class
