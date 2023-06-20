Friend Class NeutralState
    Inherits BaseGameState(Of Hue, Command, Sfx, GameState)
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState)
    End Sub
    Public Overrides Sub HandleCommand(command As Command)
        Select Case command
            Case Command.B
                SetState(GameState.GameMenu)
            Case Command.A
                SetState(GameState.ActionMenu)
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
            .WriteText(displayBuffer, (0, y), $"Health: {avatar.Health}/{avatar.MaximumHealth}", Hue.White)
            y += font.Height
            .WriteText(displayBuffer, (0, y), $"Satiety: {avatar.Satiety}/{avatar.MaximumSatiety}", Hue.White)
            y += font.Height
            .WriteText(displayBuffer, (0, y), $"Energy: {avatar.Energy}/{avatar.MaximumEnergy}", Hue.White)
            y += font.Height
            .WriteText(displayBuffer, (0, y), $"Location: {avatar.Location.Name}", Hue.White)
            y += font.Height
            Dim exits = avatar.Location.Routes
            .WriteText(displayBuffer, (0, y), $"Exits: {String.Join(", ", exits.Select(Function(x) x.Direction.ToDirectionDescriptor.Name).ToArray)}", Hue.White)

            ShowStatusBar(displayBuffer, font, "Space/(A) - Actions | Esc/(B) - Game Menu", Hue.Black, Hue.White)
        End With
    End Sub
End Class
