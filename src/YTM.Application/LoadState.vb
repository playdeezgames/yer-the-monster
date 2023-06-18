Friend Class LoadState
    Inherits BaseMenuState
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(
            parent,
            setState,
            LoadTitle,
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
                SetState(GameState.MainMenu)
            Case Else
                If DoesSaveExist(MenuItemIndex) Then
                    Context.LoadFromSlot(MenuItemIndex)
                    SetState(GameState.Neutral)
                Else
                    PlaySfx(Sfx.Shucks)
                End If
        End Select
    End Sub
    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        MyBase.Render(displayBuffer)
        Dim font = Fonts.GetFont(GameFont.Font5x7)
        If MenuItemIndex > 0 Then
            If DoesSaveExist(MenuItemIndex) Then
                font.WriteText(displayBuffer, (0, ViewHeight - font.Height), SaveSlotExistsText, Hue.Cyan)
            Else
                font.WriteText(displayBuffer, (0, ViewHeight - font.Height), SaveSlotDoesNotExistText, Hue.Magenta)
            End If
        End If
    End Sub
End Class
