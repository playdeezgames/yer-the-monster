Imports AOS.UI
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Module Program
    Sub Main(args As String())
        Dim gameController As New GameController((ScreenWidth, ScreenHeight), False, 1.0F)
        Using host As New Host(Of Hue, Command, Sfx)("Yer, The Monster", gameController, (ViewWidth, ViewHeight), AddressOf BufferCreator, AddressOf CommandTransformer, AddressOf GamePadTransformer, sfxFileNames)
            host.Run()
        End Using
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
            Case Keys.Up
                Return Command.Up
            Case Keys.Down
                Return Command.Down
            Case Keys.Right
                Return Command.Right
            Case Keys.Left
                Return Command.Left
            Case Keys.Space, Keys.Enter
                Return Command.A
            Case Keys.Escape
                Return Command.B
            Case Else
                Return Nothing
        End Select
    End Function
    Private ReadOnly sfxFileNames As IReadOnlyDictionary(Of Sfx, String) = New Dictionary(Of Sfx, String)
End Module
