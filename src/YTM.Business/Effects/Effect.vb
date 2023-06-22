Friend Class Effect
    Inherits EffectDataClient
    Implements IEffect
    Public Sub New(worldData As WorldData, effectId As Integer)
        MyBase.New(worldData, effectId)
    End Sub
    Public ReadOnly Property Id As Integer Implements IEffect.Id
        Get
            Return EffectId
        End Get
    End Property

    Public ReadOnly Property EffectType As String Implements IEffect.EffectType
        Get
            Return EffectData.EffectType
        End Get
    End Property

    Public Sub SetTeleport(destination As IMapCell) Implements IEffect.SetTeleport
        EffectData.Teleport = New TeleportData With
            {
                .DestinationMapId = destination.Map.Id,
                .DestinationColumn = destination.Column,
                .DestinationRow = destination.Row
            }
    End Sub

    Public Function GetTeleport() As IMapCell Implements IEffect.GetTeleport
        Dim teleport = EffectData.Teleport
        If teleport Is Nothing Then
            Return Nothing
        End If
        Return New MapCell(WorldData, teleport.DestinationMapId, teleport.DestinationColumn, teleport.DestinationRow)
    End Function
End Class
