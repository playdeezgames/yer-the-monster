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
        If MenuItemIndex > 0 Then
            If Context.DoesSaveExist(MenuItemIndex) Then
                ShowStatusBar(displayBuffer, font, "Will overwrite!", Hue.Black, Hue.Red)
            Else
                ShowStatusBar(displayBuffer, font, "This slot is empty!", Hue.Black, Hue.LightGray)
            End If
        Else
            ShowStatusBar(displayBuffer, font, "On second thought...", Hue.Black, Hue.LightGray)
        End If
    End Sub
End Class
