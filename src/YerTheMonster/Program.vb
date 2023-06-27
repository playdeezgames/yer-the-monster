Imports System.IO
Imports System.Text.Json
Imports AOS.UI
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
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
            AddressOf KeyboardTransformer,
            AddressOf GamePadTransformer,
            sfxFileNames)
            host.Run()
        End Using
    End Sub
    Private ReadOnly keyboardCommandTable As IReadOnlyDictionary(Of String, Func(Of KeyboardState, Boolean)) =
        New Dictionary(Of String, Func(Of KeyboardState, Boolean)) From
        {
            {Command.A, Function(state) state.IsKeyDown(Keys.Space) OrElse state.IsKeyDown(Keys.Enter)},
            {Command.B, Function(state) state.IsKeyDown(Keys.Escape)},
            {Command.Up, Function(state) state.IsKeyDown(Keys.Up) OrElse state.IsKeyDown(Keys.NumPad8)},
            {Command.Down, Function(state) state.IsKeyDown(Keys.Down) OrElse state.IsKeyDown(Keys.NumPad2)},
            {Command.Left, Function(state) state.IsKeyDown(Keys.Left) OrElse state.IsKeyDown(Keys.NumPad4)},
            {Command.Right, Function(state) state.IsKeyDown(Keys.Right) OrElse state.IsKeyDown(Keys.NumPad6)}
        }
    Private Function KeyboardTransformer(state As KeyboardState) As String()
        Dim result As New HashSet(Of String)
        For Each entry In keyboardCommandTable
            CheckKeyboardForCommand(result, entry.Value(state), entry.Key)
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
    Private ReadOnly _nextGamePadCommandTimes As New Dictionary(Of String, DateTimeOffset)
    Private ReadOnly _nextKeyboardCommandTimes As New Dictionary(Of String, DateTimeOffset)
    Private Sub CheckGamePadForCommand(commands As HashSet(Of String), isPressed As Boolean, command As String)
        If isPressed Then
            If _nextGamePadCommandTimes.ContainsKey(command) Then
                If DateTimeOffset.Now > _nextGamePadCommandTimes(command) Then
                    commands.Add(command)
                    _nextGamePadCommandTimes(command) = DateTimeOffset.Now.AddSeconds(0.3)
                End If
            Else
                commands.Add(command)
                _nextGamePadCommandTimes(command) = DateTimeOffset.Now.AddSeconds(1.0)
            End If
        Else
            _nextGamePadCommandTimes.Remove(command)
        End If
    End Sub
    Private Sub CheckKeyboardForCommand(commands As HashSet(Of String), isPressed As Boolean, command As String)
        If isPressed Then
            If _nextKeyboardCommandTimes.ContainsKey(command) Then
                If DateTimeOffset.Now > _nextKeyboardCommandTimes(command) Then
                    commands.Add(command)
                    _nextKeyboardCommandTimes(command) = DateTimeOffset.Now.AddSeconds(0.3)
                End If
            Else
                commands.Add(command)
                _nextKeyboardCommandTimes(command) = DateTimeOffset.Now.AddSeconds(1.0)
            End If
        Else
            _nextKeyboardCommandTimes.Remove(command)
        End If
    End Sub
    Private ReadOnly gamePadCommandtable As IReadOnlyDictionary(Of String, Func(Of GamePadState, Boolean)) =
        New Dictionary(Of String, Func(Of GamePadState, Boolean)) From
        {
            {Command.A, Function(state) state.IsButtonDown(Buttons.A)},
            {Command.B, Function(state) state.IsButtonDown(Buttons.B)},
            {Command.Up, Function(state) state.DPad.Up = ButtonState.Pressed},
            {Command.Down, Function(state) state.DPad.Down = ButtonState.Pressed},
            {Command.Left, Function(state) state.DPad.Left = ButtonState.Pressed},
            {Command.Right, Function(state) state.DPad.Right = ButtonState.Pressed}
        }
    Private Function GamePadTransformer(state As GamePadState) As String()
        Dim result As New HashSet(Of String)
        For Each entry In gamePadCommandtable
            CheckGamePadForCommand(result, entry.Value(state), entry.Key)
        Next
        Return result.ToArray
    End Function
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
