﻿Friend Class Item
    Inherits ItemDataClient
    Implements IItem
    Sub New(worldData As WorldData, itemId As Integer)
        MyBase.New(worldData, itemId)
    End Sub
    Public ReadOnly Property Id As Integer Implements IItem.Id
        Get
            Return ItemId
        End Get
    End Property

    Public Property Name As String Implements IItem.Name
        Get
            Return ItemData.Name
        End Get
        Set(value As String)
            ItemData.Name = value
        End Set
    End Property

    Public ReadOnly Property ItemType As String Implements IItem.ItemType
        Get
            Return ItemData.ItemType
        End Get
    End Property

    Public Sub Recycle() Implements IItem.Recycle
        ItemData.Recycled = True
    End Sub
End Class
