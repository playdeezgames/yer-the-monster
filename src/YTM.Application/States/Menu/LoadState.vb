Friend Class LoadState
    Inherits BaseMenuState
    Public Sub New(parent As IGameController(Of Hue), setState As Action(Of GameState?, Boolean))
        MyBase.New(
            parent,
            setState,
            LoadTitle,
            {
                Slot1Text,
                Slot2Text,
                Slot3Text,
                Slot4Text,
                Slot5Text
            },
            GoBackText)
    End Sub
    Private ReadOnly Property SlotIndex As Integer
        Get
            Return MenuItemIndex + 1
        End Get
    End Property
    Protected Overrides Sub HandleMenuItem(menuItem As String)
        Select Case menuItem
            Case GoBackText
                SetState(GameState.MainMenu)
            Case Else
                If DoesSaveExist(SlotIndex) Then
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
        If DoesSaveExist(SlotIndex) Then
            ShowHeader(displayBuffer, font, SaveSlotExistsText, Hue.Black, Hue.LightGray)
        Else
            ShowHeader(displayBuffer, font, SaveSlotDoesNotExistText, Hue.Black, Hue.Red)
        End If
        ShowStatusBar(displayBuffer, font, ControlsText("Load", "Cancel"), Hue.Black, Hue.LightGray)
    End Sub
End Class
