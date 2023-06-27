Friend MustInherit Class BaseMenuState
    Inherits BaseGameState(Of Hue)
    Private ReadOnly _menuItems As String()
    Private _menuItemIndex As Integer = 0
    Private ReadOnly _cancelMenuItem As String
    Protected Property Title As String
    Protected ReadOnly Property MenuItemIndex As Integer
        Get
            Return _menuItemIndex
        End Get
    End Property
    Protected ReadOnly Property MenuItemText As String
        Get
            Return _menuItems(MenuItemIndex)
        End Get
    End Property
    Public Sub New(
                  parent As IGameController(Of Hue),
                  setState As Action(Of String, Boolean),
                  title As String,
                  menuItems As String(),
                  cancelMenuItem As String)
        MyBase.New(parent, setState)
        Me.Title = title
        Me._menuItems = menuItems
        Me._cancelMenuItem = cancelMenuItem
    End Sub
    Public Overrides Sub HandleCommand(cmd As String)
        Select Case cmd
            Case Command.Up
                _menuItemIndex = (_menuItemIndex + _menuItems.Length - 1) Mod _menuItems.Length
            Case Command.Down
                _menuItemIndex = (_menuItemIndex + 1) Mod _menuItems.Length
            Case Command.A
                HandleMenuItem(MenuItemText)
            Case Command.B
                HandleMenuItem(_cancelMenuItem)
        End Select
    End Sub
    Protected MustOverride Sub HandleMenuItem(menuItem As String)
    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        displayBuffer.Fill((0, 0), (ViewWidth, ViewHeight), Hue.Black)
        Dim font = Fonts.GetFont(GameFont.Font5x7)
        With font
            .WriteText(displayBuffer, (0, 0), Title, Hue.Orange)
            Dim y = font.Height
            For index = 0 To _menuItems.Length - 1
                .WriteText(displayBuffer, (0, y), _menuItems(index), If(index = _menuItemIndex, Hue.LightBlue, Hue.Blue))
                y += font.Height
            Next
        End With
    End Sub
End Class
