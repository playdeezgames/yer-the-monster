Friend Class ActionMenuState
    Inherits BaseMenuState
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(
            parent,
            setState,
            ActionMenuTitle,
            {
                GoBackText,
                InventoryText
            },
            GoBackText)
    End Sub
    Protected Overrides Sub HandleMenuItem(menuItem As String)
        Select Case menuItem
            Case GoBackText
                SetState(GameState.Neutral)
            Case InventoryText
                'SetState(GameState.Inventory)
            Case Else
                Throw New NotImplementedException
        End Select
    End Sub
    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        MyBase.Render(displayBuffer)
        Dim font = Fonts.GetFont(GameFont.Font5x7)
        Dim avatar = World.Avatar
        With font
            Select Case MenuItemText
                Case InventoryText
                    If avatar.HasItems Then
                        .WriteText(displayBuffer, (0, ViewHeight - font.Height), "View Yer's Items", Hue.White)
                    Else
                        .WriteText(displayBuffer, (0, ViewHeight - font.Height), "Yer has no Items", Hue.Magenta)
                    End If
            End Select
        End With
    End Sub
End Class
