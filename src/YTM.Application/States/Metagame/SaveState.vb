Friend Class SaveState
    Inherits BaseMenuState
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(
            parent,
            setState,
            SaveGameTitle,
            {
                GoBackText,
                Slot1Text,
                Slot2Text,
                Slot3Text,
                Slot4Text,
                Slot5Text
            },
            GoBackText)
    End Sub
    Protected Overrides Sub HandleMenuItem(menuItem As String)
        Select Case menuItem
            Case GoBackText
                SetState(GameState.GameMenu)
            Case Else
                Context.SaveToSlot(MenuItemIndex)
                SetState(GameState.GameMenu)
        End Select
    End Sub
    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        MyBase.Render(displayBuffer)
        Dim font = Fonts.GetFont(GameFont.Font5x7)
        If MenuItemIndex > 0 AndAlso Context.DoesSaveExist(MenuItemIndex) Then
            font.WriteText(displayBuffer, (0, ViewHeight - font.Height), "Will overwrite!", Hue.Magenta)
        End If
    End Sub
End Class
