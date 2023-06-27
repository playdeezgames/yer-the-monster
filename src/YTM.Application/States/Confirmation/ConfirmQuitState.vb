Friend Class ConfirmQuitState
    Inherits BaseGameState
    Private Confirmation As Boolean = False
    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), fontSource As IFontSource)
        MyBase.New(parent, setState, fontSource)
    End Sub

    Public Overrides Sub HandleCommand(cmd As String)
        Select Case cmd
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

    Public Overrides Sub Render(displayBuffer As IPixelSink)
        displayBuffer.Fill((0, 0), (ViewWidth, ViewHeight), Hue.Black)
        Dim font = Fonts.GetFont(GameFont.Font5x7)
        With font
            .WriteText(displayBuffer, (0, 0), ConfirmQuitTitle, Hue.Red)
            .WriteText(displayBuffer, (0, font.Height), NoText, If(Confirmation, Hue.Blue, Hue.LightBlue))
            .WriteText(displayBuffer, (0, font.Height * 2), YesText, If(Confirmation, Hue.LightBlue, Hue.Blue))
        End With
        If Confirmation Then
            ShowStatusBar(displayBuffer, font, "Please don't go!", Hue.Black, Hue.Red)
        Else
            ShowStatusBar(displayBuffer, font, "You'll stay?", Hue.Black, Hue.LightGray)
        End If
    End Sub
End Class
