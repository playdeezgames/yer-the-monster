Friend Class WindowSizeState
    Inherits BaseMenuState
    Private _saveConfig As Action
    Public Sub New(parent As IGameController(Of Hue), setState As Action(Of String, Boolean), saveConfig As Action)
        MyBase.New(
            parent,
            setState,
            WindowSizeTitle,
            {
                Scale1Text,
                Scale2Text,
                Scale3Text,
                Scale4Text,
                Scale5Text,
                Scale6Text,
                Scale7Text,
                Scale8Text,
                Scale9Text,
                Scale10Text,
                Scale11Text,
                Scale12Text
            },
            GoBackText)
        _saveConfig = saveConfig
    End Sub
    Protected Overrides Sub HandleMenuItem(menuItem As String)
        Select Case menuItem
            Case GoBackText
                SetState(GameState.Options)
            Case Else
                Dim tokens = menuItem.Split("x"c)
                Dim width = CInt(tokens(0))
                Dim height = CInt(tokens(1))
                Parent.Size = (width, height)
                _saveConfig()
        End Select
    End Sub
    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        MyBase.Render(displayBuffer)
        Dim font = Fonts.GetFont(GameFont.Font5x7)
        Title = $"Window Size: {Parent.Size.Item1}x{Parent.Size.Item2}"
        ShowStatusBar(displayBuffer, font, ControlsText("Choose", "Cancel"), Hue.Black, Hue.LightGray)
    End Sub
End Class
