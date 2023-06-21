Public Class CharacterTypeDescriptor
    Public ReadOnly Character As Char
    Public ReadOnly Hue As Hue
    Public ReadOnly Property Statistics As IReadOnlyDictionary(Of String, Integer)
    Sub New(character As Char, hue As Hue, statistics As IReadOnlyDictionary(Of String, Integer))
        Me.Character = character
        Me.Hue = hue
        Me.Statistics = statistics
    End Sub
End Class
