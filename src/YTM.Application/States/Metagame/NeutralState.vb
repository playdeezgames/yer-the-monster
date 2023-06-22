﻿Friend Class NeutralState
    Inherits BaseGameState(Of Hue, Command, Sfx, GameState)
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(parent, setState)
    End Sub
    Public Overrides Sub HandleCommand(command As Command)
        Throw New NotImplementedException()
    End Sub
    Public Overrides Sub Render(displayBuffer As IPixelSink(Of Hue))
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
        SetState(GameState.Navigation)
    End Sub
End Class