Public Interface IEffect
    Sub SetTeleport(destination As IMapCell)
    ReadOnly Property Id As Integer
    ReadOnly Property EffectType As String
    Function GetTeleport() As IMapCell
End Interface
