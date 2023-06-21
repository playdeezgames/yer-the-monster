Friend Class DeadState
    Inherits BaseGameState(Of Hue, Command, Sfx, GameState)

    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState)
    End Sub

    Public Overrides Sub HandleCommand(command As Command)
        If command = Command.A Then
            Abandon()
            SetState(GameState.MainMenu)
        End If
    End Sub

    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        displayBuffer.Fill((0, 0), (ViewWidth, ViewHeight), Hue.Black)
        Dim font = UIFont()
        font.WriteText(displayBuffer, (0, 0), "Yer Dead!", Hue.Magenta)
        ShowStatusBar(displayBuffer, font, "Space/(A) - Main Menu", Hue.Black, Hue.White)
    End Sub
End Class
