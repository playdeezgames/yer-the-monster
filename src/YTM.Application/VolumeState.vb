Friend Class VolumeState
    Inherits BaseMenuState

    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
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
    End Sub

    Protected Overrides Sub HandleMenuItem(menuItem As String)
        Select Case menuItem
            Case GoBackText
                SetState(GameState.Options)
            Case Volume0Text
                Parent.Volume = 0.0F
                PlaySfx(Sfx.PlayerHit)
            Case Volume1Text
                Parent.Volume = 0.1F
                PlaySfx(Sfx.PlayerHit)
            Case Volume2Text
                Parent.Volume = 0.2F
                PlaySfx(Sfx.PlayerHit)
            Case Volume3Text
                Parent.Volume = 0.3F
                PlaySfx(Sfx.PlayerHit)
            Case Volume4Text
                Parent.Volume = 0.4F
                PlaySfx(Sfx.PlayerHit)
            Case Volume5Text
                Parent.Volume = 0.5F
                PlaySfx(Sfx.PlayerHit)
            Case Volume6Text
                Parent.Volume = 0.6F
                PlaySfx(Sfx.PlayerHit)
            Case Volume7Text
                Parent.Volume = 0.7F
                PlaySfx(Sfx.PlayerHit)
            Case Volume8Text
                Parent.Volume = 0.8F
                PlaySfx(Sfx.PlayerHit)
            Case Volume9Text
                Parent.Volume = 0.9F
                PlaySfx(Sfx.PlayerHit)
            Case Volume10Text
                Parent.Volume = 1.0F
                PlaySfx(Sfx.PlayerHit)
        End Select
    End Sub
    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        MyBase.Render(displayBuffer)
        Dim font = Fonts.GetFont(GameFont.Font5x7)
        font.WriteText(displayBuffer, (0, ViewHeight - font.Height), $"Current Volume: {Parent.Volume * 100.0F:F0}%", Hue.White)
    End Sub
End Class
