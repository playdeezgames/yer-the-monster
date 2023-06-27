Friend Class FightState
    Inherits BasePickerState

    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean))
        MyBase.New(parent, setState, "<placeholder>", ControlsText("Select", "RUN!"), GameState.Run)
    End Sub

    Protected Overrides Sub OnActivateMenuItem(value As (String, String))
        Select Case value.Item2
            Case RunText
                SetState(GameState.Run)
            Case AttackText
                SetState(GameState.Attack)
            Case Else
                Throw New NotImplementedException
        End Select
    End Sub

    Protected Overrides Function InitializeMenuItems() As List(Of (String, String))
        Dim avatar = World.Avatar
        Dim enemy = Context.Enemy
        HeaderText = $"{avatar.Name}({avatar.Health}/{avatar.MaximumHealth}) is fighting {enemy.Name}({enemy.Health}/{enemy.MaximumHealth})."
        Dim result As New List(Of (String, String)) From {
            (AttackText, AttackText),
            (RunText, RunText)
        }
        Return result
    End Function

    Public Overrides Sub Render(displayBuffer As IPixelSink)
        MyBase.Render(displayBuffer)
    End Sub
End Class
