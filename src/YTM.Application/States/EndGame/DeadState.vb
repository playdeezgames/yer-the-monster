Friend Class DeadState
    Inherits BaseGameState

    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), context As IUIContext)
        MyBase.New(parent, setState, context)
    End Sub

    Public Overrides Sub HandleCommand(cmd As String)
        If cmd = Command.A Then
            Application.Context.Abandon()
            SetState(GameState.MainMenu)
        End If
    End Sub

    Public Overrides Sub Render(displayBuffer As IPixelSink)
        displayBuffer.Fill((0, 0), (ViewWidth, ViewHeight), Hue.Black)
        Dim font = Context.Font(GameFont.Font5x7)
        font.WriteText(displayBuffer, (0, 0), "Yer Dead!", Hue.Red)
        ShowStatusBar(displayBuffer, font, "Space/(A) - Main Menu", Hue.Black, Hue.LightGray)
    End Sub
End Class
