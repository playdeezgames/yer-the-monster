Friend Class SaveState
    Inherits BaseMenuState
    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), fontSource As IFontSource)
        MyBase.New(
            parent,
            setState,
            fontSource,
            "",
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
                SetState(GameState.GameMenu)
            Case Else
                Context.SaveToSlot(SlotIndex)
                SetState(GameState.GameMenu)
        End Select
    End Sub
    Public Overrides Sub Render(displayBuffer As IPixelSink)
        MyBase.Render(displayBuffer)
        Dim font = Fonts.GetFont(GameFont.Font5x7)
        If Context.DoesSaveExist(SlotIndex) Then
            ShowHeader(displayBuffer, font, "Will overwrite!", Hue.Black, Hue.Red)
        Else
            ShowHeader(displayBuffer, font, "This slot is empty!", Hue.Black, Hue.LightGray)
        End If
        ShowStatusBar(displayBuffer, font, ControlsText("Save/Overwrite", "Cancel"), Hue.Black, Hue.LightGray)
    End Sub
End Class
