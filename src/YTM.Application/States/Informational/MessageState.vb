Friend Class MessageState
    Inherits BaseGameState

    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), fontSource As IFontSource)
        MyBase.New(parent, setState, fontSource)
    End Sub

    Public Overrides Sub HandleCommand(cmd As String)
        If cmd = Command.A Then
            World.NextMessage()
            SetState(GameState.Neutral)
            Return
        End If
    End Sub

    Public Overrides Sub Render(displayBuffer As IPixelSink)
        displayBuffer.Fill((0, 0), (ViewWidth, ViewHeight), Hue.Black)
        Dim message = World.CurrentMessage
        Dim font = UIFont()
        Dim y = 0
        For Each line In message.Lines
            font.WriteText(displayBuffer, (0, y), line, Hue.LightGray)
            y += font.Height
        Next
        ShowStatusBar(displayBuffer, font, "Space/(A) - Continue", Hue.Black, Hue.LightGray)
    End Sub
End Class
