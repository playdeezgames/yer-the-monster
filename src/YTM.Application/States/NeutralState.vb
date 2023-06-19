﻿Friend Class NeutralState
    Inherits BaseGameState(Of Hue, Command, Sfx, GameState)
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState)
    End Sub
    Public Overrides Sub HandleCommand(command As Command)
        Select Case command
            Case Command.B
                SetState(GameState.GameMenu)
        End Select
    End Sub
    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        displayBuffer.Fill((0, 0), (ViewWidth, ViewHeight), Hue.Black)
        Dim font = Fonts.GetFont(GameFont.Font5x7)
        Dim avatar = World.Avatar
        Dim y = 0
        With font
            .WriteText(displayBuffer, (0, y), $"Name: {avatar.Name}", Hue.White)
            y += font.Height
            .WriteText(displayBuffer, (0, y), $"Location: {avatar.Location.Name}", Hue.White)

            displayBuffer.Fill((0, ViewHeight - font.Height), (ViewWidth, font.Height), Hue.Magenta)
            .WriteText(displayBuffer, (0, ViewHeight - font.Height), "Space/(A) - Actions | Esc/(B) - Game Menu", Hue.Black)
        End With
    End Sub
End Class
