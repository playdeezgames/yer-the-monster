Friend Class ConfirmQuitState
    Inherits BaseGameState(Of Hue, Command, Sfx, GameState)
    Private Confirmation As Boolean = False
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState)
    End Sub

    Public Overrides Sub HandleCommand(command As Command)
        Select Case command
            Case Command.Up, Command.Down
                Confirmation = Not Confirmation
            Case Command.A
                If Confirmation Then
                    PopState()
                Else
                    SetState(GameState.MainMenu)
                End If
            Case Command.B
                Confirmation = False
                SetState(GameState.MainMenu)
        End Select
    End Sub

    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        displayBuffer.Fill((0, 0), (ViewWidth, ViewHeight), Hue.Black)
        Dim font = Fonts.GetFont(GameFont.Font5x7)
        With font
            .WriteText(displayBuffer, (0, 0), ConfirmQuitTitle, Hue.White)
            .WriteText(displayBuffer, (0, font.Height), NoText, If(Confirmation, Hue.Cyan, Hue.Purple))
            .WriteText(displayBuffer, (0, font.Height * 2), YesText, If(Confirmation, Hue.Purple, Hue.Cyan))
        End With
        If Confirmation Then
            ShowStatusBar(displayBuffer, font, "Please don't go!", Hue.Black, Hue.Purple)
        Else
            ShowStatusBar(displayBuffer, font, "You'll stay?", Hue.Black, Hue.White)
        End If
    End Sub
End Class
