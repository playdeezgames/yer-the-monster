Friend Class NavigationState
    Inherits BaseGameState(Of Hue, Command, Sfx, GameState)

    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState)
    End Sub

    Public Overrides Sub HandleCommand(command As Command)
        Dim avatar = World.Avatar
        Select Case command
            Case Command.B
                SetState(GameState.GameMenu)
            Case Command.A
                SetState(GameState.ActionMenu)
            Case Command.Up
                avatar.Move(0, -1)
                SetState(GameState.Neutral)
            Case Command.Down
                avatar.Move(0, 1)
                SetState(GameState.Neutral)
            Case Command.Left
                avatar.Move(-1, 0)
                SetState(GameState.Neutral)
            Case Command.Right
                avatar.Move(1, 0)
                SetState(GameState.Neutral)
        End Select
    End Sub

    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        displayBuffer.Fill((0, 0), (ViewWidth, ViewHeight), Hue.Black)
        Dim map As IMap = RenderMap(displayBuffer)
        ShowStatistics(displayBuffer, World.Avatar)
        ShowHeader(displayBuffer, UIFont, map.DisplayName, Hue.White, Hue.Black)
        ShowStatusBar(displayBuffer, UIFont, "Space/(A) - Actions | Esc/(B) - Game Menu", Hue.Black, Hue.White)
    End Sub

    Private Sub ShowStatistics(displayBuffer As IPixelSink(Of Hue), avatar As ICharacter)
        Dim font = UIFont()
        Dim text = $"H={(avatar.Health / avatar.MaximumHealth * 100),3:f0}%"
        font.WriteText(displayBuffer, (ViewWidth - font.TextWidth(text) + 1, font.Height + 1), text, Hue.Black)
        font.WriteText(displayBuffer, (ViewWidth - font.TextWidth(text), font.Height), text, Hue.White)

        text = $"S={(avatar.Satiety / avatar.MaximumSatiety * 100),3:f0}%"
        font.WriteText(displayBuffer, (ViewWidth - font.TextWidth(text) + 1, font.Height * 2 + 1), text, Hue.Black)
        font.WriteText(displayBuffer, (ViewWidth - font.TextWidth(text), font.Height * 2), text, Hue.White)

        text = $"E={(avatar.Energy / avatar.MaximumEnergy * 100),3:f0}%"
        font.WriteText(displayBuffer, (ViewWidth - font.TextWidth(text) + 1, font.Height * 3 + 1), text, Hue.Black)
        font.WriteText(displayBuffer, (ViewWidth - font.TextWidth(text), font.Height * 3), text, Hue.White)
    End Sub

    Private Shared Function RenderMap(displayBuffer As IPixelSink(Of Hue)) As IMap
        Dim avatar = World.Avatar
        Dim avatarColumn = avatar.MapCell.Column
        Dim avatarRow = avatar.MapCell.Row
        Dim map = avatar.MapCell.Map
        Dim ytmFont = Fonts.GetFont(GameFont.YTM)
        For column = 0 To map.Columns - 1
            For row = 0 To map.Rows - 1
                Dim x = CenterMapCellX + (column - avatarColumn) * MapCellWidth
                Dim y = CenterMapCellY + (row - avatarRow) * MapCellHeight
                Dim mapCell = map.Cell(column, row)
                Dim terrainDescriptor = mapCell.TerrainType.ToTerrainTypeDescriptor
                ytmFont.WriteText(displayBuffer, (x, y), terrainDescriptor.Character, terrainDescriptor.Hue)
                Dim character = mapCell.Character
                If character IsNot Nothing Then
                    Dim characterDescriptor = character.CharacterType.ToCharacterTypeDescriptor
                    ytmFont.WriteText(displayBuffer, (x, y), characterDescriptor.Character, characterDescriptor.Hue)
                End If
            Next
        Next

        Return map
    End Function
End Class
