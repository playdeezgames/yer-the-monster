Friend Class Message
    Inherits WorldDataClient
    Implements IMessage

    Sub New(worldData As WorldData)
        MyBase.New(worldData)
    End Sub

    Public ReadOnly Property Lines As IEnumerable(Of String) Implements IMessage.Lines
        Get
            Return WorldData.Messages.First.Lines
        End Get
    End Property
End Class
