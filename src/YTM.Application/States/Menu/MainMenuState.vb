Friend Class MainMenuState
    Inherits BasePickerState
    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), context As IUIContext)
        MyBase.New(parent, setState, context, "Main Menu", ControlsText("Select", "Quit"), GameState.ConfirmQuit)
    End Sub

    Protected Overrides Sub OnActivateMenuItem(value As (String, String))
        Select Case value.Item2
            Case QuitText
                SetState(GameState.ConfirmQuit)
            Case OptionsText
                SetStates(GameState.Options, BoilerplateState.MainMenu)
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

    Protected Overrides Function InitializeMenuItems() As List(Of (String, String))
        Return New List(Of (String, String)) From
            {
                (EmbarkText, EmbarkText),
                (LoadText, LoadText),
                (OptionsText, OptionsText),
                (AboutText, AboutText),
                (QuitText, QuitText)
            }
    End Function
End Class
