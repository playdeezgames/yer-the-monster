Friend Class AboutState
    Inherits BaseGameState(Of Hue, Command, Sfx, GameState)
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState)
    End Sub
    Public Overrides Sub HandleCommand(command As Command)
        SetState(GameState.MainMenu)
    End Sub
    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        displayBuffer.Fill((0, 0), (ViewWidth, ViewHeight), Hue.Black)
        Dim font = Fonts.GetFont(GameFont.Font5x7)
        With font
            .WriteText(displayBuffer, (0, 0), AboutTitle, Hue.White)
            .WriteText(displayBuffer, (0, font.Height * 2), About1Text, Hue.Magenta)
            .WriteText(displayBuffer, (0, font.Height * 4), About2Text, Hue.Magenta)
            .WriteText(displayBuffer, (0, font.Height * 6), About3Text, Hue.Magenta)
            .WriteText(displayBuffer, (0, font.Height * 8), About4Text, Hue.Magenta)
            .WriteText(displayBuffer, (0, font.Height * 12), About5Text, Hue.Magenta)
        End With
        ShowStatusBar(displayBuffer, font, "Space/(A) - Return to Main Menu", Hue.Black, Hue.White)
    End Sub
End Class
