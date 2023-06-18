Friend Class ConfirmAbandonState
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
                    Context.Abandon()
                    SetState(GameState.MainMenu)
                Else
                    SetState(GameState.GameMenu)
                End If
            Case Command.B
                Confirmation = False
                SetState(GameState.GameMenu)
        End Select
    End Sub
    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        displayBuffer.Fill((0, 0), (ViewWidth, ViewHeight), Hue.Black)
        Dim font = Fonts.GetFont(GameFont.Font5x7)
        With font
            .WriteText(displayBuffer, (0, 0), ConfirmAbandonTitle, Hue.White)
            .WriteText(displayBuffer, (0, font.Height), NoText, If(Confirmation, Hue.Cyan, Hue.Magenta))
            .WriteText(displayBuffer, (0, font.Height * 2), YesText, If(Confirmation, Hue.Magenta, Hue.Cyan))
        End With
    End Sub
End Class
