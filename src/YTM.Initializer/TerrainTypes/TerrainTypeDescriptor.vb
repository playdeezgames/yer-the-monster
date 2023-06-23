Public Class TerrainTypeDescriptor
    ReadOnly Property Character As Char
    ReadOnly Property Hue As Hue
    ReadOnly Property Tenable As Boolean
    ReadOnly Property OnEnter As Action(Of ICharacter)
    Sub New(character As Char, hue As Hue, tenable As Boolean, Optional onEnter As Action(Of ICharacter) = Nothing)
        Me.Character = character
        Me.Hue = hue
        Me.Tenable = tenable
        Me.OnEnter = onEnter
    End Sub
End Class
