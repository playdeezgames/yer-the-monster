Public MustInherit Class BasePickerState
    Inherits BaseGameState(Of Hue, Command, Sfx, GameState)
    Private _menuItems As New List(Of (String, String))
    Private _menuItemIndex As Integer
    Private ReadOnly _statusBarText As String
    Private ReadOnly _cancelGameState As GameState
    Public Sub New(
                  parent As IGameController(Of Hue, Command, Sfx),
                  setState As Action(Of GameState?, Boolean),
                  statusBarText As String,
                  cancelGameState As GameState)
        MyBase.New(parent, setState)
        _statusBarText = statusBarText
        _cancelGameState = cancelGameState
    End Sub
    Public Overrides Sub HandleCommand(command As Command)
        Select Case command
            Case Command.B
                SetState(_cancelGameState)
            Case Command.A
                OnActivateMenuItem(_menuItems(_menuItemIndex))
            Case Command.Up
                _menuItemIndex = (_menuItemIndex + _menuItems.Count - 1) Mod _menuItems.Count
            Case Command.Down
                _menuItemIndex = (_menuItemIndex + 1) Mod _menuItems.Count
        End Select
    End Sub
    Protected MustOverride Sub OnActivateMenuItem(value As (String, String))
    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        displayBuffer.Fill((0, 0), (ViewWidth, ViewHeight), Hue.Black)
        Dim font = Fonts.GetFont(GameFont.Font5x7)
        Dim y = ViewHeight \ 2 - font.Height \ 2 - _menuItemIndex * font.Height
        Dim index = 0
        For Each menuItem In _menuItems
            Dim x = ViewWidth \ 2 - font.TextWidth(menuItem.Item1) \ 2
            Dim h = If(index = _menuItemIndex, Hue.Magenta, Hue.Cyan)
            font.WriteText(displayBuffer, (x, y), menuItem.Item1, h)
            index += 1
            y += font.Height
        Next
        ShowStatusBar(displayBuffer, font, _statusBarText, Hue.Black, Hue.White)
    End Sub
    Public Overrides Sub OnStart()
        _menuItems = InitializeMenuItems()
        _menuItemIndex = 0
    End Sub
    Protected MustOverride Function InitializeMenuItems() As List(Of (String, String))
End Class
