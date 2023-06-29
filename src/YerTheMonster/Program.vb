Imports AOS.UI
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Input
Module Program
    Private Const GameTitle = "Yer, The Monster"
    Sub Main(args As String())
        Using host As New Host(
            GameTitle,
            New GameController(
                New YTMSettings((DefaultScreenWidth, DefaultScreenHeight)),
                New YTMContext(fontFilenames, (ViewWidth, ViewHeight))),
            (ViewWidth, ViewHeight),
            hueTable,
            commandTable,
            sfxFileNames)
            host.Run()
        End Using
    End Sub
    Private ReadOnly fontFilenames As IReadOnlyDictionary(Of String, String) =
        New Dictionary(Of String, String) From
        {
            {UIFont, "Content/CyFont5x7.json"},
            {GameFont.YTM, "Content/ytm.json"}
        }
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
