﻿Friend Class GameMenuState
    Inherits BasePickerState
    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), context As IUIContext)
        MyBase.New(parent, setState, context, "Game Menu", ControlsText("Select", "Cancel"), GameState.Neutral)
    End Sub
    Protected Overrides Sub OnActivateMenuItem(value As (String, String))
        Select Case value.Item2
            Case ContinueGameText
                SetState(GameState.Neutral)
            Case SaveGameText
                SetState(GameState.Save)
            Case OptionsText
                SetStates(BoilerplateState.Options, GameState.GameMenu)
            Case AbandonGameText
                SetState(GameState.Abandon)
        End Select
    End Sub
    Protected Overrides Function InitializeMenuItems() As List(Of (String, String))
        Return New List(Of (String, String)) From
            {
                (ContinueGameText, ContinueGameText),
                (SaveGameText, SaveGameText),
                (OptionsText, OptionsText),
                (AbandonGameText, AbandonGameText)
            }
    End Function
End Class
