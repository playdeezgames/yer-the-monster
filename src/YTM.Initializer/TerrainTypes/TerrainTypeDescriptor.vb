Public Class TerrainTypeDescriptor
    ReadOnly Property Character As Char
    ReadOnly Property Hue As Hue
    ReadOnly Property Tenable As Boolean
    Sub New(character As Char, hue As Hue, tenable As Boolean)
        Me.Character = character
        Me.Hue = hue
        Me.Tenable = tenable
    End Sub
End Class
