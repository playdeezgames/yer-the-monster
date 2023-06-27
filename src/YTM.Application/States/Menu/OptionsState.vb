Friend Class OptionsState
    Inherits BaseMenuState
    Private ReadOnly _saveConfig As Action
    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), saveConfig As Action)
        MyBase.New(
            parent,
            setState,
            OptionsTitle,
            {
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
                PopState()
            Case ToggleFullScreenText
                Parent.FullScreen = Not Parent.FullScreen
                _saveConfig()
            Case SetWindowSizeText
                SetState(GameState.WindowSize)
            Case SetVolumeText
                SetState(GameState.Volume)
            Case Else
                Throw New NotImplementedException
        End Select
    End Sub
    Public Overrides Sub Render(displayBuffer As IPixelSink)
        Title = _table(MenuItemText)
        MyBase.Render(displayBuffer)
        ShowStatusBar(displayBuffer, Context.UIFont, ControlsText("Select", "Cancel"), Hue.Black, Hue.LightGray)
    End Sub
    Private ReadOnly _table As IReadOnlyDictionary(Of String, String) =
        New Dictionary(Of String, String) From
        {
                {ToggleFullScreenText, "Beware of non-standard display modes!"},
                {SetWindowSizeText, "Mebbe just make the window bigger?"},
                {SetVolumeText, "If it is too loud, yer too old!"}
        }
End Class
