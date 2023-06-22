Friend Class EffectDataClient
    Inherits WorldDataClient
    Protected ReadOnly EffectId As Integer
    Protected ReadOnly Property EffectData As EffectData
        Get
            Return WorldData.Effects(EffectId)
        End Get
    End Property
    Protected Sub New(worldData As WorldData, effectId As Integer)
        MyBase.New(worldData)
        Me.EffectId = effectId
    End Sub
End Class
