Friend Class SplashState
    Inherits BaseGameState(Of Hue, Command, Sfx, GameState)
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState)
    End Sub

    Public Overrides Sub HandleCommand(command As Command)
    End Sub
    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        displayBuffer.Fill((0, 0), (ViewWidth, ViewHeight), Hue.Black)
        Dim font = Fonts.GetFont(GameFont.Font5x7)
        With font
            .WriteText(displayBuffer, (0, 0), "A Game in VB.NET About", Hue.Magenta)
            .WriteText(displayBuffer, (0, font.Height), "Yer, the Monster,", Hue.Magenta)
            .WriteText(displayBuffer, (0, font.Height * 2), "and Starting with Nothing", Hue.Magenta)
            .WriteText(displayBuffer, (0, font.Height * 4), "A Production of TheGrumpyGameDev", Hue.Cyan)
            .WriteText(displayBuffer, (0, font.Height * 6), "For ""Learn You a Game Jam: Pixel Edition""", Hue.White)
            .WriteText(displayBuffer, (0, ViewHeight - font.Height), "Press Space/(A)", Hue.White)
        End With
    End Sub
End Class
