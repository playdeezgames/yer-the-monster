Public Class GameController
    Inherits BaseGameController
    Public Sub New(settings As ISettings, context As IUIContext)
        MyBase.New(settings, context)
        Initialize()
        CreateBoilerplateStates(context)
        SetState(GameState.Neutral, New NeutralState(Me, AddressOf SetCurrentState, context))
        SetState(GameState.ActionMenu, New ActionMenuState(Me, AddressOf SetCurrentState, context))
        SetState(GameState.Inventory, New InventoryState(Me, AddressOf SetCurrentState, context))
        SetState(GameState.Dead, New DeadState(Me, AddressOf SetCurrentState, context))
        SetState(GameState.Message, New MessageState(Me, AddressOf SetCurrentState, context))
        SetState(GameState.Navigation, New NavigationState(Me, AddressOf SetCurrentState, context))
        SetState(GameState.PickUpItem, New PickUpItemState(Me, AddressOf SetCurrentState, context))
        SetState(GameState.InventoryDetail, New InventoryDetailItemState(Me, AddressOf SetCurrentState, context))
        SetState(GameState.Fight, New FightState(Me, AddressOf SetCurrentState, context))
        SetState(GameState.Run, New RunState(Me, AddressOf SetCurrentState, context))
        SetState(GameState.Attack, New AttackState(Me, AddressOf SetCurrentState, context))

        SetCurrentState(BoilerplateState.Splash, True)
    End Sub

    Private Sub CreateBoilerplateStates(context As IUIContext)
        SetState(BoilerplateState.ConfirmQuit, New ConfirmQuitState(Me, AddressOf SetCurrentState, context))
        SetState(BoilerplateState.Options, New OptionsState(Me, AddressOf SetCurrentState, context))
        SetState(GameState.WindowSize, New WindowSizeState(Me, AddressOf SetCurrentState, context))
        SetState(GameState.Volume, New VolumeState(Me, AddressOf SetCurrentState, context))
        SetState(BoilerplateState.About, New AboutState(Me, AddressOf SetCurrentState, context))
        SetState(BoilerplateState.Embark, New EmbarkState(Me, AddressOf SetCurrentState, context))
        SetState(BoilerplateState.Load, New LoadState(Me, AddressOf SetCurrentState, context))
        SetState(GameState.GameMenu, New GameMenuState(Me, AddressOf SetCurrentState, context))
        SetState(GameState.Abandon, New ConfirmAbandonState(Me, AddressOf SetCurrentState, context))
        SetState(GameState.Save, New SaveState(Me, AddressOf SetCurrentState, context))
    End Sub
End Class
