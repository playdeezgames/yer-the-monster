Public Class YTMContext
    Inherits UIContext

    Public Sub New(fontFilenames As IReadOnlyDictionary(Of String, String), viewSize As (Integer, Integer))
        MyBase.New(fontFilenames, viewSize)
    End Sub

    Public Overrides Sub ShowSplashContent(displayBuffer As IPixelSink, font As Font)
        With font
            .WriteText(displayBuffer, (0, 0), "A Game in VB.NET About", Hue.Orange)
            .WriteText(displayBuffer, (0, font.Height), "Yer, the Monster,", Hue.Orange)
            .WriteText(displayBuffer, (0, font.Height * 2), "and Starting with Nothing", Hue.Orange)
            .WriteText(displayBuffer, (0, font.Height * 4), "A Production of TheGrumpyGameDev", Hue.Tan)
            .WriteText(displayBuffer, (0, font.Height * 6), "For ""Learn You a Game Jam: Pixel Edition""", Hue.Brown)
            ShowStatusBar(displayBuffer, font, "Space/(A)", Hue.Black, Hue.LightGray)
        End With
    End Sub

    Public Overrides Sub ShowAboutContent(displayBuffer As IPixelSink, font As Font)
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
