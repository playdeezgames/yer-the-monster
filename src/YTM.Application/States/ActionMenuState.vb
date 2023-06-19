Friend Class ActionMenuState
    Inherits BaseMenuState
    Public Sub New(parent As IGameController(Of Hue, Command, Sfx), setState As Action(Of GameState?, Boolean))
        MyBase.New(
            parent,
            setState,
            ActionMenuTitle,
            {
                GoBackText
            },
            GoBackText)
    End Sub
    Protected Overrides Sub HandleMenuItem(menuItem As String)
        Select Case menuItem
            Case GoBackText
                SetState(GameState.Neutral)
            Case Else
                Throw New NotImplementedException
        End Select
    End Sub
End Class
