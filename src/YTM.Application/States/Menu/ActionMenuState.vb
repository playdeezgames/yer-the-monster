Friend Class ActionMenuState
    Inherits BaseMenuState
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(
            parent,
            setState,
            ActionMenuTitle,
            {
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
            ShowStatusBar(displayBuffer, font, "Space/(A) - Select | Esc/(B) - Go back", Hue.Black, Hue.LightGray)
        End With
    End Sub
End Class
