Imports System.ComponentModel.Design
Imports System.IO
Imports System.Runtime.InteropServices
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
        Using host As New Host(Of Hue, Command, Sfx)(
            "Yer, The Monster",
            gameController,
            (ViewWidth, ViewHeight),
            AddressOf BufferCreator,
            AddressOf CommandTransformer,
            AddressOf GamePadTransformer,
            sfxFileNames)
            host.Run()
        End Using
    End Sub
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
    Private ReadOnly _nextCommandTimes As New Dictionary(Of Command, DateTimeOffset)
    Private Sub CheckForGamePadCommand(commands As HashSet(Of Command), isPressed As Boolean, command As Command)
        If isPressed Then
            If Not _nextCommandTimes.ContainsKey(command) OrElse DateTimeOffset.Now > _nextCommandTimes(command) Then
                commands.Add(command)
                _nextCommandTimes(command) = DateTimeOffset.Now.AddSeconds(0.5)
            End If
        Else
            _nextCommandTimes.Remove(command)
        End If
    End Sub
    Private Function GamePadTransformer(oldState As GamePadState, newState As GamePadState) As Command()
        Dim result As New HashSet(Of Command)
        CheckForGamePadCommand(result, newState.IsButtonDown(Buttons.A), Command.A)
        CheckForGamePadCommand(result, newState.IsButtonDown(Buttons.B), Command.B)
        CheckForGamePadCommand(result, newState.DPad.Up = ButtonState.Pressed, Command.Up)
        CheckForGamePadCommand(result, newState.DPad.Down = ButtonState.Pressed, Command.Down)
        CheckForGamePadCommand(result, newState.DPad.Left = ButtonState.Pressed, Command.Left)
        CheckForGamePadCommand(result, newState.DPad.Right = ButtonState.Pressed, Command.Right)
        Return result.ToArray
    End Function
    Private Function BufferCreator(texture As Texture2D) As IDisplayBuffer(Of Hue)
        Return New DisplayBuffer(Of Hue)(texture, AddressOf TransformHue)
    End Function
    Private ReadOnly hueTable As IReadOnlyDictionary(Of Hue, Color) =
        New Dictionary(Of Hue, Color) From
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
    Private Function TransformHue(hue As Hue) As Color
        Return hueTable(hue)
    End Function
    Private Function CommandTransformer(keys As Keys) As Command?
        Select Case keys
            Case Keys.Up, Keys.NumPad8
                Return Command.Up
            Case Keys.Down, Keys.NumPad2
                Return Command.Down
            Case Keys.Right, Keys.NumPad6
                Return Command.Right
            Case Keys.Left, Keys.NumPad4
                Return Command.Left
            Case Keys.Space, Keys.Enter
                Return Command.A
            Case Keys.Escape
                Return Command.B
            Case Else
                Return Nothing
        End Select
    End Function
    Private ReadOnly sfxFileNames As IReadOnlyDictionary(Of Sfx, String) =
        New Dictionary(Of Sfx, String) From
        {
            {Sfx.PlayerHit, "Content/PlayerHit.wav"},
            {Sfx.Shucks, "Content/Shucks.wav"}
        }
End Module
