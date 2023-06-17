Friend MustInherit Class BaseMenuState
    Inherits BaseGameState(Of Hue, Command, Sfx, GameState)
    Private ReadOnly MenuItems As String()
    Private MenuItemIndex As Integer = 0
    Private CancelMenuItem As String
    Public Sub New(
                  parent As IGameController(Of Hue, Command, Sfx),
                  setState As Action(Of GameState?, Boolean),
                  menuItems As String(),
                  cancelMenuItem As String)
        MyBase.New(parent, setState)
        Me.MenuItems = menuItems
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
End Class
