﻿Friend MustInherit Class BaseMenuState
    Inherits BaseGameState(Of Hue, Command, Sfx, GameState)
    Private ReadOnly _menuItems As String()
    Private _menuItemIndex As Integer = 0
    Private ReadOnly _cancelMenuItem As String
    Private ReadOnly _title As String
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
                  parent As IGameController(Of Hue, Command, Sfx),
                  setState As Action(Of GameState?, Boolean),
                  title As String,
                  menuItems As String(),
                  cancelMenuItem As String)
        MyBase.New(parent, setState)
        Me._title = title
        Me._menuItems = menuItems
        Me._cancelMenuItem = cancelMenuItem
    End Sub
    Public Overrides Sub HandleCommand(command As Command)
        Select Case command
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
            .WriteText(displayBuffer, (0, 0), _title, Hue.White)
            Dim y = font.Height
            For index = 0 To _menuItems.Length - 1
                .WriteText(displayBuffer, (0, y), _menuItems(index), If(index = _menuItemIndex, Hue.Purple, Hue.Cyan))
                y += font.Height
            Next
        End With
    End Sub
End Class
