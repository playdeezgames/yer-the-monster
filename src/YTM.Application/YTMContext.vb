Public Class YTMContext
    Inherits UIContext

    Public Sub New(fontFilenames As IReadOnlyDictionary(Of String, String), viewSize As (Integer, Integer))
        MyBase.New(fontFilenames, viewSize)
    End Sub

    Public Overrides ReadOnly Property AvailableWindowSizes As IEnumerable(Of (Integer, Integer))
        Get
            Return {
                (640, 360),
                (1280, 720),
                (1920, 1080),
                (2560, 1440),
                (3200, 1800),
                (3840, 2160),
                (4480, 2520),
                (5120, 2880),
                (5760, 3240),
                (6400, 3600),
                (7040, 3960),
                (7680, 4320)}
        End Get
    End Property

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

    Public Overrides Sub AbandonGame()
        Context.Abandon()
    End Sub

    Public Overrides Sub LoadGame(slot As Integer)
        Context.LoadFromSlot(slot)
    End Sub

    Public Overrides Sub SaveGame(slot As Integer)
        Context.SaveToSlot(slot)
    End Sub

    Public Overrides Function DoesSlotExist(slot As Integer) As Boolean
        Return Context.DoesSaveExist(slot)
    End Function
End Class
