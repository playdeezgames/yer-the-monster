﻿Friend Class PickUpItemState
    Inherits BaseGameState

    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean))
        MyBase.New(parent, setState)
    End Sub

    Public Overrides Sub HandleCommand(cmd As String)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub Render(displayBuffer As IPixelSink)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub OnStart()
        MyBase.OnStart()
        World.Avatar.PickUpItem()
        SetState(GameState.Neutral)
    End Sub
End Class
