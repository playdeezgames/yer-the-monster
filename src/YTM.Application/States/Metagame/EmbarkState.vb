Friend Class EmbarkState
    Inherits BaseGameState(Of Hue, Sfx, GameState)
    Public Sub New(parent As IGameController(Of Hue, Sfx), setState As Action(Of GameState?, Boolean))
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
        Context.Embark()
        SetState(GameState.Neutral)
    End Sub
End Class
