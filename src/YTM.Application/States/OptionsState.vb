Friend Class OptionsState
    Inherits BaseMenuState
    Private _saveConfig As Action
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean), saveConfig As Action)
        MyBase.New(
            parent,
            setState,
            OptionsTitle,
            {
                GoBackText,
                ToggleFullScreenText,
                SetWindowSizeText,
                SetVolumeText
            },
            GoBackText)
        _saveConfig = saveConfig
    End Sub
    Protected Overrides Sub HandleMenuItem(menuItem As String)
        Select Case menuItem
            Case GoBackText
                SetState(GameState.MainMenu)
            Case ToggleFullScreenText
                Parent.FullScreen = Not Parent.FullScreen
            Case SetWindowSizeText
                SetState(GameState.WindowSize)
            Case SetVolumeText
                SetState(GameState.Volume)
            Case Else
                Throw New NotImplementedException
        End Select
    End Sub
End Class
