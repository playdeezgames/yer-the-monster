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
                    New Dictionary(Of String, Action(Of ICharacter, IItem)))
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
                        {VerbTypes.Eat, AddressOf EatBigShroom}
                    })
            }
        }

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
