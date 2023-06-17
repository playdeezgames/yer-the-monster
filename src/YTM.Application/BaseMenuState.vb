Friend MustInherit Class BaseMenuState
    Inherits BaseGameState(Of Hue, Command, Sfx, GameState)
    Private ReadOnly MenuItems As String()
    Private MenuItemIndex As Integer = 0
    Private ReadOnly CancelMenuItem As String
    Private ReadOnly Title As String
    Public Sub New(
                  parent As IGameController(Of Hue, Command, Sfx),
                  setState As Action(Of GameState?, Boolean),
                  title As String,
                  menuItems As String(),
                  cancelMenuItem As String)
        MyBase.New(parent, setState)
        Me.Title = title
        Me.MenuItems = menuItems
        Me.CancelMenuItem = cancelMenuItem
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
                HandleMenuItem(CancelMenuItem)
        End Select
    End Sub
    Protected MustOverride Sub HandleMenuItem(menuItem As String)
    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        displayBuffer.Fill((0, 0), (ViewWidth, ViewHeight), Hue.Black)
        Dim font = Fonts.GetFont(GameFont.Font5x7)
        With font
            .WriteText(displayBuffer, (0, 0), Title, Hue.White)
            Dim y = font.Height
            For index = 0 To MenuItems.Length - 1
                .WriteText(displayBuffer, (0, y), MenuItems(index), If(index = MenuItemIndex, Hue.Magenta, Hue.Cyan))
                y += font.Height
            Next
        End With
    End Sub
End Class
