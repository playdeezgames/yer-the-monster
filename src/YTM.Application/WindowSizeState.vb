Friend Class WindowSizeState
    Inherits BaseMenuState

    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(
            parent,
            setState,
            WindowSizeTitle,
            {
                GoBackText,
                Scale1Text,
                Scale2Text,
                Scale3Text,
                Scale4Text,
                Scale5Text,
                Scale6Text,
                Scale7Text,
                Scale8Text,
                Scale9Text,
                Scale10Text
            },
            GoBackText)
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
        End Select
    End Sub
    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        MyBase.Render(displayBuffer)
        Dim font = Fonts.GetFont(GameFont.Font5x7)
        font.WriteText(displayBuffer, (0, ViewHeight - font.Height), $"Current Size: {Parent.Size.Item1}x{Parent.Size.Item2}", Hue.White)
    End Sub
End Class
