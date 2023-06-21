Public Class TerrainTypeDescriptor
    ReadOnly Property Character As Char
    ReadOnly Property Hue As Hue
    Sub New(character As Char, hue As Hue)
        Me.Character = character
        Me.Hue = hue
    End Sub
End Class
