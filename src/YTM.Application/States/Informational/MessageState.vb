﻿Friend Class MessageState
    Inherits BaseGameState(Of Hue, GameState)

    Public Sub New(parent As IGameController(Of Hue), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState)
    End Sub

    Public Overrides Sub HandleCommand(cmd As String)
        If cmd = Command.A Then
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
            font.WriteText(displayBuffer, (0, y), line, Hue.LightGray)
            y += font.Height
        Next
        ShowStatusBar(displayBuffer, font, "Space/(A) - Continue", Hue.Black, Hue.LightGray)
    End Sub
End Class
