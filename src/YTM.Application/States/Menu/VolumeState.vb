Friend Class VolumeState
    Inherits BaseMenuState
    Private _saveConfig As Action
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean), saveConfig As Action)
        MyBase.New(
            parent,
            setState,
            VolumeTitle,
            {
                GoBackText,
                Volume0Text,
                Volume1Text,
                Volume2Text,
                Volume3Text,
                Volume4Text,
                Volume5Text,
                Volume6Text,
                Volume7Text,
                Volume8Text,
                Volume10Text
            },
            GoBackText)
        _saveConfig = saveConfig
    End Sub

    Protected Overrides Sub HandleMenuItem(menuItem As String)
        Select Case menuItem
            Case GoBackText
                SetState(GameState.Options)
            Case Volume0Text
                SetVolume(0.0F)
            Case Volume1Text
                SetVolume(0.1F)
            Case Volume2Text
                SetVolume(0.2F)
            Case Volume3Text
                SetVolume(0.3F)
            Case Volume4Text
                SetVolume(0.4F)
            Case Volume5Text
                SetVolume(0.5F)
            Case Volume6Text
                SetVolume(0.6F)
            Case Volume7Text
                SetVolume(0.7F)
            Case Volume8Text
                SetVolume(0.8F)
            Case Volume9Text
                SetVolume(0.9F)
            Case Volume10Text
                SetVolume(1.0F)
        End Select
    End Sub
    Private Sub SetVolume(newVolume As Single)
        Parent.Volume = newVolume
        PlaySfx(Sfx.PlayerHit)
        _saveConfig()
    End Sub
    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        MyBase.Render(displayBuffer)
        Dim font = Fonts.GetFont(GameFont.Font5x7)
        ShowStatusBar(displayBuffer, font, $"Current Volume: {Parent.Volume * 100.0F:F0}%", Hue.Black, Hue.LightGray)
    End Sub
End Class
