Public MustInherit Class BasePickerState
    Inherits BaseGameState
    Private _menuItems As New List(Of (String, String))
    Private _menuItemIndex As Integer
    Private ReadOnly _statusBarText As String
    Protected Property HeaderText As String
    Private ReadOnly _cancelGameState As String
    Public Sub New(
                  parent As IGameController,
                  setState As Action(Of String, Boolean),
                  fontSource As IUIContext,
                  headerText As String,
                  statusBarText As String,
                  cancelGameState As String)
        MyBase.New(parent, setState, fontSource)
        _statusBarText = statusBarText
        _cancelGameState = cancelGameState
        Me.HeaderText = headerText
    End Sub
    Public Overrides Sub HandleCommand(cmd As String)
        Select Case cmd
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
    Public Overrides Sub Render(displayBuffer As IPixelSink)
        displayBuffer.Fill((0, 0), (ViewWidth, ViewHeight), Hue.Black)
        Dim font = FontSource.Font(GameFont.Font5x7)
        displayBuffer.Fill((0, ViewHeight \ 2 - font.Height \ 2), (ViewWidth, font.Height), Hue.Blue)
        Dim y = ViewHeight \ 2 - font.Height \ 2 - _menuItemIndex * font.Height
        Dim index = 0
        For Each menuItem In _menuItems
            Dim x = ViewWidth \ 2 - font.TextWidth(menuItem.Item1) \ 2
            Dim h = If(index = _menuItemIndex, Hue.Black, Hue.Blue)
            font.WriteText(displayBuffer, (x, y), menuItem.Item1, h)
            index += 1
            y += font.Height
        Next
        ShowHeader(displayBuffer, font, HeaderText, Hue.Orange, Hue.Black)
        ShowStatusBar(displayBuffer, font, _statusBarText, Hue.Black, Hue.LightGray)
    End Sub
    Public Overrides Sub OnStart()
        _menuItems = InitializeMenuItems()
        _menuItemIndex = 0
    End Sub
    Protected MustOverride Function InitializeMenuItems() As List(Of (String, String))
End Class
