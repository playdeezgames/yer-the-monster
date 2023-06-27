Friend Class SplashState
    Inherits BaseGameState
    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), fontSource As IFontSource)
        MyBase.New(parent, setState, fontSource)
    End Sub

    Public Overrides Sub HandleCommand(cmd As String)
        Select Case cmd
            Case Command.A
                SetState(GameState.MainMenu)
        End Select
    End Sub
    Public Overrides Sub Render(displayBuffer As IPixelSink)
        displayBuffer.Fill((0, 0), (ViewWidth, ViewHeight), Hue.Black)
        Dim font = UIFont()
        With font
            .WriteText(displayBuffer, (0, 0), "A Game in VB.NET About", Hue.Orange)
            .WriteText(displayBuffer, (0, font.Height), "Yer, the Monster,", Hue.Orange)
            .WriteText(displayBuffer, (0, font.Height * 2), "and Starting with Nothing", Hue.Orange)
            .WriteText(displayBuffer, (0, font.Height * 4), "A Production of TheGrumpyGameDev", Hue.Tan)
            .WriteText(displayBuffer, (0, font.Height * 6), "For ""Learn You a Game Jam: Pixel Edition""", Hue.Brown)

            ShowStatusBar(displayBuffer, font, "Space/(A)", Hue.Black, Hue.LightGray)
        End With
        font = Fonts.GetFont(GameFont.YTM)
    End Sub
End Class
