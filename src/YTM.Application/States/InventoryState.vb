Friend Class InventoryState
    Inherits BaseGameState(Of Hue, Command, Sfx, GameState)
    Private _menuItems As New Dictionary(Of String, String)
    Private _menuItemIndex As Integer
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState)
    End Sub
    Public Overrides Sub HandleCommand(command As Command)
        Select Case command
            Case Command.B
                SetState(GameState.Neutral)
        End Select
    End Sub
    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        displayBuffer.Fill((0, 0), (ViewWidth, ViewHeight), Hue.Black)
        Dim font = Fonts.GetFont(GameFont.Font5x7)
        Dim y = ViewHeight \ 2 - font.Height \ 2 - _menuItemIndex * font.Height
        Dim index = 0
        For Each key In _menuItems.Keys
            Dim x = ViewWidth \ 2 - font.TextWidth(key) \ 2
            Dim h = If(index = _menuItemIndex, Hue.Magenta, Hue.Cyan)
            font.WriteText(displayBuffer, (x, y), key, h)
            index += 1
            y += font.Height
        Next
        ShowStatusBar(displayBuffer, font, "Space/(A) - Item Details | Esc/(B) - Go Back", Hue.Black, Hue.White)
    End Sub
    Public Overrides Sub OnStart()
        MyBase.OnStart()
        Dim avatar = World.Avatar
        _menuItems = avatar.Items.GroupBy(Function(x) x.Name).ToDictionary(Function(x) $"{x.Key}(x{x.Count})", Function(x) x.Key)
        _menuItemIndex = 0
    End Sub
End Class
