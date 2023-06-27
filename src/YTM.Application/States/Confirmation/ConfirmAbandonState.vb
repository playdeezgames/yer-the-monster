Friend Class ConfirmAbandonState
    Inherits BaseGameState(Of Hue, GameState)
    Private Confirmation As Boolean = False
    Public Sub New(parent As IGameController(Of Hue), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState)
    End Sub
    Public Overrides Sub HandleCommand(cmd As String)
        Select Case cmd
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
            .WriteText(displayBuffer, (0, 0), ConfirmAbandonTitle, Hue.Red)
            .WriteText(displayBuffer, (0, font.Height), NoText, If(Confirmation, Hue.Blue, Hue.LightBlue))
            .WriteText(displayBuffer, (0, font.Height * 2), YesText, If(Confirmation, Hue.LightBlue, Hue.Blue))
        End With
        If Confirmation Then
            ShowStatusBar(displayBuffer, font, "You can't! You mustn't!", Hue.Black, Hue.Red)
        Else
            ShowStatusBar(displayBuffer, font, "There's so much left to do!", Hue.Black, Hue.LightGray)
        End If
    End Sub
End Class
