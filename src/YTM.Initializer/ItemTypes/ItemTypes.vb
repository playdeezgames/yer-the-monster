Imports System.Runtime.CompilerServices

Public Module ItemTypes
    Friend Const Nihil = "Nihil"
    Friend Const BigShroom = "BigShroom"
    Friend ReadOnly Descriptors As IReadOnlyDictionary(Of String, ItemTypeDescriptor) =
        New Dictionary(Of String, ItemTypeDescriptor) From
        {
            {
                Nihil,
                New ItemTypeDescriptor(
                    "Nothing",
                    "!"c,
                    Hue.Black,
                    Array.Empty(Of String),
                    New Dictionary(Of String, Action(Of ICharacter, IItem)) From
                    {
                        {VerbTypes.Drop, AddressOf DropNothing},
                        {VerbTypes.Eat, AddressOf EatNothing}
                    })
            },
            {
                BigShroom,
                New ItemTypeDescriptor(
                    "Big Shroom",
                    "$"c,
                    Hue.Red,
                    {
                        TerrainTypes.Empty
                    },
                    New Dictionary(Of String, Action(Of ICharacter, IItem)) From
                    {
                        {VerbTypes.Eat, AddressOf EatBigShroom},
                        {VerbTypes.Drop, AddressOf StandardDrop}
                    })
            }
        }

    Private Sub DropNothing(character As ICharacter, item As IItem)
        character.AddMessage(
            "It is nothing....",
            "",
            "...",
            "",
            "If you dropped it, then what would you have?")
    End Sub

    Private Sub StandardDrop(character As ICharacter, item As IItem)
        If character.MapCell.HasItem Then
            character.AddMessage($"{character.Name} cannot drop {item.Name} here.")
            Return
        End If
        character.MapCell.Item = item
        character.RemoveItem(item)
    End Sub

    Private Sub EatNothing(character As ICharacter, item As IItem)
        character.AddMessage($"{character.Name} eats {item.Name}.")
        character.ApplyHunger(2)
    End Sub

    Private Sub EatBigShroom(character As ICharacter, item As IItem)
        character.SetSatiety(character.Satiety + 20)
        character.RemoveItem(item)
        character.AddMessage($"{character.Name} eats {item.Name}.")
        item.Recycle()
    End Sub

    Friend ReadOnly Property All As IEnumerable(Of String)
        Get
            Return Descriptors.Keys
        End Get
    End Property
    <Extension>
    Public Function ToItemTypeDescriptor(itemType As String) As ItemTypeDescriptor
        Return Descriptors(itemType)
    End Function
End Module
