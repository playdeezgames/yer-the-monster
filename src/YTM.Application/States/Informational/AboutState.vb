Friend Class AboutState
    Inherits BaseGameState
    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), fontSource As IFontSource)
        MyBase.New(parent, setState, fontSource)
    End Sub
    Public Overrides Sub HandleCommand(cmd As String)
        SetState(GameState.MainMenu)
    End Sub
    Public Overrides Sub Render(displayBuffer As IPixelSink)
        displayBuffer.Fill((0, 0), (ViewWidth, ViewHeight), Hue.Black)
        Dim font = Fonts.GetFont(GameFont.Font5x7)
        With font
            .WriteText(displayBuffer, (0, 0), AboutTitle, Hue.Orange)
            .WriteText(displayBuffer, (0, font.Height * 2), About1Text, Hue.Tan)
            .WriteText(displayBuffer, (0, font.Height * 4), About2Text, Hue.Tan)
            .WriteText(displayBuffer, (0, font.Height * 6), About3Text, Hue.Tan)
            .WriteText(displayBuffer, (0, font.Height * 8), About4Text, Hue.Tan)
            .WriteText(displayBuffer, (0, font.Height * 12), About5Text, Hue.Tan)
        End With
        ShowStatusBar(displayBuffer, font, "Space/(A) - Return to Main Menu", Hue.Black, Hue.LightGray)
    End Sub
End Class
