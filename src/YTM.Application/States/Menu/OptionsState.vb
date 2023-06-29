Friend Class OptionsState
    Inherits BasePickerState
    Public Sub New(
                  parent As IGameController,
                  setState As Action(Of String, Boolean),
                  fontSource As IFontSource)
        MyBase.New(parent, setState, fontSource, "Options", ControlsText("Select", "Cancel"), Nothing)
    End Sub

    Protected Overrides Sub OnActivateMenuItem(value As (String, String))
        Select Case value.Item2
            Case ToggleFullScreenText
                Parent.FullScreen = Not Parent.FullScreen
                SaveConfig()
            Case SetWindowSizeText
                SetState(GameState.WindowSize)
            Case SetVolumeText
                SetState(GameState.Volume)
            Case Else
                Throw New NotImplementedException
        End Select
    End Sub
    Protected Overrides Function InitializeMenuItems() As List(Of (String, String))
        Return New List(Of (String, String)) From
            {
                (ToggleFullScreenText, ToggleFullScreenText),
                (SetWindowSizeText, SetWindowSizeText),
                (SetVolumeText, SetVolumeText)
            }
    End Function
End Class
