Imports System.ComponentModel.Design

Friend Class NavigationState
    Inherits BaseGameState

    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), context As IUIContext)
        MyBase.New(parent, setState, context)
    End Sub
    Private ReadOnly commandDeltas As IReadOnlyDictionary(Of String, (Integer, Integer)) =
        New Dictionary(Of String, (Integer, Integer)) From
        {
            {Command.Up, (0, -1)},
            {Command.Down, (0, 1)},
            {Command.Left, (-1, 0)},
            {Command.Right, (1, 0)}
        }

    Public Overrides Sub HandleCommand(cmd As String)
        Dim avatar = World.Avatar
        Select Case cmd
            Case Command.B
                SetState(GameState.GameMenu)
            Case Command.A
                SetState(GameState.ActionMenu)
            Case Else
                Dim delta = commandDeltas(cmd)
                Application.AttackTarget = avatar.Move(delta.Item1, delta.Item2)
                SetState(GameState.Neutral)
        End Select
    End Sub

    Public Overrides Sub Render(displayBuffer As IPixelSink)
        displayBuffer.Fill((0, 0), (ViewWidth, ViewHeight), Hue.Black)
        Dim map As IMap = RenderMap(displayBuffer, Context.Font(GameFont.YTM))
        ShowStatistics(displayBuffer, World.Avatar)
        ShowHeader(displayBuffer, Context.Font(GameFont.Font5x7), map.DisplayName, Hue.Orange, Hue.Black)
        ShowStatusBar(displayBuffer, Context.Font(GameFont.Font5x7), "Space/(A) - Actions | Esc/(B) - Game Menu", Hue.Black, Hue.LightGray)
    End Sub

    Private Sub ShowStatistics(displayBuffer As IPixelSink, avatar As ICharacter)
        Dim font = Context.Font(GameFont.Font5x7)
        Dim text = $"H={(avatar.Health / avatar.MaximumHealth * 100),3:f0}%"
        font.WriteText(displayBuffer, (ViewWidth - font.TextWidth(text), font.Height), text, Hue.Pink)

        text = $"S={(avatar.Satiety / avatar.MaximumSatiety * 100),3:f0}%"
        font.WriteText(displayBuffer, (ViewWidth - font.TextWidth(text), font.Height * 2), text, Hue.Purple)

        text = $"E={(avatar.Energy / avatar.MaximumEnergy * 100),3:f0}%"
        font.WriteText(displayBuffer, (ViewWidth - font.TextWidth(text), font.Height * 3), text, Hue.Yellow)
    End Sub

    Private Shared Function RenderMap(displayBuffer As IPixelSink, ytmFont As Font) As IMap
        Dim avatar = World.Avatar
        Dim avatarColumn = avatar.MapCell.Column
        Dim avatarRow = avatar.MapCell.Row
        Dim map = avatar.MapCell.Map
        For column = 0 To map.Columns - 1
            For row = 0 To map.Rows - 1
                Dim x = CenterMapCellX + (column - avatarColumn) * MapCellWidth
                Dim y = CenterMapCellY + (row - avatarRow) * MapCellHeight
                Dim mapCell = map.Cell(column, row)
                Dim terrainDescriptor = mapCell.TerrainType.ToTerrainTypeDescriptor
                ytmFont.WriteText(displayBuffer, (x, y), terrainDescriptor.Character, terrainDescriptor.Hue)

                Dim item = mapCell.Item
                If item IsNot Nothing Then
                    Dim itemDescriptor = item.ItemType.ToItemTypeDescriptor
                    ytmFont.WriteText(displayBuffer, (x, y), itemDescriptor.Character, itemDescriptor.Hue)
                End If

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
