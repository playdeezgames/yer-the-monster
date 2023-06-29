Friend Class WindowSizeState
    Inherits BasePickerState
    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), fontSource As IUIContext)
        MyBase.New(parent, setState, fontSource, "<placeholder>", ControlsText("Select", "Cancel"), GameState.Options)
    End Sub
    Protected Overrides Sub OnActivateMenuItem(value As (String, String))
        Dim tokens = value.Item2.Split("x"c)
        Dim width = CInt(tokens(0))
        Dim height = CInt(tokens(1))
        Parent.Size = (width, height)
        SaveConfig()
        HeaderText = $"Current Size: {Size.Item1}x{Size.Item2}"
    End Sub
    Protected Overrides Function InitializeMenuItems() As List(Of (String, String))
        HeaderText = $"Current Size: {Size.Item1}x{Size.Item2}"
        Return New List(Of (String, String)) From
            {
                (Scale1Text, Scale1Text),
                (Scale2Text, Scale2Text),
                (Scale3Text, Scale3Text),
                (Scale4Text, Scale4Text),
                (Scale5Text, Scale5Text),
                (Scale6Text, Scale6Text),
                (Scale7Text, Scale7Text),
                (Scale8Text, Scale8Text),
                (Scale9Text, Scale9Text),
                (Scale10Text, Scale10Text),
                (Scale11Text, Scale11Text),
                (Scale12Text, Scale12Text)
            }
    End Function
End Class
