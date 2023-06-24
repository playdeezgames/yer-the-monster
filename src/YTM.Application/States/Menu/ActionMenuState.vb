Friend Class ActionMenuState
    Inherits BaseMenuState
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(
            parent,
            setState,
            ActionMenuTitle,
            {
                GoBackText,
                InventoryText,
                PickUpItemText
            },
            GoBackText)
    End Sub
    Protected Overrides Sub HandleMenuItem(menuItem As String)
        Select Case menuItem
            Case GoBackText
                SetState(GameState.Neutral)
            Case InventoryText
                SetState(GameState.Inventory)
            Case Else
                SetState(GameState.PickUpItem)
        End Select
    End Sub
    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        MyBase.Render(displayBuffer)
        Dim font = Fonts.GetFont(GameFont.Font5x7)
        Dim avatar = World.Avatar
        With font
            Select Case MenuItemText
                Case GoBackText
                    ShowStatusBar(displayBuffer, font, "Never mind...", Hue.Black, Hue.LightGray)
                Case MoveText
                    ShowStatusBar(displayBuffer, font, "I gotta get out of this place!", Hue.Black, Hue.LightGray)
                Case InventoryText
                    If avatar.HasItems Then
                        ShowStatusBar(displayBuffer, font, "View Yer's Items", Hue.Black, Hue.LightGray)
                    Else
                        ShowStatusBar(displayBuffer, font, "Yer has no Items", Hue.Black, Hue.Red)
                    End If
                Case PickUpItemText
                    If avatar.MapCell.HasItem Then
                        ShowStatusBar(displayBuffer, font, avatar.MapCell.Item.Name, Hue.Black, Hue.LightGray)
                    Else
                        ShowStatusBar(displayBuffer, font, "Nothing to pick up!", Hue.Black, Hue.Red)
                    End If
            End Select
        End With
    End Sub
End Class
