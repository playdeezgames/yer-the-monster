Imports System.IO
Imports System.Text.Json
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Input

Module Program
    Sub Main(args As String())
        Dim config As YTMConfig = ReadConfig()
        Dim gameController As New GameController(
            (config.WindowWidth, config.WindowHeight),
            config.FullScreen,
            config.SfxVolume,
            AddressOf SaveConfig)
        Using host As New Host(
            "Yer, The Monster",
            gameController,
            (ViewWidth, ViewHeight),
            hueTable,
            AddressOf CommandTransformer,
            commandTable,
            sfxFileNames)
            host.Run()
        End Using
    End Sub
    Private ReadOnly commandTable As IReadOnlyDictionary(Of String, Func(Of KeyboardState, GamePadState, Boolean)) =
        New Dictionary(Of String, Func(Of KeyboardState, GamePadState, Boolean)) From
        {
            {Command.A, Function(keyboard, gamePad) keyboard.IsKeyDown(Keys.Space) OrElse keyboard.IsKeyDown(Keys.Enter) OrElse gamePad.IsButtonDown(Buttons.A)},
            {Command.B, Function(keyboard, gamePad) keyboard.IsKeyDown(Keys.Escape) OrElse gamePad.IsButtonDown(Buttons.B)},
            {Command.Up, Function(keyboard, gamePad) keyboard.IsKeyDown(Keys.Up) OrElse keyboard.IsKeyDown(Keys.NumPad8) OrElse gamePad.DPad.Up = ButtonState.Pressed},
            {Command.Down, Function(keyboard, gamePad) keyboard.IsKeyDown(Keys.Down) OrElse keyboard.IsKeyDown(Keys.NumPad2) OrElse gamePad.DPad.Down = ButtonState.Pressed},
            {Command.Left, Function(keyboard, gamePad) keyboard.IsKeyDown(Keys.Left) OrElse keyboard.IsKeyDown(Keys.NumPad4) OrElse gamePad.DPad.Left = ButtonState.Pressed},
            {Command.Right, Function(keyboard, gamePad) keyboard.IsKeyDown(Keys.Right) OrElse keyboard.IsKeyDown(Keys.NumPad6) OrElse gamePad.DPad.Right = ButtonState.Pressed}
        }
    Private Function CommandTransformer(keyboard As KeyboardState, gamePad As GamePadState) As String()
        Dim result As New HashSet(Of String)
        For Each entry In commandTable
            CheckForCommands(result, entry.Value(keyboard, gamePad), entry.Key)
        Next
        Return result.ToArray
    End Function

    Private Const ConfigFileName = "config.json"
    Private Function ReadConfig() As YTMConfig
        Try
            Return JsonSerializer.Deserialize(Of YTMConfig)(File.ReadAllText(ConfigFileName))
        Catch ex As Exception
            Return New YTMConfig() With
            {
                .FullScreen = False,
                .SfxVolume = 0.5,
                .WindowHeight = DefaultScreenHeight,
                .WindowWidth = DefaultScreenWidth
            }
        End Try
    End Function
    Private Sub SaveConfig(windowSize As (Integer, Integer), fullScreen As Boolean, volume As Single)
        File.WriteAllText(ConfigFileName, JsonSerializer.Serialize(New YTMConfig With {.SfxVolume = volume, .WindowHeight = windowSize.Item2, .WindowWidth = windowSize.Item1, .FullScreen = fullScreen}))
    End Sub
    Private ReadOnly _nextCommandTimes As New Dictionary(Of String, DateTimeOffset)
    Private Sub CheckForCommands(commands As HashSet(Of String), isPressed As Boolean, command As String)
        If isPressed Then
            If _nextCommandTimes.ContainsKey(command) Then
                If DateTimeOffset.Now > _nextCommandTimes(command) Then
                    commands.Add(command)
                    _nextCommandTimes(command) = DateTimeOffset.Now.AddSeconds(0.3)
                End If
            Else
                commands.Add(command)
                _nextCommandTimes(command) = DateTimeOffset.Now.AddSeconds(1.0)
            End If
        Else
            _nextCommandTimes.Remove(command)
        End If
    End Sub
    Private ReadOnly hueTable As IReadOnlyDictionary(Of Integer, Color) =
        New Dictionary(Of Integer, Color) From
        {
            {Hue.Black, New Color(0, 0, 0)},
            {Hue.Cyan, New Color(41, 208, 208)},
            {Hue.Purple, New Color(129, 38, 192)},
            {Hue.White, New Color(255, 255, 255)},
            {Hue.Orange, New Color(255, 146, 51)},
            {Hue.Brown, New Color(129, 74, 25)},
            {Hue.Red, New Color(173, 35, 35)},
            {Hue.Blue, New Color(42, 75, 215)},
            {Hue.DarkGray, New Color(87, 87, 87)},
            {Hue.LightGray, New Color(160, 160, 160)},
            {Hue.LightGreen, New Color(129, 197, 122)},
            {Hue.LightBlue, New Color(157, 175, 255)},
            {Hue.Yellow, New Color(255, 238, 51)},
            {Hue.Tan, New Color(233, 222, 187)},
            {Hue.Pink, New Color(255, 205, 243)},
            {Hue.Green, New Color(29, 105, 20)}
        }
    Private ReadOnly sfxFileNames As IReadOnlyDictionary(Of String, String) =
        New Dictionary(Of String, String) From
        {
            {Sfx.PlayerHit, "Content/PlayerHit.wav"},
            {Sfx.Shucks, "Content/Shucks.wav"}
        }
End Module
