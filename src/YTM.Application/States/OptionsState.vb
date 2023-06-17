Friend Class OptionsState
    Inherits BaseMenuState
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
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
    End Sub
    Protected Overrides Sub HandleMenuItem(menuItem As String)
        Select Case menuItem
            Case GoBackText
                SetState(GameState.MainMenu)
            Case ToggleFullScreenText
                Parent.FullScreen = Not Parent.FullScreen
            Case Else
                Throw New NotImplementedException
        End Select
    End Sub
End Class
