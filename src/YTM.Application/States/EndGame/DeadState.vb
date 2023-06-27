Friend Class DeadState
    Inherits BaseGameState

    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean))
        MyBase.New(parent, setState)
    End Sub

    Public Overrides Sub HandleCommand(cmd As String)
        If cmd = Command.A Then
            Context.Abandon()
            SetState(GameState.MainMenu)
        End If
    End Sub

    Public Overrides Sub Render(displayBuffer As IPixelSink)
        displayBuffer.Fill((0, 0), (ViewWidth, ViewHeight), Hue.Black)
        Dim font = UIFont()
        font.WriteText(displayBuffer, (0, 0), "Yer Dead!", Hue.Red)
        ShowStatusBar(displayBuffer, font, "Space/(A) - Main Menu", Hue.Black, Hue.LightGray)
    End Sub
End Class
