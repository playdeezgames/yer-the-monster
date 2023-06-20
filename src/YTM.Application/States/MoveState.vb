Friend Class MoveState
    Inherits BasePickerState
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState, "Space/(A) - Go! | Esc/(B) - Cancel", GameState.ActionMenu)
    End Sub
    Protected Overrides Sub OnActivateMenuItem(value As (String, String))
        Select Case value.Item2
            Case NeverMindText
                SetState(GameState.ActionMenu)
            Case Else
                World.Avatar.Move(value.Item2)
                SetState(GameState.Neutral)
        End Select
    End Sub
    Protected Overrides Function InitializeMenuItems() As List(Of (String, String))
        Dim result As New List(Of (String, String)) From {
            (NeverMindText, NeverMindText)
        }
        result.AddRange(World.Avatar.Location.Routes.Select(Function(x) (x.Direction.ToDirectionDescriptor.Name, x.Direction)))
        Return result
    End Function
End Class
