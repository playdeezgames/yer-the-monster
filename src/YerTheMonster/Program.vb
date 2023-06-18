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
    Private Function GamePadTransformer(oldState As GamePadState, newState As GamePadState) As Command()
        Dim results As New List(Of Command)
        If newState.IsButtonDown(Buttons.A) AndAlso Not oldState.IsButtonDown(Buttons.A) Then
            results.Add(Command.A)
        End If
        If newState.IsButtonDown(Buttons.B) AndAlso Not oldState.IsButtonDown(Buttons.B) Then
            results.Add(Command.B)
        End If
        If newState.DPad.Up = ButtonState.Pressed AndAlso oldState.DPad.Up = ButtonState.Released Then
            results.Add(Command.Up)
        End If
        If newState.DPad.Down = ButtonState.Pressed AndAlso oldState.DPad.Down = ButtonState.Released Then
            results.Add(Command.Down)
        End If
        If newState.DPad.Left = ButtonState.Pressed AndAlso oldState.DPad.Left = ButtonState.Released Then
            results.Add(Command.Left)
        End If
        If newState.DPad.Right = ButtonState.Pressed AndAlso oldState.DPad.Right = ButtonState.Released Then
            results.Add(Command.Right)
        End If
        Return results.ToArray
    End Function
    Private Function BufferCreator(texture As Texture2D) As IDisplayBuffer(Of Hue)
        Return New DisplayBuffer(Of Hue)(texture, AddressOf TransformHue)
    End Function
    Private ReadOnly hueTable As IReadOnlyDictionary(Of Hue, Color) =
        New Dictionary(Of Hue, Color) From
        {
            {Hue.Black, Color.Black},
            {Hue.Cyan, Color.Cyan},
            {Hue.Magenta, Color.Magenta},
            {Hue.White, Color.White}
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
