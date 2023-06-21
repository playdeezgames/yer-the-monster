Friend Class MessageState
    Inherits BaseGameState(Of Hue, Command, Sfx, GameState)

    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState)
    End Sub

    Public Overrides Sub HandleCommand(command As Command)
        If command = Command.A Then
            World.NextMessage()
            SetState(GameState.Neutral)
            Return
        End If
    End Sub

    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        displayBuffer.Fill((0, 0), (ViewWidth, ViewHeight), Hue.Black)
        Dim message = World.CurrentMessage
        Dim font = UIFont()
        Dim y = 0
        For Each line In message.Lines
            font.WriteText(displayBuffer, (0, y), line, Hue.White)
            y += font.Height
        Next
        ShowStatusBar(displayBuffer, font, "Space/(A) - Continue", Hue.Black, Hue.White)
    End Sub
End Class
