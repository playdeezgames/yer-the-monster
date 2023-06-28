Friend Class VolumeState
    Inherits BasePickerState
    Private ReadOnly _saveConfig As Action
    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), fontSource As IFontSource, saveConfig As Action)
        MyBase.New(parent, setState, fontSource, "<placeholder>", ControlsText("Select", "Cancel"), GameState.Options)
        _saveConfig = saveConfig
    End Sub
    Protected Overrides Sub OnActivateMenuItem(value As (String, String))
        Dim percent = CInt(value.Item2)
        Volume = percent * 0.01F
        PlaySfx(Sfx.PlayerHit)
        _saveConfig()
        HeaderText = $"Volume (Currently: {Volume * 100:f0}%)"
    End Sub
    Protected Overrides Function InitializeMenuItems() As List(Of (String, String))
        HeaderText = $"Volume (Currently: {Volume * 100:f0}%)"
        Dim result As New List(Of (String, String))
        For index = 0 To 10
            result.Add(($"{index * 10}%", $"{index * 10}"))
        Next
        Return result
    End Function
End Class
