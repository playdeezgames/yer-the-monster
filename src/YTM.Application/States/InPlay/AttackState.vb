Friend Class AttackState
    Inherits BaseGameState(Of Hue)

    Public Sub New(parent As IGameController(Of Hue), setState As Action(Of String, Boolean))
        MyBase.New(parent, setState)
    End Sub

    Public Overrides Sub HandleCommand(cmd As String)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
        Throw New NotImplementedException()
    End Sub
    Public Overrides Sub OnStart()
        MyBase.OnStart()
        World.Avatar.Attack(Context.Enemy, True)
        SetState(GameState.Neutral)
    End Sub
End Class
