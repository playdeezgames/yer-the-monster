Friend Class SplashState
    Inherits BaseGameState(Of Hue, Command, Sfx, GameState)
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState)
    End Sub

    Public Overrides Sub HandleCommand(command As Command)
        Select Case command
            Case Command.A
                SetState(GameState.MainMenu)
        End Select
    End Sub
    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
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
