Friend Class NeutralState
    Inherits BaseGameState
    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean))
        MyBase.New(parent, setState)
    End Sub
    Public Overrides Sub HandleCommand(cmd As String)
        Throw New NotImplementedException()
    End Sub
    Public Overrides Sub Render(displayBuffer As IPixelSink)
        Throw New NotImplementedException
    End Sub
    Public Overrides Sub OnStart()
        MyBase.OnStart()
        If World.HasMessages Then
            SetState(GameState.Message)
            Return
        End If
        Dim avatar = World.Avatar
        If avatar.IsDead Then
            SetState(GameState.Dead)
            Return
        End If
        If Context.Enemy IsNot Nothing Then
            SetState(GameState.Fight)
            Return
        End If
        SetState(GameState.Navigation)
    End Sub
End Class
