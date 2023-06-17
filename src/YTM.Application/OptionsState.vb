Friend Class OptionsState
    Inherits BaseGameState(Of Hue, Command, Sfx, GameState)
    Private ReadOnly MenuItems() As String = {GoBackText, ToggleFullScreenText, SetWindowSizeText, SetVolumeText}
    Private MenuItemIndex As Integer = 0
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState)
    End Sub
    Public Overrides Sub HandleCommand(command As Command)
        Select Case command
            Case Command.Up
                MenuItemIndex = (MenuItemIndex + MenuItems.Length - 1) Mod MenuItems.Length
            Case Command.Down
                MenuItemIndex = (MenuItemIndex + 1) Mod MenuItems.Length
            Case Command.A
                HandleMenuItem(MenuItems(MenuItemIndex))
            Case Command.B
                HandleMenuItem(GoBackText)
        End Select
    End Sub

    Private Sub HandleMenuItem(menuItem As String)
        Select Case menuItem
            Case GoBackText
                SetState(GameState.MainMenu)
            Case ToggleFullScreenText
                Parent.FullScreen = Not Parent.FullScreen
            Case Else
                Throw New NotImplementedException
        End Select
    End Sub

    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        displayBuffer.Fill((0, 0), (ViewWidth, ViewHeight), Hue.Black)
        Dim font = Fonts.GetFont(GameFont.Font5x7)
        With font
            .WriteText(displayBuffer, (0, 0), OptionsTitle, Hue.White)
            Dim y = font.Height
            For index = 0 To MenuItems.Length - 1
                .WriteText(displayBuffer, (0, y), MenuItems(index), If(index = MenuItemIndex, Hue.Magenta, Hue.Cyan))
                y += font.Height
            Next
        End With
    End Sub
End Class
