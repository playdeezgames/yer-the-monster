Public Class DirectionDescriptor
    ReadOnly Property Name As String
    ReadOnly Property DeltaX As Integer?
    ReadOnly Property DeltaY As Integer?
    ReadOnly Property Opposite As String
    Sub New(name As String, opposite As String, deltaX As Integer?, deltaY As Integer?)
        Me.Name = name
        Me.Opposite = opposite
        Me.DeltaY = deltaY
        Me.DeltaX = deltaX
    End Sub
End Class
